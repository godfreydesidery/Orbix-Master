/**
 * 
 */
package com.orbix.api.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.CustomProduction;
import com.orbix.api.models.CustomProductionMaterial;

/**
 * @author GODFREY
 *
 */
@Repository
public interface CustomProductionMaterialRepository extends JpaRepository<CustomProductionMaterial, Long> {

	/**
	 * @param customProduction
	 * @return
	 */
	List<CustomProductionMaterial> findAllByCustomProduction(CustomProduction customProduction);

}
