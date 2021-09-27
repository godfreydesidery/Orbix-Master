/**
 * 
 */
package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.ClientReplacementProduct;

/**
 * @author GODFREY
 *
 */
@Repository
public interface ClientReplacementProductRepository extends JpaRepository<ClientReplacementProduct, Long> {

}
