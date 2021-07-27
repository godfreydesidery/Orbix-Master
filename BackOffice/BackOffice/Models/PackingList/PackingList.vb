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
    Public Function generateIssueNo() As String
        Dim no As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id` FROM `packing_list` ORDER BY `id` DESC LIMIT 1"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                no = (Val(reader.GetString("id")) + 1).ToString
                Exit While
            End While
            If no = "" Then
                no = "1"
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


    Public Function getPackingListId(issueNo As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id` FROM `packing_list` WHERE `issue_no`='" + issueNo + "'"
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
    Public Function getPackingList(issueNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `packing_list`.`id` AS `id`, `packing_list`.`issue_no` AS `issue_no`, `packing_list`.`issue_date` AS `issue_date`, `packing_list`.`status` AS `status`, `packing_list`.`sales_person_id` AS `sales_person_id`, `packing_list`.`amount_issued` AS `amount_issued`, `packing_list`.`total_returns` AS `total_returns`, `packing_list`.`total_damages` AS `total_damages`, `packing_list`.`total_discounts` AS `total_discounts`, `packing_list`.`total_expenditures` AS `total_expenditures`, `packing_list`.`total_bank_cash` AS `total_bank_cash`, `packing_list`.`debt` AS `debt`, `packing_list`.`sales_person_id` AS `sales_person_id`, `packing_list`.`cost_of_goods` AS `cost_of_goods` FROM `packing_list` WHERE `packing_list`.`issue_no`='" + issueNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                Me.GL_ID = reader.GetString("id")
                Me.GL_ISSUE_NO = reader.GetString("issue_no")
                Me.GL_ISSUE_DATE = reader.GetString("issue_date")
                Me.GL_STATUS = reader.GetString("status")
                Me.GL_SALES_PERSON = getSalesPersonName(reader.GetString("sales_person_id"))
                Me.GL_AMOUNT_ISSUED = reader.GetString("amount_issued")
                Me.GL_TOTAL_RETURNS = reader.GetString("total_returns")
                Me.GL_TOTAL_DAMAGES = reader.GetString("total_damages")
                Me.GL_TOTAL_DISCOUNTS = reader.GetString("total_discounts")
                Me.GL_TOTAL_EXPENDITURES = reader.GetString("total_expenditures")
                Me.GL_TOTAL_BANK_CASH = reader.GetString("total_bank_cash")
                Me.GL_DEBT = reader.GetString("debt")
                Me.GL_COST_OF_GOODS_SOLD = reader.GetString("cost_of_goods")
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
    Public Function getStatus(issueNo As String) As String
        Dim status As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `status` FROM `packing_list` WHERE `issue_no`='" + issueNo + "'"
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

    Public Function addNewPackingList() As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `packing_list`(  `issue_no`, `issue_date`, `status`, `sales_person_id`,`amount_issued`,`total_returns`,`total_damages`,`total_discounts`,`total_expenditures`,`total_bank_cash`,`debt`) VALUES (@issue_no,@issue_date,@status,@sales_person_id,@amount_issued,@total_returns,@total_damages,@total_discounts,@total_expenditures,@total_bank_cash,@debt)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.Add("@issue_no", GL_ISSUE_NO)
            command.Parameters.Add("@issue_date", GL_ISSUE_DATE)
            command.Parameters.Add("@status", GL_STATUS)
            command.Parameters.Add("@sales_person_id", getSalesPersonId(GL_SALES_PERSON))
            command.Parameters.Add("@amount_issued", GL_AMOUNT_ISSUED)
            command.Parameters.Add("@total_returns", GL_TOTAL_RETURNS)
            command.Parameters.Add("@total_damages", GL_TOTAL_DAMAGES)
            command.Parameters.Add("@total_discounts", GL_TOTAL_DISCOUNTS)
            command.Parameters.Add("@total_expenditures", GL_TOTAL_EXPENDITURES)
            command.Parameters.Add("@total_bank_cash", GL_TOTAL_BANK_CASH)
            command.Parameters.Add("@debt", GL_DEBT)
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.ToString)
        End Try
        Return success
    End Function
    Public Function addPackingListDetails() As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `packing_list_details`( `issue_no`, `item_code`, `description`, `price`, `returns`, `packed`, `qty_issued`, `qty_returned`, `qty_sold`, `qty_damaged`,`cprice`) VALUES (@issue_no,@item_code,@description,@price,@returns,@packed,@qty_issued,@qty_returned,@qty_sold,@qty_damaged,@cprice)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text

            command.Parameters.Add("@issue_no", GL_ISSUE_NO)
            command.Parameters.Add("@item_code", GL_ITEM_CODE)
            command.Parameters.Add("@description", GL_DESCRIPTION)
            command.Parameters.Add("@price", GL_PRICE)
            command.Parameters.Add("@returns", GL_RETURNS)
            command.Parameters.Add("@packed", GL_PACKED)
            command.Parameters.Add("@qty_issued", GL_TOTAL_ISSUED)
            command.Parameters.Add("@qty_returned", GL_QTY_RETURNED)
            command.Parameters.Add("@qty_sold", GL_QTY_SOLD)
            command.Parameters.Add("@qty_damaged", GL_QTY_DAMAGED)
            command.Parameters.Add("@cprice", GL_C_PRICE)

            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function editPackingListDetails(issueNo As String, itemCode As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `packing_list_details` SET `price`='" + GL_PRICE.ToString + "', `returns`='" + GL_RETURNS.ToString + "', `packed`='" + GL_PACKED.ToString + "', `qty_issued`='" + GL_TOTAL_ISSUED.ToString + "',`qty_returned`='" + GL_QTY_RETURNED.ToString + "',`qty_sold`='" + GL_QTY_SOLD.ToString + "',`qty_damaged`='" + GL_QTY_DAMAGED.ToString + "',`cprice`='" + GL_C_PRICE.ToString + "' WHERE `issue_no`='" + issueNo + "' AND `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.ToString)
        End Try
        Return success
    End Function
    Public Function approvePackingList(issueNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `packing_list` SET`status`='APPROVED' WHERE `issue_no`='" + issueNo + "'"
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
    Public Function printPackingList(issueNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `packing_list` SET`status`='PRINTED' WHERE `issue_no`='" + issueNo + "'"
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
    Public Function completePackingList(issueNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `packing_list` SET`status`='COMPLETED' WHERE `issue_no`='" + issueNo + "'"
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
    Public Function cancelPackingList(issueNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `packing_list` SET`status`='CANCELED' WHERE `issue_no`='" + issueNo + "'"
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
    Public Function archivePackingList(issueNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `packing_list` SET`status`='ARCHIVED' WHERE `issue_no`='" + issueNo + "'"
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
    Public Function deletePackingListDetails(issueNo As String, itemCode As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `packing_list_details` WHERE `issue_no`='" + issueNo + "' AND `item_code`='" + itemCode + "'"
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
    Public Function isPackingListExist(issueNo As String) As Boolean
        Dim exist As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `issue_no` FROM `packing_list` WHERE `issue_no`='" + issueNo + "'"
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
    Public Function changeStatus(issueNo As String, status As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `packing_list` SET `status`='" + status + "' WHERE `issue_no`='" + issueNo + "'"
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
    Public Function editPackingList(issueNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `packing_list` SET `sales_person_id`='" + getSalesPersonId(GL_SALES_PERSON) + "',`amount_issued`='" + GL_AMOUNT_ISSUED.ToString + "',`total_returns`='" + GL_TOTAL_RETURNS.ToString + "',`total_damages`='" + GL_TOTAL_DAMAGES.ToString + "',`total_discounts`='" + GL_TOTAL_DISCOUNTS.ToString + "',`total_expenditures`='" + GL_TOTAL_EXPENDITURES.ToString + "',`total_bank_cash`='" + GL_TOTAL_BANK_CASH.ToString + "',`debt`='" + GL_DEBT.ToString + "',`cost_of_goods`='" + GL_COST_OF_GOODS_SOLD.ToString + "' WHERE `issue_no`='" + issueNo + "'"
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

    Public Function deletePackingList(issueNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `packing_list` WHERE `issue_no`='" + issueNo + "';DELETE FROM `packing_list_details` WHERE `issue_no`='" + issueNo + "'"
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
