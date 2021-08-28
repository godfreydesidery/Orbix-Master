/**
 * 
 */
package com.orbix.api.models;

import java.time.LocalDate;
import java.util.Date;
import java.util.List;

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
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.Valid;
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
@Entity
@Component
@Table(name = "receipts")
@EntityListeners(AuditingEntityListener.class)
public class Receipt {
	
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;	
	@NotBlank
	@Column(unique = true)
    private String no;	
	private LocalDate issueDate;
	private String status;	
	private String notes;
	@Temporal(TemporalType.TIMESTAMP)
    private Date printed;
	@Temporal(TemporalType.TIMESTAMP)
    private Date rePrinted;
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
	private double total = 0;
	
	@ManyToOne(targetEntity = Cart.class, fetch = FetchType.LAZY,  optional = true)
    @JoinColumn(name = "cart_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
    private Cart cart;
	
	@ManyToOne(targetEntity = Till.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "till_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
    private Till till;
	
	@ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "created_user_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded	
    private User createdUser;
	
	@ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "reprinted_user_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded	
    private User reprintedUser;
	
	@OneToMany(targetEntity = ReceiptDetail.class, mappedBy = "receipt", fetch = FetchType.EAGER, orphanRemoval = true)
    @Valid
    @JsonIgnoreProperties("receipt")
    private List<ReceiptDetail> receiptDetails;

	public Cart getCart() {
		return cart;
	}

	public double getTotal() {
		return total;
	}

	public void setTotal(double total) {
		this.total = total;
	}

	public void setCart(Cart cart) {
		this.cart = cart;
	}

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
	 * @return the no
	 */
	public String getNo() {
		return no;
	}

	/**
	 * @param no the no to set
	 */
	public void setNo(String no) {
		this.no = no;
	}

	/**
	 * @return the issueDate
	 */
	public LocalDate getIssueDate() {
		return issueDate;
	}

	/**
	 * @param issueDate the issueDate to set
	 */
	public void setIssueDate(LocalDate issueDate) {
		this.issueDate = issueDate;
	}

	/**
	 * @return the status
	 */
	public String getStatus() {
		return status;
	}

	/**
	 * @param status the status to set
	 */
	public void setStatus(String status) {
		this.status = status;
	}

	/**
	 * @return the notes
	 */
	public String getNotes() {
		return notes;
	}

	/**
	 * @param notes the notes to set
	 */
	public void setNotes(String notes) {
		this.notes = notes;
	}

	/**
	 * @return the printed
	 */
	public Date getPrinted() {
		return printed;
	}

	/**
	 * @param printed the printed to set
	 */
	public void setPrinted(Date printed) {
		this.printed = printed;
	}

	/**
	 * @return the rePrinted
	 */
	public Date getRePrinted() {
		return rePrinted;
	}

	/**
	 * @param rePrinted the rePrinted to set
	 */
	public void setRePrinted(Date rePrinted) {
		this.rePrinted = rePrinted;
	}

	/**
	 * @return the createdUser
	 */
	public User getCreatedUser() {
		return createdUser;
	}

	/**
	 * @param createdUser the createdUser to set
	 */
	public void setCreatedUser(User createdUser) {
		this.createdUser = createdUser;
	}

	/**
	 * @return the reprintedUser
	 */
	public User getReprintedUser() {
		return reprintedUser;
	}

	/**
	 * @param reprintedUser the reprintedUser to set
	 */
	public void setReprintedUser(User reprintedUser) {
		this.reprintedUser = reprintedUser;
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

	/**
	 * @return the receiptDetails
	 */
	public List<ReceiptDetail> getReceiptDetails() {
		return receiptDetails;
	}

	/**
	 * @param receiptDetails the receiptDetails to set
	 */
	public void setReceiptDetails(List<ReceiptDetail> receiptDetails) {
		this.receiptDetails = receiptDetails;
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
	
}
