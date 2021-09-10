package com.orbix.api.controllers;

import java.util.Optional;

import javax.validation.Valid;
import javax.ws.rs.core.MediaType;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.orbix.api.accessories.Formater;
import com.orbix.api.models.CompanyProfile;
import com.orbix.api.models.Department;
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
	
	@RequestMapping(method = RequestMethod.POST, value="/company_profile/save", produces=MediaType.APPLICATION_JSON)
    @ResponseBody
    @Transactional
    public CompanyProfile saveProfile(@Valid @RequestBody CompanyProfile profile_, @RequestHeader("user_id") Long userId) throws Exception {
    	CompanyProfile profile = companyProfileRepository.findByCompanyKey("1").get();
    	profile.setName(profile_.getName());
    	profile.setContactName(profile_.getContactName());
    	profile.setTin(profile_.getTin());
    	profile.setVrn(profile_.getVrn());
    	profile.setPhysicalAddress(profile_.getPhysicalAddress());
    	profile.setPostCode(profile_.getPostCode());
    	profile.setPostAddress(profile_.getPostAddress());
    	profile.setTelephone(profile_.getTelephone());
    	profile.setMobile(profile_.getMobile());
    	profile.setEmail(profile_.getEmail());
    	profile.setFax(profile_.getFax());
    	profile.setLogo(profile_.getLogo());
    	profile.setBankAccountName(profile_.getBankAccountName());
    	profile.setBankAddress(profile_.getBankAddress());
    	profile.setBankPostCode(profile_.getBankPostCode());
    	profile.setBankName(profile_.getBankName());
    	profile.setBankAccountNo(profile_.getBankAccountNo());
    	return companyProfileRepository.saveAndFlush(profile);
    	
    }
}
