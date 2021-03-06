/**
 * 
 */
package com.example.orbix_web.models;

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
import javax.persistence.OneToOne;
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
@Table(name = "grns")
@EntityListeners(AuditingEntityListener.class)
public class Grn {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;	
	@NotBlank
	@Column(unique = true)
    private String no;
	private LocalDate receivedDate;
	private String invoiceNo;
	private double invoiceTotal;
	private String status;
	
	@ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "received_by_user_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private User receivedUser;
	
	@OneToOne(targetEntity = Lpo.class, fetch = FetchType.LAZY,  optional = true)
    @JoinColumn(name = "lpo_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded	
    private Lpo lpo;
	
	@OneToOne(targetEntity = Supplier.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "supplier_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Supplier supplier;
	
	@OneToMany(targetEntity = GrnDetail.class, mappedBy = "grn", fetch = FetchType.EAGER, orphanRemoval = true)
    @Valid
    @JsonIgnoreProperties("grn")
    private List<GrnDetail> grnDetails;

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
	 * @return the receivedDate
	 */
	public LocalDate getReceivedDate() {
		return receivedDate;
	}

	/**
	 * @param receivedDate the receivedDate to set
	 */
	public void setReceivedDate(LocalDate receivedDate) {
		this.receivedDate = receivedDate;
	}

	/**
	 * @return the invoiceNo
	 */
	public String getInvoiceNo() {
		return invoiceNo;
	}

	/**
	 * @param invoiceNo the invoiceNo to set
	 */
	public void setInvoiceNo(String invoiceNo) {
		this.invoiceNo = invoiceNo;
	}

	/**
	 * @return the invoiceTotal
	 */
	public String getInvoiceTotal() {
		return invoiceTotal;
	}

	/**
	 * @param invoiceTotal the invoiceTotal to set
	 */
	public void setInvoiceTotal(String invoiceTotal) {
		this.invoiceTotal = invoiceTotal;
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
	 * @return the receivedUser
	 */
	public User getReceivedUser() {
		return receivedUser;
	}

	/**
	 * @param receivedUser the receivedUser to set
	 */
	public void setReceivedUser(User receivedUser) {
		this.receivedUser = receivedUser;
	}

	/**
	 * @return the lpo
	 */
	public Lpo getLpo() {
		return lpo;
	}

	/**
	 * @param lpo the lpo to set
	 */
	public void setLpo(Lpo lpo) {
		this.lpo = lpo;
	}

	/**
	 * @return the grnDetails
	 */
	public List<GrnDetail> getGrnDetails() {
		return grnDetails;
	}

	/**
	 * @param grnDetails the grnDetails to set
	 */
	public void setGrnDetails(List<GrnDetail> grnDetails) {
		this.grnDetails = grnDetails;
	}

	/**
	 * @return the supplier
	 */
	public Supplier getSupplier() {
		return supplier;
	}

	/**
	 * @param supplier the supplier to set
	 */
	public void setSupplier(Supplier supplier) {
		this.supplier = supplier;
	}
	
}
