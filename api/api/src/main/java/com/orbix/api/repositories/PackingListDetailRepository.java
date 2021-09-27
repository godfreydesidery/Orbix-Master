/**
 * 
 */
package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.PackingListDetail;

/**
 * @author GODFREY
 *
 */
@Repository
public interface PackingListDetailRepository extends JpaRepository<PackingListDetail, Long> {

}
