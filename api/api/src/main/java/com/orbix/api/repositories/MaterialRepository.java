/**
 * 
 */
package com.orbix.api.repositories;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Material;
import com.orbix.api.models.MaterialCategory;

/**
 * @author GODFREY
 *
 */
@Repository
public interface MaterialRepository extends JpaRepository<Material, Long> {
	
	@Query("select m.description from Material m")
	Iterable<MaterialCategory> getDescriptions();

	/**
	 * @param description
	 * @return
	 */
	Optional<Material> findByDescription(String description);

	/**
	 * @param code
	 * @return
	 */
	Optional<Material> findByCode(String code);
}
