<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemConversion
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItemConversion))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.txtConversionDate = New System.Windows.Forms.TextBox()
        Me.txtConversionNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbRawDescription = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtRawQty = New System.Windows.Forms.TextBox()
        Me.btnRawAdd = New System.Windows.Forms.Button()
        Me.btnRawReset = New System.Windows.Forms.Button()
        Me.btnRawSearchItem = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtRawBarCode = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtRawItemCode = New System.Windows.Forms.TextBox()
        Me.txtRawPrice = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbEndDescription = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEndQty = New System.Windows.Forms.TextBox()
        Me.btnEndAdd = New System.Windows.Forms.Button()
        Me.btnEndReset = New System.Windows.Forms.Button()
        Me.btnEndSearchItem = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEndBarcode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEndItemCode = New System.Windows.Forms.TextBox()
        Me.txtEndPrice = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtgrdItemsToConvert = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgrdEndItems = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dtgrdConversionList = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnCancel = New System.Windows.Forms.ToolStripButton()
        Me.btnApprove = New System.Windows.Forms.ToolStripButton()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.btnComplete = New System.Windows.Forms.ToolStripButton()
        Me.btnArchive = New System.Windows.Forms.ToolStripButton()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dtgrdItemsToConvert, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgrdEndItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgrdConversionList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txtId)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtStatus)
        Me.Panel1.Controls.Add(Me.txtReason)
        Me.Panel1.Controls.Add(Me.txtConversionDate)
        Me.Panel1.Controls.Add(Me.txtConversionNo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(10, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(575, 164)
        Me.Panel1.TabIndex = 0
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(3, 4)
        Me.txtId.MaxLength = 50
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(34, 22)
        Me.txtId.TabIndex = 111
        Me.txtId.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(356, 4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(120, 54)
        Me.btnSearch.TabIndex = 52
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(164, 102)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(186, 22)
        Me.txtStatus.TabIndex = 7
        '
        'txtReason
        '
        Me.txtReason.Location = New System.Drawing.Point(164, 68)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(404, 22)
        Me.txtReason.TabIndex = 6
        '
        'txtConversionDate
        '
        Me.txtConversionDate.Location = New System.Drawing.Point(164, 34)
        Me.txtConversionDate.Name = "txtConversionDate"
        Me.txtConversionDate.ReadOnly = True
        Me.txtConversionDate.Size = New System.Drawing.Size(186, 22)
        Me.txtConversionDate.TabIndex = 5
        '
        'txtConversionNo
        '
        Me.txtConversionNo.Location = New System.Drawing.Point(164, 4)
        Me.txtConversionNo.Name = "txtConversionNo"
        Me.txtConversionNo.Size = New System.Drawing.Size(186, 22)
        Me.txtConversionNo.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(110, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Status"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Reason for Conversion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Conversion Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(57, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Conversion No"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.cmbRawDescription)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.txtRawQty)
        Me.Panel2.Controls.Add(Me.btnRawAdd)
        Me.Panel2.Controls.Add(Me.btnRawReset)
        Me.Panel2.Controls.Add(Me.btnRawSearchItem)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txtRawBarCode)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.txtRawItemCode)
        Me.Panel2.Controls.Add(Me.txtRawPrice)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Location = New System.Drawing.Point(10, 262)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(495, 164)
        Me.Panel2.TabIndex = 94
        '
        'cmbRawDescription
        '
        Me.cmbRawDescription.FormattingEnabled = True
        Me.cmbRawDescription.Location = New System.Drawing.Point(118, 68)
        Me.cmbRawDescription.Name = "cmbRawDescription"
        Me.cmbRawDescription.Size = New System.Drawing.Size(366, 24)
        Me.cmbRawDescription.TabIndex = 99
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(81, 129)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(30, 17)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Qty"
        '
        'txtRawQty
        '
        Me.txtRawQty.Location = New System.Drawing.Point(117, 126)
        Me.txtRawQty.MaxLength = 50
        Me.txtRawQty.Name = "txtRawQty"
        Me.txtRawQty.Size = New System.Drawing.Size(115, 22)
        Me.txtRawQty.TabIndex = 56
        '
        'btnRawAdd
        '
        Me.btnRawAdd.Enabled = False
        Me.btnRawAdd.Location = New System.Drawing.Point(238, 98)
        Me.btnRawAdd.Name = "btnRawAdd"
        Me.btnRawAdd.Size = New System.Drawing.Size(120, 50)
        Me.btnRawAdd.TabIndex = 53
        Me.btnRawAdd.Text = "Add/Update"
        Me.btnRawAdd.UseVisualStyleBackColor = True
        '
        'btnRawReset
        '
        Me.btnRawReset.Location = New System.Drawing.Point(364, 98)
        Me.btnRawReset.Name = "btnRawReset"
        Me.btnRawReset.Size = New System.Drawing.Size(120, 47)
        Me.btnRawReset.TabIndex = 54
        Me.btnRawReset.Text = "Reset"
        Me.btnRawReset.UseVisualStyleBackColor = True
        '
        'btnRawSearchItem
        '
        Me.btnRawSearchItem.Location = New System.Drawing.Point(238, 4)
        Me.btnRawSearchItem.Name = "btnRawSearchItem"
        Me.btnRawSearchItem.Size = New System.Drawing.Size(120, 54)
        Me.btnRawSearchItem.TabIndex = 51
        Me.btnRawSearchItem.Text = "Search"
        Me.btnRawSearchItem.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(44, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 17)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Item Code"
        '
        'txtRawBarCode
        '
        Me.txtRawBarCode.Location = New System.Drawing.Point(117, 4)
        Me.txtRawBarCode.MaxLength = 50
        Me.txtRawBarCode.Name = "txtRawBarCode"
        Me.txtRawBarCode.Size = New System.Drawing.Size(115, 22)
        Me.txtRawBarCode.TabIndex = 50
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(32, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 17)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Description"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(50, 7)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 17)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Barcode"
        '
        'txtRawItemCode
        '
        Me.txtRawItemCode.Location = New System.Drawing.Point(117, 35)
        Me.txtRawItemCode.MaxLength = 50
        Me.txtRawItemCode.Name = "txtRawItemCode"
        Me.txtRawItemCode.Size = New System.Drawing.Size(115, 22)
        Me.txtRawItemCode.TabIndex = 39
        '
        'txtRawPrice
        '
        Me.txtRawPrice.Location = New System.Drawing.Point(118, 98)
        Me.txtRawPrice.MaxLength = 50
        Me.txtRawPrice.Name = "txtRawPrice"
        Me.txtRawPrice.ReadOnly = True
        Me.txtRawPrice.Size = New System.Drawing.Size(115, 22)
        Me.txtRawPrice.TabIndex = 47
        Me.txtRawPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(71, 98)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 17)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "Price"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.cmbEndDescription)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.txtEndQty)
        Me.Panel3.Controls.Add(Me.btnEndAdd)
        Me.Panel3.Controls.Add(Me.btnEndReset)
        Me.Panel3.Controls.Add(Me.btnEndSearchItem)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtEndBarcode)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.txtEndItemCode)
        Me.Panel3.Controls.Add(Me.txtEndPrice)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Location = New System.Drawing.Point(898, 201)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(494, 164)
        Me.Panel3.TabIndex = 95
        '
        'cmbEndDescription
        '
        Me.cmbEndDescription.FormattingEnabled = True
        Me.cmbEndDescription.Location = New System.Drawing.Point(117, 65)
        Me.cmbEndDescription.Name = "cmbEndDescription"
        Me.cmbEndDescription.Size = New System.Drawing.Size(367, 24)
        Me.cmbEndDescription.TabIndex = 99
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(81, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 17)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Qty"
        '
        'txtEndQty
        '
        Me.txtEndQty.Location = New System.Drawing.Point(118, 123)
        Me.txtEndQty.MaxLength = 50
        Me.txtEndQty.Name = "txtEndQty"
        Me.txtEndQty.Size = New System.Drawing.Size(115, 22)
        Me.txtEndQty.TabIndex = 56
        '
        'btnEndAdd
        '
        Me.btnEndAdd.Enabled = False
        Me.btnEndAdd.Location = New System.Drawing.Point(238, 95)
        Me.btnEndAdd.Name = "btnEndAdd"
        Me.btnEndAdd.Size = New System.Drawing.Size(120, 51)
        Me.btnEndAdd.TabIndex = 53
        Me.btnEndAdd.Text = "Add/Update"
        Me.btnEndAdd.UseVisualStyleBackColor = True
        '
        'btnEndReset
        '
        Me.btnEndReset.Location = New System.Drawing.Point(364, 95)
        Me.btnEndReset.Name = "btnEndReset"
        Me.btnEndReset.Size = New System.Drawing.Size(120, 50)
        Me.btnEndReset.TabIndex = 54
        Me.btnEndReset.Text = "Reset"
        Me.btnEndReset.UseVisualStyleBackColor = True
        '
        'btnEndSearchItem
        '
        Me.btnEndSearchItem.Location = New System.Drawing.Point(238, 4)
        Me.btnEndSearchItem.Name = "btnEndSearchItem"
        Me.btnEndSearchItem.Size = New System.Drawing.Size(120, 54)
        Me.btnEndSearchItem.TabIndex = 51
        Me.btnEndSearchItem.Text = "Search"
        Me.btnEndSearchItem.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(44, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 17)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Item Code"
        '
        'txtEndBarcode
        '
        Me.txtEndBarcode.Location = New System.Drawing.Point(117, 4)
        Me.txtEndBarcode.MaxLength = 50
        Me.txtEndBarcode.Name = "txtEndBarcode"
        Me.txtEndBarcode.Size = New System.Drawing.Size(115, 22)
        Me.txtEndBarcode.TabIndex = 50
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(37, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 17)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Description"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(50, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 17)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Barcode"
        '
        'txtEndItemCode
        '
        Me.txtEndItemCode.Location = New System.Drawing.Point(117, 35)
        Me.txtEndItemCode.MaxLength = 50
        Me.txtEndItemCode.Name = "txtEndItemCode"
        Me.txtEndItemCode.Size = New System.Drawing.Size(115, 22)
        Me.txtEndItemCode.TabIndex = 39
        '
        'txtEndPrice
        '
        Me.txtEndPrice.Location = New System.Drawing.Point(118, 95)
        Me.txtEndPrice.MaxLength = 50
        Me.txtEndPrice.Name = "txtEndPrice"
        Me.txtEndPrice.ReadOnly = True
        Me.txtEndPrice.Size = New System.Drawing.Size(115, 22)
        Me.txtEndPrice.TabIndex = 47
        Me.txtEndPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(75, 95)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 17)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Price"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 238)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(173, 17)
        Me.Label11.TabIndex = 96
        Me.Label11.Text = "Select products to convert"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(895, 181)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(134, 17)
        Me.Label14.TabIndex = 97
        Me.Label14.Text = "Select end products"
        '
        'dtgrdItemsToConvert
        '
        Me.dtgrdItemsToConvert.AllowUserToAddRows = False
        Me.dtgrdItemsToConvert.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtgrdItemsToConvert.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdItemsToConvert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdItemsToConvert.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dtgrdItemsToConvert.Location = New System.Drawing.Point(10, 449)
        Me.dtgrdItemsToConvert.Name = "dtgrdItemsToConvert"
        Me.dtgrdItemsToConvert.ReadOnly = True
        Me.dtgrdItemsToConvert.RowTemplate.Height = 24
        Me.dtgrdItemsToConvert.Size = New System.Drawing.Size(884, 196)
        Me.dtgrdItemsToConvert.TabIndex = 98
        '
        'Column1
        '
        Me.Column1.HeaderText = "Item Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Description"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Qty"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column4.HeaderText = "Price"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'dtgrdEndItems
        '
        Me.dtgrdEndItems.AllowUserToAddRows = False
        Me.dtgrdEndItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdEndItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdEndItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdEndItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.dtgrdEndItems.Location = New System.Drawing.Point(898, 397)
        Me.dtgrdEndItems.Name = "dtgrdEndItems"
        Me.dtgrdEndItems.ReadOnly = True
        Me.dtgrdEndItems.RowTemplate.Height = 24
        Me.dtgrdEndItems.Size = New System.Drawing.Size(883, 248)
        Me.dtgrdEndItems.TabIndex = 99
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Item Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Qty"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn4.HeaderText = "Price"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 429)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(131, 17)
        Me.Label15.TabIndex = 100
        Me.Label15.Text = "Products to convert"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(898, 377)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(208, 17)
        Me.Label20.TabIndex = 101
        Me.Label20.Text = "End products (after conversion)"
        '
        'dtgrdConversionList
        '
        Me.dtgrdConversionList.AllowUserToAddRows = False
        Me.dtgrdConversionList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdConversionList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdConversionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdConversionList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.dtgrdConversionList.Location = New System.Drawing.Point(1168, 50)
        Me.dtgrdConversionList.Name = "dtgrdConversionList"
        Me.dtgrdConversionList.ReadOnly = True
        Me.dtgrdConversionList.RowTemplate.Height = 24
        Me.dtgrdConversionList.Size = New System.Drawing.Size(613, 146)
        Me.dtgrdConversionList.TabIndex = 106
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Conv No"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackgroundImage = Global.BackOffice.My.Resources.Resources.red_back_arrow
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.Location = New System.Drawing.Point(1681, 651)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(100, 40)
        Me.btnBack.TabIndex = 110
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnClear, Me.btnSave, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.ToolStripSeparator3, Me.ToolStripSeparator4, Me.btnCancel, Me.btnApprove, Me.btnPrint, Me.btnComplete, Me.btnArchive})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1789, 27)
        Me.ToolStrip1.TabIndex = 113
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 27)
        '
        'btnNew
        '
        Me.btnNew.Image = Global.BackOffice.My.Resources.Resources.new_file
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(63, 24)
        Me.btnNew.Text = "New"
        Me.btnNew.ToolTipText = "Creates a new Conversion document"
        '
        'btnEdit
        '
        Me.btnEdit.Image = Global.BackOffice.My.Resources.Resources.pencil
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(59, 24)
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.ToolTipText = "Promts user to edit an existing conversion document"
        '
        'btnClear
        '
        Me.btnClear.Image = Global.BackOffice.My.Resources.Resources.brush
        Me.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(67, 24)
        Me.btnClear.Text = "Clear"
        Me.btnClear.ToolTipText = "Clear all the fields"
        '
        'btnSave
        '
        Me.btnSave.Image = Global.BackOffice.My.Resources.Resources.floppy_disk
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(64, 24)
        Me.btnSave.Text = "Save"
        Me.btnSave.ToolTipText = "Save details of a new or existing document"
        '
        'btnCancel
        '
        Me.btnCancel.Image = Global.BackOffice.My.Resources.Resources.cancel
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(77, 24)
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.ToolTipText = "Cancels the conversion document"
        '
        'btnApprove
        '
        Me.btnApprove.Image = Global.BackOffice.My.Resources.Resources.tick
        Me.btnApprove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(90, 24)
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.ToolTipText = "Approve a pending conversion document for further actions"
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.BackOffice.My.Resources.Resources.printer
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(180, 24)
        Me.btnPrint.Text = "Print Production Sheet"
        Me.btnPrint.ToolTipText = "Print an already approved conversion document"
        '
        'btnComplete
        '
        Me.btnComplete.Image = Global.BackOffice.My.Resources.Resources.foward_arrow
        Me.btnComplete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnComplete.Name = "btnComplete"
        Me.btnComplete.Size = New System.Drawing.Size(98, 24)
        Me.btnComplete.Text = "Complete"
        '
        'btnArchive
        '
        Me.btnArchive.Image = CType(resources.GetObject("btnArchive.Image"), System.Drawing.Image)
        Me.btnArchive.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnArchive.Name = "btnArchive"
        Me.btnArchive.Size = New System.Drawing.Size(82, 24)
        Me.btnArchive.Text = "Archive"
        Me.btnArchive.ToolTipText = "Sends a completed document to archives for future references"
        '
        'frmItemConversion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1789, 703)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.dtgrdConversionList)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.dtgrdEndItems)
        Me.Controls.Add(Me.dtgrdItemsToConvert)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmItemConversion"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Product Stock Conversion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dtgrdItemsToConvert, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgrdEndItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgrdConversionList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents txtReason As TextBox
    Friend WithEvents txtConversionDate As TextBox
    Friend WithEvents txtConversionNo As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmbRawDescription As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtRawQty As TextBox
    Friend WithEvents btnRawAdd As Button
    Friend WithEvents btnRawReset As Button
    Friend WithEvents btnRawSearchItem As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents txtRawBarCode As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtRawItemCode As TextBox
    Friend WithEvents txtRawPrice As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmbEndDescription As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtEndQty As TextBox
    Friend WithEvents btnEndAdd As Button
    Friend WithEvents btnEndReset As Button
    Friend WithEvents btnEndSearchItem As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEndBarcode As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtEndItemCode As TextBox
    Friend WithEvents txtEndPrice As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents dtgrdItemsToConvert As DataGridView
    Friend WithEvents dtgrdEndItems As DataGridView
    Friend WithEvents Label15 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents dtgrdConversionList As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents txtId As TextBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents btnEdit As ToolStripButton
    Friend WithEvents btnClear As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnCancel As ToolStripButton
    Friend WithEvents btnApprove As ToolStripButton
    Friend WithEvents btnPrint As ToolStripButton
    Friend WithEvents btnArchive As ToolStripButton
    Friend WithEvents btnComplete As ToolStripButton
End Class
