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
@Table(name = "custom_productions")
@EntityListeners(AuditingEntityListener.class)
public class CustomProduction {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;	
	@NotBlank
	@Column(unique = true)
    private String no;
	@NotBlank
	@Column(unique = true)
    private String name;
	private double batchSize;
	private String uom;
    private String status;
    
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
    
    @OneToMany(targetEntity = CustomProductionMaterial.class, mappedBy = "customProduction", fetch = FetchType.LAZY, orphanRemoval = true)
    @Valid
    @JsonIgnoreProperties("customProduction")
    private List<CustomProductionMaterial> customProductionMaterial;
    
    @OneToMany(targetEntity = CustomProductionProduct.class, mappedBy = "customProduction", fetch = FetchType.LAZY, orphanRemoval = true)
    @Valid
    @JsonIgnoreProperties("customProduction")
    private List<CustomProductionProduct> customProductionProduct;

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

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public double getBatchSize() {
		return batchSize;
	}

	public void setBatchSize(double batchSize) {
		this.batchSize = batchSize;
	}

	public String getUom() {
		return uom;
	}

	public void setUom(String uom) {
		this.uom = uom;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
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

	public List<CustomProductionMaterial> getCustomProductionMaterial() {
		return customProductionMaterial;
	}

	public void setCustomProductionMaterial(List<CustomProductionMaterial> customProductionMaterial) {
		this.customProductionMaterial = customProductionMaterial;
	}

	public List<CustomProductionProduct> getCustomProductionProduct() {
		return customProductionProduct;
	}

	public void setCustomProductionProduct(List<CustomProductionProduct> customProductionProduct) {
		this.customProductionProduct = customProductionProduct;
	} 
	
	
}
