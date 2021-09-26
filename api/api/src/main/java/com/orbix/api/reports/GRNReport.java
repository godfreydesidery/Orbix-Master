package com.orbix.api.reports;

import java.time.LocalDate;

public interface GRNReport {
	LocalDate getDate();
	String getCode();
	String getDescription();
	double getQty();
	double getPrice();
    double getAmount();	
    String getGrnNo();
    String getLpoNo();
    String getInvoiceNo();
    String getSupplier();
}
