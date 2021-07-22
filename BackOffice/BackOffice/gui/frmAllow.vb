Public Class frmAllow
    Public Shared username As String = ""
    Public Shared password As String = ""

    Private Sub frmAllow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        username = ""
        password = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        username = txtUsername.Text
        password = txtPassword.Text
        Me.Dispose()
    End Sub
    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Down Then
            txtPassword.Clear()
            txtPassword.Focus()
        End If
    End Sub
    Private Sub txtPassword_Keydown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Up Then
            txtUsername.Focus()
        End If
        If e.KeyCode = Keys.Enter And txtPassword.Focused = True Then
            username = txtUsername.Text
            password = txtPassword.Text
            Me.Dispose()
        End If
    End Sub
End Class