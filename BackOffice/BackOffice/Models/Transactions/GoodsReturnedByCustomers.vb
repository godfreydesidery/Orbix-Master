Imports Devart.Data.MySql

Public Class GoodsReturnedByCustomers
    Public Function checkValid(billNo As String, itemCode As String, qtyReturned As Double, qtyPurchased As Double) As Boolean
        Dim valid As Boolean = False
        ''
        Dim alreadyReturned As Double = 0
        '
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `sn`, `bill_no`, `item_code`, `qty_returned` FROM `returned_goods` WHERE `bill_no`='" + billNo + "' AND `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                alreadyReturned = Val(reader.GetString("qty_returned"))
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If qtyPurchased - qtyReturned >= 0 Then
            valid = True
        End If
        Return valid
    End Function
    Public Function returnItem(billNo As String, itemCode As String, qty As Double, saleId As String) As Boolean
        Dim success As Boolean = False
        Dim exist As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `sn`, `bill_no`, `item_code`, `qty_returned` FROM `returned_goods` WHERE `bill_no`='" + billNo + "' AND `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                exist = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            If exist = False Then
                query = "INSERT INTO `returned_goods`(`bill_no`, `item_code`, `qty_returned`) VALUES (@bill_no,@item_code,@qty)" 'insert query
            Else
                query = "UPDATE `returned_goods` SET`bill_no`='" + billNo + "',`item_code`='" + itemCode + "',`qty_returned`=`qty_returned`+" + qty.ToString + " WHERE `bill_no`='" + billNo + "' AND `item_code`='" + itemCode + "'" 'update query
            End If
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@bill_no", billNo)
            command.Parameters.AddWithValue("@item_code", itemCode)
            command.Parameters.AddWithValue("@qty", qty)
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try

        'update inventory
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "UPDATE `inventorys` SET `qty`=`qty`+" + qty.ToString + " WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'update sales
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "UPDATE `sale_details` SET `qty`=`qty`-" + qty.ToString + " WHERE `item_code`='" + itemCode + "' AND `sale_id`='" + billNo + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim amountToDeduct As Double = 0

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "SELECT `discounted_price` FROM `sale_details` WHERE `item_code`='" + itemCode + "' AND `sale_id`='" + billNo + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                amountToDeduct = Val(reader.GetString("discounted_price")) * qty
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



        'update amount
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "UPDATE `sale_details` SET `amount`=`discounted_price`*`qty` WHERE `item_code`='" + itemCode + "' AND `sale_id`='" + billNo + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "UPDATE `sale` SET `amount`=`amount`-" + amountToDeduct.ToString + " WHERE `id`='" + billNo + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
End Class
