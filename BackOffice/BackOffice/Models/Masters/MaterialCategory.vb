Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class MaterialCategory
    Public Property id As String
    Public Property no As String
    Public Property name As String
    Public Property status As String

    Public Function getNames() As List(Of String)
        'Returns a list of descriptions of all the products
        Dim list As New List(Of String)
        Try
            Dim response As Object = New Object
            Dim json As JObject = New JObject
            response = Web.get_("materials/categories/get_names")
            list = JsonConvert.DeserializeObject(Of List(Of String))(response.ToString)
            Return list
        Catch ex As Exception
            Return list
        End Try
        Return list
    End Function
End Class
