Imports System.IO
Imports Devart.Data.MySql
Imports Microsoft.Office.Interop
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmDailySalesReport

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Private Function refreshList()
        dtgrdList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `date`,SUM(`amount`) AS total_amount,SUM(`discount`) AS total_discount,SUM(`tax_return`) AS total_tax FROM `sale` WHERE `date`>='" + dateStart.Text + "' AND `date`<='" + dateEnd.Text + "' GROUP BY `date`"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim date_ As String = ""
            Dim totalAmount As String = ""
            Dim totalDiscount As String = ""
            Dim totalTax As String = ""

            Dim total As Double = 0
            Dim discount As Double = 0
            Dim tax As Double = 0

            While reader.Read

                date_ = reader.GetString("date")
                totalAmount = LCurrency.displayValue(reader.GetString("total_amount"))
                totalDiscount = LCurrency.displayValue(reader.GetString("total_discount"))
                totalTax = LCurrency.displayValue(reader.GetString("total_tax"))

                total = total + Val(reader.GetString("total_amount"))
                discount = discount + Val(reader.GetString("total_discount"))
                tax = tax + Val(reader.GetString("total_tax"))


                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell


                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = date_
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = totalAmount
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = totalDiscount
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = totalTax
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdList.Rows.Add(dtgrdRow)
            End While
            conn.Close()
            txtTotalDiscount.Text = LCurrency.displayValue(discount.ToString)
            txtTotalSales.Text = LCurrency.displayValue(total.ToString)
            txtTotalVat.Text = LCurrency.displayValue(tax.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click



        refreshList()
    End Sub

    Private Sub frmDailySalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtgrdList.Rows.Clear()
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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs)


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
        documentTitle.AddText("Daily Sales Report")
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
        paragraph.AddText("From:  " + dateStart.Text + "  To:  " + dateEnd.Text)
        paragraph.Format.Alignment = ParagraphAlignment.Left
        paragraph.Format.Font.Size = 9
        paragraph.Format.Font.Color = Colors.Green

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

        column = table.AddColumn("3cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("3cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("3cm")
        column.Format.Alignment = ParagraphAlignment.Right

        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.HeadingFormat = True
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Date")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Sales")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Center
        row.Cells(2).AddParagraph("Discount")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Center
        row.Cells(3).AddParagraph("Vat")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Center

        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalQty As Double = 0

        For i As Integer = 0 To dtgrdList.RowCount - 1

            Dim date_ As String = dtgrdList.Item(0, i).Value
            Dim sales As String = dtgrdList.Item(1, i).Value
            Dim discount As String = dtgrdList.Item(2, i).Value
            Dim vat As String = dtgrdList.Item(3, i).Value

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.White
            row.Cells(0).AddParagraph(date_)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(sales)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Right
            row.Cells(2).AddParagraph(discount)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Right
            row.Cells(3).AddParagraph(vat)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Right

            table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Next

        row = table.AddRow()
        row.Format.Font.Bold = False
        row.HeadingFormat = False
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        row.Cells(2).AddParagraph("")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Right
        row.Cells(3).AddParagraph("")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right

        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Font.Bold = False
        row.HeadingFormat = False
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        row.Cells(2).AddParagraph("Total Sales")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Right
        row.Cells(3).AddParagraph(txtTotalSales.Text)
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(3).Format.Font.Bold = True

        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Font.Bold = False
        row.HeadingFormat = False
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        row.Cells(2).AddParagraph("Total Discount")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Right
        row.Cells(3).AddParagraph(txtTotalDiscount.Text)
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(3).Format.Font.Bold = True

        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Font.Bold = False
        row.HeadingFormat = False
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        row.Cells(2).AddParagraph("Total Vat")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Right
        row.Cells(3).AddParagraph(txtTotalVat.Text)
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(3).Format.Font.Bold = True

        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

    End Sub

    Private Sub dtgrdList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdList.CellContentClick

    End Sub

    Private Sub btnExportToPDF_Click(sender As Object, e As EventArgs) Handles btnExportToPDF.Click
        refreshList()
        Dim startDate As String = dateStart.Text
        Dim endDate As String = dateEnd.Text

        Dim document As Document = New Document

        document.Info.Title = "Daily Sales Report"
        document.Info.Subject = "Daily Sales Report"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Daily Sales Report " & dateStart.Text & " to " & dateEnd.Text & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)
    End Sub

    Private Sub btnExportToExcel_Click(sender As Object, e As EventArgs) Handles btnExportToExcel.Click
        Cursor = Cursors.WaitCursor
        If dtgrdList.RowCount = 0 Then
            MsgBox("Nothing to export")
            Exit Sub
        End If
        Dim appXL As Excel.Application
        Dim wbXl As Excel.Workbook
        Dim shXL As Excel.Worksheet
        Dim raXL As Excel.Range
        ' Start Excel and get Application object.
        appXL = CreateObject("Excel.Application")
        appXL.Visible = True
        ' Add a new workbook.
        wbXl = appXL.Workbooks.Add
        shXL = wbXl.ActiveSheet

        Dim r As Integer = 1

        shXL.Cells(r, 1).Value = "Daily Sales Report"

        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A" + r.ToString, "B" + r.ToString)
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        r = r + 1

        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "From: " + dateStart.Text
        shXL.Cells(r, 2).Value = "To: " + dateEnd.Text

        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A" + r.ToString, "B" + r.ToString)
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With


        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A" + r.ToString)
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        r = r + 2
        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "Date"
        shXL.Cells(r, 2).Value = "Amount"
        shXL.Cells(r, 3).Value = "Discount"
        shXL.Cells(r, 4).Value = "Vat"

        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A" + r.ToString, "D" + r.ToString)
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        r = r + 1
        'raXL = shXL.Range("C1", "C7")
        'raXL.Formula = "=A1 & "" "" & B1"
        'Dim r As Integer = 3
        For i As Integer = 0 To dtgrdList.RowCount - 1
            With shXL
                .Cells(r, 1).Value = dtgrdList.Item(0, i).Value
                .Cells(r, 2).Value = dtgrdList.Item(1, i).Value
                .Cells(r, 3).Value = dtgrdList.Item(2, i).Value
                .Cells(r, 4).Value = dtgrdList.Item(3, i).Value
            End With
            r = r + 1
        Next

        r = r + 1
        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "Total Discount"
        shXL.Cells(r, 2).Value = txtTotalDiscount.Text
        r = r + 1
        shXL.Cells(r, 1).Value = "Total Vat"
        shXL.Cells(r, 2).Value = txtTotalVat.Text
        r = r + 1
        shXL.Cells(r, 1).Value = "Total Sales"
        shXL.Cells(r, 2).Value = txtTotalSales.Text


        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "D1")
        raXL.EntireColumn.AutoFit()

        Dim strFileName As String = LSystem.saveToDesktop & "\Daily Sales Report " & dateStart.Text & dateEnd.Text & ".xls"
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try
        If System.IO.File.Exists(strFileName) Then
            Try
                'System.IO.File.Delete(strFileName)
            Catch ex As Exception
            End Try
        End If
        Try
            wbXl.Save()
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
        Exit Sub
Err_Handler:
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
        Cursor = Cursors.Default
    End Sub
End Class