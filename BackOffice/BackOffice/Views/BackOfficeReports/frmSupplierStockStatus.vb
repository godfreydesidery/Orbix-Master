Imports System.IO
Imports Devart.Data.MySql
Imports Microsoft.Office.Interop
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmSupplierStockStatus

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Dim list As String = ""

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnView.Click
        list = ""
        For i As Integer = 0 To lstCode.Items.Count - 1
            list = list + lstCode.Items.Item(i)
            If i < lstCode.Items.Count - 1 Then
                list = list + ","
            End If
        Next
        refreshList(cmbSupplier.Text, cmbDepartment.Text, "", "")
    End Sub
    Private Function refreshList(supplierName As String, departmentName As String, className As String, subClassname As String)
        dtgrdItemList.Rows.Clear()



        Try
            Dim response As Object = New Object
            If list <> "" Then
                response = Web.get_("products/get_supply_stock_status?supplier_name=&department_name=&class_name=&sub_class_name=&codes=" + list)
            Else
                response = Web.get_("products/get_supply_stock_status?supplier_name=" + supplierName + "&department_name=&class_name=&sub_class_name=&codes=")
            End If

            Dim details As List(Of SupplyStockStatus) = JsonConvert.DeserializeObject(Of List(Of SupplyStockStatus))(response.ToString)


            Dim totalStockValue As Double = 0
            Dim totalStockCost As Double = 0

            For Each detail In details

                If detail.stock >= 0 Then
                    totalStockValue = totalStockValue + detail.stockValue
                End If
                If detail.stock >= 0 Then
                    totalStockCost = totalStockCost + detail.stockCost
                End If

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = detail.code
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = detail.description
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = detail.stock
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(detail.costPriceVatIncl.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(detail.sellingPriceVatIncl.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(detail.stockCost.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(detail.stockValue.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdItemList.Rows.Add(dtgrdRow)
            Next
            txtTotalStock.Text = LCurrency.displayValue(totalStockCost.ToString)
            txtNetValue.Text = LCurrency.displayValue(totalStockValue.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return vbNull
        Exit Function

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = ""
            If supplierName <> "" And departmentName <> "" Then
                query = "SELECT `item_code`,`item_scan_code`, `item_long_description`, `item_description`, `pck`, `department_id`, `class_id`, `sub_class_id`, `supplier_id`, `unit_cost_price`, `retail_price`, `discount`, `vat`, `margin`, `standard_uom`, `active` FROM `items` WHERE `supplier_id`='" + (New Supplier).getSupplierID("", supplierName) + "' AND `department_id`='" + (New Department).getDepartmentID(departmentName) + "'"
                If list <> "" Then
                    cmbSupplier.Text = ""
                    cmbDepartment.Text = ""
                    query = "SELECT `item_code`,`item_scan_code`, `item_long_description`, `item_description`, `pck`, `department_id`, `class_id`, `sub_class_id`, `supplier_id`, `unit_cost_price`, `retail_price`, `discount`, `vat`, `margin`, `standard_uom`, `active` FROM `items` WHERE `supplier_id`='" + (New Supplier).getSupplierID("", supplierName) + "' AND `department_id`='" + (New Department).getDepartmentID(departmentName) + "'AND `item_code` IN (" + list + ")"
                End If
            ElseIf supplierName <> "" Then
                query = "SELECT `item_code`,`item_scan_code`, `item_long_description`, `item_description`, `pck`, `department_id`, `class_id`, `sub_class_id`, `supplier_id`, `unit_cost_price`, `retail_price`, `discount`, `vat`, `margin`, `standard_uom`, `active` FROM `items` WHERE `supplier_id`='" + (New Supplier).getSupplierID("", supplierName) + "'"
                If list <> "" Then
                    cmbSupplier.Text = ""
                    cmbDepartment.Text = ""
                    query = "SELECT `item_code`,`item_scan_code`, `item_long_description`, `item_description`, `pck`, `department_id`, `class_id`, `sub_class_id`, `supplier_id`, `unit_cost_price`, `retail_price`, `discount`, `vat`, `margin`, `standard_uom`, `active` FROM `items` WHERE `supplier_id`='" + (New Supplier).getSupplierID("", supplierName) + "'AND `item_code` IN (" + list + ")"
                End If
            Else
                query = "SELECT `sn`, `item_code`, `item_scan_code`, `item_long_description`, `item_description`, `pck`, `department_id`, `class_id`, `sub_class_id`, `supplier_id`, `unit_cost_price`, `retail_price`, `discount`, `vat`, `margin`, `standard_uom`, `active` FROM `items`"
                If list <> "" Then
                    cmbSupplier.Text = ""
                    cmbDepartment.Text = ""
                    query = "SELECT `sn`, `item_code`, `item_scan_code`, `item_long_description`, `item_description`, `pck`, `department_id`, `class_id`, `sub_class_id`, `supplier_id`, `unit_cost_price`, `retail_price`, `discount`, `vat`, `margin`, `standard_uom`, `active` FROM `items` WHERE `item_code` IN (" + list + ")"
                End If
            End If

            'query = "SELECT `sn`, `item_code`, `item_scan_code`, `item_long_description`, `item_description`, `pck`, `department_id`, `class_id`, `sub_class_id`, `supplier_id`, `unit_cost_price`, `retail_price`, `discount`, `vat`, `margin`, `standard_uom`, `active` FROM `items` WHERE `supplier_id`='" + (New Supplier).getSupplierID("", supplierName) + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim itemCode As String = ""
            Dim description As String = ""
            Dim stock As String = ""
            Dim sellingPrice As String = ""
            Dim costPrice As String = ""
            Dim stockValue As Double = 0
            Dim stockCost As Double = 0
            Dim totalStockValue As Double = 0
            Dim totalStockCost As Double = 0

            Dim supplier As String = ""
            While reader.Read

                itemCode = reader.GetString("item_code")
                description = reader.GetString("item_long_description")
                stock = (New Inventory).getInventory(itemCode)
                costPrice = reader.GetString("unit_cost_price")
                sellingPrice = reader.GetString("retail_price")
                stockValue = Val(stock) * Val(sellingPrice)
                stockCost = Val(stock) * Val(costPrice)
                If stockValue >= 0 Then
                    totalStockValue = totalStockValue + stockValue
                End If
                If stockCost >= 0 Then
                    totalStockCost = totalStockCost + stockCost
                End If

                supplier = (New Supplier).getSupplierName(reader.GetString("supplier_id"), "")


                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = itemCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = description
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = stock
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(costPrice.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(sellingPrice.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(stockValue.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = supplier
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdItemList.Rows.Add(dtgrdRow)
            End While
            txtTotalStock.Text = LCurrency.displayValue(totalStockCost.ToString)
            txtNetValue.Text = LCurrency.displayValue(totalStockValue.ToString)
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function
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

        document.Info.Title = "Supplier Stock Status"
        document.Info.Subject = "Supplier Stock Status"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()
        Dim supplierName = cmbSupplier.Text
        If supplierName = "" Then
            supplierName = "--Selected items from all suppliers--"
        End If

        Dim filename As String = LSystem.getRoot & "\Supplier Stock Status" & cmbSupplier.Text & " .pdf"

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
        documentTitle.AddText("Supplier Stock status Report")
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
        If cmbSupplier.Text = "" Then
            paragraph.AddText("--Selected Items--")
        Else
            paragraph.AddText("(" + (New Supplier).getSupplierCode("", cmbSupplier.Text) + ")  " + cmbSupplier.Text)
        End If
        paragraph.Format.Alignment = ParagraphAlignment.Left
        paragraph.Format.Font.Size = 8
        paragraph.Format.Font.Color = Colors.Black

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
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("5.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.7cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.7cm")
        column.Format.Alignment = ParagraphAlignment.Center


        column = table.AddColumn("2.2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

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
        row.Cells(0).AddParagraph("Code")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Description")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Stock")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("C Price")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph("S Price")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph("Stock Cost")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(6).AddParagraph("Stock Value")
        row.Cells(6).Format.Alignment = ParagraphAlignment.Left

        table.SetEdge(0, 0, 7, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalQty As Double = 0

        For i As Integer = 0 To dtgrdItemList.RowCount - 1

            Dim code As String = dtgrdItemList.Item(0, i).Value
            Dim descr As String = dtgrdItemList.Item(1, i).Value
            Dim stock As String = dtgrdItemList.Item(2, i).Value
            Dim costPrice As String = LCurrency.displayValue(dtgrdItemList.Item(3, i).Value)
            Dim sellingPrice As String = LCurrency.displayValue(dtgrdItemList.Item(4, i).Value)
            Dim stockCost As String = LCurrency.displayValue(dtgrdItemList.Item(5, i).Value)
            Dim stockValue As String = LCurrency.displayValue(dtgrdItemList.Item(6, i).Value)

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Font.Size = 8
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.White
            row.Cells(0).AddParagraph(code)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(descr)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(stock)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(costPrice)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Right
            row.Cells(4).AddParagraph(sellingPrice)
            row.Cells(4).Format.Alignment = ParagraphAlignment.Right
            row.Cells(5).AddParagraph(stockCost)
            row.Cells(5).Format.Alignment = ParagraphAlignment.Right
            row.Cells(6).AddParagraph(stockValue)
            row.Cells(6).Format.Alignment = ParagraphAlignment.Right

            table.SetEdge(0, 0, 7, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Next

        row = table.AddRow()
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

        row = table.AddRow()
        row.Borders.Color = Colors.White
        row.Format.Font.Size = 8
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
        row.Cells(5).AddParagraph("Stock Cost")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(6).AddParagraph(txtTotalStock.Text)
        row.Cells(6).Format.Alignment = ParagraphAlignment.Right

        table.SetEdge(0, 0, 7, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Borders.Color = Colors.White
        row.Format.Font.Size = 8
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
        row.Cells(5).AddParagraph("Stock Value")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(6).AddParagraph(txtNetValue.Text)
        row.Cells(6).Format.Alignment = ParagraphAlignment.Right

        table.SetEdge(0, 0, 7, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("---NB: Negative stocks are excluded---")
        paragraph.Format.Alignment = ParagraphAlignment.Right
        paragraph.Format.Font.Size = 8

        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("***End of Report***")
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9

    End Sub

    Private Sub frmSupplierStockStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSupplier.Items.Clear()
        dtgrdItemList.Rows.Clear()
        Dim item As New Item
        longList = item.getItems()
        Dim supplier As New Supplier
        cmbSupplier.Items.Add("")
        longSupplierList = supplier.getNames()

    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        refreshList(cmbSupplier.Text, cmbDepartment.Text, "", "")
    End Sub

    Private Sub searchItem()
        Dim found As Boolean = False
        Dim valid As Boolean = False
        Dim barCode As String = txtBarCode.Text
        Dim code As String = txtItemCodeS.Text
        Dim descr As String = cmbDescription.Text

        If barCode <> "" Then
            code = (New Product).getCode(barCode, "")
        ElseIf code <> "" Then
            code = code
        ElseIf descr <> "" Then
            code = (New Product).getCode("", descr)
        Else
            code = ""
        End If

        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("products/get_by_code?code=" + code)
            json = JObject.Parse(response)
            Dim product As Product = JsonConvert.DeserializeObject(Of Product)(json.ToString)
            txtItemCodeS.Text = product.code
            cmbDescription.Text = product.description
            btnAdd.Enabled = True
        Catch ex As Exception
            MsgBox("Not found")
            Exit Sub
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
        dtgrdItemList.Rows.Clear()
        clearFields()
    End Sub
    Private Sub clearFields()
        txtItemCodeS.Text = ""
        txtBarCode.Text = ""
        cmbDescription.SelectedItem = Nothing
        cmbDescription.Text = ""
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

    Private Sub btnExportToExcel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSupplier.SelectedIndexChanged
        dtgrdItemList.Rows.Clear()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If dtgrdItemList.RowCount = 0 Then
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
        If cmbSupplier.Text = "" Then
            shXL.Cells(r, 1).Value = "Supplier: <--All-->"
        Else
            shXL.Cells(r, 1).Value = "Supplier: " + cmbSupplier.Text
        End If


        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A1")
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        r = r + 2
        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "Code"
        shXL.Cells(r, 2).Value = "Description"
        shXL.Cells(r, 3).Value = "Stock"
        shXL.Cells(r, 4).Value = "Cost Price@"
        shXL.Cells(r, 5).Value = "Selling Price@"
        shXL.Cells(r, 6).Value = "Stock Cost"
        shXL.Cells(r, 7).Value = "Stock Value"
        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A3", "G3")
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        r = r + 1
        'raXL = shXL.Range("C1", "C7")
        'raXL.Formula = "=A1 & "" "" & B1"
        'Dim r As Integer = 3
        For i As Integer = 0 To dtgrdItemList.RowCount - 1
            With shXL
                .Cells(r, 1).Value = dtgrdItemList.Item(0, i).Value
                .Cells(r, 2).Value = dtgrdItemList.Item(1, i).Value
                .Cells(r, 3).Value = dtgrdItemList.Item(2, i).Value
                .Cells(r, 4).Value = dtgrdItemList.Item(3, i).Value
                .Cells(r, 5).Value = dtgrdItemList.Item(4, i).Value
                .Cells(r, 6).Value = dtgrdItemList.Item(5, i).Value
                .Cells(r, 7).Value = dtgrdItemList.Item(6, i).Value
            End With
            r = r + 1
        Next
        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "G1")
        raXL.EntireColumn.AutoFit()
        Dim strFileName As String = LSystem.saveToDesktop & "\Supply Stock Status " & cmbSupplier.Text & cmbDepartment.Text & ".xls"
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
        ' appXL.Workbooks.Open(strFileName)
        Exit Sub
Err_Handler:
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

    End Sub

    Private Sub btnExportToPDF_Click(sender As Object, e As EventArgs) Handles btnExportToPDF.Click
        'refreshList(cmbSupplier.Text, cmbDepartment.Text)
        If dtgrdItemList.RowCount = 0 Then
            MsgBox("Nothing to export")
            Exit Sub
        End If
        If cmbSupplier.Text = "" Then
            If list = "" Then
                '   MsgBox("Select a supplier.", vbOKOnly + vbCritical, "Error: No selection")
                '  Exit Sub
            End If

        End If
        If dtgrdItemList.RowCount > 0 Then
            print()
        Else
            Dim res As Integer = MsgBox("List is empty. Would you like to print an empty list?", vbYesNo + vbQuestion, "List empty")
            If res = DialogResult.Yes Then
                print()
            End If
        End If
    End Sub

    Dim longSupplierList As New List(Of String)
    Dim shortSupplierList As New List(Of String)
    Private Sub cmbSupplier_KeyUp(sender As Object, e As EventArgs) Handles cmbSupplier.KeyUp
        Dim currentText As String = cmbSupplier.Text
        shortSupplierList.Clear()
        cmbSupplier.Items.Clear()
        cmbSupplier.Items.Add(currentText)

        cmbSupplier.DroppedDown = True
        For Each text As String In longSupplierList
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbSupplier.Text.ToUpper()) Then
                shortSupplierList.Add(text)
            End If
        Next
        cmbSupplier.Items.AddRange(shortSupplierList.ToArray())
        cmbSupplier.SelectionStart = cmbSupplier.Text.Length
        Cursor.Current = Cursors.Default
    End Sub

End Class