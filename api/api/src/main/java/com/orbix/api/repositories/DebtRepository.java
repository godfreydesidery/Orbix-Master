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

import com.orbix.api.models.Debt;
import com.orbix.api.models.PackingList;
import com.orbix.api.reports.DebtTrackerReport;
import com.orbix.api.reports.PrintedLPO;

/**
 * @author GODFREY
 *
 */
@Repository
public interface DebtRepository extends JpaRepository<Debt, Long> {

	/**
	 * @param packingList
	 * @return
	 */
	Optional<Debt> findByPackingList(PackingList packingList);
	
	@Query(
			value = "SELECT\r\n" + 
					"`debts`.`amount` AS `amount`,\r\n" + 
					"`debts`.`reference` AS `reference`,\r\n" + 
					"`days`.`bussiness_date` AS `date`,\r\n" + 
					"`sales_persons`.`name` AS `name`\r\n" + 
					"FROM\r\n" + 
					"`debts`\r\n" + 
					"JOIN `days` ON\r\n" + 
					"`days`.`id`=`debts`.`day_id`\r\n" + 
					"JOIN\r\n" + 
					"(SELECT\r\n" + 
					" `sales_persons`.`id` AS `id`,\r\n" + 
					" `personnels`.`name` AS `name`\r\n" + 
					" FROM\r\n" + 
					" `sales_persons`\r\n" + 
					" JOIN `personnels` ON\r\n" + 
					" `sales_persons`.`personnel_id`=`personnels`.`id`)\r\n" + 
					" `sales_persons` ON\r\n" + 
					" `sales_persons`.`id`=`debts`.`sales_person_id`\r\n" + 
					" WHERE\r\n" + 
					" `days`.`bussiness_date` BETWEEN :fromDate AND :toDate AND `amount`>0",
					nativeQuery = true					
			)
	List<DebtTrackerReport> getDebtTracker(LocalDate fromDate, LocalDate toDate);
	
	@Query(
			value = "SELECT\r\n" + 
					"`debts`.`amount` AS `amount`,\r\n" + 
					"`debts`.`reference` AS `reference`,\r\n" + 
					"`days`.`bussiness_date` AS `date`,\r\n" + 
					"`sales_persons`.`name` AS `name`\r\n" + 
					"FROM\r\n" + 
					"`debts`\r\n" + 
					"JOIN `days` ON\r\n" + 
					"`days`.`id`=`debts`.`day_id`\r\n" + 
					"JOIN\r\n" + 
					"(SELECT\r\n" + 
					" `sales_persons`.`id` AS `id`,\r\n" + 
					" `personnels`.`name` AS `name`\r\n" + 
					" FROM\r\n" + 
					" `sales_persons`\r\n" + 
					" JOIN `personnels` ON\r\n" + 
					" `sales_persons`.`personnel_id`=`personnels`.`id`)\r\n" + 
					" `sales_persons` ON\r\n" + 
					" `sales_persons`.`id`=`debts`.`sales_person_id`\r\n" + 
					" WHERE\r\n" + 
					" `days`.`bussiness_date` BETWEEN :fromDate AND :toDate AND `amount`>0 AND `name` =:name",
					nativeQuery = true					
			)
	List<DebtTrackerReport> getDebtTrackerBySalesPerson(LocalDate fromDate, LocalDate toDate, String name);
	

}
