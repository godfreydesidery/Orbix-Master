Imports Devart.Data.MySql

Public Class frmLogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        login()
    End Sub
    Private Function login()
        '0-LOGIN_SUCCESS
        '1-LOGIN_FAIL_INVALID
        '2-LOGIN_FAIL_OTHERS
        Dim currUser As New User
        Dim auth As Integer = currUser.authenticate(txtUsername.Text, txtPassword.Text)
        If auth = 0 Then
            Me.Hide()
            frmMain.Show()
            Me.Close()
        ElseIf (auth = 1) Then
            MsgBox("Could not log in. Invalid Username and Password.", vbCritical + vbOKOnly, "Error: Login failed")
        Else
            MsgBox("Could not log in. The user account is either invalid or diactivated. Contact the system administrator for help.", vbCritical + vbOKOnly, "Error: Login failed")
        End If
        Return vbNull
    End Function

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
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
            login()
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Shown
        Dim app As New LApplication
        app.loadSettings()
        Day.DAY = (New Day).getCurrentDay.ToString("yyyy-MM-dd")


        'Dim company As New Company
        If Company.loadCompanyDetails = True Then 'loads company information

        Else

            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                Dim Query As String = "INSERT INTO `company`( `company_name`) VALUES (@fake_company_name)"
                conn.Open()
                command.CommandText = Query
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@fake_company_name", "COMPANY")

                command.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception

                MsgBox(ex.Message + ex.GetType.ToString)
            End Try
            MsgBox("Company Information not configured. The system has entered a default company. Please configure company details before proceeding. Contact the system administrator for help", vbOKOnly + vbCritical, "Error :No company details")
            End
        End If
    End Sub
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"
    Private Sub startOSK()
        Dim old As Long
        If Environment.Is64BitOperatingSystem Then
            If Wow64DisableWow64FsRedirection(old) Then
                Process.Start(osk)
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            Process.Start(osk)
        End If
    End Sub

    Private Sub frmLogin_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

    End Sub

    Private Sub txtUsername_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtUsername.MouseDoubleClick
        startOSK()

    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub txtPassword_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtPassword.MouseDoubleClick
        startOSK()

    End Sub


End Class
