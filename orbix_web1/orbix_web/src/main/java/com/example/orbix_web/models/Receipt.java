/**
 * 
 */
package com.example.orbix_web.models;

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
import org.hibernate.envers.Audited;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

import com.fasterxml.jackson.annotation.JsonIgnore;
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
	
	@OneToMany(targetEntity = ReceiptDetail.class, mappedBy = "receiptDetails", fetch = FetchType.EAGER, orphanRemoval = true)
    @Valid
    @JsonIgnoreProperties("receipt")
    private List<ReceiptDetail> receiptDetails;

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
}
