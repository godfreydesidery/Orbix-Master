package com.orbix.api.controllers;

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

import com.orbix.api.exceptions.InvalidOperationException;
import com.orbix.api.exceptions.NotFoundException;
import com.orbix.api.models.CashPickUp;
import com.orbix.api.models.Till;
import com.orbix.api.models.User;
import com.orbix.api.repositories.CashPickUpRepository;
import com.orbix.api.repositories.TillRepository;
import com.orbix.api.repositories.UserRepository;

@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class CashPickUpServiceController {
	@Autowired
	CashPickUpRepository cashPickUpRepository;
	@Autowired
	TillRepository tillRepository;
	@Autowired
	UserRepository userRepository;
	
	@RequestMapping(method = RequestMethod.POST, value="/cash_pick_ups/pick_up_by_till_no", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public CashPickUp collect(
    		@RequestParam(name = "no") String tillNo,
            								@Valid @RequestBody CashPickUp cashPickUp_, 
            								@RequestHeader("user_id") Long userId) throws Exception {
		Till till = tillRepository.findByNo(tillNo)
                .orElseThrow(() -> new NotFoundException("Till not found"));
		User user = userRepository.findById(userId)
                .orElseThrow(() -> new NotFoundException("User not found"));
		if(till.getCash() < cashPickUp_.getAmount()) {
			throw new InvalidOperationException("Pick up amount exceeds the available cash balance");
		}else {
			till.setCash(till.getCash() - cashPickUp_.getAmount());
			tillRepository.saveAndFlush(till);
		}
		
		CashPickUp cashPickUp = new CashPickUp();
		cashPickUp.setAmount(cashPickUp_.getAmount());
		cashPickUp.setTill(till);
		cashPickUp.setDetails(cashPickUp_.getDetails());
		cashPickUp.setPickedBy(user);
		
    	return cashPickUpRepository.saveAndFlush(cashPickUp);
    }
}
