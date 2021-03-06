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
	
	@ManyToOne(targetEntity = Day.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "day_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Day day;
	
	@OneToMany(targetEntity = GrnDetail.class, mappedBy = "grn", fetch = FetchType.EAGER, orphanRemoval = true)
    @Valid
    @JsonIgnoreProperties("grn")
    private List<GrnDetail> grnDetails;

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

	public LocalDate getReceivedDate() {
		return receivedDate;
	}

	public void setReceivedDate(LocalDate receivedDate) {
		this.receivedDate = receivedDate;
	}

	public String getInvoiceNo() {
		return invoiceNo;
	}

	public void setInvoiceNo(String invoiceNo) {
		this.invoiceNo = invoiceNo;
	}

	public double getInvoiceTotal() {
		return invoiceTotal;
	}

	public void setInvoiceTotal(double invoiceTotal) {
		this.invoiceTotal = invoiceTotal;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

	public User getReceivedUser() {
		return receivedUser;
	}

	public void setReceivedUser(User receivedUser) {
		this.receivedUser = receivedUser;
	}

	public Lpo getLpo() {
		return lpo;
	}

	public void setLpo(Lpo lpo) {
		this.lpo = lpo;
	}

	public Supplier getSupplier() {
		return supplier;
	}

	public void setSupplier(Supplier supplier) {
		this.supplier = supplier;
	}

	public List<GrnDetail> getGrnDetails() {
		return grnDetails;
	}

	public void setGrnDetails(List<GrnDetail> grnDetails) {
		this.grnDetails = grnDetails;
	}

	public Day getDay() {
		return day;
	}

	public void setDay(Day day) {
		this.day = day;
	}

	
	
}
