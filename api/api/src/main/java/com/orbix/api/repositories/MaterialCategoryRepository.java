/**
 * 
 */
package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.MaterialCategory;

/**
 * @author GODFREY
 *
 */
@Repository
public interface MaterialCategoryRepository extends JpaRepository<MaterialCategory, Long> {

}