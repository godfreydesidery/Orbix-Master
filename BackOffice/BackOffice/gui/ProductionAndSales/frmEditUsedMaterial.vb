Imports Devart.Data.MySql

Public Class frmEditUsedMaterial
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub
    Dim productionId As String
    Private Sub frmEditUsedMaterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtId.Text = ""
        txtId.Text = Production.GLOBAL_ID
        txtMaterial.Text = Production.GLOBAL_SUMMARY
        txtQty.Text = Production.GLOBAL_QTY
        productionId = Production.GLOBAL_PRODUCTION_ID
        txtAdd.Focus()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click


        Dim value As String = txtAdd.Text
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "UPDATE `production_material` SET `qty`=`qty`+" + value + " WHERE `production_id`='" + productionId + "' AND `material_id`='" + txtId.Text + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Me.Dispose()
    End Sub

    Private Sub btnDeduct_Click(sender As Object, e As EventArgs) Handles btnDeduct.Click
        Dim value As String = txtDeduct.Text
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "UPDATE `production_material` SET `qty`=`qty`-" + value + " WHERE `production_id`='" + productionId + "' AND `material_id`='" + txtId.Text + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Me.Dispose()
    End Sub

    Private Sub txtAdd_TextChanged(sender As Object, e As EventArgs) Handles txtAdd.TextChanged
        If Not IsNumeric(txtAdd.Text) Or Val(txtAdd.Text) < 0 Then
            txtAdd.Text = ""
            btnAdd.Enabled = False
        End If
        If txtAdd.Text <> "" Then
            txtDeduct.Text = ""
            btnAdd.Enabled = True
            btnDeduct.Enabled = False
        End If
    End Sub

    Private Sub txtDeduct_TextChanged(sender As Object, e As EventArgs) Handles txtDeduct.TextChanged
        If Not IsNumeric(txtDeduct.Text) Or Val(txtDeduct.Text) < 0 Or Val(txtDeduct.Text) > Val(txtQty.Text) Then
            txtDeduct.Text = ""
            btnDeduct.Enabled = False
        End If
        If txtDeduct.Text <> "" Then
            txtAdd.Text = ""
            btnDeduct.Enabled = True
            btnAdd.Enabled = False
        End If
    End Sub

    Private Sub frmDelete_Click(sender As Object, e As EventArgs) Handles frmRemove.Click
        Dim status As String = (New Production).getStatus(productionId)
        If status = "CANCELED" Then
            MsgBox("Can not edit a canceled document", vbOKOnly + vbCritical, "Error: Invalid oprration")
            Exit Sub
        ElseIf status = "COMPLETED" Or status = "ARCHIVED" Then
            MsgBox("Can not edit a completed document", vbOKOnly + vbCritical, "Error: Invalid oprration")
            Exit Sub
        ElseIf status = "APPROVED" Then
            'Dim r As Integer = MsgBox("Remove " + txtMaterial.Text + " from this production document?", vbYesNo + vbQuestion, "Remove material from approved document")
            ' MsgBox("Can not delete material from an approved document", vbOKOnly + vbCritical, "Error: Invalid oprration")
            'Exit Sub
        End If

        Dim res As Integer = MsgBox("Remove material from production?", vbYesNo + vbQuestion, "Confirm delete")
        If res = DialogResult.Yes Then
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                Dim codeQuery As String = "DELETE FROM `production_material` WHERE `production_id`='" + productionId + "' AND `material_id`='" + txtId.Text + "'"
                conn.Open()
                command.CommandText = codeQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Me.Dispose()
        End If
    End Sub
End Class