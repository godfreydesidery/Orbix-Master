package com.orbix.api.reports;

import java.time.LocalDate;

public interface ProductListingReport {	
	LocalDate getDate();
	String getCode();
	String getDescription();
	String getCashier();
	String getReceiptNo();
	String getTillNo();	
    double getAmount();	
}
