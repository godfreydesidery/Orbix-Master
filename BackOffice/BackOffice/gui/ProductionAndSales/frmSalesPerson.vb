Imports Devart.Data.MySql

Public Class frmSalesPerson
    Dim EDIT_MODE As String = ""
    Private GL_USERNAME As String = ""
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub



    Private Function clear()
        txtRollNo.Text = ""
        txtFirstName.Text = ""
        txtSecondName.Text = ""
        txtLastName.Text = ""
        txtInvoiceLimit.Text = ""
        txtAddress.Text = ""
        txtTelephone.Text = ""
        txtEmail.Text = ""
        txtStatus.Text = ""
        Return vbNull
    End Function
    Private Function lock()
        txtRollNo.ReadOnly = True
        txtFirstName.ReadOnly = True
        txtSecondName.ReadOnly = True
        txtLastName.ReadOnly = True
        txtAddress.ReadOnly = True
        txtTelephone.ReadOnly = True
        txtEmail.ReadOnly = True
        txtInvoiceLimit.ReadOnly = True

        Return vbNull
    End Function
    Private Function unlock()
        txtRollNo.ReadOnly = False
        txtFirstName.ReadOnly = False
        txtSecondName.ReadOnly = False
        txtLastName.ReadOnly = False
        txtAddress.ReadOnly = False
        txtTelephone.ReadOnly = False
        txtEmail.ReadOnly = False
        txtInvoiceLimit.ReadOnly = False

        Return vbNull
    End Function
    'Private Sub loadRoles()
    'Dim conn As New MySqlConnection(Database.conString)
    'Try
    'Dim suppcommand As New MySqlCommand()
    'Dim supplierQuery As String = "SELECT `id`, `role` FROM `roles`"
    '      conn.Open()
    '      suppcommand.CommandText = supplierQuery
    '      suppcommand.Connection = conn
    ''       suppcommand.CommandType = CommandType.Text
    'Dim reader As MySqlDataReader = suppcommand.ExecuteReader
    '       cmbRole.Items.Clear()
    'If reader.HasRows Then
    'While reader.Read
    '              cmbRole.Items.Add(reader.GetString("role"))
    'End While
    'End If
    '      conn.Close()
    'Catch ex As Devart.Data.MySql.MySqlException
    '       ErrorMessage.dbConnectionError()
    'Exit Sub
    'End Try
    'End Sub
    Private Sub frmSalesPerson_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        ' loadRoles()
    End Sub
    Private Function refreshList()


        dtgrdList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `roll_no`, `first_name`, `second_name`, `last_name`,`full_name`, `address`, `telephone`, `email`, `status`, `invoice_limit` FROM `sales_persons`"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim rollNo As String = ""
            Dim firstname As String = ""
            Dim secondName As String = ""
            Dim lastName As String = ""
            Dim fullName As String = ""
            Dim address As String = ""
            Dim telephone As String = ""
            Dim email As String = ""
            Dim status As String = ""
            Dim invoiceLimit As Double = 0


            While reader.Read

                rollNo = reader.GetString("roll_no")
                firstname = reader.GetString("first_name")
                secondName = reader.GetString("second_name")
                lastName = reader.GetString("last_name")
                fullName = reader.GetString("full_name")
                address = reader.GetString("address")
                telephone = reader.GetString("telephone")
                email = reader.GetString("email")
                status = reader.GetString("status")
                invoiceLimit = reader.GetString("invoice_limit")



                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = rollNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = fullName
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = address + " " + telephone + " " + email
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = "Invoice Limit " + invoiceLimit.ToString + " Status " + status
                dtgrdRow.Cells.Add(dtgrdCell)



                dtgrdList.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function
    Private Sub frmSalesPerson_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        refreshList()
        lock()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        EDIT_MODE = "NEW"
        txtId.Text = ""
        btnEdit.Enabled = True
        btnDelete.Enabled = False
        btnSave.Enabled = True
        btnSearch.Enabled = False
        clear()
        unlock()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If txtFirstName.Text <> "" Then
            EDIT_MODE = ""
            btnDelete.Enabled = True
            btnSave.Enabled = True

        End If
        btnSearch.Enabled = True
        unlock()

    End Sub
    'Dim username As String = ""
    Private Function search() As Boolean
        Dim found = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT `id`, `roll_no`, `first_name`, `second_name`, `last_name`,`full_name`, `address`, `telephone`, `email`, `status`, `invoice_limit` FROM `sales_persons` WHERE `roll_no`='" + txtRollNo.Text + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtId.Text = reader.GetString("id")
                txtRollNo.Text = reader.GetString("roll_no")
                txtFirstName.Text = reader.GetString("first_name")
                txtSecondName.Text = reader.GetString("second_name")
                txtLastName.Text = reader.GetString("last_name")
                txtAddress.Text = reader.GetString("address")
                txtTelephone.Text = reader.GetString("telephone")
                txtEmail.Text = reader.GetString("email")
                txtStatus.Text = reader.GetString("status")
                txtInvoiceLimit.Text = LCurrency.displayValue(reader.GetString("invoice_limit"))
                found = True
                Exit While
            End While
            If found = True Then
                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                btnDelete.Enabled = True
            Else
                MsgBox("No matching record", vbOKOnly + vbCritical, "Error: Not found")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        btnNew.Enabled = True
        btnEdit.Enabled = True
        btnDelete.Enabled = False
        btnSave.Enabled = False
        search()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If validateEntries() <> True Then
            Exit Sub
        End If

        If EDIT_MODE = "NEW" Then
            'User.GL_STATUS = "ACTIVE"

            Dim added As Boolean = False
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                Dim Query As String = "INSERT INTO `sales_persons`(`roll_no`, `first_name`, `second_name`, `last_name`, `full_name`, `address`, `telephone`,`email`, `status`, `invoice_limit`) VALUES (@roll_no,@first_name,@second_name,@last_name,@full_name,@address,@telephone,@email,@status,@invoice_limit)"

                conn.Open()
                command.CommandText = Query
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@roll_no", txtRollNo.Text)
                command.Parameters.AddWithValue("@first_name", txtFirstName.Text)
                command.Parameters.AddWithValue("@second_name", txtSecondName.Text)
                command.Parameters.AddWithValue("@last_name", txtLastName.Text)
                command.Parameters.AddWithValue("@full_name", txtLastName.Text + ", " + txtFirstName.Text + " " + txtSecondName.Text + " (" + txtRollNo.Text + ")")
                command.Parameters.AddWithValue("@address", txtAddress.Text)
                command.Parameters.AddWithValue("@telephone", txtTelephone.Text)
                command.Parameters.AddWithValue("@email", txtEmail.Text)
                command.Parameters.AddWithValue("@status", "ACTIVE")
                command.Parameters.AddWithValue("@invoice_limit", LCurrency.getValue(txtInvoiceLimit.Text))
                command.ExecuteNonQuery()
                conn.Close()
                added = True
                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                EDIT_MODE = ""
                MsgBox("Save successiful")
            Catch ex As MySqlException
                added = False
                MsgBox("Could not add Record. Duplicate entries in roll number ", vbOKOnly + vbCritical, "Error: Duplicate entry")
            Catch ex As Exception
                added = False
                MsgBox(ex.Message + ex.GetType.ToString)
            End Try

        Else

            Dim edited As Boolean = False
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                Dim Query As String = "UPDATE `sales_persons` SET `first_name`='" + txtFirstName.Text + "',`second_name`='" + txtSecondName.Text + "',`last_name`='" + txtLastName.Text + "',`full_name`='" + txtLastName.Text + ", " + txtFirstName.Text + " " + txtSecondName.Text + " (" + txtRollNo.Text + ")" + "',`address`='" + txtAddress.Text + "',`telephone`='" + txtTelephone.Text + "',`email`='" + txtEmail.Text + "',`invoice_limit`='" + LCurrency.getValue(txtInvoiceLimit.Text) + "' WHERE `roll_no`='" + txtRollNo.Text + "'"

                conn.Open()
                command.CommandText = Query
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                conn.Close()
                edited = True
                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                EDIT_MODE = ""
                MsgBox("Edit successiful")
            Catch ex As MySqlException
                edited = False
                MsgBox("Could not edit record. Duplicate or no entries in roll no number ", vbOKOnly + vbCritical, "Error: Duplicate entry")
            Catch ex As Exception
                edited = False
                MsgBox(ex.Message + ex.GetType.ToString)
            End Try

        End If
        refreshList()
    End Sub
    Public Function block(rollNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `sales_persons` SET`status`='BLOCKED' WHERE `roll_no`='" + rollNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function unblock(rollNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `sales_persons` SET`status`='ACTIVE' WHERE `roll_no`='" + rollNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Private Function deleteUser(username As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "DELETE FROM `users` WHERE `username`='" + username + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return success
    End Function

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected Sales Person? The record will be completely removed from the system", vbYesNo + vbQuestion, "Delete Sales Person?")
        If res = DialogResult.Yes Then

            Dim deleted As Boolean = False
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                Dim Query As String = "DELETE FROM `sales_persons` WHERE `roll_no`='" + txtRollNo.Text + "'"
                conn.Open()
                command.CommandText = Query
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                conn.Close()
                deleted = True

            Catch ex As Exception
                deleted = False
                MsgBox(ex.Message + ex.GetType.ToString)
            End Try

            refreshList()
        End If
        btnDelete.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = False
        unlock()
        clear()
    End Sub



    Private Sub txtRollNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRollNo.KeyDown
        If Keys.Tab = Keys.Right Then
            search()
        End If
    End Sub


    Private Function validateEntries() As Boolean
        Dim valid As Boolean = True
        Dim errorMessage As String = ""

        If txtRollNo.Text = "" Then
            errorMessage = "Roll No required"
            valid = False
        End If
        If txtFirstName.Text = "" Then
            errorMessage = "First Name required"
            valid = False
        End If
        If txtSecondName.Text = "" Then
            errorMessage = "Second Name required"
            valid = False
        End If
        If txtLastName.Text = "" Then
            errorMessage = "Last Name required"
            valid = False
        End If
        If txtAddress.Text = "" Then
            errorMessage = "Address required"
            valid = False
        End If
        If txtTelephone.Text = "" Then
            errorMessage = "Telephone no required"
            valid = False
        End If

        If valid = False Then
            MsgBox(errorMessage, vbOKOnly + vbCritical, "Error: Invalid entry")
        End If
        Return valid
    End Function
    Private Sub dtgrdList_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdList.RowHeaderMouseClick
        clear()
        Dim row As Integer = -1
        Dim col As Integer = -1
        Try
            row = dtgrdList.CurrentRow.Index
            col = dtgrdList.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try
        Dim rollNo As String = ""
        row = dtgrdList.CurrentRow.Index
        txtRollNo.Text = dtgrdList.Item(0, row).Value.ToString
        search()
    End Sub

    Private Sub btnBlock_Click(sender As Object, e As EventArgs) Handles btnBlock.Click
        Dim res As Integer = MsgBox("Block Selected Sales Person? Sales operations can not be assigned o a blocked sales person", vbYesNo + vbQuestion, "Block?")
        If res = DialogResult.Yes Then
            block(txtRollNo.Text)
            refreshList()
            search()
        End If
    End Sub

    Private Sub btnUnblock_Click(sender As Object, e As EventArgs) Handles btnUnblock.Click
        Dim res As Integer = MsgBox("Unblock Selected Sales Person?", vbYesNo + vbQuestion, "Unblock?")
        If res = DialogResult.Yes Then
            unblock(txtRollNo.Text)
            refreshList()
            search()
        End If
    End Sub

    Private Sub txtStatus_TextChanged(sender As Object, e As EventArgs) Handles txtStatus.TextChanged
        If txtStatus.Text = "ACTIVE" Then
            btnBlock.Enabled = True
            btnUnblock.Enabled = False
        End If
        If txtStatus.Text = "BLOCKED" Then
            btnBlock.Enabled = False
            btnUnblock.Enabled = True
        End If
    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged
        If txtFirstName.Text.Contains("'") Then
            txtFirstName.Text = ""
        End If
    End Sub

    Private Sub txtSecondName_TextChanged(sender As Object, e As EventArgs) Handles txtSecondName.TextChanged
        If txtSecondName.Text.Contains("'") Then
            txtSecondName.Text = ""
        End If
    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
        If txtLastName.Text.Contains("'") Then
            txtLastName.Text = ""
        End If
    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtAddress.TextChanged
        If txtAddress.Text.Contains("'") Then
            txtAddress.Text = ""
        End If
    End Sub

    Private Sub txtTelephone_TextChanged(sender As Object, e As EventArgs) Handles txtTelephone.TextChanged
        If txtTelephone.Text.Contains("'") Then
            txtTelephone.Text = ""
        End If
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        If txtEmail.Text.Contains("'") Then
            txtEmail.Text = ""
        End If
    End Sub

    Private Sub txtRollNo_TextChanged(sender As Object, e As EventArgs) Handles txtRollNo.TextChanged
        If txtRollNo.Text.Contains("'") Then
            txtRollNo.Text = ""
        End If
    End Sub



    'Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectionChangeCommitted
    'If txtID.Text <> "" And txtUsername.Text <> "" Then
    '  Try
    'Dim conn As New MySqlConnection(Database.conString)
    'Dim command As New MySqlCommand()

    'Dim codeQuery As String = "UPDATE `users` SET `status`='" + cmbStatus.Text + "' WHERE `id`='" + txtID.Text + "'"
    '    conn.Open()
    '   command.CommandText = codeQuery
    '   command.Connection = conn
    '   command.CommandType = CommandType.Text
    '   command.ExecuteNonQuery()
    '    conn.Close()
    '  MsgBox("Status set to " + cmbStatus.Text + " ", vbOKOnly + vbInformation, "Status changed")
    'Catch ex As Exception
    'MsgBox(ex.Message)
    'End Try

    'End If
    ' End Sub

    'Private Sub cmbStatus_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged

    'End Sub

End Class