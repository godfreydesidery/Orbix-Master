/**
 * 
 */
package com.orbix.api.controllers;

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
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.orbix.api.accessories.Formater;
import com.orbix.api.exceptions.InvalidOperationException;
import com.orbix.api.exceptions.MissingInformationException;
import com.orbix.api.exceptions.NotFoundException;
import com.orbix.api.models.DamagedProduct;
import com.orbix.api.models.Day;
import com.orbix.api.models.PackingList;
import com.orbix.api.models.PackingListDetail;
import com.orbix.api.models.Product;
import com.orbix.api.models.SalesPerson;
import com.orbix.api.models.StockCard;
import com.orbix.api.models.User;
import com.orbix.api.repositories.DamagedProductRepository;
import com.orbix.api.repositories.DayRepository;
import com.orbix.api.repositories.PackingListDetailRepository;
import com.orbix.api.repositories.PackingListRepository;
import com.orbix.api.repositories.PersonnelRepository;
import com.orbix.api.repositories.ProductRepository;
import com.orbix.api.repositories.SalesPersonRepository;
import com.orbix.api.repositories.StockCardRepository;
import com.orbix.api.repositories.UserRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class PackingListServiceController {
	@Autowired
    PackingListRepository packingListRepository;
	@Autowired
    PackingListDetailRepository packingListDetailRepository;
	@Autowired
    UserRepository userRepository;
	@Autowired
    DayRepository dayRepository;
	@Autowired
    PersonnelRepository personnelRepository;
	@Autowired
    SalesPersonRepository salesPersonRepository;
	@Autowired
    ProductRepository productRepository;
	@Autowired
    StockCardRepository stockCardRepository;
	@Autowired
    DamagedProductRepository damagedProductRepository;
	
	
	@RequestMapping(method = RequestMethod.GET, value = "/packing_lists", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<PackingList> getAllPackingLists(
    		@RequestHeader("user_id") Long userId) {
        return packingListRepository.findAll();
    }
	
	@RequestMapping(method = RequestMethod.GET, value = "/packing_lists/visible", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<PackingList> getAllVisiblePackingLists(
    		@RequestHeader("user_id") Long userId) {
    	List<String> statuses = Stream.of("PENDING", "APPROVED", "PRINTED", "REPRINTED", "COMPLETED").collect(Collectors.toList());   	
        return packingListRepository.findAllByStatus(statuses);
    }
	
	@RequestMapping(method = RequestMethod.GET, value = "/packing_lists/get_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public PackingList getPackingListByNo(
    		@RequestParam(name = "no") String no, 
    		@RequestHeader("user_id") Long userId) {
        return packingListRepository.findByNo(no)
                .orElseThrow(() -> new NotFoundException("Packing List not found"));
    }
	
	@RequestMapping(method = RequestMethod.POST, value = "/packing_lists/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public PackingList createPackingList(
    		@Valid 
    		@RequestBody PackingList packingList, 
    		@RequestHeader("user_id") Long userId) {    	   
    	User user = userRepository.findById(userId)
    			.orElseThrow(() -> new NotFoundException("User not found"));
    	SalesPerson salesPerson = salesPersonRepository
    			.findByPersonnel(
    					personnelRepository
    					.findByName(packingList.getSalesPerson().getPersonnel().getName()))
    			.orElseThrow(() -> new NotFoundException("Sales Person not found"));
    	
    	Day day = dayRepository.getCurrentBussinessDay();
    	
    	
    	packingList.setCreatedDay(day);
    	packingList.setCreatedByUser(user);
    	packingList.setSalesPerson(salesPerson);
    	packingList.setStatus("PENDING");
    	
    	packingList.setApprovedByUser(null);
    	packingList.setPrintedByUser(null);
    	packingList.setIssuedByUser(null);
    	packingList.setCompletedByUser(null);
    	
    	packingList.setApprovedDay(null);
    	packingList.setPrintedDay(null);
    	packingList.setIssuedDay(null);
    	packingList.setCompletedDay(null);
    	
    	String random = String.valueOf(Math.random()).replace(".", "") + String.valueOf(Math.random()).replace(".", "");
    	packingList.setNo(random); 
    	packingListRepository.saveAndFlush(packingList);
    	
    	String serial = packingList.getId().toString();
    	
    	String plNo = "PL-"+Formater.formatNine(serial);
    	packingList.setNo(plNo); 
    	
    	packingListRepository.saveAndFlush(packingList);    	
        return packingListRepository.findById(packingList.getId()).get();
    }
	
	@Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/packing_lists/approve_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean approvePackingList(
    		@RequestParam(name = "id") Long packingListId, 
    		@RequestHeader("user_id") Long userId) {
		Optional<PackingList> packingList = packingListRepository.findById(packingListId);
		if(!packingList.isPresent()) {
			throw new NotFoundException("Packing List not found");
		}
		User user = userRepository.findById(userId)
    			.orElseThrow(() -> new NotFoundException("User not found")); 	
    	Day day = dayRepository.getCurrentBussinessDay();
		if(packingList.get().getStatus().equals("PENDING")) {
			packingList.get().setStatus("APPROVED");
			packingList.get().setApprovedByUser(user);
			packingList.get().setApprovedDay(day);
			packingListRepository.save(packingList.get());
			return true;
		}else {
			throw new InvalidOperationException("Could not approve, Only pending packing list can be approved");
		}    	
	}
	
	@Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/packing_lists/print_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean printPackingList(
    		@RequestParam(name = "id") Long packingListId, 
    		@RequestHeader("user_id") Long userId) {
		Optional<PackingList> packingList = packingListRepository.findById(packingListId);
		if(!packingList.isPresent()) {
			throw new NotFoundException("Packing List not found");
		}
		User user = userRepository.findById(userId)
    			.orElseThrow(() -> new NotFoundException("User not found")); 	
    	Day day = dayRepository.getCurrentBussinessDay();
		if(packingList.get().getStatus().equals("APPROVED")) {
			packingList.get().setStatus("PRINTED");
			packingList.get().setApprovedByUser(user);
			packingList.get().setApprovedDay(day);
			packingListRepository.save(packingList.get());
			
			
			List <PackingListDetail> details = packingListDetailRepository.findByPackingList(packingList.get());
			
			for(PackingListDetail detail : details) {
				/**
				 * Deduct from stock
				 */
				
				/**
				 * Create stock card
				 */
				
				Product product;
	    		StockCard stockCard;
	    		
	    		product = productRepository.findByCode(detail.getCode()).get();
	    		product.setStock(product.getStock() - detail.getTotalPacked());
	    		productRepository.saveAndFlush(product);
	    		
	    		stockCard = new StockCard();
	    		product = productRepository.findByCode(detail.getCode()).get();
	    		stockCard.setCode(detail.getCode());
	    		stockCard.setDescription(detail.getDescription());
	    		stockCard.setDay(dayRepository.getCurrentBussinessDay());
	    		stockCard.setCreatedOn(new Date());
	    		stockCard.setQtyIn(0);
	    		stockCard.setQtyOut(detail.getTotalPacked());
	    		stockCard.setBalance(product.getStock());
	    		stockCard.setReference("Sales Issued to PL# "+packingList.get().getNo());
	    		stockCardRepository.saveAndFlush(stockCard);
	    		
			}
			
			return true;
		}else {
			throw new InvalidOperationException("Could not print, Only approved packing list can be printed");
		}    	
	}
	
	@Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/packing_lists/complete_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean completePackingList(
    		@RequestParam(name = "id") Long packingListId, 
    		@RequestHeader("user_id") Long userId) {
		Optional<PackingList> packingList = packingListRepository.findById(packingListId);
		if(!packingList.isPresent()) {
			throw new NotFoundException("Packing List not found");
		}
		User user = userRepository.findById(userId)
    			.orElseThrow(() -> new NotFoundException("User not found")); 	
    	Day day = dayRepository.getCurrentBussinessDay();
		if(packingList.get().getStatus().equals("PRINTED")) {
			packingList.get().setStatus("COMPLETED");
			packingList.get().setCompletedByUser(user);
			packingList.get().setCompletedDay(day);
			packingListRepository.save(packingList.get());
			
			
			List <PackingListDetail> details = packingListDetailRepository.findByPackingList(packingList.get());
			
			for(PackingListDetail detail : details) {
				/**
				 * Return returned to stock
				 * Create stock card
				 * Register sale
				 * Register damage
				 */
				
				Product product;
	    		StockCard stockCard;
	    		DamagedProduct damagedProduct;
	    		if(detail.getReturned() > 0) {	 
	    			product = productRepository.findByCode(detail.getCode()).get();
	    			product.setStock(product.getStock() + detail.getReturned());
	    			productRepository.saveAndFlush(product);
	    		}
	    	
	    		if(detail.getReturned() > 0) {	    			
		    		stockCard = new StockCard();
		    		product = productRepository.findByCode(detail.getCode()).get();
		    		stockCard.setCode(detail.getCode());
		    		stockCard.setDescription(detail.getDescription());
		    		stockCard.setDay(dayRepository.getCurrentBussinessDay());
		    		stockCard.setCreatedOn(new Date());
		    		stockCard.setQtyIn(detail.getReturned());
		    		stockCard.setQtyOut(0);
		    		stockCard.setBalance(product.getStock());
		    		stockCard.setReference("Returned from PL# "+packingList.get().getNo());
		    		stockCardRepository.saveAndFlush(stockCard);
	    		}
	    		
	    		if(detail.getDamaged() > 0) {
	    			damagedProduct = new DamagedProduct();
	    			damagedProduct.setCode(detail.getCode());
	    			damagedProduct.setDescription(detail.getDescription());
	    			damagedProduct.setPrice(detail.getSellingPriceVatIncl());
	    			damagedProduct.setQty(detail.getDamaged());
	    			damagedProduct.setSummary("Damaged in PL# "+packingList.get().getNo());
	    			damagedProductRepository.saveAndFlush(damagedProduct);
	    		}
	    		
			}
			
			return true;
		}else {
			throw new InvalidOperationException("Could not print, Only approved packing list can be printed");
		}    	
	}
	
	@Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/packing_lists/cancel_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean cancelPackingList(
    		@RequestParam(name = "id") Long packingListId, 
    		@RequestHeader("user_id") Long userId) {
    	PackingList packingList = packingListRepository.findById(packingListId)
    			.orElseThrow(() -> new NotFoundException("Packing List not found"));
		
		if(packingList.getStatus().equals("PENDING") || packingList.getStatus().equals("APPROVED")) {
			packingList.setStatus("CANCELED");
			packingListRepository.save(packingList);
			return true;
		}else {
			throw new InvalidOperationException("Could not cancel, Only pending or approved Packing List can be canceled");
		}        	
	}
	
	@Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/packing_lists/archive_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean archivePackingList(
    		@RequestParam(name = "id") Long packingListId, 
    		@RequestHeader("user_id") Long userId) {
    	PackingList packingList = packingListRepository.findById(packingListId)
    			.orElseThrow(() -> new NotFoundException("Packing List not found"));
		
		if(packingList.getStatus().equals("COMPLETED") && packingList.getDeficit() == 0) {
			packingList.setStatus("ARCHIVED");
			packingListRepository.save(packingList);
			return true;
		}else {
			throw new InvalidOperationException("Could not archive, Only completed and debt free Packing List can be canceled");
		}        	
	}
	
	@Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/packing_lists/archive_all", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean archiveAllPackingList( 
    		@RequestHeader("user_id") Long userId) {
		List<String> statuses = Stream.of("COMPLETED").collect(Collectors.toList());
		List <PackingList> packingLists = packingListRepository.findAllByStatus(statuses);
		
		for(PackingList list : packingLists) {
			try {				
				if(list.getStatus().equals("COMPLETED") && list.getDeficit() == 0) {
					list.setStatus("ARCHIVED");
					packingListRepository.save(list);					
				}			
			}catch(Exception e) {
				System.out.println("Could not archive");
			}			
		}
		return true;
	}
	
	@RequestMapping(method = RequestMethod.GET, value = "/packing_lists/get_status_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public String getPackingListStatusById(
    		@RequestParam(name = "id") Long id, 
    		@RequestHeader("user_id") Long userId) {
    	Optional<PackingList> packingList = packingListRepository.findById(id);
    	if(packingList.isPresent()) {
    		return packingList.get().getStatus();
    	}else {
    		return "";
    	}       	
    }
	
	@RequestMapping(method = RequestMethod.GET, value = "/packing_lists/get_status_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public String getPackingListStatusByNo(
    		@RequestParam(name = "no") String no, 
    		@RequestHeader("user_id") Long userId) {
    	Optional<PackingList> packingList = packingListRepository.findByNo(no);
    	if(packingList.isPresent()) {
    		return packingList.get().getStatus();
    	}else {
    		return "";
    	}       	
    }
	
	
	
	@RequestMapping(method = RequestMethod.GET, value = "/packing_list_details/get_by_packing_list_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public List <PackingListDetail> getPackingListByPackingListId(
    		@RequestParam(name = "id") Long id, 
    		@RequestHeader("user_id") Long userId) {
		PackingList packingList = packingListRepository.findById(id)
				.orElseThrow(() -> new NotFoundException("Packing List not found"));
        return packingListDetailRepository.findByPackingList(packingList);
    }
	
	@RequestMapping(method = RequestMethod.GET, value = "/packing_list_details/get_by_packing_list_no", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public List <PackingListDetail> getPackingListByPackingListNo(
    		@RequestParam(name = "no") String no, 
    		@RequestHeader("user_id") Long userId) {
		PackingList packingList = packingListRepository.findByNo(no)
				.orElseThrow(() -> new NotFoundException("Packing List not found"));
        return packingListDetailRepository.findByPackingList(packingList);
    }
	
	@RequestMapping(method = RequestMethod.POST, value = "/packing_list_details/new_or_edit", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public List<PackingListDetail> createOrEditPackingListDetail(
    		@Valid 
    		@RequestBody PackingListDetail packingListDetail, 
    		@RequestHeader("user_id") Long userId) {    	
    	if(packingListDetail.getCode().equals("")) {
    		throw new MissingInformationException("Product code required");
    	}
    	if(packingListDetail.getDescription().equals("")) {
    		throw new MissingInformationException("Product description required");
    	}
    	
    	Optional<PackingList> packingList = packingListRepository.findById(packingListDetail.getPackingList().getId());
    	if(!packingList.isPresent()) {
    		throw new MissingInformationException("Packing List not selected");
    	}   	
    	String code = packingListDetail.getCode();
    	Optional<PackingListDetail> detail_ = packingListDetailRepository.findByPackingListAndCode(packingList.get(), code);  	
    	if(detail_.isPresent() == true) {    		    		
    		if(packingList.get().getStatus().equals("PENDING")) {
    			detail_.get().setDescription(packingListDetail.getDescription());
    			if(packingListDetail.getPreviousReturns() >= 0 && packingListDetail.getIssued() >=0) {
	    			if(packingListDetail.getTotalPacked() == (packingListDetail.getPreviousReturns() + packingListDetail.getIssued()) && packingListDetail.getTotalPacked() > 0) {	    				
	    				detail_.get().setPreviousReturns(packingListDetail.getPreviousReturns());
	    				detail_.get().setIssued(packingListDetail.getIssued());
	    				detail_.get().setTotalPacked(packingListDetail.getTotalPacked());
	    				detail_.get().setSold(0);
	    				detail_.get().setReturned(0);
	    				detail_.get().setDamaged(0);
	    			}else {
	    				throw new InvalidOperationException("Invalid entry in returns and issued quantities");
	    			}
	    		}else {
	    			throw new InvalidOperationException("Invalid entry in returns and issued quantities");
	    		}
    		}
    		
    		if(packingList.get().getStatus().equals("PRINTED")) {
    			if(packingListDetail.getSold() >= 0 && packingListDetail.getReturned() >=0 && packingListDetail.getDamaged() >=0) {
	    			if(packingListDetail.getTotalPacked() == (packingListDetail.getSold() + packingListDetail.getReturned() + packingListDetail.getDamaged()) && packingListDetail.getTotalPacked() > 0) {	    				
	    				detail_.get().setSold(packingListDetail.getSold());
	    				detail_.get().setReturned(packingListDetail.getReturned());
	    				detail_.get().setDamaged(packingListDetail.getDamaged());
	    			}else {
	    				throw new InvalidOperationException("Invalid entry in returns and issued quantities");
	    			}
	    		}else {
	    			throw new InvalidOperationException("Invalid entry in returns and issued quantities");
	    		}
    		}
    		
    		packingListDetailRepository.save(detail_.get());
    	}else {
    		PackingListDetail detail= new PackingListDetail();
    		if(packingList.get().getStatus().equals("PENDING")) {
    			detail.setDescription(packingListDetail.getDescription());
    			if(packingListDetail.getPreviousReturns() >= 0 && packingListDetail.getIssued() >=0) {
	    			if(packingListDetail.getTotalPacked() == (packingListDetail.getPreviousReturns() + packingListDetail.getIssued()) && packingListDetail.getTotalPacked() > 0) {
	    				detail.setPackingList(packingList.get());
	    				detail.setBarcode(packingListDetail.getBarcode());
	    				detail.setCode(packingListDetail.getCode());
	    				detail.setDescription(packingListDetail.getDescription());
	    				detail.setCostPriceVatIncl(packingListDetail.getCostPriceVatIncl());
	    				detail.setSellingPriceVatIncl(packingListDetail.getSellingPriceVatIncl());
	    				detail.setPreviousReturns(packingListDetail.getPreviousReturns());
	    				detail.setIssued(packingListDetail.getIssued());
	    				detail.setTotalPacked(packingListDetail.getTotalPacked());
	    				detail.setSold(0);
	    				detail.setReturned(0);
	    				detail.setDamaged(0);
	    			}else {
	    				throw new InvalidOperationException("Invalid entry in returns and issued quantities");
	    			}
	    		}else {
	    			throw new InvalidOperationException("Invalid entry in returns and issued quantities");
	    		}
    			packingListDetailRepository.save(detail);
    		}
    
    	}
    	return packingListDetailRepository.findByPackingList(packingList.get());   	
    }
	
	
	@Transactional
    @RequestMapping(method = RequestMethod.DELETE, value = "/packing_list_details/delete_by_id", produces = "text/html")
    public ResponseEntity<?> deletePackingListDetail(
    		@RequestParam(name = "id") Long packingListDetailId, 
    		@RequestHeader("user_id") Long userId) {
    	PackingListDetail packingListDetail = packingListDetailRepository.findById(packingListDetailId)
                .orElseThrow(() -> new NotFoundException("Packing List Detail not found"));
    	Optional<PackingList> packingList = packingListRepository.findById(packingListDetail.getPackingList().getId());
    	if(!packingList.isPresent()) {
    		throw new NotFoundException("Packing List not found");
    	}
    	String status = packingList.get().getStatus();
    	if(status.equals("PRINTED") || status.equals("REPRINTED") || status.equals("COMPLETED") || status.equals("ARCHIVED")) {
			throw new InvalidOperationException("Could not delete detail. Only BLANK and PENDING Packing Lists can be modified.");
    	}
    	packingListDetailRepository.delete(packingListDetail);
    	return new ResponseEntity<>("Packing List detail deleted successifully.", HttpStatus.OK);  	 	
    }
	
}
