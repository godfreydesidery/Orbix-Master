/**
 * 
 */
package com.example.orbix_web.repositories;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.example.orbix_web.models.Grn;
import com.example.orbix_web.models.Lpo;
import com.example.orbix_web.models.Supplier;

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
	
}
