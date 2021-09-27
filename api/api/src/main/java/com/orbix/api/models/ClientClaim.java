package com.orbix.api.models;

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

@Entity
@Component
@Table(name = "client_claims")
@EntityListeners(AuditingEntityListener.class)
public class ClientClaim {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
	
	@NotBlank
	@Column(unique = true)
    private String no;
	private String status;
	private String clientName;
	private String clientPhone;
	private String clientAddress;
	private String issueNo;
	private String invoiceNo;
	private String receiptNo;
	private String returnedBy;
	private String receivedBy;
	private String comments;
	
	@ManyToOne(targetEntity = Day.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "created_day_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Day createdDay;
    
    @ManyToOne(targetEntity = Day.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "approved_day_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Day approvedDay;
    
    @ManyToOne(targetEntity = Day.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "completed_day_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Day completedDay;
    
    @ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "created_by_user_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private User createdByUser;
    
    @ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "approved_by_user_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private User approvedByUser;
    
    @ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "completed_by_user_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private User completedByUser;
    
    @OneToMany(targetEntity = ClientClaimedProduct.class, mappedBy = "clientClaim", fetch = FetchType.LAZY, orphanRemoval = true)
    @Valid
    @JsonIgnoreProperties("clientClaim")
    private List<ClientClaimedProduct> clientClaimedProduct;
    
    @OneToMany(targetEntity = ClientReplacementProduct.class, mappedBy = "clientClaim", fetch = FetchType.LAZY, orphanRemoval = true)
    @Valid
    @JsonIgnoreProperties("clientClaim")
    private List<ClientReplacementProduct> clientReplacementProduct;

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

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

	public String getClientName() {
		return clientName;
	}

	public void setClientName(String clientName) {
		this.clientName = clientName;
	}

	public String getClientPhone() {
		return clientPhone;
	}

	public void setClientPhone(String clientPhone) {
		this.clientPhone = clientPhone;
	}

	public String getClientAddress() {
		return clientAddress;
	}

	public void setClientAddress(String clientAddress) {
		this.clientAddress = clientAddress;
	}

	public String getIssueNo() {
		return issueNo;
	}

	public void setIssueNo(String issueNo) {
		this.issueNo = issueNo;
	}

	public String getInvoiceNo() {
		return invoiceNo;
	}

	public void setInvoiceNo(String invoiceNo) {
		this.invoiceNo = invoiceNo;
	}

	public String getReceiptNo() {
		return receiptNo;
	}

	public void setReceiptNo(String receiptNo) {
		this.receiptNo = receiptNo;
	}

	public String getReturnedBy() {
		return returnedBy;
	}

	public void setReturnedBy(String returnedBy) {
		this.returnedBy = returnedBy;
	}

	public String getReceivedBy() {
		return receivedBy;
	}

	public void setReceivedBy(String receivedBy) {
		this.receivedBy = receivedBy;
	}

	public String getComments() {
		return comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}

	public Day getCreatedDay() {
		return createdDay;
	}

	public void setCreatedDay(Day createdDay) {
		this.createdDay = createdDay;
	}

	public Day getApprovedDay() {
		return approvedDay;
	}

	public void setApprovedDay(Day approvedDay) {
		this.approvedDay = approvedDay;
	}

	public Day getCompletedDay() {
		return completedDay;
	}

	public void setCompletedDay(Day completedDay) {
		this.completedDay = completedDay;
	}

	public User getCreatedByUser() {
		return createdByUser;
	}

	public void setCreatedByUser(User createdByUser) {
		this.createdByUser = createdByUser;
	}

	public User getApprovedByUser() {
		return approvedByUser;
	}

	public void setApprovedByUser(User approvedByUser) {
		this.approvedByUser = approvedByUser;
	}

	public User getCompletedByUser() {
		return completedByUser;
	}

	public void setCompletedByUser(User completedByUser) {
		this.completedByUser = completedByUser;
	}

	public List<ClientClaimedProduct> getClientClaimedProduct() {
		return clientClaimedProduct;
	}

	public void setClientClaimedProduct(List<ClientClaimedProduct> clientClaimedProduct) {
		this.clientClaimedProduct = clientClaimedProduct;
	}

	public List<ClientReplacementProduct> getClientReplacementProduct() {
		return clientReplacementProduct;
	}

	public void setClientReplacementProduct(List<ClientReplacementProduct> clientReplacementProduct) {
		this.clientReplacementProduct = clientReplacementProduct;
	}
    
    
}
