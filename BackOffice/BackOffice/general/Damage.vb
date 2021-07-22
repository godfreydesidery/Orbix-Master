Imports Devart.Data.MySql

Public Class Damage
    Public Function registerDamage(date_ As String, itemCode As String, qty As Double, price As Double, reference As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "INSERT INTO `damages`(`date`,`item_code`,`qty`,`price`,`reference`) VALUES (@date,@item_code,@qty,@price,@reference)"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@date", date_)
            command.Parameters.AddWithValue("@item_code", itemCode)
            command.Parameters.AddWithValue("@qty", qty)
            command.Parameters.AddWithValue("@price", price)
            command.Parameters.AddWithValue("@reference", reference)
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
End Class
