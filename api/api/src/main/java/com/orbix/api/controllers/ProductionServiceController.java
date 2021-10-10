/**
 * 
 */
package com.orbix.api.controllers;

import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.orbix.api.accessories.Formater;
import com.orbix.api.exceptions.InvalidEntryException;
import com.orbix.api.exceptions.InvalidOperationException;
import com.orbix.api.exceptions.MissingInformationException;
import com.orbix.api.exceptions.NotFoundException;
import com.orbix.api.models.CustomProduction;
import com.orbix.api.models.CustomProductionMaterial;
import com.orbix.api.models.Day;
import com.orbix.api.models.Material;
import com.orbix.api.models.PackingList;
import com.orbix.api.models.ProductConversion;
import com.orbix.api.models.ProductConversionInitial;
import com.orbix.api.models.SalesPerson;
import com.orbix.api.models.User;
import com.orbix.api.repositories.CustomProductionMaterialRepository;
import com.orbix.api.repositories.CustomProductionRepository;
import com.orbix.api.repositories.DayRepository;
import com.orbix.api.repositories.UserRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class ProductionServiceController {
	@Autowired
	CustomProductionRepository customProductionRepository;
	@Autowired
	CustomProductionMaterialRepository customProductionMaterialRepository;
	@Autowired
	UserRepository userRepository;
	@Autowired
	DayRepository dayRepository;
	
	
	@RequestMapping(method = RequestMethod.GET, value="/custom_productions", produces=MediaType.APPLICATION_JSON_VALUE)
    public List <CustomProduction> getAllCustomProductions(
    		@RequestHeader("user_id") Long userId) {
        return customProductionRepository.findAll();
    }
	
	@RequestMapping(method = RequestMethod.GET, value = "/custom_productions/visible", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<CustomProduction> getAllVisibleCustomProductions(
    		@RequestHeader("user_id") Long userId) {
    	List<String> statuses = Stream.of("PENDING", "APPROVED", "PRINTED", "REPRINTED", "COMPLETED").collect(Collectors.toList());   	
        return customProductionRepository.findAllByStatus(statuses);
    }
	
	@RequestMapping(method = RequestMethod.GET, value = "/custom_productions/get_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public CustomProduction getCustomProductionByNo(
    		@RequestParam(name = "no") String no, 
    		@RequestHeader("user_id") Long userId) {
        return customProductionRepository.findByNo(no)
                .orElseThrow(() -> new NotFoundException("Record not found"));
    }
	
	
	@RequestMapping(method = RequestMethod.POST, value = "/custom_productions/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public CustomProduction createCustomProduction(
    		@Valid 
    		@RequestBody CustomProduction customProduction, 
    		@RequestHeader("user_id") Long userId) {    	   
    	User user = userRepository.findById(userId)
    			.orElseThrow(() -> new NotFoundException("User not found"));
    	
    	Day day = dayRepository.getCurrentBussinessDay();
    	
    	if(customProduction.getProductName().isEmpty()) {
    		throw new MissingInformationException("Product name required");
    	}
    	if(customProduction.getBatchSize() <= 0) {
    		throw new InvalidEntryException("Invalid batch size");
    	}
    	if(customProduction.getUom().isEmpty()) {
    		throw new MissingInformationException("UOM required");
    	}
    	
    	
    	customProduction.setCreatedDay(day);
    	customProduction.setCreatedByUser(user);
    	customProduction.setStatus("PENDING");
    	
    	customProduction.setApprovedByUser(null);
    	customProduction.setCompletedByUser(null);
    	
    	customProduction.setApprovedDay(null);   	
    	customProduction.setCompletedDay(null);
    	
    	String random = String.valueOf(Math.random()).replace(".", "") + String.valueOf(Math.random()).replace(".", "");
    	customProduction.setNo(random); 
    	customProductionRepository.saveAndFlush(customProduction);
    	
    	String serial = customProduction.getId().toString();
    	
    	String prNo = "CP-"+Formater.formatNine(serial);
    	customProduction.setNo(prNo); 
    	
    	customProductionRepository.saveAndFlush(customProduction);    	
        return customProductionRepository.findById(customProduction.getId()).get();
    }
	
	@Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/custom_productions/approve_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean approveCustomProduction(
    		@RequestParam(name = "id") Long customProductionId, 
    		@RequestHeader("user_id") Long userId) {
		Optional<CustomProduction> customProduction = customProductionRepository.findById(customProductionId);
		if(!customProduction.isPresent()) {
			throw new NotFoundException("Record not found");
		}
		User user = userRepository.findById(userId)
    			.orElseThrow(() -> new NotFoundException("User not found")); 	
    	Day day = dayRepository.getCurrentBussinessDay();
		if(customProduction.get().getStatus().equals("PENDING")) {
			customProduction.get().setStatus("APPROVED");
			customProduction.get().setApprovedByUser(user);
			customProduction.get().setApprovedDay(day);
			customProductionRepository.save(customProduction.get());
			return true;
		}else {
			throw new InvalidOperationException("Could not approve, Only pending custom productions can be approved");
		}    	
	}
	
	@RequestMapping(method = RequestMethod.GET, value = "/custom_productions/get_status_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public String getStatusById(
    		@RequestParam(name = "id") Long id, 
    		@RequestHeader("user_id") Long userId) {
    	Optional<CustomProduction> customProduction = customProductionRepository.findById(id);
    	if(customProduction.isPresent()) {
    		return customProduction.get().getStatus();
    	}else {
    		return "";
    	}       	
    }
	
	@RequestMapping(method = RequestMethod.GET, value = "/custom_productions/get_status_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public String getStatusByNo(
    		@RequestParam(name = "no") String no, 
    		@RequestHeader("user_id") Long userId) {
    	Optional<CustomProduction> customProduction = customProductionRepository.findByNo(no);
    	if(customProduction.isPresent()) {
    		return customProduction.get().getStatus();
    	}else {
    		return "";
    	}       	
    }
	
	@RequestMapping(method = RequestMethod.GET, value="/custom_productions/get_materials_by_production_id", produces=MediaType.APPLICATION_JSON_VALUE)
    public List <CustomProductionMaterial> getProductionMaterials(
    		@RequestParam(name = "id") Long id, 
    		@RequestHeader("user_id") Long userId) {
    	Optional<CustomProduction> customProduction = customProductionRepository.findById(id);
    	if(customProduction.isPresent()) {
    		return customProductionMaterialRepository.findAllByCustomProduction(customProduction.get());
    	}
    	return null;        
    }
	
}
