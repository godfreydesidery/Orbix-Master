/**
 * 
 */
package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.ClientClaimedProduct;

/**
 * @author GODFREY
 *
 */
@Repository
public interface ClientClaimedProductRepository extends JpaRepository<ClientClaimedProduct, Long> {

}
