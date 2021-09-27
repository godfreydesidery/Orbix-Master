package com.orbix.api.models;

import javax.persistence.Embedded;
import javax.persistence.Entity;
import javax.persistence.EntityListeners;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToOne;
import javax.persistence.Table;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

@Entity
@Component
@Table(name = "custom_production_materials")
@EntityListeners(AuditingEntityListener.class)
public class CustomProductionMaterial {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;	
	private double qty = 0;
	
	@ManyToOne(targetEntity = CustomProduction.class, fetch = FetchType.EAGER,  optional = false)
    @JoinColumn(name = "custom_production_id", nullable = false , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private CustomProduction customProduction;
	
	@OneToOne(targetEntity = Material.class, fetch = FetchType.EAGER,  optional = false)
    @JoinColumn(name = "material_id", nullable = false , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded	
    private Material material;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public double getQty() {
		return qty;
	}

	public void setQty(double qty) {
		this.qty = qty;
	}

	public CustomProduction getCustomProduction() {
		return customProduction;
	}

	public void setCustomProduction(CustomProduction customProduction) {
		this.customProduction = customProduction;
	}

	public Material getMaterial() {
		return material;
	}

	public void setMaterial(Material material) {
		this.material = material;
	}
	
	
}
