package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.StockCard;

@Repository
public interface StockCardRepository extends JpaRepository<StockCard, Long> {

}
