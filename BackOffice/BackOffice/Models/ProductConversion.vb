Public Class ProductConversion
    Public Property id As String
    Public Property no As String
    Public Property status As String
    Public Property reason As String
    Public Property comments As String

    Public Property createdDay As Day = New Day
    Public Property issuedDay As Day = New Day
    Public Property approvedDay As Day = New Day
    Public Property printedDay As Day = New Day
    Public Property completedDay As Day = New Day
    Public Property createdByUser As User = New User
    Public Property approvedByUser As User = New User
    Public Property issuedByUser As User = New User
    Public Property printedByUser As User = New User
    Public Property completedByUser As User = New User

End Class
