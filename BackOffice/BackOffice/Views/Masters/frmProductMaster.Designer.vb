<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProductMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductMaster))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.txtPrimaryBarcode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtShortDescription = New System.Windows.Forms.TextBox()
        Me.chkDiscontinued = New System.Windows.Forms.CheckBox()
        Me.txtPackSize = New System.Windows.Forms.ComboBox()
        Me.txtStandardUom = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbSupplier = New System.Windows.Forms.ComboBox()
        Me.txtProfitMargin = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
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
        Me.cmbSubClass = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.cmbDepartment = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lstBarCodes = New System.Windows.Forms.ListBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtSpan = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtSellingPriceVatExcl = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCostPriceVatExcl = New System.Windows.Forms.TextBox()
        Me.chkSellable = New System.Windows.Forms.CheckBox()
        Me.cmbDescription = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnViewSuppliers = New System.Windows.Forms.ToolStripButton()
        Me.btnEditSupplier = New System.Windows.Forms.ToolStripButton()
        Me.btnEditInventory = New System.Windows.Forms.ToolStripButton()
        Me.btnAddBarcode = New System.Windows.Forms.ToolStripButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtCommonDescription = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtIngredients = New System.Windows.Forms.TextBox()
        Me.chkReturnable = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(83, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Code"
        '
        'txtCode
        '
        Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(131, 76)
        Me.txtCode.MaxLength = 20
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(175, 24)
        Me.txtCode.TabIndex = 12
        '
        'txtPrimaryBarcode
        '
        Me.txtPrimaryBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrimaryBarcode.Location = New System.Drawing.Point(131, 48)
        Me.txtPrimaryBarcode.MaxLength = 20
        Me.txtPrimaryBarcode.Name = "txtPrimaryBarcode"
        Me.txtPrimaryBarcode.Size = New System.Drawing.Size(175, 24)
        Me.txtPrimaryBarcode.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "PrimaryBarcode"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(312, 48)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 40)
        Me.btnSearch.TabIndex = 15
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 138)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(117, 17)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "Short Description"
        '
        'txtShortDescription
        '
        Me.txtShortDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShortDescription.Location = New System.Drawing.Point(131, 138)
        Me.txtShortDescription.MaxLength = 50
        Me.txtShortDescription.Name = "txtShortDescription"
        Me.txtShortDescription.Size = New System.Drawing.Size(473, 24)
        Me.txtShortDescription.TabIndex = 46
        '
        'chkDiscontinued
        '
        Me.chkDiscontinued.AutoSize = True
        Me.chkDiscontinued.Location = New System.Drawing.Point(132, 194)
        Me.chkDiscontinued.Name = "chkDiscontinued"
        Me.chkDiscontinued.Size = New System.Drawing.Size(112, 21)
        Me.chkDiscontinued.TabIndex = 45
        Me.chkDiscontinued.Text = "Discontinued"
        Me.chkDiscontinued.UseVisualStyleBackColor = True
        '
        'txtPackSize
        '
        Me.txtPackSize.AutoCompleteCustomSource.AddRange(New String() {"", "Piece", "Packet", "Crate"})
        Me.txtPackSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txtPackSize.FormattingEnabled = True
        Me.txtPackSize.Items.AddRange(New Object() {"", "Pieces", "packet", "Crate"})
        Me.txtPackSize.Location = New System.Drawing.Point(132, 302)
        Me.txtPackSize.MaxLength = 5
        Me.txtPackSize.Name = "txtPackSize"
        Me.txtPackSize.Size = New System.Drawing.Size(174, 24)
        Me.txtPackSize.TabIndex = 43
        '
        'txtStandardUom
        '
        Me.txtStandardUom.Location = New System.Drawing.Point(131, 332)
        Me.txtStandardUom.MaxLength = 20
        Me.txtStandardUom.Name = "txtStandardUom"
        Me.txtStandardUom.Size = New System.Drawing.Size(175, 22)
        Me.txtStandardUom.TabIndex = 34
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(23, 332)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(102, 17)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Standard UOM"
        '
        'cmbSupplier
        '
        Me.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSupplier.Enabled = False
        Me.cmbSupplier.FormattingEnabled = True
        Me.cmbSupplier.Location = New System.Drawing.Point(131, 360)
        Me.cmbSupplier.Name = "cmbSupplier"
        Me.cmbSupplier.Size = New System.Drawing.Size(305, 24)
        Me.cmbSupplier.TabIndex = 30
        '
        'txtProfitMargin
        '
        Me.txtProfitMargin.Location = New System.Drawing.Point(158, 127)
        Me.txtProfitMargin.MaxLength = 6
        Me.txtProfitMargin.Name = "txtProfitMargin"
        Me.txtProfitMargin.Size = New System.Drawing.Size(168, 22)
        Me.txtProfitMargin.TabIndex = 32
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 363)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 17)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Primary Supplier"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(42, 124)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 17)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Profit Margin(%)"
        '
        'txtSellingPriceVatIncl
        '
        Me.txtSellingPriceVatIncl.Location = New System.Drawing.Point(158, 71)
        Me.txtSellingPriceVatIncl.MaxLength = 20
        Me.txtSellingPriceVatIncl.Name = "txtSellingPriceVatIncl"
        Me.txtSellingPriceVatIncl.Size = New System.Drawing.Size(168, 22)
        Me.txtSellingPriceVatIncl.TabIndex = 28
        Me.txtSellingPriceVatIncl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(142, 17)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Selling Price(Vat Incl)"
        '
        'txtDiscount
        '
        Me.txtDiscount.Location = New System.Drawing.Point(158, 183)
        Me.txtDiscount.MaxLength = 6
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.Size = New System.Drawing.Size(168, 22)
        Me.txtDiscount.TabIndex = 26
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(63, 183)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 17)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Discount (%)"
        '
        'txtCostPriceVatIncl
        '
        Me.txtCostPriceVatIncl.Location = New System.Drawing.Point(158, 12)
        Me.txtCostPriceVatIncl.MaxLength = 20
        Me.txtCostPriceVatIncl.Name = "txtCostPriceVatIncl"
        Me.txtCostPriceVatIncl.Size = New System.Drawing.Size(168, 22)
        Me.txtCostPriceVatIncl.TabIndex = 22
        Me.txtCostPriceVatIncl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 17)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Cost Price(Vat Incl)"
        '
        'txtVat
        '
        Me.txtVat.Location = New System.Drawing.Point(158, 155)
        Me.txtVat.MaxLength = 6
        Me.txtVat.Name = "txtVat"
        Me.txtVat.Size = New System.Drawing.Size(168, 22)
        Me.txtVat.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(94, 153)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 17)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "VAT(%)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(55, 301)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 17)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Pack Size"
        '
        'cmbSubClass
        '
        Me.cmbSubClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubClass.FormattingEnabled = True
        Me.cmbSubClass.Location = New System.Drawing.Point(131, 452)
        Me.cmbSubClass.Name = "cmbSubClass"
        Me.cmbSubClass.Size = New System.Drawing.Size(305, 24)
        Me.cmbSubClass.Sorted = True
        Me.cmbSubClass.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(55, 452)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 17)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Sub Class"
        '
        'cmbClass
        '
        Me.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(131, 423)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(305, 24)
        Me.cmbClass.Sorted = True
        Me.cmbClass.TabIndex = 4
        '
        'cmbDepartment
        '
        Me.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartment.FormattingEnabled = True
        Me.cmbDepartment.Location = New System.Drawing.Point(131, 393)
        Me.cmbDepartment.Name = "cmbDepartment"
        Me.cmbDepartment.Size = New System.Drawing.Size(305, 24)
        Me.cmbDepartment.Sorted = True
        Me.cmbDepartment.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(83, 423)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 17)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Class"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(43, 393)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Department"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(312, 335)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 17)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Select downwards"
        '
        'btnBack
        '
        Me.btnBack.BackgroundImage = Global.BackOffice.My.Resources.Resources.red_back_arrow
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.Location = New System.Drawing.Point(854, 443)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(100, 40)
        Me.btnBack.TabIndex = 24
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'lstBarCodes
        '
        Me.lstBarCodes.Enabled = False
        Me.lstBarCodes.FormattingEnabled = True
        Me.lstBarCodes.ItemHeight = 16
        Me.lstBarCodes.Location = New System.Drawing.Point(442, 223)
        Me.lstBarCodes.Name = "lstBarCodes"
        Me.lstBarCodes.Size = New System.Drawing.Size(162, 116)
        Me.lstBarCodes.TabIndex = 49
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(439, 195)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(74, 17)
        Me.Label18.TabIndex = 50
        Me.Label18.Text = "Bar Codes"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(862, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 42)
        Me.Button1.TabIndex = 51
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'txtSpan
        '
        Me.txtSpan.Location = New System.Drawing.Point(902, 20)
        Me.txtSpan.Name = "txtSpan"
        Me.txtSpan.Size = New System.Drawing.Size(54, 22)
        Me.txtSpan.TabIndex = 52
        Me.txtSpan.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(875, 13)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(110, 17)
        Me.Label19.TabIndex = 53
        Me.Label19.Text = "Dont delete this!"
        Me.Label19.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.txtSellingPriceVatExcl)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txtCostPriceVatExcl)
        Me.Panel1.Controls.Add(Me.txtCostPriceVatIncl)
        Me.Panel1.Controls.Add(Me.txtDiscount)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtSellingPriceVatIncl)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtVat)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtProfitMargin)
        Me.Panel1.Location = New System.Drawing.Point(610, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(346, 226)
        Me.Panel1.TabIndex = 54
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 96)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(146, 17)
        Me.Label20.TabIndex = 38
        Me.Label20.Text = "Selling Price(Vat Excl)"
        '
        'txtSellingPriceVatExcl
        '
        Me.txtSellingPriceVatExcl.Location = New System.Drawing.Point(158, 99)
        Me.txtSellingPriceVatExcl.MaxLength = 20
        Me.txtSellingPriceVatExcl.Name = "txtSellingPriceVatExcl"
        Me.txtSellingPriceVatExcl.Size = New System.Drawing.Size(168, 22)
        Me.txtSellingPriceVatExcl.TabIndex = 37
        Me.txtSellingPriceVatExcl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(20, 40)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(132, 17)
        Me.Label17.TabIndex = 36
        Me.Label17.Text = "Cost Price(Vat Excl)"
        '
        'txtCostPriceVatExcl
        '
        Me.txtCostPriceVatExcl.Location = New System.Drawing.Point(158, 40)
        Me.txtCostPriceVatExcl.MaxLength = 20
        Me.txtCostPriceVatExcl.Name = "txtCostPriceVatExcl"
        Me.txtCostPriceVatExcl.Size = New System.Drawing.Size(168, 22)
        Me.txtCostPriceVatExcl.TabIndex = 35
        Me.txtCostPriceVatExcl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkSellable
        '
        Me.chkSellable.AutoSize = True
        Me.chkSellable.Location = New System.Drawing.Point(250, 194)
        Me.chkSellable.Name = "chkSellable"
        Me.chkSellable.Size = New System.Drawing.Size(80, 21)
        Me.chkSellable.TabIndex = 46
        Me.chkSellable.Text = "Sellable"
        Me.chkSellable.UseVisualStyleBackColor = True
        '
        'cmbDescription
        '
        Me.cmbDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDescription.FormattingEnabled = True
        Me.cmbDescription.Location = New System.Drawing.Point(131, 108)
        Me.cmbDescription.Name = "cmbDescription"
        Me.cmbDescription.Size = New System.Drawing.Size(473, 26)
        Me.cmbDescription.TabIndex = 107
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnClear, Me.btnDelete, Me.btnSave, Me.ToolStripSeparator1, Me.btnViewSuppliers, Me.btnEditSupplier, Me.btnEditInventory, Me.btnAddBarcode})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(966, 27)
        Me.ToolStrip1.TabIndex = 108
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.Image = Global.BackOffice.My.Resources.Resources.new_file
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(63, 24)
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew.ToolTipText = "Creates a new record"
        '
        'btnEdit
        '
        Me.btnEdit.Image = Global.BackOffice.My.Resources.Resources.pencil
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(59, 24)
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.ToolTipText = "Unlock fields for editing"
        '
        'btnClear
        '
        Me.btnClear.Image = Global.BackOffice.My.Resources.Resources.cancel
        Me.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(67, 24)
        Me.btnClear.Text = "Clear"
        Me.btnClear.ToolTipText = "Clear all the fields"
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Image = Global.BackOffice.My.Resources.Resources.trash
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(77, 24)
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.ToolTipText = "Deletes an existing record"
        '
        'btnSave
        '
        Me.btnSave.Image = Global.BackOffice.My.Resources.Resources.floppy_disk
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(64, 24)
        Me.btnSave.Text = "Save"
        Me.btnSave.ToolTipText = "Save a new or existing record"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'btnViewSuppliers
        '
        Me.btnViewSuppliers.Image = CType(resources.GetObject("btnViewSuppliers.Image"), System.Drawing.Image)
        Me.btnViewSuppliers.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnViewSuppliers.Name = "btnViewSuppliers"
        Me.btnViewSuppliers.Size = New System.Drawing.Size(130, 24)
        Me.btnViewSuppliers.Text = "View Suppliers"
        '
        'btnEditSupplier
        '
        Me.btnEditSupplier.Image = CType(resources.GetObject("btnEditSupplier.Image"), System.Drawing.Image)
        Me.btnEditSupplier.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditSupplier.Name = "btnEditSupplier"
        Me.btnEditSupplier.Size = New System.Drawing.Size(118, 24)
        Me.btnEditSupplier.Text = "Edit Supplier"
        '
        'btnEditInventory
        '
        Me.btnEditInventory.Enabled = False
        Me.btnEditInventory.Image = CType(resources.GetObject("btnEditInventory.Image"), System.Drawing.Image)
        Me.btnEditInventory.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditInventory.Name = "btnEditInventory"
        Me.btnEditInventory.Size = New System.Drawing.Size(124, 24)
        Me.btnEditInventory.Text = "Edit Inventory"
        '
        'btnAddBarcode
        '
        Me.btnAddBarcode.Enabled = False
        Me.btnAddBarcode.Image = CType(resources.GetObject("btnAddBarcode.Image"), System.Drawing.Image)
        Me.btnAddBarcode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddBarcode.Name = "btnAddBarcode"
        Me.btnAddBarcode.Size = New System.Drawing.Size(180, 24)
        Me.btnAddBarcode.Text = "Add/Remove Barcode"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(442, 349)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(162, 127)
        Me.PictureBox1.TabIndex = 109
        Me.PictureBox1.TabStop = False
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(12, 30)
        Me.txtId.MaxLength = 20
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(39, 22)
        Me.txtId.TabIndex = 110
        Me.txtId.Visible = False
        '
        'txtCommonDescription
        '
        Me.txtCommonDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCommonDescription.Location = New System.Drawing.Point(131, 166)
        Me.txtCommonDescription.MaxLength = 50
        Me.txtCommonDescription.Name = "txtCommonDescription"
        Me.txtCommonDescription.Size = New System.Drawing.Size(473, 24)
        Me.txtCommonDescription.TabIndex = 111
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(23, 165)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(104, 17)
        Me.Label21.TabIndex = 112
        Me.Label21.Text = "Common Name"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(49, 223)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(78, 17)
        Me.Label22.TabIndex = 114
        Me.Label22.Text = "Ingredients"
        '
        'txtIngredients
        '
        Me.txtIngredients.Location = New System.Drawing.Point(132, 222)
        Me.txtIngredients.MaxLength = 50
        Me.txtIngredients.Multiline = True
        Me.txtIngredients.Name = "txtIngredients"
        Me.txtIngredients.Size = New System.Drawing.Size(304, 74)
        Me.txtIngredients.TabIndex = 113
        '
        'chkReturnable
        '
        Me.chkReturnable.AutoSize = True
        Me.chkReturnable.Location = New System.Drawing.Point(336, 194)
        Me.chkReturnable.Name = "chkReturnable"
        Me.chkReturnable.Size = New System.Drawing.Size(100, 21)
        Me.chkReturnable.TabIndex = 115
        Me.chkReturnable.Text = "Returnable"
        Me.chkReturnable.UseVisualStyleBackColor = True
        '
        'frmProductMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(966, 498)
        Me.Controls.Add(Me.chkSellable)
        Me.Controls.Add(Me.chkReturnable)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtIngredients)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtCommonDescription)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.cmbDescription)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtSpan)
        Me.Controls.Add(Me.chkDiscontinued)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lstBarCodes)
        Me.Controls.Add(Me.cmbSubClass)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmbClass)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cmbDepartment)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtStandardUom)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtShortDescription)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtPackSize)
        Me.Controls.Add(Me.cmbSupplier)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtPrimaryBarcode)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.Name = "frmProductMaster"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Product Master"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPrimaryBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCostPriceVatIncl As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtVat As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbSubClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbClass As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSellingPriceVatIncl As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtStandardUom As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtProfitMargin As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPackSize As System.Windows.Forms.ComboBox
    Friend WithEvents chkDiscontinued As CheckBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtShortDescription As TextBox
    Friend WithEvents btnBack As Button
    Friend WithEvents lstBarCodes As ListBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents txtSpan As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmbDescription As ComboBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents btnEdit As ToolStripButton
    Friend WithEvents btnClear As ToolStripButton
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnViewSuppliers As ToolStripButton
    Friend WithEvents btnEditSupplier As ToolStripButton
    Friend WithEvents btnEditInventory As ToolStripButton
    Friend WithEvents btnAddBarcode As ToolStripButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtCostPriceVatExcl As TextBox
    Friend WithEvents txtSellingPriceVatExcl As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents chkSellable As CheckBox
    Friend WithEvents txtCommonDescription As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtIngredients As TextBox
    Friend WithEvents chkReturnable As CheckBox
End Class
