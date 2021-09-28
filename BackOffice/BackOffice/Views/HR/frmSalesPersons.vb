Imports Devart.Data.MySql
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmSalesPersons
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Function clear()
        txtId.Text = ""
        txtRollNo.Text = ""
        txtNameAndRollNo.Text = ""
        txtContact.Text = ""
        txtInvoiceLimit.Text = ""
        txtCreditLimit.Text = ""
        chkActive.Checked = False
        Return vbNull
    End Function
    Private Function lock()
        txtRollNo.ReadOnly = True
        txtInvoiceLimit.ReadOnly = True
        txtCreditLimit.ReadOnly = True
        Return vbNull
    End Function
    Private Function unlock()
        txtRollNo.ReadOnly = False
        txtInvoiceLimit.ReadOnly = False
        txtCreditLimit.ReadOnly = False
        Return vbNull
    End Function

    Private Sub frmSalesPerson_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
    End Sub
    Private Function refreshList()

        dtgrdList.Rows.Clear()

        Dim salesPersons As New List(Of SalesPerson)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("sales_persons")
            salesPersons = JsonConvert.DeserializeObject(Of List(Of SalesPerson))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return vbNull
            Exit Function
        End Try

        For Each salesPerson In salesPersons
            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = salesPerson.personnel.rollNo
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = salesPerson.personnel.lastName + ", " + salesPerson.personnel.firstName + " " + salesPerson.personnel.secondName
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = salesPerson.personnel.address + " " + salesPerson.personnel.telephone + " " + salesPerson.personnel.email + " [" + salesPerson.status + "]"
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = salesPerson.id
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdList.Rows.Add(dtgrdRow)
        Next
        dtgrdList.ClearSelection()

        Return vbNull
    End Function
    Private Sub frmSalesPerson_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        refreshList()
        lock()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtId.Text = ""
        btnEdit.Enabled = True
        btnDelete.Enabled = False
        btnSave.Enabled = True
        btnSearch.Enabled = False
        clear()
        unlock()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If txtId.Text <> "" Then
            btnDelete.Enabled = True
            btnSave.Enabled = True
        Else
            btnDelete.Enabled = False
            btnSave.Enabled = False
        End If
        btnSearch.Enabled = True
        unlock()
    End Sub
    'Dim username As String = ""
    Private Function searchById(id As String) As Boolean
        Dim found = False

        Dim salesPerson As New SalesPerson
        Dim response As Object = New Object
        Dim json As JObject = New JObject

        Try
            response = Web.get_("personnels/get_sales_person_by_id?id=" + id)
            salesPerson = JsonConvert.DeserializeObject(Of SalesPerson)(response.ToString)

            txtId.Text = salesPerson.id
            txtRollNo.Text = salesPerson.personnel.rollNo
            txtNameAndRollNo.Text = salesPerson.personnel.lastName + ", " + salesPerson.personnel.firstName + " " + salesPerson.personnel.secondName
            txtContact.Text = salesPerson.personnel.address + " " + salesPerson.personnel.telephone + " " + salesPerson.personnel.email
            txtInvoiceLimit.Text = LCurrency.displayValue(salesPerson.invoiceLimit.ToString)
            txtCreditLimit.Text = LCurrency.displayValue(salesPerson.creditLimit.ToString)
            If salesPerson.status = "ACTIVE" Then
                chkActive.Checked = True
            Else
                chkActive.Checked = False
            End If

            If salesPerson.id <> "" Then
                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                btnDelete.Enabled = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return vbNull
    End Function

    Private Function searchByRollNo(rollNo As String) As Boolean
        Dim found = False

        Dim salesPerson As New SalesPerson
        Dim response As Object = New Object
        Dim json As JObject = New JObject

        Try
            response = Web.get_("personnels/get_sales_person_by_roll_no?roll_no=" + rollNo)
            salesPerson = JsonConvert.DeserializeObject(Of SalesPerson)(response.ToString)

            txtId.Text = salesPerson.id
            txtRollNo.Text = salesPerson.personnel.rollNo
            txtNameAndRollNo.Text = salesPerson.personnel.lastName + ", " + salesPerson.personnel.firstName + " " + salesPerson.personnel.secondName
            txtContact.Text = salesPerson.personnel.address + " " + salesPerson.personnel.telephone + " " + salesPerson.personnel.email
            txtInvoiceLimit.Text = LCurrency.displayValue(salesPerson.invoiceLimit.ToString)
            txtCreditLimit.Text = LCurrency.displayValue(salesPerson.creditLimit.ToString)
            If salesPerson.status = "ACTIVE" Then
                chkActive.Checked = True
            Else
                chkActive.Checked = False
            End If

            If salesPerson.id <> "" Then
                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                btnDelete.Enabled = True
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
        searchByRollNo(txtRollNo.Text)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If validateEntries() <> True Then
            Exit Sub
        End If
        Dim response As Object
        Dim salesPerson As SalesPerson

        If txtId.Text = "" Then
            salesPerson = New SalesPerson
            salesPerson.personnel.rollNo = txtRollNo.Text
            salesPerson.invoiceLimit = LCurrency.getValue(txtInvoiceLimit.Text)
            salesPerson.creditLimit = LCurrency.getValue(txtCreditLimit.Text)

            If chkActive.Checked = True Then
                salesPerson.status = "ACTIVE"
            Else
            End If

            salesPerson.status = "INACTIVE"
                Try
                response = Web.post(salesPerson, "sales_persons/new")
                If response = True Then
                    MsgBox("Created successifully", vbOKOnly + vbInformation, "Success")
                Else
                    MsgBox("Process failed", vbOKOnly + vbInformation, "Failed")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else

            salesPerson = New SalesPerson
            salesPerson.id = txtId.Text
            salesPerson.personnel.rollNo = txtRollNo.Text
            salesPerson.invoiceLimit = LCurrency.getValue(txtInvoiceLimit.Text)
            salesPerson.creditLimit = LCurrency.getValue(txtCreditLimit.Text)
            If chkActive.Checked = True Then
                salesPerson.status = "ACTIVE"
            Else
                salesPerson.status = "INACTIVE"
            End If

            Try
                response = Web.put(salesPerson, "sales_persons/edit")
                If response = True Then
                    MsgBox("Updated successifully", vbOKOnly + vbInformation, "Success")
                Else
                    MsgBox("Update failed", vbOKOnly + vbInformation, "Failed")
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
        refreshList()
    End Sub

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
            searchByRollNo(txtRollNo.Text)
        End If
    End Sub

    Private Function validateEntries() As Boolean
        Dim valid As Boolean = True
        Dim errorMessage As String = ""

        If txtRollNo.Text = "" Then
            errorMessage = "Roll No required"
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

        searchById(dtgrdList.Item(3, row).Value.ToString)
    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtNameAndRollNo.TextChanged
        If txtNameAndRollNo.Text.Contains("'") Then
            txtNameAndRollNo.Text = ""
        End If
    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtContact.TextChanged
        If txtContact.Text.Contains("'") Then
            txtContact.Text = ""
        End If
    End Sub

    Private Sub txtRollNo_TextChanged(sender As Object, e As EventArgs) Handles txtRollNo.TextChanged
        If txtRollNo.Text.Contains("'") Then
            txtRollNo.Text = ""
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
        lock()
    End Sub
End Class