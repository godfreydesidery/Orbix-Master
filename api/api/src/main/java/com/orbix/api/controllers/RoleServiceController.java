package com.orbix.api.controllers;

import java.util.List;
import java.util.NoSuchElementException;
import java.util.Optional;

import javax.transaction.Transactional;
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
import com.orbix.api.exceptions.NotFoundException;
import com.orbix.api.models.Priveledge;
import com.orbix.api.models.Role;
import com.orbix.api.repositories.CompanyProfileRepository;
import com.orbix.api.repositories.PriveledgeRepository;
import com.orbix.api.repositories.RoleRepository;

@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class RoleServiceController {
	@Autowired
	RoleRepository roleRepository;
	@Autowired
	PriveledgeRepository priveledgeRepository;
	
	@RequestMapping(method = RequestMethod.GET, value = "/roles")
    public List<Role> getAllDepartments(@RequestHeader("user_id") Long userId) {
        return roleRepository.findAll();
    }
	
	@RequestMapping(method = RequestMethod.GET, value = "/roles/get_by_id", produces=MediaType.APPLICATION_JSON)
    @Transactional
    public Role getDepartmentById(
    		@RequestParam(name = "id") Long id, 
    		@RequestHeader("user_id") Long userId) {
        return roleRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("Role not found"));
    }
	
	@RequestMapping(method = RequestMethod.POST, value = "/roles/new", produces=MediaType.APPLICATION_JSON)
    @ResponseBody
    @Transactional
    public Role createRole(
    		@Valid @RequestBody Role roleDetails,
    		@RequestHeader("user_id") Long userId) {
    	Optional<Role> role = roleRepository.findByName(roleDetails.getName());
        if(role.isPresent()) {
        	throw new InvalidOperationException("Role already exist");
        }
        return roleRepository.saveAndFlush(roleDetails);   	
    }
	
	@RequestMapping(method = RequestMethod.PUT, value = "/roles/edit_by_id", produces=MediaType.APPLICATION_JSON)
    @ResponseBody
    @Transactional
    public Role editRoleById(
    		@Valid @RequestBody Role roleDetails,
    		@RequestParam(name = "id") Long id, 
    		@RequestHeader("user_id") Long userId) {
    	Optional<Role> role = roleRepository.findById(id);
        if(!role.isPresent()) {
        	throw new InvalidOperationException("Role does not exist");
        }
        role.get().setName(roleDetails.getName());
        return roleRepository.saveAndFlush(role.get());   	
    }
	
	@RequestMapping(method = RequestMethod.DELETE, value = "/roles/delete_by_id", produces=MediaType.APPLICATION_JSON)
    @ResponseBody
    @Transactional
    public boolean deleteRoleById( 
    		@RequestParam(name = "id") Long id,
    		@RequestHeader("user_id") Long userId) {
    	Optional<Role> role = roleRepository.findById(id);
        if(!role.isPresent()) {
        	throw new InvalidOperationException("Role does not exist");
        }
        List<Priveledge> priveledges = priveledgeRepository.findByRole(role.get());
        if(priveledges.isEmpty()) {
        	roleRepository.delete(role.get());
        	return true;
        }
        throw new InvalidOperationException("Could not delete role, role already in use");        	
    }
    
}
