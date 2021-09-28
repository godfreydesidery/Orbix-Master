/**
 * 
 */
package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.DamagedProduct;

/**
 * @author GODFREY
 *
 */
@Repository
public interface DamagedProductRepository extends JpaRepository<DamagedProduct, Long> {
	
}
