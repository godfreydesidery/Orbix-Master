﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStockCardReports
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
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
        Me.cmbSupplier = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dateStart = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dateEnd = New System.Windows.Forms.DateTimePicker()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.dtgrdList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnExportToPDF = New System.Windows.Forms.ToolStripButton()
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dtgrdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cmbSupplier)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dateStart)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dateEnd)
        Me.Panel1.Location = New System.Drawing.Point(10, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(377, 91)
        Me.Panel1.TabIndex = 65
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
        Me.Panel3.Location = New System.Drawing.Point(10, 147)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(377, 315)
        Me.Panel3.TabIndex = 64
        '
        'cmbDescription
        '
        Me.cmbDescription.FormattingEnabled = True
        Me.cmbDescription.Location = New System.Drawing.Point(3, 104)
        Me.cmbDescription.Name = "cmbDescription"
        Me.cmbDescription.Size = New System.Drawing.Size(326, 24)
        Me.cmbDescription.TabIndex = 101
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(113, 134)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 51)
        Me.Button1.TabIndex = 65
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lstCode
        '
        Me.lstCode.FormattingEnabled = True
        Me.lstCode.ItemHeight = 16
        Me.lstCode.Location = New System.Drawing.Point(3, 191)
        Me.lstCode.Name = "lstCode"
        Me.lstCode.Size = New System.Drawing.Size(214, 84)
        Me.lstCode.TabIndex = 64
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 2)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 17)
        Me.Label16.TabIndex = 60
        Me.Label16.Text = "Bar Code"
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(3, 134)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(104, 51)
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
        Me.btnSearchItem.Location = New System.Drawing.Point(225, 4)
        Me.btnSearchItem.Name = "btnSearchItem"
        Me.btnSearchItem.Size = New System.Drawing.Size(104, 50)
        Me.btnSearchItem.TabIndex = 62
        Me.btnSearchItem.Text = "Search"
        Me.btnSearchItem.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 53)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 17)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Item Code"
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
        Me.Label10.Location = New System.Drawing.Point(3, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 17)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Item Description"
        '
        'cmbSupplier
        '
        Me.cmbSupplier.FormattingEnabled = True
        Me.cmbSupplier.Location = New System.Drawing.Point(69, 48)
        Me.cmbSupplier.Name = "cmbSupplier"
        Me.cmbSupplier.Size = New System.Drawing.Size(286, 24)
        Me.cmbSupplier.TabIndex = 52
        Me.cmbSupplier.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 17)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Supplier"
        Me.Label7.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 17)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "From"
        '
        'dateStart
        '
        Me.dateStart.CustomFormat = "yyyy-MM-dd"
        Me.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateStart.Location = New System.Drawing.Point(49, 8)
        Me.dateStart.Name = "dateStart"
        Me.dateStart.Size = New System.Drawing.Size(120, 22)
        Me.dateStart.TabIndex = 47
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(200, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 17)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "To"
        '
        'dateEnd
        '
        Me.dateEnd.CustomFormat = "yyyy-MM-dd"
        Me.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateEnd.Location = New System.Drawing.Point(235, 8)
        Me.dateEnd.Name = "dateEnd"
        Me.dateEnd.Size = New System.Drawing.Size(120, 22)
        Me.dateEnd.TabIndex = 48
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(393, 97)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(104, 44)
        Me.btnRun.TabIndex = 49
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
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
        Me.dtgrdList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.dtgrdList.Location = New System.Drawing.Point(393, 147)
        Me.dtgrdList.Name = "dtgrdList"
        Me.dtgrdList.ReadOnly = True
        Me.dtgrdList.RowTemplate.Height = 24
        Me.dtgrdList.Size = New System.Drawing.Size(1041, 564)
        Me.dtgrdList.TabIndex = 64
        '
        'Column1
        '
        Me.Column1.HeaderText = "Date"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Item Code"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Description"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Qty In"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Qty Out"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Balance"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Reference"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackColor = System.Drawing.SystemColors.Control
        Me.btnBack.BackgroundImage = Global.BackOffice.My.Resources.Resources.red_back_arrow
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.Location = New System.Drawing.Point(1336, 717)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(100, 40)
        Me.btnBack.TabIndex = 63
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExportToPDF, Me.btnExportToExcel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1448, 27)
        Me.ToolStrip1.TabIndex = 110
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
        Me.btnExportToExcel.Enabled = False
        Me.btnExportToExcel.Image = Global.BackOffice.My.Resources.Resources.spreadsheet
        Me.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(180, 24)
        Me.btnExportToExcel.Text = "Export to Spreadsheet"
        '
        'frmStockCardReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1448, 759)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dtgrdList)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnRun)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmStockCardReports"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Stock Card Reports"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dtgrdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents lstCode As ListBox
    Friend WithEvents Label16 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtBarCode As TextBox
    Friend WithEvents btnSearchItem As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents txtItemCodeS As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbSupplier As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dateStart As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dateEnd As DateTimePicker
    Friend WithEvents btnRun As Button
    Friend WithEvents dtgrdList As DataGridView
    Friend WithEvents btnBack As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents cmbDescription As ComboBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnExportToPDF As ToolStripButton
    Friend WithEvents btnExportToExcel As ToolStripButton
End Class