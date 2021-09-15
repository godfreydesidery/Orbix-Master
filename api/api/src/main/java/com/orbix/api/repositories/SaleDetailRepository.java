package com.orbix.api.repositories;

import java.time.LocalDate;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Sale;
import com.orbix.api.models.SaleDetail;

@Repository
public interface SaleDetailRepository extends JpaRepository<SaleDetail, Long> {

	List<SaleDetail> findBySale(Sale sale);

	List<SaleDetail> findBySaleIn(List<Sale> sales);

}
