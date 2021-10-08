/**
 * 
 */
package com.orbix.api.repositories;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Lpo;
import com.orbix.api.models.ProductConversion;
import com.orbix.api.models.ProductConversionInitial;

/**
 * @author GODFREY
 *
 */
@Repository
public interface ProductConversionRepository extends JpaRepository<ProductConversion, Long> {

	@Query("SELECT c FROM ProductConversion c WHERE c.status IN (:statuses)")
	List<ProductConversion> findAllByStatus(List<String> statuses);
	
	/**
	 * @param no
	 * @return
	 */
	Optional<ProductConversion> findByNo(String no);

}
