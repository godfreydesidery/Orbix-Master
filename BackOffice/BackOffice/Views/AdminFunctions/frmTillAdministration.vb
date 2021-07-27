Imports Devart.Data.MySql

Public Class frmTillAdministration

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        frmFiscalPrinter.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        frmPOSPrinter.ShowDialog()
    End Sub
    Private Function refreshList()
        dtgrdTillList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `till_no`, `computer_name` FROM `till` "
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim tillNo As String = ""
            Dim computerName As String = ""

            While reader.Read

                tillNo = reader.GetString("till_no")
                computerName = reader.GetString("computer_name")

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = tillNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = computerName
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdTillList.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function
    Private Function search(tillNo As String) As Boolean
        cmbTillNo.Enabled = False
        If searchTill(tillNo) = True Then
            searchPosPrinter(tillNo)
            searchFiscalPrinter(tillNo)
        Else
            MsgBox("No matching till", vbCritical + vbOKOnly, "Error: Not found")
        End If
        Return vbNull
    End Function
    Private Function searchTill(tillnumber As String) As Boolean
        Dim found As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `till_no`, `computer_name`, `status` FROM `till` WHERE `till_no`='" + tillnumber + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim tillNo As String = ""
            Dim computerName As String = ""
            Dim status As String = ""

            While reader.Read
                tillNo = reader.GetString("till_no")
                computerName = reader.GetString("computer_name")
                status = reader.GetString("status")
                found = True
                Exit While
            End While
            cmbTillNo.Text = tillnumber
            txtComputerName.Text = computerName
            cmbStatus.Text = status

            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        lock()
        cmbTillNo.Enabled = False
        Return found
    End Function
    Private Function searchPosPrinter(tillnumber As String) As Boolean
        Dim found As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `till_no`, `logical_name`, `status` FROM `pos_printer` WHERE `till_no`='" + tillnumber + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim tillNo As String = ""
            Dim printerLogicName As String = ""
            Dim status As String = ""

            While reader.Read
                tillNo = reader.GetString("till_no")
                printerLogicName = reader.GetString("logical_name")
                status = reader.GetString("status")

                found = True
                Exit While
            End While
            txtPosPrinterLogicName.Text = printerLogicName
            If status = "ENABLED" Then
                chkEnablePosPrinter.Checked = True
            Else
                chkEnablePosPrinter.Checked = False
            End If

            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return found
    End Function
    Private Function searchFiscalPrinter(tillnumber As String) As Boolean
        Dim found As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT  `till_no`, `operator_code`, `operator_password`, `port`, `status` FROM `fiscal_printer` WHERE `till_no`='" + tillnumber + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim tillNo As String = ""
            Dim operatorCode As String = ""
            Dim operatorPassword As String = ""
            Dim port As String = ""
            Dim status As String = ""

            While reader.Read
                operatorCode = reader.GetString("operator_code")
                operatorPassword = reader.GetString("operator_password")
                port = reader.GetString("port")
                status = reader.GetString("status")

                found = True
                Exit While
            End While
            txtFiscalPrinterOperatorCode.Text = operatorCode
            txtFiscalPrinterPassword.Text = operatorPassword
            txtFiscalPrinterPort.Text = port

            If status = "ENABLED" Then
                chkEnableFiscalPrinter.Checked = True
            Else
                chkEnableFiscalPrinter.Checked = False
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        cmbTillNo.Enabled = False
        EDIT_MODE = ""
        Return found
    End Function
    Private Function saveNewTill(tillNo As String) As Boolean

        Return vbNull
    End Function
    Private Sub frmTillAdministration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshList()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search(cmbTillNo.Text)
    End Sub

    Private Sub dtgrdTillList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdTillList.CellClick
        Dim tillNo As String = ""
        tillNo = dtgrdTillList.Item(0, dtgrdTillList.CurrentRow.Index).Value.ToString
        search(tillNo)
    End Sub

    Private Sub btnApplyPosPrinter_Click(sender As Object, e As EventArgs) Handles btnApplyPosPrinter.Click
        If EDIT_MODE = "NEW" Or cmbTillNo.Text = "" Then
            MsgBox("Save till first", vbOKOnly + vbExclamation, "")
            Exit Sub
        End If
        If txtPosPrinterLogicName.Text = "" Then
            MsgBox("Logical name for POS printer required", vbExclamation + vbOKOnly, "Error: Missing information")
            Exit Sub
        End If
        'delete any printer if present
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "DELETE FROM `pos_printer` WHERE `till_no`='" + cmbTillNo.Text + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'insert new printer inf
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "INSERT INTO `pos_printer`(`till_no`, `logical_name`, `status`) VALUES (@till_no,@logical_name,@status)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@till_no", cmbTillNo.Text)
            command.Parameters.AddWithValue("@logical_name", txtPosPrinterLogicName.Text)
            Dim status As String = "DISABLED"
            If chkEnablePosPrinter.Checked = True Then
                status = "ENABLED"
            End If
            command.Parameters.AddWithValue("@status", status)
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        MsgBox("Applied")
    End Sub
    Private Sub btnApplyFiscalPrinter_Click(sender As Object, e As EventArgs) Handles btnApplyFiscalPrinter.Click
        If EDIT_MODE = "NEW" Or cmbTillNo.Text = "" Then
            MsgBox("Save till first", vbOKOnly + vbExclamation, "")
            Exit Sub
        End If
        If txtFiscalPrinterOperatorCode.Text = "" Or txtFiscalPrinterPassword.Text = "" Or txtFiscalPrinterPort.Text = "" Then
            MsgBox("Operator code, Operator password and port required for Fiscal printer", vbOKOnly + vbExclamation, "Error: Missing information")
            Exit Sub
        End If
        'delete any printer if present
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "DELETE FROM `fiscal_printer` WHERE `till_no`='" + cmbTillNo.Text + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'insert new printer inf
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "INSERT INTO `fiscal_printer`( `till_no`, `operator_code`, `operator_password`, `port`, `status`) VALUES (@till_no,@operator_code,@operator_password,@port,@status)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@till_no", cmbTillNo.Text)
            command.Parameters.AddWithValue("@operator_code", txtFiscalPrinterOperatorCode.Text)
            command.Parameters.AddWithValue("@operator_password", txtFiscalPrinterPassword.Text)
            command.Parameters.AddWithValue("@port", txtFiscalPrinterPort.Text)
            Dim status As String = "DISABLED"
            If chkEnableFiscalPrinter.Checked = True Then
                status = "ENABLED"
            End If
            command.Parameters.AddWithValue("@status", status)
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        MsgBox("Applied")
    End Sub
    Private Function clear()
        cmbTillNo.Text = ""
        txtComputerName.Text = ""
        cmbStatus.SelectedIndex = 0
        txtPosPrinterLogicName.Text = ""
        chkEnablePosPrinter.Checked = False
        txtFiscalPrinterOperatorCode.Text = ""
        txtFiscalPrinterPassword.Text = ""
        txtFiscalPrinterPort.Text = ""
        chkEnableFiscalPrinter.Checked = False
        Return vbNull
    End Function
    Private Function lock()
        txtComputerName.ReadOnly = True
        cmbStatus.Enabled = False
        Return vbNull
    End Function
    Private Function unlock()
        txtComputerName.ReadOnly = False
        cmbStatus.Enabled = True
        Return vbNull
    End Function
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        EDIT_MODE = "NEW"
        clear()
        cmbTillNo.Enabled = True
    End Sub
    Dim EDIT_MODE As String = ""
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If EDIT_MODE = "NEW" Then

            If searchTill(cmbTillNo.Text) = True Then
                MsgBox("A till with the specified Till Number already exist. Please specify a different till number.", vbExclamation + vbOKOnly, "Error: Duplicate till no")
                clear()
                Exit Sub
            End If

            If cmbTillNo.Text = "" Then
                MsgBox("Till number required", vbExclamation + vbOKOnly, "Error: Missing information")
                Exit Sub
            End If
            'save new till
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                'create bar code
                Dim codeQuery As String = "INSERT INTO `till`(`till_no`, `computer_name`, `status`) VALUES (@till_no,@computer_name,@status)"
                conn.Open()
                command.CommandText = codeQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@till_no", cmbTillNo.Text)
                command.Parameters.AddWithValue("@computer_name", txtComputerName.Text)
                command.Parameters.AddWithValue("@status", cmbStatus.Text)
                command.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        If EDIT_MODE = "" Then
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                'create bar code
                Dim codeQuery As String = "UPDATE `till` SET `computer_name`='" + txtComputerName.Text + "',`status`='" + cmbStatus.Text + "' WHERE `till_no`='" + cmbTillNo.Text + "'"
                conn.Open()
                command.CommandText = codeQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        refreshList()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        EDIT_MODE = ""
        unlock()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub
End Class