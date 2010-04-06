<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_conf_usage_type
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
        Dim Usage_in_projectLabel As System.Windows.Forms.Label
        Dim DescriptionLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Me.Ffe_databaseDataSet = New FfE.ffe_databaseDataSet
        Me.Usage_typeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usage_typeTableAdapter = New FfE.ffe_databaseDataSetTableAdapters.usage_typeTableAdapter
        Me.TableAdapterManager = New FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Usage_typeBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.Usage_typeBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.Delete = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.Usage_typeDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Usage_in_projectTextBox = New System.Windows.Forms.TextBox
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Usage_in_projectLabel = New System.Windows.Forms.Label
        DescriptionLabel = New System.Windows.Forms.Label
        NameLabel = New System.Windows.Forms.Label
        CType(Me.Ffe_databaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Usage_typeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Usage_typeBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Usage_typeBindingNavigator.SuspendLayout()
        CType(Me.Usage_typeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Usage_in_projectLabel
        '
        Usage_in_projectLabel.AutoSize = True
        Usage_in_projectLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Usage_in_projectLabel.Location = New System.Drawing.Point(19, 68)
        Usage_in_projectLabel.Name = "Usage_in_projectLabel"
        Usage_in_projectLabel.Size = New System.Drawing.Size(116, 15)
        Usage_in_projectLabel.TabIndex = 15
        Usage_in_projectLabel.Text = "Usage in project:"
        '
        'DescriptionLabel
        '
        DescriptionLabel.AutoSize = True
        DescriptionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        DescriptionLabel.Location = New System.Drawing.Point(294, 33)
        DescriptionLabel.Name = "DescriptionLabel"
        DescriptionLabel.Size = New System.Drawing.Size(84, 15)
        DescriptionLabel.TabIndex = 13
        DescriptionLabel.Text = "Description:"
        '
        'NameLabel
        '
        NameLabel.AutoSize = True
        NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        NameLabel.Location = New System.Drawing.Point(86, 32)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(49, 15)
        NameLabel.TabIndex = 11
        NameLabel.Text = "Name:"
        '
        'Ffe_databaseDataSet
        '
        Me.Ffe_databaseDataSet.DataSetName = "ffe_databaseDataSet"
        Me.Ffe_databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Usage_typeBindingSource
        '
        Me.Usage_typeBindingSource.DataMember = "usage_type"
        Me.Usage_typeBindingSource.DataSource = Me.Ffe_databaseDataSet
        '
        'Usage_typeTableAdapter
        '
        Me.Usage_typeTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.measureTableAdapter = Nothing
        Me.TableAdapterManager.photosTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.usage_typeTableAdapter = Me.Usage_typeTableAdapter
        Me.TableAdapterManager.userTableAdapter = Nothing
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.Controls.Add(Me.Usage_typeBindingNavigator)
        Me.Panel1.Controls.Add(Me.Usage_typeDataGridView)
        Me.Panel1.Controls.Add(Usage_in_projectLabel)
        Me.Panel1.Controls.Add(Me.Usage_in_projectTextBox)
        Me.Panel1.Controls.Add(DescriptionLabel)
        Me.Panel1.Controls.Add(Me.DescriptionTextBox)
        Me.Panel1.Controls.Add(NameLabel)
        Me.Panel1.Controls.Add(Me.NameTextBox)
        Me.Panel1.Location = New System.Drawing.Point(21, 22)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(590, 368)
        Me.Panel1.TabIndex = 0
        '
        'Usage_typeBindingNavigator
        '
        Me.Usage_typeBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.Usage_typeBindingNavigator.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Usage_typeBindingNavigator.AutoSize = False
        Me.Usage_typeBindingNavigator.BindingSource = Me.Usage_typeBindingSource
        Me.Usage_typeBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.Usage_typeBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.Usage_typeBindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.Usage_typeBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorAddNewItem, Me.Usage_typeBindingNavigatorSaveItem, Me.Delete, Me.BindingNavigatorDeleteItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem})
        Me.Usage_typeBindingNavigator.Location = New System.Drawing.Point(42, 297)
        Me.Usage_typeBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.Usage_typeBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.Usage_typeBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.Usage_typeBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.Usage_typeBindingNavigator.Name = "Usage_typeBindingNavigator"
        Me.Usage_typeBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.Usage_typeBindingNavigator.Size = New System.Drawing.Size(505, 54)
        Me.Usage_typeBindingNavigator.TabIndex = 10
        Me.Usage_typeBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.AutoSize = False
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = Global.FfE.My.Resources.Resources.add_usage
        Me.BindingNavigatorAddNewItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(52, 49)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.AutoSize = False
        Me.BindingNavigatorCountItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        'Usage_typeBindingNavigatorSaveItem
        '
        Me.Usage_typeBindingNavigatorSaveItem.AutoSize = False
        Me.Usage_typeBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Usage_typeBindingNavigatorSaveItem.Image = Global.FfE.My.Resources.Resources.save_usage
        Me.Usage_typeBindingNavigatorSaveItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Usage_typeBindingNavigatorSaveItem.Name = "Usage_typeBindingNavigatorSaveItem"
        Me.Usage_typeBindingNavigatorSaveItem.Size = New System.Drawing.Size(52, 49)
        Me.Usage_typeBindingNavigatorSaveItem.Text = "Save"
        '
        'Delete
        '
        Me.Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Delete.Image = Global.FfE.My.Resources.Resources.del_usage
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
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(39, 29)
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
        'Usage_typeDataGridView
        '
        Me.Usage_typeDataGridView.AllowUserToAddRows = False
        Me.Usage_typeDataGridView.AllowUserToDeleteRows = False
        Me.Usage_typeDataGridView.AutoGenerateColumns = False
        Me.Usage_typeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Usage_typeDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn3})
        Me.Usage_typeDataGridView.DataSource = Me.Usage_typeBindingSource
        Me.Usage_typeDataGridView.Location = New System.Drawing.Point(22, 117)
        Me.Usage_typeDataGridView.Name = "Usage_typeDataGridView"
        Me.Usage_typeDataGridView.Size = New System.Drawing.Size(538, 158)
        Me.Usage_typeDataGridView.TabIndex = 17
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "usage_type_id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Usage type id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "name"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "usage_in_project"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Usage in project"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 125
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "description"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 175
        '
        'Usage_in_projectTextBox
        '
        Me.Usage_in_projectTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Usage_typeBindingSource, "usage_in_project", True))
        Me.Usage_in_projectTextBox.Location = New System.Drawing.Point(141, 68)
        Me.Usage_in_projectTextBox.MaxLength = 50
        Me.Usage_in_projectTextBox.Name = "Usage_in_projectTextBox"
        Me.Usage_in_projectTextBox.Size = New System.Drawing.Size(123, 20)
        Me.Usage_in_projectTextBox.TabIndex = 16
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Usage_typeBindingSource, "description", True))
        Me.DescriptionTextBox.Location = New System.Drawing.Point(384, 31)
        Me.DescriptionTextBox.MaxLength = 250
        Me.DescriptionTextBox.Multiline = True
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.Size = New System.Drawing.Size(176, 56)
        Me.DescriptionTextBox.TabIndex = 14
        '
        'NameTextBox
        '
        Me.NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Usage_typeBindingSource, "name", True))
        Me.NameTextBox.Location = New System.Drawing.Point(141, 32)
        Me.NameTextBox.MaxLength = 50
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(123, 20)
        Me.NameTextBox.TabIndex = 12
        '
        'Form_conf_usage_type
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(623, 401)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form_conf_usage_type"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Usage type configuration"
        CType(Me.Ffe_databaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Usage_typeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Usage_typeBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Usage_typeBindingNavigator.ResumeLayout(False)
        Me.Usage_typeBindingNavigator.PerformLayout()
        CType(Me.Usage_typeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Ffe_databaseDataSet As FfE.ffe_databaseDataSet
    Friend WithEvents Usage_typeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Usage_typeTableAdapter As FfE.ffe_databaseDataSetTableAdapters.usage_typeTableAdapter
    Friend WithEvents TableAdapterManager As FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Usage_typeBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents Usage_typeBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents Delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents Usage_typeDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usage_in_projectTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
End Class
