package com.orbix.api.models;

import java.util.Date;

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
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

@Entity
@Component
@Table(name = "voideds")
@EntityListeners(AuditingEntityListener.class)
public class Voided {
	
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
	
	@NotBlank
    private String code;
	private String barcode;
	@NotBlank
    private String description;
	@NotNull
	private double qty;
	@NotNull
	private double costPriceVatIncl;
	private double costPriceVatExcl;
	@NotNull
	private double sellingPriceVatIncl;
	private double sellingPriceVatExcl;
	private double discount = 0;
	
	@Temporal(TemporalType.TIMESTAMP)
    private Date voidedAt;
	
	@ManyToOne(targetEntity = Till.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "till_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
    private Till till;
	
	@ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "voided_user_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded	
    private User voidedUser;
	
	@ManyToOne(targetEntity = Day.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "day_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Day day;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getCode() {
		return code;
	}

	public void setCode(String code) {
		this.code = code;
	}

	public String getBarcode() {
		return barcode;
	}

	public void setBarcode(String barcode) {
		this.barcode = barcode;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public double getQty() {
		return qty;
	}

	public void setQty(double qty) {
		this.qty = qty;
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

	public double getDiscount() {
		return discount;
	}

	public void setDiscount(double discount) {
		this.discount = discount;
	}

	public Date getVoidedAt() {
		return voidedAt;
	}

	public void setVoidedAt(Date voidedAt) {
		this.voidedAt = voidedAt;
	}

	public Till getTill() {
		return till;
	}

	public void setTill(Till till) {
		this.till = till;
	}

	public User getVoidedUser() {
		return voidedUser;
	}

	public void setVoidedUser(User voidedUser) {
		this.voidedUser = voidedUser;
	}

	public Day getDay() {
		return day;
	}

	public void setDay(Day day) {
		this.day = day;
	}

	
}
