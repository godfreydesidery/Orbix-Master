Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmMaterialCategory

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Function clear()

        txtId.Text = ""
        txtCategoryNo.Text = ""
        cmbCategoryName.Text = ""
        cmbCategoryName.SelectedItem = Nothing
        btnBlock.Enabled = False
        btnUnblock.Enabled = False
        Return vbNull
    End Function
    Private Function lock()
        txtCategoryNo.ReadOnly = True
        cmbCategoryName.Enabled = False
        Return vbNull
    End Function
    Private Function unlock()
        txtCategoryNo.ReadOnly = False
        cmbCategoryName.Enabled = True
        Return vbNull
    End Function

    Private Sub frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()

        Dim category As New MaterialCategory
        longList = category.getNames()

    End Sub
    Private Function refreshList()
        dtgrdList.Rows.Clear()

        Dim categories As New List(Of MaterialCategory)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("materials/categories")
            categories = JsonConvert.DeserializeObject(Of List(Of MaterialCategory))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return vbNull
            Exit Function
        End Try

        For Each category In categories

            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = category.no
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = category.name
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = category.status
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
        '  btnDelete.Enabled = False
        btnSave.Enabled = True
        btnSearch.Enabled = False
        clear()
        unlock()
        txtCategoryNo.ReadOnly = True
        txtCategoryNo.Text = "NA"
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If cmbCategoryName.Text <> "" Then
            '  btnDelete.Enabled = True
            btnSave.Enabled = True

        End If

        btnSearch.Enabled = True
        unlock()

        If txtId.Text <> "" Then
            txtCategoryNo.ReadOnly = True
        Else
            txtCategoryNo.ReadOnly = False
        End If
    End Sub

    Private Function search(no As String, name As String) As Boolean
        Dim found = False

        Dim category As New MaterialCategory
        Dim response As Object = New Object
        Dim json As JObject = New JObject

        Try
            If no <> "" Then
                response = Web.get_("materials/categories/get_by_no?no=" + no)
            Else
                response = Web.get_("materials/categories/get_by_name?name=" + name)
            End If
            category = JsonConvert.DeserializeObject(Of MaterialCategory)(response.ToString)

            txtId.Text = category.id
            txtCategoryNo.Text = category.no
            cmbCategoryName.Text = category.name
            If category.id <> "" Then
                found = True
            End If

            If found = True Then
                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                '   btnDelete.Enabled = True
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
        '  btnDelete.Enabled = False
        btnSave.Enabled = False
        search(txtCategoryNo.Text, cmbCategoryName.Text)
    End Sub

    Dim longList As New List(Of String)
    Dim shortList As New List(Of String)
    Private Sub cmbDescription_KeyUp(sender As Object, e As EventArgs) Handles cmbCategoryName.KeyUp
        Dim currentText As String = cmbCategoryName.Text
        shortList.Clear()
        cmbCategoryName.Items.Clear()
        cmbCategoryName.Items.Add(currentText)
        cmbCategoryName.DroppedDown = True
        For Each text As String In longList
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbCategoryName.Text.ToUpper()) Then
                shortList.Add(text)
            End If
        Next
        cmbCategoryName.Items.AddRange(shortList.ToArray())
        cmbCategoryName.SelectionStart = cmbCategoryName.Text.Length
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If validateEntries() <> True Then
            Exit Sub
        End If
        Dim response As Object
        Dim category As MaterialCategory

        If txtId.Text = "" Then
            category = New MaterialCategory
            category.no = "NA"
            category.name = cmbCategoryName.Text
            If chkActive.Checked = True Then
                category.status = "ACTIVE"
            Else
                category.status = "INACTIVE"
            End If

            Try
                response = Web.post(category, "materials/categories/new")
                category = JsonConvert.DeserializeObject(Of MaterialCategory)(response.ToString)

                txtId.Text = category.id
                txtCategoryNo.Text = category.no

                MsgBox("Created successifully", vbOKOnly + vbInformation, "Success")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else

            category = New MaterialCategory
            category.id = txtId.Text
            category.no = txtCategoryNo.Text
            category.name = cmbCategoryName.Text
            If chkActive.Checked = True Then
                category.status = "ACTIVE"
            Else
                category.status = "INACTIVE"
            End If

            Try
                response = Web.put(category, "materials/categories/edit_by_id?id=" + txtId.Text)
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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected category? The record will be completely removed from the system", vbYesNo + vbQuestion, "Delete Category?")
        If res = DialogResult.Yes Then

            Dim deleted As Boolean = False
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                Dim Query As String = "DELETE FROM `material_categories` WHERE `category_no`='" + txtCategoryNo.Text + "'"
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
        ' btnDelete.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = False
        unlock()
        clear()
    End Sub

    Private Sub txtRollNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCategoryNo.KeyDown
        If Keys.Tab = Keys.Right Then
            search(txtCategoryNo.Text, "")
        End If
    End Sub

    Private Function validateEntries() As Boolean
        Dim valid As Boolean = True
        Dim errorMessage As String = ""

        If txtCategoryNo.Text = "" Then
            errorMessage = "Category No required"
            valid = False
        End If
        If cmbCategoryName.Text = "" Then
            errorMessage = "Category name required"
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

        row = dtgrdList.CurrentRow.Index
        txtCategoryNo.Text = dtgrdList.Item(0, row).Value.ToString
        search(dtgrdList.Item(0, row).Value.ToString, "")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub
End Class