<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fharprofilGraphic
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Pane = New ZedGraph.ZedGraphControl
        Me.SuspendLayout()
        '
        'Pane
        '
        Me.Pane.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pane.Location = New System.Drawing.Point(0, 0)
        Me.Pane.Name = "Pane"
        Me.Pane.ScrollGrace = 0
        Me.Pane.ScrollMaxX = 0
        Me.Pane.ScrollMaxY = 0
        Me.Pane.ScrollMaxY2 = 0
        Me.Pane.ScrollMinX = 0
        Me.Pane.ScrollMinY = 0
        Me.Pane.ScrollMinY2 = 0
        Me.Pane.Size = New System.Drawing.Size(522, 383)
        Me.Pane.TabIndex = 0
        '
        'fharprofilGraphic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Pane)
        Me.Name = "fharprofilGraphic"
        Me.Size = New System.Drawing.Size(522, 383)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pane As ZedGraph.ZedGraphControl

End Class
