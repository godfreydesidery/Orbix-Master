Imports System.IO
Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.ProductVersionInfo
Imports MigraDoc.Rendering
Imports MigraDoc.RtfRendering
Imports PdfSharp.Pdf

Public Class frmPrintLPO
    Dim orderNo As String = ""
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Private Function clear()
        txtValidUntil.Text = ""
        txtStatus.Text = ""
        txtSupplier.Text = ""
        Return vbNull
    End Function
    Private Function search()
        Dim order As New Order
        If order.getOrder(txtOrderNo.Text) = True Then
            orderNo = txtOrderNo.Text
            txtValidUntil.Text = order.GL_VALID_UNTIL
            txtStatus.Text = order.GL_STATUS
            txtOrderDate.Text = order.GL_ORDER_DATE
            txtValidityPeriod.Text = order.GL_VALIDITY_PERIOD
            txtSupplier.Text = (New Supplier).getSupplierName(order.GL_SUPPLIER_ID, "")
            loadOrderDetails(txtOrderNo.Text)
        Else
            orderNo = ""
            dtgrdItemList.Rows.Clear()
            clear()
            MsgBox("No matching purchase order", vbOKOnly + vbCritical, "Error: Not found")
        End If
        Return vbNull
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search()
    End Sub
    Private Function horizontalLine(length As Integer)
        Dim line As String = ""
        For i As Integer = 1 To length
            line = line + "_"
        Next
        Return line
    End Function
    Private Function centerText(text As String)
        For i As Integer = 1 To ((90 - text.Length) / 2)
            text = "`" + text
        Next
        Return text
    End Function
    Private Sub ttestPdf()

        Dim document As Document = New Document

        document.Info.Title = "Report"
        document.Info.Subject = "Sample Report"
        document.Info.Author = "Godfrey"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Demo1.pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)

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
        documentTitle.AddText("Local Purchase Order")
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
        paragraph.AddFormattedText("To:          " + txtSupplier.Text, TextFormat.Bold)
        paragraph.Format.Font.Size = 9
        Dim supplier As New Supplier
        supplier.search((New Supplier).getSupplierCode("", txtSupplier.Text))
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Address " + supplier.GL_POST_ADDRESS)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Phone " + supplier.GL_TELEPHONE)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Fax " + supplier.GL_FAX)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Email " + supplier.GL_EMAIL)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Order#:      " + orderNo)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Order Date:  " + txtOrderDate.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Valid Up To: " + txtValidUntil.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Supplier#:   " + ((New Supplier).getSupplierCode("", txtSupplier.Text)) + " " + txtSupplier.Text)
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

        column = table.AddColumn("3cm")
        column.Format.Alignment = ParagraphAlignment.Center


        column = table.AddColumn("9cm")
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
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        'row.Shading.Color = TableBlue
        row.Cells(0).AddParagraph("Code")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Description")

        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Pack Size")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Qty")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left

        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalQty As Double = 0

        For i As Integer = 0 To dtgrdItemList.RowCount - 1
            Dim code As String = dtgrdItemList.Item(0, i).Value.ToString
            Dim descr As String = dtgrdItemList.Item(1, i).Value.ToString
            Dim packing As String = dtgrdItemList.Item(2, i).Value.ToString
            Dim qty As String = dtgrdItemList.Item(3, i).Value.ToString
            totalQty = totalQty + Val(qty)
            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.White
            row.Cells(0).AddParagraph(code)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(descr)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(packing)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(qty)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Left

            table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        Next
        'Add total quantity field
        paragraph = section.AddParagraph()
        paragraph.Format.SpaceBefore = "1cm"
        paragraph.Style = "Reference"
        paragraph.AddTab()
        paragraph.AddText("Total Quantity: " + totalQty.ToString)

    End Sub

    Private Function loadOrderDetails(orderNo)
        dtgrdItemList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `sn`, `order_no`, `item_code`, `quantity`, `unit_cost_price`, `stock_size` FROM `order_details` WHERE `order_no`='" + orderNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim itemCode As String = ""
            Dim description As String = ""
            Dim quantity As String = ""
            Dim costPrice As String = ""
            Dim stockSize As String = ""
            Dim packSize As String = ""

            While reader.Read
                Dim item As New Item
                itemCode = reader.GetString("item_code")
                item.searchItem(itemCode)
                description = item.GL_LONG_DESCR
                quantity = reader.GetString("quantity")
                costPrice = LCurrency.displayValue(reader.GetString("unit_cost_price"))
                stockSize = reader.GetString("stock_size")
                packSize = item.GL_PCK

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell


                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = itemCode
                dtgrdRow.Cells.Add(dtgrdCell)


                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = description
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = packSize
                dtgrdRow.Cells.Add(dtgrdCell)


                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = quantity
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = costPrice
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = stockSize
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdItemList.Rows.Add(dtgrdRow)

            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function

    Private Sub dtgrdItemList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdItemList.CellContentClick

    End Sub

    Private Sub btnPrint_Click_1(sender As Object, e As EventArgs) Handles btnPrint.Click

        If orderNo = "" Then
            MsgBox("Select order to print.", vbOKOnly + vbCritical, "Error:No selection")
            Exit Sub
        End If
        Dim status As String = (New Order).getStatus(txtOrderNo.Text)
        If status = "PRINTED" Or status = "REPRINTED" Then
            Dim res As Integer = MsgBox("This order has already been printed. Would you like to re-print it?", vbYesNo + vbQuestion, "Reprint order?")
            If res = DialogResult.Yes Then
                'continue
            Else
                Exit Sub
            End If
        End If
        If status = "PENDING" Or status = "NEW" Or status = "CANCELLED" Or status = "BLANK" Then
            MsgBox("Could not print order. Order has not been approved", vbOKOnly, "Invalid operation")
            Exit Sub
        End If
        If status = "" Then
            MsgBox("Could not print order. Order status unknown", vbOKOnly, "Invalid operation")
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("Could not print order. Order already completed", vbOKOnly, "Invalid operation")
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

        myRenderer.PdfDocument.Save(fileName)

        Process.Start(filename)
        Dim order As New Order
        If status = "PRINTED" Or status = "REPRINTED" Then
            order.changeStatus(orderNo, "REPRINTED")
        Else
            order.changeStatus(orderNo, "PRINTED")
        End If
        refreshOrderList()

    End Sub

    Private Sub txtOrderNo_previewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtOrderNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            search()
        End If
    End Sub
    Private Sub clearFields()
        txtOrderNo.Text = ""
        txtOrderDate.Text = ""
        txtStatus.Text = ""
        txtSupplier.Text = ""
        txtValidityPeriod.Text = ""
        txtValidUntil.Text = ""
    End Sub
    Private Sub frmPrintLPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshOrderList()
        clearFields()
        dtgrdItemList.Rows.Clear()
    End Sub
    Private Sub refreshOrderList()
        dtgrdOrderList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `order_id`, `order_no`, `order_date`, `validity_period`, `valid_until`, `supplier_id`, `status`, `user_id` FROM `orders` WHERE `status`='APPROVED' OR `status`='PRINTED' OR `status`='REPRINTED'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim orderNo As String = ""
            Dim orderDate As String = ""
            Dim supplierID As String = ""
            Dim orderTotal As String = ""
            Dim status As String = ""


            While reader.Read
                Dim item As New Item
                orderNo = reader.GetString("order_no")
                orderDate = reader.GetString("order_date")
                supplierID = reader.GetString("supplier_id")
                status = reader.GetString("status")

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell


                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = orderNo
                dtgrdRow.Cells.Add(dtgrdCell)


                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = orderDate
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = (New Supplier).getSupplierName(supplierID, "")
                dtgrdRow.Cells.Add(dtgrdCell)


                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue((New Order).getOrderTotal(orderNo))
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = status
                dtgrdRow.Cells.Add(dtgrdCell)



                dtgrdOrderList.Rows.Add(dtgrdRow)

            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub dtgrdOrderList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdOrderList.CellClick
        Dim r As Integer = dtgrdOrderList.CurrentRow.Index
        Dim orderNo As String = dtgrdOrderList.Item(0, r).Value.ToString
        txtOrderNo.Text = orderNo
        search()
    End Sub

    Private Sub dtgrdOrderList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdOrderList.CellContentClick

    End Sub
End Class