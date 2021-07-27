Imports Devart.Data.MySql
Imports Microsoft.Office.Interop
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering
Public Class frmMaterialVsProduction
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
        documentTitle.AddText("Material vs Production Report")
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


        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("4.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left


        column = table.AddColumn("4.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.0cm")
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
        row.Cells(1).AddParagraph("Mat Code")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Material Descr")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("UOM")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph("Qty")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph("Item Code")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(6).AddParagraph("Item Descr")
        row.Cells(6).Format.Alignment = ParagraphAlignment.Left
        row.Cells(7).AddParagraph("UOM")
        row.Cells(7).Format.Alignment = ParagraphAlignment.Left
        row.Cells(8).AddParagraph("Qty")
        row.Cells(8).Format.Alignment = ParagraphAlignment.Left



        table.SetEdge(0, 0, 9, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalAmount As Double = 0
        Dim totalVat As Double = 0
        Dim totalDiscount As Double = 0


        For i As Integer = 0 To dtgrdList.RowCount - 1
            Dim _date As String = dtgrdList.Item(0, i).Value.ToString
            Dim materialCode As String = dtgrdList.Item(1, i).Value.ToString
            Dim materialDescription As String = dtgrdList.Item(2, i).Value.ToString
            Dim materialUom As String = dtgrdList.Item(3, i).Value.ToString
            Dim materialQty As String = dtgrdList.Item(4, i).Value.ToString
            Dim itemCode As String = dtgrdList.Item(5, i).Value.ToString
            Dim itemDescription As String = dtgrdList.Item(6, i).Value.ToString
            Dim itemUom As String = dtgrdList.Item(7, i).Value.ToString
            Dim itemQty As String = dtgrdList.Item(8, i).Value.ToString

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Font.Size = 8
            row.Height = "5mm"
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.LightGray
            row.Cells(0).AddParagraph(_date)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(materialCode)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(materialDescription)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(materialUom)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Left
            row.Cells(4).AddParagraph(materialQty)
            row.Cells(4).Format.Alignment = ParagraphAlignment.Left
            row.Cells(5).AddParagraph(itemCode)
            row.Cells(5).Format.Alignment = ParagraphAlignment.Left
            row.Cells(6).AddParagraph(itemDescription)
            row.Cells(6).Format.Alignment = ParagraphAlignment.Left
            row.Cells(7).AddParagraph(itemUom)
            row.Cells(7).Format.Alignment = ParagraphAlignment.Left
            row.Cells(8).AddParagraph(itemQty)
            row.Cells(8).Format.Alignment = ParagraphAlignment.Left

            table.SetEdge(0, 0, 9, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        Next
        table.SetEdge(0, 0, 9, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
    End Sub


    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        generate()
    End Sub
    Private Sub generate()
        refreshList()
    End Sub
    Private Function refreshList()
        Cursor = Cursors.WaitCursor
        dtgrdList.Rows.Clear()

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            Dim itemQuery As String = ""

            ' Dim categoryId As String = (New Material).getCategoryIdByCategoryName(cmbCategory.Text)


            query = "SELECT
                        `material_usage`.`material_code` AS `material_code`, 
                        `item_production`.`date` AS `date`, 
                        SUM(`material_usage`.`qty`) AS `material_qty`, 
                        `item_production`.`item_code` AS `item_code`,
                        SUM(`item_production`.`qty`) AS `item_qty` 
                    FROM
                       `material_usage`         
                    INNER JOIN 
                        `item_production` 
                    ON
                        `item_production`.`date`=`material_usage`.`date` AND (`item_production`.`date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "') AND (`material_usage`.`date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "')
                    GROUP BY `date`, `material_code`,`item_code`
                    ORDER BY 
                        `date`"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim dtgrdRow As DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            While reader.Read

                dtgrdRow = New DataGridViewRow

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = ""
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = ""
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = ""
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = ""
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = ""
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = ""
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = ""
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = ""
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = ""
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdList.Rows.Add(dtgrdRow)
            End While

            conn.Close()

            Dim conn2 As New MySqlConnection(Database.conString)
            Dim command2 As New MySqlCommand()
            conn2.Open()
            command2.CommandText = query
            command2.Connection = conn2
            command2.CommandType = CommandType.Text
            Dim reader2 As MySqlDataReader = command2.ExecuteReader()

            Dim dates As Integer = 0
            Dim materials As Integer = 0
            Dim items As Integer = 0

            Dim c_date As String = ""
            Dim cmaterialCode As String = ""
            Dim cmaterialqty As String = ""
            Dim citemCode As String = ""
            Dim citemQty As String = ""

            Dim r As Integer = 0

            Dim rdate As Integer = 0
            Dim rmaterial As Integer = 0
            Dim ritem As Integer = 0

            Dim materialCodes As New List(Of String)
            Dim itemCodes As New List(Of String)

            While reader2.Read
                Dim _date As String = reader2.GetString("date")
                Dim materialCode As String = reader2.GetString("material_code")
                Dim materialqty As String = reader2.GetString("material_qty")
                Dim itemCode As String = reader2.GetString("item_code")
                Dim itemQty As String = reader2.GetString("item_qty")


                If c_date = _date Then
                    dtgrdList.Item(0, rdate).Value = ""
                    If materialCodes.Contains(materialCode) Then
                        dtgrdList.Item(1, rmaterial).Value = ""
                        dtgrdList.Item(2, rmaterial).Value = ""
                        dtgrdList.Item(3, rmaterial).Value = ""
                        dtgrdList.Item(4, rmaterial).Value = ""
                    Else
                        materialCodes.Add(materialCode)
                        dtgrdList.Item(1, rmaterial).Value = materialCode
                        dtgrdList.Item(2, rmaterial).Value = (New Material).getDescription(materialCode)
                        dtgrdList.Item(3, rmaterial).Value = (New Material).getUom(materialCode)
                        dtgrdList.Item(4, rmaterial).Value = materialqty
                        rmaterial = rmaterial + 1
                    End If
                    If itemCodes.Contains(itemCode) Then
                        dtgrdList.Item(5, ritem).Value = ""
                        dtgrdList.Item(6, ritem).Value = ""
                        dtgrdList.Item(7, ritem).Value = ""
                        dtgrdList.Item(8, ritem).Value = ""
                    Else
                        itemCodes.Add(itemCode)
                        dtgrdList.Item(5, ritem).Value = itemCode
                        dtgrdList.Item(6, ritem).Value = (New Item).getItemLongDescription(itemCode)
                        dtgrdList.Item(7, ritem).Value = (New Item).getUom(itemCode)
                        dtgrdList.Item(8, ritem).Value = itemQty
                        ritem = ritem + 1
                    End If
                Else
                    dtgrdList.Item(0, rdate).Value = _date
                    materialCodes.Clear()
                    itemCodes.Clear()
                    rmaterial = r
                    ritem = r
                End If
                rdate = rdate + 1
                c_date = _date
                r = r + 1
            End While
            conn2.Close()

            Dim count As Integer = dtgrdList.RowCount - 1
            While count >= 0
                If dtgrdList.Item(0, count).Value = "" And dtgrdList.Item(1, count).Value = "" And dtgrdList.Item(5, count).Value = "" Then
                    dtgrdList.Rows.RemoveAt(count)
                End If
                count = count - 1
            End While


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Cursor = Cursors.Arrow

        Return vbNull
    End Function
    Dim list As String = ""

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnExportToPDF.Click
        generate()
        If dtgrdList.RowCount = 0 Then
            MsgBox("Nothing to print")
            Exit Sub
        End If

        Dim document As Document = New Document

        document.Info.Title = "Material vs Production Report"
        document.Info.Subject = "Material vs Production Report"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Material vs Production Report " & dateStart.Text & dateEnd.Text & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)
    End Sub

    Private Sub btnExportToExcel_Click(sender As Object, e As EventArgs) Handles btnExportToExcel.Click
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
        shXL.Cells(r, 1).Value = "Materials vs Production Report"

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

        r = r + 2
        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "Date"
        shXL.Cells(r, 2).Value = "Material Code"
        shXL.Cells(r, 3).Value = "Material Description"
        shXL.Cells(r, 4).Value = "UOM"
        shXL.Cells(r, 5).Value = "Qty"
        shXL.Cells(r, 6).Value = "Item Code"
        shXL.Cells(r, 7).Value = "Item Description"
        shXL.Cells(r, 8).Value = "UOM"
        shXL.Cells(r, 9).Value = "Qty"

        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A" + r.ToString, "I" + r.ToString)
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
                .Cells(r, 7).Value = dtgrdList.Item(6, i).Value
                .Cells(r, 8).Value = dtgrdList.Item(7, i).Value
                .Cells(r, 9).Value = dtgrdList.Item(8, i).Value
            End With
            r = r + 1
        Next

        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "I1")
        raXL.EntireColumn.AutoFit()
        Dim strFileName As String = LSystem.saveToDesktop & "\Material vs Production Report " & dateStart.Text & dateEnd.Text & ".xls"
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

    Private Sub frmMaterialVsProduction_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class