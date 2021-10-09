Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmMaterials

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Function clear()

        txtId.Text = ""
        txtMaterialCode.Text = ""
        cmbDescription.Text = ""
        cmbDescription.SelectedItem = Nothing
        cmbCategory.Text = ""
        cmbCategory.SelectedItem = Nothing
        txtPrice.Text = ""
        txtQty.Text = ""
        txtUom.Text = ""
        btnBlock.Enabled = False
        btnUnblock.Enabled = False
        Return vbNull
    End Function
    Private Function lock()
        txtMaterialCode.ReadOnly = True
        cmbDescription.Enabled = False
        cmbCategory.Enabled = False
        txtQty.ReadOnly = True
        txtUom.ReadOnly = True
        txtPrice.ReadOnly = True

        Return vbNull
    End Function
    Private Function unlock()
        txtMaterialCode.ReadOnly = False
        cmbDescription.Enabled = True
        cmbCategory.Enabled = True
        txtQty.ReadOnly = False
        txtUom.ReadOnly = False
        txtPrice.ReadOnly = False

        Return vbNull
    End Function

    Private Sub frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        loadCategories()

        Dim material As New Material
        longList = material.getDescriptions()

    End Sub
    Private Function refreshList()
        dtgrdList.Rows.Clear()

        Dim materials As New List(Of Material)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("materials")
            materials = JsonConvert.DeserializeObject(Of List(Of Material))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return vbNull
            Exit Function
        End Try

        For Each material In materials

            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = material.code
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = material.description
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = material.stock.ToString + " " + material.standardUom + " "
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(material.costPrice.ToString)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = material.materialCategory.name
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = " Status: " + material.status
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdList.Rows.Add(dtgrdRow)

        Next
        Return vbNull
    End Function
    Private Sub frmSalesPerson_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        refreshList()
        lock()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtId.Text = ""
        btnEdit.Enabled = True
        '  btnDelete.Enabled = False
        btnSave.Enabled = True
        btnSearch.Enabled = False
        clear()
        unlock()
        txtMaterialCode.ReadOnly = True
        txtMaterialCode.Text = "NA"
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If cmbDescription.Text <> "" Then
            '  btnDelete.Enabled = True
            btnSave.Enabled = True

        End If

        btnSearch.Enabled = True
        unlock()

        If txtId.Text <> "" Then
            txtMaterialCode.ReadOnly = True
        Else
            txtMaterialCode.ReadOnly = False
        End If
        txtQty.ReadOnly = True
    End Sub

    Private Function search(no As String, name As String) As Boolean
        Dim found = False

        Dim material As New Material
        Dim response As Object = New Object
        Dim json As JObject = New JObject

        Try
            If no <> "" Then
                response = Web.get_("materials/get_by_no?no=" + no)
            Else
                response = Web.get_("materials/get_by_description?name=" + name)
            End If
            material = JsonConvert.DeserializeObject(Of Material)(response.ToString)

            txtId.Text = material.id
            txtMaterialCode.Text = material.code
            cmbDescription.Text = material.description
            txtUom.Text = material.standardUom
            txtQty.Text = material.stock
            txtPrice.Text = LCurrency.displayValue(material.costPrice)
            If Not IsNothing(material.materialCategory) Then
                cmbCategory.Text = material.materialCategory.name
            Else
                cmbCategory.Text = ""
            End If

            found = True


            If found = True Then
                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False
                '   btnDelete.Enabled = True
            Else
                MsgBox("No matching record", vbOKOnly + vbCritical, "Error: Not found")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function

    'Dim username As String = ""

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        btnNew.Enabled = True
        btnEdit.Enabled = True
        '  btnDelete.Enabled = False
        btnSave.Enabled = False
        search(txtMaterialCode.Text, cmbCategory.Text)

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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If validateEntries() <> True Then
            Exit Sub
        End If
        Dim response As Object
        Dim material As Material

        If txtId.Text = "" Then
            material = New Material
            material.code = "NA"
            material.description = cmbDescription.Text
            If chkActive.Checked = True Then
                material.status = "ACTIVE"
            Else
                material.status = "INACTIVE"
            End If
            material.standardUom = txtUom.Text
            material.stock = txtQty.Text
            material.costPrice = LCurrency.getValue(txtPrice.Text)
            material.materialCategory.name = cmbCategory.Text

            Try
                response = Web.post(material, "materials/new")
                material = JsonConvert.DeserializeObject(Of Material)(response.ToString)

                txtId.Text = material.id
                txtMaterialCode.Text = material.code

                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False

                MsgBox("Created successifully", vbOKOnly + vbInformation, "Success")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else

            material = New Material
            material.id = txtId.Text
            material.code = txtMaterialCode.Text
            material.description = cmbDescription.Text
            material.materialCategory.name = cmbCategory.Text
            If chkActive.Checked = True Then
                material.status = "ACTIVE"
            Else
                material.status = "INACTIVE"
            End If
            material.standardUom = txtUom.Text
            material.stock = txtQty.Text
            material.costPrice = LCurrency.getValue(txtPrice.Text)
            material.materialCategory.name = cmbCategory.Text

            Try
                response = Web.put(material, "materials/edit_by_id?id=" + txtId.Text)

                lock()
                btnEdit.Enabled = True
                btnSave.Enabled = False

                If response = True Then
                    MsgBox("Updated successifully", vbOKOnly + vbInformation, "Success")
                Else
                    MsgBox("Update failed", vbOKOnly + vbInformation, "Failed")
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
        refreshList()
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected Material? The record will be completely removed from the system", vbYesNo + vbQuestion, "Delete Sales Person?")
        If res = DialogResult.Yes Then

            Dim deleted As Boolean = False
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                Dim Query As String = "DELETE FROM `materials` WHERE `material_code`='" + txtMaterialCode.Text + "'"
                conn.Open()
                command.CommandText = Query
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                conn.Close()
                deleted = True

            Catch ex As Exception
                deleted = False
                MsgBox(ex.Message + ex.GetType.ToString)
            End Try

            refreshList()
        End If
        ' btnDelete.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = False
        unlock()
        clear()
    End Sub



    Private Sub txtRollNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMaterialCode.KeyDown
        If Keys.Tab = Keys.Right Then
            search("", cmbDescription.Text)
        End If
    End Sub


    Private Function validateEntries() As Boolean
        Dim valid As Boolean = True
        Dim errorMessage As String = ""

        If txtMaterialCode.Text = "" Then
            errorMessage = "Code required"
            valid = False
        End If
        If cmbDescription.Text = "" Then
            errorMessage = "Material Description required required"
            valid = False
        End If
        If txtUom.Text = "" Then
            errorMessage = "Unit of measure required"
            valid = False
        End If
        If cmbCategory.Text = "" Then
            errorMessage = "Category required"
            valid = False
        End If

        If valid = False Then
            MsgBox(errorMessage, vbOKOnly + vbCritical, "Error: Invalid entry")
        End If
        Return valid
    End Function
    Private Sub dtgrdList_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdList.RowHeaderMouseClick
        clear()
        Dim row As Integer = -1
        Dim col As Integer = -1
        Try
            row = dtgrdList.CurrentRow.Index
            col = dtgrdList.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try

        row = dtgrdList.CurrentRow.Index
        txtMaterialCode.Text = dtgrdList.Item(0, row).Value.ToString
        search(dtgrdList.Item(0, row).Value.ToString, "")
    End Sub


    Private Sub txtAdd_TextChanged(sender As Object, e As EventArgs) Handles txtAdd.TextChanged
        If Not IsNumeric(txtAdd.Text) Or Val(txtAdd.Text) < 0 Then
            txtAdd.Text = ""
            btnAdd.Enabled = False
        End If
        If txtAdd.Text <> "" Then
            txtDeduct.Text = ""
            btnAdd.Enabled = True
            btnDeduct.Enabled = False
        End If
    End Sub

    Private Sub txtDeduct_TextChanged(sender As Object, e As EventArgs) Handles txtDeduct.TextChanged
        If Not IsNumeric(txtDeduct.Text) Or Val(txtDeduct.Text) < 0 Or Val(txtDeduct.Text) > Val(txtQty.Text) Then
            txtDeduct.Text = ""
            btnDeduct.Enabled = False
        End If
        If txtDeduct.Text <> "" Then
            txtAdd.Text = ""
            btnDeduct.Enabled = True
            btnAdd.Enabled = False
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim value As String = txtAdd.Text
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "UPDATE `materials` SET `qty`=`qty`+" + value + " WHERE `id`='" + txtId.Text + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        txtAdd.Text = ""
        Dim materialStockCard As New MaterialStockCard
        Dim materialStock As New Material
        materialStockCard.qtyIn(Day.DAY, txtMaterialCode.Text, value, materialStock.getStock(txtMaterialCode.Text), "Manual increase by user")
        search(txtMaterialCode.Text, cmbDescription.Text)
        refreshList()
    End Sub

    Private Sub btnDeduct_Click(sender As Object, e As EventArgs) Handles btnDeduct.Click
        Dim value As String = txtDeduct.Text
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "UPDATE `materials` SET `qty`=`qty`-" + value + " WHERE `id`='" + txtId.Text + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        txtDeduct.Text = ""
        Dim materialStockCard As New MaterialStockCard
        Dim materialStock As New Material
        materialStockCard.qtyOut(Day.DAY, txtMaterialCode.Text, value, materialStock.getStock(txtMaterialCode.Text), "Manual decrease by user")
        search(txtMaterialCode.Text, cmbDescription.Text)
        refreshList()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub MaterialStockStatusToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ' generate()
        If dtgrdList.RowCount = 0 Then
            MsgBox("Nothing to print")
            Exit Sub
        End If

        Dim document As Document = New Document

        document.Info.Title = "Material stock status"
        document.Info.Subject = "Material stock status"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Material stock status .pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)
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
        style.Font.Name = "Times New Roman"
        style.Font.Size = 9
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
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Material stock status", TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9
        paragraph.Format.Font.Color = Colors.Green

        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph.AddText("Date: " + Day.DAY)
        paragraph.Format.Alignment = ParagraphAlignment.Left





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

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("4.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("5.0cm")
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
        row.Cells(0).AddParagraph("Code")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Description")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Qty")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Price")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph("Amount")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph("Summary")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left



        table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalAmount As Double = 0
        Dim totalVat As Double = 0
        Dim totalDiscount As Double = 0


        For i As Integer = 0 To dtgrdList.RowCount - 1
            Dim code As String = dtgrdList.Item(0, i).Value.ToString
            Dim description As String = dtgrdList.Item(1, i).Value.ToString
            Dim qty As String = dtgrdList.Item(2, i).Value.ToString
            Dim price As String = dtgrdList.Item(3, i).Value.ToString
            Dim amount As String = Val(qty) * Val(LCurrency.getValue(price))
            Dim summary As String = "Category:  " + dtgrdList.Item(4, i).Value.ToString + " " + dtgrdList.Item(5, i).Value.ToString

            If Val(qty) > 0 Then
                totalAmount = totalAmount + Val(amount)
            End If

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Font.Size = 8
            row.Height = "5mm"
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.LightGray
            row.Cells(0).AddParagraph(code)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(description)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(qty)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(price)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Right
            row.Cells(4).AddParagraph(LCurrency.displayValue(amount.ToString))
            row.Cells(4).Format.Alignment = ParagraphAlignment.Right
            row.Cells(5).AddParagraph(summary)
            row.Cells(5).Format.Alignment = ParagraphAlignment.Left

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
        row.Cells(3).AddParagraph("Total")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph(LCurrency.displayValue(totalAmount.ToString))
        row.Cells(4).Format.Alignment = ParagraphAlignment.Right
        row.Cells(5).AddParagraph("")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("N/B: Negative stock excluded from total")
        paragraph.Format.Font.Size = 6
        paragraph.Format.Font.Italic = True
        paragraph.Format.Alignment = ParagraphAlignment.Left
        paragraph.Format.Font.Color = Colors.Red
    End Sub

    Private Sub loadCategories()
        cmbCategory.Items.Clear()
        Dim materialCategories As New MaterialCategory
        Dim list As New List(Of String)
        list.AddRange(materialCategories.getNames())
        For Each l In list
            cmbCategory.Items.Add(l)
        Next
    End Sub
End Class