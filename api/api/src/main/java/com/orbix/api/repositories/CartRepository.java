package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Cart;
import com.orbix.api.models.Till;

@Repository
public interface CartRepository extends JpaRepository<Cart, Long> {

	Cart findByTill(Till till);

	Cart findByIdAndTill(Long id, Till till);

}
