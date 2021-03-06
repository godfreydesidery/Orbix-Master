/**
 * 
 */
package com.orbix.api.controllers;

import java.util.List;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
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
import com.orbix.api.exceptions.ResourceNotFoundException;
import com.orbix.api.models.Clas;
import com.orbix.api.models.Department;
import com.orbix.api.models.SubClass;
import com.orbix.api.repositories.ClassRepository;
import com.orbix.api.repositories.DepartmentRepository;
import com.orbix.api.repositories.SubClassRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class SubClassServiceController {
	
	@Autowired
    SubClassRepository subClassRepository;
	@Autowired
    ClassRepository clasRepository;
    @Autowired
    DepartmentRepository departmentRepository;
    
    /**
     * @param userId
     * @return
     */
    @GetMapping("/sub_classes")
    public List<SubClass> getAllSubClasses(@RequestHeader("user_id") Long userId) {
        return subClassRepository.findAll();
    }
	
    /**
     * @param id
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/sub_classes/get_by_id")
    public SubClass getSubClassById(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {	
        return subClassRepository.findById(id)
        		.orElseThrow(() -> new NotFoundException("Sub Class not found"));
    }
    
    // Get All Classes
    /**
     * @param class_name
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/sub_classes/get_by_class_name", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<SubClass> getAllClassesSubClasses(@RequestParam(name = "class_name") String class_name, @RequestHeader("user_id") Long userId) {
    	Clas clas = clasRepository.findByName(class_name)
                .orElseThrow(() -> new NotFoundException("Class "+class_name+" does not exist"));    	
        return subClassRepository.findByClas(clas);
    }
    
    /**
     * @param id
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/sub_classes/get_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public SubClass getById(@RequestParam(value = "id") Long id, @RequestHeader("user_id") Long userId) {
        return subClassRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("Sub-Class not found"));
    }
    
    /**
     * @param name
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/sub_classes/get_by_name", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public SubClass getByName(@RequestParam(value = "name") String name, @RequestHeader("user_id") Long userId) {
        return subClassRepository.findByName(name)
                .orElseThrow(() -> new NotFoundException("Resource not found"));
    }
    
    /**
     * @param subClass
     * @param userId
     * @return
     * @throws Exception
     */
    @RequestMapping(method = RequestMethod.POST, value="/sub_classes/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public SubClass createSubClass(@Valid @RequestBody SubClass subClass, @RequestHeader("user_id") Long userId) throws Exception {
    	Department department = departmentRepository.findByName(subClass.getDepartment().getName())
                .orElseThrow(() -> new MissingInformationException("Department required"));
    	departmentRepository.save(department);
		Clas clas = clasRepository.findByName(subClass.getClas().getName())
                .orElseThrow(() -> new MissingInformationException("Class required"));
		clasRepository.save(clas);
		
		subClass.setDepartment(department);
		subClass.setClas(clas);
		
		String random = String.valueOf(Math.random()).replace(".", "");
		subClass.setCode(random); 
		subClassRepository.saveAndFlush(subClass);    	
    	String serial = subClass.getId().toString();    	
    	String code = Formater.formatFive(serial);
    	subClass.setCode(code);     	
    	return subClassRepository.saveAndFlush(subClass);  	
    }
    
    /**
     * @param id
     * @param subClassDetails
     * @param userId
     * @return
     * @throws Exception
     */
    @RequestMapping(method = RequestMethod.PUT, value="/sub_classes/edit_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public SubClass updateSubClass(@RequestParam(name = "id") Long id,
            								@Valid @RequestBody SubClass subClassDetails, @RequestHeader("user_id") Long userId) throws Exception {
    	SubClass subClass =subClassRepository.findById(id)
    			.orElseThrow(() -> new NotFoundException("Sub-class not found"));
    	subClass = subClassDetails;
    	
    	Department department = departmentRepository.findByName(subClassDetails.getDepartment().getName())
                .orElseThrow(() -> new NotFoundException("Department not found"));
    	departmentRepository.save(department);
		Clas clas = clasRepository.findByName(subClassDetails.getClas().getName())
                .orElseThrow(() -> new NotFoundException("Class not found"));
		clasRepository.save(clas);
		
		subClass.setDepartment(department);
		subClass.setClas(clas);
    	return subClassRepository.saveAndFlush(subClass);
    }
    
 // Delete a Department
    @DeleteMapping("/sub_classes/delete_by_id")
    public ResponseEntity<?> deleteClass(@RequestParam(name = "id") Long subClassId) {
    	SubClass subClass = subClassRepository.findById(subClassId)
                .orElseThrow(() -> new ResourceNotFoundException("Sub Class", "id", subClassId));
    	subClassRepository.delete(subClass);
        return ResponseEntity.ok().build();
    }

}
