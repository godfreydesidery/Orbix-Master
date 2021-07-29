/**
 * 
 */
package com.orbix.api.repositories;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Rtv;

/**
 * @author GODFREY
 *
 */
@Repository
public interface RtvRepository extends JpaRepository<Rtv, Long>{

	/**
	 * @param statuses
	 * @return
	 */
	@Query("SELECT r FROM Rtv r WHERE r.status IN (:statuses)")
	List<Rtv> findAllByStatus(@Param("statuses") List<String> statuses);

	Optional<Rtv> findByNo(String no);
}
