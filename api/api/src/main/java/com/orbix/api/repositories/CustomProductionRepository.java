/**
 * 
 */
package com.orbix.api.repositories;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.CustomProduction;

/**
 * @author GODFREY
 *
 */
@Repository
public interface CustomProductionRepository extends JpaRepository<CustomProduction, Long> {
	
	@Query("SELECT cp FROM CustomProduction cp WHERE cp.status IN (:statuses)")
	List<CustomProduction> findAllByStatus(List<String> statuses);

	/**
	 * @param no
	 * @return
	 */
	Optional<CustomProduction> findByNo(String no);

	
}
