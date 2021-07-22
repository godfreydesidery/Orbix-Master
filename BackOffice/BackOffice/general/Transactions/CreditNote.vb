Imports Devart.Data.MySql

Public Class CreditNote
    Public GL_CR_NO As String = ""
    Public GL_CR_AMOUNT As String = ""
    Public GL_BILL_NO As String = ""
    Public GL_DATE As String = ""
    Public GL_STATUS As String = ""
    Public GL_DETAILS As String = ""

    Private Function generateCrNo() As String
        Dim no As String = ""

        Dim KeyGen As RandomKeyGenerator
        Dim NumKeys As Integer
        Dim i_Keys As Integer
        Dim RandomKey As String = ""

        ' MODIFY THIS TO GET MORE KEYS    - LAITH - 27/07/2005 22:48:30 -
        NumKeys = 10

        KeyGen = New RandomKeyGenerator
        KeyGen.KeyLetters = "0987654321"
        KeyGen.KeyNumbers = "0123456789"
        KeyGen.KeyChars = 15
        For i_Keys = 1 To NumKeys
            RandomKey = KeyGen.Generate()
        Next
        no = RandomKey.ToString
        Return no
    End Function
    Public Function createCreditNotee(crAmount As Double, billNo As String, crDate As String, details As String) As String
        Dim crNo As String = generateCrNo()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "INSERT INTO `cr_note`( `cr_no`, `cr_amount`, `cr_bill_no`, `cr_date`, `cr_status`, `cr_details`) VALUES (@cr_no,@cr_amount,@cr_bill_no,@cr_date,@cr_status,@cr_details)" 'insert query
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@cr_no", crNo)
            command.Parameters.AddWithValue("@cr_amount", crAmount)
            command.Parameters.AddWithValue("@cr_bill_no", billNo)
            command.Parameters.AddWithValue("@cr_date", crDate)
            command.Parameters.AddWithValue("@cr_details", details)
            command.Parameters.AddWithValue("@cr_status", "PENDING")
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            crNo = ""
            MsgBox(ex.Message)
        End Try
        Return crNo
    End Function
    Public Function updateCreditNote(crNo As String, billNo As String, creditor As String, type As String, status As String, amount As String, description As String) As Boolean
        Dim success As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "UPDATE `credit_notes` SET `cr_note_bill_no`='" + billNo + "',`sr_note_creditor`='" + creditor + "',`cr_note_type`='" + type + "',`cr_note_status`='" + status + "',`cr_note_description`='" + description + "',`credit_amount`='" + amount + "' WHERE `cr_note_no`='" + crNo + "'" 'insert query
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
    Public Function updateCreditNoteParticulars(crNo As String, itemCode As String, price As String, qty As String)
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "UPDATE `credit_note_particulars` SET `item_code`='" + itemCode + "',`qty`='" + qty + "',`price`='" + price + "' WHERE `cr_note_no`='" + crNo + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function

    'Private function delete
    Public Function deleteCreditNote(crNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "DELETE FROM `credit_notes` WHERE `cr_note_no`='" + crNo + "';DELETE FROM `credit_note_particulars` WHERE `cr_note_no`='" + crNo + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            crNo = ""
            MsgBox(ex.Message)
        End Try
        Return crNo
    End Function
    Public Function createCreditNote(billNo As String, type As String, creditor As String, status As String, description As String, date_ As String, amount As String) As String
        Dim crNo As String = generateCrNo()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "INSERT INTO `credit_notes`( `cr_note_no`, `cr_note_bill_no`, `sr_note_creditor`, `cr_note_type`, `cr_note_status`, `cr_note_description`, `cr_note_date`, `credit_amount`) VALUES (@cr_note_no,@cr_note_bill_no,@sr_note_creditor,@cr_note_type,@cr_note_status,@cr_note_description,@cr_note_date,@amount)" 'insert query
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@cr_note_no", crNo)
            command.Parameters.AddWithValue("@cr_note_bill_no", billNo)
            command.Parameters.AddWithValue("@sr_note_creditor", creditor)
            command.Parameters.AddWithValue("@cr_note_type", type)
            command.Parameters.AddWithValue("@cr_note_status", status)
            command.Parameters.AddWithValue("@cr_note_description", description)
            command.Parameters.AddWithValue("@cr_note_date", date_)
            command.Parameters.AddWithValue("@amount", amount)

            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            crNo = ""
            MsgBox(ex.Message)
        End Try
        Return crNo
    End Function
    Public Function createCreditNoteParticulars(crNo As String, itemCode As String, price As String, qty As String)
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "INSERT INTO `credit_note_particulars`( `cr_note_no`, `item_code`, `qty`, `price`) VALUES (@cr_note_no,@item_code,@qty,@price)" 'insert query
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@cr_note_no", crNo)
            command.Parameters.AddWithValue("@item_code", itemCode)
            command.Parameters.AddWithValue("@qty", qty)
            command.Parameters.AddWithValue("@price", price)
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function
    Public Function createCustomerCreditNote(crDate As String, crBillNo As String, crAmount As String, status As String, details As String) As String
        Dim crNo As String = "1" + generateCrNo()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "INSERT INTO `customer_credit_notes`( `cr_no`, `cr_date`, `cr_bill_no`, `cr_amount`, `status`, `cr_details`) VALUES (@cr_no,@cr_date,@cr_bill_no,@cr_amount,@status,@cr_details)" 'insert query
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@cr_no", crNo)
            command.Parameters.AddWithValue("@cr_date", crDate)
            command.Parameters.AddWithValue("@cr_bill_no", crBillNo)
            command.Parameters.AddWithValue("@cr_amount", crAmount)
            command.Parameters.AddWithValue("@status", status)
            command.Parameters.AddWithValue("@cr_details", details)
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            crNo = ""
        End Try
        Return crNo
    End Function
    Public Function createSupplierCreditNote(crDate As String, crOrderNo As String, crAmount As String, status As String, details As String) As String
        Dim crNo As String = "2" + generateCrNo()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "INSERT INTO `supplier_credit_notes`(`cr_no`, `cr_date`, `cr_order_no`, `cr_amount`, `status`, `cr_details`) VALUES (@cr_no,@cr_date,@cr_order_no,@cr_amount,@status,@cr_details)" 'insert query
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@cr_no", crNo)
            command.Parameters.AddWithValue("@cr_date", crDate)
            command.Parameters.AddWithValue("@cr_order_no", crOrderNo)
            command.Parameters.AddWithValue("@cr_amount", crAmount)
            command.Parameters.AddWithValue("@status", status)
            command.Parameters.AddWithValue("@cr_details", details)
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            crNo = ""
        End Try
        Return crNo
    End Function
    Public Function refundCustomerCreditNote(crNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "UPDATE `customer_credit_notes` SET `status`='REFUNDED' WHERE `cr_no`='" + crNo + "'"
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
    Public Function adjustSupplierCreditNote(crNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "UPDATE `supplier_credit_notes` SET `status`='ADJUSTED' WHERE `cr_no`='" + crNo + "'"
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
    Public Function deleteCustomerCreditNote(crNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "DELETE FROM `customer_credit_notes` WHERE `cr_no`='" + crNo + "';DELETE FROM `credit_note_particulars` WHERE `cr_note_no`='" + crNo + "'"
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
    Public Function deleteSupplierCreditNote(crNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "DELETE FROM `supplier_credit_notes` WHERE `cr_no`='" + crNo + "';DELETE FROM `credit_note_particulars` WHERE `cr_note_no`='" + crNo + "'"
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
    Public Function updateSupplierCreditNote(crNoteNo As String, orderNo As String, crAmount As String, crDetails As String)
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "UPDATE `supplier_credit_notes` SET `cr_order_no`='" + orderNo + "',`cr_amount`='" + crAmount + "',`cr_details`='' WHERE `cr_no`='" + crNoteNo + "'"
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
    Public Function updateCustomerCreditNote(crNoteNo As String, billNo As String, crAmount As String, crDetails As String)
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "UPDATE `customer_credit_notes` SET `cr_bill_no`='" + billNo + "',`cr_amount`='" + crAmount + "',`cr_details`='" + crDetails + "' WHERE `cr_no`='" + crNoteNo + "'"
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
    Public Function deleteCreditNoteParticulars(crNoteNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "DELETE FROM `credit_note_particulars` WHERE `cr_note_no`='" + crNoteNo + "'"
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
