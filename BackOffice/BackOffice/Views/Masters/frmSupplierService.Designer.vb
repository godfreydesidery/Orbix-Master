<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSupplierService
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSupplierCode = New System.Windows.Forms.TextBox()
        Me.txtSupplierName = New System.Windows.Forms.TextBox()
        Me.txtContactName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtServiceDescr = New System.Windows.Forms.TextBox()
        Me.txtCostVatIncl = New System.Windows.Forms.TextBox()
        Me.txtCostVatExcl = New System.Windows.Forms.TextBox()
        Me.txtVATNo = New System.Windows.Forms.TextBox()
        Me.txtTermsOfPayment = New System.Windows.Forms.TextBox()
        Me.dtgrdServices = New System.Windows.Forms.DataGridView()
        Me.colGoodsServices = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCostPriceVatIncl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCostPriceVatExcl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.cmbPacking = New System.Windows.Forms.ComboBox()
        Me.txtItem = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBarCode = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.dtgrdServices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Supplier Code*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Company Name*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 17)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Contact Name*"
        '
        'txtSupplierCode
        '
        Me.txtSupplierCode.Location = New System.Drawing.Point(124, 12)
        Me.txtSupplierCode.MaxLength = 50
        Me.txtSupplierCode.Name = "txtSupplierCode"
        Me.txtSupplierCode.ReadOnly = True
        Me.txtSupplierCode.Size = New System.Drawing.Size(251, 22)
        Me.txtSupplierCode.TabIndex = 27
        '
        'txtSupplierName
        '
        Me.txtSupplierName.Location = New System.Drawing.Point(124, 43)
        Me.txtSupplierName.MaxLength = 100
        Me.txtSupplierName.Name = "txtSupplierName"
        Me.txtSupplierName.ReadOnly = True
        Me.txtSupplierName.Size = New System.Drawing.Size(451, 22)
        Me.txtSupplierName.TabIndex = 28
        '
        'txtContactName
        '
        Me.txtContactName.Location = New System.Drawing.Point(124, 79)
        Me.txtContactName.MaxLength = 100
        Me.txtContactName.Name = "txtContactName"
        Me.txtContactName.ReadOnly = True
        Me.txtContactName.Size = New System.Drawing.Size(451, 22)
        Me.txtContactName.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(606, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(204, 17)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Goods and Service Description"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(705, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 17)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Supply Packing"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(639, 174)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(171, 17)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Cost Price (VAT Inclusive)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(635, 202)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(175, 17)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Cost Price (VAT Exclusive)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(687, 258)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 17)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Terms of Payment"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(753, 227)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 17)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "VAT No"
        '
        'txtServiceDescr
        '
        Me.txtServiceDescr.Location = New System.Drawing.Point(816, 76)
        Me.txtServiceDescr.MaxLength = 300
        Me.txtServiceDescr.Multiline = True
        Me.txtServiceDescr.Name = "txtServiceDescr"
        Me.txtServiceDescr.Size = New System.Drawing.Size(364, 66)
        Me.txtServiceDescr.TabIndex = 47
        '
        'txtCostVatIncl
        '
        Me.txtCostVatIncl.Location = New System.Drawing.Point(816, 174)
        Me.txtCostVatIncl.MaxLength = 10
        Me.txtCostVatIncl.Name = "txtCostVatIncl"
        Me.txtCostVatIncl.Size = New System.Drawing.Size(364, 22)
        Me.txtCostVatIncl.TabIndex = 49
        '
        'txtCostVatExcl
        '
        Me.txtCostVatExcl.Location = New System.Drawing.Point(816, 202)
        Me.txtCostVatExcl.MaxLength = 10
        Me.txtCostVatExcl.Name = "txtCostVatExcl"
        Me.txtCostVatExcl.Size = New System.Drawing.Size(364, 22)
        Me.txtCostVatExcl.TabIndex = 50
        '
        'txtVATNo
        '
        Me.txtVATNo.Location = New System.Drawing.Point(816, 230)
        Me.txtVATNo.MaxLength = 10
        Me.txtVATNo.Name = "txtVATNo"
        Me.txtVATNo.Size = New System.Drawing.Size(364, 22)
        Me.txtVATNo.TabIndex = 51
        '
        'txtTermsOfPayment
        '
        Me.txtTermsOfPayment.Location = New System.Drawing.Point(816, 258)
        Me.txtTermsOfPayment.MaxLength = 50
        Me.txtTermsOfPayment.Name = "txtTermsOfPayment"
        Me.txtTermsOfPayment.Size = New System.Drawing.Size(364, 22)
        Me.txtTermsOfPayment.TabIndex = 52
        '
        'dtgrdServices
        '
        Me.dtgrdServices.AllowUserToAddRows = False
        Me.dtgrdServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdServices.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtgrdServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdServices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colGoodsServices, Me.colCostPriceVatIncl, Me.colCostPriceVatExcl})
        Me.dtgrdServices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgrdServices.EnableHeadersVisualStyles = False
        Me.dtgrdServices.Location = New System.Drawing.Point(12, 369)
        Me.dtgrdServices.Name = "dtgrdServices"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dtgrdServices.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgrdServices.RowTemplate.Height = 24
        Me.dtgrdServices.Size = New System.Drawing.Size(1203, 337)
        Me.dtgrdServices.TabIndex = 53
        '
        'colGoodsServices
        '
        Me.colGoodsServices.HeaderText = "Supply Item"
        Me.colGoodsServices.Name = "colGoodsServices"
        Me.colGoodsServices.ReadOnly = True
        '
        'colCostPriceVatIncl
        '
        Me.colCostPriceVatIncl.HeaderText = "Cost Price(VAT inclusive)"
        Me.colCostPriceVatIncl.Name = "colCostPriceVatIncl"
        Me.colCostPriceVatIncl.ReadOnly = True
        '
        'colCostPriceVatExcl
        '
        Me.colCostPriceVatExcl.HeaderText = "Cost Price(VAT exclusive)"
        Me.colCostPriceVatExcl.Name = "colCostPriceVatExcl"
        Me.colCostPriceVatExcl.ReadOnly = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(286, 232)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 53)
        Me.btnDelete.TabIndex = 56
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(376, 232)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 53)
        Me.btnSave.TabIndex = 57
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(1116, 722)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(99, 53)
        Me.Button5.TabIndex = 58
        Me.Button5.Text = "Back"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'cmbPacking
        '
        Me.cmbPacking.FormattingEnabled = True
        Me.cmbPacking.Location = New System.Drawing.Point(816, 144)
        Me.cmbPacking.Name = "cmbPacking"
        Me.cmbPacking.Size = New System.Drawing.Size(364, 24)
        Me.cmbPacking.TabIndex = 59
        '
        'txtItem
        '
        Me.txtItem.Location = New System.Drawing.Point(124, 204)
        Me.txtItem.MaxLength = 100
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(451, 22)
        Me.txtItem.TabIndex = 61
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(84, 205)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 17)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "Item"
        '
        'txtBarCode
        '
        Me.txtBarCode.Location = New System.Drawing.Point(124, 148)
        Me.txtBarCode.MaxLength = 50
        Me.txtBarCode.Name = "txtBarCode"
        Me.txtBarCode.Size = New System.Drawing.Size(191, 22)
        Me.txtBarCode.TabIndex = 63
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(51, 151)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 17)
        Me.Label11.TabIndex = 62
        Me.Label11.Text = "Bar Code"
        '
        'txtItemCode
        '
        Me.txtItemCode.Location = New System.Drawing.Point(124, 176)
        Me.txtItemCode.MaxLength = 50
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(191, 22)
        Me.txtItemCode.TabIndex = 65
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(47, 175)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 17)
        Me.Label12.TabIndex = 64
        Me.Label12.Text = "Item Code"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(321, 145)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(95, 47)
        Me.btnSearch.TabIndex = 66
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 116)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(441, 17)
        Me.Label13.TabIndex = 67
        Me.Label13.Text = "Enter item supplied or to be supllied by this supplier and click Search"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(813, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(136, 17)
        Me.Label14.TabIndex = 68
        Me.Label14.Text = "Enter service details"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(1003, 48)
        Me.txtCode.MaxLength = 50
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(177, 22)
        Me.txtCode.TabIndex = 70
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(926, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 17)
        Me.Label15.TabIndex = 69
        Me.Label15.Text = "Item Code"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(205, 232)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 53)
        Me.btnEdit.TabIndex = 72
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(124, 232)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 53)
        Me.btnNew.TabIndex = 73
        Me.btnNew.Text = "Clear"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(7, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(253, 24)
        Me.Label16.TabIndex = 74
        Me.Label16.Text = "Goods provided by Supplier"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtSupplierCode)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtCode)
        Me.Panel1.Controls.Add(Me.btnEdit)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.btnNew)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtContactName)
        Me.Panel1.Controls.Add(Me.cmbPacking)
        Me.Panel1.Controls.Add(Me.txtItem)
        Me.Panel1.Controls.Add(Me.txtSupplierName)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.txtTermsOfPayment)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtVATNo)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.txtCostVatExcl)
        Me.Panel1.Controls.Add(Me.txtBarCode)
        Me.Panel1.Controls.Add(Me.txtCostVatIncl)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtServiceDescr)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtItemCode)
        Me.Panel1.Location = New System.Drawing.Point(12, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1203, 305)
        Me.Panel1.TabIndex = 75
        '
        'frmSupplierService
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1226, 787)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.dtgrdServices)
        Me.MinimizeBox = False
        Me.Name = "frmSupplierService"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "0"
        CType(Me.dtgrdServices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSupplierCode As TextBox
    Friend WithEvents txtSupplierName As TextBox
    Friend WithEvents txtContactName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtServiceDescr As TextBox
    Friend WithEvents txtCostVatIncl As TextBox
    Friend WithEvents txtCostVatExcl As TextBox
    Friend WithEvents txtVATNo As TextBox
    Friend WithEvents txtTermsOfPayment As TextBox
    Friend WithEvents dtgrdServices As DataGridView
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents cmbPacking As ComboBox
    Friend WithEvents txtItem As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtBarCode As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtItemCode As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents colGoodsServices As DataGridViewTextBoxColumn
    Friend WithEvents colCostPriceVatIncl As DataGridViewTextBoxColumn
    Friend WithEvents colCostPriceVatExcl As DataGridViewTextBoxColumn
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtCode As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel1 As Panel
End Class
