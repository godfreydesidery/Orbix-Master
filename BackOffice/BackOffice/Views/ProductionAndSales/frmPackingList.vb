Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmPackingList
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
        If report = True Then
            documentTitle.AddText("Packing List and Returns (Preliminary Report)")
        Else
            documentTitle.AddText("Packing List and Returns")
        End If
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
        paragraph.AddFormattedText("Issue No: " + txtIssueNo.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Issued on: " + txtCreated.Text.Substring(0, 10))
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Status: " + txtStatus.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("S/M Officer:       " + cmbSalesPersons.Text)
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

        Dim status As String = txtStatus.Text

        Dim skip As Integer = 0

        If status = "PRINTED" Or status = "APPROVED" Or status = "COMPLETED" Or status = "ARCHIVED" Then

            'Before you can add a row, you must define the columns
            Dim column As Column

            column = table.AddColumn("1.5cm")
            column.Format.Alignment = ParagraphAlignment.Left


            column = table.AddColumn("6cm")
            column.Format.Alignment = ParagraphAlignment.Left

            column = table.AddColumn("2.0cm")
            column.Format.Alignment = ParagraphAlignment.Right

            column = table.AddColumn("1.0cm")
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
            row.Format.Font.Size = 9
            row.Format.Alignment = ParagraphAlignment.Center
            row.Format.Font.Bold = True
            row.Borders.Color = Colors.Black
            row.Cells(0).AddParagraph("Code")
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph("Description")
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph("@Price")
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph("Qty Issued")
            row.Cells(3).Format.Alignment = ParagraphAlignment.Left
            row.Cells(4).AddParagraph("Qty Sold")
            row.Cells(4).Format.Alignment = ParagraphAlignment.Left
            row.Cells(5).AddParagraph("Qty Returned")
            row.Cells(5).Format.Alignment = ParagraphAlignment.Left
            row.Cells(6).AddParagraph("Qty Damaged")
            row.Cells(6).Format.Alignment = ParagraphAlignment.Left


            table.SetEdge(0, 0, 7, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

            Dim totalAmount As Double = 0
            Dim totalVat As Double = 0
            Dim totalDiscount As Double = 0

            For i As Integer = 0 To dtgrdItemList.RowCount - 1
                Dim code As String = dtgrdItemList.Item(0, i).Value.ToString
                Dim description As String = dtgrdItemList.Item(1, i).Value.ToString
                '  Dim price As String = LCurrency.displayValue(dtgrdItemList.Item(2, i).Value.ToString)
                Dim price As String = dtgrdItemList.Item(2, i).Value.ToString
                Dim qtyIssued As String = dtgrdItemList.Item(5, i).Value.ToString
                Dim qtysold As String = dtgrdItemList.Item(6, i).Value.ToString
                Dim qtyReturned As String = dtgrdItemList.Item(7, i).Value.ToString
                Dim qtyDamaged As String = dtgrdItemList.Item(8, i).Value.ToString
                ' Dim cPrice As String = LCurrency.displayValue(dtgrdItemList.Item(10, i).Value.ToString)
                Dim cPrice As String = dtgrdItemList.Item(10, i).Value.ToString

                skip = skip + 1

                If status = "PRINTED" And report = False Then
                    qtyReturned = ""
                    qtysold = ""
                    qtyDamaged = ""
                End If

                row = table.AddRow()
                row.Format.Font.Bold = False
                row.HeadingFormat = False
                row.Format.Font.Size = 9
                row.Height = "6mm"
                row.Format.Alignment = ParagraphAlignment.Center
                row.Borders.Color = Colors.Black
                row.Cells(0).AddParagraph(code)
                row.Cells(0).Format.Alignment = ParagraphAlignment.Left
                row.Cells(1).AddParagraph(description)
                row.Cells(1).Format.Alignment = ParagraphAlignment.Left
                row.Cells(2).AddParagraph(price)
                row.Cells(2).Format.Alignment = ParagraphAlignment.Right
                row.Cells(3).AddParagraph(qtyIssued)
                row.Cells(3).Format.Alignment = ParagraphAlignment.Left
                row.Cells(4).AddParagraph(qtysold)
                row.Cells(4).Format.Alignment = ParagraphAlignment.Left
                row.Cells(5).AddParagraph(qtyReturned)
                row.Cells(5).Format.Alignment = ParagraphAlignment.Left
                row.Cells(6).AddParagraph(qtyDamaged)
                row.Cells(6).Format.Alignment = ParagraphAlignment.Left

                table.SetEdge(0, 0, 7, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
            Next
            table.SetEdge(0, 0, 7, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        ElseIf status = "PENDING" Then

            'Before you can add a row, you must define the columns
            Dim column As Column

            column = table.AddColumn("1.5cm")
            column.Format.Alignment = ParagraphAlignment.Left

            column = table.AddColumn("6cm")
            column.Format.Alignment = ParagraphAlignment.Left

            column = table.AddColumn("2.0cm")
            column.Format.Alignment = ParagraphAlignment.Right

            column = table.AddColumn("2.0cm")
            column.Format.Alignment = ParagraphAlignment.Right

            column = table.AddColumn("2cm")
            column.Format.Alignment = ParagraphAlignment.Right

            column = table.AddColumn("2cm")
            column.Format.Alignment = ParagraphAlignment.Right

            'column = table.AddColumn("2cm")
            'column.Format.Alignment = ParagraphAlignment.Right

            'column = table.AddColumn("2cm")
            'column.Format.Alignment = ParagraphAlignment.Right

            'column = table.AddColumn("2cm")
            'column.Format.Alignment = ParagraphAlignment.Right



            'Create the header of the table
            Dim row As Row

            row = table.AddRow()
            row.Format.Font.Bold = True
            row.HeadingFormat = True
            row.Format.Font.Size = 9
            row.Format.Alignment = ParagraphAlignment.Center
            row.Format.Font.Bold = True
            row.Borders.Color = Colors.Black
            row.Cells(0).AddParagraph("Code")
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph("Description")
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph("@Price")
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph("Returns")
            row.Cells(3).Format.Alignment = ParagraphAlignment.Left
            row.Cells(4).AddParagraph("Packed")
            row.Cells(4).Format.Alignment = ParagraphAlignment.Left
            row.Cells(5).AddParagraph("Total Issued")
            row.Cells(5).Format.Alignment = ParagraphAlignment.Left
            'row.Cells(4).AddParagraph("Qty Sold")
            'row.Cells(4).Format.Alignment = ParagraphAlignment.Left
            'row.Cells(5).AddParagraph("Qty Returned")
            'row.Cells(5).Format.Alignment = ParagraphAlignment.Left
            'row.Cells(6).AddParagraph("Qty Damaged")
            'row.Cells(6).Format.Alignment = ParagraphAlignment.Left

            table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

            Dim totalAmount As Double = 0
            Dim totalVat As Double = 0
            Dim totalDiscount As Double = 0

            For i As Integer = 0 To dtgrdItemList.RowCount - 1
                Dim code As String = dtgrdItemList.Item(0, i).Value.ToString
                Dim description As String = dtgrdItemList.Item(1, i).Value.ToString
                ' Dim price As String = LCurrency.displayValue(dtgrdItemList.Item(2, i).Value.ToString)
                Dim price As String = dtgrdItemList.Item(2, i).Value.ToString
                Dim returns As String = dtgrdItemList.Item(3, i).Value.ToString
                Dim packed As String = dtgrdItemList.Item(4, i).Value.ToString
                Dim totalIssued As String = dtgrdItemList.Item(5, i).Value.ToString

                'Dim qtysold As String = dtgrdItemList.Item(4, i).Value.ToString
                'Dim qtyReturned As String = dtgrdItemList.Item(5, i).Value.ToString
                'Dim qtyDamaged As String = dtgrdItemList.Item(6, i).Value.ToString

                If status = "PRINTED" Then
                    'qtyReturned = ""
                    'qtysold = ""
                    'qtyDamaged = ""
                End If

                row = table.AddRow()
                row.Format.Font.Bold = False
                row.HeadingFormat = False
                row.Format.Font.Size = 9
                row.Height = "5mm"
                row.Format.Alignment = ParagraphAlignment.Center
                row.Borders.Color = Colors.Black
                row.Cells(0).AddParagraph(code)
                row.Cells(0).Format.Alignment = ParagraphAlignment.Left
                row.Cells(1).AddParagraph(description)
                row.Cells(1).Format.Alignment = ParagraphAlignment.Left
                row.Cells(2).AddParagraph(price)
                row.Cells(2).Format.Alignment = ParagraphAlignment.Right
                row.Cells(3).AddParagraph(returns)
                row.Cells(3).Format.Alignment = ParagraphAlignment.Left
                row.Cells(4).AddParagraph(packed)
                row.Cells(4).Format.Alignment = ParagraphAlignment.Left
                row.Cells(5).AddParagraph(totalIssued)
                row.Cells(5).Format.Alignment = ParagraphAlignment.Left
                'row.Cells(4).AddParagraph(qtysold)
                'row.Cells(4).Format.Alignment = ParagraphAlignment.Left
                'row.Cells(5).AddParagraph(qtyReturned)
                'row.Cells(5).Format.Alignment = ParagraphAlignment.Left
                'row.Cells(6).AddParagraph(qtyDamaged)
                'row.Cells(6).Format.Alignment = ParagraphAlignment.Left

                table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
            Next
            table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        End If

        paragraph = section.AddParagraph()

        If Not status = "PENDING" Then
            If (skip Mod 20) < 13 And skip >= 18 Then
                section.AddPageBreak()
            End If
        End If

        'Create the item table
        Dim table3 As Table = section.AddTable()
        table3.Style = "Table"
        ' table.Borders.Color = TableBorder
        table3.Borders.Width = 0.25
        table3.Borders.Left.Width = 0.5
        table3.Borders.Right.Width = 0.5
        table3.Rows.LeftIndent = 0

        'Before you can add a row, you must define the columns
        Dim column3 As Column

        column3 = table3.AddColumn("4cm")
        column3.Format.Alignment = ParagraphAlignment.Left


        column3 = table3.AddColumn("4cm")
        column3.Format.Alignment = ParagraphAlignment.Left

        If status = "PENDING" Then

            paragraph = section.AddParagraph()
            paragraph.AddFormattedText("Returns:" + LCurrency.displayValue(txtTotalPreviousReturns.Text))
            paragraph.Format.Font.Size = 8
            paragraph = section.AddParagraph()
            paragraph.AddFormattedText("Packed:" + LCurrency.displayValue(txtTotalAmountPacked.Text))
            paragraph.Format.Font.Size = 8
            paragraph = section.AddParagraph()
            paragraph.AddFormattedText("Total Issued:" + LCurrency.displayValue(txtTotalAmountIssued.Text))
            paragraph.Format.Font.Size = 8

        End If
        'Create the header of the table
        Dim row3 As Row
        If Not status = "PENDING" Then

            row3 = table3.AddRow()
            row3.Format.Font.Bold = True
            row3.HeadingFormat = True
            row3.Format.Font.Size = 9
            row3.Height = "6mm"
            row3.Format.Alignment = ParagraphAlignment.Center
            row3.Borders.Color = Colors.Gray
            row3.Cells(0).AddParagraph("Issue No")
            row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row3.Cells(1).AddParagraph(txtIssueNo.Text)
            row3.Cells(1).Format.Alignment = ParagraphAlignment.Left

            table3.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

            row3 = table3.AddRow()
            row3.Format.Font.Bold = False
            row3.HeadingFormat = True
            row3.Format.Font.Size = 9
            row3.Height = "6mm"
            row3.Format.Alignment = ParagraphAlignment.Center
            row3.Borders.Color = Colors.Gray
            row3.Cells(0).AddParagraph("Total Issued")
            row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row3.Cells(1).AddParagraph(LCurrency.displayValue(txtTotalAmountIssued.Text))
            row3.Cells(1).Format.Alignment = ParagraphAlignment.Right

            table3.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

            row3 = table3.AddRow()
            row3.Format.Font.Bold = False
            row3.HeadingFormat = True
            row3.Format.Font.Size = 9
            row3.Format.Alignment = ParagraphAlignment.Center
            row3.Borders.Color = Colors.Gray
            row3.Cells(0).AddParagraph("Total Sales")
            row3.Height = "6mm"
            row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
            If Not status = "PRINTED" Or report = True Then
                row3.Cells(1).AddParagraph(LCurrency.displayValue(txtTotalSales.Text))
            Else
                row3.Cells(1).AddParagraph("")
            End If

            row3.Cells(1).Format.Alignment = ParagraphAlignment.Right

            table3.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

            row3 = table3.AddRow()
            row3.Format.Font.Bold = False
            row3.HeadingFormat = True
            row3.Format.Font.Size = 9
            row3.Format.Alignment = ParagraphAlignment.Center
            row3.Borders.Color = Colors.Gray
            row3.Cells(0).AddParagraph("Total Returns")
            row3.Height = "6mm"
            row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
            If Not status = "PRINTED" Or report = True Then
                row3.Cells(1).AddParagraph(LCurrency.displayValue(txtTotalReturns.Text))
            Else
                row3.Cells(1).AddParagraph("")
            End If

            row3.Cells(1).Format.Alignment = ParagraphAlignment.Right

            table3.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

            row3 = table3.AddRow()
            row3.Format.Font.Bold = False
            row3.HeadingFormat = True
            row3.Format.Font.Size = 9
            row3.Format.Alignment = ParagraphAlignment.Center
            row3.Borders.Color = Colors.Gray
            row3.Cells(0).AddParagraph("Total Damages")
            row3.Height = "6mm"
            row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
            If Not status = "PRINTED" Or report = True Then
                row3.Cells(1).AddParagraph(LCurrency.displayValue(txtTotalDamages.Text))
            Else
                row3.Cells(1).AddParagraph("")
            End If

            row3.Cells(1).Format.Alignment = ParagraphAlignment.Right

            table3.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

            row3 = table3.AddRow()
            row3.Format.Font.Bold = False
            row3.HeadingFormat = True
            row3.Format.Font.Size = 9
            row3.Format.Alignment = ParagraphAlignment.Center
            row3.Borders.Color = Colors.Gray
            row3.Cells(0).AddParagraph("Total Discounts")
            row3.Height = "6mm"
            row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
            If Not status = "PRINTED" Or report = True Then
                row3.Cells(1).AddParagraph(LCurrency.displayValue(txtTotalDiscounts.Text))
            Else
                row3.Cells(1).AddParagraph("")
            End If

            row3.Cells(1).Format.Alignment = ParagraphAlignment.Right

            table3.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

            row3 = table3.AddRow()
            row3.Format.Font.Bold = False
            row3.HeadingFormat = True
            row3.Format.Font.Size = 9
            row3.Format.Alignment = ParagraphAlignment.Center
            row3.Borders.Color = Colors.Gray
            row3.Cells(0).AddParagraph("Total Expenditures")
            row3.Height = "6mm"
            row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
            If Not status = "PRINTED" Or report = True Then
                row3.Cells(1).AddParagraph(LCurrency.displayValue(txtTotalExpenses.Text))
            Else
                row3.Cells(1).AddParagraph("")
            End If

            row3.Cells(1).Format.Alignment = ParagraphAlignment.Right

            table3.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

            row3 = table3.AddRow()
            row3.Format.Font.Bold = False
            row3.HeadingFormat = True
            row3.Format.Font.Size = 9
            row3.Format.Alignment = ParagraphAlignment.Center
            row3.Borders.Color = Colors.Gray
            row3.Cells(0).AddParagraph("Cash & Bank Deposit")
            row3.Height = "6mm"
            row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
            If Not status = "PRINTED" Or report = True Then
                row3.Cells(1).AddParagraph(LCurrency.displayValue(txtTotalBankDeposit.Text))
            Else
                row3.Cells(1).AddParagraph("")
            End If

            row3.Cells(1).Format.Alignment = ParagraphAlignment.Right

            table3.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

            row3 = table3.AddRow()
            row3.Format.Font.Bold = False
            row3.HeadingFormat = True
            row3.Format.Font.Size = 9
            row3.Format.Alignment = ParagraphAlignment.Center
            row3.Borders.Color = Colors.Gray
            row3.Cells(0).AddParagraph("Total Deficit / Debt")
            row3.Height = "6mm"
            row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
            If Not status = "PRINTED" Or report = True Then
                row3.Cells(1).AddParagraph(LCurrency.displayValue(txtDebt.Text))
            Else
                row3.Cells(1).AddParagraph("")
            End If

            row3.Cells(1).Format.Alignment = ParagraphAlignment.Right

            table3.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        End If

        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()

        paragraph = section.AddParagraph()
        paragraph.AddText("Issued by:________________Verified by:________________Approved by:________________")
        paragraph.Format.Font.Size = 8

    End Sub

    Private Function clear()
        txtIssueNo.Text = ""

        Return vbNull
    End Function


    Private Function searchPackingList(issueNo As String) As Boolean
        Dim found As Boolean = False
        Dim packingList As New PackingList
        Dim packingListDetails As New List(Of PackingListDetail)

        Dim response As Object = New Object
        Dim json As JObject = New JObject

        Try
            response = Web.get_("packing_lists/get_by_no?no=" + issueNo)
            packingList = JsonConvert.DeserializeObject(Of PackingList)(response.ToString)

            If Not IsNothing(packingList.createdDay) Then
                txtCreated.Text = packingList.createdDay.bussinessDate.ToString("yyyy-MM-dd") + " " + packingList.createdByUser.lastName + ", " + packingList.createdByUser.firstName
            Else
                txtCreated.Text = ""
            End If
            If Not IsNothing(packingList.approvedDay) Then
                txtApproved.Text = packingList.approvedDay.bussinessDate.ToString("yyyy-MM-dd") + " " + packingList.approvedByUser.lastName + ", " + packingList.approvedByUser.firstName
            Else
                txtApproved.Text = ""
            End If
            If Not IsNothing(packingList.printedDay) Then
                txtPrinted.Text = packingList.printedDay.bussinessDate.ToString("yyyy-MM-dd") + " " + packingList.printedByUser.lastName + ", " + packingList.printedByUser.firstName
            Else
                txtPrinted.Text = ""
            End If
            If Not IsNothing(packingList.issuedDay) Then
                txtIssued.Text = packingList.issuedDay.bussinessDate.ToString("yyyy-MM-dd") + " " + packingList.issuedByUser.lastName + ", " + packingList.issuedByUser.firstName
            Else
                txtIssued.Text = ""
            End If
            If Not IsNothing(packingList.completedDay) Then
                txtCompleted.Text = packingList.completedDay.bussinessDate.ToString("yyyy-MM-dd") + " " + packingList.completedByUser.lastName + ", " + packingList.completedByUser.firstName
            Else
                txtCompleted.Text = ""
            End If

            txtId.Text = packingList.id
            txtStatus.Text = packingList.status

            cmbSalesPersons.Text = packingList.salesPerson.personnel.name
            txtTotalAmountIssued.Text = LCurrency.displayValue(0)
            txtTotalReturns.Text = LCurrency.displayValue(0)
            txtTotalDamages.Text = LCurrency.displayValue(0)
            txtTotalDiscounts.Text = LCurrency.displayValue(0)
            txtTotalExpenses.Text = LCurrency.displayValue(0)
            txtTotalBankDeposit.Text = LCurrency.displayValue(0)
            txtDebt.Text = LCurrency.displayValue(0)
            txtCostOfGoodsSold.Text = LCurrency.displayValue(0)

            If txtId.Text = "" Then
                btnSave.Enabled = False
            Else
                btnSave.Enabled = True
            End If

            Dim status As String = packingList.status

            If status = "APPROVED" Or status = "PRINTED" Or status = "REPRINTED" Or status = "COMPLETED" Or status = "CANCELED" Then
                btnApprove.Enabled = False
            ElseIf status = "PENDING" Then
                btnApprove.Enabled = True
            Else
                btnApprove.Enabled = False
            End If

            If status = "PENDING" Then
                txtIssueNo.ReadOnly = True
                cmbSalesPersons.Enabled = True

                txtBarCode.ReadOnly = False
                txtCode.ReadOnly = False
                cmbDescription.Enabled = True
                txtReturns.ReadOnly = False
                txtIssuedQty.ReadOnly = False
                txtQtyReturned.ReadOnly = True
                txtQtySold.ReadOnly = True
                txtQtyDamaged.ReadOnly = True


                txtTotalDiscounts.ReadOnly = True
                txtTotalExpenses.ReadOnly = True
                txtTotalBankDeposit.ReadOnly = True
                txtDebt.ReadOnly = True
            End If

            If status = "APPROVED" Then
                txtIssueNo.ReadOnly = True
                cmbSalesPersons.Enabled = False

                txtBarCode.ReadOnly = True
                txtCode.ReadOnly = True
                cmbDescription.Enabled = False
                txtReturns.ReadOnly = True
                txtIssuedQty.ReadOnly = True
                txtQtyReturned.ReadOnly = True
                txtQtySold.ReadOnly = True
                txtQtyDamaged.ReadOnly = True


                txtTotalDiscounts.ReadOnly = True
                txtTotalExpenses.ReadOnly = True
                txtTotalBankDeposit.ReadOnly = True
                txtDebt.ReadOnly = True
            End If
            If status = "PRINTED" Then
                txtIssueNo.ReadOnly = True
                cmbSalesPersons.Enabled = False

                txtBarCode.ReadOnly = True
                txtCode.ReadOnly = True
                cmbDescription.Enabled = False
                txtReturns.ReadOnly = True
                txtIssuedQty.ReadOnly = True
                txtQtyReturned.ReadOnly = False
                txtQtySold.ReadOnly = False
                txtQtyDamaged.ReadOnly = False


                txtTotalDiscounts.ReadOnly = False
                txtTotalExpenses.ReadOnly = False
                txtTotalBankDeposit.ReadOnly = False
                txtDebt.ReadOnly = False
            End If
            If status = "COMPLETED" Then
                txtIssueNo.ReadOnly = True
                cmbSalesPersons.Enabled = False

                txtBarCode.ReadOnly = True
                txtCode.ReadOnly = True
                cmbDescription.Enabled = False
                txtReturns.ReadOnly = True
                txtIssuedQty.ReadOnly = True
                txtQtyReturned.ReadOnly = True
                txtQtySold.ReadOnly = True
                txtQtyDamaged.ReadOnly = True


                txtTotalDiscounts.ReadOnly = True
                txtTotalExpenses.ReadOnly = True
                txtTotalBankDeposit.ReadOnly = True
                txtDebt.ReadOnly = True
            End If
            If status = "CANCELED" Then
                txtIssueNo.ReadOnly = True
                cmbSalesPersons.Enabled = False

                txtBarCode.ReadOnly = True
                txtCode.ReadOnly = True
                cmbDescription.Enabled = False
                txtReturns.ReadOnly = True
                txtIssuedQty.ReadOnly = True
                txtQtyReturned.ReadOnly = True
                txtQtySold.ReadOnly = True
                txtQtyDamaged.ReadOnly = True


                txtTotalDiscounts.ReadOnly = True
                txtTotalExpenses.ReadOnly = True
                txtTotalBankDeposit.ReadOnly = True
                txtDebt.ReadOnly = True
            End If
            If status = "ARCHIVED" Then
                txtIssueNo.ReadOnly = True
                cmbSalesPersons.Enabled = False

                txtBarCode.ReadOnly = True
                txtCode.ReadOnly = True
                cmbDescription.Enabled = False
                txtReturns.ReadOnly = True
                txtIssuedQty.ReadOnly = True
                txtQtyReturned.ReadOnly = True
                txtQtySold.ReadOnly = True
                txtQtyDamaged.ReadOnly = True

                txtTotalDiscounts.ReadOnly = True
                txtTotalExpenses.ReadOnly = True
                txtTotalBankDeposit.ReadOnly = True
                txtDebt.ReadOnly = True
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return vbNull
            Exit Function
        End Try
        Try
            response = Web.get_("packing_list_details/get_by_packing_list_no?no=" + issueNo)
            packingListDetails = JsonConvert.DeserializeObject(Of List(Of PackingListDetail))(response.ToString)
            refreshList(packingListDetails)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return found
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        searchPackingList(txtIssueNo.Text)
    End Sub
    Private Sub clearItemFields()
        txtBarCode.Text = ""
        txtCode.Text = ""
        cmbDescription.Text = ""
        txtPrice.Text = ""
        txtReturns.Text = ""
        txtIssuedQty.Text = ""
        txtPacked.Text = ""
        txtQtyReturned.Text = ""
        txtQtyDamaged.Text = ""
        txtQtySold.Text = ""
        txtCPrice.Text = ""
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        oldPrice = 0

        txtId.Text = ""
        txtIssueNo.Text = ""
        txtCreated.Text = ""
        cmbSalesPersons.SelectedItem = Nothing
        txtStatus.Text = "PENDING"

        txtBarCode.Text = ""
        txtCode.Text = ""
        cmbDescription.Text = ""
        txtPrice.Text = ""
        txtReturns.Text = ""
        txtIssuedQty.Text = ""
        txtPacked.Text = ""
        txtQtyReturned.Text = ""
        txtQtyDamaged.Text = ""
        txtQtySold.Text = ""
        txtCPrice.Text = ""

        txtTotalPreviousReturns.Text = ""
        txtTotalAmountPacked.Text = ""
        txtTotalAmountIssued.Text = ""
        txtTotalSales.Text = ""
        txtTotalReturns.Text = ""
        txtTotalDiscounts.Text = ""
        txtTotalExpenses.Text = ""
        txtTotalDamages.Text = ""
        txtTotalBankDeposit.Text = ""
        txtDebt.Text = ""
        txtCostOfGoodsSold.Text = ""



        txtIssueNo.ReadOnly = True
        cmbSalesPersons.Enabled = True


        txtBarCode.ReadOnly = False
        txtCode.ReadOnly = False
        cmbDescription.Enabled = True
        txtReturns.ReadOnly = False
        txtIssuedQty.ReadOnly = False
        txtQtyReturned.ReadOnly = True
        txtQtySold.ReadOnly = True
        txtQtyDamaged.ReadOnly = True

        txtTotalDiscounts.ReadOnly = True
        txtTotalExpenses.ReadOnly = True
        txtTotalBankDeposit.ReadOnly = True
        txtDebt.ReadOnly = True


        txtCreated.Text = Day.DAY
        btnSave.Enabled = False
        btnApprove.Enabled = False
        'clear()
        txtIssueNo.Text = "NA"
        If txtIssueNo.Text = "" Then
            txtIssueNo.Text = "0"
        End If
        dtgrdItemList.Rows.Clear()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        oldPrice = 0

        ' If User.authorize("EDIT PACKING LIST") = True Then


        '  Else
        'MsgBox("Action denied for current user.", vbOKOnly + vbExclamation, "Action denied")
        'Exit Sub
        ' End If

        If txtId.Text = "" Then
            btnSave.Enabled = False
            txtIssueNo.ReadOnly = False
            txtIssueNo.Text = ""
            txtCreated.Text = ""
            cmbSalesPersons.SelectedItem = Nothing
            txtStatus.Text = ""
        Else
            btnSave.Enabled = True
            txtIssueNo.ReadOnly = True
        End If

    End Sub

    Private Function refreshList(details As List(Of PackingListDetail))
        Cursor = Cursors.WaitCursor
        dtgrdItemList.Rows.Clear()

        Dim totalPreviousReturns As Double = 0
        Dim amountIssued As Double = 0
        Dim totalPacked As Double = 0
        Dim totalSales As Double = 0
        Dim totalreturned As Double = 0
        Dim totalsold As Double = 0
        Dim totalDamaged As Double = 0
        Dim totalCost As Double = 0

        For Each detail In details

            totalPreviousReturns = totalPreviousReturns + (detail.previousReturns * detail.sellingPriceVatIncl)
            amountIssued = amountIssued + (detail.issued * detail.sellingPriceVatIncl)
            totalPacked = totalPacked + (detail.totalPacked * detail.sellingPriceVatIncl)
            totalSales = totalSales + (detail.sold * detail.sellingPriceVatIncl)
            totalreturned = totalreturned + (detail.returned * detail.sellingPriceVatIncl)
            totalsold = totalsold + (detail.sold * detail.sellingPriceVatIncl)
            totalDamaged = totalDamaged + (detail.damaged * detail.sellingPriceVatIncl)
            totalCost = totalCost + (detail.sold * detail.costPriceVatIncl)


            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.code
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.description
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(detail.sellingPriceVatIncl.ToString)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.previousReturns
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.issued
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.totalPacked
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.sold
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.returned
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.damaged
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = detail.id
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(detail.costPriceVatIncl.ToString)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdItemList.Rows.Add(dtgrdRow)

        Next

        txtTotalPreviousReturns.Text = LCurrency.displayValue(totalPreviousReturns.ToString)
        txtTotalAmountPacked.Text = LCurrency.displayValue(totalPacked.ToString)
        txtTotalAmountIssued.Text = LCurrency.displayValue(amountIssued.ToString)
        txtTotalSales.Text = LCurrency.displayValue(totalSales.ToString)
        txtTotalReturns.Text = LCurrency.displayValue(totalreturned.ToString)
        txtTotalDamages.Text = LCurrency.displayValue(totalDamaged.ToString)
        txtCostOfGoodsSold.Text = LCurrency.displayValue(totalCost.ToString)

        Try
            dtgrdItemList.CurrentCell = dtgrdItemList.Rows(currentRow).Cells(0)
            dtgrdItemList.Rows(currentRow).Selected = True
        Catch ex As Exception

        End Try

        Cursor = Cursors.Arrow
        Return vbNull
    End Function

    Private Sub dtgrdItemList_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdItemList.RowHeaderMouseClick
        txtPrice.ReadOnly = True
        Dim status As String
        Try
            status = Web.get_("packing_lists/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try

        If status = "APPROVED" Then
            MsgBox("Could not edit, document already approved", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("Could not edit, document already completed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "ARCHIVED" Then
            MsgBox("Could not edit, document already completed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("Could not edit, document has been canceled", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "" Then
            MsgBox("Could not edit, status unknown", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        Dim row As Integer = -1
        row = dtgrdItemList.CurrentRow.Index
        currentRow = row 'sets a row index ti be used in autoscroll

        'If dtgrdItemList.SelectedRows.Count = 1 Then
        'oldRow = row
        ' Else
        'oldRow = -1
        'End If

        'Dim barCode As String = dtgrdItemList.Item(0, row).Value
        Dim itemCode As String = dtgrdItemList.Item(0, row).Value
        Dim description As String = dtgrdItemList.Item(1, row).Value
        Dim price As String = dtgrdItemList.Item(2, row).Value
        Dim returns As String = dtgrdItemList.Item(3, row).Value
        Dim packed As String = dtgrdItemList.Item(4, row).Value
        Dim qtyIssued As String = dtgrdItemList.Item(5, row).Value
        Dim qtySold As String = dtgrdItemList.Item(6, row).Value
        Dim qtyReturned As String = dtgrdItemList.Item(7, row).Value
        Dim qtyDamaged As String = dtgrdItemList.Item(8, row).Value
        Dim sn As String = dtgrdItemList.Item(9, row).Value
        Dim cPrice As String = dtgrdItemList.Item(10, row).Value

        Dim dtgrdRow As New DataGridViewRow

        txtCode.Text = itemCode
        cmbDescription.Text = description
        txtPrice.Text = price
        txtReturns.Text = returns
        txtIssuedQty.Text = packed
        txtPacked.Text = qtyIssued
        txtQtyReturned.Text = qtyReturned
        txtQtySold.Text = qtySold
        txtQtyDamaged.Text = qtyDamaged
        txtCPrice.Text = cPrice

        If txtStatus.Text = "PENDING" Then
            'lock
            txtBarCode.ReadOnly = True
            txtCode.ReadOnly = True
            cmbDescription.Enabled = False

            txtQtyReturned.ReadOnly = True
            txtQtySold.ReadOnly = True
            txtQtyDamaged.ReadOnly = True
            'unlock
            txtReturns.ReadOnly = False
            txtIssuedQty.ReadOnly = False

            btnAdd.Enabled = True
        End If
        If txtStatus.Text = "APPROVED" Then
            'lock
            txtBarCode.ReadOnly = True
            txtCode.ReadOnly = True
            cmbDescription.Enabled = False
            txtReturns.ReadOnly = True
            txtIssuedQty.ReadOnly = True
            txtQtySold.ReadOnly = True
            txtQtyDamaged.ReadOnly = True

            txtPacked.ReadOnly = True

            btnAdd.Enabled = False
        End If
        If txtStatus.Text = "PRINTED" Then
            'lock
            txtBarCode.ReadOnly = True
            txtCode.ReadOnly = True
            cmbDescription.Enabled = False
            txtReturns.ReadOnly = True
            txtIssuedQty.ReadOnly = True

            'unlock
            txtQtyReturned.ReadOnly = False
            txtQtySold.ReadOnly = False
            txtQtyDamaged.ReadOnly = False

            btnAdd.Enabled = True
        End If
        If txtStatus.Text = "COMPLETED" Then
            'lock
            txtBarCode.ReadOnly = True
            txtCode.ReadOnly = True
            cmbDescription.Enabled = False
            txtReturns.ReadOnly = True
            txtIssuedQty.ReadOnly = True
            txtQtyReturned.ReadOnly = True
            txtQtySold.ReadOnly = True
            txtQtyDamaged.ReadOnly = True

            btnAdd.Enabled = False
            'unlock

        End If

    End Sub

    Dim oldRow As Integer = -1
    Dim glsn As String = ""

    Private Sub dtgrdItemList_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdItemList.RowHeaderMouseDoubleClick
        txtPrice.ReadOnly = True
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Dim status As String = ""

        Try
            status = Web.get_("packing_lists/get_status_by_no?no=" + txtIssueNo.Text)
        Catch ex As Exception
            status = ""
        End Try

        If status = "PENDING" Then
            'continue delete
            Dim res As Integer = MsgBox("Remove item from list?", vbYesNo + vbQuestion, "Remove item")
            If Not res = DialogResult.Yes Then
                Exit Sub
            End If
        Else
            MsgBox("Can not delete item, not a pending packing list", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If

        Dim row As Integer = -1
        row = dtgrdItemList.CurrentRow.Index

        Dim sn As String = dtgrdItemList.Item(9, row).Value

        MsgBox(sn)

        Try
            response = Web.delete("packing_list_details/delete_by_id?id=" + sn)
            lockFields()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        lockFields()
        Try
            Dim packingListDetails As List(Of PackingListDetail)
            response = Web.get_("packing_list_details/get_by_packing_list_id?id=" + txtId.Text)
            packingListDetails = JsonConvert.DeserializeObject(Of List(Of PackingListDetail))(response)
            refreshList(packingListDetails)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        clearItemdetails()
    End Sub
    Private Sub loadSalesPersons()
        cmbSalesPersons.Items.Clear()
        Dim salesPersons As New List(Of SalesPerson)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("sales_persons")
            salesPersons = JsonConvert.DeserializeObject(Of List(Of SalesPerson))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try
        For Each salesPerson In salesPersons
            Try
                cmbSalesPersons.Items.Add(salesPerson.personnel.name)
            Catch ex As Exception

            End Try
        Next
    End Sub

    Private Sub frmPackingList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.AppStarting
        resetAll()
        loadSalesPersons()
        refreshPackingLists()

        Dim product As New Product
        longList = product.getDescriptions
        Cursor = Cursors.Default
    End Sub

    Private Sub frmPurchaseOrder_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtIssueNo.Text = ""
        dtgrdItemList.Rows.Clear()

    End Sub

    Private Sub txtOrderNo_preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtIssueNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            searchPackingList(txtIssueNo.Text)
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

    Private Sub btnSearchItem_Click(sender As Object, e As EventArgs) Handles btnSearchItem.Click

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
            txtPrice.Text = LCurrency.displayValue(product.sellingPriceVatIncl.ToString)
            txtCPrice.Text = LCurrency.displayValue(product.costPriceVatIncl.ToString)
            txtStockSize.Text = product.stock
            found = True
            If found = False Then
                MsgBox("Product not found", vbOKOnly + vbCritical, "Item not found")
                clearFields()
                btnAdd.Enabled = False
            Else
                btnAdd.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub clearFields()
        txtDetailId.Text = ""
        txtBarCode.Text = ""
        txtCode.Text = ""
        cmbDescription.Text = ""
        txtPackSize.Text = ""

        txtPrice.Text = ""
        txtStockSize.Text = ""
        txtReturns.Text = ""
        txtIssuedQty.Text = ""
        txtPacked.Text = ""
        txtQtyReturned.Text = ""
        txtQtySold.Text = ""
        txtQtyDamaged.Text = ""
        txtCPrice.Text = ""
        btnAdd.Enabled = False
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
        Cursor = Cursors.WaitCursor
        If currentRow = -1 Then
            currentRow = dtgrdItemList.RowCount
        End If
        txtPrice.ReadOnly = True
        If txtIssueNo.Text = "" Then
            MsgBox("Select new")
            clearFields()
            Cursor = Cursors.Default
            Exit Sub
        End If
        Dim status As String
        Try
            status = Web.get_("packing_lists/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If status = "APPROVED" Then
            MsgBox("Could not edit, document already approved", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearFields()
            Cursor = Cursors.Default
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("Could not edit, document already completed", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearFields()
            Cursor = Cursors.Default
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("Could not edit, document has been canceled", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearFields()
            Cursor = Cursors.Default
            Exit Sub
        End If
        If status = "ARCHIVED" Then
            MsgBox("Could not edit, document already completed", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearFields()
            Cursor = Cursors.Default
            Exit Sub
        End If
        If status = "" Then
            MsgBox("Could not edit, document status unknown", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearFields()
            Cursor = Cursors.Default
            Exit Sub
        End If
        If cmbSalesPersons.Text = "" Then
            MsgBox("Could not add item, sales person required", vbOKOnly + vbCritical, "Error: Missing Information")
            Cursor = Cursors.Default
            Exit Sub
        End If
        Dim barCode As String = txtBarCode.Text
        Dim code As String = txtCode.Text
        Dim description As String = cmbDescription.Text

        Dim returns As String = txtReturns.Text
        Dim qtyIssued As String = txtIssuedQty.Text
        Dim packed As String = txtPacked.Text
        Dim qtyReturned As String = txtQtyReturned.Text
        Dim qtySold As String = txtQtySold.Text
        Dim qtyDamaged As String = txtQtyDamaged.Text
        Dim sellingPriceVatIncl As String = LCurrency.getValue(txtPrice.Text)
        Dim costPriceVatIncl As String = LCurrency.getValue(txtCPrice.Text)
        Dim stockSize As String = txtStockSize.Text
        If code = "" Then
            MsgBox("Product required", vbOKOnly + vbCritical, "Error: Missing information")
            Cursor = Cursors.Default
            Exit Sub
        End If
        If Val(packed) <= 0 Then
            MsgBox("Could not add product. Invalid issue qty, qty should be non-negative", vbOKOnly + vbCritical, "Error: Invalid entry")
            Cursor = Cursors.Default
            Exit Sub
        End If
        If ((Val(packed) - (Val(qtyReturned) + Val(qtySold) + Val(qtyDamaged)) <> 0) And status = "PRINTED") Then
            MsgBox("Could not update, quantity values do not tally", vbOKOnly + vbCritical, "Error: Invalid entry")
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim _new As Boolean = False
        Dim packingList As PackingList

        Dim response As Object = New Object
        Dim json As JObject = New JObject

        packingList = New PackingList
        If txtId.Text = "" Then
            Try
                packingList.no = "NA"
                packingList.salesPerson.personnel.name = cmbSalesPersons.Text
                response = Web.post(packingList, "packing_lists/new")
                packingList = JsonConvert.DeserializeObject(Of PackingList)(response.ToString)
                txtId.Text = packingList.id
                cmbSalesPersons.Text = packingList.salesPerson.personnel.name
                txtCreated.Text = packingList.createdDay.bussinessDate + " " + packingList.createdByUser.lastName + ", " + packingList.createdByUser.firstName
                txtApproved.Text = ""
                txtPrinted.Text = ""
                txtIssued.Text = ""
                txtCompleted.Text = ""
                txtStatus.Text = packingList.status
                txtTotalPreviousReturns.Text = packingList.returns
                txtTotalAmountPacked.Text = packingList.packed
                txtTotalAmountIssued.Text = packingList.issued
                txtTotalSales.Text = packingList.sales
                txtTotalReturns.Text = packingList.returns
                txtTotalDamages.Text = packingList.damages
                txtTotalDiscounts.Text = packingList.discount
                txtTotalExpenses.Text = packingList.expenses
                txtCostOfGoodsSold.Text = packingList.costOfGoodsSold
                txtTotalBankDeposit.Text = packingList.bankDeposit
                txtCash.Text = packingList.cash
                txtDebt.Text = packingList.deficit
            Catch ex As Exception
                MsgBox(ex.ToString)
                Exit Sub
            End Try
        Else
            packingList.id = txtId.Text
        End If

        If txtId.Text = "" Then
            MsgBox("Could not add, please restart application")
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim packingListDetail As New PackingListDetail
        packingListDetail.packingList = packingList
        packingListDetail.barcode = barCode
        packingListDetail.code = code
        packingListDetail.description = description
        packingListDetail.sellingPriceVatIncl = LCurrency.getValue(sellingPriceVatIncl)
        packingListDetail.costPriceVatIncl = LCurrency.getValue(costPriceVatIncl)
        packingListDetail.previousReturns = Math.Round((Val(returns)), 2, MidpointRounding.AwayFromZero)
        packingListDetail.issued = Math.Round((Val(qtyIssued)), 2, MidpointRounding.AwayFromZero)
        packingListDetail.totalPacked = Math.Round((Val(packed)), 2, MidpointRounding.AwayFromZero)
        packingListDetail.sold = Math.Round((Val(qtySold)), 2, MidpointRounding.AwayFromZero)
        packingListDetail.returned = Math.Round((Val(qtyReturned)), 2, MidpointRounding.AwayFromZero)
        packingListDetail.damaged = Math.Round((Val(qtyDamaged)), 2, MidpointRounding.AwayFromZero)

        Try
            response = Web.post(packingListDetail, "packing_list_details/new_or_edit")
            Dim packingListDetails As List(Of PackingListDetail) = New List(Of PackingListDetail)
            packingListDetails = JsonConvert.DeserializeObject(Of List(Of PackingListDetail))(response.ToString)
            refreshList(packingListDetails)
            If dtgrdItemList.RowCount <= 1 Then
                refreshPackingLists()
                '      search(txtId.Text, "")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        btnApprove.Enabled = True
        If _new = True Then
            refreshPackingLists()
        End If
        '      refreshList()
        clearFields()
        unLockFields()
        currentRow = -1
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim status As String
        Try
            status = Web.get_("packing_lists/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If Not (status = "PENDING" Or status = "APPROVED") Then
            MsgBox("You can not cancel this document. Only pending or approved documents can be canceled.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If

        If txtIssueNo.Text = "" Then
            MsgBox("Please select document to cancel", vbOKOnly + vbInformation, "Error: No selection")
            Exit Sub
        End If

        Dim res As Integer = MsgBox("Are you sure you want to cancel document : " + txtIssueNo.Text + " ? Once canceled, the document will be rendered invalid", vbYesNo + vbQuestion, "Cancel document?")
        If res = DialogResult.Yes Then

            Dim canceled As Boolean = False
            Try
                canceled = Web.put(vbNull, "packing_lists/cancel_by_id?id=" + txtId.Text)
            Catch ex As Exception
                canceled = False
            End Try
            If canceled = True Then
                MsgBox("Document Successively canceled", vbOKOnly + vbInformation, "Operation successiful")
            Else
                MsgBox("Could not cancel document", vbOKOnly + vbExclamation, "Operation failed")
            End If
            searchPackingList(txtIssueNo.Text)
        End If
        refreshPackingLists()
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim status As String
        Try
            status = Web.get_("packing_lists/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If Not status = "PENDING" Then
            MsgBox("You can not approve this document. Only pending documents can be approved.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If

        If txtIssueNo.Text = "" Then
            MsgBox("Please select document to approve", vbOKOnly + vbInformation, "Error: No selection")
            Exit Sub
        End If

        If dtgrdItemList.RowCount = 0 Then
            MsgBox("You can not approve an empty document", vbOKOnly + vbInformation, "Error: Empty document")
            Exit Sub
        End If

        Dim res As Integer = MsgBox("Are you sure you want to approve document : " + txtIssueNo.Text + " ? Once approved, the document can not be edited", vbYesNo + vbQuestion, "Approve document?")
        If res = DialogResult.Yes Then

            Dim approved As Boolean = False
            Try
                approved = Web.put(vbNull, "packing_lists/approve_by_id?id=" + txtId.Text)
            Catch ex As Exception
                approved = False
            End Try
            If approved = True Then
                MsgBox("Document Successively approved", vbOKOnly + vbInformation, "Operation successiful")
            Else
                MsgBox("Could not approve document", vbOKOnly + vbExclamation, "Operation failed")
            End If
            searchPackingList(txtIssueNo.Text)
        End If
        refreshPackingLists()
    End Sub

    Private Sub clearItemdetails()
        txtBarCode.Text = ""
        txtCode.Text = ""
        cmbDescription.Text = ""
        txtPrice.Text = ""
        txtReturns.Text = ""
        txtIssuedQty.Text = ""
        txtPacked.Text = ""
        txtQtyReturned.Text = ""
        txtQtyDamaged.Text = ""
        txtQtySold.Text = ""
        txtCPrice.Text = ""
        cmbDescription.Enabled = True
        unLockFields()
    End Sub



    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtPrice.ReadOnly = True
        clearItemdetails()
        currentRow = -1
    End Sub

    Private Function validateInputs() As Boolean
        Dim valid As Boolean = True
        If txtIssueNo.Text = "" Then
            valid = False
            MsgBox("Operation failed, issue no required", vbOKOnly + vbCritical, "Error: Missing information")
            Return valid
            Exit Function
        End If
        If cmbSalesPersons.Text = "" Then
            valid = False
            MsgBox("Operation failed, Sales person required", vbOKOnly + vbCritical, "Error: Missing information")
            Return valid
            Exit Function
        End If
        Return valid
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If txtIssueNo.Text = "" Then
            MsgBox("Please select document")
            Exit Sub
        End If

        Dim status As String
        Try
            status = Web.get_("packing_lists/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try

        If Not (status = "PENDING" Or status = "APPROVED" Or status = "PRINTED") Then
            MsgBox("Can not modify. Only Pending, Approved or Printed documents can be modified", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If

        'validate entries
        If validateInputs() = False Then
            Exit Sub
        End If


        Dim packingList As New PackingList
        packingList.id = txtId.Text
        packingList.no = txtIssueNo.Text
        packingList.salesPerson.personnel.name = cmbSalesPersons.Text
        packingList.issued = Val(LCurrency.getValue(txtTotalAmountIssued.Text))
        packingList.returns = Val(LCurrency.getValue(txtTotalReturns.Text))
        packingList.damages = Val(LCurrency.getValue(txtTotalDamages.Text))
        packingList.discount = Val(LCurrency.getValue(txtTotalDiscounts.Text))
        packingList.expenses = Val(LCurrency.getValue(txtTotalExpenses.Text))
        packingList.bankDeposit = Val(LCurrency.getValue(txtTotalBankDeposit.Text))
        packingList.cash = Val(LCurrency.getValue(txtCash.Text))
        packingList.costOfGoodsSold = Val(LCurrency.getValue(txtCostOfGoodsSold.Text))

        Dim response As Object = New Object
        response = Web.put(packingList, "packing_lists/edit_by_id?id=" + txtId.Text)

        searchPackingList(txtIssueNo.Text)

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        resetAll()
    End Sub

    Private Sub resetAll()
        oldPrice = 0

        txtId.Text = ""
        txtIssueNo.Text = ""
        txtCreated.Text = ""
        cmbSalesPersons.SelectedItem = Nothing
        txtStatus.Text = ""

        txtBarCode.Text = ""
        txtCode.Text = ""
        cmbDescription.SelectedItem = Nothing
        cmbDescription.Text = ""
        txtPrice.Text = ""
        txtReturns.Text = ""
        txtIssuedQty.Text = ""
        txtPacked.Text = ""
        txtQtyReturned.Text = ""
        txtQtyDamaged.Text = ""
        txtQtySold.Text = ""
        txtCPrice.Text = ""

        txtTotalPreviousReturns.Text = ""
        txtTotalAmountPacked.Text = ""
        txtTotalAmountIssued.Text = ""
        txtTotalSales.Text = ""
        txtTotalReturns.Text = ""
        txtTotalDiscounts.Text = ""
        txtTotalExpenses.Text = ""
        txtTotalDamages.Text = ""
        txtTotalBankDeposit.Text = ""
        txtDebt.Text = ""
        txtCostOfGoodsSold.Text = ""


        'lock
        txtIssueNo.ReadOnly = True
        txtQtyReturned.ReadOnly = True
        txtQtySold.ReadOnly = True
        txtQtyDamaged.ReadOnly = True

        txtTotalDiscounts.ReadOnly = True
        txtTotalExpenses.ReadOnly = True
        txtTotalBankDeposit.ReadOnly = True
        txtDebt.ReadOnly = True
        txtPrice.ReadOnly = True
        txtBarCode.ReadOnly = True
        txtCode.ReadOnly = True
        cmbDescription.Enabled = False
        txtCreated.Text = ""
        txtStatus.Text = ""

        'unlock

        btnSave.Enabled = False

        dtgrdItemList.Rows.Clear()
    End Sub


    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim status As String
        Try
            status = Web.get_("packing_lists/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        report = False
        If status = "PENDING" Or status = "APPROVED" Or status = "PRINTED" Or status = "COMPLETED" Or status = "ARCHIVED" Then
            'contunue to print
        ElseIf status = "PENDING" Then
            MsgBox("Could not print a pending packing list", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        ElseIf status = "CANCELED" Then
            MsgBox("Could not print a canceled packing list", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        Else
            MsgBox("Select a document to print", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If

        If txtIssueNo.Text = "" Then
            MsgBox("Select a document to print", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If
        Dim res As Integer = 0

        If status = "APPROVED" Then
            res = MsgBox("Print document: " + txtIssueNo.Text + " ? Issued products will be deducted from stock", vbYesNo + vbQuestion, "Print?")
            If res = DialogResult.Yes Then
                Try
                    Dim printed As Boolean = Web.put(vbNull, "packing_lists/print_by_id?id=" + txtId.Text)
                    If printed = True Then

                    Else
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
            End If
        ElseIf status = "PENDING" Then
            res = MsgBox("Print pending document: " + txtIssueNo.Text + " ? ", vbYesNo + vbQuestion, "Print?")
        Else
            res = MsgBox("Re-Print document: " + txtIssueNo.Text + " ? ", vbYesNo + vbQuestion, "Print?")
        End If

        Try
            status = Web.get_("packing_lists/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
            MsgBox("Could not print, document status could not be determined", vbOKOnly + vbExclamation, "Error: Status unknown")
            Exit Sub
        End Try

        txtStatus.Text = status

        If res = DialogResult.Yes Then

            Dim document As Document = New Document

            document.Info.Title = "Packing List"
            document.Info.Subject = "Packing List"
            document.Info.Author = "Orbit"
            defineStyles(document)
            createDocument(document)

            Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
            myRenderer.Document = document
            myRenderer.RenderDocument()

            Dim filename As String = LSystem.getRoot & "\Packing List " & txtIssueNo.Text & ".pdf"

            myRenderer.PdfDocument.Save(filename)

            Process.Start(filename)

        End If

    End Sub

    Private Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click
        Dim debt As Double = 0

        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Dim packingList As New PackingList
        Try
            response = Web.get_("packing_lists/get_by_id?id=" + txtId.Text)
            packingList = JsonConvert.DeserializeObject(Of PackingList)(response.ToString)
        Catch ex As Exception
            Exit Sub
        End Try
        debt = packingList.deficit

        If debt > 0 Then
            MsgBox("Could not archive, debt not cleared", vbOKOnly + vbCritical, "Error: Debt not cleared")
            Exit Sub
        End If
        Dim status As String
        Try
            status = Web.get_("packing_lists/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If status = "COMPLETED" Then
            'continue
        Else
            If txtIssueNo.Text = "" Then
                MsgBox("Select a packing list to archive", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            MsgBox("Can not archive, only completed packing list can be archived", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If

        Dim res As Integer = MsgBox("Are you sure you want to archive document : " + txtIssueNo.Text + " ? Document will be archived for future reference", vbYesNo + vbQuestion, "Archive document?")
        If res = DialogResult.Yes Then

            Dim canceled As Boolean = False
            Try
                canceled = Web.put(vbNull, "packing_lists/archive_by_id?id=" + txtId.Text)
            Catch ex As Exception
                canceled = False
            End Try
            If canceled = True Then
                MsgBox("Document Successively archived", vbOKOnly + vbInformation, "Operation successiful")
            Else
                MsgBox("Could not archive document", vbOKOnly + vbExclamation, "Operation failed")
            End If
            searchPackingList(txtIssueNo.Text)
        End If
        refreshPackingLists()
    End Sub

    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        If txtIssueNo.Text = "" Then
            MsgBox("Select a packing list to complete", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If
        Dim status As String = ""
        Try
            status = Web.get_("packing_lists/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If status <> "PRINTED" Then
            MsgBox("Operation failed, Only printed packing list can be completed and posted to sales", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If



        txtTotalAmountIssued.Text = LCurrency.displayValue(Math.Round((Val(LCurrency.getValue(txtTotalAmountIssued.Text))), 2, MidpointRounding.AwayFromZero).ToString)
        txtTotalReturns.Text = LCurrency.displayValue(Math.Round((Val(LCurrency.getValue(txtTotalReturns.Text))), 2, MidpointRounding.AwayFromZero).ToString)
        txtTotalDamages.Text = LCurrency.displayValue(Math.Round((Val(LCurrency.getValue(txtTotalDamages.Text))), 2, MidpointRounding.AwayFromZero).ToString)
        txtTotalDiscounts.Text = LCurrency.displayValue(Math.Round((Val(LCurrency.getValue(txtTotalDiscounts.Text))), 2, MidpointRounding.AwayFromZero).ToString)
        txtTotalExpenses.Text = LCurrency.displayValue(Math.Round((Val(LCurrency.getValue(txtTotalExpenses.Text))), 2, MidpointRounding.AwayFromZero).ToString)
        txtTotalBankDeposit.Text = LCurrency.displayValue(Math.Round((Val(LCurrency.getValue(txtTotalBankDeposit.Text))), 2, MidpointRounding.AwayFromZero).ToString)
        txtDebt.Text = LCurrency.displayValue(Math.Round((Val(LCurrency.getValue(txtDebt.Text))), 2, MidpointRounding.AwayFromZero).ToString)
        txtTotalSales.Text = LCurrency.displayValue(Math.Round((Val(LCurrency.getValue(txtTotalSales.Text))), 2, MidpointRounding.AwayFromZero).ToString)
        txtCostOfGoodsSold.Text = LCurrency.displayValue(Math.Round((Val(LCurrency.getValue(txtCostOfGoodsSold.Text))), 2, MidpointRounding.AwayFromZero).ToString)

        Dim amountIssued As Double = Val(LCurrency.getValue(txtTotalAmountIssued.Text))
        Dim sales As Double = Val(LCurrency.getValue(txtTotalSales.Text))
        Dim returns As Double = Val(LCurrency.getValue(txtTotalReturns.Text))
        Dim damages As Double = Val(LCurrency.getValue(txtTotalDamages.Text))
        Dim discounts As Double = Val(LCurrency.getValue(txtTotalDiscounts.Text))
        Dim expenditures As Double = Val(LCurrency.getValue(txtTotalExpenses.Text))
        Dim bankCash As Double = Val(LCurrency.getValue(txtTotalBankDeposit.Text))
        Dim debt As Double = Val(LCurrency.getValue(txtDebt.Text))
        Dim costOfGoods As Double = Val(LCurrency.getValue(txtCostOfGoodsSold.Text))


        'validate entries
        If discounts < 0 Or expenditures < 0 Or bankCash < 0 Or debt < 0 Then
            MsgBox("Operation failed, negative amounts are not allowed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If

        If ((amountIssued - (returns + damages + discounts + expenditures + bankCash + debt) <> 0)) Then
            MsgBox("Operation failed, Amounts do not tally", vbOKOnly + vbExclamation, "Error: Invalid entries")
            Exit Sub
        End If

        If ((amountIssued - (sales + returns + damages) <> 0)) Then
            MsgBox("Can not update, unsold items must be returned or registered as damaged", vbOKOnly + vbExclamation, "Error: Invalid entries")
            Exit Sub
        End If

        Dim packingList As New PackingList
        packingList.id = txtId.Text
        packingList.no = txtIssueNo.Text
        packingList.salesPerson.personnel.name = cmbSalesPersons.Text
        packingList.issued = Val(LCurrency.getValue(txtTotalAmountIssued.Text))
        packingList.returns = Val(LCurrency.getValue(txtTotalReturns.Text))
        packingList.damages = Val(LCurrency.getValue(txtTotalDamages.Text))
        packingList.discount = Val(LCurrency.getValue(txtTotalDiscounts.Text))
        packingList.expenses = Val(LCurrency.getValue(txtTotalExpenses.Text))
        packingList.bankDeposit = Val(LCurrency.getValue(txtTotalBankDeposit.Text))
        packingList.cash = Val(LCurrency.getValue(txtCash.Text))
        packingList.costOfGoodsSold = Val(LCurrency.getValue(txtCostOfGoodsSold.Text))

        Dim res As Integer = MsgBox("Complete transaction? Returned products will be returned to stock and sales will be registered to sales", vbYesNoCancel + vbQuestion, "Complete transaction")
        If Not res = DialogResult.Yes Then
            Exit Sub
        End If
        Dim completed As Boolean = False
        Try
            completed = Web.put(packingList, "packing_lists/complete_by_id?id=" + txtId.Text)
        Catch ex As Exception
            completed = False
        End Try
        If completed = True Then
            MsgBox("Document Successively completed", vbOKOnly + vbInformation, "Operation successiful")
        Else
            MsgBox("Could not complete document", vbOKOnly + vbExclamation, "Operation failed")
        End If
        searchPackingList(txtIssueNo.Text)
        refreshPackingLists()

    End Sub

    Private Sub refreshPackingLists()
        dtgrdPackingLists.Rows.Clear()

        Try
            Dim response As Object = New Object

            response = Web.get_("packing_lists/visible")

            Dim packingLists As List(Of PackingList) = JsonConvert.DeserializeObject(Of List(Of PackingList))(response.ToString)

            For Each packingList In packingLists

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = packingList.no
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = packingList.createdDay.bussinessDate
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = "Status: " + packingList.status + " S/M Officer: " + packingList.salesPerson.personnel.name
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdPackingLists.Rows.Add(dtgrdRow)

            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub dtgrdPackingLists_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdPackingLists.CellClick
        Dim r As Integer = dtgrdPackingLists.CurrentRow.Index
        Dim issueNo As String = dtgrdPackingLists.Item(0, r).Value.ToString
        txtIssueNo.Text = issueNo
        txtIssueNo.ReadOnly = False
        searchPackingList(issueNo)
    End Sub

    Private Sub btnClearDebt_Click(sender As Object, e As EventArgs) Handles btnClearDebt.Click
        If txtId.Text = "" Then
            MsgBox("Please select packing list", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If
        PackingList.GLOBAL_ISSUE_NO = txtIssueNo.Text
        PackingList.GLOBAL_SM_OFFICER = cmbSalesPersons.Text
        PackingList.GLOBAL_DEBT = LCurrency.getValue(txtDebt.Text)

        frmClearDebt.ShowDialog()
        txtIssueNo.ReadOnly = False
        searchPackingList(txtIssueNo.Text)
        txtIssueNo.ReadOnly = True
    End Sub

    Private Sub txtDebt_TextChanged(sender As Object, e As EventArgs) Handles txtDebt.TextChanged
        If Val(LCurrency.getValue(txtDebt.Text)) > 0 Then
            btnClearDebt.Enabled = True
        Else
            btnClearDebt.Enabled = False
        End If
        If Val(LCurrency.getValue(txtDebt.Text)) < 0 Then
            txtDebt.Text = ""
        End If
    End Sub

    Private Sub txtStatus_TextChanged(sender As Object, e As EventArgs) Handles txtStatus.TextChanged
        If txtStatus.Text = "" Or txtStatus.Text = "PENDING" Then
            cmbSalesPersons.Enabled = True
        Else
            cmbSalesPersons.Enabled = False
        End If
    End Sub

    Private Sub txtQtyIssued_TextChanged(sender As Object, e As EventArgs) Handles txtPacked.TextChanged
        If Not IsNumeric(txtPacked.Text) Or txtPacked.Text.Contains("-") Or Val(txtPacked.Text) < 0 Then
            txtPacked.Text = ""
        End If
    End Sub

    Private Sub txtQtySold_TextChanged(sender As Object, e As EventArgs) Handles txtQtySold.TextChanged
        If Not IsNumeric(txtQtySold.Text) Or txtQtySold.Text.Contains("-") Or Val(txtQtySold.Text) < 0 Then
            txtQtySold.Text = ""
        End If
    End Sub

    Private Sub txtQtyReturned_TextChanged(sender As Object, e As EventArgs) Handles txtQtyReturned.TextChanged
        If Not IsNumeric(txtQtyReturned.Text) Or txtQtyReturned.Text.Contains("-") Or Val(txtQtyReturned.Text) < 0 Then
            txtQtyReturned.Text = ""
        End If
    End Sub

    Private Sub txtQtyDamaged_TextChanged(sender As Object, e As EventArgs) Handles txtQtyDamaged.TextChanged
        If Not IsNumeric(txtQtyDamaged.Text) Or txtQtyDamaged.Text.Contains("-") Or Val(txtQtyDamaged.Text) < 0 Then
            txtQtyDamaged.Text = ""
        End If
    End Sub

    Private Sub btnDeficit_Click(sender As Object, e As EventArgs) Handles btnDeficit.Click
        If txtId.Text = "" Then
            Exit Sub
        End If
        txtDebt.Text = ""
        Dim res As Integer = MsgBox("Calculate deficit? Make sure you have verified the amounts before entering deficit", vbYesNoCancel + vbQuestion, "Calculate deficit?")
        If Not res = DialogResult.Yes Then
            Exit Sub
        End If

        Dim amountIssued As Double = Val(LCurrency.getValue(txtTotalAmountIssued.Text))
        Dim sales As Double = Val(LCurrency.getValue(txtTotalSales.Text))
        Dim returns As Double = Val(LCurrency.getValue(txtTotalReturns.Text))
        Dim damages As Double = Val(LCurrency.getValue(txtTotalDamages.Text))
        Dim discounts As Double = Val(LCurrency.getValue(txtTotalDiscounts.Text))
        Dim expenditures As Double = Val(LCurrency.getValue(txtTotalExpenses.Text))
        Dim bankCash As Double = Val(LCurrency.getValue(txtTotalBankDeposit.Text))

        Dim debt As Double = sales - (discounts + expenditures + bankCash)

        If debt < 0 Then
            MsgBox("Invalid deficit amount, deficit less than zero")
        End If
        txtDebt.Text = LCurrency.displayValue(debt.ToString)
    End Sub

    Private Sub txtTotalDiscounts_TextChanged(sender As Object, e As EventArgs) Handles txtTotalDiscounts.TextChanged
        If Not IsNumeric(LCurrency.getValue(txtTotalDiscounts.Text)) Or txtTotalDiscounts.Text.Contains("-") Or Val(LCurrency.getValue(txtTotalDiscounts.Text)) < 0 Then
            txtTotalDiscounts.Text = ""
        End If
    End Sub

    Private Sub txtTotalExpenditures_TextChanged(sender As Object, e As EventArgs) Handles txtTotalExpenses.TextChanged
        If Not IsNumeric(LCurrency.getValue(txtTotalExpenses.Text)) Or txtTotalExpenses.Text.Contains("-") Or Val(LCurrency.getValue(txtTotalExpenses.Text)) < 0 Then
            txtTotalExpenses.Text = ""
        End If
    End Sub

    Private Sub txtTotalBankCash_TextChanged(sender As Object, e As EventArgs) Handles txtTotalBankDeposit.TextChanged
        If Not IsNumeric(LCurrency.getValue(txtTotalBankDeposit.Text)) Or txtTotalBankDeposit.Text.Contains("-") Or Val(LCurrency.getValue(txtTotalBankDeposit.Text)) < 0 Then
            txtTotalBankDeposit.Text = ""
        End If
    End Sub

    Dim report As String = False
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnPrintReport.Click
        Dim status As String
        Try
            status = Web.get_("packing_lists/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        report = True

        If 1 = 1 Then ' User.authorize("PRINT PACKING LIST") = True Then
            If txtIssueNo.Text = "" Then
                MsgBox("Select a document to print", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If

            If dtgrdItemList.RowCount = 0 Then
                MsgBox("Could not print an empty document", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            Dim list As PackingList = New PackingList

            Dim issueNo As String = txtIssueNo.Text
            If issueNo = "" Then
                MsgBox("Select a document to print.", vbOKOnly + vbCritical, "Error:No selection")
                Exit Sub
            End If
            If dtgrdItemList.RowCount = 0 Then
                MsgBox("Can not print an empty document. Please select a document to print", vbOKOnly + vbCritical, "Error: No selection")
                Exit Sub
            End If

            Dim document As Document = New Document

            document.Info.Title = "Packing List"
            document.Info.Subject = "Packing List"
            document.Info.Author = "Orbit"

            defineStyles(document)
            createDocument(document)

            Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
            myRenderer.Document = document
            myRenderer.RenderDocument()

            Dim filename As String = LSystem.getRoot & "\Packing List " & issueNo & ".pdf"

            myRenderer.PdfDocument.Save(filename)

            Process.Start(filename)


            Try
                status = Web.get_("packing_lists/get_status_by_id?id=" + txtId.Text)
                txtStatus.Text = status
            Catch ex As Exception
                status = ""
            End Try


        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
        refreshPackingLists()
    End Sub

    Private Sub txtReturns_TextChanged(sender As Object, e As EventArgs) Handles txtReturns.TextChanged
        If Val(txtReturns.Text) < 0 Then
            txtReturns.Text = ""
        End If
        If Not IsNumeric(txtReturns.Text) Then
            txtReturns.Text = ""
        End If
        If (txtReturns.Text).Contains("-") Then
            txtReturns.Text = ""
        End If
        txtPacked.Text = (Val(txtReturns.Text) + Val(txtIssuedQty.Text)).ToString
    End Sub

    Private Sub txtPacked_TextChanged(sender As Object, e As EventArgs) Handles txtIssuedQty.TextChanged
        If Val(txtIssuedQty.Text) < 0 Then
            txtIssuedQty.Text = ""
        End If
        If Not IsNumeric(txtIssuedQty.Text) Then
            txtIssuedQty.Text = ""
        End If
        If (txtIssuedQty.Text).Contains("-") Then
            txtIssuedQty.Text = ""
        End If
        txtPacked.Text = (Val(txtReturns.Text) + Val(txtIssuedQty.Text)).ToString
    End Sub

    Dim oldPrice As Double = 0
    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        If txtPrice.ReadOnly = True And txtPrice.Text <> "" And Val(LCurrency.getValue(txtPrice.Text)) > 0 Then
            Dim res As Integer = MsgBox("Change price?", vbYesNo + vbQuestion, "Customize price")
            If res = DialogResult.Yes Then
                oldPrice = Val(LCurrency.getValue(txtPrice.Text))
                txtPrice.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub txtPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.TextChanged
        If txtPrice.ReadOnly = False And (Not IsNumeric(txtPrice.Text) Or txtPrice.Text.Contains("-")) Then
            txtPrice.Text = oldPrice.ToString
            oldPrice = 0
            txtPrice.ReadOnly = True
        End If
    End Sub
    'maintains the visible position of a row after refresh
    Dim currentRow As Integer = -1

    Private Sub btnArchiveAll_Click(sender As Object, e As EventArgs) Handles btnArchiveAll.Click
        resetAll()
        Dim res As Integer = MsgBox("Archive all completed and debt free documents? The documents will be archived for future references", vbYesNo + vbQuestion, "Archive all")
        If Not res = DialogResult.Yes Then
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Try
            Web.put(vbNull, "packing_lists/archive_all")
            MsgBox("Success", vbOKOnly + vbInformation, "")
        Catch ex As Exception
            MsgBox("Failed", vbOKOnly + vbInformation, "")
        End Try
        refreshPackingLists()
        Cursor = Cursors.Default
    End Sub
End Class