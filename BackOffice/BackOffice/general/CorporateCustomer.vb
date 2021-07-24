Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class CorporateCustomer
    Public Property id As String
    Public Property no As String
    Public Property name As String
    Public Property tin As String
    Public Property vrn As String
    Public Property contactName As String
    Public Property postAddress As String
    Public Property postCode As String
    Public Property physicalAddress As String
    Public Property telephone As String
    Public Property mobile As String
    Public Property email As String
    Public Property fax As String
    Public Property active As Integer
    Public Property bankAccountName As String
    Public Property bankPostAddress As String
    Public Property bankPostCode As String
    Public Property bankName As String
    Public Property bankAccountNo As String
    Public Property invoiceLimit As Double
    Public Property creditLimit As Double
    Public Property creditDays As Integer

    Public Function getNames() As List(Of String)
        'Returns a list of descriptions of all the products
        Dim list As New List(Of String)
        Try
            Dim response As Object = New Object
            Dim json As JObject = New JObject
            response = Web.get_("corporate_customers/names")
            list = JsonConvert.DeserializeObject(Of List(Of String))(response.ToString)
            Return list
        Catch ex As Exception
            Return list
        End Try
        Return list
    End Function
End Class
