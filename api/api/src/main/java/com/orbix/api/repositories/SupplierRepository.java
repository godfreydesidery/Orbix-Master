package com.orbix.api.repositories;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Supplier;

/**
 * @author GODFREY
 *
 */
@Repository
public interface SupplierRepository extends JpaRepository<Supplier, Long> {

	Optional<Supplier> findByName(String name);

	@Query("select s.name from Supplier s")
	Iterable<Supplier> getNames();

	Optional<Supplier> findByCode(String supplierCode);

}
