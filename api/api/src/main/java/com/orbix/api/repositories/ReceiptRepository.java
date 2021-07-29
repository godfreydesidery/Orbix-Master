/**
 * 
 */
package com.orbix.api.repositories;

import java.time.LocalDate;
import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Receipt;
import com.orbix.api.models.Till;

/**
 * @author GODFREY
 *
 */
@Repository
public interface ReceiptRepository extends JpaRepository<Receipt, Long> {

	/**
	 * @param till
	 * @param date
	 * @return 
	 */
	List<Receipt> findByTillAndIssueDate(Till till, LocalDate date);

	/**
	 * @param till
	 * @return 
	 */
	List<Receipt> findByTill(Till till);

	/**
	 * @param date
	 * @return 
	 */
	List<Receipt> findByIssueDate(LocalDate date);

	Optional<Receipt> findByNo(String no);

}