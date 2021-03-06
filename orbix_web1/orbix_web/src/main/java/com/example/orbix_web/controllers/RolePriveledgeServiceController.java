/**
 * 
 */
package com.example.orbix_web.controllers;

import java.util.List;
import java.util.NoSuchElementException;

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

import com.example.orbix_web.exceptions.InvalidOperationException;
import com.example.orbix_web.exceptions.NotFoundException;
import com.example.orbix_web.exceptions.ResourceNotFoundException;
import com.example.orbix_web.models.Role;
import com.example.orbix_web.models.RolePriveledge;
import com.example.orbix_web.repositories.RolePriveledgeRepository;
import com.example.orbix_web.repositories.RoleRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class RolePriveledgeServiceController {
	@Autowired
    RoleRepository roleRepository;
	@Autowired
    RolePriveledgeRepository rolePriveledgeRepository;
	
	// Get All Priveledges by role
    @RequestMapping(method = RequestMethod.GET, value = "/priveledges/get_by_role_name", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<RolePriveledge> getAllRoles(@RequestParam(name = "role_name") String roleName) {
    	Role role = roleRepository.findByName(roleName)
                .orElseThrow(() -> new NotFoundException("Role not found"));
        return rolePriveledgeRepository.findByRole(role);
    }
    
 // Get a Single Role by name
    @RequestMapping(method = RequestMethod.GET, value = "/role_priveledges/get_by_role_name_and_name", produces=MediaType.APPLICATION_JSON_VALUE)
    public RolePriveledge getPriveledgeByRoleNameAndName(@RequestParam(name = "role_name") String roleName, @RequestParam(name = "name") String name) {
    	Role role = roleRepository.findByName(roleName)
                .orElseThrow(() -> new NotFoundException("Role not found"));
        return rolePriveledgeRepository.findByRoleAndName(role,name)
                .orElseThrow(() -> new ResourceNotFoundException("Role", "rolename", roleName));
    }
    
 // Create a new Role
    @RequestMapping(method = RequestMethod.POST, value = "/role_priveledges/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    public RolePriveledge createRolePriveledge(@Valid @RequestBody RolePriveledge rolePriveledge) {
    	Role role = roleRepository.findByName(rolePriveledge.getRole().getName())
                .orElseThrow(() -> new NotFoundException("Role not found"));
    	RolePriveledge rp;
    	boolean valid = true;
    	try {
    		rp = rolePriveledgeRepository.findByRoleAndName(role,rolePriveledge.getName()).get();
    		System.out.println(rolePriveledge.getRole().getName());
    		valid = false;
    		if(rp == null) {
    			valid = true;
    		}
    	}	
		catch(NoSuchElementException e) {
			valid = true;
		}
    	catch(Exception e) {
    		System.out.println(e.toString());
    		valid =false;
    	}
    	if (valid == true) {
    		roleRepository.save(role);
    		rolePriveledge.setRole(role);
    		rolePriveledgeRepository.save(rolePriveledge);
    	}    	
        return rolePriveledge;
    }
 
 // Delete a Role
    @RequestMapping(method = RequestMethod.DELETE, value = "/role_priveledges/delete/role_name={role_name}&name={name}")
    public ResponseEntity<Object> deleteRolePriveledge(@PathVariable(value = "role_name") String roleName, @PathVariable(value = "name") String name) {
    	System.out.println("Deleting");
    	Role role = roleRepository.findByName(roleName)
                .orElseThrow(() -> new NotFoundException("Role not found"));
    	RolePriveledge rolePriveledge = rolePriveledgeRepository.findByRoleAndName(role,name)
                .orElseThrow(() -> new ResourceNotFoundException("Role", "rolename", roleName));
    	if(role.getName().equals("ADMIN") && rolePriveledge.getName().equals("ADMIN")) {
    		return new ResponseEntity<>("Deleting this priveledge is not allowed", HttpStatus.OK);
    	}
    	rolePriveledgeRepository.delete(rolePriveledge);
    	return new ResponseEntity<>("Priveledge removed successifully", HttpStatus.OK);
    }
	
}
