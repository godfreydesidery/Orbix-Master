package com.orbix.api.repositories;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Product;
import com.orbix.api.models.Supplier;

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

}
