<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_car_photos
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
        Me.PhotosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ffe_databaseDataSet = New FfE.ffe_databaseDataSet
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.PhotosTableAdapter = New FfE.ffe_databaseDataSetTableAdapters.photosTableAdapter
        Me.TableAdapterManager = New FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PathTextBox = New System.Windows.Forms.TextBox
        Me.Car_idTextBox = New System.Windows.Forms.TextBox
        Me.PhotosBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.PhotosBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.PhotosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ffe_databaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PhotosBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PhotosBindingNavigator.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PhotosBindingSource
        '
        Me.PhotosBindingSource.DataMember = "photos"
        Me.PhotosBindingSource.DataSource = Me.Ffe_databaseDataSet
        '
        'Ffe_databaseDataSet
        '
        Me.Ffe_databaseDataSet.DataSetName = "ffe_databaseDataSet"
        Me.Ffe_databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'PhotosTableAdapter
        '
        Me.PhotosTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.photosTableAdapter = Me.PhotosTableAdapter
        Me.TableAdapterManager.UpdateOrder = FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.usage_typeTableAdapter = Nothing
        Me.TableAdapterManager.userTableAdapter = Nothing
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PathTextBox)
        Me.Panel1.Controls.Add(Me.Car_idTextBox)
        Me.Panel1.Controls.Add(Me.PhotosBindingNavigator)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1185, 683)
        Me.Panel1.TabIndex = 6
        '
        'PathTextBox
        '
        Me.PathTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PathTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PhotosBindingSource, "path", True))
        Me.PathTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PathTextBox.Location = New System.Drawing.Point(158, 651)
        Me.PathTextBox.Name = "PathTextBox"
        Me.PathTextBox.ReadOnly = True
        Me.PathTextBox.Size = New System.Drawing.Size(869, 22)
        Me.PathTextBox.TabIndex = 10
        '
        'Car_idTextBox
        '
        Me.Car_idTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Car_idTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PhotosBindingSource, "car_id", True))
        Me.Car_idTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Car_idTextBox.Location = New System.Drawing.Point(303, 25)
        Me.Car_idTextBox.Name = "Car_idTextBox"
        Me.Car_idTextBox.ReadOnly = True
        Me.Car_idTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Car_idTextBox.Size = New System.Drawing.Size(63, 22)
        Me.Car_idTextBox.TabIndex = 9
        '
        'PhotosBindingNavigator
        '
        Me.PhotosBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.PhotosBindingNavigator.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PhotosBindingNavigator.AutoSize = False
        Me.PhotosBindingNavigator.BackColor = System.Drawing.Color.Transparent
        Me.PhotosBindingNavigator.BindingSource = Me.PhotosBindingSource
        Me.PhotosBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.PhotosBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.PhotosBindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.PhotosBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.PhotosBindingNavigatorSaveItem})
        Me.PhotosBindingNavigator.Location = New System.Drawing.Point(411, 13)
        Me.PhotosBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.PhotosBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.PhotosBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.PhotosBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.PhotosBindingNavigator.Name = "PhotosBindingNavigator"
        Me.PhotosBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.PhotosBindingNavigator.Size = New System.Drawing.Size(530, 54)
        Me.PhotosBindingNavigator.TabIndex = 8
        Me.PhotosBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = Global.FfE.My.Resources.Resources.add_img
        Me.BindingNavigatorAddNewItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(52, 51)
        Me.BindingNavigatorAddNewItem.Text = "Agregar nuevo"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(56, 51)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = Global.FfE.My.Resources.Resources.del_img
        Me.BindingNavigatorDeleteItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(52, 51)
        Me.BindingNavigatorDeleteItem.Text = "Eliminar"
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
        Me.BindingNavigatorMoveFirstItem.Text = "Mover primero"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = Global.FfE.My.Resources.Resources.img_back
        Me.BindingNavigatorMovePreviousItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(52, 51)
        Me.BindingNavigatorMovePreviousItem.Text = "Mover anterior"
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
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 33)
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
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = Global.FfE.My.Resources.Resources.img_next
        Me.BindingNavigatorMoveNextItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(52, 51)
        Me.BindingNavigatorMoveNextItem.Text = "Mover siguiente"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = Global.FfE.My.Resources.Resources.img_last
        Me.BindingNavigatorMoveLastItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(52, 51)
        Me.BindingNavigatorMoveLastItem.Text = "Mover último"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'PhotosBindingNavigatorSaveItem
        '
        Me.PhotosBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PhotosBindingNavigatorSaveItem.Image = Global.FfE.My.Resources.Resources.save_img
        Me.PhotosBindingNavigatorSaveItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PhotosBindingNavigatorSaveItem.Name = "PhotosBindingNavigatorSaveItem"
        Me.PhotosBindingNavigatorSaveItem.Size = New System.Drawing.Size(52, 51)
        Me.PhotosBindingNavigatorSaveItem.Text = "Guardar datos"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(243, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Car Id:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackgroundImage = Global.FfE.My.Resources.Resources.car_photo
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.PhotosBindingSource, "photo", True))
        Me.PictureBox1.Location = New System.Drawing.Point(21, 82)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1152, 552)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'Form_car_photos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1185, 683)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form_car_photos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Photos Car"
        CType(Me.PhotosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ffe_databaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PhotosBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PhotosBindingNavigator.ResumeLayout(False)
        Me.PhotosBindingNavigator.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Ffe_databaseDataSet As FfE.ffe_databaseDataSet
    Friend WithEvents PhotosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PhotosTableAdapter As FfE.ffe_databaseDataSetTableAdapters.photosTableAdapter
    Friend WithEvents TableAdapterManager As FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Car_idTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PhotosBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents PhotosBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
