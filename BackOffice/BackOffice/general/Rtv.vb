Public Class Rtv
    Dim id As String
    Dim no As String
    Dim issueDate As Date
    Dim status As String
    Dim createdUser As User = New User
    Dim approvedUser As User = New User
    Dim completedUser As User = New User
    Dim supplier As Supplier = New Supplier
    Dim rtvDetails As List(Of RtvDetail)
End Class
