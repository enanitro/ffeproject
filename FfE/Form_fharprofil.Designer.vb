<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_fharprofil
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.select_id = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.drive_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Colour = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.failure = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Km = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.speed = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Time = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1264, 625)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(22, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1218, 577)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fharprofil ID"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.select_id, Me.drive_id, Me.Colour, Me.failure, Me.Km, Me.speed, Me.Time})
        Me.DataGridView1.Location = New System.Drawing.Point(16, 29)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(477, 383)
        Me.DataGridView1.TabIndex = 0
        '
        'select_id
        '
        Me.select_id.HeaderText = ""
        Me.select_id.Name = "select_id"
        Me.select_id.ReadOnly = True
        Me.select_id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.select_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.select_id.Width = 30
        '
        'drive_id
        '
        Me.drive_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.drive_id.HeaderText = "Drive ID"
        Me.drive_id.Name = "drive_id"
        Me.drive_id.ReadOnly = True
        Me.drive_id.Width = 83
        '
        'Colour
        '
        Me.Colour.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Colour.HeaderText = "Colour"
        Me.Colour.Name = "Colour"
        Me.Colour.ReadOnly = True
        Me.Colour.Width = 74
        '
        'failure
        '
        Me.failure.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.failure.HeaderText = "Failure"
        Me.failure.Name = "failure"
        Me.failure.ReadOnly = True
        Me.failure.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.failure.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.failure.Width = 77
        '
        'Km
        '
        Me.Km.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Km.HeaderText = "Km"
        Me.Km.Name = "Km"
        Me.Km.ReadOnly = True
        Me.Km.Width = 70
        '
        'speed
        '
        Me.speed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.speed.HeaderText = "Speed"
        Me.speed.Name = "speed"
        Me.speed.ReadOnly = True
        Me.speed.Width = 73
        '
        'Time
        '
        Me.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Time.HeaderText = "Time"
        Me.Time.Name = "Time"
        Me.Time.ReadOnly = True
        Me.Time.Width = 64
        '
        'Form_fharprofil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1264, 625)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form_fharprofil"
        Me.Text = "Fharprofil"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents select_id As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents drive_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colour As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents failure As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Km As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents speed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Time As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
