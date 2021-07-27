<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaleInvoice
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSaleInvoiceNo = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSaleInvoiceStatus = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSaleInvoiceDate = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.btnSearchItem = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtBarCode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtItemCodeS = New System.Windows.Forms.TextBox()
        Me.txtStockSize = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCostPrice = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPackSize = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtgrdItemList = New System.Windows.Forms.DataGridView()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.txtSellingPrice = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dtgrdItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.btnPrint)
        Me.Panel3.Controls.Add(Me.txtContact)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.txtName)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtSaleInvoiceNo)
        Me.Panel3.Controls.Add(Me.btnSearch)
        Me.Panel3.Controls.Add(Me.txtSaleInvoiceStatus)
        Me.Panel3.Controls.Add(Me.btnDelete)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.btnSave)
        Me.Panel3.Controls.Add(Me.btnNew)
        Me.Panel3.Controls.Add(Me.btnEdit)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtSaleInvoiceDate)
        Me.Panel3.Location = New System.Drawing.Point(12, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(777, 135)
        Me.Panel3.TabIndex = 59
        '
        'txtContact
        '
        Me.txtContact.Location = New System.Drawing.Point(85, 71)
        Me.txtContact.MaxLength = 50
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(292, 22)
        Me.txtContact.TabIndex = 44
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 17)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Contact"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(85, 43)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(292, 22)
        Me.txtName.TabIndex = 42
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 17)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Invoice No"
        '
        'txtSaleInvoiceNo
        '
        Me.txtSaleInvoiceNo.Location = New System.Drawing.Point(85, 6)
        Me.txtSaleInvoiceNo.MaxLength = 50
        Me.txtSaleInvoiceNo.Name = "txtSaleInvoiceNo"
        Me.txtSaleInvoiceNo.ReadOnly = True
        Me.txtSaleInvoiceNo.Size = New System.Drawing.Size(196, 22)
        Me.txtSaleInvoiceNo.TabIndex = 18
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(287, 7)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(90, 30)
        Me.btnSearch.TabIndex = 19
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSaleInvoiceStatus
        '
        Me.txtSaleInvoiceStatus.Location = New System.Drawing.Point(655, 8)
        Me.txtSaleInvoiceStatus.Name = "txtSaleInvoiceStatus"
        Me.txtSaleInvoiceStatus.ReadOnly = True
        Me.txtSaleInvoiceStatus.Size = New System.Drawing.Size(109, 22)
        Me.txtSaleInvoiceStatus.TabIndex = 31
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(578, 39)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(90, 30)
        Me.btnDelete.TabIndex = 23
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(601, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 17)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Status"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(674, 39)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 30)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(386, 39)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(90, 30)
        Me.btnNew.TabIndex = 21
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(482, 39)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(90, 30)
        Me.btnEdit.TabIndex = 22
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(383, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 17)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Invoice Date"
        '
        'txtSaleInvoiceDate
        '
        Me.txtSaleInvoiceDate.Location = New System.Drawing.Point(475, 8)
        Me.txtSaleInvoiceDate.Name = "txtSaleInvoiceDate"
        Me.txtSaleInvoiceDate.ReadOnly = True
        Me.txtSaleInvoiceDate.Size = New System.Drawing.Size(115, 22)
        Me.txtSaleInvoiceDate.TabIndex = 25
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.txtSellingPrice)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.txtDescription)
        Me.Panel2.Controls.Add(Me.btnSearchItem)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.txtBarCode)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.txtItemCodeS)
        Me.Panel2.Controls.Add(Me.txtStockSize)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txtCostPrice)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.txtQuantity)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.txtPackSize)
        Me.Panel2.Location = New System.Drawing.Point(12, 153)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(777, 141)
        Me.Panel2.TabIndex = 58
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(229, 99)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(90, 30)
        Me.btnAdd.TabIndex = 53
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(325, 99)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 30)
        Me.btnCancel.TabIndex = 54
        Me.btnCancel.Text = "Reset"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(89, 71)
        Me.txtDescription.MaxLength = 50
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(326, 22)
        Me.txtDescription.TabIndex = 40
        '
        'btnSearchItem
        '
        Me.btnSearchItem.Location = New System.Drawing.Point(325, 12)
        Me.btnSearchItem.Name = "btnSearchItem"
        Me.btnSearchItem.Size = New System.Drawing.Size(90, 30)
        Me.btnSearchItem.TabIndex = 51
        Me.btnSearchItem.Text = "Search"
        Me.btnSearchItem.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 17)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Item Code"
        '
        'txtBarCode
        '
        Me.txtBarCode.Location = New System.Drawing.Point(89, 12)
        Me.txtBarCode.MaxLength = 50
        Me.txtBarCode.Name = "txtBarCode"
        Me.txtBarCode.Size = New System.Drawing.Size(230, 22)
        Me.txtBarCode.TabIndex = 50
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 76)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 17)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Description"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(22, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 17)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Barcode"
        '
        'txtItemCodeS
        '
        Me.txtItemCodeS.Location = New System.Drawing.Point(89, 43)
        Me.txtItemCodeS.MaxLength = 50
        Me.txtItemCodeS.Name = "txtItemCodeS"
        Me.txtItemCodeS.Size = New System.Drawing.Size(230, 22)
        Me.txtItemCodeS.TabIndex = 39
        '
        'txtStockSize
        '
        Me.txtStockSize.Location = New System.Drawing.Point(553, 112)
        Me.txtStockSize.MaxLength = 50
        Me.txtStockSize.Name = "txtStockSize"
        Me.txtStockSize.ReadOnly = True
        Me.txtStockSize.Size = New System.Drawing.Size(115, 22)
        Me.txtStockSize.TabIndex = 48
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(22, 102)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 17)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "Quantity"
        '
        'txtCostPrice
        '
        Me.txtCostPrice.Location = New System.Drawing.Point(553, 11)
        Me.txtCostPrice.MaxLength = 50
        Me.txtCostPrice.Name = "txtCostPrice"
        Me.txtCostPrice.ReadOnly = True
        Me.txtCostPrice.Size = New System.Drawing.Size(115, 22)
        Me.txtCostPrice.TabIndex = 47
        Me.txtCostPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(477, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 17)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "Pack Size"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(473, 112)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 17)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "Stock Size"
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(89, 99)
        Me.txtQuantity.MaxLength = 50
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(115, 22)
        Me.txtQuantity.TabIndex = 43
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(472, 11)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 17)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "Cost Price"
        '
        'txtPackSize
        '
        Me.txtPackSize.Location = New System.Drawing.Point(553, 76)
        Me.txtPackSize.MaxLength = 50
        Me.txtPackSize.Name = "txtPackSize"
        Me.txtPackSize.ReadOnly = True
        Me.txtPackSize.Size = New System.Drawing.Size(115, 22)
        Me.txtPackSize.TabIndex = 44
        '
        'txtTotal
        '
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(877, 698)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(280, 30)
        Me.txtTotal.TabIndex = 57
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(805, 698)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 25)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "Total"
        '
        'dtgrdItemList
        '
        Me.dtgrdItemList.AllowUserToAddRows = False
        Me.dtgrdItemList.AllowUserToResizeColumns = False
        Me.dtgrdItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdItemList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgrdItemList.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dtgrdItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column13, Me.Column7, Me.Column8, Me.Column10, Me.Column9, Me.Column11, Me.Column2, Me.Column12, Me.Column1})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgrdItemList.DefaultCellStyle = DataGridViewCellStyle6
        Me.dtgrdItemList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgrdItemList.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.dtgrdItemList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtgrdItemList.Location = New System.Drawing.Point(12, 300)
        Me.dtgrdItemList.Name = "dtgrdItemList"
        Me.dtgrdItemList.ReadOnly = True
        Me.dtgrdItemList.RowTemplate.Height = 24
        Me.dtgrdItemList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dtgrdItemList.Size = New System.Drawing.Size(1277, 382)
        Me.dtgrdItemList.TabIndex = 55
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.SystemColors.Control
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBack.Location = New System.Drawing.Point(1174, 693)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(115, 35)
        Me.btnBack.TabIndex = 54
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'txtSellingPrice
        '
        Me.txtSellingPrice.Location = New System.Drawing.Point(553, 45)
        Me.txtSellingPrice.MaxLength = 50
        Me.txtSellingPrice.Name = "txtSellingPrice"
        Me.txtSellingPrice.ReadOnly = True
        Me.txtSellingPrice.Size = New System.Drawing.Size(115, 22)
        Me.txtSellingPrice.TabIndex = 56
        Me.txtSellingPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(458, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 17)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Selling Price"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(674, 98)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(90, 30)
        Me.btnPrint.TabIndex = 45
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "Bar Code"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column13.Visible = False
        '
        'Column7
        '
        Me.Column7.FillWeight = 83.45177!
        Me.Column7.HeaderText = "Item Code"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.FillWeight = 182.7411!
        Me.Column8.HeaderText = "Description"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.FillWeight = 83.45177!
        Me.Column10.HeaderText = "Quantity"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column9
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column9.FillWeight = 83.45177!
        Me.Column9.HeaderText = "Selling Price@"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column11
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column11.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column11.FillWeight = 83.45177!
        Me.Column11.HeaderText = "Total Selling Price"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Total Cost"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'Column12
        '
        Me.Column12.FillWeight = 83.45177!
        Me.Column12.HeaderText = "Current Stock"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'frmSaleInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1303, 757)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtgrdItemList)
        Me.Controls.Add(Me.btnBack)
        Me.MinimizeBox = False
        Me.Name = "frmSaleInvoice"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sales Invoice"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dtgrdItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnApprove As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSaleInvoiceNo As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSaleInvoiceStatus As TextBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSaleInvoiceDate As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents btnSearchItem As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents txtBarCode As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtItemCodeS As TextBox
    Friend WithEvents txtStockSize As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtCostPrice As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtPackSize As TextBox
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents dtgrdItemList As DataGridView
    Friend WithEvents btnBack As Button
    Friend WithEvents txtContact As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSellingPrice As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnPrint As Button
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
End Class
