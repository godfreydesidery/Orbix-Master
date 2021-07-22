Imports Devart.Data.MySql

Public Class User
    Public Shared USER_ID As String = ""
    Public Shared USERNAME As String = ""
    Public Shared FIRST_NAME As String = ""
    Public Shared SECOND_NAME As String = ""
    Public Shared LAST_NAME As String = ""
    Public Shared PASSWORD As String = ""
    Public Shared _ALIAS As String = ""
    Public Shared LOGIN_TIME As String = ""
    Public Shared ROLE As String = ""

    Public Shared Function authorize(username As String, password As String, special As Boolean) As Boolean
        Dim auth As Boolean = False
        Dim query As String = "SELECT `id`, `first_name`, `second_name`, `last_name`, `pay_roll_no`, `username`, `password`, `role`, `alias`, `status` FROM `users` WHERE `username`=@username"
        Dim command As New MySqlCommand()
        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@username", username.ToString)
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim no As Integer = 0
            While reader.Read
                If username = reader.GetString("username") And special = True Then
                    If Hash.check(password, reader.GetString("password")) Then
                        auth = True
                    End If
                End If
                Exit While
            End While
        Catch ex As Devart.Data.MySql.MySqlException
            MsgBox(ex.Message)
            Return vbNull
            Exit Function
        End Try
        Return auth
    End Function
    Public Shared Function authenticate(username As String, password As String)
        Dim found As Boolean = False
        Dim status As String = ""
        Dim hashedPassword = ""
        Dim query As String = "SELECT `id`, `first_name`, `second_name`, `last_name`, `pay_roll_no`, `username`, `password`, `role`, `alias`, `status` FROM `users` WHERE `username`=@username"
        Dim command As New MySqlCommand()
        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@username", username.ToString)
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim no As Integer = 0
            While reader.Read
                no = no + 1
                status = reader.GetString("status")
                User._alias = reader.GetString("alias")
                hashedPassword = reader.GetString("password")
                User.USER_ID = reader.GetString("id")
                User.ROLE = reader.GetString("role")
                User.FIRST_NAME = reader.GetString("first_name")
                User.SECOND_NAME = reader.GetString("second_name")
                User.LAST_NAME = reader.GetString("last_name")
            End While
            If no = 0 Then
                'no exist
                status = "not found"
            ElseIf no = 1 Then
                'user distinct
                If status = "ACTIVE" Then
                    'user active
                    status = "ACTIVE"
                    If Hash.check(password, hashedPassword) Then
                        User.username = username
                        User.password = hashedPassword
                        User.LOGIN_TIME = DateAndTime.Now.ToString("yyyy-MM-dd:HH:MM:SS")
                    Else
                        status = "invalid"
                    End If
                Else
                    'user inactive
                    status = "INACTIVE"
                End If
            Else
                'duplicate users
                status = "invalid"
            End If
        Catch ex As Devart.Data.MySql.MySqlException
            MsgBox(ex.Message)
            'LError.databaseConnection()
            Return vbNull
            Exit Function
        End Try
        Return status
        Return vbNull
    End Function
    Public Function getAlias(id As String)
        Dim _alias As String = ""
        Dim query As String = "SELECT `id`, `first_name`, `second_name`, `last_name`, `pay_roll_no`, `username`, `password`, `role`, `alias`, `status` FROM `users` WHERE `id`=@id"
        Dim command As New MySqlCommand()
        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@id", id.ToString)
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim no As Integer = 0
            While reader.Read
                _alias = reader.GetString("alias")
                Exit While
            End While
        Catch ex As Devart.Data.MySql.MySqlException
            MsgBox(ex.Message)
            Return vbNull
            Exit Function
        End Try
        Return _alias
    End Function
    Public Shared Function authorize(priveledge As String)
        Dim allowed As Boolean = False
        Dim role_id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT `role_id` FROM `users` WHERE `id`='" + User.USER_ID + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                role_id = reader.GetString("role_id")
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
            allowed = False
        End Try

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT `role_id` FROM `role_priveledge` WHERE `role_id`='" + role_id + "'AND `priveledge`='" + priveledge + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                allowed = True
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
            allowed = False
        End Try
        Return allowed
    End Function
End Class
