package com.orbix.api.repositories;

import java.util.List;
import java.util.Optional;

import javax.validation.Valid;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Cart;
import com.orbix.api.models.CartDetail;

@Repository
public interface CartDetailRepository extends JpaRepository<CartDetail, Long> {

	/**
	 * @param findById
	 * @return
	 */
	List<CartDetail> findByCart(Optional<Cart> findById);

	/**
	 * @param code
	 * @return
	 */
	Optional<CartDetail> findByCode(String code);

	/**
	 * @param code
	 * @param i
	 * @param cart
	 * @return
	 */
	Optional<CartDetail> findByCodeAndVoidedAndCart(String code, int i, @Valid Cart cart);

}
