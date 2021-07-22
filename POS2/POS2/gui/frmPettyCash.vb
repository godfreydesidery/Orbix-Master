Imports Devart.Data.MySql

Public Class frmPettyCash

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
        Dim amount As String = txtAmount.Text
        If IsNumeric(amount) And Val(amount) >= 0 Then
            btnOK.Enabled = True
        Else
            txtAmount.Text = ""
            btnOK.Enabled = False
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtAmount.Text = ""
        txtDetails.Text = ""
    End Sub

    Private Function getCurrentCash()
        Dim available As Double = 0

        Dim query As String = "SELECT  `cash` FROM `till_total` WHERE `till_no`='" + Till.TILLNO + "'"
        Dim command As New MySqlCommand()
        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            While reader.Read
                available = reader.GetString("cash")
                Exit While
            End While
        Catch ex As Devart.Data.MySql.MySqlException
            LError.databaseConnection()
            Return vbNull
            Exit Function
        End Try

        Return available
    End Function
    Private Function getCurrentFloat()
        Dim available As Double = 0

        Dim query As String = "SELECT  `amount` FROM `float_balance` WHERE `till_no`='" + Till.TILLNO + "'"
        Dim command As New MySqlCommand()
        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            While reader.Read
                available = reader.GetString("amount")
                Exit While
            End While
        Catch ex As Devart.Data.MySql.MySqlException
            LError.databaseConnection()
            Return vbNull
            Exit Function
        End Try

        Return available
    End Function
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim amount As String = txtAmount.Text
        Dim detail As String = txtDetails.Text

        If getCurrentCash() < Val(amount) Then
            MsgBox("Could not complete operation. Insufficient cash amount available.", vbExclamation + vbOKOnly, "Error: Insufficient Funds")
            Exit Sub
        End If
        Dim res As Integer = MessageBox.Show("Petty Cash amount: " + LCurrency.displayValue(txtAmount.Text) + " Confirm?", "Confirm Petty Cash", MessageBoxButtons.YesNo)
        If res = DialogResult.Yes Then
            'record petty cash

            Dim conn As New MySqlConnection(Database.conString)
            Try
                conn.Open()
                Dim command As New MySqlCommand()
                command.Connection = conn
                command.CommandText = "INSERT INTO `petty_cash`(`till_no`,`amount`,`date_time`, `details`) VALUES ('" + Till.TILLNO + "','" + amount + "','" + Day.systemDate + "','" + detail + "')"
                command.ExecuteNonQuery()
                txtAmount.Text = ""
                conn.Close()
            Catch ex As Devart.Data.MySql.MySqlException
                LError.databaseConnection()
                Exit Sub
            End Try

            Dim conn2 As New MySqlConnection(Database.conString)
            Try
                conn2.Open()
                Dim command2 As New MySqlCommand()
                command2.Connection = conn2
                command2.CommandText = "UPDATE `till_total` SET`cash`=`cash`-'" + amount.ToString + "' WHERE `till_no`='" + Till.TILLNO + "'"
                command2.ExecuteNonQuery()
                conn2.Close()
            Catch ex As Devart.Data.MySql.MySqlException
                LError.databaseConnection()
                Exit Sub
            End Try
            Dim collection As New Collection
            collection.collect(Till.TILLNO, Day.systemDate, amount, 0, 0, 0, 0, 0, 0, 0, 0, 0)
            Me.Dispose()
        End If

    End Sub

    Private Sub frmPettyCash_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class