<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInjector
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtinvCount = New System.Windows.Forms.TextBox()
        Me.lblItems = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtItemcount = New System.Windows.Forms.TextBox()
        Me.btnInv = New System.Windows.Forms.Button()
        Me.btnItems = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(243, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(175, 17)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Updating Prices(Progress)"
        '
        'txtinvCount
        '
        Me.txtinvCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinvCount.Location = New System.Drawing.Point(246, 157)
        Me.txtinvCount.Name = "txtinvCount"
        Me.txtinvCount.Size = New System.Drawing.Size(191, 34)
        Me.txtinvCount.TabIndex = 17
        '
        'lblItems
        '
        Me.lblItems.AutoSize = True
        Me.lblItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItems.Location = New System.Drawing.Point(501, 139)
        Me.lblItems.Name = "lblItems"
        Me.lblItems.Size = New System.Drawing.Size(72, 29)
        Me.lblItems.TabIndex = 16
        Me.lblItems.Text = "out of"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(243, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 17)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Uploading items(Progress)"
        '
        'txtItemcount
        '
        Me.txtItemcount.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemcount.Location = New System.Drawing.Point(246, 54)
        Me.txtItemcount.Name = "txtItemcount"
        Me.txtItemcount.Size = New System.Drawing.Size(191, 34)
        Me.txtItemcount.TabIndex = 14
        '
        'btnInv
        '
        Me.btnInv.Location = New System.Drawing.Point(16, 123)
        Me.btnInv.Name = "btnInv"
        Me.btnInv.Size = New System.Drawing.Size(188, 68)
        Me.btnInv.TabIndex = 13
        Me.btnInv.Text = "Inject Prices"
        Me.btnInv.UseVisualStyleBackColor = True
        '
        'btnItems
        '
        Me.btnItems.Location = New System.Drawing.Point(16, 20)
        Me.btnItems.Name = "btnItems"
        Me.btnItems.Size = New System.Drawing.Size(188, 68)
        Me.btnItems.TabIndex = 12
        Me.btnItems.Text = "Inject Items"
        Me.btnItems.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 221)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(188, 68)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Update Stocks"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(243, 221)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(178, 17)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Updating Stocks(Progress)"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(246, 255)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(191, 34)
        Me.TextBox1.TabIndex = 20
        '
        'frmInjector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 353)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtinvCount)
        Me.Controls.Add(Me.lblItems)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtItemcount)
        Me.Controls.Add(Me.btnInv)
        Me.Controls.Add(Me.btnItems)
        Me.Name = "frmInjector"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Injector"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents txtinvCount As TextBox
    Friend WithEvents lblItems As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtItemcount As TextBox
    Friend WithEvents btnInv As Button
    Friend WithEvents btnItems As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
End Class
