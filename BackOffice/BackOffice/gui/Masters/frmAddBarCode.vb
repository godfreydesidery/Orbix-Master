Imports Devart.Data.MySql

Public Class frmAddBarCode
    Private Sub refreshList(itemCode As String)
        dtgrdBarCodes.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `sn`, `item_scan_code`, `item_code`, `descr` FROM `bar_codes` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim barCode As String = ""

            While reader.Read

                barCode = reader.GetString("item_scan_code")

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = barCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdBarCodes.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub frmAddBarCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtItemCode.Text = frmProductMaster.GLOBAL_ITEM_CODE
        refreshList(txtItemCode.Text)
    End Sub
    Private Function save(barCode As String, itemCode As String) As Boolean
        Dim success As Boolean = False
        If txtBarCode.Text = "" Or txtItemCode.Text = "" Then
            MsgBox("Bar code for the selected item required", vbOKOnly + vbCritical, "Error: Missing information.")
            Return success
            Exit Function
        End If
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim Query As String = "INSERT INTO `bar_codes`(`item_scan_code`, `item_code`) VALUES (@bar_code,@item_code)"
            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@bar_code", txtBarCode.Text)
            command.Parameters.AddWithValue("@item_code", txtItemCode.Text)
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
        End Try
        If success = False Then
            MsgBox("Could not add bar code for the selected item. A similar barcode might be existing in the system. Try to clear unused bar codes.", vbOKOnly + vbCritical, "Error: Operation failed")
        Else
            MsgBox("Bar code successively added.", vbOKOnly + vbInformation, "Success: Bar code added")
        End If
        Return success
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtBarCode.Text = "" Then
            MsgBox("Null Entry")
            Exit Sub
        End If
        save(txtBarCode.Text, txtItemCode.Text)
        txtBarCode.Text = ""
        refreshList(txtItemCode.Text)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtBarCode.Text = ""
        Me.Dispose()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim selectedBarCode As String = ""
        Try
            selectedBarCode = dtgrdBarCodes.CurrentCell.Value.ToString
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim Query As String = "DELETE FROM `bar_codes` WHERE `item_scan_code`='" + selectedBarCode + "'"
            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            refreshList(txtItemCode.Text)
            MsgBox("Bar Code removed")
        Catch ex As Exception
            MsgBox("Operation failed")
        End Try
    End Sub
End Class