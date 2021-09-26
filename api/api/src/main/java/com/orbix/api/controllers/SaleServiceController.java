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

import com.orbix.api.models.Day;
import com.orbix.api.models.Sale;
import com.orbix.api.models.SaleDetail;
import com.orbix.api.reports.DailySalesReport;
import com.orbix.api.reports.FastMovingItems;
import com.orbix.api.reports.ProductListingReport;
import com.orbix.api.reports.SlowMovingItems;
import com.orbix.api.reports.SupplySalesReport;
import com.orbix.api.repositories.DayRepository;
import com.orbix.api.repositories.SaleDetailRepository;
import com.orbix.api.repositories.SaleRepository;

@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class SaleServiceController {
	@Autowired
	SaleRepository saleRepository;
	@Autowired
	SaleDetailRepository saleDetailRepository;
	@Autowired
	DayRepository dayRepository;
	
	/**
	 * Get daily sales
	 * @param fromDate
	 * @param toDate
	 * @param userId
	 * @return
	 */
	@Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/sales/get_daily_sales_report_by_date", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<DailySalesReport> getDailySalesReport(
    		@RequestParam(name = "from_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate fromDate,
    		@RequestParam(name = "to_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate toDate,   		
    		@RequestHeader("user_id") Long userId) {
		List<DailySalesReport> report = saleRepository.getDailySalesReportByDate(fromDate, toDate);		
		return report;
    }
	
	/**
	 * Get product listing / detailed sales by product
	 */
	@Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/sales/get_product_listing_report", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<ProductListingReport> getProductListingReport(
    		@RequestParam(name = "from_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate fromDate,
    		@RequestParam(name = "to_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate toDate,
    		@RequestParam(name = "codes") ArrayList<String> codes,
    		@RequestHeader("user_id") Long userId) {
		List<ProductListingReport> report;
		if(codes.isEmpty()) {			
			report = saleRepository.getProductListingReport(fromDate, toDate);	
		}else {			
			report = saleRepository.getProductListingReportBySelectedProducts(fromDate, toDate, codes);	
		}			
		return report;
    }
	
	/**
	 * Get Z History
	 */
	
	/**
	 * Get stock based on supplier
	 */
	
	/**
	 * 
	 */
	
	/**
	 * Get supply sales report
	 */
	@Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/sales/get_supply_sales_report", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<SupplySalesReport> getSupplySalesReport(
    		@RequestParam(name = "from_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate fromDate,
    		@RequestParam(name = "to_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate toDate,
    		@RequestParam(name = "supplier_name") String supplierName,
    		@RequestParam(name = "codes") ArrayList<String> codes,
    		@RequestHeader("user_id") Long userId) {
		List<SupplySalesReport> report;
		if(codes.isEmpty()) {			
			report = saleRepository.getSupplySalesReport(fromDate, toDate, supplierName);	
		}else {			
			report = saleRepository.getSupplySalesReportByProduct(fromDate, toDate, supplierName, codes);		
		}			
		return report;
    }
	
	@Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/sales/get_fast_moving_items", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<FastMovingItems> getFastMovingItems(
    		@RequestParam(name = "from_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate fromDate,
    		@RequestParam(name = "to_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate toDate,
    		@RequestParam(name = "supplier_name") String supplierName,
    		@RequestParam(name = "department_name") String departmentName,
    		@RequestParam(name = "class_name") String className,
    		@RequestParam(name = "sub_class_name") String subClassName,
    		@RequestHeader("user_id") Long userId) {
		List<FastMovingItems> report;
				
			report = saleRepository.getFastMovingItems(fromDate, toDate);		
		
		return report;
    }
	
	@Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/sales/get_slow_moving_items", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<SlowMovingItems> getSlowMovingItems(
    		@RequestParam(name = "from_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate fromDate,
    		@RequestParam(name = "to_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate toDate,
    		@RequestParam(name = "supplier_name") String supplierName,
    		@RequestParam(name = "department_name") String departmentName,
    		@RequestParam(name = "class_name") String className,
    		@RequestParam(name = "sub_class_name") String subClassName,
    		@RequestHeader("user_id") Long userId) {
		List<SlowMovingItems> report;
				
			report = saleRepository.getSlowMovingItems(fromDate, toDate);		
		
		return report;
    }
}
