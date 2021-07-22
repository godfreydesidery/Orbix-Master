Imports Devart.Data.MySql

Public Class Till
    Public Shared TILLNO As String = ""

    Public Shared Function tillTotalRegister(tillNo As String, cash As Double, voucher As Double, cheque As Double, deposit As Double, loyalty As Double, CRCard As Double, CAP As Double, invoice As Double, CRNote As Double, mobile As Double)
        Dim commited As Boolean = False
        Dim conn As New MySqlConnection(Database.conString)
        Dim query As String = ""
        Dim command As New MySqlCommand()
        conn.Open()
        command.Connection = conn
        query = "INSERT IGNORE INTO `till_total`(`till_no`) VALUES ('" + Till.TILLNO + "')"
        command.CommandText = query
        command.Prepare()
        command.ExecuteNonQuery()
        query = "UPDATE `till_total` SET `cash`=`cash`+'" + cash.ToString + "',`voucher`=`voucher`+'" + voucher.ToString + "',`cheque`=`cheque`+' " + cheque.ToString + "',`deposit`=`deposit`+'" + deposit.ToString + "',`loyalty`=`loyalty`+'" + loyalty.ToString + "',`cr_card`=`cr_card`+'" + CRCard.ToString + "',`cap`=`cap`+'" + CAP.ToString + "',`invoice`=`invoice`+'" + invoice.ToString + "',`cr_note`=`cr_note`+'" + CRNote.ToString + "',`mobile`=`mobile`+'" + mobile.ToString + "' WHERE `till_no`='" + tillNo.ToString + "'"
        command.CommandText = query
        command.Prepare()
        command.ExecuteNonQuery()
        conn.Close()
        commited = True
        Return commited
        Return vbNull
    End Function

End Class
