package com.orbix.api.repositories;

import java.time.LocalDate;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Sale;
import com.orbix.api.reports.DailySalesReport;
import com.orbix.api.reports.ProductListingReport;

@Repository
public interface SaleRepository extends JpaRepository<Sale, Long> {

	@Query(
			value = "SELECT\r\n" + 
					"`days`.`bussiness_date` AS `date`,\r\n" + 
					"SUM(`sale_details`.`qty`*`sale_details`.`selling_price_vat_incl`) AS `amount`,\r\n" + 
					"SUM(`sale_details`.`qty`*`sale_details`.`discount`) AS `discount`\r\n" + 
					"FROM\r\n" + 
					"(SELECT * FROM `days` WHERE `bussiness_date` BETWEEN :fromDate AND :toDate)`days`\r\n" + 
					"JOIN\r\n" + 
					"`sales`\r\n" + 
					"ON\r\n" + 
					"`days`.`id`=`sales`.`day_id`\r\n" + 
					"JOIN\r\n" + 
					"`sale_details`\r\n" + 
					"ON\r\n" + 
					"`sale_details`.`sale_id`=`sales`.`id`\r\n" + 
					"GROUP BY\r\n" + 
					"`date`",
					nativeQuery = true					
			)
	List<DailySalesReport> getDailySalesReportByDate(LocalDate fromDate, LocalDate toDate);
	
//	@Query(
//			value = ""
//			nativeQuery = true;
//			)
//	List<ProductListingReport> getProductListingReport(LocalDate fromDate, LocalDate toDate);
//	
}
