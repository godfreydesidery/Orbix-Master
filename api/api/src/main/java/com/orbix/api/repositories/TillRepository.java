/**
 * 
 */
package com.orbix.api.repositories;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Till;

/**
 * @author GODFREY
 *
 */
@Repository
public interface TillRepository extends JpaRepository<Till, Long> {
	/**
	 * @param no
	 * @return
	 */
	Optional<Till> findByNo(String no);

	/**
	 * @param name
	 * @return
	 */
	Optional<Till> findByName(String name);

	Optional<Till> findByComputerName(String computerName);

}
