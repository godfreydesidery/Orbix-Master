/**
 * 
 */
package com.orbix.api.controllers;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Calendar;
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
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.orbix.api.accessories.Formater;
import com.orbix.api.exceptions.InvalidEntryException;
import com.orbix.api.exceptions.InvalidOperationException;
import com.orbix.api.exceptions.MissingInformationException;
import com.orbix.api.exceptions.NotFoundException;
import com.orbix.api.models.CorporateCustomer;
import com.orbix.api.models.Sale;
import com.orbix.api.models.SaleDetail;
import com.orbix.api.models.SalesInvoice;
import com.orbix.api.models.SalesInvoiceDetail;
import com.orbix.api.models.User;
import com.orbix.api.repositories.CorporateCustomerRepository;
import com.orbix.api.repositories.DayRepository;
import com.orbix.api.repositories.SaleDetailRepository;
import com.orbix.api.repositories.SaleRepository;
import com.orbix.api.repositories.SalesInvoiceDetailRepository;
import com.orbix.api.repositories.SalesInvoiceRepository;
import com.orbix.api.repositories.UserRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class SalesInvoiceServiceController {	
	@Autowired
	SalesInvoiceRepository salesInvoiceRepository;
	@Autowired
	CorporateCustomerRepository corporateCustomerRepository;
	@Autowired
	SalesInvoiceDetailRepository salesInvoiceDetailRepository;	
	
	@Autowired
	UserRepository userRepository;
	@Autowired
	SaleRepository saleRepository;
	@Autowired
	SaleDetailRepository saleDetailRepository;
	@Autowired
    DayRepository dayRepository;
	
	/**
	 * Get all the Sales invoices
	 * @return
	 */
	@RequestMapping(method = RequestMethod.GET, value = "/sales_invoices", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<SalesInvoice> getAllSalesInvoices() {
        return salesInvoiceRepository.findAll();
    }
	
	/**
	 * Get all visible invoices
	 * @return
	 */
	@RequestMapping(method = RequestMethod.GET, value = "/sales_invoices/visible", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<SalesInvoice> getAllVisibleSalesInvoice(@RequestHeader("user_id") Long userId) {
    	List<String> statuses = Stream.of("PENDING", "APPROVED", "COMPLETED").collect(Collectors.toList());   	
        return salesInvoiceRepository.findAllByStatus(statuses);
    }
	
	/**
	 * Get a sale invoice by id
	 * @param id
	 * @return
	 */
	@RequestMapping(method = RequestMethod.GET, value = "/sales_invoices/get_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    public SalesInvoice getGetSalesInvoiceById(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
        return salesInvoiceRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("Invoice not found"));
    }
	
	/**
	 * Get a sale invoice by no
	 * @param no
	 * @return
	 */
	@RequestMapping(method = RequestMethod.GET, value = "/sales_invoices/get_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    public SalesInvoice getGetSalesInvoiceByNo(@RequestParam(name = "no") String no, @RequestHeader("user_id") Long userId) {
        return salesInvoiceRepository.findByNo(no)
                .orElseThrow(() -> new NotFoundException("Invoice not found"));
    }
	
	/**
	 * Create a new sales invoice
	 * @param invoice
	 * @return
	 */
	@RequestMapping(method = RequestMethod.POST, value = "/sales_invoices/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public SalesInvoice createSalesInvoice(@Valid @RequestBody SalesInvoice invoice, @RequestHeader("user_id") Long userId) {
    	LocalDate issueDate = invoice.getIssueDate();
    	String customerName = (invoice.getCorporateCustomer().getName());
    	Optional<CorporateCustomer> customer = corporateCustomerRepository.findByName(customerName);
    	if(customer.isPresent() == true) {
    		corporateCustomerRepository.save(customer.get());
    		invoice.setCorporateCustomer(customer.get());
    	}else {
    		throw new NotFoundException("Customer not found");
    	}    
    	Optional<User> createdUser;
    	Long createdUserId = (invoice.getCreatedUser().getId());
    	createdUser = userRepository.findById(createdUserId);
    	if(createdUser.isPresent() == true) {
    		userRepository.save(createdUser.get());
    		invoice.setCreatedUser(createdUser.get());
    	}else {
    		invoice.setCreatedUser(null);
    	}
    	invoice.setApprovedUser(null);
    	invoice.setCompletedUser(null);
    	    	
    	LocalDate systemDate =LocalDate.now(); //day.getSystemDate();
    	invoice.setDay(dayRepository.getCurrentBussinessDay());
    	
    	invoice.setIssueDate(systemDate);
    	String random = String.valueOf(Math.random()).replace(".", "") + String.valueOf(Math.random()).replace(".", "");
    	invoice.setNo(random); 
    	salesInvoiceRepository.saveAndFlush(invoice);
    	
    	invoice.setStatus("PENDING");
    	
    	String serial = invoice.getId().toString();
    	String invNo = "SI-"+Formater.formatNine(serial);
    	invoice.setNo(invNo); 
    	return salesInvoiceRepository.saveAndFlush(invoice);    	
    }
	
	/**
	 * Update an invoice by id
	 * @param invoice
	 * @param id
	 * @return
	 */
	@RequestMapping(method = RequestMethod.PUT, value = "/sales_invoices/edit_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public boolean updateSalesInvoice(@Valid @RequestBody SalesInvoice invoice, @RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
		if(invoice.getCorporateCustomer().getNo().isEmpty()) {
			throw new NotFoundException("Customer not found");
		}
		Optional<CorporateCustomer> customer = corporateCustomerRepository.findByNo(invoice.getCorporateCustomer().getNo());
		invoice.setCorporateCustomer(customer.get());	
		corporateCustomerRepository.save(customer.get());
		return true;
    }
	
	/**
	 * Delete a sale invoice by id
	 * @param id
	 * @return
	 */
	@DeleteMapping("/sales_invoices/delete_by_id")
    public ResponseEntity<?> deleteCorporateCustomer(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
    	SalesInvoice invoice = salesInvoiceRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("Invoice not found"));
    //	this.checkUsageBeforeDelete(supplier);
    	salesInvoiceRepository.delete(invoice);
        return ResponseEntity.ok().build();
    }
	
	@Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/sales_invoices/get_status_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    public String getSalesInvoiceStatusById(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
		Optional<SalesInvoice> invoice = salesInvoiceRepository.findById(id);
		if(invoice.isPresent() == false) {
			return "";
		}
		return invoice.get().getStatus();  	
    }
	
	/**
	 * Create or Update a sales invoice detail by id
	 * @param detail
	 * @return
	 */
	@RequestMapping(method = RequestMethod.POST, value = "/sales_invoice_details/new_or_edit", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public SalesInvoiceDetail createOrEditSalesInvoiceDetail(@Valid @RequestBody SalesInvoiceDetail detail, @RequestHeader("user_id") Long userId) {    	
    	Long id = detail.getSalesInvoice().getId();
    	if(id == null) {
    		throw new MissingInformationException("Invoice not selected");
    	}
    	if(detail.getCode().equals("")) {
    		throw new MissingInformationException("Product code required");
    	}
    	if(detail.getQty() <= 0) {
    		throw new InvalidEntryException("Invalid entry in qty, qty should be more than zero");
    	}
    	SalesInvoice invoice = salesInvoiceRepository.findById(id).get();
    	String code = detail.getCode();
    	Optional<SalesInvoiceDetail> detail_ = salesInvoiceDetailRepository.findBySalesInvoiceAndCode(invoice, code);  	
    	if(detail_.isPresent() == true) {    		
    		detail_.get().setDescription(detail.getDescription());
    		detail_.get().setCostPriceVatIncl(detail.getCostPriceVatIncl());
    		detail_.get().setCostPriceVatExcl(detail.getCostPriceVatExcl());
    		detail_.get().setSellingPriceVatIncl(detail.getSellingPriceVatIncl());
    		detail_.get().setSellingPriceVatExcl(detail.getSellingPriceVatExcl());
    		detail_.get().setQty(detail.getQty());    		
    		return salesInvoiceDetailRepository.save(detail_.get());
    	}else {
    		return salesInvoiceDetailRepository.save(detail);
    	}
    }
	
	/**
	 * Delete a sales invoice detail
	 * @param id
	 * @return
	 */
	@Transactional
    @RequestMapping(method = RequestMethod.DELETE, value = "/sales_invoice_details/delete_by_id", produces = "text/html")
    public ResponseEntity<?> deleteSalesInvoiceDetail(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
    	SalesInvoiceDetail detail = salesInvoiceDetailRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("Invoice Detail not found"));
    	salesInvoiceDetailRepository.delete(detail);
    	return new ResponseEntity<>("Invoice detail deleted successifully.", HttpStatus.OK);  	 	
    }
	
	/**
	 * Cancel a sales invoice
	 * @param id
	 * @return
	 */
	@Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/sales_invoices/cancel_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean cancelSalesInvoice(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
		Optional<SalesInvoice> invoice_ = salesInvoiceRepository.findById(id);
		if(!invoice_.isPresent()) {
			throw new NotFoundException("Invoice not found");
		}
		if(invoice_.get().getStatus().equals("PENDING") || invoice_.get().getStatus().equals("APPROVED")) {
			invoice_.get().setStatus("CANCELED");
			salesInvoiceRepository.save(invoice_.get());
		}else {
			throw new InvalidOperationException("Only a pending or approved invoice can be canceled");
		}
		return true;		
	}
	
	/**
	 * Approve a sales invoice
	 * @param id
	 * @return
	 */
	@Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/sales_invoices/approve_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean approveSalesInvoice(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
		Optional<SalesInvoice> invoice_ = salesInvoiceRepository.findById(id);
		if(!invoice_.isPresent()) {
			throw new NotFoundException("Invoice not found");
		}
		Optional<User> user = userRepository.findById(userId);
		if(!user.isPresent()) {
			throw new NotFoundException("User not found");
		}
		if(invoice_.get().getStatus().equals("PENDING")) {
			invoice_.get().setStatus("APPROVED");
			invoice_.get().setApprovedUser(user.get());
			salesInvoiceRepository.save(invoice_.get());
		}else {
			throw new InvalidOperationException("Only a pending invoice can be approved");
		}
		return true;		
	}
	
	/**
	 * Complete a sale invoice
	 * @param id
	 * @return
	 */
	@Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/sales_invoices/complete_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean completeSalesInvoice(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
		/**
		 * To complete a sales invoice
		 * Upon complete, invoice details should be posted to sales
		 * sale details to be equal to invoice details
		 */
		Optional<SalesInvoice> invoice_ = salesInvoiceRepository.findById(id);
		if(!invoice_.isPresent()) {
			throw new NotFoundException("Invoice not found");
		}
		Optional<User> user = userRepository.findById(userId);
		if(!user.isPresent()) {
			throw new NotFoundException("User not found");
		}
		if(invoice_.get().getStatus().equals("APPROVED")) {
			invoice_.get().setStatus("COMPLETED");
			invoice_.get().setCompletedUser(user.get());
			salesInvoiceRepository.save(invoice_.get());
		}else {
			throw new InvalidOperationException("Only an approved invoice can be completed");
		}		
		/**
    	 * Create a sale
    	 * to save a sale with sale details
    	 * the details should be the same as
    	 * receipt details
    	 */
		SalesInvoice salesInvoice = salesInvoiceRepository.findById(id).get();
    	Sale sale = new Sale();
    	sale.setSalesInvoice(salesInvoice);
    	saleRepository.saveAndFlush(sale);    	
    	for(SalesInvoiceDetail detail : salesInvoice.getSalesInvoiceDetails()) {
    		SaleDetail saleDetail = new SaleDetail();
    		saleDetail.setSale(sale);
    		saleDetail.setCode(detail.getCode());
    		saleDetail.setDescription(detail.getDescription());
    		saleDetail.setQty(detail.getQty());
    		saleDetail.setCostPriceVatIncl(detail.getCostPriceVatIncl());
    		saleDetail.setCostPriceVatExcl(detail.getCostPriceVatExcl());
    		saleDetail.setSellingPriceVatIncl(detail.getSellingPriceVatIncl());
    		saleDetail.setSellingPriceVatExcl(detail.getSellingPriceVatExcl());
    		saleDetail.setDiscount(detail.getDiscount());
    		
    		saleDetailRepository.save(saleDetail);    		
    	} 
		return true;		
	}
	
	/**
	 * Archive a sale invoice
	 * @param id
	 * @return
	 */
	@Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/sales_invoices/archive_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean archiveSalesInvoice(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
		Optional<SalesInvoice> invoice_ = salesInvoiceRepository.findById(id);
		if(!invoice_.isPresent()) {
			throw new NotFoundException("Invoice not found");
		}
		if(invoice_.get().getStatus().equals("COMPLETED")) {
			invoice_.get().setStatus("ARCHIVED");
			salesInvoiceRepository.save(invoice_.get());
		}else {
			throw new InvalidOperationException("Only a completed invoice can be archived");
		}
		return true;		
	}

}
