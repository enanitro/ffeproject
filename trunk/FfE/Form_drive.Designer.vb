<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_drive
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
        Dim DateLabel As System.Windows.Forms.Label
        Dim DescriptionLabel As System.Windows.Forms.Label
        Dim StatusLabel As System.Windows.Forms.Label
        Dim ClimateLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim User_idLabel As System.Windows.Forms.Label
        Dim VornameLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim Car_idLabel As System.Windows.Forms.Label
        Dim NameLabel2 As System.Windows.Forms.Label
        Dim TypeLabel As System.Windows.Forms.Label
        Dim OwnerLabel As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_drive))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.DriveBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.find_drive = New System.Windows.Forms.ToolStripButton
        Me.Drive_idLabel1 = New System.Windows.Forms.Label
        Me.DriveBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ffe_databaseDataSet = New FfE.ffe_databaseDataSet
        Me.date_driver = New System.Windows.Forms.DateTimePicker
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DriveBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton
        Me.delete = New System.Windows.Forms.ToolStripButton
        Me.btn_find_drive = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label12 = New System.Windows.Forms.Label
        Me.pn_importer = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.ImporterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btn_importer = New System.Windows.Forms.Button
        Me.cmb_importer = New System.Windows.Forms.ComboBox
        Me.pn_car = New System.Windows.Forms.Panel
        Me.OwnerLabel1 = New System.Windows.Forms.Label
        Me.CarBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TypeLabel1 = New System.Windows.Forms.Label
        Me.License_plateLabel1 = New System.Windows.Forms.Label
        Me.NameLabel3 = New System.Windows.Forms.Label
        Me.Car_idLabel1 = New System.Windows.Forms.Label
        Me.PhotoPictureBox1 = New System.Windows.Forms.PictureBox
        Me.btn_expandir_car = New System.Windows.Forms.Button
        Me.cmb_car = New System.Windows.Forms.ComboBox
        Me.pn_driver = New System.Windows.Forms.Panel
        Me.NameLabel1 = New System.Windows.Forms.Label
        Me.UserBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VornameLabel1 = New System.Windows.Forms.Label
        Me.User_idLabel1 = New System.Windows.Forms.Label
        Me.PhotoPictureBox = New System.Windows.Forms.PictureBox
        Me.btn_expandir_driver = New System.Windows.Forms.Button
        Me.cmb_driver = New System.Windows.Forms.ComboBox
        Me.cmb_drive_type = New System.Windows.Forms.ComboBox
        Me.cmb_status = New System.Windows.Forms.ComboBox
        Me.cmb_usage = New System.Windows.Forms.ComboBox
        Me.UsagetypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmb_climate = New System.Windows.Forms.ComboBox
        Me.txt_description = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.btn_export = New System.Windows.Forms.Button
        Me.btn_import = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.DriveDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DriveTableAdapter = New FfE.ffe_databaseDataSetTableAdapters.driveTableAdapter
        Me.TableAdapterManager = New FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager
        Me.CarTableAdapter = New FfE.ffe_databaseDataSetTableAdapters.carTableAdapter
        Me.Usage_typeTableAdapter = New FfE.ffe_databaseDataSetTableAdapters.usage_typeTableAdapter
        Me.UserTableAdapter = New FfE.ffe_databaseDataSetTableAdapters.userTableAdapter
        Me.TableAdapterManager1 = New FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager
        Me.FfedatabaseDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        DateLabel = New System.Windows.Forms.Label
        DescriptionLabel = New System.Windows.Forms.Label
        StatusLabel = New System.Windows.Forms.Label
        ClimateLabel = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        User_idLabel = New System.Windows.Forms.Label
        VornameLabel = New System.Windows.Forms.Label
        NameLabel = New System.Windows.Forms.Label
        Car_idLabel = New System.Windows.Forms.Label
        NameLabel2 = New System.Windows.Forms.Label
        TypeLabel = New System.Windows.Forms.Label
        OwnerLabel = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        Label9 = New System.Windows.Forms.Label
        Label11 = New System.Windows.Forms.Label
        CType(Me.DriveBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ffe_databaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DriveBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DriveBindingNavigator.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pn_importer.SuspendLayout()
        CType(Me.ImporterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pn_car.SuspendLayout()
        CType(Me.CarBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PhotoPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pn_driver.SuspendLayout()
        CType(Me.UserBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PhotoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsagetypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DriveDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FfedatabaseDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateLabel
        '
        DateLabel.AutoSize = True
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        DateLabel.Location = New System.Drawing.Point(76, 72)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(41, 15)
        DateLabel.TabIndex = 7
        DateLabel.Text = "Date:"
        '
        'DescriptionLabel
        '
        DescriptionLabel.AutoSize = True
        DescriptionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        DescriptionLabel.Location = New System.Drawing.Point(33, 232)
        DescriptionLabel.Name = "DescriptionLabel"
        DescriptionLabel.Size = New System.Drawing.Size(84, 15)
        DescriptionLabel.TabIndex = 15
        DescriptionLabel.Text = "Description:"
        '
        'StatusLabel
        '
        StatusLabel.AutoSize = True
        StatusLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        StatusLabel.Location = New System.Drawing.Point(66, 152)
        StatusLabel.Name = "StatusLabel"
        StatusLabel.Size = New System.Drawing.Size(51, 15)
        StatusLabel.TabIndex = 11
        StatusLabel.Text = "Status:"
        '
        'ClimateLabel
        '
        ClimateLabel.AutoSize = True
        ClimateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        ClimateLabel.Location = New System.Drawing.Point(57, 112)
        ClimateLabel.Name = "ClimateLabel"
        ClimateLabel.Size = New System.Drawing.Size(60, 15)
        ClimateLabel.TabIndex = 13
        ClimateLabel.Text = "Climate:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Label1.Location = New System.Drawing.Point(31, 272)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(86, 15)
        Label1.TabIndex = 17
        Label1.Text = "Usage Type:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Label4.Location = New System.Drawing.Point(39, 192)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(78, 15)
        Label4.TabIndex = 16
        Label4.Text = "Drive Type:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Label2.Location = New System.Drawing.Point(65, 9)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(49, 15)
        Label2.TabIndex = 24
        Label2.Text = "Driver:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Label5.Location = New System.Drawing.Point(81, 12)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(33, 15)
        Label5.TabIndex = 24
        Label5.Text = "Car:"
        '
        'User_idLabel
        '
        User_idLabel.AutoSize = True
        User_idLabel.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        User_idLabel.Location = New System.Drawing.Point(35, 54)
        User_idLabel.Name = "User_idLabel"
        User_idLabel.Size = New System.Drawing.Size(19, 13)
        User_idLabel.TabIndex = 27
        User_idLabel.Text = "Id:"
        '
        'VornameLabel
        '
        VornameLabel.AutoSize = True
        VornameLabel.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        VornameLabel.Location = New System.Drawing.Point(35, 86)
        VornameLabel.Name = "VornameLabel"
        VornameLabel.Size = New System.Drawing.Size(52, 13)
        VornameLabel.TabIndex = 28
        VornameLabel.Text = "Vorname:"
        '
        'NameLabel
        '
        NameLabel.AutoSize = True
        NameLabel.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameLabel.Location = New System.Drawing.Point(35, 116)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(37, 13)
        NameLabel.TabIndex = 29
        NameLabel.Text = "Name:"
        '
        'Car_idLabel
        '
        Car_idLabel.AutoSize = True
        Car_idLabel.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Car_idLabel.Location = New System.Drawing.Point(37, 47)
        Car_idLabel.Name = "Car_idLabel"
        Car_idLabel.Size = New System.Drawing.Size(19, 13)
        Car_idLabel.TabIndex = 27
        Car_idLabel.Text = "Id:"
        '
        'NameLabel2
        '
        NameLabel2.AutoSize = True
        NameLabel2.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameLabel2.Location = New System.Drawing.Point(37, 71)
        NameLabel2.Name = "NameLabel2"
        NameLabel2.Size = New System.Drawing.Size(37, 13)
        NameLabel2.TabIndex = 28
        NameLabel2.Text = "Name:"
        '
        'TypeLabel
        '
        TypeLabel.AutoSize = True
        TypeLabel.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TypeLabel.Location = New System.Drawing.Point(37, 95)
        TypeLabel.Name = "TypeLabel"
        TypeLabel.Size = New System.Drawing.Size(32, 13)
        TypeLabel.TabIndex = 30
        TypeLabel.Text = "Type:"
        '
        'OwnerLabel
        '
        OwnerLabel.AutoSize = True
        OwnerLabel.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        OwnerLabel.Location = New System.Drawing.Point(37, 119)
        OwnerLabel.Name = "OwnerLabel"
        OwnerLabel.Size = New System.Drawing.Size(41, 13)
        OwnerLabel.TabIndex = 31
        OwnerLabel.Text = "Owner:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(35, 116)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(37, 13)
        Label3.TabIndex = 29
        Label3.Text = "Name:"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label7.Location = New System.Drawing.Point(35, 86)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(52, 13)
        Label7.TabIndex = 28
        Label7.Text = "Vorname:"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label9.Location = New System.Drawing.Point(35, 54)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(19, 13)
        Label9.TabIndex = 27
        Label9.Text = "Id:"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Label11.Location = New System.Drawing.Point(49, 10)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(65, 15)
        Label11.TabIndex = 24
        Label11.Text = "Importer:"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.AutoSize = False
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Enabled = False
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(80, 52)
        Me.BindingNavigatorAddNewItem.Text = "Agregar nuevo"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.AutoSize = False
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Enabled = False
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(80, 52)
        Me.BindingNavigatorDeleteItem.Text = "Eliminar"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.AutoSize = False
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Enabled = False
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(70, 52)
        Me.BindingNavigatorMoveFirstItem.Text = "Mover primero"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.AutoSize = False
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Enabled = False
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(52, 52)
        Me.BindingNavigatorMoveLastItem.Text = "Mover último"
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.AutoSize = False
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Enabled = False
        Me.BindingNavigatorMoveNextItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(52, 52)
        Me.BindingNavigatorMoveNextItem.Text = "Mover siguiente"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.AutoSize = False
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Enabled = False
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(52, 52)
        Me.BindingNavigatorMovePreviousItem.Text = "Mover anterior"
        '
        'DriveBindingNavigatorSaveItem
        '
        Me.DriveBindingNavigatorSaveItem.AutoSize = False
        Me.DriveBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DriveBindingNavigatorSaveItem.Image = CType(resources.GetObject("DriveBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.DriveBindingNavigatorSaveItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DriveBindingNavigatorSaveItem.Name = "DriveBindingNavigatorSaveItem"
        Me.DriveBindingNavigatorSaveItem.Size = New System.Drawing.Size(80, 52)
        Me.DriveBindingNavigatorSaveItem.Text = "Guardar datos"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.AutoSize = False
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 52)
        '
        'find_drive
        '
        Me.find_drive.AutoSize = False
        Me.find_drive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.find_drive.Image = CType(resources.GetObject("find_drive.Image"), System.Drawing.Image)
        Me.find_drive.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.find_drive.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.find_drive.Name = "find_drive"
        Me.find_drive.Size = New System.Drawing.Size(52, 52)
        '
        'Drive_idLabel1
        '
        Me.Drive_idLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Drive_idLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DriveBindingSource, "drive_id", True))
        Me.Drive_idLabel1.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Drive_idLabel1.ForeColor = System.Drawing.Color.White
        Me.Drive_idLabel1.Image = CType(resources.GetObject("Drive_idLabel1.Image"), System.Drawing.Image)
        Me.Drive_idLabel1.Location = New System.Drawing.Point(159, 10)
        Me.Drive_idLabel1.Name = "Drive_idLabel1"
        Me.Drive_idLabel1.Size = New System.Drawing.Size(174, 36)
        Me.Drive_idLabel1.TabIndex = 2
        Me.Drive_idLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DriveBindingSource
        '
        Me.DriveBindingSource.DataMember = "drive"
        Me.DriveBindingSource.DataSource = Me.Ffe_databaseDataSet
        '
        'Ffe_databaseDataSet
        '
        Me.Ffe_databaseDataSet.DataSetName = "ffe_databaseDataSet"
        Me.Ffe_databaseDataSet.Locale = New System.Globalization.CultureInfo("es-ES")
        Me.Ffe_databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'date_driver
        '
        Me.date_driver.CalendarForeColor = System.Drawing.Color.Navy
        Me.date_driver.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.DriveBindingSource, "date", True))
        Me.date_driver.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DriveBindingSource, "date", True))
        Me.date_driver.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_driver.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_driver.Location = New System.Drawing.Point(124, 67)
        Me.date_driver.Name = "date_driver"
        Me.date_driver.Size = New System.Drawing.Size(157, 23)
        Me.date_driver.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(1, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(395, 654)
        Me.Panel1.TabIndex = 13
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.DriveBindingNavigator)
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(370, 630)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Drive"
        '
        'DriveBindingNavigator
        '
        Me.DriveBindingNavigator.AddNewItem = Me.ToolStripButton1
        Me.DriveBindingNavigator.AutoSize = False
        Me.DriveBindingNavigator.BackColor = System.Drawing.Color.Transparent
        Me.DriveBindingNavigator.BindingSource = Me.DriveBindingSource
        Me.DriveBindingNavigator.CountItem = Nothing
        Me.DriveBindingNavigator.DeleteItem = Nothing
        Me.DriveBindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.DriveBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.DriveBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton7, Me.delete, Me.btn_find_drive, Me.ToolStripButton3, Me.ToolStripButton4, Me.BindingNavigatorSeparator, Me.ToolStripButton5, Me.ToolStripButton6})
        Me.DriveBindingNavigator.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.DriveBindingNavigator.Location = New System.Drawing.Point(69, 469)
        Me.DriveBindingNavigator.MoveFirstItem = Me.ToolStripButton3
        Me.DriveBindingNavigator.MoveLastItem = Me.ToolStripButton6
        Me.DriveBindingNavigator.MoveNextItem = Me.ToolStripButton5
        Me.DriveBindingNavigator.MovePreviousItem = Me.ToolStripButton4
        Me.DriveBindingNavigator.Name = "DriveBindingNavigator"
        Me.DriveBindingNavigator.PositionItem = Nothing
        Me.DriveBindingNavigator.Size = New System.Drawing.Size(235, 119)
        Me.DriveBindingNavigator.TabIndex = 16
        Me.DriveBindingNavigator.Text = "BindingNavigator1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.AutoSize = False
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton1.Size = New System.Drawing.Size(56, 56)
        Me.ToolStripButton1.Text = "Add new"
        Me.ToolStripButton1.ToolTipText = "Add new drive"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.AutoSize = False
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(56, 56)
        Me.ToolStripButton7.Text = "Save"
        Me.ToolStripButton7.ToolTipText = "Save drive"
        '
        'delete
        '
        Me.delete.AutoSize = False
        Me.delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.delete.Image = Global.FfE.My.Resources.Resources.delete_drive
        Me.delete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.delete.ImageTransparentColor = System.Drawing.Color.White
        Me.delete.Name = "delete"
        Me.delete.Size = New System.Drawing.Size(56, 56)
        Me.delete.Text = "Delete"
        '
        'btn_find_drive
        '
        Me.btn_find_drive.AutoSize = False
        Me.btn_find_drive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_find_drive.Image = CType(resources.GetObject("btn_find_drive.Image"), System.Drawing.Image)
        Me.btn_find_drive.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_find_drive.ImageTransparentColor = System.Drawing.Color.White
        Me.btn_find_drive.Name = "btn_find_drive"
        Me.btn_find_drive.Size = New System.Drawing.Size(56, 56)
        Me.btn_find_drive.Text = "Search"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.AutoSize = False
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(56, 56)
        Me.ToolStripButton3.Text = "First"
        Me.ToolStripButton3.ToolTipText = "Move First"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.AutoSize = False
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(56, 56)
        Me.ToolStripButton4.Text = "Back"
        Me.ToolStripButton4.ToolTipText = "Move back"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.AutoSize = False
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(4, 56)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.AutoSize = False
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton5.Size = New System.Drawing.Size(56, 56)
        Me.ToolStripButton5.Text = "Next"
        Me.ToolStripButton5.ToolTipText = "Move next"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.AutoSize = False
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton6.Size = New System.Drawing.Size(56, 56)
        Me.ToolStripButton6.Text = "Last"
        Me.ToolStripButton6.ToolTipText = "Move last"
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.pn_importer)
        Me.Panel2.Controls.Add(Me.pn_car)
        Me.Panel2.Controls.Add(Me.pn_driver)
        Me.Panel2.Controls.Add(Me.cmb_drive_type)
        Me.Panel2.Controls.Add(Label4)
        Me.Panel2.Controls.Add(Me.cmb_status)
        Me.Panel2.Controls.Add(Me.cmb_usage)
        Me.Panel2.Controls.Add(Me.cmb_climate)
        Me.Panel2.Controls.Add(Me.Drive_idLabel1)
        Me.Panel2.Controls.Add(Label1)
        Me.Panel2.Controls.Add(DateLabel)
        Me.Panel2.Controls.Add(Me.txt_description)
        Me.Panel2.Controls.Add(DescriptionLabel)
        Me.Panel2.Controls.Add(Me.date_driver)
        Me.Panel2.Controls.Add(ClimateLabel)
        Me.Panel2.Controls.Add(StatusLabel)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Location = New System.Drawing.Point(6, 22)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(359, 444)
        Me.Panel2.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Image = CType(resources.GetObject("Label12.Image"), System.Drawing.Image)
        Me.Label12.Location = New System.Drawing.Point(14, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(148, 36)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Drive Id:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pn_importer
        '
        Me.pn_importer.Controls.Add(Label3)
        Me.pn_importer.Controls.Add(Me.Label6)
        Me.pn_importer.Controls.Add(Label7)
        Me.pn_importer.Controls.Add(Me.Label8)
        Me.pn_importer.Controls.Add(Label9)
        Me.pn_importer.Controls.Add(Me.Label10)
        Me.pn_importer.Controls.Add(Me.PictureBox1)
        Me.pn_importer.Controls.Add(Me.btn_importer)
        Me.pn_importer.Controls.Add(Me.cmb_importer)
        Me.pn_importer.Controls.Add(Label11)
        Me.pn_importer.Location = New System.Drawing.Point(3, 383)
        Me.pn_importer.Name = "pn_importer"
        Me.pn_importer.Size = New System.Drawing.Size(305, 38)
        Me.pn_importer.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImporterBindingSource, "name", True))
        Me.Label6.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(74, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 23)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Label3"
        '
        'ImporterBindingSource
        '
        Me.ImporterBindingSource.DataMember = "user"
        Me.ImporterBindingSource.DataSource = Me.Ffe_databaseDataSet
        '
        'Label8
        '
        Me.Label8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImporterBindingSource, "vorname", True))
        Me.Label8.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(89, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 23)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Label3"
        '
        'Label10
        '
        Me.Label10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImporterBindingSource, "user_id", True))
        Me.Label10.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(57, 55)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 24)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Label3"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.ImporterBindingSource, "photo", True))
        Me.PictureBox1.Location = New System.Drawing.Point(202, 39)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 106)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'btn_importer
        '
        Me.btn_importer.BackgroundImage = CType(resources.GetObject("btn_importer.BackgroundImage"), System.Drawing.Image)
        Me.btn_importer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_importer.FlatAppearance.BorderSize = 0
        Me.btn_importer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_importer.Location = New System.Drawing.Point(11, 8)
        Me.btn_importer.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_importer.Name = "btn_importer"
        Me.btn_importer.Size = New System.Drawing.Size(18, 18)
        Me.btn_importer.TabIndex = 26
        Me.btn_importer.UseVisualStyleBackColor = True
        '
        'cmb_importer
        '
        Me.cmb_importer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_importer.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_importer.FormattingEnabled = True
        Me.cmb_importer.Location = New System.Drawing.Point(121, 8)
        Me.cmb_importer.Name = "cmb_importer"
        Me.cmb_importer.Size = New System.Drawing.Size(155, 23)
        Me.cmb_importer.TabIndex = 25
        '
        'pn_car
        '
        Me.pn_car.Controls.Add(OwnerLabel)
        Me.pn_car.Controls.Add(Me.OwnerLabel1)
        Me.pn_car.Controls.Add(TypeLabel)
        Me.pn_car.Controls.Add(Me.TypeLabel1)
        Me.pn_car.Controls.Add(Me.License_plateLabel1)
        Me.pn_car.Controls.Add(NameLabel2)
        Me.pn_car.Controls.Add(Me.NameLabel3)
        Me.pn_car.Controls.Add(Car_idLabel)
        Me.pn_car.Controls.Add(Me.Car_idLabel1)
        Me.pn_car.Controls.Add(Me.PhotoPictureBox1)
        Me.pn_car.Controls.Add(Me.btn_expandir_car)
        Me.pn_car.Controls.Add(Me.cmb_car)
        Me.pn_car.Controls.Add(Label5)
        Me.pn_car.Location = New System.Drawing.Point(3, 344)
        Me.pn_car.Name = "pn_car"
        Me.pn_car.Size = New System.Drawing.Size(305, 38)
        Me.pn_car.TabIndex = 26
        '
        'OwnerLabel1
        '
        Me.OwnerLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CarBindingSource, "owner", True))
        Me.OwnerLabel1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OwnerLabel1.ForeColor = System.Drawing.Color.Navy
        Me.OwnerLabel1.Location = New System.Drawing.Point(76, 119)
        Me.OwnerLabel1.Name = "OwnerLabel1"
        Me.OwnerLabel1.Size = New System.Drawing.Size(120, 13)
        Me.OwnerLabel1.TabIndex = 32
        Me.OwnerLabel1.Text = "Label3"
        '
        'CarBindingSource
        '
        Me.CarBindingSource.DataMember = "car"
        Me.CarBindingSource.DataSource = Me.Ffe_databaseDataSet
        '
        'TypeLabel1
        '
        Me.TypeLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CarBindingSource, "type", True))
        Me.TypeLabel1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TypeLabel1.ForeColor = System.Drawing.Color.Navy
        Me.TypeLabel1.Location = New System.Drawing.Point(69, 94)
        Me.TypeLabel1.Name = "TypeLabel1"
        Me.TypeLabel1.Size = New System.Drawing.Size(127, 12)
        Me.TypeLabel1.TabIndex = 31
        Me.TypeLabel1.Text = "Label3"
        '
        'License_plateLabel1
        '
        Me.License_plateLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CarBindingSource, "license_plate", True))
        Me.License_plateLabel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.License_plateLabel1.ForeColor = System.Drawing.Color.Navy
        Me.License_plateLabel1.Location = New System.Drawing.Point(202, 121)
        Me.License_plateLabel1.Name = "License_plateLabel1"
        Me.License_plateLabel1.Size = New System.Drawing.Size(100, 23)
        Me.License_plateLabel1.TabIndex = 30
        Me.License_plateLabel1.Text = "Label3"
        Me.License_plateLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NameLabel3
        '
        Me.NameLabel3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CarBindingSource, "name", True))
        Me.NameLabel3.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameLabel3.ForeColor = System.Drawing.Color.Navy
        Me.NameLabel3.Location = New System.Drawing.Point(73, 71)
        Me.NameLabel3.Name = "NameLabel3"
        Me.NameLabel3.Size = New System.Drawing.Size(123, 13)
        Me.NameLabel3.TabIndex = 29
        Me.NameLabel3.Text = "Label3"
        '
        'Car_idLabel1
        '
        Me.Car_idLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CarBindingSource, "car_id", True))
        Me.Car_idLabel1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Car_idLabel1.ForeColor = System.Drawing.Color.Navy
        Me.Car_idLabel1.Location = New System.Drawing.Point(62, 47)
        Me.Car_idLabel1.Name = "Car_idLabel1"
        Me.Car_idLabel1.Size = New System.Drawing.Size(100, 13)
        Me.Car_idLabel1.TabIndex = 28
        Me.Car_idLabel1.Text = "Label3"
        '
        'PhotoPictureBox1
        '
        Me.PhotoPictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PhotoPictureBox1.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.CarBindingSource, "photo", True))
        Me.PhotoPictureBox1.Location = New System.Drawing.Point(202, 39)
        Me.PhotoPictureBox1.Name = "PhotoPictureBox1"
        Me.PhotoPictureBox1.Size = New System.Drawing.Size(100, 79)
        Me.PhotoPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PhotoPictureBox1.TabIndex = 27
        Me.PhotoPictureBox1.TabStop = False
        '
        'btn_expandir_car
        '
        Me.btn_expandir_car.BackgroundImage = CType(resources.GetObject("btn_expandir_car.BackgroundImage"), System.Drawing.Image)
        Me.btn_expandir_car.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_expandir_car.FlatAppearance.BorderSize = 0
        Me.btn_expandir_car.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_expandir_car.Location = New System.Drawing.Point(11, 8)
        Me.btn_expandir_car.Name = "btn_expandir_car"
        Me.btn_expandir_car.Size = New System.Drawing.Size(18, 18)
        Me.btn_expandir_car.TabIndex = 26
        Me.btn_expandir_car.UseVisualStyleBackColor = True
        '
        'cmb_car
        '
        Me.cmb_car.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_car.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_car.FormattingEnabled = True
        Me.cmb_car.Location = New System.Drawing.Point(121, 6)
        Me.cmb_car.Name = "cmb_car"
        Me.cmb_car.Size = New System.Drawing.Size(155, 23)
        Me.cmb_car.TabIndex = 25
        '
        'pn_driver
        '
        Me.pn_driver.Controls.Add(NameLabel)
        Me.pn_driver.Controls.Add(Me.NameLabel1)
        Me.pn_driver.Controls.Add(VornameLabel)
        Me.pn_driver.Controls.Add(Me.VornameLabel1)
        Me.pn_driver.Controls.Add(User_idLabel)
        Me.pn_driver.Controls.Add(Me.User_idLabel1)
        Me.pn_driver.Controls.Add(Me.PhotoPictureBox)
        Me.pn_driver.Controls.Add(Me.btn_expandir_driver)
        Me.pn_driver.Controls.Add(Me.cmb_driver)
        Me.pn_driver.Controls.Add(Label2)
        Me.pn_driver.Location = New System.Drawing.Point(3, 305)
        Me.pn_driver.MinimumSize = New System.Drawing.Size(305, 38)
        Me.pn_driver.Name = "pn_driver"
        Me.pn_driver.Size = New System.Drawing.Size(305, 38)
        Me.pn_driver.TabIndex = 25
        '
        'NameLabel1
        '
        Me.NameLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserBindingSource, "name", True))
        Me.NameLabel1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameLabel1.ForeColor = System.Drawing.Color.Navy
        Me.NameLabel1.Location = New System.Drawing.Point(74, 116)
        Me.NameLabel1.Name = "NameLabel1"
        Me.NameLabel1.Size = New System.Drawing.Size(122, 23)
        Me.NameLabel1.TabIndex = 30
        Me.NameLabel1.Text = "Label3"
        '
        'UserBindingSource
        '
        Me.UserBindingSource.DataMember = "user"
        Me.UserBindingSource.DataSource = Me.Ffe_databaseDataSet
        '
        'VornameLabel1
        '
        Me.VornameLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserBindingSource, "vorname", True))
        Me.VornameLabel1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VornameLabel1.ForeColor = System.Drawing.Color.Navy
        Me.VornameLabel1.Location = New System.Drawing.Point(89, 87)
        Me.VornameLabel1.Name = "VornameLabel1"
        Me.VornameLabel1.Size = New System.Drawing.Size(105, 23)
        Me.VornameLabel1.TabIndex = 29
        Me.VornameLabel1.Text = "Label3"
        '
        'User_idLabel1
        '
        Me.User_idLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UserBindingSource, "user_id", True))
        Me.User_idLabel1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.User_idLabel1.ForeColor = System.Drawing.Color.Navy
        Me.User_idLabel1.Location = New System.Drawing.Point(57, 55)
        Me.User_idLabel1.Name = "User_idLabel1"
        Me.User_idLabel1.Size = New System.Drawing.Size(80, 24)
        Me.User_idLabel1.TabIndex = 28
        Me.User_idLabel1.Text = "Label3"
        '
        'PhotoPictureBox
        '
        Me.PhotoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PhotoPictureBox.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.UserBindingSource, "photo", True))
        Me.PhotoPictureBox.Location = New System.Drawing.Point(202, 39)
        Me.PhotoPictureBox.Name = "PhotoPictureBox"
        Me.PhotoPictureBox.Size = New System.Drawing.Size(100, 106)
        Me.PhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PhotoPictureBox.TabIndex = 27
        Me.PhotoPictureBox.TabStop = False
        '
        'btn_expandir_driver
        '
        Me.btn_expandir_driver.BackgroundImage = CType(resources.GetObject("btn_expandir_driver.BackgroundImage"), System.Drawing.Image)
        Me.btn_expandir_driver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_expandir_driver.FlatAppearance.BorderSize = 0
        Me.btn_expandir_driver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_expandir_driver.Location = New System.Drawing.Point(11, 6)
        Me.btn_expandir_driver.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_expandir_driver.Name = "btn_expandir_driver"
        Me.btn_expandir_driver.Size = New System.Drawing.Size(18, 18)
        Me.btn_expandir_driver.TabIndex = 26
        Me.btn_expandir_driver.UseVisualStyleBackColor = True
        '
        'cmb_driver
        '
        Me.cmb_driver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_driver.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_driver.FormattingEnabled = True
        Me.cmb_driver.Location = New System.Drawing.Point(121, 8)
        Me.cmb_driver.Name = "cmb_driver"
        Me.cmb_driver.Size = New System.Drawing.Size(155, 23)
        Me.cmb_driver.TabIndex = 25
        '
        'cmb_drive_type
        '
        Me.cmb_drive_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_drive_type.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_drive_type.FormattingEnabled = True
        Me.cmb_drive_type.Items.AddRange(New Object() {"Aggressive", "Normal", "Slow"})
        Me.cmb_drive_type.Location = New System.Drawing.Point(124, 190)
        Me.cmb_drive_type.Name = "cmb_drive_type"
        Me.cmb_drive_type.Size = New System.Drawing.Size(157, 23)
        Me.cmb_drive_type.TabIndex = 17
        '
        'cmb_status
        '
        Me.cmb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_status.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_status.FormattingEnabled = True
        Me.cmb_status.Items.AddRange(New Object() {"Waiting for approval", "Experimental", "Final", "Check"})
        Me.cmb_status.Location = New System.Drawing.Point(124, 149)
        Me.cmb_status.Name = "cmb_status"
        Me.cmb_status.Size = New System.Drawing.Size(157, 23)
        Me.cmb_status.TabIndex = 15
        '
        'cmb_usage
        '
        Me.cmb_usage.DataSource = Me.UsagetypeBindingSource
        Me.cmb_usage.DisplayMember = "name"
        Me.cmb_usage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_usage.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_usage.FormattingEnabled = True
        Me.cmb_usage.Location = New System.Drawing.Point(124, 272)
        Me.cmb_usage.Name = "cmb_usage"
        Me.cmb_usage.Size = New System.Drawing.Size(155, 23)
        Me.cmb_usage.TabIndex = 18
        Me.cmb_usage.ValueMember = "usage_type_id"
        '
        'UsagetypeBindingSource
        '
        Me.UsagetypeBindingSource.DataMember = "usage_type"
        Me.UsagetypeBindingSource.DataSource = Me.Ffe_databaseDataSet
        '
        'cmb_climate
        '
        Me.cmb_climate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_climate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_climate.FormattingEnabled = True
        Me.cmb_climate.Items.AddRange(New Object() {"Winter", "Summer", "Intermediate"})
        Me.cmb_climate.Location = New System.Drawing.Point(124, 108)
        Me.cmb_climate.Name = "cmb_climate"
        Me.cmb_climate.Size = New System.Drawing.Size(157, 23)
        Me.cmb_climate.TabIndex = 14
        '
        'txt_description
        '
        Me.txt_description.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DriveBindingSource, "description", True))
        Me.txt_description.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_description.Location = New System.Drawing.Point(124, 231)
        Me.txt_description.Multiline = True
        Me.txt_description.Name = "txt_description"
        Me.txt_description.Size = New System.Drawing.Size(157, 23)
        Me.txt_description.TabIndex = 16
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label13.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DriveBindingSource, "drive_id", True))
        Me.Label13.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Image = CType(resources.GetObject("Label13.Image"), System.Drawing.Image)
        Me.Label13.Location = New System.Drawing.Point(159, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(174, 36)
        Me.Label13.TabIndex = 29
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.GroupBox4)
        Me.Panel3.Controls.Add(Me.GroupBox3)
        Me.Panel3.Location = New System.Drawing.Point(402, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(818, 654)
        Me.Panel3.TabIndex = 14
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Button3)
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.btn_export)
        Me.GroupBox4.Controls.Add(Me.btn_import)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox4.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(785, 149)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Data operations"
        '
        'Button3
        '
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.Location = New System.Drawing.Point(315, 27)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(144, 105)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Fahrprofile"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.FfE.My.Resources.Resources.view_data
        Me.Button2.Location = New System.Drawing.Point(471, 27)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(144, 105)
        Me.Button2.TabIndex = 3
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.FfE.My.Resources.Resources.del_channel2
        Me.Button1.Location = New System.Drawing.Point(624, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 105)
        Me.Button1.TabIndex = 2
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_export
        '
        Me.btn_export.BackgroundImage = CType(resources.GetObject("btn_export.BackgroundImage"), System.Drawing.Image)
        Me.btn_export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_export.Location = New System.Drawing.Point(159, 27)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(144, 105)
        Me.btn_export.TabIndex = 1
        Me.btn_export.UseVisualStyleBackColor = True
        '
        'btn_import
        '
        Me.btn_import.BackgroundImage = CType(resources.GetObject("btn_import.BackgroundImage"), System.Drawing.Image)
        Me.btn_import.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_import.Location = New System.Drawing.Point(6, 27)
        Me.btn_import.Name = "btn_import"
        Me.btn_import.Size = New System.Drawing.Size(144, 105)
        Me.btn_import.TabIndex = 0
        Me.btn_import.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.DriveDataGridView)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 168)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(785, 475)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Drives"
        '
        'DriveDataGridView
        '
        Me.DriveDataGridView.AllowUserToAddRows = False
        Me.DriveDataGridView.AllowUserToDeleteRows = False
        Me.DriveDataGridView.AutoGenerateColumns = False
        Me.DriveDataGridView.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DriveDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DriveDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DriveDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9})
        Me.DriveDataGridView.DataSource = Me.DriveBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DriveDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.DriveDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DriveDataGridView.Location = New System.Drawing.Point(3, 17)
        Me.DriveDataGridView.Name = "DriveDataGridView"
        Me.DriveDataGridView.ReadOnly = True
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.DriveDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DriveDataGridView.Size = New System.Drawing.Size(779, 455)
        Me.DriveDataGridView.TabIndex = 3
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "drive_id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Drive ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "date"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "status"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "climate"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Climate"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "drive_type"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Drive Type"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "description"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "usage_type_id"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Usage type ID"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "driver_id"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Driver ID"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "importer_id"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Importer ID"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "car_id"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Car ID"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DriveTableAdapter
        '
        Me.DriveTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.carTableAdapter = Me.CarTableAdapter
        Me.TableAdapterManager.channel_nameTableAdapter = Nothing
        Me.TableAdapterManager.copy_dataTableAdapter = Nothing
        Me.TableAdapterManager.dataTableAdapter = Nothing
        Me.TableAdapterManager.driveTableAdapter = Me.DriveTableAdapter
        Me.TableAdapterManager.ids_canbusTableAdapter = Nothing
        Me.TableAdapterManager.loggerTableAdapter = Nothing
        Me.TableAdapterManager.measureTableAdapter = Nothing
        Me.TableAdapterManager.photosTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.usage_typeTableAdapter = Me.Usage_typeTableAdapter
        Me.TableAdapterManager.userTableAdapter = Me.UserTableAdapter
        '
        'CarTableAdapter
        '
        Me.CarTableAdapter.ClearBeforeFill = True
        '
        'Usage_typeTableAdapter
        '
        Me.Usage_typeTableAdapter.ClearBeforeFill = True
        '
        'UserTableAdapter
        '
        Me.UserTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.carTableAdapter = Nothing
        Me.TableAdapterManager1.channel_nameTableAdapter = Nothing
        Me.TableAdapterManager1.Connection = Nothing
        Me.TableAdapterManager1.copy_dataTableAdapter = Nothing
        Me.TableAdapterManager1.dataTableAdapter = Nothing
        Me.TableAdapterManager1.driveTableAdapter = Nothing
        Me.TableAdapterManager1.ids_canbusTableAdapter = Nothing
        Me.TableAdapterManager1.loggerTableAdapter = Nothing
        Me.TableAdapterManager1.measureTableAdapter = Nothing
        Me.TableAdapterManager1.photosTableAdapter = Nothing
        Me.TableAdapterManager1.UpdateOrder = FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager1.usage_typeTableAdapter = Nothing
        Me.TableAdapterManager1.userTableAdapter = Nothing
        '
        'FfedatabaseDataSetBindingSource
        '
        Me.FfedatabaseDataSetBindingSource.DataSource = Me.Ffe_databaseDataSet
        Me.FfedatabaseDataSetBindingSource.Position = 0
        '
        'Form_drive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1221, 664)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.MinimumSize = New System.Drawing.Size(1237, 700)
        Me.Name = "Form_drive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Drive configuration"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DriveBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ffe_databaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DriveBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DriveBindingNavigator.ResumeLayout(False)
        Me.DriveBindingNavigator.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pn_importer.ResumeLayout(False)
        Me.pn_importer.PerformLayout()
        CType(Me.ImporterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pn_car.ResumeLayout(False)
        Me.pn_car.PerformLayout()
        CType(Me.CarBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PhotoPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pn_driver.ResumeLayout(False)
        Me.pn_driver.PerformLayout()
        CType(Me.UserBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PhotoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsagetypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DriveDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FfedatabaseDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Ffe_databaseDataSet As FfE.ffe_databaseDataSet
    Friend WithEvents DriveBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DriveTableAdapter As FfE.ffe_databaseDataSetTableAdapters.driveTableAdapter
    Friend WithEvents TableAdapterManager As FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents DriveBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents Drive_idLabel1 As System.Windows.Forms.Label
    Friend WithEvents date_driver As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_description As System.Windows.Forms.TextBox
    Friend WithEvents cmb_usage As System.Windows.Forms.ComboBox
    Friend WithEvents TableAdapterManager1 As FfE.ffe_databaseDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmb_status As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_climate As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_drive_type As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents pn_car As System.Windows.Forms.Panel
    Friend WithEvents btn_expandir_car As System.Windows.Forms.Button
    Friend WithEvents cmb_car As System.Windows.Forms.ComboBox
    Friend WithEvents pn_driver As System.Windows.Forms.Panel
    Friend WithEvents btn_expandir_driver As System.Windows.Forms.Button
    Friend WithEvents cmb_driver As System.Windows.Forms.ComboBox
    Friend WithEvents UserTableAdapter As FfE.ffe_databaseDataSetTableAdapters.userTableAdapter
    Friend WithEvents UserBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NameLabel1 As System.Windows.Forms.Label
    Friend WithEvents VornameLabel1 As System.Windows.Forms.Label
    Friend WithEvents User_idLabel1 As System.Windows.Forms.Label
    Friend WithEvents PhotoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CarTableAdapter As FfE.ffe_databaseDataSetTableAdapters.carTableAdapter
    Friend WithEvents CarBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OwnerLabel1 As System.Windows.Forms.Label
    Friend WithEvents TypeLabel1 As System.Windows.Forms.Label
    Friend WithEvents License_plateLabel1 As System.Windows.Forms.Label
    Friend WithEvents NameLabel3 As System.Windows.Forms.Label
    Friend WithEvents Car_idLabel1 As System.Windows.Forms.Label
    Friend WithEvents PhotoPictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Usage_typeTableAdapter As FfE.ffe_databaseDataSetTableAdapters.usage_typeTableAdapter
    Friend WithEvents UsagetypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FfedatabaseDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents find_drive As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_import As System.Windows.Forms.Button
    Friend WithEvents btn_export As System.Windows.Forms.Button
    Friend WithEvents DriveBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_find_drive As System.Windows.Forms.ToolStripButton
    Friend WithEvents pn_importer As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_importer As System.Windows.Forms.Button
    Friend WithEvents cmb_importer As System.Windows.Forms.ComboBox
    Friend WithEvents ImporterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents DriveDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
