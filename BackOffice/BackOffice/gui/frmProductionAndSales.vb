Public Class frmProductionAndSales
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmSalesPerson.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmPackingList.ShowDialog()
    End Sub

    Private Sub btnSalesReport_Click(sender As Object, e As EventArgs) Handles btnSalesReport.Click
        frmDetailedDailySalesReport.ShowDialog()
    End Sub

    Private Sub btnCustomProduction_Click(sender As Object, e As EventArgs) Handles btnCustomProduction.Click
        frmCustomProduction.ShowDialog()
    End Sub

    Private Sub btnMaterials_Click(sender As Object, e As EventArgs) Handles btnMaterials.Click
        frmMaterials.ShowDialog()
    End Sub

    Private Sub btnStockConversion_Click(sender As Object, e As EventArgs) Handles btnStockConversion.Click
        frmItemConversion.ShowDialog()
    End Sub

    Private Sub frmCustomerClaims_Click(sender As Object, e As EventArgs) Handles frmCustomerClaims.Click
        frmCustomerClaim.ShowDialog()
    End Sub

    Private Sub btnCategory_Click(sender As Object, e As EventArgs) Handles btnCategory.Click
        frmMaterialCategory.ShowDialog()
    End Sub

    Private Sub btnMaterialUsageReport_Click(sender As Object, e As EventArgs) Handles btnMaterialUsageReport.Click
        frmMaterialUsageReport.ShowDialog()
    End Sub

    Private Sub btnProductionReport_Click(sender As Object, e As EventArgs) Handles btnProductionReport.Click
        frmProductionReport.ShowDialog()
    End Sub

    Private Sub btnMatStockcards_Click(sender As Object, e As EventArgs) Handles btnMatStockcards.Click
        frmMaterialStockCard.ShowDialog()
    End Sub

    Private Sub btnDebtReport_Click(sender As Object, e As EventArgs) Handles btnDebtReport.Click
        frmDebtReport.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmConsolidatedDailySalesReport.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmDebtPayment.ShowDialog()
    End Sub

    Private Sub btnSummaryDailySalesReport_Click(sender As Object, e As EventArgs) Handles btnSummaryDailySalesReport.Click
        frmDailySummarySalesReport.ShowDialog()
    End Sub

    Private Sub btnDamagesReport_Click(sender As Object, e As EventArgs) Handles btnDamagesReport.Click
        frmDamagesReport.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmMaterialStockStatus.ShowDialog()
    End Sub

    Private Sub btnMaterialVsProduction_Click(sender As Object, e As EventArgs) Handles btnMaterialVsProduction.Click
        frmMaterialVsProduction.showdialog
    End Sub
End Class