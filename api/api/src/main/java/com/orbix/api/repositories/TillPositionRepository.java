/**
 * 
 */
package com.orbix.api.repositories;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Till;
import com.orbix.api.models.TillPosition;

/**
 * @author GODFREY
 *
 */
@Repository
public interface TillPositionRepository extends JpaRepository<TillPosition, Long> {

	Optional<TillPosition> findByTill(Till till);

}
