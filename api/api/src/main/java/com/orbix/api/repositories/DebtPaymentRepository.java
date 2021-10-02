/**
 * 
 */
package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.DebtPayment;

/**
 * @author GODFREY
 *
 */
@Repository
public interface DebtPaymentRepository extends JpaRepository<DebtPayment, Long> {
	
}
