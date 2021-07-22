Imports System.IO
Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmGRNReport
    Private Sub frmGRNReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'refreshBillList("", "", "", "", "")
        dtgrdGRNList.Rows.Clear()
        dtgrdGRNParticulars.Rows.Clear()

        'Dim conn As New MySqlConnection(Database.conString)
        'Try
        '    Dim suppcommand As New MySqlCommand()
        '    Dim supplierQuery As String = "SELECT `supplier_id`, `supplier_name` FROM `supplier`"
        '    conn.Open()
        '    suppcommand.CommandText = supplierQuery
        '    suppcommand.Connection = conn
        '    suppcommand.CommandType = CommandType.Text
        '    Dim reader As MySqlDataReader = suppcommand.ExecuteReader
        '    cmbSupplier.Items.Clear()
        '    cmbSupplier.Items.Add("")
        '    If reader.HasRows Then
        '        While reader.Read
        '            cmbSupplier.Items.Add(reader.GetString("supplier_name"))
        '        End While
        '    End If
        '    conn.Close()
        'Catch ex As Devart.Data.MySql.MySqlException
        '    ErrorMessage.dbConnectionError()
        '    Exit Sub
        'End Try

    End Sub
    Private Sub dtgrdGRNList_cellclick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdGRNList.CellClick
        Try
            Dim i As Integer = dtgrdGRNList.CurrentRow.Index
            Dim grnNo As String = ""
            grnNo = dtgrdGRNList.Item(0, dtgrdGRNList.CurrentRow.Index).Value
            refreshParticulars(grnNo)
            txtOrderNo.Text = dtgrdGRNList.Item(3, i).Value
            txtInvoiceNo.Text = dtgrdGRNList.Item(2, i).Value
            txtGRNNo.Text = dtgrdGRNList.Item(0, i).Value
            txtDate.Text = dtgrdGRNList.Item(1, i).Value
            lblGRNNo.Text = grnNo
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Function refreshParticulars(grnNo As String)
        dtgrdGRNParticulars.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "SELECT `sn`, `grn_no`, `item_code`, `qty`, `unit_cost` FROM `goods_received_note_particulars` WHERE `grn_no`='" + grnNo + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim total As Double = 0
            While reader.Read
                Dim itemCode As String = reader.GetString("item_code")
                Dim description As String = (New Item).getItemLongDescription(itemCode)
                Dim qty As String = reader.GetString("qty")
                Dim price As String = reader.GetString("unit_cost")
                Dim amount As String = Val(qty) * Val(price)

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = itemCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = description
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = qty
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(price)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(amount)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdGRNParticulars.Rows.Add(dtgrdRow)
                total = total + Val(amount)
            End While
            conn.Close()
            txtTotalAmount.Text = LCurrency.displayValue(total.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function
    Dim filter As Boolean = False
    Private Function refreshBillList(grnNo As String, fromDate As String, toDate As String, invoiceNo As String, orderNo As String)
        dtgrdGRNList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT `grn_no`, `order_no`, `invoice_no`, `grn_date`, `amount` FROM `goods_received_note`"

            If grnNo = "" And invoiceNo = "" And orderNo = "" Then
                query = "SELECT `grn_no`, `order_no`, `invoice_no`, `grn_date`, `amount` FROM `goods_received_note` WHERE `grn_date` BETWEEN '" + fromDate + "' AND '" + toDate + "'"
            End If
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                Dim grnNo_ As String = reader.GetString("grn_no")
                Dim date_ As String = reader.GetString("grn_date")
                Dim invoiceNo_ As String = reader.GetString("invoice_no")
                Dim orderNo_ As String = reader.GetString("order_no")
                Dim amount As String = reader.GetString("amount")

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = grnNo_
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = date_
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = invoiceNo_
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = orderNo_
                dtgrdRow.Cells.Add(dtgrdCell)

                Dim id As String = (New Order).getSupplierID(grnNo_)
                Dim supplierCode As String = (New Supplier).getSupplierCode(id, "")
                If filter = True Then
                    If supplierCode <> "" And txtSupplierCode.Text = supplierCode Then
                        dtgrdGRNList.Rows.Add(dtgrdRow)
                    End If
                Else
                    dtgrdGRNList.Rows.Add(dtgrdRow)
                End If

            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function

    Private Sub dtgrdGRNList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdGRNList.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        refreshBillList(txtGRNNo.Text, dateStart.Text, dateEnd.Text, txtInvoiceNo.Text, txtOrderNo.Text)
    End Sub
    Private Sub txtInvoiceNo_previewkeydown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtInvoiceNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            refreshBillList(txtGRNNo.Text, dateStart.Text, dateEnd.Text, txtInvoiceNo.Text, txtOrderNo.Text)
        End If
    End Sub
    Private Sub txtorderno_previewkeydown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtOrderNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            refreshBillList(txtGRNNo.Text, dateStart.Text, dateEnd.Text, txtInvoiceNo.Text, txtOrderNo.Text)
        End If
    End Sub
    Private Sub txtgrnNo_previewkeydown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtGRNNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            refreshBillList(txtGRNNo.Text, dateStart.Text, dateEnd.Text, txtInvoiceNo.Text, txtOrderNo.Text)
        End If
    End Sub
    Private Sub txtGRNNo_TextChanged(sender As Object, e As EventArgs) Handles txtGRNNo.TextChanged

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblGRNNo_Click(sender As Object, e As EventArgs) Handles lblGRNNo.Click

    End Sub

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
    Private Function printGRN(grnNo As String, orderNo As String, invoiceNo As String, supplierCode As String, date_ As String, grnAmount As String)

        Dim document As Document = New Document

        document.Info.Title = "GRN Report"
        document.Info.Subject = "GRN Report"
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
        documentTitle.AddText("GRN Report")
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

        For i As Integer = 0 To dtgrdGRNParticulars.RowCount - 1
            Dim code As String = dtgrdGRNParticulars.Item(0, i).Value
            Dim description As String = dtgrdGRNParticulars.Item(1, i).Value
            Dim qty As String = dtgrdGRNParticulars.Item(2, i).Value
            Dim price As String = dtgrdGRNParticulars.Item(3, i).Value
            Dim amount As String = dtgrdGRNParticulars.Item(4, i).Value
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


        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

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
        row.Cells(3).AddParagraph("Total Qty")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(4).AddParagraph(totalQty)
        row.Cells(4).Format.Alignment = ParagraphAlignment.Right


        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
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
        row.Cells(3).AddParagraph("Total Amount")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(4).AddParagraph(grnAmount)
        row.Cells(4).Format.Alignment = ParagraphAlignment.Right

        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If dtgrdGRNParticulars.RowCount > 0 Then
            printGRN(txtGRNNo.Text, txtOrderNo.Text, txtInvoiceNo.Text, (New Supplier).getSupplierCode((New Order).getSupplierID(txtGRNNo.Text), ""), txtDate.Text, txtTotalAmount.Text)
        Else
            MsgBox("Could not print! List empty.", vbOKOnly + vbExclamation, "Error: Empty list")
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub btnListBySupplier_Click(sender As Object, e As EventArgs) Handles btnListBySupplier.Click
        filter = True
        If txtSupplierCode.Text <> "" Then
            txtSupplier.Text = (New Supplier).getSupplierName("", txtSupplierCode.Text)
        ElseIf txtSupplier.Text <> "" Then
            txtSupplierCode.Text = (New Supplier).getSupplierCode("", txtSupplier.Text)
        End If
        refreshBillList(txtGRNNo.Text, dateStart.Text, dateEnd.Text, txtInvoiceNo.Text, txtOrderNo.Text)
        filter = False
    End Sub

    Private Sub cmbSupplier_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbSupplier_MouseClick(sender As Object, e As MouseEventArgs)
        txtSupplierCode.Text = ""
    End Sub

    Private Sub txtSupplierCode_TextChanged(sender As Object, e As EventArgs) Handles txtSupplierCode.TextChanged

    End Sub

    Private Sub txtSupplierCode_MouseEnter(sender As Object, e As EventArgs) Handles txtSupplierCode.MouseEnter
        txtSupplier.Text = ""
    End Sub

    Private Sub btnListAll_Click(sender As Object, e As EventArgs) Handles btnListAll.Click
        refreshBillList(txtGRNNo.Text, dateStart.Text, dateEnd.Text, txtInvoiceNo.Text, txtOrderNo.Text)
    End Sub

    Private Sub txtSupplier_TextChanged(sender As Object, e As EventArgs) Handles txtSupplier.TextChanged

    End Sub

    Private Sub txtSupplier_MouseEnter(sender As Object, e As EventArgs) Handles txtSupplier.MouseEnter
        Dim list As New List(Of String)
        Dim mySource As New AutoCompleteStringCollection
        Dim supplier As New Supplier
        list = supplier.getNames()
        mySource.AddRange(list.ToArray)
        txtSupplier.AutoCompleteCustomSource = mySource
        txtSupplier.AutoCompleteMode = AutoCompleteMode.Suggest
        txtSupplier.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub
End Class