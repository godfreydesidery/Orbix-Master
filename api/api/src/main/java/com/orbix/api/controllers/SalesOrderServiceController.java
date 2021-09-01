package com.orbix.api.controllers;

import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RestController;

@RestController
@Service
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class SalesOrderServiceController {

}
