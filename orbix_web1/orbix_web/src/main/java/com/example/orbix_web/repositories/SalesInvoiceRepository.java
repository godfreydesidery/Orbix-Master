/**
 * 
 */
package com.example.orbix_web.repositories;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import com.example.orbix_web.models.Customer;
import com.example.orbix_web.models.SalesInvoice;

/**
 * @author GODFREY
 *
 */
public interface SalesInvoiceRepository extends JpaRepository<SalesInvoice, Long> {

	/**
	 * @param statuses
	 * @return
	 */
	@Query("SELECT s FROM SalesInvoice s WHERE s.status IN (:statuses)")
	List<SalesInvoice> findAllByStatus(List<String> statuses);

	/**
	 * @param invoiceNo
	 * @return
	 */
	//SalesInvoice findByInvoiceNo(String invoiceNo);

	/**
	 * @param customer
	 * @return
	 */
	//List<SalesInvoice> findByCustomer(Customer customer);

	/**
	 * @param customer
	 * @param string
	 * @return
	 */
	//List<SalesInvoice> findByCustomerAndInvoiceStatusIn(Customer customer, List<String> status);

	


}
