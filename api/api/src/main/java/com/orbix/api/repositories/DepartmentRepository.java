package com.orbix.api.repositories;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Department;

/**
 * @author GODFREY
 *
 */
@Repository
public interface DepartmentRepository extends JpaRepository<Department, Long> {

	Optional<Department> findByName(String departmentName);

	Optional<Department> findByCode(String departmentCode);

	@Query("select d.name from Department d")
	Iterable<Department> getNames();

}
