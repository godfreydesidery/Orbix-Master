<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreditNotes
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
        Me.txtCrNo = New System.Windows.Forms.TextBox()
        Me.txtCrDetails = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCrDate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBillNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtgrdCrNoteList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbCreditor = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        CType(Me.dtgrdCrNoteList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(385, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cr No"
        '
        'txtCrNo
        '
        Me.txtCrNo.Location = New System.Drawing.Point(435, 10)
        Me.txtCrNo.Name = "txtCrNo"
        Me.txtCrNo.Size = New System.Drawing.Size(229, 22)
        Me.txtCrNo.TabIndex = 1
        '
        'txtCrDetails
        '
        Me.txtCrDetails.Location = New System.Drawing.Point(435, 235)
        Me.txtCrDetails.Multiline = True
        Me.txtCrDetails.Name = "txtCrDetails"
        Me.txtCrDetails.Size = New System.Drawing.Size(356, 61)
        Me.txtCrDetails.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(360, 235)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cr Details"
        '
        'txtCrDate
        '
        Me.txtCrDate.Location = New System.Drawing.Point(435, 66)
        Me.txtCrDate.Name = "txtCrDate"
        Me.txtCrDate.Size = New System.Drawing.Size(229, 22)
        Me.txtCrDate.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(373, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Cr Date"
        '
        'txtBillNo
        '
        Me.txtBillNo.Location = New System.Drawing.Point(435, 38)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.Size = New System.Drawing.Size(229, 22)
        Me.txtBillNo.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(381, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Bill No"
        '
        'dtgrdCrNoteList
        '
        Me.dtgrdCrNoteList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdCrNoteList.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.dtgrdCrNoteList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdCrNoteList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column5, Me.Column2, Me.Column3, Me.Column4})
        Me.dtgrdCrNoteList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgrdCrNoteList.Location = New System.Drawing.Point(15, 341)
        Me.dtgrdCrNoteList.Name = "dtgrdCrNoteList"
        Me.dtgrdCrNoteList.RowTemplate.Height = 24
        Me.dtgrdCrNoteList.Size = New System.Drawing.Size(1428, 464)
        Me.dtgrdCrNoteList.TabIndex = 10
        '
        'Column1
        '
        Me.Column1.HeaderText = "Item Code"
        Me.Column1.Name = "Column1"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Description"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Qty"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Price"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Amount"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(670, 54)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(121, 34)
        Me.btnNew.TabIndex = 11
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(670, 94)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(121, 38)
        Me.btnEdit.TabIndex = 12
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(670, 138)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(121, 39)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(670, 183)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(121, 46)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(301, 24)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Supplier / Customer Credit notes"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(381, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 17)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Status"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(371, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Creditor"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(389, 124)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 17)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Type"
        '
        'cmbCreditor
        '
        Me.cmbCreditor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCreditor.FormattingEnabled = True
        Me.cmbCreditor.Items.AddRange(New Object() {"SUPPLIER", "CUSTOMER"})
        Me.cmbCreditor.Location = New System.Drawing.Point(435, 94)
        Me.cmbCreditor.Name = "cmbCreditor"
        Me.cmbCreditor.Size = New System.Drawing.Size(229, 24)
        Me.cmbCreditor.TabIndex = 21
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(670, 9)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(121, 39)
        Me.btnSearch.TabIndex = 23
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmbType
        '
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"ADJUSTMENT", "REFUNDABLE"})
        Me.cmbType.Location = New System.Drawing.Point(435, 124)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(229, 24)
        Me.cmbType.TabIndex = 24
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"ADJUST DUE", "ADJUSTED", "REFUND DUE", "REFUNDED"})
        Me.cmbStatus.Location = New System.Drawing.Point(435, 154)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(229, 24)
        Me.cmbStatus.TabIndex = 25
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(1359, 811)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(84, 39)
        Me.btnBack.TabIndex = 26
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(435, 183)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ReadOnly = True
        Me.txtAmount.Size = New System.Drawing.Size(229, 22)
        Me.txtAmount.TabIndex = 28
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(373, 183)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 17)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Amount"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(808, 235)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(141, 61)
        Me.btnPrint.TabIndex = 29
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'frmCreditNotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1455, 862)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.cmbCreditor)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.dtgrdCrNoteList)
        Me.Controls.Add(Me.txtBillNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCrDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCrDetails)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCrNo)
        Me.Controls.Add(Me.Label1)
        Me.MinimizeBox = False
        Me.Name = "frmCreditNotes"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Credit Note"
        CType(Me.dtgrdCrNoteList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtCrNo As TextBox
    Friend WithEvents txtCrDetails As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCrDate As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBillNo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtgrdCrNoteList As DataGridView
    Friend WithEvents btnNew As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbCreditor As ComboBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents btnBack As Button
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnPrint As Button
End Class
