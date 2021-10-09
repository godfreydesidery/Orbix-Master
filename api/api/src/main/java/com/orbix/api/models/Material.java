package com.orbix.api.models;

import javax.persistence.Embedded;
import javax.persistence.Entity;
import javax.persistence.EntityListeners;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.OneToOne;
import javax.persistence.Table;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

@Component
@Entity
@Table(name = "materials")
@EntityListeners(AuditingEntityListener.class)
public class Material {
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
	private double costPrice = 0;
	private double stock = 0;
	private double maximumStock = 0;
	private double minimumStock = 0;
	private double defaultRequisitionLevel = 0;
	private double defaultRequisitionQty = 0;
	private String status;
	private double unitProductEquivalent = 0;
	
	@OneToOne(targetEntity = MaterialCategory.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "material_category_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private MaterialCategory materialCategory;
	
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
	public double getCostPrice() {
		return costPrice;
	}
	public void setCostPrice(double costPrice) {
		this.costPrice = costPrice;
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
	public double getDefaultRequisitionLevel() {
		return defaultRequisitionLevel;
	}
	public void setDefaultRequisitionLevel(double defaultRequisitionLevel) {
		this.defaultRequisitionLevel = defaultRequisitionLevel;
	}
	public double getDefaultRequisitionQty() {
		return defaultRequisitionQty;
	}
	public void setDefaultRequisitionQty(double defaultRequisitionQty) {
		this.defaultRequisitionQty = defaultRequisitionQty;
	}
	public String getStatus() {
		return status;
	}
	public void setStatus(String status) {
		this.status = status;
	}
	public double getUnitProductEquivalent() {
		return unitProductEquivalent;
	}
	public void setUnitProductEquivalent(double unitProductEquivalent) {
		this.unitProductEquivalent = unitProductEquivalent;
	}
	public MaterialCategory getMaterialCategory() {
		return materialCategory;
	}
	public void setMaterialCategory(MaterialCategory materialCategory) {
		this.materialCategory = materialCategory;
	}
	
	
}
