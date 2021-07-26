Public Class SalesInvoice
    Public Property id As String
    Public Property no As String
    Public Property issueDate As Date
    Public Property status As String
    Public Property terms As String
    Public Property comment As String
    Public Property createdUser As User = New User
    Public Property approvedUser As User = New User
    Public Property completedUser As User = New User
    Public Property corporateCustomer As CorporateCustomer = New CorporateCustomer
    Public Property salesInvoiceDetails As List(Of SalesInvoiceDetail) = New List(Of SalesInvoiceDetail)
End Class
