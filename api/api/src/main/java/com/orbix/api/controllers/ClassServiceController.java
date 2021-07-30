/**
 * 
 */
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
import org.springframework.web.bind.annotation.GetMapping;
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
import com.orbix.api.repositories.ClassRepository;
import com.orbix.api.repositories.DepartmentRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class ClassServiceController {

    @Autowired
    ClassRepository clasRepository;
    @Autowired
    DepartmentRepository departmentRepository;
    
    /**
     * @param userId
     * @return
     */
    @GetMapping("/classes")
    public List<Clas> getAllClasses(@RequestHeader("user_id") Long userId) {
        return clasRepository.findAll();
    }
   
    /**
     * @param departmentName
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/classes/get_by_department_name")
    public List<Clas> getAllDepartmentClasses(@RequestParam(name = "department_name") String departmentName, @RequestHeader("user_id") Long userId) {
    	Optional<Department> department = departmentRepository.findByName(departmentName);
    	if(!department.isPresent()) {
    		throw new NotFoundException("Department not found");
    	}
    	return clasRepository.findByDepartment(department.get());   	
    }
    
    /**
     * @param userId
     * @return
     */
    @GetMapping(value="/classes/class_names")
    public Iterable<Clas> getAllClassByNames(@RequestHeader("user_id") Long userId) {
        return clasRepository.getNames();
    }
    
    /**
     * @param id
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/classes/get_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public Clas getById(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
        return clasRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("Class not found"));
    }
    
    /**
     * @param name
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/classes/get_by_name", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Clas getByName(@RequestParam(name = "name") String name, @RequestHeader("user_id") Long userId) {
        return clasRepository.findByName(name)
                .orElseThrow(() -> new NotFoundException("Resource not found"));
    }
    
    /**
     * @param clas
     * @param userId
     * @return
     * @throws Exception
     */
    @RequestMapping(method = RequestMethod.POST, value="/classes/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Clas createClas(@Valid @RequestBody Clas clas, @RequestHeader("user_id") Long userId) throws Exception {    	
    	Department department = departmentRepository.findByName(clas.getDepartment().getName())
                .orElseThrow(() -> new MissingInformationException("Department required"));
    	department.setName(clas.getDepartment().getName());
    	departmentRepository.save(department);   	  	
    	clas.setDepartment(department);
    	
    	String random = String.valueOf(Math.random()).replace(".", "");
    	clas.setCode(random); 
    	clasRepository.saveAndFlush(clas);    	
    	String serial = clas.getId().toString();    	
    	String code = Formater.formatFive(serial);
    	clas.setCode(code); 
    	clasRepository.saveAndFlush(clas);    	
    	return clas;
    }
    
    /**
     * @param clasId
     * @param clasDetails
     * @param userId
     * @return
     * @throws Exception
     */
    @RequestMapping(method = RequestMethod.PUT, value="/classes/edit_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    public Clas updateClas(@RequestParam(name = "id") Long clasId,
            								@Valid @RequestBody Clas clasDetails, @RequestHeader("user_id") Long userId) throws Exception {
		Clas clas = clasRepository.findById(clasId)
                .orElseThrow(() -> new NotFoundException("Class not found"));
		clas = clasDetails;     		
    	return clasRepository.saveAndFlush(clas);
    }
    
    /**
     * @param clasCode
     * @param userId
     * @return
     */
    @GetMapping("/classes/get_by_code")
    public Clas getClassByClassCode(@RequestParam(value = "class_code") String clasCode, @RequestHeader("user_id") Long userId) {
        return clasRepository.findByCode(clasCode)
                .orElseThrow(() -> new ResourceNotFoundException("Class", "class_code", clasCode));
    }

    /**
     * @param clasId
     * @param userId
     * @return
     */
    @DeleteMapping("/classes/delete_by_id")
    public ResponseEntity<?> deleteClass(@RequestParam(name = "id") Long clasId, @RequestHeader("user_id") Long userId) {
    	Clas clas = clasRepository.findById(clasId)
                .orElseThrow(() -> new ResourceNotFoundException("Class", "id", clasId));

    	clasRepository.delete(clas);
        return ResponseEntity.ok().build();
    }
}
