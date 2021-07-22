Imports Devart.Data.MySql

Public Class SubClass
    ' Inherits Class_
    Public GL_SUB_CLASS_ID As String = ""
    Public GL_SUB_CLASS_NAME As String = ""

    Public Property id As String
    Public Property code As String
    Public Property name As String
    Public Property clas As Class_ = New Class_
    Public Property department As Department = New Department

    Public Function getSubClassID(subClassName As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `sub_class_id` FROM `sub_class` WHERE `sub_class_name`='" + subClassName + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("sub_class_id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'added = False
            MsgBox(ex.Message)
        End Try
        Return id
    End Function

    Public Function addNewSubClass(classID As String, subClassName As String) As Boolean
        Dim added As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "INSERT INTO `sub_class`( `sub_class_name`, `class_id`) VALUES (@sub_class_name,@class_id)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@sub_class_name", subClassName)
            command.Parameters.AddWithValue("@class_id", classID)
            command.ExecuteNonQuery()
            conn.Close()
            added = True
        Catch ex As Exception
            added = False
        End Try

        Return added
    End Function
    Public Function editSubClass(subClassID As String, subClassName As String, classID As String) As Boolean
        Dim edited As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'edit department
            Dim codeQuery As String = "UPDATE `sub_class` SET `sub_class_name`=@sub_class_name,`class_id`=@class_id WHERE `sub_class_id`='" + subClassID + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@sub_class_name", subClassName)
            command.Parameters.AddWithValue("@class_id", classID)
            command.ExecuteNonQuery()
            conn.Close()
            edited = True
        Catch ex As Exception
            edited = False
        End Try

        Return edited
    End Function
    Public Function deleteSubClass(subClassName As String) As Boolean
        Dim deleted As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'delete department
            Dim codeQuery As String = "DELETE FROM `sub_class` WHERE `sub_class_name`='" + subClassName + "'"
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


    Public Function getSubClassName(subClassID As String) As String
        Dim subClass As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `sub_class_name` FROM `sub_class` WHERE `sub_class_id`='" + subClassID + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                subClass = reader.GetString("sub_class_name")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'added = False
            MsgBox(ex.Message)
        End Try
        Return subClass
    End Function
End Class
