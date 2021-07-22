Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmSaleInvoice
    Dim EDIT_MODE As String = ""
    Dim ORDER_STAT As String = ""
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Function lock()
        txtContact.ReadOnly = True
        txtName.ReadOnly = True
        Return vbNull
    End Function
    Private Function unlock()
        txtContact.ReadOnly = False
        txtName.ReadOnly = False
        Return vbNull
    End Function
    Private Function clear()
        txtSaleInvoiceNo.Text = ""
        txtContact.Text = ""
        txtName.Text = ""
        txtTotal.Text = ""
        txtSaleInvoiceStatus.Text = ""
        txtSaleInvoiceDate.Text = ""
        dtgrdItemList.Rows.Clear()

        Return vbNull
    End Function


    Private Function searchInvoice(invoiceNo As String) As Boolean
        Dim found As Boolean = False
        Dim invoice As New SaleInvoice
        If invoice.getSaleInvoice(invoiceNo) = True Then
            txtSaleInvoiceNo.ReadOnly = True
            txtContact.Text = invoice.GL_CONTACT
            txtName.Text = invoice.GL_NAME
            txtSaleInvoiceDate.Text = invoice.GL_INVOICE_DATE
            txtSaleInvoiceStatus.Text = invoice.GL_STATUS


            lock()
        End If
        Return found
    End Function
    Private Function search()
        If txtSaleInvoiceNo.Text = "" Then
            MsgBox("Can not process invoice. Please specify whether the invoice is new or existing by selecting New or Edit", vbOKOnly + vbCritical, "Invalid operation")
            Return vbNull
            Exit Function
        End If
        If txtSaleInvoiceNo.ReadOnly = False Then
            Dim invoice As New SaleInvoice
            If invoice.getSaleInvoice(txtSaleInvoiceNo.Text) = True Then
                txtSaleInvoiceNo.ReadOnly = True
                'txtOrderNo.Text = order.GL_ORDER_NO
                txtContact.Text = invoice.GL_CONTACT
                txtName.Text = invoice.GL_NAME
                txtSaleInvoiceDate.Text = invoice.GL_INVOICE_DATE
                txtSaleInvoiceStatus.Text = invoice.GL_STATUS
                lock()
                refreshList()

                'End If
                'If searchOrder(txtOrderNo.Text) = True Then
                EDIT_MODE = ""
                'txtOrderNo.ReadOnly = True
                lock()
                Dim status As String = invoice.GL_STATUS



            Else
                MsgBox("No matching sale invoice", vbOKOnly + vbCritical, "Error: Not found")
                Return vbNull
                Exit Function
            End If
        End If

        Return vbNull
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        EDIT_MODE = "NEW"
        ORDER_STAT = "NEW"
        txtSaleInvoiceNo.ReadOnly = True
        txtContact.ReadOnly = False
        txtName.ReadOnly = False
        txtSaleInvoiceStatus.Text = ""
        txtSaleInvoiceDate.Text = Day.DAY
        unlock()
        btnSave.Enabled = False
        btnDelete.Enabled = False
        clear()
        txtSaleInvoiceNo.Text = (New SaleInvoice).generateInvoiceNo
        If txtSaleInvoiceNo.Text = "" Then
            txtSaleInvoiceNo.Text = "INV1"
        End If
        dtgrdItemList.Rows.Clear()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        'If User.authorize("EDIT LPO") = True Then


        'Else
        'MsgBox("Action denied for current user.", vbOKOnly + vbExclamation, "Action denied")
        'Exit Sub
        ' End If
        If txtSaleInvoiceStatus.Text = "NEW" Then
            txtSaleInvoiceStatus.Text = ""
        End If
        EDIT_MODE = ""
        ORDER_STAT = ""
        txtSaleInvoiceNo.ReadOnly = False
        lock()
        btnDelete.Enabled = True
        clear()
    End Sub




    Private Function saveNewSaleInvoice() As String
        Dim ordNo As String = ""
        Try
            Dim invoice As New SaleInvoice
            invoice.GL_INVOICE_NO = txtSaleInvoiceNo.Text
            invoice.GL_INVOICE_DATE = txtSaleInvoiceDate.Text
            invoice.GL_CONTACT = txtContact.Text
            invoice.GL_NAME = txtName.Text
            invoice.GL_STATUS = "PENDING"
            invoice.GL_USER_ID = User.CURRENT_USER_ID
            invoice.addNewInvoice()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function

    Private Function saveInvoiceDetail(invoiceNo As String, itemCode As String, qty As Double, unitCostPrice As Double, stockSize As Double) As Boolean
        Dim success As Boolean = False
        Try
            Dim invoice As New SaleInvoice
            invoice.GL_INVOICE_NO = invoiceNo
            invoice.GL_ITEM_CODE = itemCode
            invoice.GL_QUANTITY = qty
            invoice.GL_UNIT_COST_PRICE = unitCostPrice
            invoice.GL_STOCK_SIZE = stockSize
            invoice.addInvoiceDetails()
            success = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        refreshList()

        If dtgrdItemList.RowCount > 0 Then
            Dim invoice As New SaleInvoice
            'update the fields
            invoice.GL_INVOICE_DATE = txtSaleInvoiceDate.Text
            invoice.GL_STATUS = "PENDING"
            invoice.GL_USER_ID = User.CURRENT_USER_ID
            invoice.editInvoice(txtSaleInvoiceNo.Text)
            MsgBox("Order saved.", vbOKOnly + vbInformation, "Success")
        Else
            MsgBox("No items are listed in this invoice.", vbOKOnly + vbExclamation, "Invalid operation")

        End If

    End Sub
    Private Function refreshList()
        dtgrdItemList.Rows.Clear()
        Try

            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `sn`, `invoice_no`, `item_code`, `quantity`, `cost_price`, `selling_price` FROM `sale_invoice_details` WHERE `invoice_no`='" + txtSaleInvoiceNo.Text + "' "
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim sn As String = ""
            Dim barCode As String = ""
            Dim itemCode As String = ""
            Dim description As String = ""
            Dim quantity As String = ""
            Dim packSize As String = ""
            Dim unitSellingPrice As String = ""
            Dim unitCostPrice As String = ""
            Dim costPrice As Double = 0
            Dim sellingPrice As Double = 0
            Dim totalSellingPrice As Double = 0


            While reader.Read
                Dim item As New Item
                itemCode = reader.GetString("item_code")
                item.searchItem(itemCode)
                sn = reader.GetString("sn")
                description = item.GL_LONG_DESCR
                quantity = reader.GetString("quantity")
                packSize = item.GL_PCK
                unitSellingPrice = Val(reader.GetString("selling_price"))
                unitCostPrice = Val(reader.GetString("cost_price"))
                sellingPrice = Val(quantity) * Val(unitSellingPrice)
                costPrice = Val(quantity) * Val(unitCostPrice)

                totalSellingPrice = totalSellingPrice + sellingPrice


                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = barCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = itemCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = description
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = quantity
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(unitSellingPrice)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(sellingPrice.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = ""
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = ""
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = sn
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdItemList.Rows.Add(dtgrdRow)
            End While
            txtTotal.Text = LCurrency.displayValue(totalSellingPrice)
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function

    Private Sub dtgrdItemList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdItemList.CellContentClick

    End Sub

    Private Sub dtgrdItemList_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdItemList.RowHeaderMouseDoubleClick

        Dim status As String = (New Order).getStatus(txtSaleInvoiceNo.Text)
        If status = "APPROVED" Then
            MsgBox("You can not edit this order. Order already approved.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "PRINTED" Then
            MsgBox("You can not edit this order. Order already printed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "REPRINTED" Then
            MsgBox("You can not edit this order. Order already printed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("You can not edit this order. Order already completed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("You can not edit this order. Order canceled.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If


        Dim row As Integer = -1
        row = dtgrdItemList.CurrentRow.Index

        Dim barCode As String = dtgrdItemList.Item(0, row).Value
        Dim itemCode As String = dtgrdItemList.Item(1, row).Value
        Dim description As String = dtgrdItemList.Item(2, row).Value
        Dim quantity As String = dtgrdItemList.Item(3, row).Value
        Dim sellingPrice As String = dtgrdItemList.Item(4, row).Value
        Dim sn As String = dtgrdItemList.Item(8, row).Value

        Dim dtgrdRow As New DataGridViewRow

        txtItemCodeS.Text = itemCode
        txtDescription.Text = description
        txtQuantity.Text = quantity
        txtSellingPrice.Text = LCurrency.displayValue(sellingPrice)

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `sale_invoice_details` WHERE `sn`='" + sn + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            lockFields()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        refreshList()

    End Sub

    Private Sub frmSaleInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtSaleInvoiceNo.Text = ""
        txtContact.Text = ""
        txtName.Text = ""
        txtSaleInvoiceDate.Text = ""
        txtSaleInvoiceStatus.Text = ""
        txtContact.ReadOnly = True
        txtName.ReadOnly = True
    End Sub

    Private Sub frmPurchaseOrder_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtSaleInvoiceNo.Text = ""
        dtgrdItemList.Rows.Clear()

    End Sub





    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtSaleInvoiceNo.Text = "" Then
            MsgBox("Please select an order to delete.", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If
        Dim invoice As New SaleInvoice
        If invoice.isInvoiceExist(txtSaleInvoiceNo.Text) <> True Then
            MsgBox("No matching invoice", vbOKOnly + vbExclamation, "")
            Exit Sub
        End If
        search()
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected invoice: " + txtSaleInvoiceNo.Text + " ? Information on this invoice will be removed from the system.", vbYesNo + vbQuestion, "Delete order?")
        If res = DialogResult.Yes Then
            invoice.deleteSaleInvoice(txtSaleInvoiceNo.Text)
            MsgBox("Sale Invoice Successively removed", vbOKOnly + vbInformation, "")
        End If
    End Sub

    Private Sub txtOrderDate_TextChanged(sender As Object, e As EventArgs) Handles txtSaleInvoiceDate.TextChanged

    End Sub



    Private Sub txtOrderNo_preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtSaleInvoiceNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            search()
        End If
    End Sub

    Private Sub btnEdit_DoubleClick(sender As Object, e As EventArgs) Handles btnEdit.DoubleClick

    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged

    End Sub

    Private Sub txtDescription_MouseEnter(sender As Object, e As EventArgs) Handles txtDescription.MouseEnter
        Dim list As New List(Of String)
        Dim mySource As New AutoCompleteStringCollection
        Dim item As New Item
        list = item.getItems(txtDescription.Text)
        mySource.AddRange(list.ToArray)
        txtDescription.AutoCompleteCustomSource = mySource
        txtDescription.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtDescription.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub

    Private Sub txtSupplierName_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSearchItem_Click(sender As Object, e As EventArgs) Handles btnSearchItem.Click

        Dim found As Boolean = False
        Dim valid As Boolean = False
        Dim barCode As String = txtBarCode.Text
        Dim itemCode As String = txtItemCodeS.Text
        Dim descr As String = txtDescription.Text

        If barCode <> "" Then
            itemCode = (New Item).getItemCode(barCode, "")
        ElseIf itemCode <> "" Then
            itemCode = itemCode
        ElseIf descr <> "" Then
            itemCode = (New Item).getItemCode("", descr)
        Else
            itemCode = ""
        End If

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `item_code`, `item_long_description`, `pck`,`unit_cost_price`, `retail_price`,`vat`, `margin`, `standard_uom`, `active` FROM `items` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtItemCodeS.Text = reader.GetString("item_code")
                txtDescription.Text = reader.GetString("item_long_description")
                txtPackSize.Text = reader.GetString("pck")
                txtSellingPrice.Text = LCurrency.displayValue(reader.GetString("retail_price"))
                txtCostPrice.Text = LCurrency.displayValue(reader.GetString("unit_cost_price"))
                txtStockSize.Text = (New Inventory).getInventory(reader.GetString("item_code"))
                found = True
                'If isSupply(txtItemCodeS.Text, txtSupplierCode.Text) <> True Then
                'MsgBox("Can not add item to this order. Item not available for this Supplier")
                'clearFields()
                'Else
                valid = True
                lockFields()
                txtQuantity.ReadOnly = False
                'End If
                Exit While
            End While
            conn.Close()
            If found = False Then
                MsgBox("Item not found")
                clearFields()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub clearFields()
        txtBarCode.Text = ""
        txtItemCodeS.Text = ""
        txtDescription.Text = ""
        txtPackSize.Text = ""
        txtQuantity.Text = ""
        txtCostPrice.Text = ""
        txtSellingPrice.Text = ""
        txtStockSize.Text = ""
    End Sub
    Private Sub lockFields()
        txtBarCode.ReadOnly = True
        txtItemCodeS.ReadOnly = True
        txtDescription.ReadOnly = True

        btnAdd.Enabled = True
    End Sub
    Private Sub unLockFields()
        txtBarCode.ReadOnly = False
        txtItemCodeS.ReadOnly = False
        txtDescription.ReadOnly = False

        btnAdd.Enabled = False
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Dim status As String = (New Order).getStatus(txtSaleInvoiceNo.Text)
        ' If status = "APPROVED" Then
        'MsgBox("You can not edit this order. Order already approved.", vbOKOnly + vbExclamation, "Error: Invalid operation")
        'clearFields()
        'Exit Sub
        'End If
        'If status = "PRINTED" Then
        'MsgBox("You can not edit this order. Order already printed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
        'clearFields()
        'Exit Sub
        'End If
        'If status = "REPRINTED" Then
        'MsgBox("You can not edit this order. Order already printed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
        'clearFields()
        'Exit Sub
        '  End If
        ' If status = "COMPLETED" Then
        'MsgBox("You can not edit this order. Order already completed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
        'clearFields()
        'Exit Sub
        'End If
        ' If status = "CANCELED" Then
        'MsgBox("You can not edit this order. Order canceled.", vbOKOnly + vbExclamation, "Error: Invalid operation")
        'clearFields()
        'Exit Sub
        ' End If
        Dim barCode As String = txtBarCode.Text
        Dim itemCode As String = txtItemCodeS.Text
        Dim descr As String = txtDescription.Text
        Dim qty As String = txtQuantity.Text
        Dim sellingPrice As String = txtSellingPrice.Text
        Dim costPrice As String = txtCostPrice.Text
        Dim stockSize As String = txtStockSize.Text
        If itemCode = "" Then
            MsgBox("Invalid entry")
            Exit Sub
        End If
        If Val(qty) <= 0 Then
            MsgBox("Could not add item. Invalid quantity entry. Quantity should not be negative", vbOKOnly + vbCritical, "Error: Invalid entry")
            Exit Sub
        End If
        If Val(qty) Mod 1 <> 0 Then
            MsgBox("Could not add item. Invalid quantity entry. Quantity should be a whole number", vbOKOnly + vbCritical, "Error: Invalid entry")
            Exit Sub
        End If
        Dim invoice As SaleInvoice
        If ORDER_STAT = "NEW" Then
            invoice = New SaleInvoice
            invoice.GL_INVOICE_NO = txtSaleInvoiceNo.Text
            Dim invoiceDate As String = (New Day).getCurrentDay.ToString("yyyy-MM-dd")
            invoice.GL_INVOICE_DATE = invoiceDate


            invoice.GL_STATUS = "PENDING"
            invoice.GL_USER_ID = User.CURRENT_USER_ID
            invoice.GL_NAME = txtName.Text
            invoice.GL_CONTACT = txtContact.Text
            txtSaleInvoiceNo.Text = (New SaleInvoice).generateInvoiceNo()
            If invoice.isInvoiceExist(txtSaleInvoiceNo.Text) = False Then
                If invoice.addNewInvoice() = True Then
                    ORDER_STAT = ""
                End If
            Else
                ORDER_STAT = ""
            End If
        End If
        invoice = New SaleInvoice
        invoice.GL_INVOICE_NO = txtSaleInvoiceNo.Text
        invoice.GL_ITEM_CODE = itemCode
        invoice.GL_QUANTITY = Val(qty)
        invoice.GL_UNIT_COST_PRICE = Val(LCurrency.getValue(costPrice))
        invoice.GL_UNIT_SELLING_PRICE = Val(LCurrency.getValue(sellingPrice))
        invoice.addInvoiceDetails()
        refreshList()

        clearFields()
        unLockFields()
        Exit Sub
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clearFields()
        unLockFields()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub txtOrderStatus_TextChanged(sender As Object, e As EventArgs) Handles txtSaleInvoiceStatus.TextChanged

    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs)
        Dim status As String = (New Order).getStatus(txtSaleInvoiceNo.Text)
        If status = "APPROVED" Then
            MsgBox("You can not approve this order. Order already approved.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "PRINTED" Then
            MsgBox("You can not approve this order. Order already printed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "REPRINTED" Then
            MsgBox("You can not approve this order. Order already printed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("You can not approve this order. Order already completed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("You can not approve this order. Order canceled.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If User.authorize("APPROVE LPO") = True Then
            If txtSaleInvoiceNo.Text = "" Then
                MsgBox("Please select order to approve", vbOKOnly + vbInformation, "")
                Exit Sub
            End If
            Dim res As Integer = MsgBox("Are you sure you want to approve the selected order : " + txtSaleInvoiceNo.Text + " ? Once approved, you will no longer be able to edit the selected order.", vbYesNo + vbQuestion, "Approve order?")
            If res = DialogResult.Yes Then
                'approve order

                If dtgrdItemList.RowCount = 0 Then
                    MsgBox("You can not approve an empty order", vbOKOnly + vbInformation, "")
                    Exit Sub
                End If
                Dim order As Order = New Order
                If order.approveOrder(txtSaleInvoiceNo.Text) = True Then
                    MsgBox("Order Successively approved", vbOKOnly + vbInformation, "")
                Else
                    MsgBox("Could not approve order", vbOKOnly + vbInformation, "")
                End If



            End If

        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub


    Private Sub defineStyles(doc As Document)
        'Get the predefined style Normal.
        Dim style As Style = doc.Styles("Normal")
        'Because all styles are derived from Normal, the next line changes the
        'font of the whole document. Or, more exactly, it changes the font of
        'all styles And paragraphs that do Not redefine the font.
        style.Font.Name = "Verdana"
        'style = doc.Document.Styles(StyleNames.Header)
        style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right)
        style = doc.Styles(StyleNames.Footer)
        style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center)
        'Create a new style called Table based on style Normal
        style = doc.Styles.AddStyle("Table", "Normal")
        style.Font.Name = "Verdana"
        style.Font.Name = "Times New Roman"
        style.Font.Size = 9
        'Create a new style called Reference based on style Normal
        style = doc.Styles.AddStyle("Reference", "Normal")
        style.ParagraphFormat.SpaceBefore = "5mm"
        style.ParagraphFormat.SpaceAfter = "5mm"
        style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right)

    End Sub
    Private Sub createDocument(doc As Document)
        'Each MigraDoc document needs at least one section.
        Dim section As Section = doc.AddSection()
        section.PageSetup.DifferentFirstPageHeaderFooter = True
        Dim paragraph As Paragraph
        doc.FootnoteStartingNumber() = 1
        paragraph = section.Footers.Primary.AddParagraph()
        Dim _datetime As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        paragraph.AddText("Printed :" & _datetime + " By :" & User.CURRENT_ALIAS & " From :" & Company.GL_NAME)
        paragraph.Format.Font.Size = 8
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Color = Colors.GreenYellow
        paragraph = section.Footers.Primary.AddParagraph()
        paragraph.AddPageField()
        paragraph.AddText(" of ")
        paragraph.AddNumPagesField()
        paragraph.Format.Alignment = ParagraphAlignment.Right
        section.Footers.FirstPage = section.Footers.Primary.Clone()
        'Start of header
        Dim logoPath As String = ""
        Dim logoImage As Image = Nothing
        Dim headerTable As Table = section.Headers.FirstPage.AddTable()
        headerTable.Borders.Width = 0.2
        headerTable.Borders.Left.Width = 0.2
        headerTable.Borders.Right.Width = 0.2
        headerTable.Rows.LeftIndent = 0
        Dim headerColumn As Column
        headerColumn = headerTable.AddColumn("2.2cm")
        headerColumn.Format.Alignment = ParagraphAlignment.Left
        headerColumn = headerTable.AddColumn("0.3cm")
        headerColumn.Format.Alignment = ParagraphAlignment.Left
        headerColumn = headerTable.AddColumn("12cm")
        headerColumn.Format.Alignment = ParagraphAlignment.Left
        Dim headerRow As Row
        headerRow = headerTable.AddRow()
        headerRow.Format.Font.Bold = False
        headerRow.HeadingFormat = True
        headerRow.Format.Font.Size = 9
        headerRow.Format.Alignment = ParagraphAlignment.Center
        headerRow.Borders.Color = Colors.White
        Try
            Dim logo As New System.IO.MemoryStream(CType(Company.GL_LOGO, Byte()))
            logoImage = Image.FromStream(logo)
            logoPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "TempDocumentLogo.png"
            If My.Computer.FileSystem.FileExists(logoPath) Then
                My.Computer.FileSystem.DeleteFile(logoPath)
            End If
            logoImage.Save(logoPath)
            If logo.Length > 0 Then
                headerRow.Cells(0).AddImage(logoPath).Width = "2.2cm"
                headerRow.Cells(0).Format.Alignment = ParagraphAlignment.Left
            End If
        Catch ex As Exception
        End Try
        headerRow.Cells(1).AddParagraph("")
        Dim companyName As New Paragraph
        companyName.AddText(Company.GL_NAME + Environment.NewLine)
        companyName.Format.Font.Bold = True
        companyName.Format.Font.Size = 9
        Dim physicalAddress As New Paragraph
        physicalAddress.AddText(Company.GL_PHYSICAL_ADDRESS + Environment.NewLine)
        physicalAddress.Format.Font.Size = 8
        Dim address As New Paragraph
        address.AddText(Company.GL_POST_ADDRESS + Environment.NewLine)
        address.Format.Font.Size = 8
        Dim postCode As New Paragraph
        postCode.AddText(Company.GL_POST_CODE + Environment.NewLine)
        postCode.Format.Font.Size = 8
        Dim telephone As New Paragraph
        telephone.AddText("Tel: " + Company.GL_TELEPHONE + " Mob:" + Company.GL_MOBILE + Environment.NewLine)
        telephone.Format.Font.Size = 7
        Dim email As New Paragraph
        email.AddText("Email: " + Company.GL_EMAIL + Environment.NewLine)
        email.Format.Font.Size = 7
        email.Format.Font.Italic = True
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Sales Invoice", TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9
        paragraph.Format.Font.Color = Colors.Green

        paragraph = section.AddParagraph()

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Invoice No: " + txtSaleInvoiceNo.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Issued to:       " + txtName.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Contacts:        " + txtContact.Text)
        paragraph.Format.Font.Size = 8



        'Add the print date field
        paragraph = section.AddParagraph()
        paragraph.Format.SpaceBefore = "1cm"
        paragraph.Style = "Reference"
        paragraph.AddTab()
        paragraph.AddText("Created: ")
        paragraph.AddDateField("dd.MM.yyyy")

        'Create the item table
        Dim table As Table = section.AddTable()
        table.Style = "Table"
        ' table.Borders.Color = TableBorder
        table.Borders.Width = 0.25
        table.Borders.Left.Width = 0.5
        table.Borders.Right.Width = 0.5
        table.Rows.LeftIndent = 0

        'Before you can add a row, you must define the columns
        Dim column As Column

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Center


        column = table.AddColumn("4cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Font.Size = 7
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.Black
        row.Cells(0).AddParagraph("Code")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Description")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("@Price")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Issued")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Center
        row.Cells(4).AddParagraph("Returned")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Center
        row.Cells(5).AddParagraph("Sold")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Center
        row.Cells(6).AddParagraph("Due")
        row.Cells(6).Format.Alignment = ParagraphAlignment.Center
        row.Cells(7).AddParagraph("Amount")
        row.Cells(7).Format.Alignment = ParagraphAlignment.Center


        table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalAmount As Double = 0
        Dim totalVat As Double = 0
        Dim totalDiscount As Double = 0

        For i As Integer = 0 To dtgrdItemList.RowCount - 1
            Dim code As String = dtgrdItemList.Item(1, i).Value.ToString
            Dim description As String = dtgrdItemList.Item(2, i).Value.ToString
            Dim qty As String = dtgrdItemList.Item(3, i).Value.ToString
            Dim price As String = LCurrency.displayValue(dtgrdItemList.Item(4, i).Value.ToString)
            Dim amount As String = LCurrency.displayValue(dtgrdItemList.Item(5, i).Value.ToString)
            totalAmount = totalAmount + Val(LCurrency.getValue(qty)) * Val(LCurrency.getValue(price))

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Font.Size = 7
            row.Height = "1cm"
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.Black
            row.Cells(0).AddParagraph(code)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(description)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(price)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Right
            row.Cells(3).AddParagraph(qty)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Center
            row.Cells(4).AddParagraph("")
            row.Cells(4).Format.Alignment = ParagraphAlignment.Center
            row.Cells(5).AddParagraph("")
            row.Cells(5).Format.Alignment = ParagraphAlignment.Center
            row.Cells(6).AddParagraph("")
            row.Cells(6).Format.Alignment = ParagraphAlignment.Center
            row.Cells(7).AddParagraph(LCurrency.displayValue(amount))
            row.Cells(7).Format.Alignment = ParagraphAlignment.Right

            table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        Next

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph()
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(4).AddParagraph()
        row.Cells(4).Format.Alignment = ParagraphAlignment.Right
        row.Cells(5).AddParagraph()
        row.Cells(5).Format.Alignment = ParagraphAlignment.Right
        row.Cells(6).AddParagraph()
        row.Cells(6).Format.Alignment = ParagraphAlignment.Right
        row.Cells(7).AddParagraph()
        row.Cells(7).Format.Alignment = ParagraphAlignment.Right


        table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)




        row = table.AddRow()
        row.Format.Font.Bold = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph()
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph()
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(6).AddParagraph("Total")
        row.Cells(6).Format.Alignment = ParagraphAlignment.Left
        row.Cells(7).AddParagraph(LCurrency.displayValue(totalAmount.ToString))
        row.Cells(7).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim invoiceNo As String = txtSaleInvoiceNo.Text
        If invoiceNo = "" Then
            MsgBox("Select sale invoice to print.", vbOKOnly + vbCritical, "Error:No selection")
            Exit Sub
        End If
        If dtgrdItemList.RowCount = 0 Then
            MsgBox("Can not print an empty invoice. Please select the bill to print", vbOKOnly + vbCritical, "Error: No selection")
            Exit Sub
        End If

        Dim document As Document = New Document

        document.Info.Title = "SaleInvoice"
        document.Info.Subject = "SaleInvoice"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Sale Invoice " & invoiceNo & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)
    End Sub
End Class