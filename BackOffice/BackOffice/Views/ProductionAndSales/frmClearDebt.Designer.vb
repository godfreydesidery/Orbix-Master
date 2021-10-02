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
        Me.txtBankDeposit = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCashPayment = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAmountRemaining = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(73, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Issue No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Outstanding Debt"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(58, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "S/M Officer"
        '
        'txtIssueNo
        '
        Me.txtIssueNo.Location = New System.Drawing.Point(144, 24)
        Me.txtIssueNo.Name = "txtIssueNo"
        Me.txtIssueNo.ReadOnly = True
        Me.txtIssueNo.Size = New System.Drawing.Size(205, 22)
        Me.txtIssueNo.TabIndex = 3
        '
        'txtSMOficer
        '
        Me.txtSMOficer.Location = New System.Drawing.Point(144, 52)
        Me.txtSMOficer.Name = "txtSMOficer"
        Me.txtSMOficer.ReadOnly = True
        Me.txtSMOficer.Size = New System.Drawing.Size(287, 22)
        Me.txtSMOficer.TabIndex = 4
        '
        'txtDebt
        '
        Me.txtDebt.Location = New System.Drawing.Point(144, 82)
        Me.txtDebt.Name = "txtDebt"
        Me.txtDebt.ReadOnly = True
        Me.txtDebt.Size = New System.Drawing.Size(205, 22)
        Me.txtDebt.TabIndex = 5
        Me.txtDebt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPay
        '
        Me.btnPay.Location = New System.Drawing.Point(143, 341)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(100, 35)
        Me.btnPay.TabIndex = 6
        Me.btnPay.Text = "Pay"
        Me.btnPay.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Bank Deposit"
        '
        'txtBankDeposit
        '
        Me.txtBankDeposit.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankDeposit.Location = New System.Drawing.Point(144, 133)
        Me.txtBankDeposit.Name = "txtBankDeposit"
        Me.txtBankDeposit.Size = New System.Drawing.Size(205, 27)
        Me.txtBankDeposit.TabIndex = 8
        Me.txtBankDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(249, 341)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 35)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(144, 269)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(205, 66)
        Me.txtRemarks.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 269)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Remarks, if any"
        '
        'txtCashPayment
        '
        Me.txtCashPayment.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashPayment.Location = New System.Drawing.Point(144, 166)
        Me.txtCashPayment.Name = "txtCashPayment"
        Me.txtCashPayment.Size = New System.Drawing.Size(205, 27)
        Me.txtCashPayment.TabIndex = 13
        Me.txtCashPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(39, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Cash Payment"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(143, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(153, 17)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Enter Payment Amount"
        '
        'txtAmountRemaining
        '
        Me.txtAmountRemaining.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountRemaining.Location = New System.Drawing.Point(143, 227)
        Me.txtAmountRemaining.Name = "txtAmountRemaining"
        Me.txtAmountRemaining.Size = New System.Drawing.Size(206, 27)
        Me.txtAmountRemaining.TabIndex = 16
        Me.txtAmountRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(50, 233)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 17)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Amount Due"
        '
        'frmClearDebt
        '
        Me.AcceptButton = Me.btnPay
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(445, 388)
        Me.Controls.Add(Me.txtAmountRemaining)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCashPayment)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtBankDeposit)
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
    Friend WithEvents txtBankDeposit As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCashPayment As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtAmountRemaining As TextBox
    Friend WithEvents Label8 As Label
End Class
