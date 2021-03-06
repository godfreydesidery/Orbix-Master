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
import com.orbix.api.reports.FastMovingItems;
import com.orbix.api.reports.ProductListingReport;
import com.orbix.api.reports.SlowMovingItems;
import com.orbix.api.reports.SupplySalesReport;

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
	
	@Query(
			value = "SELECT\r\n" + 
					"`days`.`bussiness_date` AS `date`,\r\n" + 
					"`sale_details`.`code` AS `code`,\r\n" + 
					"`sale_details`.`description` AS `description`,\r\n" + 
					"SUM(`sale_details`.`qty`*(`sale_details`.`selling_price_vat_incl`-`sale_details`.`discount`)) AS `amount`,\r\n" + 
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
					"SUM(`sale_details`.`qty`*(`sale_details`.`selling_price_vat_incl`-`sale_details`.`discount`)) AS `amount`,\r\n" + 
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
	
	
	@Query(
			value = "SELECT \r\n" + 
					"`sale_details`.`code` AS `code`,\r\n" + 
					"`products`.`description` AS `description`,\r\n" + 
					"`products`.`stock` AS `stock`,\r\n" + 
					"SUM(`sale_details`.`qty`) AS `qty`,\r\n" + 
					"SUM(`sale_details`.`qty`*(`sale_details`.`selling_price_vat_incl`-`sale_details`.`discount`)) AS `amount`,\r\n" + 
					"SUM(`sale_details`.`qty`*`sale_details`.`discount`) AS `discount`,\r\n" + 
					"SUM(`sale_details`.`qty`*`sale_details`.`tax`) AS `tax`,\r\n" + 
					"SUM(`sale_details`.`qty`*(`sale_details`.`selling_price_vat_incl`-`sale_details`.`cost_price_vat_incl`-`sale_details`.`discount`)) AS `profit`\r\n" + 
					"FROM\r\n" + 
					"`sales`\r\n" + 
					"JOIN `days` ON\r\n" + 
					"`days`.`id`=`sales`.`day_id`\r\n" + 
					"JOIN `sale_details` ON\r\n" + 
					"`sale_details`.`sale_id`=`sales`.`id`\r\n" + 
					"JOIN `products` ON\r\n" + 
					"`sale_details`.`code`=`products`.`code`\r\n" + 
					"JOIN `suppliers` ON\r\n" + 
					"`suppliers`.`id`=`products`.`supplier_id`\r\n" + 
					"WHERE\r\n" + 
					"`days`.`bussiness_date` BETWEEN :fromDate AND :toDate AND `suppliers`.`name`=:supplierName\r\n" + 
					"GROUP BY `code`",
					nativeQuery = true					
			)
	List<SupplySalesReport> getSupplySalesReport(LocalDate fromDate, LocalDate toDate, String supplierName);
	
	@Query(
			value = "SELECT \r\n" + 
					"`sale_details`.`code` AS `code`,\r\n" + 
					"`products`.`description` AS `description`,\r\n" + 
					"`products`.`stock` AS `stock`,\r\n" + 
					"SUM(`sale_details`.`qty`) AS `qty`,\r\n" + 
					"SUM((`sale_details`.`qty`*(`sale_details`.`selling_price_vat_incl`-`sale_details`.`discount`)) AS `amount`,\r\n" + 
					"SUM(`sale_details`.`qty`*`sale_details`.`discount`) AS `discount`,\r\n" + 
					"SUM(`sale_details`.`qty`*`sale_details`.`tax`) AS `tax`,\r\n" + 
					"SUM(`sale_details`.`qty`*(`sale_details`.`selling_price_vat_incl`-`sale_details`.`cost_price_vat_incl`-`sale_details`.`discount`)) AS `profit`\r\n" + 
					"FROM\r\n" + 
					"`sales`\r\n" + 
					"JOIN `days` ON\r\n" + 
					"`days`.`id`=`sales`.`day_id`\r\n" + 
					"JOIN `sale_details` ON\r\n" + 
					"`sale_details`.`sale_id`=`sales`.`id`\r\n" + 
					"JOIN `products` ON\r\n" + 
					"`sale_details`.`code`=`products`.`code`\r\n" + 
					"JOIN `suppliers` ON\r\n" + 
					"`suppliers`.`id`=`products`.`supplier_id`\r\n" + 
					"WHERE\r\n" + 
					"`days`.`bussiness_date` BETWEEN :fromDate AND :toDate AND `suppliers`.`name`=:supplierName AND `sale_details`.`code` IN (:codes)\r\n" + 
					"GROUP BY `code`",
					nativeQuery = true					
			)
	List<SupplySalesReport> getSupplySalesReportByProduct(LocalDate fromDate, LocalDate toDate, String supplierName, @Param("codes") ArrayList<String> codes);

	
	@Query(
			value = "SELECT\r\n" + 
					"`sale_details`.`code` AS `code`,\r\n" + 
					"SUM(`sale_details`.`qty`) AS `qty`,\r\n" + 
					"SUM(`sale_details`.`qty`*(`sale_details`.`selling_price_vat_incl`-`sale_details`.`discount`)) AS `amount`,\r\n" + 
					"`products`.`description` AS `description`,\r\n" + 
					"`products`.`stock` as `stock`\r\n" + 
					"FROM\r\n" + 
					"`sales`\r\n" + 
					"JOIN `days` ON\r\n" + 
					"`days`.`id`=`sales`.`day_id`\r\n" + 
					"JOIN `sale_details` ON\r\n" + 
					"`sale_details`.`sale_id`=`sales`.`id`\r\n" + 
					"JOIN `products` ON\r\n" + 
					"`sale_details`.`code`=`products`.`code`\r\n" + 
					"WHERE\r\n" + 
					"`days`.`bussiness_date` BETWEEN :fromDate AND :toDate\r\n" + 
					"GROUP BY `code`\r\n" + 
					"ORDER BY `qty` DESC",
					nativeQuery = true					
			)
	List<FastMovingItems> getFastMovingItems(LocalDate fromDate, LocalDate toDate);
	
	@Query(
			value = "SELECT\r\n" + 
					"`sale_details`.`code` AS `code`,\r\n" + 
					"SUM(`sale_details`.`qty`) AS `qty`,\r\n" + 
					"SUM(`sale_details`.`qty`*(`sale_details`.`selling_price_vat_incl`-`sale_details`.`discount`)) AS `amount`,\r\n" + 
					"`products`.`description` AS `description`,\r\n" + 
					"`products`.`stock` as `stock`\r\n" + 
					"FROM\r\n" + 
					"`sales`\r\n" + 
					"JOIN `days` ON\r\n" + 
					"`days`.`id`=`sales`.`day_id`\r\n" + 
					"JOIN `sale_details` ON\r\n" + 
					"`sale_details`.`sale_id`=`sales`.`id`\r\n" + 
					"JOIN `products` ON\r\n" + 
					"`sale_details`.`code`=`products`.`code`\r\n" + 
					"WHERE\r\n" + 
					"`days`.`bussiness_date` BETWEEN :fromDate AND :toDate\r\n" + 
					"GROUP BY `code`\r\n" + 
					"ORDER BY `qty` ASC",
					nativeQuery = true					
			)
	List<SlowMovingItems> getSlowMovingItems(LocalDate fromDate, LocalDate toDate);

}
