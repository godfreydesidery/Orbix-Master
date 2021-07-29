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
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.orbix.api.accessories.Formater;
import com.orbix.api.exceptions.NotFoundException;
import com.orbix.api.exceptions.ResourceNotFoundException;
import com.orbix.api.models.Department;
import com.orbix.api.repositories.DepartmentRepository;

/**
 * @author GODFREY
 *
 */
/**
 * @author GODFREY
 *
 */
/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class DepartmentServiceController {

    @Autowired
    DepartmentRepository departmentRepository;
    
    /**
     * @param userId
     * @return
     */
    @GetMapping("/departments")
    public List<Department> getAllDepartments(@RequestHeader("user_id") Long userId) {
        return departmentRepository.findAll();
    }
    
    /**
     * @param id
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/departments/get_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public Department getDepartmentById(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
        return departmentRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("Department not found"));
    }
   
    /**
     * @param departmentCode
     * @param userId
     * @return
     */
    @GetMapping("/departments/get_by_code")
    public Department getDepartmentByDepartmentCode(@RequestParam(name = "code") String departmentCode, @RequestHeader("user_id") Long userId) {
    	System.out.println("checked");
        return departmentRepository.findByCode(departmentCode)
                .orElseThrow(() -> new ResourceNotFoundException("Department", "department_code", departmentCode));
    }
    
    /**
     * @param name
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/departments/get_by_name", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public Department getDepartmentByName(@RequestParam(name = "name") String name, @RequestHeader("user_id") Long userId) {
        return departmentRepository.findByName(name)
                .orElseThrow(() -> new NotFoundException("Resource not found"));
    }
    
    /**
     * @param department
     * @param userId
     * @return
     * @throws Exception
     */
    @RequestMapping(method = RequestMethod.POST, value="/departments/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Department createDepartment(@Valid @RequestBody Department department, @RequestHeader("user_id") Long userId) throws Exception {
    	String random = String.valueOf(Math.random()).replace(".", "");
    	department.setCode(random); 
    	departmentRepository.saveAndFlush(department);    	
    	String serial = department.getId().toString();    	
    	String code = Formater.formatThree(serial);
    	department.setCode(code); 
    	departmentRepository.saveAndFlush(department);   	
    	return department;
    }
    
    /**
     * @param departmentId
     * @param departmentDetails
     * @param userId
     * @return
     * @throws Exception
     */
    @RequestMapping(method = RequestMethod.PUT, value="/departments/edit_by_id}", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Department updateDepartment(@RequestParam(value = "id") Long departmentId,
            								@Valid @RequestBody Department departmentDetails, @RequestHeader("user_id") Long userId) throws Exception {
		Department department = departmentRepository.findById(departmentId)
                .orElseThrow(() -> new NotFoundException("Department not found"));
		department = departmentDetails;     		
    	return departmentRepository.saveAndFlush(department);
    }
   
    /**
     * @param userId
     * @return
     */
    @GetMapping(value="/departments/department_names")
    public Iterable<Department> getAllDepartmentByNames(@RequestHeader("user_id") Long userId) {
        return departmentRepository.getNames();
    }
   
    /**
     * @param departmentId
     * @param departmentDetails
     * @param userId
     * @return
     */
    @PutMapping("/departments/edit_by_id")
    public Department updateNote(@RequestParam(name = "id") Long departmentId,
                                            @Valid @RequestBody Department departmentDetails, @RequestHeader("user_id") Long userId) {

        Department department = departmentRepository.findById(departmentId)
                .orElseThrow(() -> new ResourceNotFoundException("Department", "id", departmentId));

        department = departmentDetails;

        Department updatedDepartment = departmentRepository.save(department);
        return updatedDepartment;
    }

    /**
     * @param departmentId
     * @param userId
     * @return
     */
    @DeleteMapping("/departments/delete_by_id")
    @Transactional
    public ResponseEntity<?> deleteDepartment(@RequestParam(name = "id") Long departmentId, @RequestHeader("user_id") Long userId) {
    	Department department = departmentRepository.findById(departmentId)
                .orElseThrow(() -> new ResourceNotFoundException("Department", "id", departmentId));

    	departmentRepository.delete(department);

        return ResponseEntity.ok().build();
    }
}
