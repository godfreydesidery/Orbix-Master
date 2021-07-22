<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGRNReport
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtgrdGRNList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgrdGRNParticulars = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtGRNNo = New System.Windows.Forms.TextBox()
        Me.txtOrderNo = New System.Windows.Forms.TextBox()
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dateStart = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dateEnd = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblGRNNo = New System.Windows.Forms.Label()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSupplierCode = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnListAll = New System.Windows.Forms.Button()
        Me.btnListBySupplier = New System.Windows.Forms.Button()
        Me.txtSupplier = New System.Windows.Forms.TextBox()
        CType(Me.dtgrdGRNList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgrdGRNParticulars, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "GRN No"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(444, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Order No"
        '
        'dtgrdGRNList
        '
        Me.dtgrdGRNList.AllowUserToAddRows = False
        Me.dtgrdGRNList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdGRNList.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdGRNList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgrdGRNList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdGRNList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dtgrdGRNList.Location = New System.Drawing.Point(812, 31)
        Me.dtgrdGRNList.MultiSelect = False
        Me.dtgrdGRNList.Name = "dtgrdGRNList"
        Me.dtgrdGRNList.ReadOnly = True
        Me.dtgrdGRNList.RowTemplate.Height = 24
        Me.dtgrdGRNList.Size = New System.Drawing.Size(536, 200)
        Me.dtgrdGRNList.TabIndex = 12
        '
        'Column1
        '
        Me.Column1.HeaderText = "GRN No"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Date"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "InvoiceNo"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "OrderNo"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'dtgrdGRNParticulars
        '
        Me.dtgrdGRNParticulars.AllowUserToAddRows = False
        Me.dtgrdGRNParticulars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdGRNParticulars.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdGRNParticulars.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgrdGRNParticulars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdGRNParticulars.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.Column5})
        Me.dtgrdGRNParticulars.Location = New System.Drawing.Point(3, 237)
        Me.dtgrdGRNParticulars.MultiSelect = False
        Me.dtgrdGRNParticulars.Name = "dtgrdGRNParticulars"
        Me.dtgrdGRNParticulars.ReadOnly = True
        Me.dtgrdGRNParticulars.RowTemplate.Height = 24
        Me.dtgrdGRNParticulars.Size = New System.Drawing.Size(1345, 405)
        Me.dtgrdGRNParticulars.TabIndex = 13
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Code"
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
        Me.DataGridViewTextBoxColumn4.HeaderText = "@Price"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Amount"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'txtGRNNo
        '
        Me.txtGRNNo.Location = New System.Drawing.Point(76, 13)
        Me.txtGRNNo.MaxLength = 20
        Me.txtGRNNo.Name = "txtGRNNo"
        Me.txtGRNNo.Size = New System.Drawing.Size(132, 22)
        Me.txtGRNNo.TabIndex = 14
        '
        'txtOrderNo
        '
        Me.txtOrderNo.Location = New System.Drawing.Point(517, 11)
        Me.txtOrderNo.MaxLength = 20
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.Size = New System.Drawing.Size(139, 22)
        Me.txtOrderNo.TabIndex = 15
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Location = New System.Drawing.Point(301, 13)
        Me.txtInvoiceNo.MaxLength = 20
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(127, 22)
        Me.txtInvoiceNo.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(221, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 17)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Invoice No"
        '
        'dateStart
        '
        Me.dateStart.CustomFormat = "yyyy-MM-dd"
        Me.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateStart.Location = New System.Drawing.Point(76, 52)
        Me.dateStart.Name = "dateStart"
        Me.dateStart.Size = New System.Drawing.Size(132, 22)
        Me.dateStart.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 17)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "From"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(270, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 17)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "To"
        '
        'dateEnd
        '
        Me.dateEnd.CustomFormat = "yyyy-MM-dd"
        Me.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateEnd.Location = New System.Drawing.Point(301, 52)
        Me.dateEnd.Name = "dateEnd"
        Me.dateEnd.Size = New System.Drawing.Size(127, 22)
        Me.dateEnd.TabIndex = 21
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(555, 52)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 35)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Filter"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(676, 52)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(115, 35)
        Me.btnPrint.TabIndex = 24
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmount.Location = New System.Drawing.Point(815, 645)
        Me.txtTotalAmount.MaxLength = 20
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(248, 30)
        Me.txtTotalAmount.TabIndex = 26
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(676, 645)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 25)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Total Amount"
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(1233, 648)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(115, 35)
        Me.btnBack.TabIndex = 28
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(434, 51)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(115, 35)
        Me.Button3.TabIndex = 29
        Me.Button3.Text = "View All"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(812, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 17)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "GRN List"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 217)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(171, 17)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "GRN Particulars GRN No:"
        '
        'lblGRNNo
        '
        Me.lblGRNNo.AutoSize = True
        Me.lblGRNNo.Location = New System.Drawing.Point(189, 217)
        Me.lblGRNNo.Name = "lblGRNNo"
        Me.lblGRNNo.Size = New System.Drawing.Size(0, 17)
        Me.lblGRNNo.TabIndex = 32
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(34, 90)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(40, 22)
        Me.txtDate.TabIndex = 33
        Me.txtDate.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txtGRNNo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtOrderNo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.txtInvoiceNo)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.btnPrint)
        Me.Panel1.Controls.Add(Me.dateStart)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.dateEnd)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(3, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(803, 100)
        Me.Panel1.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 17)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "List GRN by Supplier"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 140)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 17)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Code"
        '
        'txtSupplierCode
        '
        Me.txtSupplierCode.Location = New System.Drawing.Point(60, 137)
        Me.txtSupplierCode.Name = "txtSupplierCode"
        Me.txtSupplierCode.Size = New System.Drawing.Size(97, 22)
        Me.txtSupplierCode.TabIndex = 38
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(182, 140)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 17)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Name"
        '
        'btnListAll
        '
        Me.btnListAll.Location = New System.Drawing.Point(682, 137)
        Me.btnListAll.Name = "btnListAll"
        Me.btnListAll.Size = New System.Drawing.Size(115, 35)
        Me.btnListAll.TabIndex = 40
        Me.btnListAll.Text = "List All"
        Me.btnListAll.UseVisualStyleBackColor = True
        '
        'btnListBySupplier
        '
        Me.btnListBySupplier.Location = New System.Drawing.Point(538, 137)
        Me.btnListBySupplier.Name = "btnListBySupplier"
        Me.btnListBySupplier.Size = New System.Drawing.Size(136, 35)
        Me.btnListBySupplier.TabIndex = 41
        Me.btnListBySupplier.Text = "List By Supplier"
        Me.btnListBySupplier.UseVisualStyleBackColor = True
        '
        'txtSupplier
        '
        Me.txtSupplier.Location = New System.Drawing.Point(233, 137)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.Size = New System.Drawing.Size(299, 22)
        Me.txtSupplier.TabIndex = 42
        '
        'frmGRNReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1355, 702)
        Me.Controls.Add(Me.txtSupplier)
        Me.Controls.Add(Me.btnListBySupplier)
        Me.Controls.Add(Me.btnListAll)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtSupplierCode)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.lblGRNNo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtTotalAmount)
        Me.Controls.Add(Me.dtgrdGRNParticulars)
        Me.Controls.Add(Me.dtgrdGRNList)
        Me.MinimizeBox = False
        Me.Name = "frmGRNReport"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Goods Received Note Report"
        CType(Me.dtgrdGRNList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgrdGRNParticulars, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtgrdGRNList As DataGridView
    Friend WithEvents dtgrdGRNParticulars As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents txtGRNNo As TextBox
    Friend WithEvents txtOrderNo As TextBox
    Friend WithEvents txtInvoiceNo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dateStart As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dateEnd As DateTimePicker
    Friend WithEvents Button1 As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents txtTotalAmount As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblGRNNo As Label
    Friend WithEvents txtDate As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtSupplierCode As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnListAll As Button
    Friend WithEvents btnListBySupplier As Button
    Friend WithEvents txtSupplier As TextBox
End Class
