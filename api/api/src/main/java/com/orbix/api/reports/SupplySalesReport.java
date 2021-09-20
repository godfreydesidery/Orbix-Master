package com.orbix.api.reports;

public interface SupplySalesReport {
	String getCode();
	String getDescription();
	String getStock();
	String getQty();
	double getAmount();
	double getDiscount();	
    double getTax();
    double getProfit();
}
