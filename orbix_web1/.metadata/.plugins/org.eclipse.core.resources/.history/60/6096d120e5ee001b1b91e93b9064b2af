/**
 * 
 */
package com.example.orbix_web.controllers;

import java.util.List;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.example.orbix_web.accessories.Formater;
import com.example.orbix_web.exceptions.InvalidOperationException;
import com.example.orbix_web.exceptions.NotFoundException;
import com.example.orbix_web.exceptions.ResourceNotFoundException;
import com.example.orbix_web.models.CorporateCustomer;
import com.example.orbix_web.models.Supplier;
import com.example.orbix_web.repositories.CorporateCustomerRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class CorporateCustomerServiceController {
	@Autowired
	CorporateCustomerRepository corporateCustomerRepository;
	
	/**
	 * @param userId
	 * @return
	 */
	@RequestMapping(method = RequestMethod.GET, value = "/corporate_customers", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<CorporateCustomer> getAllCorporateCustomers(@RequestHeader("user_id") Long userId) {
        return corporateCustomerRepository.findAll();
    }
	
	/**
	 * @param userId
	 * @return
	 */
	@RequestMapping(method = RequestMethod.GET, value="/corporate_customers/names")
    public Iterable<CorporateCustomer> getAllCustomerNames(@RequestHeader("user_id") Long userId) {
        return corporateCustomerRepository.getNames();
    }
	
	/**
	 * @param id
	 * @param userId
	 * @return
	 */
	@RequestMapping(method = RequestMethod.GET, value = "/corporate_customers/get_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    public CorporateCustomer getCorporateCustomerById(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
        return corporateCustomerRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("Customer not found"));
    }
	
	/**
	 * @param no
	 * @param userId
	 * @return
	 */
	@RequestMapping(method = RequestMethod.GET, value = "/corporate_customers/get_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    public CorporateCustomer getCorporateCustomerByNo(@RequestParam(name = "no") String no, @RequestHeader("user_id") Long userId) {
        return corporateCustomerRepository.findByNo(no)
                .orElseThrow(() -> new NotFoundException("Customer not found"));
    }
	
	/**
	 * @param name
	 * @param userId
	 * @return
	 */
	@RequestMapping(method = RequestMethod.GET, value = "/corporate_customers/get_by_name", produces=MediaType.APPLICATION_JSON_VALUE)
    public CorporateCustomer getCorporateCustomerByName(@RequestParam(name = "name") String name, @RequestHeader("user_id") Long userId) {
        return corporateCustomerRepository.findByName(name)
                .orElseThrow(() -> new NotFoundException("Customer not found"));
    }
	
	/**
	 * @param customer
	 * @param userId
	 * @return
	 * @throws Exception
	 */
	@RequestMapping(method = RequestMethod.POST, value="/corporate_customers/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public CorporateCustomer createCorporateCustomer(@Valid @RequestBody CorporateCustomer customer, @RequestHeader("user_id") Long userId) throws Exception {				
		String random = String.valueOf(Math.random()).replace(".", "") + String.valueOf(Math.random()).replace(".", "");
    	customer.setNo(random); 
    	corporateCustomerRepository.saveAndFlush(customer);   	
    	String serial = customer.getId().toString();
    	String customerNo = "C-"+Formater.formatSix(serial);
    	customer.setNo(customerNo); 
    	customer.setActive(1);
    	return corporateCustomerRepository.saveAndFlush(customer);
    }
	
	/**
	 * @param id
	 * @param customerDetails
	 * @param userId
	 * @return
	 * @throws Exception
	 */
	@RequestMapping(method = RequestMethod.PUT, value="/corporate_customers/edit_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public CorporateCustomer updateCorporateCustomer(@RequestParam(name = "id") Long id,
            								@Valid @RequestBody CorporateCustomer customerDetails, @RequestHeader("user_id") Long userId) throws Exception {
		CorporateCustomer customer = corporateCustomerRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("Customer not found"));
		customer = customerDetails;     
//edit later 		
    	return corporateCustomerRepository.saveAndFlush(customer);
    }
	
	/**
	 * Delete a customer
	 * @param id
	 * @return
	 */
	@DeleteMapping("/corporate_customers/delete_by_id")
    public ResponseEntity<?> deleteCorporateCustomer(@RequestParam(name = "id") Long id) {
    	CorporateCustomer customer = corporateCustomerRepository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException("Customer", "id", id));
    //	this.checkUsageBeforeDelete(supplier);
    	corporateCustomerRepository.delete(customer);
        return ResponseEntity.ok().build();
    }
    
    private boolean checkUsageBeforeDelete(CorporateCustomer customer) {
    	/**
    	 * Checks whether an supplier has been used any where
    	 * returns false if it has not been used
    	 * throw invalid operation exception if it has been used
    	 * to prevent deletion
    	 */
    	boolean used = false;
    	//assume it has been used, to be implemented later
    	used = true;
    	//throw exception
    	if(used == true) {
    		throw new InvalidOperationException("Could not delete. Supplier already in use within the system.");
    	}
    	return used;
    }
}
