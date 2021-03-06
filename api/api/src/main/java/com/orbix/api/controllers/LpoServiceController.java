/**
 * 
 */
package com.orbix.api.controllers;

import java.time.LocalDate;
import java.util.Date;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import javax.persistence.PostPersist;
import javax.persistence.PrePersist;
import javax.swing.text.html.Option;
import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PatchMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
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
import com.orbix.api.models.Lpo;
import com.orbix.api.models.LpoDetail;
import com.orbix.api.models.Supplier;
import com.orbix.api.models.User;
import com.orbix.api.reports.NegativeStockReport;
import com.orbix.api.reports.PendingLPO;
import com.orbix.api.reports.PrintedLPO;
import com.orbix.api.repositories.DayRepository;
import com.orbix.api.repositories.LpoDetailRepository;
import com.orbix.api.repositories.LpoRepository;
import com.orbix.api.repositories.SupplierRepository;
import com.orbix.api.repositories.UserRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class LpoServiceController {

	@Autowired
    UserRepository userRepository;
    @Autowired
    LpoRepository lpoRepository;
    @Autowired
    LpoDetailRepository lpoDetailRepository;    
    @Autowired
    SupplierRepository supplierRepository;
    @Autowired
    DayRepository dayRepository;
    
    /**
     * Get All LPOs
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/lpos", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<Lpo> getAllLpos(@RequestHeader("user_id") Long userId) {
        return lpoRepository.findAll();
    }
 
    /**
     * Get All LPOs, visible
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/lpos/visible", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<Lpo> getAllVisibleLpos(@RequestHeader("user_id") Long userId) {
    	List<String> statuses = Stream.of("PENDING", "APPROVED", "PRINTED", "REPRINTED", "COMPLETED").collect(Collectors.toList());   	
        return lpoRepository.findAllByStatus(statuses);
    }
    
    /**
     * Get Lpo details by id
     * @param lpoId
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/lpo_details/get_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<LpoDetail> getAllLpoDetailsByLpo(@RequestParam(name = "id") Long lpoId, @RequestHeader("user_id") Long userId) {
    	Optional<Lpo> lpo = lpoRepository.findById(lpoId);
    	if(lpo.isPresent() == true) {
    		return lpoDetailRepository.findByLpo(lpo.get());
    	}
        return null;
    }
    
    /**
     * Create a new LPO
     * @param lpo
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.POST, value = "/lpos/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Lpo createLpo(@Valid @RequestBody Lpo lpo, @RequestHeader("user_id") Long userId) {
    	String supplierName = (lpo.getSupplier()).getName();
    	Optional<Supplier> supplier = supplierRepository.findByName(supplierName);
    	if(supplier.isPresent() == true) {
    		supplierRepository.save(supplier.get());
    		lpo.setSupplier(supplier.get());
    	}else {
    		lpo.setSupplier(null);
    	}    
    	Optional<User> createdUser;
    	createdUser = userRepository.findById(userId);
    	if(createdUser.isPresent() == true) {
    		userRepository.save(createdUser.get());
    		lpo.setCreatedUser(createdUser.get());
    	}else {
    		lpo.setCreatedUser(null);
    	}
    	lpo.setApprovedUser(null);
    	lpo.setCompletedUser(null);
    	    	
    	LocalDate bussinessDate =dayRepository.getCurrentBussinessDay().getBussinessDate();
    	if(!lpo.getIssueDate().isEqual(bussinessDate)) {
    		throw new InvalidEntryException("Date synchronization failed. Please contact the system administrator.");
    	}
    	
    	lpo.setIssueDate(bussinessDate);
    	String random = String.valueOf(Math.random()).replace(".", "") + String.valueOf(Math.random()).replace(".", "");
    	lpo.setNo(random); 
    	lpoRepository.saveAndFlush(lpo);
    	
    	lpo.setStatus("PENDING");
    	
    	String serial = lpo.getId().toString();
    	
    	String lpoNo = "LPO-"+Formater.formatNine(serial);
    	lpo.setNo(lpoNo); 
    	lpo.setDay(dayRepository.getCurrentBussinessDay());
    	lpoRepository.saveAndFlush(lpo);    	
        return lpoRepository.findById(lpo.getId()).get();
    }
    
    
    /**
     * Edit an LPO by id
     * @param lpo
     * @param id
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.PUT, value = "/lpos/edit_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public boolean updateLpo(@Valid @RequestBody Lpo lpo, @RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
    	Optional<Lpo> lpo_ = lpoRepository.findById(id);
    	if(!lpo_.isPresent()) {
    		throw new NotFoundException("LPO not found");
    	}
    	lpo_.get().setComment(lpo.getComment());
    	lpoRepository.saveAndFlush(lpo_.get());
    	return true;
    }
    
    /**
     * Create or edit lpo detail
     * @param lpoDetail
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.POST, value = "/lpo_details/new_or_edit", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public List<LpoDetail> createOrEditLpoDetail(@Valid @RequestBody LpoDetail lpoDetail, @RequestHeader("user_id") Long userId) {    	
    	if(lpoDetail.getCode().equals("")) {
    		throw new MissingInformationException("Product code required");
    	}
    	if(lpoDetail.getQty() <= 0) {
    		throw new InvalidEntryException("Invalid entry in qty, qty should be more than zero");
    	}
    	Optional<Lpo> lpo = lpoRepository.findById(lpoDetail.getLpo().getId());
    	if(!lpo.isPresent()) {
    		throw new MissingInformationException("LPO not selected");
    	}   	
    	String code = lpoDetail.getCode();
    	Optional<LpoDetail> lpoDetail_ = lpoDetailRepository.findByLpoAndCode(lpo.get(), code);  	
    	if(lpoDetail_.isPresent() == true) {    		
    		lpoDetail_.get().setDescription(lpoDetail.getDescription());
    		lpoDetail_.get().setQty(lpoDetail.getQty());
    		lpoDetail_.get().setCostPrice(lpoDetail.getCostPrice());
    		lpoDetail_.get().setPackSize(lpoDetail.getPackSize());
    		lpoDetailRepository.save(lpoDetail_.get());
    	}else {
    		lpoDetailRepository.save(lpoDetail);
    	}
    	return lpoDetailRepository.findByLpo(lpo.get());   	
    }
    
    /**
     * Get a Single LPO by id
     * @param lpoId
     * @param userId
     * @return
     */  
    @RequestMapping(method = RequestMethod.GET, value = "/lpos/get_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public Lpo getLpoById(@RequestParam(name = "id") Long lpoId, @RequestHeader("user_id") Long userId) {
        return lpoRepository.findById(lpoId)
                .orElseThrow(() -> new NotFoundException("LPO not found"));
    }
    
    /**
     * Get a single LPO by no
     * @param no
     * @param userId
     * @return
     */   
    @RequestMapping(method = RequestMethod.GET, value = "/lpos/get_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public Lpo getLpoByNo(@RequestParam(name = "no") String no, @RequestHeader("user_id") Long userId) {
        return lpoRepository.findByNo(no)
                .orElseThrow(() -> new NotFoundException("LPO not found"));
    }
    
    /**
     * Checks whether an LPO exists by id
     * @param id
     * @param userId
     * @return
     */   
    @RequestMapping(method = RequestMethod.GET, value = "/lpos/exist_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public boolean isLpoExistById(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
    	Optional<Lpo> lpo =lpoRepository.findById(id);
    	if(lpo.isPresent()) {
    		return true;
    	}else {
    		return false;
    	}    	 	
    }
    
    /**
     * Get the status of an LPO
     * @param lpoId
     * @param userId
     * @return
     */   
    @RequestMapping(method = RequestMethod.GET, value = "/lpos/get_status_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public String getLpoStatusById(@RequestParam(name = "id") Long lpoId, @RequestHeader("user_id") Long userId) {
    	Optional<Lpo> lpo = lpoRepository.findById(lpoId);
    	if(lpo.isPresent()) {
    		return lpo.get().getStatus();
    	}else {
    		return "";
    	}   	
    }
        
    /**
     * @param no
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/lpos/get_status_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public String getLpoStatusByNo(@RequestParam(name = "no") String no, @RequestHeader("user_id") Long userId) {
    	Optional<Lpo> lpo = lpoRepository.findByNo(no);
    	if(lpo.isPresent()) {
    		return lpo.get().getStatus();
    	}else {
    		return "";
    	}       	
    }
    
    /**
     * Approve LPO
     * @param lpoId
     * @param userId
     * @return
     */
    @Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/lpos/approve_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean approveLpo(@RequestParam(name = "id") Long lpoId, @RequestHeader("user_id") Long userId) {
		Optional<Lpo> lpo = lpoRepository.findById(lpoId);
		if(!lpo.isPresent()) {
			throw new NotFoundException("LPO not found");
		}
		if(lpo.get().getStatus().equals("PENDING")) {
			lpo.get().setStatus("APPROVED");
			lpoRepository.save(lpo.get());
			return true;
		}else {
			throw new InvalidOperationException("Could not approve, Only pending LPO can be approved");
		}    	
	}
    
    /**
     * Cancel LPO
     * @param lpoId
     * @param userId
     * @return
     */
    @Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/lpos/cancel_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean cancelLpo(@RequestParam(name = "id") Long lpoId, @RequestHeader("user_id") Long userId) {
    	Optional<Lpo> lpo = lpoRepository.findById(lpoId);
		if(!lpo.isPresent()) {
			throw new NotFoundException("LPO not found");
		}
		if(lpo.get().getStatus().equals("PENDING") || lpo.get().getStatus().equals("APPROVED")) {
			lpo.get().setStatus("CANCELED");
			lpoRepository.save(lpo.get());
			return true;
		}else {
			throw new InvalidOperationException("Could not cancel, Only pending LPO or approved LPO can be canceled");
		}        	
	}
    
    /**
     * Print LPO
     * @param lpoId
     * @param userId
     * @return
     */
    @Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/lpos/print_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean printLpo(@RequestParam(name = "id") Long lpoId, @RequestHeader("user_id") Long userId) {
    	Optional<Lpo> lpo = lpoRepository.findById(lpoId);
		if(!lpo.isPresent()) {
			throw new NotFoundException("LPO not found");
		}
		if(lpo.get().getStatus().equals("APPROVED")) {
			lpo.get().setStatus("PRINTED");
			lpoRepository.save(lpo.get());
			return true;
		}else if(lpo.get().getStatus().equals("PRINTED") || lpo.get().getStatus().equals("REPRINTED")) {
			lpo.get().setStatus("REPRINTED");
			lpoRepository.save(lpo.get());
			return true;
		}else {
			throw new InvalidOperationException("Could not print, Only printed or reprinted LPO can be printed");
		}       	
	}
    
    /**
     * Archive LPO
     * @param lpoId
     * @param userId
     * @return
     */
    @Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/lpos/archive_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean archiveLpo(@RequestParam(name = "id") Long lpoId, @RequestHeader("user_id") Long userId) {
    	Optional<Lpo> lpo = lpoRepository.findById(lpoId);
		if(!lpo.isPresent()) {
			throw new NotFoundException("LPO not found");
		}
		if(lpo.get().getStatus().equals("COMPLETED")) {
			lpo.get().setStatus("ARCHIVED");
			lpoRepository.save(lpo.get());
			return true;
		}else {
			throw new InvalidOperationException("Could not archive, Only completed LPO can be archived");
		}      	
	}
    
    @Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/lpos/archive_all", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean archiveAll(@RequestHeader("user_id") Long userId) {
    	List<Lpo> lpos = lpoRepository.findAllByStatus("COMPLETED");
    	for(Lpo lpo : lpos) {
    		lpo.setStatus("ARCHIVED");
			lpoRepository.save(lpo);
    	}
		return true;   	
	}
  

    /**
     * Delete an LPO
     * @param lpoId
     * @param userId
     * @return
     */
    @Transactional
    @RequestMapping(method = RequestMethod.DELETE, value = "/lpos/delete_by_id", produces = "text/html")
    public ResponseEntity<?> deleteLPO(@RequestParam(name = "id") Long lpoId, @RequestHeader("user_id") Long userId) {
    	Optional<Lpo> lpo = lpoRepository.findById(lpoId);
    	if(!lpo.isPresent()) {
    		throw new NotFoundException("LPO not found");
    	}
    	String status = lpo.get().getStatus();
    	if(status.equals("PRINTED") || status.equals("REPRINTED") || status.equals("COMPLETED")) {
    			throw new InvalidOperationException("Could not delete, LPO already printed. Only BLANK, PENDING, APPROVED  and ARCHIVED LPOs can be deleted.");
		}else {
			lpoRepository.delete(lpo.get());
			return new ResponseEntity<>("LPO deleted successifully.", HttpStatus.OK);
		}   		
    }
    
    /**
     * Delete a LPO detail
     * @param lpoDetailId
     * @return
     */
    @Transactional
    @RequestMapping(method = RequestMethod.DELETE, value = "/lpo_details/delete_by_id", produces = "text/html")
    public ResponseEntity<?> deleteLPODetail(@RequestParam(name = "id") Long lpoDetailId, @RequestHeader("user_id") Long userId) {
    	LpoDetail lpoDetail = lpoDetailRepository.findById(lpoDetailId)
                .orElseThrow(() -> new NotFoundException("LPO Detail not found"));
    	Optional<Lpo> lpo = lpoRepository.findById(lpoDetail.getLpo().getId());
    	if(!lpo.isPresent()) {
    		throw new NotFoundException("LPO not found");
    	}
    	String status = lpo.get().getStatus();
    	if(status.equals("PRINTED") || status.equals("REPRINTED") || status.equals("COMPLETED") || status.equals("ARCHIVED")) {
			throw new InvalidOperationException("Could not delete detail. Only BLANK and PENDING LPOs can be modified.");
    	}
    	lpoDetailRepository.delete(lpoDetail);
    	return new ResponseEntity<>("LPO detail deleted successifully.", HttpStatus.OK);  	 	
    }
    
    
    @Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/lpos/get_printed_lpos", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<PrintedLPO> getPrintedLPO(
    		@RequestParam(name = "from_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate fromDate,
    		@RequestParam(name = "to_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate toDate,
    		@RequestParam(name = "supplier_name") String supplierName,   		
    		@RequestHeader("user_id") Long userId) {
		List<PrintedLPO> report;
		
		return lpoRepository.getPrintedLPO(fromDate, toDate);
    }
    
    
    @Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/lpos/get_pending_lpos", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<PendingLPO> getPendingLPO(
    		@RequestParam(name = "from_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate fromDate,
    		@RequestParam(name = "to_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate toDate,
    		@RequestParam(name = "supplier_name") String supplierName,   		
    		@RequestHeader("user_id") Long userId) {
		List<PendingLPO> report;
		
		return lpoRepository.getPendingLPO(fromDate, toDate);
    }
 
}
