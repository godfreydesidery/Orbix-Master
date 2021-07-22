<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTillAdministration
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
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTillNo = New System.Windows.Forms.ComboBox()
        Me.txtComputerName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtFiscalPrinterPort = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnApplyFiscalPrinter = New System.Windows.Forms.Button()
        Me.txtFiscalPrinterPassword = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkEnableFiscalPrinter = New System.Windows.Forms.CheckBox()
        Me.txtFiscalPrinterOperatorCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnApplyPosPrinter = New System.Windows.Forms.Button()
        Me.chkEnablePosPrinter = New System.Windows.Forms.CheckBox()
        Me.txtPosPrinterLogicName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dtgrdTillList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.Panel3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dtgrdTillList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.SystemColors.Control
        Me.btnBack.BackgroundImage = Global.BackOffice.My.Resources.Resources.red_back_arrow
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.Location = New System.Drawing.Point(787, 513)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(100, 40)
        Me.btnBack.TabIndex = 5
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(77, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Till No"
        '
        'cmbTillNo
        '
        Me.cmbTillNo.Enabled = False
        Me.cmbTillNo.FormattingEnabled = True
        Me.cmbTillNo.Location = New System.Drawing.Point(131, 9)
        Me.cmbTillNo.Name = "cmbTillNo"
        Me.cmbTillNo.Size = New System.Drawing.Size(205, 24)
        Me.cmbTillNo.TabIndex = 7
        '
        'txtComputerName
        '
        Me.txtComputerName.Location = New System.Drawing.Point(129, 55)
        Me.txtComputerName.Name = "txtComputerName"
        Me.txtComputerName.Size = New System.Drawing.Size(370, 22)
        Me.txtComputerName.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Computer Name"
        '
        'btnSearch
        '
        Me.btnSearch.Enabled = False
        Me.btnSearch.Location = New System.Drawing.Point(402, 9)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(97, 40)
        Me.btnSearch.TabIndex = 10
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.cmbStatus)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.TabControl1)
        Me.Panel3.Controls.Add(Me.cmbTillNo)
        Me.Panel3.Controls.Add(Me.btnSearch)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.txtComputerName)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Location = New System.Drawing.Point(10, 50)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(533, 453)
        Me.Panel3.TabIndex = 11
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"", "ENABLED", "DISABLED"})
        Me.cmbStatus.Location = New System.Drawing.Point(131, 88)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(205, 24)
        Me.cmbStatus.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(75, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Status"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(16, 118)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(500, 320)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(492, 291)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Printers"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtFiscalPrinterPort)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.btnApplyFiscalPrinter)
        Me.Panel2.Controls.Add(Me.txtFiscalPrinterPassword)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.chkEnableFiscalPrinter)
        Me.Panel2.Controls.Add(Me.txtFiscalPrinterOperatorCode)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(251, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 279)
        Me.Panel2.TabIndex = 1
        '
        'txtFiscalPrinterPort
        '
        Me.txtFiscalPrinterPort.Location = New System.Drawing.Point(3, 153)
        Me.txtFiscalPrinterPort.Name = "txtFiscalPrinterPort"
        Me.txtFiscalPrinterPort.Size = New System.Drawing.Size(192, 22)
        Me.txtFiscalPrinterPort.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(2, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 17)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Port"
        '
        'btnApplyFiscalPrinter
        '
        Me.btnApplyFiscalPrinter.Location = New System.Drawing.Point(102, 223)
        Me.btnApplyFiscalPrinter.Name = "btnApplyFiscalPrinter"
        Me.btnApplyFiscalPrinter.Size = New System.Drawing.Size(81, 41)
        Me.btnApplyFiscalPrinter.TabIndex = 11
        Me.btnApplyFiscalPrinter.Text = "Apply"
        Me.btnApplyFiscalPrinter.UseVisualStyleBackColor = True
        '
        'txtFiscalPrinterPassword
        '
        Me.txtFiscalPrinterPassword.Location = New System.Drawing.Point(3, 106)
        Me.txtFiscalPrinterPassword.Name = "txtFiscalPrinterPassword"
        Me.txtFiscalPrinterPassword.Size = New System.Drawing.Size(192, 22)
        Me.txtFiscalPrinterPassword.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(2, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 17)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Operator Password"
        '
        'chkEnableFiscalPrinter
        '
        Me.chkEnableFiscalPrinter.AutoSize = True
        Me.chkEnableFiscalPrinter.Location = New System.Drawing.Point(6, 191)
        Me.chkEnableFiscalPrinter.Name = "chkEnableFiscalPrinter"
        Me.chkEnableFiscalPrinter.Size = New System.Drawing.Size(82, 21)
        Me.chkEnableFiscalPrinter.TabIndex = 6
        Me.chkEnableFiscalPrinter.Text = "Enabled"
        Me.chkEnableFiscalPrinter.UseVisualStyleBackColor = True
        '
        'txtFiscalPrinterOperatorCode
        '
        Me.txtFiscalPrinterOperatorCode.Location = New System.Drawing.Point(3, 59)
        Me.txtFiscalPrinterOperatorCode.Name = "txtFiscalPrinterOperatorCode"
        Me.txtFiscalPrinterOperatorCode.Size = New System.Drawing.Size(192, 22)
        Me.txtFiscalPrinterOperatorCode.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 17)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Operator Code"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 17)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Fiscal Printer"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnApplyPosPrinter)
        Me.Panel1.Controls.Add(Me.chkEnablePosPrinter)
        Me.Panel1.Controls.Add(Me.txtPosPrinterLogicName)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(9, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 279)
        Me.Panel1.TabIndex = 0
        '
        'btnApplyPosPrinter
        '
        Me.btnApplyPosPrinter.Location = New System.Drawing.Point(105, 223)
        Me.btnApplyPosPrinter.Name = "btnApplyPosPrinter"
        Me.btnApplyPosPrinter.Size = New System.Drawing.Size(72, 41)
        Me.btnApplyPosPrinter.TabIndex = 10
        Me.btnApplyPosPrinter.Text = "Apply"
        Me.btnApplyPosPrinter.UseVisualStyleBackColor = True
        '
        'chkEnablePosPrinter
        '
        Me.chkEnablePosPrinter.AutoSize = True
        Me.chkEnablePosPrinter.Location = New System.Drawing.Point(6, 129)
        Me.chkEnablePosPrinter.Name = "chkEnablePosPrinter"
        Me.chkEnablePosPrinter.Size = New System.Drawing.Size(82, 21)
        Me.chkEnablePosPrinter.TabIndex = 2
        Me.chkEnablePosPrinter.Text = "Enabled"
        Me.chkEnablePosPrinter.UseVisualStyleBackColor = True
        '
        'txtPosPrinterLogicName
        '
        Me.txtPosPrinterLogicName.Location = New System.Drawing.Point(3, 81)
        Me.txtPosPrinterLogicName.Name = "txtPosPrinterLogicName"
        Me.txtPosPrinterLogicName.Size = New System.Drawing.Size(192, 22)
        Me.txtPosPrinterLogicName.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 17)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Logic Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "POS Printer"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(492, 291)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Line Display"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dtgrdTillList
        '
        Me.dtgrdTillList.AllowUserToAddRows = False
        Me.dtgrdTillList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdTillList.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdTillList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdTillList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.dtgrdTillList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgrdTillList.Location = New System.Drawing.Point(551, 50)
        Me.dtgrdTillList.Name = "dtgrdTillList"
        Me.dtgrdTillList.ReadOnly = True
        Me.dtgrdTillList.RowTemplate.Height = 24
        Me.dtgrdTillList.Size = New System.Drawing.Size(336, 453)
        Me.dtgrdTillList.TabIndex = 12
        '
        'Column1
        '
        Me.Column1.HeaderText = "Till No"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Computer Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.ToolStripButton5, Me.ToolStripButton6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(896, 27)
        Me.ToolStrip1.TabIndex = 79
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
        'btnDelete
        '
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
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Enabled = False
        Me.ToolStripButton5.Image = Global.BackOffice.My.Resources.Resources.closed_padlock
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(24, 24)
        Me.ToolStripButton5.Text = "Block"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Enabled = False
        Me.ToolStripButton6.Image = Global.BackOffice.My.Resources.Resources.open_padlock
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(24, 24)
        Me.ToolStripButton6.Text = "Unblock"
        '
        'frmTillAdministration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 565)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.dtgrdTillList)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.btnBack)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTillAdministration"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Till Administration"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtgrdTillList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTillNo As System.Windows.Forms.ComboBox
    Friend WithEvents txtComputerName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnApplyFiscalPrinter As Button
    Friend WithEvents txtFiscalPrinterPassword As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents chkEnableFiscalPrinter As CheckBox
    Friend WithEvents txtFiscalPrinterOperatorCode As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnApplyPosPrinter As Button
    Friend WithEvents chkEnablePosPrinter As CheckBox
    Friend WithEvents txtPosPrinterLogicName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dtgrdTillList As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents txtFiscalPrinterPort As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents btnEdit As ToolStripButton
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripButton6 As ToolStripButton
End Class
