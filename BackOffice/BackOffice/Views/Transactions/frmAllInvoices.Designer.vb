<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAllInvoices
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtgrdInvoices = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtTotalPaid = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTotalInvoices = New System.Windows.Forms.TextBox()
        Me.txtTotalDue = New System.Windows.Forms.TextBox()
        CType(Me.dtgrdInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgrdInvoices
        '
        Me.dtgrdInvoices.AllowUserToAddRows = False
        Me.dtgrdInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dtgrdInvoices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgrdInvoices.Location = New System.Drawing.Point(12, 53)
        Me.dtgrdInvoices.Name = "dtgrdInvoices"
        Me.dtgrdInvoices.RowTemplate.Height = 24
        Me.dtgrdInvoices.Size = New System.Drawing.Size(1157, 437)
        Me.dtgrdInvoices.TabIndex = 4
        '
        'Column1
        '
        Me.Column1.FillWeight = 50.76137!
        Me.Column1.HeaderText = "Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.FillWeight = 150.5303!
        Me.Column2.HeaderText = "Vendor"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column3.FillWeight = 99.56927!
        Me.Column3.HeaderText = "Invoice Total"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.FillWeight = 99.56927!
        Me.Column4.HeaderText = "Total Paid"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.FillWeight = 99.56927!
        Me.Column5.HeaderText = "Total Due"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1054, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 35)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Print"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1054, 532)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(115, 35)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Close"
        Me.Button2.UseVisualStyleBackColor = True
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
        Me.Panel2.Location = New System.Drawing.Point(12, 501)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(572, 66)
        Me.Panel2.TabIndex = 19
        '
        'txtTotalPaid
        '
        Me.txtTotalPaid.Enabled = False
        Me.txtTotalPaid.Location = New System.Drawing.Point(201, 30)
        Me.txtTotalPaid.Name = "txtTotalPaid"
        Me.txtTotalPaid.ReadOnly = True
        Me.txtTotalPaid.Size = New System.Drawing.Size(178, 22)
        Me.txtTotalPaid.TabIndex = 14
        Me.txtTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(198, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 17)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Paid"
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
        'txtTotalInvoices
        '
        Me.txtTotalInvoices.Enabled = False
        Me.txtTotalInvoices.Location = New System.Drawing.Point(17, 30)
        Me.txtTotalInvoices.Name = "txtTotalInvoices"
        Me.txtTotalInvoices.ReadOnly = True
        Me.txtTotalInvoices.Size = New System.Drawing.Size(178, 22)
        Me.txtTotalInvoices.TabIndex = 12
        Me.txtTotalInvoices.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalDue
        '
        Me.txtTotalDue.Enabled = False
        Me.txtTotalDue.Location = New System.Drawing.Point(385, 30)
        Me.txtTotalDue.Name = "txtTotalDue"
        Me.txtTotalDue.ReadOnly = True
        Me.txtTotalDue.Size = New System.Drawing.Size(178, 22)
        Me.txtTotalDue.TabIndex = 15
        Me.txtTotalDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmAllInvoices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1181, 579)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.dtgrdInvoices)
        Me.MinimizeBox = False
        Me.Name = "frmAllInvoices"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vendors Invoice Summary"
        CType(Me.dtgrdInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtgrdInvoices As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtTotalPaid As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTotalInvoices As TextBox
    Friend WithEvents txtTotalDue As TextBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
End Class
