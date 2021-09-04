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

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

@Component
@Entity
@Table(name = "cash_pick_ups")
@EntityListeners(AuditingEntityListener.class)
public class CashPickUp {
	
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
	private double amount;
	private String details;
	@Temporal(TemporalType.TIMESTAMP)
    private Date pickedAt;
	
	@ManyToOne(targetEntity = Till.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "till_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Till till;
	
	@ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "user_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded	
    private User pickedBy;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public double getAmount() {
		return amount;
	}

	public void setAmount(double amount) {
		this.amount = amount;
	}

	public String getDetails() {
		return details;
	}

	public void setDetails(String details) {
		this.details = details;
	}

	public Date getPickedAt() {
		return pickedAt;
	}

	public void setPickedAt(Date pickedAt) {
		this.pickedAt = pickedAt;
	}

	public Till getTill() {
		return till;
	}

	public void setTill(Till till) {
		this.till = till;
	}

	public User getPickedBy() {
		return pickedBy;
	}

	public void setPickedBy(User pickedBy) {
		this.pickedBy = pickedBy;
	}

	
}
