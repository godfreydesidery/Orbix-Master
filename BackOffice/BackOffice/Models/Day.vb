Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Day

    Public Shared GL_BUSSINESS_DATE As Date
    Public Property bussinessDate As Date
    Public Shared DAY As Date
    Public Property startedAt As String = ""
    Public endAt As String = ""



    Public Function getCurrentDay() As Date
        Dim date_ As Date = #0001-01-01#
        Dim day_ As New Day
        Try
            Dim response As Object = New Object
            Dim json As JObject = New JObject
            response = Web.get_("days/get_current_bussiness_day")
            json = JObject.Parse(response)
            day_ = JsonConvert.DeserializeObject(Of Day)(json.ToString)

            startedAt = day_.startedAt
            endAt = day_.endAt
            date_ = day_.bussinessDate

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return date_
    End Function
End Class
