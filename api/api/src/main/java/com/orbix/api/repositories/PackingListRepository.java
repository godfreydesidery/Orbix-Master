/**
 * 
 */
package com.orbix.api.repositories;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Lpo;
import com.orbix.api.models.PackingList;
import com.orbix.api.models.User;

/**
 * @author GODFREY
 *
 */
@Repository
public interface PackingListRepository extends JpaRepository<PackingList, Long> {

	/**
	 * @param statuses
	 * @return
	 */
	@Query("SELECT p FROM PackingList p WHERE p.status IN (:statuses)")
	List<PackingList> findAllByStatus(List<String> statuses);

	/**
	 * @param no
	 * @return
	 */
	Optional<PackingList> findByNo(String no);

	

}