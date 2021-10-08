/**
 * 
 */
package com.orbix.api.repositories;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Product;
import com.orbix.api.models.ProductConversion;
import com.orbix.api.models.ProductConversionFinal;

/**
 * @author GODFREY
 *
 */
@Repository
public interface ProductConversionFinalRepository extends JpaRepository<ProductConversionFinal, Long> {

	/**
	 * @param product
	 * @param productConversion
	 * @return
	 */
	Optional<ProductConversionFinal> findByProductAndProductConversion(Product product,
			ProductConversion productConversion);

	/**
	 * @param productConversion
	 * @return
	 */
	List<ProductConversionFinal> findAllByProductConversion(ProductConversion productConversion);

}
