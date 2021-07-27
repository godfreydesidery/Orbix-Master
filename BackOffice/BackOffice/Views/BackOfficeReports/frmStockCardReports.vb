Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmStockCardReports

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub frmStockCardReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSupplier.Items.Clear()
        dtgrdList.Rows.Clear()
        Dim item As New Item
        longList = item.getItems()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = ""
            query = "SELECT`supplier_name` FROM `supplier` "
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                cmbSupplier.Items.Add(reader.GetString("supplier_name"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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
    Private Function print()


        Dim document As Document = New Document

        document.Info.Title = "Stock Card Report"
        document.Info.Subject = "Stock Card Report"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Stock Card Report" & dateStart.Text & " to " & dateEnd.Text & " .pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)




        Return vbNull
    End Function
    Private Function printWithoutProfit()


        Dim document As Document = New Document

        document.Info.Title = "Stock Card Report"
        document.Info.Subject = "Stock Card Report"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Stock Card Report" & dateStart.Text & " to " & dateEnd.Text & " .pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)




        Return vbNull
    End Function
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
        documentTitle.AddText("Stock Cards Report")
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
        paragraph.AddFormattedText("From:  " + dateStart.Text + "  To:  " + dateEnd.Text)
        paragraph.Format.Alignment = ParagraphAlignment.Left
        paragraph.Format.Font.Size = 8
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

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("5.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left


        column = table.AddColumn("6.0cm")
        column.Format.Alignment = ParagraphAlignment.Left



        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.HeadingFormat = True
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Format.Font.Size = 8
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Date")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Item Code")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Description")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("In")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph("Out")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph("Balance")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(6).AddParagraph("Reference")
        row.Cells(6).Format.Alignment = ParagraphAlignment.Left


        table.SetEdge(0, 0, 7, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalQty As Double = 0

        For i As Integer = 0 To dtgrdList.RowCount - 1

            Dim date_ As String = dtgrdList.Item(0, i).Value
            Dim itemCode As String = dtgrdList.Item(1, i).Value
            Dim description As String = dtgrdList.Item(2, i).Value
            Dim qtyIn As String = dtgrdList.Item(3, i).Value
            Dim qtyOut As String = dtgrdList.Item(4, i).Value
            Dim balance As String = dtgrdList.Item(5, i).Value
            Dim reference As String = dtgrdList.Item(6, i).Value


            row = table.AddRow()
            row.Format.Font.Size = 8
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.White
            row.Cells(0).AddParagraph(date_)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(itemCode)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(description)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(qtyIn)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Left
            row.Cells(4).AddParagraph(qtyOut)
            row.Cells(4).Format.Alignment = ParagraphAlignment.Left
            row.Cells(5).AddParagraph(balance)
            row.Cells(5).Format.Alignment = ParagraphAlignment.Left
            row.Cells(6).AddParagraph(reference)
            row.Cells(6).Format.Alignment = ParagraphAlignment.Left


            table.SetEdge(0, 0, 7, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Next

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Format.Font.Size = 8
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph()
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph()
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph()
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph()
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph()
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph()
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(6).AddParagraph()
        row.Cells(6).Format.Alignment = ParagraphAlignment.Left


        paragraph = section.AddParagraph()


        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("***End of Report***")
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9

    End Sub

    Private Function refreshList()
        dtgrdList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "SELECT `stock_cards`.`date` as `date`,`stock_cards`.`item_code` AS `item_code`,`stock_cards`.`qty_in` AS `qty_in`,`stock_cards`.`qty_out` AS `qty_out`,`stock_cards`.`balance` AS `balance`,`stock_cards`.`reference` AS `reference` FROM `stock_cards` WHERE `stock_cards`.`date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "'"

            'query = "SELECT `stock_cards`.`date` as `date`,`stock_cards`.`item_code` AS `item_code`,`stock_cards`.`qty_in` AS `qty_in`,`stock_cards`.`qty_out` AS `qty_out`,`stock_cards`.`balance` AS `balance`,`stock_cards`.`reference` AS `reference` FROM `stock_cards` WHERE `stock_cards`.`date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "'"

            If list <> "" Then
                query = "SELECT `stock_cards`.`date` as `date`,`stock_cards`.`item_code` AS `item_code`,`stock_cards`.`qty_in` AS `qty_in`,`stock_cards`.`qty_out` AS `qty_out`,`stock_cards`.`balance` AS `balance`,`stock_cards`.`reference` AS `reference` FROM `stock_cards` WHERE `stock_cards`.`date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "' AND `item_code` IN (" + list + ")"
                'query = "SELECT `sale`.`date` as `date`,`sale_details`.`item_code` AS `item_code`,SUM((`sale_details`.`selling_price`-`sale_details`.`discounted_price`)*`sale_details`.`qty`) AS `discount`,`sale_details`.`selling_price`AS `price`,SUM(`sale_details`.`qty`) AS `qty`,SUM(`sale_details`.`tax_return`) AS `tax`,SUM(`sale_details`.`amount`) AS `amount` FROM `sale`,`sale_details` WHERE `sale`.`id`=`sale_details`.`sale_id` AND `sale`.`date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "' AND `item_code` IN (" + list + ") GROUP BY `item_code`,`date`,`price`,`price` ORDER BY `amount` DESC"
            End If

            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim total As Double = 0
            Dim totalVat As Double = 0
            Dim totalDiscount As Double = 0
            Dim totalProfit As Double = 0



            While reader.Read
                Dim date_ As String = reader.GetString("date")
                Dim itemCode As String = reader.GetString("item_code")
                Dim description As String = (New Item).getItemLongDescription(itemCode)
                Dim qtyIn As String = reader.GetString("qty_in")
                Dim qtyOut As String = reader.GetString("qty_out")
                Dim balance As String = reader.GetString("balance")
                Dim reference As String = reader.GetString("reference")

                'Item.searchItem(itemCode)


                If cmbSupplier.Text <> "" Then
                    If cmbSupplier.Text <> (New Supplier).getSupplierName((New Item).getSupplierId("", "", itemCode), "") Then
                        Continue While
                    Else

                    End If
                End If






                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = date_
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = itemCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = description
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = qtyIn
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = qtyOut
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = balance
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reference
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdList.Rows.Add(dtgrdRow)
            End While

            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function
    Dim list As String = ""

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        list = ""
        For i As Integer = 0 To lstCode.Items.Count - 1
            list = list + "'" + lstCode.Items.Item(i) + "'"
            If i < lstCode.Items.Count - 1 Then
                list = list + ","
            End If
        Next
        refreshList()

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs)
        print()
    End Sub

    Private Sub txtTotal_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtTotalDiscount_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtTotalVAT_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSupplier.SelectedIndexChanged
        clearFields()
        lstCode.Items.Clear()
    End Sub

    Private Sub btnPrintWithProfit_Click(sender As Object, e As EventArgs) Handles btnExportToPDF.Click
        printWithoutProfit()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Private Sub searchItem()
        Dim found As Boolean = False
        Dim valid As Boolean = False
        Dim barCode As String = txtBarCode.Text
        Dim itemCode As String = txtItemCodeS.Text
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
            Dim codeQuery As String = "SELECT `item_code`, `item_long_description`, `pck`,`unit_cost_price`, `retail_price`,`vat`, `margin`, `standard_uom`, `active` FROM `items` WHERE `item_code`='" + itemCode + "' "
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtItemCodeS.Text = reader.GetString("item_code")
                cmbDescription.Text = reader.GetString("item_long_description")

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

    Private Sub btnSearchItem_Click(sender As Object, e As EventArgs) Handles btnSearchItem.Click
        searchItem()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        lstCode.Items.Add(txtItemCodeS.Text)
        clearFields()
        btnAdd.Enabled = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lstCode.Items.Clear()
        cmbSupplier.Text = ""
        dtgrdList.Rows.Clear()
        clearFields()
    End Sub
    Private Sub clearFields()
        txtItemCodeS.Text = ""
        txtBarCode.Text = ""
        cmbDescription.SelectedItem = Nothing
        cmbDescription.Text = ""
    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub txtBarCode_TextChanged(sender As Object, e As EventArgs) Handles txtBarCode.TextChanged

    End Sub
    Private Sub txtBarCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            searchItem()
        End If
    End Sub
    Private Sub txtitemcodes_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemCodeS.KeyDown
        If e.KeyCode = Keys.Enter Then
            searchItem()
        End If
    End Sub
    Private Sub txtdescription_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            searchItem()
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
End Class