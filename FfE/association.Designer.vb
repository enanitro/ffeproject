<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class association
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
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(20, 113)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(432, 199)
        Me.CheckedListBox1.TabIndex = 27
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(20, 88)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(86, 19)
        Me.CheckBox1.TabIndex = 28
        Me.CheckBox1.Text = "Select all"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(203, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(249, 86)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "These channels can be associated or disassociated with the measure. Select the as" & _
            "sociations/disassociations and press the correct button." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Button1.Image = Global.FfE.My.Resources.Resources.NetByte_Design_Studio___0058
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(112, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 60)
        Me.Button1.TabIndex = 30
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Button11.Image = Global.FfE.My.Resources.Resources.NetByte_Design_Studio___0072
        Me.Button11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button11.Location = New System.Drawing.Point(20, 12)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(69, 60)
        Me.Button11.TabIndex = 26
        Me.Button11.UseVisualStyleBackColor = True
        '
        'association
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(478, 333)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.Button11)
        Me.ForeColor = System.Drawing.Color.Black
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "association"
        Me.Text = "Channel-measure association"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
