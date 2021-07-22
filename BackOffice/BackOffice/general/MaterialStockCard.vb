Imports Devart.Data.MySql

Public Class MaterialStockCard
    Public Function qtyIn(date_ As String, materialCode As String, qty As Double, balance As Double, reference As String) As Boolean
        If qty = 0 Then Return False
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "INSERT INTO `material_stock_cards`(`date`,`material_code`,`qty_in`,`balance`,`reference`) VALUES (@date,@material_code,@qty,@balance,@reference)"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@date", date_)
            command.Parameters.AddWithValue("@material_code", materialCode)
            command.Parameters.AddWithValue("@qty", qty)
            command.Parameters.AddWithValue("@balance", balance)
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
    Public Function qtyOut(date_ As String, materialCode As String, qty As Double, balance As Double, reference As String) As Boolean
        If qty = 0 Then Return False
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "INSERT INTO `material_stock_cards`(`date`,`material_code`,`qty_out`,`balance`,`reference`) VALUES (@date,@material_code,@qty,@balance,@reference)"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@date", date_)
            command.Parameters.AddWithValue("@material_code", materialCode)
            command.Parameters.AddWithValue("@qty", qty)
            command.Parameters.AddWithValue("@balance", balance)
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
