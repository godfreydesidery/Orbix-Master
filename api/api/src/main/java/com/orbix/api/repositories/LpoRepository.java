package com.orbix.api.repositories;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Lpo;

@Repository
public interface LpoRepository extends JpaRepository<Lpo, Long> {

	@Query("SELECT l FROM Lpo l WHERE l.status IN (:statuses)")
	List<Lpo> findAllByStatus(List<String> statuses);

	Optional<Lpo> findByNo(String no);

}
