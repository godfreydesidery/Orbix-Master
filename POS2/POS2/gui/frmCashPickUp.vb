Imports Devart.Data.MySql

Public Class frmCashPickUp

    Dim currentAmount As Double = 0
    Dim pickUpAmount As Double = 0
    Dim newCashAmount As Double = 0
    Dim currentFloat As Double = 0

    Private Sub frmCashPickUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT `till_no`, `cash`, `voucher`, `deposit`, `loyalty`, `cr_card`, `cap`, `invoice`, `cr_note`, `mobile` FROM `till_total` WHERE `till_no`='" + Till.TILLNO + "'"
        Dim command As New MySqlCommand()
        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                currentAmount = reader.GetString("cash")
            End While
            txtAvailable.Text = LCurrency.displayValue(currentAmount.ToString)
            txtPickUp.Text = ""
            txtRemaining.Text = ""
        Catch ex As Devart.Data.MySql.MySqlException
            LError.databaseConnection()
            Exit Sub
        End Try


        Dim query2 As String = "SELECT  `amount` FROM `float_balance` WHERE `till_no`='" + Till.TILLNO + "'"
        Dim command2 As New MySqlCommand()
        Dim conn2 As New MySqlConnection(Database.conString)
        Try
            conn2.Open()
            command2.CommandText = query2
            command2.Connection = conn2
            command2.CommandType = CommandType.Text
            Dim reader2 As MySqlDataReader = command2.ExecuteReader()
            While reader2.Read
                currentFloat = reader2.GetString("amount")
                Exit While
            End While
        Catch ex As Devart.Data.MySql.MySqlException
            LError.databaseConnection()
            Exit Sub
        End Try

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtPickUp.Text = ""
    End Sub

    Private Sub txtPickUp_TextChanged(sender As Object, e As EventArgs) Handles txtPickUp.TextChanged
        Dim amount As String = txtPickUp.Text
        If IsNumeric(amount) And Val(amount) >= 0 Then 'And Val(amount) <= currentAmount Then
            newCashAmount = currentAmount - Val(amount)
            txtRemaining.Text = LCurrency.displayValue(newCashAmount.ToString)
        Else
            txtPickUp.Text = ""
            txtRemaining.Text = ""
        End If
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If Val(txtPickUp.Text) <= 0 Then
            MsgBox("Invalid amount", vbExclamation + vbOKOnly, "Error")
            txtPickUp.Text = ""
        Else
            Dim res As Integer = MessageBox.Show("Pick Up amount: " + LCurrency.displayValue(txtPickUp.Text) + " New amount: " + LCurrency.displayValue(txtRemaining.Text) + " Confirm?", "Confirm Cash Pick Up", MessageBoxButtons.YesNo)
            Dim pickUpamount As Double = Val(txtPickUp.Text)
            If res = DialogResult.Yes Then
                currentAmount = Val(LCurrency.getValue(txtRemaining.Text))
                txtAvailable.Text = LCurrency.displayValue(currentAmount.ToString)
                txtPickUp.Text = ""
                Dim conn As New MySqlConnection(Database.conString)
                Try
                    conn.Open()
                    Dim command As New MySqlCommand()
                    command.Connection = conn
                    command.CommandText = "UPDATE `till_total` SET `cash`='" + currentAmount.ToString + "' WHERE `till_no`='" + Till.TILLNO + "'"
                    command.Prepare()
                    command.ExecuteNonQuery()
                    conn.Close()
                Catch ex As Devart.Data.MySql.MySqlException
                    LError.databaseConnection()
                    Exit Sub
                End Try
                Dim collection As New Collection
                collection.collect(Till.TILLNO, Day.systemDate, pickUpamount, 0, 0, 0, 0, 0, 0, 0, 0, 0) 'add to collections
            End If
        End If
    End Sub

    Private Sub txtRemaining_TextChanged(sender As Object, e As EventArgs) Handles txtRemaining.TextChanged
        If txtRemaining.Text = "" Then
            btnOK.Enabled = False
        Else
            btnOK.Enabled = True
        End If
    End Sub
End Class