Imports Devart.Data.MySql

Public Class frmSupplierService
    Dim EDIT_MODE As String = ""
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Dispose()
    End Sub

    Private Sub frmSupplierService_Load(sender As Object, e As EventArgs) Handles Me.Shown
        clear() 'clear the fields
        lock()
        Dim supcode As String = frmSuppliers.GLOBAL_SUPPLIER_CODE
        Dim supplier As New Supplier
        Dim supplierID As String = supplier.getSupplierID(supcode, "")
        Dim supplierCode As String = ""
        Dim supplierName As String = ""
        Dim contactName As String = ""

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `supplier_id`, `supplier_code`, `supplier_name`, `contact_name` FROM `supplier` WHERE `supplier_id`='" + supplierID + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                supplierCode = reader.GetString("supplier_code")
                supplierName = reader.GetString("supplier_name")
                contactName = reader.GetString("contact_name")
                Exit While
            End While
            conn.Close()
            txtSupplierCode.Text = supplierCode
            txtSupplierName.Text = supplierName
            txtContactName.Text = contactName
        Catch ex As Exception
            'added = False
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs)
        EDIT_MODE = "NEW"
        btnDelete.Enabled = False
        btnSave.Enabled = True
        clearFields()
        unlock()
    End Sub
    Private Function searchService(itemCode As String, supplierID As String) As Boolean
        Dim found As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT  `supplier_id`, `item_code`, `service_description`, `vat_no`, `packing`, `cost_price_vat_incl`, `cost_price_vat_excl`, `terms_of_payment` FROM `supplier_item` WHERE `supplier_id`='" + supplierID + "' AND `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtServiceDescr.Text = reader.GetString("service_description")
                txtVATNo.Text = reader.GetString("vat_no")
                cmbPacking.Text = reader.GetString("packing")
                txtCostVatIncl.Text = reader.GetString("cost_price_vat_incl")
                txtCostVatExcl.Text = reader.GetString("cost_price_vat_excl")
                txtTermsOfPayment.Text = reader.GetString("terms_of_payment")

                txtCode.Text = txtItemCode.Text

                found = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'added = False
            MsgBox(ex.Message)
        End Try
        Return found
    End Function
    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        EDIT_MODE = ""
        unlock()
    End Sub
    Private Function clearFields()
        txtBarCode.Text = ""
        txtItemCode.Text = ""
        txtItem.Text = ""
        txtCode.Text = ""
        txtServiceDescr.Text = ""
        cmbPacking.Text = ""
        txtCostVatIncl.Text = ""
        txtCostVatExcl.Text = ""
        txtVATNo.Text = ""
        txtTermsOfPayment.Text = ""
        Return vbNull
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If EDIT_MODE = "NEW" And txtCode.Text <> "" Then
            If ((New SupplierService).addNewService(txtItemCode.Text, (New Supplier).getSupplierID(txtSupplierCode.Text, ""), txtServiceDescr.Text, cmbPacking.Text, txtCostVatIncl.Text, txtCostVatExcl.Text, txtVATNo.Text, txtTermsOfPayment.Text)) = True Then
                btnSave.Enabled = False
                lock()
                MsgBox("New supplier service added", vbOKOnly + vbInformation, "Success")
            Else
                MsgBox("Could not add service", vbOKOnly + vbInformation, "Error: Adding failed")
            End If
        ElseIf EDIT_MODE = "" Then
            If ((New SupplierService).editService((New SupplierService).getServiceID(txtCode.Text, (New Supplier).getSupplierID(txtSupplierCode.Text, "")), txtServiceDescr.Text, cmbPacking.Text, txtCostVatIncl.Text, txtCostVatExcl.Text, txtVATNo.Text, txtTermsOfPayment.Text)) = True Then
                btnSave.Enabled = False
                lock()
                MsgBox("Edit successiful", vbOKOnly + vbInformation, "Success")
            Else
                MsgBox("Could not edit service", vbOKOnly + vbInformation, "Error: Edit failed")
            End If
        Else
            MsgBox("Please select product to be supplied by the supplier", vbOKOnly + vbCritical, "Error: No input")
        End If
        refreshList()
    End Sub
    Private Function clear()
        txtBarCode.Text = ""
        txtItemCode.Text = ""
        txtCode.Text = ""
        txtItem.Text = ""
        txtServiceDescr.Text = ""
        cmbPacking.Text = ""
        txtCostVatIncl.Text = ""
        txtCostVatExcl.Text = ""
        txtVATNo.Text = ""
        txtTermsOfPayment.Text = ""
        Return vbNull
    End Function
    Private Function getItem(itemCode As String) As String
        Dim item As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `item_long_description`, `item_description` FROM `items` WHERE `item_code`='" + itemCode + "' "
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                item = reader.GetString("item_long_description")
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return item
    End Function
    Private Function refreshList()

        dtgrdServices.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code

            Dim supplier As New Supplier
            Dim codeQuery As String = "SELECT  `item_code`, `cost_price_vat_incl`, `cost_price_vat_excl` FROM `supplier_item` WHERE `supplier_id`='" + supplier.getSupplierID(txtSupplierCode.Text, "") + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim itemCode As String = ""
            Dim item As String = ""
            Dim costPriceVatIncl As String = ""
            Dim costPriceVatExcl As String = ""

            While reader.Read

                itemCode = reader.GetString("item_code")
                costPriceVatIncl = reader.GetString("cost_price_vat_incl")
                costPriceVatExcl = reader.GetString("cost_price_vat_excl")
                item = getItem(itemCode)

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = item
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = costPriceVatIncl
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = costPriceVatExcl
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdServices.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return vbNull
    End Function

    Private Sub frmSupplierService_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        refreshList()
    End Sub
    Private Function searchItem(itemCode As String) As Boolean
        Dim found As Boolean = False
        Dim item_Code As String = ""
        Dim descr As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code

            Dim supplier As New Supplier
            Dim codeQuery As String = "SELECT `item_code`, `item_long_description` FROM `items` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()


            While reader.Read
                item_Code = reader.GetString("item_code")
                descr = reader.GetString("item_long_description")
                found = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        txtItemCode.Text = item_Code
        txtItem.Text = descr
        Return found
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs)
        Dim item As New Item
        txtCode.Text = ""
        Dim supplier As New Supplier
        If txtBarCode.Text <> "" Then
            txtItemCode.Text = ""
            txtItem.Text = ""
            If searchItem(item.getItemCode(txtBarCode.Text, "")) = True Then
                'btnAddNew.Enabled = True
                txtCode.Text = txtItemCode.Text
            Else
                MsgBox("No matching item with barcode " + txtBarCode.Text, vbOKOnly + vbCritical, "Error: Not found")
                txtBarCode.Text = ""
                'btnAddNew.Enabled = False
                txtCode.Text = ""
            End If
        ElseIf txtItemCode.Text <> "" Then
            txtItem.Text = ""
            If searchItem(txtItemCode.Text) = True Then
                'btnAddNew.Enabled = True
                txtCode.Text = txtItemCode.Text
            Else
                MsgBox("No matching item with code " + txtItemCode.Text, vbOKOnly + vbCritical, "Error: Not found")
                txtItemCode.Text = ""
                'btnAddNew.Enabled = False
                txtCode.Text = ""
            End If
        Else
            If searchItem(item.getItemCode("", txtItem.Text)) = True Then
                'btnAddNew.Enabled = True
                txtCode.Text = txtItemCode.Text
            Else
                MsgBox("No matching item with the specified description ", vbOKOnly + vbCritical, "Error: Not found")
                txtItem.Text = ""
                'btnAddNew.Enabled = False
                txtCode.Text = ""
            End If
        End If
        If txtCode.Text <> "" Then
            EDIT_MODE = ""
            btnDelete.Enabled = True
            'btnSave.Enabled = True
            lock()
            If searchService(txtCode.Text, supplier.getSupplierID(txtSupplierCode.Text, "")) <> True Then
                MsgBox("The selected supplier does not supply this product", vbOKOnly + vbInformation, "")
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If EDIT_MODE = "" Then
            Dim res As Integer = MsgBox("Are you sure you want to remove the service from this supplier?", vbYesNo + vbQuestion, "Remove Service")
            If res = DialogResult.Yes Then
                Dim supplierService As New SupplierService
                supplierService.deleteService((New SupplierService).getServiceID(txtCode.Text, (New Supplier).getSupplierID(txtSupplierCode.Text, "")))
                refreshList()
                clear()
                MsgBox("Service successifuly removed", vbOKOnly + vbInformation, "Success")
            End If

        End If
    End Sub
    Private Function lock()
        txtServiceDescr.ReadOnly = True
        cmbPacking.Enabled = False
        txtCostVatIncl.ReadOnly = True
        txtCostVatExcl.ReadOnly = True
        txtVATNo.ReadOnly = True
        txtTermsOfPayment.ReadOnly = True
        Return vbNull
    End Function
    Private Function unlock()
        txtServiceDescr.ReadOnly = False
        cmbPacking.Enabled = True
        txtCostVatIncl.ReadOnly = False
        txtCostVatExcl.ReadOnly = False
        txtVATNo.ReadOnly = False
        txtTermsOfPayment.ReadOnly = False
        Return vbNull
    End Function
    Private Sub dtgrdServices_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdServices.CellContentClick

    End Sub

    Private Sub dtgrdServices_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdServices.RowHeaderMouseClick

        Dim row As Integer = -1
        Dim col As Integer = -1
        Try
            row = dtgrdServices.CurrentRow.Index
            col = dtgrdServices.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try
        Dim supplierService As String = ""
        Dim item As New Item
        Dim supplier As New Supplier
        row = dtgrdServices.CurrentRow.Index
        supplierService = dtgrdServices.Item(0, row).Value.ToString
        Dim itemCode As String = item.getItemCode("", supplierService)
        If searchItem(itemCode) = True Then
            btnDelete.Enabled = True
            btnSave.Enabled = True
            lock()
            EDIT_MODE = ""
        End If
        If searchService(itemCode, supplier.getSupplierID(txtSupplierCode.Text, "")) = True Then
            btnDelete.Enabled = True
            btnSave.Enabled = True
            lock()
            EDIT_MODE = ""
        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub
    Private Function search()

        Dim itemCode As String = ""
        If txtBarCode.Text <> "" Then
            itemCode = (New Item).getItemCode(txtBarCode.Text, "")
        ElseIf txtItemCode.Text <> "" Then
            txtBarCode.Text = ""
            itemCode = txtItemCode.Text
        ElseIf txtItem.Text <> "" Then
            itemCode = (New Item).getItemCode("", txtItem.Text)
        Else
            itemCode = ""
        End If
        If itemCode <> "" And (New Item).isExist(itemCode) Then
            Dim item As New Item
            EDIT_MODE = ""
            item.searchItem(itemCode)
            txtItemCode.Text = item.GL_ITEM_CODE
            txtItem.Text = item.GL_LONG_DESCR
            txtCode.Text = item.GL_ITEM_CODE
            'unlock()

            btnSave.Enabled = True
        Else
            EDIT_MODE = ""
            txtBarCode.Text = ""
            txtItemCode.Text = ""
            txtItemCode.Text = ""
            txtCode.Text = ""

            btnSave.Enabled = False
            btnDelete.Enabled = False

            MsgBox("No matching item", vbOKOnly + vbCritical, "Error: Not found")
            Return vbNull
            Exit Function
        End If
        Dim service As New SupplierService
        If service.searchService(itemCode, (New Supplier).getSupplierID(txtSupplierCode.Text, "")) <> True Then
            unlock()
            EDIT_MODE = "NEW"
            btnSave.Enabled = True
            btnDelete.Enabled = False

        Else
            lock()
            EDIT_MODE = ""
            btnSave.Enabled = True
            btnDelete.Enabled = True
            txtServiceDescr.Text = service.GL_SERVICE_DESCRIPTION
            txtVATNo.Text = service.GL_VAT_NO
            cmbPacking.Text = service.GL_PACKING
            txtCostVatIncl.Text = service.GL_COST_PRICE_VAT_INCL
            txtCostVatExcl.Text = service.GL_COST_PRICE_VAT_EXCL
            txtTermsOfPayment.Text = service.GL_TERMS_OF_PAYMENT

            btnSave.Enabled = True
        End If

        Return vbNull
    End Function
    Private Sub btnSearch_Click_1(sender As Object, e As EventArgs) Handles btnSearch.Click
        search()
    End Sub

    Private Sub btnEdit_Click_1(sender As Object, e As EventArgs) Handles btnEdit.Click

        unlock()
        btnSave.Enabled = True
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        clear()
        lock()
        btnSave.Enabled = False
        btnDelete.Enabled = False
    End Sub



    Private Sub txtBarCode_TextChanged(sender As Object, e As PreviewKeyDownEventArgs) Handles txtBarCode.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            txtItem.Text = ""
            search()
        End If
    End Sub
    Private Sub txtitemcode_TextChanged(sender As Object, e As PreviewKeyDownEventArgs) Handles txtItemCode.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            txtBarCode.Text = ""
            search()
        End If
    End Sub

    Private Sub txtItem_MouseEnter(sender As Object, e As EventArgs) Handles txtItem.MouseEnter
        Dim list As New List(Of String)
        Dim mySource As New AutoCompleteStringCollection
        Dim item As New Item
        list = item.getItems(txtItem.Text)
        mySource.AddRange(list.ToArray)
        txtItem.AutoCompleteCustomSource = mySource
        txtItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtItem.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub

    Private Sub frmSupplierService_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class