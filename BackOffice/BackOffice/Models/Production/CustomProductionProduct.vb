Public Class CustomProductionProduct
    Public Property id As String
    Public Property qty As Double

    Public Property costPriceVatIncl As Double
    Public Property costPriceVatExcl As Double
    Public Property sellingPriceVatIncl As Double
    Public Property sellingPriceVatExcl As Double

    Public Property product As Product = New Product
    Public Property customProduction As CustomProduction = New CustomProduction
End Class
