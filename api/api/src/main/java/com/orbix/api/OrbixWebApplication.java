package com.orbix.api;

import java.util.Date;
import java.util.TimeZone;

import javax.annotation.PostConstruct;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.context.ConfigurableApplicationContext;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.data.jpa.repository.config.EnableJpaAuditing;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurerAdapter;

import javafx.application.Application;


@SpringBootApplication()
@ComponentScan(basePackages={"com.example.orbix_web"})
@EnableJpaAuditing
@EnableAutoConfiguration
//@EnableJpaRepositories(basePackageClasses = {CustomerRepository.class})
public class OrbixWebApplication {
	
	protected ConfigurableApplicationContext springContext;
	
	@PostConstruct
	void started() {
		TimeZone.setDefault(TimeZone.getTimeZone("UTC"));
	}
	
	public static void main(String[] args) throws Throwable {
		SpringApplication.run(OrbixWebApplication.class, args);
		
		//Application.launch(JavaFxApplication.class,args);
		
	}
	
	
	
	
}
