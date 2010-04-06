<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_canbus_ids
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
        Me.components = New System.ComponentModel.Container
        Dim OffsetLabel As System.Windows.Forms.Label
        Dim FactorLabel As System.Windows.Forms.Label
        Dim SignedLabel As System.Windows.Forms.Label
        Dim SequenceLabel As System.Windows.Forms.Label
        Dim LongbitsLabel As System.Windows.Forms.Label
        Dim StartbitLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim Hex_idLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_canbus_ids))
        Me.Ffe_databaseDataSet = New FfE.ffe_databaseDataSet
        Me.Ids_canbusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ids_canbusTableAdapter = New FfE.ffe_databaseDataSetTableAdapters.ids_canbusTableAdapter
        Me.TableAdapterManager = New FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.OffsetTextBox = New System.Windows.Forms.TextBox
        Me.FactorTextBox = New System.Windows.Forms.TextBox
        Me.SignedCheckBox = New System.Windows.Forms.CheckBox
        Me.SequenceTextBox = New System.Windows.Forms.TextBox
        Me.LongbitsTextBox = New System.Windows.Forms.TextBox
        Me.StartbitTextBox = New System.Windows.Forms.TextBox
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.Dec_idTextBox = New System.Windows.Forms.TextBox
        Me.Hex_idTextBox = New System.Windows.Forms.TextBox
        Me.Ids_canbusBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.Ids_canbusBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.Delete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Ids_canbusDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        OffsetLabel = New System.Windows.Forms.Label
        FactorLabel = New System.Windows.Forms.Label
        SignedLabel = New System.Windows.Forms.Label
        SequenceLabel = New System.Windows.Forms.Label
        LongbitsLabel = New System.Windows.Forms.Label
        StartbitLabel = New System.Windows.Forms.Label
        NameLabel = New System.Windows.Forms.Label
        Hex_idLabel = New System.Windows.Forms.Label
        CType(Me.Ffe_databaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ids_canbusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Ids_canbusBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ids_canbusBindingNavigator.SuspendLayout()
        CType(Me.Ids_canbusDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OffsetLabel
        '
        OffsetLabel.AutoSize = True
        OffsetLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        OffsetLabel.Location = New System.Drawing.Point(752, 52)
        OffsetLabel.Name = "OffsetLabel"
        OffsetLabel.Size = New System.Drawing.Size(48, 15)
        OffsetLabel.TabIndex = 37
        OffsetLabel.Text = "Offset:"
        '
        'FactorLabel
        '
        FactorLabel.AutoSize = True
        FactorLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FactorLabel.Location = New System.Drawing.Point(579, 52)
        FactorLabel.Name = "FactorLabel"
        FactorLabel.Size = New System.Drawing.Size(51, 15)
        FactorLabel.TabIndex = 35
        FactorLabel.Text = "Factor:"
        '
        'SignedLabel
        '
        SignedLabel.AutoSize = True
        SignedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SignedLabel.Location = New System.Drawing.Point(480, 52)
        SignedLabel.Name = "SignedLabel"
        SignedLabel.Size = New System.Drawing.Size(56, 15)
        SignedLabel.TabIndex = 33
        SignedLabel.Text = "Signed:"
        '
        'SequenceLabel
        '
        SequenceLabel.AutoSize = True
        SequenceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SequenceLabel.Location = New System.Drawing.Point(18, 84)
        SequenceLabel.Name = "SequenceLabel"
        SequenceLabel.Size = New System.Drawing.Size(75, 15)
        SequenceLabel.TabIndex = 31
        SequenceLabel.Text = "Sequence:"
        '
        'LongbitsLabel
        '
        LongbitsLabel.AutoSize = True
        LongbitsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        LongbitsLabel.Location = New System.Drawing.Point(345, 52)
        LongbitsLabel.Name = "LongbitsLabel"
        LongbitsLabel.Size = New System.Drawing.Size(43, 15)
        LongbitsLabel.TabIndex = 29
        LongbitsLabel.Text = "Long:"
        '
        'StartbitLabel
        '
        StartbitLabel.AutoSize = True
        StartbitLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        StartbitLabel.Location = New System.Drawing.Point(207, 52)
        StartbitLabel.Name = "StartbitLabel"
        StartbitLabel.Size = New System.Drawing.Size(57, 15)
        StartbitLabel.TabIndex = 27
        StartbitLabel.Text = "Startbit:"
        '
        'NameLabel
        '
        NameLabel.AutoSize = True
        NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameLabel.Location = New System.Drawing.Point(44, 17)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(49, 15)
        NameLabel.TabIndex = 25
        NameLabel.Text = "Name:"
        '
        'Hex_idLabel
        '
        Hex_idLabel.AutoSize = True
        Hex_idLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Hex_idLabel.Location = New System.Drawing.Point(41, 52)
        Hex_idLabel.Name = "Hex_idLabel"
        Hex_idLabel.Size = New System.Drawing.Size(52, 15)
        Hex_idLabel.TabIndex = 22
        Hex_idLabel.Text = "Hex id:"
        '
        'Ffe_databaseDataSet
        '
        Me.Ffe_databaseDataSet.DataSetName = "ffe_databaseDataSet"
        Me.Ffe_databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Ids_canbusBindingSource
        '
        Me.Ids_canbusBindingSource.DataMember = "ids_canbus"
        Me.Ids_canbusBindingSource.DataSource = Me.Ffe_databaseDataSet
        '
        'Ids_canbusTableAdapter
        '
        Me.Ids_canbusTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.carTableAdapter = Nothing
        Me.TableAdapterManager.channel_nameTableAdapter = Nothing
        Me.TableAdapterManager.copy_dataTableAdapter = Nothing
        Me.TableAdapterManager.dataTableAdapter = Nothing
        Me.TableAdapterManager.driveTableAdapter = Nothing
        Me.TableAdapterManager.ids_canbusTableAdapter = Me.Ids_canbusTableAdapter
        Me.TableAdapterManager.loggerTableAdapter = Nothing
        Me.TableAdapterManager.measureTableAdapter = Nothing
        Me.TableAdapterManager.photosTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.usage_typeTableAdapter = Nothing
        Me.TableAdapterManager.userTableAdapter = Nothing
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.Controls.Add(OffsetLabel)
        Me.Panel1.Controls.Add(Me.OffsetTextBox)
        Me.Panel1.Controls.Add(FactorLabel)
        Me.Panel1.Controls.Add(Me.FactorTextBox)
        Me.Panel1.Controls.Add(SignedLabel)
        Me.Panel1.Controls.Add(Me.SignedCheckBox)
        Me.Panel1.Controls.Add(SequenceLabel)
        Me.Panel1.Controls.Add(Me.SequenceTextBox)
        Me.Panel1.Controls.Add(LongbitsLabel)
        Me.Panel1.Controls.Add(Me.LongbitsTextBox)
        Me.Panel1.Controls.Add(StartbitLabel)
        Me.Panel1.Controls.Add(Me.StartbitTextBox)
        Me.Panel1.Controls.Add(NameLabel)
        Me.Panel1.Controls.Add(Me.NameTextBox)
        Me.Panel1.Controls.Add(Me.Dec_idTextBox)
        Me.Panel1.Controls.Add(Hex_idLabel)
        Me.Panel1.Controls.Add(Me.Hex_idTextBox)
        Me.Panel1.Controls.Add(Me.Ids_canbusBindingNavigator)
        Me.Panel1.Controls.Add(Me.Ids_canbusDataGridView)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(923, 427)
        Me.Panel1.TabIndex = 0
        '
        'OffsetTextBox
        '
        Me.OffsetTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Ids_canbusBindingSource, "offset", True))
        Me.OffsetTextBox.Location = New System.Drawing.Point(804, 50)
        Me.OffsetTextBox.Name = "OffsetTextBox"
        Me.OffsetTextBox.Size = New System.Drawing.Size(100, 20)
        Me.OffsetTextBox.TabIndex = 38
        '
        'FactorTextBox
        '
        Me.FactorTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Ids_canbusBindingSource, "factor", True))
        Me.FactorTextBox.Location = New System.Drawing.Point(632, 50)
        Me.FactorTextBox.Name = "FactorTextBox"
        Me.FactorTextBox.Size = New System.Drawing.Size(100, 20)
        Me.FactorTextBox.TabIndex = 36
        '
        'SignedCheckBox
        '
        Me.SignedCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.Ids_canbusBindingSource, "signed", True))
        Me.SignedCheckBox.Location = New System.Drawing.Point(542, 49)
        Me.SignedCheckBox.Name = "SignedCheckBox"
        Me.SignedCheckBox.Size = New System.Drawing.Size(17, 24)
        Me.SignedCheckBox.TabIndex = 34
        Me.SignedCheckBox.UseVisualStyleBackColor = True
        '
        'SequenceTextBox
        '
        Me.SequenceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Ids_canbusBindingSource, "sequence", True))
        Me.SequenceTextBox.Location = New System.Drawing.Point(97, 84)
        Me.SequenceTextBox.Name = "SequenceTextBox"
        Me.SequenceTextBox.Size = New System.Drawing.Size(807, 20)
        Me.SequenceTextBox.TabIndex = 32
        '
        'LongbitsTextBox
        '
        Me.LongbitsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Ids_canbusBindingSource, "longbits", True))
        Me.LongbitsTextBox.Location = New System.Drawing.Point(394, 50)
        Me.LongbitsTextBox.Name = "LongbitsTextBox"
        Me.LongbitsTextBox.Size = New System.Drawing.Size(50, 20)
        Me.LongbitsTextBox.TabIndex = 30
        '
        'StartbitTextBox
        '
        Me.StartbitTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Ids_canbusBindingSource, "startbit", True))
        Me.StartbitTextBox.Location = New System.Drawing.Point(265, 50)
        Me.StartbitTextBox.Name = "StartbitTextBox"
        Me.StartbitTextBox.Size = New System.Drawing.Size(49, 20)
        Me.StartbitTextBox.TabIndex = 28
        '
        'NameTextBox
        '
        Me.NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Ids_canbusBindingSource, "name", True))
        Me.NameTextBox.Location = New System.Drawing.Point(97, 14)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(291, 20)
        Me.NameTextBox.TabIndex = 26
        '
        'Dec_idTextBox
        '
        Me.Dec_idTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Ids_canbusBindingSource, "dec_id", True))
        Me.Dec_idTextBox.Location = New System.Drawing.Point(21, 376)
        Me.Dec_idTextBox.Name = "Dec_idTextBox"
        Me.Dec_idTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Dec_idTextBox.TabIndex = 24
        Me.Dec_idTextBox.Visible = False
        '
        'Hex_idTextBox
        '
        Me.Hex_idTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Ids_canbusBindingSource, "hex_id", True))
        Me.Hex_idTextBox.Location = New System.Drawing.Point(97, 50)
        Me.Hex_idTextBox.Name = "Hex_idTextBox"
        Me.Hex_idTextBox.Size = New System.Drawing.Size(91, 20)
        Me.Hex_idTextBox.TabIndex = 23
        '
        'Ids_canbusBindingNavigator
        '
        Me.Ids_canbusBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.Ids_canbusBindingNavigator.BindingSource = Me.Ids_canbusBindingSource
        Me.Ids_canbusBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.Ids_canbusBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.Ids_canbusBindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.Ids_canbusBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorAddNewItem, Me.Ids_canbusBindingNavigatorSaveItem, Me.Delete, Me.BindingNavigatorDeleteItem, Me.ToolStripSeparator1, Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.Ids_canbusBindingNavigator.Location = New System.Drawing.Point(151, 356)
        Me.Ids_canbusBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.Ids_canbusBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.Ids_canbusBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.Ids_canbusBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.Ids_canbusBindingNavigator.Name = "Ids_canbusBindingNavigator"
        Me.Ids_canbusBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.Ids_canbusBindingNavigator.Size = New System.Drawing.Size(510, 56)
        Me.Ids_canbusBindingNavigator.TabIndex = 20
        Me.Ids_canbusBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = Global.FfE.My.Resources.Resources.add
        Me.BindingNavigatorAddNewItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(52, 53)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(56, 53)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.AutoSize = False
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(0, 0)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        Me.BindingNavigatorDeleteItem.Visible = False
        '
        'Ids_canbusBindingNavigatorSaveItem
        '
        Me.Ids_canbusBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Ids_canbusBindingNavigatorSaveItem.Image = Global.FfE.My.Resources.Resources.save2
        Me.Ids_canbusBindingNavigatorSaveItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Ids_canbusBindingNavigatorSaveItem.Name = "Ids_canbusBindingNavigatorSaveItem"
        Me.Ids_canbusBindingNavigatorSaveItem.Size = New System.Drawing.Size(53, 53)
        Me.Ids_canbusBindingNavigatorSaveItem.Text = "Save"
        '
        'Delete
        '
        Me.Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Delete.Image = Global.FfE.My.Resources.Resources.delete
        Me.Delete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(53, 53)
        Me.Delete.Text = "Delete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 56)
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = Global.FfE.My.Resources.Resources.img_first
        Me.BindingNavigatorMoveFirstItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(52, 53)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = Global.FfE.My.Resources.Resources.img_back
        Me.BindingNavigatorMovePreviousItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(52, 53)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 56)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 33)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 56)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = Global.FfE.My.Resources.Resources.img_next
        Me.BindingNavigatorMoveNextItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(52, 53)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = Global.FfE.My.Resources.Resources.img_last
        Me.BindingNavigatorMoveLastItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(52, 53)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 56)
        '
        'Ids_canbusDataGridView
        '
        Me.Ids_canbusDataGridView.AllowUserToAddRows = False
        Me.Ids_canbusDataGridView.AllowUserToDeleteRows = False
        Me.Ids_canbusDataGridView.AutoGenerateColumns = False
        Me.Ids_canbusDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Ids_canbusDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9})
        Me.Ids_canbusDataGridView.DataSource = Me.Ids_canbusBindingSource
        Me.Ids_canbusDataGridView.Location = New System.Drawing.Point(21, 124)
        Me.Ids_canbusDataGridView.Name = "Ids_canbusDataGridView"
        Me.Ids_canbusDataGridView.ReadOnly = True
        Me.Ids_canbusDataGridView.Size = New System.Drawing.Size(883, 220)
        Me.Ids_canbusDataGridView.TabIndex = 21
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "channel_id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Channel ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "name"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "hex_id"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Hex ID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "dec_id"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Dec ID"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "startbit"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Startbit"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "longbits"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Long"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "sequence"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Sequence"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "signed"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "signed"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "factor"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Factor"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "offset"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Offset"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'form_canbus_ids
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(947, 451)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "form_canbus_ids"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CAN-BUS ID channels"
        CType(Me.Ffe_databaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ids_canbusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Ids_canbusBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ids_canbusBindingNavigator.ResumeLayout(False)
        Me.Ids_canbusBindingNavigator.PerformLayout()
        CType(Me.Ids_canbusDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Ffe_databaseDataSet As FfE.ffe_databaseDataSet
    Friend WithEvents Ids_canbusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Ids_canbusTableAdapter As FfE.ffe_databaseDataSetTableAdapters.ids_canbusTableAdapter
    Friend WithEvents TableAdapterManager As FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents OffsetTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FactorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SignedCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SequenceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LongbitsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StartbitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Dec_idTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Hex_idTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Ids_canbusBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents Ids_canbusBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents Delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Ids_canbusDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
