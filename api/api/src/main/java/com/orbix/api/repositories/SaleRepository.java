package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Sale;

@Repository
public interface SaleRepository extends JpaRepository<Sale, Long> {

}
