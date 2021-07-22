Imports Devart.Data.MySql

Public Class Debt
    Public Function registerPayment(_date As String, issueNo As String, initialBalance As Double, amount As Double, currentBalance As Double, salesPersonId As String, userId As String, remarks As String)
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "INSERT INTO `debt_payment`(
                                                        `date`,
                                                        `issue_no`,
                                                        `initial_balance`,
                                                        `amount`,
                                                        `current_balance`,
                                                        `user_id`,
                                                        `sales_person_id`,
                                                        `remarks`)
                                                    VALUES (
                                                        @date,
                                                        @issue_no,
                                                        @initial_balance,
                                                        @amount,
                                                        @current_balance,
                                                        @user_id,
                                                        @sales_person_id,
                                                        @remarks)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.Add("@date", _date)
            command.Parameters.Add("@issue_no", issueNo)
            command.Parameters.Add("@initial_balance", initialBalance.ToString)
            command.Parameters.Add("@amount", amount.ToString)
            command.Parameters.Add("@current_balance", currentBalance.ToString)
            command.Parameters.Add("@user_id", userId)
            command.Parameters.Add("@sales_person_id", salesPersonId)
            command.Parameters.Add("@remarks", remarks)
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.ToString)
        End Try
        Return success
        Return vbNull
    End Function
End Class
