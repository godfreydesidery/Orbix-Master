Imports Devart.Data.MySql

Public Class frmCorporateCustomers

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Private Function lock()
        txtCustomerNo.ReadOnly = True
        txtCustomerName.ReadOnly = True
        txtAddress.ReadOnly = True
        txtLocation.ReadOnly = True
        txtTelephone.ReadOnly = True
        txtPhone.ReadOnly = True
        txtEmail.ReadOnly = True
        txtFax.ReadOnly = True
        Return vbNull
    End Function
    Private Function unlock()
        txtCustomerNo.ReadOnly = False
        txtCustomerName.ReadOnly = False
        txtAddress.ReadOnly = False
        txtLocation.ReadOnly = False
        txtTelephone.ReadOnly = False
        txtPhone.ReadOnly = False
        txtEmail.ReadOnly = False
        txtFax.ReadOnly = False
        Return vbNull
    End Function
    Private Function clear()
        txtCustomerNo.Text = ""
        txtCustomerName.Text = ""
        txtAddress.Text = ""
        txtLocation.Text = ""
        txtTelephone.Text = ""
        txtPhone.Text = ""
        txtEmail.Text = ""
        txtFax.Text = ""
        Return vbNull
    End Function
    Private Function searchCustomers(customerNo As String, customerName As String)

        dtgrdCustomerList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = ""
            If customerName <> "" Then
                query = "SELECT `sn`, `customer_no`, `customer_name`, `address`, `location`, `telephone`, `phone`, `email`, `fax` FROM `customers` WHERE `customer_name`LIKE'%" + customerName + "%'"
            Else
                query = "SELECT `sn`, `customer_no`, `customer_name`, `address`, `location`, `telephone`, `phone`, `email`, `fax` FROM `customers` WHERE `customer_no`LIKE'%" + customerNo + "%'"
            End If
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim custNo As String = ""
            Dim custName As String = ""

            While reader.Read

                custNo = reader.GetString("customer_no")
                custName = reader.GetString("customer_name")

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = custNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = custName
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCustomerList.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function
    Private Function search(customerNo As String)
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = ""
            query = "SELECT `sn`, `customer_no`, `customer_name`, `address`, `location`, `telephone`, `phone`, `email`, `fax` FROM `customers` WHERE `customer_no`='" + customerNo + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtCustomerNo.Text = reader.GetString("customer_no")
                txtCustomerName.Text = reader.GetString("customer_name")
                txtAddress.Text = reader.GetString("address")
                txtLocation.Text = reader.GetString("location")
                txtTelephone.Text = reader.GetString("telephone")
                txtPhone.Text = reader.GetString("phone")
                txtEmail.Text = reader.GetString("email")
                txtFax.Text = reader.GetString("fax")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return vbNull
    End Function
    Private Sub frmCorporateCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        clear()
        unlock()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        unlock()
    End Sub

    Private Sub txtCustomerName_TextChanged(sender As Object, e As EventArgs) Handles txtCustomerName.KeyDown
        searchCustomers("", txtCustomerName.Text)
    End Sub

    Private Sub txtCustomerNo_TextChanged(sender As Object, e As EventArgs) Handles txtCustomerNo.KeyDown
        searchCustomers(txtCustomerNo.Text, "")
    End Sub

    Private Sub dtgrdCustomerList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdCustomerList.CellClick
        lock()
        Dim custNo As String = dtgrdCustomerList.Item(0, dtgrdCustomerList.CurrentRow.Index).Value.ToString
        search(custNo)
    End Sub

    Private Sub txtCustomerNo_TextChanged(sender As Object, e As KeyEventArgs) Handles txtCustomerNo.KeyDown

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class