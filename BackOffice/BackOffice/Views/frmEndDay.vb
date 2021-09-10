Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmEndDay
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Private Function loadDay()
        Dim day As New Day
        Dim currentDate As Date = day.getCurrentDay()
        If currentDate.ToString("yyyy-MM-dd") = "0001-01-01" Then
            currentDate = Date.Now
            ''''''day.startDay(currentDate.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd:HH:MM:SS"))
        End If
        txtCurrentDate.Text = currentDate.ToString("yyyy-MM-dd")
        txtOpenAt.Text = day.startedAt
        Return vbNull
    End Function
    Private Sub frmEndDay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadDay()
    End Sub
    Private Sub btnCloseDay_Click(sender As Object, e As EventArgs) Handles btnCloseDay.Click
        Dim res As Integer = MsgBox("Are you sure you want to End the day?", vbQuestion + vbYesNo, "End Day")
        If res = DialogResult.Yes Then
            Dim day As Day = New Day
            Day.bussinessDate = Day.DAY
            Try
                Dim response As Object = New Object
                Dim json As JObject = New JObject
                response = Web.post(day, "days/end_day")
                json = JObject.Parse(response)
                day = JsonConvert.DeserializeObject(Of Day)(json.ToString)
                btnCloseDay.Enabled = False
                lblStatus.Text = "....You have started a new day!...."
                MsgBox("Day ended successifully, Application will close")
                End
            Catch ex As Exception
                MsgBox("Could not end the day. Please contact System administrator")
            End Try

        End If
        Exit Sub
    End Sub
End Class