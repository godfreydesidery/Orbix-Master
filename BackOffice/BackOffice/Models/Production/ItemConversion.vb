Imports Devart.Data.MySql

Public Class ItemConversion

    Public GL_ID As String = ""
    Public GL_CONVERSION_NO As String = ""
    Public GL_DATE As String = ""
    Public GL_STATUS As String = ""
    Public GL_REASON As String = ""


    Public GL_RAW_ITEM_CODE As String = ""
    Public GL_RAW_DESCRIPTION As String = ""
    Public GL_RAW_QTY As Double = 0
    Public GL_RAW_PRICE As Double = 0

    Public GL_END_ITEM_CODE As String = ""
    Public GL_END_DESCRIPTION As String = ""
    Public GL_END_QTY As Double = 0
    Public GL_END_PRICE As Double = 0



    Public Function generateConversionNo() As String
        Dim no As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id` FROM `item_conversion` ORDER BY `id` DESC LIMIT 1"
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
    Public Function getStatus(conversionNo As String) As String
        Dim status As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `status` FROM `item_conversion` WHERE `conversion_no`='" + conversionNo + "'"
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
    Public Function addNewConversion() As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `item_conversion`(`conversion_no`, `date`, `reason`, `status`) VALUES (@conversion_no,@date,@reason,@status)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.Add("@conversion_no", GL_CONVERSION_NO)
            command.Parameters.Add("@date", GL_DATE)
            command.Parameters.Add("@reason", GL_REASON)
            command.Parameters.Add("@status", "PENDING")
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.ToString)
        End Try
        Return success
    End Function
    Public Function editConversion(conversionNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `item_conversion` SET `date`='" + GL_DATE.ToString + "',`reason`='" + GL_REASON + "' WHERE `conversion_no`='" + conversionNo + "'"
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
    Public Function isItemConversionExist(conversionNo As String) As Boolean
        Dim exist As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `conversion_no` FROM `item_conversion` WHERE `conversion_no`='" + conversionNo + "'"
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

    Public Function getItemConversion(conversionNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id`, `conversion_no`, `date`, `reason`, `status`, `user_id` FROM `item_conversion` WHERE `conversion_no`='" + conversionNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                Me.GL_ID = reader.GetString("id")
                Me.GL_CONVERSION_NO = reader.GetString("conversion_no")
                Me.GL_DATE = reader.GetString("date")
                Me.GL_STATUS = reader.GetString("status")
                Me.GL_REASON = reader.GetString("reason")
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
    Public Function addItemToConvert() As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `items_to_convert`(`item_code`, `description`, `qty`, `price`, `conversion_id`) VALUES (@item_code,@description,@qty,@price,@conversion_id)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text

            command.Parameters.Add("@item_code", GL_RAW_ITEM_CODE)
            command.Parameters.Add("@description", GL_RAW_DESCRIPTION)
            command.Parameters.Add("@qty", GL_RAW_QTY)
            command.Parameters.Add("@price", GL_RAW_PRICE)
            command.Parameters.Add("@conversion_id", GL_ID)

            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function editItemToConvert(conversionId As String, itemCode As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `items_to_convert` SET `qty`='" + GL_RAW_QTY.ToString + "' WHERE `conversion_id`='" + conversionId + "' AND `item_code`='" + itemCode + "'"
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

    Public Function addConverted() As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `converted`(`item_code`, `description`, `qty`, `price`, `conversion_id`) VALUES (@item_code,@description,@qty,@price,@conversion_id)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text

            command.Parameters.Add("@item_code", GL_END_ITEM_CODE)
            command.Parameters.Add("@description", GL_END_DESCRIPTION)
            command.Parameters.Add("@qty", GL_END_QTY)
            command.Parameters.Add("@price", GL_END_PRICE)
            command.Parameters.Add("@conversion_id", GL_ID)

            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function editConverted(conversionId As String, itemCode As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `converted` SET `qty`='" + GL_END_QTY.ToString + "' WHERE `conversion_id`='" + conversionId + "' AND `item_code`='" + itemCode + "'"
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

    Public Function approveConversion(conversionNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `item_conversion` SET`status`='APPROVED' WHERE `conversion_no`='" + conversionNo + "'"
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

    Public Function cancelConversion(conversionNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `item_conversion` SET`status`='CANCELED' WHERE `conversion_no`='" + conversionNo + "'"
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

    Public Function printConversion(conversionNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `item_conversion` SET`status`='PRINTED' WHERE `conversion_no`='" + conversionNo + "'"
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

    Public Function completeConversion(conversionNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `item_conversion` SET`status`='COMPLETED' WHERE `conversion_no`='" + conversionNo + "'"
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
    Public Function archiveConversion(conversionNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `item_conversion` SET`status`='ARCHIVED' WHERE `conversion_no`='" + conversionNo + "'"
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
