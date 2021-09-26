package com.orbix.api.reports;

public interface SupplyStockStatus {
	String getCode();
	String getDescription();
	String getStock();
	double getDiscountRatio();
	double getCostPriceVatIncl();
	double getSellingPriceVatIncl();	
    double getStockCost();
    double getStockValue();
}
