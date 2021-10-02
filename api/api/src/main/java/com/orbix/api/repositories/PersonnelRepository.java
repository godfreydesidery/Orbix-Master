/**
 * 
 */
package com.orbix.api.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Lpo;
import com.orbix.api.models.Personnel;

/**
 * @author GODFREY
 *
 */
@Repository
public interface PersonnelRepository extends JpaRepository<Personnel, Long> {

	/**
	 * @param rollNo
	 * @return
	 */
	Personnel findByRollNo(String rollNo);

	/**
	 * @param name
	 * @return
	 */
	Personnel findByName(String name);
	
}
