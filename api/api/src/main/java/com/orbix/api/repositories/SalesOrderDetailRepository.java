package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.SalesOrderDetail;


@Repository
public interface SalesOrderDetailRepository extends JpaRepository<SalesOrderDetail, Long> {

}
