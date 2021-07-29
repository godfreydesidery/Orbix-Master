package com.orbix.api.repositories;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Clas;
import com.orbix.api.models.SubClass;

@Repository
public interface SubClassRepository extends JpaRepository<SubClass, Long> {

	Optional<SubClass> findByName(String subClassName);

	List<SubClass> findByClas(Clas clas);

}
