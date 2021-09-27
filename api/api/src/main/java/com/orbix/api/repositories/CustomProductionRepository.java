/**
 * 
 */
package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.CustomProduction;

/**
 * @author GODFREY
 *
 */
@Repository
public interface CustomProductionRepository extends JpaRepository<CustomProduction, Long> {

}
