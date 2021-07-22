Imports Devart.Data.MySql
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmProductInquiry

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub
    Private Function searchInventory(itemCode As String) As Boolean
        Dim found As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code

            Dim codeQuery As String = "SELECT  `qty`, `min_inventory`, `max_inventory`, `def_reorder_qty`, `reorder_level` FROM `inventorys` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read

                txtMinInventory.Text = reader.GetString("min_inventory")
                txtMaxInventory.Text = reader.GetString("max_inventory")
                txtDefReorderLevel.Text = reader.GetString("reorder_level")
                txtDefReorderQty.Text = reader.GetString("def_reorder_qty")
                txtQty.Text = reader.GetString("qty")

                found = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return found
    End Function
    Dim itemCodes As String = ""
    Private Function searchItem(itemCode As String) As Boolean
        Dim found As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code

            Dim codeQuery As String = "SELECT `item_code`, `item_scan_code`, `item_long_description`, `item_description`, `pck`, `department_id`, `class_id`, `sub_class_id`, `supplier_id`, `unit_cost_price`, `retail_price`, `discount`, `vat`, `margin`, `standard_uom`,`active` FROM `items` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtCode.Text = reader.GetString("item_code")
                itemCode = txtCode.Text
                cmbDescription.Text = reader.GetString("item_long_description")
                txtShortDescription.Text = reader.GetString("item_description")
                txtPacksize.Text = reader.GetString("pck")
                txtVat.Text = LCurrency.displayValue(reader.GetString("vat"))
                txtDiscount.Text = LCurrency.displayValue(reader.GetString("discount"))
                txtCostPriceVatIncl.Text = LCurrency.displayValue(reader.GetString("unit_cost_price"))
                txtSellingPriceVatIncl.Text = LCurrency.displayValue(reader.GetString("retail_price"))
                txtPrimarySupplier.Text = (New Supplier).getSupplierName(reader.GetString("supplier_id"), "")
                txtProfitMargin.Text = LCurrency.displayValue(reader.GetString("margin"))
                txtStandardUOM.Text = reader.GetString("standard_uom")
                txtDepartment.Text = (New Department).getDepartmentName(reader.GetString("department_id"))
                txtClass.Text = (New Class_).getClassName(reader.GetString("class_id"))
                txtSubClass.Text = (New SubClass).getSubClassName(reader.GetString("sub_class_id"))
                If reader.GetString("active") = "1" Then
                    chkDiscontinued.Checked = True
                Else
                    chkDiscontinued.Checked = False
                End If
                found = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return found
    End Function
    Private Function search()





        txtId.Text = ""
        If txtPrimaryBarcode.Text = "" And txtCode.Text = "" And cmbDescription.Text = "" Then
            MsgBox("Please specify a record to search. Enter barcode, itemcode or long description.", vbOKOnly + vbExclamation, "Error: Search key not specified")
            Return vbNull
            Exit Function
        End If
        txtCode.ReadOnly = True
        txtPrimaryBarcode.ReadOnly = True
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            If txtPrimaryBarcode.Text <> "" Then
                response = Web.get_("products/barcode=" + txtPrimaryBarcode.Text)
                json = JObject.Parse(response)

                ' If searchByBarCode(txtPrimaryBarcode.Text) = True Then
                'itemCode = txtCode.Text
                'Dim barcodes As List(Of String) = (New Item).getBarCodes(itemCode)
                'lstBarCodes.Items.Clear()
                'For i As Integer = 0 To barcodes.Count - 1
                'lstBarCodes.Items.Add(barcodes.ElementAt(i))
                'Next
                'End If
            ElseIf txtCode.Text <> "" Then
                response = Web.get_("products/code=" + txtCode.Text)
                json = JObject.Parse(response)
            ElseIf cmbDescription.Text <> "" Then
                response = Web.get_("products/description=" + cmbDescription.Text)
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
            txtDiscount.Text = product.discount
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

    Private Sub txtLongDescription_mouseenter(sender As Object, e As EventArgs)
        Dim list As New List(Of String)
        Dim mySource As New AutoCompleteStringCollection
        Dim item As New Item
        list = item.getItems(cmbDescription.Text)
        mySource.AddRange(list.ToArray)
        cmbDescription.AutoCompleteCustomSource = mySource
        cmbDescription.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbDescription.AutoCompleteSource = AutoCompleteSource.CustomSource
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
    Private Sub txtBarCode_TextChanged(sender As Object, e As EventArgs) Handles txtPrimaryBarcode.TextChanged

    End Sub

    Private Sub txtBarCode_LostFocus(sender As Object, e As EventArgs) Handles txtPrimaryBarcode.LostFocus

    End Sub

    Private Sub txtBarCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrimaryBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            search()
        End If
    End Sub

    Private Sub txtLongDescription_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub txtReorderQty_TextChanged(sender As Object, e As EventArgs) Handles txtDefReorderQty.TextChanged

    End Sub

    Private Sub txtReorderLevel_TextChanged(sender As Object, e As EventArgs) Handles txtDefReorderLevel.TextChanged

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub txtMaxInventory_TextChanged(sender As Object, e As EventArgs) Handles txtMaxInventory.TextChanged

    End Sub

    Private Sub txtMinInventory_TextChanged(sender As Object, e As EventArgs) Handles txtMinInventory.TextChanged

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click

    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub txtStandardUOM_TextChanged(sender As Object, e As EventArgs) Handles txtStandardUOM.TextChanged

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub txtMargin_TextChanged(sender As Object, e As EventArgs) Handles txtProfitMargin.TextChanged

    End Sub

    Private Sub txtDiscount_TextChanged(sender As Object, e As EventArgs) Handles txtDiscount.TextChanged

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub txtVAT_TextChanged(sender As Object, e As EventArgs) Handles txtVat.TextChanged

    End Sub

    Private Sub txtRetailPrice_TextChanged(sender As Object, e As EventArgs) Handles txtSellingPriceVatIncl.TextChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub txtCostPrice_TextChanged(sender As Object, e As EventArgs) Handles txtCostPriceVatIncl.TextChanged

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