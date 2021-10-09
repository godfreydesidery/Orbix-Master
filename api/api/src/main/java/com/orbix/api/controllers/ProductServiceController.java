/**
 * 
 */
package com.orbix.api.controllers;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.format.annotation.DateTimeFormat;
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

import com.orbix.api.accessories.Formater;
import com.orbix.api.exceptions.InvalidEntryException;
import com.orbix.api.exceptions.InvalidOperationException;
import com.orbix.api.exceptions.NotFoundException;
import com.orbix.api.models.Clas;
import com.orbix.api.models.DamagedProduct;
import com.orbix.api.models.Day;
import com.orbix.api.models.Debt;
import com.orbix.api.models.Department;
import com.orbix.api.models.Lpo;
import com.orbix.api.models.PackingList;
import com.orbix.api.models.PackingListDetail;
import com.orbix.api.models.Product;
import com.orbix.api.models.ProductConversion;
import com.orbix.api.models.ProductConversionFinal;
import com.orbix.api.models.ProductConversionInitial;
import com.orbix.api.models.Sale;
import com.orbix.api.models.SaleDetail;
import com.orbix.api.models.StockCard;
import com.orbix.api.models.SubClass;
import com.orbix.api.models.Supplier;
import com.orbix.api.models.User;
import com.orbix.api.reports.NegativeStockReport;
import com.orbix.api.reports.PriceChangeReport;
import com.orbix.api.reports.ProductListingReport;
import com.orbix.api.reports.SupplySalesReport;
import com.orbix.api.reports.SupplyStockStatus;
import com.orbix.api.repositories.ClassRepository;
import com.orbix.api.repositories.DayRepository;
import com.orbix.api.repositories.DepartmentRepository;
import com.orbix.api.repositories.PriceChangeRepository;
import com.orbix.api.repositories.ProductConversionFinalRepository;
import com.orbix.api.repositories.ProductConversionInitialRepository;
import com.orbix.api.repositories.ProductConversionRepository;
import com.orbix.api.repositories.ProductRepository;
import com.orbix.api.repositories.StockCardRepository;
import com.orbix.api.repositories.SubClassRepository;
import com.orbix.api.repositories.SupplierRepository;
import com.orbix.api.repositories.UserRepository;

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
    ProductConversionRepository productConversionRepository;
	@Autowired
    ProductConversionInitialRepository productConversionInitialRepository;
	@Autowired
    ProductConversionFinalRepository productConversionFinalRepository;
	@Autowired
    SupplierRepository supplierRepository;
	@Autowired
	DepartmentRepository departmentRepository;
	@Autowired
    ClassRepository classRepository;
	@Autowired
    SubClassRepository subClassRepository;
	@Autowired
    PriceChangeRepository priceChangeRepository;
	@Autowired
    DayRepository dayRepository;
	@Autowired
    UserRepository userRepository;
	@Autowired
    StockCardRepository stockCardRepository;
	
    /**
     * @param userId
     * @return
     */
    @RequestMapping(method = RequestMethod.GET, value="/products", produces=MediaType.APPLICATION_JSON_VALUE)
    public List <Product> getAllProducts(
    		@RequestHeader("user_id") Long userId) {
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
    
    @RequestMapping(method = RequestMethod.GET, value="/products/get_code_by_description", produces=MediaType.APPLICATION_JSON_VALUE)
    public String  getProductCodeByDescription(
    		@RequestHeader("user_id") Long userId,
    		@RequestParam("description") String description) {
        return productRepository.findByDescription(description).get().getCode();
    }
    
    @RequestMapping(method = RequestMethod.GET, value="/products/get_code_by_barcode", produces=MediaType.APPLICATION_JSON_VALUE)
    public String  getProductCodeByBarcode(
    		@RequestHeader("user_id") Long userId,
    		@RequestParam("barcode") String barcode) {
        return productRepository.findByPrimaryBarcode(barcode).get().getCode();
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
    public Product createProduct(
    		@Valid @RequestBody Product product, 
    		@RequestHeader("user_id") Long userId) throws Exception {
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
    @Transactional
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
		product.setDiscountRatio(productDetails.getDiscountRatio());
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
		 * To avoid dirty writing the inventory
		 */
		product.setPrimaryBarcode(productDetails.getPrimaryBarcode());
		product.setDescription(productDetails.getDescription());
		product.setShortDescription(productDetails.getShortDescription());
		product.setCommonDescription(productDetails.getCommonDescription());
		product.setStandardUom(productDetails.getStandardUom());
		product.setPackSize(productDetails.getPackSize());
		product.setIngredients(productDetails.getIngredients());
		/**
		 * If there is any change in price, register a price change
		 */
		product.setCostPriceVatIncl(productDetails.getCostPriceVatIncl());
		product.setCostPriceVatExcl(productDetails.getCostPriceVatExcl());
		product.setSellingPriceVatIncl(productDetails.getSellingPriceVatIncl());
		product.setSellingPriceVatExcl(productDetails.getSellingPriceVatExcl());
		product.setProfitMargin(productDetails.getProfitMargin());
		product.setVat(productDetails.getVat());
		product.setDiscountRatio(productDetails.getDiscountRatio());
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
    
    @Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/products/get_supply_stock_status", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<SupplyStockStatus> getSupplyStockStatus( 
    		@RequestParam(name = "supplier_name") String supplierName,
    		@RequestParam(name = "codes") ArrayList<String> codes,
    		@RequestHeader("user_id") Long userId) {
		List<SupplyStockStatus> report;
		if(codes.isEmpty()) {			
			report = productRepository.getSupplyStockStatus(supplierName);	
		}else {			
			//report = saleRepository.getProductListingReportBySelectedProducts(fromDate, toDate, codes);	
		}			
		//return report;
		
		return productRepository.getSupplyStockStatus(supplierName);
    }
    
    @Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/products/get_negative_stock_report", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<NegativeStockReport> getNegativeStockReport( 
    		@RequestParam(name = "supplier_name") String supplierName,
    		@RequestParam(name = "department_name") String departmentName,
    		@RequestParam(name = "class_name") String className,
    		@RequestParam(name = "sub_class_name") String subClassName,
    		@RequestHeader("user_id") Long userId) {
		List<NegativeStockReport> report;
		
		return productRepository.getNegativeStockReport();
    }
    
    @Transactional
    @RequestMapping(method = RequestMethod.GET, value = "/products/get_price_change_report", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<PriceChangeReport> getPriceChangeReport( 
    		@RequestParam(name = "from_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate fromDate,
    		@RequestParam(name = "to_date") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE) LocalDate toDate,
    		@RequestParam(name = "supplier_name") String supplierName,
    		@RequestParam(name = "department_name") String departmentName,
    		@RequestParam(name = "class_name") String className,
    		@RequestParam(name = "sub_class_name") String subClassName,
    		@RequestHeader("user_id") Long userId) {
		List<PriceChangeReport> report;
		
		return priceChangeRepository.getPriceChangeReport(fromDate, toDate);
    }
    
    
    @RequestMapping(method = RequestMethod.GET, value="/products/conversions", produces=MediaType.APPLICATION_JSON_VALUE)
    public List <ProductConversion> getAllProductConversions(
    		@RequestHeader("user_id") Long userId) {
        return productConversionRepository.findAll();
    }
    
    @RequestMapping(method = RequestMethod.GET, value = "/products/conversions/visible", produces=MediaType.APPLICATION_JSON_VALUE)
    public List<ProductConversion> getAllVisibleProductConversion(
    		@RequestHeader("user_id") Long userId) {
    	List<String> statuses = Stream.of("PENDING", "APPROVED", "PRINTED", "REPRINTED", "COMPLETED").collect(Collectors.toList());   	
        return productConversionRepository.findAllByStatus(statuses);
    }
    
    @RequestMapping(method = RequestMethod.GET, value = "/products/conversions/get_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public ProductConversion getProductConversionByNo(
    		@RequestParam(name = "no") String no, 
    		@RequestHeader("user_id") Long userId) {
        return productConversionRepository.findByNo(no)
                .orElseThrow(() -> new NotFoundException("Product conversion not found"));
    }
    
    
    @RequestMapping(method = RequestMethod.POST, value="/products/conversions/new", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public ProductConversion createProductConversion(
    		@Valid @RequestBody ProductConversion productConversion, 
    		@RequestHeader("user_id") Long userId) throws Exception {
    	User user = userRepository.findById(userId)
                .orElseThrow(() -> new NotFoundException("User not found"));
    	
    	ProductConversion conversion = new ProductConversion();
    	
    	String random = String.valueOf(Math.random()).replace(".", "") + String.valueOf(Math.random()).replace(".", "");
    	conversion.setNo(random); 
    	productConversionRepository.saveAndFlush(conversion);
    	
    	conversion.setStatus("PENDING");
    	conversion.setReason(productConversion.getReason());
    	
    	String serial = conversion.getId().toString();
    	
    	String convNo = "CNV-"+Formater.formatNine(serial);
    	conversion.setNo(convNo); 
    	conversion.setCreatedDay(dayRepository.getCurrentBussinessDay());
    	conversion.setCreatedByUser(user);
    	productConversionRepository.saveAndFlush(conversion);  
    	
    	return conversion;
    }
    
    
    
    @RequestMapping(method = RequestMethod.POST, value="/products/conversions/add_or_edit_initial", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public ProductConversionInitial createProductConversionInitial(
    		@Valid @RequestBody ProductConversionInitial productConversionInitial, 
    		@RequestHeader("user_id") Long userId) throws Exception {    	
    	ProductConversion productConversion = productConversionRepository.findById(productConversionInitial.getProductConversion().getId())
    			.orElseThrow(() -> new NotFoundException("Product Conversion not found"));
    	Product product = productRepository.findByCode(productConversionInitial.getProduct().getCode())
                .orElseThrow(() -> new NotFoundException("Product not found"));
    	if(productConversionInitial.getQty() <= 0) {
    		throw new InvalidEntryException("Negative quantity not allowed in product quantity");
    	}
    	
    	Optional <ProductConversionInitial> c = productConversionInitialRepository.findByProductAndProductConversion(product, productConversion);
    	ProductConversionInitial initial;
    	if(c.isPresent()) {
    		initial = c.get();
    	}else {
    		initial= new ProductConversionInitial();
    		initial.setProduct(product);
    		initial.setProductConversion(productConversion);
    	}   
    	initial.setPrice(product.getSellingPriceVatIncl());
    	initial.setQty(productConversionInitial.getQty());
    	
    	return productConversionInitialRepository.saveAndFlush(initial);
    	
    }
    
    
    @RequestMapping(method = RequestMethod.POST, value="/products/conversions/add_or_edit_final", produces=MediaType.APPLICATION_JSON_VALUE)
    @ResponseBody
    @Transactional
    public ProductConversionFinal createProductConversionFinal(
    		@Valid @RequestBody ProductConversionFinal productConversionFinal, 
    		@RequestHeader("user_id") Long userId) throws Exception {    	
    	ProductConversion productConversion = productConversionRepository.findById(productConversionFinal.getProductConversion().getId())
    			.orElseThrow(() -> new NotFoundException("Product Conversion not found"));
    	Product product = productRepository.findByCode(productConversionFinal.getProduct().getCode())
                .orElseThrow(() -> new NotFoundException("Product not found"));
    	if(productConversionFinal.getQty() <= 0) {
    		throw new InvalidEntryException("Negative quantity not allowed in product quantity");
    	}
    	
    	Optional <ProductConversionFinal> c = productConversionFinalRepository.findByProductAndProductConversion(product, productConversion);
    	ProductConversionFinal final_;
    	if(c.isPresent()) {
    		final_ = c.get();
    	}else {
    		final_= new ProductConversionFinal();
    		final_.setProduct(product);
    		final_.setProductConversion(productConversion);
    	} 
    	final_.setPrice(product.getSellingPriceVatIncl());
    	final_.setQty(productConversionFinal.getQty());
    	
    	return productConversionFinalRepository.saveAndFlush(final_);
    	
    }
    
    
    @RequestMapping(method = RequestMethod.GET, value = "/products/conversions/get_status_by_id", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public String getProductConversionStatusById(
    		@RequestParam(name = "id") Long id, 
    		@RequestHeader("user_id") Long userId) {
    	Optional<ProductConversion> productConversion = productConversionRepository.findById(id);
    	if(productConversion.isPresent()) {
    		return productConversion.get().getStatus();
    	}else {
    		return "";
    	}       	
    }
    
    @RequestMapping(method = RequestMethod.GET, value = "/products/conversions/get_status_by_no", produces=MediaType.APPLICATION_JSON_VALUE)
    @Transactional
    public String getProductConversionStatusByNo(
    		@RequestParam(name = "no") String no, 
    		@RequestHeader("user_id") Long userId) {
    	Optional<ProductConversion> productConversion = productConversionRepository.findByNo(no);
    	if(productConversion.isPresent()) {
    		return productConversion.get().getStatus();
    	}else {
    		return "";
    	}       	
    }
    
    @RequestMapping(method = RequestMethod.GET, value="/products/conversions/get_all_initial_by_conversion_id", produces=MediaType.APPLICATION_JSON_VALUE)
    public List <ProductConversionInitial> getAllProductConversionInitials(
    		@RequestParam(name = "id") Long id, 
    		@RequestHeader("user_id") Long userId) {
    	Optional<ProductConversion> productConversion = productConversionRepository.findById(id);
    	if(productConversion.isPresent()) {
    		return productConversionInitialRepository.findAllByProductConversion(productConversion.get());
    	}
    	return null;
        
    }
    
    @RequestMapping(method = RequestMethod.GET, value="/products/conversions/get_all_final_by_conversion_id", produces=MediaType.APPLICATION_JSON_VALUE)
    public List <ProductConversionFinal> getAllProductConversionFinals(
    		@RequestParam(name = "id") Long id, 
    		@RequestHeader("user_id") Long userId) {
    	Optional<ProductConversion> productConversion = productConversionRepository.findById(id);
    	if(productConversion.isPresent()) {
    		return productConversionFinalRepository.findAllByProductConversion(productConversion.get());
    	}
    	return null;
        
    }
    
    @Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "products/conversions/cancel_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean cancelConversion(
    		@RequestParam(name = "id") Long conversionId, 
    		@RequestHeader("user_id") Long userId) {
    	ProductConversion productConversion = productConversionRepository.findById(conversionId)
    			.orElseThrow(() -> new NotFoundException("Conversion not found"));
		
		if(productConversion.getStatus().equals("PENDING") || productConversion.getStatus().equals("APPROVED")) {
			productConversion.setStatus("CANCELED");
			productConversionRepository.save(productConversion);
			return true;
		}else {
			throw new InvalidOperationException("Could not cancel, Only pending or approved conversions can be canceled");
		}        	
	}
    
    @Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/products/conversions/approve_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean approveProductConversion(
    		@RequestParam(name = "id") Long packingListId, 
    		@RequestHeader("user_id") Long userId) {
		Optional<ProductConversion> productConversion = productConversionRepository.findById(packingListId);
		if(!productConversion.isPresent()) {
			throw new NotFoundException("Conversion not found");
		}
		User user = userRepository.findById(userId)
    			.orElseThrow(() -> new NotFoundException("User not found")); 	
    	Day day = dayRepository.getCurrentBussinessDay();
		if(productConversion.get().getStatus().equals("PENDING")) {
			productConversion.get().setStatus("APPROVED");
			productConversion.get().setApprovedByUser(user);
			productConversion.get().setApprovedDay(day);
			productConversionRepository.save(productConversion.get());
			return true;
		}else {
			throw new InvalidOperationException("Could not approve, Only pending conversions can be approved");
		}    	
	}
    
    @Transactional
    @RequestMapping(method = RequestMethod.PUT, value = "/products/conversions/complete_by_id", produces = MediaType.APPLICATION_JSON_VALUE)
    public boolean completeProductConversion(
    		@RequestParam(name = "id") Long productConversionId, 
    		@RequestHeader("user_id") Long userId) {
		Optional<ProductConversion> productConversion_ = productConversionRepository.findById(productConversionId);
		if(!productConversion_.isPresent()) {
			throw new NotFoundException("Conversion not found");
		}
		User user = userRepository.findById(userId)
    			.orElseThrow(() -> new NotFoundException("User not found")); 	
    	Day day = dayRepository.getCurrentBussinessDay();
    	
    	
		
		//double totalInitial = productConversion.getInitialTotal();
		//double totalFinal = productConversion.getFinalTotal();
		
    	List <ProductConversionInitial> initials = productConversionInitialRepository.findAllByProductConversion(productConversion_.get());
    	List <ProductConversionFinal> finals = productConversionFinalRepository.findAllByProductConversion(productConversion_.get());
    	
    	
    	
		if(productConversion_.get().getStatus().equals("APPROVED")) {
			productConversion_.get().setStatus("COMPLETED");
			productConversion_.get().setCompletedByUser(user);
			productConversion_.get().setCompletedDay(day);
			
			productConversionRepository.save(productConversion_.get());
			
			for(ProductConversionInitial initial : initials) {
				/**
				 * Return returned to stock
				 * Create stock card
				 */
				
				Product product;
	    		StockCard stockCard;
	    		if(initial.getQty() > 0) {	 
	    			product = productRepository.findByCode(initial.getProduct().getCode()).get();
	    			product.setStock(product.getStock() - initial.getQty());
	    			productRepository.saveAndFlush(product);
	    		}
	    		
	    		if(initial.getQty() > 0) {	    			
		    		stockCard = new StockCard();
		    		product = productRepository.findByCode(initial.getProduct().getCode()).get();
		    		stockCard.setCode(initial.getProduct().getCode());
		    		stockCard.setDescription(initial.getProduct().getDescription());
		    		stockCard.setDay(dayRepository.getCurrentBussinessDay());
		    		stockCard.setCreatedOn(new Date());
		    		stockCard.setQtyIn(0);
		    		stockCard.setQtyOut(initial.getQty());
		    		stockCard.setBalance(product.getStock());
		    		stockCard.setReference("Used in conversion# "+productConversion_.get().getNo());
		    		stockCardRepository.saveAndFlush(stockCard);
	    		}
	    		
	    		
			}
			
			for(ProductConversionFinal final_ : finals) {
				/**
				 * Return returned to stock
				 * Create stock card
				 */
				
				Product product;
	    		StockCard stockCard;
	    		if(final_.getQty() > 0) {	 
	    			product = productRepository.findByCode(final_.getProduct().getCode()).get();
	    			product.setStock(product.getStock() + final_.getQty());
	    			productRepository.saveAndFlush(product);
	    		}
	    		
	    		if(final_.getQty() > 0) {	    			
		    		stockCard = new StockCard();
		    		product = productRepository.findByCode(final_.getProduct().getCode()).get();
		    		stockCard.setCode(final_.getProduct().getCode());
		    		stockCard.setDescription(final_.getProduct().getDescription());
		    		stockCard.setDay(dayRepository.getCurrentBussinessDay());
		    		stockCard.setCreatedOn(new Date());
		    		stockCard.setQtyIn(0);
		    		stockCard.setQtyOut(final_.getQty());
		    		stockCard.setBalance(product.getStock());
		    		stockCard.setReference("Produced in conversion# "+productConversion_.get().getNo());
		    		stockCardRepository.saveAndFlush(stockCard);
	    		}
	    		
			}
			
			return true;
		}else {
			throw new InvalidOperationException("Could not complete, Only approved conversions can be completed");
		}    	
	}
}
