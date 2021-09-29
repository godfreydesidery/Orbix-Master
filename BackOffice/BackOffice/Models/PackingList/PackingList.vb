Imports Devart.Data.MySql

Public Class PackingList
    Inherits Item


    Public Shared GLOBAL_ISSUE_NO As String = ""
    Public Shared GLOBAL_SM_OFFICER As String = ""
    Public Shared GLOBAL_DEBT As String = ""


    Public GL_ID As String = ""
    Public GL_ISSUE_NO As String = ""
    Public GL_ISSUE_DATE As String = ""
    Public GL_STATUS As String = ""
    Public GL_SALES_PERSON As String = ""
    Public GL_DESCRIPTION As String = ""
    Public GL_RETURNS As Double = 0
    Public GL_PACKED As Double = 0
    Public GL_TOTAL_ISSUED As Double = 0
    Public GL_QTY_RETURNED As Double = 0
    Public GL_QTY_SOLD As Double = 0
    Public GL_QTY_DAMAGED As Double = 0
    Public GL_AMOUNT_ISSUED As Double = 0
    Public GL_TOTAL_RETURNS As Double = 0
    Public GL_TOTAL_DAMAGES As Double = 0
    Public GL_TOTAL_DISCOUNTS As Double = 0
    Public GL_TOTAL_EXPENDITURES As Double = 0
    Public GL_TOTAL_BANK_CASH As Double = 0
    Public GL_DEBT As Double = 0
    Public GL_COST_OF_GOODS_SOLD As Double = 0

    ' Public GL_PACK_SIZE As Double = 0
    Public GL_PRICE As Double = 0
    Public GL_C_PRICE As Double = 0
    Public GL_STOCK_SIZE As Integer = 0


    Public Overloads Property id As String = ""
    Public Property no As String = ""
    Public Property createdDay As Day = New Day
    Public Property issuedDay As Day = New Day
    Public Property approvedDay As Day = New Day
    Public Property printedDay As Day = New Day
    Public Property completedDay As Day = New Day
    Public Property salesPerson As SalesPerson = New SalesPerson
    Public Property createdByUser As User = New User
    Public Property approvedByUser As User = New User
    Public Property issuedByUser As User = New User
    Public Property printedByUser As User = New User
    Public Property completedByUser As User = New User
    Public Property status As String = ""
    Public Property returns As Double = 0
    Public Property packed As Double = 0
    Public Property issued As Double = 0
    Public Property discount As Double = 0
    Public Property sales As Double = 0
    Public Property damages As Double = 0
    Public Property expenses As Double = 0
    Public Property costOfGoodsSold As Double = 0
    Public Property bankDeposit As Double = 0
    Public Property cash As Double = 0
    Public Property sample As Double = 0
    Public Property deficit As Double = 0
    Public Property packinListDetails As List(Of PackingListDetail) = New List(Of PackingListDetail)


    Public Function getPackingListDate(issueNo As String) As String
        Dim _date As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `issue_date` FROM `packing_list` WHERE `issue_no`='" + issueNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                _date = reader.GetString("issue_date")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return _date
    End Function
    Public Function getSalesPersonName(id As String) As String
        Dim name As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id`, `full_name` FROM `sales_persons` WHERE `id`='" + id + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                name = reader.GetString("full_name")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return name
    End Function

    Public Function getDebt(issueNo As String) As String
        Dim debt As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `debt` FROM `packing_list` WHERE `issue_no`='" + issueNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                debt = reader.GetString("debt")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return debt
    End Function

    Public Function getSalesPersonId(name) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id`,`full_name` FROM `sales_persons` WHERE `full_name`='" + name + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return id
    End Function
    Public Function getSalesPersonIdByIssueNo(issueNo As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id`,`sales_person_id` FROM `packing_list` WHERE `issue_no`='" + issueNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("sales_person_id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return id
    End Function

End Class
