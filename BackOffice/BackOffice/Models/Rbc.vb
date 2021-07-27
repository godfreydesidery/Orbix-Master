Public Class Rbc
    Public Property id As String
    Public Property no As String
    Public Property billNo As String
    Public Property tillNo As String
    Public Property billDate As Date
    Public Property billAmount As Double
    Public Property rbcDate As Date
    Public Property status As String
    Public Property rbcDetails As List(Of RbcDetail) = New List(Of RbcDetail)
End Class
