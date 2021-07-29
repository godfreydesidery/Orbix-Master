/**
 * 
 */
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

/**
 * @author GODFREY
 *
 */
@Component
@Entity
@Table(name = "rtv_details")
@EntityListeners(AuditingEntityListener.class)
public class RtvDetail {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
	private String barcode;
	@NotBlank
    private String code;
	@NotBlank
    private String description;
    private double qty;
    private double packSize;
	private String reason;	
	private double costPriceVatIncl;
	private double costPriceVatExcl;
	private double sellingPriceVatIncl;
	private double sellingPriceVatExcl;

	@ManyToOne(targetEntity = Rtv.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "rtv_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Rtv rtv;

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

	public double getQty() {
		return qty;
	}

	public void setQty(double qty) {
		this.qty = qty;
	}

	public double getPackSize() {
		return packSize;
	}

	public void setPackSize(double packSize) {
		this.packSize = packSize;
	}

	public String getReason() {
		return reason;
	}

	public void setReason(String reason) {
		this.reason = reason;
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

	public Rtv getRtv() {
		return rtv;
	}

	public void setRtv(Rtv rtv) {
		this.rtv = rtv;
	}

}
