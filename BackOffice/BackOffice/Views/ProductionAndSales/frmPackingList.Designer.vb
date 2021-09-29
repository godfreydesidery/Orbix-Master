<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPackingList
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPackingList))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIssueNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dtgrdPackingLists = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTotalAmountIssued = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalReturns = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalDiscounts = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalExpenses = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalBankDeposit = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCostOfGoodsSold = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtTotalPreviousReturns = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtTotalAmountPacked = New System.Windows.Forms.TextBox()
        Me.btnDeficit = New System.Windows.Forms.Button()
        Me.txtTotalSales = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtDebt = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotalDamages = New System.Windows.Forms.TextBox()
        Me.dtgrdItemList = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtDetailId = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtCPrice = New System.Windows.Forms.TextBox()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtReturns = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtIssuedQty = New System.Windows.Forms.TextBox()
        Me.cmbDescription = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtQtyDamaged = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtQtySold = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtQtyReturned = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtPacked = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.txtPackSize = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnSearchItem = New System.Windows.Forms.Button()
        Me.txtStockSize = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBarCode = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbSalesPersons = New System.Windows.Forms.ComboBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtCreated = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtPrinted = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtCash = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtCompleted = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtIssued = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtApproved = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cntxtMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancel = New System.Windows.Forms.ToolStripButton()
        Me.btnApprove = New System.Windows.Forms.ToolStripButton()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.btnComplete = New System.Windows.Forms.ToolStripButton()
        Me.btnClearDebt = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnArchive = New System.Windows.Forms.ToolStripButton()
        Me.btnArchiveAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPrintReport = New System.Windows.Forms.ToolStripButton()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dtgrdPackingLists, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgrdItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.cntxtMenu.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Issue No"
        '
        'txtIssueNo
        '
        Me.txtIssueNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtIssueNo.Location = New System.Drawing.Point(81, 8)
        Me.txtIssueNo.Name = "txtIssueNo"
        Me.txtIssueNo.ReadOnly = True
        Me.txtIssueNo.Size = New System.Drawing.Size(220, 27)
        Me.txtIssueNo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Created"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "SM Officer"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 258)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Status"
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtStatus.Location = New System.Drawing.Point(81, 252)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(327, 27)
        Me.txtStatus.TabIndex = 7
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(308, 5)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 35)
        Me.btnSearch.TabIndex = 9
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dtgrdPackingLists
        '
        Me.dtgrdPackingLists.AllowUserToAddRows = False
        Me.dtgrdPackingLists.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdPackingLists.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdPackingLists.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdPackingLists.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtgrdPackingLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdPackingLists.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.dtgrdPackingLists.Location = New System.Drawing.Point(1240, 50)
        Me.dtgrdPackingLists.Name = "dtgrdPackingLists"
        Me.dtgrdPackingLists.ReadOnly = True
        Me.dtgrdPackingLists.RowTemplate.Height = 24
        Me.dtgrdPackingLists.Size = New System.Drawing.Size(547, 172)
        Me.dtgrdPackingLists.TabIndex = 67
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn1.FillWeight = 42.63959!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Issue No"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 59.71546!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Issue Date"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.FillWeight = 197.6449!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Summary"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'txtTotalAmountIssued
        '
        Me.txtTotalAmountIssued.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtTotalAmountIssued.Location = New System.Drawing.Point(228, 362)
        Me.txtTotalAmountIssued.Name = "txtTotalAmountIssued"
        Me.txtTotalAmountIssued.ReadOnly = True
        Me.txtTotalAmountIssued.Size = New System.Drawing.Size(181, 27)
        Me.txtTotalAmountIssued.TabIndex = 73
        Me.txtTotalAmountIssued.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(119, 369)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 17)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "Amount Issued"
        '
        'txtTotalReturns
        '
        Me.txtTotalReturns.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtTotalReturns.Location = New System.Drawing.Point(228, 428)
        Me.txtTotalReturns.Name = "txtTotalReturns"
        Me.txtTotalReturns.ReadOnly = True
        Me.txtTotalReturns.Size = New System.Drawing.Size(181, 27)
        Me.txtTotalReturns.TabIndex = 75
        Me.txtTotalReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(129, 601)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 17)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "Bank Deposit"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(126, 435)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 17)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "Total Returns"
        '
        'txtTotalDiscounts
        '
        Me.txtTotalDiscounts.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtTotalDiscounts.Location = New System.Drawing.Point(228, 495)
        Me.txtTotalDiscounts.Name = "txtTotalDiscounts"
        Me.txtTotalDiscounts.Size = New System.Drawing.Size(181, 27)
        Me.txtTotalDiscounts.TabIndex = 79
        Me.txtTotalDiscounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(116, 502)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 17)
        Me.Label8.TabIndex = 78
        Me.Label8.Text = "Total Discounts"
        '
        'txtTotalExpenses
        '
        Me.txtTotalExpenses.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtTotalExpenses.Location = New System.Drawing.Point(228, 528)
        Me.txtTotalExpenses.Name = "txtTotalExpenses"
        Me.txtTotalExpenses.Size = New System.Drawing.Size(181, 27)
        Me.txtTotalExpenses.TabIndex = 81
        Me.txtTotalExpenses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(116, 468)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 17)
        Me.Label9.TabIndex = 80
        Me.Label9.Text = "Total Damages"
        '
        'txtTotalBankDeposit
        '
        Me.txtTotalBankDeposit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtTotalBankDeposit.Location = New System.Drawing.Point(228, 594)
        Me.txtTotalBankDeposit.Name = "txtTotalBankDeposit"
        Me.txtTotalBankDeposit.Size = New System.Drawing.Size(181, 27)
        Me.txtTotalBankDeposit.TabIndex = 83
        Me.txtTotalBankDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(97, 529)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(125, 17)
        Me.Label10.TabIndex = 82
        Me.Label10.Text = "Total expenditures"
        '
        'txtCostOfGoodsSold
        '
        Me.txtCostOfGoodsSold.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtCostOfGoodsSold.Location = New System.Drawing.Point(228, 561)
        Me.txtCostOfGoodsSold.Name = "txtCostOfGoodsSold"
        Me.txtCostOfGoodsSold.ReadOnly = True
        Me.txtCostOfGoodsSold.Size = New System.Drawing.Size(181, 27)
        Me.txtCostOfGoodsSold.TabIndex = 102
        Me.txtCostOfGoodsSold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(57, 568)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(165, 17)
        Me.Label29.TabIndex = 101
        Me.Label29.Text = "Cost Value of goods sold"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(131, 302)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(91, 17)
        Me.Label26.TabIndex = 95
        Me.Label26.Text = "Prev Returns"
        '
        'txtTotalPreviousReturns
        '
        Me.txtTotalPreviousReturns.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtTotalPreviousReturns.Location = New System.Drawing.Point(228, 296)
        Me.txtTotalPreviousReturns.Name = "txtTotalPreviousReturns"
        Me.txtTotalPreviousReturns.ReadOnly = True
        Me.txtTotalPreviousReturns.Size = New System.Drawing.Size(181, 27)
        Me.txtTotalPreviousReturns.TabIndex = 96
        Me.txtTotalPreviousReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(129, 336)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(91, 17)
        Me.Label25.TabIndex = 93
        Me.Label25.Text = "Total Packed"
        '
        'txtTotalAmountPacked
        '
        Me.txtTotalAmountPacked.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtTotalAmountPacked.Location = New System.Drawing.Point(228, 329)
        Me.txtTotalAmountPacked.Name = "txtTotalAmountPacked"
        Me.txtTotalAmountPacked.ReadOnly = True
        Me.txtTotalAmountPacked.Size = New System.Drawing.Size(181, 27)
        Me.txtTotalAmountPacked.TabIndex = 94
        Me.txtTotalAmountPacked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDeficit
        '
        Me.btnDeficit.Location = New System.Drawing.Point(228, 693)
        Me.btnDeficit.Name = "btnDeficit"
        Me.btnDeficit.Size = New System.Drawing.Size(181, 35)
        Me.btnDeficit.TabIndex = 92
        Me.btnDeficit.Text = "Calculate Deficit"
        Me.btnDeficit.UseVisualStyleBackColor = True
        '
        'txtTotalSales
        '
        Me.txtTotalSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtTotalSales.Location = New System.Drawing.Point(228, 395)
        Me.txtTotalSales.Name = "txtTotalSales"
        Me.txtTotalSales.ReadOnly = True
        Me.txtTotalSales.Size = New System.Drawing.Size(181, 27)
        Me.txtTotalSales.TabIndex = 90
        Me.txtTotalSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(141, 402)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 17)
        Me.Label14.TabIndex = 91
        Me.Label14.Text = "Total Sales"
        '
        'txtDebt
        '
        Me.txtDebt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtDebt.Location = New System.Drawing.Point(228, 660)
        Me.txtDebt.Name = "txtDebt"
        Me.txtDebt.Size = New System.Drawing.Size(181, 27)
        Me.txtDebt.TabIndex = 85
        Me.txtDebt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(131, 661)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 17)
        Me.Label11.TabIndex = 84
        Me.Label11.Text = "Deficit (Debt)"
        '
        'txtTotalDamages
        '
        Me.txtTotalDamages.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtTotalDamages.Location = New System.Drawing.Point(228, 461)
        Me.txtTotalDamages.Name = "txtTotalDamages"
        Me.txtTotalDamages.ReadOnly = True
        Me.txtTotalDamages.Size = New System.Drawing.Size(181, 27)
        Me.txtTotalDamages.TabIndex = 77
        Me.txtTotalDamages.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtgrdItemList
        '
        Me.dtgrdItemList.AllowUserToAddRows = False
        Me.dtgrdItemList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdItemList.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdItemList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtgrdItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column8, Me.Column9, Me.Column10, Me.Column2, Me.Column3, Me.Column11, Me.Column13, Me.Column12, Me.Column14, Me.Column1, Me.Column4})
        Me.dtgrdItemList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgrdItemList.Location = New System.Drawing.Point(439, 276)
        Me.dtgrdItemList.Name = "dtgrdItemList"
        Me.dtgrdItemList.ReadOnly = True
        Me.dtgrdItemList.RowTemplate.Height = 24
        Me.dtgrdItemList.Size = New System.Drawing.Size(1348, 528)
        Me.dtgrdItemList.TabIndex = 90
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.txtDetailId)
        Me.Panel2.Controls.Add(Me.Label28)
        Me.Panel2.Controls.Add(Me.txtCPrice)
        Me.Panel2.Controls.Add(Me.btnChange)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.txtReturns)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.txtIssuedQty)
        Me.Panel2.Controls.Add(Me.cmbDescription)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.txtQtyDamaged)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.txtQtySold)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.txtQtyReturned)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.txtPacked)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.btnReset)
        Me.Panel2.Controls.Add(Me.txtPackSize)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.btnSearchItem)
        Me.Panel2.Controls.Add(Me.txtStockSize)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txtBarCode)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.txtCode)
        Me.Panel2.Controls.Add(Me.txtPrice)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Location = New System.Drawing.Point(439, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(795, 200)
        Me.Panel2.TabIndex = 93
        '
        'txtDetailId
        '
        Me.txtDetailId.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtDetailId.Location = New System.Drawing.Point(278, 130)
        Me.txtDetailId.MaxLength = 50
        Me.txtDetailId.Name = "txtDetailId"
        Me.txtDetailId.Size = New System.Drawing.Size(38, 27)
        Me.txtDetailId.TabIndex = 107
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(11, 169)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(72, 17)
        Me.Label28.TabIndex = 105
        Me.Label28.Text = "Cost Price"
        '
        'txtCPrice
        '
        Me.txtCPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtCPrice.Location = New System.Drawing.Point(88, 163)
        Me.txtCPrice.MaxLength = 50
        Me.txtCPrice.Name = "txtCPrice"
        Me.txtCPrice.ReadOnly = True
        Me.txtCPrice.Size = New System.Drawing.Size(100, 27)
        Me.txtCPrice.TabIndex = 106
        Me.txtCPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(194, 130)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(50, 25)
        Me.btnChange.TabIndex = 104
        Me.btnChange.Text = "<c>"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(457, 9)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(58, 17)
        Me.Label24.TabIndex = 102
        Me.Label24.Text = "Returns"
        '
        'txtReturns
        '
        Me.txtReturns.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtReturns.Location = New System.Drawing.Point(521, 6)
        Me.txtReturns.MaxLength = 50
        Me.txtReturns.Name = "txtReturns"
        Me.txtReturns.Size = New System.Drawing.Size(80, 27)
        Me.txtReturns.TabIndex = 103
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(466, 44)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(49, 17)
        Me.Label23.TabIndex = 100
        Me.Label23.Text = "Issued"
        '
        'txtIssuedQty
        '
        Me.txtIssuedQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtIssuedQty.Location = New System.Drawing.Point(521, 39)
        Me.txtIssuedQty.MaxLength = 50
        Me.txtIssuedQty.Name = "txtIssuedQty"
        Me.txtIssuedQty.Size = New System.Drawing.Size(80, 27)
        Me.txtIssuedQty.TabIndex = 101
        '
        'cmbDescription
        '
        Me.cmbDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDescription.FormattingEnabled = True
        Me.cmbDescription.Location = New System.Drawing.Point(5, 96)
        Me.cmbDescription.Name = "cmbDescription"
        Me.cmbDescription.Size = New System.Drawing.Size(449, 28)
        Me.cmbDescription.TabIndex = 99
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(607, 83)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(95, 17)
        Me.Label22.TabIndex = 61
        Me.Label22.Text = "Qty Damaged"
        '
        'txtQtyDamaged
        '
        Me.txtQtyDamaged.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtQtyDamaged.Location = New System.Drawing.Point(703, 77)
        Me.txtQtyDamaged.MaxLength = 50
        Me.txtQtyDamaged.Name = "txtQtyDamaged"
        Me.txtQtyDamaged.Size = New System.Drawing.Size(80, 27)
        Me.txtQtyDamaged.TabIndex = 62
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(634, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 17)
        Me.Label21.TabIndex = 59
        Me.Label21.Text = "Qty Sold"
        '
        'txtQtySold
        '
        Me.txtQtySold.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtQtySold.Location = New System.Drawing.Point(703, 8)
        Me.txtQtySold.MaxLength = 50
        Me.txtQtySold.Name = "txtQtySold"
        Me.txtQtySold.Size = New System.Drawing.Size(80, 27)
        Me.txtQtySold.TabIndex = 60
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(607, 49)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(93, 17)
        Me.Label20.TabIndex = 57
        Me.Label20.Text = "Qty Returned"
        '
        'txtQtyReturned
        '
        Me.txtQtyReturned.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtQtyReturned.Location = New System.Drawing.Point(703, 44)
        Me.txtQtyReturned.MaxLength = 50
        Me.txtQtyReturned.Name = "txtQtyReturned"
        Me.txtQtyReturned.Size = New System.Drawing.Size(80, 27)
        Me.txtQtyReturned.TabIndex = 58
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(460, 82)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 17)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Packed"
        '
        'txtPacked
        '
        Me.txtPacked.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtPacked.Location = New System.Drawing.Point(521, 76)
        Me.txtPacked.MaxLength = 50
        Me.txtPacked.Name = "txtPacked"
        Me.txtPacked.ReadOnly = True
        Me.txtPacked.Size = New System.Drawing.Size(80, 27)
        Me.txtPacked.TabIndex = 56
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(521, 116)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(110, 35)
        Me.btnAdd.TabIndex = 53
        Me.btnAdd.Text = "Add/Update"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(355, 6)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 17)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "Pack Size"
        Me.Label15.Visible = False
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(652, 116)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(85, 35)
        Me.btnReset.TabIndex = 54
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'txtPackSize
        '
        Me.txtPackSize.Location = New System.Drawing.Point(346, 41)
        Me.txtPackSize.MaxLength = 50
        Me.txtPackSize.Name = "txtPackSize"
        Me.txtPackSize.ReadOnly = True
        Me.txtPackSize.Size = New System.Drawing.Size(61, 22)
        Me.txtPackSize.TabIndex = 44
        Me.txtPackSize.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(355, 6)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 17)
        Me.Label17.TabIndex = 46
        Me.Label17.Text = "Stock Size"
        Me.Label17.Visible = False
        '
        'btnSearchItem
        '
        Me.btnSearchItem.Location = New System.Drawing.Point(240, 5)
        Me.btnSearchItem.Name = "btnSearchItem"
        Me.btnSearchItem.Size = New System.Drawing.Size(100, 35)
        Me.btnSearchItem.TabIndex = 51
        Me.btnSearchItem.Text = "Search"
        Me.btnSearchItem.UseVisualStyleBackColor = True
        '
        'txtStockSize
        '
        Me.txtStockSize.Location = New System.Drawing.Point(366, 13)
        Me.txtStockSize.MaxLength = 50
        Me.txtStockSize.Name = "txtStockSize"
        Me.txtStockSize.ReadOnly = True
        Me.txtStockSize.Size = New System.Drawing.Size(53, 22)
        Me.txtStockSize.TabIndex = 48
        Me.txtStockSize.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(39, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 17)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Code"
        '
        'txtBarCode
        '
        Me.txtBarCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarCode.Location = New System.Drawing.Point(89, 6)
        Me.txtBarCode.MaxLength = 50
        Me.txtBarCode.Name = "txtBarCode"
        Me.txtBarCode.Size = New System.Drawing.Size(145, 27)
        Me.txtBarCode.TabIndex = 50
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 76)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 17)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Description"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(19, 11)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 17)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Barcode"
        '
        'txtCode
        '
        Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(89, 43)
        Me.txtCode.MaxLength = 50
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(145, 27)
        Me.txtCode.TabIndex = 39
        '
        'txtPrice
        '
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtPrice.Location = New System.Drawing.Point(89, 130)
        Me.txtPrice.MaxLength = 50
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.ReadOnly = True
        Me.txtPrice.Size = New System.Drawing.Size(99, 27)
        Me.txtPrice.TabIndex = 47
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 133)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(86, 17)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "Selling Price"
        '
        'cmbSalesPersons
        '
        Me.cmbSalesPersons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSalesPersons.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbSalesPersons.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.cmbSalesPersons.FormattingEnabled = True
        Me.cmbSalesPersons.Location = New System.Drawing.Point(82, 48)
        Me.cmbSalesPersons.Name = "cmbSalesPersons"
        Me.cmbSalesPersons.Size = New System.Drawing.Size(327, 28)
        Me.cmbSalesPersons.TabIndex = 94
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(51, 29)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(21, 22)
        Me.txtId.TabIndex = 95
        Me.txtId.Visible = False
        '
        'txtCreated
        '
        Me.txtCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtCreated.Location = New System.Drawing.Point(82, 83)
        Me.txtCreated.Name = "txtCreated"
        Me.txtCreated.ReadOnly = True
        Me.txtCreated.Size = New System.Drawing.Size(327, 27)
        Me.txtCreated.TabIndex = 96
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.txtPrinted)
        Me.Panel3.Controls.Add(Me.Label34)
        Me.Panel3.Controls.Add(Me.txtCash)
        Me.Panel3.Controls.Add(Me.Label33)
        Me.Panel3.Controls.Add(Me.txtCompleted)
        Me.Panel3.Controls.Add(Me.Label32)
        Me.Panel3.Controls.Add(Me.txtIssued)
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Controls.Add(Me.txtApproved)
        Me.Panel3.Controls.Add(Me.Label30)
        Me.Panel3.Controls.Add(Me.txtCostOfGoodsSold)
        Me.Panel3.Controls.Add(Me.txtIssueNo)
        Me.Panel3.Controls.Add(Me.Label29)
        Me.Panel3.Controls.Add(Me.txtCreated)
        Me.Panel3.Controls.Add(Me.btnDeficit)
        Me.Panel3.Controls.Add(Me.Label26)
        Me.Panel3.Controls.Add(Me.txtDebt)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.txtTotalPreviousReturns)
        Me.Panel3.Controls.Add(Me.txtTotalBankDeposit)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label25)
        Me.Panel3.Controls.Add(Me.txtId)
        Me.Panel3.Controls.Add(Me.txtTotalAmountPacked)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.cmbSalesPersons)
        Me.Panel3.Controls.Add(Me.txtTotalSales)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtStatus)
        Me.Panel3.Controls.Add(Me.btnSearch)
        Me.Panel3.Controls.Add(Me.txtTotalDamages)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.txtTotalDiscounts)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.txtTotalReturns)
        Me.Panel3.Controls.Add(Me.txtTotalAmountIssued)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.txtTotalExpenses)
        Me.Panel3.Location = New System.Drawing.Point(10, 50)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(423, 754)
        Me.Panel3.TabIndex = 97
        '
        'txtPrinted
        '
        Me.txtPrinted.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtPrinted.Location = New System.Drawing.Point(81, 152)
        Me.txtPrinted.Name = "txtPrinted"
        Me.txtPrinted.ReadOnly = True
        Me.txtPrinted.Size = New System.Drawing.Size(327, 27)
        Me.txtPrinted.TabIndex = 112
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(22, 158)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(53, 17)
        Me.Label34.TabIndex = 111
        Me.Label34.Text = "Printed"
        '
        'txtCash
        '
        Me.txtCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtCash.Location = New System.Drawing.Point(228, 627)
        Me.txtCash.Name = "txtCash"
        Me.txtCash.Size = New System.Drawing.Size(181, 27)
        Me.txtCash.TabIndex = 110
        Me.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(180, 628)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(40, 17)
        Me.Label33.TabIndex = 109
        Me.Label33.Text = "Cash"
        '
        'txtCompleted
        '
        Me.txtCompleted.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtCompleted.Location = New System.Drawing.Point(81, 218)
        Me.txtCompleted.Name = "txtCompleted"
        Me.txtCompleted.ReadOnly = True
        Me.txtCompleted.Size = New System.Drawing.Size(327, 27)
        Me.txtCompleted.TabIndex = 108
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(3, 224)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(75, 17)
        Me.Label32.TabIndex = 107
        Me.Label32.Text = "Completed"
        '
        'txtIssued
        '
        Me.txtIssued.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtIssued.Location = New System.Drawing.Point(81, 185)
        Me.txtIssued.Name = "txtIssued"
        Me.txtIssued.ReadOnly = True
        Me.txtIssued.Size = New System.Drawing.Size(327, 27)
        Me.txtIssued.TabIndex = 106
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(26, 191)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(49, 17)
        Me.Label31.TabIndex = 105
        Me.Label31.Text = "Issued"
        '
        'txtApproved
        '
        Me.txtApproved.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.txtApproved.Location = New System.Drawing.Point(81, 116)
        Me.txtApproved.Name = "txtApproved"
        Me.txtApproved.ReadOnly = True
        Me.txtApproved.Size = New System.Drawing.Size(327, 27)
        Me.txtApproved.TabIndex = 104
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(9, 122)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(69, 17)
        Me.Label30.TabIndex = 103
        Me.Label30.Text = "Approved"
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(1485, 256)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(302, 17)
        Me.Label27.TabIndex = 100
        Me.Label27.Text = "Item list(Click to select, Double click to remove)"
        '
        'cntxtMenu
        '
        Me.cntxtMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cntxtMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnRemove})
        Me.cntxtMenu.Name = "cntxtMenu"
        Me.cntxtMenu.Size = New System.Drawing.Size(167, 28)
        '
        'mnRemove
        '
        Me.mnRemove.Name = "mnRemove"
        Me.mnRemove.Size = New System.Drawing.Size(166, 24)
        Me.mnRemove.Text = "Remove Item"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnClear, Me.btnSave, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.ToolStripSeparator3, Me.ToolStripSeparator4, Me.btnCancel, Me.btnApprove, Me.btnPrint, Me.btnComplete, Me.btnClearDebt, Me.ToolStripSeparator6, Me.btnArchive, Me.btnArchiveAll, Me.ToolStripSeparator5, Me.btnPrintReport})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1799, 27)
        Me.ToolStrip1.TabIndex = 101
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.Image = Global.BackOffice.My.Resources.Resources.new_file
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(63, 24)
        Me.btnNew.Text = "New"
        Me.btnNew.ToolTipText = "Creates a new Packing List"
        '
        'btnEdit
        '
        Me.btnEdit.Image = Global.BackOffice.My.Resources.Resources.pencil
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(59, 24)
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.ToolTipText = "Promts user to edit an existing Packing List"
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
        Me.btnSave.ToolTipText = "Save details of a new or existing Packing List"
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
        'btnCancel
        '
        Me.btnCancel.Image = Global.BackOffice.My.Resources.Resources.cancel
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(77, 24)
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.ToolTipText = "Cancels the packing list"
        '
        'btnApprove
        '
        Me.btnApprove.Image = Global.BackOffice.My.Resources.Resources.tick
        Me.btnApprove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(90, 24)
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.ToolTipText = "Approve the Packing List"
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.BackOffice.My.Resources.Resources.printer
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(63, 24)
        Me.btnPrint.Text = "Print"
        Me.btnPrint.ToolTipText = "Removes items from stock and print the packing list to pdf"
        '
        'btnComplete
        '
        Me.btnComplete.Image = Global.BackOffice.My.Resources.Resources.foward_arrow
        Me.btnComplete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnComplete.Name = "btnComplete"
        Me.btnComplete.Size = New System.Drawing.Size(160, 24)
        Me.btnComplete.Text = "Complete and post"
        Me.btnComplete.ToolTipText = "Complete sales made from the packing list"
        '
        'btnClearDebt
        '
        Me.btnClearDebt.Enabled = False
        Me.btnClearDebt.Image = Global.BackOffice.My.Resources.Resources.money
        Me.btnClearDebt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClearDebt.Name = "btnClearDebt"
        Me.btnClearDebt.Size = New System.Drawing.Size(92, 24)
        Me.btnClearDebt.Text = "Pay Debt"
        Me.btnClearDebt.ToolTipText = "Receive debts from sales persons"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 27)
        '
        'btnArchive
        '
        Me.btnArchive.Image = CType(resources.GetObject("btnArchive.Image"), System.Drawing.Image)
        Me.btnArchive.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnArchive.Name = "btnArchive"
        Me.btnArchive.Size = New System.Drawing.Size(82, 24)
        Me.btnArchive.Text = "Archive"
        Me.btnArchive.ToolTipText = "Sends a completed packing list to archives for future references"
        '
        'btnArchiveAll
        '
        Me.btnArchiveAll.Image = CType(resources.GetObject("btnArchiveAll.Image"), System.Drawing.Image)
        Me.btnArchiveAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnArchiveAll.Name = "btnArchiveAll"
        Me.btnArchiveAll.Size = New System.Drawing.Size(102, 24)
        Me.btnArchiveAll.Text = "Archive all"
        Me.btnArchiveAll.ToolTipText = "Sends all completed and cleared packing list to archives for future references"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 27)
        '
        'btnPrintReport
        '
        Me.btnPrintReport.Image = Global.BackOffice.My.Resources.Resources.printer
        Me.btnPrintReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrintReport.Name = "btnPrintReport"
        Me.btnPrintReport.Size = New System.Drawing.Size(112, 24)
        Me.btnPrintReport.Text = "Print Report"
        Me.btnPrintReport.ToolTipText = "Print packing list as report to pdf"
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackgroundImage = Global.BackOffice.My.Resources.Resources.red_back_arrow
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.Location = New System.Drawing.Point(1687, 832)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(100, 40)
        Me.btnBack.TabIndex = 92
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Column8
        '
        Me.Column8.FillWeight = 61.77913!
        Me.Column8.HeaderText = "Code"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.FillWeight = 233.4812!
        Me.Column9.HeaderText = "Description"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column10.FillWeight = 89.8288!
        Me.Column10.HeaderText = "Price"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Returns"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Issued"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.FillWeight = 85.86243!
        Me.Column11.HeaderText = "Total Packed"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.FillWeight = 76.53453!
        Me.Column13.HeaderText = "Qty Sold"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.FillWeight = 81.44789!
        Me.Column12.HeaderText = "Qty Returned"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.FillWeight = 71.06599!
        Me.Column14.HeaderText = "Qty Damaged"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "id"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column4
        '
        Me.Column4.HeaderText = "CPrice"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'frmPackingList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1799, 876)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.dtgrdItemList)
        Me.Controls.Add(Me.dtgrdPackingLists)
        Me.Name = "frmPackingList"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Packing Lists and Returns"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgrdPackingLists, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgrdItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.cntxtMenu.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtIssueNo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents dtgrdPackingLists As DataGridView
    Friend WithEvents txtTotalAmountIssued As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTotalReturns As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTotalDiscounts As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTotalExpenses As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtTotalBankDeposit As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents dtgrdItemList As DataGridView
    Friend WithEvents txtDebt As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents btnSearchItem As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents txtBarCode As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtCode As TextBox
    Friend WithEvents txtStockSize As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtPackSize As TextBox
    Friend WithEvents cmbSalesPersons As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtQtyDamaged As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtQtySold As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtQtyReturned As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtPacked As TextBox
    Friend WithEvents txtId As TextBox
    Friend WithEvents txtCreated As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtTotalDamages As TextBox
    Friend WithEvents cmbDescription As ComboBox
    Friend WithEvents txtTotalSales As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btnDeficit As Button
    Friend WithEvents Label24 As Label
    Friend WithEvents txtReturns As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtIssuedQty As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtTotalPreviousReturns As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtTotalAmountPacked As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents cntxtMenu As ContextMenuStrip
    Friend WithEvents mnRemove As ToolStripMenuItem
    Friend WithEvents btnChange As Button
    Friend WithEvents Label28 As Label
    Friend WithEvents txtCPrice As TextBox
    Friend WithEvents txtCostOfGoodsSold As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents btnEdit As ToolStripButton
    Friend WithEvents btnClear As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnApprove As ToolStripButton
    Friend WithEvents btnArchive As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnPrintReport As ToolStripButton
    Friend WithEvents btnCancel As ToolStripButton
    Friend WithEvents btnPrint As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnComplete As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnClearDebt As ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents btnArchiveAll As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents txtCompleted As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents txtIssued As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents txtApproved As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents txtCash As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents txtPrinted As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents txtDetailId As TextBox
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
End Class
