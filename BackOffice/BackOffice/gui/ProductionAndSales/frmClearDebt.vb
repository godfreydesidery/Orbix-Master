Imports Devart.Data.MySql

Public Class frmClearDebt
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub
    Dim productionId As String
    Private Sub frmEditUsedMaterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtIssueNo.Text = ""

        txtIssueNo.Text = PackingList.GLOBAL_ISSUE_NO
        txtSMOficer.Text = PackingList.GLOBAL_SM_OFFICER
        txtDebt.Text = LCurrency.displayValue(PackingList.GLOBAL_DEBT.ToString)
    End Sub

    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        txtDebt.Text = LCurrency.displayValue((New PackingList).getDebt(txtIssueNo.Text).ToString)
        If Val(txtAmount.Text) > 0 Then
            If Val(LCurrency.getValue(txtDebt.Text)) - Val(txtAmount.Text) < 0 Then
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
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "UPDATE `packing_list` SET `debt`=`debt`-" + txtAmount.Text + ",`total_bank_cash`=`total_bank_cash`+" + txtAmount.Text + " WHERE `issue_no`='" + txtIssueNo.Text + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            Dim debt As New Debt
            debt.registerPayment(Day.DAY, txtIssueNo.Text, Val(LCurrency.getValue(txtDebt.Text)), Val(txtAmount.Text), Val(LCurrency.getValue(txtDebt.Text)) - Val(txtAmount.Text), (New PackingList).getSalesPersonIdByIssueNo(txtIssueNo.Text), User.CURRENT_USER_ID, txtRemarks.Text)
            MsgBox("Success")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Dispose()
    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
        If Val(txtAmount.Text) < 0 Then
            txtAmount.Text = ""
        End If
        If txtAmount.Text.Contains("-") Then
            txtAmount.Text = ""
        End If
        If txtAmount.Text.Contains(",") Then
            txtAmount.Text = ""
        End If
        If Not IsNumeric(txtAmount.Text) Then
            txtAmount.Text = ""
        End If
    End Sub
End Class