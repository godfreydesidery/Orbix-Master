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
import com.orbix.api.exceptions.InvalidOperationException;
import com.orbix.api.exceptions.NotFoundException;
import com.orbix.api.exceptions.ResourceNotFoundException;
import com.orbix.api.models.Role;
import com.orbix.api.models.User;
import com.orbix.api.repositories.RoleRepository;
import com.orbix.api.repositories.UserRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class UserServiceController {
	@Autowired
	UserRepository userRepository;
	@Autowired
	RoleRepository roleRepository;
	
	/**
	 * Get all users
	 */
	@RequestMapping(method = RequestMethod.GET, value = "/users", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<User> getAllUsers(
    		@RequestHeader("user_id") Long userId) {
        return userRepository.findAll();
    }
	
	/**
	 * Get a single user by id
	 */
	@RequestMapping(method = RequestMethod.GET, value = "/users/get_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    public User getUserById(
    		@RequestParam(name = "id") Long id, 
    		@RequestHeader("user_id") Long userId) {
        return userRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("User not found"));
    }
	
	@RequestMapping(method = RequestMethod.GET, value = "/users/get_by_username", produces=MediaType.APPLICATION_JSON_VALUE)
    public User getUserByUsername(
    		@RequestParam(name = "username") String username, 
    		@RequestHeader("user_id") Long userId) {
        return userRepository.findByUsername(username)
                .orElseThrow(() -> new NotFoundException("User not found"));
    }
	
	/**
	 * Create a new user
	 */
	@RequestMapping(method = RequestMethod.POST, value="/users/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public User createUser(
    		@Valid @RequestBody User user, 
    		@RequestHeader("user_id") Long userId) throws Exception {  	
    	
    	
    	Optional<Role> role;
    	if(!user.getRole().getName().isEmpty()) {
    		role = roleRepository.findByName(user.getRole().getName());
    		roleRepository.saveAndFlush(role.get());
    		user.setRole(role.get());
    	}else {
    		user.setRole(null);
    	}
    	String random = String.valueOf(Math.random()).replace(".", "") + String.valueOf(Math.random()).replace(".", "");
    	user.setRollNo(random); 
    	userRepository.saveAndFlush(user);
    	String serial = user.getId().toString();    	
    	String code = "U-"+Formater.formatSix(serial);
    	user.setRollNo(code);   	
    	return userRepository.saveAndFlush(user);
    }
	
	/**
	 * Update a user by id
	 */
	@RequestMapping(method = RequestMethod.PUT, value="/users/edit_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public User updateUser(
    		@RequestParam(name = "id") Long id,
    		@Valid @RequestBody User userDetails, 
    		@RequestHeader("user_id") Long userId) throws Exception {
		User user = userRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("User not found"));
		if(user.getUsername().equals("admin")) {
			throw new InvalidOperationException("Editing the admin profile is not allowed");
		}
		user.setUsername(userDetails.getUsername());
		user.setFirstName(userDetails.getFirstName());
		user.setSecondName(userDetails.getSecondName());
		user.setLastName(userDetails.getLastName());
		user.setPassword(userDetails.getPassword());
		Optional<Role> role;
		System.out.println("Testing");
    	if(!userDetails.getRole().getName().isEmpty()) {
    		
    		role = roleRepository.findByName(userDetails.getRole().getName());
    		roleRepository.saveAndFlush(role.get());
    		user.setRole(role.get());
    	}else {
    		user.setRole(null);
    	}
//edit later 		
    	return userRepository.saveAndFlush(user);
    }
	
	/**
	 * Delete a user
	 */
	@DeleteMapping("/users/delete_by_id")
    @Transactional
    public ResponseEntity<?> deleteUser(
    		@RequestParam(name = "id") Long id, 
    		@RequestHeader("user_id") Long userId) {
    	User user = userRepository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException("User", "id", id));
    	if(user.getUsername().equals("admin")) {
    		throw new InvalidOperationException("Deleting the admin profile is not allowed");
    	}
    	//this.checkUsageBeforeDelete(user);
    	userRepository.delete(user);
        return ResponseEntity.ok().build();
    }
	
	/**
	 * Activate a user
	 */
	@RequestMapping(method = RequestMethod.PUT, value="/users/activate_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public boolean  activateUser(
    		@RequestParam(name = "id") Long id,
    		@RequestHeader("user_id") Long userId) throws Exception{
		User user = userRepository.findById(id)
				.orElseThrow(() -> new NotFoundException("User does not exist"));
				user.setActive(1);
		return true;
	}
	
	/**
	 * Deactivate a user
	 */
	@RequestMapping(method = RequestMethod.PUT, value="/users/deactivate_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public boolean  deactivateUser(
    		@RequestParam(name = "id") Long id,
    		@RequestHeader("user_id") Long userId) throws Exception{
		User user = userRepository.findById(id)
				.orElseThrow(() -> new NotFoundException("User does not exist"));
				user.setActive(0);
		return true;
	}
}
