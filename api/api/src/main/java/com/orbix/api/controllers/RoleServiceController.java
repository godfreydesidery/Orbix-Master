package com.orbix.api.controllers;

import java.util.List;

import javax.transaction.Transactional;
import javax.ws.rs.core.MediaType;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.orbix.api.exceptions.NotFoundException;
import com.orbix.api.models.Role;
import com.orbix.api.repositories.CompanyProfileRepository;
import com.orbix.api.repositories.RoleRepository;

@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class RoleServiceController {
	@Autowired
	RoleRepository roleRepository;
	
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
    
}
