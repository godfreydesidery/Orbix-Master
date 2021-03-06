/**
 * 
 */
package com.example.orbix_web.controllers;

import java.time.LocalDate;
import java.util.Date;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.example.orbix_web.accessories.Formater;
import com.example.orbix_web.exceptions.InvalidEntryException;
import com.example.orbix_web.exceptions.InvalidOperationException;
import com.example.orbix_web.exceptions.MissingInformationException;
import com.example.orbix_web.exceptions.NotFoundException;
import com.example.orbix_web.models.CustomerCreditNote;
import com.example.orbix_web.models.Item;
import com.example.orbix_web.models.Lpo;
import com.example.orbix_web.models.LpoDetail;
import com.example.orbix_web.models.Rtv;
import com.example.orbix_web.models.RtvDetail;
import com.example.orbix_web.models.SalesInvoiceDetail;
import com.example.orbix_web.models.SalesReturnDetail;
import com.example.orbix_web.models.StockCard;
import com.example.orbix_web.models.Supplier;
import com.example.orbix_web.models.User;
import com.example.orbix_web.models.VendorCreditNote;
import com.example.orbix_web.repositories.ItemRepository;
import com.example.orbix_web.repositories.RtvDetailRepository;
import com.example.orbix_web.repositories.RtvRepository;
import com.example.orbix_web.repositories.StockCardRepository;
import com.example.orbix_web.repositories.SupplierRepository;
import com.example.orbix_web.repositories.UserRepository;
import com.example.orbix_web.repositories.VendorCreditNoteRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class RtvServiceController {
	
	@Autowired
    SupplierRepository supplierRepository;
	@Autowired
    RtvRepository rtvRepository;
	@Autowired
    RtvDetailRepository rtvDetailRepository;
	@Autowired
    ItemRepository itemRepository;
	@Autowired
    StockCardRepository stockCardRepository;
	@Autowired
    VendorCreditNoteRepository vendorCreditNoteRepository;
	@Autowired
    UserRepository userRepository;
			
	/**
	 * Get all Rtvs
	 * @param userId
	 * @return
	 */
	@RequestMapping(method = RequestMethod.GET, value = "/rtvs", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<Rtv> getAllRtvs(@RequestHeader("user_id") Long userId) {
        return rtvRepository.findAll();
    }
	
	/**
	 * Get all Rtvs (visible)
	 * @param userId
	 * @return
	 */
	@RequestMapping(method = RequestMethod.GET, value = "/rtvs/visible", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<Rtv> getAllVisibleRtvs(@RequestHeader("user_id") Long userId) {
    	List<String> statuses = Stream.of("PENDING", "APPROVED", "COMPLETED").collect(Collectors.toList());   	
        return rtvRepository.findAllByStatus(statuses);
    }
	
	/**
	 * Get rtv by id
	 * @param id
	 * @param userId
	 * @return
	 */
	@Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/rtvs/get_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    public Rtv getRtvById(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
        return rtvRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("RTV not found"));
    }
	
	/**
	 * Get Rtv by no
	 * @param no
	 * @param userId
	 * @return
	 */
	@Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/rtvs/get_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    public Rtv getRtvByNo(@RequestParam(name = "no") String no, @RequestHeader("user_id") Long userId) {
        return rtvRepository.findByNo(no)
                .orElseThrow(() -> new NotFoundException("RTV not found"));
    }
	
	/**
	 * Create new Rtv
	 * @param rtv
	 * @param userId
	 * @return
	 */
	@RequestMapping(method = RequestMethod.POST, value = "/rtvs/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Rtv createRtv(@Valid @RequestBody Rtv rtv, @RequestHeader("user_id") Long userId) {
    	LocalDate issueDate = rtv.getIssueDate();	
    	String supplierName = (rtv.getSupplier()).getName();
    	Optional<Supplier> supplier = supplierRepository.findByName(supplierName);
    	if(supplier.isPresent() == true) {
    		supplierRepository.save(supplier.get());
    		rtv.setSupplier(supplier.get());
    	}else {
    		throw new MissingInformationException("Supplier information required");    	
    	}    
    	Optional<User> createdUser;
    	Long createdUserId = (rtv.getCreatedUser().getId());
    	createdUser = userRepository.findById(createdUserId);
    	if(createdUser.isPresent() == true) {
    		userRepository.save(createdUser.get());
    		rtv.setCreatedUser(createdUser.get());
    	}else {
    		rtv.setCreatedUser(null);
    	}
    	rtv.setApprovedUser(null);
    	rtv.setCompletedUser(null);
    	    	
    	//Day day = dayRepository.findTopByOrderByIdDesc(); 	
    	LocalDate systemDate = LocalDate.now(); //day.getSystemDate();
//    	if(issueDate == null) {
//    		throw new MissingInformationException("Date required");
//    	}else if(!issueDate.equals(systemDate)) {
//    		throw new InvalidEntryException("Date does not match with System date");
//    	}  
    	
    	rtv.setIssueDate(systemDate);
    	String random = String.valueOf(Math.random()).replace(".", "") + String.valueOf(Math.random()).replace(".", "");
    	rtv.setNo(random); 
    	rtvRepository.saveAndFlush(rtv);
    	
    	rtv.setStatus("PENDING");
    	
    	String serial = rtv.getId().toString();
    	System.out.println(serial);

    	String rtvNo = "RTV-"+Formater.formatNine(serial);
    	rtv.setNo(rtvNo); 
    	rtvRepository.saveAndFlush(rtv);    	
        return rtvRepository.findById(rtv.getId()).get();
    }
	
	/**
	 * Update Rtv by id
	 * @param rtv
	 * @param id
	 * @param userId
	 * @return
	 */
	@RequestMapping(method = RequestMethod.PUT, value = "/rtvs/edit_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public boolean updateRtvById(@Valid @RequestBody Rtv rtv, @RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
		Optional<Rtv> rtv_ = rtvRepository.findById(id);
		if(rtv_.isPresent() == true) {
			rtvRepository.save(rtv);
			return true;
		}else {
			throw new NotFoundException("Could not update, RTV not found");
		}    	
    }
		
	/**
	 * Update Rtv by no
	 * @param rtv
	 * @param no
	 * @param userId
	 * @return
	 */
	@RequestMapping(method = RequestMethod.PUT, value = "/rtvs/edit_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional(noRollbackFor = Exception.class)
    public boolean updateRtvByNo(@Valid @RequestBody Rtv rtv, @RequestParam(name = "no") String no, @RequestHeader("user_id") Long userId) {
		Optional<Rtv> rtv_ = rtvRepository.findByNo(no);
		if(rtv_.isPresent() == true) {
			rtvRepository.save(rtv);
			return true;
		}else {
			throw new NotFoundException("Could not update, RTV not found");
		}    	
    }
	
	/**
	 * Delete Rtv by id
	 * @param id
	 * @param userId
	 * @return
	 */
	@Transactional
    @RequestMapping(method = RequestMethod.DELETE, value = "/rtv/delete_by_id", produces = "text/html")
    public ResponseEntity<?> deleteRtvById(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
		Optional<Rtv> rtv = rtvRepository.findById(id);
		if(rtv.isPresent() == true) {
			String status = rtv.get().getStatus();
			if(status.equals("APPROVED") || status.equals("COMPLETED")) {
    			throw new InvalidOperationException("Could not delete an approved or completed RTV");
    		}
		}else {
			throw new NotFoundException("RTV document could not be found");
		}
		rtvRepository.deleteById(id);
		return new ResponseEntity<>("RTV deleted successifully.", HttpStatus.OK);
    }
	
	/**
	 * @param id
	 * @param userId
	 * @return
	 */
	@Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/rtvs/get_status_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    public String getRtvStatusById(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
		Optional<Rtv> rtv = rtvRepository.findById(id);
		if(rtv.isPresent() == false) {
			return "";
		}
		return rtv.get().getStatus();  	
    }
	
	/**
	 * Get a single rtv detail by rtv id
	 * @param id
	 * @param userId
	 * @return
	 */
	@Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/rtv_details/get_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    public RtvDetail getRtvDetailById(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
        return rtvDetailRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("RTV not found"));
    }
	
	/**
	 * Create a new rtv detail
	 * @param rtvDetail
	 * @param userId
	 * @return
	 */
	@RequestMapping(method = RequestMethod.POST, value = "/rtv_details/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public RtvDetail createRtvDetail(@Valid @RequestBody RtvDetail rtvDetail, @RequestHeader("user_id") Long userId) {
		Optional<Rtv> rtv = rtvRepository.findById(rtvDetail.getRtv().getId());		
		if(rtv.isPresent() == false) {
			throw new NotFoundException("RTV document not found");
		}
		if(rtv.get().getStatus().equals("PENDING") == false) {
			throw new InvalidOperationException("Can not add product, RTV not a pending document");
		}
		rtvDetail.setRtv(rtv.get());
		return rtvDetailRepository.save(rtvDetail);		
    }
	
	/**
	 * Update rtv detail by id
	 * @param rtvDetail
	 * @param id
	 * @param userId
	 * @return
	 */
	@RequestMapping(method = RequestMethod.PUT, value = "/rtv_details/edit_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional()
    public RtvDetail updateRtvDetailById(@Valid @RequestBody RtvDetail rtvDetail,
    		@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
		Optional<Rtv> rtv = rtvRepository.findById(rtvDetail.getRtv().getId());		
		if(rtv.isPresent() == false) {
			throw new NotFoundException("RTV document not found");
		}
		if(rtv.get().getStatus().equals("PENDING") == false) {
			throw new InvalidOperationException("Can not add product, RTV not a pending document");
		}
		Optional<RtvDetail> rtvDetail_ = rtvDetailRepository.findById(id);
		if(rtvDetail_.isPresent() == false) {
			throw new NotFoundException("RTV detail not found");
		}
		return rtvDetailRepository.save(rtvDetail);		
    }
	
	/**
	 * Delete a single rtv detail by id
	 * @param id
	 * @param userId
	 * @return
	 */
	@Transactional
    @RequestMapping(method = RequestMethod.DELETE, value = "/rtv_details/delete_by_id", produces = "text/html")
    public ResponseEntity<?> deleteRtvDetailById(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
		Optional<RtvDetail> rtvDetail = rtvDetailRepository.findById(id);
		if(!rtvDetail.isPresent()) {
			throw new NotFoundException("RTV document could not be found");			
		}else {
			Optional<Rtv> rtv = rtvRepository.findById(rtvDetail.get().getRtv().getId());
			if(rtv.isPresent() == true) {
				if(!rtv.get().getStatus().equals("PENDING")) {
					throw new InvalidOperationException("Can not remove product, RTV not a pending document");
				}
			}else {
				throw new NotFoundException("RTV document not found");
			}			
		}
		rtvDetailRepository.deleteById(id);
		return new ResponseEntity<>("RTV Detail deleted successifully.", HttpStatus.OK);
    }
	
	/**
	 * Approve RTV
	 * @param rtvId
	 * @param userId
	 * @return
	 */
	@Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/rtvs/approve_by_id")
    public ResponseEntity<Object> approveRtv(@RequestParam(name = "id") Long rtvId, @RequestHeader("user_id") Long userId){
    	Rtv rtv = rtvRepository.findById(rtvId)
    			.orElseThrow(() -> new NotFoundException("RTV not found"));
		String status = rtv.getStatus();
		if(!status.equals("PENDING")) {
			throw new InvalidOperationException("Could not approve RTV. Only Pending RTV can be approved.");
		}
		rtv.setStatus("APPROVED");
		rtvRepository.saveAndFlush(rtv);
		return new ResponseEntity<>("RTV approved", HttpStatus.OK);		
    }
    
	/**
	 * Cancel RTV
	 * @param rtvId
	 * @param userId
	 * @return
	 */
	@Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/rtvs/cancel_by_id")
    public ResponseEntity<Object> cancelRtv(@RequestParam(value = "id") Long rtvId, @RequestHeader("user_id") Long userId){
		Rtv rtv = rtvRepository.findById(rtvId)
    			.orElseThrow(() -> new NotFoundException("RTV not found"));
		String status = rtv.getStatus();
		if(!(status.equals("PENDING") || status.equals("APPROVED"))) {
			throw new InvalidOperationException("Could not cancel RTV. Only Pending or approved RTV can be canceled.");
		}
		rtv.setStatus("CANCELED");
		rtvRepository.saveAndFlush(rtv);
		return new ResponseEntity<>("RTV canceled", HttpStatus.OK);		
    	
    }                                           
}
