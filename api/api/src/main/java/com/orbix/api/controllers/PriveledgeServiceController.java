/**
 * 
 */
package com.orbix.api.controllers;

import java.util.List;
import java.util.NoSuchElementException;
import java.util.Optional;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.orbix.api.exceptions.NotFoundException;
import com.orbix.api.exceptions.ResourceNotFoundException;
import com.orbix.api.models.Priveledge;
import com.orbix.api.models.Role;
import com.orbix.api.repositories.PriveledgeRepository;
import com.orbix.api.repositories.RoleRepository;



/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class PriveledgeServiceController {
	@Autowired
    RoleRepository roleRepository;
	@Autowired
    PriveledgeRepository rolePriveledgeRepository;
	
	// Get All Priveledges by role
    @RequestMapping(method = RequestMethod.GET, value = "/priveledges/get_by_role_name", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<Priveledge> getAllRoles(@RequestParam(name = "role_name") String roleName) {
    	Optional<Role> role = roleRepository.findByName(roleName);
    	if(!role.isPresent()) {
    		throw new NotFoundException("Role not found");
    	}   	
        return rolePriveledgeRepository.findByRole(role.get());
    }
    
 // Get a Single Role by name
    @RequestMapping(method = RequestMethod.GET, value = "/role_priveledges/get_by_role_name_and_name", produces=MediaType.APPLICATION_JSON_VALUE)
    public Priveledge getPriveledgeByRoleNameAndName(@RequestParam(name = "role_name") String roleName, @RequestParam(name = "name") String name) {
    	Optional<Role> role = roleRepository.findByName(roleName);
    	if(!role.isPresent()) {
    		throw new NotFoundException("Role not found");
    	}
        return rolePriveledgeRepository.findByRoleAndName(role.get(),name)
                .orElseThrow(() -> new ResourceNotFoundException("Role", "rolename", roleName));
    }
    
 // Create a new Role
    @RequestMapping(method = RequestMethod.POST, value = "/role_priveledges/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    public Priveledge createPriveledge(@Valid @RequestBody Priveledge priveledge) {
    	System.out.println("Checking");
    	System.out.println("Checking");
    	System.out.println("Checking");
    	System.out.println("Checking");
    	System.out.println("Checking");
    	System.out.println("Checking");
    	System.out.println("Checking");
    	System.out.println("Checking");
    	Role role = roleRepository.findByName(priveledge.getRole().getName())
                .orElseThrow(() -> new NotFoundException("Role not found"));
    	Optional<Priveledge> rp = rolePriveledgeRepository.findByRoleAndName(role,priveledge.getName());
    	if(!rp.isPresent()) {
    		roleRepository.save(role);
    		priveledge.setRole(role);
    		rolePriveledgeRepository.save(priveledge);
    	}
    	
    	return priveledge;   
    }
 
 // Delete a Role
    @RequestMapping(method = RequestMethod.DELETE, value = "/role_priveledges/delete_by_role_name_and_name")
    public ResponseEntity<Object> deleteRolePriveledge(
    		@RequestParam(name = "role_name") String roleName, 
    		@RequestParam(name = "name") String name) {
    	System.out.println("Deleting");
    	Role role = roleRepository.findByName(roleName)
                .orElseThrow(() -> new NotFoundException("Role not found"));
    	Priveledge priveledge = rolePriveledgeRepository.findByRoleAndName(role,name)
                .orElseThrow(() -> new ResourceNotFoundException("Role", "rolename", roleName));
    	if(role.getName().equals("ADMIN") && priveledge.getName().equals("ADMIN")) {
    		return new ResponseEntity<>("Deleting this priveledge is not allowed", HttpStatus.OK);
    	}
    	rolePriveledgeRepository.delete(priveledge);
    	return new ResponseEntity<>("Priveledge removed successifully", HttpStatus.OK);
    }
	
}
