/**
 * 
 */
package com.orbix.api.controllers;

import java.util.List;
import java.util.Optional;

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
import com.orbix.api.exceptions.NotFoundException;
import com.orbix.api.exceptions.ResourceNotFoundException;
import com.orbix.api.models.Till;
import com.orbix.api.repositories.TillRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class TillServiceController {

    @Autowired
    TillRepository tillRepository;
    
    /**
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/tills", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<Till> getAllTills(@RequestHeader("user_id") Long userId) {
        return tillRepository.findAll();
    }
    
    /**
     * @param id
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/tills/get_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    public Till getTillById(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
        return tillRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("Till not found"));
    }
    
    /**
     * @param no
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/tills/get_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    public Till getTillByNo(@RequestParam(name = "no") String no, @RequestHeader("user_id") Long userId) {
        return tillRepository.findByNo(no)
                .orElseThrow(() -> new NotFoundException("Till not found"));
    }
    
    @RequestMapping(method = RequestMethod.GET, value = "/tills/get_till_position_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    public Till getTillPositionByNo(@RequestParam(name = "no") String no, @RequestHeader("user_id") Long userId) {
        return tillRepository.findByNo(no)
                .orElseThrow(() -> new NotFoundException("Till not found"));
    }
    
    @RequestMapping(method = RequestMethod.GET, value = "/tills/get_float_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    public Till getFloatByNo(@RequestParam(name = "no") String no, @RequestHeader("user_id") Long userId) {
        return tillRepository.findByNo(no)
                .orElseThrow(() -> new NotFoundException("Till not found"));
    }
    
    /**
     * @param name
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/tills/get_by_name", produces=MediaType.APPLICATION_JSON_VALUE)
    public Till getTillByName(@RequestParam(name = "name") String name, @RequestHeader("user_id") Long userId) {
        return tillRepository.findByName(name)
                .orElseThrow(() -> new NotFoundException("Till not found"));
    }
    
    /**
     * @param computerName
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/tills/get_by_computer_name", produces=MediaType.APPLICATION_JSON_VALUE)
    public Till getTillByComputerName(@RequestParam(name = "computer_name") String computerName, @RequestHeader("user_id") Long userId) {
        return tillRepository.findByComputerName(computerName)
                .orElseThrow(() -> new NotFoundException("Till not found"));
    }
    
    /**
     * @param till
     * @param userId
     * @return
     * @throws Exception
     */
    @RequestMapping(method = RequestMethod.POST, value="/tills/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Till createTill(@Valid @RequestBody Till till, @RequestHeader("user_id") Long userId) throws Exception {  	
    	String random = String.valueOf(Math.random()).replace(".", "") + String.valueOf(Math.random()).replace(".", "");
    	till.setNo(random); 
    	tillRepository.saveAndFlush(till);  	
    	String serial = till.getId().toString();    	
    	String _no = Formater.formatThree(serial);
    	till.setNo(_no);   	
    	return tillRepository.saveAndFlush(till);
    }
    
    /**
     * @param tillId
     * @param tillDetails
     * @param userId
     * @return
     * @throws Exception
     */
    @RequestMapping(method = RequestMethod.PUT, value="/tills/edit_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Till updateTill(@RequestParam(name = "id") Long tillId,
            								@Valid @RequestBody Till tillDetails, @RequestHeader("user_id") Long userId) throws Exception {
		Till till = tillRepository.findById(tillId)
                .orElseThrow(() -> new NotFoundException("Till not found"));
		till.setName(tillDetails.getName());
		till.setComputerName(tillDetails.getComputerName());
		till.setActive(tillDetails.getActive());
    	return tillRepository.saveAndFlush(till);
    }
    
    @RequestMapping(method = RequestMethod.PUT, value="/tills/update_float_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Till updateFloat(
    		@RequestParam(name = "no") String tillNo,
            								@Valid @RequestBody Till till_, 
            								@RequestHeader("user_id") Long userId) throws Exception {
		Till till = tillRepository.findByNo(tillNo)
                .orElseThrow(() -> new NotFoundException("Till not found"));
		till.setFloatBalance(till_.getFloatBalance());		
    	return tillRepository.saveAndFlush(till);
    }
    
    /**
     * @param tillId
     * @param userId
     * @return
     * @throws Exception
     */
    @RequestMapping(method = RequestMethod.PUT, value="/tills/activate_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public boolean activateTill(@RequestParam(name = "id") Long tillId,
            								 @RequestHeader("user_id") Long userId) throws Exception {
		Till till = tillRepository.findById(tillId)
                .orElseThrow(() -> new NotFoundException("Till not found"));
		if(till.getActive() != 1) {
			till.setActive(1);
			return true;
		}else {
			return false;
		}
    }
    /**
     * @param tillId
     * @param userId
     * @return
     * @throws Exception
     */
    @RequestMapping(method = RequestMethod.PUT, value="/tills/deactivate_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public boolean deactivateTill(@RequestParam(name = "id") Long tillId,
            								 @RequestHeader("user_id") Long userId) throws Exception {
		Till till = tillRepository.findById(tillId)
                .orElseThrow(() -> new NotFoundException("Till not found"));
		if(till.getActive() != 0) {
			till.setActive(0);
			return true;
		}else {
			return false;
		}
    }

    /**
     * @param tillId
     * @param userId
     * @return
     */
    @DeleteMapping("/tills/delete_by_id")
    @Transactional
    public ResponseEntity<?> deleteTill(@RequestParam(name = "id") Long tillId, @RequestHeader("user_id") Long userId) {
    	Till till = tillRepository.findById(tillId)
                .orElseThrow(() -> new ResourceNotFoundException("Till", "id", tillId));
    	//this.checkUsageBeforeDelete(supplier);
    	tillRepository.delete(till);
        return ResponseEntity.ok().build();
    }
  
    /**
     * @param tillId
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/tills/get_status_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    public int getTillStatusById(@RequestParam(name = "id") Long tillId, @RequestHeader("user_id") Long userId) {
    	Optional<Till> till = tillRepository.findById(tillId);
    	if(till.isPresent()) {
    		return till.get().getActive();
    	}else {
    		throw new NotFoundException("Till not found");
    	}   	
    } 
    
    /**
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/till_positions", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<Till> getAllTillPositions(@RequestHeader("user_id") Long userId) {
        return tillRepository.findAll();
    }
}
