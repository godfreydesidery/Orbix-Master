Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering
Imports Newtonsoft.Json

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
        paragraph.AddFormattedText("Issue Date: " + txtCreated.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Status: " + (New PackingList).getStatus(txtIssueNo.Text))
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

        Dim status As String = (New PackingList).getStatus(txtIssueNo.Text)

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
        Dim list As New PackingList
        If list.getPackingList(issueNo) = True Then
            txtIssueNo.ReadOnly = True
            'txtOrderNo.Text = order.GL_ORDER_NO

            txtCreated.Text = list.GL_ISSUE_DATE
            txtStatus.Text = list.GL_STATUS
            cmbSalesPersons.Text = list.GL_SALES_PERSON
            txtTotalAmountIssued.Text = LCurrency.displayValue(list.GL_AMOUNT_ISSUED.ToString)
            txtTotalReturns.Text = LCurrency.displayValue(list.GL_TOTAL_RETURNS.ToString)
            txtTotalDamages.Text = LCurrency.displayValue(list.GL_TOTAL_DAMAGES.ToString)
            txtTotalDiscounts.Text = LCurrency.displayValue(list.GL_TOTAL_DISCOUNTS.ToString)
            txtTotalExpenses.Text = LCurrency.displayValue(list.GL_TOTAL_EXPENDITURES.ToString)
            txtTotalBankDeposit.Text = LCurrency.displayValue(list.GL_TOTAL_BANK_CASH.ToString)
            txtDebt.Text = LCurrency.displayValue(list.GL_DEBT.ToString)
            txtAmountSold.Text = LCurrency.displayValue(list.GL_COST_OF_GOODS_SOLD.ToString)

            'txtTotalSales.Text = LCurrency.displayValue((LCurrency.getValue(txtTotalAmountIssued.Text)).ToString)

        End If
        Return found
    End Function
    Private Function search()
        clearItemFields()
        If txtIssueNo.Text = "" Then
            MsgBox("Can not process packing list. Please specify whether the packing list is new or existing by selecting New or Edit", vbOKOnly + vbCritical, "Invalid operation")
            Return vbNull
            Exit Function
        End If
        If txtIssueNo.ReadOnly = False Then
            Dim list As New PackingList
            If list.getPackingList(txtIssueNo.Text) = True Then
                txtId.Text = list.GL_ID
                txtIssueNo.ReadOnly = True

                txtCreated.Text = list.GL_ISSUE_DATE
                txtStatus.Text = list.GL_STATUS
                cmbSalesPersons.Text = list.GL_SALES_PERSON
                txtTotalAmountIssued.Text = LCurrency.displayValue(list.GL_AMOUNT_ISSUED.ToString)
                txtTotalReturns.Text = LCurrency.displayValue(list.GL_TOTAL_RETURNS.ToString)
                txtTotalDamages.Text = LCurrency.displayValue(list.GL_TOTAL_DAMAGES.ToString)
                txtTotalDiscounts.Text = LCurrency.displayValue(list.GL_TOTAL_DISCOUNTS.ToString)
                txtTotalExpenses.Text = LCurrency.displayValue(list.GL_TOTAL_EXPENDITURES.ToString)
                txtTotalBankDeposit.Text = LCurrency.displayValue(list.GL_TOTAL_BANK_CASH.ToString)
                txtDebt.Text = LCurrency.displayValue(list.GL_DEBT.ToString)
                txtAmountSold.Text = LCurrency.displayValue(list.GL_COST_OF_GOODS_SOLD.ToString)

                'txtTotalSales.Text = LCurrency.displayValue((LCurrency.getValue(txtTotalAmountIssued.Text)).ToString)

                'MsgBox(list.GL_AMOUNT_ISSUED)

                refreshList()
                If txtId.Text = "" Then
                    btnSave.Enabled = False
                Else
                    btnSave.Enabled = True
                End If

                Dim status As String = list.GL_STATUS

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
                    txtItemCode.ReadOnly = False
                    cmbDescription.Enabled = True
                    txtReturns.ReadOnly = False
                    txtPacked.ReadOnly = False
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
                    txtItemCode.ReadOnly = True
                    cmbDescription.Enabled = False
                    txtReturns.ReadOnly = True
                    txtPacked.ReadOnly = True
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
                    txtItemCode.ReadOnly = True
                    cmbDescription.Enabled = False
                    txtReturns.ReadOnly = True
                    txtPacked.ReadOnly = True
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
                    txtItemCode.ReadOnly = True
                    cmbDescription.Enabled = False
                    txtReturns.ReadOnly = True
                    txtPacked.ReadOnly = True
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
                    txtItemCode.ReadOnly = True
                    cmbDescription.Enabled = False
                    txtReturns.ReadOnly = True
                    txtPacked.ReadOnly = True
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
                    txtItemCode.ReadOnly = True
                    cmbDescription.Enabled = False
                    txtReturns.ReadOnly = True
                    txtPacked.ReadOnly = True
                    txtQtyReturned.ReadOnly = True
                    txtQtySold.ReadOnly = True
                    txtQtyDamaged.ReadOnly = True


                    txtTotalDiscounts.ReadOnly = True
                    txtTotalExpenses.ReadOnly = True
                    txtTotalBankDeposit.ReadOnly = True
                    txtDebt.ReadOnly = True
                End If

            Else
                MsgBox("No matching record", vbOKOnly + vbCritical, "Error: Not found")
                Return vbNull
                Exit Function
            End If
        End If

        Return vbNull
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search()
    End Sub
    Private Sub clearItemFields()
        txtBarCode.Text = ""
        txtItemCode.Text = ""
        cmbDescription.Text = ""
        txtPrice.Text = ""
        txtReturns.Text = ""
        txtPacked.Text = ""
        txtTotalIssued.Text = ""
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
        txtItemCode.Text = ""
        cmbDescription.Text = ""
        txtPrice.Text = ""
        txtReturns.Text = ""
        txtPacked.Text = ""
        txtTotalIssued.Text = ""
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
        txtAmountSold.Text = ""



        txtIssueNo.ReadOnly = True
        cmbSalesPersons.Enabled = True


        txtBarCode.ReadOnly = False
        txtItemCode.ReadOnly = False
        cmbDescription.Enabled = True
        txtReturns.ReadOnly = False
        txtPacked.ReadOnly = False
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
        txtIssueNo.Text = (New PackingList).generateIssueNo
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


    Private Function savePackingListDetail(issueNo As String, itemCode As String, price As Double, returns As Double, packed As Double, qtyIssued As Double, qtyReturned As Double, qtySold As Double, qtyDamaged As Double, cPrice As Double) As Boolean
        Dim success As Boolean = False
        Try
            Dim list As New PackingList
            list.GL_ISSUE_NO = issueNo
            list.GL_ITEM_CODE = itemCode
            list.GL_PRICE = price
            list.GL_RETURNS = returns
            list.GL_PACKED = packed
            list.GL_TOTAL_ISSUED = qtyIssued
            list.GL_QTY_RETURNED = qtyReturned
            list.GL_QTY_SOLD = qtySold
            list.GL_QTY_DAMAGED = qtyDamaged
            list.GL_C_PRICE = cPrice


            list.addPackingListDetails()
            success = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return success
    End Function

    Private Function refreshList()
        Cursor = Cursors.WaitCursor
        dtgrdItemList.Rows.Clear()

        Try

        Catch ex As Exception

        End Try

        Try

            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `id`, `packing_list_id`,`issue_no`, `item_code`,`description`,`price`,`returns`, `packed`, `qty_issued`,`qty_returned`,`qty_sold`,`qty_damaged`,`cprice` FROM `packing_list_details` WHERE `issue_no`='" + txtIssueNo.Text + "' "
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim id As String = ""
            Dim barCode As String = ""
            Dim itemCode As String = ""
            Dim description As String = ""
            Dim price As Double = vbNull
            Dim returns As Double = vbNull
            Dim packed As Double = vbNull
            Dim qtyIssued As Double = vbNull
            Dim qtyReturned As Double = vbNull
            Dim qtySold As Double = vbNull
            Dim qtyDamaged As Double = vbNull
            Dim cPrice As Double = 0

            Dim totalPreviousReturns As Double = 0
            Dim totalPacked As Double = 0
            Dim amountIssued As Double = 0
            Dim totalSales As Double = 0
            Dim totalreturned As Double = 0
            Dim totalsold As Double = 0
            Dim totalDamaged As Double = 0
            Dim totalCost As Double = 0


            While reader.Read
                Dim item As New Item
                itemCode = reader.GetString("item_code")
                id = reader.GetString("id")
                description = reader.GetString("description")
                price = Val(reader.GetString("price"))
                returns = Val(reader.GetString("returns"))
                packed = Val(reader.GetString("packed"))
                qtyIssued = Val(reader.GetString("qty_issued"))
                qtyReturned = Val(reader.GetString("qty_returned"))
                qtySold = Val(reader.GetString("qty_sold"))
                qtyDamaged = Val(reader.GetString("qty_damaged"))
                cPrice = Val(reader.GetString("cprice"))

                totalPreviousReturns = totalPreviousReturns + (returns * price)
                totalPacked = totalPacked + (packed * price)
                amountIssued = amountIssued + Val(qtyIssued) * Val(price)
                totalSales = totalSales + Val(qtySold) * Val(price)
                totalreturned = totalreturned + Val(qtyReturned) * Val(price)
                totalsold = totalsold + Val(qtySold) * Val(price)
                totalDamaged = totalDamaged + Val(qtyDamaged) * Val(price)
                totalCost = totalCost + Val(qtySold) * Val(cPrice)

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = itemCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = description
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                ' dtgrdCell.Value = price
                dtgrdCell.Value = LCurrency.displayValue(price.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = returns
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = packed
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = qtyIssued
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = qtySold
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = qtyReturned
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = qtyDamaged
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = id
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                'dtgrdCell.Value = cPrice
                dtgrdCell.Value = LCurrency.displayValue(cPrice.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdItemList.Rows.Add(dtgrdRow)
            End While

            conn.Close()
            txtTotalPreviousReturns.Text = LCurrency.displayValue(totalPreviousReturns.ToString)
            txtTotalAmountPacked.Text = LCurrency.displayValue(totalPacked.ToString)
            txtTotalAmountIssued.Text = LCurrency.displayValue(amountIssued.ToString)
            txtTotalSales.Text = LCurrency.displayValue(totalSales.ToString)
            txtTotalReturns.Text = LCurrency.displayValue(totalreturned.ToString)
            txtTotalDamages.Text = LCurrency.displayValue(totalDamaged.ToString)
            txtAmountSold.Text = LCurrency.displayValue(totalCost.ToString)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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
        Dim status As String = (New PackingList).getStatus(txtIssueNo.Text)
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
        If status = "CANCELED" Then
            MsgBox("Could not edit, document has been canceled", vbOKOnly + vbExclamation, "Error: Invalid operation")
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

        txtItemCode.Text = itemCode
        cmbDescription.Text = description
        txtPrice.Text = price
        txtReturns.Text = returns
        txtPacked.Text = packed
        txtTotalIssued.Text = qtyIssued
        txtQtyReturned.Text = qtyReturned
        txtQtySold.Text = qtySold
        txtQtyDamaged.Text = qtyDamaged
        txtCPrice.Text = cPrice

        If txtStatus.Text = "PENDING" Then
            'lock
            txtBarCode.ReadOnly = True
            txtItemCode.ReadOnly = True
            cmbDescription.Enabled = False

            txtQtyReturned.ReadOnly = True
            txtQtySold.ReadOnly = True
            txtQtyDamaged.ReadOnly = True
            'unlock
            txtReturns.ReadOnly = False
            txtPacked.ReadOnly = False

            btnAdd.Enabled = True
        End If
        If txtStatus.Text = "APPROVED" Then
            'lock
            txtBarCode.ReadOnly = True
            txtItemCode.ReadOnly = True
            cmbDescription.Enabled = False
            txtReturns.ReadOnly = True
            txtPacked.ReadOnly = True
            txtQtySold.ReadOnly = True
            txtQtyDamaged.ReadOnly = True

            txtTotalIssued.ReadOnly = True

            btnAdd.Enabled = False
        End If
        If txtStatus.Text = "PRINTED" Then
            'lock
            txtBarCode.ReadOnly = True
            txtItemCode.ReadOnly = True
            cmbDescription.Enabled = False
            txtReturns.ReadOnly = True
            txtPacked.ReadOnly = True

            'unlock
            txtQtyReturned.ReadOnly = False
            txtQtySold.ReadOnly = False
            txtQtyDamaged.ReadOnly = False

            btnAdd.Enabled = True
        End If
        If txtStatus.Text = "COMPLETED" Then
            'lock
            txtBarCode.ReadOnly = True
            txtItemCode.ReadOnly = True
            cmbDescription.Enabled = False
            txtReturns.ReadOnly = True
            txtPacked.ReadOnly = True
            txtQtyReturned.ReadOnly = True
            txtQtySold.ReadOnly = True
            txtQtyDamaged.ReadOnly = True

            btnAdd.Enabled = False
            'unlock

        End If

        'If (e.Button = MouseButtons.Right) Then

        'If dtgrdItemList.SelectedRows.Count = 1 Then
        'If (row >= 0 And dtgrdItemList.NewRowIndex) Then
        'glsn = sn
        '     cntxtMenu.Show(dtgrdItemList, dtgrdItemList.PointToClient(Cursor.Position))
        '  MsgBox("Deleting record " + glsn)
        'm.MenuItems.Add(New MenuItem(String.Format("Remove this item {0}", currentMouseOverRow.ToString())))
        'End If
        'End If


        ' End If
    End Sub

    Dim oldRow As Integer = -1
    Dim glsn As String = ""

    Private Sub dtGridMouseRightClick(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub dtgrdItemList_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdItemList.RowHeaderMouseDoubleClick
        txtPrice.ReadOnly = True
        Dim status As String = (New PackingList).getStatus(txtIssueNo.Text)

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


        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `packing_list_details` WHERE `id`='" + sn + "'"
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
        clearItemdetails()
        refreshList()

    End Sub
    Private Sub loadSalesPersons()
        Dim conn As New MySqlConnection(Database.conString)
        Try
            Dim suppcommand As New MySqlCommand()
            Dim supplierQuery As String = "SELECT `id`, `full_name` FROM `sales_persons` WHERE `status`='ACTIVE'"
            conn.Open()
            suppcommand.CommandText = supplierQuery
            suppcommand.Connection = conn
            suppcommand.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = suppcommand.ExecuteReader
            cmbSalesPersons.Items.Clear()
            If reader.HasRows Then
                While reader.Read
                    cmbSalesPersons.Items.Add(reader.GetString("full_name"))
                End While
            End If
            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            ErrorMessage.dbConnectionError()
            Exit Sub
        End Try
    End Sub

    Private Sub frmPackingList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.AppStarting
        resetAll()
        loadSalesPersons()
        refreshPackingLists()

        Dim item As New Item
        longList = item.getItems()
        Cursor = Cursors.Default
    End Sub

    Private Sub frmPurchaseOrder_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtIssueNo.Text = ""
        dtgrdItemList.Rows.Clear()

    End Sub

    Private Sub txtOrderNo_preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtIssueNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            search()
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
        Dim barCode As String = txtBarCode.Text
        Dim itemCode As String = txtItemCode.Text
        Dim descr As String = cmbDescription.Text

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
                txtItemCode.Text = reader.GetString("item_code")
                cmbDescription.Text = reader.GetString("item_long_description")
                txtPackSize.Text = reader.GetString("pck")
                txtPrice.Text = LCurrency.displayValue(reader.GetString("retail_price"))
                txtCPrice.Text = LCurrency.displayValue(reader.GetString("unit_cost_price"))
                txtStockSize.Text = (New Inventory).getInventory(reader.GetString("item_code"))
                found = True
                valid = True
                lockFields()
                Exit While
            End While
            conn.Close()
            If found = False Then
                MsgBox("Item not found", vbOKOnly + vbExclamation, "Error: Not found")
                clearFields()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub clearFields()
        txtBarCode.Text = ""
        txtItemCode.Text = ""
        cmbDescription.Text = ""
        txtPackSize.Text = ""

        txtPrice.Text = ""
        txtStockSize.Text = ""
        txtReturns.Text = ""
        txtPacked.Text = ""
        txtTotalIssued.Text = ""
        txtQtyReturned.Text = ""
        txtQtySold.Text = ""
        txtQtyDamaged.Text = ""
        txtCPrice.Text = ""
    End Sub
    Private Sub lockFields()
        txtBarCode.ReadOnly = True
        txtItemCode.ReadOnly = True
        cmbDescription.Enabled = False

        btnAdd.Enabled = True
    End Sub
    Private Sub unLockFields()
        txtBarCode.ReadOnly = False
        txtItemCode.ReadOnly = False
        cmbDescription.Enabled = True

        btnAdd.Enabled = False
    End Sub
    Private Function checkDuplicate(itemCode As String, issueNo As String) As Boolean
        Dim present As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `item_code`, `issue_no` FROM `packing_list_details` WHERE `item_code`='" + itemCode + "' AND `issue_no`='" + issueNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read

                present = True

                Exit While
            End While
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return present
    End Function
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
        Dim status As String = (New PackingList).getStatus(txtIssueNo.Text)
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
        If cmbSalesPersons.Text = "" Then
            MsgBox("Could not add item, sales person required", vbOKOnly + vbCritical, "Error: Missing Information")
            Cursor = Cursors.Default
            Exit Sub
        End If
        Dim barCode As String = txtBarCode.Text
        Dim itemCode As String = txtItemCode.Text
        Dim description As String = cmbDescription.Text

        Dim returns As String = txtReturns.Text
        Dim packed As String = txtPacked.Text
        Dim qtyIssued As String = txtTotalIssued.Text
        Dim qtyReturned As String = txtQtyReturned.Text
        Dim qtySold As String = txtQtySold.Text
        Dim qtyDamaged As String = txtQtyDamaged.Text
        'Dim price As String = txtPrice.Text
        Dim price As String = LCurrency.getValue(txtPrice.Text)
        Dim cPrice As String = LCurrency.getValue(txtCPrice.Text)
        Dim stockSize As String = txtStockSize.Text
        If itemCode = "" Then
            MsgBox("Item required", vbOKOnly + vbCritical, "Error: Missing information")
            Cursor = Cursors.Default
            Exit Sub
        End If
        If Val(qtyIssued) <= 0 Then
            MsgBox("Could not add item. Invalid issue qty, qty should be non-negative", vbOKOnly + vbCritical, "Error: Invalid entry")
            Cursor = Cursors.Default
            Exit Sub
        End If
        If ((Val(qtyIssued) - (Val(qtyReturned) + Val(qtySold) + Val(qtyDamaged)) <> 0) And status = "PRINTED") Then
            MsgBox("Could not update, quantity values do not tally", vbOKOnly + vbCritical, "Error: Invalid entry")
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim _new As Boolean = False
        Dim list As PackingList
        If txtId.Text = "" Then



            _new = True
            list = New PackingList
            list.GL_ISSUE_NO = txtIssueNo.Text
            Dim issueDate As String = (New Day).getCurrentDay.ToString("yyyy-MM-dd")
            list.GL_ISSUE_DATE = issueDate
            list.GL_SALES_PERSON = cmbSalesPersons.Text
            list.GL_STATUS = "PENDING"
            If list.isPackingListExist(txtIssueNo.Text) = False Then
                If list.addNewPackingList() = True Then
                    list.getPackingList(txtIssueNo.Text)
                    txtId.Text = list.GL_ID
                    btnSave.Enabled = True
                End If
            Else

            End If
        End If
        If txtId.Text = "" Then
            MsgBox("Could not add, please restart application")
            Cursor = Cursors.Default
            Exit Sub
        End If
        list = New PackingList
        list.GL_ISSUE_NO = txtIssueNo.Text
        list.GL_ITEM_CODE = itemCode
        list.GL_DESCRIPTION = description
        list.GL_PRICE = price
        list.GL_C_PRICE = cPrice
        list.GL_RETURNS = Math.Round((Val(returns)), 2, MidpointRounding.AwayFromZero)
        list.GL_PACKED = Math.Round((Val(packed)), 2, MidpointRounding.AwayFromZero)
        list.GL_TOTAL_ISSUED = Math.Round((Val(qtyIssued)), 2, MidpointRounding.AwayFromZero)
        list.GL_QTY_RETURNED = Math.Round((Val(qtyReturned)), 2, MidpointRounding.AwayFromZero)
        list.GL_QTY_SOLD = Math.Round((Val(qtySold)), 2, MidpointRounding.AwayFromZero)
        list.GL_QTY_DAMAGED = Math.Round((Val(qtyDamaged)), 2, MidpointRounding.AwayFromZero)
        If checkDuplicate(itemCode, txtIssueNo.Text) = False Then
            list.addPackingListDetails()
        Else
            list.editPackingListDetails(txtIssueNo.Text, itemCode)
        End If
        btnApprove.Enabled = True
        If _new = True Then
            refreshPackingLists()
        End If
        refreshList()
        clearFields()
        unLockFields()
        currentRow = -1
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim status As String = (New PackingList).getStatus(txtIssueNo.Text)
        If status = "PENDING" Or status = "APPROVED" Then
            'continue
        Else
            MsgBox("Can not cancel, only Pending or Approved packing list can be canceled", vbOKOnly + vbCritical, "Error: Invalid operation")
            Exit Sub
        End If

        If 1 = 1 Then ' User.authorize("APPROVE PACKING LIST") = True Then
            If txtIssueNo.Text = "" Then
                MsgBox("Select a packing list to cancel", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            Dim res As Integer = MsgBox("Cancel packing list: " + txtIssueNo.Text + " ? Packing list can not be used after canceling", vbYesNo + vbQuestion, "Cancel document?")
            If res = DialogResult.Yes Then

                Dim list As PackingList = New PackingList
                If list.cancelPackingList(txtIssueNo.Text) = True Then
                    MsgBox("Cancel Success", vbOKOnly + vbInformation, "Success")
                Else
                    MsgBox("Cancel failed", vbOKOnly + vbExclamation, "Failed")
                End If



            End If
            txtStatus.Text = (New PackingList).getStatus(txtIssueNo.Text)
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation, "Error: Access denied")
        End If
        refreshPackingLists()
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim status As String = (New PackingList).getStatus(txtIssueNo.Text)
        If status = "APPROVED" Then
            MsgBox("Could not approve, already approved", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "PRINTED" Then
            MsgBox("Could not approve, already printed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "REPRINTED" Then
            MsgBox("Could not approve, already printed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("Could not approve, already completed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("Could not approve, document has been canceled", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If 1 = 1 Then ' User.authorize("APPROVE PACKING LIST") = True Then
            If txtIssueNo.Text = "" Then
                MsgBox("Select a packing list to approve", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            Dim res As Integer = MsgBox("Approve packing list: " + txtIssueNo.Text + " ? Editing will be disabled after approval", vbYesNo + vbQuestion, "Approve document?")
            If res = DialogResult.Yes Then
                'approve order

                If dtgrdItemList.RowCount = 0 Then
                    MsgBox("Could not approve an empty packing list", vbOKOnly + vbExclamation, "Error: Invalid operation")
                    Exit Sub
                End If
                Dim list As PackingList = New PackingList
                If list.approvePackingList(txtIssueNo.Text) = True Then
                    MsgBox("Approve Success", vbOKOnly + vbInformation, "Success")
                Else
                    MsgBox("Approve failed", vbOKOnly + vbExclamation, "Failure")
                End If

            End If
            txtStatus.Text = (New PackingList).getStatus(txtIssueNo.Text)
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
        refreshPackingLists()
    End Sub

    Private Sub clearItemdetails()
        txtBarCode.Text = ""
        txtItemCode.Text = ""
        cmbDescription.Text = ""
        txtPrice.Text = ""
        txtReturns.Text = ""
        txtPacked.Text = ""
        txtTotalIssued.Text = ""
        txtQtyReturned.Text = ""
        txtQtyDamaged.Text = ""
        txtQtySold.Text = ""
        txtCPrice.Text = ""
        cmbDescription.Enabled = True
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

        Dim status As String = (New PackingList).getStatus(txtIssueNo.Text)
        If status = "CANCELED" Or status = "COMPLETED" Or status = "ARCHIVED" Then
            MsgBox("Could not modify. Only Pending, Approved or Printed documents can be modified", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If

        'validate entries
        If validateInputs() = False Then
            Exit Sub
        End If
        Dim list As New PackingList
        list.GL_ISSUE_NO = txtIssueNo.Text
        list.GL_ISSUE_DATE = txtCreated.Text
        list.GL_STATUS = txtStatus.Text
        list.GL_SALES_PERSON = cmbSalesPersons.Text

        list.GL_AMOUNT_ISSUED = Val(LCurrency.getValue(txtTotalAmountIssued.Text))
        list.GL_TOTAL_RETURNS = Val(LCurrency.getValue(txtTotalReturns.Text))
        list.GL_TOTAL_DAMAGES = Val(LCurrency.getValue(txtTotalDamages.Text))
        list.GL_TOTAL_DISCOUNTS = Val(LCurrency.getValue(txtTotalDiscounts.Text))
        list.GL_TOTAL_EXPENDITURES = Val(LCurrency.getValue(txtTotalExpenses.Text))
        list.GL_TOTAL_BANK_CASH = Val(LCurrency.getValue(txtTotalBankDeposit.Text))
        list.GL_DEBT = Val(LCurrency.getValue(txtDebt.Text))
        list.GL_COST_OF_GOODS_SOLD = Val(LCurrency.getValue(txtAmountSold.Text))
        'check if new or existing 

        If txtId.Text = "" Then
            'save a new record
            If list.addNewPackingList() = True Then
                list.getPackingList(txtIssueNo.Text)
                MsgBox("Save success", vbOKOnly + vbInformation, "Success")
            Else
                MsgBox("Saving failed", vbOKOnly + vbExclamation, "Failure")
            End If
        Else
            'save an existing record

            If list.editPackingList(txtIssueNo.Text) = True Then
                list.getPackingList(txtIssueNo.Text)
                MsgBox("Edit success", vbOKOnly + vbInformation, "Success")
            Else
                MsgBox("Editing failed", vbOKOnly + vbExclamation, "Failure")
            End If
        End If
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
        txtItemCode.Text = ""
        cmbDescription.SelectedItem = Nothing
        cmbDescription.Text = ""
        txtPrice.Text = ""
        txtReturns.Text = ""
        txtPacked.Text = ""
        txtTotalIssued.Text = ""
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
        txtAmountSold.Text = ""


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
        txtItemCode.ReadOnly = True
        cmbDescription.Enabled = False
        txtCreated.Text = ""
        txtStatus.Text = ""

        'unlock

        btnSave.Enabled = False


        dtgrdItemList.Rows.Clear()
    End Sub


    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim status As String = (New PackingList).getStatus(txtIssueNo.Text)
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

        If 1 = 1 Then ' User.authorize("PRINT PACKING LIST") = True Then
            If txtIssueNo.Text = "" Then
                MsgBox("Select a packing list to approve", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            Dim res As Integer = 0
            If status = "APPROVED" Then
                res = MsgBox("Print packing list: " + txtIssueNo.Text + " ? Issued items will be deducted from stock", vbYesNo + vbQuestion, "Print?")
            ElseIf status = "PENDING" Then
                res = MsgBox("Print pending packing list: " + txtIssueNo.Text + " ? ", vbYesNo + vbQuestion, "Print?")
            Else
                res = MsgBox("Re-Print packing list: " + txtIssueNo.Text + " ? ", vbYesNo + vbQuestion, "Print?")
            End If
            If res = DialogResult.Yes Then
                'approve order

                If dtgrdItemList.RowCount = 0 Then
                    MsgBox("Could not approve an empty packing list", vbOKOnly + vbExclamation, "Error: No selection")
                    Exit Sub
                End If
                Dim list As PackingList = New PackingList
                Dim success As Boolean = True
                If status = "APPROVED" Or status = "PRINTED" Then
                    If list.printPackingList(txtIssueNo.Text) = True Then
                        'if status is approved , deduct from stock
                        If status = "APPROVED" Then
                            'deduct from stock

                            For i As Integer = 0 To dtgrdItemList.RowCount - 1

                                Dim itemCode As String = dtgrdItemList.Item(0, i).Value
                                Dim qtyIsssued As String = dtgrdItemList.Item(5, i).Value
                                'sql for recording sales
                                Dim conn As New MySqlConnection(Database.conString)
                                Try
                                    conn.Open()
                                    Dim command As New MySqlCommand()
                                    command.Connection = conn
                                    command.CommandText = "UPDATE `inventorys` SET `qty`=`qty`-'" + qtyIsssued + "' WHERE `item_code`='" + itemCode + "'"
                                    command.Prepare()
                                    command.ExecuteNonQuery()
                                    conn.Close()
                                    Dim inventory As New Inventory
                                    Dim stockCard As New StockCard
                                    stockCard.qtyOut(Day.DAY, itemCode, qtyIsssued, inventory.getInventory(itemCode), "Issued to packing List, Issue No: " + txtIssueNo.Text)
                                Catch ex As Exception
                                    MsgBox(ex.ToString)
                                End Try
                            Next
                        End If
                        success = True
                        If status = "APPROVED" Then
                            MsgBox("Print Success", vbOKOnly + vbInformation, "Success")
                        End If
                    Else
                        success = False
                        MsgBox("Print failed", vbOKOnly + vbExclamation, "Failure")
                    End If
                End If
                If success = True Then
                    'now do the actual printing in pdf

                    Dim issueNo As String = txtIssueNo.Text
                    If issueNo = "" Then
                        MsgBox("Select a packing list to print.", vbOKOnly + vbCritical, "Error:No selection")
                        Exit Sub
                    End If
                    If dtgrdItemList.RowCount = 0 Then
                        MsgBox("Can not print an empty packing list. Please select the bill to print", vbOKOnly + vbCritical, "Error: No selection")
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

                End If

            End If
            txtStatus.Text = (New PackingList).getStatus(txtIssueNo.Text)
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
        refreshPackingLists()
    End Sub

    Private Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click
        Dim debt As Double = Val((New PackingList).getDebt(txtIssueNo.Text))
        If debt > 0 Then
            MsgBox("Could not archive, debt not cleared", vbOKOnly + vbCritical, "Error: Debt not cleared")
            Exit Sub
        End If
        Dim status As String = (New PackingList).getStatus(txtIssueNo.Text)
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

        If 1 = 1 Then ' User.authorize("APPROVE LPO") = True Then
            If txtIssueNo.Text = "" Then
                MsgBox("Select a document to archive", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            Dim res As Integer = MsgBox("Archive packing list: " + txtIssueNo.Text + " ? Packing list will be sent to archives for future references", vbYesNo + vbQuestion, "Archive packing list?")
            If res = DialogResult.Yes Then

                Dim list As PackingList = New PackingList
                If list.archivePackingList(txtIssueNo.Text) = True Then
                    MsgBox("Archive Success", vbOKOnly + vbInformation, "Success")
                Else
                    MsgBox("Archive failed", vbOKOnly + vbExclamation, "Failure")
                End If
            End If
            txtStatus.Text = (New PackingList).getStatus(txtIssueNo.Text)
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
        refreshPackingLists()
    End Sub

    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        If txtIssueNo.Text = "" Then
            MsgBox("Select a packing list to complete", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If
        Dim status As String = (New PackingList).getStatus(txtIssueNo.Text)
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
        txtAmountSold.Text = LCurrency.displayValue(Math.Round((Val(LCurrency.getValue(txtAmountSold.Text))), 2, MidpointRounding.AwayFromZero).ToString)

        Dim amountIssued As Double = Val(LCurrency.getValue(txtTotalAmountIssued.Text))
        Dim sales As Double = Val(LCurrency.getValue(txtTotalSales.Text))
        Dim returns As Double = Val(LCurrency.getValue(txtTotalReturns.Text))
        Dim damages As Double = Val(LCurrency.getValue(txtTotalDamages.Text))
        Dim discounts As Double = Val(LCurrency.getValue(txtTotalDiscounts.Text))
        Dim expenditures As Double = Val(LCurrency.getValue(txtTotalExpenses.Text))
        Dim bankCash As Double = Val(LCurrency.getValue(txtTotalBankDeposit.Text))
        Dim debt As Double = Val(LCurrency.getValue(txtDebt.Text))
        Dim costOfGoods As Double = Val(LCurrency.getValue(txtAmountSold.Text))


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


        Dim res As Integer = MsgBox("Complete transaction? Returned items will be returned to stock and sales will be registered to sales", vbYesNoCancel + vbQuestion, "Complete transaction")
        If Not res = DialogResult.Yes Then
            Exit Sub
        End If

        'now, post to sales, returns and complete document
        recordSale(txtIssueNo.Text)

        'record sales details with the specified sale id
        recordSaleDetails(saleId)

        For i As Integer = 0 To dtgrdItemList.RowCount - 1

            Dim itemCode As String = dtgrdItemList.Item(0, i).Value
            Dim qtyReturned As String = dtgrdItemList.Item(7, i).Value
            Dim qtyDamaged As String = dtgrdItemList.Item(8, i).Value
            Dim price As String = LCurrency.getValue(dtgrdItemList.Item(2, i).Value)
            'sql for recording sales
            Dim conn As New MySqlConnection(Database.conString)
            Try
                conn.Open()
                Dim command As New MySqlCommand()
                command.Connection = conn
                command.CommandText = "UPDATE `inventorys` SET `qty`=`qty`+'" + qtyReturned + "' WHERE `item_code`='" + itemCode + "'"
                command.Prepare()
                command.ExecuteNonQuery()
                conn.Close()
                Dim inventory As New Inventory
                Dim stockCard As New StockCard
                Dim damaged As New Damage
                If Val(qtyReturned) <> 0 Then
                    stockCard.qtyIn(Day.DAY, itemCode, qtyReturned, inventory.getInventory(itemCode), "Returned from packing List, Issue No: " + txtIssueNo.Text)
                End If
                If Val(qtyDamaged) <> 0 Then
                    Try
                        damaged.registerDamage(Day.DAY, itemCode, qtyDamaged, price, "Damaged in packing List, Issue No: " + txtIssueNo.Text)
                    Catch ex As Exception

                    End Try
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Next

        Dim list As PackingList = New PackingList
        list.GL_ISSUE_NO = txtIssueNo.Text
        list.GL_ISSUE_DATE = txtCreated.Text
        list.GL_STATUS = txtStatus.Text
        list.GL_SALES_PERSON = cmbSalesPersons.Text

        list.GL_AMOUNT_ISSUED = Val(LCurrency.getValue(txtTotalAmountIssued.Text))
        list.GL_TOTAL_RETURNS = Val(LCurrency.getValue(txtTotalReturns.Text))
        list.GL_TOTAL_DAMAGES = Val(LCurrency.getValue(txtTotalDamages.Text))
        list.GL_TOTAL_DISCOUNTS = Val(LCurrency.getValue(txtTotalDiscounts.Text))
        list.GL_TOTAL_EXPENDITURES = Val(LCurrency.getValue(txtTotalExpenses.Text))
        list.GL_TOTAL_BANK_CASH = Val(LCurrency.getValue(txtTotalBankDeposit.Text))
        list.GL_DEBT = Val(LCurrency.getValue(txtDebt.Text))
        list.GL_COST_OF_GOODS_SOLD = Val(LCurrency.getValue(txtAmountSold.Text))

        If list.completePackingList(txtIssueNo.Text) = True Then
            list.editPackingList(txtIssueNo.Text)
            list.getPackingList(txtIssueNo.Text)
            MsgBox("Process Success", vbOKOnly + vbInformation, "Success")
        Else
            MsgBox("Process failed", vbOKOnly + vbExclamation, "Failure")
        End If
    End Sub

    Dim saleId As String = ""


    Private Function recordSale(receiptNo As String)
        Dim recorded As Boolean = False
        Dim tillNO As String = "PCKLIST" 'Till.TILLNO
        Dim dayDate As String = txtCreated.Text
        Dim dateTime As DateTime = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
        'Dim total As Double = LCurrency.getValue(txtTotal.Text)
        Dim discount As Double = txtTotalDiscounts.Text
        'Dim vat As Double = LCurrency.getValue(txtVAT.Text)
        Dim amount As Double = Val(LCurrency.getValue(txtTotalAmountIssued.Text)) - Val(LCurrency.getValue(txtTotalReturns.Text)) - Val(LCurrency.getValue(txtTotalDamages.Text))


        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            Dim command As New MySqlCommand()
            command.Connection = conn
            command.CommandText = "INSERT INTO `sale`( `till_no`,`user_id`,`date`, `date_time`, `amount`, `discount`, `vat`,`tax_return`) VALUES (@till_no,@user_id,@date,@date_time,@amount,@discount,@vat,@tax_return)"
            command.Prepare()
            command.Parameters.AddWithValue("@till_no", tillNO)
            command.Parameters.AddWithValue("@user_id", User.CURRENT_USER_ID)
            command.Parameters.AddWithValue("@date_time", dateTime)
            command.Parameters.AddWithValue("@date", dayDate)
            command.Parameters.AddWithValue("@amount", amount)
            command.Parameters.AddWithValue("@discount", discount)
            command.Parameters.AddWithValue("@vat", 0)
            command.Parameters.AddWithValue("@tax_return", 0)
            command.ExecuteNonQuery()
            Dim sn As String = command.InsertId.ToString
            recorded = True
            saleId = "BL" + command.InsertId.ToString

            conn.Close()
            conn.Open()
            command.CommandText = "UPDATE `sale` SET `id`='" + saleId + "' WHERE `sn`='" + sn + "'"
            command.Prepare()
            command.ExecuteNonQuery()
            recorded = True
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return vbNull
            Exit Function
        End Try
        Try
            conn.Open()
            Dim command As New MySqlCommand()
            command.Connection = conn
            command.CommandText = "INSERT INTO `receipt`( `bill_no`, `till_no`, `receipt_no`, `date`) VALUES (@id,@till_no,@receipt_no,@date)"
            command.Prepare()
            command.Parameters.AddWithValue("@id", saleId)
            command.Parameters.AddWithValue("@till_no", tillNO)
            command.Parameters.AddWithValue("@receipt_no", receiptNo)
            command.Parameters.AddWithValue("@date", dayDate)
            command.ExecuteNonQuery()
            recorded = True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return vbNull
            Exit Function
        End Try
        Return recorded
    End Function

    Private Function recordSaleDetails(salesId As String)
        Dim recorded As Boolean = False
        'totalTaxReturns = 0

        For i As Integer = 0 To dtgrdItemList.RowCount - 1

            Dim itemCode As String = dtgrdItemList.Item(0, i).Value
            Dim description As String = dtgrdItemList.Item(1, i).Value
            Dim price As String = LCurrency.getValue(dtgrdItemList.Item(2, i).Value)
            Dim vat As String = 0 'dtgrdItemList.Item(5, i).Value
            Dim discount As String = 0 'dtgrdItemList.Item(6, i).Value
            Dim qty As String = dtgrdItemList.Item(6, i).Value
            Dim amount As String = Val(price) * Val(qty)
            Dim discountedPrice As Double = Val(price)
            Dim actualVat As Double = 0 'Val(qty) * discountedPrice * Val(vat) / 100
            Dim taxReturn As Double = 0 'Val(qty) * (discountedPrice - Item.getCostPrice(itemCode)) * Val(vat) / 100
            'totalTaxReturns = totalTaxReturns + taxReturn
            '  Dim cPrice As String = dtgrdItemList.Item(10, i).Value

            'sql for recording sales
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            If Val(qty) <= 0 Then
                Continue For
            End If
            Try
                conn.Open()
                command.Connection = conn
                command.CommandText = "INSERT INTO `sale_details`(`sale_id`, `item_code`, `selling_price`, `discounted_price`, `qty`, `amount`, `vat`,`tax_return`) VALUES (@sale_id,@item_code,@selling_price,@discounted_price,@qty,@amount,@vat,@tax_return)"
                command.Prepare()
                command.Parameters.AddWithValue("@sale_id", salesId)
                command.Parameters.AddWithValue("@item_code", itemCode)
                command.Parameters.AddWithValue("@selling_price", price)
                command.Parameters.AddWithValue("@discounted_price", discountedPrice)
                command.Parameters.AddWithValue("@qty", Val(qty))
                command.Parameters.AddWithValue("@amount", LCurrency.getValue(amount))
                command.Parameters.AddWithValue("@vat", actualVat)
                command.Parameters.AddWithValue("@tax_return", taxReturn)
                command.ExecuteNonQuery()
                conn.Close()
                recorded = True
            Catch ex As Exception
                MsgBox(ex.ToString)
                recorded = False
                Return vbNull
                Exit Function
            End Try
        Next
        Return recorded
    End Function

    Private Function increaseInventory(ref As String)
        For i As Integer = 0 To dtgrdItemList.RowCount - 1
            If dtgrdItemList.Item(9, i).Value = False Then
                Dim itemCode As String = dtgrdItemList.Item(1, i).Value
                Dim qty As String = dtgrdItemList.Item(7, i).Value
                'sql for updating inventory
                Dim conn As New MySqlConnection(Database.conString)
                Try
                    conn.Open()
                    Dim command As New MySqlCommand()
                    command.Connection = conn
                    command.CommandText = "UPDATE `inventorys` SET `qty`=`qty`-'" + qty + "' WHERE `item_code`='" + itemCode + "'"
                    command.Prepare()
                    command.ExecuteNonQuery()
                    conn.Close()
                    Dim inventory As New Inventory
                    Dim stockCard As New StockCard
                    stockCard.qtyOut(Day.DAY, itemCode, qty, inventory.getInventory(itemCode), "Product Sale, " + ref)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    Return vbNull
                    Exit Function
                End Try
            End If
        Next
        Return vbNull
    End Function

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
                dtgrdCell.Value = "Status: " + packingList.status + " S/M Officer: " + packingList.salesPerson.personnel.alias
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdPackingLists.Rows.Add(dtgrdRow)

            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Exit Sub

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id`, `issue_no`, `issue_date`, `status`, `sales_person_id`, `amount_issued`, `total_returns`, `total_damages`, `total_discounts`, `total_expenditures`, `total_bank_cash`, `debt`, `user_id`, `float_amount` FROM `packing_list` WHERE `status`='PENDING' OR `status`='APPROVED' OR `status`='PRINTED' OR `status`='COMPLETED'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim issueNo As String = ""
            Dim issueDate As String = ""
            Dim status As String = ""
            Dim salesPerson As String = ""

            While reader.Read
                Dim item As New Item
                issueNo = reader.GetString("issue_no")
                issueDate = reader.GetString("issue_date")
                status = reader.GetString("status")
                salesPerson = (New PackingList).getSalesPersonName(reader.GetString("sales_person_id"))

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = issueNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = issueDate
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = "Status: " + status + " S/M Officer: " + salesPerson
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdPackingLists.Rows.Add(dtgrdRow)

            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtgrdPackingLists_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdPackingLists.CellClick
        Dim r As Integer = dtgrdPackingLists.CurrentRow.Index
        Dim issueNo As String = dtgrdPackingLists.Item(0, r).Value.ToString
        txtIssueNo.Text = issueNo
        txtIssueNo.ReadOnly = False
        search()
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
        search()
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

    Private Sub txtQtyIssued_TextChanged(sender As Object, e As EventArgs) Handles txtTotalIssued.TextChanged
        If Not IsNumeric(txtTotalIssued.Text) Or txtTotalIssued.Text.Contains("-") Or Val(txtTotalIssued.Text) < 0 Then
            txtTotalIssued.Text = ""
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

    Private Sub dtgrdPackingLists_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdPackingLists.CellContentClick

    End Sub

    Dim report As String = False
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnPrintReport.Click
        Dim status As String = (New PackingList).getStatus(txtIssueNo.Text)
        report = True

        If 1 = 1 Then ' User.authorize("PRINT PACKING LIST") = True Then
            If txtIssueNo.Text = "" Then
                MsgBox("Select a packing list to print", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If



            If dtgrdItemList.RowCount = 0 Then
                MsgBox("Could not print an empty packing list", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            Dim list As PackingList = New PackingList


            'now do the actual printing in pdf

            Dim issueNo As String = txtIssueNo.Text
            If issueNo = "" Then
                MsgBox("Select a packing list to print.", vbOKOnly + vbCritical, "Error:No selection")
                Exit Sub
            End If
            If dtgrdItemList.RowCount = 0 Then
                MsgBox("Can not print an empty packing list. Please select the packing list to print", vbOKOnly + vbCritical, "Error: No selection")
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


            txtStatus.Text = (New PackingList).getStatus(txtIssueNo.Text)
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
        txtTotalIssued.Text = (Val(txtReturns.Text) + Val(txtPacked.Text)).ToString
    End Sub

    Private Sub txtPacked_TextChanged(sender As Object, e As EventArgs) Handles txtPacked.TextChanged
        If Val(txtPacked.Text) < 0 Then
            txtPacked.Text = ""
        End If
        If Not IsNumeric(txtPacked.Text) Then
            txtPacked.Text = ""
        End If
        If (txtPacked.Text).Contains("-") Then
            txtPacked.Text = ""
        End If
        txtTotalIssued.Text = (Val(txtReturns.Text) + Val(txtPacked.Text)).ToString
    End Sub

    Private Sub cmbDescription_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDescription.SelectedIndexChanged

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
        Dim res As Integer = MsgBox("Are you sure you want to archive all cleared packing list documents? All the cleared documents will be sent to archives for future reference.", vbQuestion + vbYesNo, "Archive all cleared packing lists")
        If res = DialogResult.Yes Then
            Dim noOfdocuments As Integer = 0
            Try
                Cursor = Cursors.WaitCursor
                For i As Integer = 0 To dtgrdPackingLists.RowCount - 1
                    Dim no As String = dtgrdPackingLists.Item(0, i).Value.ToString
                    Dim list As PackingList = New PackingList
                    Dim debt As Double = Val(list.getDebt(no))
                    Dim status As String = list.getStatus(no)
                    If debt = 0 And status = "COMPLETED" Then
                        noOfdocuments = noOfdocuments + 1
                    End If
                Next
                If noOfdocuments = 0 Then
                    MsgBox("No documents to archive, only completed and debt free documents can be arcived", vbOKOnly + vbExclamation, "No documents to archive")
                    Cursor = Cursors.Default
                    Exit Sub
                Else
                    Dim confirm As Integer = MsgBox(noOfdocuments.ToString + "  documents will be archived, continue?", vbYesNo + vbQuestion, "Concirm archive")
                    If Not confirm = DialogResult.Yes Then
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                MsgBox("Could not archive")
                Cursor = Cursors.Default
                Exit Sub
            End Try

            Try
                Cursor = Cursors.WaitCursor
                For i As Integer = 0 To dtgrdPackingLists.RowCount - 1
                    Dim no As String = dtgrdPackingLists.Item(0, i).Value.ToString
                    Dim list As PackingList = New PackingList
                    Dim debt As Double = Val(list.getDebt(no))
                    Dim status As String = list.getStatus(no)
                    If debt = 0 And status = "COMPLETED" Then
                        'archive
                        list.archivePackingList(no)
                    End If
                Next
                MsgBox(noOfdocuments.ToString + " document(s) archived successifuly")
            Catch ex As Exception
                '  MsgBox(ex.ToString)
            End Try
            refreshPackingLists()
            Cursor = Cursors.Default
        End If
    End Sub
End Class