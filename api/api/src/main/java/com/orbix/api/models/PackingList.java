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

@Component
@Entity
@Table(name = "packing_lists")
@EntityListeners(AuditingEntityListener.class)
public class PackingList {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
	
	@NotBlank
	@Column(unique = true)
    private String no;
	private String status;
	
	private double returns;
	private double packed;
	private double issued;
	
	private double discount;
	private double expenses;
	private double bankDeposit;
	private double cash;
	private double sample;
	private double deficit;
	
	@ManyToOne(targetEntity = Day.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "created_day_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Day createdDay;
	
	@ManyToOne(targetEntity = Day.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "issued_day_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Day issuedDay;
	
	@ManyToOne(targetEntity = Day.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "approved_day_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Day approvedDay;
	
	@ManyToOne(targetEntity = Day.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "printed_day_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Day printedDay;
	
	@ManyToOne(targetEntity = Day.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "completed_day_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Day completedDay;
	
	@ManyToOne(targetEntity = SalesPerson.class, fetch = FetchType.EAGER,  optional = false)
    @JoinColumn(name = "sales_person_id", nullable = false , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private SalesPerson salesPerson;
	
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
    @JoinColumn(name = "issued_by_user_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private User issuedByUser;
	
	@ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "printed_by_user_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private User printedByUser;
	
	@ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "completed_by_user_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private User completedByUser;
	
	@OneToMany(targetEntity = PackingListDetail.class, mappedBy = "packingList", fetch = FetchType.EAGER, orphanRemoval = true)
    @Valid
    @JsonIgnoreProperties("packingList")
    private List<PackingListDetail> packingListDetails;

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

	public double getReturns() {
		return returns;
	}

	public void setReturns(double returns) {
		this.returns = returns;
	}

	public double getPacked() {
		return packed;
	}

	public void setPacked(double packed) {
		this.packed = packed;
	}

	public double getIssued() {
		return issued;
	}

	public void setIssued(double issued) {
		this.issued = issued;
	}

	public double getDiscount() {
		return discount;
	}

	public void setDiscount(double discount) {
		this.discount = discount;
	}

	public double getExpenses() {
		return expenses;
	}

	public void setExpenses(double expenses) {
		this.expenses = expenses;
	}


	public double getBankDeposit() {
		return bankDeposit;
	}

	public void setBankDeposit(double bankDeposit) {
		this.bankDeposit = bankDeposit;
	}

	public double getCash() {
		return cash;
	}

	public void setCash(double cash) {
		this.cash = cash;
	}

	public double getSample() {
		return sample;
	}

	public void setSample(double sample) {
		this.sample = sample;
	}

	public double getDeficit() {
		return deficit;
	}

	public void setDeficit(double deficit) {
		this.deficit = deficit;
	}

	public Day getCreatedDay() {
		return createdDay;
	}

	public void setCreatedDay(Day createdDay) {
		this.createdDay = createdDay;
	}

	public Day getIssuedDay() {
		return issuedDay;
	}

	public void setIssuedDay(Day issuedDay) {
		this.issuedDay = issuedDay;
	}

	public Day getApprovedDay() {
		return approvedDay;
	}

	public void setApprovedDay(Day approvedDay) {
		this.approvedDay = approvedDay;
	}

	public Day getPrintedDay() {
		return printedDay;
	}

	public void setPrintedDay(Day printedDay) {
		this.printedDay = printedDay;
	}

	public Day getCompletedDay() {
		return completedDay;
	}

	public void setCompletedDay(Day completedDay) {
		this.completedDay = completedDay;
	}


	public SalesPerson getSalesPerson() {
		return salesPerson;
	}

	public void setSalesPerson(SalesPerson salesPerson) {
		this.salesPerson = salesPerson;
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

	public User getIssuedByUser() {
		return issuedByUser;
	}

	public void setIssuedByUser(User issuedByUser) {
		this.issuedByUser = issuedByUser;
	}

	public User getPrintedByUser() {
		return printedByUser;
	}

	public void setPrintedByUser(User printedByUser) {
		this.printedByUser = printedByUser;
	}

	public User getCompletedByUser() {
		return completedByUser;
	}

	public void setCompletedByUser(User completedByUser) {
		this.completedByUser = completedByUser;
	}

	public List<PackingListDetail> getPackingListDetails() {
		return packingListDetails;
	}

	public void setPackingListDetails(List<PackingListDetail> packingListDetails) {
		this.packingListDetails = packingListDetails;
	}

	
	
}
