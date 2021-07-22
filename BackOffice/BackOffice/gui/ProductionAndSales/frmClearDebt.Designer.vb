<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClearDebt
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIssueNo = New System.Windows.Forms.TextBox()
        Me.txtSMOficer = New System.Windows.Forms.TextBox()
        Me.txtDebt = New System.Windows.Forms.TextBox()
        Me.btnPay = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(75, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Issue No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Outstanding Debt"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(60, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "S/M Officer"
        '
        'txtIssueNo
        '
        Me.txtIssueNo.Location = New System.Drawing.Point(146, 71)
        Me.txtIssueNo.Name = "txtIssueNo"
        Me.txtIssueNo.ReadOnly = True
        Me.txtIssueNo.Size = New System.Drawing.Size(200, 22)
        Me.txtIssueNo.TabIndex = 3
        '
        'txtSMOficer
        '
        Me.txtSMOficer.Location = New System.Drawing.Point(146, 99)
        Me.txtSMOficer.Name = "txtSMOficer"
        Me.txtSMOficer.ReadOnly = True
        Me.txtSMOficer.Size = New System.Drawing.Size(287, 22)
        Me.txtSMOficer.TabIndex = 4
        '
        'txtDebt
        '
        Me.txtDebt.Location = New System.Drawing.Point(146, 129)
        Me.txtDebt.Name = "txtDebt"
        Me.txtDebt.ReadOnly = True
        Me.txtDebt.Size = New System.Drawing.Size(200, 22)
        Me.txtDebt.TabIndex = 5
        Me.txtDebt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPay
        '
        Me.btnPay.Location = New System.Drawing.Point(144, 233)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(97, 57)
        Me.btnPay.TabIndex = 6
        Me.btnPay.Text = "Pay"
        Me.btnPay.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Enter Amount"
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(144, 170)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(200, 27)
        Me.txtAmount.TabIndex = 8
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(249, 233)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(97, 57)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(144, 205)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(287, 22)
        Me.txtRemarks.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 205)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Remarks, if any"
        '
        'frmClearDebt
        '
        Me.AcceptButton = Me.btnPay
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(445, 330)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnPay)
        Me.Controls.Add(Me.txtDebt)
        Me.Controls.Add(Me.txtSMOficer)
        Me.Controls.Add(Me.txtIssueNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmClearDebt"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pay Debt"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtIssueNo As TextBox
    Friend WithEvents txtSMOficer As TextBox
    Friend WithEvents txtDebt As TextBox
    Friend WithEvents btnPay As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label5 As Label
End Class
