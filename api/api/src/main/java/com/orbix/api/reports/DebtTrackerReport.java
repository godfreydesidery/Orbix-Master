/**
 * 
 */
package com.orbix.api.reports;

import java.time.LocalDate;

/**
 * @author GODFREY
 *
 */
public interface DebtTrackerReport {
	LocalDate getDate();
    double getAmount();	
    String getReference();
    String getName();
}
