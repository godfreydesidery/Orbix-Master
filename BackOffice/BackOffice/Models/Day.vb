Imports Devart.Data.MySql

Public Class Day
    Public Shared DAY As String = ""
    Public startedAt As String = ""
    Public endAt As String = ""
    Public Function getCurrentDay() As Date
        Dim date_ As Date = #0001-01-01#
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `day_no`, `date`, `start_at`, `end_at`, `open_closed` FROM `day_log` ORDER BY `day_no` DESC LIMIT 1"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                startedAt = reader.GetString("start_at")
                endAt = reader.GetString("end_at")
                date_ = reader.GetDateTime("date")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return date_
    End Function
    Public Function startDay(date_ As String, startAt As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "INSERT INTO `day_log`(`date`, `start_at`,`open_closed`) VALUES (@date,@start_at,@open)"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@date", date_)
            command.Parameters.AddWithValue("@start_at", startAt)
            command.Parameters.AddWithValue("@open", "OPEN")
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function endDay(date_ As String, endAt As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "UPDATE `day_log` SET `end_at`='" + endAt + "',`open_closed`='CLOSED' WHERE `date`='" + date_ + "'"
            conn.Open()
            command.CommandText = query
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
