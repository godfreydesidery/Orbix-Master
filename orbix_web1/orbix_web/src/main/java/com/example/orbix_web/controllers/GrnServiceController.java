/**
 * 
 */
package com.example.orbix_web.controllers;

import java.time.LocalDate;
import java.util.Arrays;
import java.util.Date;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import javax.transaction.Transactional;
import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;
import org.thymeleaf.util.ArrayUtils;

import com.example.orbix_web.accessories.Formater;
import com.example.orbix_web.exceptions.InvalidEntryException;
import com.example.orbix_web.exceptions.InvalidOperationException;
import com.example.orbix_web.exceptions.MissingInformationException;
import com.example.orbix_web.exceptions.NotFoundException;
import com.example.orbix_web.exceptions.OperationFailedException;
import com.example.orbix_web.models.Day;
import com.example.orbix_web.models.Grn;
import com.example.orbix_web.models.GrnDetail;
import com.example.orbix_web.models.Item;
import com.example.orbix_web.models.Lpo;
import com.example.orbix_web.models.LpoDetail;
import com.example.orbix_web.models.StockCard;
import com.example.orbix_web.models.Supplier;
import com.example.orbix_web.models.User;
import com.example.orbix_web.repositories.DayRepository;
import com.example.orbix_web.repositories.GrnDetailRepository;
import com.example.orbix_web.repositories.GrnRepository;
import com.example.orbix_web.repositories.ItemRepository;
import com.example.orbix_web.repositories.LpoDetailRepository;
import com.example.orbix_web.repositories.LpoRepository;
import com.example.orbix_web.repositories.StockCardRepository;
import com.example.orbix_web.repositories.SupplierRepository;
import com.example.orbix_web.repositories.UserRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class GrnServiceController {
	
	@Autowired
    SupplierRepository supplierRepository;
	@Autowired
    GrnRepository grnRepository;
	@Autowired
    GrnDetailRepository grnDetailRepository;
	@Autowired
    LpoRepository lpoRepository;
	@Autowired
    LpoDetailRepository lpoDetailRepository;
	@Autowired
    UserRepository userRepository;
	@Autowired
    ItemRepository itemRepository;
	@Autowired
    StockCardRepository stockCardRepository;
	@Autowired
    DayRepository dayRepository;
	
    /**
     * Get All GRNs
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/grns")
    public List<Grn> getAllGrns(@RequestHeader("user_id") Long userId) {
        return grnRepository.findAll();
    }
    
    /**
     * Get all Grns visible
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/grns/visible")
    public List<Grn> getAllVisibleGrns(@RequestHeader("user_id") Long userId) {
    	List<String> statuses = Stream.of("PENDING", "APPROVED", "COMPLETED").collect(Collectors.toList());   	
        return grnRepository.findAllByStatus(statuses);
    }
    
    /**
     * Create a new GRN
     * @param grn
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.POST, value = "/grns/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional   
    public Grn createGrn(@Valid @RequestBody Grn grn, @RequestHeader("user_id") Long userId) {
    	LocalDate receivedDate = grn.getReceivedDate();	
    	String supplierCode = grn.getSupplier().getCode();
    	Optional<Supplier> supplier = supplierRepository.findByCode(supplierCode);
    	if(supplier.isPresent()) {
    		supplierRepository.save(supplier.get());
    		grn.setSupplier(supplier.get());
    	}else {
    		grn.setSupplier(null);
    	}    
    	Long receivedUserId = grn.getReceivedUser().getId();
    	Optional<User> receivedUser = userRepository.findById(receivedUserId);
    	if(receivedUser.isPresent()) {
    		userRepository.save(receivedUser.get());
    		grn.setReceivedUser(receivedUser.get());
    	}else {
    		grn.setReceivedUser(null);
    	}
    	String lpoNo = grn.getLpo().getNo();
    	Optional<Lpo> lpo = lpoRepository.findByNo(lpoNo);
    	if(lpo.isPresent()) {
    		lpo.get().setStatus("COMPLETED");
    		lpoRepository.save(lpo.get());
    		grn.setLpo(lpo.get());
    	}else {
    		grn.setLpo(null);  		
    	}
    	String serial;
    	Optional<Grn> serialGrn = grnRepository.findTopByOrderByIdDesc();
    	if(serialGrn.isPresent()) {
    		serial = String.valueOf(serialGrn.get().getId()+1);
    	}else {
    		serial = "1";
    	}   	
    	String grnNo = "GRN-"+Formater.formatNine(serial);
    	grn.setNo(grnNo); 
    	grn.setStatus("COMPLETED");
    	
    	grnRepository.saveAndFlush(grn);
    	
    	List<GrnDetail> grnDetails = grn.getGrnDetails();
    	for(GrnDetail grnDetail : grnDetails) {
    		grnDetail.setGrn(grn);
    		grnDetailRepository.saveAndFlush(grnDetail);
    	}   	
        return grn;
    }

    /**
     * Get a Single GRN
     * @param grnId
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/grns/get_by_id")
    public Grn getGrnById(@RequestParam(name = "id") Long grnId, @RequestHeader("user_id") Long userId) {
        return grnRepository.findById(grnId)
                .orElseThrow(() -> new NotFoundException("GRN not found"));
    }

    /**
     * Get a Single GRN by grn no
     * @param no
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/grns/get_by_no")
    public Grn getGrnByGrnNo(@RequestParam(name = "no") String no) {
        return grnRepository.findByNo(no)
                .orElseThrow(() -> new NotFoundException("GRN not found"));
    }
    // Update a GRN
    @RequestMapping(method = RequestMethod.PUT, value = "/grns/edit_by_id", produces = "text/html")
    public ResponseEntity<Object> updateGrn(@RequestParam(value = "id") Long grnId,
                                            @Valid @RequestBody Grn grnDetails, @RequestHeader("user_id") Long userId) {
    	Optional<Grn> grn = grnRepository.findById(grnId);
    	if(!grn.isPresent()) {
    		throw new NotFoundException("GRN not found");
    	}
    	grnRepository.save(grn.get());
		return new ResponseEntity<>("GRN updated", HttpStatus.OK);    	
    }    
}
