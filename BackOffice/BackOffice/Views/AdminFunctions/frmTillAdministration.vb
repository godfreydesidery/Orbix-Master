Imports Devart.Data.MySql
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

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
        Dim list As New List(Of Till)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("tills")
            list = JsonConvert.DeserializeObject(Of List(Of Till))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return vbNull
            Exit Function
        End Try
        For Each till As Till In list
            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = till.id
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = till.no
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = till.computerName
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = till.name
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdTillList.Rows.Add(dtgrdRow)
        Next
        Return vbNull
    End Function
    Private Function search(id As String, tillNo As String) As Boolean
        cmbTillNo.Enabled = False
        If searchTill("", tillNo) = True Then
            searchPosPrinter(tillNo)
            searchFiscalPrinter(tillNo)
        Else
            MsgBox("No matching till", vbCritical + vbOKOnly, "Error: Not found")
        End If
        Return vbNull
    End Function
    Private Function searchTill(tillId As String, tillnumber As String) As Boolean
        If cmbTillNo.Text = "" And txtId.Text = "" Then
            MsgBox("Please specify a record to search.", vbOKOnly + vbExclamation, "Error: Search key not specified")
            Return vbNull
            Exit Function
        End If
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            If txtId.Text <> "" Then
                response = Web.get_("tills/get_by_id?id=" + txtId.Text)
            Else
                response = Web.get_("tills/get_by_no?no=" + cmbTillNo.Text)
            End If

            json = JObject.Parse(response)
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Dim till As Till = JsonConvert.DeserializeObject(Of Till)(json.ToString)
        If till.id.ToString = "" Then
            MsgBox("No matching product", vbOKOnly + vbCritical, "Error: Not found")
            Return False
        Else

            cmbTillNo.Text = till.no
            txtComputerName.Text = till.computerName
            txtName.Text = till.name
            If till.active = 1 Then
                chkActive.Checked = True
            Else
                chkActive.Checked = False
            End If
            Return True
        End If
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
        search("", cmbTillNo.Text)
    End Sub

    Private Sub dtgrdTillList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdTillList.CellClick

        txtId.Text = dtgrdTillList.Item(0, dtgrdTillList.CurrentRow.Index).Value.ToString
        search(txtId.Text, "")
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
        txtId.Text = ""
        cmbTillNo.Text = ""
        txtComputerName.Text = ""
        txtName.Text = ""
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
        Return vbNull
    End Function
    Private Function unlock()
        txtComputerName.ReadOnly = False
        Return vbNull
    End Function
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        clear()
        cmbTillNo.Enabled = True
    End Sub
    Dim EDIT_MODE As String = ""
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cmbTillNo.Text = "" Then
            MsgBox("Till number required", vbExclamation + vbOKOnly, "Error: Missing information")
            Exit Sub
        End If
        Dim till As Till = New Till
        till.id = txtId.Text
        till.no = cmbTillNo.Text
        till.computerName = txtComputerName.Text
        till.name = txtName.Text
        If chkActive.Checked = True Then
            till.active = 1
        Else
            till.active = 0
        End If
        MsgBox(till.active)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            Dim success As Boolean = False
            If txtId.Text = "" Then
                response = Web.post(till, "tills/new")
                json = JObject.Parse(response)
                txtId.Text = json.SelectToken("id")
                refreshList()
                MsgBox("Till created successifully", vbOKOnly + vbInformation, "Success")
            Else
                If Web.put(till, "tills/edit_by_id?id=" + txtId.Text) = True Then
                    refreshList()
                    MsgBox("Till updated successifully", vbOKOnly + vbInformation, "Success")
                Else
                    MsgBox("Update failed")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("Operation failed")
            Exit Sub
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        EDIT_MODE = ""
        unlock()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub
End Class