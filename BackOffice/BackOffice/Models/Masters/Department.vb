Imports Devart.Data.MySql
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Department

    Public GL_DEPT_ID As String = ""
    Public GL_DEPT_NAME As String = ""

    Public Property id As String = ""
    Public Property code As String = ""
    Public Property name As String = ""

    Public Function getDepartmentID(deptName As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `department_id` FROM `department` WHERE `department_name`='" + deptName + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("department_id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'added = False
        End Try
        Return id
    End Function

    Public Function addNewDepartment(deptName As String) As Boolean
        Dim added As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'Dim reader As MySqlDataReader
            'create bar code
            Dim codeQuery As String = "INSERT INTO `department`( `department_name`) VALUES (@dept_name)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@dept_name", deptName)
            command.ExecuteNonQuery()
            conn.Close()
            added = True
        Catch ex As Exception
            added = False
            MsgBox(ex.Message)
        End Try

        Return added
    End Function
    Public Function editDepartment(deptId As String, deptName As String) As Boolean
        Dim edited As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'Dim reader As MySqlDataReader
            'edit department
            Dim codeQuery As String = "UPDATE `department` SET `department_name`='" + deptName + "' WHERE `department_id`='" + deptId + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text

            command.ExecuteNonQuery()
            conn.Close()
            edited = True
        Catch ex As Exception
            edited = False
        End Try

        Return edited
    End Function
    Public Function deleteDepartment(deptId As String) As Boolean
        Dim deleted As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'Dim reader As MySqlDataReader
            'delete department
            Dim codeQuery As String = "DELETE FROM `department` WHERE `department_id`='" + deptId + "'"
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
    Public Function getDepartmentName(departmentID As String) As String
        Dim departmentName As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `department_name` FROM `department` WHERE `department_id`='" + departmentID + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                departmentName = reader.GetString("department_name")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'added = False
            MsgBox(ex.Message)
        End Try
        Return departmentName
    End Function



End Class
