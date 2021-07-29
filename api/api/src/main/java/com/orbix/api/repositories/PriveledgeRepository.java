package com.orbix.api.repositories;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Priveledge;
import com.orbix.api.models.Role;

/**
 * @author GODFREY
 *
 */
@Repository
public interface PriveledgeRepository extends JpaRepository<Priveledge, Long> {

	boolean existsByRoleAndName(Role role, String priveledge);

	List<Priveledge> findByRole(Role role);

	Optional<Priveledge> findByRoleAndName(Role role, String name);

}
