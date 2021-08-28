package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import com.orbix.api.models.Voided;

public interface VoidedRepository extends JpaRepository<Voided, Long> {

}
