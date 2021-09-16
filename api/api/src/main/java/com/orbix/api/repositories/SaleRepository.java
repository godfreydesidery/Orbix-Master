package com.orbix.api.repositories;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
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
	
//	SELECT
//	`days`.`bussiness_date` AS `date`,
//	`sale_details`.`code` AS `code`,
//	SUM(`sale_details`.`qty`*`sale_details`.`selling_price_vat_incl`) AS `amount`,
//	CONCAT(`users`.`last_name`,', ',`users`.`first_name`) AS `cashier`,
//	`receipts`.`no` AS `receiptNo`,
//	`tills`.`no` AS `tillNo`
//	FROM
//	`sales`
//	JOIN `days` ON
//	`days`.`id`=`sales`.`day_id`
//	JOIN `sale_details` ON
//	`sale_details`.`sale_id`=`sales`.`id`
//	LEFT JOIN `users` ON
//	`users`.`id`=`sales`.`sale_user_id`
//	JOIN `receipts` ON
//	`receipts`.`id`=`sales`.`receipt_id`
//	JOIN `tills` ON
//	`tills`.`id`=`receipts`.`till_id`
//	WHERE
//	`days`.`bussiness_date` BETWEEN '2021-09-01' AND '2021-09-30'
//	GROUP BY `date`,`code`,`receiptNo`,`cashier`,`tillNo`
//	ORDER BY
//	`date` ASC
	
	
	@Query(
			value = "SELECT\r\n" + 
					"`days`.`bussiness_date` AS `date`,\r\n" + 
					"`sale_details`.`code` AS `code`,\r\n" + 
					"`sale_details`.`description` AS `description`,\r\n" + 
					"SUM(`sale_details`.`qty`*`sale_details`.`selling_price_vat_incl`) AS `amount`,\r\n" + 
					"CONCAT(`users`.`last_name`,', ',`users`.`first_name`) AS `cashier`,\r\n" + 
					"`receipts`.`no` AS `receiptNo`,\r\n" + 
					"`sales_invoices`.`no` as `invoiceNo`,\r\n" + 
					"`tills`.`no` AS `tillNo`\r\n" + 
					"FROM\r\n" + 
					"`sales`\r\n" + 
					"JOIN `days` ON\r\n" + 
					"`days`.`id`=`sales`.`day_id`\r\n" + 
					"JOIN `sale_details` ON\r\n" + 
					"`sale_details`.`sale_id`=`sales`.`id`\r\n" + 
					"LEFT JOIN `users` ON\r\n" + 
					"`users`.`id`=`sales`.`sale_user_id`\r\n" + 
					"LEFT JOIN `receipts` ON\r\n" + 
					"`receipts`.`id`=`sales`.`receipt_id`\r\n" + 
					"LEFT JOIN `sales_invoices` ON\r\n" + 
					"`sales_invoices`.`id` =`sales`.`sales_invoice_id`\r\n" + 
					"LEFT JOIN `tills` ON\r\n" + 
					"`tills`.`id`=`receipts`.`till_id`\r\n" + 
					"WHERE\r\n" +
					"`days`.`bussiness_date` BETWEEN :fromDate AND :toDate\r\n" + 
					"GROUP BY `date`,`code`,`description`,`receiptNo`,`cashier`,`tillNo`\r\n" + 
					"ORDER BY\r\n" + 
					"`date` ASC",
					nativeQuery = true					
			)
	List<ProductListingReport> getProductListingReport(LocalDate fromDate, LocalDate toDate);
	
	
	@Query(
			value = "SELECT\r\n" + 
					"`days`.`bussiness_date` AS `date`,\r\n" + 
					"`sale_details`.`code` AS `code`,\r\n" + 
					"`sale_details`.`description` AS `description`,\r\n" + 
					"SUM(`sale_details`.`qty`*`sale_details`.`selling_price_vat_incl`) AS `amount`,\r\n" + 
					"CONCAT(`users`.`last_name`,', ',`users`.`first_name`) AS `cashier`,\r\n" + 
					"`receipts`.`no` AS `receiptNo`,\r\n" + 
					"`sales_invoices`.`no` as `invoiceNo`,\r\n" + 
					"`tills`.`no` AS `tillNo`\r\n" + 
					"FROM\r\n" + 
					"`sales`\r\n" + 
					"JOIN `days` ON\r\n" + 
					"`days`.`id`=`sales`.`day_id`\r\n" + 
					"JOIN `sale_details` ON\r\n" + 
					"`sale_details`.`sale_id`=`sales`.`id`\r\n" + 
					"LEFT JOIN `users` ON\r\n" + 
					"`users`.`id`=`sales`.`sale_user_id`\r\n" + 
					"LEFT JOIN `receipts` ON\r\n" + 
					"`receipts`.`id`=`sales`.`receipt_id`\r\n" + 
					"LEFT JOIN `sales_invoices` ON\r\n" + 
					"`sales_invoices`.`id` =`sales`.`sales_invoice_id`\r\n" + 
					"LEFT JOIN `tills` ON\r\n" + 
					"`tills`.`id`=`receipts`.`till_id`\r\n" + 
					"WHERE\r\n" +
					"`days`.`bussiness_date` BETWEEN :fromDate AND :toDate AND `sale_details`.`code` IN (:codes)\r\n" + 
					"GROUP BY `date`,`code`,`description`,`receiptNo`,`cashier`,`tillNo`\r\n" + 
					"ORDER BY\r\n" + 
					"`date` ASC",
					nativeQuery = true					
			)
	List<ProductListingReport> getProductListingReportBySelectedProducts(LocalDate fromDate, LocalDate toDate,@Param("codes") ArrayList<String> codes);
	
}
