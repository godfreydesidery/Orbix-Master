Imports Devart.Data.MySql
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmProductInquiry

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Function search()
        txtId.Text = ""
        If txtPrimaryBarcode.Text = "" And txtCode.Text = "" And cmbDescription.Text = "" Then
            MsgBox("Please specify a record to search. Enter barcode, itemcode or description.", vbOKOnly + vbExclamation, "Error: Search key not specified")
            Return vbNull
            Exit Function
        End If
        txtCode.ReadOnly = True
        txtPrimaryBarcode.ReadOnly = True
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            If txtPrimaryBarcode.Text <> "" Then
                response = Web.get_("products/get_by_barcode?barcode=" + txtPrimaryBarcode.Text)
                json = JObject.Parse(response)

            ElseIf txtCode.Text <> "" Then
                response = Web.get_("products/get_by_code?code=" + txtCode.Text)
                json = JObject.Parse(response)
            ElseIf cmbDescription.Text <> "" Then
                response = Web.get_("products/get_by_description?description=" + cmbDescription.Text)
                json = JObject.Parse(response)
            End If
        Catch ex As Exception
            Return vbNull
            Exit Function
        End Try

        Dim product As Product = JsonConvert.DeserializeObject(Of Product)(json.ToString)
        If product.id.ToString = "" Then
            MsgBox("No matching product", vbOKOnly + vbCritical, "Error: Not found")
            txtCode.ReadOnly = False
            txtPrimaryBarcode.ReadOnly = False
        Else

            txtId.Text = product.id
            Product.GLOBAL_PRODUCT = product
            txtPrimaryBarcode.Text = product.primaryBarcode
            txtCode.Text = product.code
            cmbDescription.Text = product.description
            txtShortDescription.Text = product.shortDescription
            txtCommonDescription.Text = product.commonDescription
            txtStandardUOM.Text = product.standardUom
            txtPacksize.Text = product.packSize
            txtIngredients.Text = product.ingredients
            txtCostPriceVatIncl.Text = LCurrency.displayValue(product.costPriceVatIncl.ToString)
            txtCostPriceVatExcl.Text = LCurrency.displayValue(product.costPriceVatExcl.ToString)
            txtSellingPriceVatIncl.Text = LCurrency.displayValue(product.sellingPriceVatIncl.ToString)
            txtSellingPriceVatExcl.Text = LCurrency.displayValue(product.sellingPriceVatExcl.ToString)
            txtProfitMargin.Text = product.profitMargin
            txtVat.Text = product.vat
            txtDiscount.Text = product.discountRatio
            txtQty.Text = product.stock
            txtMinInventory.Text = product.minimumStock
            txtMaxInventory.Text = product.maximumStock
            txtDefReorderLevel.Text = product.defaultReorderLevel
            txtDefReorderQty.Text = product.defaultReorderQty

            If Not IsNothing(product.primarySupplier) Then
                txtPrimarySupplier.Text = product.primarySupplier.name
            Else
                txtPrimarySupplier.Text = ""
            End If
            If Not IsNothing(product.department) Then
                txtDepartment.Text = product.department.name
            Else
                txtDepartment.Text = ""
            End If
            If Not IsNothing(product.clas) Then
                txtClass.Text = product.clas.name
            Else
                txtClass.Text = ""
            End If
            If Not IsNothing(product.subClass) Then
                txtSubClass.Text = product.subClass.name
            Else
                txtSubClass.Text = ""
            End If

            If product.status = "DISCONTINUED" Then
                chkDiscontinued.Checked = True
            Else
                chkDiscontinued.Checked = False
            End If
            If product.sellable = 1 Then
                chkSellable.Checked = True
            Else
                chkSellable.Checked = False
            End If
            If product.returnable = 1 Then
                chkReturnable.Checked = True
            Else
                chkReturnable.Checked = False
            End If

        End If

        Return vbNull

        Exit Function

        Dim barcodes As List(Of String) = (New Item).getBarCodes(txtCode.Text)
        lstBarCodes.Items.Clear()
        For i As Integer = 0 To barcodes.Count - 1
            lstBarCodes.Items.Add(barcodes.ElementAt(i))
        Next
        Return vbNull
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search()
    End Sub
    Private Function clearFields()
        txtId.Text = ""
        txtPrimaryBarcode.Text = ""
        txtCode.Text = ""
        cmbDescription.Text = ""
        txtShortDescription.Text = ""
        txtCommonDescription.Text = ""
        txtPacksize.Text = ""
        txtVat.Text = ""
        txtDiscount.Text = ""
        txtCostPriceVatIncl.Text = ""
        txtCostPriceVatExcl.Text = ""
        txtSellingPriceVatIncl.Text = ""
        txtSellingPriceVatExcl.Text = ""
        txtPrimarySupplier.Text = ""
        txtProfitMargin.Text = ""
        txtStandardUOM.Text = ""
        txtDepartment.Text = ""
        txtClass.Text = ""
        txtSubClass.Text = ""
        txtMinInventory.Text = ""
        txtMaxInventory.Text = ""
        txtDefReorderLevel.Text = ""
        txtDefReorderQty.Text = ""
        txtQty.Text = ""
        chkDiscontinued.Checked = False
        Return vbNull
    End Function
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        clearFields()
        txtCode.ReadOnly = False
        txtPrimaryBarcode.ReadOnly = False
        cmbDescription.Enabled = True
    End Sub

    Private Sub frmProductInquiry_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        clearFields()
    End Sub

    Private Sub txtBarCode_preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtPrimaryBarcode.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            txtCode.Text = ""
            cmbDescription.Text = ""
            search()
        End If
    End Sub


    Private Sub txtItemCode_Preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtCode.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            txtPrimaryBarcode.Text = ""
            cmbDescription.Text = ""
            search()
        End If
    End Sub

    Private Sub txtLongDescription_preview(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Tab Then
            txtPrimaryBarcode.Text = ""
            txtCode.Text = ""
            search()
        End If
    End Sub

    Private Sub frmProductInquiry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim product_ As New Product
        longList = product_.getDescriptions
    End Sub
    Public Shared GLOBAL_ITEM_CODE As String = ""

    Private Sub txtBarCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrimaryBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            search()
        End If
    End Sub

    Private Sub btnViewSuppliers_Click(sender As Object, e As EventArgs)
        If txtCode.Text <> "" Then
            GLOBAL_ITEM_CODE = txtCode.Text
            frmViewSuppliers.ShowDialog()
        End If
    End Sub

    Dim longList As New List(Of String)
    Dim shortList As New List(Of String)
    Private Sub cmbDescription_KeyUp(sender As Object, e As EventArgs) Handles cmbDescription.KeyUp
        Dim currentText As String = cmbDescription.Text
        shortList.Clear()
        cmbDescription.Items.Clear()
        cmbDescription.Items.Add(currentText)
        cmbDescription.DroppedDown = True
        For Each text As String In longList
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbDescription.Text.ToUpper()) Then
                shortList.Add(text)
            End If
        Next
        cmbDescription.Items.AddRange(shortList.ToArray())
        cmbDescription.SelectionStart = cmbDescription.Text.Length
        Cursor.Current = Cursors.Default
    End Sub
End Class