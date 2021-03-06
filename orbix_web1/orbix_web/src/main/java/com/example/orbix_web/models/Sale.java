/**
 * 
 */
package com.example.orbix_web.models;

import java.time.LocalDate;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EntityListeners;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToOne;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotBlank;

import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;
import org.hibernate.envers.Audited;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;
import org.springframework.stereotype.Component;

import com.example.orbix_web.database.Audit;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

/**
 * @author GODFREY
 *
 */
@Entity
@Component
@Table(name = "sales")
@EntityListeners(AuditingEntityListener.class)
public class Sale extends Audit<String>{
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
	private LocalDate saleDate;
	
	@OneToOne(fetch = FetchType.LAZY, optional = true)
    @JoinColumn(name = "sales_invoice_id", nullable = true)
    @OnDelete(action = OnDeleteAction.CASCADE)
	//@JsonIgnoreProperties("salesInvoiceDetail")
    private SalesInvoice salesInvoice;
	
	@OneToOne(fetch = FetchType.LAZY, optional = true)
    @JoinColumn(name = "receipt_id", nullable = true)
    @OnDelete(action = OnDeleteAction.CASCADE)
	//@JsonIgnoreProperties("receiptDetail")
    private Receipt receipt;
}