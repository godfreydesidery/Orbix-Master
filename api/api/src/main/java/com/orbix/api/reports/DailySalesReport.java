package com.orbix.api.reports;

import java.time.LocalDate;

public interface DailySalesReport {
	LocalDate getDate();
    double getAmount();	
    double getDiscount();	
}
