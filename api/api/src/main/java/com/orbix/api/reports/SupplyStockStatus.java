package com.orbix.api.reports;

public interface SupplyStockStatus {
	String getCode();
	String getDescription();
	String getStock();
	double getDiscount();
	double getCostPriceVatIncl();
	double getSellingPriceVatIncl();	
    double getStockCost();
    double getStockValue();
}
