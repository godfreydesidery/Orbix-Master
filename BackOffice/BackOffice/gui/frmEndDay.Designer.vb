<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEndDay
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
        Me.txtCurrentDate = New System.Windows.Forms.TextBox()
        Me.txtOpenAt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCloseDay = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(213, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Current System Date"
        '
        'txtCurrentDate
        '
        Me.txtCurrentDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentDate.Location = New System.Drawing.Point(12, 106)
        Me.txtCurrentDate.Name = "txtCurrentDate"
        Me.txtCurrentDate.ReadOnly = True
        Me.txtCurrentDate.Size = New System.Drawing.Size(296, 30)
        Me.txtCurrentDate.TabIndex = 1
        '
        'txtOpenAt
        '
        Me.txtOpenAt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOpenAt.Location = New System.Drawing.Point(323, 106)
        Me.txtOpenAt.Name = "txtOpenAt"
        Me.txtOpenAt.ReadOnly = True
        Me.txtOpenAt.Size = New System.Drawing.Size(299, 30)
        Me.txtOpenAt.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(318, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Opened at"
        '
        'btnCloseDay
        '
        Me.btnCloseDay.BackColor = System.Drawing.Color.Maroon
        Me.btnCloseDay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCloseDay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCloseDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseDay.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCloseDay.Location = New System.Drawing.Point(12, 207)
        Me.btnCloseDay.Name = "btnCloseDay"
        Me.btnCloseDay.Size = New System.Drawing.Size(610, 59)
        Me.btnCloseDay.TabIndex = 6
        Me.btnCloseDay.Text = "Close Current day and start a new Day"
        Me.btnCloseDay.UseVisualStyleBackColor = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(12, 9)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(84, 24)
        Me.Label29.TabIndex = 19
        Me.Label29.Text = "End Day"
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(547, 361)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 42)
        Me.btnBack.TabIndex = 20
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(94, 171)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 18)
        Me.lblStatus.TabIndex = 21
        '
        'frmEndDay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 415)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.btnCloseDay)
        Me.Controls.Add(Me.txtOpenAt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCurrentDate)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEndDay"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "End of Day"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtCurrentDate As TextBox
    Friend WithEvents txtOpenAt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCloseDay As Button
    Friend WithEvents Label29 As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents lblStatus As Label
End Class
