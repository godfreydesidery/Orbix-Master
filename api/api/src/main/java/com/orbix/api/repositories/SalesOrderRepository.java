package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.SalesOrder;

@Repository
public interface SalesOrderRepository extends JpaRepository<SalesOrder, Long> {

}
