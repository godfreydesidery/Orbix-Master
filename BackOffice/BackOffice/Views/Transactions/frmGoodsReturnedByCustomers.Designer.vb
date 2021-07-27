<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGoodsReturnedByCustomers
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearchBillNo = New System.Windows.Forms.TextBox()
        Me.dtgrdItemList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.txtTillNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBillDate = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBillAmount = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBillNo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.dtgrdItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.SystemColors.Control
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBack.Location = New System.Drawing.Point(1227, 672)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(115, 35)
        Me.btnBack.TabIndex = 5
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Bill No"
        '
        'txtSearchBillNo
        '
        Me.txtSearchBillNo.Location = New System.Drawing.Point(54, 12)
        Me.txtSearchBillNo.Name = "txtSearchBillNo"
        Me.txtSearchBillNo.Size = New System.Drawing.Size(148, 22)
        Me.txtSearchBillNo.TabIndex = 9
        '
        'dtgrdItemList
        '
        Me.dtgrdItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdItemList.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtgrdItemList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgrdItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column4, Me.Column3})
        Me.dtgrdItemList.Location = New System.Drawing.Point(7, 104)
        Me.dtgrdItemList.Name = "dtgrdItemList"
        Me.dtgrdItemList.RowTemplate.Height = 24
        Me.dtgrdItemList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dtgrdItemList.Size = New System.Drawing.Size(1335, 562)
        Me.dtgrdItemList.TabIndex = 10
        '
        'Column1
        '
        Me.Column1.HeaderText = "Item Code"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Quantity"
        Me.Column2.Name = "Column2"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Price@"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Description"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(205, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(115, 35)
        Me.btnSearch.TabIndex = 11
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(1144, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(115, 35)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(1004, 12)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(115, 35)
        Me.btnConfirm.TabIndex = 13
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'txtTillNo
        '
        Me.txtTillNo.Location = New System.Drawing.Point(395, 12)
        Me.txtTillNo.Name = "txtTillNo"
        Me.txtTillNo.ReadOnly = True
        Me.txtTillNo.Size = New System.Drawing.Size(147, 22)
        Me.txtTillNo.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(341, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Till No"
        '
        'txtBillDate
        '
        Me.txtBillDate.Location = New System.Drawing.Point(614, 12)
        Me.txtBillDate.Name = "txtBillDate"
        Me.txtBillDate.ReadOnly = True
        Me.txtBillDate.Size = New System.Drawing.Size(141, 22)
        Me.txtBillDate.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(548, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 17)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Bill Date"
        '
        'txtBillAmount
        '
        Me.txtBillAmount.Location = New System.Drawing.Point(855, 15)
        Me.txtBillAmount.Name = "txtBillAmount"
        Me.txtBillAmount.ReadOnly = True
        Me.txtBillAmount.Size = New System.Drawing.Size(143, 22)
        Me.txtBillAmount.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(771, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 17)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Bill Amount"
        '
        'txtBillNo
        '
        Me.txtBillNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBillNo.Location = New System.Drawing.Point(12, 83)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.ReadOnly = True
        Me.txtBillNo.Size = New System.Drawing.Size(367, 15)
        Me.txtBillNo.TabIndex = 20
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txtSearchBillNo)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnConfirm)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtBillAmount)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtTillNo)
        Me.Panel1.Controls.Add(Me.txtBillDate)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(7, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1335, 65)
        Me.Panel1.TabIndex = 21
        '
        'frmGoodsReturnedByCustomers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1349, 714)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtBillNo)
        Me.Controls.Add(Me.dtgrdItemList)
        Me.Controls.Add(Me.btnBack)
        Me.MinimizeBox = False
        Me.Name = "frmGoodsReturnedByCustomers"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Return by Customer"
        CType(Me.dtgrdItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSearchBillNo As TextBox
    Friend WithEvents dtgrdItemList As DataGridView
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnConfirm As Button
    Friend WithEvents txtTillNo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBillDate As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtBillAmount As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtBillNo As TextBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
End Class
