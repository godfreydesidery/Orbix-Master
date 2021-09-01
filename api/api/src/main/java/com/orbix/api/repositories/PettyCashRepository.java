package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import com.orbix.api.models.PettyCash;

public interface PettyCashRepository extends JpaRepository<PettyCash, Long> {

}
