Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmSalesInvoice
    '   Dim EDIT_MODE As String = ""
    '  Dim ORDER_STAT As String = ""
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
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
        style.Font.Name = "Calibri"
        style.Font.Size = 10
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
        headerRow.Cells(2).Add(companyName)
        headerRow.Cells(2).Add(physicalAddress)
        headerRow.Cells(2).Add(postCode)
        headerRow.Cells(2).Add(address)
        headerRow.Cells(2).Add(telephone)
        headerRow.Cells(2).Add(email)
        headerRow.Cells(2).Format.Alignment = ParagraphAlignment.Left
        headerTable.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        Dim tittleTable As Tables.Table = section.AddTable()
        tittleTable.Borders.Width = 0.25
        tittleTable.Borders.Left.Width = 0.5
        tittleTable.Borders.Right.Width = 0.5
        tittleTable.Rows.LeftIndent = 0
        Dim titleColumn As Tables.Column
        titleColumn = tittleTable.AddColumn("2.5cm")
        titleColumn.Format.Alignment = ParagraphAlignment.Left
        titleColumn = tittleTable.AddColumn("12.0cm")
        titleColumn.Format.Alignment = ParagraphAlignment.Left
        Dim titleRow As Tables.Row
        Dim documentTitle As New Paragraph
        documentTitle.AddText("Goods Return to Vendor")
        documentTitle.Format.Alignment = ParagraphAlignment.Left
        documentTitle.Format.Font.Size = 10
        documentTitle.Format.Font.Color = Colors.Black
        titleRow = tittleTable.AddRow()
        titleRow.Format.Font.Bold = True
        titleRow.HeadingFormat = True
        titleRow.Format.Font.Size = 8
        titleRow.Format.Alignment = ParagraphAlignment.Center
        titleRow.Format.Font.Bold = True
        titleRow.Borders.Color = Colors.White
        titleRow.Cells(0).AddParagraph("")
        titleRow.Cells(0).Format.Alignment = ParagraphAlignment.Left
        titleRow.Cells(1).Add(documentTitle)
        titleRow.Cells(1).Format.Alignment = ParagraphAlignment.Left
        tittleTable.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        'end of header

        Dim customer As New CorporateCustomer
        customer = searchCustomer(txtCustomerNo.Text, cmbCustomerName.Text)
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("To:          " + cmbCustomerName.Text, TextFormat.Bold)
        paragraph.Format.Font.Size = 9
        Supplier.search((New Supplier).getSupplierCode("", cmbCustomerName.Text))
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText(supplier.GL_POST_ADDRESS)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Phone: " + supplier.GL_TELEPHONE)
        paragraph.Format.Font.Size = 8
        If supplier.GL_FAX <> "" Then
            paragraph = section.AddParagraph()
            paragraph.AddFormattedText("Fax: " + supplier.GL_FAX)
            paragraph.Format.Font.Size = 8
        End If
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Email: " + supplier.GL_EMAIL)
        paragraph.Format.Font.Size = 8
        paragraph.Format.Font.Italic = True
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("RTV#:      " + txtCustomerNo.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Issue Date:  " + txt.Text)
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
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("6.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("3.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("3.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.HeadingFormat = True
        row.Format.Font.Size = 8
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        'row.Shading.Color = TableBlue
        row.Cells(0).AddParagraph("Code")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Description")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Qty")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Cost Price")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph("Amount")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph("Pack Size")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(6).AddParagraph("Reason")
        row.Cells(6).Format.Alignment = ParagraphAlignment.Left

        table.SetEdge(0, 0, 7, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalQty As Double = 0
        Dim totalAmount As Double = 0


        For i As Integer = 0 To dtgrdProductList.RowCount - 1
            Dim barcode As String = dtgrdProductList.Item(1, i).Value.ToString
            Dim code As String = dtgrdProductList.Item(2, i).Value.ToString
            Dim description As String = dtgrdProductList.Item(3, i).Value.ToString
            Dim qty As String = dtgrdProductList.Item(4, i).Value.ToString
            Dim costPriceIncl As String = dtgrdProductList.Item(5, i).Value.ToString
            Dim discount As String = dtgrdProductList.Item(9, i).Value.ToString
            Dim amount As String = dtgrdProductList.Item(10, i).Value.ToString

            totalQty = totalQty + Val(qty)
            totalAmount = totalAmount + LCurrency.getValue(amount)

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.Format.Font.Size = 8
            row.HeadingFormat = False
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.White
            row.Cells(0).AddParagraph(code)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(description)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(qty)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(costPriceIncl)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Right
            row.Cells(4).AddParagraph(discount)
            row.Cells(4).Format.Alignment = ParagraphAlignment.Right
            row.Cells(5).AddParagraph(amount)
            row.Cells(5).Format.Alignment = ParagraphAlignment.Left

            table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        Next
        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = False
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
        row.Cells(4).AddParagraph("")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Right
        row.Cells(5).AddParagraph(LCurrency.displayValue(totalAmount.ToString))
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left


        table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
    End Sub

    Private Function lock()
        txtCustomerNo.ReadOnly = True
        cmbCustomerName.Enabled = False
        Return vbNull
    End Function
    Private Function unlock()
        txtCustomerNo.ReadOnly = False
        cmbCustomerName.Enabled = True
        Return vbNull
    End Function
    Private Function clear()
        txtId.Text = ""
        txtInvoiceNo.Text = ""
        txtCustomerNo.Text = ""
        cmbCustomerName.SelectedItem = Nothing
        cmbCustomerName.Text = ""
        txtIssueDate.Text = ""
        txtStatus.Text = ""
        txtTotal.Text = ""
        txtComment.Text = ""
        dtgrdProductList.Rows.Clear()
        Return vbNull
    End Function

    Private Function search(id As String, no As String)
        clear()
        Dim invoice As SalesInvoice = New SalesInvoice

        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            If no <> "" Then
                response = Web.get_("sales_invoice/get_by_no?no=" + no)
            ElseIf id <> "" Then
                response = Web.get_("sales_invoice/get_by_id?id=" + id)
            Else
                MsgBox("Please enter a search key", vbOKOnly + vbExclamation, "Error: No selection")
                Return vbNull
                Exit Function
            End If
            json = JObject.Parse(response)
            invoice = JsonConvert.DeserializeObject(Of SalesInvoice)(json.ToString)
            txtInvoiceNo.ReadOnly = True
            If IsNothing(invoice.corporateCustomer) Then
                txtCustomerNo.Text = ""
                cmbCustomerName.Text = ""
            Else
                txtCustomerNo.Text = invoice.corporateCustomer.no
                cmbCustomerName.Text = invoice.corporateCustomer.name
            End If
            txtId.Text = invoice.id
            txtInvoiceNo.Text = invoice.no
            txtIssueDate.Text = invoice.issueDate

            txtStatus.Text = invoice.status
            txtComment.Text = invoice.comment
            lock()
            If Not IsNothing(invoice.salesInvoiceDetails) Then
                refreshproductList(invoice.salesInvoiceDetails)
            End If
            Dim status As String = invoice.status
            If status = "APPROVED" Or status = "COMPLETED" Or status = "CANCELED" Or status = "ARCHIVED" Then
                btnApprove.Enabled = False
            Else
                btnApprove.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("No matching invoice", vbOKOnly + vbCritical, "Error: Not found")
            Return vbNull
            Exit Function
        End Try
        Return vbNull
    End Function
    Private Function searchCustomer(no As String, name As String) As Boolean
        Dim customer As CorporateCustomer
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            If txtCustomerNo.Text <> "" Then
                response = Web.get_("corporate_customers/get_by_no?no=" + no)
                json = JObject.Parse(response)
                customer = JsonConvert.DeserializeObject(Of CorporateCustomer)(json.ToString)
                cmbCustomerName.Text = customer.name
                Return True
                lock()
            ElseIf cmbCustomerName.Text <> "" Then
                response = Web.get_("corporate_customers/get_by_name?name=" + name)
                json = JObject.Parse(response)
                customer = JsonConvert.DeserializeObject(Of CorporateCustomer)(json.ToString)
                txtCustomerNo.Text = customer.no
                Return True
                lock()
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If txtInvoiceNo.ReadOnly = False Then
            search("", txtInvoiceNo.Text)
            Exit Sub
        End If
        If txtId.Text <> "" Then
            Exit Sub
        End If
        If searchCustomer(txtCustomerNo.Text, cmbCustomerName.Text) = True Then
            btnSave.Enabled = True
        Else
            If txtCustomerNo.Text = "" Then
                MsgBox("Please enter supplier code", vbOKOnly + vbCritical, "Error: Missing information")
            Else
                MsgBox("No matching supplier", vbOKOnly + vbCritical, "Error: Not found")
            End If
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        clear()
        clearFields()
        txtInvoiceNo.ReadOnly = True
        txtCustomerNo.ReadOnly = False
        cmbCustomerName.Enabled = True
        txtStatus.Text = ""
        txtIssueDate.Text = Day.DAY  ' Day.DAY
        unlock()
        btnSave.Enabled = False
        txtInvoiceNo.Text = "NA"
        dtgrdProductList.Rows.Clear()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        'If User.authorize("EDIT LPO") = True Then

        ' Else
        'MsgBox("Action denied for current user.", vbOKOnly + vbExclamation, "Action denied")
        'Exit Sub
        ' End If
        If txtId.Text = "" Then
            clear()
            txtInvoiceNo.ReadOnly = False
            btnSave.Enabled = False
        Else
            lock()
            txtInvoiceNo.ReadOnly = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim invoice As SalesInvoice
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        If txtId.Text = "" Then
            invoice = New SalesInvoice
        Else
            response = Web.get_("sales_invoices/get_by_id?id=" + txtId.Text)
            json = JObject.Parse(response)
            invoice = JsonConvert.DeserializeObject(Of SalesInvoice)(json.ToString)
        End If
        If txtId.Text <> "" Then
            invoice.id = txtId.Text
        Else
            invoice.no = "NA"
            invoice.createdUser.id = User.CURRENT_USER_ID
        End If
        invoice.issueDate = Day.DAY

        invoice.comment = txtComment.Text

        If dtgrdProductList.RowCount = 0 Then
            Dim res As Integer = MsgBox("No items listed. Would you like to save an empty Invoice?", vbYesNo + vbQuestion, "Save empty Invoice?")
            If Not res = DialogResult.Yes Then
                Exit Sub
            End If
        End If
        Try
            If txtId.Text = "" Then
                response = Web.post(invoice, "sales_invoices/new")
                json = JObject.Parse(response)
                txtId.Text = json.SelectToken("id")
                MsgBox("Invoice created successifully", vbOKOnly + vbInformation, "Success: Invoice saved.")
            Else
                response = Web.put(invoice, "sales_invoices/edit_by_id?id=" + txtId.Text)
                If response = True Then
                    MsgBox("Invoice updated successifully", vbOKOnly + vbInformation, "Success: Invoice updated.")
                Else
                    MsgBox("Could not update Invoice", vbOKOnly + vbExclamation, "Error: operation failed")
                End If
            End If
            refreshInvoiceList()
        Catch ex As Exception
            MsgBox("Operation failed")
            Exit Sub
        End Try
    End Sub

    Private Function refreshproductList(details As List(Of SalesInvoiceDetail))
        dtgrdProductList.Rows.Clear()
        Dim total As Double = 0
        For Each detail In details
            total = total + detail.qty * detail.costPriceVatIncl

            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.id
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.barcode
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.code
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.description
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.qty
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(detail.costPriceVatIncl)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(detail.costPriceVatExcl)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(detail.sellingPriceVatIncl)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(detail.sellingPriceVatExcl)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.discount
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue((detail.qty * (100 * detail.sellingPriceVatIncl - detail.discount)) / 100)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdProductList.Rows.Add(dtgrdRow)
        Next
        dtgrdProductList.ClearSelection()
        txtTotal.Text = LCurrency.displayValue(total)
        Return vbNull
    End Function

    Private Sub dtgrdItemList_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdProductList.RowHeaderMouseDoubleClick
        Dim status As String
        Try
            status = Web.get_("sales_invoices/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If status = "APPROVED" Then
            MsgBox("You can not edit this Invoice. Invoice already approved.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("You can not edit this Invoice. Invoice already completed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("You can not edit this Invoice. Invoice canceled.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "" Then
            MsgBox("You can not edit this Invoice. Invoice status unknown.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If

        Dim rtv As Rtv
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        response = Web.get_("sales_invoices/get_by_id?id=" + txtId.Text)
        json = JObject.Parse(response)
        rtv = JsonConvert.DeserializeObject(Of Rtv)(json.ToString)

        Dim row As Integer = -1
        row = dtgrdProductList.CurrentRow.Index

        Dim sn As String = dtgrdProductList.Item(0, row).Value.ToString
        Dim barcode As String = dtgrdProductList.Item(1, row).Value.ToString
        Dim code As String = dtgrdProductList.Item(2, row).Value.ToString
        Dim description As String = dtgrdProductList.Item(3, row).Value.ToString
        Dim qty As String = dtgrdProductList.Item(4, row).Value.ToString
        Dim costPriceIncl As String = dtgrdProductList.Item(5, row).Value.ToString
        Dim costPriceExcl As String = dtgrdProductList.Item(6, row).Value.ToString
        Dim sellingPriceIncl As String = dtgrdProductList.Item(7, row).Value.ToString
        Dim sellingPriceExcl As String = dtgrdProductList.Item(8, row).Value.ToString
        Dim discount As String = dtgrdProductList.Item(9, row).Value.ToString
        Dim amount As String = dtgrdProductList.Item(10, row).Value.ToString

        txtDetailId.Text = sn
        txtBarCode.Text = barcode
        txtCode.Text = code
        cmbDescription.Text = description
        txtQty.Text = qty
        txtCostPriceVatIncl.Text = LCurrency.displayValue(costPriceIncl)
        txtCostPriceVatExcl.Text = LCurrency.displayValue(costPriceExcl)
        txtSellingPriceVatIncl.Text = LCurrency.displayValue(sellingPriceIncl)
        txtSellingPriceVatExcl.Text = LCurrency.displayValue(sellingPriceExcl)
        txtAmount.Text = LCurrency.displayValue(qty * (100 * sellingPriceIncl - discount) / 100)
        If txtDetailId.Text <> "" Then
            btnAdd.Enabled = True
        Else
            btnAdd.Enabled = False
        End If

        Try
            response = Web.delete("sales_incoice_details/delete_by_id?id=" + sn)
            '    lockFields()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '    lockFields()
        '    search(txtId.Text, "")
    End Sub

    Private Sub dtgrdItemList_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdProductList.RowHeaderMouseClick
        Dim status As String
        Try
            status = Web.get_("rtvs/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If status = "APPROVED" Then
            MsgBox("You can not edit this RTV. RTV already approved.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("You can not edit this RTV. RTV already completed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("You can not edit this RTV. RTV canceled.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "" Then
            MsgBox("You can not edit this RTV. RTV status unknown.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If

        Dim invoice As SalesInvoice
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        response = Web.get_("sales_invoices/get_by_id?id=" + txtId.Text)
        json = JObject.Parse(response)
        invoice = JsonConvert.DeserializeObject(Of SalesInvoice)(json.ToString)

        Dim row As Integer = -1
        row = dtgrdProductList.CurrentRow.Index

        Dim sn As String = dtgrdProductList.Item(0, row).Value.ToString
        Dim barcode As String = dtgrdProductList.Item(1, row).Value.ToString
        Dim code As String = dtgrdProductList.Item(2, row).Value.ToString
        Dim description As String = dtgrdProductList.Item(3, row).Value.ToString
        Dim qty As String = dtgrdProductList.Item(4, row).Value.ToString
        Dim costPriceIncl As String = dtgrdProductList.Item(5, row).Value.ToString
        Dim costPriceExcl As String = dtgrdProductList.Item(6, row).Value.ToString
        Dim sellingPriceIncl As String = dtgrdProductList.Item(7, row).Value.ToString
        Dim sellingPriceExcl As String = dtgrdProductList.Item(8, row).Value.ToString
        Dim discount As String = dtgrdProductList.Item(9, row).Value.ToString
        Dim amount As String = dtgrdProductList.Item(10, row).Value.ToString

        txtDetailId.Text = sn
        txtBarCode.Text = barcode
        txtCode.Text = code
        cmbDescription.Text = description
        txtQty.Text = qty
        txtCostPriceVatIncl.Text = LCurrency.displayValue(costPriceIncl)
        txtCostPriceVatExcl.Text = LCurrency.displayValue(costPriceExcl)
        txtSellingPriceVatIncl.Text = LCurrency.displayValue(sellingPriceIncl)
        txtSellingPriceVatExcl.Text = LCurrency.displayValue(sellingPriceExcl)
        txtAmount.Text = LCurrency.displayValue(qty * (100 * sellingPriceIncl - discount) / 100)

        If txtDetailId.Text <> "" Then
            btnAdd.Enabled = True
        Else
            btnAdd.Enabled = False
        End If

        Try
            '     response = Web.delete("rtv_details/delete_by_id?id=" + sn)
            '     lockFields()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '    lockFields()
        '    search(txtId.Text, "")
    End Sub

    Dim longCustomer As New List(Of String)
    Dim shortCustomer As New List(Of String)
    Private Sub frmReturnToVendor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        clearFields()

        txtInvoiceNo.Text = ""
        txtCustomerNo.Text = ""
        cmbCustomerName.SelectedItem = Nothing
        cmbCustomerName.Text = ""
        '    dateIssueDate.Value = Nothing
        txtStatus.Text = ""
        '      dateValidUntil.Value = Nothing
        txtCustomerNo.ReadOnly = True
        cmbCustomerName.Enabled = False

        Dim customer As New CorporateCustomer
        longCustomer = customer.getNames()
        refreshInvoiceList()
    End Sub
    Private Sub refreshInvoiceList()
        dtgrdInvoiceLists.Rows.Clear()
        Try
            Dim response As Object = New Object
            Dim json As JObject = New JObject
            Dim invoices As List(Of SalesInvoice)
            response = Web.get_("sales_invoices/visible")
            invoices = JsonConvert.DeserializeObject(Of List(Of SalesInvoice))(response)

            For Each invoice In invoices
                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = invoice.id
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = invoice.no
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = invoice.issueDate.ToString("yyyy-MM-dd")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                If Not IsNothing(invoice.corporateCustomer) Then
                    dtgrdCell.Value = invoice.corporateCustomer.name
                Else
                    dtgrdCell.Value = ""
                End If
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = invoice.status
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdInvoiceLists.Rows.Add(dtgrdRow)
            Next
            dtgrdInvoiceLists.ClearSelection()
        Catch ex As Exception

        End Try
        dtgrdInvoiceLists.ClearSelection()
    End Sub

    Private Sub frmSalesInvoice_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtInvoiceNo.Text = ""
        dtgrdProductList.Rows.Clear()
        Dim product As New Product
        longList = product.getDescriptions
    End Sub

    Private Sub txtCustomerCode_preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtCustomerNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            If txtId.Text <> "" Then
                Exit Sub
            End If
            If searchCustomer(txtCustomerNo.Text, cmbCustomerName.Text) = True Then
                If txtId.Text = "" Then
                    txtCustomerNo.Text = "NA"
                End If
                btnSave.Enabled = True
            Else
                If txtCustomerNo.Text = "" Then
                    MsgBox("Please enter customer no", vbOKOnly + vbCritical, "Error: Missing information")
                Else
                    MsgBox("No matching customer", vbOKOnly + vbCritical, "Error: Not found")
                End If
            End If
        End If
    End Sub

    Private Sub txtInvoiceNo_preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtInvoiceNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            search("", txtInvoiceNo.Text)
        End If
    End Sub

    Private Sub btnSearchItem_Click(sender As Object, e As EventArgs) Handles btnSearchItem.Click
        If txtCustomerNo.Text = "" Then
            MsgBox("Please select Customer", vbOKOnly + vbCritical, "Error: No customer selected")
            Exit Sub
        End If
        Dim found As Boolean = False
        Dim valid As Boolean = False
        Dim barcode As String = txtBarCode.Text
        Dim code As String = txtCode.Text
        Dim description As String = cmbDescription.Text
        Try
            Dim product As Product
            Dim response As Object = New Object
            Dim json As JObject = New JObject

            If barcode <> "" Then
                response = Web.get_("products/get_by_barcode?barcode=" + barcode)
                json = JObject.Parse(response)
                product = JsonConvert.DeserializeObject(Of Product)(json.ToString)
            ElseIf code <> "" Then
                response = Web.get_("products/get_by_code?code=" + code)
                json = JObject.Parse(response)
                product = JsonConvert.DeserializeObject(Of Product)(json.ToString)
            ElseIf description <> "" Then
                response = Web.get_("products/get_by_description?description=" + description)
                json = JObject.Parse(response)
                product = JsonConvert.DeserializeObject(Of Product)(json.ToString)
            Else
                MsgBox("Please enter a search key", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            txtCode.Text = product.code
            cmbDescription.Text = product.description
            txtPackSize.Text = product.packSize
            txtCostPriceVatIncl.Text = LCurrency.displayValue(product.costPriceVatIncl)
            txtCostPriceVatExcl.Text = LCurrency.displayValue(product.costPriceVatExcl)
            txtSellingPriceVatIncl.Text = LCurrency.displayValue(product.sellingPriceVatIncl)
            txtSellingPriceVatExcl.Text = LCurrency.displayValue(product.sellingPriceVatExcl)
            txtStockSize.Text = product.stock
            txtPackSize.Text = product.packSize
            found = True
            If found = False Then
                MsgBox("Product not found", vbOKOnly + vbCritical, "Item not found")
                clearFields()
            End If
            Exit Sub
            valid = True
            lockFields()
            txtQty.ReadOnly = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub clearFields()
        txtDetailId.Text = ""
        txtBarCode.Text = ""
        txtCode.Text = ""
        cmbDescription.SelectedItem = Nothing
        cmbDescription.Text = ""
        txtPackSize.Text = ""
        txtQty.Text = ""
        txtCostPriceVatIncl.Text = ""
        txtCostPriceVatExcl.Text = ""
        txtSellingPriceVatIncl.Text = ""
        txtSellingPriceVatExcl.Text = ""
        txtStockSize.Text = ""
    End Sub
    Private Sub lockFields()
        txtBarCode.ReadOnly = True
        txtCode.ReadOnly = True
        cmbDescription.Enabled = False
        btnAdd.Enabled = True
    End Sub
    Private Sub unLockFields()
        txtBarCode.ReadOnly = False
        txtCode.ReadOnly = False
        cmbDescription.Enabled = True
        btnAdd.Enabled = False
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim status As String
        Try
            status = Web.get_("sales_invoices/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If status = "APPROVED" Then
            MsgBox("You can not edit this Invoice. Invoice already approved.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("You can not edit this Invoice. Invoice already completed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("You can not edit this Invoice. Invoice canceled.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "" Then
            MsgBox("You can not edit this Invoice. Invoice status unknown.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        Dim barCode As String = txtBarCode.Text
        Dim code As String = txtCode.Text
        Dim description As String = cmbDescription.Text
        Dim qty As String = txtQty.Text
        Dim costPriceVatInvl As String = LCurrency.getValue(txtCostPriceVatIncl.Text)
        Dim costPriceVatExcl As String = LCurrency.getValue(txtCostPriceVatExcl.Text)
        Dim sellingPriceVatIncl As String = LCurrency.getValue(txtSellingPriceVatIncl.Text)
        Dim sellingPriceVatExcl As String = LCurrency.getValue(txtSellingPriceVatExcl.Text)
        Dim packSize As String = txtPackSize.Text
        If code = "" Then
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
        Try

            Dim response As Object = New Object
            Dim invoice As SalesInvoice
            Dim json As JObject = New JObject
            If txtId.Text = "" Then

                invoice = New SalesInvoice
                invoice.no = "NA"
                invoice.createdUser.id = User.CURRENT_USER_ID
                invoice.corporateCustomer.no = txtCustomerNo.Text
                invoice.corporateCustomer.name = cmbCustomerName.Text
                invoice.issueDate = Day.DAY
                invoice.comment = txtComment.Text
                response = Web.post(invoice, "sales_invoices/new")
                json = JObject.Parse(response)
                invoice = JsonConvert.DeserializeObject(Of SalesInvoice)(json.ToString)
                txtId.Text = invoice.id
                txtInvoiceNo.Text = invoice.no
            End If



            '   txtVaildUntil.Text = ((New Day).getCurrentDay.AddDays(validityPeriod)).ToString("yyyy-MM-dd")  sample code

            Dim detail As SalesInvoiceDetail = New SalesInvoiceDetail
            detail.id = txtDetailId.Text
            detail.salesInvoice.id = txtId.Text
            detail.barcode = barCode
            detail.code = code
            detail.description = description
            detail.qty = qty
            detail.costPriceVatIncl = LCurrency.getValue(txtCostPriceVatIncl.Text)
            detail.costPriceVatExcl = LCurrency.getValue(txtCostpriceVatExcl.Text)
            detail.sellingPriceVatIncl = LCurrency.getValue(txtSellingPriceVatIncl.Text)
            detail.sellingPriceVatExcl = LCurrency.getValue(txtSellingPriceVatExcl.Text)
            If txtDetailId.Text = "" Then
                response = Web.post(detail, "sales_invoice_details/new")
            Else
                response = Web.put(detail, "sales_invoice_details/edit_by_id?id=" + txtDetailId.Text)
            End If
            If dtgrdProductList.RowCount < 1 Then
                refreshInvoiceList()
            End If
            search(txtId.Text, "")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        clearFields()
        unLockFields()
        Exit Sub
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        clearFields()
        unLockFields()
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim status As String
        Try
            status = Web.get_("sales_invoices/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If status = "APPROVED" Then
            MsgBox("You can not approve this Invoice. Invoice already approved.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("You can not approve this Invoice. Invoice already completed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("You can not approve this Invoice. Invoice canceled.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "" Then
            MsgBox("You can not approve this Invoice. Invoice status unknown.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        '    If User.authorize("APPROVE LPO") = True Then
        If txtInvoiceNo.Text = "" Then
            MsgBox("Please select an Invoice to approve", vbOKOnly + vbInformation, "")
            Exit Sub
        End If
        Dim res As Integer = MsgBox("Are you sure you want to approve Invoice : " + txtInvoiceNo.Text + " ? Once approved, the Invoice can not be edited", vbYesNo + vbQuestion, "Approve Invoice?")
        If res = DialogResult.Yes Then
            'approve order

            If dtgrdProductList.RowCount = 0 Then
                MsgBox("You can not approve an empty Invoice", vbOKOnly + vbInformation, "")
                Exit Sub
            End If

            Dim approved As Boolean = False
            Try
                approved = Web.put(vbNull, "sales_invoices/approve_by_id?id=" + txtId.Text)
            Catch ex As Exception
                approved = False
            End Try
            If approved = True Then
                MsgBox("Invoice Successively approved", vbOKOnly + vbInformation, "")
            Else
                MsgBox("Operation failed")
            End If
            search(txtId.Text, "")
            refreshInvoiceList()
        End If
        '   Else
        '   MsgBox("Access denied!", vbOKOnly + vbExclamation)
        '   End If
    End Sub

    Private Sub txtInvoiceNo_TextChanged(sender As Object, e As EventArgs) Handles txtInvoiceNo.TextChanged
        If txtInvoiceNo.Text = "" Then
            btnApprove.Enabled = False
        Else
            btnApprove.Enabled = True
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

    Private Sub cmbCustomer_KeyUp(sender As Object, e As EventArgs) Handles cmbCustomerName.KeyUp
        Dim currentText As String = cmbCustomerName.Text
        shortCustomer.Clear()
        cmbCustomerName.Items.Clear()
        cmbCustomerName.Items.Add(currentText)
        cmbCustomerName.DroppedDown = True
        For Each text As String In longCustomer
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbCustomerName.Text.ToUpper()) Then
                shortCustomer.Add(text)
            End If
        Next
        cmbCustomerName.Items.AddRange(shortCustomer.ToArray())
        cmbCustomerName.SelectionStart = cmbCustomerName.Text.Length
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub dtgrdInvoiceList_CellContentClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdInvoiceLists.RowHeaderMouseClick
        Dim r As Integer = dtgrdInvoiceLists.CurrentRow.Index
        Dim rtvId As String = dtgrdInvoiceLists.Item(0, r).Value.ToString
        Dim rtvNo As String = dtgrdInvoiceLists.Item(1, r).Value.ToString
        txtId.Text = rtvId
        txtInvoiceNo.Text = rtvNo
        search(rtvId, "")
    End Sub

    Private Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click
        Dim status As String
        Try
            status = Web.get_("sales_invoices/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If Not status = "COMPLETED" Then
            MsgBox("Only completed Invoice can be archived", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        '     If User.authorize("APPROVE LPO") = True Then
        If txtInvoiceNo.Text = "" Then
            MsgBox("Please select Invoice to archive", vbOKOnly + vbInformation, "")
            Exit Sub
        End If

        Dim archived As Boolean = False
        Try
            archived = Web.put(vbNull, "sales_invoices/archive_by_id?id=" + txtId.Text)
        Catch ex As Exception
            archived = False
        End Try
        If archived = True Then
            MsgBox("Invoice Successively archived", vbOKOnly + vbInformation, "")
        Else
            MsgBox("Poeration failed")
        End If
        search(txtId.Text, "")
        refreshInvoiceList()


        '   Else
        'MsgBox("Access denied!", vbOKOnly + vbExclamation)
        ' End If
    End Sub

    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim status As String
        Try
            status = Web.get_("sales_invoices/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If Not (status = "PENDING" Or status = "APPROVED") Then
            MsgBox("Only a pending or approved invoice can be canceled", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        '     If User.authorize("APPROVE LPO") = True Then
        If txtInvoiceNo.Text = "" Then
            MsgBox("Please select an invoice to cancel", vbOKOnly + vbExclamation, "")
            Exit Sub
        End If

        'approve order
        Dim res As Integer = MsgBox("Are you sure you want to cancel the Invoice : " + txtInvoiceNo.Text + " ? After canceling, the Invoice will be rendered invalid", vbYesNo + vbQuestion, "Cancel Invoice?")
        Try
            status = Web.get_("sales_invoices/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If res = DialogResult.Yes And (status = "PENDING" Or status = "APPROVED") Then
            Dim canceled As Boolean = False
            Try
                canceled = Web.put(vbNull, "sales_invoices/cancel_by_id?id=" + txtId.Text)
            Catch ex As Exception
                canceled = False
            End Try
            If canceled = True Then
                MsgBox("Invoice Successively canceled", vbOKOnly + vbInformation, "")
            Else
                MsgBox("Operation failed")
            End If
            search(txtId.Text, "")
            refreshInvoiceList()
        End If

        '   Else
        'MsgBox("Access denied!", vbOKOnly + vbExclamation)
        ' End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If txtInvoiceNo.Text = "" Then
            MsgBox("Select an RTV to print.", vbOKOnly + vbCritical, "Error:No selection")
            Exit Sub
        End If
        Dim status As String
        Try
            status = Web.get_("sales_invoices/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If Not (status = "COMPLETED") Then
            MsgBox("Could not print Invoice. Only completed can be printed", vbOKOnly + vbExclamation, "Invalid operation")
            ' Exit Sub
        End If

        search(txtId.Text, "")
        refreshInvoiceList()

        Dim document As Document = New Document
        document.Info.Title = "Sales Invoice"
        document.Info.Subject = "Sales Invoice"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\" & txtInvoiceNo.Text & ".pdf"

        myRenderer.PdfDocument.Save(filename)
        Process.Start(filename)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
        clearFields()
    End Sub

    Private Sub txtDetailId_TextChanged(sender As Object, e As EventArgs) Handles txtDetailId.TextChanged
        If txtDetailId.Text = "" Then
            btnSearchItem.Enabled = True
            txtBarCode.ReadOnly = False
            txtCode.ReadOnly = False
            cmbDescription.Enabled = True
        Else
            btnSearchItem.Enabled = False
            txtBarCode.ReadOnly = True
            txtCode.ReadOnly = True
            cmbDescription.Enabled = False
        End If
    End Sub
End Class