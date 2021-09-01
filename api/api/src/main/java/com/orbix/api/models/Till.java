/**
 * 
 */
package com.orbix.api.models;

import javax.persistence.Column;
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
import org.hibernate.envers.Audited;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

import com.fasterxml.jackson.annotation.JsonIgnore;

/**
 * @author GODFREY
 *
 */
@Entity
@Component
@Table(name = "tills")
@EntityListeners(AuditingEntityListener.class)
public class Till {
	/**
	 * Till basic information
	 */
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
	
	@NotBlank
	@Column(unique=true)
    private String no;
	@NotBlank
	@Column(unique=true)
    private String name;
	@NotBlank
	@Column(unique=true)
	private String computerName;
	private int active = 1;
	
	/**
	 * Till current position
	 */
	private double cash = 0;
	private double voucher = 0;
	private double deposit = 0;
	private double loyalty = 0;
	private double crCard = 0;
	private double cheque = 0;
	private double cap = 0;
	private double invoice = 0;
	private double crNote = 0;
	private double mobile = 0;
	private double other = 0;
	
	/**
	 * Till float
	 */
	private double floatBalance = 0;
	
	public Long getId() {
		return id;
	}
	public void setId(Long id) {
		this.id = id;
	}
	public String getNo() {
		return no;
	}
	public void setNo(String no) {
		this.no = no;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getComputerName() {
		return computerName;
	}
	public void setComputerName(String computerName) {
		this.computerName = computerName;
	}
	public int getActive() {
		return active;
	}
	public void setActive(int active) {
		this.active = active;
	}
	public double getCash() {
		return cash;
	}
	public void setCash(double cash) {
		this.cash = cash;
	}
	public double getVoucher() {
		return voucher;
	}
	public void setVoucher(double voucher) {
		this.voucher = voucher;
	}
	public double getDeposit() {
		return deposit;
	}
	public void setDeposit(double deposit) {
		this.deposit = deposit;
	}
	public double getLoyalty() {
		return loyalty;
	}
	public void setLoyalty(double loyalty) {
		this.loyalty = loyalty;
	}
	public double getCrCard() {
		return crCard;
	}
	public void setCrCard(double crCard) {
		this.crCard = crCard;
	}
	public double getCheque() {
		return cheque;
	}
	public void setCheque(double cheque) {
		this.cheque = cheque;
	}
	public double getCap() {
		return cap;
	}
	public void setCap(double cap) {
		this.cap = cap;
	}
	public double getInvoice() {
		return invoice;
	}
	public void setInvoice(double invoice) {
		this.invoice = invoice;
	}
	public double getCrNote() {
		return crNote;
	}
	public void setCrNote(double crNote) {
		this.crNote = crNote;
	}
	public double getMobile() {
		return mobile;
	}
	public void setMobile(double mobile) {
		this.mobile = mobile;
	}
	public double getOther() {
		return other;
	}
	public void setOther(double other) {
		this.other = other;
	}
	public double getFloatBalance() {
		return floatBalance;
	}
	public void setFloatBalance(double floatBalance) {
		this.floatBalance = floatBalance;
	}
	
	
}
