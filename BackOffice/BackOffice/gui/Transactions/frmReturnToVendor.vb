Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Public Class frmReturnToVendor
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


        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("To:          " + cmbSupplierName.Text, TextFormat.Bold)
        paragraph.Format.Font.Size = 9
        Dim supplier As New Supplier
        supplier.search((New Supplier).getSupplierCode("", cmbSupplierName.Text))
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
        paragraph.AddFormattedText("RTV#:      " + txtRtvNo.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Issue Date:  " + txtIssueDate.Text)
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

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("3.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("3.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        'row.Shading.Color = TableBlue
        row.Cells(0).AddParagraph("Barcode")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Code")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Description")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Qty")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph("Cost Price")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph("Amount")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(6).AddParagraph("Pack Size")
        row.Cells(6).Format.Alignment = ParagraphAlignment.Left
        row.Cells(7).AddParagraph("Reason")
        row.Cells(7).Format.Alignment = ParagraphAlignment.Left

        table.SetEdge(0, 0, 8, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalQty As Double = 0

        For i As Integer = 0 To dtgrdProductList.RowCount - 1
            Dim barcode As String = dtgrdProductList.Item(1, i).Value.ToString
            Dim code As String = dtgrdProductList.Item(2, i).Value.ToString
            Dim description As String = dtgrdProductList.Item(3, i).Value.ToString
            Dim qty As String = dtgrdProductList.Item(4, i).Value.ToString
            Dim costPriceIncl As String = dtgrdProductList.Item(5, i).Value.ToString
            Dim amount As String = dtgrdProductList.Item(9, i).Value.ToString
            Dim packSize As String = dtgrdProductList.Item(10, i).Value.ToString
            Dim reason As String = dtgrdProductList.Item(11, i).Value.ToString

            totalQty = totalQty + Val(qty)
            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.White
            row.Cells(0).AddParagraph(barcode)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(code)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(description)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(qty)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Left
            row.Cells(4).AddParagraph(costPriceIncl)
            row.Cells(4).Format.Alignment = ParagraphAlignment.Right
            row.Cells(5).AddParagraph(amount)
            row.Cells(5).Format.Alignment = ParagraphAlignment.Right
            row.Cells(6).AddParagraph(reason)
            row.Cells(6).Format.Alignment = ParagraphAlignment.Left
            row.Cells(7).AddParagraph(reason)
            row.Cells(7).Format.Alignment = ParagraphAlignment.Left


            table.SetEdge(0, 0, 8, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
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
        row.Cells(2).AddParagraph("Total Qty")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph(totalQty.ToString)
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left

        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
    End Sub

    Private Function lock()
        txtSupplierCode.ReadOnly = True
        cmbSupplierName.Enabled = False
        Return vbNull
    End Function
    Private Function unlock()
        txtSupplierCode.ReadOnly = False
        cmbSupplierName.Enabled = True
        Return vbNull
    End Function
    Private Function clear()
        txtId.Text = ""
        txtRtvNo.Text = ""
        txtSupplierCode.Text = ""
        cmbSupplierName.SelectedItem = Nothing
        cmbSupplierName.Text = ""
        txtIssueDate.Text = ""
        txtStatus.Text = ""

        txtTotal.Text = ""
        txtComments.Text = ""
        dtgrdProductList.Rows.Clear()
        Return vbNull
    End Function
    Private Function isSupply(code As String, supplierCode As String) As Boolean
        Dim supply As Boolean = False
        Dim product As New Product
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            Return Web.get_("products/is_supplied/product_code=" + code + "&supplier_code=" + supplierCode)
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function searchSupplier(code As String, name As String) As Boolean
        Dim supplier_ As Supplier
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            If txtSupplierCode.Text <> "" Then
                response = Web.get_("suppliers/code=" + code)
                json = JObject.Parse(response)
                supplier_ = JsonConvert.DeserializeObject(Of Supplier)(json.ToString)
                cmbSupplierName.Text = supplier_.name
                Return True
                lock()
            ElseIf cmbSupplierName.Text <> "" Then
                response = Web.get_("suppliers/name=" + name)
                json = JObject.Parse(response)
                supplier_ = JsonConvert.DeserializeObject(Of Supplier)(json.ToString)
                txtSupplierCode.Text = supplier_.code
                Return True
                lock()
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Private Function search(id As String, no As String)
        Dim rtv As Rtv = New Rtv

        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            If no <> "" Then
                response = Web.get_("rtvs/get_by_no?no=" + no)
            ElseIf id <> "" Then
                response = Web.get_("rtvs/get_by_id?id=" + id)
            Else
                MsgBox("Please enter a search key", vbOKOnly + vbExclamation, "Error: No selection")
                Return vbNull
                Exit Function
            End If
            json = JObject.Parse(response)
            rtv = JsonConvert.DeserializeObject(Of Rtv)(json.ToString)
            txtRtvNo.ReadOnly = True
            If IsNothing(rtv.) Then
                txtSupplierCode.Text = ""
                cmbSupplierName.Text = ""
            Else
                txtSupplierCode.Text = lpo_.supplier.code
                cmbSupplierName.Text = lpo_.supplier.name
            End If
            txtId.Text = lpo_.id
            txtIssueDate.Text = lpo_.issueDate

            txtStatus.Text = lpo_.status
            txtComments.Text = lpo_.comment
            lock()
            If Not IsNothing(lpo_.lpoDetails) Then
                refreshList(lpo_.lpoDetails)
            End If
            Dim status As String = lpo_.status
            If status = "APPROVED" Or status = "PRINTED" Or status = "REPRINTED" Or status = "COMPLETED" Or status = "CANCELED" Then
                btnApprove.Enabled = False
            Else
                btnApprove.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("No matching order", vbOKOnly + vbCritical, "Error: Not found")
            Return vbNull
            Exit Function
        End Try
        Return vbNull
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If txtOrderNo.ReadOnly = False Then
            search("", txtOrderNo.Text)
            Exit Sub
        End If
        If txtId.Text <> "" Then
            Exit Sub
        End If
        If searchSupplier(txtSupplierCode.Text, cmbSupplierName.Text) = True Then
            btnSave.Enabled = True
        Else
            If txtSupplierCode.Text = "" Then
                MsgBox("Please enter supplier code", vbOKOnly + vbCritical, "Error: Missing information")
            Else
                MsgBox("No matching supplier", vbOKOnly + vbCritical, "Error: Not found")
            End If
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        clear()
        clearFields()
        cmbValidityPeriod.Text = "30"
        dateValidUntil.Value = ((New Day).getCurrentDay.AddDays(Val(cmbValidityPeriod.Text)))
        txtOrderNo.ReadOnly = True
        txtSupplierCode.ReadOnly = False
        cmbSupplierName.Enabled = True
        txtOrderStatus.Text = ""
        dateIssueDate.Value = Date.Now() ' Day.DAY
        unlock()
        btnSave.Enabled = False
        txtOrderNo.Text = "NA"
        dtgrdItemList.Rows.Clear()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If User.authorize("EDIT LPO") = True Then

        Else
            MsgBox("Action denied for current user.", vbOKOnly + vbExclamation, "Action denied")
            Exit Sub
        End If
        If txtId.Text = "" Then
            clear()
            txtOrderNo.ReadOnly = False
            btnSave.Enabled = False
        Else
            lock()
            txtOrderNo.ReadOnly = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim lpo_ As Lpo
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        If txtId.Text = "" Then
            lpo_ = New Lpo
        Else
            response = Web.get_("lpos/id=" + txtId.Text)
            json = JObject.Parse(response)
            lpo_ = JsonConvert.DeserializeObject(Of Lpo)(json.ToString)
        End If
        If txtId.Text <> "" Then
            lpo_.id = txtId.Text
        Else
            lpo_.no = "NA"
            lpo_.createdUser.id = User.CURRENT_USER_ID
        End If
        lpo_.issueDate = dateIssueDate.Value.ToString("yyyy-MM-dd")
        lpo_.validityDays = cmbValidityPeriod.Text
        lpo_.validUntil = dateValidUntil.Value.ToString("yyyy-MM-dd")
        lpo_.comment = txtComment.Text

        If dtgrdItemList.RowCount = 0 Then
            Dim res As Integer = MsgBox("No items listed. Would you like to save an empty LPO?", vbYesNo + vbQuestion, "Save empty LPO?")
            If Not res = DialogResult.Yes Then
                Exit Sub
            End If
        End If
        Try
            If txtId.Text = "" Then
                response = Web.post(lpo_, "lpos/new")
                json = JObject.Parse(response)
                txtId.Text = json.SelectToken("id")
                MsgBox("LPO created successifully", vbOKOnly + vbInformation, "Success: LPO saved.")
            Else
                response = Web.put(lpo_, "lpos/edit/id=" + txtId.Text)
                If response = True Then
                    MsgBox("LPO updated successifully", vbOKOnly + vbInformation, "Success: LPO updated.")
                Else
                    MsgBox("Could not update LPO", vbOKOnly + vbExclamation, "Error: operation failed")
                End If
            End If
            refreshLPOList()
        Catch ex As Exception
            MsgBox("Operation failed")
            Exit Sub
        End Try
    End Sub

    Private Function refreshList(lpoDetails As List(Of LpoDetail))
        dtgrdItemList.Rows.Clear()
        Dim total As Double = 0
        For Each detail In lpoDetails
            total = total + detail.qty * detail.costPrice

            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

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
            dtgrdCell.Value = detail.packSize
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.qty
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(detail.costPrice)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(detail.qty * detail.costPrice)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.packSize
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.id
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdItemList.Rows.Add(dtgrdRow)
        Next
        txtTotal.Text = LCurrency.displayValue(total)
        Return vbNull
    End Function

    Private Sub dtgrdItemList_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdItemList.RowHeaderMouseDoubleClick
        Dim status As String
        Try
            status = Web.get_("lpos/id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If status = "APPROVED" Then
            MsgBox("You can not edit this LPO. LPO already approved.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "PRINTED" Then
            MsgBox("You can not edit this LPO. LPO already printed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "REPRINTED" Then
            MsgBox("You can not edit this LPO. LPO already printed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("You can not edit this LPO. LPO already completed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("You can not edit this LPO. LPO canceled.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "" Then
            MsgBox("You can not edit this LPO. LPO status unknown.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If

        Dim lpo_ As Lpo
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        response = Web.get_("lpos/id=" + txtId.Text)
        json = JObject.Parse(response)
        lpo_ = JsonConvert.DeserializeObject(Of Lpo)(json.ToString)

        Dim row As Integer = -1
        row = dtgrdItemList.CurrentRow.Index
        Dim barCode As String = dtgrdItemList.Item(0, row).Value
        Dim itemCode As String = dtgrdItemList.Item(1, row).Value
        Dim description As String = dtgrdItemList.Item(2, row).Value
        Dim packSize As String = dtgrdItemList.Item(3, row).Value
        Dim quantity As String = dtgrdItemList.Item(4, row).Value
        Dim costPrice As String = dtgrdItemList.Item(5, row).Value
        Dim totalCost As String = dtgrdItemList.Item(6, row).Value
        Dim sn As String = dtgrdItemList.Item(8, row).Value

        txtItemCodeS.Text = itemCode
        cmbDescription.Text = description
        txtQuantity.Text = quantity
        txtPackSize.Text = packSize
        txtCostPrice.Text = costPrice
        txtPackSize.Text = packSize

        Try
            response = Web.delete("lpo_details/delete/id=" + sn)
            lockFields()
        Catch ex As Exception

        End Try
        lockFields()
        Try
            Dim lpoDetails As List(Of LpoDetail)
            response = Web.get_("lpo_details/lpo_id=" + txtId.Text)
            lpoDetails = JsonConvert.DeserializeObject(Of List(Of LpoDetail))(response)
            refreshList(lpoDetails)
        Catch ex As Exception

        End Try
    End Sub

    Dim longSupplier As New List(Of String)
    Dim shortSupplier As New List(Of String)
    Private Sub frmPurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        clearFields()

        txtOrderNo.Text = ""
        txtSupplierCode.Text = ""
        cmbSupplierName.SelectedItem = Nothing
        cmbSupplierName.Text = ""
        '    dateIssueDate.Value = Nothing
        cmbValidityPeriod.Text = ""
        txtOrderStatus.Text = ""
        '      dateValidUntil.Value = Nothing
        txtSupplierCode.ReadOnly = True
        cmbSupplierName.Enabled = False

        Dim supplier As New Supplier
        longSupplier = supplier.getNames()
        refreshLPOList()
    End Sub
    Private Sub refreshLPOList()
        dtgrdLPOList.Rows.Clear()
        Try
            Dim response As Object = New Object
            Dim json As JObject = New JObject
            Dim lpos As List(Of Lpo)
            response = Web.get_("lpos/visible")
            lpos = JsonConvert.DeserializeObject(Of List(Of Lpo))(response)

            For Each lpo In lpos
                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = lpo.id
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = lpo.no
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = lpo.issueDate.ToString("yyyy-MM-dd")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = lpo.status
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdLPOList.Rows.Add(dtgrdRow)
            Next
        Catch ex As Exception

        End Try
        dtgrdLPOList.ClearSelection()
    End Sub

    Private Sub frmPurchaseOrder_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtOrderNo.Text = ""
        dtgrdItemList.Rows.Clear()
        Dim product As New Product
        longList = product.getDescriptions
    End Sub

    Private Sub cmbValidityPeriod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbValidityPeriod.SelectedIndexChanged
        If txtId.Text = "" Then
            Exit Sub
        End If
        Dim validityPeriod As Integer = Val(cmbValidityPeriod.Text)
        If validityPeriod > 0 And validityPeriod <= 60 Then
            dateValidUntil.Value = ((New Day).getCurrentDay.AddDays(validityPeriod))
        Else
            dateValidUntil.Value = Nothing
        End If
    End Sub

    Private Sub txtSupplierCode_preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtSupplierCode.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            If txtId.Text <> "" Then
                Exit Sub
            End If
            If searchSupplier(txtSupplierCode.Text, cmbSupplierName.Text) = True Then
                If txtId.Text = "" Then
                    txtOrderStatus.Text = "NEW"
                End If
                btnSave.Enabled = True
            Else
                If txtSupplierCode.Text = "" Then
                    MsgBox("Please enter supplier code", vbOKOnly + vbCritical, "Error: Missing information")
                Else
                    MsgBox("No matching supplier", vbOKOnly + vbCritical, "Error: Not found")
                End If
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        If txtOrderNo.Text = "" Then
            MsgBox("Please select an order to delete.", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If
        Dim order As New Order
        If order.isOrderExist(txtOrderNo.Text) <> True Then
            MsgBox("No matching order", vbOKOnly + vbExclamation, "")
            Exit Sub
        End If
        search(txtId.Text, txtOrderNo.Text)
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected order: " + txtOrderNo.Text + " ? Information on this order will be removed from the system.", vbYesNo + vbQuestion, "Delete order?")
        If res = DialogResult.Yes Then
            order.deleteOrder(txtOrderNo.Text)
            MsgBox("Order Successively removed", vbOKOnly + vbInformation, "")
        End If
    End Sub

    Private Sub txtOrderNo_preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtOrderNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            search("", txtOrderNo.Text)
        End If
    End Sub

    Private Sub btnSearchItem_Click(sender As Object, e As EventArgs) Handles btnSearchItem.Click
        If txtSupplierCode.Text = "" Then
            MsgBox("Please select Supplier", vbOKOnly + vbCritical, "Error: No supplier")
            Exit Sub
        End If
        Dim found As Boolean = False
        Dim valid As Boolean = False
        Dim barcode As String = txtBarCode.Text
        Dim code As String = txtItemCodeS.Text
        Dim description As String = cmbDescription.Text
        Try
            Dim product As Product
            Dim response As Object = New Object
            Dim json As JObject = New JObject

            If barcode <> "" Then
                response = Web.get_("products/barcode=" + barcode)
                json = JObject.Parse(response)
                product = JsonConvert.DeserializeObject(Of Product)(json.ToString)
            ElseIf code <> "" Then
                response = Web.get_("products/code=" + code)
                json = JObject.Parse(response)
                product = JsonConvert.DeserializeObject(Of Product)(json.ToString)
            ElseIf description <> "" Then
                response = Web.get_("products/description=" + description)
                json = JObject.Parse(response)
                product = JsonConvert.DeserializeObject(Of Product)(json.ToString)
            Else
                MsgBox("Please enter a search key", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If

            txtItemCodeS.Text = product.code
            cmbDescription.Text = product.description
            txtPackSize.Text = product.packSize
            txtCostPrice.Text = product.costPriceVatIncl
            txtStockSize.Text = product.stock
            found = True
            If isSupply(txtItemCodeS.Text, txtSupplierCode.Text) = False And found = True Then
                MsgBox("Can not add product to this order. Product not available for this Supplier")
                clearFields()
            Else
                valid = True
                lockFields()
                txtQuantity.ReadOnly = False
            End If
            If found = False Then
                MsgBox("Product not found", vbOKOnly + vbCritical, "Item not found")
                clearFields()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub clearFields()
        txtBarCode.Text = ""
        txtItemCodeS.Text = ""
        cmbDescription.SelectedItem = Nothing
        cmbDescription.Text = ""
        txtPackSize.Text = ""
        txtQuantity.Text = ""
        txtCostPrice.Text = ""
        txtStockSize.Text = ""
    End Sub
    Private Sub lockFields()
        txtBarCode.ReadOnly = True
        txtItemCodeS.ReadOnly = True
        cmbDescription.Enabled = False

        btnAdd.Enabled = True
    End Sub
    Private Sub unLockFields()
        txtBarCode.ReadOnly = False
        txtItemCodeS.ReadOnly = False
        cmbDescription.Enabled = True

        btnAdd.Enabled = False
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim status As String
        Try
            status = Web.get_("lpos/get_status/id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
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
        If status = "" Then
            MsgBox("You can not edit this order. Order status unknown.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        Dim barCode As String = txtBarCode.Text
        Dim code As String = txtItemCodeS.Text
        Dim description As String = cmbDescription.Text
        Dim qty As String = txtQuantity.Text
        Dim costPrice As String = txtCostPrice.Text
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

            Dim lpo_ As Lpo
            Dim response As Object = New Object
            Dim json As JObject = New JObject
            If txtId.Text = "" Then
                lpo_ = New Lpo
                lpo_.no = "NA"
                lpo_.createdUser.id = User.CURRENT_USER_ID
                lpo_.supplier.code = txtSupplierCode.Text
                lpo_.supplier.name = cmbSupplierName.Text
                lpo_.issueDate = dateIssueDate.Value.ToString("yyyy-MM-dd")
                lpo_.validityDays = cmbValidityPeriod.Text
                lpo_.validUntil = dateValidUntil.Value.ToString("yyyy-MM-dd")
                lpo_.comment = txtComment.Text

                response = Web.post(lpo_, "lpos/new")
                json = JObject.Parse(response)
                lpo_ = JsonConvert.DeserializeObject(Of Lpo)(json.ToString)
                txtId.Text = lpo_.id
                txtOrderNo.Text = lpo_.no
            End If



            '   txtVaildUntil.Text = ((New Day).getCurrentDay.AddDays(validityPeriod)).ToString("yyyy-MM-dd")  sample code

            Dim lpoDetail As LpoDetail = New LpoDetail
            lpoDetail.lpo.id = txtId.Text
            lpoDetail.barcode = barCode
            lpoDetail.code = code
            lpoDetail.description = description
            lpoDetail.qty = qty
            lpoDetail.packSize = packSize
            lpoDetail.costPrice = costPrice

            response = Web.post(lpoDetail, "lpo_details/new_or_edit")
            Dim lpoDetails As List(Of LpoDetail) = New List(Of LpoDetail)
            lpoDetails = JsonConvert.DeserializeObject(Of List(Of LpoDetail))(response.ToString)
            refreshList(lpoDetails)
            If dtgrdItemList.RowCount <= 1 Then
                refreshLPOList()
                search(txtId.Text, "")
            End If
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
            status = Web.get_("lpos/get_status/id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If status = "APPROVED" Then
            MsgBox("You can not approve this LPO. LPO already approved.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "PRINTED" Then
            MsgBox("You can not approve this LPO. LPO already printed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "REPRINTED" Then
            MsgBox("You can not approve this LPO. LPO already printed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("You can not approve this LPO. LPO already completed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("You can not approve this LPO. LPO canceled.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "BLANK" Then
            MsgBox("Could not approve a blank LPO", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "" Then
            MsgBox("You can not approve this LPO. Order status unknown.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If User.authorize("APPROVE LPO") = True Then
            If txtOrderNo.Text = "" Then
                MsgBox("Please select an LPO to approve", vbOKOnly + vbInformation, "")
                Exit Sub
            End If
            Dim res As Integer = MsgBox("Are you sure you want to approve LPO : " + txtOrderNo.Text + " ? Once approved, the LPO can not be edited", vbYesNo + vbQuestion, "Approve LPO?")
            If res = DialogResult.Yes Then
                'approve order

                If dtgrdItemList.RowCount = 0 Then
                    MsgBox("You can not approve an empty LPO", vbOKOnly + vbInformation, "")
                    Exit Sub
                End If

                Dim approved As Boolean = False
                Try
                    approved = Web.put(vbNull, "lpos/approve/id=" + txtId.Text)
                Catch ex As Exception
                    approved = False
                End Try
                If approved = True Then
                    MsgBox("LPO Successively approved", vbOKOnly + vbInformation, "")
                Else
                    MsgBox("Operation failed")
                End If
                search(txtId.Text, "")
                refreshLPOList()
            End If
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub txtOrderNo_TextChanged(sender As Object, e As EventArgs) Handles txtOrderNo.TextChanged
        If txtOrderNo.Text = "" Then
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

    Private Sub cmbSupplier_KeyUp(sender As Object, e As EventArgs) Handles cmbSupplierName.KeyUp
        Dim currentText As String = cmbSupplierName.Text
        shortSupplier.Clear()
        cmbSupplierName.Items.Clear()
        cmbSupplierName.Items.Add(currentText)
        cmbSupplierName.DroppedDown = True
        For Each text As String In longSupplier
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbSupplierName.Text.ToUpper()) Then
                shortSupplier.Add(text)
            End If
        Next
        cmbSupplierName.Items.AddRange(shortSupplier.ToArray())
        cmbSupplierName.SelectionStart = cmbSupplierName.Text.Length
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub dtgrdLPOList_CellContentClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdLPOList.RowHeaderMouseClick
        Dim r As Integer = dtgrdLPOList.CurrentRow.Index
        Dim lpoId As String = dtgrdLPOList.Item(0, r).Value.ToString
        Dim lpoNo As String = dtgrdLPOList.Item(1, r).Value.ToString
        txtId.Text = lpoId
        txtOrderNo.Text = lpoNo
        search(lpoId, "")
    End Sub

    Private Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click
        Dim status As String
        Try
            status = Web.get_("lpos/get_status/id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If Not status = "COMPLETED" Then
            MsgBox("Only COMPLETED LPO can be archived", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        '     If User.authorize("APPROVE LPO") = True Then
        If txtOrderNo.Text = "" Then
            MsgBox("Please select LPO to archive", vbOKOnly + vbInformation, "")
            Exit Sub
        End If

        Dim archived As Boolean = False
        Try
            archived = Web.put(vbNull, "lpos/archive/id=" + txtId.Text)
        Catch ex As Exception
            archived = False
        End Try
        If archived = True Then
            MsgBox("LPO Successively archived", vbOKOnly + vbInformation, "")
        Else
            MsgBox("Poeration failed")
        End If
        search(txtId.Text, "")
        refreshLPOList()


        '   Else
        'MsgBox("Access denied!", vbOKOnly + vbExclamation)
        ' End If
    End Sub

    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim status As String
        Try
            status = Web.get_("lpos/get_status/id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If Not (status = "PENDING") Then
            MsgBox("Only a PENDING LPO can be canceled", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        '     If User.authorize("APPROVE LPO") = True Then
        If txtOrderNo.Text = "" Then
            MsgBox("Please select an LPO to cancel", vbOKOnly + vbExclamation, "")
            Exit Sub
        End If

        'approve order
        Dim res As Integer = MsgBox("Are you sure you want to cancel LPO : " + txtOrderNo.Text + " ? After canceling, the order will be rendered invalid", vbYesNo + vbQuestion, "Cancel LPO?")
        Try
            status = Web.get_("lpos/get_status/id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If res = DialogResult.Yes And (status = "PENDING") Then

            Dim canceled As Boolean = False
            Try
                canceled = Web.put(vbNull, "lpos/cancel/id=" + txtId.Text)
            Catch ex As Exception
                canceled = False
            End Try
            If canceled = True Then
                MsgBox("LPO Successively canceled", vbOKOnly + vbInformation, "")
            Else
                MsgBox("Operation failed")
            End If
            search(txtId.Text, "")
            refreshLPOList()
        End If

        '   Else
        'MsgBox("Access denied!", vbOKOnly + vbExclamation)
        ' End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If txtOrderNo.Text = "" Then
            MsgBox("Select an LPO to print.", vbOKOnly + vbCritical, "Error:No selection")
            Exit Sub
        End If
        Dim status As String
        Try
            status = Web.get_("lpos/get_status/id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If status = "PRINTED" Or status = "REPRINTED" Then
            Dim res As Integer = MsgBox("This LPO has already been printed. Would you like to re-print it?", vbYesNo + vbQuestion, "Reprint LPO?")
            If res = DialogResult.Yes Then
                'continue
            Else
                Exit Sub
            End If
        End If
        If status = "PENDING" Or status = "NEW" Or status = "CANCELLED" Or status = "CANCELED" Or status = "BLANK" Then
            MsgBox("Could not print LPO. LPO not approved", vbOKOnly + vbExclamation, "Invalid operation")
            Exit Sub
        End If
        If status = "" Then
            MsgBox("Could not print LPO. LPO status unknown", vbOKOnly + vbExclamation, "Invalid operation")
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("Could not print LPO. LPO already completed", vbOKOnly + vbExclamation, "Invalid operation")
            Exit Sub
        End If

        Dim printed As Boolean = False
        Try
            printed = Web.put(vbNull, "lpos/print/id=" + txtId.Text)
        Catch ex As Exception
            printed = False
        End Try
        If printed = True Then
            MsgBox("LPO Successively printed", vbOKOnly + vbInformation, "Success: LPO Printed")
        Else
            MsgBox("Operation failed")
        End If
        search(txtId.Text, "")
        refreshLPOList()
        If printed = False Then
            Exit Sub
        End If

        Dim document As Document = New Document
        document.Info.Title = "Local Purchase Order"
        document.Info.Subject = "Local Purchase Order"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\" & txtOrderNo.Text & ".pdf"

        myRenderer.PdfDocument.Save(filename)
        Process.Start(filename)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
        clearFields()
    End Sub
End Class