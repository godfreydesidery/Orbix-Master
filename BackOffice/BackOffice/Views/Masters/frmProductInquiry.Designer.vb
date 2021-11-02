<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProductInquiry
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtPacksize = New System.Windows.Forms.TextBox()
        Me.txtPrimarySupplier = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtShortDescription = New System.Windows.Forms.TextBox()
        Me.chkDiscontinued = New System.Windows.Forms.CheckBox()
        Me.txtStandardUOM = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtProfitMargin = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.txtPrimaryBarcode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSellingPriceVatIncl = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDiscount = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCostPriceVatIncl = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtVat = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtDepartment = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtSubClass = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtClass = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtDefReorderQty = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtDefReorderLevel = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtMaxInventory = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMinInventory = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lstBarCodes = New System.Windows.Forms.ListBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbDescription = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnReset = New System.Windows.Forms.ToolStripButton()
        Me.txtCommonDescription = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtCostPriceVatExcl = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtSellingPriceVatExcl = New System.Windows.Forms.TextBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtIngredients = New System.Windows.Forms.TextBox()
        Me.chkSellable = New System.Windows.Forms.CheckBox()
        Me.chkReturnable = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPacksize
        '
        Me.txtPacksize.Location = New System.Drawing.Point(122, 201)
        Me.txtPacksize.MaxLength = 20
        Me.txtPacksize.Name = "txtPacksize"
        Me.txtPacksize.ReadOnly = True
        Me.txtPacksize.Size = New System.Drawing.Size(100, 22)
        Me.txtPacksize.TabIndex = 49
        '
        'txtPrimarySupplier
        '
        Me.txtPrimarySupplier.Location = New System.Drawing.Point(122, 229)
        Me.txtPrimarySupplier.MaxLength = 100
        Me.txtPrimarySupplier.Name = "txtPrimarySupplier"
        Me.txtPrimarySupplier.ReadOnly = True
        Me.txtPrimarySupplier.Size = New System.Drawing.Size(401, 22)
        Me.txtPrimarySupplier.TabIndex = 48
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(-1, 126)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(117, 17)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "Short Description"
        '
        'txtShortDescription
        '
        Me.txtShortDescription.Location = New System.Drawing.Point(122, 126)
        Me.txtShortDescription.MaxLength = 100
        Me.txtShortDescription.Name = "txtShortDescription"
        Me.txtShortDescription.ReadOnly = True
        Me.txtShortDescription.Size = New System.Drawing.Size(402, 22)
        Me.txtShortDescription.TabIndex = 46
        '
        'chkDiscontinued
        '
        Me.chkDiscontinued.AutoSize = True
        Me.chkDiscontinued.Enabled = False
        Me.chkDiscontinued.Location = New System.Drawing.Point(228, 200)
        Me.chkDiscontinued.Name = "chkDiscontinued"
        Me.chkDiscontinued.Size = New System.Drawing.Size(112, 21)
        Me.chkDiscontinued.TabIndex = 45
        Me.chkDiscontinued.Text = "Discontinued"
        Me.chkDiscontinued.UseVisualStyleBackColor = True
        '
        'txtStandardUOM
        '
        Me.txtStandardUOM.Location = New System.Drawing.Point(166, 537)
        Me.txtStandardUOM.MaxLength = 100
        Me.txtStandardUOM.Name = "txtStandardUOM"
        Me.txtStandardUOM.ReadOnly = True
        Me.txtStandardUOM.Size = New System.Drawing.Size(126, 22)
        Me.txtStandardUOM.TabIndex = 34
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(58, 537)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(102, 17)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Standard UOM"
        '
        'txtProfitMargin
        '
        Me.txtProfitMargin.Location = New System.Drawing.Point(166, 509)
        Me.txtProfitMargin.MaxLength = 6
        Me.txtProfitMargin.Name = "txtProfitMargin"
        Me.txtProfitMargin.ReadOnly = True
        Me.txtProfitMargin.Size = New System.Drawing.Size(126, 22)
        Me.txtProfitMargin.TabIndex = 32
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(56, 232)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 17)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Supplier"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(423, 40)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 40)
        Me.btnSearch.TabIndex = 15
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(50, 509)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 17)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Profit Margin(%)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(76, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Code"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(123, 68)
        Me.txtCode.MaxLength = 20
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(281, 22)
        Me.txtCode.TabIndex = 12
        '
        'txtPrimaryBarcode
        '
        Me.txtPrimaryBarcode.Location = New System.Drawing.Point(123, 40)
        Me.txtPrimaryBarcode.MaxLength = 20
        Me.txtPrimaryBarcode.Name = "txtPrimaryBarcode"
        Me.txtPrimaryBarcode.Size = New System.Drawing.Size(281, 22)
        Me.txtPrimaryBarcode.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Primary Barcode"
        '
        'txtSellingPriceVatIncl
        '
        Me.txtSellingPriceVatIncl.Location = New System.Drawing.Point(166, 396)
        Me.txtSellingPriceVatIncl.MaxLength = 20
        Me.txtSellingPriceVatIncl.Name = "txtSellingPriceVatIncl"
        Me.txtSellingPriceVatIncl.ReadOnly = True
        Me.txtSellingPriceVatIncl.Size = New System.Drawing.Size(126, 22)
        Me.txtSellingPriceVatIncl.TabIndex = 28
        Me.txtSellingPriceVatIncl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 394)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(148, 17)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Selling Price(VAT Incl)"
        '
        'txtDiscount
        '
        Me.txtDiscount.Location = New System.Drawing.Point(166, 481)
        Me.txtDiscount.MaxLength = 6
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.ReadOnly = True
        Me.txtDiscount.Size = New System.Drawing.Size(126, 22)
        Me.txtDiscount.TabIndex = 26
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(71, 484)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 17)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Discount (%)"
        '
        'txtCostPriceVatIncl
        '
        Me.txtCostPriceVatIncl.Location = New System.Drawing.Point(166, 341)
        Me.txtCostPriceVatIncl.MaxLength = 20
        Me.txtCostPriceVatIncl.Name = "txtCostPriceVatIncl"
        Me.txtCostPriceVatIncl.ReadOnly = True
        Me.txtCostPriceVatIncl.Size = New System.Drawing.Size(126, 22)
        Me.txtCostPriceVatIncl.TabIndex = 22
        Me.txtCostPriceVatIncl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 341)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 17)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Cost Price(VAT Incl)"
        '
        'txtVat
        '
        Me.txtVat.Location = New System.Drawing.Point(166, 452)
        Me.txtVat.MaxLength = 6
        Me.txtVat.Name = "txtVat"
        Me.txtVat.ReadOnly = True
        Me.txtVat.Size = New System.Drawing.Size(126, 22)
        Me.txtVat.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(103, 455)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 17)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "VAT(%)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 17)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Pack Size"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(175, 28)
        Me.txtQty.MaxLength = 20
        Me.txtQty.Name = "txtQty"
        Me.txtQty.ReadOnly = True
        Me.txtQty.Size = New System.Drawing.Size(174, 22)
        Me.txtQty.TabIndex = 44
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(75, 33)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(94, 17)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "Current Stock"
        '
        'txtDepartment
        '
        Me.txtDepartment.Location = New System.Drawing.Point(123, 257)
        Me.txtDepartment.MaxLength = 50
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.ReadOnly = True
        Me.txtDepartment.Size = New System.Drawing.Size(401, 22)
        Me.txtDepartment.TabIndex = 42
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(33, 257)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(82, 17)
        Me.Label20.TabIndex = 41
        Me.Label20.Text = "Department"
        '
        'txtSubClass
        '
        Me.txtSubClass.Location = New System.Drawing.Point(122, 313)
        Me.txtSubClass.MaxLength = 50
        Me.txtSubClass.Name = "txtSubClass"
        Me.txtSubClass.ReadOnly = True
        Me.txtSubClass.Size = New System.Drawing.Size(402, 22)
        Me.txtSubClass.TabIndex = 40
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(49, 313)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(71, 17)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "Sub Class"
        '
        'txtClass
        '
        Me.txtClass.Location = New System.Drawing.Point(123, 285)
        Me.txtClass.MaxLength = 50
        Me.txtClass.Name = "txtClass"
        Me.txtClass.ReadOnly = True
        Me.txtClass.Size = New System.Drawing.Size(402, 22)
        Me.txtClass.TabIndex = 38
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(76, 285)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 17)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = "Class"
        '
        'txtDefReorderQty
        '
        Me.txtDefReorderQty.Location = New System.Drawing.Point(175, 149)
        Me.txtDefReorderQty.MaxLength = 20
        Me.txtDefReorderQty.Name = "txtDefReorderQty"
        Me.txtDefReorderQty.ReadOnly = True
        Me.txtDefReorderQty.Size = New System.Drawing.Size(174, 22)
        Me.txtDefReorderQty.TabIndex = 36
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 149)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(166, 17)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "Default Reorder Quantity"
        '
        'txtDefReorderLevel
        '
        Me.txtDefReorderLevel.Location = New System.Drawing.Point(175, 116)
        Me.txtDefReorderLevel.MaxLength = 20
        Me.txtDefReorderLevel.Name = "txtDefReorderLevel"
        Me.txtDefReorderLevel.ReadOnly = True
        Me.txtDefReorderLevel.Size = New System.Drawing.Size(174, 22)
        Me.txtDefReorderLevel.TabIndex = 34
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(19, 116)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(147, 17)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Default Reorder Level"
        '
        'txtMaxInventory
        '
        Me.txtMaxInventory.Location = New System.Drawing.Point(175, 88)
        Me.txtMaxInventory.MaxLength = 20
        Me.txtMaxInventory.Name = "txtMaxInventory"
        Me.txtMaxInventory.ReadOnly = True
        Me.txtMaxInventory.Size = New System.Drawing.Size(174, 22)
        Me.txtMaxInventory.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(96, 87)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 17)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Max Stock"
        '
        'txtMinInventory
        '
        Me.txtMinInventory.Location = New System.Drawing.Point(175, 56)
        Me.txtMinInventory.MaxLength = 20
        Me.txtMinInventory.Name = "txtMinInventory"
        Me.txtMinInventory.ReadOnly = True
        Me.txtMinInventory.Size = New System.Drawing.Size(174, 22)
        Me.txtMinInventory.TabIndex = 30
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(97, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 17)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Min Stock"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Inventory Details"
        '
        'lstBarCodes
        '
        Me.lstBarCodes.Enabled = False
        Me.lstBarCodes.FormattingEnabled = True
        Me.lstBarCodes.ItemHeight = 16
        Me.lstBarCodes.Location = New System.Drawing.Point(296, 366)
        Me.lstBarCodes.Name = "lstBarCodes"
        Me.lstBarCodes.Size = New System.Drawing.Size(227, 196)
        Me.lstBarCodes.TabIndex = 52
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(531, 78)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(78, 17)
        Me.Label23.TabIndex = 53
        Me.Label23.Text = "Ingredients"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtDefReorderQty)
        Me.Panel1.Controls.Add(Me.txtQty)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtDefReorderLevel)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txtMaxInventory)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtMinInventory)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(531, 229)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(371, 202)
        Me.Panel1.TabIndex = 54
        '
        'cmbDescription
        '
        Me.cmbDescription.FormattingEnabled = True
        Me.cmbDescription.Location = New System.Drawing.Point(123, 96)
        Me.cmbDescription.Name = "cmbDescription"
        Me.cmbDescription.Size = New System.Drawing.Size(402, 24)
        Me.cmbDescription.TabIndex = 108
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnReset})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(925, 27)
        Me.ToolStrip1.TabIndex = 109
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnReset
        '
        Me.btnReset.Image = Global.BackOffice.My.Resources.Resources.cancel
        Me.btnReset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(69, 24)
        Me.btnReset.Text = "Reset"
        Me.btnReset.ToolTipText = "Clear all the fields"
        '
        'txtCommonDescription
        '
        Me.txtCommonDescription.Location = New System.Drawing.Point(121, 154)
        Me.txtCommonDescription.MaxLength = 100
        Me.txtCommonDescription.Name = "txtCommonDescription"
        Me.txtCommonDescription.ReadOnly = True
        Me.txtCommonDescription.Size = New System.Drawing.Size(402, 22)
        Me.txtCommonDescription.TabIndex = 110
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(10, 154)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(104, 17)
        Me.Label22.TabIndex = 111
        Me.Label22.Text = "Common Name"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(22, 369)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(138, 17)
        Me.Label24.TabIndex = 112
        Me.Label24.Text = "Cost Price(VAT Excl)"
        '
        'txtCostPriceVatExcl
        '
        Me.txtCostPriceVatExcl.Location = New System.Drawing.Point(166, 369)
        Me.txtCostPriceVatExcl.MaxLength = 20
        Me.txtCostPriceVatExcl.Name = "txtCostPriceVatExcl"
        Me.txtCostPriceVatExcl.ReadOnly = True
        Me.txtCostPriceVatExcl.Size = New System.Drawing.Size(126, 22)
        Me.txtCostPriceVatExcl.TabIndex = 113
        Me.txtCostPriceVatExcl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(8, 422)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(152, 17)
        Me.Label25.TabIndex = 114
        Me.Label25.Text = "Selling Price(VAT Excl)"
        '
        'txtSellingPriceVatExcl
        '
        Me.txtSellingPriceVatExcl.Location = New System.Drawing.Point(166, 424)
        Me.txtSellingPriceVatExcl.MaxLength = 20
        Me.txtSellingPriceVatExcl.Name = "txtSellingPriceVatExcl"
        Me.txtSellingPriceVatExcl.ReadOnly = True
        Me.txtSellingPriceVatExcl.Size = New System.Drawing.Size(126, 22)
        Me.txtSellingPriceVatExcl.TabIndex = 115
        Me.txtSellingPriceVatExcl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(5, 30)
        Me.txtId.MaxLength = 20
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(36, 22)
        Me.txtId.TabIndex = 116
        Me.txtId.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(298, 346)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(74, 17)
        Me.Label26.TabIndex = 117
        Me.Label26.Text = "Bar Codes"
        '
        'txtIngredients
        '
        Me.txtIngredients.Location = New System.Drawing.Point(530, 98)
        Me.txtIngredients.MaxLength = 100
        Me.txtIngredients.Multiline = True
        Me.txtIngredients.Name = "txtIngredients"
        Me.txtIngredients.ReadOnly = True
        Me.txtIngredients.Size = New System.Drawing.Size(372, 78)
        Me.txtIngredients.TabIndex = 118
        '
        'chkSellable
        '
        Me.chkSellable.AutoSize = True
        Me.chkSellable.Enabled = False
        Me.chkSellable.Location = New System.Drawing.Point(346, 200)
        Me.chkSellable.Name = "chkSellable"
        Me.chkSellable.Size = New System.Drawing.Size(80, 21)
        Me.chkSellable.TabIndex = 119
        Me.chkSellable.Text = "Sellable"
        Me.chkSellable.UseVisualStyleBackColor = True
        '
        'chkReturnable
        '
        Me.chkReturnable.AutoSize = True
        Me.chkReturnable.Enabled = False
        Me.chkReturnable.Location = New System.Drawing.Point(432, 200)
        Me.chkReturnable.Name = "chkReturnable"
        Me.chkReturnable.Size = New System.Drawing.Size(100, 21)
        Me.chkReturnable.TabIndex = 120
        Me.chkReturnable.Text = "Returnable"
        Me.chkReturnable.UseVisualStyleBackColor = True
        '
        'frmProductInquiry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 594)
        Me.Controls.Add(Me.chkReturnable)
        Me.Controls.Add(Me.chkSellable)
        Me.Controls.Add(Me.txtIngredients)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.txtSellingPriceVatExcl)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtCostPriceVatExcl)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtCommonDescription)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txtCostPriceVatIncl)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbDescription)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lstBarCodes)
        Me.Controls.Add(Me.txtVat)
        Me.Controls.Add(Me.txtPrimarySupplier)
        Me.Controls.Add(Me.txtSubClass)
        Me.Controls.Add(Me.txtSellingPriceVatIncl)
        Me.Controls.Add(Me.txtDepartment)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPacksize)
        Me.Controls.Add(Me.txtDiscount)
        Me.Controls.Add(Me.txtClass)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.chkDiscontinued)
        Me.Controls.Add(Me.txtProfitMargin)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtStandardUOM)
        Me.Controls.Add(Me.txtShortDescription)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPrimaryBarcode)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.MinimizeBox = False
        Me.Name = "frmProductInquiry"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Product Inquiry"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPacksize As TextBox
    Friend WithEvents txtPrimarySupplier As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtShortDescription As TextBox
    Friend WithEvents chkDiscontinued As CheckBox
    Friend WithEvents txtStandardUOM As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtProfitMargin As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCode As TextBox
    Friend WithEvents txtPrimaryBarcode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSellingPriceVatIncl As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtDiscount As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCostPriceVatIncl As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtVat As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDefReorderQty As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtDefReorderLevel As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtMaxInventory As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtMinInventory As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtDepartment As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtSubClass As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtClass As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtQty As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents lstBarCodes As ListBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmbDescription As ComboBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnReset As ToolStripButton
    Friend WithEvents txtCommonDescription As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents txtCostPriceVatExcl As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtSellingPriceVatExcl As TextBox
    Friend WithEvents txtId As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtIngredients As TextBox
    Friend WithEvents chkSellable As CheckBox
    Friend WithEvents chkReturnable As CheckBox
End Class
