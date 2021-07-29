/**
 * 
 */
package com.example.orbix_web.repositories;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import com.example.orbix_web.models.CompanyProfile;
import com.example.orbix_web.models.CorporateCustomer;

/**
 * @author GODFREY
 *
 */
public interface CorporateCustomerRepository extends JpaRepository <CorporateCustomer, Long> {

	/**
	 * @param no
	 * @return
	 */
	Optional<CorporateCustomer> findByNo(String no);

	/**
	 * @return
	 */
	@Query("select c.name from CorporateCustomer c")
	Iterable<CorporateCustomer> getNames();

}
