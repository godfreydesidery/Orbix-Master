<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSupplierCreditNote
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
        Me.btnAdjust = New System.Windows.Forms.Button()
        Me.txtCrStatus = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCrAmount = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtgrdCrNoteList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtCrDetails = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.txtOrderNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCrDate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCrNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.dtgrdCrNoteList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAdjust
        '
        Me.btnAdjust.Location = New System.Drawing.Point(654, 95)
        Me.btnAdjust.Name = "btnAdjust"
        Me.btnAdjust.Size = New System.Drawing.Size(110, 52)
        Me.btnAdjust.TabIndex = 65
        Me.btnAdjust.Text = "Adjust"
        Me.btnAdjust.UseVisualStyleBackColor = True
        '
        'txtCrStatus
        '
        Me.txtCrStatus.Location = New System.Drawing.Point(86, 129)
        Me.txtCrStatus.MaxLength = 50
        Me.txtCrStatus.Name = "txtCrStatus"
        Me.txtCrStatus.ReadOnly = True
        Me.txtCrStatus.Size = New System.Drawing.Size(229, 22)
        Me.txtCrStatus.TabIndex = 64
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 17)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Cr Status"
        '
        'txtCrAmount
        '
        Me.txtCrAmount.Location = New System.Drawing.Point(86, 101)
        Me.txtCrAmount.MaxLength = 50
        Me.txtCrAmount.Name = "txtCrAmount"
        Me.txtCrAmount.Size = New System.Drawing.Size(229, 22)
        Me.txtCrAmount.TabIndex = 62
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 17)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Cr Amount"
        '
        'dtgrdCrNoteList
        '
        Me.dtgrdCrNoteList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdCrNoteList.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.dtgrdCrNoteList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdCrNoteList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column5, Me.Column2, Me.Column3, Me.Column4})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgrdCrNoteList.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtgrdCrNoteList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dtgrdCrNoteList.Location = New System.Drawing.Point(4, 203)
        Me.dtgrdCrNoteList.Name = "dtgrdCrNoteList"
        Me.dtgrdCrNoteList.RowTemplate.Height = 24
        Me.dtgrdCrNoteList.Size = New System.Drawing.Size(1318, 423)
        Me.dtgrdCrNoteList.TabIndex = 60
        '
        'Column1
        '
        Me.Column1.FillWeight = 67.89339!
        Me.Column1.HeaderText = "Item Code"
        Me.Column1.MaxInputLength = 50
        Me.Column1.Name = "Column1"
        '
        'Column5
        '
        Me.Column5.FillWeight = 228.4264!
        Me.Column5.HeaderText = "Description"
        Me.Column5.MaxInputLength = 100
        Me.Column5.MinimumWidth = 10
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.FillWeight = 67.89339!
        Me.Column2.HeaderText = "Qty"
        Me.Column2.MaxInputLength = 10
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.FillWeight = 67.89339!
        Me.Column3.HeaderText = "Price"
        Me.Column3.MaxInputLength = 10
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.FillWeight = 67.89339!
        Me.Column4.HeaderText = "Amount"
        Me.Column4.MaxInputLength = 15
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'txtCrDetails
        '
        Me.txtCrDetails.Location = New System.Drawing.Point(321, 86)
        Me.txtCrDetails.MaxLength = 400
        Me.txtCrDetails.Multiline = True
        Me.txtCrDetails.Name = "txtCrDetails"
        Me.txtCrDetails.Size = New System.Drawing.Size(306, 65)
        Me.txtCrDetails.TabIndex = 59
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(321, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 17)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Cr Details"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(653, 37)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(111, 52)
        Me.btnPrint.TabIndex = 57
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(321, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(121, 50)
        Me.btnSearch.TabIndex = 56
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(897, 95)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(121, 52)
        Me.btnSave.TabIndex = 55
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(897, 40)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(121, 49)
        Me.btnDelete.TabIndex = 54
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(770, 95)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(121, 52)
        Me.btnEdit.TabIndex = 53
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(770, 40)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(121, 49)
        Me.btnNew.TabIndex = 52
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'txtOrderNo
        '
        Me.txtOrderNo.Location = New System.Drawing.Point(86, 41)
        Me.txtOrderNo.MaxLength = 50
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.ReadOnly = True
        Me.txtOrderNo.Size = New System.Drawing.Size(229, 22)
        Me.txtOrderNo.TabIndex = 51
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 17)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Order No"
        '
        'txtCrDate
        '
        Me.txtCrDate.Location = New System.Drawing.Point(86, 69)
        Me.txtCrDate.MaxLength = 50
        Me.txtCrDate.Name = "txtCrDate"
        Me.txtCrDate.ReadOnly = True
        Me.txtCrDate.Size = New System.Drawing.Size(229, 22)
        Me.txtCrDate.TabIndex = 49
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Cr Date"
        '
        'txtCrNo
        '
        Me.txtCrNo.Location = New System.Drawing.Point(86, 13)
        Me.txtCrNo.MaxLength = 50
        Me.txtCrNo.Name = "txtCrNo"
        Me.txtCrNo.Size = New System.Drawing.Size(229, 22)
        Me.txtCrNo.TabIndex = 47
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 17)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Cr No"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(198, 24)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Supplier Credit Notes"
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(1228, 632)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(94, 39)
        Me.btnBack.TabIndex = 44
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtCrStatus)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtCrNo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtCrDetails)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtCrAmount)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtCrDate)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtOrderNo)
        Me.Panel1.Location = New System.Drawing.Point(4, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(643, 158)
        Me.Panel1.TabIndex = 66
        '
        'frmSupplierCreditNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1329, 686)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnAdjust)
        Me.Controls.Add(Me.dtgrdCrNoteList)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnBack)
        Me.MinimizeBox = False
        Me.Name = "frmSupplierCreditNote"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Supplier Credit Notes"
        CType(Me.dtgrdCrNoteList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAdjust As Button
    Friend WithEvents txtCrStatus As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCrAmount As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents dtgrdCrNoteList As DataGridView
    Friend WithEvents txtCrDetails As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents txtOrderNo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCrDate As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCrNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
End Class
