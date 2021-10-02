Public Class DebtPayment
    Public Property id As String = ""
    Public Property initialAmount As Double
    Public Property bankDeposit As Double
    Public Property cashPayment As Double
    Public Property totalPaid As Double
    Public Property amountRemaining As Double
    Public Property receivingUser As User = New User
    Public Property debt As Debt = New Debt
    Public Property receivingDay As Day = New Day
End Class
