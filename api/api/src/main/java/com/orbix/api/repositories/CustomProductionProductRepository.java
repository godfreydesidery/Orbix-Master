/**
 * 
 */
package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.CustomProductionProduct;

/**
 * @author GODFREY
 *
 */
@Repository
public interface CustomProductionProductRepository extends JpaRepository<CustomProductionProduct, Long> {

}
