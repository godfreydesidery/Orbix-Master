/**
 * 
 */
package com.example.orbix_web.models;

import java.util.Date;

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
import org.hibernate.envers.Audited;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

import com.example.orbix_web.database.Audit;
import com.fasterxml.jackson.annotation.JsonIgnore;

/**
 * @author GODFREY
 *
 */
@Entity
@Component
@Table(name = "sale_details")
@EntityListeners(AuditingEntityListener.class)
public class SaleDetail extends Audit<String>{
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
	
	@ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "sale_id", nullable = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    private Sale sale;

	/**
	 * @return the id
	 */
	public Long getId() {
		return id;
	}

	/**
	 * @param id the id to set
	 */
	public void setId(Long id) {
		this.id = id;
	}

	/**
	 * @return the code
	 */
	public String getCode() {
		return code;
	}

	/**
	 * @param code the code to set
	 */
	public void setCode(String code) {
		this.code = code;
	}

	/**
	 * @return the barcode
	 */
	public String getBarcode() {
		return barcode;
	}

	/**
	 * @param barcode the barcode to set
	 */
	public void setBarcode(String barcode) {
		this.barcode = barcode;
	}

	/**
	 * @return the description
	 */
	public String getDescription() {
		return description;
	}

	/**
	 * @param description the description to set
	 */
	public void setDescription(String description) {
		this.description = description;
	}

	/**
	 * @return the qty
	 */
	public double getQty() {
		return qty;
	}

	/**
	 * @param qty the qty to set
	 */
	public void setQty(double qty) {
		this.qty = qty;
	}

	/**
	 * @return the costPriceVatIncl
	 */
	public double getCostPriceVatIncl() {
		return costPriceVatIncl;
	}

	/**
	 * @param costPriceVatIncl the costPriceVatIncl to set
	 */
	public void setCostPriceVatIncl(double costPriceVatIncl) {
		this.costPriceVatIncl = costPriceVatIncl;
	}

	/**
	 * @return the costPriceVatExcl
	 */
	public double getCostPriceVatExcl() {
		return costPriceVatExcl;
	}

	/**
	 * @param costPriceVatExcl the costPriceVatExcl to set
	 */
	public void setCostPriceVatExcl(double costPriceVatExcl) {
		this.costPriceVatExcl = costPriceVatExcl;
	}

	/**
	 * @return the sellingPriceVatIncl
	 */
	public double getSellingPriceVatIncl() {
		return sellingPriceVatIncl;
	}

	/**
	 * @param sellingPriceVatIncl the sellingPriceVatIncl to set
	 */
	public void setSellingPriceVatIncl(double sellingPriceVatIncl) {
		this.sellingPriceVatIncl = sellingPriceVatIncl;
	}

	/**
	 * @return the sellingPriceVatExcl
	 */
	public double getSellingPriceVatExcl() {
		return sellingPriceVatExcl;
	}

	/**
	 * @param sellingPriceVatExcl the sellingPriceVatExcl to set
	 */
	public void setSellingPriceVatExcl(double sellingPriceVatExcl) {
		this.sellingPriceVatExcl = sellingPriceVatExcl;
	}

	/**
	 * @return the discount
	 */
	public double getDiscount() {
		return discount;
	}

	/**
	 * @param discount the discount to set
	 */
	public void setDiscount(double discount) {
		this.discount = discount;
	}

	/**
	 * @return the sale
	 */
	public Sale getSale() {
		return sale;
	}

	/**
	 * @param sale the sale to set
	 */
	public void setSale(Sale sale) {
		this.sale = sale;
	}	
}
