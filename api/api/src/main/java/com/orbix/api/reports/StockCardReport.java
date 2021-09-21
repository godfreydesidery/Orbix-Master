package com.orbix.api.reports;

import java.time.LocalDate;

public interface StockCardReport {
	LocalDate getDate();
	String getCode();
	String getDescription();	
    double getQtyIn();
    double getQtyOut();
    double getBalance();
    String getReference();
}
