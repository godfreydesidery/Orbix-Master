Public Class RtvDetail
    Public Property id As String
    Public Property barcode As String
    Public Property code As String
    Public Property description As String
    Public Property qty As Double
    Public Property costPriceVatIncl As Double = 0
    Public Property costPriceVatExcl As Double = 0
    Public Property sellingPriceVatIncl As Double = 0
    Public Property sellingPriceVatExc As Double = 0
    Public Property packSize As Double = 1
    Public Property reason As String = ""
    Public Property rtv As Rtv = New Rtv
End Class
