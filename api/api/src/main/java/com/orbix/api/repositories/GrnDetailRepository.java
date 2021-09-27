/**
 * 
 */
package com.orbix.api.repositories;

import java.util.List;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Grn;
import com.orbix.api.models.GrnDetail;

/**
 * @author GODFREY
 *
 */
@Repository
public interface GrnDetailRepository extends JpaRepository<GrnDetail, Long>{

	/**
	 * @param itemCode
	 * @param orderNo
	 * @return
	 */
	//@Query("SELECT d FROM GrnDetail d where d.itemCode = itemCode and d.orderNo = orderNo")
	//Optional<GrnDetail> findByItemCodeAndOrderNo_(@Param("itemCode") String itemCode, @Param("orderNo") String orderNo);
	//Optional<GrnDetail> findByItemCodeAndOrderNo(String itemCode, String orderNo);
	
	
	List<GrnDetail> findByGrn(Grn grn);
	

}
