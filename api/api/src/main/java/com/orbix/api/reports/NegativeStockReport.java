package com.orbix.api.reports;

public interface NegativeStockReport {
	String getBarcode();
	String getCode();
	String getDescription();
	double getStock();
}
