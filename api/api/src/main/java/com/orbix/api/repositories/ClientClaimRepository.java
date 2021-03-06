/**
 * 
 */
package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.ClientClaim;

/**
 * @author GODFREY
 *
 */
@Repository
public interface ClientClaimRepository extends JpaRepository<ClientClaim, Long> {

}
