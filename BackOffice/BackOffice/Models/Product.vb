Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Product

    ' Inherits SubClass
    Public Shared GLOBAL_PRODUCT As Product = New Product

    Public GL_SUPPLIER_ID As String = ""
    Public GL_BAR_CODE As String = ""
    Public GL_CODE As String = ""
    Public GL_SHORT_DESCR As String = ""
    Public GL_LONG_DESCR As String = ""
    Public GL_PCK As String = ""

    Public GL_COST_PRICE_VAT_INCL As Double = 0
    Public GL_SELLING_PRICE_VAT_INCL As Double = 0
    Public GL_COST_PRICE_VAT_EXCL As Double = 0
    Public GL_SELLING_PRICE_VAT_EXCL As Double = 0
    Public GL_VAT As Double = 0

    Public GL_DISCOUNT_RATIO As Double = 0
    Public GL_SUPPLIER As String = 0
    Public GL_MARGIN As Double = 0
    Public GL_STANDARD_UOM As String = ""
    Public GL_DEPARTMENT As String = ""
    Public GL_CLASS As String = ""
    Public GL_SUB_CLASS As String = ""
    Public GL_STATUS As String = ""

    Public Property id As String
    Public Property primaryBarcode As String
    Public Property code As String
    Public Property description As String
    Public Property shortDescription As String
    Public Property commonDescription As String
    Public Property standardUom As String
    Public Property packSize As Double
    Public Property ingredients As String
    Public Property costPriceVatIncl As Double
    Public Property costPriceVatExcl As Double
    Public Property sellingPriceVatIncl As Double
    Public Property sellingPriceVatExcl As Double
    Public Property profitMargin As Double
    Public Property vat As Double
    Public Property discountRatio As Double
    Public Property stock As Double
    Public Property minimumStock As Double
    Public Property maximumStock As Double
    Public Property defaultReorderLevel As Double
    Public Property defaultReorderQty As Double

    Public Property status As String
    Public Property sellable As Integer
    Public Property returnable As Integer

    Public Property primarySupplier As Supplier = New Supplier
    Public Property department As Department = New Department
    Public Property clas As Class_ = New Class_
    Public Property subClass As SubClass = New SubClass

    Public Function getDescriptions() As List(Of String)
        'Returns a list of descriptions of all the products
        Dim list As New List(Of String)
        Try
            Dim response As Object = New Object
            Dim json As JObject = New JObject
            response = Web.get_("products/descriptions")
            list = JsonConvert.DeserializeObject(Of List(Of String))(response.ToString)
            Return list
        Catch ex As Exception
            Return list
        End Try
        Return list
    End Function

    Public Function getCode(barCode As String, descr As String) As String
        '
        Try
            Dim response As Object = New Object
            Dim json As JObject = New JObject
            If descr <> "" Then
                response = Web.get_("products/get_code_by_description?description=" + descr)
            Else
                response = Web.get_("products/get_code_by_barcode?barcode=" + barCode)
            End If
            Return JsonConvert.DeserializeObject(Of String)(response.ToString)
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class
