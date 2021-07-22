Imports Devart.Data.MySql

Public Class frmFloat

    Dim currentFloat As Double = 0
    Dim addFloat As Double = 0
    Dim newFloat As Double = 0

    Private Sub frmFloat_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim query As String = ""

        Dim command As New MySqlCommand()
        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            command.Connection = conn
            command.CommandType = CommandType.Text
            query = "INSERT IGNORE INTO `float_balance`( `till_no`) VALUES ('" + Till.TILLNO + "')"
            command.CommandText = query
            command.ExecuteNonQuery()
            query = "SELECT  `amount` FROM `float_balance` WHERE `till_no`='" + Till.TILLNO + "'"
            command.CommandText = query

            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                currentFloat = reader.GetString("amount")
                Exit While
            End While
            conn.Close()
            txtCurrentFloat.Text = LCurrency.displayValue(currentFloat.ToString)
        Catch ex As Devart.Data.MySql.MySqlException
            LError.databaseConnection()
            Exit Sub
        End Try

    End Sub

    Private Sub txtAddFloat_GotFocus(sender As Object, e As EventArgs) Handles txtAddFloat.GotFocus
        txtDeductFloat.Text = ""
    End Sub

    Private Sub txtAddFloat_TextChanged(sender As Object, e As EventArgs) Handles txtAddFloat.TextChanged
        Dim amount As String = txtAddFloat.Text
        If IsNumeric(amount) And Val(amount) >= 0 Then
            newFloat = currentFloat + Val(amount)
            txtNewFloat.Text = LCurrency.displayValue(newFloat.ToString)
        Else
            txtAddFloat.Text = ""
            txtNewFloat.Text = ""
        End If
    End Sub

    Private Sub txtNewFloat_TextChanged(sender As Object, e As EventArgs) Handles txtNewFloat.TextChanged
        If txtNewFloat.Text = "" Then
            btnOK.Enabled = False
        Else
            btnOK.Enabled = True
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim res As Integer = 0
        Dim op As String = ""
        If Val(txtAddFloat.Text) > 0 Then
            txtDeductFloat.Text = ""
            res = MessageBox.Show("Increase amount: " + LCurrency.displayValue(txtAddFloat.Text) + " New amount: " + LCurrency.displayValue(txtNewFloat.Text) + " Confirm?", "Confirm float increase", MessageBoxButtons.YesNo)
        ElseIf Val(txtDeductFloat.Text) > 0 Then
            txtAddFloat.Text = ""
            res = MessageBox.Show("Deduct amount: " + LCurrency.displayValue(txtDeductFloat.Text) + " New amount: " + LCurrency.displayValue(txtNewFloat.Text) + " Confirm?", "Confirm float deduction", MessageBoxButtons.YesNo)
        End If
        If res = DialogResult.Yes Then
            currentFloat = Val(LCurrency.getValue(txtNewFloat.Text))
            txtCurrentFloat.Text = LCurrency.displayValue(currentFloat.ToString)

            Dim conn As New MySqlConnection(Database.conString)
            Try
                conn.Open()
                Dim command As New MySqlCommand()
                command.Connection = conn
                command.CommandText = "UPDATE `float_balance` SET `amount`='" + currentFloat.ToString + "' WHERE `till_no`='" + Till.TILLNO + "'"
                command.Prepare()
                command.ExecuteNonQuery()
                conn.Close()
            Catch ex As Devart.Data.MySql.MySqlException
                LError.databaseConnection()
                Exit Sub
            End Try

            txtAddFloat.Text = ""
            txtDeductFloat.Text = ""
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtAddFloat.Text = ""
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub txtCurrentFloat_TextChanged(sender As Object, e As EventArgs) Handles txtCurrentFloat.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub txtDeductFloat_GotFocus(sender As Object, e As EventArgs) Handles txtDeductFloat.GotFocus
        txtAddFloat.Text = ""
    End Sub

    Private Sub txtDeductFloat_TextChanged(sender As Object, e As EventArgs) Handles txtDeductFloat.TextChanged
        Dim amount As String = txtDeductFloat.Text
        If IsNumeric(amount) And Val(amount) >= 0 And Val(amount) <= Val(currentFloat) Then
            newFloat = currentFloat - Val(amount)
            txtNewFloat.Text = LCurrency.displayValue(newFloat.ToString)
        Else
            txtDeductFloat.Text = ""
            txtNewFloat.Text = ""
        End If
    End Sub
End Class