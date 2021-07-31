package com.orbix.api.controllers;

import java.util.List;
import java.util.Optional;

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
import com.orbix.api.models.Cart;
import com.orbix.api.models.CartDetail;
import com.orbix.api.models.Clas;
import com.orbix.api.models.Department;
import com.orbix.api.models.Till;
import com.orbix.api.repositories.CartDetailRepository;
import com.orbix.api.repositories.CartRepository;
import com.orbix.api.repositories.ClassRepository;
import com.orbix.api.repositories.DepartmentRepository;
import com.orbix.api.repositories.TillRepository;

@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class CartServiceController {
	@Autowired
    CartRepository cartRepository;
	@Autowired
    CartDetailRepository cartDetailRepository;
    @Autowired
    TillRepository tillRepository;
    
    @RequestMapping(method = RequestMethod.POST, value="/carts/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Cart createCart(
    		@Valid @RequestBody Cart cart, 
    		@RequestHeader("user_id") Long userId) throws Exception {    	
    	Till till = tillRepository.findByNo(cart.getTill().getNo())
                .orElseThrow(() -> new MissingInformationException("Till required"));
    	tillRepository.save(till); 
    	List<CartDetail> cartDetails = cart.getCartDetails();
    	cart.setTill(till);
    	cartRepository.saveAndFlush(cart);       	
    	for(CartDetail detail : cartDetails) {   		
    		detail.setCart(cart);
    		cartDetailRepository.save(detail);
    	}
    	return cart;
    }
    
    @RequestMapping(method = RequestMethod.PUT, value="/carts/update_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Cart updateCart(
    		@Valid @RequestBody Cart _cart,
    		@RequestParam(name = "id") Long id, 
    		@RequestHeader("user_id") Long userId) throws Exception {    	
    	List<CartDetail> cartDetails = _cart.getCartDetails();
    	//cartRepository.saveAndFlush(cart);  
    	Cart cart = cartRepository.findById(_cart.getId()).get();
    	cartRepository.saveAndFlush(cart);
    	
    	for(CartDetail _detail : cartDetails) {
    		Optional<CartDetail> detail = cartDetailRepository.findByCodeAndVoidedAndCart(_detail.getCode(), 0, cart);  
    		if(detail.isPresent()) {  			
    			detail.get().setCart(cart);
    			double oldQty = detail.get().getQty();
    			double qty = _detail.getQty();    			
    			detail.get().setQty(oldQty + qty);
				cartDetailRepository.saveAndFlush(detail.get());   			
    		}else {
    			_detail.setCart(cart);
    			cartDetailRepository.saveAndFlush(_detail);
    		}
    	}
    	return cart;	
    }
    
    @RequestMapping(method = RequestMethod.PUT, value="/carts/void", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public boolean void_(
    		@RequestParam(name = "detail_id") Long id, 
    		@Valid @RequestBody Cart cart, 
    		@RequestHeader("user_id") Long userId) throws Exception { 
    	CartDetail detail = cartDetailRepository.findById(id)
                .orElseThrow(() -> new MissingInformationException("Detail not found"));
    	detail.setVoided(1);
    	cartDetailRepository.saveAndFlush(detail);   	
    	return true;	
    }
    
    @RequestMapping(method = RequestMethod.PUT, value="/carts/update_qty", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public boolean updateQty(
    		@RequestParam(name = "detail_id") Long id, 
    		@RequestParam(name = "qty") double qty, 
    		@RequestHeader("user_id") Long userId) throws Exception { 
    	CartDetail detail = cartDetailRepository.findById(id)
                .orElseThrow(() -> new MissingInformationException("Detail not found"));
    	detail.setQty(qty);
    	cartDetailRepository.saveAndFlush(detail);   	
    	return true;	
    }
    
    @RequestMapping(method = RequestMethod.PUT, value="/carts/unvoid", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public boolean unvoid_(
    		@RequestParam(name = "detail_id") Long id, 
    		@Valid @RequestBody Cart cart, 
    		@RequestHeader("user_id") Long userId) throws Exception { 
    	CartDetail detail = cartDetailRepository.findById(id)
                .orElseThrow(() -> new MissingInformationException("Detail not found"));
    	detail.setVoided(0);
    	cartDetailRepository.saveAndFlush(detail);   	
    	return true;	
    }
    
    @RequestMapping(method = RequestMethod.GET, value = "/carts/check_voided")
    public boolean checkVoided(
    		@RequestParam(name = "detail_id") Long id, 
    		@RequestHeader("user_id") Long userId) {
    	CartDetail detail = cartDetailRepository.findById(id)
                .orElseThrow(() -> new MissingInformationException("Detail not found"));
    	if(detail.getVoided() == 1) {
    		return true;    		
    	}else {
    		return false;
    	}   	
    }
    
    @RequestMapping(method = RequestMethod.GET, value = "/carts/get_by_till_no")
    public Cart getCartByTillNo(
    		@RequestParam(name = "till_no") String tillNo, 
    		@RequestHeader("user_id") Long userId) {
    	Optional<Till> till = tillRepository.findByNo(tillNo);
    	if(!till.isPresent()) {
    		throw new NotFoundException("Till not found");
    	}
    	return cartRepository.findByTill(till.get());   	
    }
    @RequestMapping(method = RequestMethod.GET, value = "/carts/get_by_id_and_till_no")
    public Cart getCartById(
    		@RequestParam(name = "id") Long id, 
    		@RequestParam(name = "till_no") String tillNo, 
    		@RequestHeader("user_id") Long userId) {
    	Optional<Till> till = tillRepository.findByNo(tillNo);
    	if(!till.isPresent()) {
    		throw new NotFoundException("Till not found");
    	}
    	return cartRepository.findByIdAndTill(id, till.get());   	
    }
}
