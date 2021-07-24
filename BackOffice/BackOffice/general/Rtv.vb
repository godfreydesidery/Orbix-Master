Public Class Rtv
    Public Property id As String
    Public Property no As String
    Public Property issueDate As Date
    Public Property status As String
    Public Property comment As String
    Public Property createdUser As User = New User
    Public Property approvedUser As User = New User
    Public Property completedUser As User = New User
    Public Property supplier As Supplier = New Supplier
    Public Property rtvDetails As List(Of RtvDetail)
End Class
