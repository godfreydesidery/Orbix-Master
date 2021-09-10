package com.orbix.api.controllers;

import java.sql.Timestamp;
import java.time.LocalDate;
import java.time.chrono.ChronoLocalDate;
import java.util.Date;

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
import com.orbix.api.exceptions.MissingInformationException;
import com.orbix.api.exceptions.NotFoundException;
import com.orbix.api.models.Day;
import com.orbix.api.models.Department;
import com.orbix.api.models.Product;
import com.orbix.api.models.User;
import com.orbix.api.repositories.DayRepository;
import com.orbix.api.repositories.UserRepository;

@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class DayServiceController {
	@Autowired
	DayRepository dayRepository;
	@Autowired
	UserRepository userRepository;
	
	@RequestMapping(method = RequestMethod.GET, value = "/days/get_current_bussiness_day", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public Day getCurrentBussinessDay() {
        return dayRepository.getCurrentBussinessDay();               
    }
	
	@RequestMapping(method = RequestMethod.POST, value="/days/end_day", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Day endDay(
    		@Valid @RequestBody Day day_, 
    		@RequestHeader("user_id") Long userId) throws Exception {  
		User user = userRepository.findById(userId)
                .orElseThrow(() -> new NotFoundException("User not found"));
    	Day oldDay = dayRepository.findByBussinessDate(day_.getBussinessDate())
                .orElseThrow(() -> new MissingInformationException("Day required"));
    	if(oldDay.getStatus().equals("ENDED")) {
    		throw new InvalidOperationException("Can not end an already ended day");
    	}
    	Timestamp timestamp = new Timestamp(System.currentTimeMillis());
    	
    	
    	
    	oldDay.setEndedBy(user);
    	oldDay.setEndedAt(timestamp);
    	oldDay.setStatus("ENDED");
    	dayRepository.saveAndFlush(oldDay);
    	
    	Day newDay = new Day();
    	LocalDate currentServerDate = LocalDate.now();
    	if(currentServerDate.isAfter( oldDay.getBussinessDate())) {
    		newDay.setBussinessDate(currentServerDate);
    	}else if(currentServerDate.isEqual(oldDay.getBussinessDate())) {
    		newDay.setBussinessDate(oldDay.getBussinessDate().plusDays(1));
    	}else {
    		throw new InvalidOperationException("Could not end a day with a date more than the current server date");
    	}  	
    	newDay.setStartedBy(user);
    	newDay.setStartedAt(timestamp);
    	newDay.setStatus("STARTED");
    	dayRepository.saveAndFlush(newDay);  
    	
    	return newDay;
    }
	
//	@RequestMapping(method = RequestMethod.GET, value = "/days/get_current_bussiness_date")
//    @Transactional
//    public Date getCurrentBussinessDate(@RequestHeader("user_id") Long userId) {
//        return dayRepository.fi
//                .orElseThrow(() -> new NotFoundException("Product not found"));
//    }
}
