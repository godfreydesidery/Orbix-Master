package com.orbix.api.models;

import java.time.LocalDate;
import java.util.List;

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

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@Entity
@Component
@Table(name = "carts")
@EntityListeners(AuditingEntityListener.class)
public class Cart {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
	private LocalDate cartDate;
	
	@ManyToOne(targetEntity = Till.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "till_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Till till;
	
	@ManyToOne(targetEntity = Day.class, fetch = FetchType.EAGER,  optional = true)
    @JoinColumn(name = "day_id", nullable = true , updatable = true)
    @OnDelete(action = OnDeleteAction.NO_ACTION)
	@Autowired
	@Embedded
    private Day day;
	
	@OneToMany(targetEntity = CartDetail.class, mappedBy = "cart", fetch = FetchType.EAGER, orphanRemoval = true)
    @Valid
    @JsonIgnoreProperties("cart")
    private List<CartDetail> cartDetails;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Till getTill() {
		return till;
	}

	public void setTill(Till till) {
		this.till = till;
	}

	public LocalDate getCartDate() {
		return cartDate;
	}

	public void setCartDate(LocalDate cartDate) {
		this.cartDate = cartDate;
	}

	public List<CartDetail> getCartDetails() {
		return cartDetails;
	}

	public void setCartDetails(List<CartDetail> cartDetails) {
		this.cartDetails = cartDetails;
	}

	public Day getDay() {
		return day;
	}

	public void setDay(Day day) {
		this.day = day;
	}
	
	
}
