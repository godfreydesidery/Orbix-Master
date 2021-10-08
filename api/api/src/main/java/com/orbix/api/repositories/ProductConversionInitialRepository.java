/**
 * 
 */
package com.orbix.api.repositories;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Product;
import com.orbix.api.models.ProductConversion;
import com.orbix.api.models.ProductConversionInitial;

/**
 * @author GODFREY
 *
 */
@Repository
public interface ProductConversionInitialRepository extends JpaRepository<ProductConversionInitial, Long> {

	/**
	 * @param product
	 * @param productConversion
	 * @return
	 */
	Optional<ProductConversionInitial> findByProductAndProductConversion(Product product,
			ProductConversion productConversion);

	/**
	 * @param productConversion
	 * @return
	 */
	List<ProductConversionInitial> findAllByProductConversion(ProductConversion productConversion);


}
