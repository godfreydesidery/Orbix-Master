/**
 * 
 */
package com.example.orbix_web.controllers;

import java.util.List;
import java.util.Optional;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.example.orbix_web.exceptions.NotFoundException;
import com.example.orbix_web.models.Clas;
import com.example.orbix_web.models.Department;
import com.example.orbix_web.models.Item;
import com.example.orbix_web.models.Product;
import com.example.orbix_web.models.SubClass;
import com.example.orbix_web.models.Supplier;
import com.example.orbix_web.repositories.ClasRepository;
import com.example.orbix_web.repositories.DepartmentRepository;
import com.example.orbix_web.repositories.ItemRepository;
import com.example.orbix_web.repositories.ProductRepository;
import com.example.orbix_web.repositories.SubClassRepository;
import com.example.orbix_web.repositories.SupplierRepository;

/**
 * @author GODFREY
 *
 */
@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class ProductServiceController {
	@Autowired
    ProductRepository productRepository;
	@Autowired
    SupplierRepository supplierRepository;
	@Autowired
    DepartmentRepository departmentRepository;
	@Autowired
    ClasRepository classRepository;
	@Autowired
    SubClassRepository subClassRepository;
	
    /**
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value="/products", produces=MediaType.APPLICATION_JSON_VALUE)
    public List <Product> getAllProducts(@RequestHeader("user_id") Long userId) {
        return productRepository.findAll();
    }
	
    /**
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value="/products/descriptions", produces=MediaType.APPLICATION_JSON_VALUE)
    public Iterable <Product> getAllProductsDescription(@RequestHeader("user_id") Long userId) {
        return productRepository.getDescription();
    }
	
	/**
	 * @param product
	 * @param userId
	 * @return
	 * @throws Exception
	 */
	@RequestMapping(method = RequestMethod.POST, value="/products/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Product createProduct(@Valid @RequestBody Product product, @RequestHeader("user_id") Long userId) throws Exception {
		if(!product.getPrimarySupplier().getName().isEmpty()){
			String supplierName = (product.getPrimarySupplier()).getName();
			Optional<Supplier> supplier = supplierRepository.findByName(supplierName);
			if(supplier.isPresent()) {
		    	supplierRepository.save(supplier.get());
		    	product.setPrimarySupplier(supplier.get());
			}else {
				product.setPrimarySupplier(null);
			}
		}else {
			product.setPrimarySupplier(null);
		}
		if(!product.getDepartment().getName().isEmpty()){
			String departmentName = (product.getDepartment()).getName();
			Optional<Department> department = departmentRepository.findByName(departmentName);
			if(department.isPresent()) {
		    	departmentRepository.save(department.get());
		    	product.setDepartment(department.get());
			}else {
				product.setDepartment(null);
			}
		}else {
			product.setDepartment(null);
		}
		if(!product.getClas().getName().isEmpty()){
			String className = (product.getClas()).getName();
			Optional<Clas> clas = classRepository.findByName(className);
			if(clas.isPresent()) {
		    	classRepository.save(clas.get());
		    	product.setClas(clas.get());
			}else {
				product.setClas(null);
			}
		}else {
			product.setClas(null);
		}
		
		if(!product.getSubClass().getName().isEmpty()){
			String subClassName = (product.getSubClass()).getName();
			Optional<SubClass> subClass = subClassRepository.findByName(subClassName);
			if(subClass.isPresent()) {
		    	subClassRepository.save(subClass.get());
		    	product.setSubClass(subClass.get());
			}else {
				product.setSubClass(null);
			}
		}else {
			product.setSubClass(null);
		}
		
    	return productRepository.saveAndFlush(product);
    }
	
	/**
	 * @param productId
	 * @param inventoryDetails
	 * @param userId
	 * @return
	 * @throws Exception
	 */
	@RequestMapping(method = RequestMethod.PUT, value="/products/update_inventory_by_product_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    public Product updateInventory(@RequestParam(name = "product_id") Long productId,
            								@Valid @RequestBody Product inventoryDetails, @RequestHeader("user_id") Long userId) throws Exception {
		Product product = productRepository.findById(productId)
                .orElseThrow(() -> new NotFoundException("Item not found"));
		product.setStock(inventoryDetails.getStock());
		product.setMaximumStock(inventoryDetails.getMaximumStock()); 
		product.setMinimumStock(inventoryDetails.getMinimumStock());
		product.setDefaultReorderLevel(inventoryDetails.getDefaultReorderLevel());
		product.setDefaultReorderQty(inventoryDetails.getDefaultReorderQty());			
    	productRepository.saveAndFlush(product);
    	System.out.println(product.getStock());
    	System.out.println(inventoryDetails.getStock());
    	return product;
    }
	
	/**
	 * @param productId
	 * @param productDetails
	 * @param userId
	 * @return
	 * @throws Exception
	 */
	@RequestMapping(method = RequestMethod.PUT, value="/products/edit_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Product updateProduct(@RequestParam(name = "id") Long productId,
            								@Valid @RequestBody Product productDetails, @RequestHeader("user_id") Long userId) throws Exception {
		Product product = productRepository.findById(productId)
                .orElseThrow(() -> new NotFoundException("Product not found"));
		
		if(!productDetails.getPrimarySupplier().getName().isEmpty()) {
			String supplierName = (productDetails.getPrimarySupplier()).getName();
			Optional<Supplier> supplier = supplierRepository.findByName(supplierName);
			if(supplier.isPresent()) {
		    	supplierRepository.save(supplier.get());
		    	product.setPrimarySupplier(supplier.get());
			}else {
				product.setPrimarySupplier(null);
			}
		}else {
			product.setPrimarySupplier(null);
		}
		
		if(!productDetails.getDepartment().getName().isEmpty()) {
			String departmentName = (productDetails.getDepartment()).getName();
			Optional<Department> department = departmentRepository.findByName(departmentName);
			if(department.isPresent()) {
				departmentRepository.save(department.get());
		    	product.setDepartment(department.get());
			}else {
				product.setDepartment(null);
			}
		}else {
			product.setDepartment(null);
		}
		
		if(!productDetails.getClas().getName().isEmpty()) {
			String clasName = (productDetails.getClas()).getName();
			Optional<Clas> clas = classRepository.findByName(clasName);
			if(clas.isPresent()) {
				classRepository.save(clas.get());
		    	product.setClas(clas.get());
			}else {
				product.setClas(null);
			}
		}else {
			product.setClas(null);
		}
		
		if(!productDetails.getSubClass().getName().isEmpty()) {
			String subClassName = (productDetails.getSubClass()).getName();
			Optional<SubClass> subClass = subClassRepository.findByName(subClassName);
			if(subClass.isPresent()) {
				subClassRepository.save(subClass.get());
		    	product.setSubClass(subClass.get());
			}else {
				product.setSubClass(null);
			}
		}else {
			product.setSubClass(null);
		}
		
		/**
		 * To avoid dirty wrinting the inventory
		 */
		product.setPrimaryBarcode(productDetails.getPrimaryBarcode());
		product.setCode(productDetails.getCode());
		product.setDescription(productDetails.getDescription());
		product.setShortDescription(productDetails.getShortDescription());
		product.setCommonDescription(productDetails.getCommonDescription());
		product.setStandardUom(productDetails.getStandardUom());
		product.setPackSize(productDetails.getPackSize());
		product.setIngredients(productDetails.getIngredients());
		product.setCostPriceVatIncl(productDetails.getCostPriceVatIncl());
		product.setCostPriceVatExcl(productDetails.getCostPriceVatExcl());
		product.setSellingPriceVatIncl(productDetails.getSellingPriceVatIncl());
		product.setSellingPriceVatExcl(productDetails.getSellingPriceVatExcl());
		product.setProfitMargin(productDetails.getProfitMargin());
		product.setVat(productDetails.getVat());
		product.setDiscount(productDetails.getDiscount());
		product.setStatus(productDetails.getStatus());
		product.setSellable(productDetails.getSellable());
		product.setReturnable(productDetails.getReturnable());
    	return productRepository.saveAndFlush(product); 	
    	/**
    	 * remember to update stock card, and price change log
    	 */
    }
	
	
	/**
	 * @param code
	 * @param productDetails
	 * @param userId
	 * @return
	 * @throws Exception
	 */
	@RequestMapping(method = RequestMethod.PUT, value="/products/edit_by_code", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public Product updateProductByCode(@RequestParam(name = "code") String code,
            								@Valid @RequestBody Product productDetails, @RequestHeader("user_id") Long userId) throws Exception {
		Product product = productRepository.findByCode(code)
                .orElseThrow(() -> new NotFoundException("Product not found"));		
		
		if(productDetails.getPrimarySupplier().getName() != null) {
			String supplierName = (productDetails.getPrimarySupplier()).getName();
			Optional<Supplier> supplier = supplierRepository.findByName(supplierName);
			if(supplier.isPresent()) {
		    	supplierRepository.save(supplier.get());
		    	product.setPrimarySupplier(supplier.get());
			}else {
				product.setPrimarySupplier(null);
			}
		}else {
			product.setPrimarySupplier(null);
		}
		
		if(productDetails.getDepartment().getName() != null) {
			String departmentName = (productDetails.getDepartment()).getName();
			Optional<Department> department = departmentRepository.findByName(departmentName);
			if(department.isPresent()) {
				departmentRepository.save(department.get());
		    	product.setDepartment(department.get());
			}else {
				product.setDepartment(null);
			}
		}else {
			product.setDepartment(null);
		}
		
		if(productDetails.getClas().getName() != null) {
			String clasName = (productDetails.getClas()).getName();
			Optional<Clas> clas = classRepository.findByName(clasName);
			if(clas.isPresent()) {
				classRepository.save(clas.get());
		    	product.setClas(clas.get());
			}else {
				product.setClas(null);
			}
		}else {
			product.setClas(null);
		}
		
		if(productDetails.getSubClass().getName() != null) {
			String subClassName = (productDetails.getSubClass()).getName();
			Optional<SubClass> subClass = subClassRepository.findByName(subClassName);
			if(subClass.isPresent()) {
				subClassRepository.save(subClass.get());
		    	product.setSubClass(subClass.get());
			}else {
				product.setSubClass(null);
			}
		}else {
			product.setSubClass(null);
		}
		
		/**
		 * To avoid dirty wrinting the inventory
		 */
		product.setPrimaryBarcode(productDetails.getPrimaryBarcode());
		product.setDescription(productDetails.getDescription());
		product.setShortDescription(productDetails.getShortDescription());
		product.setCommonDescription(productDetails.getCommonDescription());
		product.setStandardUom(productDetails.getStandardUom());
		product.setPackSize(productDetails.getPackSize());
		product.setIngredients(productDetails.getIngredients());
		product.setCostPriceVatIncl(productDetails.getCostPriceVatIncl());
		product.setCostPriceVatExcl(productDetails.getCostPriceVatExcl());
		product.setSellingPriceVatIncl(productDetails.getSellingPriceVatIncl());
		product.setSellingPriceVatExcl(productDetails.getSellingPriceVatExcl());
		product.setProfitMargin(productDetails.getProfitMargin());
		product.setVat(productDetails.getVat());
		product.setDiscount(productDetails.getDiscount());
		product.setStatus(productDetails.getStatus());
		product.setSellable(productDetails.getSellable());
		product.setReturnable(productDetails.getReturnable());
    	return productRepository.saveAndFlush(product); 	
    	/**
    	 * remember to update stock card, and price change log
    	 */
    }
	
    /**
     * @param id
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/products/get_by_id")
    @Transactional
    public Product getProductById(@RequestParam(name = "id") Long id, @RequestHeader("user_id") Long userId) {
        return productRepository.findById(id)
                .orElseThrow(() -> new NotFoundException("Product not found"));
    }
    /**
     * @param barcode
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/products/get_by_barcode")
    @Transactional
    public Product getProductByPrimaryBarcode(@RequestParam(name = "barcode") String barcode, @RequestHeader("user_id") Long userId) {
        return productRepository.findByPrimaryBarcode(barcode)
                .orElseThrow(() -> new NotFoundException("Product not found"));
    }
    /**
     * @param code
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/products/get_by_code")
    @Transactional
    public Product getProductByCode(@RequestParam(name = "code") String code, @RequestHeader("user_id") Long userId) {
    	System.out.println("get success");
        return productRepository.findByCode(code)
                .orElseThrow(() -> new NotFoundException("Product not found"));
    }
    /**
     * @param description
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/products/get_by_description")
    @Transactional
    public Product getProductByDescription(@RequestParam(name = "description") String description, @RequestHeader("user_id") Long userId) {
    	System.out.println("get success");
        return productRepository.findByDescription(description)
                .orElseThrow(() -> new NotFoundException("Product not found"));
    }
    
    /**
     * @param productId
     * @param userId
     * @return
     */
    @Transactional
    @RequestMapping(method = RequestMethod.DELETE, value = "/products/delete_by_id", produces = "text/html")
    public ResponseEntity<?> deleteItem(@RequestParam(name = "id") Long productId, @RequestHeader("user_id") Long userId) {
    	Product product = productRepository.findById(productId)
                .orElseThrow(() -> new NotFoundException("Item not found"));
    	//this.checkUsageBeforeDelete(product);
    	productRepository.delete(product);
    	return ResponseEntity.ok().build();
    	
    }
    
    /**
     * 
     * @param productCode
     * @param supplierCode
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value = "/products/is_supplied")
    @Transactional
    public boolean isSuppliedBySupplier(@RequestParam(name = "product_code") String productCode, 
    		@RequestParam(name = "supplier_code") String supplierCode, 
    		@RequestHeader("user_id") Long userId) {
    	Optional<Supplier> supplier = supplierRepository.findByCode(supplierCode);
    	if(!supplier.isPresent()) {
    		return false;
    	}
    	return productRepository.existsByCodeAndPrimarySupplier(productCode, supplier.get());   	
    }
}
