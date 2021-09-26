package com.orbix.api.repositories;

import java.time.LocalDate;
import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Lpo;
import com.orbix.api.reports.PendingLPO;
import com.orbix.api.reports.PrintedLPO;

@Repository
public interface LpoRepository extends JpaRepository<Lpo, Long> {

	@Query("SELECT l FROM Lpo l WHERE l.status IN (:statuses)")
	List<Lpo> findAllByStatus(List<String> statuses);

	Optional<Lpo> findByNo(String no);

	List<Lpo> findAllByStatus(String string);
	
		
	@Query(
			value = "SELECT\r\n" + 
					"`lpos`.`no` AS `lpoNo`,\r\n" + 
					"CONCAT('(',`suppliers`.`code`,') ',`suppliers`.`name`) AS `supplierName`,\r\n" + 
					"`days`.`bussiness_date` AS `dateCreated`,\r\n" + 
					"`lpos`.`valid_until` AS `validUntil`,\r\n" + 
					"CONCAT(`lpos`.`validity_days`,' days ',`lpos`.`status`) AS `summary`,\r\n" + 
					"`lpos`.`status` AS `status`\r\n" + 
					"FROM\r\n" + 
					"`lpos`\r\n" + 
					"JOIN `days` ON\r\n" + 
					"`lpos`.`day_id`=`days`.`id`\r\n" + 
					"JOIN `suppliers` ON\r\n" + 
					"`lpos`.`supplier_id`=`suppliers`.`id`\r\n" + 
					"WHERE\r\n" + 
					"`days`.`bussiness_date` BETWEEN :fromDate AND :toDate AND `lpos`.`status`='PRINTED'",
					nativeQuery = true					
			)
	List<PrintedLPO> getPrintedLPO(LocalDate fromDate, LocalDate toDate);
	
	
	@Query(
			value = "SELECT\r\n" + 
					"`lpos`.`no` AS `lpoNo`,\r\n" + 
					"CONCAT('(',`suppliers`.`code`,') ',`suppliers`.`name`) AS `supplierName`,\r\n" + 
					"`days`.`bussiness_date` AS `dateCreated`,\r\n" + 
					"`lpos`.`valid_until` AS `validUntil`,\r\n" + 
					"CONCAT(`lpos`.`validity_days`,' days ',`lpos`.`status`) AS `summary`,\r\n" + 
					"`lpos`.`status` AS `status`\r\n" + 
					"FROM\r\n" + 
					"`lpos`\r\n" + 
					"JOIN `days` ON\r\n" + 
					"`lpos`.`day_id`=`days`.`id`\r\n" + 
					"JOIN `suppliers` ON\r\n" + 
					"`lpos`.`supplier_id`=`suppliers`.`id`\r\n" + 
					"WHERE\r\n" + 
					"`days`.`bussiness_date` BETWEEN :fromDate AND :toDate AND `lpos`.`status`='PENDING'",
					nativeQuery = true					
			)
	List<PendingLPO> getPendingLPO(LocalDate fromDate, LocalDate toDate);

}
