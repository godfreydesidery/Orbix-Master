/**
 * 
 */
package com.orbix.api.repositories;

import java.time.LocalDate;
import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Grn;
import com.orbix.api.reports.GRNReport;
import com.orbix.api.reports.PendingLPO;

/**
 * @author GODFREY
 *
 */
@Repository
public interface GrnRepository extends JpaRepository<Grn, Long>{

	/**
	 * @param no
	 * @return
	 */
	Optional<Grn> findByNo(String no);

	/**
	 * @return
	 */
	Optional<Grn> findTopByOrderByIdDesc();

	@Query("SELECT g FROM Grn g WHERE g.status IN (:statuses)")
	List<Grn> findAllByStatus(List<String> statuses);
	
	
	@Query(
			value = "SELECT\r\n" + 
					"`days`.`bussiness_date` AS `date`,\r\n" + 
					"`grns`.`no` AS `grnNo`,\r\n" + 
					"`grns`.`invoice_no` AS `invoiceNo`,\r\n" + 
					"`lpos`.`no` AS `lpoNo`,\r\n" + 
					"CONCAT('(',`suppliers`.`code`,') ',`suppliers`.`name`) AS `supplier`,\r\n" + 
					"`grn_details`.`code` AS `code`,\r\n" + 
					"`grn_details`.`description` AS `description`,\r\n" + 
					"`grn_details`.`qty_received` AS `qty`,\r\n" + 
					"`grn_details`.`client_cost_price` AS `price`,\r\n" + 
					"`grn_details`.`client_cost_price`*`grn_details`.`qty_received` AS `amount`\r\n" + 
					"FROM\r\n" + 
					"`grns`\r\n" + 
					"JOIN `days` ON\r\n" + 
					"`grns`.`day_id`=`days`.`id`\r\n" + 
					"JOIN `grn_details` ON\r\n" + 
					"`grn_details`.`grn_id`=`grns`.`id`\r\n" + 
					"LEFT JOIN `suppliers` ON\r\n" + 
					"`grns`.`supplier_id`=`suppliers`.`id`\r\n" + 
					"LEFT JOIN `lpos` ON\r\n" + 
					"`grns`.`lpo_id`=`lpos`.`id`\r\n" + 
					"WHERE\r\n" + 
					"`days`.`bussiness_date` BETWEEN :fromDate AND :toDate",
					nativeQuery = true					
			)
	List<GRNReport> getGrnReport(LocalDate fromDate, LocalDate toDate);
	
}
