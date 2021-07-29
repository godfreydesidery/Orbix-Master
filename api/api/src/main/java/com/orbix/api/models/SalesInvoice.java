/**
 * 
 */
package com.orbix.api.models;

import java.time.LocalDate;
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
@Component
@Entity
@Table(name = "sales_invoices")
@EntityListeners(AuditingEntityListener.class)
public class SalesInvoice {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;	
	@NotBlank
	@Column(unique = true)
    private String no;	
	private LocalDate issueDate;
	private String status;	
	private String terms;
	
	@ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "created_user_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded	
    private User createdUser;
    
    @ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "approved_user_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded	
    private User approvedUser;
    
    @ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "completed_user_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded	
    private User completedUser;
	
	@ManyToOne(targetEntity = CorporateCustomer.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "corporate_customer_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
    private CorporateCustomer corporateCustomer;
	
	@OneToMany(targetEntity = SalesInvoiceDetail.class, mappedBy = "salesInvoice", fetch = FetchType.EAGER, orphanRemoval = true)
    @Valid
    @JsonIgnoreProperties("salesInvoice")
    private List<SalesInvoiceDetail> salesInvoiceDetails;

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
	 * @return the terms
	 */
	public String getTerms() {
		return terms;
	}

	/**
	 * @param terms the terms to set
	 */
	public void setTerms(String terms) {
		this.terms = terms;
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
	 * @return the approvedUser
	 */
	public User getApprovedUser() {
		return approvedUser;
	}

	/**
	 * @param approvedUser the approvedUser to set
	 */
	public void setApprovedUser(User approvedUser) {
		this.approvedUser = approvedUser;
	}

	/**
	 * @return the completedUser
	 */
	public User getCompletedUser() {
		return completedUser;
	}

	/**
	 * @param completedUser the completedUser to set
	 */
	public void setCompletedUser(User completedUser) {
		this.completedUser = completedUser;
	}

	/**
	 * @return the corporateCustomer
	 */
	public CorporateCustomer getCorporateCustomer() {
		return corporateCustomer;
	}

	/**
	 * @param corporateCustomer the corporateCustomer to set
	 */
	public void setCorporateCustomer(CorporateCustomer corporateCustomer) {
		this.corporateCustomer = corporateCustomer;
	}

	public List<SalesInvoiceDetail> getSalesInvoiceDetails() {
		return salesInvoiceDetails;
	}

	public void setSalesInvoiceDetails(List<SalesInvoiceDetail> salesInvoiceDetails) {
		this.salesInvoiceDetails = salesInvoiceDetails;
	}

}
