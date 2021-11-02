Imports System.IO
Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmZHistory
    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        txtFrom.Text = dateStart.Text
        txtTo.Text = dateEnd.Text
        Dim saleVatExclusive As Double = 0
        getTotalSales(dateStart.Text, dateEnd.Text)
        saleVatExclusive = getTotalSalesVatIncl(dateStart.Text, dateEnd.Text) - getTotalVat(dateStart.Text, dateEnd.Text)
        txtSalesVatExclusive.Text = LCurrency.displayValue(saleVatExclusive.ToString)
        getTotalDiscount(dateStart.Text, dateEnd.Text)
        getTotalRefunds(dateStart.Text, dateEnd.Text)
        Dim netSales As Double = 0
        Dim sale1 As Double = getTotalSalesVatIncl(dateStart.Text, dateEnd.Text)
        Dim refund As Double = getTotalRefunds(dateStart.Text, dateEnd.Text)
        netSales = sale1 - refund
        txtTotalNetSales.Text = LCurrency.displayValue(netSales.ToString)
        getTotalVariance(dateStart.Text, dateEnd.Text)
        getTotalFloat(dateStart.Text, dateEnd.Text)
        getActualCreditCollections(dateStart.Text, dateEnd.Text)
        getTotalCustomers(dateStart.Text, dateEnd.Text)
        getTotalCashPayment(dateStart.Text, dateEnd.Text)
        getTotalCollection(dateStart.Text, dateEnd.Text)
        getTotalCashPickup(dateStart.Text, dateEnd.Text)
        getTotalPettyCash(dateStart.Text, dateEnd.Text)

    End Sub
    Private Function getTotalFloat(startDate As String, endDate As String) As Double
        Dim float As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT SUM(`amount`) AS `float` FROM `float_balance`"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtTotalFloat.Text = LCurrency.displayValue(reader.GetDouble("float").ToString)
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return float
    End Function
    Private Function getTotalCashPayment(startDate As String, endDate As String) As Double
        Dim total As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT SUM(`payment`.`cash`) AS `cash` FROM `payment`,`sale`WHERE `payment`.`sale_id`=`sale`.`id` AND `sale`.`date` BETWEEN '" + startDate + "' AND  '" + endDate + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                total = reader.GetDouble("cash")
                txtTotalCash.Text = LCurrency.displayValue(total.ToString)
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return total
    End Function

    Private Function getTotalCashPickup(startDate As String, endDate As String) As Double
        Dim total As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT  SUM(`cash`) AS `cash` FROM `collections` WHERE `date` BETWEEN '" + startDate + "' AND '" + endDate + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                total = reader.GetDouble("cash")
                txtCashPickup.Text = LCurrency.displayValue(total.ToString)
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return total
    End Function
    Private Function getTotalCustomers(startDate As String, endDate As String) As Integer
        Dim total As Integer = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT COUNT(`id`) AS `number` FROM `sale` WHERE `date` BETWEEN '" + startDate + "' AND '" + endDate + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtTotalCustomers.Text = (reader.GetInt64("number")).ToString
                total = reader.GetInt64("number")
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return total
    End Function
    Private Function getActualCreditCollections(startDate As String, endDate As String) As Double
        Dim float As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT  SUM(`cr_card`)AS `cr_card`, SUM(`cheque`)AS `cheque`,  SUM(`cr_note`) AS `cr_note` FROM `collections` WHERE `date` BETWEEN '" + startDate + "' AND '" + endDate + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtActualCheques.Text = LCurrency.displayValue(reader.GetDouble("cheque").ToString)
                txtActualCrCards.Text = LCurrency.displayValue(reader.GetDouble("cr_card").ToString)
                txtActualCrNotes.Text = LCurrency.displayValue(reader.GetDouble("cr_note").ToString)
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return float
    End Function
    Private Function getTotalVariance(startDate As String, endDate As String) As Double
        Dim variance As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT SUM(`cash`) AS `cash`, SUM(`voucher`) AS `voucher`, SUM(`cheque`) AS `cheque`, SUM(`deposit`) AS `deposit`,SUM( `loyalty`)AS `loyalty`, SUM(`cr_card`) AS `cr_card`, SUM(`cap`)AS `cap`,SUM( `invoice`) AS `invoice`, SUM(`cr_note`)AS `cr_note`,SUM( `mobile`) AS `mobile` FROM `till_total`"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                variance = variance + reader.GetDouble("cash")
                variance = variance + reader.GetDouble("voucher")
                variance = variance + reader.GetDouble("cheque")
                variance = variance + reader.GetDouble("deposit")
                variance = variance + reader.GetDouble("loyalty")
                variance = variance + reader.GetDouble("cr_card")
                variance = variance + reader.GetDouble("cap")
                variance = variance + reader.GetDouble("invoice")
                variance = variance + reader.GetDouble("cr_note")
                variance = variance + reader.GetDouble("mobile")
                txtTotalVariance.Text = LCurrency.displayValue(variance.ToString)
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return variance
    End Function
    Private Function getTotalCollection(startDate As String, endDate As String) As Double
        Dim total As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT SUM(`cash`) AS `cash`, SUM(`voucher`) AS `voucher`, SUM(`deposit`) AS `deposit`, SUM(`loyalty`) AS `loyalty`, SUM(`cr_card`) AS `cr_card`, SUM(`cheque`) AS `cheque`, SUM(`cap`) AS `cap`, SUM(`invoice`) AS `invoice`, SUM(`cr_note`) AS `cr_note`, SUM(`mobile`) AS `mobile` FROM `collections` WHERE `date` BETWEEN '" + startDate + "' AND '" + endDate + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                total = total + reader.GetDouble("cash")
                total = total + reader.GetDouble("voucher")
                total = total + reader.GetDouble("cheque")
                total = total + reader.GetDouble("deposit")
                total = total + reader.GetDouble("loyalty")
                total = total + reader.GetDouble("cr_card")
                total = total + reader.GetDouble("cap")
                total = total + reader.GetDouble("invoice")
                total = total + reader.GetDouble("cr_note")
                total = total + reader.GetDouble("mobile")
                txtTotalCollections.Text = LCurrency.displayValue(total.ToString)
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return total
    End Function
    Private Function getTotalRefunds(startDate As String, endDate As String) As Double
        Dim totalRefund As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT SUM(`amount`) AS `amount` FROM `refunds` WHERE `date`BETWEEN '" + startDate + "' AND '" + endDate + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtRefunds.Text = LCurrency.displayValue(reader.GetDouble("amount").ToString)
                totalRefund = reader.GetDouble("amount")
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return totalRefund
    End Function
    Private Function getTotalDiscount(startDate As String, endDate As String) As Double
        Dim totalDiscount As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT SUM(`discount`) AS `discount` FROM `sale` WHERE `date`BETWEEN '" + startDate + "' AND '" + endDate + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtDiscount.Text = LCurrency.displayValue(reader.GetDouble("discount").ToString)
                totalDiscount = reader.GetDouble("discount")
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return totalDiscount
    End Function
    Private Function getTotalPettyCash(startDate As String, endDate As String) As Double
        Dim totalPettyCash As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT SUM(`amount`) AS `amount` FROM `petty_cash` WHERE DATE(`date_time`)BETWEEN '" + startDate + "' AND '" + endDate + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtTotalPettyCash.Text = LCurrency.displayValue(reader.GetDouble("amount").ToString)
                totalPettyCash = reader.GetDouble("amount")
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return totalPettyCash
    End Function
    Private Function getTotalSalesVatIncl(startDate As String, endDate As String) As Double
        Dim totalSales As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT SUM(`amount`) AS `amount` FROM `sale` WHERE `date`BETWEEN '" + startDate + "' AND '" + endDate + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtTotalSales.Text = LCurrency.displayValue(reader.GetDouble("amount").ToString)
                txtSalesTotal.Text = LCurrency.displayValue(reader.GetDouble("amount").ToString)
                totalSales = reader.GetDouble("amount")
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return totalSales
    End Function

    Private Function getTotalVat(startDate As String, endDate As String) As Double
        Dim totalTax As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT SUM(`tax_return`) AS `tax` FROM `sale` WHERE `date`BETWEEN '" + startDate + "' AND '" + endDate + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtVatOnSales.Text = LCurrency.displayValue(reader.GetDouble("tax").ToString)
                totalTax = reader.GetDouble("tax")
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return totalTax
    End Function
    Private Function getTotalSales(startDate As String, endDate As String)
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `sale`.`date` AS `date`,SUM(`payment`.`cash`) AS `cash`,SUM(`payment`.`voucher`) AS `voucher`,SUM(`payment`.`cheque`)AS `cheque`,SUM(`payment`.`deposit`)AS `deposit`,SUM(`payment`.`loyalty`)AS `loyalty`,SUM(`payment`.`cr_card`)AS `cr_card`,SUM(`payment`.`cap`) AS `cap`,SUM(`payment`.`invoice`)AS `invoice`,SUM(`payment`.`cr_note`) AS `cr_note`,SUM(`payment`.`mobile`) AS `mobile` FROM `sale`,`payment` WHERE `sale`.`id`=`payment`.`sale_id` AND `sale`.`date` BETWEEN '" + dateStart.Text + "' AND '" + dateEnd.Text + "' GROUP BY 'date'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtTotalCashSales.Text = LCurrency.displayValue(reader.GetDouble("cash").ToString)
                txtTotalVoucherSales.Text = LCurrency.displayValue(reader.GetDouble("voucher").ToString)
                txtTotalChequeSales.Text = LCurrency.displayValue(reader.GetDouble("cheque").ToString)
                txtTotalDepositSales.Text = LCurrency.displayValue(reader.GetDouble("deposit").ToString)
                txtTotalLoyaltySales.Text = LCurrency.displayValue(reader.GetDouble("loyalty").ToString)
                txtTotalCreditCardSales.Text = LCurrency.displayValue(reader.GetDouble("cr_card").ToString)
                txtTotalGiftVoucherSales.Text = LCurrency.displayValue(reader.GetDouble("voucher").ToString)
                txtTotalCapSales.Text = LCurrency.displayValue(reader.GetDouble("cap").ToString)
                txtTotalCrNoteSales.Text = LCurrency.displayValue(reader.GetDouble("cr_note").ToString)
                txtTotalMobileSales.Text = LCurrency.displayValue(reader.GetDouble("mobile").ToString)
                txtTotalInvoiceSales.Text = LCurrency.displayValue(reader.GetDouble("invoice").ToString)
                Exit While
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return vbNull
    End Function

    Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs) Handles txtTotalSales.TextChanged

    End Sub

    Private Sub frmZHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFrom.Text = ""
        txtTo.Text = ""
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
        Dim startDate As String = dateStart.Text
        Dim endDate As String = dateEnd.Text

        Dim document As Document = New Document

        document.Info.Title = "Z History"
        document.Info.Subject = "Z History"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Z History " & dateStart.Text & " to " & dateEnd.Text & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(fileName)

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
        documentTitle.AddText("Z History")
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
        paragraph.AddText("From:  " + dateStart.Text + "  To:  " + dateEnd.Text)
        paragraph.Format.Alignment = ParagraphAlignment.Left
        paragraph.Format.Font.Size = 9
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

        column = table.AddColumn("5cm")
        column.Format.Alignment = ParagraphAlignment.Center


        column = table.AddColumn("5cm")
        column.Format.Alignment = ParagraphAlignment.Right



        'Create the header of the table

        Dim row As Row

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White

        row.Cells(0).AddParagraph("Total Sales Excluding VAT")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtSalesVatExclusive.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("VAT on sale")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtVatOnSales.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph()
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Format.Font.Bold = True
        row.Cells(0).AddParagraph("Total Sales")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalSales.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph()
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Cash Sales ")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalCashSales.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Voucher Sales")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalVoucherSales.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Cheque Sales")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalChequeSales.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Deposit Sales")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalDepositSales.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Loyalty Sales")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalLoyaltySales.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total CR Card Sales")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalCreditCardSales.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total G.V. Sales")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalGiftVoucherSales.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total CAP Sales")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalCapSales.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Invoice Sales")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalInvoiceSales.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total CR Note Sales")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalCrNoteSales.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Mobile Sales")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalMobileSales.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph()
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Round Off")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalRoundOffs.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Sales")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalSales.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Discount")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtDiscount.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Refund ")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtRefunds.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph()
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Format.Font.Bold = True
        row.Cells(0).AddParagraph("Total Net Sales")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalNetSales.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph()
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Cash")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalCash.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Cash Pickups")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtCashPickup.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Collections")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalCollections.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Float")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalFloat.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Actual Cheques")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtActualCheques.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Actual CR Cards")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtActualCrCards.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Actual CR Notes")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtActualCrNotes.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Variance")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalVariance.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Petty Cash")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalPettyCash.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph()
        row.Cells(1).Format.Alignment = ParagraphAlignment.Right
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        row = table.AddRow()
        row.Format.Alignment = ParagraphAlignment.Center
        row.Borders.Color = Colors.White
        row.Cells(0).AddParagraph("Total Customers")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph(txtTotalCustomers.Text)
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs)
        If txtFrom.Text = "" Or txtTo.Text = "" Then
            MsgBox("Select Range", vbOKOnly + vbExclamation, "")
            Exit Sub
        End If
        print()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dateStart_ValueChanged(sender As Object, e As EventArgs) Handles dateStart.ValueChanged

    End Sub

    Private Sub btnExportToPDF_Click(sender As Object, e As EventArgs) Handles btnExportToPDF.Click
        If txtFrom.Text = "" Or txtTo.Text = "" Then
            MsgBox("Select Range", vbOKOnly + vbExclamation, "")
            Exit Sub
        End If
        print()
    End Sub
End Class