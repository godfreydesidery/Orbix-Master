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
import javax.validation.constraints.NotNull;

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
@Table(name = "debt_payments")
@EntityListeners(AuditingEntityListener.class)
public class DebtPayment {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
	@NotNull
	private double initialAmount = 0;
	private double bankDeposit = 0;
	private double cashPayment = 0;
	@NotNull
	private double totalPaid = 0;
	@NotNull
	private double amountRemaining = 0;
	
	@ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = false)
    @JoinColumn(name = "received_by_user_id", nullable = false , updatable = false)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private User receivingUser;
	
	@ManyToOne(targetEntity = Debt.class, fetch = FetchType.EAGER,  optional = false)
    @JoinColumn(name = "debt_id", nullable = false , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Debt debt;
	
	@ManyToOne(targetEntity = Day.class, fetch = FetchType.EAGER,  optional = false)
    @JoinColumn(name = "day_id", nullable = false , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Day receivingDay;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public double getInitialAmount() {
		return initialAmount;
	}

	public void setInitialAmount(double initialAmount) {
		this.initialAmount = initialAmount;
	}

	public double getBankDeposit() {
		return bankDeposit;
	}

	public void setBankDeposit(double bankDeposit) {
		this.bankDeposit = bankDeposit;
	}

	public double getCashPayment() {
		return cashPayment;
	}

	public void setCashPayment(double cashPayment) {
		this.cashPayment = cashPayment;
	}

	public double getTotalPaid() {
		return totalPaid;
	}

	public void setTotalPaid(double totalPaid) {
		this.totalPaid = totalPaid;
	}

	public double getAmountRemaining() {
		return amountRemaining;
	}

	public void setAmountRemaining(double amountRemaining) {
		this.amountRemaining = amountRemaining;
	}

	public User getReceivingUser() {
		return receivingUser;
	}

	public void setReceivingUser(User receivingUser) {
		this.receivingUser = receivingUser;
	}

	public Debt getDebt() {
		return debt;
	}

	public void setDebt(Debt debt) {
		this.debt = debt;
	}

	public Day getReceivingDay() {
		return receivingDay;
	}

	public void setReceivingDay(Day receivingDay) {
		this.receivingDay = receivingDay;
	}

}
