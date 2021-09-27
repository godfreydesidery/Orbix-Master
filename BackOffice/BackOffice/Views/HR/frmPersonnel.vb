Imports Devart.Data.MySql
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmPersonnel
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Function clear()
        txtId.Text = ""
        txtRegNo.Text = ""
        txtRollNo.Text = ""
        txtFirstName.Text = ""
        txtSecondName.Text = ""
        txtLastName.Text = ""
        txtAddress.Text = ""
        txtTelephone.Text = ""
        txtEmail.Text = ""
        chkActive.Checked = False
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

        Return vbNull
    End Function

    Private Sub frmSalesPerson_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
    End Sub
    Private Function refreshList()

        dtgrdList.Rows.Clear()

        Dim personnels As New List(Of Personnel)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("personnels")
            personnels = JsonConvert.DeserializeObject(Of List(Of Personnel))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return vbNull
            Exit Function
        End Try

        For Each personnel In personnels
            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = personnel.regNo
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = personnel.rollNo
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = personnel.lastName + ", " + personnel.firstName
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = personnel.address + "  " + personnel.telephone + "  " + personnel.email
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdList.Rows.Add(dtgrdRow)
        Next

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

        If txtFirstName.Text <> "" Then
            btnDelete.Enabled = True
            btnSave.Enabled = True

        End If
        btnSearch.Enabled = True
        unlock()

    End Sub
    'Dim username As String = ""
    Private Function search(rollNo As String) As Boolean
        Dim found = False

        Dim personnel As New Personnel
        Dim response As Object = New Object
        Dim json As JObject = New JObject

        Try
            response = Web.get_("personnels/get_personnel_by_roll_no?roll_no=" + rollNo)
            personnel = JsonConvert.DeserializeObject(Of Personnel)(response.ToString)

            txtId.Text = personnel.id
            txtRollNo.Text = personnel.rollNo
            txtRegNo.Text = personnel.regNo
            txtFirstName.Text = personnel.firstName
            txtSecondName.Text = personnel.secondName
            txtLastName.Text = personnel.lastName
            txtAddress.Text = personnel.address
            txtTelephone.Text = personnel.telephone
            txtEmail.Text = personnel.email
            If personnel.status = "ACTIVE" Then
                chkActive.Checked = True
            Else
                chkActive.Checked = False
            End If

            If personnel.id <> "" Then
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
        search(txtRollNo.Text)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If validateEntries() <> True Then
            Exit Sub
        End If
        Dim response As Object
        Dim personnel As Personnel

        If txtId.Text = "" Then
            personnel = New Personnel
            personnel.regNo = "NA"
            personnel.rollNo = txtRollNo.Text
            personnel.firstName = txtFirstName.Text
            personnel.secondName = txtSecondName.Text
            personnel.lastName = txtLastName.Text
            personnel.address = txtAddress.Text
            personnel.telephone = txtTelephone.Text
            personnel.email = txtEmail.Text
            If chkActive.Checked = True Then
                personnel.status = "ACTIVE"
            Else
                personnel.status = "INACTIVE"
            End If

            Try
                response = Web.post(personnel, "personnels/new")
                personnel = JsonConvert.DeserializeObject(Of Personnel)(response.ToString)

                txtId.Text = personnel.id
                txtRollNo.Text = personnel.rollNo

                MsgBox("Created successifully", vbOKOnly + vbInformation, "Success")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else

            personnel = New Personnel
            personnel.id = txtId.Text
            personnel.regNo = txtRegNo.Text
            personnel.rollNo = txtRollNo.Text
            personnel.firstName = txtFirstName.Text
            personnel.secondName = txtSecondName.Text
            personnel.lastName = txtLastName.Text
            personnel.address = txtAddress.Text
            personnel.telephone = txtTelephone.Text
            personnel.email = txtEmail.Text
            If chkActive.Checked = True Then
                personnel.status = "ACTIVE"
            Else
                personnel.status = "INACTIVE"
            End If

            Try
                response = Web.put(personnel, "personnels/edit")
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
            search(txtRollNo.Text)
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
        search(dtgrdList.Item(1, row).Value.ToString)
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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

    End Sub
End Class