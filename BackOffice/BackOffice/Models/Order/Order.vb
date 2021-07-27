Imports Devart.Data.MySql

Public Class Order
    Inherits Item
    Public GL_ORDER_NO As String = ""
    Public GL_ORDER_DATE As String = ""
    Public GL_VALIDITY_PERIOD As String = ""
    Public GL_VALID_UNTIL As String = ""
    Public GL_SUPPLIER_CODE As String = ""
    Public GL_STATUS As String = ""
    Public GL_USER_ID As String = ""
    Public GL_ITEM_LONG_DESCRIPTION As String = ""
    Public GL_QUANTITY As String = ""
    Public GL_PACK_SIZE As Double = 0
    Public GL_UNIT_COST_PRICE As Double = 0
    Public GL_STOCK_SIZE As Integer = 0
    Public Function generateOrderNo() As String
        Dim no As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `order_id` FROM `orders` ORDER BY `order_id` DESC LIMIT 1"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                no = "LPO" + (Val(reader.GetString("order_id")) + 1).ToString
                Exit While
            End While
            If no = "" Then
                no = "LPO1"
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return no
    End Function
    Public Function getOrderTotal(orderno As String)
        Dim total As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT  (`quantity`* `unit_cost_price`) AS `total` FROM `order_details` WHERE `order_no`='" + orderno + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                total = total + Val(reader.GetString("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return total
    End Function
    Public Function generateOrderNooo() As String
        Dim no As String = ""

        Dim KeyGen As RandomKeyGenerator
        Dim NumKeys As Integer
        Dim i_Keys As Integer
        Dim RandomKey As String = ""

        ' MODIFY THIS TO GET MORE KEYS    - LAITH - 27/07/2005 22:48:30 -
        NumKeys = 6

        KeyGen = New RandomKeyGenerator
        KeyGen.KeyLetters = "1234567890"
        KeyGen.KeyNumbers = "0123456789"
        KeyGen.KeyChars = 3
        For i_Keys = 1 To NumKeys
            RandomKey = KeyGen.Generate()
        Next
        Dim str As String = ""
        While str.Length <> 3
            str = Math.Ceiling(VBMath.Rnd * 1000)
            If str.Length = 3 Then
                Exit While
            End If
        End While

        no = (New Day).getCurrentDay.ToString("yyyyMMdd") + "-" + str + "-" + RandomKey.ToString
        Return no
    End Function
    Public Overloads Function getSupplierID(grnNo As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `orders`.`supplier_id` FROM `goods_received_note`,`orders` WHERE `orders`.`order_no`=`goods_received_note`.`order_no` AND  `goods_received_note`.`grn_no`='" + grnNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("supplier_id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return id
    End Function
    Public Function getOrderId(orderNo As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `order_id` FROM `orders` WHERE `order_no`='" + orderNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("order_id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return id
    End Function
    Public Function getOrder(orderNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `order_id`, `order_no`, `order_date`, `validity_period`, `valid_until`, `supplier_id`, `status`, `user_id` FROM `orders` WHERE `order_no`='" + orderNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                Me.GL_ORDER_NO = reader.GetString("order_no")
                Me.GL_ORDER_DATE = reader.GetString("order_date")
                Me.GL_VALIDITY_PERIOD = reader.GetString("validity_period")
                Me.GL_VALID_UNTIL = reader.GetString("valid_until")
                Me.GL_SUPPLIER_ID = reader.GetString("supplier_id")
                Me.GL_SUPPLIER_CODE = (New Supplier).getSupplierCode(Me.GL_SUPPLIER_ID, "")
                Me.GL_STATUS = reader.GetString("status")
                Me.GL_USER_ID = reader.GetString("user_id")
                success = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function getStatus(orderNo As String) As String
        Dim status As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `order_id`, `order_no`, `order_date`, `validity_period`, `valid_until`, `supplier_id`, `status`, `user_id` FROM `orders` WHERE `order_no`='" + orderNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                status = reader.GetString("status")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return status
    End Function
    Public Function getOrderDetails(orderNo As String) As Boolean 'this does not work 
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `sn`, `order_no`, `item_code`, `quantity`, `unit_cost_price`, `stock_size` FROM `order_details` WHERE `order_no`='" + orderNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                Me.GL_ORDER_NO = reader.GetString("order_no")
                Me.GL_ITEM_CODE = reader.GetString("item_code")
                Me.GL_QUANTITY = reader.GetString("quantity")
                Me.GL_UNIT_COST_PRICE = reader.GetString("unit_cost_price")
                Me.GL_STOCK_SIZE = reader.GetString("stock_size")
                Dim item As New Item
                item.searchItem(Me.GL_ITEM_CODE)
                Me.GL_PACK_SIZE = item.GL_PCK
            End While
            conn.Close()
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function addNewOrder() As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `orders`(  `order_no`, `order_date`, `validity_period`, `valid_until`, `supplier_id`,  `status`,`user_id`) VALUES (@order_no,@order_date,@validity_period,@valid_until,@supplier_id,@status,@user_id)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.Add("@order_no", GL_ORDER_NO)
            command.Parameters.Add("@order_date", GL_ORDER_DATE)
            command.Parameters.Add("@validity_period", GL_VALIDITY_PERIOD)
            command.Parameters.Add("@valid_until", GL_VALID_UNTIL)
            command.Parameters.Add("@supplier_id", GL_SUPPLIER_ID)
            command.Parameters.Add("@status", GL_STATUS)
            command.Parameters.Add("@user_id", GL_USER_ID)
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function addOrderDetails() As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `order_details`( `order_no`, `item_code`, `quantity`, `unit_cost_price`, `stock_size`) VALUES (@order_no,@item_code,@quantity,@unit_cost_price,@stock_size)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.Add("@order_no", GL_ORDER_NO)
            command.Parameters.Add("@item_code", GL_ITEM_CODE)
            command.Parameters.Add("@quantity", GL_QUANTITY)
            command.Parameters.Add("@unit_cost_price", GL_UNIT_COST_PRICE)
            command.Parameters.Add("@stock_size", GL_STOCK_SIZE)
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function editOrderDetails(orderNo As String, itemCode As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `order_details` SET`quantity`='" + GL_QUANTITY + "',`unit_cost_price`='" + GL_COST_PRICE + "',`stock_size`='" + GL_STOCK_SIZE + "' WHERE `order_no`='" + orderNo + "' AND `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function approveOrder(orderNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `orders` SET`status`='APPROVED' WHERE `order_no`='" + orderNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function cancelOrder(orderNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `orders` SET`status`='CANCELED' WHERE `order_no`='" + orderNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function archiveOrder(orderNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `orders` SET`status`='ARCHIVED' WHERE `order_no`='" + orderNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function deleteOrderDetails(orderNo As String, itemCode As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `order_details` WHERE `order_no`='" + orderNo + "' AND `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function isOrderExist(orderNo As String) As Boolean
        Dim exist As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `order_no` FROM `orders` WHERE `order_no`='" + orderNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                exist = True
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return exist
    End Function
    Public Function changeStatus(orderNo As String, status As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `orders` SET `status`='" + status + "' WHERE `order_no`='" + orderNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function editOrder(orderNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `orders` SET`order_date`='" + GL_ORDER_DATE + "',`validity_period`='" + GL_VALIDITY_PERIOD + "',`valid_until`='" + GL_VALID_UNTIL + "',`status`='" + GL_STATUS + "',`user_id`='" + GL_USER_ID + "' WHERE `order_no`='" + orderNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function

    Public Function deleteOrder(orderNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `orders` WHERE `order_no`='" + orderNo + "';DELETE FROM `order_details` WHERE `order_no`='" + orderNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
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
