<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class From_Conf_User
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
        Dim VornameLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim EmailLabel As System.Windows.Forms.Label
        Dim LinkLabel As System.Windows.Forms.Label
        Dim Ma_artLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(From_Conf_User))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Ma_artTextBox = New System.Windows.Forms.TextBox
        Me.UserBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ffe_databaseDataSet = New FfE.ffe_databaseDataSet
        Me.LinkTextBox = New System.Windows.Forms.TextBox
        Me.EmailTextBox = New System.Windows.Forms.TextBox
        Me.UserDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PhotoPictureBox = New System.Windows.Forms.PictureBox
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.VornameTextBox = New System.Windows.Forms.TextBox
        Me.UserBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.UserBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.Delete = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.UserTableAdapter = New FfE.ffe_databaseDataSetTableAdapters.userTableAdapter
        Me.TableAdapterManager = New FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager
        VornameLabel = New System.Windows.Forms.Label
        NameLabel = New System.Windows.Forms.Label
        EmailLabel = New System.Windows.Forms.Label
        LinkLabel = New System.Windows.Forms.Label
        Ma_artLabel = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.UserBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ffe_databaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PhotoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UserBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'VornameLabel
        '
        VornameLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        VornameLabel.AutoSize = True
        VornameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        VornameLabel.Location = New System.Drawing.Point(63, 35)
        VornameLabel.Name = "VornameLabel"
        VornameLabel.Size = New System.Drawing.Size(49, 15)
        VornameLabel.TabIndex = 4
        VornameLabel.Text = "Name:"
        '
        'NameLabel
        '
        NameLabel.AutoSize = True
        NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        NameLabel.Location = New System.Drawing.Point(43, 63)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(69, 15)
        NameLabel.TabIndex = 5
        NameLabel.Text = "Surname:"
        '
        'EmailLabel
        '
        EmailLabel.AutoSize = True
        EmailLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        EmailLabel.Location = New System.Drawing.Point(64, 91)
        EmailLabel.Name = "EmailLabel"
        EmailLabel.Size = New System.Drawing.Size(48, 15)
        EmailLabel.TabIndex = 11
        EmailLabel.Text = "Email:"
        '
        'LinkLabel
        '
        LinkLabel.AutoSize = True
        LinkLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        LinkLabel.Location = New System.Drawing.Point(74, 119)
        LinkLabel.Name = "LinkLabel"
        LinkLabel.Size = New System.Drawing.Size(38, 15)
        LinkLabel.TabIndex = 12
        LinkLabel.Text = "Link:"
        '
        'Ma_artLabel
        '
        Ma_artLabel.AutoSize = True
        Ma_artLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Ma_artLabel.Location = New System.Drawing.Point(54, 147)
        Ma_artLabel.Name = "Ma_artLabel"
        Ma_artLabel.Size = New System.Drawing.Size(58, 15)
        Ma_artLabel.TabIndex = 13
        Ma_artLabel.Text = "Partner:"
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.Controls.Add(Ma_artLabel)
        Me.Panel1.Controls.Add(Me.Ma_artTextBox)
        Me.Panel1.Controls.Add(LinkLabel)
        Me.Panel1.Controls.Add(Me.LinkTextBox)
        Me.Panel1.Controls.Add(EmailLabel)
        Me.Panel1.Controls.Add(Me.EmailTextBox)
        Me.Panel1.Controls.Add(Me.UserDataGridView)
        Me.Panel1.Controls.Add(Me.PhotoPictureBox)
        Me.Panel1.Controls.Add(NameLabel)
        Me.Panel1.Controls.Add(Me.NameTextBox)
        Me.Panel1.Controls.Add(VornameLabel)
        Me.Panel1.Controls.Add(Me.VornameTextBox)
        Me.Panel1.Controls.Add(Me.UserBindingNavigator)
        Me.Panel1.Location = New System.Drawing.Point(15, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(660, 518)
        Me.Panel1.TabIndex = 0
        '
        'Ma_artTextBox
        '
        Me.Ma_artTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserBindingSource, "ma_art", True))
        Me.Ma_artTextBox.Location = New System.Drawing.Point(113, 145)
        Me.Ma_artTextBox.MaxLength = 45
        Me.Ma_artTextBox.Name = "Ma_artTextBox"
        Me.Ma_artTextBox.Size = New System.Drawing.Size(249, 20)
        Me.Ma_artTextBox.TabIndex = 9
        '
        'UserBindingSource
        '
        Me.UserBindingSource.DataMember = "user"
        Me.UserBindingSource.DataSource = Me.Ffe_databaseDataSet
        '
        'Ffe_databaseDataSet
        '
        Me.Ffe_databaseDataSet.DataSetName = "ffe_databaseDataSet"
        Me.Ffe_databaseDataSet.Locale = New System.Globalization.CultureInfo("es-ES")
        Me.Ffe_databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LinkTextBox
        '
        Me.LinkTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserBindingSource, "link", True))
        Me.LinkTextBox.Location = New System.Drawing.Point(113, 117)
        Me.LinkTextBox.MaxLength = 45
        Me.LinkTextBox.Name = "LinkTextBox"
        Me.LinkTextBox.Size = New System.Drawing.Size(348, 20)
        Me.LinkTextBox.TabIndex = 8
        '
        'EmailTextBox
        '
        Me.EmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserBindingSource, "email", True))
        Me.EmailTextBox.Location = New System.Drawing.Point(113, 89)
        Me.EmailTextBox.MaxLength = 45
        Me.EmailTextBox.Name = "EmailTextBox"
        Me.EmailTextBox.Size = New System.Drawing.Size(249, 20)
        Me.EmailTextBox.TabIndex = 7
        '
        'UserDataGridView
        '
        Me.UserDataGridView.AllowUserToAddRows = False
        Me.UserDataGridView.AllowUserToDeleteRows = False
        Me.UserDataGridView.AutoGenerateColumns = False
        Me.UserDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UserDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.UserDataGridView.DataSource = Me.UserBindingSource
        Me.UserDataGridView.Location = New System.Drawing.Point(25, 208)
        Me.UserDataGridView.Name = "UserDataGridView"
        Me.UserDataGridView.Size = New System.Drawing.Size(613, 220)
        Me.UserDataGridView.TabIndex = 11
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "user_id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "User_id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "vorname"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "name"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Surname"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "email"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Email"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "link"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Link"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ma_art"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Partner"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'PhotoPictureBox
        '
        Me.PhotoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PhotoPictureBox.BackgroundImage = CType(resources.GetObject("PhotoPictureBox.BackgroundImage"), System.Drawing.Image)
        Me.PhotoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PhotoPictureBox.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.UserBindingSource, "photo", True))
        Me.PhotoPictureBox.Location = New System.Drawing.Point(496, 22)
        Me.PhotoPictureBox.Name = "PhotoPictureBox"
        Me.PhotoPictureBox.Size = New System.Drawing.Size(142, 169)
        Me.PhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PhotoPictureBox.TabIndex = 11
        Me.PhotoPictureBox.TabStop = False
        '
        'NameTextBox
        '
        Me.NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserBindingSource, "name", True))
        Me.NameTextBox.Location = New System.Drawing.Point(113, 61)
        Me.NameTextBox.MaxLength = 50
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(348, 20)
        Me.NameTextBox.TabIndex = 6
        '
        'VornameTextBox
        '
        Me.VornameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.VornameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserBindingSource, "vorname", True))
        Me.VornameTextBox.Location = New System.Drawing.Point(113, 33)
        Me.VornameTextBox.MaxLength = 30
        Me.VornameTextBox.Name = "VornameTextBox"
        Me.VornameTextBox.Size = New System.Drawing.Size(249, 20)
        Me.VornameTextBox.TabIndex = 5
        '
        'UserBindingNavigator
        '
        Me.UserBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.UserBindingNavigator.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.UserBindingNavigator.AutoSize = False
        Me.UserBindingNavigator.BindingSource = Me.UserBindingSource
        Me.UserBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.UserBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.UserBindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.UserBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorAddNewItem, Me.UserBindingNavigatorSaveItem, Me.Delete, Me.BindingNavigatorDeleteItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem})
        Me.UserBindingNavigator.Location = New System.Drawing.Point(22, 446)
        Me.UserBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.UserBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.UserBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.UserBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.UserBindingNavigator.Name = "UserBindingNavigator"
        Me.UserBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.UserBindingNavigator.Size = New System.Drawing.Size(616, 52)
        Me.UserBindingNavigator.TabIndex = 1
        Me.UserBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.AutoSize = False
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(80, 49)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(56, 49)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.AutoSize = False
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(0, 0)
        Me.BindingNavigatorDeleteItem.Text = "Eliminar"
        Me.BindingNavigatorDeleteItem.Visible = False
        '
        'UserBindingNavigatorSaveItem
        '
        Me.UserBindingNavigatorSaveItem.AutoSize = False
        Me.UserBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UserBindingNavigatorSaveItem.Image = CType(resources.GetObject("UserBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.UserBindingNavigatorSaveItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.UserBindingNavigatorSaveItem.Name = "UserBindingNavigatorSaveItem"
        Me.UserBindingNavigatorSaveItem.Size = New System.Drawing.Size(80, 49)
        Me.UserBindingNavigatorSaveItem.Text = "Save"
        Me.UserBindingNavigatorSaveItem.ToolTipText = "Save data"
        '
        'Delete
        '
        Me.Delete.AutoSize = False
        Me.Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Delete.Image = Global.FfE.My.Resources.Resources.delete_person
        Me.Delete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Delete.ImageTransparentColor = System.Drawing.Color.White
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(80, 49)
        Me.Delete.Text = "Delete"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 52)
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(52, 49)
        Me.BindingNavigatorMoveFirstItem.Text = "First"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(52, 49)
        Me.BindingNavigatorMovePreviousItem.Text = "Back"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 52)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posición"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(25, 33)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Posición actual"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 52)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(52, 49)
        Me.BindingNavigatorMoveNextItem.Text = "Next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(52, 49)
        Me.BindingNavigatorMoveLastItem.Text = "Last"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'UserTableAdapter
        '
        Me.UserTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.usage_typeTableAdapter = Nothing
        Me.TableAdapterManager.userTableAdapter = Me.UserTableAdapter
        '
        'From_Conf_User
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(690, 564)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "From_Conf_User"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "User configuration"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.UserBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ffe_databaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PhotoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UserBindingNavigator.ResumeLayout(False)
        Me.UserBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Ffe_databaseDataSet As FfE.ffe_databaseDataSet
    Friend WithEvents UserBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UserTableAdapter As FfE.ffe_databaseDataSetTableAdapters.userTableAdapter
    Friend WithEvents TableAdapterManager As FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager
    Friend WithEvents UserBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UserBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents VornameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PhotoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UserDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Ma_artTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LinkTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
