<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewSuppliers
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtgrdSuppliers = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtItem = New System.Windows.Forms.TextBox()
        Me.btnAssignProduct = New System.Windows.Forms.Button()
        CType(Me.dtgrdSuppliers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Suppliers for Item: "
        '
        'dtgrdSuppliers
        '
        Me.dtgrdSuppliers.AllowUserToAddRows = False
        Me.dtgrdSuppliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdSuppliers.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdSuppliers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.dtgrdSuppliers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgrdSuppliers.Location = New System.Drawing.Point(15, 115)
        Me.dtgrdSuppliers.Name = "dtgrdSuppliers"
        Me.dtgrdSuppliers.ReadOnly = True
        Me.dtgrdSuppliers.RowTemplate.Height = 24
        Me.dtgrdSuppliers.Size = New System.Drawing.Size(1127, 482)
        Me.dtgrdSuppliers.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.FillWeight = 67.51269!
        Me.Column1.HeaderText = "Supplier Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.FillWeight = 236.2798!
        Me.Column2.HeaderText = "Supplier Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.FillWeight = 90.83618!
        Me.Column3.HeaderText = "Cost Price(Vat Incl)"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.FillWeight = 86.74509!
        Me.Column4.HeaderText = "Cost Price(Vat Excl)"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.FillWeight = 38.89823!
        Me.Column5.HeaderText = "Supply Packing"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.FillWeight = 52.68568!
        Me.Column6.HeaderText = "VAT No"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.FillWeight = 127.0423!
        Me.Column7.HeaderText = "Terms of Payment"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(1007, 603)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(135, 52)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtItem
        '
        Me.txtItem.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtItem.Location = New System.Drawing.Point(144, 81)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.ReadOnly = True
        Me.txtItem.Size = New System.Drawing.Size(533, 15)
        Me.txtItem.TabIndex = 3
        '
        'btnAssignProduct
        '
        Me.btnAssignProduct.Location = New System.Drawing.Point(673, 57)
        Me.btnAssignProduct.Name = "btnAssignProduct"
        Me.btnAssignProduct.Size = New System.Drawing.Size(135, 52)
        Me.btnAssignProduct.TabIndex = 4
        Me.btnAssignProduct.Text = "Assign Product"
        Me.btnAssignProduct.UseVisualStyleBackColor = True
        '
        'frmViewSuppliers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1154, 669)
        Me.Controls.Add(Me.btnAssignProduct)
        Me.Controls.Add(Me.txtItem)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dtgrdSuppliers)
        Me.Controls.Add(Me.Label1)
        Me.MinimizeBox = False
        Me.Name = "frmViewSuppliers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Item Supplier"
        CType(Me.dtgrdSuppliers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dtgrdSuppliers As DataGridView
    Friend WithEvents btnClose As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents txtItem As TextBox
    Friend WithEvents btnAssignProduct As Button
End Class
