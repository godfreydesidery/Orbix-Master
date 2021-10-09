/**
 * 
 */
package com.orbix.api.controllers;

import java.util.List;
import java.util.Optional;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
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
import com.orbix.api.exceptions.MissingInformationException;
import com.orbix.api.exceptions.NotFoundException;
import com.orbix.api.models.Material;
import com.orbix.api.models.MaterialCategory;
import com.orbix.api.repositories.MaterialCategoryRepository;
import com.orbix.api.repositories.MaterialRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class MaterialServiceController {
	@Autowired
	MaterialRepository materialRepository;
	@Autowired
	MaterialCategoryRepository materialCategoryRepository;
	
	@RequestMapping(method = RequestMethod.GET, value="/materials", produces=MediaType.APPLICATION_JSON_VALUE)
    public List <Material> getAllMaterials(
    		@RequestHeader("user_id") Long userId) {
        return materialRepository.findAll();
    }
	
	@RequestMapping(method = RequestMethod.GET, value="/materials/get_descriptions", produces=MediaType.APPLICATION_JSON_VALUE)
    public Iterable <MaterialCategory> getAllMaterialNames(
    		@RequestHeader("user_id") Long userId) {
        return materialRepository.getDescriptions();
    }
	
	@RequestMapping(method = RequestMethod.GET, value = "/materials/get_by_id")
    @Transactional
    public Material getMaterialById(
    		@RequestParam(name = "id") Long id, 
    		@RequestHeader("user_id") Long userId) {
        return materialRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("Material not found"));
    }
	
	@RequestMapping(method = RequestMethod.GET, value = "/materials/get_by_code")
    @Transactional
    public Material getMaterialByCode(
    		@RequestParam(name = "code") String code, 
    		@RequestHeader("user_id") Long userId) {
        return materialRepository.findByCode(code)
                .orElseThrow(() -> new NotFoundException("Material not found"));
    }
	
	@RequestMapping(method = RequestMethod.GET, value = "/materials/get_by_name")
    @Transactional
    public Material getMaterialByname(
    		@RequestParam(name = "description") String description, 
    		@RequestHeader("user_id") Long userId) {
        return materialRepository.findByDescription(description)
                .orElseThrow(() -> new NotFoundException("Material not found"));
    }
	
	@RequestMapping(method = RequestMethod.POST, value="/materials/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Material createMaterial(
    		@Valid 
    		@RequestBody Material material, 
    		@RequestHeader("user_id") Long userId) throws Exception {
		if(material.getDescription().isEmpty()) {
			throw new MissingInformationException("Required fields missing");
		}
		Optional<MaterialCategory> category = materialCategoryRepository.findByName(material.getMaterialCategory().getName());
		if(!category.isPresent()) {
			throw new MissingInformationException("Category required");
		}
		material.setMaterialCategory(category.get());
		
		
		String random = String.valueOf(Math.random()).replace(".", "") + String.valueOf(Math.random()).replace(".", "");
		material.setCode(random); 
    	materialRepository.saveAndFlush(material);
    	
    	String serial = material.getId().toString();
    	
    	String code = "MT-"+Formater.formatFive(serial);
    	material.setCode(code);
    	
    	return materialRepository.saveAndFlush(material);
    }
	
	@RequestMapping(method = RequestMethod.PUT, value="/materials/edit_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public boolean editMaterialById(
    		@Valid 
    		@RequestBody Material material, 
    		@RequestParam(name = "id") Long id,
    		@RequestHeader("user_id") Long userId) throws Exception {
		if(material.getDescription().isEmpty()) {
			throw new MissingInformationException("Required fields missing");
		}
		Optional<MaterialCategory> category = materialCategoryRepository.findByName(material.getMaterialCategory().getName());
		if(!category.isPresent()) {
			throw new MissingInformationException("Category required");
		}
		material.setMaterialCategory(category.get());
		
		
    	materialRepository.saveAndFlush(material);
    	
    	return true;
    }
	
	@RequestMapping(method = RequestMethod.GET, value="/materials/categories", produces=MediaType.APPLICATION_JSON_VALUE)
    public List <MaterialCategory> getAllMaterialCategories(
    		@RequestHeader("user_id") Long userId) {
        return materialCategoryRepository.findAll();
    }
	
	@RequestMapping(method = RequestMethod.GET, value="/materials/categories/get_names", produces=MediaType.APPLICATION_JSON_VALUE)
    public Iterable <MaterialCategory> getAllMaterialCategoriesNames(
    		@RequestHeader("user_id") Long userId) {
        return materialCategoryRepository.getNames();
    }
	
	@RequestMapping(method = RequestMethod.GET, value = "/materials/categories/get_by_id")
    @Transactional
    public MaterialCategory getMaterialCategoryById(
    		@RequestParam(name = "id") Long id, 
    		@RequestHeader("user_id") Long userId) {
        return materialCategoryRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("Category not found"));
    }
	
	@RequestMapping(method = RequestMethod.GET, value = "/materials/categories/get_by_no")
    @Transactional
    public MaterialCategory getMaterialCategoryByCode(
    		@RequestParam(name = "no") String no, 
    		@RequestHeader("user_id") Long userId) {
        return materialCategoryRepository.findByNo(no)
                .orElseThrow(() -> new NotFoundException("Category not found"));
    }
	
	@RequestMapping(method = RequestMethod.GET, value = "/materials/categories/get_by_name")
    @Transactional
    public MaterialCategory getMaterialCategoryByname(
    		@RequestParam(name = "name") String name, 
    		@RequestHeader("user_id") Long userId) {
        return materialCategoryRepository.findByName(name)
                .orElseThrow(() -> new NotFoundException("Category not found"));
    }
	
	@RequestMapping(method = RequestMethod.POST, value="/materials/categories/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public MaterialCategory createMaterialCategory(
    		@Valid 
    		@RequestBody MaterialCategory materialCategory, 
    		@RequestHeader("user_id") Long userId) throws Exception {
		if(materialCategory.getName().isEmpty()) {
			throw new MissingInformationException("Required fields missing");
		}
		
		String random = String.valueOf(Math.random()).replace(".", "") + String.valueOf(Math.random()).replace(".", "");
		materialCategory.setNo(random); 
    	materialCategoryRepository.saveAndFlush(materialCategory);
    	
    	String serial = materialCategory.getId().toString();
    	
    	String no = "MC-"+Formater.formatThree(serial);
    	materialCategory.setNo(no);
    	
    	return materialCategoryRepository.saveAndFlush(materialCategory);
    }
	
	@RequestMapping(method = RequestMethod.PUT, value="/materials/categories/edit_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public boolean editMaterialCategoryById(
    		@Valid 
    		@RequestBody MaterialCategory materialCategory, 
    		@RequestParam(name = "id") Long id,
    		@RequestHeader("user_id") Long userId) throws Exception {
		if(materialCategory.getName().isEmpty()) {
			throw new MissingInformationException("Required fields missing");
		}
		
		MaterialCategory category = materialCategoryRepository.findById(id)
				.orElseThrow(() -> new NotFoundException("Record not found"));
		
		category.setName(materialCategory.getName());
		category.setStatus(materialCategory.getStatus());
		
		
    	materialCategoryRepository.saveAndFlush(category);
    	
    	return true;
    }
}
