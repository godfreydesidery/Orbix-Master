Imports Devart.Data.MySql
Imports Microsoft.Office.Interop
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering
Public Class frmProductionReport
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
        documentTitle.AddText("Daily Production Report")
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
        paragraph.AddFormattedText("From: " + dateStart.Text + " to :" + dateEnd.Text)
        paragraph.Format.Font.Size = 8

        paragraph = section.AddParagraph()
        paragraph.AddText("N/B: Prices listed according to current selling prices")
        paragraph.Format.Font.Size = 7



        'Add the print date field
        paragraph = section.AddParagraph()
        paragraph.Format.SpaceBefore = "1cm"
        paragraph.Style = "Reference"
        paragraph.AddTab()
        paragraph.AddText("Created: ")
        paragraph.AddDateField("dd.MM.yyyy")

        'Create the item table
        Dim table As Tables.Table = section.AddTable()
        table.Style = "Table"
        ' table.Borders.Color = TableBorder
        table.Borders.Width = 0.25
        table.Borders.Left.Width = 0.5
        table.Borders.Right.Width = 0.5
        table.Rows.LeftIndent = 0

        'Before you can add a row, you must define the columns
        Dim column As Tables.Column

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Left


        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("6cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Right


        'Create the header of the table
        Dim row As Tables.Row

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Font.Size = 8
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.LightGray
        row.Cells(0).AddParagraph("Date")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Code")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Description")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Qty")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph("Price")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph("Amount")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left



        table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalAmount As Double = 0
        Dim totalVat As Double = 0
        Dim totalDiscount As Double = 0


        For i As Integer = 0 To dtgrdList.RowCount - 1
            Dim _date As String = dtgrdList.Item(0, i).Value.ToString
            Dim code As String = dtgrdList.Item(1, i).Value.ToString
            Dim description As String = dtgrdList.Item(2, i).Value.ToString
            Dim qty As String = dtgrdList.Item(3, i).Value.ToString
            Dim price As String = dtgrdList.Item(4, i).Value.ToString
            Dim amount As String = dtgrdList.Item(5, i).Value.ToString


            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Font.Size = 8
            row.Height = "5mm"
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.LightGray
            row.Cells(0).AddParagraph(_date)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(code)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(description)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(qty)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Left
            row.Cells(4).AddParagraph(price)
            row.Cells(4).Format.Alignment = ParagraphAlignment.Right
            row.Cells(5).AddParagraph(amount)
            row.Cells(5).Format.Alignment = ParagraphAlignment.Right

            table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        Next
        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = False
        row.Format.Font.Size = 8
        row.Height = "5mm"
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.LightGray
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph("Total")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph(txtTotalAmount.Text)
        row.Cells(5).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()

    End Sub


    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        generate()
    End Sub
    Private Sub generate()
        list = ""
        For i As Integer = 0 To lstCode.Items.Count - 1
            list = list + "'" + lstCode.Items.Item(i) + "'"
            If i < lstCode.Items.Count - 1 Then
                list = list + ","
            End If
        Next
        refreshList()
    End Sub
    Private Function refreshList()
        Cursor = Cursors.WaitCursor
        dtgrdList.Rows.Clear()

        Dim totalSales As Double = 0
        Dim totalVat As Double = 0
        Dim totalProfit As Double = 0
        Dim totalAmount As Double = 0

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            ' Dim categoryId As String = (New Material).getCategoryIdByCategoryName(cmbCategory.Text)

            query = "SELECT 
                        `item_code`,
                        `date`, 
                        SUM(`qty`) AS `qty`
                    FROM 
	                    `item_production`
                    WHERE
                        `date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "'
                    GROUP BY 
                        `item_code`,`date`
                    ORDER BY
                        `date`
                    "


            If list <> "" Then
                query = "SELECT 
                        `item_code`,
                        `date`, 
                        SUM(`qty`) AS `qty`
                    FROM 
	                    `item_production`
                    WHERE
                        `date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "' AND `item_code` IN (" + list + ")
                    GROUP BY 
                        `item_code`,`date`
                    ORDER BY
                        `date`
                    "

            End If


            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim dtgrdRow As DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            Dim c_date As String = ""

            While reader.Read
                Dim itemCode As String = reader.GetString("item_code")
                Dim _date As String = reader.GetString("date")
                Dim qty As String = reader.GetString("qty")

                'If categoryId <> "" And categoryId = (New Material).getMaterialCategoryId(materialCode) Then
                'ElseIf categoryId <> "" And categoryId <> (New Material).getMaterialCategoryId(materialCode) Then
                'Continue While
                ' End If

                Dim price As String = (New Item).getItemPrice(itemCode)
                totalAmount = totalAmount + (Val(qty) * Val(price))

                dtgrdRow = New DataGridViewRow

                dtgrdCell = New DataGridViewTextBoxCell()
                If c_date = _date Then
                    dtgrdCell.Value = ""
                Else
                    dtgrdCell.Value = _date
                End If
                c_date = _date
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = itemCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = (New Item).getItemLongDescription(itemCode)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = qty
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(price)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue((Val(qty) * Val(price)).ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdList.Rows.Add(dtgrdRow)
            End While

            txtTotalAmount.Text = LCurrency.displayValue(totalAmount.ToString)

            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Cursor = Cursors.Arrow

        Return vbNull
    End Function
    Dim list As String = ""

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    ' Private Sub loadCategories()
    ' Dim conn As New MySqlConnection(Database.conString)
    'Try
    'Dim suppcommand As New MySqlCommand()
    '   Dim supplierQuery As String = "SELECT
    '                                               `id`,
    '                                              `category_name`
    '                                         FROM
    '                                             `material_categories`"
    '         conn.Open()
    '         suppcommand.CommandText = supplierQuery
    '         suppcommand.Connection = conn
    '        suppcommand.CommandType = CommandType.Text
    ' Dim reader As MySqlDataReader = suppcommand.ExecuteReader
    '          cmbCategory.Items.Clear()
    '          cmbCategory.Items.Add("")
    '  If reader.HasRows Then
    '  While reader.Read
    '                   cmbCategory.Items.Add(reader.GetString("category_name"))
    '              End While
    '  End If
    '          conn.Close()
    '  Catch ex As Devart.Data.MySql.MySqlException
    '          ErrorMessage.dbConnectionError()
    '  Exit Sub
    '  End Try
    '  End Sub

    Private Sub frmSalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim item As New Item
        longList = item.getItems()
        clearFields()
        dtgrdList.Rows.Clear()
        '   loadCategories()
    End Sub
    Dim longList As New List(Of String)
    Dim shortList As New List(Of String)
    Private Sub cmbDescription_KeyUp(sender As Object, e As EventArgs) Handles cmbMaterialName.KeyUp
        shortList.Clear()
        cmbMaterialName.Items.Clear()
        cmbMaterialName.DroppedDown = True
        For Each text As String In longList
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbMaterialName.Text.ToUpper()) Then
                shortList.Add(text)
            End If
        Next
        cmbMaterialName.Items.AddRange(shortList.ToArray())
        cmbMaterialName.SelectionStart = cmbMaterialName.Text.Length
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnSearchItem_Click(sender As Object, e As EventArgs) Handles btnSearchItem.Click
        Dim found As Boolean = False
        Dim valid As Boolean = False
        Dim itemCode As String = txtMaterialCode.Text
        Dim descr As String = cmbMaterialName.Text

        If itemCode <> "" Then
            itemCode = itemCode
        ElseIf descr <> "" Then
            itemCode = (New Item).getItemCode(descr)
        Else
            itemCode = ""
        End If

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "SELECT
                                        `item_code`,
                                        `item_long_description`,
                                        `retail_price`
                                    FROM 
                                        `items`
                                    WHERE 
                                        `item_code`='" + itemCode + "' "
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtMaterialCode.Text = reader.GetString("item_code")
                cmbMaterialName.Text = reader.GetString("item_long_description")
                found = True
                valid = True
                Exit While
            End While
            conn.Close()
            If found = False Then
                MsgBox("Item not found")
                btnAdd.Enabled = False
            Else
                btnAdd.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        lstCode.Items.Add(txtMaterialCode.Text)
        clearFields()
        btnAdd.Enabled = False
    End Sub
    Private Sub clearFields()
        txtMaterialCode.Text = ""
        cmbMaterialName.Text = ""
        txtTotalAmount.Text = ""

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lstCode.Items.Clear()
        cmbCategory.Text = ""
        dtgrdList.Rows.Clear()
        clearFields()

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnExportToPDF.Click
        generate()
        If dtgrdList.RowCount = 0 Then
            MsgBox("Nothing to print")
            Exit Sub
        End If

        Dim document As Document = New Document

        document.Info.Title = "Daily Production Report"
        document.Info.Subject = "Daily Production Report"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Daily Production Report " & dateStart.Text & dateEnd.Text & cmbCategory.Text & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnExportToExcel.Click
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

        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "Daily Production Report"

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
        r = r + 1
        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "Category: " + cmbCategory.Text


        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A" + r.ToString)
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        r = r + 2
        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "Date"
        shXL.Cells(r, 2).Value = "Code"
        shXL.Cells(r, 3).Value = "Description"
        shXL.Cells(r, 4).Value = "Qty"
        shXL.Cells(r, 5).Value = "Price"
        shXL.Cells(r, 6).Value = "Amount"
        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A" + r.ToString, "F" + r.ToString)
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
                .Cells(r, 5).Value = dtgrdList.Item(4, i).Value
                .Cells(r, 6).Value = dtgrdList.Item(5, i).Value
            End With
            r = r + 1
        Next
        ' Add table headers going cell by cell.
        shXL.Cells(r, 5).Value = "Total"
        shXL.Cells(r, 6).Value = txtTotalAmount.Text

        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A" + r.ToString, "F" + r.ToString)
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With


        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "F1")
        raXL.EntireColumn.AutoFit()
        Dim strFileName As String = LSystem.saveToDesktop & "\Daily Production Report " & dateStart.Text & dateEnd.Text & ".xls"
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

        'appXL.Workbooks.Open(strFileName)
        Exit Sub
Err_Handler:
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

    End Sub
End Class