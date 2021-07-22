Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmMaterialCategory
    Dim EDIT_MODE As String = ""
    Private GL_USERNAME As String = ""
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub



    Private Function clear()

        txtId.Text = ""
        txtCategoryNo.Text = ""
        cmbCategoryName.Text = ""
        cmbCategoryName.SelectedItem = Nothing
        txtStatus.Text = ""
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

        Dim material As New Material
        longList = material.getMaterials()

    End Sub
    Private Function refreshList()


        dtgrdList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `id`, `category_no`, `category_name`, `status` FROM `material_categories`"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim id As String = ""
            Dim categoryNo As String = ""
            Dim categoryName As String = ""
            Dim status As String = ""



            While reader.Read

                id = reader.GetString("id")
                categoryNo = reader.GetString("category_no")
                categoryName = reader.GetString("category_name")
                status = reader.GetString("status")



                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = categoryNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = categoryName
                dtgrdRow.Cells.Add(dtgrdCell)



                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = status
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
        '  btnDelete.Enabled = False
        btnSave.Enabled = True
        btnSearch.Enabled = False
        clear()
        unlock()
        txtCategoryNo.ReadOnly = True
        txtCategoryNo.Text = generateCategoryNo()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If cmbCategoryName.Text <> "" Then
            EDIT_MODE = ""
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
    'Dim username As String = ""
    Private Function search() As Boolean
        Dim found = False
        If txtCategoryNo.Text <> "" Then
            cmbCategoryName.SelectedItem = Nothing
        End If
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT `id`, `category_no`, `category_name`, `status` FROM `material_categories` WHERE `category_no`='" + txtCategoryNo.Text + "'"
            If cmbCategoryName.Text <> "" Then
                query = "SELECT `id`, `category_no`, `category_name`, `status` FROM `material_categories` WHERE `category_name`='" + cmbCategoryName.Text + "'"
            End If
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtId.Text = reader.GetString("id")
                txtCategoryNo.Text = reader.GetString("category_no")
                cmbCategoryName.Text = reader.GetString("category_name")
                txtStatus.Text = reader.GetString("status")

                found = True
                Exit While
            End While
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
        If txtStatus.Text = "" Then
            btnBlock.Enabled = True
        End If
        Return vbNull
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        btnNew.Enabled = True
        btnEdit.Enabled = True
        '  btnDelete.Enabled = False
        btnSave.Enabled = False
        search()

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

        If EDIT_MODE = "NEW" Then
            'User.GL_STATUS = "ACTIVE"

            Dim added As Boolean = False
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                Dim Query As String = "INSERT INTO `material_categories`(`category_no`, `category_name`, `status`) VALUES (@category_no,@category_name,@status)"

                conn.Open()
                command.CommandText = Query
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@category_no", txtCategoryNo.Text)
                command.Parameters.AddWithValue("@category_name", cmbCategoryName.Text)
                command.Parameters.AddWithValue("@status", "ACTIVE")

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
                MsgBox("Could not add Record. Duplicate entries ", vbOKOnly + vbCritical, "Error: Duplicate entry")
            Catch ex As Exception
                added = False
                MsgBox(ex.Message + ex.GetType.ToString)
            End Try

        Else

            Dim edited As Boolean = False
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                Dim Query As String = "UPDATE `material_categories` SET `category_name`='" + cmbCategoryName.Text + "', `status`='" + txtStatus.Text + "' WHERE `category_no`='" + txtCategoryNo.Text + "'"

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
                MsgBox("Could not edit record. Duplicate or no entries ", vbOKOnly + vbCritical, "Error: Duplicate entry")
            Catch ex As Exception
                edited = False
                MsgBox(ex.Message + ex.GetType.ToString)
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
            search()
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
        search()
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

    Private Sub frmMaterials_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Function generateCategoryNo() As String
        Dim no As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id` FROM `material_categories` ORDER BY `id` DESC LIMIT 1"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                no = (Val(reader.GetString("id")) + 1).ToString
                Exit While
            End While
            If no = "" Then
                no = "1"
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return no
    End Function



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub btnBlock_Click(sender As Object, e As EventArgs) Handles btnBlock.Click
        Dim res As Integer = MsgBox("Block Selected Category? A blocked category can not be used", vbYesNo + vbQuestion, "Block?")
        If res = DialogResult.Yes Then
            block(txtId.Text)
            refreshList()
            search()
        End If
    End Sub

    Private Sub btnUnblock_Click(sender As Object, e As EventArgs) Handles btnUnblock.Click
        Dim res As Integer = MsgBox("Unblock Selected category?", vbYesNo + vbQuestion, "Unblock?")
        If res = DialogResult.Yes Then
            unblock(txtId.Text)
            refreshList()
            search()
        End If
    End Sub

    Public Function block(id As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `material_categories` SET`status`='BLOCKED' WHERE `id`='" + id + "'"
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
    Public Function unblock(id As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `material_categories` SET`status`='ACTIVE' WHERE `id`='" + id + "'"
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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub
    Private Sub _clear()

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub btnNew_Click_1(sender As Object, e As EventArgs) Handles btnNew.Click

    End Sub
End Class