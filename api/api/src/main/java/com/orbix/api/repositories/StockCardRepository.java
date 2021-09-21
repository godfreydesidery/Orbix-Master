package com.orbix.api.repositories;

import java.time.LocalDate;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.StockCard;
import com.orbix.api.reports.StockCardReport;

@Repository
public interface StockCardRepository extends JpaRepository<StockCard, Long> {
	
	@Query(
			value = "SELECT\r\n" + 
					"`days`.`bussiness_date` AS `date`,\r\n" + 
					"`stock_cards`.`code` AS `code`,\r\n" + 
					"`stock_cards`.`description` AS `description`,\r\n" + 
					"`stock_cards`.`qty_in` AS `qtyIn`,\r\n" + 
					"`stock_cards`.`qty_out` AS `qtyOut`,\r\n" + 
					"`stock_cards`.`balance` AS `balance`,\r\n" + 
					"`stock_cards`.`reference` AS `reference`\r\n" + 
					"FROM\r\n" + 
					"`stock_cards`\r\n" + 
					"JOIN `days` ON\r\n" + 
					"`stock_cards`.`day_id`=`days`.`id`\r\n" + 
					"WHERE\r\n" + 
					"`days`.`bussiness_date` BETWEEN :fromDate AND :toDate\r\n" + 
					"ORDER BY `date` ASC",
					nativeQuery = true					
			)
	List<StockCardReport> getStockCardReport(LocalDate fromDate, LocalDate toDate);
	
}
