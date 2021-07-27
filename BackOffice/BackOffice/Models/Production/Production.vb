Imports Devart.Data.MySql

Public Class Production



    Inherits Item

    Public Shared GLOBAL_ID As String = ""
    Public Shared GLOBAL_PRODUCTION_ID As String = ""
    Public Shared GLOBAL_SUMMARY As String = ""
    Public Shared GLOBAL_QTY As String = ""
    Public Shared GLOBAL_STATUS As String = ""

    Public GL_ID As String = ""
    Public GL_PRODUCTION_NO As String = ""
    Public GL_DATE As String = ""
    Public GL_STATUS As String = ""
    Public GL_OPERATOR As String = ""
    Public GL_PRODUCT_NAME As String = ""
    Public GL_BATCH_SIZE As Double = 0
    Public GL_UOM As String = ""

    Public Function getProduction(processNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id`, `production_no`, `product_name`, `batch_size`, `uom`, `status`, `date` FROM `productions` WHERE `production_no`='" + processNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                Me.GL_ID = reader.GetString("id")
                Me.GL_PRODUCTION_NO = reader.GetString("production_no")
                Me.GL_PRODUCT_NAME = reader.GetString("product_name")
                Me.GL_DATE = reader.GetString("date")
                Me.GL_STATUS = reader.GetString("status")
                Me.GL_BATCH_SIZE = reader.GetString("batch_size")
                Me.GL_UOM = reader.GetString("uom")
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

    Public Function getStatus(id As String) As String
        Dim status As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `status` FROM `productions` WHERE `id`='" + id + "'"
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

    Public Function addFinishedProduct(productionId As String, itemCode As String, description As String, qty As Double) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `finished_products`( `production_id`, `item_code`, `description`, `qty`) VALUES (@production_id,@item_code,@description,@qty)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.Add("@production_id", productionId)
            command.Parameters.Add("@item_code", itemCode)
            command.Parameters.Add("@description", description)
            command.Parameters.Add("@qty", qty)
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function

    Public Function editFinishedProduct(productionId As String, itemCode As String, qty As Double) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `finished_products` SET`qty`='" + qty.ToString + "' WHERE `production_id`='" + productionId + "' AND `item_code`='" + itemCode + "'"
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

    Public Function isFinishedProductExist(productionId As String, itemCode As String) As Boolean
        Dim exist As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `item_code` FROM `finished_products` WHERE `production_id`='" + productionId + "' AND `item_code`='" + itemCode + "'"
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
    Public Function registerProduction(date_ As String, itemCode As String, price As Double, qty As Double, balance As Double, reference As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "INSERT INTO `item_production`(`date`,`item_code`, `price`, `qty`,`balance`,`reference`) VALUES (@date,@item_code,@price,@qty,@balance,@reference)"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@date", date_)
            command.Parameters.AddWithValue("@item_code", itemCode)
            command.Parameters.AddWithValue("@price", price)
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
