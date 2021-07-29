/**
 * 
 */
package com.orbix.api.repositories;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Grn;

/**
 * @author GODFREY
 *
 */
@Repository
public interface GrnRepository extends JpaRepository<Grn, Long>{

	/**
	 * @param no
	 * @return
	 */
	Optional<Grn> findByNo(String no);

	/**
	 * @return
	 */
	Optional<Grn> findTopByOrderByIdDesc();

	@Query("SELECT g FROM Grn g WHERE g.status IN (:statuses)")
	List<Grn> findAllByStatus(List<String> statuses);
	
}
