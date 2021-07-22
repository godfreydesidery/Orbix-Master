Imports System.IO
Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmCreditNoteReport

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Private Function refreshList(filtered As Boolean)
        dtgrdItemList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = ""
            If filtered = True Then
                query = "SELECT `sn`, `cr_no`, `cr_date`, `cr_bill_no`, `cr_amount`, `status`, `cr_details` FROM `customer_credit_notes` WHERE `cr_no`='" + txtCrNo.Text + "' OR `cr_date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "'"
            Else
                query = "SELECT `sn`, `cr_no`, `cr_date`, `cr_bill_no`, `cr_amount`, `status`, `cr_details` FROM `customer_credit_notes`"
            End If
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim crNo As String = ""
            Dim billNo As String = ""
            Dim crDate As String = ""
            Dim crAmount As String = ""
            Dim crType As String = ""
            Dim status As String = ""
            Dim creditor As String = ""
            Dim details As String = ""

            While reader.Read

                crNo = reader.GetString("cr_no")
                billNo = reader.GetString("cr_bill_no")
                crDate = reader.GetString("cr_date")
                crAmount = reader.GetString("cr_amount")
                status = reader.GetString("status")
                details = reader.GetString("cr_details")

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = crNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = billNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = crDate
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = crAmount
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = status
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = details
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdItemList.Rows.Add(dtgrdRow)
            End While
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
        style.Font.Name = "Times New Roman"
        style.Font.Size = 9
        'Create a new style called Reference based on style Normal
        style = doc.Styles.AddStyle("Reference", "Normal")
        style.ParagraphFormat.SpaceBefore = "5mm"
        style.ParagraphFormat.SpaceAfter = "5mm"
        style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right)

    End Sub
    Private Function print()


        Dim document As Document = New Document

        document.Info.Title = "Daily Sales Report"
        document.Info.Subject = "Daily Sales Report"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Credit Note Report .pdf"

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
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Credit Note Report", TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9
        paragraph.Format.Font.Color = Colors.Green

        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("From:  " + dateStart.Text + "  To:  " + dateEnd.Text, TextFormat.Bold)
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9
        paragraph.Format.Font.Color = Colors.Green
        paragraph = section.AddParagraph()


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


        column = table.AddColumn("3cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("3cm")
        column.Format.Alignment = ParagraphAlignment.Right

        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.HeadingFormat = True
        row.Format.Font.Bold = True
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("CR No")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Bill No")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Center
        row.Cells(2).AddParagraph("Date")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Center
        row.Cells(3).AddParagraph("Amount")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Center
        row.Cells(4).AddParagraph("Status")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Center
        row.Cells(5).AddParagraph("Details")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Center

        table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalQty As Double = 0

        For i As Integer = 0 To dtgrdItemList.RowCount - 1

            Dim crNo As String = dtgrdItemList.Item(0, i).Value
            Dim billNo As String = dtgrdItemList.Item(1, i).Value
            Dim date_ As String = dtgrdItemList.Item(2, i).Value
            Dim amount As String = dtgrdItemList.Item(3, i).Value
            Dim status As String = dtgrdItemList.Item(4, i).Value
            Dim details As String = dtgrdItemList.Item(5, i).Value

            row = table.AddRow()
            row.Format.Font.Bold = False
            row.HeadingFormat = False
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.White
            row.Cells(0).AddParagraph(crNo)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(billNo)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Center
            row.Cells(2).AddParagraph(date_)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Center
            row.Cells(3).AddParagraph(amount)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Center
            row.Cells(4).AddParagraph(status)
            row.Cells(4).Format.Alignment = ParagraphAlignment.Center
            row.Cells(5).AddParagraph(details)
            row.Cells(5).Format.Alignment = ParagraphAlignment.Center

            table.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Next

        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("***End of Report***")
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Size = 9

    End Sub
    Private Sub frmCreditNoteReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dateStart_ValueChanged(sender As Object, e As EventArgs) Handles dateStart.ValueChanged

    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        refreshList(False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        refreshList(True)
    End Sub
    Private Function clear()
        txtCrNo.Text = ""
        dateStart.Text = ""
        dateEnd.Text = ""
        dtgrdItemList.Rows.Clear()
        Return vbNull
    End Function
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub dtgrdItemList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdItemList.CellContentClick

    End Sub

    Private Sub txtCrNo_previewkeydown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtCrNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            refreshList(True)
            If dtgrdItemList.RowCount = 0 Then
                MsgBox("No matching record", vbOKOnly + vbExclamation, "Error: Not found")
            End If
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If dtgrdItemList.RowCount = 0 Then
            MsgBox("Could not print. List empty", vbOKOnly + vbExclamation, "Error: Empty list")
            Exit Sub
        End If
        print()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub txtCrNo_TextChanged(sender As Object, e As EventArgs) Handles txtCrNo.TextChanged

    End Sub
End Class