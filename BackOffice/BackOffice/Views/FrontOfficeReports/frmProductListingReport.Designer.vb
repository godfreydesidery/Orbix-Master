﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductListingReport
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
        Me.dtgrdList = New System.Windows.Forms.DataGridView()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dateStart = New System.Windows.Forms.DateTimePicker()
        Me.dateEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnView = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnExportToPDF = New System.Windows.Forms.ToolStripButton()
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbSubClass = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbDepartment = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbSupplier = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbDescription = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lstCode = New System.Windows.Forms.ListBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtBarCode = New System.Windows.Forms.TextBox()
        Me.btnSearchItem = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtItemCodeS = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.dtgrdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgrdList
        '
        Me.dtgrdList.AllowUserToAddRows = False
        Me.dtgrdList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgrdList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdList.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtgrdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column1, Me.Column7, Me.Column5, Me.Column2, Me.Column3, Me.Column8, Me.Column4})
        Me.dtgrdList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgrdList.Location = New System.Drawing.Point(356, 79)
        Me.dtgrdList.Name = "dtgrdList"
        Me.dtgrdList.RowTemplate.Height = 24
        Me.dtgrdList.Size = New System.Drawing.Size(985, 582)
        Me.dtgrdList.TabIndex = 6
        '
        'Column6
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column6.FillWeight = 68.95222!
        Me.Column6.HeaderText = "Date"
        Me.Column6.Name = "Column6"
        '
        'Column1
        '
        Me.Column1.FillWeight = 80.77941!
        Me.Column1.HeaderText = "Code"
        Me.Column1.Name = "Column1"
        '
        'Column7
        '
        Me.Column7.FillWeight = 221.4627!
        Me.Column7.HeaderText = "Description"
        Me.Column7.Name = "Column7"
        '
        'Column5
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column5.FillWeight = 99.76032!
        Me.Column5.HeaderText = "Amount"
        Me.Column5.Name = "Column5"
        '
        'Column2
        '
        Me.Column2.FillWeight = 98.06259!
        Me.Column2.HeaderText = "Cashier"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.FillWeight = 81.21828!
        Me.Column3.HeaderText = "Receipt No"
        Me.Column3.Name = "Column3"
        '
        'Column8
        '
        Me.Column8.FillWeight = 91.99205!
        Me.Column8.HeaderText = "Invoice No"
        Me.Column8.Name = "Column8"
        '
        'Column4
        '
        Me.Column4.FillWeight = 57.77247!
        Me.Column4.HeaderText = "Till No"
        Me.Column4.Name = "Column4"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "From"
        '
        'dateStart
        '
        Me.dateStart.CustomFormat = "yyyy-MM-dd"
        Me.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateStart.Location = New System.Drawing.Point(49, 2)
        Me.dateStart.Name = "dateStart"
        Me.dateStart.Size = New System.Drawing.Size(127, 22)
        Me.dateStart.TabIndex = 8
        '
        'dateEnd
        '
        Me.dateEnd.CustomFormat = "yyyy-MM-dd"
        Me.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateEnd.Location = New System.Drawing.Point(213, 3)
        Me.dateEnd.Name = "dateEnd"
        Me.dateEnd.Size = New System.Drawing.Size(118, 22)
        Me.dateEnd.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(182, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 17)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "To"
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(356, 39)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(104, 34)
        Me.btnView.TabIndex = 11
        Me.btnView.Text = "Run"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dateStart)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dateEnd)
        Me.Panel1.Location = New System.Drawing.Point(10, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(340, 34)
        Me.Panel1.TabIndex = 15
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExportToPDF, Me.btnExportToExcel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1352, 27)
        Me.ToolStrip1.TabIndex = 106
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnExportToPDF
        '
        Me.btnExportToPDF.Image = Global.BackOffice.My.Resources.Resources.pdfred
        Me.btnExportToPDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportToPDF.Name = "btnExportToPDF"
        Me.btnExportToPDF.Size = New System.Drawing.Size(124, 24)
        Me.btnExportToPDF.Text = "Export to PDF"
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Image = Global.BackOffice.My.Resources.Resources.spreadsheet
        Me.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(180, 24)
        Me.btnExportToExcel.Text = "Export to Spreadsheet"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.cmbSubClass)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.cmbClass)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.cmbDepartment)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.cmbSupplier)
        Me.Panel2.Location = New System.Drawing.Point(10, 79)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(340, 139)
        Me.Panel2.TabIndex = 125
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 17)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Sub Class"
        '
        'cmbSubClass
        '
        Me.cmbSubClass.FormattingEnabled = True
        Me.cmbSubClass.Location = New System.Drawing.Point(91, 97)
        Me.cmbSubClass.Name = "cmbSubClass"
        Me.cmbSubClass.Size = New System.Drawing.Size(238, 24)
        Me.cmbSubClass.TabIndex = 51
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(43, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 17)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Class"
        '
        'cmbClass
        '
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(91, 67)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(238, 24)
        Me.cmbClass.TabIndex = 49
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 17)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Department"
        '
        'cmbDepartment
        '
        Me.cmbDepartment.FormattingEnabled = True
        Me.cmbDepartment.Location = New System.Drawing.Point(91, 37)
        Me.cmbDepartment.Name = "cmbDepartment"
        Me.cmbDepartment.Size = New System.Drawing.Size(238, 24)
        Me.cmbDepartment.TabIndex = 47
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 17)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Supplier"
        '
        'cmbSupplier
        '
        Me.cmbSupplier.FormattingEnabled = True
        Me.cmbSupplier.Location = New System.Drawing.Point(91, 5)
        Me.cmbSupplier.Name = "cmbSupplier"
        Me.cmbSupplier.Size = New System.Drawing.Size(238, 24)
        Me.cmbSupplier.TabIndex = 6
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.cmbDescription)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.lstCode)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.btnAdd)
        Me.Panel3.Controls.Add(Me.txtBarCode)
        Me.Panel3.Controls.Add(Me.btnSearchItem)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.txtItemCodeS)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Location = New System.Drawing.Point(10, 224)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(340, 261)
        Me.Panel3.TabIndex = 126
        '
        'cmbDescription
        '
        Me.cmbDescription.FormattingEnabled = True
        Me.cmbDescription.Location = New System.Drawing.Point(6, 80)
        Me.cmbDescription.Name = "cmbDescription"
        Me.cmbDescription.Size = New System.Drawing.Size(323, 24)
        Me.cmbDescription.TabIndex = 101
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(190, 110)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 35)
        Me.Button1.TabIndex = 65
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lstCode
        '
        Me.lstCode.FormattingEnabled = True
        Me.lstCode.ItemHeight = 16
        Me.lstCode.Location = New System.Drawing.Point(84, 151)
        Me.lstCode.Name = "lstCode"
        Me.lstCode.Size = New System.Drawing.Size(206, 100)
        Me.lstCode.TabIndex = 64
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(17, 7)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 17)
        Me.Label16.TabIndex = 60
        Me.Label16.Text = "Barcode"
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(84, 110)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 35)
        Me.btnAdd.TabIndex = 63
        Me.btnAdd.Text = "Add>>"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtBarCode
        '
        Me.txtBarCode.Location = New System.Drawing.Point(84, 4)
        Me.txtBarCode.MaxLength = 50
        Me.txtBarCode.Name = "txtBarCode"
        Me.txtBarCode.Size = New System.Drawing.Size(135, 22)
        Me.txtBarCode.TabIndex = 61
        '
        'btnSearchItem
        '
        Me.btnSearchItem.Location = New System.Drawing.Point(229, 3)
        Me.btnSearchItem.Name = "btnSearchItem"
        Me.btnSearchItem.Size = New System.Drawing.Size(100, 35)
        Me.btnSearchItem.TabIndex = 62
        Me.btnSearchItem.Text = "Search"
        Me.btnSearchItem.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(37, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 17)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Code"
        '
        'txtItemCodeS
        '
        Me.txtItemCodeS.Location = New System.Drawing.Point(84, 32)
        Me.txtItemCodeS.MaxLength = 50
        Me.txtItemCodeS.Name = "txtItemCodeS"
        Me.txtItemCodeS.Size = New System.Drawing.Size(135, 22)
        Me.txtItemCodeS.TabIndex = 58
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 17)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Description"
        '
        'frmProductListingReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1352, 673)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.dtgrdList)
        Me.MinimizeBox = False
        Me.Name = "frmProductListingReport"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Product Listing Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgrdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgrdList As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents dateStart As DateTimePicker
    Friend WithEvents dateEnd As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents btnView As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnExportToPDF As ToolStripButton
    Friend WithEvents btnExportToExcel As ToolStripButton
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbSubClass As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbClass As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbDepartment As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbSupplier As ComboBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmbDescription As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents lstCode As ListBox
    Friend WithEvents Label16 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtBarCode As TextBox
    Friend WithEvents btnSearchItem As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents txtItemCodeS As TextBox
    Friend WithEvents Label10 As Label
End Class
