Option Explicit On
Imports BackOffice.Nett


'Imports Microsoft.Office.Interop
Imports Devart.Data.MySql
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmProductMaster
    ' Dim RECORD_MODE As Integer = 0 ' 0 save new, 1 save existing
    'Dim NEW_SPECIAL As Integer = 0

    Dim supplierID As String = ""
    Dim departmentID As String = ""
    Dim classID As String = ""
    Dim subClassID As String = ""

    Dim id As String = ""
    Dim primaryBarcode As String = ""
    Dim code As String = ""
    Dim shortDescription As String = ""
    Dim commonDescription As String = ""
    Dim description As String = ""
    Dim packSize As Double = 1

    Dim costPriceVatIncl As Double = 0
    Dim costPriceVatExcl As Double = 0
    Dim sellingPriceVatIncl As Double = 0
    Dim sellingPriceVatExcl As Double = 0
    Dim vat As Double = 0

    Dim discount As Double = 0
    Dim supplier As String = 0
    Dim profitMargin As Double = 0
    Dim standardUom As String = ""
    Dim department As String = ""
    Dim _class As String = ""
    Dim subClass As String = ""
    Dim status As String = ""
    Private Function assignValues()
        primaryBarcode = txtPrimaryBarcode.Text
        code = txtCode.Text
        description = cmbDescription.Text
        shortDescription = txtShortDescription.Text
        commonDescription = txtCommonDescription.Text
        packSize = txtPackSize.Text
        costPriceVatIncl = Val(txtCostPriceVatIncl.Text)
        sellingPriceVatIncl = Val(txtSellingPriceVatIncl.Text)
        vat = Val(txtVat.Text)
        discount = Val(txtDiscount.Text)
        supplier = cmbSupplier.Text
        profitMargin = Val(txtProfitMargin.Text)
        standardUOM = txtStandardUom.Text
        department = cmbDepartment.Text
        _class = cmbClass.Text
        subClass = cmbSubClass.Text
        Return vbNull
    End Function
    Private Function validateInput()
        Dim valid As Boolean = False
        'code
        valid = True

        Return valid
    End Function
    Private Function getValues()
        txtPrimaryBarcode.Text = primaryBarcode
        txtCode.Text = code
        txtShortDescription.Text = shortDescription
        cmbDescription.Text = description
        txtCommonDescription.Text = commonDescription
        txtPackSize.Text = packSize
        txtCostPriceVatIncl.Text = costPriceVatIncl
        txtCostPriceVatExcl.Text = costPriceVatExcl
        txtSellingPriceVatIncl.Text = sellingPriceVatIncl
        txtSellingPriceVatExcl.Text = sellingPriceVatExcl
        txtVat.Text = vat
        txtDiscount.Text = discount
        'cmbSupplier.Text = supplier
        txtProfitMargin.Text = profitMargin
        txtStandardUom.Text = standardUOM
        'cmbDepartment.Text = department
        'cmbClass.Text = _class
        'cmbSubClass.Text = subClass
        Return vbNull
    End Function

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub
    Private Sub lock()
        txtPrimaryBarcode.ReadOnly = True
        txtCode.ReadOnly = True
        cmbDescription.Enabled = False
        txtCommonDescription.ReadOnly = True
        txtShortDescription.ReadOnly = True
        txtCostPriceVatIncl.ReadOnly = True
        txtSellingPriceVatIncl.ReadOnly = True
        txtIngredients.ReadOnly = True
        txtVat.ReadOnly = True
        txtDiscount.ReadOnly = True
        txtProfitMargin.ReadOnly = True
        txtStandardUom.ReadOnly = True
        cmbSupplier.Enabled = False
    End Sub
    Private Sub unlock()
        txtPrimaryBarcode.ReadOnly = False
        txtCode.ReadOnly = False
        cmbDescription.Enabled = True
        txtCommonDescription.ReadOnly = False
        txtShortDescription.ReadOnly = False
        txtCostPriceVatIncl.ReadOnly = False
        txtSellingPriceVatIncl.ReadOnly = False
        txtIngredients.ReadOnly = False
        txtVat.ReadOnly = False
        txtDiscount.ReadOnly = False
        txtProfitMargin.ReadOnly = False
        txtStandardUom.ReadOnly = False
        'cmbSupplier.Enabled = True
    End Sub
    Private Function clearAll()
        txtId.Text = ""
        txtPrimaryBarcode.Text = ""
        txtCode.Text = ""
        cmbDescription.Text = ""
        txtShortDescription.Text = ""
        txtCommonDescription.Text = ""
        txtPackSize.Text = ""
        txtCostPriceVatIncl.Text = ""
        txtCostPriceVatExcl.Text = ""
        txtSellingPriceVatIncl.Text = ""
        txtSellingPriceVatExcl.Text = ""
        txtIngredients.Text = ""
        txtVat.Text = ""
        txtDiscount.Text = ""
        cmbSupplier.SelectedItem = Nothing
        cmbSupplier.Text = ""
        txtProfitMargin.Text = ""
        txtStandardUom.Text = ""

        cmbDepartment.SelectedItem = Nothing
        cmbDepartment.Text = ""
        cmbClass.SelectedItem = Nothing
        cmbClass.Text = ""
        cmbSubClass.SelectedItem = Nothing
        cmbSubClass.Text = ""

        supplierID = ""
        departmentID = ""
        classID = ""
        subClassID = ""

        primaryBarcode = ""
        code = ""
        shortDescription = ""
        packSize = 1

        costPriceVatIncl = 0
        sellingPriceVatIncl = 0
        vat = 0

        discount = 0
        supplier = 0
        profitMargin = 0
        standardUOM = 0
        department = ""
        _class = ""
        subClass = ""

        chkDiscontinued.Checked = False

        Return vbNull
    End Function
    Private Function getMargin(costPrice As Double, sellingPrice As Double) As Double
        Dim margin_ As Double = 0
        margin_ = ((sellingPrice - costPrice) / costPrice) * 100
        Return margin_
    End Function
    Private Function getSellingPrice(costPrice As Double, margin_ As Double) As Double
        Dim sellingPrice As Double = 0
        sellingPrice = (Math.Ceiling((costPrice * ((margin_ / 100) + 1)) / 100)) * 100
        Return sellingPrice
    End Function
    Private Function validateData()
        Dim valid As Boolean = True

        Return valid
    End Function

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        unlock()
        clearAll()
        btnSearch.Enabled = False
        btnSave.Enabled = True
        txtCode.ReadOnly = False
        btnAddBarcode.Enabled = False
        btnDelete.Enabled = False
        generateItemCode()
    End Sub

    Private Sub btnEditInventory_Click(sender As Object, e As EventArgs) Handles btnEditInventory.Click
        If code <> "" Then
            Item.GLOBAL_ITEM_CODE = code
            frmEditInventory.ShowDialog()
        End If
    End Sub
    Private Sub generateItemCode()
        Dim no As String = ""

        Dim KeyGen As RandomKeyGenerator
        Dim NumKeys As Integer
        Dim i_Keys As Integer
        Dim RandomKey As String = ""

        ' MODIFY THIS TO GET MORE KEYS    - LAITH - 27/07/2005 22:48:30 -
        NumKeys = 6

        KeyGen = New RandomKeyGenerator
        KeyGen.KeyLetters = "1234567890"
        KeyGen.KeyNumbers = "0123456789"
        KeyGen.KeyChars = 3
        For i_Keys = 1 To NumKeys
            RandomKey = KeyGen.Generate()
        Next
        Dim str As String = ""
        While str.Length <> 3
            str = Math.Ceiling(VBMath.Rnd * 1000)
            If str.Length = 3 Then
                Exit While
            End If
        End While
        Dim code As String = str + RandomKey.ToString
        If (New Item).searchItem(code) Then
            generateItemCode()
        Else
            txtCode.Text = code
        End If
    End Sub

    Private Sub frmProductMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lock()
        If User.authorize("EDIT INVENTORY") Then
            btnEditInventory.Enabled = True
        End If
        Dim supplier As New Supplier
        cmbSupplier.Items.Add("")
        cmbSupplier.Items.AddRange(supplier.getNames().ToArray)
        cmbDepartment.Items.Clear()
        Dim list As New List(Of Department)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("departments")
            list = JsonConvert.DeserializeObject(Of List(Of Department))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try
        cmbDepartment.Items.Add("")
        For Each department_ As Department In list
            cmbDepartment.Items.Add(department_.name)
        Next
        Dim product_ As New Product
        longList = product_.getDescriptions
    End Sub

    Private Sub cmbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartment.SelectedIndexChanged
        classID = ""
        cmbClass.Text = ""
        cmbClass.Items.Clear()
        subClassID = ""
        cmbSubClass.Text = ""
        cmbSubClass.Items.Clear()
        If cmbDepartment.Text = "" Then
            Exit Sub
        End If
        Dim list As New List(Of Class_)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("classes/department_name=" + cmbDepartment.Text)
            list = JsonConvert.DeserializeObject(Of List(Of Class_))(response.ToString)
        Catch ex As Exception
            ' MsgBox(ex.ToString)
            Exit Sub
        End Try
        For Each class_ As Class_ In list
            cmbClass.Items.Add(class_.name)
        Next

        Exit Sub

    End Sub

    Private Sub cmbClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClass.SelectedIndexChanged

        cmbSubClass.Text = ""
        cmbSubClass.Items.Clear()

        If cmbClass.Text = "" Then
            Exit Sub
        End If

        Dim list As New List(Of SubClass)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("sub_classes/class_name=" + cmbClass.Text)
            list = JsonConvert.DeserializeObject(Of List(Of SubClass))(response.ToString)
        Catch ex As Exception
            ' MsgBox(ex.ToString)
            Exit Sub
        End Try
        For Each subClass As SubClass In list
            cmbSubClass.Items.Add(subClass.name)
        Next
    End Sub

    Private Sub cmbSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSupplier.SelectedIndexChanged
        Dim conn As New MySqlConnection(Database.conString)
        If cmbSupplier.Text = "" Then
            supplierID = ""
        End If
        Try
            Dim suppcommand As New MySqlCommand()
            Dim supplierQuery As String = "SELECT  `supplier_id`, `supplier_name` FROM `supplier` WHERE `supplier_name`='" + cmbSupplier.Text + "'"
            conn.Open()
            suppcommand.CommandText = supplierQuery
            suppcommand.Connection = conn
            suppcommand.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = suppcommand.ExecuteReader
            If reader.HasRows Then
                While reader.Read
                    supplierID = reader.GetString("supplier_id")
                    Exit While
                End While
            End If

            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            ErrorMessage.dbConnectionError()
            Exit Sub
        End Try
    End Sub

    Private Sub cmbSubClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubClass.SelectedIndexChanged
        If cmbSubClass.Text = "" Then
            subClassID = ""
        End If
        Dim conn As New MySqlConnection(Database.conString)

        Try
            Dim command As New MySqlCommand()
            Dim Query As String = "SELECT `sub_class_id`, `sub_class_name` FROM `sub_class` WHERE `sub_class_name`='" + cmbSubClass.Text + "'"
            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader
            If reader.HasRows Then
                While reader.Read
                    subClassID = reader.GetString("sub_class_id")
                    Exit While
                End While
            End If
            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            ErrorMessage.dbConnectionError()
            Exit Sub
        End Try
    End Sub
    Private Function validateValues() As Boolean
        Dim valid As Boolean = True
        Dim msg As String = ""
        If txtCode.Text = "" Then
            msg = "Item code required"
            valid = False
            txtCode.Focus()
        ElseIf cmbDescription.Text = "" Then
            msg = "Long Description required"
            valid = False
            cmbDescription.Focus()
        ElseIf txtShortDescription.Text = "" Then
            msg = "Short Description required"
            valid = False
            txtShortDescription.Focus()
        ElseIf txtVat.Text = "" Then
            msg = "VAT required"
            valid = False
            txtVat.Focus()
        ElseIf txtCostPriceVatIncl.Text = "" Or Not IsNumeric(txtCostPriceVatIncl.Text) Or Val(txtCostPriceVatIncl.Text) < 0 Then
            msg = "Invalid Cost price. Cost price should be numeric"
            valid = False
            txtVat.Focus()
        ElseIf txtSellingPriceVatIncl.Text = "" Or Not IsNumeric(txtSellingPriceVatIncl.Text) Or Val(txtSellingPriceVatIncl.Text) < 0 Then
            msg = "Invalid Retail price. Retail price should be numeric"
            valid = False
            txtVat.Focus()
        End If
        If valid = False Then
            MsgBox("Could not complete operation. " + msg, vbOKOnly + vbCritical, "Error: Invalid entry")
            Return valid
            Exit Function
        End If
        Return valid
    End Function

    Private Sub btnSave_Click1(sender As Object, e As EventArgs) Handles btnSave.Click
        If validateValues() = False Then
            'stop operation if the values are invalid
            Exit Sub
        End If
        Dim product As Product = New Product
        product.id = txtId.Text
        If txtPrimaryBarcode.Text = "" Then
            product.primaryBarcode = Nothing
        Else
            product.primaryBarcode = txtPrimaryBarcode.Text
        End If
        product.code = txtCode.Text
        product.description = cmbDescription.Text
        product.shortDescription = txtShortDescription.Text
        product.commonDescription = txtCommonDescription.Text
        product.standardUom = txtStandardUom.Text
        product.packSize = txtPackSize.Text
        product.ingredients = txtIngredients.Text
        product.costPriceVatIncl = txtCostPriceVatIncl.Text
        product.costPriceVatExcl = txtCostPriceVatExcl.Text
        product.sellingPriceVatIncl = txtSellingPriceVatIncl.Text
        product.sellingPriceVatExcl = txtSellingPriceVatExcl.Text
        product.profitMargin = txtProfitMargin.Text
        product.vat = txtVat.Text
        product.discount = txtDiscount.Text
        product.primarySupplier.name = cmbSupplier.Text
        product.department.name = cmbDepartment.Text
        product.clas.name = cmbClass.Text
        product.subClass.name = cmbSubClass.Text

        If chkDiscontinued.Checked = True Then
            product.status = "DISCONTINUED"
        Else
            product.status = "ACTIVE"
        End If
        If chkSellable.Checked = True Then
            product.sellable = 1
        Else
            product.sellable = 0
        End If
        If chkReturnable.Checked = True Then
            product.returnable = 1
        Else
            product.returnable = 0
        End If
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            Dim success As Boolean = False
            If txtId.Text = "" Then
                response = Web.post(product, "products/new")
                json = JObject.Parse(response)
                'Dim data As Product = New Product
                txtId.Text = json.SelectToken("id")
                success = True
                btnSave.Enabled = False
                Dim res As Integer = MsgBox("Product successifully saved. Edit inventory?", vbQuestion + vbYesNo, "Success: Product saved.")
                If res = DialogResult.Yes Then
                    response = Web.get_("products/get_by_id?id=" + txtId.Text)
                    json = JObject.Parse(response)
                    product = JsonConvert.DeserializeObject(Of Product)(json.ToString)
                    Product.GLOBAL_PRODUCT = product
                    frmEditInventory.ShowDialog()
                Else
                    clearAll()
                End If
            Else
                If Web.put(product, "products/edit_by_id?id=" + txtId.Text) = True Then
                    btnSave.Enabled = False
                    Dim res As Integer = MsgBox("Product successifully modified. Edit inventory?", vbQuestion + vbYesNo, "Success: Product modified.")
                    If res = DialogResult.Yes Then
                        response = Web.get_("products/get_by_id?id=" + txtId.Text)
                        json = JObject.Parse(response)
                        product = JsonConvert.DeserializeObject(Of Product)(json.ToString)
                        Product.GLOBAL_PRODUCT = product
                        frmEditInventory.ShowDialog()
                    Else
                        clearAll()
                    End If
                Else
                    MsgBox("Update failed")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("Operation failed")
            Exit Sub
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If txtId.Text = "" Then
            unlock()
            btnSave.Enabled = False
            btnSearch.Enabled = True
            txtCode.ReadOnly = False
            clearAll()
        Else
            unlock()
            btnSave.Enabled = True
            btnSearch.Enabled = True
            txtCode.ReadOnly = True
        End If
    End Sub
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
            btnAddBarcode.Enabled = False
            btnDelete.Enabled = False
            MsgBox("No matching product", vbOKOnly + vbCritical, "Error: Not found")
            txtCode.ReadOnly = False
            txtPrimaryBarcode.ReadOnly = False
        Else
            btnAddBarcode.Enabled = True
            btnDelete.Enabled = True
            btnSave.Enabled = True

            txtId.Text = product.id
            Product.GLOBAL_PRODUCT = product
            txtPrimaryBarcode.Text = product.primaryBarcode
            txtCode.Text = product.code
            cmbDescription.Text = product.description
            txtShortDescription.Text = product.shortDescription
            txtCommonDescription.Text = product.commonDescription
            txtStandardUom.Text = product.standardUom
            txtPackSize.Text = product.packSize
            txtIngredients.Text = product.ingredients
            txtCostPriceVatIncl.Text = product.costPriceVatIncl
            txtCostPriceVatExcl.Text = product.costPriceVatExcl
            txtSellingPriceVatIncl.Text = product.sellingPriceVatIncl
            txtSellingPriceVatExcl.Text = product.sellingPriceVatExcl
            txtProfitMargin.Text = product.profitMargin
            txtVat.Text = product.vat
            txtDiscount.Text = product.discount
            If Not IsNothing(product.department) Then
                cmbDepartment.Text = product.department.name
            End If
            If Not IsNothing(product.clas) Then
                cmbClass.Text = product.clas.name
            End If
            If Not IsNothing(product.subClass) Then
                cmbSubClass.Text = product.subClass.name
            End If
            If Not IsNothing(product.primarySupplier) Then
                cmbSupplier.Text = product.primarySupplier.name
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

                assignValues()

            End If

            Return vbNull
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search()
    End Sub
    Public Shared GLOBAL_ITEM_CODE As String = ""
    Private Sub btnAddBarcode_Click(sender As Object, e As EventArgs) Handles btnAddBarcode.Click
        GLOBAL_ITEM_CODE = txtCode.Text
        frmAddBarCode.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub txtLongDescription_TextChanged(sender As Object, e As EventArgs)
        Dim list As New List(Of String)
        Dim mySource As New AutoCompleteStringCollection
        Dim item As New Item
        list = item.getItems(cmbDescription.Text)
        mySource.AddRange(list.ToArray)
        cmbDescription.AutoCompleteCustomSource = mySource
        cmbDescription.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbDescription.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub
    Private Sub txtmargin_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProfitMargin.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSellingPriceVatIncl.Text = getSellingPrice(Val(txtCostPriceVatIncl.Text), Val(txtProfitMargin.Text)).ToString
        End If
    End Sub
    Private Sub txtretailprice_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSellingPriceVatIncl.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtProfitMargin.Text = getMargin(Val(txtCostPriceVatIncl.Text), Val(txtSellingPriceVatIncl.Text)).ToString
        End If
    End Sub
    Private Function delete(id As String) As Boolean
        Dim success As Boolean = False
        If id = "" Then
            MsgBox(" No item selected. Please specify an item To delete.", vbOKOnly + vbCritical, "Error: No selection")
            Return vbNull
            Exit Function
        End If
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected item? All information about this item will be removed from the system.", vbYesNo + vbQuestion, "Delete item?")
        If res = DialogResult.Yes Then
            'delete the item
            'will proceed to delete the item
        Else
            'do not delete the item; discard operation
            Return vbNull
            Exit Function
        End If
        ' MsgBox("Could not delete")
        'Return False
        Try
            Dim response As String
            response = Web.delete("products/delete_by_id?id=" + txtId.Text)
            success = True
            clearAll()
            MsgBox("Product successifully deleted", vbOKOnly + vbInformation, "Success: Delete success")
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        btnSearch.Enabled = False
        Return success
    End Function
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        delete(txtId.Text)
    End Sub

    Private Sub txtBarCode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtPrimaryBarcode.PreviewKeyDown

        If e.KeyCode = Keys.Tab Then
            txtCode.Text = ""
            cmbDescription.Text = ""
            search()
        End If
    End Sub
    Private Sub txtCode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtCode.PreviewKeyDown

        If e.KeyCode = Keys.Tab Then
            txtPrimaryBarcode.Text = ""
            cmbDescription.Text = ""
            search()
        End If
    End Sub
    Private Sub txtLongDescr_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)

        If e.KeyCode = Keys.Tab Then
            txtPrimaryBarcode.Text = ""
            txtCode.Text = ""
            search()
        End If
    End Sub

    Private Sub txtMargin_TextChanged(sender As Object, e As EventArgs) Handles txtProfitMargin.TextChanged

    End Sub

    Private Sub txtItemCode_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged
        If txtCode.Text.Contains("'") Then
            txtCode.Text = ""
        End If
    End Sub

    Private Sub txtLongDescription_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtBarCode_TextChanged(sender As Object, e As EventArgs) Handles txtPrimaryBarcode.TextChanged
        If txtPrimaryBarcode.Text.Contains("'") Then
            txtPrimaryBarcode.Text = ""
        End If
    End Sub
    Private Sub txtBarCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrimaryBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPrimaryBarcode.Text <> "" Then
                search()
            End If
        End If
    End Sub


    Private Sub btnViewSuppliers_Click(sender As Object, e As EventArgs) Handles btnViewSuppliers.Click
        If code <> "" Then
            GLOBAL_ITEM_CODE = txtCode.Text
            frmViewSuppliers.ShowDialog()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnEditSupplier.Click
        cmbSupplier.Enabled = True
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

    Private Sub cmbDescription_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDescription.SelectedIndexChanged
        If cmbDescription.Text.Contains("'") Then
            cmbDescription.Text = ""
        End If
    End Sub
    Private Sub cmbDescription_TextChanged(sender As Object, e As EventArgs) Handles cmbDescription.TextChanged

        If cmbDescription.Text.Contains("'") Then
            Try
                cmbDescription.Text = cmbDescription.Text.Replace("'", "")
            Catch ex As Exception
                cmbDescription.Text = ""
            End Try
        End If
    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtShortDescription.TextChanged
        If txtShortDescription.Text.Contains("'") Then
            txtShortDescription.Text = ""
        End If
    End Sub

    Private Sub cmbPck_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtPackSize.SelectedIndexChanged
        If txtPackSize.Text.Contains("'") Then
            txtPackSize.Text = ""
        End If
    End Sub

    Private Sub txtStandardUOM_TextChanged(sender As Object, e As EventArgs) Handles txtStandardUom.TextChanged
        If txtStandardUom.Text.Contains("'") Then
            txtStandardUom.Text = ""
        End If
    End Sub
End Class
