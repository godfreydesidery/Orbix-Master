/**
 * 
 */
package com.orbix.api.models;

import java.time.LocalDate;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Embedded;
import javax.persistence.Entity;
import javax.persistence.EntityListeners;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToOne;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotBlank;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

/**
 * @author GODFREY
 *
 */
@Component
@Entity
@Table(name = "grn_details")
@EntityListeners(AuditingEntityListener.class)
public class GrnDetail {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
	private String barcode;
	@NotBlank
    private String code;
	@NotBlank
    private String description;
	private double packSize;
	private double qtyOrdered;
    private double qtyReceived;   
	private double supplierCostPrice;
    private double clientCostPrice;
       
    @ManyToOne(targetEntity = Grn.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "grn_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
	@JsonIgnoreProperties("lpo")
    private Grn grn;

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
	 * @return the packSize
	 */
	public double getPackSize() {
		return packSize;
	}

	/**
	 * @param packSize the packSize to set
	 */
	public void setPackSize(double packSize) {
		this.packSize = packSize;
	}

	/**
	 * @return the qtyOrdered
	 */
	public double getQtyOrdered() {
		return qtyOrdered;
	}

	/**
	 * @param qtyOrdered the qtyOrdered to set
	 */
	public void setQtyOrdered(double qtyOrdered) {
		this.qtyOrdered = qtyOrdered;
	}

	/**
	 * @return the qtyReceived
	 */
	public double getQtyReceived() {
		return qtyReceived;
	}

	/**
	 * @param qtyReceived the qtyReceived to set
	 */
	public void setQtyReceived(double qtyReceived) {
		this.qtyReceived = qtyReceived;
	}

	/**
	 * @return the supplierCostPrice
	 */
	public double getSupplierCostPrice() {
		return supplierCostPrice;
	}

	/**
	 * @param supplierCostPrice the supplierCostPrice to set
	 */
	public void setSupplierCostPrice(double supplierCostPrice) {
		this.supplierCostPrice = supplierCostPrice;
	}

	/**
	 * @return the clientCostPrice
	 */
	public double getClientCostPrice() {
		return clientCostPrice;
	}

	/**
	 * @param clientCostPrice the clientCostPrice to set
	 */
	public void setClientCostPrice(double clientCostPrice) {
		this.clientCostPrice = clientCostPrice;
	}

	/**
	 * @return the grn
	 */
	public Grn getGrn() {
		return grn;
	}

	/**
	 * @param grn the grn to set
	 */
	public void setGrn(Grn grn) {
		this.grn = grn;
	}
    
}
