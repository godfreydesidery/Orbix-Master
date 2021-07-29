package com.orbix.api;

import java.util.TimeZone;

import javax.annotation.PostConstruct;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ConfigurableApplicationContext;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.data.jpa.repository.config.EnableJpaAuditing;

import com.orbix.api.models.Priveledge;
import com.orbix.api.models.Role;
import com.orbix.api.models.User;
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
	
	@PostConstruct
	void started() {
		TimeZone.setDefault(TimeZone.getTimeZone("UTC"));
		Role role = new Role();
			User user = new User();
			Priveledge priveledge = new Priveledge();
		try {			
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
		}catch(Exception e) {
			System.out.println("Could not create initial user");
		}				
	}
	
	public static void main(String[] args) throws Throwable {
		SpringApplication.run(MainApplication.class, args);
		
	}
}
