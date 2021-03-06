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
import javax.validation.constraints.NotBlank;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

@Component
@Entity
@Table(name = "packing_list_details")
@EntityListeners(AuditingEntityListener.class)
public class PackingListDetail {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
	
	private String barcode;
	@NotBlank
    private String code;	
	private String description;
	private double costPriceVatIncl;
	private double sellingPriceVatIncl;
	private double previousReturns;
	private double issued;
	private double totalPacked;
	private double sold;
	private double returned;
	private double damaged;
	//private double sample;
	
	@ManyToOne(targetEntity = PackingList.class, fetch = FetchType.EAGER,  optional = false)
    @JoinColumn(name = "packing_list_id", nullable = false , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private PackingList packingList;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getBarcode() {
		return barcode;
	}

	public void setBarcode(String barcode) {
		this.barcode = barcode;
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

	public double getPreviousReturns() {
		return previousReturns;
	}

	public void setPreviousReturns(double previousReturns) {
		this.previousReturns = previousReturns;
	}


	public double getSold() {
		return sold;
	}

	public void setSold(double sold) {
		this.sold = sold;
	}

	public double getReturned() {
		return returned;
	}

	public void setReturned(double returned) {
		this.returned = returned;
	}

	public double getDamaged() {
		return damaged;
	}

	public void setDamaged(double damaged) {
		this.damaged = damaged;
	}

	public PackingList getPackingList() {
		return packingList;
	}

	public void setPackingList(PackingList packingList) {
		this.packingList = packingList;
	}

	public double getIssued() {
		return issued;
	}

	public void setIssued(double issued) {
		this.issued = issued;
	}

	public double getTotalPacked() {
		return totalPacked;
	}

	public void setTotalPacked(double totalPacked) {
		this.totalPacked = totalPacked;
	}

	public double getCostPriceVatIncl() {
		return costPriceVatIncl;
	}

	public void setCostPriceVatIncl(double costPriceVatIncl) {
		this.costPriceVatIncl = costPriceVatIncl;
	}

	public double getSellingPriceVatIncl() {
		return sellingPriceVatIncl;
	}

	public void setSellingPriceVatIncl(double sellingPriceVatIncl) {
		this.sellingPriceVatIncl = sellingPriceVatIncl;
	}

	
}
