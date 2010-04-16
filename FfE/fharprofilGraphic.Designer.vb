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
        Me.myPane = New ZedGraph.ZedGraphControl
        Me.SuspendLayout()
        '
        'myPane
        '
        Me.myPane.Dock = System.Windows.Forms.DockStyle.Fill
        Me.myPane.Location = New System.Drawing.Point(0, 0)
        Me.myPane.Name = "myPane"
        Me.myPane.ScrollGrace = 0
        Me.myPane.ScrollMaxX = 0
        Me.myPane.ScrollMaxY = 0
        Me.myPane.ScrollMaxY2 = 0
        Me.myPane.ScrollMinX = 0
        Me.myPane.ScrollMinY = 0
        Me.myPane.ScrollMinY2 = 0
        Me.myPane.Size = New System.Drawing.Size(522, 383)
        Me.myPane.TabIndex = 0
        '
        'fharprofilGraphic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.myPane)
        Me.Name = "fharprofilGraphic"
        Me.Size = New System.Drawing.Size(522, 383)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents myPane As ZedGraph.ZedGraphControl

End Class
