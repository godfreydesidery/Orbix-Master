/**
 * 
 */
package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.ProductConversionInitial;

/**
 * @author GODFREY
 *
 */
@Repository
public interface ProductConversionInitialRepository extends JpaRepository<ProductConversionInitial, Long> {

}
