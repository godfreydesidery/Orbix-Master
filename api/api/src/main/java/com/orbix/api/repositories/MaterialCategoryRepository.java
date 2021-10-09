/**
 * 
 */
package com.orbix.api.repositories;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.MaterialCategory;

/**
 * @author GODFREY
 *
 */
@Repository
public interface MaterialCategoryRepository extends JpaRepository<MaterialCategory, Long> {
	
	@Query("select m.name from MaterialCategory m")
	Iterable<MaterialCategory> getNames();

	/**
	 * @param no
	 * @return
	 */
	Optional<MaterialCategory> findByNo(String no);

	/**
	 * @param name
	 * @return
	 */
	Optional<MaterialCategory> findByName(String name);
}