/**
 * 
 */
package com.orbix.api.repositories;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.PackingList;
import com.orbix.api.models.PackingListDetail;

/**
 * @author GODFREY
 *
 */
@Repository
public interface PackingListDetailRepository extends JpaRepository<PackingListDetail, Long> {

	/**
	 * @param packingList
	 * @return
	 */
	List<PackingListDetail> findByPackingList(PackingList packingList);

	/**
	 * @param packingList
	 * @param code
	 * @return
	 */
	Optional<PackingListDetail> findByPackingListAndCode(PackingList packingList, String code);

}
