Imports Devart.Data.MySql
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmUserEnrolment
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Function clear()
        txtID.Text = ""
        txtFirstName.Text = ""
        txtSecondName.Text = ""
        txtLastName.Text = ""
        txtPayrollNo.Text = ""
        cmbRole.Text = ""
        cmbStatus.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtConfPassword.Text = ""
        chkActive.Checked = False
        Return vbNull
    End Function
    Private Function lock()
        txtFirstName.ReadOnly = True
        txtSecondName.ReadOnly = True
        txtLastName.ReadOnly = True
        txtPayrollNo.ReadOnly = True
        cmbRole.Enabled = False
        cmbStatus.Enabled = False
        txtUsername.ReadOnly = True
        txtPassword.ReadOnly = True
        txtConfPassword.ReadOnly = True
        chkActive.Enabled = False
        Return vbNull
    End Function
    Private Function unlock()
        txtFirstName.ReadOnly = False
        txtSecondName.ReadOnly = False
        txtLastName.ReadOnly = False
        txtPayrollNo.ReadOnly = False
        cmbRole.Enabled = True
        cmbStatus.Enabled = True
        txtUsername.ReadOnly = False
        txtPassword.ReadOnly = False
        txtConfPassword.ReadOnly = False
        chkActive.Enabled = True
        Return vbNull
    End Function
    Private Sub loadRoles()
        cmbRole.Items.Clear()
        cmbRole.Items.Add("")
        Dim list As New List(Of Role)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("roles")
            list = JsonConvert.DeserializeObject(Of List(Of Role))(response.ToString)
        Catch ex As Exception
            Exit Sub
        End Try
        For Each role_ As Role In list
            cmbRole.Items.Add(role_.name)
        Next


        Exit Sub
    End Sub
    Private Sub frmUserEnrolment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        loadRoles()
    End Sub
    Private Function refreshList()
        dtgrdUsers.Rows.Clear()

        Dim list As New List(Of User)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("users")
            list = JsonConvert.DeserializeObject(Of List(Of User))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return vbNull
            Exit Function
        End Try

        For Each user_ As User In list

            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = user_.username
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = user_.rollNo
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = user_.firstName + " " + user_.lastName
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            If IsNothing(user_.role) Then
                dtgrdCell.Value = ""
            Else
                dtgrdCell.Value = user_.role.name
            End If
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = user_.id
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdUsers.Rows.Add(dtgrdRow)
        Next
        Return vbNull
    End Function
    Private Sub frmUserEnrolment_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        refreshList()
        lock()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtID.Text = ""
        btnEdit.Enabled = True
        btnDelete.Enabled = False
        btnSave.Enabled = True
        btnSearch.Enabled = False
        clear()
        unlock()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If txtUsername.Text <> "" Then
            btnDelete.Enabled = True
            btnSave.Enabled = True
        End If
        btnSearch.Enabled = True
        unlock()
        txtPassword.Text = ""
        txtConfPassword.Text = ""
    End Sub
    'Dim username As String = ""
    Private Function search(id As String, username As String) As Boolean

        txtID.Text = ""
        If id = "" And username = "" Then
            MsgBox("Please specify a record to search. Enter id or username.", vbOKOnly + vbExclamation, "Error: Search key not specified")
            Return vbNull
            Exit Function
        End If

        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            If id <> "" Then
                response = Web.get_("users/" + id)
                json = JObject.Parse(response)
            ElseIf username <> "" Then
                response = Web.get_("users/username=" + username)
                json = JObject.Parse(response)
            End If
        Catch ex As Exception
            Return False
            Exit Function
        End Try

        Dim user_ As User = JsonConvert.DeserializeObject(Of User)(json.ToString)
        If user_.id.ToString = "" Then
            MsgBox("No matching record", vbOKOnly + vbCritical, "Error: Not found")
        Else
            txtID.Text = user_.id
            txtUsername.Text = user_.username
            txtFirstName.Text = user_.firstName
            txtSecondName.Text = user_.secondName
            txtLastName.Text = user_.lastName
            txtPayrollNo.Text = user_.rollNo
            If IsNothing(user_.role) Then
                cmbRole.Text = ""
            Else
                cmbRole.Text = user_.role.name
            End If
            '    cmbStatus.Text = user_.status
            If user_.active = 0 Then
                chkActive.Checked = False
            Else
                chkActive.Checked = True
            End If
            lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                btnDelete.Enabled = True
            End If
            txtPassword.Text = ""
        txtConfPassword.Text = ""
        Return vbNull

    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        btnNew.Enabled = True
        btnEdit.Enabled = True
        btnDelete.Enabled = False
        btnSave.Enabled = False
        search(txtID.Text, txtUsername.Text)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If validateEntries() <> True Then
            Exit Sub
        End If
        Dim user As New User

        user.username = txtUsername.Text
        user.firstName = txtFirstName.Text
        user.secondName = txtSecondName.Text
        user.lastName = txtLastName.Text
        user.rollNo = txtPayrollNo.Text
        user.role.name = cmbRole.Text
        '   user.status = cmbStatus.Text
        If txtPassword.Text <> "" Then
            user.password = txtPassword.Text
        End If
        If chkActive.Checked = True Then
            user.active = 1
        Else
            user.active = 0
        End If
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            If txtID.Text = "" Then
                response = Web.post(user, "users/new")
                json = JObject.Parse(response)
                'Dim data As Product = New Product
                txtID.Text = json.SelectToken("id")
                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                MsgBox("User created successifully", vbOKOnly + vbInformation, "Success: New user created")
            Else
                If Web.put(user, "users/edit/" + txtID.Text) = True Then
                    lock()
                    btnEdit.Enabled = True
                    btnSave.Enabled = False
                    MsgBox("User updated successifully", vbOKOnly + vbInformation, "Success: User updated")
                Else
                    MsgBox("Update failed")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("Operation failed")
            Exit Sub
        End Try
        refreshList()
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtID.Text = "" Then
            MsgBox("Please select a user to delete", vbOKOnly + vbCritical, "Error: No selection")
            Exit Sub
        End If
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected user? Information about the user will be removed from the sustem", vbYesNo + vbQuestion, "Delete user account?")
        If res = DialogResult.Yes Then
            Try
                Dim response As String
                response = Web.delete("users/delete/" + txtID.Text)
                MsgBox(response.ToString, vbOKOnly + vbInformation, "Success: Delete success")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            refreshList()
        End If
        btnDelete.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = False
        unlock()
        clear()
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If Keys.Tab = Keys.Right Then
            search(txtID.Text, txtUsername.Text)
        End If
    End Sub

    Private Function validateEntries() As Boolean
        Dim valid As Boolean = True
        Dim errorMessage As String = ""

        If txtPassword.Text = "" And txtID.Text = "" Then
            errorMessage = "Password required for a new user"
            valid = False
        End If
        If txtID.Text = "" Then
            If txtPassword.Text.Length < 6 Or txtPassword.Text.Length > 10 Then
                errorMessage = "Invalid password length. Password length must be between 6-10 characters"
                valid = False
            End If
            If txtPassword.Text <> txtConfPassword.Text Then
                errorMessage = "The value of password and password confirmation does not match"
                valid = False
            End If
        Else
            If (txtPassword.Text.Length < 6 Or txtPassword.Text.Length > 10) And txtPassword.Text.Length > 0 Then
                errorMessage = "Invalid password length. Password length must be between 6-10 characters"
                valid = False
            End If
            If txtPassword.Text <> txtConfPassword.Text Then
                errorMessage = "The value of password and password confirmation does not match"
                valid = False
            End If
        End If

        If txtLastName.Text = "" Then
            errorMessage = "Last name required"
            valid = False
        End If
        If txtFirstName.Text = "" Then
            errorMessage = "First name required"
            valid = False
        End If
        If txtUsername.Text = "" Then
            errorMessage = "Username required"
            valid = False
        End If
        If valid = False Then
            MsgBox(errorMessage, vbOKOnly + vbCritical, "Error: Invalid entry")
        End If
        Return valid
    End Function
    Private Sub dtgrdUsers_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdUsers.RowHeaderMouseClick
        clear()
        Dim row As Integer = -1
        Dim col As Integer = -1
        Try
            row = dtgrdUsers.CurrentRow.Index
            col = dtgrdUsers.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try
        Dim username As String = ""
        row = dtgrdUsers.CurrentRow.Index
        txtUsername.Text = dtgrdUsers.Item(0, row).Value.ToString
        txtID.Text = dtgrdUsers.Item(4, row).Value.ToString
        search(txtID.Text, txtUsername.Text)
    End Sub

End Class