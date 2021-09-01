Imports Devart.Data.MySql
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmCashPickUp
    Dim currentAmount As Double = 0
    Dim pickUpAmount As Double = 0
    Dim newCashAmount As Double = 0
    Dim currentFloat As Double = 0

    Private Sub frmCashPickUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim response As Object = New Object
        Dim json As JObject = New JObject

        Try
            response = Web.get_("tills/get_till_position_by_no?no=" + Till.TILLNO)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        json = JObject.Parse(response)
        Dim till_ As Till = JsonConvert.DeserializeObject(Of Till)(json.ToString)
        currentAmount = till_.cash
        currentFloat = till_.floatBalance
        txtAvailable.Text = LCurrency.displayValue(currentAmount.ToString)
        txtPickUp.Text = ""
        txtRemaining.Text = ""

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