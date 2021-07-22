Imports System.IO
Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmReceipts

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Private billDate As String = ""

    Private Function refreshParticulars(billNo As String)
        dtgrdParticulars.Rows.Clear()
        lblBillNo.Text = billNo
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "SELECT `sn`, `sale_id`, `item_code`, `selling_price`, `discounted_price`, `qty`, `amount`, `vat` FROM `sale_details` WHERE `sale_id`='" + billNo + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                Dim itemCode As String = reader.GetString("item_code")
                Dim description As String = (New Item).getItemLongDescription(itemCode)
                Dim qty As String = reader.GetString("qty")
                Dim price As String = reader.GetString("discounted_price")
                Dim amount As String = reader.GetString("amount")
                Dim discount As String = (Val(reader.GetString("selling_price")) - Val(price)).ToString
                Dim vat As String = reader.GetString("vat")

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

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(discount)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(vat)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdParticulars.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return vbNull
    End Function
    Private Function refreshBillList(receiptNo As String, fromDate As String, toDate As String, tillNo As String)
        dtgrdBillList.Rows.Clear()
        lblBillNo.Text = ""
        Dim billNo As String = (New Receipt).getBillNo(tillNo, receiptNo, fromDate)
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            If receiptNo = "" And fromDate = "" And toDate = "" And tillNo = "" Then
                query = "SELECT `receipt`.`bill_no`,  `receipt`.`till_no`,  `receipt`.`receipt_no`,  `receipt`.`date`, `bill`.`amount` FROM `receipt`,`bill` WHERE `receipt`.`bill_no`=`bill`.`bill_no` ORDER BY `bill`.`amount`"
            ElseIf receiptNo = "" And fromDate <> "" And toDate <> "" And tillNo = "" Then
                query = "SELECT `receipt`.`bill_no`,  `receipt`.`till_no`,  `receipt`.`receipt_no`,  `receipt`.`date`, `bill`.`amount` FROM `receipt`,`bill` WHERE `receipt`.`bill_no`=`bill`.`bill_no` AND `receipt`.`date` BETWEEN '" + fromDate + "' AND '" + toDate + "'ORDER BY `bill`.`amount`"
            ElseIf receiptNo <> "" And fromDate <> "" And toDate <> "" And tillNo = "" Then
                query = "SELECT `receipt`.`bill_no`,  `receipt`.`till_no`,  `receipt`.`receipt_no`,  `receipt`.`date`, `bill`.`amount` FROM `receipt`,`bill` WHERE `receipt`.`bill_no`=`bill`.`bill_no` AND `receipt`.`date` BETWEEN '" + fromDate + "' AND '" + toDate + "' AND `receipt`.`receipt_no`='" + receiptNo + "'ORDER BY `bill`.`amount`"
            ElseIf receiptNo = "" And fromDate <> "" And toDate <> "" And tillNo <> "" Then
                query = "SELECT `receipt`.`bill_no`,  `receipt`.`till_no`,  `receipt`.`receipt_no`,  `receipt`.`date`, `bill`.`amount` FROM `receipt`,`bill`  WHERE `receipt`.`bill_no`=`bill`.`bill_no` AND `receipt`.`date` BETWEEN '" + fromDate + "' AND '" + toDate + "' AND `receipt`.`till_no`='" + tillNo + "'ORDER BY `bill`.`amount`"
            Else
                query = "SELECT `receipt`.`bill_no`,  `receipt`.`till_no`,  `receipt`.`receipt_no`,  `receipt`.`date`, `bill`.`amount` FROM `receipt`,`bill`  WHERE `receipt`.`bill_no`=`bill`.`bill_no` AND `receipt`.`date` BETWEEN '" + fromDate + "' AND '" + toDate + "' AND `receipt`.`till_no`='" + tillNo + "' AND `receipt`.`receipt_no`='" + receiptNo + "'ORDER BY `bill`.`amount`"
            End If
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                Dim billNo_ As String = reader.GetString("bill_no")
                Dim tillNo_ As String = reader.GetString("till_no")
                Dim receiptNo_ As String = reader.GetString("receipt_no")
                Dim date_ As String = reader.GetString("date")
                Dim receipt As New Receipt
                receipt.getBill(billNo_)

                Dim amount As String = receipt.GL_AMOUNT
                Dim discount As String = receipt.GL_DISCOUNT
                Dim vat As String = receipt.GL_VAT

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = billNo_
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = tillNo_
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = receiptNo_
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = date_
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(amount)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdBillList.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function
    Private Sub frmReceipts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtgrdBillList.Rows.Clear()
        dtgrdParticulars.Rows.Clear()
        lblBillNo.Text = ""
        lblReceiptNo.Text = ""
        lblTillNo.Text = ""
    End Sub

    Private Sub btnViewAll_Click(sender As Object, e As EventArgs) Handles btnViewAll.Click
        refreshBillList("", "", "", "")
        dtgrdParticulars.Rows.Clear()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            dtgrdBillList.Rows.Clear()
            dtgrdParticulars.Rows.Clear()
            refreshBillList(txtReceiptNo.Text, dateStart.Text, dateEnd.Text, txtTillNo.Text)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtgrdBillList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdBillList.CellClick
        Try
            Dim billNo As String = ""

            billNo = dtgrdBillList.Item(0, dtgrdBillList.CurrentRow.Index).Value.ToString
            lblTillNo.Text = dtgrdBillList.Item(1, dtgrdBillList.CurrentRow.Index).Value.ToString
            lblReceiptNo.Text = dtgrdBillList.Item(2, dtgrdBillList.CurrentRow.Index).Value.ToString
            billDate = dtgrdBillList.Item(3, dtgrdBillList.CurrentRow.Index).Value.ToString

            refreshParticulars(billNo)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtgrdParticulars_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdParticulars.CellContentClick

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
    Private Sub btnReceipt_Click(sender As Object, e As EventArgs) Handles btnReceipt.Click
        Dim billNo As String = lblBillNo.Text
        Dim receiptNo As String = lblReceiptNo.Text
        If lblBillNo.Text = "" Then
            MsgBox("Select a bill to print.", vbOKOnly + vbCritical, "Error:No selection")
            Exit Sub
        End If
        If dtgrdBillList.RowCount = 0 Then
            MsgBox("Can not print an empty bill. Please select the bill to print", vbOKOnly + vbCritical, "Error: No selection")
            Exit Sub
        End If

        Dim document As Document = New Document

        document.Info.Title = "GRN"
        document.Info.Subject = "GRN"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Receipt " & billNo & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)

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
        documentTitle.AddText("Receipt")
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
        paragraph.AddFormattedText("TIN:        " + Company.GL_TIN)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("VRN:        " + Company.GL_VRN)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Till No:    " + lblTillNo.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Bill Date:  " + billDate)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Receipt No: " + lblReceiptNo.Text)
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


        column = table.AddColumn("6cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.8cm")
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
        row.Format.Font.Size = 8
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
        row.Cells(4).AddParagraph("Discount")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Center
        row.Cells(5).AddParagraph("VAT")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Center
        row.Cells(6).AddParagraph("Amount")
        row.Cells(6).Format.Alignment = ParagraphAlignment.Center


        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalAmount As Double = 0
        Dim totalVat As Double = 0
        Dim totalDiscount As Double = 0

        For i As Integer = 0 To dtgrdParticulars.RowCount - 1
            Dim code As String = dtgrdParticulars.Item(0, i).Value.ToString
            Dim description As String = dtgrdParticulars.Item(1, i).Value.ToString
            Dim qty As String = dtgrdParticulars.Item(2, i).Value.ToString
            Dim price As String = LCurrency.displayValue(dtgrdParticulars.Item(3, i).Value.ToString)
            Dim amount As String = LCurrency.displayValue(dtgrdParticulars.Item(4, i).Value.ToString)
            Dim discount As String = LCurrency.displayValue(dtgrdParticulars.Item(5, i).Value.ToString)
            Dim vat As String = LCurrency.displayValue(dtgrdParticulars.Item(6, i).Value.ToString)
            totalAmount = totalAmount + Val(LCurrency.getValue(qty)) * Val(LCurrency.getValue(price))
            totalVat = totalVat + Val(LCurrency.getValue(vat))
            totalDiscount = totalDiscount + Val(LCurrency.getValue(discount.ToString))

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Font.Size = 7
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
            row.Cells(4).AddParagraph(discount)
            row.Cells(4).Format.Alignment = ParagraphAlignment.Right
            row.Cells(5).AddParagraph(vat)
            row.Cells(5).Format.Alignment = ParagraphAlignment.Right
            row.Cells(6).AddParagraph(amount)
            row.Cells(6).Format.Alignment = ParagraphAlignment.Right

            table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
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


        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(4).AddParagraph()
        row.Cells(4).Format.Alignment = ParagraphAlignment.Right
        row.Cells(5).AddParagraph("Total Discount")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Right
        row.Cells(6).AddParagraph(LCurrency.displayValue(totalDiscount.ToString))
        row.Cells(6).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(4).AddParagraph()
        row.Cells(4).Format.Alignment = ParagraphAlignment.Right
        row.Cells(5).AddParagraph("Total VAT")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Right
        row.Cells(6).AddParagraph(LCurrency.displayValue(totalVat.ToString))
        row.Cells(6).Format.Alignment = ParagraphAlignment.Right
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
        row.Cells(3).AddParagraph("")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(4).AddParagraph()
        row.Cells(4).Format.Alignment = ParagraphAlignment.Right
        row.Cells(5).AddParagraph("Total Amount")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Right
        row.Cells(6).AddParagraph(LCurrency.displayValue(totalAmount.ToString))
        row.Cells(6).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

    End Sub

    Private Sub dtgrdBillList_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdBillList.CellContentClick

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub lblReceiptNo_Click(sender As Object, e As EventArgs) Handles lblReceiptNo.Click

    End Sub
End Class