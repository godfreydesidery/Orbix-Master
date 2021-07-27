Public Class frmOrders

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If User.CURRENT_ROLE = "ADMIN" Or User.CURRENT_ROLE = "MANAGER" Or User.CURRENT_ROLE = "ASSISTANT MANAGER" Or User.CURRENT_ROLE = "PROCUREMENT" Then
        If User.authorize("PROCUREMENT") = True Then
            frmPurchaseOrder.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If User.authorize("PROCUREMENT") = True Then
            frmBlankLPO.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If User.authorize("PROCUREMENT") = True Then
            frmPrintLPO.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub btnLPO_Click(sender As Object, e As EventArgs) Handles btnLPO.Click
        If User.authorize("PROCUREMENT") = True Then
            frmLPO.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub frmOrders_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class