Imports Devart.Data.MySql

Public Class SupplierService
    Public GL_ITEM As String = ""
    Public GL_ITEM_CODE As String = ""
    Public GL_SERVICE_DESCRIPTION As String = ""
    Public GL_PACKING As String = ""
    Public GL_COST_PRICE_VAT_INCL As String = ""
    Public GL_COST_PRICE_VAT_EXCL As String = ""
    Public GL_VAT_NO As String = ""
    Public GL_TERMS_OF_PAYMENT As String = ""
    Public Function getServiceID(itemCode As String, supplierID As String) As String
        Dim id As String = ""

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `supplier_item_id`  FROM `supplier_item` WHERE `item_code`='" + itemCode + "' AND `supplier_id`='" + supplierID + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("supplier_item_id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'added = False
            MsgBox(ex.Message)
        End Try
        Return id
    End Function
    Public Function getGetItemCode(barCode As String) As String
        Dim code As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `item_scan_code`, `item_code` FROM `bar_codes` WHERE `item_scan_code`='" + barCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                code = reader.GetString("item_code")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'added = False
            MsgBox(ex.Message)
        End Try
        Return code
    End Function
    Public Function addNewService(itemCode As String, supplierID As String, serviceDescr As String, packing As String, costPriceVatIncl As String, costPriceVatExcl As String, vatNo As String, termsOfPayment As String) As Boolean
        Dim added As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'Dim reader As MySqlDataReader
            'create bar code
            Dim codeQuery As String = "INSERT INTO `supplier_item`( `supplier_id`, `item_code`, `service_description`, `vat_no`, `packing`, `cost_price_vat_incl`, `cost_price_vat_excl`, `terms_of_payment`) VALUES (@supplier_id,@item_code,@service_descr,@vat_no,@packing,@cost_price_vat_incl,@cost_price_vat_excl,@terms_of_payment)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@supplier_id", supplierID)
            command.Parameters.AddWithValue("@item_code", itemCode)
            command.Parameters.AddWithValue("@service_descr", serviceDescr)
            command.Parameters.AddWithValue("@packing", packing)
            command.Parameters.AddWithValue("@cost_price_vat_incl", costPriceVatIncl)
            command.Parameters.AddWithValue("@cost_price_vat_excl", costPriceVatExcl)
            command.Parameters.AddWithValue("@vat_no", vatNo)
            command.Parameters.AddWithValue("@terms_of_payment", termsOfPayment)

            command.ExecuteNonQuery()
            conn.Close()
            added = True
        Catch ex As Exception
            added = False
            MsgBox(ex.Message)
        End Try
        Return added
    End Function
    Public Function editService(serviceID As String, serviceDescr As String, packing As String, costPriceVatIncl As String, costPriceVatExcl As String, vatNo As String, termsOfPayment As String) As Boolean
        Dim edited As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'Dim reader As MySqlDataReader
            'create bar code
            Dim codeQuery As String = "UPDATE `supplier_item` SET `service_description`='" + serviceDescr + "',`vat_no`='" + vatNo + "',`packing`='" + packing + "',`cost_price_vat_incl`='" + costPriceVatIncl + "',`cost_price_vat_excl`='" + costPriceVatExcl + "',`terms_of_payment`='" + termsOfPayment + "' WHERE `supplier_item_id`='" + serviceID + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            edited = True
        Catch ex As Exception
            edited = False
            MsgBox(ex.Message)
        End Try
        If serviceID = "" Then
            edited = False
        End If
        Return edited
    End Function
    Public Function deleteService(serviceID As String) As Boolean
        Dim deleted As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "DELETE FROM `supplier_item` WHERE `supplier_item_id`='" + serviceID + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            deleted = True
        Catch ex As Exception
            deleted = False
            MsgBox(ex.Message)
        End Try

        Return deleted
    End Function
    Public Function searchService(itemCode As String, supplierID As String) As Boolean
        Dim found As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim reader As MySqlDataReader

            Dim query As String = "SELECT `supplier_id`, `item_code`, `service_description`, `vat_no`, `packing`, `cost_price_vat_incl`, `cost_price_vat_excl`, `terms_of_payment` FROM `supplier_item` WHERE `supplier_id`='" + supplierID + "' AND `item_code`='" + itemCode + "'"

            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            reader = command.ExecuteReader
            While reader.Read
                Me.GL_SERVICE_DESCRIPTION = reader.GetString("service_description")
                Me.GL_VAT_NO = reader.GetString("vat_no")
                Me.GL_PACKING = reader.GetString("packing")
                Me.GL_COST_PRICE_VAT_INCL = reader.GetString("cost_price_vat_incl")
                Me.GL_COST_PRICE_VAT_EXCL = reader.GetString("cost_price_vat_excl")
                Me.GL_TERMS_OF_PAYMENT = reader.GetString("terms_of_payment")
                found = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return found
    End Function
End Class
