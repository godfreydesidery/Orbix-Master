package com.orbix.api.controllers;

import java.util.Optional;

import javax.validation.Valid;
import javax.ws.rs.core.MediaType;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.orbix.api.exceptions.InvalidOperationException;
import com.orbix.api.models.Role;
import com.orbix.api.models.User;
import com.orbix.api.repositories.PriveledgeRepository;
import com.orbix.api.repositories.UserRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class AuthServiceController {
	@Autowired
	UserRepository userRepository;
	@Autowired
	PriveledgeRepository priveledgeRepository;
	
    /**
     * @param user_id
     * @param priveledge
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/authorize", produces = MediaType.APPLICATION_JSON)
    @ResponseBody
    public boolean authorizeUser(
    		@RequestParam(name = "user_id") Long user_id, 
    		@RequestParam(name = "priveledge") String priveledge,
    		@RequestHeader(name = "user_id") Long userId) {     	    	
    	Optional<User> user = userRepository.findByIdAndActive(user_id, 1);    	   	
    	if(user.isPresent() == true) {
    		Role role =user.get().getRole();
    		if(priveledgeRepository.existsByRoleAndName(role, priveledge) ) {
    			return true;
    		}  		
    		return false;
    	}    	
    	return false;   	
    }
    
    @RequestMapping(value = "/login", produces = MediaType.APPLICATION_JSON)
    @ResponseBody
    public User login(
    		@Valid @RequestBody User _user) {     	    	
    	Optional<User> user = userRepository.findByUsernameAndActive(_user.getUsername(), 1);
    	if(user.isPresent()) {
    		if(user.get().getPassword().equals(_user.getPassword())) {
    			return user.get();
    		}
    		throw new InvalidOperationException("Invalid username and password");
    	}
    	throw new InvalidOperationException("Invalid username and password");    		
    }
}
