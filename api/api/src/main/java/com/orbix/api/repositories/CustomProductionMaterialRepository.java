/**
 * 
 */
package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.CustomProductionMaterial;

/**
 * @author GODFREY
 *
 */
@Repository
public interface CustomProductionMaterialRepository extends JpaRepository<CustomProductionMaterial, Long> {

}
