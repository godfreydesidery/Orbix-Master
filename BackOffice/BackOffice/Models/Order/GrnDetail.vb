Public Class GrnDetail
    Public Property id As String
    Public Property barcode As String
    Public Property code As String
    Public Property description As String
    Public Property packSize As Double
    Public Property qtyOrdered As Double
    Public Property qtyReceived As Double
    Public Property supplierCostPrice As Double
    Public Property clientCostPrice As Double
    Public Property grn As Grn = New Grn()
End Class
