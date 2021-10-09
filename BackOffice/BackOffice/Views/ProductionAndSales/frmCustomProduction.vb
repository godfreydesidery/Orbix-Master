Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmCustomProduction
    Dim ready As Boolean = True
    Dim materials As New List(Of Material_)
    Dim materialsUsed As New List(Of MaterialUsed)

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
        documentTitle.AddText("Production Sheet")
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
        paragraph.AddFormattedText("Production No: " + txtProductionNo.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Issue Date: " + txtCreated.Text.Substring(0, 10))
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Product Name: " + txtProductName.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Batch Size " + txtBatchSize.Text + " " + cmbUom.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Status: " + txtStatus.Text)
        paragraph.Format.Font.Size = 8




        'Add the print date field
        paragraph = section.AddParagraph()
        paragraph.Format.SpaceBefore = "1cm"
        paragraph.Style = "Reference"
        paragraph.AddTab()
        paragraph.AddText("Created: ")
        paragraph.AddDateField("dd.MM.yyyy")

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Materials")
        paragraph.Format.Font.Size = 8

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

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Left


        column = table.AddColumn("4cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Right



        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Font.Size = 8
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.Black
        row.Cells(0).AddParagraph("SN")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Material")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("UOM")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Qty")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph("Add")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph("Add")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(6).AddParagraph("Add")
        row.Cells(6).Format.Alignment = ParagraphAlignment.Left
        row.Cells(7).AddParagraph("Add")
        row.Cells(7).Format.Alignment = ParagraphAlignment.Left
        row.Cells(8).AddParagraph("Add")
        row.Cells(8).Format.Alignment = ParagraphAlignment.Left
        row.Cells(9).AddParagraph("Total Qty")
        row.Cells(9).Format.Alignment = ParagraphAlignment.Left
        row.Cells(10).AddParagraph("UOM")
        row.Cells(10).Format.Alignment = ParagraphAlignment.Left


        table.SetEdge(0, 0, 9, 1, Tables.Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalAmount As Double = 0
        Dim totalVat As Double = 0
        Dim totalDiscount As Double = 0

        Dim status As String = (New Production).getStatus(txtProductionNo.Text)
        Dim sn As Integer = 0
        Dim description As String
        Dim uom As String
        Dim qty As Double
        For i As Integer = 0 To materialsUsed.Count - 1

            sn = sn + 1
            description = materialsUsed.Item(i).description
            uom = materialsUsed.Item(i).uom
            qty = materialsUsed.Item(i).qty

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Font.Size = 8
            row.Height = "5mm"
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.Black
            row.Cells(0).AddParagraph(sn)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(description)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(uom)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(qty)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Left
            row.Cells(4).AddParagraph()
            row.Cells(4).Format.Alignment = ParagraphAlignment.Left
            row.Cells(5).AddParagraph()
            row.Cells(5).Format.Alignment = ParagraphAlignment.Left
            row.Cells(6).AddParagraph()
            row.Cells(6).Format.Alignment = ParagraphAlignment.Left
            row.Cells(7).AddParagraph()
            row.Cells(7).Format.Alignment = ParagraphAlignment.Left
            row.Cells(8).AddParagraph()
            row.Cells(8).Format.Alignment = ParagraphAlignment.Left
            row.Cells(9).AddParagraph()
            row.Cells(9).Format.Alignment = ParagraphAlignment.Left
            row.Cells(10).AddParagraph(uom)
            row.Cells(10).Format.Alignment = ParagraphAlignment.Left


            table.SetEdge(0, 0, 9, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        Next

        paragraph = section.AddParagraph()

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Finished Products")
        paragraph.Format.Font.Size = 8

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

        column3 = table3.AddColumn("2cm")
        column3.Format.Alignment = ParagraphAlignment.Left

        column3 = table3.AddColumn("9cm")
        column3.Format.Alignment = ParagraphAlignment.Left

        column3 = table3.AddColumn("2cm")
        column3.Format.Alignment = ParagraphAlignment.Left

        'Create the header of the table
        Dim row3 As Row

        row3 = table3.AddRow()
        row3.Format.Font.Bold = False
        row3.HeadingFormat = True
        row3.Format.Font.Size = 9
        row3.Format.Alignment = ParagraphAlignment.Center
        row3.Borders.Color = Colors.Gray
        row3.Cells(0).AddParagraph("Item Code")
        row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row3.Cells(1).AddParagraph("Description")
        row3.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row3.Cells(2).AddParagraph("Qty")
        row3.Cells(2).Format.Alignment = ParagraphAlignment.Left

        table3.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim j As Integer
        For j = 0 To dtgrdItemList.RowCount - 1
            row3 = table3.AddRow()
            row3.Format.Font.Bold = False
            row3.HeadingFormat = True
            row3.Format.Font.Size = 9
            row3.Format.Alignment = ParagraphAlignment.Center
            row3.Borders.Color = Colors.Gray
            row3.Cells(0).AddParagraph(dtgrdItemList.Item(0, j).Value)
            row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row3.Cells(1).AddParagraph(dtgrdItemList.Item(1, j).Value)
            row3.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row3.Cells(2).AddParagraph(dtgrdItemList.Item(2, j).Value + " " + dtgrdItemList.Item(3, j).Value)
            row3.Cells(2).Format.Alignment = ParagraphAlignment.Left
        Next

        table3.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

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

        'Create the header of the table
        Dim row2 As Row

        row2 = table2.AddRow()
        row2.Format.Font.Bold = False
        row2.HeadingFormat = True
        row2.Format.Font.Size = 9
        row2.Format.Alignment = ParagraphAlignment.Center
        row2.Borders.Color = Colors.White
        row2.Cells(0).AddParagraph("Issued by:")
        row2.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row2.Cells(1).AddParagraph()
        row2.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row2.Cells(2).AddParagraph("Verified by:")
        row2.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row2.Cells(3).AddParagraph()
        row2.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row2.Cells(4).AddParagraph("Approved by:")
        row2.Cells(4).Format.Alignment = ParagraphAlignment.Left
        row2.Cells(5).AddParagraph()
        row2.Cells(5).Format.Alignment = ParagraphAlignment.Left

        table2.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

    End Sub

    Private Sub loadMaterials()
        chklstMaterials.Items.Clear()
        materials.Clear()

        Dim materials_ As New List(Of Material)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("materials")
            materials_ = JsonConvert.DeserializeObject(Of List(Of Material))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        For Each m In materials_
            Dim material As New Material_
            material.id = m.id
            material.materialCode = m.code
            material.description = m.description
            material.uom = m.standardUom
            ' material.qty = Val(reader.GetString("qty"))
            material.price = m.costPrice
            material.status = m.status
            material.summary = m.description + "  (" + m.standardUom + ")"
            materials.Add(material)
        Next
        Dim i As Integer
        For i = 0 To materials.Count - 1
            chklstMaterials.Items.Add(materials.Item(i).summary)
        Next
    End Sub

    Private Sub frmCustomProduction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        refreshProductionList()
        loadMaterials()

        Dim product As New Product
        longList = product.getDescriptions
    End Sub

    Private Sub btnAddUpdate_Click(sender As Object, e As EventArgs) Handles btnAddUpdate.Click
        Dim status As String = (New Production).getStatus(txtId.Text)
        If status = "CANCELED" Then
            MsgBox("Can not edit a canceled document", vbOKOnly + vbCritical, "Error: Invalid oprration")
            Exit Sub
        ElseIf status = "COMPLETED" Or status = "ARCHIVED" Then
            MsgBox("Can not edit a completed document", vbOKOnly + vbCritical, "Error: Invalid oprration")
            Exit Sub
        End If

        Dim i As Integer
        If txtId.Text = "" Then
            If save() = False Then
                MsgBox("Could not save document", vbOKOnly + vbExclamation, "Error")
                Exit Sub
            End If
        End If
        For i = 0 To chklstMaterials.Items.Count - 1
            If chklstMaterials.GetItemChecked(i) = True Then

                Dim material As New Material_
                Dim materialUsed As New MaterialUsed

                materialUsed.id = materials.Item(i).id
                materialUsed.materialCode = materials.Item(i).materialCode
                materialUsed.description = materials.Item(i).description
                materialUsed.price = materials.Item(i).price
                materialUsed.qty = 0
                materialUsed.uom = materials.Item(i).uom
                materialUsed.summary = materials.Item(i).description + " (0) " + materials.Item(i).uom

                Dim j As Integer
                Dim contains As Boolean = False
                For j = 0 To materialsUsed.Count - 1
                    contains = False
                    If materialUsed.id = materialsUsed.Item(j).id Then
                        contains = True
                        Exit For
                    End If
                Next
                If contains = False Then
                    Dim sn As String = saveMaterialUsed(materialUsed.id, materialUsed.price)
                    If sn <> "" Then
                        materialUsed.sn = sn
                        materialsUsed.Add(materialUsed)
                        lstbxMaterials.Items.Add(materialUsed.summary)
                    Else
                        MsgBox("Could not add material", vbOKOnly + vbCritical + "Error: Operation failed")
                    End If
                End If
            End If
        Next
    End Sub

    Private Function save() As Boolean
        Dim saved = False

        If txtProductionNo.Text = "" Then
            MsgBox("Production No required", vbOKOnly + vbExclamation, "Error: Missing information")
            Return saved
        End If
        If txtProductName.Text = "" Then
            MsgBox("Product name required", vbOKOnly + vbExclamation, "Error: Missing information")
            Return saved
        End If
        If Val(txtBatchSize.Text) <= 0 Then
            MsgBox("Invalid batch size", vbOKOnly + vbExclamation, "Error: Invalid entry")
            Return saved
        End If
        If cmbUom.Text = "" Then
            MsgBox("Unit of measure required", vbOKOnly + vbExclamation, "Error: Missing information")
            Return saved
        End If
        Try
            If txtId.Text = "" Then

                Dim customProduction As New CustomProduction
                customProduction.no = "NA"
                customProduction.productName = txtProductName.Text
                customProduction.batchSize = txtBatchSize.Text
                customProduction.uom = cmbUom.Text
                customProduction.status = txtStatus.Text

                Dim response As Object = New Object
                response = Web.post(customProduction, "custom_productions/new")

                '    searchPackingList(txtIssueNo.Text)


            Else

                Dim customProduction As New CustomProduction
                customProduction.productName = txtProductName.Text
                customProduction.batchSize = txtBatchSize.Text
                customProduction.uom = cmbUom.Text
                customProduction.status = txtStatus.Text

                Dim response As Object = New Object
                response = Web.put(customProduction, "custom_productions/edit_by_id")

                '    searchPackingList(txtIssueNo.Text)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return saved
    End Function

    Private Function getProductionId(productionNo As String)
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "SELECT `id` FROM `productions` WHERE `production_no`='" + productionNo + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return id
    End Function
    Private Function getProductionMaterialId(productionId As String, materialId As String)
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "SELECT `id` FROM `production_material` WHERE `production_id`='" + productionId + "' AND `material_id`='" + materialId + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return id
    End Function

    Private Function updateMaterialUsed(sn As String) As Boolean
        Dim updated As Boolean = False

        Return updated
    End Function
    Private Function saveMaterialUsed(materialId As String, price As Double) As String
        Dim sn As String = ""

        Dim conn As New MySqlConnection(Database.conString)
        Dim command As New MySqlCommand()
        Try
            'add a new item
            Dim Query As String = "INSERT INTO `production_material`(`production_id`, `material_id`, `price`) VALUES (@production_id,@material_id,@price)"
            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@production_id", txtId.Text)
            command.Parameters.AddWithValue("@material_id", materialId)
            command.Parameters.AddWithValue("@price", price.ToString)

            command.ExecuteNonQuery()
            conn.Close()
            txtId.Text = getProductionId(txtProductionNo.Text)

            sn = getProductionMaterialId(txtId.Text, materialId)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return sn
    End Function
    Private Function loadMaterialUsed(processId As String) As Boolean
        Dim loaded As Boolean = False
        materialsUsed.Clear()
        lstbxMaterials.Items.Clear()

        Dim conn As New MySqlConnection(Database.conString)
        Try
            Dim suppcommand As New MySqlCommand()
            Dim query As String = "SELECT `id`, `production_id`, `material_id`, `qty`,`price` FROM `production_material` WHERE `production_id`='" + processId + "'"
            conn.Open()
            suppcommand.CommandText = query
            suppcommand.Connection = conn
            suppcommand.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = suppcommand.ExecuteReader


            If reader.HasRows Then
                While reader.Read
                    Dim materialUsed As New MaterialUsed

                    materialUsed.sn = reader.GetString("id")
                    materialUsed.id = reader.GetString("material_id")
                    materialUsed.materialCode = (New Material_).getMaterialCode(reader.GetString("material_id"))
                    materialUsed.description = (New Material_).getMaterialDescription(reader.GetString("material_id"))
                    materialUsed.qty = reader.GetString("qty")
                    materialUsed.price = reader.GetString("price")
                    materialUsed.uom = (New Material_).getMaterialUom(reader.GetString("material_id"))
                    materialUsed.summary = materialUsed.description.ToString() + " (" + materialUsed.qty.ToString + ") " + materialUsed.uom.ToString

                    materialsUsed.Add(materialUsed)
                    lstbxMaterials.Items.Add(materialUsed.summary)

                End While
            End If
            conn.Close()

        Catch ex As Devart.Data.MySql.MySqlException
            materialsUsed.Clear()
            lstbxMaterials.Items.Clear()
            MsgBox(ex.ToString)
            ready = False
            Return loaded
            Exit Function
        End Try

        Return loaded
    End Function



    Private Function search() As Boolean
        Dim found As Boolean = False
        If txtProductionNo.Text = "" Then
            MsgBox("Can not process production. Please select New for new production or Edit to edit an existing document", vbOKOnly + vbCritical, "Invalid operation")
            Return vbNull
            Exit Function
        End If
        If txtProductionNo.ReadOnly = False Then
            Dim list As New Production
            If list.getProduction(txtProductionNo.Text) = True Then
                txtId.Text = list.GL_ID
                txtProductionNo.ReadOnly = True
                txtCreated.Text = list.GL_DATE
                txtStatus.Text = list.GL_STATUS
                txtProductName.Text = list.GL_PRODUCT_NAME
                txtBatchSize.Text = list.GL_BATCH_SIZE
                cmbUom.Text = list.GL_UOM

                found = True


                'refreshList()
                If txtId.Text = "" Then
                    btnSave.Enabled = False
                Else
                    btnSave.Enabled = True
                End If

                Dim status As String = list.GL_STATUS

                If status = "APPROVED" Or status = "PRINTED" Or status = "REPRINTED" Or status = "COMPLETED" Or status = "CANCELED" Then
                    ' btnApprove.Enabled = False
                ElseIf status = "PENDING" Then
                    ' btnApprove.Enabled = True
                Else
                    ' btnApprove.Enabled = False
                End If

                If status = "PENDING" Then

                End If

                If status = "APPROVED" Then

                End If
                If status = "PRINTED" Then

                End If
                If status = "COMPLETED" Then

                End If
                If status = "CANCELED" Then

                End If
                If status = "ARCHIVED" Then

                End If


                clearFields()

                If status = "PENDING" Or status = "APPROVED" Then
                    unlockFields()
                Else
                    lockFields()
                End If

            Else
                MsgBox("No matching record", vbOKOnly + vbCritical, "Error: Not found")
                Return found
                Exit Function
            End If
        End If
        Return found
    End Function

    Public Function generateProductionNo() As String
        Dim no As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id` FROM `productions` ORDER BY `id` DESC LIMIT 1"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                no = (Val(reader.GetString("id")) + 1).ToString
                Exit While
            End While
            If no = "" Then
                no = "1"
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return no
    End Function
    Private Class Material_
        Protected Friend id As String
        Protected Friend materialCode As String
        Protected Friend description As String
        Protected Friend uom As String
        Protected Friend price As Double
        Protected Friend status As String
        Protected Friend summary As String

        Public Function getMaterialCode(id As String) As String
            Dim code As String = ""
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                'create bar code
                Dim query As String = ""

                query = "SELECT  `material_code` FROM `materials` WHERE `id`='" + id + "'"

                conn.Open()
                command.CommandText = query
                command.Connection = conn
                command.CommandType = CommandType.Text
                Dim reader As MySqlDataReader = command.ExecuteReader()
                While reader.Read
                    code = reader.GetString("material_code")
                    Exit While
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return code
        End Function

        Public Function getMaterialDescription(id As String) As String
            Dim code As String = ""
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                'create bar code
                Dim query As String = ""

                query = "SELECT  `description` FROM `materials` WHERE `id`='" + id + "'"

                conn.Open()
                command.CommandText = query
                command.Connection = conn
                command.CommandType = CommandType.Text
                Dim reader As MySqlDataReader = command.ExecuteReader()
                While reader.Read
                    code = reader.GetString("description")
                    Exit While
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return code
        End Function

        Public Function getMaterialUom(id As String) As String
            Dim code As String = ""
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                'create bar code
                Dim query As String = ""

                query = "SELECT  `uom` FROM `materials` WHERE `id`='" + id + "'"

                conn.Open()
                command.CommandText = query
                command.Connection = conn
                command.CommandType = CommandType.Text
                Dim reader As MySqlDataReader = command.ExecuteReader()
                While reader.Read
                    code = reader.GetString("uom")
                    Exit While
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return code
        End Function

    End Class
    Private Class MaterialUsed
        Protected Friend sn As String
        Protected Friend id As String
        Protected Friend materialCode As String
        Protected Friend description As String
        Protected Friend uom As String
        Protected Friend qty As Double
        Protected Friend price As Double
        Protected Friend status As String
        Protected Friend summary As String
    End Class

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If search() = True Then
            txtProductionNo.ReadOnly = True
            txtProductName.ReadOnly = True
            txtBatchSize.ReadOnly = True
            cmbUom.Enabled = False

            btnAddUpdate.Enabled = True

            loadMaterialUsed(txtProductionNo.Text)
            refreshFinishedProductsList()
        End If


    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtId.Text = ""
        txtProductionNo.Text = ""
        txtProductName.Text = ""
        txtStatus.Text = ""
        txtBatchSize.Text = ""
        txtCreated.Text = ""
        cmbUom.Text = ""

        btnAddUpdate.Enabled = True


        txtProductionNo.ReadOnly = True
        txtProductName.ReadOnly = False
        txtBatchSize.ReadOnly = False
        cmbUom.Enabled = True

        materialsUsed.Clear()
        lstbxMaterials.Items.Clear()
        txtProductionNo.Text = generateProductionNo()

        dtgrdItemList.Rows.Clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        save()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If txtId.Text = "" Then
            txtProductionNo.ReadOnly = False
            txtProductName.ReadOnly = True
            txtBatchSize.ReadOnly = True
            cmbUom.Enabled = False
        End If
        If txtId.Text <> "" Then
            txtProductionNo.ReadOnly = True
            txtProductName.ReadOnly = False
            txtBatchSize.ReadOnly = False
            cmbUom.Enabled = True
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()

    End Sub

    Private Sub clear()
        txtId.Text = ""
        txtProductionNo.Text = ""
        txtProductName.Text = ""
        txtStatus.Text = ""
        txtBatchSize.Text = ""
        txtCreated.Text = ""
        cmbUom.Text = ""

        txtBarCode.Text = ""
        txtItemCode.Text = ""
        cmbDescription.Text = ""

        dtgrdItemList.Rows.Clear()

        btnAddUpdate.Enabled = False

        materialsUsed.Clear()
        lstbxMaterials.Items.Clear()
    End Sub

    Private Sub refreshProductionList()
        dtgrdProductionList.Rows.Clear()




        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id`, `production_no`, `product_name`, `batch_size`, `uom`, `status`, `date` FROM `productions` WHERE `status`='PENDING' OR `status`='APPROVED' OR `status`='PRINTED' OR `status`='COMPLETED'"
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
                issueNo = reader.GetString("production_no")
                issueDate = reader.GetString("date")
                status = reader.GetString("status")

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = issueNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = issueDate
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = status
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdProductionList.Rows.Add(dtgrdRow)

            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

    Private Sub searchItem()
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
            Dim codeQuery As String = "SELECT `item_code`, `item_long_description`, `pck`,`unit_cost_price`, `retail_price`,`vat`, `margin`, `standard_uom`, `active` FROM `items` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtItemCode.Text = reader.GetString("item_code")
                cmbDescription.Text = reader.GetString("item_long_description")
                lblUom.Text = reader.GetString("standard_uom")

                found = True
                valid = True

                btnAdd.Enabled = True
                lockFields()
                Exit While
            End While
            conn.Close()
            If found = False Then
                MsgBox("Item not found", vbOKOnly + vbExclamation, "Error: Not found")
                ' clearFields()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnSearchItem_Click(sender As Object, e As EventArgs) Handles btnSearchItem.Click
        searchItem()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtBarCode.Text = ""
        txtItemCode.Text = ""
        cmbDescription.Text = ""
        txtQty.Text = ""
        lblUom.Text = ""

        txtBarCode.ReadOnly = False
        txtItemCode.ReadOnly = False
        cmbDescription.Enabled = True
        btnAdd.Enabled = False
    End Sub

    Private Sub clearFields()
        txtBarCode.Text = ""
        txtItemCode.Text = ""
        cmbDescription.Text = ""
        txtQty.Text = ""
        lblUom.Text = ""
    End Sub
    Private Sub unlockFields()
        txtBarCode.ReadOnly = False
        txtItemCode.ReadOnly = False
        cmbDescription.Enabled = True
        '  txtQty.ReadOnly = False
    End Sub
    Private Sub lockFields()
        txtBarCode.ReadOnly = True
        txtItemCode.ReadOnly = True
        cmbDescription.Enabled = False
        ' txtQty.ReadOnly = True
    End Sub



    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim status As String = (New Production).getStatus(txtId.Text)
        If status = "COMPLETED" Then
            MsgBox("You can not edit this production document. Document already completed.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "ARCHIVED" Then
            MsgBox("You can not edit this production document. Document completed and archived.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("You can not edit this production document. Document canceled.", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearFields()
            Exit Sub
        End If
        Dim barCode As String = txtBarCode.Text
        Dim itemCode As String = txtItemCode.Text
        Dim descr As String = cmbDescription.Text
        Dim qty As String = txtQty.Text

        If itemCode = "" Then
            MsgBox("Item required", vbOKOnly + vbExclamation, "Error: Missing information")
            Exit Sub
        End If
        If Val(qty) <= 0 Then
            MsgBox("Could not add item. Invalid quantity entry. Quantity should not be negative", vbOKOnly + vbCritical, "Error: Invalid entry")
            Exit Sub
        End If
        Dim production As Production

        production = New Production

        If txtId.Text <> "" Then
            If (New Production).isFinishedProductExist(txtId.Text, txtItemCode.Text) = False Then
                'add a new finished product
                production.addFinishedProduct(txtId.Text, txtItemCode.Text, cmbDescription.Text, txtQty.Text)
            Else
                'edit an existing finished product
                production.editFinishedProduct(txtId.Text, txtItemCode.Text, txtQty.Text)
            End If
        Else
            MsgBox("Could not add to an empty production document", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If

        refreshFinishedProductsList()

        clearFields()
        unlockFields()

    End Sub

    Private Function refreshFinishedProductsList()
        dtgrdItemList.Rows.Clear()
        Try

            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `id`, `item_code`, `description`, `qty`, `production_id` FROM `finished_products` WHERE`production_id`='" + txtId.Text + "' "
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim sn As String = ""
            Dim barCode As String = ""
            Dim itemCode As String = ""
            Dim description As String = ""
            Dim qty As String = ""
            Dim uom As String = ""

            Dim total As Double = 0

            While reader.Read
                Dim item As New Item
                itemCode = reader.GetString("item_code")
                item.searchItem(itemCode)
                description = reader.GetString("description") 'item.GL_LONG_DESCR
                qty = reader.GetString("qty")
                uom = item.getItemUom(itemCode)
                sn = reader.GetString("id")



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
                dtgrdCell.Value = uom
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = sn
                dtgrdRow.Cells.Add(dtgrdCell)



                dtgrdItemList.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function

    Private Sub dtgrdProductionList_CellClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdItemList.RowHeaderMouseClick
        Dim r As Integer = dtgrdItemList.CurrentRow.Index
        Dim itemCode As String = dtgrdItemList.Item(0, r).Value.ToString
        txtItemCode.Text = itemCode
        searchItem()
    End Sub



    Private Sub lstbxMaterials_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles lstbxMaterials.SelectedIndexChanged
        Dim status As String = (New Production).getStatus(txtId.Text)
        If status = "CANCELED" Then
            MsgBox("Can not edit a canceled document", vbOKOnly + vbCritical, "Error: Invalid oprration")
            Exit Sub
        ElseIf status = "COMPLETED" Or status = "ARCHIVED" Then
            MsgBox("Can not edit a completed document", vbOKOnly + vbCritical, "Error: Invalid oprration")
            Exit Sub
        End If

        Try
            Dim i As Integer = lstbxMaterials.SelectedIndex
            Dim id As String = materialsUsed.Item(i).id
            Dim summary As String = materialsUsed.Item(i).summary
            Dim qty As Double = materialsUsed.Item(i).qty

            Production.GLOBAL_ID = id
            Production.GLOBAL_PRODUCTION_ID = txtId.Text
            Production.GLOBAL_SUMMARY = summary
            Production.GLOBAL_QTY = qty
            Production.GLOBAL_STATUS = status


            frmEditUsedMaterial.ShowDialog()

        Catch ex As Exception
            MsgBox("Invalid selection")
        End Try


        loadMaterialUsed(txtId.Text)

    End Sub

    Public Sub deductMaterials()

        Dim i As Integer
        For i = 0 To materialsUsed.Count - 1
            If materialsUsed.Item(i).qty > 0 Then
                'deduct material
                Try
                    Dim conn As New MySqlConnection(Database.conString)
                    Dim command As New MySqlCommand()
                    Dim Query As String = "UPDATE `materials` SET `qty`=`qty`-'" + materialsUsed.Item(i).qty.ToString + "' WHERE `id`='" + materialsUsed.Item(i).id + "'"

                    conn.Open()
                    command.CommandText = Query
                    command.Connection = conn
                    command.CommandType = CommandType.Text
                    command.ExecuteNonQuery()
                    conn.Close()

                    Dim materialStockCard As New MaterialStockCard
                    Dim materialStock As Material = New Material
                    Dim materialUsage As Material = New Material

                    materialStockCard.qtyOut(Day.DAY, materialsUsed.Item(i).materialCode.ToString, materialsUsed.Item(i).qty.ToString, materialStock.getStock(materialsUsed.Item(i).materialCode.ToString), "CustPRD#: " + txtProductionNo.Text)
                    materialUsage.registerUsage(Day.DAY, materialsUsed.Item(i).materialCode.ToString, materialsUsed.Item(i).price.ToString, materialsUsed.Item(i).qty.ToString, materialStock.getStock(materialsUsed.Item(i).materialCode.ToString), "CustPRD#: " + txtProductionNo.Text)

                    btnEdit.Enabled = True
                    btnSave.Enabled = False
                Catch ex As Exception
                    MsgBox(ex.Message + ex.GetType.ToString)
                End Try
            End If
        Next
    End Sub



    Public Function updateInventory(itemCode As String, qty As String, grnNo As String)
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `inventorys` SET `qty`=`qty`+" + Val(qty).ToString + " WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            Dim inventory As New Inventory

            Dim stockCard As New StockCard
            stockCard.qtyIn(Day.DAY, itemCode, Val(qty), inventory.getInventory(itemCode), "Received goods, GRN No: " + grnNo)
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try
        Return vbNull
    End Function

    Private Sub addStock()
        Dim i As Integer
        Dim item As New Item
        For i = 0 To dtgrdItemList.RowCount - 1
            If Val(dtgrdItemList.Item(2, i).Value) > 0 Then

                Try
                    Dim conn As New MySqlConnection(Database.conString)
                    Dim command As New MySqlCommand()
                    Dim codeQuery As String = "UPDATE `inventorys` SET `qty`=`qty`+" + Val(dtgrdItemList.Item(2, i).Value).ToString + " WHERE `item_code`='" + dtgrdItemList.Item(0, i).Value + "'"
                    conn.Open()
                    command.CommandText = codeQuery
                    command.Connection = conn
                    command.CommandType = CommandType.Text
                    command.ExecuteNonQuery()
                    conn.Close()
                    Dim inventory As New Inventory

                    Dim stockCard As New StockCard
                    Dim production As Production = New Production
                    Dim itemcode As String = dtgrdItemList.Item(0, i).Value
                    stockCard.qtyIn(Day.DAY, itemcode, Val(dtgrdItemList.Item(2, i).Value), inventory.getInventory(itemcode), "Goods Produced, Production No: " + txtProductionNo.Text)
                    production.registerProduction(Day.DAY, itemcode, (New Item).getItemCostPrice(itemcode), dtgrdItemList.Item(2, i).Value, inventory.getInventory(itemcode), "Goods Produced, Production No: " + txtProductionNo.Text)
                Catch ex As Exception
                    MsgBox(ex.StackTrace)
                End Try
            End If
        Next
    End Sub

    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        Dim status As String = (New Production).getStatus(txtId.Text)
        If status = "COMPLETED" Or status = "ARCHIVED" Then
            MsgBox("Already completed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If
        If status <> "PRINTED" Then
            MsgBox("Could not complete, document not printed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If
        Dim res As Integer = MsgBox("Complete the production process? Materials will be removed from material stock and finished products will be added to stock", vbYesNo + vbQuestion, "Complete Process")
        If res = DialogResult.Yes Then
            deductMaterials()
            addStock()
            completeProduction(txtProductionNo.Text)
            status = (New Production).getStatus(txtId.Text)
            txtStatus.Text = status
            refreshFinishedProductsList()
            refreshProductionList()
            MsgBox("Production process " + txtProductionNo.Text + " completed successifully", vbOKOnly + vbInformation, "Success")
        End If

    End Sub

    Private Sub dtgrdProductionList_CellContentClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdProductionList.RowHeaderMouseClick
        Dim r As Integer = dtgrdProductionList.CurrentRow.Index
        Dim issueNo As String = dtgrdProductionList.Item(0, r).Value.ToString
        txtProductionNo.Text = issueNo
        txtProductionNo.ReadOnly = False
        If search() = True Then
            txtProductionNo.ReadOnly = True
            txtProductName.ReadOnly = True
            txtBatchSize.ReadOnly = True
            cmbUom.Enabled = False

            btnAddUpdate.Enabled = True

            loadMaterialUsed(txtProductionNo.Text)
            refreshFinishedProductsList()
        End If
    End Sub


    Public Function approveProduction(productionNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `productions` SET`status`='APPROVED' WHERE `production_no`='" + productionNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function

    Public Function archiveProduction(productionNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `productions` SET`status`='ARCHIVED' WHERE `production_no`='" + productionNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function

    Public Function printProduction(productionNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `productions` SET`status`='PRINTED' WHERE `production_no`='" + productionNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function

    Public Function cancelProduction(productionNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `productions` SET`status`='CANCELED' WHERE `production_no`='" + productionNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function

    Public Function completeProduction(productionNo As String) As Boolean
        Dim success As Boolean = True
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "UPDATE `productions` SET`status`='COMPLETED' WHERE `production_no`='" + productionNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function

    Private Sub btnProduction_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim status As String
        Try
            status = Web.get_("products/conversions/get_status_by_id?id=" + txtId.Text)
        Catch ex As Exception
            status = ""
        End Try
        If Not status = "PENDING" Then
            MsgBox("Could not approve, only pending documents can be approved", vbOKOnly + vbExclamation, "Error: Invalid operation")
            ' clearFields()
            Exit Sub
        End If

        If 1 = 1 Then ' User.authorize("APPROVE PACKING LIST") = True Then
            If txtProductionNo.Text = "" Then
                MsgBox("Select a conversion to approve", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            Dim res As Integer = MsgBox("Approve cusutom production: " + txtProductionNo.Text + " ? Editing will be disabled after approval", vbYesNo + vbQuestion, "Approve document?")
            If res = DialogResult.Yes Then

                Dim approved As Boolean = False
                Try
                    approved = Web.put(vbNull, "custom_productions/approve_by_id?id=" + txtId.Text)
                Catch ex As Exception
                    approved = False
                End Try
                If approved = True Then
                    MsgBox("Document Successively approved", vbOKOnly + vbInformation, "Operation successiful")
                Else
                    MsgBox("Could not approve document", vbOKOnly + vbExclamation, "Operation failed")
                End If
                ' (txtConversionNo.Text)
            End If
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
        refreshProductionList()

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim status As String = (New Production).getStatus(txtId.Text)
        If status = "APPROVED" Then
            Dim res As Integer = MsgBox("Print production sheet " + txtProductionNo.Text + " ?", vbYesNo + vbQuestion, "Print production sheet?")
            If res = DialogResult.Yes Then
                printProduction(txtProductionNo.Text)
                MsgBox("Print success", vbOKOnly + vbInformation, "Success")
            End If
        ElseIf status = "COMPLETED" Or status = "PRINTED" Or status = "ARCHIVED" Then
            'print documemnt only
        Else
            MsgBox("Could not print, document not approved", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If

        txtProductionNo.ReadOnly = False
        search()
        status = (New Production).getStatus(txtId.Text)
        txtStatus.Text = status
        refreshFinishedProductsList()
        refreshProductionList()


        Dim document As Document = New Document

        document.Info.Title = "Production"
        document.Info.Subject = "Production"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Production " & txtProductionNo.Text & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim status As String = (New Production).getStatus(txtId.Text)
        If status = "PENDING" Or status = "APPROVED" Then

            Dim res As Integer = MsgBox("Cancel production " + txtProductionNo.Text + " ?", vbYesNo + vbQuestion, "Cancel production?")
            If res = DialogResult.Yes Then
                cancelProduction(txtProductionNo.Text)

                status = (New Production).getStatus(txtId.Text)
                txtStatus.Text = status
                refreshFinishedProductsList()
                refreshProductionList()

                MsgBox("Cancel success", vbOKOnly + vbInformation, "Success")
            End If
        Else
            MsgBox("Could not cancel, only pending or approved document can be canceled", vbOKOnly + vbExclamation, "Error: Invalid operation")
        End If
    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged
        If Not IsNumeric(txtQty.Text) Then
            txtQty.Text = ""
        End If
        If Val(txtQty.Text) < 0 Then
            txtQty.Text = ""
        End If
        If txtQty.Text.Contains("-") Then
            txtQty.Text = ""
        End If
    End Sub

    Private Sub dtgrdItemList_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdItemList.RowHeaderMouseDoubleClick

        Dim status As String = (New Production).getStatus(txtId.Text)

        If status = "PENDING" Or status = "APPROVED" Then
            'continue delete
            Dim res As Integer = MsgBox("Remove finished product from this document?", vbYesNo + vbQuestion, "Remove product")
            If Not res = DialogResult.Yes Then
                Exit Sub
            End If
        Else
            MsgBox("Could not remove, you can only remove from pending or approved documents", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If

        Dim row As Integer = -1
        row = dtgrdItemList.CurrentRow.Index

        Dim itemCode As String = dtgrdItemList.Item(0, row).Value

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `finished_products` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            '  lockFields()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        clearFields()
        unlockFields()
        refreshFinishedProductsList()
    End Sub

    Private Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click
        Dim status As String = (New Production).getStatus(txtId.Text)
        If status = "COMPLETED" Then
            Dim res As Integer = MsgBox("Archive document? The document will be archived for future references", vbYesNo + vbQuestion, "Archive document")
            If res = DialogResult.Yes Then
                archiveProduction(txtProductionNo.Text)
                status = (New Production).getStatus(txtId.Text)
                txtStatus.Text = status
                refreshProductionList()
                clear()
                MsgBox("Document archived")
            End If
        Else
            MsgBox("Could not archive", vbOKOnly + vbExclamation, "Error: Invalid operation")
        End If
    End Sub

    Private Sub btnClear_Click_1(sender As Object, e As EventArgs) Handles btnClear.Click

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub
End Class