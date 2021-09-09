package com.orbix.api.models;

import java.time.LocalDate;
import java.time.LocalDateTime;

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
import javax.persistence.Table;
import javax.validation.constraints.NotBlank;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

@Component
@Entity
@Table(name = "sales_orders")
@EntityListeners(AuditingEntityListener.class)
public class SalesOrder {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;			
	private LocalDateTime issueDateTime;
	private LocalDateTime completedDateTime;
	private String status;
	
	@ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "attendant_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded	
    private User attendant;
	
	@ManyToOne(targetEntity = Day.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "day_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Day day;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

	public User getAttendant() {
		return attendant;
	}

	public void setAttendant(User attendant) {
		this.attendant = attendant;
	}

	public LocalDateTime getIssueDateTime() {
		return issueDateTime;
	}

	public void setIssueDateTime(LocalDateTime issueDateTime) {
		this.issueDateTime = issueDateTime;
	}

	public LocalDateTime getCompletedDateTime() {
		return completedDateTime;
	}

	public void setCompletedDateTime(LocalDateTime completedDateTime) {
		this.completedDateTime = completedDateTime;
	}

	public Day getDay() {
		return day;
	}

	public void setDay(Day day) {
		this.day = day;
	}
	
	
	
}
