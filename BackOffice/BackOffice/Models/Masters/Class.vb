Imports Devart.Data.MySql

Public Class Class_
    '   Inherits Department
    Public GL_CLASS_ID As String = ""
    Public GL_CLASS_NAME As String = ""

    Public Property id As String
    Public Property code As String
    Public Property name As String
    Public Property department As Department = New Department

    Public Function getClassID(className As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `class_id` FROM `class` WHERE `class_name`='" + className + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("class_id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'added = False
            MsgBox(ex.Message)
        End Try
        Return id
    End Function
    Public Function addNewClass(departmentID As String, className As String) As Boolean
        Dim added As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "INSERT INTO `class`( `class_name`, `department_id`) VALUES (@class_name,@dept_id)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@class_name", className)
            command.Parameters.AddWithValue("@dept_id", departmentID)
            command.ExecuteNonQuery()
            conn.Close()
            added = True
        Catch ex As Exception
            added = False
        End Try

        Return added
    End Function
    Public Function editClass(classID As String, className As String, departmentID As String) As Boolean
        Dim edited As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'edit department
            Dim codeQuery As String = "UPDATE `class` SET `class_name`=@class_name,`department_id`=@department_id WHERE `class_id`='" + classID + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@class_name", className)
            command.Parameters.AddWithValue("@department_id", departmentID)
            command.ExecuteNonQuery()
            conn.Close()
            edited = True
        Catch ex As Exception
            edited = False
        End Try

        Return edited
    End Function
    Public Function deleteClass(className As String) As Boolean
        Dim deleted As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'delete department
            Dim codeQuery As String = "DELETE FROM `class` WHERE `class_name`='" + className + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text

            command.ExecuteNonQuery()
            conn.Close()
            deleted = True
        Catch ex As Exception
            deleted = False
        End Try

        Return deleted
    End Function

    Public Function getClassName(classID As String) As String
        Dim class_ As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `class_name` FROM `class` WHERE `class_id`='" + classID + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                class_ = reader.GetString("class_name")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'added = False
            MsgBox(ex.Message)
        End Try
        Return class_
    End Function
End Class
