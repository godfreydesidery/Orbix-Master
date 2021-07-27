Imports Devart.Data.MySql
Imports Microsoft.Office.Interop
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmDailySummarySalesReport
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
        documentTitle.AddText("Summarized Daily Sales Report")
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
        paragraph.AddFormattedText("From: " + dateStart.Text + " to :" + dateEnd.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("S/M Officer:       " + cmbSalesPersons.Text)
        paragraph.Format.Font.Size = 8

        'Add the print date field
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()

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

        column = table.AddColumn("6.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("2.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        'Create the header of the table
        Dim row As Tables.Row

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Font.Size = 9
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.LightGray
        row.Cells(0).AddParagraph("Item Code")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Description")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Qty")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Amount")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left

        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalAmount As Double = 0
        Dim totalVat As Double = 0
        Dim totalDiscount As Double = 0


        For i As Integer = 0 To dtgrdList.RowCount - 1
            Dim code As String = dtgrdList.Item(0, i).Value.ToString
            Dim description As String = dtgrdList.Item(1, i).Value.ToString
            Dim qty As String = dtgrdList.Item(2, i).Value.ToString
            Dim amount As String = dtgrdList.Item(3, i).Value.ToString

            totalAmount = totalAmount + Val(LCurrency.getValue(amount))

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Font.Size = 9
            row.Height = "5mm"
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.LightGray
            row.Cells(0).AddParagraph(code)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(description)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(qty)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(amount)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Right

            table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        Next
        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = False
        row.Format.Font.Size = 9
        row.Height = "5mm"
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.LightGray
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Total")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph(LCurrency.displayValue(totalAmount.ToString))
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()

        'Create the item table
        Dim table2 As Table = section.AddTable()
        table2.Style = "Table"
        ' table.Borders.Color = TableBorder
        table2.Borders.Width = 0.25
        table2.Borders.Left.Width = 0.5
        table2.Borders.Right.Width = 0.5
        table2.Rows.LeftIndent = 0

        'Before you can add a row, you must define the columns
        Dim column2 As Column

        column2 = table2.AddColumn("2cm")
        column2.Format.Alignment = ParagraphAlignment.Left


        column2 = table2.AddColumn("3.5cm")
        column2.Format.Alignment = ParagraphAlignment.Left

        column2 = table2.AddColumn("2cm")
        column2.Format.Alignment = ParagraphAlignment.Right

        column2 = table2.AddColumn("3.5cm")
        column2.Format.Alignment = ParagraphAlignment.Right

        column2 = table2.AddColumn("2.5cm")
        column2.Format.Alignment = ParagraphAlignment.Right

        column2 = table2.AddColumn("3.0cm")
        column2.Format.Alignment = ParagraphAlignment.Right



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

        column3 = table3.AddColumn("3.5cm")
        column3.Format.Alignment = ParagraphAlignment.Left


        column3 = table3.AddColumn("3cm")
        column3.Format.Alignment = ParagraphAlignment.Left

        'Create the header of the table
        Dim row3 As Row

        row3 = table3.AddRow()
        row3.Format.Font.Bold = False
        row3.HeadingFormat = True
        row3.Format.Font.Size = 9
        row3.Format.Alignment = ParagraphAlignment.Center
        row3.Borders.Color = Colors.White
        row3.Cells(0).AddParagraph("Total Issued")
        row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row3.Cells(1).AddParagraph(txtTotalIssued.Text)
        row3.Cells(1).Format.Alignment = ParagraphAlignment.Right

        table3.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row3 = table3.AddRow()
        row3.Format.Font.Bold = False
        row3.HeadingFormat = True
        row3.Format.Font.Size = 9
        row3.Format.Alignment = ParagraphAlignment.Center
        row3.Borders.Color = Colors.White
        row3.Cells(0).AddParagraph("Total Sales")
        row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row3.Cells(1).AddParagraph(txtTotal.Text)
        row3.Cells(1).Format.Alignment = ParagraphAlignment.Right

        table3.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row3 = table3.AddRow()
        row3.Format.Font.Bold = False
        row3.HeadingFormat = True
        row3.Format.Font.Size = 9
        row3.Format.Alignment = ParagraphAlignment.Center
        row3.Borders.Color = Colors.White
        row3.Cells(0).AddParagraph("Discount")
        row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row3.Cells(1).AddParagraph(txtTotalDiscount.Text)
        row3.Cells(1).Format.Alignment = ParagraphAlignment.Right

        table3.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row3 = table3.AddRow()
        row3.Format.Font.Bold = False
        row3.HeadingFormat = True
        row3.Format.Font.Size = 9
        row3.Format.Alignment = ParagraphAlignment.Center
        row3.Borders.Color = Colors.White
        row3.Cells(0).AddParagraph("Net Sales")
        row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row3.Cells(1).AddParagraph(txtNetSales.Text)

        row3.Cells(1).Format.Alignment = ParagraphAlignment.Right

        table3.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row3 = table3.AddRow()
        row3.Format.Font.Bold = False
        row3.HeadingFormat = True
        row3.Format.Font.Size = 9
        row3.Format.Alignment = ParagraphAlignment.Center
        row3.Borders.Color = Colors.White
        row3.Cells(0).AddParagraph("Total Expenses")
        row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row3.Cells(1).AddParagraph(txtTotalExpenditures.Text)

        row3.Cells(1).Format.Alignment = ParagraphAlignment.Right

        table3.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row3 = table3.AddRow()
        row3.Format.Font.Bold = False
        row3.HeadingFormat = True
        row3.Format.Font.Size = 9
        row3.Format.Alignment = ParagraphAlignment.Center
        row3.Borders.Color = Colors.White
        row3.Cells(0).AddParagraph("Bank& Cash Deposit")
        row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row3.Cells(1).AddParagraph(txtTotalBankcash.Text)

        row3.Cells(1).Format.Alignment = ParagraphAlignment.Right

        table3.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row3 = table3.AddRow()
        row3.Format.Font.Bold = False
        row3.HeadingFormat = True
        row3.Format.Font.Size = 9
        row3.Format.Alignment = ParagraphAlignment.Center
        row3.Borders.Color = Colors.White
        row3.Cells(0).AddParagraph("Deficit/ Debt")
        row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row3.Cells(1).AddParagraph(txtDebt.Text)
        row3.Cells(1).Format.Alignment = ParagraphAlignment.Right

        table3.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

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

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""

            query = "SELECT
                        `packing_list`.`issue_date` AS `issue_date`, 
                        `packing_list`.`status` AS `status`,
                        `packing_list_details`.`item_code` AS `item_code`,
                        `packing_list_details`.`description` AS `description`,
                        SUM(`packing_list_details`.`qty_sold`) AS `qty_sold`,
                        SUM(`packing_list_details`.`price`*`packing_list_details`.`qty_sold`) AS `amount`,
                        SUM(`packing_list_details`.`cprice`*`packing_list_details`.`qty_sold`) AS `camount`
                    FROM 
                        `packing_list`, `packing_list_details` 
                    WHERE 
                        `packing_list`.`issue_no`=`packing_list_details`.`issue_no` AND (`status`='COMPLETED' OR `status`='ARCHIVED')AND `issue_date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "' AND `qty_sold` > '0'
                    
                    GROUP BY 
                        `item_code`"




            If list <> "" And cmbSalesPersons.Text = "" Then
                query = "SELECT
                       `packing_list`.`issue_date` AS `issue_date`, 
                        `packing_list`.`status` AS `status`,
                        `packing_list_details`.`item_code` AS `item_code`,
                        `packing_list_details`.`description` AS `description`,
                        SUM(`packing_list_details`.`qty_sold`) AS `qty_sold`,
                        SUM(`packing_list_details`.`price`*`packing_list_details`.`qty_sold`) AS `amount`,
                        SUM(`packing_list_details`.`cprice`*`packing_list_details`.`qty_sold`) AS `camount`
                    FROM 
                        `packing_list`, `packing_list_details` 
                    WHERE 
                        `packing_list`.`issue_no`=`packing_list_details`.`issue_no` AND (`status`='COMPLETED' OR `status`='ARCHIVED')AND `issue_date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "' AND `item_code` IN (" + list + ") AND `qty_sold` > '0'
                   
                     GROUP BY 
                        `item_code`"
            End If

            If list <> "" And cmbSalesPersons.Text <> "" Then
                Dim salesPersonId As String = (New PackingList).getSalesPersonId(cmbSalesPersons.Text)

                query = "SELECT
                        `packing_list`.`issue_date` AS `issue_date`, 
                        `packing_list`.`status` AS `status`,
                        `packing_list_details`.`item_code` AS `item_code`,
                        `packing_list_details`.`description` AS `description`,
                        SUM(`packing_list_details`.`qty_sold`) AS `qty_sold`,
                        SUM(`packing_list_details`.`price`*`packing_list_details`.`qty_sold`) AS `amount`,
                        SUM(`packing_list_details`.`cprice`*`packing_list_details`.`qty_sold`) AS `camount`
                    FROM 
                        `packing_list`, `packing_list_details` 
                    WHERE 
                        `packing_list`.`issue_no`=`packing_list_details`.`issue_no` AND (`status`='COMPLETED' OR `status`='ARCHIVED')AND `issue_date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "' AND `item_code` IN (" + list + ") AND `sales_person_id`='" + salesPersonId + "' AND `qty_sold` > '0'
                    
                     GROUP BY 
                        `item_code`"
            End If

            If list = "" And cmbSalesPersons.Text <> "" Then
                Dim salesPersonId As String = (New PackingList).getSalesPersonId(cmbSalesPersons.Text)

                query = "SELECT
                       `packing_list`.`issue_date` AS `issue_date`, 
                        `packing_list`.`status` AS `status`,
                        `packing_list_details`.`item_code` AS `item_code`,
                        `packing_list_details`.`description` AS `description`,
                        SUM(`packing_list_details`.`qty_sold`) AS `qty_sold`,
                        SUM(`packing_list_details`.`price`*`packing_list_details`.`qty_sold`) AS `amount`,
                        SUM(`packing_list_details`.`cprice`*`packing_list_details`.`qty_sold`) AS `camount`
                    FROM 
                        `packing_list`, `packing_list_details` 
                    WHERE 
                        `packing_list`.`issue_no`=`packing_list_details`.`issue_no` AND (`status`='COMPLETED' OR `status`='ARCHIVED')AND `issue_date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "' AND `sales_person_id`='" + salesPersonId + "' AND `qty_sold` > '0'
                    
                     GROUP BY 
                        `item_code`"
            End If

            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            While reader.Read
                Dim itemCode As String = reader.GetString("item_code")
                Dim description As String = reader.GetString("description")
                Dim stock As String = (New Item).getStock(itemCode)
                Dim qty As String = reader.GetString("qty_sold")
                Dim _date As String = reader.GetString("issue_date")
                Dim amount As String = reader.GetString("amount")
                Dim cAmount As String = reader.GetString("camount")

                totalProfit = totalProfit + (Val(amount) - Val(cAmount))

                Dim item As New Item
                item.searchItem(itemCode)

                totalSales = totalSales + Val(amount)

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
                dtgrdCell.Value = LCurrency.displayValue(amount)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdList.Rows.Add(dtgrdRow)
            End While
            conn.Close()
            txtTotal.Text = LCurrency.displayValue(totalSales.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If list = "" Then
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                Dim query As String = ""
                If cmbSalesPersons.Text <> "" Then
                    Dim salesPersonId As String = (New PackingList).getSalesPersonId(cmbSalesPersons.Text)
                    query = "SELECT
                                `id`, 
                                `issue_no`, 
                                `issue_date`, 
                                `status`, 
                                `sales_person_id`, 
                                `amount_issued`, 
                                `total_returns`, 
                                `total_damages`, 
                                `total_discounts`, 
                                `total_expenditures`, 
                                `total_bank_cash`, 
                                `debt`, 
                                `user_id`, 
                                `float_amount`                    
                            FROM 
                                `packing_list` 
                            WHERE 
                                (`status`='COMPLETED' OR `status`='ARCHIVED')AND (`issue_date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "') AND `sales_person_id`='" + salesPersonId + "' AND ((`total_discounts`+`total_expenditures`+`total_bank_cash`+`debt`)>'0')"
                ElseIf cmbSalesPersons.Text = "" Then
                    query = "SELECT
                                `id`, 
                                `issue_no`, 
                                `issue_date`, 
                                `status`, 
                                `sales_person_id`, 
                                `amount_issued`, 
                                `total_returns`, 
                                `total_damages`, 
                                `total_discounts`, 
                                `total_expenditures`, 
                                `total_bank_cash`, 
                                `debt`, 
                                `user_id`, 
                                `float_amount`                     
                            FROM 
                                `packing_list` 
                            WHERE 
                                (`status`='COMPLETED' OR `status`='ARCHIVED')AND (`issue_date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "') AND ((`total_discounts`+`total_expenditures`+`total_bank_cash`+`debt`)>'0')"
                End If
                conn.Open()
                command.CommandText = query
                command.Connection = conn
                command.CommandType = CommandType.Text
                Dim reader As MySqlDataReader = command.ExecuteReader()
                Dim totalIssued As Double = 0
                Dim totalDiscount As Double = 0
                Dim totalExpenditures As Double = 0
                Dim totalBankCash As Double = 0
                Dim debt As Double = 0
                'calculate total discounts
                'Dim count As Integer = 0
                While reader.Read
                    'count = count + 1
                    totalIssued = totalIssued + Val(reader.GetString("amount_issued"))
                    totalDiscount = totalDiscount + Val(reader.GetString("total_discounts"))
                    totalExpenditures = totalExpenditures + Val(reader.GetString("total_expenditures"))
                    totalBankCash = totalBankCash + Val(reader.GetString("total_bank_cash"))
                    debt = debt + Val(reader.GetString("debt"))
                End While
                'MsgBox(count)
                txtTotalIssued.Text = LCurrency.displayValue(totalIssued.ToString)
                txtTotalDiscount.Text = LCurrency.displayValue(totalDiscount.ToString)
                txtNetSales.Text = LCurrency.displayValue((totalSales - totalDiscount).ToString)

                txtTotalExpenditures.Text = LCurrency.displayValue(totalExpenditures.ToString)
                txtTotalBankcash.Text = LCurrency.displayValue(totalBankCash.ToString)
                txtDebt.Text = LCurrency.displayValue(debt.ToString)
                txtNetProfit.Text = LCurrency.displayValue((totalProfit - totalExpenditures - totalDiscount).ToString)

            Catch ex As Exception
                ex.ToString()
            End Try
        Else
            txtTotalIssued.Text = "NA"
            txtTotalDiscount.Text = "NA"
            txtNetSales.Text = "NA"

            txtTotalExpenditures.Text = "NA"
            txtTotalBankcash.Text = "NA"
            txtDebt.Text = "NA"
        End If
        Cursor = Cursors.Arrow
        Return vbNull
    End Function
    Dim list As String = ""

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Private Sub loadSalesPersons()
        Dim conn As New MySqlConnection(Database.conString)
        Try
            Dim suppcommand As New MySqlCommand()
            Dim supplierQuery As String = "SELECT
                                                `id`,
                                                `full_name`
                                            FROM
                                                `sales_persons`"
            conn.Open()
            suppcommand.CommandText = supplierQuery
            suppcommand.Connection = conn
            suppcommand.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = suppcommand.ExecuteReader
            cmbSalesPersons.Items.Clear()
            cmbSalesPersons.Items.Add("")
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

    Private Sub frmSalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim item As New Item
        longList = item.getItems()
        loadSalesPersons()
        clearFields()
        dtgrdList.Rows.Clear()
    End Sub
    Dim longList As New List(Of String)
    Dim shortList As New List(Of String)
    Private Sub cmbDescription_KeyUp(sender As Object, e As EventArgs) Handles cmbDescription.KeyUp
        shortList.Clear()
        cmbDescription.Items.Clear()
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
            Dim query As String = "SELECT
                                        `item_code`,
                                        `item_long_description`,
                                        `pck`,`unit_cost_price`,
                                        `retail_price`,
                                        `vat`, 
                                        `margin`,
                                        `standard_uom`,
                                        `active`
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
                txtItemCode.Text = reader.GetString("item_code")
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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        lstCode.Items.Add(txtItemCode.Text)
        clearFields()
        btnAdd.Enabled = False
    End Sub
    Private Sub clearFields()
        txtItemCode.Text = ""
        txtBarCode.Text = ""
        cmbDescription.Text = ""
        txtTotalDiscount.Text = ""
        txtNetSales.Text = ""
        txtTotal.Text = ""
        txtDebt.Text = ""
        txtTotalBankcash.Text = ""
        txtTotalExpenditures.Text = ""
        txtTotalIssued.Text = ""
        txtNetProfit.Text = ""
        dtgrdList.Rows.Clear()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lstCode.Items.Clear()
        cmbSalesPersons.Text = ""
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

        document.Info.Title = "Summarized Daily Sales Report"
        document.Info.Subject = "Summarized Daily Sales Report"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Summarized Daily Sales Report " & dateStart.Text & dateEnd.Text & cmbSalesPersons.Text & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)
    End Sub

    Private Sub cmbSalesPersons_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSalesPersons.SelectedIndexChanged
        clearFields()
    End Sub

    Private Sub btnExportToExcel_Click(sender As Object, e As EventArgs) Handles btnExportToExcel.Click
        If dtgrdList.RowCount = 0 Then
            MsgBox("Nothing to export")
            Exit Sub
        End If
        Dim appXL As New Microsoft.Office.Interop.Excel.Application
        Dim wbXl As Microsoft.Office.Interop.Excel.Workbook
        Dim shXL As Microsoft.Office.Interop.Excel.Worksheet
        Dim raXL As Excel.Range
        ' Start Excel and get Application object.
        appXL = CreateObject("Excel.Application")
        appXL.Visible = True
        ' Add a new workbook.
        wbXl = appXL.Workbooks.Add
        shXL = wbXl.ActiveSheet

        Dim r As Integer = 1

        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "Summarized Daily Sales Report"

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
        shXL.Cells(r, 1).Value = "S/M Officer: " + cmbSalesPersons.Text


        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A" + r.ToString)
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        r = r + 2
        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "Item Code"
        shXL.Cells(r, 2).Value = "Description"
        shXL.Cells(r, 3).Value = "Qty"
        shXL.Cells(r, 4).Value = "Amount"
        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A" + r.ToString, "G" + r.ToString)
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
        shXL.Cells(r, 1).Value = "Total Issued"
        shXL.Cells(r, 2).Value = txtTotalIssued.Text
        r = r + 1
        shXL.Cells(r, 1).Value = "Total Sales"
        shXL.Cells(r, 2).Value = txtTotal.Text
        r = r + 1
        shXL.Cells(r, 1).Value = "Total Discounts"
        shXL.Cells(r, 2).Value = txtTotalDiscount.Text
        r = r + 1
        shXL.Cells(r, 1).Value = "Net Sales"
        shXL.Cells(r, 2).Value = txtNetSales.Text
        r = r + 1
        shXL.Cells(r, 1).Value = "Total Expenditures"
        shXL.Cells(r, 2).Value = txtTotalExpenditures.Text
        r = r + 1
        shXL.Cells(r, 1).Value = "Cash and Bank Deposit"
        shXL.Cells(r, 2).Value = txtTotalBankcash.Text
        r = r + 1
        shXL.Cells(r, 1).Value = "Deficit/Debt"
        shXL.Cells(r, 2).Value = txtDebt.Text
        r = r + 1

        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "G1")
        raXL.EntireColumn.AutoFit()

        Dim strFileName As String = LSystem.saveToDesktop & "\Summarized Daily Sales Report " & dateStart.Text & dateEnd.Text & cmbSalesPersons.Text & ".xls"
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



        ' appXL.Visible = True
        ' Make sure Excel is visible and give the user control
        ' of Excel's lifetime.
        '      appXL.Visible = True
        '       appXL.UserControl = True
        ' Release object references.
        '       raXL = Nothing
        '        shXL = Nothing
        '     wbXl = Nothing
        '      appXL.Quit()
        '       appXL = Nothing
        Exit Sub
Err_Handler:
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

    End Sub

    Private Sub cmbDescription_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbDescription.KeyUp

    End Sub
End Class