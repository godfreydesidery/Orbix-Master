Imports Devart.Data.MySql

Public Class SaleInvoice
    Inherits Item
    Public GL_INVOICE_NO As String = ""
    Public GL_INVOICE_DATE As String = ""
    Public GL_VALIDITY_PERIOD As String = ""
    Public GL_VALID_UNTIL As String = ""
    Public GL_CONTACT As String = ""
    Public GL_NAME As String = ""
    Public GL_STATUS As String = ""
    Public GL_USER_ID As String = ""
    Public GL_ITEM_LONG_DESCRIPTION As String = ""
    Public GL_QUANTITY As String = ""
    Public GL_PACK_SIZE As Double = 0
    Public GL_UNIT_COST_PRICE As Double = 0
    Public GL_UNIT_SELLING_PRICE As Double = 0
    Public GL_STOCK_SIZE As Integer = 0
    Public Function generateInvoiceNo() As String
        Dim no As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `invoice_id` FROM `sale_invoices` ORDER BY `invoice_id` DESC LIMIT 1"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                no = "INV" + (Val(reader.GetString("invoice_id")) + 1).ToString
                Exit While
            End While
            If no = "" Then
                no = "INV1"
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return no
    End Function
    Public Function getInvoiceTotal(invoiceNo As String)
        Dim total As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT  (`quantity`* `unit_cost_price`) AS `total` FROM `sale_invoice_details` WHERE `sale_invoice_no`='" + invoiceNo + "'"
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


    Public Function getInvoiceId(invoiceNo As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `invoice_id` FROM `sale_invoices` WHERE `sale_invoice_no`='" + invoiceNo + "'"
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
    Public Function getSaleInvoice(invoiceNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `invoice_id`, `invoice_no`, `invoice_date`, `contact`, `name`, `status`, `user_id` FROM `sale_invoices` WHERE `invoice_no`='" + invoiceNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                Me.GL_INVOICE_NO = reader.GetString("invoice_no")
                Me.GL_INVOICE_DATE = reader.GetString("invoice_date")
                Me.GL_CONTACT = reader.GetString("contact")
                Me.GL_NAME = reader.GetString("name")
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

    Public Function getInvoiceDetails(invoiceNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `sn`, `invoice_no`, `item_code`, `quantity`, `unit_cost_price`` FROM `sale_invoice_details` WHERE `invoice_no`='" + invoiceNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                Me.GL_INVOICE_NO = reader.GetString("invoice_no")
                Me.GL_ITEM_CODE = reader.GetString("item_code")
                Me.GL_QUANTITY = reader.GetString("quantity")
                Me.GL_UNIT_COST_PRICE = reader.GetString("unit_cost_price")
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
    Public Function addNewInvoice() As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `sale_invoices`(  `invoice_no`, `invoice_date`, `contact`, `name`, `status`, `user_id`) VALUES (@invoice_no,@invoice_date,@contact,@name,@status,@user_id)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.Add("@invoice_no", GL_INVOICE_NO)
            command.Parameters.Add("@invoice_date", GL_INVOICE_DATE)
            command.Parameters.Add("@contact", GL_CONTACT)
            command.Parameters.Add("@name", GL_NAME)
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
    Public Function addInvoiceDetails() As Boolean
        Dim success As Boolean = False
        Dim present As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `sn`, `invoice_no`, `item_code`, `quantity`, `cost_price` FROM `sale_invoice_details` WHERE `invoice_no`='" + GL_INVOICE_NO + "' AND `item_code` ='" + GL_ITEM_CODE + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                present = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
            Return success
            Exit Function
        End Try
        If present = True Then
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                Dim codeQuery As String = "UPDATE `sale_invoice_details` SET`quantity`=`quantity`+'" + GL_QUANTITY + "' WHERE `invoice_no`='" + GL_INVOICE_NO + "' AND `item_code`='" + GL_ITEM_CODE + "'"
                conn.Open()
                command.CommandText = codeQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                conn.Close()
                success = True
                Return success
                Exit Function
            Catch ex As Exception
                success = False
                MsgBox(ex.Message)
                Return success
                Exit Function
            End Try

        End If

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `sale_invoice_details`( `invoice_no`, `item_code`, `quantity`, `cost_price`, `selling_price`) VALUES (@invoice_no,@item_code,@quantity,@cost_price,@selling_price)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.Add("@invoice_no", GL_INVOICE_NO)
            command.Parameters.Add("@item_code", GL_ITEM_CODE)
            command.Parameters.Add("@quantity", GL_QUANTITY)
            command.Parameters.Add("@cost_price", GL_UNIT_COST_PRICE)
            command.Parameters.Add("@selling_price", GL_UNIT_SELLING_PRICE)
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
            Return success
        End Try
        Return success
    End Function
    Public Function editInvoiceDetails(invoiceNo As String, itemCode As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `sale_invoice_details` SET`quantity`='" + GL_QUANTITY + "',`unit_cost_price`='" + GL_COST_PRICE + "' WHERE `invoice_no`='" + invoiceNo + "' AND `item_code`='" + itemCode + "'"
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
    Public Function deleteInvoiceDetails(invoiceNo As String, itemCode As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `sale_invoice_details` WHERE `invoice_no`='" + invoiceNo + "' AND `item_code`='" + itemCode + "'"
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
    Public Function isInvoiceExist(invoiceNo As String) As Boolean
        Dim exist As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `invoice_no` FROM `sale_invoices` WHERE `invoice_no`='" + invoiceNo + "'"
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
    Public Function changeStatus(invoiceNo As String, status As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `sale_invoices` SET `status`='" + status + "' WHERE `invoice_no`='" + invoiceNo + "'"
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
    Public Function editInvoice(invoiceNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `sale_invoices` SET`invoice_date`='" + GL_INVOICE_DATE + "',`contact`='" + GL_CONTACT + "',`name`='" + GL_NAME + "',`status`='" + GL_STATUS + "',`user_id`='" + GL_USER_ID + "' WHERE `invoice_no`='" + invoiceNo + "'"
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

    Public Function deleteSaleInvoice(invoiceNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `sale_invoices` WHERE `invoice_no`='" + invoiceNo + "';DELETE FROM `sale_invoice_details` WHERE `invoice_no`='" + invoiceNo + "'"
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
