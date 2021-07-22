<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMassManager
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDownloadMaster = New System.Windows.Forms.Button()
        Me.btnGenerateItemMasterTemplate = New System.Windows.Forms.Button()
        Me.btnUpdatePrice = New System.Windows.Forms.Button()
        Me.btnUpdateMaster = New System.Windows.Forms.Button()
        Me.btnUpdateInventory = New System.Windows.Forms.Button()
        Me.btnUploadMaster = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.prgBar = New System.Windows.Forms.ProgressBar()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSupplierMaster = New System.Windows.Forms.Button()
        Me.btnSupplierTemplate = New System.Windows.Forms.Button()
        Me.btnUpdateSupplier = New System.Windows.Forms.Button()
        Me.btnUploadSupplier = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dlgOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.lblOperation = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnUpdateUnits = New System.Windows.Forms.Button()
        Me.btnuploadUnits = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnDownloadUnitTemplate = New System.Windows.Forms.Button()
        Me.btnExportUnitsToExcel = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnDownloadMaster)
        Me.Panel1.Controls.Add(Me.btnGenerateItemMasterTemplate)
        Me.Panel1.Controls.Add(Me.btnUpdatePrice)
        Me.Panel1.Controls.Add(Me.btnUpdateMaster)
        Me.Panel1.Controls.Add(Me.btnUpdateInventory)
        Me.Panel1.Controls.Add(Me.btnUploadMaster)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 79)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(228, 331)
        Me.Panel1.TabIndex = 0
        '
        'btnDownloadMaster
        '
        Me.btnDownloadMaster.Location = New System.Drawing.Point(6, 224)
        Me.btnDownloadMaster.Name = "btnDownloadMaster"
        Me.btnDownloadMaster.Size = New System.Drawing.Size(215, 39)
        Me.btnDownloadMaster.TabIndex = 50
        Me.btnDownloadMaster.Text = "Export Master to Excel"
        Me.btnDownloadMaster.UseVisualStyleBackColor = True
        '
        'btnGenerateItemMasterTemplate
        '
        Me.btnGenerateItemMasterTemplate.Location = New System.Drawing.Point(6, 271)
        Me.btnGenerateItemMasterTemplate.Name = "btnGenerateItemMasterTemplate"
        Me.btnGenerateItemMasterTemplate.Size = New System.Drawing.Size(215, 43)
        Me.btnGenerateItemMasterTemplate.TabIndex = 49
        Me.btnGenerateItemMasterTemplate.Text = "Excel Master Template"
        Me.btnGenerateItemMasterTemplate.UseVisualStyleBackColor = True
        '
        'btnUpdatePrice
        '
        Me.btnUpdatePrice.Location = New System.Drawing.Point(6, 134)
        Me.btnUpdatePrice.Name = "btnUpdatePrice"
        Me.btnUpdatePrice.Size = New System.Drawing.Size(215, 39)
        Me.btnUpdatePrice.TabIndex = 48
        Me.btnUpdatePrice.Text = "Update Prices from Excel"
        Me.btnUpdatePrice.UseVisualStyleBackColor = True
        Me.btnUpdatePrice.Visible = False
        '
        'btnUpdateMaster
        '
        Me.btnUpdateMaster.Location = New System.Drawing.Point(6, 89)
        Me.btnUpdateMaster.Name = "btnUpdateMaster"
        Me.btnUpdateMaster.Size = New System.Drawing.Size(215, 39)
        Me.btnUpdateMaster.TabIndex = 47
        Me.btnUpdateMaster.Text = "Update Master from Excel"
        Me.btnUpdateMaster.UseVisualStyleBackColor = True
        '
        'btnUpdateInventory
        '
        Me.btnUpdateInventory.Location = New System.Drawing.Point(6, 179)
        Me.btnUpdateInventory.Name = "btnUpdateInventory"
        Me.btnUpdateInventory.Size = New System.Drawing.Size(215, 39)
        Me.btnUpdateInventory.TabIndex = 46
        Me.btnUpdateInventory.Text = "Update Inventory from Excel"
        Me.btnUpdateInventory.UseVisualStyleBackColor = True
        Me.btnUpdateInventory.Visible = False
        '
        'btnUploadMaster
        '
        Me.btnUploadMaster.Location = New System.Drawing.Point(6, 44)
        Me.btnUploadMaster.Name = "btnUploadMaster"
        Me.btnUploadMaster.Size = New System.Drawing.Size(215, 39)
        Me.btnUploadMaster.TabIndex = 46
        Me.btnUploadMaster.Text = "Upload Master From Excel"
        Me.btnUploadMaster.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 17)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Product Management"
        '
        'prgBar
        '
        Me.prgBar.Location = New System.Drawing.Point(11, 12)
        Me.prgBar.Name = "prgBar"
        Me.prgBar.Size = New System.Drawing.Size(1015, 23)
        Me.prgBar.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.btnSupplierMaster)
        Me.Panel2.Controls.Add(Me.btnSupplierTemplate)
        Me.Panel2.Controls.Add(Me.btnUpdateSupplier)
        Me.Panel2.Controls.Add(Me.btnUploadSupplier)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(246, 80)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(231, 331)
        Me.Panel2.TabIndex = 46
        '
        'btnSupplierMaster
        '
        Me.btnSupplierMaster.Location = New System.Drawing.Point(3, 225)
        Me.btnSupplierMaster.Name = "btnSupplierMaster"
        Me.btnSupplierMaster.Size = New System.Drawing.Size(215, 39)
        Me.btnSupplierMaster.TabIndex = 51
        Me.btnSupplierMaster.Text = "Export Suppliers to Excel"
        Me.btnSupplierMaster.UseVisualStyleBackColor = True
        '
        'btnSupplierTemplate
        '
        Me.btnSupplierTemplate.Location = New System.Drawing.Point(3, 270)
        Me.btnSupplierTemplate.Name = "btnSupplierTemplate"
        Me.btnSupplierTemplate.Size = New System.Drawing.Size(215, 43)
        Me.btnSupplierTemplate.TabIndex = 50
        Me.btnSupplierTemplate.Text = "Excel Supplier Template"
        Me.btnSupplierTemplate.UseVisualStyleBackColor = True
        '
        'btnUpdateSupplier
        '
        Me.btnUpdateSupplier.Location = New System.Drawing.Point(6, 89)
        Me.btnUpdateSupplier.Name = "btnUpdateSupplier"
        Me.btnUpdateSupplier.Size = New System.Drawing.Size(218, 39)
        Me.btnUpdateSupplier.TabIndex = 47
        Me.btnUpdateSupplier.Text = "Update Supplier Master"
        Me.btnUpdateSupplier.UseVisualStyleBackColor = True
        '
        'btnUploadSupplier
        '
        Me.btnUploadSupplier.Location = New System.Drawing.Point(6, 44)
        Me.btnUploadSupplier.Name = "btnUploadSupplier"
        Me.btnUploadSupplier.Size = New System.Drawing.Size(218, 39)
        Me.btnUploadSupplier.TabIndex = 46
        Me.btnUploadSupplier.Text = "Upload Supplier Master"
        Me.btnUploadSupplier.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 17)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Supplier Management"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(912, 375)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(115, 35)
        Me.btnClose.TabIndex = 47
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblOperation
        '
        Me.lblOperation.AutoSize = True
        Me.lblOperation.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblOperation.Location = New System.Drawing.Point(344, 45)
        Me.lblOperation.Name = "lblOperation"
        Me.lblOperation.Size = New System.Drawing.Size(0, 17)
        Me.lblOperation.TabIndex = 49
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.btnExportUnitsToExcel)
        Me.Panel3.Controls.Add(Me.btnDownloadUnitTemplate)
        Me.Panel3.Controls.Add(Me.btnUpdateUnits)
        Me.Panel3.Controls.Add(Me.btnuploadUnits)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Location = New System.Drawing.Point(483, 80)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(230, 332)
        Me.Panel3.TabIndex = 50
        '
        'btnUpdateUnits
        '
        Me.btnUpdateUnits.Location = New System.Drawing.Point(6, 90)
        Me.btnUpdateUnits.Name = "btnUpdateUnits"
        Me.btnUpdateUnits.Size = New System.Drawing.Size(217, 39)
        Me.btnUpdateUnits.TabIndex = 48
        Me.btnUpdateUnits.Text = "Update Units"
        Me.btnUpdateUnits.UseVisualStyleBackColor = True
        '
        'btnuploadUnits
        '
        Me.btnuploadUnits.Location = New System.Drawing.Point(6, 44)
        Me.btnuploadUnits.Name = "btnuploadUnits"
        Me.btnuploadUnits.Size = New System.Drawing.Size(217, 39)
        Me.btnuploadUnits.TabIndex = 46
        Me.btnuploadUnits.Text = "Upload Units"
        Me.btnuploadUnits.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 17)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Unit Management"
        '
        'btnDownloadUnitTemplate
        '
        Me.btnDownloadUnitTemplate.Location = New System.Drawing.Point(6, 274)
        Me.btnDownloadUnitTemplate.Name = "btnDownloadUnitTemplate"
        Me.btnDownloadUnitTemplate.Size = New System.Drawing.Size(217, 39)
        Me.btnDownloadUnitTemplate.TabIndex = 49
        Me.btnDownloadUnitTemplate.Text = "Download Units Template"
        Me.btnDownloadUnitTemplate.UseVisualStyleBackColor = True
        '
        'btnExportUnitsToExcel
        '
        Me.btnExportUnitsToExcel.Location = New System.Drawing.Point(8, 229)
        Me.btnExportUnitsToExcel.Name = "btnExportUnitsToExcel"
        Me.btnExportUnitsToExcel.Size = New System.Drawing.Size(215, 39)
        Me.btnExportUnitsToExcel.TabIndex = 52
        Me.btnExportUnitsToExcel.Text = "Export Units to Excel"
        Me.btnExportUnitsToExcel.UseVisualStyleBackColor = True
        Me.btnExportUnitsToExcel.Visible = False
        '
        'frmMassManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 422)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.lblOperation)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.prgBar)
        Me.Controls.Add(Me.Panel1)
        Me.MinimizeBox = False
        Me.Name = "frmMassManager"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mass Manager"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents prgBar As ProgressBar
    Friend WithEvents btnUpdatePrice As Button
    Friend WithEvents btnUpdateMaster As Button
    Friend WithEvents btnUploadMaster As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnUpdateSupplier As Button
    Friend WithEvents btnUploadSupplier As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btnUpdateInventory As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents dlgOpenFile As OpenFileDialog
    Friend WithEvents lblOperation As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnUpdateUnits As Button
    Friend WithEvents btnuploadUnits As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnGenerateItemMasterTemplate As Button
    Friend WithEvents btnDownloadMaster As Button
    Friend WithEvents btnSupplierTemplate As Button
    Friend WithEvents btnSupplierMaster As Button
    Friend WithEvents btnDownloadUnitTemplate As Button
    Friend WithEvents btnExportUnitsToExcel As Button
End Class
