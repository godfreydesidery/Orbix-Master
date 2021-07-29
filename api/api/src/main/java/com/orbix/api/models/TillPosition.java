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
import javax.persistence.OneToOne;
import javax.persistence.Table;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

import com.fasterxml.jackson.annotation.JsonIgnore;

/**
 * @author GODFREY
 *
 */
@Entity
@Component
@Table(name = "till_positions")
@EntityListeners(AuditingEntityListener.class)
public class TillPosition {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;	
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
	
	@OneToOne(fetch = FetchType.EAGER, optional = false)
    @JoinColumn(name = "till_id", nullable = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JsonIgnore
    private Till till;

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
	 * @return the cash
	 */
	public double getCash() {
		return cash;
	}

	/**
	 * @param cash the cash to set
	 */
	public void setCash(double cash) {
		this.cash = cash;
	}

	/**
	 * @return the voucher
	 */
	public double getVoucher() {
		return voucher;
	}

	/**
	 * @param voucher the voucher to set
	 */
	public void setVoucher(double voucher) {
		this.voucher = voucher;
	}

	/**
	 * @return the deposit
	 */
	public double getDeposit() {
		return deposit;
	}

	/**
	 * @param deposit the deposit to set
	 */
	public void setDeposit(double deposit) {
		this.deposit = deposit;
	}

	/**
	 * @return the loyalty
	 */
	public double getLoyalty() {
		return loyalty;
	}

	/**
	 * @param loyalty the loyalty to set
	 */
	public void setLoyalty(double loyalty) {
		this.loyalty = loyalty;
	}

	/**
	 * @return the crCard
	 */
	public double getCrCard() {
		return crCard;
	}

	/**
	 * @param crCard the crCard to set
	 */
	public void setCrCard(double crCard) {
		this.crCard = crCard;
	}

	/**
	 * @return the cheque
	 */
	public double getCheque() {
		return cheque;
	}

	/**
	 * @param cheque the cheque to set
	 */
	public void setCheque(double cheque) {
		this.cheque = cheque;
	}

	/**
	 * @return the cap
	 */
	public double getCap() {
		return cap;
	}

	/**
	 * @param cap the cap to set
	 */
	public void setCap(double cap) {
		this.cap = cap;
	}

	/**
	 * @return the invoice
	 */
	public double getInvoice() {
		return invoice;
	}

	/**
	 * @param invoice the invoice to set
	 */
	public void setInvoice(double invoice) {
		this.invoice = invoice;
	}

	/**
	 * @return the crNote
	 */
	public double getCrNote() {
		return crNote;
	}

	/**
	 * @param crNote the crNote to set
	 */
	public void setCrNote(double crNote) {
		this.crNote = crNote;
	}

	/**
	 * @return the mobile
	 */
	public double getMobile() {
		return mobile;
	}

	/**
	 * @param mobile the mobile to set
	 */
	public void setMobile(double mobile) {
		this.mobile = mobile;
	}

	/**
	 * @return the other
	 */
	public double getOther() {
		return other;
	}

	/**
	 * @param other the other to set
	 */
	public void setOther(double other) {
		this.other = other;
	}

	/**
	 * @return the till
	 */
	public Till getTill() {
		return till;
	}

	/**
	 * @param till the till to set
	 */
	public void setTill(Till till) {
		this.till = till;
	}
}
