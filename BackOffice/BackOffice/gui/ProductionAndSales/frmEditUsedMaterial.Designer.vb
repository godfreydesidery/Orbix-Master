<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditUsedMaterial
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
        Me.txtMaterial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAdd = New System.Windows.Forms.TextBox()
        Me.txtDeduct = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDeduct = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.frmRemove = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Material"
        '
        'txtMaterial
        '
        Me.txtMaterial.Location = New System.Drawing.Point(76, 30)
        Me.txtMaterial.Name = "txtMaterial"
        Me.txtMaterial.ReadOnly = True
        Me.txtMaterial.Size = New System.Drawing.Size(350, 22)
        Me.txtMaterial.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Qty"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(78, 58)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.ReadOnly = True
        Me.txtQty.Size = New System.Drawing.Size(234, 22)
        Me.txtQty.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(79, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Add"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(196, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 17)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Deduct"
        '
        'txtAdd
        '
        Me.txtAdd.Location = New System.Drawing.Point(82, 123)
        Me.txtAdd.Name = "txtAdd"
        Me.txtAdd.Size = New System.Drawing.Size(111, 22)
        Me.txtAdd.TabIndex = 6
        '
        'txtDeduct
        '
        Me.txtDeduct.Location = New System.Drawing.Point(199, 123)
        Me.txtDeduct.Name = "txtDeduct"
        Me.txtDeduct.Size = New System.Drawing.Size(113, 22)
        Me.txtDeduct.TabIndex = 7
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(81, 156)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(111, 44)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDeduct
        '
        Me.btnDeduct.Enabled = False
        Me.btnDeduct.Location = New System.Drawing.Point(201, 156)
        Me.btnDeduct.Name = "btnDeduct"
        Me.btnDeduct.Size = New System.Drawing.Size(111, 44)
        Me.btnDeduct.TabIndex = 9
        Me.btnDeduct.Text = "Deduct"
        Me.btnDeduct.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(318, 156)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(111, 44)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(-2, 5)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(35, 22)
        Me.txtId.TabIndex = 11
        Me.txtId.Visible = False
        '
        'frmRemove
        '
        Me.frmRemove.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.frmRemove.Location = New System.Drawing.Point(315, 58)
        Me.frmRemove.Name = "frmRemove"
        Me.frmRemove.Size = New System.Drawing.Size(111, 44)
        Me.frmRemove.TabIndex = 12
        Me.frmRemove.Text = "Remove"
        Me.frmRemove.UseVisualStyleBackColor = True
        '
        'frmEditUsedMaterial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(446, 219)
        Me.Controls.Add(Me.frmRemove)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDeduct)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtDeduct)
        Me.Controls.Add(Me.txtAdd)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMaterial)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmEditUsedMaterial"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Material"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtMaterial As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtQty As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtAdd As TextBox
    Friend WithEvents txtDeduct As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDeduct As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtId As TextBox
    Friend WithEvents frmRemove As Button
End Class
