<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompanyClass
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
        Me.Button6 = New System.Windows.Forms.Button()
        Me.dtgrdDepartment = New System.Windows.Forms.DataGridView()
        Me.colCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dtgrdDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(623, 550)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 51)
        Me.Button6.TabIndex = 21
        Me.Button6.Text = "Back"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'dtgrdDepartment
        '
        Me.dtgrdDepartment.AllowUserToAddRows = False
        Me.dtgrdDepartment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgrdDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgrdDepartment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCode, Me.colName})
        Me.dtgrdDepartment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgrdDepartment.Location = New System.Drawing.Point(44, 271)
        Me.dtgrdDepartment.Name = "dtgrdDepartment"
        Me.dtgrdDepartment.RowTemplate.Height = 24
        Me.dtgrdDepartment.Size = New System.Drawing.Size(654, 273)
        Me.dtgrdDepartment.TabIndex = 20
        '
        'colCode
        '
        Me.colCode.HeaderText = "Department Code"
        Me.colCode.Name = "colCode"
        Me.colCode.ReadOnly = True
        '
        'colName
        '
        Me.colName.HeaderText = "Department Name"
        Me.colName.Name = "colName"
        Me.colName.ReadOnly = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(623, 156)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 51)
        Me.Button5.TabIndex = 19
        Me.Button5.Text = "Save"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(521, 156)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 51)
        Me.Button4.TabIndex = 18
        Me.Button4.Text = "Delete"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(414, 156)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 51)
        Me.Button3.TabIndex = 17
        Me.Button3.Text = "Edit"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(307, 156)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 51)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Add New"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(593, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 62)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(173, 83)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(316, 22)
        Me.TextBox2.TabIndex = 14
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(173, 43)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(316, 22)
        Me.TextBox1.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Department Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Department Code"
        '
        'frmCompanyClass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 644)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.dtgrdDepartment)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCompanyClass"
        Me.Text = "frmCompanyClass"
        CType(Me.dtgrdDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button6 As Button
    Friend WithEvents dtgrdDepartment As DataGridView
    Friend WithEvents colCode As DataGridViewTextBoxColumn
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
