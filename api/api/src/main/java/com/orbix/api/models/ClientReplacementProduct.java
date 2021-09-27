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
import javax.persistence.Table;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

@Component
@Entity
@Table(name = "client_replacement_products")
@EntityListeners(AuditingEntityListener.class)
public class ClientReplacementProduct {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
	
	private double price;
	private double qty = 0;
		
	@ManyToOne(targetEntity = ClientClaim.class, fetch = FetchType.EAGER,  optional = false)
    @JoinColumn(name = "client_claim_id", nullable = false , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private ClientClaim clientClaim;
	
	@ManyToOne(targetEntity = Product.class, fetch = FetchType.EAGER,  optional = false)
    @JoinColumn(name = "product_id", nullable = false , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Product product;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public double getPrice() {
		return price;
	}

	public void setPrice(double price) {
		this.price = price;
	}

	public double getQty() {
		return qty;
	}

	public void setQty(double qty) {
		this.qty = qty;
	}

	public ClientClaim getClientClaim() {
		return clientClaim;
	}

	public void setClientClaim(ClientClaim clientClaim) {
		this.clientClaim = clientClaim;
	}

	public Product getProduct() {
		return product;
	}

	public void setProduct(Product product) {
		this.product = product;
	}
	
	
}
