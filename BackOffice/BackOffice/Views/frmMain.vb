Imports System.Threading
Imports System.Windows.Forms

Public Class frmMain

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        If MsgBox("Exit Application?", vbYesNo + vbQuestion, "Exit") = MsgBoxResult.Yes Then
            Me.Close()
            Application.Exit()
        End If
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Dim t As New Thread(
        Sub()
            Dim system As New LSystem
            Dim errmsg As String = ""
            While system.refreshSystem = ""

            End While
            End
        End Sub)

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'lblCompany.Text = Company.NAME
        Try
            pctLogo.Image = Image.FromStream(New System.IO.MemoryStream(Company.GL_LOGO))
        Catch ex As Exception

        End Try

        tstrpAlias.Text = tstrpAlias.Text + " " + User.CURRENT_FIRST_NAME + "  " + User.CURRENT_LAST_NAME
        ' t.Start()
        tsrpDateTime.Text = "System Date: " + Day.DAY.ToString("yyyy-MM-dd")


        If User.authorize("VIEW REPORTS") Then
            tlstripReports.Enabled = True
        Else
            tlstripReports.Enabled = False
        End If

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs)
        If User.authorize("END DAY") Then
            frmEndDay.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub PrintPriceLabelsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPriceLabelsToolStripMenuItem.Click
        frmPriceLabels.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If User.authorize("PRODUCT MANAGEMENT") = True Then
            frmProductMaster.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If User.authorize("PRODUCT INQUIRY") = True Then
            frmProductInquiry.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub MassManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MassManagementToolStripMenuItem.Click
        If User.authorize("PRODUCT MANAGEMENT") Then

            frmMassManager.ShowDialog()

        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub CorporateCustomersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CorporateCustomersToolStripMenuItem.Click
        frmCorporateCustomers.ShowDialog()
    End Sub

    Private Sub CompanyProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompanyProfileToolStripMenuItem.Click
        If User.authorize("COMPANY MANAGEMENT") Then
            frmCompany.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub SuppliersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuppliersToolStripMenuItem.Click
        If User.authorize("SUPPLIER MANAGEMENT") Then
            frmSuppliers.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        If User.authorize("PROCUREMENT") = True Then
            frmLPO.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        'If User.CURRENT_ROLE = "ADMIN" Or User.CURRENT_ROLE = "MANAGER" Or User.CURRENT_ROLE = "ASSISTANT MANAGER" Or User.CURRENT_ROLE = "PROCUREMENT" Then
        If User.authorize("PROCUREMENT") = True Then
            frmPurchaseOrder.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        If User.authorize("PROCUREMENT") = True Then
            frmBlankLPO.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        If User.authorize("PROCUREMENT") = True Then
            frmPrintLPO.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click

        If User.authorize("PROCUREMENT") Then
            frmGoodsReceivedNote.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        If User.authorize("ACCOUNTS") Then
            frmGoodsReturnedByCustomers.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click

        If User.authorize("ACCOUNTS") Then
            frmCustomerCreditNote.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        If User.authorize("ACCOUNTS") Then
            frmSupplierCreditNote.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub AllocationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllocationsToolStripMenuItem.Click
        If User.authorize("ACCOUNTS") Then
            ' frmAllocations.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub ReceiptsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceiptsToolStripMenuItem.Click

        If User.authorize("ACCOUNTS") Then
            frmReceipts.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub QuotationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuotationsToolStripMenuItem.Click
        If User.authorize("ACCOUNTS") Then
            'frmQuotations.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub ReturnToVendorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToVendorToolStripMenuItem.Click
        If User.authorize("PROCUREMENT") Then
            frmReturnToVendor.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub SalesLedgeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesLedgeToolStripMenuItem.Click

        If User.authorize("ACCOUNTS") Then
            'frmSalesLedge.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub SalesJournalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesJournalToolStripMenuItem.Click
        If User.authorize("ACCOUNTS") Then
            'frmSalesJournal.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub VendorsInvoiceBookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VendorsInvoiceBookToolStripMenuItem.Click

        If User.authorize("ACCOUNTS") Then
            frmInvoiceBook.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub SalesInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesInvoiceToolStripMenuItem.Click
        frmSalesInvoice.ShowDialog()
        ' If User.authorize("SALE INVOICE") Then
        '  frmSaleInvoice.ShowDialog()
        '     Else
        'MsgBox("Access denied!", vbOKOnly + vbExclamation)
        '   End If
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        frmSalesPerson.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        frmMaterialCategory.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        frmPackingList.ShowDialog()
    End Sub

    Private Sub DetailedDailySalesReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetailedDailySalesReportToolStripMenuItem.Click
        frmDetailedDailySalesReport.ShowDialog()
    End Sub

    Private Sub SummarizedDailySalesReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SummarizedDailySalesReportToolStripMenuItem.Click
        frmDailySummarySalesReport.ShowDialog()
    End Sub

    Private Sub ConsolidatedDailySalesReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsolidatedDailySalesReportToolStripMenuItem.Click
        frmConsolidatedDailySalesReport.ShowDialog()
    End Sub

    Private Sub DebtReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DebtReportToolStripMenuItem.Click
        frmDebtReport.ShowDialog()
    End Sub

    Private Sub DebtPaymentHistoryReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DebtPaymentHistoryReportToolStripMenuItem.Click
        frmDebtPayment.ShowDialog()
    End Sub

    Private Sub DamagesReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DamagesReportToolStripMenuItem.Click
        frmDamagesReport.ShowDialog()
    End Sub

    Private Sub MaterialStockStatusReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaterialStockStatusReportToolStripMenuItem.Click
        frmMaterialStockStatus.ShowDialog()
    End Sub

    Private Sub MaterialStockCardReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaterialStockCardReportToolStripMenuItem.Click
        frmMaterialStockCard.ShowDialog()
    End Sub

    Private Sub MaterialUsageReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaterialUsageReportToolStripMenuItem.Click
        frmMaterialUsageReport.ShowDialog()
    End Sub

    Private Sub DailyProductionReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailyProductionReportToolStripMenuItem.Click
        frmProductionReport.ShowDialog()
    End Sub

    Private Sub MaterialVsProductionReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaterialVsProductionReportToolStripMenuItem.Click
        frmMaterialVsProduction.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        frmCustomerClaim.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        frmMaterials.ShowDialog()
    End Sub

    Private Sub CustomProductionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomProductionToolStripMenuItem.Click
        frmCustomProduction.ShowDialog()
    End Sub

    Private Sub DailySalesReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailySalesReportToolStripMenuItem.Click
        If User.authorize("VIEW REPORTS") Then
            frmDailySalesReport.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub ZHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZHistoryToolStripMenuItem.Click
        If User.authorize("VIEW REPORTS") Then
            frmZHistory.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub CashierVarianceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashierVarianceToolStripMenuItem.Click
        If User.authorize("VIEW REPORTS") Then
            frmCashierVariance.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub CreditNoteReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditNoteReportsToolStripMenuItem.Click
        If User.authorize("VIEW REPORTS") Then
            frmCreditNoteReport.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub PettyCashReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PettyCashReportToolStripMenuItem.Click
        frmPettyCash.ShowDialog()
    End Sub

    Private Sub CreditCardSalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditCardSalesToolStripMenuItem.Click
        ' frmCreditCardSales.ShowDialog()
    End Sub

    Private Sub GiftVoucherSalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GiftVoucherSalesToolStripMenuItem.Click
        If User.authorize("VIEW REPORTS") Then
            '  frmGiftVoucherSales.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub ReturnedBottlesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnedBottlesToolStripMenuItem.Click
        If User.authorize("VIEW REPORTS") Then
            'frmReturnedBottles.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub ProductListingReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductListingReportToolStripMenuItem.Click
        If User.authorize("VIEW REPORTS") Then
            frmProductListingReport.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub SupplySalesReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplySalesReportToolStripMenuItem.Click
        If User.authorize("VIEW REPORTS") Then
            frmSupplySalesReport.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub StockCardsReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockCardsReportToolStripMenuItem.Click
        If User.authorize("VIEW REPORTS") Then
            frmStockCardReports.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub FastMovingItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FastMovingItemsToolStripMenuItem.Click
        If User.authorize("VIEW REPORTS") Then
            frmFastMovingItems.ShowDialog()

        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub SupplierStockStatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierStockStatusToolStripMenuItem.Click
        If User.authorize("VIEW REPORTS") Then
            frmSupplierStockStatus.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub SlowMovingItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SlowMovingItemsToolStripMenuItem.Click

        If User.authorize("VIEW REPORTS") Then
            frmSlowMovingItems.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub NegativeStockReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NegativeStockReportToolStripMenuItem.Click
        If User.authorize("VIEW REPORTS") Then
            frmNegativeStockReports.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub PrintedLPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintedLPOToolStripMenuItem.Click
        If User.authorize("VIEW REPORTS") Then
            frmPrintedLPO.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub PendingLPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendingLPOToolStripMenuItem.Click

        If User.authorize("VIEW REPORTS") Then
            frmPendingLPO.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub GRNReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GRNReportToolStripMenuItem.Click
        If User.authorize("VIEW REPORTS") Then
            frmGrnReport2.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub PriceChangeReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PriceChangeReportToolStripMenuItem.Click
        If User.authorize("VIEW REPORTS") Then
            frmPriceChange.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub BackOfficeReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackOfficeReportsToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        If User.authorize("ADMIN") Then
            frmUserEnrolment.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click
        If User.authorize("ADMIN") Then
            frmTillAdministration.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem19.Click
        If User.authorize("ADMIN") Then
            'frmBiometricEnrolment.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem20.Click
        If User.authorize("ADMIN") Then
            'frmPersonaEnrolment.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub ToolStripMenuItem21_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem21.Click
        If User.authorize("ADMIN") Then
            frmTillPosition.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub ToolStripMenuItem22_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem22.Click
        If User.authorize("ADMIN") Then
            frmAccessControl.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub MenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub

    Private Sub StockConversionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockConversionToolStripMenuItem.Click
        frmItemConversion.ShowDialog()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim _date As Date = CDate(dtCustomDate.Text)
        Dim res As Integer = MsgBox("Set custom date to " + dtCustomDate.Text + "?", vbYesNo + vbQuestion, "Set System date to custom date")
        If res = DialogResult.Yes Then
            Day.DAY = _date
            tsrpDateTime.Text = "System Date: " + Day.DAY.ToString("yyyy-MM-dd")
            lblCustomDate.Text = "Custom date set to " + _date.ToString("yyyy-MM-dd") + " yyyy-MM-dd. Please log out after completing operations that require a custom date in order to resume to the normal system date"
            lblCustomDate.Visible = True
            lblCustDate.Visible = True
            customDate = True
        End If
    End Sub

    Private Sub ToolStripMenuItem26_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem23_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem23.Click
        If User.authorize("END DAY") Then
            If customDate = True Then
                MsgBox("Could not end day, custom date enabled. Please log in afresh to be able to end day", vbOKOnly + vbExclamation, "Invalid operation")
                Exit Sub
            End If
            frmEndDay.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub
    Dim customDate As Boolean = False

    Private Sub ToolStripMenuItem24_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem24.Click
        If User.authorize("CUSTOM DATING") = False Then
            MsgBox("You currently have no permission to change date to custom date!", vbOKOnly + vbExclamation, "Access denied")
            Exit Sub
        End If
        Dim res As Integer = MsgBox("Are you sure you want to enter a custom date? Custom sets the current system date to a specified date, and all operations will be dated on custom date. Make sure you log out and log in afresh to resume the normal system date", vbYesNo + vbQuestion, "Enter custom date")
        If res = DialogResult.Yes Then
            dtCustomDate.Visible = True
            btnUpdate.Visible = True
            lblCustDate.Visible = True
        End If
    End Sub

    Private Sub ToolStripMenuItem25_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem25.Click
        frmStockCardReports.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        frmPersonnel.ShowDialog()
    End Sub

    Private Sub SalesPersonsManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesPersonsManagementToolStripMenuItem.Click
        frmSalesPersons.ShowDialog()
    End Sub


    Private Sub hideSubMenu()
        pnlMastersMenu.Visible = False
        pnlOrdersMenu.Visible = False
        pnlReportMenu.Visible = False
        pnlTransactionsMenu.Visible = False
        pnlAdminFunctions.Visible = False
        pnlHRFunctions.Visible = False
        pnlDayOperations.Visible = False
    End Sub

    Private Sub showSubMenu(subMenu As Panel)
        If subMenu.Visible = False Then
            hideSubMenu()
            subMenu.Visible = True
        Else
            subMenu.Visible = False
        End If
    End Sub

    Private Sub btnMasters_Click(sender As Object, e As EventArgs) Handles btnMasters.Click
        showSubMenu(pnlMastersMenu)
    End Sub

    Private Sub btnOrders_Click(sender As Object, e As EventArgs) Handles btnOrders.Click
        showSubMenu(pnlOrdersMenu)
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        showSubMenu(pnlReportMenu)
    End Sub

    Private Sub btnTransactions_Click(sender As Object, e As EventArgs) Handles btnTransactions.Click
        showSubMenu(pnlTransactionsMenu)
    End Sub

    Private Sub btnAdminFunctions_Click(sender As Object, e As EventArgs) Handles btnAdminFunctions.Click
        showSubMenu(pnlAdminFunctions)
    End Sub

    Private Sub btnHRFunctions_Click(sender As Object, e As EventArgs) Handles btnHRFunctions.Click
        showSubMenu(pnlHRFunctions)
    End Sub

    Private Sub btnDayOperations_Click(sender As Object, e As EventArgs) Handles btnDayOperations.Click
        showSubMenu(pnlDayOperations)
    End Sub

    Private Sub btnProductMaster_Click(sender As Object, e As EventArgs) Handles btnProductMaster.Click
        openChildForm(New frmProductMaster)
        hideSubMenu()
    End Sub

    Private Sub btnProductInquiry_Click(sender As Object, e As EventArgs) Handles btnProductInquiry.Click
        openChildForm(New frmProductInquiry)
        hideSubMenu()
    End Sub

    Private Sub btnSuppliers_Click(sender As Object, e As EventArgs) Handles btnSuppliers.Click
        openChildForm(New frmSuppliers)
        hideSubMenu()
    End Sub

    Private Sub btnCompanyProfile_Click(sender As Object, e As EventArgs) Handles btnCompanyProfile.Click
        openChildForm(New frmCompany)
        hideSubMenu()
    End Sub

    Private Sub btnCorporateCustomers_Click(sender As Object, e As EventArgs) Handles btnCorporateCustomers.Click
        openChildForm(New frmCorporateCustomers)
        hideSubMenu()
    End Sub

    Private Sub btnMassManagement_Click(sender As Object, e As EventArgs) Handles btnMassManagement.Click
        openChildForm(New frmMassManager)
        hideSubMenu()
    End Sub

    Private Sub btnMaterialCategory_Click(sender As Object, e As EventArgs) Handles btnMaterialCategory.Click
        openChildForm(New frmMaterialCategory)
        hideSubMenu()
    End Sub

    Private Sub btnMaterial_Click(sender As Object, e As EventArgs) Handles btnMaterial.Click
        openChildForm(New frmMaterials)
        hideSubMenu()
    End Sub

    Private Sub btnLPO_Click(sender As Object, e As EventArgs) Handles btnLPO.Click
        openChildForm(New frmPurchaseOrder)
        hideSubMenu()
    End Sub

    Private Sub btnDailySalesReport_Click(sender As Object, e As EventArgs) Handles btnDailySalesReport.Click
        openChildForm(New frmDailySalesReport)
        hideSubMenu()
    End Sub

    Private Sub btnZHistoryReport_Click(sender As Object, e As EventArgs) Handles btnZHistoryReport.Click
        openChildForm(New frmZHistory)
        hideSubMenu()
    End Sub

    Private Sub btnCashierVariance_Click(sender As Object, e As EventArgs) Handles btnCashierVariance.Click
        openChildForm(New frmCashierVariance)
        hideSubMenu()
    End Sub

    Private Sub btnCreditNoteReport_Click(sender As Object, e As EventArgs) Handles btnCreditNoteReport.Click
        openChildForm(New frmCreditNoteReport)
        hideSubMenu()
    End Sub

    Private Sub btnCreditCardSalesReport_Click(sender As Object, e As EventArgs) Handles btnCreditCardSalesReport.Click
        openChildForm(New frmCreditCardSales)
        hideSubMenu()
    End Sub

    Private Sub btnGiftVoucherSalesReport_Click(sender As Object, e As EventArgs) Handles btnGiftVoucherSalesReport.Click
        openChildForm(New frmGiftVoucherSales)
        hideSubMenu()
    End Sub

    Private Sub btnReturnedBottleReport_Click(sender As Object, e As EventArgs) Handles btnReturnedBottleReport.Click
        openChildForm(New frmReturnedBottles)
        hideSubMenu()
    End Sub

    Private Sub btnProductListingReport_Click(sender As Object, e As EventArgs) Handles btnProductListingReport.Click
        openChildForm(New frmProductListingReport)
        hideSubMenu()
    End Sub

    Private Sub btnPettyCashReport_Click(sender As Object, e As EventArgs) Handles btnPettyCashReport.Click
        openChildForm(New frmPettyCash)
        hideSubMenu()
    End Sub

    Private Sub btnSupplySalesReport_Click(sender As Object, e As EventArgs) Handles btnSupplySalesReport.Click
        openChildForm(New frmSupplySalesReport)
        hideSubMenu()
    End Sub

    Private Sub btnStockCardReport_Click(sender As Object, e As EventArgs) Handles btnStockCardReport.Click
        openChildForm(New frmStockCardReports)
        hideSubMenu()
    End Sub

    Private Sub btnSupplierStockStatus_Click(sender As Object, e As EventArgs) Handles btnSupplierStockStatus.Click
        openChildForm(New frmSupplierStockStatus)
        hideSubMenu()
    End Sub

    Private Sub btnFastMovingItems_Click(sender As Object, e As EventArgs) Handles btnFastMovingItems.Click
        openChildForm(New frmFastMovingItems)
        hideSubMenu()
    End Sub

    Private Sub btnSlowMovingItems_Click(sender As Object, e As EventArgs) Handles btnSlowMovingItems.Click
        openChildForm(New frmSlowMovingItems)
        hideSubMenu()
    End Sub

    Private Sub btnNegativeStockReport_Click(sender As Object, e As EventArgs) Handles btnNegativeStockReport.Click
        openChildForm(New frmNegativeStockReports)
        hideSubMenu()
    End Sub

    Private Sub btnPrintedLPO_Click(sender As Object, e As EventArgs) Handles btnPrintedLPO.Click
        openChildForm(New frmPrintedLPO)
        hideSubMenu()
    End Sub

    Private Sub btnPendingLPO_Click(sender As Object, e As EventArgs) Handles btnPendingLPO.Click
        openChildForm(New frmPendingLPO)
        hideSubMenu()
    End Sub

    Private Sub btnGRNReport_Click(sender As Object, e As EventArgs) Handles btnGRNReport.Click
        openChildForm(New frmGrnReport2)
        hideSubMenu()
    End Sub

    Private Sub btnPriceChangeReport_Click(sender As Object, e As EventArgs) Handles btnPriceChangeReport.Click
        openChildForm(New frmPriceChange)
        hideSubMenu()
    End Sub

    Private Sub btnSupplierSalesReport_Click(sender As Object, e As EventArgs) Handles btnSupplierSalesReport.Click
        openChildForm(New frmSupplySalesReport)
        hideSubMenu()
    End Sub

    Private Sub btnDebtTrackingReport_Click(sender As Object, e As EventArgs) Handles btnDebtTrackingReport.Click
        openChildForm(New frmDebtReport)
        hideSubMenu()
    End Sub

    Private Sub btnDebtPaymentHistoryReport_Click(sender As Object, e As EventArgs) Handles btnDebtPaymentHistoryReport.Click
        openChildForm(New frmDebtPaymentHistory)
        hideSubMenu()
    End Sub

    Private Sub btnProductDamagedReport_Click(sender As Object, e As EventArgs) Handles btnProductDamagedReport.Click
        openChildForm(New frmDamagesReport)
        hideSubMenu()
    End Sub

    Private Sub btnDailyProductionReport_Click(sender As Object, e As EventArgs) Handles btnDailyProductionReport.Click
        openChildForm(New frmProductionReport)
        hideSubMenu()
    End Sub

    Private Sub btnMaterialVsProductionReport_Click(sender As Object, e As EventArgs) Handles btnMaterialVsProductionReport.Click
        openChildForm(New frmMaterialVsProduction)
        hideSubMenu()
    End Sub

    Private Sub btnMaterialUsageReport_Click(sender As Object, e As EventArgs) Handles btnMaterialUsageReport.Click
        openChildForm(New frmMaterialUsageReport)
        hideSubMenu()
    End Sub

    Private Sub btnMaterialStockStatus_Click(sender As Object, e As EventArgs) Handles btnMaterialStockStatus.Click
        openChildForm(New frmMaterialStockStatus)
        hideSubMenu()
    End Sub

    Private Sub btnMaterialStockCards_Click(sender As Object, e As EventArgs) Handles btnMaterialStockCards.Click
        openChildForm(New frmMaterialStockCard)
        hideSubMenu()
    End Sub

    Private Sub btnGoodsReceivedNote_Click(sender As Object, e As EventArgs) Handles btnGoodsReceivedNote.Click
        openChildForm(New frmGoodsReceivedNote)
        hideSubMenu()
    End Sub

    Private Sub btnGoodsReturnedByCustomers_Click(sender As Object, e As EventArgs) Handles btnGoodsReturnedByCustomers.Click
        openChildForm(New frmGoodsReturnedByCustomers)
        hideSubMenu()
    End Sub

    Private Sub btnCustomerCreditNotes_Click(sender As Object, e As EventArgs) Handles btnCustomerCreditNotes.Click
        openChildForm(New frmCustomerCreditNote)
        hideSubMenu()
    End Sub

    Private Sub btnSupplierCreditNotes_Click(sender As Object, e As EventArgs) Handles btnSupplierCreditNotes.Click
        openChildForm(New frmSupplierCreditNote)
        hideSubMenu()
    End Sub

    Private Sub btnAllocations_Click(sender As Object, e As EventArgs) Handles btnAllocations.Click
        openChildForm(New frmAllocations)
        hideSubMenu()
    End Sub

    Private Sub btnReceipts_Click(sender As Object, e As EventArgs) Handles btnReceipts.Click
        openChildForm(New frmReceipts)
        hideSubMenu()
    End Sub

    Private Sub btnQuotations_Click(sender As Object, e As EventArgs) Handles btnQuotations.Click
        openChildForm(New frmQuotations)
        hideSubMenu()
    End Sub

    Private Sub btnGoodsReturnedToVendor_Click(sender As Object, e As EventArgs) Handles btnGoodsReturnedToVendor.Click
        openChildForm(New frmReturnToVendor)
        hideSubMenu()
    End Sub

    Private Sub btnSalesLedge_Click(sender As Object, e As EventArgs) Handles btnSalesLedge.Click
        openChildForm(New frmSalesLedge)
        hideSubMenu()
    End Sub

    Private Sub btnSalesJournal_Click(sender As Object, e As EventArgs) Handles btnSalesJournal.Click
        openChildForm(New frmSalesJournal)
        hideSubMenu()
    End Sub

    Private Sub btnPackingList_Click(sender As Object, e As EventArgs) Handles btnPackingList.Click
        openChildForm(New frmPackingList)
        hideSubMenu()
    End Sub

    Private Sub btnProductConversion_Click(sender As Object, e As EventArgs) Handles btnProductConversion.Click
        openChildForm(New frmItemConversion)
        hideSubMenu()
    End Sub

    Private Sub btnCustomProduction_Click(sender As Object, e As EventArgs) Handles btnCustomProduction.Click
        openChildForm(New frmCustomProduction)
        hideSubMenu()
    End Sub

    Private Sub btnCustomerClaims_Click(sender As Object, e As EventArgs) Handles btnCustomerClaims.Click
        openChildForm(New frmCustomerClaim)
        hideSubMenu()
    End Sub

    Private Sub btnSalesInvoice_Click(sender As Object, e As EventArgs) Handles btnSalesInvoice.Click
        openChildForm(New frmSalesInvoice)
        hideSubMenu()
    End Sub

    Private Sub btnUserEnrolment_Click(sender As Object, e As EventArgs) Handles btnUserEnrolment.Click
        openChildForm(New frmUserEnrolment)
        hideSubMenu()
    End Sub

    Private Sub btnTillAdministration_Click(sender As Object, e As EventArgs) Handles btnTillAdministration.Click
        openChildForm(New frmTillAdministration)
        hideSubMenu()
    End Sub

    Private Sub btnBiometricEnrolment_Click(sender As Object, e As EventArgs) Handles btnBiometricEnrolment.Click
        openChildForm(New frmBiometricEnrolment)
        hideSubMenu()
    End Sub

    Private Sub btnTillPosition_Click(sender As Object, e As EventArgs) Handles btnTillPosition.Click
        openChildForm(New frmTillPosition)
        hideSubMenu()
    End Sub

    Private Sub btnAccessControl_Click(sender As Object, e As EventArgs) Handles btnAccessControl.Click
        openChildForm(New frmAccessControl)
        hideSubMenu()
    End Sub

    Private Sub btnPersonelEnrolment_Click(sender As Object, e As EventArgs) Handles btnPersonelEnrolment.Click
        openChildForm(New frmPersonnel)
        hideSubMenu()
    End Sub

    Private Sub btnSalesPersonEnrolment_Click(sender As Object, e As EventArgs) Handles btnSalesPersonEnrolment.Click
        openChildForm(New frmSalesPersons)
        hideSubMenu()
    End Sub

    Private Sub btnEndOfDay_Click(sender As Object, e As EventArgs) Handles btnEndOfDay.Click
        openChildForm(New frmEndDay)
        hideSubMenu()
    End Sub

    Private Sub btnCustomDating_Click(sender As Object, e As EventArgs) Handles btnCustomDating.Click
        If User.authorize("CUSTOM DATING") = False Then
            MsgBox("You currently have no permission to change date to custom date!", vbOKOnly + vbExclamation, "Access denied")
            Exit Sub
        End If
        Dim res As Integer = MsgBox("Are you sure you want to enter a custom date? Custom sets the current system date to a specified date, and all operations will be dated on custom date. Make sure you log out and log in afresh to resume the normal system date", vbYesNo + vbQuestion, "Enter custom date")
        If res = DialogResult.Yes Then
            If currentForm IsNot Nothing Then currentForm.Close()
            dtCustomDate.Visible = True
            btnUpdate.Visible = True
            lblCustDate.Visible = True
        End If
    End Sub



    Private currentForm As Form = Nothing
    Private Sub openChildForm(childForm As Form)
        If currentForm IsNot Nothing Then currentForm.Close()
        currentForm = childForm
        childForm.TopLevel = False
        childForm.Dock = DockStyle.Fill
        pnlBody.Controls.Add(childForm)
        pnlBody.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub

End Class
