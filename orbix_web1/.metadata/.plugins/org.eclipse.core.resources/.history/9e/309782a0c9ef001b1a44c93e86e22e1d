/**
 * 
 */
package com.example.orbix_web.controllers;

import java.time.LocalDate;
import java.util.List;
import java.util.Optional;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
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

import com.example.orbix_web.accessories.Formater;
import com.example.orbix_web.exceptions.NotFoundException;
import com.example.orbix_web.exceptions.ResourceNotFoundException;
import com.example.orbix_web.models.CorporateCustomer;
import com.example.orbix_web.models.Receipt;
import com.example.orbix_web.models.ReceiptDetail;
import com.example.orbix_web.models.Sale;
import com.example.orbix_web.models.SaleDetail;
import com.example.orbix_web.models.SalesInvoice;
import com.example.orbix_web.models.Till;
import com.example.orbix_web.models.User;
import com.example.orbix_web.repositories.ReceiptDetailRepository;
import com.example.orbix_web.repositories.ReceiptRepository;
import com.example.orbix_web.repositories.SaleDetailRepository;
import com.example.orbix_web.repositories.SaleRepository;
import com.example.orbix_web.repositories.TillRepository;
import com.example.orbix_web.repositories.UserRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class ReceiptServiceController {

    @Autowired
    ReceiptRepository receiptRepository;
    @Autowired
    ReceiptDetailRepository receiptDetailRepository;
    @Autowired
    TillRepository tillRepository;
    @Autowired
    UserRepository userRepository;
    @Autowired
    SaleRepository saleRepository;
    @Autowired
    SaleDetailRepository saleDetailRepository;
   
   
    /**
     * Get all receipts by params
     * @param tillNo
     * @param date
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/receipts", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<Receipt> getReceiptsByParams(
    		@RequestParam(name = "till_no") String tillNo,
    		@RequestParam(name = "date") LocalDate date,   		
    		@RequestHeader("user_id") Long userId) {
    	if(!(tillNo.isEmpty() & date == null)) {
    		Optional<Till> till = tillRepository.findByNo(tillNo);
    		if(!till.isPresent()) {
    			throw new NotFoundException("Till not found");
    		}
    		return receiptRepository.findByTillAndIssueDate(till.get(), date);
    	}else if(!tillNo.isEmpty()){
    		Optional<Till> till = tillRepository.findByNo(tillNo);
    		if(!till.isPresent()) {
    			throw new NotFoundException("Till not found");
    		}
    		return receiptRepository.findByTill(till.get());
    	}else if(date != null) {
    		return receiptRepository.findByIssueDate(date);
    	}else {
    		return receiptRepository.findAll();
    	}     
    }
    
    /**
     * @param id
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/receipts/get_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    public Receipt getGetReceiptById(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
        return receiptRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("Receipt not found"));
    }
    
    /**
     * @param no
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/receipts/get_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    public Receipt getGetReceiptByNo(@RequestParam(name = "no") String no, @RequestHeader("user_id") Long userId) {
        return receiptRepository.findByNo(no)
                .orElseThrow(() -> new NotFoundException("Receipt not found"));
    }
    
    /**
     * Create a new receipt
     * @param receipt
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.POST, value = "/receipts/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Receipt createReceipt(
    		@Valid @RequestBody Receipt receipt, 
    		@RequestHeader("user_id") Long userId) {
    	Optional<Till> till = tillRepository.findByNo(receipt.getTill().getNo());   	
    	if(!till.isPresent()) {
    		throw new NotFoundException("Till not found");
    	}
    	Optional<User> user = userRepository.findById(userId);
    	if(!user.isPresent()) {
    		throw new NotFoundException("User not found");
    	}    	
    	receipt.setTill(till.get());
    	receipt.setCreatedUser(user.get());
    	String random = String.valueOf(Math.random()).replace(".", "") + String.valueOf(Math.random()).replace(".", "");
    	receipt.setNo(random);
    	receiptRepository.saveAndFlush(receipt);
    	String serial = receipt.getId().toString();
    	String recNo = "R-"+Formater.formatNine(serial);
    	receipt.setNo(recNo); 
    	receiptRepository.saveAndFlush(receipt);
    	
    	List<ReceiptDetail> receiptDetails;
    	receiptDetails = receipt.getReceiptDetails();
    	for(ReceiptDetail detail : receiptDetails) {
    		detail.setReceipt(receipt);
    		receiptDetailRepository.saveAndFlush(detail);
    	} 
    	Sale sale = new Sale();
    	sale.setReceipt(receipt);
    	saleRepository.saveAndFlush(sale);
    	SaleDetail saleDetail = new SaleDetail();
    	for(ReceiptDetail detail : receiptDetails) {
    		saleDetail.setCode(detail.getCode());
    		saleDetail.setDescription(detail.getDescription());
    		saleDetail.setQty(detail.getQty());
    		saleDetail.setCostPriceVatIncl(detail.getCostPriceVatIncl());
    		saleDetail.setCostPriceVatExcl(detail.getCostPriceVatExcl());
    		saleDetail.setSellingPriceVatIncl(detail.getSellingPriceVatIncl());
    		saleDetail.setSellingPriceVatExcl(detail.getSellingPriceVatExcl());
    		saleDetail.setDiscount(detail.getDiscount());
    		saleDetailRepository.saveAndFlush(saleDetail);
    	}     	
    	return receipt;
    }   
}

