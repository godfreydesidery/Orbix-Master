package com.orbix.api.repositories;

import java.time.LocalDate;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.orbix.api.models.Day;

@Repository
public interface DayRepository extends JpaRepository<Day, Long> {

	Optional <Day> findByBussinessDate(LocalDate bussinessDate);

}
