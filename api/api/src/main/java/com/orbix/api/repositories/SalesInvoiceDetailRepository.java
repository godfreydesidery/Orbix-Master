/**
 * 
 */
package com.orbix.api.repositories;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;

import com.orbix.api.models.SalesInvoice;
import com.orbix.api.models.SalesInvoiceDetail;

/**
 * @author GODFREY
 *
 */
public interface SalesInvoiceDetailRepository extends JpaRepository<SalesInvoiceDetail, Long> {

	/**
	 * @param invoice
	 * @return
	 */
	List<SalesInvoiceDetail> findBySalesInvoice(SalesInvoice invoice);

	/**
	 * @param invoice
	 * @param code
	 * @return
	 */
	Optional<SalesInvoiceDetail> findBySalesInvoiceAndCode(SalesInvoice invoice, String code);

}
