Imports Devart.Data.MySql

Public Class CustomerClaim
    Public GL_ID As String = ""
    Public GL_CLAIM_NO As String = ""
    Public GL_CLAIM_DATE As String = ""
    Public GL_SETTLEMENT_DATE As String = ""
    Public GL_STATUS As String = ""
    Public GL_INVOICE_NO As String = ""
    Public GL_ISSUE_NO As String = ""
    Public GL_CUSTOMER_NAME As String = ""
    Public GL_CUSTOMER_ADDRESS As String = ""
    Public GL_CUSTOMER_PHONE As String = ""
    Public GL_RECEIVED_BY As String = ""
    Public GL_RETURNED_BY As String = ""
    Public GL_OTHER As String = ""


    Public GL_CLAIM_SN As String = ""
    Public GL_CLAIM_ITEM_CODE As String = ""
    Public GL_CLAIM_DESCRIPTION As String = ""
    Public GL_CLAIM_QTY As Double = 0
    Public GL_CLAIM_PRICE As Double = 0
    Public GL_CLAIM_REASON As String = ""
    Public GL_CLAIM_REMARKS As String = ""
    Public GL_CLAIM_TYPE As String = ""

    Public GL_REPLACEMENT_SN
    Public GL_REPLACEMENT_ITEM_CODE As String = ""
    Public GL_REPLACEMENT_DESCRIPTION As String = ""
    Public GL_REPLACEMENT_QTY As Double = 0
    Public GL_REPLACEMENT_PRICE As Double = 0



    Public Function generateClaimNo() As String
        Dim no As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id` FROM `customer_claims` ORDER BY `id` DESC LIMIT 1"
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
    Public Function getStatus(claimNo As String) As String
        Dim status As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `status` FROM `customer_claims` WHERE `claim_no`='" + claimNo + "'"
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
    Public Function addNewClaim() As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `customer_claims`(
                                                                    `claim_no`,
                                                                    `claim_date`,
                                                                    `settlement_date`,
                                                                    `status`,
                                                                    `customer_name`,
                                                                    `customer_phone`,
                                                                    `customer_address`,
                                                                    `issue_no`,
                                                                    `invoice_no`,
                                                                    `other`,
                                                                    `returned_by`,
                                                                    `received_by`)
                                                                VALUES (
                                                                    @claim_no,
                                                                    @claim_date,
                                                                    @settlement_date,
                                                                    @status,
                                                                    @customer_name,
                                                                    @customer_phone,
                                                                    @customer_address,
                                                                    @issue_no,
                                                                    @invoice_no,
                                                                    @other,
                                                                    @returned_by,
                                                                    @received_by
                                                                    )"

            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.Add("@claim_no", GL_CLAIM_NO)
            command.Parameters.Add("@claim_date", GL_CLAIM_DATE)
            command.Parameters.Add("@settlement_date", GL_SETTLEMENT_DATE)
            command.Parameters.Add("@status", "PENDING")
            command.Parameters.Add("@customer_name", GL_CUSTOMER_NAME)
            command.Parameters.Add("@customer_phone", GL_CUSTOMER_PHONE)
            command.Parameters.Add("@customer_address", GL_CUSTOMER_ADDRESS)
            command.Parameters.Add("@issue_no", GL_ISSUE_NO)
            command.Parameters.Add("@invoice_no", GL_INVOICE_NO)
            command.Parameters.Add("@other", GL_OTHER)
            command.Parameters.Add("@returned_by", GL_RETURNED_BY)
            command.Parameters.Add("@received_by", GL_RECEIVED_BY)
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.ToString)
        End Try
        Return success
    End Function
    Public Function editClaim(claimNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `customer_claims` 
                                                        SET 
                                                            `claim_date`='" + GL_CLAIM_DATE + "',
                                                            `settlement_date`='" + GL_SETTLEMENT_DATE + "',
                                                            `status`='" + GL_STATUS + "',
                                                            `customer_name`='" + GL_CUSTOMER_NAME + "',
                                                            `customer_phone`='" + GL_CUSTOMER_PHONE + "',
                                                            `customer_address`='" + GL_CUSTOMER_ADDRESS + "',
                                                            `issue_no`='" + GL_ISSUE_NO + "',
                                                            `invoice_no`='" + GL_INVOICE_NO + "',
                                                            `other`='" + GL_OTHER + "',
                                                            `returned_by`='" + GL_RETURNED_BY + "',
                                                            `received_by`='" + GL_RECEIVED_BY + "'
                                                        WHERE
                                                            `claim_no`='" + claimNo + "'"
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
    Public Function isClaimExist(claimNo As String) As Boolean
        Dim exist As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `claim_no` FROM `customer_claims` WHERE `claim_no`='" + claimNo + "'"
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

    Public Function getCustomerClaim(claimNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT 
                                        `id`, 
                                        `claim_no`,
                                        `claim_date`, 
                                        `settlement_date`, 
                                        `status`, 
                                        `customer_name`, 
                                        `customer_phone`,
                                        `customer_address`, 
                                        `issue_no`, 
                                        `invoice_no`,
                                        `other`, 
                                        `returned_by`,
                                        `received_by` 
                                    FROM 
                                        `customer_claims` 
                                    WHERE 
                                        `claim_no`='" + claimNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                Me.GL_ID = reader.GetString("id")
                Me.GL_CLAIM_NO = reader.GetString("claim_no")
                Me.GL_CLAIM_DATE = reader.GetString("claim_date")
                Me.GL_SETTLEMENT_DATE = reader.GetString("settlement_date")
                Me.GL_STATUS = reader.GetString("status")
                Me.GL_INVOICE_NO = reader.GetString("invoice_no")
                Me.GL_ISSUE_NO = reader.GetString("issue_no")
                Me.GL_CUSTOMER_NAME = reader.GetString("customer_name")
                Me.GL_CUSTOMER_ADDRESS = reader.GetString("customer_address")
                Me.GL_CUSTOMER_PHONE = reader.GetString("customer_phone")
                Me.GL_RECEIVED_BY = reader.GetString("received_by")
                Me.GL_RETURNED_BY = reader.GetString("returned_by")
                Me.GL_OTHER = reader.GetString("other")

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
    Public Function addClaimDetail() As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `claim_details`(
                                        `item_code`, 
                                        `description`,
                                        `qty`, 
                                        `price`, 
                                        `reason`,
                                        `remarks`,
                                        `claim_type`,
                                        `claim_id`
                                    ) VALUES (
                                        @item_code,
                                        @description,
                                        @qty,
                                        @price,
                                        @reason,
                                        @remarks,
                                        @claim_type,
                                        @claim_id)
                                    "
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.Add("@item_code", GL_CLAIM_ITEM_CODE)
            command.Parameters.Add("@description", GL_CLAIM_DESCRIPTION)
            command.Parameters.Add("@qty", GL_CLAIM_QTY.ToString)
            command.Parameters.Add("@price", GL_CLAIM_PRICE.ToString)
            command.Parameters.Add("@reason", GL_CLAIM_REASON)
            command.Parameters.Add("@remarks", GL_CLAIM_REMARKS)
            command.Parameters.Add("@claim_type", GL_CLAIM_TYPE)
            command.Parameters.Add("@claim_id", GL_ID)

            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function editClaimDetail(sn As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE 
                                        `claim_details` 
                                        SET 
                                            `qty`='" + GL_CLAIM_QTY.ToString + "',
                                            `reason`='" + GL_CLAIM_REASON + "',
                                            `remarks`='" + GL_CLAIM_REMARKS + "',
                                            `claim_type`='" + GL_CLAIM_TYPE + "'
                                        WHERE
                                            `id`='" + sn + "'"
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

    Public Function addReplacement() As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO
                                        `claim_replacement_details`(
                                            `item_code`,
                                            `description`, 
                                            `qty`, 
                                            `price`,
                                            `claim_id`) 
                                        VALUES (
                                                @item_code,
                                                @description,
                                                @qty,
                                                @price,
                                                @claim_id)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.Add("@item_code", GL_REPLACEMENT_ITEM_CODE)
            command.Parameters.Add("@description", GL_REPLACEMENT_DESCRIPTION)
            command.Parameters.Add("@qty", GL_REPLACEMENT_QTY.ToString)
            command.Parameters.Add("@price", GL_REPLACEMENT_PRICE.ToString)
            command.Parameters.Add("@claim_id", GL_ID.ToString)
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function editReplacement(sn As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `claim_replacement_details` SET `qty`='" + GL_REPLACEMENT_QTY.ToString + "' WHERE `id`='" + sn + "'"
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

    Public Function approveClaim(claimNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `customer_claims` SET`status`='APPROVED' WHERE `claim_no`='" + claimNo + "'"
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

    Public Function cancelClaim(claimNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `customer_claims` SET`status`='CANCELED' WHERE `claim_no`='" + claimNo + "'"
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

    Public Function printClaim(claimNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `customer_claims` SET`status`='PRINTED' WHERE `claim_no`='" + claimNo + "'"
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

    Public Function completeClaim(claimNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `customer_claims` SET`status`='COMPLETED', `settlement_date`='" + Day.DAY + "' WHERE `claim_no`='" + claimNo + "'"
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
    Public Function archiveClaim(claimNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `customer_claims` SET`status`='ARCHIVED' WHERE `claim_no`='" + claimNo + "'"
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
