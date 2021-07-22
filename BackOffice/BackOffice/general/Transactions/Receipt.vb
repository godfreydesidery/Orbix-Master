Imports Devart.Data.MySql

Public Class Receipt
    Public GL_AMOUNT As String = ""
    Public GL_VAT As String = ""
    Public GL_DISCOUNT As String = ""
    Public Function getBill(billNo As String) As String
        Dim bill As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "SELECT  `amount`, `discount`, `vat` FROM `sale` WHERE `id`='" + billNo + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                GL_AMOUNT = reader.GetString("amount")
                GL_VAT = reader.GetString("vat")
                GL_DISCOUNT = reader.GetString("discount")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return bill
    End Function
    Public Function getReceiptNo(billNo As String) As String
        Dim receiptNo As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "SELECT   `receipt_no` FROM `receipt` WHERE `bill_no`='" + billNo + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                receiptNo = reader.GetString("receipt_no")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return receiptNo
    End Function
    Public Function getBillNo(tillNo As String, receiptNo As String, date_ As String) As String
        Dim billNo As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "SELECT  `bill_no` FROM `receipt` WHERE `till_no`='" + tillNo + "' AND `receipt_no`='" + receiptNo + "' AND `date`='" + date_ + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                billNo = reader.GetString("bill_no")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return billNo
    End Function
End Class
