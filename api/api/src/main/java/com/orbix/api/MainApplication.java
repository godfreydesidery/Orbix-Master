package com.orbix.api;

import java.sql.Timestamp;
import java.time.LocalDate;
import java.util.TimeZone;

import javax.annotation.PostConstruct;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ConfigurableApplicationContext;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.data.jpa.repository.config.EnableJpaAuditing;

import com.orbix.api.models.Day;
import com.orbix.api.models.Priveledge;
import com.orbix.api.models.Role;
import com.orbix.api.models.User;
import com.orbix.api.repositories.DayRepository;
import com.orbix.api.repositories.PriveledgeRepository;
import com.orbix.api.repositories.RoleRepository;
import com.orbix.api.repositories.UserRepository;

@SpringBootApplication()
@ComponentScan(basePackages={"com.orbix.api"})
@EnableJpaAuditing
@EnableAutoConfiguration
public class MainApplication {
protected ConfigurableApplicationContext springContext;
	@Autowired
	UserRepository userRepository;
	@Autowired
	RoleRepository roleRepository;
	@Autowired
	PriveledgeRepository priveledgeRepository;
	@Autowired
    DayRepository dayRepository;
	
	@PostConstruct
	void started() {
		TimeZone.setDefault(TimeZone.getTimeZone("UTC"));
		Role role = new Role();
		User user = new User();
		Priveledge priveledge = new Priveledge();
		try {
			System.out.println("Creating initial user");
			role.setName("ADMIN");
			role.setStatus("ACTIVE");
			roleRepository.saveAndFlush(role);
			priveledge.setName("ADMIN");
			priveledge.setRole(role);
			priveledgeRepository.saveAndFlush(priveledge);
			user.setUsername("admin");
			user.setPassword("password");
			user.setFirstName("Default");
			user.setLastName("Default");
			user.setRollNo("0000");
			user.setRole(role);
			userRepository.saveAndFlush(user);
			System.out.println("Initial user created");
			System.out.println("With the following attributes");
			System.out.println("Username : admin");
			System.out.println("Password : password");
			System.out.println("First Name : Default");
			System.out.println("Last Name : Default");
			System.out.println("Priveledge : ADMIN");
			System.out.println("Role : ADMIN");
			System.out.println("Roll No : 0000");
			System.out.println("Status : ACTIVE");
		}catch(Exception e) {
			System.out.println("Could not create initial user");
		}
		
		if(dayRepository.hasData() == false) {
			System.out.println("Creating initial Bussiness day");
			
			LocalDate date = LocalDate.now();
	        Timestamp timestamp = new Timestamp(System.currentTimeMillis());
	        user = userRepository.findByUsername("admin").get();
	        userRepository.saveAndFlush(user);
			
	        Day day = new Day();
	        day.setBussinessDate(date);
	        day.setStartedAt(timestamp);
	        day.setStartedBy(user);
	        day.setStatus("STARTED");
	        dayRepository.saveAndFlush(day);		
	        
			System.out.println("Initial bussiness day attributes set to the following");
			System.out.println("Bussiness date: "+ date);
			System.out.println("Started at: "+ timestamp);
			System.out.println("Started by: admin");
			System.out.println("Status: STARTED");			
		}		
	}
	
	public static void main(String[] args) throws Throwable {
		SpringApplication.run(MainApplication.class, args);
		
	}
}
