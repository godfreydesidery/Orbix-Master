/**
 * 
 */
package com.orbix.api.controllers;

import java.time.LocalDate;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.http.MediaType;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.orbix.api.reports.DebtTrackerReport;
import com.orbix.api.repositories.DayRepository;
import com.orbix.api.repositories.DebtRepository;
import com.orbix.api.repositories.UserRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class DebtServiceController {
	@Autowired
	DayRepository dayRepository;
	@Autowired
	UserRepository userRepository;
	@Autowired
	DebtRepository debtRepository;
	
	@Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/debts/get_debt_report", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<DebtTrackerReport> getDebtTrackerReport(
    		@RequestParam(name = "from_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate fromDate,
    		@RequestParam(name = "to_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate toDate, 
    		@RequestParam(name = "name") String name, 
    		@RequestHeader("user_id") Long userId) {
		if(name.equals("")) {
			return debtRepository.getDebtTracker(fromDate, toDate);
		}else {
			return debtRepository.getDebtTrackerBySalesPerson(fromDate, toDate, name);
		}		
    }	
}
