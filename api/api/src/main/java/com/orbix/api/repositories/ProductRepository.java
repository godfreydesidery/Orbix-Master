package com.orbix.api.repositories;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Product;
import com.orbix.api.models.Supplier;
import com.orbix.api.reports.NegativeStockReport;
import com.orbix.api.reports.SupplyStockStatus;

/**
 * @author GODFREY
 *
 */
@Repository
public interface ProductRepository extends JpaRepository<Product, Long> {

	Optional<Product> findByDescription(String description);

	Optional<Product> findByCode(String code);

	Optional<Product> findByPrimaryBarcode(String barcode);

	boolean existsByCodeAndPrimarySupplier(String productCode, Supplier supplier);

	@Query("select p.description from Product p")
	Iterable<Product> getDescription();
	
	
	
	@Query(
			value = "SELECT\r\n" + 
					"`products`.`code` AS `code`,\r\n" + 
					"`products`.`description` AS `description`,\r\n" + 
					"`products`.`stock` AS `stock`,\r\n" + 
					"`products`.`discount_ratio` AS `discountRatio`,\r\n" + 
					"`products`.`cost_price_vat_incl` AS `costPriceVatIncl`,\r\n" + 
					"`products`.`selling_price_vat_incl` AS `sellingPriceVatIncl`,\r\n" + 
					"(`products`.`stock`*`products`.`cost_price_vat_incl`) AS `stockCost`,\r\n" + 
					"(`products`.`selling_price_vat_incl`*`products`.`stock`*(1 - `products`.`discount_ratio`/100)) AS `stockValue`,\r\n" + 
					"`suppliers`.`name` AS `supplierName`\r\n" + 
					"FROM\r\n" + 
					"`products`\r\n" + 
					"JOIN `suppliers` ON\r\n" + 
					"`products`.`supplier_id`=`suppliers`.`id`\r\n" + 
					"WHERE\r\n" + 
					"`suppliers`.`name`=:supplierName",
					nativeQuery = true					
			)
	List<SupplyStockStatus> getSupplyStockStatus(String supplierName);
	
	@Query(
			value = "SELECT\r\n" + 
					"`products`.`primary_barcode` AS `barcode`,\r\n" + 
					"`products`.`code` AS `code`,\r\n" + 
					"`products`.`description` AS `description`,\r\n" + 
					"`products`.`stock` AS `stock`\r\n" + 
					"FROM\r\n" + 
					"`products`\r\n" + 
					"WHERE\r\n" + 
					"`products`.`stock` < 0\r\n" + 
					"ORDER BY `stock` DESC",
					nativeQuery = true					
			)
	List<NegativeStockReport> getNegativeStockReport();

}
