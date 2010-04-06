<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Conf_Measure
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
        Dim DescriptionLabel As System.Windows.Forms.Label
        Dim UnitLabel As System.Windows.Forms.Label
        Dim SteptimeLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Ffe_databaseDataSet = New FfE.ffe_databaseDataSet
        Me.MeasureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MeasureTableAdapter = New FfE.ffe_databaseDataSetTableAdapters.measureTableAdapter
        Me.TableAdapterManager = New FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.MeasureBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.MeasureBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.Delete = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox
        Me.UnitTextBox = New System.Windows.Forms.TextBox
        Me.SteptimeTextBox = New System.Windows.Forms.TextBox
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.MeasureDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.timestep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        DescriptionLabel = New System.Windows.Forms.Label
        UnitLabel = New System.Windows.Forms.Label
        SteptimeLabel = New System.Windows.Forms.Label
        NameLabel = New System.Windows.Forms.Label
        CType(Me.Ffe_databaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MeasureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.MeasureBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MeasureBindingNavigator.SuspendLayout()
        CType(Me.MeasureDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DescriptionLabel
        '
        DescriptionLabel.AutoSize = True
        DescriptionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        DescriptionLabel.Location = New System.Drawing.Point(400, 69)
        DescriptionLabel.Name = "DescriptionLabel"
        DescriptionLabel.Size = New System.Drawing.Size(84, 15)
        DescriptionLabel.TabIndex = 20
        DescriptionLabel.Text = "Description:"
        '
        'UnitLabel
        '
        UnitLabel.AutoSize = True
        UnitLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        UnitLabel.Location = New System.Drawing.Point(450, 30)
        UnitLabel.Name = "UnitLabel"
        UnitLabel.Size = New System.Drawing.Size(37, 15)
        UnitLabel.TabIndex = 18
        UnitLabel.Text = "Unit:"
        '
        'SteptimeLabel
        '
        SteptimeLabel.AutoSize = True
        SteptimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        SteptimeLabel.Location = New System.Drawing.Point(38, 68)
        SteptimeLabel.Name = "SteptimeLabel"
        SteptimeLabel.Size = New System.Drawing.Size(74, 15)
        SteptimeLabel.TabIndex = 16
        SteptimeLabel.Text = "Time step:"
        '
        'NameLabel
        '
        NameLabel.AutoSize = True
        NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        NameLabel.Location = New System.Drawing.Point(62, 34)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(49, 15)
        NameLabel.TabIndex = 14
        NameLabel.Text = "Name:"
        '
        'Ffe_databaseDataSet
        '
        Me.Ffe_databaseDataSet.DataSetName = "ffe_databaseDataSet"
        Me.Ffe_databaseDataSet.Locale = New System.Globalization.CultureInfo("es-ES")
        Me.Ffe_databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MeasureBindingSource
        '
        Me.MeasureBindingSource.DataMember = "measure"
        Me.MeasureBindingSource.DataSource = Me.Ffe_databaseDataSet
        '
        'MeasureTableAdapter
        '
        Me.MeasureTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.carTableAdapter = Nothing
        Me.TableAdapterManager.channel_nameTableAdapter = Nothing
        Me.TableAdapterManager.copy_dataTableAdapter = Nothing
        Me.TableAdapterManager.dataTableAdapter = Nothing
        Me.TableAdapterManager.driveTableAdapter = Nothing
        Me.TableAdapterManager.ids_canbusTableAdapter = Nothing
        Me.TableAdapterManager.loggerTableAdapter = Nothing
        Me.TableAdapterManager.measureTableAdapter = Me.MeasureTableAdapter
        Me.TableAdapterManager.photosTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.usage_typeTableAdapter = Nothing
        Me.TableAdapterManager.userTableAdapter = Nothing
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.Controls.Add(Me.MeasureBindingNavigator)
        Me.Panel1.Controls.Add(DescriptionLabel)
        Me.Panel1.Controls.Add(Me.DescriptionTextBox)
        Me.Panel1.Controls.Add(UnitLabel)
        Me.Panel1.Controls.Add(Me.UnitTextBox)
        Me.Panel1.Controls.Add(SteptimeLabel)
        Me.Panel1.Controls.Add(Me.SteptimeTextBox)
        Me.Panel1.Controls.Add(NameLabel)
        Me.Panel1.Controls.Add(Me.NameTextBox)
        Me.Panel1.Controls.Add(Me.MeasureDataGridView)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(735, 364)
        Me.Panel1.TabIndex = 0
        '
        'MeasureBindingNavigator
        '
        Me.MeasureBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.MeasureBindingNavigator.AutoSize = False
        Me.MeasureBindingNavigator.BindingSource = Me.MeasureBindingSource
        Me.MeasureBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.MeasureBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.MeasureBindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.MeasureBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorAddNewItem, Me.MeasureBindingNavigatorSaveItem, Me.Delete, Me.BindingNavigatorDeleteItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem})
        Me.MeasureBindingNavigator.Location = New System.Drawing.Point(115, 286)
        Me.MeasureBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.MeasureBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.MeasureBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.MeasureBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.MeasureBindingNavigator.Name = "MeasureBindingNavigator"
        Me.MeasureBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.MeasureBindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MeasureBindingNavigator.Size = New System.Drawing.Size(504, 54)
        Me.MeasureBindingNavigator.TabIndex = 12
        Me.MeasureBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.AutoSize = False
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = Global.FfE.My.Resources.Resources.add_rule
        Me.BindingNavigatorAddNewItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(52, 49)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.AutoSize = False
        Me.BindingNavigatorCountItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(52, 49)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.AutoSize = False
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(0, 0)
        Me.BindingNavigatorDeleteItem.Text = "Eliminar"
        Me.BindingNavigatorDeleteItem.Visible = False
        '
        'MeasureBindingNavigatorSaveItem
        '
        Me.MeasureBindingNavigatorSaveItem.AutoSize = False
        Me.MeasureBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MeasureBindingNavigatorSaveItem.Image = Global.FfE.My.Resources.Resources.save_rule
        Me.MeasureBindingNavigatorSaveItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MeasureBindingNavigatorSaveItem.Name = "MeasureBindingNavigatorSaveItem"
        Me.MeasureBindingNavigatorSaveItem.Size = New System.Drawing.Size(52, 49)
        Me.MeasureBindingNavigatorSaveItem.Text = "Save"
        '
        'Delete
        '
        Me.Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Delete.Image = Global.FfE.My.Resources.Resources.del_rule
        Me.Delete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Delete.ImageTransparentColor = System.Drawing.Color.White
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(52, 51)
        Me.Delete.Text = "Delete"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.AutoSize = False
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = Global.FfE.My.Resources.Resources.img_first
        Me.BindingNavigatorMoveFirstItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(52, 49)
        Me.BindingNavigatorMoveFirstItem.Text = "First"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.AutoSize = False
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = Global.FfE.My.Resources.Resources.img_back
        Me.BindingNavigatorMovePreviousItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(52, 49)
        Me.BindingNavigatorMovePreviousItem.Text = "Back"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 54)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posición"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(39, 33)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Posición actual"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 54)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.AutoSize = False
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = Global.FfE.My.Resources.Resources.img_next
        Me.BindingNavigatorMoveNextItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(52, 49)
        Me.BindingNavigatorMoveNextItem.Text = "Next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.AutoSize = False
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = Global.FfE.My.Resources.Resources.img_last
        Me.BindingNavigatorMoveLastItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(52, 49)
        Me.BindingNavigatorMoveLastItem.Text = "Last"
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MeasureBindingSource, "description", True))
        Me.DescriptionTextBox.Location = New System.Drawing.Point(490, 68)
        Me.DescriptionTextBox.MaxLength = 250
        Me.DescriptionTextBox.Multiline = True
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.Size = New System.Drawing.Size(203, 20)
        Me.DescriptionTextBox.TabIndex = 21
        '
        'UnitTextBox
        '
        Me.UnitTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MeasureBindingSource, "unit", True))
        Me.UnitTextBox.Location = New System.Drawing.Point(490, 29)
        Me.UnitTextBox.MaxLength = 20
        Me.UnitTextBox.Name = "UnitTextBox"
        Me.UnitTextBox.Size = New System.Drawing.Size(203, 20)
        Me.UnitTextBox.TabIndex = 19
        '
        'SteptimeTextBox
        '
        Me.SteptimeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MeasureBindingSource, "timestep", True))
        Me.SteptimeTextBox.Location = New System.Drawing.Point(115, 67)
        Me.SteptimeTextBox.MaxLength = 20
        Me.SteptimeTextBox.Name = "SteptimeTextBox"
        Me.SteptimeTextBox.Size = New System.Drawing.Size(203, 20)
        Me.SteptimeTextBox.TabIndex = 17
        '
        'NameTextBox
        '
        Me.NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MeasureBindingSource, "name", True))
        Me.NameTextBox.Location = New System.Drawing.Point(115, 31)
        Me.NameTextBox.MaxLength = 30
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(203, 20)
        Me.NameTextBox.TabIndex = 15
        '
        'MeasureDataGridView
        '
        Me.MeasureDataGridView.AllowUserToAddRows = False
        Me.MeasureDataGridView.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.MeasureDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.MeasureDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MeasureDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.MeasureDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MeasureDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.timestep, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        Me.MeasureDataGridView.DataSource = Me.MeasureBindingSource
        Me.MeasureDataGridView.Location = New System.Drawing.Point(41, 126)
        Me.MeasureDataGridView.Name = "MeasureDataGridView"
        Me.MeasureDataGridView.Size = New System.Drawing.Size(653, 136)
        Me.MeasureDataGridView.TabIndex = 13
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "measure_id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Measure id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "name"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'timestep
        '
        Me.timestep.DataPropertyName = "timestep"
        Me.timestep.HeaderText = "timestep"
        Me.timestep.Name = "timestep"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "unit"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Unit"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "description"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 1500
        '
        'Form_Conf_Measure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(759, 396)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form_Conf_Measure"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Measure configuration"
        CType(Me.Ffe_databaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MeasureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.MeasureBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MeasureBindingNavigator.ResumeLayout(False)
        Me.MeasureBindingNavigator.PerformLayout()
        CType(Me.MeasureDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Ffe_databaseDataSet As FfE.ffe_databaseDataSet
    Friend WithEvents MeasureBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MeasureTableAdapter As FfE.ffe_databaseDataSetTableAdapters.measureTableAdapter
    Friend WithEvents TableAdapterManager As FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MeasureBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents MeasureBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents Delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UnitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SteptimeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MeasureDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents timestep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
