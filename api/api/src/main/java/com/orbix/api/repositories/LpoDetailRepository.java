package com.orbix.api.repositories;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Lpo;
import com.orbix.api.models.LpoDetail;

@Repository
public interface LpoDetailRepository extends JpaRepository<LpoDetail, Long> {

	List<LpoDetail> findByLpo(Lpo lpo);

	Optional<LpoDetail> findByLpoAndCode(Lpo lpo, String code);

}
