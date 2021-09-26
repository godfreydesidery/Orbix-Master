package com.orbix.api.repositories;

import java.time.LocalDate;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.PriceChange;
import com.orbix.api.reports.PriceChangeReport;

@Repository
public interface PriceChangeRepository extends JpaRepository<PriceChange, Long> {
	
	@Query(
			value = "SELECT\r\n" + 
					"`days`.`bussiness_date` AS `date`,\r\n" + 
					"`price_changes`.`date_time` AS `dateTime`,\r\n" + 
					"`price_changes`.`code` AS `code`,\r\n" + 
					"`price_changes`.`description` AS `description`,\r\n" + 
					"`price_changes`.`old_price` AS `oldPrice`,\r\n" + 
					"`price_changes`.`new_price` AS `newPrice`,\r\n" + 
					"`price_changes`.`new_price`-`price_changes`.`old_price` AS `change`,\r\n" + 
					"`price_changes`.`reason` AS `reason`,\r\n" + 
					"CONCAT(`users`.`last_name`,' ',`users`.`first_name`) AS `user`\r\n" + 
					"FROM\r\n" + 
					"`price_changes`\r\n" + 
					"JOIN `days` ON\r\n" + 
					"`price_changes`.`day_id`=`days`.`id`\r\n" + 
					"LEFT JOIN `users` ON\r\n" + 
					"`price_changes`.`changed_by_user_id`=`users`.`id`\r\n" + 
					"WHERE `days`.`bussiness_date` BETWEEN :fromDate AND :toDate\r\n" + 
					"ORDER BY `days`.`bussiness_date` ASC",
					nativeQuery = true					
			)
	List<PriceChangeReport> getPriceChangeReport(LocalDate fromDate, LocalDate toDate);
	
}
