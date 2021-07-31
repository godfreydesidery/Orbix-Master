/**
 * 
 */
package com.orbix.api.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.ReceiptDetail;

/**
 * @author GODFREY
 *
 */
@Repository
public interface ReceiptDetailRepository extends JpaRepository<ReceiptDetail, Long> {

}
