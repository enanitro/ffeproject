<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_export_full
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_export_full))
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button10 = New System.Windows.Forms.Button
        Me.btn_export = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.percent_canbus = New System.Windows.Forms.Label
        Me.path_canbus = New System.Windows.Forms.Label
        Me.ProgressBar4 = New System.Windows.Forms.ProgressBar
        Me.Button3 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.percent_gps = New System.Windows.Forms.Label
        Me.path_gps = New System.Windows.Forms.Label
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.percent_fluke = New System.Windows.Forms.Label
        Me.path_fluke = New System.Windows.Forms.Label
        Me.ProgressBar3 = New System.Windows.Forms.ProgressBar
        Me.Button4 = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.percent_graphtec = New System.Windows.Forms.Label
        Me.path_graphtec = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.description = New System.Windows.Forms.Label
        Me.importer = New System.Windows.Forms.Label
        Me.car = New System.Windows.Forms.Label
        Me.driver = New System.Windows.Forms.Label
        Me.usage_type = New System.Windows.Forms.Label
        Me.drive_type = New System.Windows.Forms.Label
        Me.status = New System.Windows.Forms.Label
        Me.climate = New System.Windows.Forms.Label
        Me.datef = New System.Windows.Forms.Label
        Me.drive_id = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.Controls.Add(Me.Button10)
        Me.Panel1.Controls.Add(Me.btn_export)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(987, 516)
        Me.Panel1.TabIndex = 0
        '
        'Button10
        '
        Me.Button10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Button10.Image = Global.FfE.My.Resources.Resources.exit1
        Me.Button10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button10.Location = New System.Drawing.Point(506, 403)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(144, 105)
        Me.Button10.TabIndex = 33
        Me.Button10.UseVisualStyleBackColor = True
        '
        'btn_export
        '
        Me.btn_export.BackgroundImage = CType(resources.GetObject("btn_export.BackgroundImage"), System.Drawing.Image)
        Me.btn_export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_export.Location = New System.Drawing.Point(337, 403)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(144, 105)
        Me.btn_export.TabIndex = 30
        Me.btn_export.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.percent_canbus)
        Me.GroupBox4.Controls.Add(Me.path_canbus)
        Me.GroupBox4.Controls.Add(Me.ProgressBar4)
        Me.GroupBox4.Controls.Add(Me.Button3)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox4.Location = New System.Drawing.Point(506, 275)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(468, 114)
        Me.GroupBox4.TabIndex = 32
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "CAN-BUS"
        '
        'percent_canbus
        '
        Me.percent_canbus.AutoSize = True
        Me.percent_canbus.Location = New System.Drawing.Point(246, 51)
        Me.percent_canbus.Name = "percent_canbus"
        Me.percent_canbus.Size = New System.Drawing.Size(27, 15)
        Me.percent_canbus.TabIndex = 13
        Me.percent_canbus.Text = "0%"
        Me.percent_canbus.Visible = False
        '
        'path_canbus
        '
        Me.path_canbus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.path_canbus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.path_canbus.Location = New System.Drawing.Point(96, 20)
        Me.path_canbus.Name = "path_canbus"
        Me.path_canbus.Size = New System.Drawing.Size(356, 18)
        Me.path_canbus.TabIndex = 11
        Me.path_canbus.Text = "path"
        Me.path_canbus.Visible = False
        '
        'ProgressBar4
        '
        Me.ProgressBar4.Location = New System.Drawing.Point(96, 74)
        Me.ProgressBar4.Name = "ProgressBar4"
        Me.ProgressBar4.Size = New System.Drawing.Size(356, 23)
        Me.ProgressBar4.TabIndex = 4
        Me.ProgressBar4.Visible = False
        '
        'Button3
        '
        Me.Button3.Image = Global.FfE.My.Resources.Resources.find_excel
        Me.Button3.Location = New System.Drawing.Point(9, 20)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 77)
        Me.Button3.TabIndex = 3
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.percent_gps)
        Me.GroupBox3.Controls.Add(Me.path_gps)
        Me.GroupBox3.Controls.Add(Me.ProgressBar2)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(506, 146)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(468, 114)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Columbus GPS"
        '
        'percent_gps
        '
        Me.percent_gps.AutoSize = True
        Me.percent_gps.Location = New System.Drawing.Point(246, 51)
        Me.percent_gps.Name = "percent_gps"
        Me.percent_gps.Size = New System.Drawing.Size(27, 15)
        Me.percent_gps.TabIndex = 13
        Me.percent_gps.Text = "0%"
        Me.percent_gps.Visible = False
        '
        'path_gps
        '
        Me.path_gps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.path_gps.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.path_gps.Location = New System.Drawing.Point(96, 20)
        Me.path_gps.Name = "path_gps"
        Me.path_gps.Size = New System.Drawing.Size(356, 18)
        Me.path_gps.TabIndex = 11
        Me.path_gps.Text = "path"
        Me.path_gps.Visible = False
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(96, 74)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(356, 23)
        Me.ProgressBar2.TabIndex = 4
        Me.ProgressBar2.Visible = False
        '
        'Button2
        '
        Me.Button2.Image = Global.FfE.My.Resources.Resources.find_excel
        Me.Button2.Location = New System.Drawing.Point(9, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 77)
        Me.Button2.TabIndex = 3
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.percent_fluke)
        Me.GroupBox5.Controls.Add(Me.path_fluke)
        Me.GroupBox5.Controls.Add(Me.ProgressBar3)
        Me.GroupBox5.Controls.Add(Me.Button4)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 275)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(468, 114)
        Me.GroupBox5.TabIndex = 31
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "LMG 500"
        '
        'percent_fluke
        '
        Me.percent_fluke.AutoSize = True
        Me.percent_fluke.Location = New System.Drawing.Point(246, 51)
        Me.percent_fluke.Name = "percent_fluke"
        Me.percent_fluke.Size = New System.Drawing.Size(27, 15)
        Me.percent_fluke.TabIndex = 13
        Me.percent_fluke.Text = "0%"
        Me.percent_fluke.Visible = False
        '
        'path_fluke
        '
        Me.path_fluke.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.path_fluke.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.path_fluke.Location = New System.Drawing.Point(96, 20)
        Me.path_fluke.Name = "path_fluke"
        Me.path_fluke.Size = New System.Drawing.Size(356, 18)
        Me.path_fluke.TabIndex = 11
        Me.path_fluke.Text = "path"
        Me.path_fluke.Visible = False
        '
        'ProgressBar3
        '
        Me.ProgressBar3.Location = New System.Drawing.Point(96, 74)
        Me.ProgressBar3.Name = "ProgressBar3"
        Me.ProgressBar3.Size = New System.Drawing.Size(356, 23)
        Me.ProgressBar3.TabIndex = 4
        Me.ProgressBar3.Visible = False
        '
        'Button4
        '
        Me.Button4.Image = Global.FfE.My.Resources.Resources.find_excel
        Me.Button4.Location = New System.Drawing.Point(9, 20)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 77)
        Me.Button4.TabIndex = 3
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.percent_graphtec)
        Me.GroupBox2.Controls.Add(Me.path_graphtec)
        Me.GroupBox2.Controls.Add(Me.ProgressBar1)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 146)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(468, 114)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Graphtec GL800"
        '
        'percent_graphtec
        '
        Me.percent_graphtec.AutoSize = True
        Me.percent_graphtec.Location = New System.Drawing.Point(246, 51)
        Me.percent_graphtec.Name = "percent_graphtec"
        Me.percent_graphtec.Size = New System.Drawing.Size(27, 15)
        Me.percent_graphtec.TabIndex = 13
        Me.percent_graphtec.Text = "0%"
        Me.percent_graphtec.Visible = False
        '
        'path_graphtec
        '
        Me.path_graphtec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.path_graphtec.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.path_graphtec.Location = New System.Drawing.Point(96, 20)
        Me.path_graphtec.Name = "path_graphtec"
        Me.path_graphtec.Size = New System.Drawing.Size(356, 18)
        Me.path_graphtec.TabIndex = 11
        Me.path_graphtec.Text = "path"
        Me.path_graphtec.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(96, 74)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(356, 23)
        Me.ProgressBar1.TabIndex = 4
        Me.ProgressBar1.Visible = False
        '
        'Button1
        '
        Me.Button1.Image = Global.FfE.My.Resources.Resources.find_excel
        Me.Button1.Location = New System.Drawing.Point(9, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 77)
        Me.Button1.TabIndex = 3
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.description)
        Me.GroupBox1.Controls.Add(Me.importer)
        Me.GroupBox1.Controls.Add(Me.car)
        Me.GroupBox1.Controls.Add(Me.driver)
        Me.GroupBox1.Controls.Add(Me.usage_type)
        Me.GroupBox1.Controls.Add(Me.drive_type)
        Me.GroupBox1.Controls.Add(Me.status)
        Me.GroupBox1.Controls.Add(Me.climate)
        Me.GroupBox1.Controls.Add(Me.datef)
        Me.GroupBox1.Controls.Add(Me.drive_id)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(962, 115)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Drive"
        '
        'description
        '
        Me.description.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.description.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.description.Location = New System.Drawing.Point(748, 52)
        Me.description.Name = "description"
        Me.description.Size = New System.Drawing.Size(208, 40)
        Me.description.TabIndex = 19
        Me.description.Text = "Label11"
        '
        'importer
        '
        Me.importer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.importer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.importer.Location = New System.Drawing.Point(549, 79)
        Me.importer.Name = "importer"
        Me.importer.Size = New System.Drawing.Size(173, 15)
        Me.importer.TabIndex = 18
        Me.importer.Text = "Label11"
        '
        'car
        '
        Me.car.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.car.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.car.Location = New System.Drawing.Point(549, 54)
        Me.car.Name = "car"
        Me.car.Size = New System.Drawing.Size(173, 15)
        Me.car.TabIndex = 17
        Me.car.Text = "Label11"
        '
        'driver
        '
        Me.driver.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.driver.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.driver.Location = New System.Drawing.Point(549, 29)
        Me.driver.Name = "driver"
        Me.driver.Size = New System.Drawing.Size(173, 15)
        Me.driver.TabIndex = 16
        Me.driver.Text = "Label11"
        '
        'usage_type
        '
        Me.usage_type.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usage_type.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.usage_type.Location = New System.Drawing.Point(317, 79)
        Me.usage_type.Name = "usage_type"
        Me.usage_type.Size = New System.Drawing.Size(153, 15)
        Me.usage_type.TabIndex = 15
        Me.usage_type.Text = "Label11"
        '
        'drive_type
        '
        Me.drive_type.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drive_type.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.drive_type.Location = New System.Drawing.Point(317, 54)
        Me.drive_type.Name = "drive_type"
        Me.drive_type.Size = New System.Drawing.Size(153, 15)
        Me.drive_type.TabIndex = 14
        Me.drive_type.Text = "Label11"
        '
        'status
        '
        Me.status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.status.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.status.Location = New System.Drawing.Point(317, 29)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(153, 15)
        Me.status.TabIndex = 13
        Me.status.Text = "Label11"
        '
        'climate
        '
        Me.climate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.climate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.climate.Location = New System.Drawing.Point(86, 79)
        Me.climate.Name = "climate"
        Me.climate.Size = New System.Drawing.Size(143, 15)
        Me.climate.TabIndex = 12
        Me.climate.Text = "Label11"
        '
        'datef
        '
        Me.datef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datef.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.datef.Location = New System.Drawing.Point(86, 54)
        Me.datef.Name = "datef"
        Me.datef.Size = New System.Drawing.Size(143, 15)
        Me.datef.TabIndex = 11
        Me.datef.Text = "Label11"
        '
        'drive_id
        '
        Me.drive_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drive_id.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.drive_id.Location = New System.Drawing.Point(86, 29)
        Me.drive_id.Name = "drive_id"
        Me.drive_id.Size = New System.Drawing.Size(143, 15)
        Me.drive_id.TabIndex = 10
        Me.drive_id.Text = "Label11"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(745, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 15)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Description:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(483, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 15)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Importer:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(515, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 15)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Car:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(499, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 15)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Driver:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(234, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Usage type:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(238, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Drive Type:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(265, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Status:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Climate:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Date:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Drive ID:"
        '
        'Form_export_full
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1011, 540)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "Form_export_full"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export data drive"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents btn_export As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents percent_canbus As System.Windows.Forms.Label
    Friend WithEvents path_canbus As System.Windows.Forms.Label
    Friend WithEvents ProgressBar4 As System.Windows.Forms.ProgressBar
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents percent_gps As System.Windows.Forms.Label
    Friend WithEvents path_gps As System.Windows.Forms.Label
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents percent_fluke As System.Windows.Forms.Label
    Friend WithEvents path_fluke As System.Windows.Forms.Label
    Friend WithEvents ProgressBar3 As System.Windows.Forms.ProgressBar
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents percent_graphtec As System.Windows.Forms.Label
    Friend WithEvents path_graphtec As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents description As System.Windows.Forms.Label
    Friend WithEvents importer As System.Windows.Forms.Label
    Friend WithEvents car As System.Windows.Forms.Label
    Friend WithEvents driver As System.Windows.Forms.Label
    Friend WithEvents usage_type As System.Windows.Forms.Label
    Friend WithEvents drive_type As System.Windows.Forms.Label
    Friend WithEvents status As System.Windows.Forms.Label
    Friend WithEvents climate As System.Windows.Forms.Label
    Friend WithEvents datef As System.Windows.Forms.Label
    Friend WithEvents drive_id As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
