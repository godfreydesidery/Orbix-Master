/**
 * 
 */
package com.orbix.api.controllers;

import java.time.LocalDate;
import java.util.List;
import java.util.Optional;
import java.util.Vector;

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
import com.orbix.api.exceptions.NotFoundException;
import com.orbix.api.models.Cart;
import com.orbix.api.models.CartDetail;
import com.orbix.api.models.Receipt;
import com.orbix.api.models.ReceiptDetail;
import com.orbix.api.models.Sale;
import com.orbix.api.models.SaleDetail;
import com.orbix.api.models.Till;
import com.orbix.api.models.User;
import com.orbix.api.models.Voided;
import com.orbix.api.repositories.CartRepository;
import com.orbix.api.repositories.DayRepository;
import com.orbix.api.repositories.ReceiptDetailRepository;
import com.orbix.api.repositories.ReceiptRepository;
import com.orbix.api.repositories.SaleDetailRepository;
import com.orbix.api.repositories.SaleRepository;
import com.orbix.api.repositories.TillRepository;
import com.orbix.api.repositories.UserRepository;
import com.orbix.api.repositories.VoidedRepository;

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
    @Autowired
    CartRepository cartRepository;
    @Autowired
    VoidedRepository voidedRepository;
    @Autowired
    DayRepository dayRepository;
   
   
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
    	userRepository.saveAndFlush(user.get());
    	receipt.setTotal(
    			receipt.getCash() +
    			receipt.getVoucher() +
    			receipt.getDeposit() +
    			receipt.getLoyalty() +
    			receipt.getCrCard() +
    			receipt.getCheque() +
    			receipt.getCap() +
    			receipt.getInvoice() +
    			receipt.getCrNote() +
    			receipt.getMobile() +
    			receipt.getOther());
    	receipt.setTill(till.get());
    	receipt.setCreatedUser(user.get());
    	receipt.setReprintedUser(null);
    	String random = String.valueOf(Math.random()).replace(".", "") + String.valueOf(Math.random()).replace(".", "");
    	receipt.setNo(random);
    	receiptRepository.saveAndFlush(receipt);
    	String serial = receipt.getId().toString();
    	String recNo = "R-"+Formater.formatNine(serial);
    	receipt.setNo(recNo); 
    	receipt.setDay(dayRepository.getCurrentBussinessDay());
    	receiptRepository.saveAndFlush(receipt);
    	
    	List<ReceiptDetail> receiptDetails = new Vector<ReceiptDetail>();
    	    	
    	Optional <Cart> cart = cartRepository.findById(receipt.getCart().getId());
    	List<CartDetail> cartDetails;
    	if(cart.isPresent() == false) {
    		throw new NotFoundException("Cart not found");
    	}
    	cartDetails = cart.get().getCartDetails();
    	ReceiptDetail receiptDetail;
    	Voided voided;
    	/**
    	 * Add details to sales details and voided items to void list
    	 */
    	for(CartDetail detail : cartDetails) {
    		if(detail.getVoided() != 1) {
    			/**
    			 * Add non voided details to receipt
    			 */
    			receiptDetail = new ReceiptDetail();
	    		receiptDetail.setReceipt(receipt);
	    		receiptDetail.setCode(detail.getCode());
	    		receiptDetail.setDescription(detail.getDescription());
	    		receiptDetail.setQty(detail.getQty());
	    		receiptDetail.setCostPriceVatIncl(detail.getCostPriceVatIncl());
	    		receiptDetail.setCostPriceVatExcl(detail.getCostPriceVatExcl());
	    		receiptDetail.setSellingPriceVatIncl(detail.getSellingPriceVatIncl());
	    		receiptDetail.setSellingPriceVatExcl(detail.getSellingPriceVatExcl());
	    		receiptDetail.setDiscount(detail.getDiscount());
	    		receiptDetails.add(receiptDetail);
	    		receiptDetailRepository.saveAndFlush(receiptDetail);
    		}else {
    			/**
    			 * Add voided details to void list
    			 */
    			voided = new Voided();
    			voided.setTill(till.get());
    			voided.setVoidedUser(user.get());
    			voided.setCode(detail.getCode());
    			voided.setDescription(detail.getDescription());
    			voided.setQty(detail.getQty());
    			voided.setCostPriceVatIncl(detail.getCostPriceVatIncl());
    			voided.setCostPriceVatExcl(detail.getCostPriceVatExcl());
    			voided.setSellingPriceVatIncl(detail.getSellingPriceVatIncl());
    			voided.setSellingPriceVatExcl(detail.getSellingPriceVatExcl());
    			voided.setDiscount(detail.getDiscount());
	    		voidedRepository.saveAndFlush(voided);
    		}
    		
    	}
    	/**
    	 * Now remove cart from receipt and empty cart
    	 */
    	receipt.setCart(null);
    	receiptRepository.saveAndFlush(receipt);
    	cartRepository.delete(cart.get());
    	/**
    	 * Update till position
    	 */
    	Optional<Till> _tillPosition = tillRepository.findById(till.get().getId());
    	if(_tillPosition.isPresent()) {
    		
    		_tillPosition.get().setCap(0);
    		_tillPosition.get().setCash(0);
    		_tillPosition.get().setCheque(0);
    		_tillPosition.get().setCrCard(0);
    		_tillPosition.get().setCrNote(0);
    		_tillPosition.get().setDeposit(0);
    		_tillPosition.get().setInvoice(0);
    		_tillPosition.get().setLoyalty(0);
    		_tillPosition.get().setMobile(0);
    		_tillPosition.get().setOther(0);
    		
    		tillRepository.saveAndFlush(_tillPosition.get());
    	}
    	_tillPosition = tillRepository.findById(till.get().getId());
    	_tillPosition.get().setCap(_tillPosition.get().getCap() + receipt.getCap());
    	_tillPosition.get().setCash(_tillPosition.get().getCash() + receipt.getCash());
    	_tillPosition.get().setCheque(_tillPosition.get().getCheque() + receipt.getCheque());
    	_tillPosition.get().setCrCard(_tillPosition.get().getCrCard() + receipt.getCrCard());
    	_tillPosition.get().setCrNote(_tillPosition.get().getCrNote() + receipt.getCrNote());
    	_tillPosition.get().setDeposit(_tillPosition.get().getDeposit() + receipt.getDeposit());
    	_tillPosition.get().setInvoice(_tillPosition.get().getInvoice() + receipt.getInvoice());
    	_tillPosition.get().setLoyalty(_tillPosition.get().getLoyalty() + receipt.getLoyalty());
    	_tillPosition.get().setMobile(_tillPosition.get().getMobile() + receipt.getMobile());
    	_tillPosition.get().setOther(_tillPosition.get().getOther() + receipt.getOther());
		tillRepository.saveAndFlush(_tillPosition.get());
    	
    	Sale sale = new Sale();
    	sale.setReceipt(receipt);
    	saleRepository.saveAndFlush(sale);
    	SaleDetail saleDetail = new SaleDetail();
    	for(ReceiptDetail detail : receiptDetails) {
    		saleDetail.setSale(sale);
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

