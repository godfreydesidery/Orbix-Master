Imports Devart.Data.MySql

Public Class Role
    'shared fields
    Public Shared CURRENT_ROLE_ID As String = ""
    Public Shared CURRENT_ROLE As String = ""


    'global fields
    Public GL_ROLE_ID As String = ""
    Public GL_ROLE As String = ""

    Public Property id As String
    Public Property name As String
    Public Property status As String

    Public Shared Function getRole()
        Dim _role As String = ""
        _role = Role.CURRENT_ROLE
        Return _role
    End Function
    Public Function getRoleID(_role As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT `id` FROM `roles` WHERE `role`='" + _role + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("id")
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return id
    End Function
    Public Function getRole(role_id As String) As String
        Dim role As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT `role` FROM `roles` WHERE `id`='" + role_id + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                role = reader.GetString("role")
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return role
    End Function
    Public Function searchRole(roleID As String) As Boolean
        Dim found As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT `id`, `role` FROM `roles` WHERE `id`='" + roleID + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                GL_ROLE_ID = reader.GetString("id")
                GL_ROLE = reader.GetString("role")
                found = True
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return found
    End Function
    Public Function addNewRole() As Boolean
        Dim added As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim Query As String = "INSERT INTO `roles`(`role`) VALUES (@role)"

            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@role", GL_ROLE)
            command.ExecuteNonQuery()
            conn.Close()
            added = True
        Catch ex As MySqlException
            added = False
            MsgBox("Could not add ROLE. Duplicate entries in role key ", vbOKOnly + vbCritical, "Error: Duplicate entry")
        Catch ex As Exception
            added = False
            MsgBox(ex.Message + ex.GetType.ToString)
        End Try
        Return added
    End Function
    Public Function editRole(roleID As String) As Boolean
        Dim edited As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim Query As String = "UPDATE `roles` SET `role`='" + GL_ROLE + "' WHERE `id`='" + roleID + "'"
            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            edited = True
        Catch ex As MySqlException
            edited = False
            MsgBox("Could not edit role. Duplicate or no entries in role key ", vbOKOnly + vbCritical, "Error: Duplicate entry")
        Catch ex As Exception
            edited = False
            MsgBox(ex.Message + ex.GetType.ToString)
        End Try
        Return edited
    End Function
    Public Function deleteRole(roleID As String) As Boolean
        Dim deleted As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim Query As String = "DELETE FROM `roles` WHERE `id`='" + roleID + "'"
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
        Return deleted
    End Function
    Public Function authenticate(username As String, password As String) As Integer
        '0- login succeeded
        '1- login failed due to invalid credentials
        '2- login failed due to other problems
        Dim auth As Integer = 0
        Try
            Dim command As New MySqlCommand()
            Dim conn As New MySqlConnection
            conn.ConnectionString = Database.conString
            Dim Query As String = "SELECT `id`, `first_name`, `second_name`, `last_name`, `pay_roll_no`, `username`, `password`, `role`, `alias`, `status`FROM `users` WHERE `username`='" + username + "' "
            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader
            If reader.HasRows Then
                Dim i As Integer = 0
                While reader.Read
                    i = i + 1
                    User.CURRENT_USER_ID = reader.GetString("id")
                    User.CURRENT_USERNAME = reader.GetString("username")
                    User.CURRENT_PASSWORD = reader.GetString("password")
                    User.CURRENT_STATUS = reader.GetString("status")

                    User.CURRENT_ROLE = reader.GetString("role")
                    User.CURRENT_FIRST_NAME = reader.GetString("first_name")
                    User.CURRENT_SECOND_NAME = reader.GetString("second_name")
                    User.CURRENT_LAST_NAME = reader.GetString("last_name")
                    User.CURRENT_ALIAS = User.CURRENT_FIRST_NAME + " " + User.CURRENT_LAST_NAME 'reader.GetString("alias")
                    If User.CURRENT_STATUS = "ACTIVE" Then
                        If Hash.check(password, User.CURRENT_PASSWORD) = True Then
                            auth = 0 'user valid and login
                        Else
                            auth = 1 'invalid credentials
                        End If
                    Else
                        auth = 2 'user blocked
                    End If
                    If i <> 1 Then 'duplicate username
                        auth = 2
                    End If
                End While
            Else
                auth = 1 'invalid credentials
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return vbNull
            Exit Function
        End Try
        Return auth
    End Function
End Class
