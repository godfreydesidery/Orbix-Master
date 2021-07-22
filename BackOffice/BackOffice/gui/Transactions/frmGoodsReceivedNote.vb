Imports System.IO
Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmGoodsReceivedNote
    Dim orderNo As String = ""
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If txtOrderNo.Text = "" Then
            MsgBox("Enter order number !", vbOKOnly + vbExclamation, "Error: Missing information")
            Exit Sub
        End If

        Dim status As String = ""
        Try
            status = Web.get_("lpos/get_status/no=" + txtOrderNo.Text)
        Catch ex As Exception

        End Try

        '   json = JObject.Parse(response)
        If status = "PRINTED" Or status = "REPRINTED" Then

        Else
            If status = "PENDING" Or status = "APPROVED" Then
                MsgBox("Goods can not be received. This order have not been printed!", vbOKOnly + vbCritical, "Error: Order not printed")
            ElseIf status = "COMPLETED" Then
                MsgBox("Order already completed!", vbOKOnly + vbExclamation, "Error: Completed order")
            ElseIf status = "CANCELLED" Then
                MsgBox("Order cancelled!", vbOKOnly + vbExclamation, "Error: Cancelled order")
            Else
                MsgBox("Order not available!", vbOKOnly + vbExclamation, "Error: Not available")
            End If
            Exit Sub
        End If

        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Dim lpo As Lpo = New Lpo
        Try
            response = Web.get_("lpos/no=" + txtOrderNo.Text)
            json = JObject.Parse(response)
            lpo = JsonConvert.DeserializeObject(Of Lpo)(json.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try
        txtOrderNo.Text = lpo.no
        If Not IsNothing(lpo.supplier) Then
            txtSupplierCode.Text = lpo.supplier.code
            txtSupplier.Text = lpo.supplier.name
        End If
        txtOrderNo.ReadOnly = True
        If Not IsNothing(lpo.lpoDetails) Then
            Dim details As List(Of LpoDetail) = lpo.lpoDetails
            For Each detail In details
                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell


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
                dtgrdCell.Value = ""
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = ""
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = detail.costPrice
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewCheckBoxCell()
                dtgrdCell.Value = True
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = detail.id
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdItemList.Rows.Add(dtgrdRow)
            Next
        End If
    End Sub

    Private Function checkCost(supplierCost As Double, clientCost As Double) As Boolean
        Dim lessOrEqual As Boolean = True
        If (supplierCost - clientCost) > 0 Then
            lessOrEqual = False
        End If
        Return lessOrEqual
    End Function
    Private Function checkQuantity(suppliedQty As Double, orderedQty As Double) As Boolean
        Dim lessOrEqual As Boolean = True
        If suppliedQty - orderedQty > 0 Then
            lessOrEqual = False
        End If
        Return lessOrEqual
    End Function
    Private Function received(hasReceived As Boolean)
        If hasReceived = True Then
            dtgrdItemList.Item(6, dtgrdItemList.CurrentCell.RowIndex).Value = "YES"
        Else
            dtgrdItemList.Item(6, dtgrdItemList.CurrentCell.RowIndex).Value = "NO"
        End If
        refreshList()
        Return vbNull
    End Function
    Private Sub dtgrdItemList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdItemList.CellEndEdit

        Dim row As Integer = dtgrdItemList.CurrentCell.RowIndex
        Dim col As Integer = dtgrdItemList.CurrentCell.ColumnIndex

        Dim orderedQty As Double = Val(dtgrdItemList.Item(2, row).Value)
        Dim suppliedQty As Double = Val(dtgrdItemList.Item(3, row).Value)
        Dim supplierCost As Double = Val(dtgrdItemList.Item(4, row).Value)
        Dim clientCost As Double = Val(dtgrdItemList.Item(5, row).Value)

        If dtgrdItemList.CurrentCell.ColumnIndex = 3 Then
            If Not IsNumeric(dtgrdItemList.CurrentCell.Value) Then
                MsgBox("Invalid value. Input should be numeric", vbOKOnly + vbCritical, "Invalid entry")
                dtgrdItemList.CurrentCell.Value = 0
            End If
            If checkQuantity(suppliedQty, orderedQty) <> True Then
                MsgBox("Quantity value rejected. Received quantity should not exceed quantity ordered", vbOKOnly + vbCritical, "Error: Invalid entry")
                dtgrdItemList.CurrentCell.Value = 0
                Exit Sub
            End If
        End If
        If dtgrdItemList.CurrentCell.ColumnIndex = 4 Then
            If Val(dtgrdItemList.Item(3, row).Value) = 0 Then
                MsgBox("Enter Quantity first!", vbOKOnly + vbExclamation, "Quantity required")
                dtgrdItemList.CurrentCell.Value = 0
                received(False)
                Exit Sub
            End If
            If Not IsNumeric(dtgrdItemList.CurrentCell.Value) Then
                MsgBox("Invalid value. Input should be numeric", vbOKOnly + vbCritical, "Error: Invalid entry")
                dtgrdItemList.CurrentCell.Value = 0
                received(False)
                Exit Sub
            End If
            If checkCost(supplierCost, clientCost) <> True Then
                MsgBox("Supplier Cost exceed by " + LCurrency.displayValue((supplierCost - clientCost).ToString) + " This value will be rejected", vbOKOnly + vbCritical, "Error: Excess value")
                dtgrdItemList.CurrentCell.Value = 0
                received(False)
                Exit Sub
            End If
            received(True)
        End If
    End Sub
    Private Function clear()
        dtgrdItemList.Rows.Clear()
        txtOrderNo.Text = ""
        txtSupplier.Text = ""
        Return vbNull
    End Function
    Private Sub frmGoodsReceivedNote_Load(sender As Object, e As EventArgs) Handles Me.Shown
        clear()
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
    Private Function printGRN(grnNo As String, orderNo As String, invoiceNo As String, supplierCode As String, date_ As String, grnAmount As String)

        Dim document As Document = New Document

        document.Info.Title = "GRN"
        document.Info.Subject = "GRN"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document, grnNo, orderNo, invoiceNo, supplierCode, date_, grnAmount)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\GRN" & grnNo & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)

        Return vbNull
    End Function
    Private Sub createDocument(doc As Document, grnNo As String, orderNo As String, invoiceNo As String, supplierCode As String, date_ As String, grnAmount As String)

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
        documentTitle.AddText("Goods Received Note")
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
        paragraph.AddFormattedText("GRN#:        " + grnNo)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Order#:      " + orderNo)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Invoice#:    " + invoiceNo)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Received on: " + date_)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Supplier#:   " + supplierCode)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Supplier:    " + (New Supplier).getSupplierName("", supplierCode))
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

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Center


        column = table.AddColumn("8cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Code")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Description")

        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Qty")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Price@")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Center
        row.Cells(4).AddParagraph("Amount")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Center

        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalAmount As Double = 0
        Dim totalVat As Double = 0
        Dim totalDiscount As Double = 0
        Dim totalQty As Double = 0

        For i As Integer = 0 To dtgrdItemList.RowCount - 1
            Dim code As String = dtgrdItemList.Item(0, i).Value
            Dim description As String = dtgrdItemList.Item(1, i).Value
            Dim qty As String = dtgrdItemList.Item(3, i).Value
            Dim price As String = dtgrdItemList.Item(4, i).Value
            Dim amount As String = (Val(price) * Val(qty))
            totalQty = totalQty + Val(qty)
            price = LCurrency.displayValue(price)
            amount = LCurrency.displayValue(amount)

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.White
            row.Cells(0).AddParagraph(code)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(description)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(qty)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(price)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Right
            row.Cells(4).AddParagraph(amount)
            row.Cells(4).Format.Alignment = ParagraphAlignment.Right

            table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        Next

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
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

        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Total Qty")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(4).AddParagraph(totalQty)
        row.Cells(4).Format.Alignment = ParagraphAlignment.Right

        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Total Amount")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(4).AddParagraph(grnAmount)
        row.Cells(4).Format.Alignment = ParagraphAlignment.Right

        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

    End Sub
    Private Function validateList() As Boolean
        Dim valid As Boolean = False
        Dim emptyField As Boolean = False
        Dim atLeastOne As Integer = 0 'make sure at least one of the items in the order list have been received
        For i As Integer = 0 To dtgrdItemList.RowCount - 1
            Dim itemCode As String = dtgrdItemList.Item(0, i).Value
            Dim qtyReceived As String = dtgrdItemList.Item(3, i).Value
            Dim supplierUnitCost As Double = Val(dtgrdItemList.Item(4, i).Value)
            Dim clientUnitCost As Double = Val(dtgrdItemList.Item(5, i).Value)
            Dim received As String = dtgrdItemList.Item(6, i).Value
            If Val(qtyReceived) = 0 Then
                emptyField = True
            End If
            'modify this
            If supplierUnitCost <> clientUnitCost And received = "YES" Then
                valid = False
            Else
                valid = True
            End If
        Next
        If atLeastOne <= 0 Then
            MsgBox("Operation failed. At least one item should be received.", vbOKOnly + vbExclamation, "Error: No item received")
            valid = False
            Return valid
            Exit Function
        End If
        If valid = False Then
            MsgBox("There is an error in the List. Please cross check the list for missing information.", vbOKOnly + vbExclamation, "Error: List invalid")
            Return valid
            Exit Function
        End If
        If emptyField = True Then
            Dim res As Integer = MsgBox("The list might be missing important information. Please cross check the list for missing quantity and cost values. Proceed anyway?", vbYesNo + vbQuestion, "Some information might be missing")
            If res = DialogResult.Yes Then
                valid = True
            Else
                valid = False
            End If
        End If
        Return valid
    End Function
    Private Sub btnReceive_Click(sender As Object, e As EventArgs) Handles btnReceive.Click
        If orderNo <> "" Then
            If txtInvoiceNo.Text <> "" Then
                txtInvoiceNo.ReadOnly = True
                txtOrderNo.ReadOnly = True
                txtDate.Text = Day.DAY

                Dim status As String = ""
                Try
                    status = Web.get_("lpos/get_status/no=" + txtOrderNo.Text)
                Catch ex As Exception

                End Try

                If status = "PRINTED" Or status = "REPRINTED" Then
                    'continue
                Else
                    MsgBox("Can not complete order. Order already completed/canceled or has not been printed", vbOKOnly, "Invalid operation")
                    Exit Sub
                End If

                If dtgrdItemList.RowCount = 0 Then
                    MsgBox("Can not complete an empty order", vbOKOnly + vbExclamation, "Error: Missing information")
                    Exit Sub
                End If
                Dim res As Integer = MsgBox("Are you sure you want to complete this order?", vbYesNo + vbQuestion, "Complete Order?")
                If res = DialogResult.Yes Then
                    'complete the order
                Else
                    Exit Sub
                End If
                If validateList() = False Then
                    'discard operation
                    'MsgBox("There is an error in the List. Please cross check the list.", vbOKOnly + vbExclamation, "Error: List invalid")
                    Exit Sub
                End If

                Dim grn As Grn = New Grn
                grn.lpo.no = txtOrderNo.Text
                grn.receiveDate = Day.DAY
                grn.supplier.code = txtSupplierCode.Text
                grn.supplier.name = txtSupplier.Text

                Dim grnDetails As List(Of GrnDetail) = New List(Of GrnDetail)
                Dim grnDetail As GrnDetail = New GrnDetail

                For i As Integer = 0 To dtgrdItemList.RowCount - 1
                    grnDetail.code = dtgrdItemList.Item(0, i).Value
                    grnDetail.description = dtgrdItemList.Item(1, i).Value
                    grnDetail.qtyOrdered = dtgrdItemList.Item(2, i).Value
                    grnDetail.qtyReceived = dtgrdItemList.Item(3, i).Value
                    grnDetail.supplierCostPrice = Val(dtgrdItemList.Item(4, i).Value)
                    grnDetail.clientCostPrice = Val(dtgrdItemList.Item(5, i).Value)
                    grnDetails.Add(grnDetail)
                Next
                grn.grnDetails = grnDetails
                Dim response As Object = New Object
                Dim json As JObject = New JObject
                response = Web.post(grn, "grns/new")
                json = JObject.Parse(response)
                Dim grn_ As Grn = JsonConvert.DeserializeObject(Of Grn)(json.ToString)
                If Not (grn_.id.ToString = "") Then
                    txtGRNNo.Text = grn_.no
                    Dim ok As Integer = MsgBox("Operation successiful. Print GRN Note?", vbYesNo + vbInformation, "Success: Received goods") 'to implement grn print functionality
                    If ok = DialogResult.Yes Then
                        printGRN(grn_.no, txtOrderNo.Text, txtInvoiceNo.Text, txtSupplierCode.Text, txtDate.Text, LCurrency.displayValue(txtAmount.Text.ToString))
                    End If
                End If
                clear()
                clearFields()
                dtgrdItemList.Rows.Clear()
            Else
                MsgBox("Please enter invoice No!", vbOKOnly + vbExclamation, "Error: Missing information")
            End If
        End If
    End Sub


    Private Sub txtOrderNo_PeviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtOrderNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            '  search()
        End If
    End Sub
    Private Function refreshList()
        Dim total As Double = 0
        For i As Integer = 0 To dtgrdItemList.RowCount - 1
            If Val(dtgrdItemList.Item(3, i).Value) > 0 Then
                total = total + Val(LCurrency.getValue(dtgrdItemList.Item(4, i).Value)) * Val(dtgrdItemList.Item(3, i).Value)
            End If
        Next
        txtAmount.Text = LCurrency.displayValue(total.ToString)
        Return vbNull
    End Function
    Private Sub frmGoodsReceivedNote_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        clearFields()
        dtgrdItemList.Rows.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        dtgrdItemList.Rows.Clear()
        txtOrderNo.Text = ""
        orderNo = ""
        txtOrderNo.ReadOnly = False
        txtInvoiceNo.ReadOnly = False
        clearFields()
        dtgrdItemList.Rows.Clear()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearFields()
        dtgrdItemList.Rows.Clear()
    End Sub
    Private Sub clearFields()
        txtOrderNo.Text = ""
        orderNo = ""
        txtInvoiceNo.Text = ""
        txtGRNNo.Text = ""
        txtDate.Text = ""
        txtSupplierCode.Text = ""
        txtSupplier.Text = ""
        txtOrderNo.ReadOnly = False
        txtInvoiceNo.ReadOnly = False
    End Sub
End Class