package com.orbix.api.controllers;

import java.util.Optional;

import javax.ws.rs.core.MediaType;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.orbix.api.models.CompanyProfile;
import com.orbix.api.models.Role;
import com.orbix.api.models.User;
import com.orbix.api.repositories.CompanyProfileRepository;

@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class CompanyProfileServiceController {
	@Autowired
	CompanyProfileRepository companyProfileRepository;
	
	@RequestMapping(method = RequestMethod.GET, value = "/company_profile", produces = MediaType.APPLICATION_JSON)
    @ResponseBody
    public CompanyProfile loadCompany() {
		Optional<CompanyProfile> company = companyProfileRepository.findByCompanyKey("1");
		if(!company.isPresent()) {
			CompanyProfile profile = new CompanyProfile();			
			profile.setCompanyKey("1");
			profile.setName("Default");
			profile.setContactName("Default");
			return companyProfileRepository.saveAndFlush(profile);
		}
		return company.get();   	   	
    }
}
