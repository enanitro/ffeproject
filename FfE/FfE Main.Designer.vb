﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FahrprofileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MeasureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.CANBUSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChannelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FunctionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.KmsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConnectionToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.BackupDBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RestoreDBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DriveToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.FunctionsToolStripMenuItem, Me.DatabaseToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(632, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DriveToolStripMenuItem
        '
        Me.DriveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem})
        Me.DriveToolStripMenuItem.Name = "DriveToolStripMenuItem"
        Me.DriveToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DriveToolStripMenuItem.Text = "Drive"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.NewToolStripMenuItem.Text = "View"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserToolStripMenuItem, Me.CarToolStripMenuItem, Me.FahrprofileToolStripMenuItem, Me.MeasureToolStripMenuItem, Me.ToolStripSeparator1, Me.CANBUSToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
        Me.OptionsToolStripMenuItem.Text = "Configuration"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.UserToolStripMenuItem.Text = "User"
        '
        'CarToolStripMenuItem
        '
        Me.CarToolStripMenuItem.Name = "CarToolStripMenuItem"
        Me.CarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CarToolStripMenuItem.Text = "Car"
        '
        'FahrprofileToolStripMenuItem
        '
        Me.FahrprofileToolStripMenuItem.Name = "FahrprofileToolStripMenuItem"
        Me.FahrprofileToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FahrprofileToolStripMenuItem.Text = "Track type"
        '
        'MeasureToolStripMenuItem
        '
        Me.MeasureToolStripMenuItem.Name = "MeasureToolStripMenuItem"
        Me.MeasureToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.MeasureToolStripMenuItem.Text = "Measure"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'CANBUSToolStripMenuItem
        '
        Me.CANBUSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChannelsToolStripMenuItem})
        Me.CANBUSToolStripMenuItem.Name = "CANBUSToolStripMenuItem"
        Me.CANBUSToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CANBUSToolStripMenuItem.Text = "CAN-BUS"
        '
        'ChannelsToolStripMenuItem
        '
        Me.ChannelsToolStripMenuItem.Name = "ChannelsToolStripMenuItem"
        Me.ChannelsToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.ChannelsToolStripMenuItem.Text = "Channels"
        '
        'FunctionsToolStripMenuItem
        '
        Me.FunctionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KmsToolStripMenuItem})
        Me.FunctionsToolStripMenuItem.Name = "FunctionsToolStripMenuItem"
        Me.FunctionsToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.FunctionsToolStripMenuItem.Text = "Functions"
        '
        'KmsToolStripMenuItem
        '
        Me.KmsToolStripMenuItem.Name = "KmsToolStripMenuItem"
        Me.KmsToolStripMenuItem.Size = New System.Drawing.Size(97, 22)
        Me.KmsToolStripMenuItem.Text = "Kms"
        '
        'DatabaseToolStripMenuItem
        '
        Me.DatabaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectionToolStripMenuItem2, Me.BackupDBToolStripMenuItem, Me.RestoreDBToolStripMenuItem})
        Me.DatabaseToolStripMenuItem.Name = "DatabaseToolStripMenuItem"
        Me.DatabaseToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.DatabaseToolStripMenuItem.Text = "Database"
        '
        'ConnectionToolStripMenuItem2
        '
        Me.ConnectionToolStripMenuItem2.Name = "ConnectionToolStripMenuItem2"
        Me.ConnectionToolStripMenuItem2.Size = New System.Drawing.Size(136, 22)
        Me.ConnectionToolStripMenuItem2.Text = "Connection"
        '
        'BackupDBToolStripMenuItem
        '
        Me.BackupDBToolStripMenuItem.Name = "BackupDBToolStripMenuItem"
        Me.BackupDBToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.BackupDBToolStripMenuItem.Text = "Backup DB"
        '
        'RestoreDBToolStripMenuItem
        '
        Me.RestoreDBToolStripMenuItem.Name = "RestoreDBToolStripMenuItem"
        Me.RestoreDBToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.RestoreDBToolStripMenuItem.Text = "Restore DB"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
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
    Friend WithEvents FahrprofileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents DriveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MeasureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConnectionToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackupDBToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestoreDBToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CANBUSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChannelsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FunctionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KmsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
