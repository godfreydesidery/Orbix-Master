package com.orbix.api.repositories;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.User;

/**
 * @author GODFREY
 *
 */
@Repository
public interface UserRepository extends JpaRepository<User, Long> {

	Optional<User> findByIdAndActive(Long user_id, int i);

	Optional<User> findByUsernameAndActive(String username, int i);

	Optional<User> findByUsername(String username);
	
}
