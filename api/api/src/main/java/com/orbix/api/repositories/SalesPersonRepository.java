/**
 * 
 */
package com.orbix.api.repositories;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Personnel;
import com.orbix.api.models.SalesPerson;

/**
 * @author GODFREY
 *
 */
@Repository
public interface SalesPersonRepository extends JpaRepository<SalesPerson, Long> {

	/**
	 * @param findByRollNo
	 * @return
	 */
	Optional <SalesPerson> findByPersonnel(Personnel findByRollNo);

}
