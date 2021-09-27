/**
 * 
 */
package com.orbix.api.controllers;

import java.util.List;
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
import com.orbix.api.exceptions.MissingInformationException;
import com.orbix.api.exceptions.NotFoundException;
import com.orbix.api.models.Personnel;
import com.orbix.api.repositories.DayRepository;
import com.orbix.api.repositories.PersonnelRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class PersonnelServiceController {
	@Autowired
	PersonnelRepository personnelRepository;
	@Autowired
    DayRepository dayRepository;
	
	@RequestMapping(method = RequestMethod.GET, value="/personnels", produces=MediaType.APPLICATION_JSON_VALUE)
    public List <Personnel> getAllPersonnels(@RequestHeader("user_id") Long userId) {
        return personnelRepository.findAll();
    }
	
	@RequestMapping(method = RequestMethod.GET, value="/personnels/get_personnel_by_roll_no", produces=MediaType.APPLICATION_JSON_VALUE)
    public Personnel  getPersonnelByRollNo(
    		@RequestHeader("user_id") Long userId,
    		@RequestParam("roll_no") String rollNo) {
        return personnelRepository.findByRollNo(rollNo);
    }
	
	@RequestMapping(method = RequestMethod.POST, value="/personnels/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Personnel createPersonnel(@Valid @RequestBody Personnel personnel, @RequestHeader("user_id") Long userId) throws Exception {
		if(personnel.getRollNo().isEmpty()
				|| personnel.getFirstName().isEmpty()
				|| personnel.getLastName().isEmpty()
				|| personnel.getAddress().isEmpty()
				|| personnel.getTelephone().isEmpty()) {
			throw new MissingInformationException("Required fields missing");
		}
		personnel.setRegistrationDay(dayRepository.getCurrentBussinessDay());
		
		String random = String.valueOf(Math.random()).replace(".", "") + String.valueOf(Math.random()).replace(".", "");
    	personnel.setRegNo(random); 
    	personnelRepository.saveAndFlush(personnel);
    	
    	String serial = personnel.getId().toString();
    	
    	String regNo = "PN-"+Formater.formatFive(serial);
    	personnel.setRegNo(regNo); 
    	
    	return personnelRepository.saveAndFlush(personnel);
    }
	
	@RequestMapping(method = RequestMethod.PUT, value="/personnels/edit", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public boolean editPersonnelById(
    		@Valid 
    		@RequestBody Personnel personnel, 
    		@RequestHeader("user_id") Long userId) throws Exception {
		if(personnel.getRollNo().isEmpty()
				|| personnel.getFirstName().isEmpty()
				|| personnel.getLastName().isEmpty()
				|| personnel.getAddress().isEmpty()
				|| personnel.getTelephone().isEmpty()) {
			throw new MissingInformationException("Required fields missing");
		}
		
		Personnel personnel_ = personnelRepository.findById(personnel.getId())
				.orElseThrow(() -> new NotFoundException("Record not found"));
		
		
		personnel_.setRollNo(personnel.getRollNo());
		personnel_.setFirstName(personnel.getFirstName());
		personnel_.setSecondName(personnel.getSecondName());
		personnel_.setLastName(personnel.getLastName());
		personnel_.setAddress(personnel.getAddress());
		personnel_.setTelephone(personnel.getTelephone());
		personnel_.setAddress(personnel.getAddress());
		personnel_.setEmail(personnel.getEmail());
		personnel_.setStatus(personnel.getStatus());
		
    	personnelRepository.saveAndFlush(personnel_);
    	
    	return true;
    }
}
