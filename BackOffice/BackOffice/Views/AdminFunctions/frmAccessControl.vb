Imports Devart.Data.MySql
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmAccessControl

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Function clear()
        cmbRole.Items.Clear()
        txtId.Text = ""
        txtRole.Text = ""
        Return vbNull
    End Function
    Private Function lock()
        txtRole.ReadOnly = True
        Return vbNull
    End Function
    Private Function unlock()
        txtRole.ReadOnly = False
        Return vbNull
    End Function
    Private Sub frmUserEnrolment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        loadRoles()
    End Sub
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
            MsgBox(ex.ToString)
            Exit Sub
        End Try
        For Each role_ As Role In list
            cmbRole.Items.Add(role_.name)
        Next
    End Sub

    Private Function refreshRoleList()
        dtgrdRoles.Rows.Clear()
        Dim list As New List(Of Role)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("roles")
            list = JsonConvert.DeserializeObject(Of List(Of Role))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return vbNull
            Exit Function
        End Try

        For Each role_ As Role In list

            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = role_.id
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = role_.name
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdRoles.Rows.Add(dtgrdRow)

        Next
        Return vbNull
    End Function
    Private Function refreshPriveledgeList(_role As String)
        dtgrdPriveledges.Rows.Clear()

        Dim list As New List(Of Priveledge)
        Dim response As Object = New Object
        Dim json As JObject = New JObject

        Try
            response = Web.get_("/priveledges/get_by_role_name?role_name=" + cmbRole.Text)
            list = JsonConvert.DeserializeObject(Of List(Of Priveledge))(response.ToString)

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return vbNull
            Exit Function
        End Try

        Dim result As New ArrayList
        Dim priveledges As String() = Priveledge.PRIVELEDGES
        Dim _priveledge As String = ""

        For ctr As Integer = 0 To priveledges.Length - 1

            _priveledge = priveledges(ctr).ToString

            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = _priveledge
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewCheckBoxCell()
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdPriveledges.Rows.Add(dtgrdRow)

            For Each item In list
                If item.name = _priveledge And item.role.name = cmbRole.SelectedItem.ToString Then
                    dtgrdPriveledges.Item(1, ctr).Value = True
                    '   dtgrdPriveledges.Rows(ctr).DefaultCellStyle.BackColor = SystemColors.ControlDark
                    If item.name.ToString.Contains("@") Then
                        '    dtgrdPriveledges.Rows(ctr).DefaultCellStyle.BackColor = SystemColors.ActiveCaption
                        dtgrdPriveledges.Rows(ctr).ReadOnly = True
                    End If
                    Exit For
                End If
            Next
        Next
        Return vbNull
    End Function

    Private Sub frmUserEnrolment_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        refreshRoleList()
        lock()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtId.Text = ""
        txtRole.Text = ""
        btnEdit.Enabled = True
        btnDelete.Enabled = False
        btnSave.Enabled = True
        clear()
        unlock()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If txtRole.Text <> "" Then
            btnDelete.Enabled = True
            btnSave.Enabled = True

        End If
        unlock()
    End Sub
    Private Function search(id As String) As Boolean
        Dim found As Boolean = False
        Dim role As New Role

        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("roles/get_by_id?id=" + id)
            json = JObject.Parse(response)
        Catch ex As Exception
            Return vbNull
            Exit Function
        End Try
        role = JsonConvert.DeserializeObject(Of Role)(json.ToString)
        If role.id.ToString = "" Then
            MsgBox("No matching role", vbOKOnly + vbCritical, "Error: Not found")
        Else
            txtId.Text = role.id
            txtRole.Text = role.name
            lock()
            btnEdit.Enabled = True
            btnSave.Enabled = False
            btnDelete.Enabled = True
            Return True
        End If
        Return False
        Exit Function
    End Function


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If validateEntries() <> True Then
            Exit Sub
        End If
        Dim role As New Role
        role.id = txtId.Text
        role.name = txtRole.Text

        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            If txtId.Text = "" Then
                response = Web.post(role, "roles/new")
                json = JObject.Parse(response)
                role = JsonConvert.DeserializeObject(Of Role)(json.ToString)
                txtId.Text = role.id

                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                MsgBox("Role created successifully", vbOKOnly + vbInformation, "Success: New role created")
            Else
                If Web.put(role, "roles/edit_by_id?id=" + txtId.Text) = True Then
                    lock()
                    btnEdit.Enabled = True
                    btnSave.Enabled = False
                    MsgBox("Role updated successifully", vbOKOnly + vbInformation, "Success: Role updated")
                Else
                    MsgBox("Update failed")
                End If
            End If
            clear()
            loadRoles()
            refreshRoleList()
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("Operation failed")
            Exit Sub
        End Try
        Exit Sub
    End Sub
    Private Function deleteRole(role As String) As Boolean
        Try
            Dim response As String
            response = Web.delete("roles/delete_by_id?id=" + txtId.Text)
            If response = "true" Then
                MsgBox("Role deleted successifully")
            Else
                MsgBox("Could not delete role")
            End If
            dtgrdRoles.ClearSelection()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtId.Text = "" Then
            MsgBox("Select role to delete", vbOKOnly + vbCritical, "Error: No selection")
            Exit Sub
        End If
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected role? Information about the role will be removed from the system", vbYesNo + vbQuestion, "Delete role account?")
        If res = DialogResult.Yes Then
            deleteRole(txtId.Text)
            refreshRoleList()
        End If
        btnDelete.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = False
        unlock()
        clear()
        loadRoles()
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRole.KeyDown
        If Keys.Tab = Keys.Right Then
            search(txtId.Text)
        End If
    End Sub

    Private Function validateEntries() As Boolean
        Dim valid As Boolean = True
        Dim errorMessage As String = ""

        If txtRole.Text = "" Then
            errorMessage = "Role required"
            valid = False
        End If
        Return valid
    End Function
    Private Sub dtgrdRoles_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdRoles.RowHeaderMouseClick
        Dim row As Integer = -1
        Dim col As Integer = -1
        Try
            row = dtgrdRoles.CurrentRow.Index
            col = dtgrdRoles.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try
        Dim id As String = ""
        Dim role As String = ""
        row = dtgrdRoles.CurrentRow.Index
        txtRole.Text = dtgrdRoles.Item(1, row).Value.ToString
        id = dtgrdRoles.Item(0, row).Value.ToString
        search(id)
    End Sub

    Private Sub cmbRole_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbRole.SelectedIndexChanged
        If cmbRole.SelectedItem.ToString <> "" Then
            lblInfo.Text = "Check or uncheck priveledges for " + cmbRole.SelectedItem.ToString
            refreshPriveledgeList(cmbRole.SelectedItem.ToString)
        Else
            dtgrdPriveledges.Rows.Clear()
            lblInfo.Text = ""
        End If
    End Sub

    Private Sub dtgrdPriveledges_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdPriveledges.CellContentClick
        Dim col As Integer = -1
        Dim row As Integer = -1
        Try
            row = dtgrdPriveledges.CurrentRow.Index
            col = dtgrdPriveledges.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try

        If dtgrdPriveledges.CurrentCell.ColumnIndex = 1 Then

            Dim priveledge_ As New Priveledge
            Dim response As Object = New Object
            Dim json As JObject = New JObject
            Try
                response = Web.get_("/role_priveledges/get_by_role_name_and_name?role_name=" + cmbRole.Text + "&name=" + dtgrdPriveledges.Item(0, row).Value.ToString)
                priveledge_ = JsonConvert.DeserializeObject(Of Priveledge)(response.ToString)
                If priveledge_.id.ToString <> "" Then
                    deletePrev()
                End If
            Catch ex As Newtonsoft.Json.JsonReaderException
                addPrev()
                Exit Sub
            Catch ex As Exception
                MsgBox(ex.ToString)
                Exit Sub
            End Try
            refreshPriveledgeList(cmbRole.SelectedItem.ToString)
        End If
    End Sub
    Private Sub deletePrev()
        Dim col As Integer = -1
        Dim row As Integer = -1
        Try
            row = dtgrdPriveledges.CurrentRow.Index
            col = dtgrdPriveledges.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        response = Web.delete("/role_priveledges/delete_by_role_name_and_name?role_name=" + cmbRole.SelectedItem.ToString + "&name=" + dtgrdPriveledges.Item(0, row).Value.ToString)
    End Sub
    Private Sub addPrev()
        Try
            Dim col As Integer = -1
            Dim row As Integer = -1
            Try
                row = dtgrdPriveledges.CurrentRow.Index
                col = dtgrdPriveledges.CurrentCell.ColumnIndex
            Catch ex As Exception
                row = -1
            End Try
            Dim response As Object = New Object
            Dim json As JObject = New JObject
            Dim priveledge As New Priveledge
            priveledge.role.name = cmbRole.Text
            priveledge.name = dtgrdPriveledges.Item(0, row).Value.ToString
            response = Web.post(priveledge, "/role_priveledges/new")
        Catch ex As Exception

        End Try

    End Sub
End Class