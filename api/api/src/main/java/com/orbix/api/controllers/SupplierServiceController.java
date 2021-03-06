/**
 * 
 */
package com.orbix.api.controllers;

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

import com.orbix.api.accessories.Formater;
import com.orbix.api.exceptions.InvalidOperationException;
import com.orbix.api.exceptions.NotFoundException;
import com.orbix.api.exceptions.ResourceNotFoundException;
import com.orbix.api.models.Supplier;
import com.orbix.api.repositories.SupplierRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class SupplierServiceController {

    @Autowired
    SupplierRepository supplierRepository;
    
    /**
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/suppliers", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<Supplier> getAllSuppliers(@RequestHeader("user_id") Long userId) {
        return supplierRepository.findAll();
    }
    
    /**
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value="/suppliers/names")
    public Iterable<Supplier> getAllSupplierNames(@RequestHeader("user_id") Long userId) {
        return supplierRepository.getNames();
    }
    
    /**
     * @param id
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/suppliers/get_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    public Supplier getSupplierById(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
        return supplierRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("Supplier not found"));
    }
    
    /**
     * @param code
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/suppliers/get_by_code", produces=MediaType.APPLICATION_JSON_VALUE)
    public Supplier getSupplierByCode(@RequestParam(name = "code") String code, @RequestHeader("user_id") Long userId) {
        return supplierRepository.findByCode(code)
                .orElseThrow(() -> new NotFoundException("Resource not found"));
    }
    
    /**
     * @param name
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/suppliers/get_by_name", produces=MediaType.APPLICATION_JSON_VALUE)
    public Supplier getSupplierByName(@RequestParam(name = "name") String name, @RequestHeader("user_id") Long userId) {
        return supplierRepository.findByName(name)
                .orElseThrow(() -> new NotFoundException("Resource not found"));
    }
    
    /**
     * @param supplier
     * @return a new supplier
     * @throws Exception
     */
    /**
     * @param supplier
     * @param userId
     * @return
     * @throws Exception
     */
    @RequestMapping(method = RequestMethod.POST, value="/suppliers/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Supplier createSupplier(@Valid @RequestBody Supplier supplier, @RequestHeader("user_id") Long userId) throws Exception {  	
    	String random = String.valueOf(Math.random()).replace(".", "") + String.valueOf(Math.random()).replace(".", "");
    	supplier.setCode(random); 
    	supplierRepository.saveAndFlush(supplier);  	
    	String serial = supplier.getId().toString();    	
    	String code = "S-"+Formater.formatSix(serial);
    	supplier.setCode(code);   	
    	supplierRepository.saveAndFlush(supplier);
    	return supplier;
    }
    /**
     * @param supplierId
     * @param supplierDetails
     * @param userId
     * @return
     * @throws Exception
     */
    @RequestMapping(method = RequestMethod.PUT, value="/suppliers/edit_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Supplier updateSupplier(@RequestParam(name = "id") Long supplierId,
            								@Valid @RequestBody Supplier supplierDetails, @RequestHeader("user_id") Long userId) throws Exception {
		Supplier supplier = supplierRepository.findById(supplierId)
                .orElseThrow(() -> new NotFoundException("Supplier not found"));
		supplier = supplierDetails;     
//edit later 		
    	return supplierRepository.saveAndFlush(supplier);
    }
    
    /**
     * @param code
     * @param supplierDetails
     * @param userId
     * @return
     * @throws Exception
     */
    @RequestMapping(method = RequestMethod.PUT, value="/suppliers/edit_by_code", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Supplier updateSupplierByCode(@RequestParam(name = "code") String code,
            								@Valid @RequestBody Supplier supplierDetails, @RequestHeader("user_id") Long userId) throws Exception {
		Supplier supplier = supplierRepository.findByCode(code)
                .orElseThrow(() -> new NotFoundException("Supplier not found"));
		supplier = supplierDetails;     
		
    	return supplierRepository.saveAndFlush(supplier);
    }
    
    /**
     * @param supplierId
     * @param userId
     * @return
     */
    @DeleteMapping("/suppliers/delete_by_id")
    @Transactional
    public ResponseEntity<?> deleteSupplier(@RequestParam(name = "id") Long supplierId, @RequestHeader("user_id") Long userId) {
    	Supplier supplier = supplierRepository.findById(supplierId)
                .orElseThrow(() -> new ResourceNotFoundException("Supplier", "id", supplierId));
    	this.checkUsageBeforeDelete(supplier);
    	supplierRepository.delete(supplier);
        return ResponseEntity.ok().build();
    }
    
    /**
     * @param supplier
     * @return
     */
    private boolean checkUsageBeforeDelete(Supplier supplier) {
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
