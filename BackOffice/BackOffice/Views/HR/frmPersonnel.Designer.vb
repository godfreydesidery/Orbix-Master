<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPersonnel
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.dtgrdList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtTelephone = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtSecondName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtRollNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRegNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dtgrdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnClear, Me.btnDelete, Me.btnSave})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1364, 27)
        Me.ToolStrip1.TabIndex = 80
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
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackColor = System.Drawing.SystemColors.Control
        Me.btnBack.BackgroundImage = Global.BackOffice.My.Resources.Resources.red_back_arrow
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.Location = New System.Drawing.Point(1253, 599)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(100, 40)
        Me.btnBack.TabIndex = 79
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'dtgrdList
        '
        Me.dtgrdList.AllowUserToAddRows = False
        Me.dtgrdList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdList.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgrdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column7, Me.Column6})
        Me.dtgrdList.Location = New System.Drawing.Point(433, 40)
        Me.dtgrdList.Name = "dtgrdList"
        Me.dtgrdList.ReadOnly = True
        Me.dtgrdList.RowTemplate.Height = 24
        Me.dtgrdList.Size = New System.Drawing.Size(920, 553)
        Me.dtgrdList.TabIndex = 78
        '
        'Column1
        '
        Me.Column1.FillWeight = 78.24103!
        Me.Column1.HeaderText = "Reg No"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.FillWeight = 69.06461!
        Me.Column2.HeaderText = "Roll No"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.FillWeight = 131.9797!
        Me.Column7.HeaderText = "Name"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.FillWeight = 120.7147!
        Me.Column6.HeaderText = "Contacts"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtRegNo)
        Me.Panel1.Controls.Add(Me.chkActive)
        Me.Panel1.Controls.Add(Me.txtId)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtEmail)
        Me.Panel1.Controls.Add(Me.txtTelephone)
        Me.Panel1.Controls.Add(Me.txtAddress)
        Me.Panel1.Controls.Add(Me.txtLastName)
        Me.Panel1.Controls.Add(Me.txtSecondName)
        Me.Panel1.Controls.Add(Me.txtFirstName)
        Me.Panel1.Controls.Add(Me.txtRollNo)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(10, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(417, 281)
        Me.Panel1.TabIndex = 77
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(125, 252)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(68, 21)
        Me.chkActive.TabIndex = 46
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(3, 4)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(41, 22)
        Me.txtId.TabIndex = 19
        Me.txtId.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(307, 10)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 35)
        Me.btnSearch.TabIndex = 16
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(125, 224)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(282, 22)
        Me.txtEmail.TabIndex = 14
        '
        'txtTelephone
        '
        Me.txtTelephone.Location = New System.Drawing.Point(125, 194)
        Me.txtTelephone.Name = "txtTelephone"
        Me.txtTelephone.Size = New System.Drawing.Size(282, 22)
        Me.txtTelephone.TabIndex = 13
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(125, 166)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(282, 22)
        Me.txtAddress.TabIndex = 12
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(125, 121)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(282, 22)
        Me.txtLastName.TabIndex = 11
        '
        'txtSecondName
        '
        Me.txtSecondName.Location = New System.Drawing.Point(125, 93)
        Me.txtSecondName.Name = "txtSecondName"
        Me.txtSecondName.Size = New System.Drawing.Size(282, 22)
        Me.txtSecondName.TabIndex = 10
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(125, 66)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(282, 22)
        Me.txtFirstName.TabIndex = 9
        '
        'txtRollNo
        '
        Me.txtRollNo.Location = New System.Drawing.Point(125, 10)
        Me.txtRollNo.Name = "txtRollNo"
        Me.txtRollNo.Size = New System.Drawing.Size(156, 22)
        Me.txtRollNo.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(77, 227)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 17)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Email"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(65, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Roll No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "First Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(46, 193)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 17)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Telephone"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Second Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(59, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Address"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Last Name"
        '
        'txtRegNo
        '
        Me.txtRegNo.Location = New System.Drawing.Point(125, 38)
        Me.txtRegNo.Name = "txtRegNo"
        Me.txtRegNo.ReadOnly = True
        Me.txtRegNo.Size = New System.Drawing.Size(156, 22)
        Me.txtRegNo.TabIndex = 47
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(65, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 17)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "Reg No"
        '
        'frmPersonnel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1364, 651)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.dtgrdList)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmPersonnel"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Personnel Enrollment"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dtgrdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents btnEdit As ToolStripButton
    Friend WithEvents btnClear As ToolStripButton
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnBack As Button
    Friend WithEvents dtgrdList As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtId As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtTelephone As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtSecondName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtRollNo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtRegNo As TextBox
End Class
