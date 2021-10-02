/**
 * 
 */
package com.orbix.api.reports;

import java.time.LocalDate;

/**
 * @author GODFREY
 *
 */
public interface DebtPaymentHistory {
	LocalDate getPaymentDate();
	LocalDate getDeficitDate();
	String getReference();	
    double getInitialAmount();
    double getAmountPaid();
    double getBalance();
}
