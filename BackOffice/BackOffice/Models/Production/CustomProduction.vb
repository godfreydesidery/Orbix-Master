Public Class CustomProduction
    Public Property id As String
    Public Property no As String
    Public Property productName As String
    Public Property batchSize As String
    Public Property uom As String
    Public Property status As String

    Public Property createdDay As Day = New Day
    Public Property approvedDay As Day = New Day
    Public Property completedDay As Day = New Day
    Public Property createdByUser As User = New User
    Public Property approvedByUser As User = New User
    Public Property completedByUser As User = New User

End Class
