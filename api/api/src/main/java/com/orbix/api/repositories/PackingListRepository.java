/**
 * 
 */
package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.PackingList;

/**
 * @author GODFREY
 *
 */
@Repository
public interface PackingListRepository extends JpaRepository<PackingList, Long> {

}