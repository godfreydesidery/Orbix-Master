package com.orbix.api.repositories;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Clas;
import com.orbix.api.models.Department;

@Repository
public interface ClassRepository extends JpaRepository<Clas, Long> {

	List<Clas> findByDepartment(Department department);

	@Query("select c.name from Clas c")
	Iterable<Clas> getNames();

	Optional<Clas> findByName(String name);

	Optional<Clas> findByCode(String clasCode);

}
