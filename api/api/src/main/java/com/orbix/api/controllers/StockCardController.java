package com.orbix.api.controllers;

import java.time.LocalDate;
import java.util.ArrayList;
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

import com.orbix.api.reports.ProductListingReport;
import com.orbix.api.reports.StockCardReport;
import com.orbix.api.repositories.DayRepository;
import com.orbix.api.repositories.StockCardRepository;

@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class StockCardController {
	@Autowired
	StockCardRepository stockCardRepository;
	
	
	@Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/sales/get_stock_card_report", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<StockCardReport> getStockCardReport(
    		@RequestParam(name = "from_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate fromDate,
    		@RequestParam(name = "to_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate toDate,
    		@RequestParam(name = "codes") ArrayList<String> codes,
    		@RequestHeader("user_id") Long userId) {
		List<StockCardReport> report;
		if(codes.isEmpty()) {			
			report = stockCardRepository.getStockCardReport(fromDate, toDate);	
		}else {	
			report = stockCardRepository.getStockCardReport(fromDate, toDate);	
			//report = stockCardRepository.getStockCardReportBySelectedProducts(fromDate, toDate, codes);	
		}			
		return report;
    }
	
}
