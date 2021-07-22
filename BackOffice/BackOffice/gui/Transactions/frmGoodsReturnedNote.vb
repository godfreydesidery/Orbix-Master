Imports System.IO
Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmGoodsReturnedNote

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Private Sub lock()
        txtGRNNo.ReadOnly = True
        txtSupplierCode.ReadOnly = True
        txtSupplierName.ReadOnly = True
        txtReturnDate.ReadOnly = True
    End Sub
    Private Sub unlock()
        txtGRNNo.ReadOnly = False
        txtSupplierCode.ReadOnly = False
        txtSupplierName.ReadOnly = False
        txtReturnDate.ReadOnly = False
    End Sub
    Private Sub clear()
        txtGRNNo.Text = ""
        txtSupplierCode.Text = ""
        txtSupplierName.Text = ""
        txtReturnDate.Text = ""
    End Sub
    Private Sub hold()
        btnNew.Enabled = False
        'btnEdit.Enabled = False
        '  btnDelete.Enabled = False
        btnSave.Enabled = False
    End Sub
    Private Sub unhold()
        btnNew.Enabled = True
        '  btnEdit.Enabled = True
        'btnDelete.Enabled = True
        btnSave.Enabled = True
    End Sub
    Private Sub frmGoodsReturnedNote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lock()
        hold()
        btnNew.Enabled = True
        ' btnEdit.Enabled = True
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        clear()
        hold()
        lock()
        btnNew.Enabled = True
        ' btnEdit.Enabled = True
        btnSave.Enabled = True
        txtSupplierCode.ReadOnly = False
        txtSupplierName.ReadOnly = False
        txtReturnDate.Text = Day.DAY
        dtgrdNoteList.Rows.Clear()
        EDIT_MODE = "NEW"
    End Sub
    Private Sub search(noteNo As String)
        lock()
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search()

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        'btnDelete.Enabled = True
        If txtGRNNo.Text = "" Then
            txtGRNNo.ReadOnly = False
        End If
    End Sub
    Private Function searchReturn(lotNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `lot_no`, `supplier_code`, `return_date` FROM `return_to_supplier` WHERE `lot_no`='" + lotNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtGRNNo.Text = reader.GetString("lot_no")
                txtSupplierCode.Text = reader.GetString("supplier_code")
                txtReturnDate.Text = reader.GetString("return_date")
                txtSupplierName.Text = (New Supplier).getSupplierName("", reader.GetString("supplier_code"))
                success = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return success
    End Function
    Private Sub search()
        If txtGRNNo.Text <> "" Then
            If searchReturn(txtGRNNo.Text) = True Then
                refreshList(txtGRNNo.Text)
                txtGRNNo.ReadOnly = True
            Else
                MsgBox("No matching record", vbOKOnly + vbCritical, "Error: Not found")
            End If
        Else
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                'create bar code
                Dim codeQuery As String = "SELECT `supplier_code`, `supplier_name` FROM `supplier` WHERE `supplier_code`='" + txtSupplierCode.Text + "' OR `supplier_code`='" + (New Supplier).getSupplierCode("", txtSupplierName.Text) + "'"
                conn.Open()
                command.CommandText = codeQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                Dim reader As MySqlDataReader = command.ExecuteReader()
                While reader.Read
                    'txtGRNNo.Text = reader.GetString("lot_no")
                    txtSupplierCode.Text = reader.GetString("supplier_code")
                    'txtReturnDate.Text = reader.GetString("return_date")
                    txtSupplierName.Text = (New Supplier).getSupplierName("", reader.GetString("supplier_code"))
                    Exit While
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

    End Sub

    Private Sub txtGRNNo_previewkeydown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtGRNNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            search()
        End If
    End Sub
    Dim EDIT_MODE As String = ""
    Private Function generateNoteNo() As String
        Dim no As String = ""

        Dim KeyGen As RandomKeyGenerator
        Dim NumKeys As Integer
        Dim i_Keys As Integer
        Dim RandomKey As String = ""

        ' MODIFY THIS TO GET MORE KEYS    - LAITH - 27/07/2005 22:48:30 -
        NumKeys = 10

        KeyGen = New RandomKeyGenerator
        KeyGen.KeyLetters = "0987654321"
        KeyGen.KeyNumbers = "0123456789"
        KeyGen.KeyChars = 7
        For i_Keys = 1 To NumKeys
            RandomKey = KeyGen.Generate()
        Next
        no = RandomKey.ToString
        Return no
    End Function
    Private Function createReturnNote(supplierCode As String, returnDate As String) As String
        Dim lotNo As String = ""
        Dim sn As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "INSERT INTO `return_to_supplier`( `supplier_code`, `return_date`) VALUES (@supplier_code,@return_date)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@supplier_code", supplierCode)
            command.Parameters.AddWithValue("@return_date", returnDate)
            command.ExecuteNonQuery()
            sn = command.InsertId
            conn.Close()
            lotNo = "RN" + sn
            codeQuery = "UPDATE `return_to_supplier` SET `lot_no`='" + lotNo + "' WHERE `sn`='" + sn + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            sn = command.InsertId.ToString
            conn.Close()
        Catch ex As Exception
            lotNo = ""
        End Try
        Return lotNo
    End Function
    Private Function createNoteList(lotNo As String, itemCode As String, qty As String, price As String, reason As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "INSERT INTO `list_return_to_supplier`( `lot_no`, `item_code`, `qty`,`price`, `reason`) VALUES (@lot_no,@item_code,@qty,@price,@reason)"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@lot_no", lotNo)
            command.Parameters.AddWithValue("@item_code", itemCode)
            command.Parameters.AddWithValue("@qty", qty)
            command.Parameters.AddWithValue("@price", price)
            command.Parameters.AddWithValue("@reason", reason)
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Private Function deleteNoteList(lotNo) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "DELETE FROM `list_return_to_supplier` WHERE `lot_no`='" + lotNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Private Sub txtSupplierCode_previewkeydown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtSupplierCode.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            Dim supp As String = (New Supplier).getSupplierName("", txtSupplierCode.Text)
            If supp = "" Then
                MsgBox("Could not find supplier with supplier code: " + txtSupplierCode.Text, vbOKOnly + vbCritical, "Error: Not found")
                txtSupplierCode.Text = ""
            Else
                txtSupplierName.Text = supp
                lock()
            End If
        End If
    End Sub

    Private Sub txtSupplierName_TextChanged(sender As Object, e As EventArgs) Handles txtSupplierName.TextChanged

    End Sub
    Private Function refreshList(noteNo As String)
        dtgrdNoteList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `item_code`, `qty`, `price`, `reason` FROM `list_return_to_supplier` WHERE `lot_no`='" + noteNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim itemCode As String = ""
            Dim description As String = ""
            Dim quantity As String = ""
            Dim costPrice As String = ""
            Dim amount As String = ""
            Dim details As String = ""

            Dim totalAmount As Double = 0

            While reader.Read
                Dim item As New Item
                itemCode = reader.GetString("item_code")
                item.searchItem(itemCode)
                description = item.GL_LONG_DESCR
                quantity = reader.GetString("qty")
                costPrice = LCurrency.displayValue(reader.GetString("price"))
                amount = LCurrency.displayValue((Val(reader.GetString("price")) * Val(quantity)).ToString)
                details = reader.GetString("reason")

                totalAmount = totalAmount + LCurrency.getValue(amount.ToString)

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = item.getBarCodesString(itemCode)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = itemCode
                dtgrdRow.Cells.Add(dtgrdCell)


                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = description
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = quantity
                dtgrdRow.Cells.Add(dtgrdCell)


                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = costPrice
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = amount
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = details
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdNoteList.Rows.Add(dtgrdRow)

            End While
            conn.Close()
            txtTotalAmount.Text = LCurrency.displayValue(totalAmount.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function
    Private Sub calculateTotal()
        Dim amount As String = ""
        Try
            For i As Integer = 0 To dtgrdNoteList.RowCount - 2
                Dim qty As String = dtgrdNoteList.Item(3, i).Value
                Dim price As String = LCurrency.getValue(dtgrdNoteList.Item(4, i).Value)
                amount = Val(amount) + Val(price) * Val(qty).ToString
            Next
            txtTotalAmount.Text = LCurrency.displayValue(amount.ToString)
        Catch ex As Exception

        End Try

    End Sub
    Private Function validateList() As Boolean
        Dim valid As Boolean = True

        For i As Integer = 0 To dtgrdNoteList.RowCount - 2
            Dim barCode As String = dtgrdNoteList.Item(0, i).Value
            Dim itemCode As String = dtgrdNoteList.Item(1, i).Value
            Dim qty As String = dtgrdNoteList.Item(3, i).Value
            Dim price As String = LCurrency.getValue(dtgrdNoteList.Item(4, i).Value)
            Dim reason As String = dtgrdNoteList.Item(6, i).Value
            If Val(qty) <= 0 Then
                valid = False
            End If
        Next

        Return valid
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If EDIT_MODE = "NEW" Then
            If dtgrdNoteList.RowCount <= 1 Then
                MsgBox("Can not save an empty list!")
                Exit Sub
            End If

            If validateList() = False Then
                MsgBox("List invalid. Please cross check the list.", vbOKOnly)
                Exit Sub
            End If
            Dim noteNo As String = ""
            While True
                noteNo = createReturnNote(txtSupplierCode.Text, txtReturnDate.Text)
                If noteNo <> "" Then
                    Exit While
                End If
            End While
            txtGRNNo.Text = noteNo
            deleteNoteList(noteNo)
            Dim inventory As New Inventory

            For i As Integer = 0 To dtgrdNoteList.RowCount - 2
                Dim itemCode As String = dtgrdNoteList.Item(1, i).Value
                Dim qty As String = dtgrdNoteList.Item(3, i).Value
                Dim price As String = LCurrency.getValue(dtgrdNoteList.Item(4, i).Value)
                Dim reason As String = dtgrdNoteList.Item(6, i).Value
                createNoteList(noteNo, itemCode, qty, price, reason)
                inventory.adjustInventory(itemCode, -Val(qty))
                Dim stockCard As New StockCard
                stockCard.qtyOut(Day.DAY, itemCode, Val(qty), inventory.getInventory(itemCode), "Return to vendor, reason: " + reason)
            Next
            EDIT_MODE = ""
            refreshList(noteNo)
            MsgBox("The goods return note saved successifully.", vbOKOnly + vbInformation, "Success: GRN Saved")
        Else
            Exit Sub
        End If
        print()
    End Sub
    Private Sub print()
        If txtGRNNo.Text = "" Then
            MsgBox("Printing an unsaved Goods Returned Note is not allowed.", vbOKOnly + vbExclamation, "Error: ")
            Exit Sub
        End If

        Dim document As Document = New Document

        document.Info.Title = "Goods Returned Note"
        document.Info.Subject = "Goods Returned Note"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Goods Returned Note " & txtGRNNo.Text & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)
    End Sub

    Private Sub dtgrdNoteList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdNoteList.CellEndEdit

        If txtSupplierCode.Text = "" Then
            MsgBox("Supplier information missing. Please select a valid supplier.", vbOKOnly + vbCritical, "Error: Missing supplier information")
            Try
                dtgrdNoteList.Rows.Clear()
            Catch ex As Exception

            End Try

            Exit Sub
        End If
        lock()
        If EDIT_MODE = "" Then
            MsgBox("Only a new Note can be edited !", vbOKOnly + vbExclamation)
            refreshList(txtGRNNo.Text)
            Exit Sub
        End If

        Try

            Dim row As Integer = dtgrdNoteList.CurrentCell.RowIndex
            Dim col As Integer = dtgrdNoteList.CurrentCell.ColumnIndex

            Dim itemCode As String = dtgrdNoteList.Item(1, row).Value

            If dtgrdNoteList.CurrentCell.ColumnIndex = 1 Or dtgrdNoteList.CurrentCell.ColumnIndex = 0 Or dtgrdNoteList.CurrentCell.ColumnIndex = 2 Then
                Dim item As New Item
                If dtgrdNoteList.CurrentCell.ColumnIndex = 0 Then
                    itemCode = item.getItemCode(dtgrdNoteList.Item(0, row).Value, "")
                    dtgrdNoteList.Item(1, row).Value = itemCode
                End If
                If dtgrdNoteList.CurrentCell.ColumnIndex = 2 Then
                    itemCode = item.getItemCode("", dtgrdNoteList.Item(2, row).Value)
                    dtgrdNoteList.Item(1, row).Value = itemCode
                End If
                If item.searchItem(itemCode) = True Then
                    If item.GL_SUPPLIER_ID <> (New Supplier).getSupplierID(txtSupplierCode.Text, "") Then
                        MsgBox("Item not available for this supplier!", vbOKOnly + vbExclamation, "Error: Invalid item")
                        dtgrdNoteList.Rows.Remove(dtgrdNoteList.CurrentRow)
                        Exit Sub
                    End If
                    dtgrdNoteList.Item(2, row).Value = item.GL_LONG_DESCR
                    dtgrdNoteList.Item(4, row).Value = item.GL_COST_PRICE
                Else
                    MsgBox("Could not find item", vbOKOnly + vbCritical, "Error: Not found")
                    dtgrdNoteList.Rows.Remove(dtgrdNoteList.CurrentRow)
                End If
            End If
            If dtgrdNoteList.CurrentCell.ColumnIndex = 3 Then
                Dim qty As String = dtgrdNoteList.Item(3, row).Value
                If IsNumeric(qty) And qty > 0 Then
                    dtgrdNoteList.Item(5, row).Value = LCurrency.displayValue((Val(qty) * Val(LCurrency.getValue(dtgrdNoteList.Item(4, row).Value))))
                Else
                    MsgBox("Invalid quantity value. Quantity values should be more than zero", vbOKOnly + vbCritical, "Error: Invalid entry")
                End If
            End If

        Catch ex As Exception

        End Try
        calculateTotal()
    End Sub

    Private Sub txtSupplierCode_TextChanged(sender As Object, e As EventArgs) Handles txtSupplierCode.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        print()
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
        paragraph.AddFormattedText("Goods Returned Note", TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9
        paragraph.Format.Font.Color = Colors.Green

        paragraph = section.AddParagraph()

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("No:          " + txtGRNNo.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Vendor:      ")
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("CODE:        " + txtSupplierCode.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("             " + txtSupplierName.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Date:        " + txtReturnDate.Text)
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

        'Before you can add a row, you must define the columns
        Dim column As Column

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Center

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Center


        column = table.AddColumn("7cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True

        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Bar Code")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Code")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Description")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Qty")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph("Price@")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Center
        row.Cells(5).AddParagraph("Amount")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Center


        table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalQty As Double = 0

        For i As Integer = 0 To dtgrdNoteList.RowCount - 2
            Dim barcode As String = dtgrdNoteList.Item(0, i).Value
            Dim code As String = dtgrdNoteList.Item(1, i).Value
            Dim descr As String = dtgrdNoteList.Item(2, i).Value
            Dim qty As String = dtgrdNoteList.Item(3, i).Value
            Dim price As String = dtgrdNoteList.Item(4, i).Value
            Dim amount As String = dtgrdNoteList.Item(5, i).Value
            totalQty = totalQty + Val(qty)
            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Font.Size = 7
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.White
            row.Cells(0).AddParagraph(barcode)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(code)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(descr)
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
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph()
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph()
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph()
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph()
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(4).AddParagraph()
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph()
        row.Cells(5).Format.Alignment = ParagraphAlignment.Right


        row = table.AddRow()
        row.Format.Font.Bold = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph()
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph()
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph()
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph()
        row.Cells(3).Format.Alignment = ParagraphAlignment.Right
        row.Cells(4).AddParagraph()
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left
        row.Cells(5).AddParagraph(txtTotalAmount.Text)
        row.Cells(5).Format.Alignment = ParagraphAlignment.Right


        table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)


    End Sub

    Private Sub btnEdit_Click_1(sender As Object, e As EventArgs) Handles btnEdit.Click
        lock()
        clear()
        dtgrdNoteList.Rows.Clear()
        txtGRNNo.ReadOnly = False
        EDIT_MODE = ""
    End Sub

    Private Sub txtSupplierName_MouseClick(sender As Object, e As MouseEventArgs) Handles txtSupplierName.MouseClick
        Dim list As New List(Of String)
        Dim mySource As New AutoCompleteStringCollection
        Dim supplier As New Supplier
        list = supplier.getNames()
        mySource.AddRange(list.ToArray)
        txtSupplierName.AutoCompleteCustomSource = mySource
        txtSupplierName.AutoCompleteMode = AutoCompleteMode.Suggest
        txtSupplierName.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub

    Private Sub txtSupplierName_MouseEnter(sender As Object, e As EventArgs) Handles txtSupplierName.MouseEnter
        Dim list As New List(Of String)
        Dim mySource As New AutoCompleteStringCollection
        Dim supplier As New Supplier
        list = supplier.getNames()
        mySource.AddRange(list.ToArray)
        txtSupplierName.AutoCompleteCustomSource = mySource
        txtSupplierName.AutoCompleteMode = AutoCompleteMode.Suggest
        txtSupplierName.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub

    Private Sub dtgrdNoteList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdNoteList.CellContentClick

    End Sub
End Class