Imports Devart.Data.MySql
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmEditInventory
    Dim code As String = ""
    Dim qty As Integer = 0
    Dim minInv As Integer = 0
    Dim maxInv As Integer = 0
    Dim reorderQty As Integer = 0
    Dim reorderLevel As Integer = 0
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub
    Private Function setValues()
        code = txtCode.Text
        qty = Val(txtStock.Text)
        minInv = Val(txtMinimumInventory.Text)
        maxInv = Val(txtMaximumInventory.Text)
        reorderQty = Val(txtDefaultReorderQuantity.Text)
        reorderLevel = Val(txtDefaultReorderLevel.Text)
        Return vbNull
    End Function
    Private Function _validate()

        Return vbNull
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Val(txtMinimumInventory.Text) > Val(txtMaximumInventory.Text) Then
            MsgBox("Minimum inventory limit should be less than or equal to Maximum inventory limit")
            Exit Sub
        End If
        If Val(txtDefaultReorderLevel.Text) < Val(txtMinimumInventory.Text) Then
            MsgBox("Reorder level should exceed minimum inventory limit")
            Exit Sub
        End If
        If Val(txtDefaultReorderQuantity.Text) > Val(txtMaximumInventory.Text) Then
            MsgBox("Reorder quantity should not exceed the maximum inventory limit")
            Exit Sub
        End If
        Dim res As Integer = MsgBox("Confirm inventory update?", vbQuestion + vbYesNo, "Update inventory")
        If res = DialogResult.No Then
            Exit Sub
        End If
        If Val(txtMinimumInventory.Text) < 0 Or Val(txtMaximumInventory.Text) < 0 Or Val(txtDefaultReorderQuantity.Text) < 0 Or Val(txtDefaultReorderLevel.Text) < 0 Then
            MsgBox("Values should not be less than zero")
            Exit Sub
        End If
        Dim product_ As Product = Product.GLOBAL_PRODUCT

        product_.stock = txtNewStock.Text
        product_.maximumStock = txtMaximumInventory.Text
        product_.minimumStock = txtMinimumInventory.Text
        product_.defaultReorderLevel = txtDefaultReorderLevel.Text
        product_.defaultReorderQty = txtDefaultReorderQuantity.Text

        If Web.put(product_, "products/update_inventory_by_product_id?product_id=" + txtProductId.Text) = True Then
            MsgBox("Inventory updated successifully", vbOKOnly + vbInformation, "Success: Inventory update")
            loadInventory()
        Else
            MsgBox("Update failed")
        End If
    End Sub

    Private Sub frmEditInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadInventory()
    End Sub

    Private Sub loadInventory()
        txtAdd.Text = ""
        txtDeduct.Text = ""

        Dim response As Object = New Object
        Dim json As JObject = New JObject
        txtProductId.Text = Product.GLOBAL_PRODUCT.id
        response = Web.get_("products/get_by_id?id=" + txtProductId.Text)
        json = JObject.Parse(response)
        Dim product_ As Product = JsonConvert.DeserializeObject(Of Product)(json.ToString)
        txtCode.Text = product_.code.ToString
        txtStock.Text = product_.stock.ToString
        txtMaximumInventory.Text = product_.maximumStock.ToString
        txtMinimumInventory.Text = product_.minimumStock.ToString
        txtDefaultReorderLevel.Text = product_.defaultReorderLevel.ToString
        txtDefaultReorderQuantity.Text = product_.defaultReorderQty.ToString
        txtNewStock.Text = (Val(txtStock.Text)).ToString

    End Sub

    Private Sub txtAdd_TextChanged(sender As Object, e As EventArgs) Handles txtAdd.TextChanged
        If Not IsNumeric(txtAdd.Text) Or Val(txtAdd.Text) < 0 Then
            txtAdd.Text = ""
        End If
        txtDeduct.Text = ""
        txtNewStock.Text = Math.Round((Val(txtAdd.Text)), 2, MidpointRounding.AwayFromZero) + Val(txtStock.Text).ToString
    End Sub

    Private Sub txtDeduct_TextChanged(sender As Object, e As EventArgs) Handles txtDeduct.TextChanged
        If Not IsNumeric(txtDeduct.Text) Or Val(txtDeduct.Text) < 0 Then
            txtDeduct.Text = ""
        End If
        txtAdd.Text = ""
        txtNewStock.Text = Val(txtStock.Text) - Math.Round((Val(txtDeduct.Text)), 2, MidpointRounding.AwayFromZero)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class