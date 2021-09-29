Public Class PackingListDetail
    Public Property id As String
    Public Property barcode As String
    Public Property code As String
    Public Property description As String
    Public Property costPriceVatIncl As Double
    Public Property sellingPriceVatIncl As Double
    Public Property previousReturns As Double
    Public Property issued As Double
    Public Property totalPacked As Double
    Public Property sold As Double
    Public Property returned As Double
    Public Property damaged As Double
    Public Property packingList As PackingList = New PackingList()
End Class
