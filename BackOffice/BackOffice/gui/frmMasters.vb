Imports Devart.Data.MySql

Public Class frmMasters

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmCorporateCustomers.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If User.authorize("PRODUCT INQUIRY") = True Then
            frmProductInquiry.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If User.authorize("PRODUCT MANAGEMENT") = True Then
            frmProductMaster.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If User.authorize("COMPANY MANAGEMENT") Then
            frmCompany.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If User.authorize("SUPPLIER MANAGEMENT") Then
            frmSuppliers.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub
    Private Function allow(username As String, password As String, role As String)
        Dim allowed As Boolean = False
        Dim conn As New MySqlConnection(Database.conString)
        Try
            Dim suppcommand As New MySqlCommand()
            Dim supplierQuery As String = "SELECT `username`, `password`, `biometric`, `role`, `alias`, `status` FROM `users` WHERE `username`='" + username + "' AND `role`='" + role + "'"
            conn.Open()
            suppcommand.CommandText = supplierQuery
            suppcommand.Connection = conn
            suppcommand.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = suppcommand.ExecuteReader

            If reader.HasRows Then
                While reader.Read
                    If Hash.check(password, reader.GetString("password")) Then
                        allowed = True
                    End If
                    Exit While
                End While
            End If
            conn.Close()
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Return allowed
            Exit Function
        End Try
        Return allowed
    End Function
    Private Sub btnMassManager_Click(sender As Object, e As EventArgs) Handles btnMassManager.Click

        If User.authorize("PRODUCT MANAGEMENT") Then

            frmMassManager.ShowDialog()

        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub
End Class