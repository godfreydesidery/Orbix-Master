package com.orbix.api.reports;

import java.time.LocalDate;
import java.util.Date;

public interface PriceChangeReport {
	LocalDate getDate();
	Date getDateTime();
	String getCode();
	String getDescription();
	double getOldPrice();
	double getNewPrice();
	double getChange();
	String getUser();
	String getReason();
}
