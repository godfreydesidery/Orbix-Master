Imports Devart.Data.MySql

Public Class SalesPerson
    'shared fields
    Public Shared CURRENT_USER_ID As String = ""
    Public Shared CURRENT_USERNAME As String = ""
    Public Shared CURRENT_PASSWORD As String = ""
    Public Shared CURRENT_STATUS As String = ""
    Public Shared CURRENT_ALIAS As String = ""
    Public Shared CURRENT_LOGIN_TIME As String = ""
    Public Shared CURRENT_ROLE As String = ""
    Public Shared CURRENT_FIRST_NAME As String = ""
    Public Shared CURRENT_SECOND_NAME As String = ""
    Public Shared CURRENT_LAST_NAME As String = ""

    'global fields
    Public GL_USER_ID As String = ""
    Public GL_FIRST_NAME As String = ""
    Public GL_SECOND_NAME As String = ""
    Public GL_LAST_NAME As String = ""
    Public GL_PAYROLL_NO As String = ""
    Public GL_ROLE As String = ""
    Public GL_USERNAME As String = ""
    Public GL_PASSWORD As String = ""
    Public GL_STATUS As String = ""
    Public Shared Function getUser()
        Dim _user As String = ""
        _user = User.CURRENT_FIRST_NAME & " " + User.CURRENT_SECOND_NAME & " " + User.CURRENT_LAST_NAME
        Return _user
    End Function
    Public Function getSalespersonId(rollNo As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT `id` FROM `sales_persons` WHERE `roll_no`='" + rollNo + "'"
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
    Public Function getFullName(id As String) As String
        Dim name As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT `first_name`, `second_name`, `last_name` FROM `sales_persons` WHERE `id`='" + id + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                name = reader.GetString("last_name") + "," + reader.GetString("first_name") + " " + reader.GetString("last_name")
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return name
    End Function
    Public Function searchSalesPerson(id As String) As Boolean
        Dim found As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT `roll_no`, `first_name`, `second_name`, `last_name`,`full_name`, `address`, `telephone`, `email`, `status`, `invoice_limit` FROM `sales_persons` WHERE `id`='" + id + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                GL_USER_ID = reader.GetString("id")
                GL_FIRST_NAME = reader.GetString("first_name")
                GL_SECOND_NAME = reader.GetString("second_name")
                GL_LAST_NAME = reader.GetString("last_name")
                GL_PAYROLL_NO = reader.GetString("pay_roll_no")
                GL_ROLE = (New Role).getRole(reader.GetString("role_id"))
                GL_USERNAME = reader.GetString("username")
                GL_PASSWORD = reader.GetString("password")
                GL_STATUS = reader.GetString("status")
                found = True
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return found
    End Function
    Public Function addNewUser() As Boolean
        Dim added As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim Query As String = "INSERT INTO `users`(`first_name`, `second_name`, `last_name`, `pay_roll_no`, `username`, `password`,`alias`, `role_id`, `status`) VALUES (@first_name,@second_name,@last_name,@pay_roll_no,@username,@password,@alias,@role_id,@status)"

            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@first_name", GL_FIRST_NAME)
            command.Parameters.AddWithValue("@second_name", GL_SECOND_NAME)
            command.Parameters.AddWithValue("@last_name", GL_LAST_NAME)
            command.Parameters.AddWithValue("@pay_roll_no", GL_PAYROLL_NO)
            command.Parameters.AddWithValue("@username", GL_USERNAME)
            command.Parameters.AddWithValue("@password", GL_PASSWORD)
            command.Parameters.AddWithValue("@alias", GL_FIRST_NAME + " " + GL_LAST_NAME + " - " + GL_USERNAME)
            command.Parameters.AddWithValue("@role_id", (New Role).getRoleID(GL_ROLE))
            command.Parameters.AddWithValue("@status", "ACTIVE")
            command.ExecuteNonQuery()
            conn.Close()
            added = True
        Catch ex As MySqlException
            added = False
            MsgBox("Could not add user. Duplicate entries in username or payroll number ", vbOKOnly + vbCritical, "Error: Duplicate entry")
        Catch ex As Exception
            added = False
            MsgBox(ex.Message + ex.GetType.ToString)
        End Try
        Return added
    End Function
    Public Function editUser(userID As String) As Boolean
        Dim edited As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim Query As String = "UPDATE `users` SET `first_name`='" + GL_FIRST_NAME + "',`second_name`='" + GL_SECOND_NAME + "',`last_name`='" + GL_LAST_NAME + "',`pay_roll_no`='" + GL_PAYROLL_NO + "',`username`='" + GL_USERNAME + "',`password`='" + GL_PASSWORD + "',`alias`='" + GL_FIRST_NAME + " " + GL_LAST_NAME + " - " + GL_USERNAME + "',`role_id`='" + (New Role).getRoleID(GL_ROLE) + "',`status`='" + GL_STATUS + "' WHERE `id`='" + userID + "'"
            If GL_PASSWORD = "" Then
                Query = "UPDATE `users` SET `first_name`='" + GL_FIRST_NAME + "',`second_name`='" + GL_SECOND_NAME + "',`last_name`='" + GL_LAST_NAME + "',`pay_roll_no`='" + GL_PAYROLL_NO + "',`username`='" + GL_USERNAME + "',`alias`='" + GL_FIRST_NAME + " " + GL_LAST_NAME + " - " + GL_USERNAME + "',`role_id`='" + (New Role).getRoleID(GL_ROLE) + "',`status`='" + GL_STATUS + "' WHERE `id`='" + userID + "'"
            End If
            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            edited = True
        Catch ex As MySqlException
            edited = False
            MsgBox("Could not edit user. Duplicate or no entries in username or payroll number ", vbOKOnly + vbCritical, "Error: Duplicate entry")
        Catch ex As Exception
            edited = False
            MsgBox(ex.Message + ex.GetType.ToString)
        End Try
        Return edited
    End Function
    Public Function deleteUser(userID As String) As Boolean
        Dim deleted As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim Query As String = "DELETE FROM `users` WHERE `id`='" + userID + "'"
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
            Dim Query As String = "SELECT `id`, `first_name`, `second_name`, `last_name`, `pay_roll_no`, `username`, `password`, `role_id`, `alias`, `status`FROM `users` WHERE `username`='" + username + "' "
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
                    User.CURRENT_ROLE = (New Role).getRole(reader.GetString("role_id"))
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
    Public Shared Function authorize(priveledge As String)
        Dim allowed As Boolean = False
        Dim role_id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT `role_id` FROM `users` WHERE `id`='" + User.CURRENT_USER_ID + "'"
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

