Imports Devart.Data.MySql

Public Class Refund
    Public Function refund(refundDate As String, crNoteNo As String, refundAmounta As Double) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "INSERT INTO `refunds`(`date`, `amount`, `cr_note_no`) VALUES (@date,@amount,@cr_note_no)"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@date", refundDate)
            command.Parameters.AddWithValue("@amount", refundAmounta.ToString)
            command.Parameters.AddWithValue("@cr_note_no", crNoteNo)
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try
        Return success
    End Function
End Class
