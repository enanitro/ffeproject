<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FfE_Main
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.DriveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FahrprofileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MeasureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator
        Me.ConnectionToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.OperationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AverageEnergyConsumptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AverageSpeedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChargedEnergyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NChargerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NSystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BRecuperationSystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VtDxdtdxGPSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AtDvdtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 431)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(632, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(93, 17)
        Me.ToolStripStatusLabel.Text = "Wellcome to FfE"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DriveToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.OperationsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(632, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DriveToolStripMenuItem
        '
        Me.DriveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.HistoryToolStripMenuItem})
        Me.DriveToolStripMenuItem.Name = "DriveToolStripMenuItem"
        Me.DriveToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DriveToolStripMenuItem.Text = "Drive"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.NewToolStripMenuItem.Text = "View"
        '
        'HistoryToolStripMenuItem
        '
        Me.HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem"
        Me.HistoryToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.HistoryToolStripMenuItem.Text = "History"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserToolStripMenuItem, Me.CarToolStripMenuItem, Me.FahrprofileToolStripMenuItem, Me.MeasureToolStripMenuItem, Me.ConnectionToolStripMenuItem, Me.ConnectionToolStripMenuItem1})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
        Me.OptionsToolStripMenuItem.Text = "Configuration"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.UserToolStripMenuItem.Text = "User"
        '
        'CarToolStripMenuItem
        '
        Me.CarToolStripMenuItem.Name = "CarToolStripMenuItem"
        Me.CarToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.CarToolStripMenuItem.Text = "Car"
        '
        'FahrprofileToolStripMenuItem
        '
        Me.FahrprofileToolStripMenuItem.Name = "FahrprofileToolStripMenuItem"
        Me.FahrprofileToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.FahrprofileToolStripMenuItem.Text = "Usage type"
        '
        'MeasureToolStripMenuItem
        '
        Me.MeasureToolStripMenuItem.Name = "MeasureToolStripMenuItem"
        Me.MeasureToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.MeasureToolStripMenuItem.Text = "Measure"
        '
        'ConnectionToolStripMenuItem
        '
        Me.ConnectionToolStripMenuItem.Name = "ConnectionToolStripMenuItem"
        Me.ConnectionToolStripMenuItem.Size = New System.Drawing.Size(133, 6)
        '
        'ConnectionToolStripMenuItem1
        '
        Me.ConnectionToolStripMenuItem1.Name = "ConnectionToolStripMenuItem1"
        Me.ConnectionToolStripMenuItem1.Size = New System.Drawing.Size(136, 22)
        Me.ConnectionToolStripMenuItem1.Text = "Connection"
        '
        'OperationsToolStripMenuItem
        '
        Me.OperationsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AverageEnergyConsumptionToolStripMenuItem, Me.AverageSpeedToolStripMenuItem, Me.ChargedEnergyToolStripMenuItem, Me.NChargerToolStripMenuItem, Me.NSystemToolStripMenuItem, Me.BRecuperationSystemToolStripMenuItem, Me.EToolStripMenuItem, Me.VtDxdtdxGPSToolStripMenuItem, Me.AtDvdtToolStripMenuItem})
        Me.OperationsToolStripMenuItem.Name = "OperationsToolStripMenuItem"
        Me.OperationsToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.OperationsToolStripMenuItem.Text = "Operations"
        '
        'AverageEnergyConsumptionToolStripMenuItem
        '
        Me.AverageEnergyConsumptionToolStripMenuItem.Name = "AverageEnergyConsumptionToolStripMenuItem"
        Me.AverageEnergyConsumptionToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.AverageEnergyConsumptionToolStripMenuItem.Text = "Average energy consumption"
        '
        'AverageSpeedToolStripMenuItem
        '
        Me.AverageSpeedToolStripMenuItem.Name = "AverageSpeedToolStripMenuItem"
        Me.AverageSpeedToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.AverageSpeedToolStripMenuItem.Text = "Average speed"
        '
        'ChargedEnergyToolStripMenuItem
        '
        Me.ChargedEnergyToolStripMenuItem.Name = "ChargedEnergyToolStripMenuItem"
        Me.ChargedEnergyToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ChargedEnergyToolStripMenuItem.Text = "Charged energy"
        '
        'NChargerToolStripMenuItem
        '
        Me.NChargerToolStripMenuItem.Name = "NChargerToolStripMenuItem"
        Me.NChargerToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.NChargerToolStripMenuItem.Text = "n charger"
        '
        'NSystemToolStripMenuItem
        '
        Me.NSystemToolStripMenuItem.Name = "NSystemToolStripMenuItem"
        Me.NSystemToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.NSystemToolStripMenuItem.Text = "n system"
        '
        'BRecuperationSystemToolStripMenuItem
        '
        Me.BRecuperationSystemToolStripMenuItem.Name = "BRecuperationSystemToolStripMenuItem"
        Me.BRecuperationSystemToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.BRecuperationSystemToolStripMenuItem.Text = "n recuperation system"
        '
        'EToolStripMenuItem
        '
        Me.EToolStripMenuItem.Name = "EToolStripMenuItem"
        Me.EToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.EToolStripMenuItem.Text = "Energy recuperated/100Km"
        '
        'VtDxdtdxGPSToolStripMenuItem
        '
        Me.VtDxdtdxGPSToolStripMenuItem.Name = "VtDxdtdxGPSToolStripMenuItem"
        Me.VtDxdtdxGPSToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.VtDxdtdxGPSToolStripMenuItem.Text = "V(t) = dx/dt (dx · GPS)"
        '
        'AtDvdtToolStripMenuItem
        '
        Me.AtDvdtToolStripMenuItem.Name = "AtDvdtToolStripMenuItem"
        Me.AtDvdtToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.AtDvdtToolStripMenuItem.Text = "A(t) = dv/dt"
        '
        'FfE_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.Name = "FfE_Main"
        Me.Text = "FfE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AverageEnergyConsumptionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AverageSpeedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChargedEnergyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NChargerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NSystemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BRecuperationSystemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VtDxdtdxGPSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AtDvdtToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FahrprofileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents DriveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConnectionToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ConnectionToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MeasureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
