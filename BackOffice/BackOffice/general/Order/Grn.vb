Public Class Grn
    Public Property id As String
    Public Property no As String
    Public Property invoiceNo As String
    Public Property invoiceTotal As Double
    Public Property receivedDate As Date
    Public Property receivedUser As User = New User
    Public Property supplier As Supplier = New Supplier
    Public Property lpo As Lpo = New Lpo
    Public Property grnDetails As List(Of GrnDetail) = New List(Of GrnDetail)
End Class
