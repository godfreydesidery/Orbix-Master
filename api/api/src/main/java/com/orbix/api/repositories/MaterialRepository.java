/**
 * 
 */
package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Material;

/**
 * @author GODFREY
 *
 */
@Repository
public interface MaterialRepository extends JpaRepository<Material, Long> {

}
