<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCustomerClaim
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomerClaim))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtSettlementDate = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtClaimDate = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtClaimNo = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtOther = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtReceivedBy = New System.Windows.Forms.TextBox()
        Me.txtReturnedBy = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.txtIssueNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtClientAddress = New System.Windows.Forms.TextBox()
        Me.txtClientPhone = New System.Windows.Forms.TextBox()
        Me.txtClientName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtClaimId = New System.Windows.Forms.TextBox()
        Me.cmbClaimType = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtClaimRemarks = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtClaimReason = New System.Windows.Forms.TextBox()
        Me.cmbClaimDescription = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtClaimQty = New System.Windows.Forms.TextBox()
        Me.btnClaimAdd = New System.Windows.Forms.Button()
        Me.btnClaimReset = New System.Windows.Forms.Button()
        Me.btnClaimSearchItem = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtClaimBarCode = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtClaimItemCode = New System.Windows.Forms.TextBox()
        Me.txtClaimPrice = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dtgrdClaimDetails = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgrdClaimReplacements = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtReplacementId = New System.Windows.Forms.TextBox()
        Me.cmbReplacementDescription = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtReplacementQty = New System.Windows.Forms.TextBox()
        Me.btnReplacementAdd = New System.Windows.Forms.Button()
        Me.btnReplacementReset = New System.Windows.Forms.Button()
        Me.btnReplacementSearch = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtReplacementBarcode = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtReplacementItemCode = New System.Windows.Forms.TextBox()
        Me.txtreplacementPrice = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.dtgrdClaimList = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnCancel = New System.Windows.Forms.ToolStripButton()
        Me.btnApprove = New System.Windows.Forms.ToolStripButton()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.btnComplete = New System.Windows.Forms.ToolStripButton()
        Me.btnArchive = New System.Windows.Forms.ToolStripButton()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dtgrdClaimDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgrdClaimReplacements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.dtgrdClaimList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txtSettlementDate)
        Me.Panel1.Controls.Add(Me.Label30)
        Me.Panel1.Controls.Add(Me.txtId)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtClaimDate)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtStatus)
        Me.Panel1.Controls.Add(Me.txtClaimNo)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(10, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(698, 247)
        Me.Panel1.TabIndex = 0
        '
        'txtSettlementDate
        '
        Me.txtSettlementDate.Location = New System.Drawing.Point(88, 60)
        Me.txtSettlementDate.Name = "txtSettlementDate"
        Me.txtSettlementDate.ReadOnly = True
        Me.txtSettlementDate.Size = New System.Drawing.Size(115, 22)
        Me.txtSettlementDate.TabIndex = 114
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(3, 58)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(78, 17)
        Me.Label30.TabIndex = 113
        Me.Label30.Text = "Settle Date"
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(-12, -2)
        Me.txtId.MaxLength = 50
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(34, 22)
        Me.txtId.TabIndex = 112
        Me.txtId.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(209, 4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(110, 50)
        Me.btnSearch.TabIndex = 13
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtClaimDate
        '
        Me.txtClaimDate.Location = New System.Drawing.Point(88, 32)
        Me.txtClaimDate.Name = "txtClaimDate"
        Me.txtClaimDate.ReadOnly = True
        Me.txtClaimDate.Size = New System.Drawing.Size(115, 22)
        Me.txtClaimDate.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Claim Date"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(88, 88)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(115, 22)
        Me.txtStatus.TabIndex = 10
        '
        'txtClaimNo
        '
        Me.txtClaimNo.Location = New System.Drawing.Point(87, 4)
        Me.txtClaimNo.Name = "txtClaimNo"
        Me.txtClaimNo.Size = New System.Drawing.Size(116, 22)
        Me.txtClaimNo.TabIndex = 9
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtOther)
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Controls.Add(Me.txtReceivedBy)
        Me.Panel3.Controls.Add(Me.txtReturnedBy)
        Me.Panel3.Controls.Add(Me.Label28)
        Me.Panel3.Controls.Add(Me.Label29)
        Me.Panel3.Controls.Add(Me.txtInvoiceNo)
        Me.Panel3.Controls.Add(Me.txtIssueNo)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Location = New System.Drawing.Point(4, 120)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(652, 120)
        Me.Panel3.TabIndex = 8
        '
        'txtOther
        '
        Me.txtOther.Location = New System.Drawing.Point(80, 83)
        Me.txtOther.Name = "txtOther"
        Me.txtOther.Size = New System.Drawing.Size(244, 22)
        Me.txtOther.TabIndex = 14
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(33, 86)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(44, 17)
        Me.Label31.TabIndex = 13
        Me.Label31.Text = "Other"
        '
        'txtReceivedBy
        '
        Me.txtReceivedBy.Location = New System.Drawing.Point(320, 48)
        Me.txtReceivedBy.Name = "txtReceivedBy"
        Me.txtReceivedBy.Size = New System.Drawing.Size(319, 22)
        Me.txtReceivedBy.TabIndex = 12
        '
        'txtReturnedBy
        '
        Me.txtReturnedBy.Location = New System.Drawing.Point(320, 20)
        Me.txtReturnedBy.Name = "txtReturnedBy"
        Me.txtReturnedBy.Size = New System.Drawing.Size(319, 22)
        Me.txtReturnedBy.TabIndex = 11
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(228, 53)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(86, 17)
        Me.Label28.TabIndex = 9
        Me.Label28.Text = "Received by"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(228, 23)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(86, 17)
        Me.Label29.TabIndex = 10
        Me.Label29.Text = "Returned by"
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Location = New System.Drawing.Point(80, 48)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(118, 22)
        Me.txtInvoiceNo.TabIndex = 8
        '
        'txtIssueNo
        '
        Me.txtIssueNo.Location = New System.Drawing.Point(80, 20)
        Me.txtIssueNo.Name = "txtIssueNo"
        Me.txtIssueNo.Size = New System.Drawing.Size(118, 22)
        Me.txtIssueNo.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(142, 17)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Purchase Information"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 17)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Issue No"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 17)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Invoice No"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtClientAddress)
        Me.Panel2.Controls.Add(Me.txtClientPhone)
        Me.Panel2.Controls.Add(Me.txtClientName)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(325, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(331, 111)
        Me.Panel2.TabIndex = 7
        '
        'txtClientAddress
        '
        Me.txtClientAddress.Location = New System.Drawing.Point(69, 79)
        Me.txtClientAddress.Name = "txtClientAddress"
        Me.txtClientAddress.Size = New System.Drawing.Size(249, 22)
        Me.txtClientAddress.TabIndex = 9
        '
        'txtClientPhone
        '
        Me.txtClientPhone.Location = New System.Drawing.Point(69, 51)
        Me.txtClientPhone.Name = "txtClientPhone"
        Me.txtClientPhone.Size = New System.Drawing.Size(249, 22)
        Me.txtClientPhone.TabIndex = 8
        '
        'txtClientName
        '
        Me.txtClientName.Location = New System.Drawing.Point(69, 23)
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.Size = New System.Drawing.Size(249, 22)
        Me.txtClientName.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 17)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Client Information"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Phone"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Address"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 17)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Claim No"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.txtClaimId)
        Me.Panel4.Controls.Add(Me.cmbClaimType)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.txtClaimRemarks)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.txtClaimReason)
        Me.Panel4.Controls.Add(Me.cmbClaimDescription)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Controls.Add(Me.txtClaimQty)
        Me.Panel4.Controls.Add(Me.btnClaimAdd)
        Me.Panel4.Controls.Add(Me.btnClaimReset)
        Me.Panel4.Controls.Add(Me.btnClaimSearchItem)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.txtClaimBarCode)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Controls.Add(Me.txtClaimItemCode)
        Me.Panel4.Controls.Add(Me.txtClaimPrice)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Location = New System.Drawing.Point(6, 328)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(460, 234)
        Me.Panel4.TabIndex = 95
        '
        'txtClaimId
        '
        Me.txtClaimId.Location = New System.Drawing.Point(332, 8)
        Me.txtClaimId.MaxLength = 50
        Me.txtClaimId.Name = "txtClaimId"
        Me.txtClaimId.Size = New System.Drawing.Size(34, 22)
        Me.txtClaimId.TabIndex = 113
        Me.txtClaimId.Visible = False
        '
        'cmbClaimType
        '
        Me.cmbClaimType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClaimType.FormattingEnabled = True
        Me.cmbClaimType.Items.AddRange(New Object() {"", "REPLACEMENT"})
        Me.cmbClaimType.Location = New System.Drawing.Point(87, 202)
        Me.cmbClaimType.Name = "cmbClaimType"
        Me.cmbClaimType.Size = New System.Drawing.Size(348, 24)
        Me.cmbClaimType.TabIndex = 106
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(4, 202)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 17)
        Me.Label17.TabIndex = 105
        Me.Label17.Text = "Claim Type"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(18, 174)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 17)
        Me.Label15.TabIndex = 103
        Me.Label15.Text = "Remarks"
        '
        'txtClaimRemarks
        '
        Me.txtClaimRemarks.Location = New System.Drawing.Point(87, 174)
        Me.txtClaimRemarks.MaxLength = 50
        Me.txtClaimRemarks.Name = "txtClaimRemarks"
        Me.txtClaimRemarks.Size = New System.Drawing.Size(348, 22)
        Me.txtClaimRemarks.TabIndex = 102
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(25, 146)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 17)
        Me.Label14.TabIndex = 101
        Me.Label14.Text = "Reason"
        '
        'txtClaimReason
        '
        Me.txtClaimReason.Location = New System.Drawing.Point(87, 146)
        Me.txtClaimReason.MaxLength = 50
        Me.txtClaimReason.Name = "txtClaimReason"
        Me.txtClaimReason.Size = New System.Drawing.Size(348, 22)
        Me.txtClaimReason.TabIndex = 100
        '
        'cmbClaimDescription
        '
        Me.cmbClaimDescription.FormattingEnabled = True
        Me.cmbClaimDescription.Location = New System.Drawing.Point(88, 60)
        Me.cmbClaimDescription.Name = "cmbClaimDescription"
        Me.cmbClaimDescription.Size = New System.Drawing.Size(347, 24)
        Me.cmbClaimDescription.TabIndex = 99
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(51, 118)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(30, 17)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Qty"
        '
        'txtClaimQty
        '
        Me.txtClaimQty.Location = New System.Drawing.Point(87, 118)
        Me.txtClaimQty.MaxLength = 50
        Me.txtClaimQty.Name = "txtClaimQty"
        Me.txtClaimQty.Size = New System.Drawing.Size(115, 22)
        Me.txtClaimQty.TabIndex = 56
        '
        'btnClaimAdd
        '
        Me.btnClaimAdd.Enabled = False
        Me.btnClaimAdd.Location = New System.Drawing.Point(208, 90)
        Me.btnClaimAdd.Name = "btnClaimAdd"
        Me.btnClaimAdd.Size = New System.Drawing.Size(111, 50)
        Me.btnClaimAdd.TabIndex = 53
        Me.btnClaimAdd.Text = "Add/Update"
        Me.btnClaimAdd.UseVisualStyleBackColor = True
        '
        'btnClaimReset
        '
        Me.btnClaimReset.Location = New System.Drawing.Point(325, 90)
        Me.btnClaimReset.Name = "btnClaimReset"
        Me.btnClaimReset.Size = New System.Drawing.Size(110, 50)
        Me.btnClaimReset.TabIndex = 54
        Me.btnClaimReset.Text = "Reset"
        Me.btnClaimReset.UseVisualStyleBackColor = True
        '
        'btnClaimSearchItem
        '
        Me.btnClaimSearchItem.Location = New System.Drawing.Point(208, 4)
        Me.btnClaimSearchItem.Name = "btnClaimSearchItem"
        Me.btnClaimSearchItem.Size = New System.Drawing.Size(111, 50)
        Me.btnClaimSearchItem.TabIndex = 51
        Me.btnClaimSearchItem.Text = "Search"
        Me.btnClaimSearchItem.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 17)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Item Code"
        '
        'txtClaimBarCode
        '
        Me.txtClaimBarCode.Location = New System.Drawing.Point(87, 4)
        Me.txtClaimBarCode.MaxLength = 50
        Me.txtClaimBarCode.Name = "txtClaimBarCode"
        Me.txtClaimBarCode.Size = New System.Drawing.Size(115, 22)
        Me.txtClaimBarCode.TabIndex = 50
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 60)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 17)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Description"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(21, 4)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 17)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Barcode"
        '
        'txtClaimItemCode
        '
        Me.txtClaimItemCode.Location = New System.Drawing.Point(87, 32)
        Me.txtClaimItemCode.MaxLength = 50
        Me.txtClaimItemCode.Name = "txtClaimItemCode"
        Me.txtClaimItemCode.Size = New System.Drawing.Size(115, 22)
        Me.txtClaimItemCode.TabIndex = 39
        '
        'txtClaimPrice
        '
        Me.txtClaimPrice.Location = New System.Drawing.Point(88, 90)
        Me.txtClaimPrice.MaxLength = 50
        Me.txtClaimPrice.Name = "txtClaimPrice"
        Me.txtClaimPrice.ReadOnly = True
        Me.txtClaimPrice.Size = New System.Drawing.Size(115, 22)
        Me.txtClaimPrice.TabIndex = 47
        Me.txtClaimPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(41, 90)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 17)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "Price"
        '
        'dtgrdClaimDetails
        '
        Me.dtgrdClaimDetails.AllowUserToAddRows = False
        Me.dtgrdClaimDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdClaimDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdClaimDetails.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdClaimDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdClaimDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column9, Me.Column5, Me.Column8, Me.Column6, Me.Column7})
        Me.dtgrdClaimDetails.Location = New System.Drawing.Point(6, 585)
        Me.dtgrdClaimDetails.Name = "dtgrdClaimDetails"
        Me.dtgrdClaimDetails.ReadOnly = True
        Me.dtgrdClaimDetails.RowTemplate.Height = 24
        Me.dtgrdClaimDetails.Size = New System.Drawing.Size(780, 154)
        Me.dtgrdClaimDetails.TabIndex = 96
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column4.HeaderText = "Price"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column9
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column9.HeaderText = "Amount"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Claim Type"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "Reason"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Remarks"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Sn"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        '
        'dtgrdClaimReplacements
        '
        Me.dtgrdClaimReplacements.AllowUserToAddRows = False
        Me.dtgrdClaimReplacements.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdClaimReplacements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdClaimReplacements.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdClaimReplacements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdClaimReplacements.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.Column10, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.dtgrdClaimReplacements.Location = New System.Drawing.Point(792, 491)
        Me.dtgrdClaimReplacements.Name = "dtgrdClaimReplacements"
        Me.dtgrdClaimReplacements.ReadOnly = True
        Me.dtgrdClaimReplacements.RowTemplate.Height = 24
        Me.dtgrdClaimReplacements.Size = New System.Drawing.Size(572, 248)
        Me.dtgrdClaimReplacements.TabIndex = 101
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
        'Column10
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column10.HeaderText = "Price"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn7.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Sn"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.txtReplacementId)
        Me.Panel5.Controls.Add(Me.cmbReplacementDescription)
        Me.Panel5.Controls.Add(Me.Label22)
        Me.Panel5.Controls.Add(Me.txtReplacementQty)
        Me.Panel5.Controls.Add(Me.btnReplacementAdd)
        Me.Panel5.Controls.Add(Me.btnReplacementReset)
        Me.Panel5.Controls.Add(Me.btnReplacementSearch)
        Me.Panel5.Controls.Add(Me.Label23)
        Me.Panel5.Controls.Add(Me.txtReplacementBarcode)
        Me.Panel5.Controls.Add(Me.Label24)
        Me.Panel5.Controls.Add(Me.Label25)
        Me.Panel5.Controls.Add(Me.txtReplacementItemCode)
        Me.Panel5.Controls.Add(Me.txtreplacementPrice)
        Me.Panel5.Controls.Add(Me.Label26)
        Me.Panel5.Location = New System.Drawing.Point(792, 308)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(456, 165)
        Me.Panel5.TabIndex = 102
        '
        'txtReplacementId
        '
        Me.txtReplacementId.Location = New System.Drawing.Point(334, 18)
        Me.txtReplacementId.MaxLength = 50
        Me.txtReplacementId.Name = "txtReplacementId"
        Me.txtReplacementId.Size = New System.Drawing.Size(34, 22)
        Me.txtReplacementId.TabIndex = 113
        Me.txtReplacementId.Visible = False
        '
        'cmbReplacementDescription
        '
        Me.cmbReplacementDescription.FormattingEnabled = True
        Me.cmbReplacementDescription.Location = New System.Drawing.Point(88, 60)
        Me.cmbReplacementDescription.Name = "cmbReplacementDescription"
        Me.cmbReplacementDescription.Size = New System.Drawing.Size(356, 24)
        Me.cmbReplacementDescription.TabIndex = 99
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(51, 118)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(30, 17)
        Me.Label22.TabIndex = 55
        Me.Label22.Text = "Qty"
        '
        'txtReplacementQty
        '
        Me.txtReplacementQty.Location = New System.Drawing.Point(87, 118)
        Me.txtReplacementQty.MaxLength = 50
        Me.txtReplacementQty.Name = "txtReplacementQty"
        Me.txtReplacementQty.Size = New System.Drawing.Size(115, 22)
        Me.txtReplacementQty.TabIndex = 56
        '
        'btnReplacementAdd
        '
        Me.btnReplacementAdd.Enabled = False
        Me.btnReplacementAdd.Location = New System.Drawing.Point(208, 90)
        Me.btnReplacementAdd.Name = "btnReplacementAdd"
        Me.btnReplacementAdd.Size = New System.Drawing.Size(120, 50)
        Me.btnReplacementAdd.TabIndex = 53
        Me.btnReplacementAdd.Text = "Add/Update"
        Me.btnReplacementAdd.UseVisualStyleBackColor = True
        '
        'btnReplacementReset
        '
        Me.btnReplacementReset.Location = New System.Drawing.Point(334, 90)
        Me.btnReplacementReset.Name = "btnReplacementReset"
        Me.btnReplacementReset.Size = New System.Drawing.Size(110, 50)
        Me.btnReplacementReset.TabIndex = 54
        Me.btnReplacementReset.Text = "Reset"
        Me.btnReplacementReset.UseVisualStyleBackColor = True
        '
        'btnReplacementSearch
        '
        Me.btnReplacementSearch.Location = New System.Drawing.Point(208, 4)
        Me.btnReplacementSearch.Name = "btnReplacementSearch"
        Me.btnReplacementSearch.Size = New System.Drawing.Size(120, 50)
        Me.btnReplacementSearch.TabIndex = 51
        Me.btnReplacementSearch.Text = "Search"
        Me.btnReplacementSearch.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(10, 32)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(71, 17)
        Me.Label23.TabIndex = 37
        Me.Label23.Text = "Item Code"
        '
        'txtReplacementBarcode
        '
        Me.txtReplacementBarcode.Location = New System.Drawing.Point(87, 4)
        Me.txtReplacementBarcode.MaxLength = 50
        Me.txtReplacementBarcode.Name = "txtReplacementBarcode"
        Me.txtReplacementBarcode.Size = New System.Drawing.Size(115, 22)
        Me.txtReplacementBarcode.TabIndex = 50
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(3, 60)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(79, 17)
        Me.Label24.TabIndex = 38
        Me.Label24.Text = "Description"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(21, 4)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 17)
        Me.Label25.TabIndex = 49
        Me.Label25.Text = "Barcode"
        '
        'txtReplacementItemCode
        '
        Me.txtReplacementItemCode.Location = New System.Drawing.Point(87, 32)
        Me.txtReplacementItemCode.MaxLength = 50
        Me.txtReplacementItemCode.Name = "txtReplacementItemCode"
        Me.txtReplacementItemCode.Size = New System.Drawing.Size(115, 22)
        Me.txtReplacementItemCode.TabIndex = 39
        '
        'txtreplacementPrice
        '
        Me.txtreplacementPrice.Location = New System.Drawing.Point(88, 90)
        Me.txtreplacementPrice.MaxLength = 50
        Me.txtreplacementPrice.Name = "txtreplacementPrice"
        Me.txtreplacementPrice.ReadOnly = True
        Me.txtreplacementPrice.Size = New System.Drawing.Size(115, 22)
        Me.txtreplacementPrice.TabIndex = 47
        Me.txtreplacementPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(41, 90)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(40, 17)
        Me.Label26.TabIndex = 45
        Me.Label26.Text = "Price"
        '
        'dtgrdClaimList
        '
        Me.dtgrdClaimList.AllowUserToAddRows = False
        Me.dtgrdClaimList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdClaimList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdClaimList.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdClaimList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdClaimList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.dtgrdClaimList.Location = New System.Drawing.Point(792, 50)
        Me.dtgrdClaimList.Name = "dtgrdClaimList"
        Me.dtgrdClaimList.RowTemplate.Height = 24
        Me.dtgrdClaimList.Size = New System.Drawing.Size(572, 223)
        Me.dtgrdClaimList.TabIndex = 103
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Claim No"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 308)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(152, 17)
        Me.Label11.TabIndex = 104
        Me.Label11.Text = "Select Product to claim"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(9, 565)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(116, 17)
        Me.Label20.TabIndex = 105
        Me.Label20.Text = "Products to claim"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(789, 280)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(260, 17)
        Me.Label21.TabIndex = 106
        Me.Label21.Text = "Select Products to issue as replacments"
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(789, 471)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(146, 17)
        Me.Label27.TabIndex = 107
        Me.Label27.Text = "Replacements (if any)"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnClear, Me.btnSave, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.ToolStripSeparator3, Me.ToolStripSeparator4, Me.btnCancel, Me.btnApprove, Me.btnPrint, Me.btnComplete, Me.ToolStripSeparator5, Me.btnArchive})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1376, 27)
        Me.ToolStrip1.TabIndex = 114
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 27)
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
        Me.btnPrint.Size = New System.Drawing.Size(63, 24)
        Me.btnPrint.Text = "Print"
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
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackgroundImage = Global.BackOffice.My.Resources.Resources.red_back_arrow
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.Location = New System.Drawing.Point(1264, 745)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(100, 40)
        Me.btnBack.TabIndex = 112
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'frmCustomerClaim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1376, 796)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dtgrdClaimList)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.dtgrdClaimReplacements)
        Me.Controls.Add(Me.dtgrdClaimDetails)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmCustomerClaim"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Client Claims"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.dtgrdClaimDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgrdClaimReplacements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.dtgrdClaimList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtClientAddress As TextBox
    Friend WithEvents txtClientPhone As TextBox
    Friend WithEvents txtClientName As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtInvoiceNo As TextBox
    Friend WithEvents txtIssueNo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents txtClaimNo As TextBox
    Friend WithEvents txtClaimDate As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents cmbClaimDescription As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtClaimQty As TextBox
    Friend WithEvents btnClaimAdd As Button
    Friend WithEvents btnClaimReset As Button
    Friend WithEvents btnClaimSearchItem As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents txtClaimBarCode As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtClaimItemCode As TextBox
    Friend WithEvents txtClaimPrice As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtClaimRemarks As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtClaimReason As TextBox
    Friend WithEvents cmbClaimType As ComboBox
    Friend WithEvents dtgrdClaimDetails As DataGridView
    Friend WithEvents dtgrdClaimReplacements As DataGridView
    Friend WithEvents Panel5 As Panel
    Friend WithEvents cmbReplacementDescription As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtReplacementQty As TextBox
    Friend WithEvents btnReplacementAdd As Button
    Friend WithEvents btnReplacementReset As Button
    Friend WithEvents btnReplacementSearch As Button
    Friend WithEvents Label23 As Label
    Friend WithEvents txtReplacementBarcode As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents txtReplacementItemCode As TextBox
    Friend WithEvents txtreplacementPrice As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents dtgrdClaimList As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents Label11 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents txtReceivedBy As TextBox
    Friend WithEvents txtReturnedBy As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents txtId As TextBox
    Friend WithEvents txtSettlementDate As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents txtOther As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents txtClaimId As TextBox
    Friend WithEvents txtReplacementId As TextBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
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
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
End Class
