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
import com.orbix.api.models.PettyCash;
import com.orbix.api.models.Till;
import com.orbix.api.models.User;
import com.orbix.api.repositories.DayRepository;
import com.orbix.api.repositories.PettyCashRepository;
import com.orbix.api.repositories.TillRepository;
import com.orbix.api.repositories.UserRepository;

@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class PettyCashServiceController {
	@Autowired
    UserRepository userRepository;
	@Autowired
    TillRepository tillRepository;
	@Autowired
    PettyCashRepository pettyCashRepository;
	@Autowired
    DayRepository dayRepository;
	
	@RequestMapping(method = RequestMethod.POST, value="/petty_cashs/collect_by_till_no", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public PettyCash collect(
    		@RequestParam(name = "no") String tillNo,
            								@Valid @RequestBody PettyCash pettyCash_, 
            								@RequestHeader("user_id") Long userId) throws Exception {
		Till till = tillRepository.findByNo(tillNo)
                .orElseThrow(() -> new NotFoundException("Till not found"));
		User user = userRepository.findById(userId)
                .orElseThrow(() -> new NotFoundException("User not found"));
		if(till.getCash() < pettyCash_.getAmount()) {
			throw new InvalidOperationException("Petty cash amount exceeds the available cash balance");
		}else {
			till.setCash(till.getCash() - pettyCash_.getAmount());
			tillRepository.saveAndFlush(till);
		}
		
		PettyCash pettyCash = new PettyCash();
		pettyCash.setAmount(pettyCash_.getAmount());
		pettyCash.setTill(till);
		pettyCash.setDetails(pettyCash_.getDetails());
		pettyCash.setPickedBy(user);
		pettyCash.setDay(dayRepository.getCurrentBussinessDay());
    	return pettyCashRepository.saveAndFlush(pettyCash);
    }
}
