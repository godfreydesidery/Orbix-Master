<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoiceBook
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSearchVendor = New System.Windows.Forms.Button()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtVendor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlInvoice = New System.Windows.Forms.Panel()
        Me.txtInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSearchInvoice = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAmountDue = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAmountPayed = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtInvoiceTotal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlAmount = New System.Windows.Forms.Panel()
        Me.btnPay = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAmountToPay = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtgrdInvoices = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.txtTotalInvoices = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtTotalPaid = New System.Windows.Forms.TextBox()
        Me.txtTotalDue = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.pnlInvoice.SuspendLayout()
        Me.pnlAmount.SuspendLayout()
        CType(Me.dtgrdInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnSearchVendor)
        Me.Panel1.Controls.Add(Me.txtCode)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtVendor)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(417, 110)
        Me.Panel1.TabIndex = 0
        '
        'btnSearchVendor
        '
        Me.btnSearchVendor.Location = New System.Drawing.Point(258, 53)
        Me.btnSearchVendor.Name = "btnSearchVendor"
        Me.btnSearchVendor.Size = New System.Drawing.Size(115, 35)
        Me.btnSearchVendor.TabIndex = 4
        Me.btnSearchVendor.Text = "Search"
        Me.btnSearchVendor.UseVisualStyleBackColor = True
        '
        'txtCode
        '
        Me.txtCode.Enabled = False
        Me.txtCode.Location = New System.Drawing.Point(99, 59)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(140, 22)
        Me.txtCode.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Code"
        '
        'txtVendor
        '
        Me.txtVendor.Location = New System.Drawing.Point(98, 19)
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Size = New System.Drawing.Size(296, 22)
        Me.txtVendor.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vendor"
        '
        'pnlInvoice
        '
        Me.pnlInvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlInvoice.Controls.Add(Me.txtInvoiceDate)
        Me.pnlInvoice.Controls.Add(Me.btnClear)
        Me.pnlInvoice.Controls.Add(Me.btnSearchInvoice)
        Me.pnlInvoice.Controls.Add(Me.btnSave)
        Me.pnlInvoice.Controls.Add(Me.btnDelete)
        Me.pnlInvoice.Controls.Add(Me.btnEdit)
        Me.pnlInvoice.Controls.Add(Me.btnNew)
        Me.pnlInvoice.Controls.Add(Me.txtStatus)
        Me.pnlInvoice.Controls.Add(Me.Label8)
        Me.pnlInvoice.Controls.Add(Me.txtAmountDue)
        Me.pnlInvoice.Controls.Add(Me.Label7)
        Me.pnlInvoice.Controls.Add(Me.txtAmountPayed)
        Me.pnlInvoice.Controls.Add(Me.Label6)
        Me.pnlInvoice.Controls.Add(Me.txtInvoiceTotal)
        Me.pnlInvoice.Controls.Add(Me.Label5)
        Me.pnlInvoice.Controls.Add(Me.Label4)
        Me.pnlInvoice.Controls.Add(Me.txtInvoiceNo)
        Me.pnlInvoice.Controls.Add(Me.Label3)
        Me.pnlInvoice.Enabled = False
        Me.pnlInvoice.Location = New System.Drawing.Point(435, 10)
        Me.pnlInvoice.Name = "pnlInvoice"
        Me.pnlInvoice.Size = New System.Drawing.Size(643, 203)
        Me.pnlInvoice.TabIndex = 1
        '
        'txtInvoiceDate
        '
        Me.txtInvoiceDate.CustomFormat = "yyyy-MM-dd"
        Me.txtInvoiceDate.Enabled = False
        Me.txtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtInvoiceDate.Location = New System.Drawing.Point(108, 56)
        Me.txtInvoiceDate.Name = "txtInvoiceDate"
        Me.txtInvoiceDate.Size = New System.Drawing.Size(140, 22)
        Me.txtInvoiceDate.TabIndex = 22
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(254, 61)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(115, 35)
        Me.btnClear.TabIndex = 21
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSearchInvoice
        '
        Me.btnSearchInvoice.Enabled = False
        Me.btnSearchInvoice.Location = New System.Drawing.Point(254, 19)
        Me.btnSearchInvoice.Name = "btnSearchInvoice"
        Me.btnSearchInvoice.Size = New System.Drawing.Size(115, 35)
        Me.btnSearchInvoice.TabIndex = 20
        Me.btnSearchInvoice.Text = "Search"
        Me.btnSearchInvoice.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(372, 131)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(115, 35)
        Me.btnSave.TabIndex = 19
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(251, 131)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(115, 35)
        Me.btnDelete.TabIndex = 18
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(130, 131)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(115, 35)
        Me.btnEdit.TabIndex = 17
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(9, 131)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(115, 35)
        Me.btnNew.TabIndex = 16
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(486, 99)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(140, 22)
        Me.txtStatus.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(384, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 17)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Invoice Status"
        '
        'txtAmountDue
        '
        Me.txtAmountDue.Location = New System.Drawing.Point(486, 63)
        Me.txtAmountDue.Name = "txtAmountDue"
        Me.txtAmountDue.ReadOnly = True
        Me.txtAmountDue.Size = New System.Drawing.Size(140, 22)
        Me.txtAmountDue.TabIndex = 13
        Me.txtAmountDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(384, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 17)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Amount Due"
        '
        'txtAmountPayed
        '
        Me.txtAmountPayed.Location = New System.Drawing.Point(486, 19)
        Me.txtAmountPayed.Name = "txtAmountPayed"
        Me.txtAmountPayed.ReadOnly = True
        Me.txtAmountPayed.Size = New System.Drawing.Size(140, 22)
        Me.txtAmountPayed.TabIndex = 11
        Me.txtAmountPayed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(384, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Amount Paid"
        '
        'txtInvoiceTotal
        '
        Me.txtInvoiceTotal.Location = New System.Drawing.Point(108, 99)
        Me.txtInvoiceTotal.Name = "txtInvoiceTotal"
        Me.txtInvoiceTotal.ReadOnly = True
        Me.txtInvoiceTotal.Size = New System.Drawing.Size(140, 22)
        Me.txtInvoiceTotal.TabIndex = 9
        Me.txtInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Invoice Total"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Invoice Date"
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Location = New System.Drawing.Point(108, 19)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.ReadOnly = True
        Me.txtInvoiceNo.Size = New System.Drawing.Size(140, 22)
        Me.txtInvoiceNo.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Invoice No"
        '
        'pnlAmount
        '
        Me.pnlAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlAmount.Controls.Add(Me.btnPay)
        Me.pnlAmount.Controls.Add(Me.Label10)
        Me.pnlAmount.Controls.Add(Me.txtAmountToPay)
        Me.pnlAmount.Controls.Add(Me.Label9)
        Me.pnlAmount.Enabled = False
        Me.pnlAmount.Location = New System.Drawing.Point(12, 128)
        Me.pnlAmount.Name = "pnlAmount"
        Me.pnlAmount.Size = New System.Drawing.Size(417, 85)
        Me.pnlAmount.TabIndex = 2
        '
        'btnPay
        '
        Me.btnPay.Enabled = False
        Me.btnPay.Location = New System.Drawing.Point(258, 36)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(115, 35)
        Me.btnPay.TabIndex = 9
        Me.btnPay.Text = "Pay"
        Me.btnPay.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(173, 17)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Enter Amount to be payed"
        '
        'txtAmountToPay
        '
        Me.txtAmountToPay.Location = New System.Drawing.Point(111, 45)
        Me.txtAmountToPay.Name = "txtAmountToPay"
        Me.txtAmountToPay.Size = New System.Drawing.Size(140, 22)
        Me.txtAmountToPay.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 17)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Amount"
        '
        'dtgrdInvoices
        '
        Me.dtgrdInvoices.AllowUserToAddRows = False
        Me.dtgrdInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.dtgrdInvoices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgrdInvoices.Location = New System.Drawing.Point(12, 269)
        Me.dtgrdInvoices.Name = "dtgrdInvoices"
        Me.dtgrdInvoices.RowTemplate.Height = 24
        Me.dtgrdInvoices.Size = New System.Drawing.Size(1066, 318)
        Me.dtgrdInvoices.TabIndex = 3
        '
        'Column1
        '
        Me.Column1.HeaderText = "Invoice No"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Invoice Date"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column3.HeaderText = "Invoice Total"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column4.HeaderText = "Amount Paid"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column5.HeaderText = "Amount Due"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Status"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "id"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(963, 628)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(115, 35)
        Me.Button9.TabIndex = 10
        Me.Button9.Text = "Close"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'txtTotalInvoices
        '
        Me.txtTotalInvoices.Enabled = False
        Me.txtTotalInvoices.Location = New System.Drawing.Point(17, 30)
        Me.txtTotalInvoices.Name = "txtTotalInvoices"
        Me.txtTotalInvoices.Size = New System.Drawing.Size(178, 22)
        Me.txtTotalInvoices.TabIndex = 12
        Me.txtTotalInvoices.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(198, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 17)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Paid"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(962, 228)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 35)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Print"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtTotalPaid
        '
        Me.txtTotalPaid.Enabled = False
        Me.txtTotalPaid.Location = New System.Drawing.Point(201, 30)
        Me.txtTotalPaid.Name = "txtTotalPaid"
        Me.txtTotalPaid.Size = New System.Drawing.Size(178, 22)
        Me.txtTotalPaid.TabIndex = 14
        Me.txtTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalDue
        '
        Me.txtTotalDue.Enabled = False
        Me.txtTotalDue.Location = New System.Drawing.Point(385, 30)
        Me.txtTotalDue.Name = "txtTotalDue"
        Me.txtTotalDue.Size = New System.Drawing.Size(178, 22)
        Me.txtTotalDue.TabIndex = 15
        Me.txtTotalDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 17)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Total Invoices"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(382, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 17)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Total Due"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.txtTotalPaid)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txtTotalInvoices)
        Me.Panel2.Controls.Add(Me.txtTotalDue)
        Me.Panel2.Location = New System.Drawing.Point(12, 598)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(572, 66)
        Me.Panel2.TabIndex = 18
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(757, 228)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(199, 35)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Vendors Invoice Summary"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmInvoiceBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 669)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.dtgrdInvoices)
        Me.Controls.Add(Me.pnlAmount)
        Me.Controls.Add(Me.pnlInvoice)
        Me.Controls.Add(Me.Panel1)
        Me.MinimizeBox = False
        Me.Name = "frmInvoiceBook"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Invoice Book"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlInvoice.ResumeLayout(False)
        Me.pnlInvoice.PerformLayout()
        Me.pnlAmount.ResumeLayout(False)
        Me.pnlAmount.PerformLayout()
        CType(Me.dtgrdInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlInvoice As Panel
    Friend WithEvents btnSearchVendor As Button
    Friend WithEvents txtCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtVendor As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtInvoiceTotal As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtInvoiceNo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtAmountDue As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtAmountPayed As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents btnSearchInvoice As Button
    Friend WithEvents pnlAmount As Panel
    Friend WithEvents txtAmountToPay As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnPay As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents dtgrdInvoices As DataGridView
    Friend WithEvents Button9 As Button
    Friend WithEvents txtInvoiceDate As DateTimePicker
    Friend WithEvents txtTotalInvoices As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents txtTotalPaid As TextBox
    Friend WithEvents txtTotalDue As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
End Class
