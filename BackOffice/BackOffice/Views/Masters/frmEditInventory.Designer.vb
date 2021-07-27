<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditInventory
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
        Me.txtMinimumInventory = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.txtMaximumInventory = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtDefaultReorderQuantity = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAdd = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDeduct = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNewStock = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDefaultReorderLevel = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtProductId = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtMinimumInventory
        '
        Me.txtMinimumInventory.Location = New System.Drawing.Point(167, 145)
        Me.txtMinimumInventory.MaxLength = 20
        Me.txtMinimumInventory.Name = "txtMinimumInventory"
        Me.txtMinimumInventory.Size = New System.Drawing.Size(206, 22)
        Me.txtMinimumInventory.TabIndex = 48
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(131, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 17)
        Me.Label15.TabIndex = 43
        Me.Label15.Text = "Qty"
        '
        'txtStock
        '
        Me.txtStock.Location = New System.Drawing.Point(167, 117)
        Me.txtStock.MaxLength = 20
        Me.txtStock.Name = "txtStock"
        Me.txtStock.ReadOnly = True
        Me.txtStock.Size = New System.Drawing.Size(206, 22)
        Me.txtStock.TabIndex = 44
        '
        'txtMaximumInventory
        '
        Me.txtMaximumInventory.Location = New System.Drawing.Point(167, 173)
        Me.txtMaximumInventory.MaxLength = 20
        Me.txtMaximumInventory.Name = "txtMaximumInventory"
        Me.txtMaximumInventory.Size = New System.Drawing.Size(206, 22)
        Me.txtMaximumInventory.TabIndex = 50
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(26, 229)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(135, 17)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Default Reorder Qty"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(33, 173)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(128, 17)
        Me.Label18.TabIndex = 49
        Me.Label18.Text = "Maximum Inventory"
        '
        'txtDefaultReorderQuantity
        '
        Me.txtDefaultReorderQuantity.Location = New System.Drawing.Point(167, 229)
        Me.txtDefaultReorderQuantity.MaxLength = 20
        Me.txtDefaultReorderQuantity.Name = "txtDefaultReorderQuantity"
        Me.txtDefaultReorderQuantity.Size = New System.Drawing.Size(206, 22)
        Me.txtDefaultReorderQuantity.TabIndex = 46
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(36, 145)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(125, 17)
        Me.Label17.TabIndex = 47
        Me.Label17.Text = "Minimum Inventory"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(128, 257)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 17)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Add"
        '
        'txtAdd
        '
        Me.txtAdd.Location = New System.Drawing.Point(167, 257)
        Me.txtAdd.MaxLength = 20
        Me.txtAdd.Name = "txtAdd"
        Me.txtAdd.Size = New System.Drawing.Size(206, 22)
        Me.txtAdd.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(110, 285)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 17)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Deduct"
        '
        'txtDeduct
        '
        Me.txtDeduct.Location = New System.Drawing.Point(167, 285)
        Me.txtDeduct.MaxLength = 20
        Me.txtDeduct.Name = "txtDeduct"
        Me.txtDeduct.Size = New System.Drawing.Size(206, 22)
        Me.txtDeduct.TabIndex = 54
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(167, 341)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 40)
        Me.btnSave.TabIndex = 55
        Me.btnSave.Text = "OK"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(273, 341)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 40)
        Me.btnCancel.TabIndex = 56
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(100, 316)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 17)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "New Qty"
        '
        'txtNewStock
        '
        Me.txtNewStock.Location = New System.Drawing.Point(167, 313)
        Me.txtNewStock.MaxLength = 20
        Me.txtNewStock.Name = "txtNewStock"
        Me.txtNewStock.ReadOnly = True
        Me.txtNewStock.Size = New System.Drawing.Size(206, 22)
        Me.txtNewStock.TabIndex = 58
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(120, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 17)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Code"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(167, 89)
        Me.txtCode.MaxLength = 20
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(206, 22)
        Me.txtCode.TabIndex = 60
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 204)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 17)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Default Reorder Level"
        '
        'txtDefaultReorderLevel
        '
        Me.txtDefaultReorderLevel.Location = New System.Drawing.Point(167, 201)
        Me.txtDefaultReorderLevel.MaxLength = 20
        Me.txtDefaultReorderLevel.Name = "txtDefaultReorderLevel"
        Me.txtDefaultReorderLevel.Size = New System.Drawing.Size(206, 22)
        Me.txtDefaultReorderLevel.TabIndex = 62
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(165, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(157, 24)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Modify inventory"
        '
        'txtProductId
        '
        Me.txtProductId.Location = New System.Drawing.Point(12, 12)
        Me.txtProductId.MaxLength = 20
        Me.txtProductId.Name = "txtProductId"
        Me.txtProductId.ReadOnly = True
        Me.txtProductId.Size = New System.Drawing.Size(33, 22)
        Me.txtProductId.TabIndex = 64
        Me.txtProductId.Visible = False
        '
        'frmEditInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(381, 390)
        Me.Controls.Add(Me.txtProductId)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDefaultReorderLevel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNewStock)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDeduct)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAdd)
        Me.Controls.Add(Me.txtMinimumInventory)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtStock)
        Me.Controls.Add(Me.txtMaximumInventory)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtDefaultReorderQuantity)
        Me.Controls.Add(Me.Label17)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditInventory"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Inventory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtMinimumInventory As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtStock As TextBox
    Friend WithEvents txtMaximumInventory As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtDefaultReorderQuantity As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAdd As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDeduct As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNewStock As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCode As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDefaultReorderLevel As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtProductId As TextBox
End Class
