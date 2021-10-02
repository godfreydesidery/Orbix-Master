Imports Devart.Data.MySql

Public Class frmClearDebt
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub frmEditUsedMaterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtIssueNo.Text = ""
        txtIssueNo.Text = PackingList.GLOBAL_ISSUE_NO
        txtSMOficer.Text = PackingList.GLOBAL_SM_OFFICER
        txtDebt.Text = LCurrency.displayValue(PackingList.GLOBAL_DEBT.ToString)
    End Sub

    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click

        txtDebt.Text = PackingList.GLOBAL_DEBT

        If Val(txtBankDeposit.Text) > 0 Or Val(txtCashPayment.Text) > 0 Then
            If Val(LCurrency.getValue(txtDebt.Text)) - Val(txtBankDeposit.Text) < 0 Then
                MsgBox("Invalid amount", vbOKOnly + vbCritical, "Error: Invalid entry")
                Exit Sub
            End If
            If Val(txtBankDeposit.Text) < 0 Then
                MsgBox("Invalid amount", vbOKOnly + vbCritical, "Error: Invalid entry")
                Exit Sub
            End If
            If Val(txtCashPayment.Text) < 0 Then
                MsgBox("Invalid amount", vbOKOnly + vbCritical, "Error: Invalid entry")
                Exit Sub
            End If
        Else
            MsgBox("Invalid amount", vbOKOnly + vbCritical, "Error: Invalid entry")
            Exit Sub
        End If
        Dim res As Integer = MsgBox("Receive funds? This amount will be deducted from outstanding debt", vbYesNo + vbQuestion, "Pay debt")
        If Not res = DialogResult.Yes Then
            Exit Sub
        End If

        Dim payment As New DebtPayment
        payment.debt.packingList.no = PackingList.GLOBAL_ISSUE_NO
        payment.initialAmount = PackingList.GLOBAL_DEBT
        payment.bankDeposit = Val(LCurrency.getValue(txtBankDeposit.Text))
        payment.cashPayment = Val(LCurrency.getValue(txtCashPayment.Text))
        payment.totalPaid = Val(LCurrency.getValue(txtBankDeposit.Text)) + Val(LCurrency.getValue(txtCashPayment.Text))
        payment.amountRemaining = payment.initialAmount - payment.totalPaid

        Try
            Dim response As Object = New Object

            response = Web.put(payment, "packing_lists/pay_debt_by_no?no=" + txtIssueNo.Text)

            ' Dim packingLists As List(Of PackingList) = JsonConvert.DeserializeObject(Of List(Of PackingList))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Dispose()
    End Sub

    Private Sub txtBankDeposit_TextChanged(sender As Object, e As EventArgs) Handles txtBankDeposit.TextChanged
        If Val(txtBankDeposit.Text) < 0 Then
            txtBankDeposit.Text = ""
        End If
        If txtBankDeposit.Text.Contains("-") Then
            txtBankDeposit.Text = ""
        End If
        If txtBankDeposit.Text.Contains(",") Then
            txtBankDeposit.Text = ""
        End If
        If Not IsNumeric(txtBankDeposit.Text) Then
            txtBankDeposit.Text = ""
        End If
        txtAmountRemaining.Text = LCurrency.displayValue(Val(LCurrency.getValue(txtDebt.Text)) - (Val(LCurrency.getValue(txtBankDeposit.Text)) + Val(LCurrency.getValue(txtCashPayment.Text))))
    End Sub

    Private Sub txtCashPayment_TextChanged(sender As Object, e As EventArgs) Handles txtCashPayment.TextChanged
        If Val(txtCashPayment.Text) < 0 Then
            txtCashPayment.Text = ""
        End If
        If txtCashPayment.Text.Contains("-") Then
            txtCashPayment.Text = ""
        End If
        If txtCashPayment.Text.Contains(",") Then
            txtCashPayment.Text = ""
        End If
        If Not IsNumeric(txtCashPayment.Text) Then
            txtCashPayment.Text = ""
        End If
        txtAmountRemaining.Text = LCurrency.displayValue(Val(LCurrency.getValue(txtDebt.Text)) - (Val(LCurrency.getValue(txtBankDeposit.Text)) + Val(LCurrency.getValue(txtCashPayment.Text))))
    End Sub

    Private Sub txtAmountRemaining_TextChanged(sender As Object, e As EventArgs) Handles txtAmountRemaining.TextChanged
        If Val(txtAmountRemaining.Text) < 0 Then
            txtBankDeposit.Text = ""
            txtCashPayment.Text = ""
            txtAmountRemaining.Text = ""
        End If
    End Sub

End Class