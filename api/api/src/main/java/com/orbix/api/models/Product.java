package com.orbix.api.models;

import javax.persistence.Embedded;
import javax.persistence.Entity;
import javax.persistence.EntityListeners;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

@Entity
@Component
@Table(name = "products")
@EntityListeners(AuditingEntityListener.class)
public class Product {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
	
	private String primaryBarcode;
	private String code;
	private String description;
	private String shortDescription;
	private String commonDescription;
	private String standardUom;
	private  double packSize = 1;
	private String ingredients;
	private double costPriceVatIncl = 0;
	private double costPriceVatExcl = 0;
	private double sellingPriceVatIncl = 0;
	private double sellingPriceVatExcl = 0;
	private double profitMargin = 0;
	private double vat = 0;
	private double discountRatio = 0;
	private double stock = 0;
	private double maximumStock = 0;
	private double minimumStock = 0;
	private double defaultReorderLevel = 0;
	private double defaultReorderQty = 0;
	private String status;
	private int sellable = 1;
	private int returnable = 0;
	
	@ManyToOne(targetEntity = Supplier.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "supplier_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Supplier primarySupplier;
	
	@ManyToOne(targetEntity = Department.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "department_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Department department;
	
	@ManyToOne(targetEntity = Clas.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "class_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Clas clas;
	
	@ManyToOne(targetEntity = SubClass.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "sub_class_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private SubClass subClass;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getPrimaryBarcode() {
		return primaryBarcode;
	}

	public void setPrimaryBarcode(String primaryBarcode) {
		this.primaryBarcode = primaryBarcode;
	}

	public String getCode() {
		return code;
	}

	public void setCode(String code) {
		this.code = code;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public String getShortDescription() {
		return shortDescription;
	}

	public void setShortDescription(String shortDescription) {
		this.shortDescription = shortDescription;
	}

	public String getCommonDescription() {
		return commonDescription;
	}

	public void setCommonDescription(String commonDescription) {
		this.commonDescription = commonDescription;
	}

	public String getStandardUom() {
		return standardUom;
	}

	public void setStandardUom(String standardUom) {
		this.standardUom = standardUom;
	}

	public double getPackSize() {
		return packSize;
	}

	public void setPackSize(double packSize) {
		this.packSize = packSize;
	}

	public String getIngredients() {
		return ingredients;
	}

	public void setIngredients(String ingredients) {
		this.ingredients = ingredients;
	}

	public double getCostPriceVatIncl() {
		return costPriceVatIncl;
	}

	public void setCostPriceVatIncl(double costPriceVatIncl) {
		this.costPriceVatIncl = costPriceVatIncl;
	}

	public double getCostPriceVatExcl() {
		return costPriceVatExcl;
	}

	public void setCostPriceVatExcl(double costPriceVatExcl) {
		this.costPriceVatExcl = costPriceVatExcl;
	}

	public double getSellingPriceVatIncl() {
		return sellingPriceVatIncl;
	}

	public void setSellingPriceVatIncl(double sellingPriceVatIncl) {
		this.sellingPriceVatIncl = sellingPriceVatIncl;
	}

	public double getSellingPriceVatExcl() {
		return sellingPriceVatExcl;
	}

	public void setSellingPriceVatExcl(double sellingPriceVatExcl) {
		this.sellingPriceVatExcl = sellingPriceVatExcl;
	}

	public double getProfitMargin() {
		return profitMargin;
	}

	public void setProfitMargin(double profitMargin) {
		this.profitMargin = profitMargin;
	}

	public double getVat() {
		return vat;
	}

	public void setVat(double vat) {
		this.vat = vat;
	}
	
	public double getDiscountRatio() {
		return discountRatio;
	}

	public void setDiscountRatio(double discountRatio) {
		this.discountRatio = discountRatio;
	}

	public double getStock() {
		return stock;
	}

	public void setStock(double stock) {
		this.stock = stock;
	}

	public double getMaximumStock() {
		return maximumStock;
	}

	public void setMaximumStock(double maximumStock) {
		this.maximumStock = maximumStock;
	}

	public double getMinimumStock() {
		return minimumStock;
	}

	public void setMinimumStock(double minimumStock) {
		this.minimumStock = minimumStock;
	}

	public double getDefaultReorderLevel() {
		return defaultReorderLevel;
	}

	public void setDefaultReorderLevel(double defaultReorderLevel) {
		this.defaultReorderLevel = defaultReorderLevel;
	}

	public double getDefaultReorderQty() {
		return defaultReorderQty;
	}

	public void setDefaultReorderQty(double defaultReorderQty) {
		this.defaultReorderQty = defaultReorderQty;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

	public int getSellable() {
		return sellable;
	}

	public void setSellable(int sellable) {
		this.sellable = sellable;
	}

	public int getReturnable() {
		return returnable;
	}

	public void setReturnable(int returnable) {
		this.returnable = returnable;
	}
	public Supplier getPrimarySupplier() {
		return primarySupplier;
	}

	public void setPrimarySupplier(Supplier primarySupplier) {
		this.primarySupplier = primarySupplier;
	}

	public Department getDepartment() {
		return department;
	}

	public void setDepartment(Department department) {
		this.department = department;
	}

	public Clas getClas() {
		return clas;
	}

	public void setClas(Clas clas) {
		this.clas = clas;
	}

	public SubClass getSubClass() {
		return subClass;
	}

	public void setSubClass(SubClass subClass) {
		this.subClass = subClass;
	}

}
