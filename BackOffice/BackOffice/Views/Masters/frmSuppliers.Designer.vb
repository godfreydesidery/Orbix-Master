<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSuppliers
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.txtContactName = New System.Windows.Forms.TextBox()
        Me.txtPostAddress = New System.Windows.Forms.TextBox()
        Me.txtPostCode = New System.Windows.Forms.TextBox()
        Me.txtPhysicalAdrress = New System.Windows.Forms.TextBox()
        Me.txtTIN = New System.Windows.Forms.TextBox()
        Me.txtVRN = New System.Windows.Forms.TextBox()
        Me.txtTelephone = New System.Windows.Forms.TextBox()
        Me.txtMobile = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.btnProductAndService = New System.Windows.Forms.Button()
        Me.txtBankAccountName = New System.Windows.Forms.TextBox()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.txtBankPostCode = New System.Windows.Forms.TextBox()
        Me.txtBankPostAddress = New System.Windows.Forms.TextBox()
        Me.txtBankAccountNo = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dtgrdSuppliers = New System.Windows.Forms.DataGridView()
        Me.colSupCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCompanyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colContactName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkDiscontinued = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtTermsOfContract = New System.Windows.Forms.TextBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.cmbName = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnBlock = New System.Windows.Forms.ToolStripButton()
        Me.btnUnblock = New System.Windows.Forms.ToolStripButton()
        CType(Me.dtgrdSuppliers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Supplier Code*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Company Name*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 17)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Contact Name*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(57, 221)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Address"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(44, 250)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 17)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Post Code"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1, 275)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 17)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Physical Address"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 463)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Bank Acc Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(-2, 489)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 17)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Bank Acc Address"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 517)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 17)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Bank Post Code"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(37, 543)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 17)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Bank Name"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(44, 306)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 17)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Telephone"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(68, 334)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 17)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Mobile"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(73, 366)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 17)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Email"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(85, 396)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 17)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Fax"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(82, 110)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 17)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "TIN*"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(75, 139)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 17)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "VRN*"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(123, 10)
        Me.txtCode.MaxLength = 50
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(173, 22)
        Me.txtCode.TabIndex = 27
        '
        'txtContactName
        '
        Me.txtContactName.Location = New System.Drawing.Point(123, 79)
        Me.txtContactName.MaxLength = 100
        Me.txtContactName.Name = "txtContactName"
        Me.txtContactName.Size = New System.Drawing.Size(279, 22)
        Me.txtContactName.TabIndex = 29
        '
        'txtPostAddress
        '
        Me.txtPostAddress.Location = New System.Drawing.Point(123, 221)
        Me.txtPostAddress.MaxLength = 100
        Me.txtPostAddress.Name = "txtPostAddress"
        Me.txtPostAddress.Size = New System.Drawing.Size(279, 22)
        Me.txtPostAddress.TabIndex = 30
        '
        'txtPostCode
        '
        Me.txtPostCode.Location = New System.Drawing.Point(123, 250)
        Me.txtPostCode.MaxLength = 100
        Me.txtPostCode.Name = "txtPostCode"
        Me.txtPostCode.Size = New System.Drawing.Size(279, 22)
        Me.txtPostCode.TabIndex = 31
        '
        'txtPhysicalAdrress
        '
        Me.txtPhysicalAdrress.Location = New System.Drawing.Point(123, 278)
        Me.txtPhysicalAdrress.MaxLength = 100
        Me.txtPhysicalAdrress.Name = "txtPhysicalAdrress"
        Me.txtPhysicalAdrress.Size = New System.Drawing.Size(279, 22)
        Me.txtPhysicalAdrress.TabIndex = 32
        '
        'txtTIN
        '
        Me.txtTIN.Location = New System.Drawing.Point(123, 107)
        Me.txtTIN.MaxLength = 50
        Me.txtTIN.Name = "txtTIN"
        Me.txtTIN.Size = New System.Drawing.Size(279, 22)
        Me.txtTIN.TabIndex = 33
        '
        'txtVRN
        '
        Me.txtVRN.Location = New System.Drawing.Point(123, 134)
        Me.txtVRN.MaxLength = 50
        Me.txtVRN.Name = "txtVRN"
        Me.txtVRN.Size = New System.Drawing.Size(279, 22)
        Me.txtVRN.TabIndex = 34
        '
        'txtTelephone
        '
        Me.txtTelephone.Location = New System.Drawing.Point(123, 306)
        Me.txtTelephone.MaxLength = 50
        Me.txtTelephone.Name = "txtTelephone"
        Me.txtTelephone.Size = New System.Drawing.Size(279, 22)
        Me.txtTelephone.TabIndex = 35
        '
        'txtMobile
        '
        Me.txtMobile.Location = New System.Drawing.Point(123, 335)
        Me.txtMobile.MaxLength = 50
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(279, 22)
        Me.txtMobile.TabIndex = 36
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(123, 363)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(279, 22)
        Me.txtEmail.TabIndex = 37
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(123, 391)
        Me.txtFax.MaxLength = 50
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(279, 22)
        Me.txtFax.TabIndex = 38
        '
        'btnProductAndService
        '
        Me.btnProductAndService.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnProductAndService.Enabled = False
        Me.btnProductAndService.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProductAndService.ForeColor = System.Drawing.Color.Black
        Me.btnProductAndService.Location = New System.Drawing.Point(299, 664)
        Me.btnProductAndService.Name = "btnProductAndService"
        Me.btnProductAndService.Size = New System.Drawing.Size(115, 43)
        Me.btnProductAndService.TabIndex = 53
        Me.btnProductAndService.Text = "Add/ Edit Products"
        Me.btnProductAndService.UseVisualStyleBackColor = False
        Me.btnProductAndService.Visible = False
        '
        'txtBankAccountName
        '
        Me.txtBankAccountName.Location = New System.Drawing.Point(123, 463)
        Me.txtBankAccountName.MaxLength = 50
        Me.txtBankAccountName.Name = "txtBankAccountName"
        Me.txtBankAccountName.Size = New System.Drawing.Size(279, 22)
        Me.txtBankAccountName.TabIndex = 41
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(123, 543)
        Me.txtBankName.MaxLength = 50
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(279, 22)
        Me.txtBankName.TabIndex = 43
        '
        'txtBankPostCode
        '
        Me.txtBankPostCode.Location = New System.Drawing.Point(123, 517)
        Me.txtBankPostCode.MaxLength = 100
        Me.txtBankPostCode.Name = "txtBankPostCode"
        Me.txtBankPostCode.Size = New System.Drawing.Size(279, 22)
        Me.txtBankPostCode.TabIndex = 44
        '
        'txtBankPostAddress
        '
        Me.txtBankPostAddress.Location = New System.Drawing.Point(123, 489)
        Me.txtBankPostAddress.MaxLength = 100
        Me.txtBankPostAddress.Name = "txtBankPostAddress"
        Me.txtBankPostAddress.Size = New System.Drawing.Size(279, 22)
        Me.txtBankPostAddress.TabIndex = 45
        '
        'txtBankAccountNo
        '
        Me.txtBankAccountNo.Location = New System.Drawing.Point(123, 569)
        Me.txtBankAccountNo.MaxLength = 50
        Me.txtBankAccountNo.Name = "txtBankAccountNo"
        Me.txtBankAccountNo.Size = New System.Drawing.Size(279, 22)
        Me.txtBankAccountNo.TabIndex = 47
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(29, 566)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 17)
        Me.Label17.TabIndex = 46
        Me.Label17.Text = "Bank Acc No"
        '
        'dtgrdSuppliers
        '
        Me.dtgrdSuppliers.AllowUserToAddRows = False
        Me.dtgrdSuppliers.AllowUserToDeleteRows = False
        Me.dtgrdSuppliers.AllowUserToOrderColumns = True
        Me.dtgrdSuppliers.AllowUserToResizeRows = False
        Me.dtgrdSuppliers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdSuppliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdSuppliers.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtgrdSuppliers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtgrdSuppliers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSupCode, Me.colCompanyName, Me.colContactName})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgrdSuppliers.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtgrdSuppliers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgrdSuppliers.Location = New System.Drawing.Point(431, 50)
        Me.dtgrdSuppliers.Name = "dtgrdSuppliers"
        Me.dtgrdSuppliers.ReadOnly = True
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dtgrdSuppliers.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgrdSuppliers.RowTemplate.Height = 24
        Me.dtgrdSuppliers.Size = New System.Drawing.Size(845, 657)
        Me.dtgrdSuppliers.TabIndex = 0
        '
        'colSupCode
        '
        Me.colSupCode.HeaderText = "Supplier Code"
        Me.colSupCode.Name = "colSupCode"
        Me.colSupCode.ReadOnly = True
        '
        'colCompanyName
        '
        Me.colCompanyName.HeaderText = "Company Name"
        Me.colCompanyName.Name = "colCompanyName"
        Me.colCompanyName.ReadOnly = True
        '
        'colContactName
        '
        Me.colContactName.HeaderText = "Contact Name"
        Me.colContactName.Name = "colContactName"
        Me.colContactName.ReadOnly = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(302, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 40)
        Me.btnSearch.TabIndex = 48
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(431, 30)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(197, 17)
        Me.Label18.TabIndex = 54
        Me.Label18.Text = "Select to view Supplier Details"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.chkDiscontinued)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.txtTermsOfContract)
        Me.Panel1.Controls.Add(Me.txtId)
        Me.Panel1.Controls.Add(Me.cmbName)
        Me.Panel1.Controls.Add(Me.txtVRN)
        Me.Panel1.Controls.Add(Me.txtPostAddress)
        Me.Panel1.Controls.Add(Me.txtContactName)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtFax)
        Me.Panel1.Controls.Add(Me.txtBankAccountNo)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtCode)
        Me.Panel1.Controls.Add(Me.txtEmail)
        Me.Panel1.Controls.Add(Me.txtTIN)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtMobile)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtTelephone)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtBankName)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtPhysicalAdrress)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtPostCode)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtBankAccountName)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtBankPostAddress)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtBankPostCode)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(10, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(415, 611)
        Me.Panel1.TabIndex = 57
        '
        'chkDiscontinued
        '
        Me.chkDiscontinued.AutoSize = True
        Me.chkDiscontinued.Location = New System.Drawing.Point(123, 419)
        Me.chkDiscontinued.Name = "chkDiscontinued"
        Me.chkDiscontinued.Size = New System.Drawing.Size(112, 21)
        Me.chkDiscontinued.TabIndex = 111
        Me.chkDiscontinued.Text = "Discontinued"
        Me.chkDiscontinued.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(67, 162)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 17)
        Me.Label19.TabIndex = 110
        Me.Label19.Text = "Terms"
        '
        'txtTermsOfContract
        '
        Me.txtTermsOfContract.Location = New System.Drawing.Point(123, 162)
        Me.txtTermsOfContract.MaxLength = 50
        Me.txtTermsOfContract.Multiline = True
        Me.txtTermsOfContract.Name = "txtTermsOfContract"
        Me.txtTermsOfContract.Size = New System.Drawing.Size(279, 53)
        Me.txtTermsOfContract.TabIndex = 109
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(4, 30)
        Me.txtId.MaxLength = 50
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(37, 22)
        Me.txtId.TabIndex = 77
        Me.txtId.Visible = False
        '
        'cmbName
        '
        Me.cmbName.FormattingEnabled = True
        Me.cmbName.Location = New System.Drawing.Point(123, 48)
        Me.cmbName.Name = "cmbName"
        Me.cmbName.Size = New System.Drawing.Size(279, 24)
        Me.cmbName.TabIndex = 108
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnClear, Me.btnDelete, Me.btnSave, Me.btnBlock, Me.btnUnblock})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1286, 27)
        Me.ToolStrip1.TabIndex = 76
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
        Me.btnDelete.Image = Global.BackOffice.My.Resources.Resources.trash
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(77, 24)
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.ToolTipText = "Deletes an existing record"
        Me.btnDelete.Visible = False
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
        'btnBlock
        '
        Me.btnBlock.Enabled = False
        Me.btnBlock.Image = Global.BackOffice.My.Resources.Resources.closed_padlock
        Me.btnBlock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBlock.Name = "btnBlock"
        Me.btnBlock.Size = New System.Drawing.Size(69, 24)
        Me.btnBlock.Text = "Block"
        Me.btnBlock.ToolTipText = "Blocks a supplier, a blocked supplier can not be used"
        '
        'btnUnblock
        '
        Me.btnUnblock.Enabled = False
        Me.btnUnblock.Image = Global.BackOffice.My.Resources.Resources.open_padlock
        Me.btnUnblock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUnblock.Name = "btnUnblock"
        Me.btnUnblock.Size = New System.Drawing.Size(87, 24)
        Me.btnUnblock.Text = "Unblock"
        Me.btnUnblock.ToolTipText = "Unblocks a blocked supplier"
        '
        'frmSuppliers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1286, 717)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.dtgrdSuppliers)
        Me.Controls.Add(Me.btnProductAndService)
        Me.MinimizeBox = False
        Me.Name = "frmSuppliers"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Suppliers"
        CType(Me.dtgrdSuppliers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtCode As TextBox
    Friend WithEvents txtContactName As TextBox
    Friend WithEvents txtPostAddress As TextBox
    Friend WithEvents txtPostCode As TextBox
    Friend WithEvents txtPhysicalAdrress As TextBox
    Friend WithEvents txtTIN As TextBox
    Friend WithEvents txtVRN As TextBox
    Friend WithEvents txtTelephone As TextBox
    Friend WithEvents txtMobile As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtFax As TextBox
    Friend WithEvents txtBankAccountName As TextBox
    Friend WithEvents txtBankName As TextBox
    Friend WithEvents txtBankPostCode As TextBox
    Friend WithEvents txtBankPostAddress As TextBox
    Friend WithEvents dtgrdSuppliers As DataGridView
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtBankAccountNo As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents btnProductAndService As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents colSupCode As DataGridViewTextBoxColumn
    Friend WithEvents colCompanyName As DataGridViewTextBoxColumn
    Friend WithEvents colContactName As DataGridViewTextBoxColumn
    Friend WithEvents cmbName As ComboBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents btnEdit As ToolStripButton
    Friend WithEvents btnClear As ToolStripButton
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnBlock As ToolStripButton
    Friend WithEvents btnUnblock As ToolStripButton
    Friend WithEvents txtId As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtTermsOfContract As TextBox
    Friend WithEvents chkDiscontinued As CheckBox
End Class
