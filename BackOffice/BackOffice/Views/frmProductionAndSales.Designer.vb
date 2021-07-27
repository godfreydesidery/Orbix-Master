<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductionAndSales
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductionAndSales))
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnSalesReport = New System.Windows.Forms.Button()
        Me.btnCustomProduction = New System.Windows.Forms.Button()
        Me.btnMaterials = New System.Windows.Forms.Button()
        Me.btnStockConversion = New System.Windows.Forms.Button()
        Me.frmCustomerClaims = New System.Windows.Forms.Button()
        Me.btnCategory = New System.Windows.Forms.Button()
        Me.btnMaterialUsageReport = New System.Windows.Forms.Button()
        Me.btnProductionReport = New System.Windows.Forms.Button()
        Me.btnMatStockcards = New System.Windows.Forms.Button()
        Me.btnDebtReport = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btnSummaryDailySalesReport = New System.Windows.Forms.Button()
        Me.btnDamagesReport = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.btnMaterialVsProduction = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Purple
        Me.btnBack.BackgroundImage = CType(resources.GetObject("btnBack.BackgroundImage"), System.Drawing.Image)
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBack.Location = New System.Drawing.Point(92, 575)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(155, 50)
        Me.btnBack.TabIndex = 2
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(63, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 25)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Production and Sales"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 91)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(155, 49)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Packing List"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 37)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(155, 48)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Sales Persons"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnSalesReport
        '
        Me.btnSalesReport.Location = New System.Drawing.Point(12, 146)
        Me.btnSalesReport.Name = "btnSalesReport"
        Me.btnSalesReport.Size = New System.Drawing.Size(155, 50)
        Me.btnSalesReport.TabIndex = 10
        Me.btnSalesReport.Text = "Detailed Daily Sales Report"
        Me.btnSalesReport.UseVisualStyleBackColor = True
        '
        'btnCustomProduction
        '
        Me.btnCustomProduction.Location = New System.Drawing.Point(173, 203)
        Me.btnCustomProduction.Name = "btnCustomProduction"
        Me.btnCustomProduction.Size = New System.Drawing.Size(155, 49)
        Me.btnCustomProduction.TabIndex = 11
        Me.btnCustomProduction.Text = "Custom Production"
        Me.btnCustomProduction.UseVisualStyleBackColor = True
        '
        'btnMaterials
        '
        Me.btnMaterials.Location = New System.Drawing.Point(173, 92)
        Me.btnMaterials.Name = "btnMaterials"
        Me.btnMaterials.Size = New System.Drawing.Size(155, 49)
        Me.btnMaterials.TabIndex = 12
        Me.btnMaterials.Text = "Materials"
        Me.btnMaterials.UseVisualStyleBackColor = True
        '
        'btnStockConversion
        '
        Me.btnStockConversion.Location = New System.Drawing.Point(173, 258)
        Me.btnStockConversion.Name = "btnStockConversion"
        Me.btnStockConversion.Size = New System.Drawing.Size(155, 49)
        Me.btnStockConversion.TabIndex = 13
        Me.btnStockConversion.Text = "Stock Conversion"
        Me.btnStockConversion.UseVisualStyleBackColor = True
        '
        'frmCustomerClaims
        '
        Me.frmCustomerClaims.Location = New System.Drawing.Point(12, 311)
        Me.frmCustomerClaims.Name = "frmCustomerClaims"
        Me.frmCustomerClaims.Size = New System.Drawing.Size(155, 49)
        Me.frmCustomerClaims.TabIndex = 14
        Me.frmCustomerClaims.Text = "Customer Claims"
        Me.frmCustomerClaims.UseVisualStyleBackColor = True
        '
        'btnCategory
        '
        Me.btnCategory.Location = New System.Drawing.Point(173, 37)
        Me.btnCategory.Name = "btnCategory"
        Me.btnCategory.Size = New System.Drawing.Size(155, 49)
        Me.btnCategory.TabIndex = 15
        Me.btnCategory.Text = "Material Categories"
        Me.btnCategory.UseVisualStyleBackColor = True
        '
        'btnMaterialUsageReport
        '
        Me.btnMaterialUsageReport.Location = New System.Drawing.Point(173, 368)
        Me.btnMaterialUsageReport.Name = "btnMaterialUsageReport"
        Me.btnMaterialUsageReport.Size = New System.Drawing.Size(155, 49)
        Me.btnMaterialUsageReport.TabIndex = 16
        Me.btnMaterialUsageReport.Text = "Material Usage Report"
        Me.btnMaterialUsageReport.UseVisualStyleBackColor = True
        '
        'btnProductionReport
        '
        Me.btnProductionReport.Location = New System.Drawing.Point(173, 423)
        Me.btnProductionReport.Name = "btnProductionReport"
        Me.btnProductionReport.Size = New System.Drawing.Size(155, 49)
        Me.btnProductionReport.TabIndex = 17
        Me.btnProductionReport.Text = "Production Report"
        Me.btnProductionReport.UseVisualStyleBackColor = True
        '
        'btnMatStockcards
        '
        Me.btnMatStockcards.Location = New System.Drawing.Point(173, 313)
        Me.btnMatStockcards.Name = "btnMatStockcards"
        Me.btnMatStockcards.Size = New System.Drawing.Size(155, 49)
        Me.btnMatStockcards.TabIndex = 18
        Me.btnMatStockcards.Text = "Material Stock Cards"
        Me.btnMatStockcards.UseVisualStyleBackColor = True
        '
        'btnDebtReport
        '
        Me.btnDebtReport.Location = New System.Drawing.Point(12, 366)
        Me.btnDebtReport.Name = "btnDebtReport"
        Me.btnDebtReport.Size = New System.Drawing.Size(155, 49)
        Me.btnDebtReport.TabIndex = 19
        Me.btnDebtReport.Text = "Debt Reports"
        Me.btnDebtReport.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 257)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(155, 48)
        Me.Button3.TabIndex = 20
        Me.Button3.Text = "Consolidated Daily Sales Report"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(12, 421)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(155, 49)
        Me.Button4.TabIndex = 21
        Me.Button4.Text = "Debt Payment History Report"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'btnSummaryDailySalesReport
        '
        Me.btnSummaryDailySalesReport.Location = New System.Drawing.Point(12, 202)
        Me.btnSummaryDailySalesReport.Name = "btnSummaryDailySalesReport"
        Me.btnSummaryDailySalesReport.Size = New System.Drawing.Size(155, 50)
        Me.btnSummaryDailySalesReport.TabIndex = 22
        Me.btnSummaryDailySalesReport.Text = "Summarized Daily Sales Report"
        Me.btnSummaryDailySalesReport.UseVisualStyleBackColor = True
        '
        'btnDamagesReport
        '
        Me.btnDamagesReport.Location = New System.Drawing.Point(12, 476)
        Me.btnDamagesReport.Name = "btnDamagesReport"
        Me.btnDamagesReport.Size = New System.Drawing.Size(155, 49)
        Me.btnDamagesReport.TabIndex = 23
        Me.btnDamagesReport.Text = "Damages Report"
        Me.btnDamagesReport.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(173, 147)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(155, 49)
        Me.Button5.TabIndex = 24
        Me.Button5.Text = "Material Stock Status"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'btnMaterialVsProduction
        '
        Me.btnMaterialVsProduction.Location = New System.Drawing.Point(173, 478)
        Me.btnMaterialVsProduction.Name = "btnMaterialVsProduction"
        Me.btnMaterialVsProduction.Size = New System.Drawing.Size(155, 49)
        Me.btnMaterialVsProduction.TabIndex = 25
        Me.btnMaterialVsProduction.Text = "Material vs Production Report"
        Me.btnMaterialVsProduction.UseVisualStyleBackColor = True
        '
        'frmProductionAndSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 632)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnMaterialVsProduction)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.btnDamagesReport)
        Me.Controls.Add(Me.btnSummaryDailySalesReport)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnDebtReport)
        Me.Controls.Add(Me.btnMatStockcards)
        Me.Controls.Add(Me.btnProductionReport)
        Me.Controls.Add(Me.btnMaterialUsageReport)
        Me.Controls.Add(Me.btnCategory)
        Me.Controls.Add(Me.frmCustomerClaims)
        Me.Controls.Add(Me.btnStockConversion)
        Me.Controls.Add(Me.btnMaterials)
        Me.Controls.Add(Me.btnCustomProduction)
        Me.Controls.Add(Me.btnSalesReport)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnBack)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmProductionAndSales"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnBack As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnSalesReport As Button
    Friend WithEvents btnCustomProduction As Button
    Friend WithEvents btnMaterials As Button
    Friend WithEvents btnStockConversion As Button
    Friend WithEvents frmCustomerClaims As Button
    Friend WithEvents btnCategory As Button
    Friend WithEvents btnMaterialUsageReport As Button
    Friend WithEvents btnProductionReport As Button
    Friend WithEvents btnMatStockcards As Button
    Friend WithEvents btnDebtReport As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents btnSummaryDailySalesReport As Button
    Friend WithEvents btnDamagesReport As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents btnMaterialVsProduction As Button
End Class
