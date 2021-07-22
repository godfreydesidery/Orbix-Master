Imports Devart.Data.MySql

Public Class Receipt
    Public Function makeReceipt(tillNo As String, date_ As String) As Integer
        Dim number As Integer = 0

        'get the maximum receipt number for that particular date
        'and increment it by 1
        'to provide a starting point
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "SELECT  MAX(`receipt_no`)AS `receipt_no` FROM `receipt` WHERE `till_no`='" + tillNo + "' AND `date`='" + date_ + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                number = Val(reader.GetString("receipt_no")) + 1
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return number
    End Function
End Class
