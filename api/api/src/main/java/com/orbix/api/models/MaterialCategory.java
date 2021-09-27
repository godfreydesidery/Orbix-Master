package com.orbix.api.models;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EntityListeners;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotBlank;

import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

@Entity
@Component
@Table(name = "material_categories")
@EntityListeners(AuditingEntityListener.class)
public class MaterialCategory {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;	
	@NotBlank
	@Column(unique = true)
    private String no;
	@NotBlank
	@Column(unique = true)
    private String name;	
    private String status;
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
	public String getStatus() {
		return status;
	}
	public void setStatus(String status) {
		this.status = status;
	}
    
    
}
