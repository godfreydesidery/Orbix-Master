package com.orbix.api.reports;

import java.time.LocalDate;

public interface PrintedLPO {
	String getLpoNo();
	String getSupplierName();
	LocalDate getDateCreated();
	LocalDate getValidUntil();
	String getSummary();
}
