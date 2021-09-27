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
@Table(name = "product_conversions")
@EntityListeners(AuditingEntityListener.class)
public class ProductConversion {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;	
	@NotBlank
	@Column(unique = true)
    private String no;	
    private String status;
    private String reason;
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
    
    @OneToMany(targetEntity = ProductConversionInitial.class, mappedBy = "productConversion", fetch = FetchType.LAZY, orphanRemoval = true)
    @Valid
    @JsonIgnoreProperties("productConversion")
    private List<ProductConversionInitial> productConversionInitial;
    
    @OneToMany(targetEntity = ProductConversionFinal.class, mappedBy = "productConversion", fetch = FetchType.LAZY, orphanRemoval = true)
    @Valid
    @JsonIgnoreProperties("productConversion")
    private List<ProductConversionFinal> productConversionFinal;

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

	public String getReason() {
		return reason;
	}

	public void setReason(String reason) {
		this.reason = reason;
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
    
    
}
