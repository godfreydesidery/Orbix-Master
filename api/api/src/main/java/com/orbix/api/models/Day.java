package com.orbix.api.models;

import java.time.LocalDate;
import java.util.Date;

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
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

@Entity
@Component
@Table(name = "days")
@EntityListeners(AuditingEntityListener.class)
public class Day {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
	private LocalDate bussinessDate;
	@Temporal(TemporalType.TIMESTAMP)
    private Date startedAt;
	@Temporal(TemporalType.TIMESTAMP)
    private Date endedAt;
	private String status = "STARTED";
	
	@ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "started_by_user_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded	
    private User startedBy;
	
	@ManyToOne(targetEntity = User.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "ended_by_user_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded	
    private User endedBy;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public LocalDate getBussinessDate() {
		return bussinessDate;
	}

	public void setBussinessDate(LocalDate bussinessDate) {
		this.bussinessDate = bussinessDate;
	}

	public Date getStartedAt() {
		return startedAt;
	}

	public void setStartedAt(Date startedAt) {
		this.startedAt = startedAt;
	}

	public Date getEndedAt() {
		return endedAt;
	}

	public void setEndedAt(Date endedAt) {
		this.endedAt = endedAt;
	}

	public User getStartedBy() {
		return startedBy;
	}

	public void setStartedBy(User startedBy) {
		this.startedBy = startedBy;
	}

	public User getEndedBy() {
		return endedBy;
	}

	public void setEndedBy(User endedBy) {
		this.endedBy = endedBy;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}
	
	
}
