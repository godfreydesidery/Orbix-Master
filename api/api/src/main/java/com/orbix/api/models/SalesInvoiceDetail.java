/**
 * 
 */
package com.orbix.api.models;

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
import javax.validation.constraints.NotNull;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

/**
 * @author GODFREY
 *
 */
@Component
@Entity
@Table(name = "sales_invoice_details")
@EntityListeners(AuditingEntityListener.class)
public class SalesInvoiceDetail {
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
	
	@ManyToOne(targetEntity = SalesInvoice.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "sales_invoice_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
    private SalesInvoice salesInvoice;

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

	public SalesInvoice getSalesInvoice() {
		return salesInvoice;
	}

	public void setSalesInvoice(SalesInvoice salesInvoice) {
		this.salesInvoice = salesInvoice;
	}
	
	
}
