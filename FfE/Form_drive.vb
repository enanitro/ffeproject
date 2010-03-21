Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_drive
    Dim estado_drive As Boolean = False
    Dim estado_car As Boolean = False
    Dim estado_importer As Boolean = False
    Dim binding_complete As Integer = 0
    Dim rows As Integer
    Dim combo As Boolean = False


    Private Sub Form_drive_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Me.Ffe_databaseDataSet.HasChanges() Or rows <> DriveDataGridView.Rows.Count Or combo = True Then
                If MsgBox("Do you want to save changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Me.Validate()
                    Me.DriveBindingSource.EndEdit()
                    Me.DriveTableAdapter.Update(Me.Ffe_databaseDataSet.drive)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form_drive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Incializacion de los combos
            Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
            load_combobox(cmb_driver, "select user_id, concat(cast(user_id as char), ' - ', vorname, ' ', name) as valor from user", connection)
            load_combobox(cmb_car, "select car_id, concat(cast(car_id as char), ' - ', name) as valor from car", connection)
            load_combobox(cmb_importer, "select user_id, concat(cast(user_id as char), ' - ', vorname, ' ', name) as valor from user", connection)



            'TODO: esta línea de código carga datos en la tabla 'Ffe_databaseDataSet.usage_type' Puede moverla o quitarla según sea necesario.
            Me.Usage_typeTableAdapter.Fill(Me.Ffe_databaseDataSet.usage_type)
            'TODO: esta línea de código carga datos en la tabla 'Ffe_databaseDataSet.car' Puede moverla o quitarla según sea necesario.
            Me.CarTableAdapter.Fill(Me.Ffe_databaseDataSet.car)
            'TODO: esta línea de código carga datos en la tabla 'Ffe_databaseDataSet.car' Puede moverla o quitarla según sea necesario.
            Me.CarTableAdapter.Fill(Me.Ffe_databaseDataSet.car)
            'TODO: esta línea de código carga datos en la tabla 'Ffe_databaseDataSet.user' Puede moverla o quitarla según sea necesario.
            Me.UserTableAdapter.Fill(Me.Ffe_databaseDataSet.user)
            'TODO: esta línea de código carga datos en la tabla 'Ffe_databaseDataSet.drive' Puede moverla o quitarla según sea necesario.
            Me.DriveTableAdapter.Fill(Me.Ffe_databaseDataSet.drive)

            DriveDataGridView.Sort(DriveDataGridView.Columns.Item(0), _
                                      System.ComponentModel.ListSortDirection.Ascending)

            rows = DriveDataGridView.Rows.Count
            combo = False
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_expandir_driver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_expandir_driver.Click
        If Me.cmb_driver.Text <> "" Then
            If Not estado_drive Then
                Me.btn_expandir_driver.BackgroundImage = FfE.My.Resources.btn_contraer
                estado_drive = Not estado_drive
                Me.pn_driver.Height = 150
                Me.pn_car.Location = New Point(pn_car.Location.X, pn_car.Location.Y + 150)
                Me.pn_importer.Location = New Point(pn_importer.Location.X, pn_importer.Location.Y + 150)
            Else
                Me.btn_expandir_driver.BackgroundImage = FfE.My.Resources.btn_expandir
                estado_drive = Not estado_drive
                Me.pn_driver.Height = 38
                Me.pn_car.Location = New Point(pn_car.Location.X, pn_car.Location.Y - 150)
                Me.pn_importer.Location = New Point(pn_importer.Location.X, pn_importer.Location.Y - 150)
            End If
        End If
    End Sub

    Private Sub btn_expandir_car_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_expandir_car.Click
        If cmb_car.Text <> "" Then
            If Not estado_car Then
                Me.btn_expandir_car.BackgroundImage = FfE.My.Resources.btn_contraer
                estado_car = Not estado_car
                Me.pn_car.Height = 150
                Me.pn_importer.Location = New Point(pn_importer.Location.X, pn_importer.Location.Y + 150)
            Else
                Me.btn_expandir_car.BackgroundImage = FfE.My.Resources.btn_expandir
                estado_car = Not estado_car
                Me.pn_car.Height = 38
                Me.pn_importer.Location = New Point(pn_importer.Location.X, pn_importer.Location.Y - 150)
            End If
        End If
    End Sub

    Private Sub btn_importer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_importer.Click
        If cmb_importer.Text <> "" Then
            If Not estado_importer Then
                Me.btn_importer.BackgroundImage = FfE.My.Resources.btn_contraer
                estado_importer = Not estado_importer
                Me.pn_importer.Height = 150
            Else
                Me.btn_importer.BackgroundImage = FfE.My.Resources.btn_expandir
                estado_importer = Not estado_importer
                Me.pn_importer.Height = 38
            End If
        End If
    End Sub

    Private Sub load_combobox(ByVal ComboBox As ComboBox, ByVal sql As String, ByVal cs As String)
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(cs)

        Try

            ' Abrir la conexión a Sql  
            cn.Open()

            ' Pasar la consulta sql y la conexión al Sql Command   
            Dim cmd As New MySqlCommand(sql, cn)

            ' Inicializar un nuevo SqlDataAdapter   
            Dim da As New MySqlDataAdapter(cmd)

            'Crear y Llenar un Dataset  
            Dim ds As New DataSet
            da.Fill(ds)

            ' asignar el DataSource al combobox  
            ComboBox.DataSource = ds.Tables(0)

            ' Asignar el campo a la propiedad DisplayMember del combo   
            ComboBox.ValueMember = ds.Tables(0).Columns(0).Caption.ToString
            ComboBox.DisplayMember = ds.Tables(0).Columns(1).Caption.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub cmb_driver_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_driver.GotFocus
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        load_combobox(cmb_driver, "select user_id, concat(cast(user_id as char), ' - ', vorname, ' ', name) as valor from user", connection)
    End Sub



    Private Sub cmb_driver_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_driver.SelectedIndexChanged
        Try
            If IsNumeric(Me.cmb_driver.SelectedValue) Then
                Me.UserBindingSource.Filter = "user_id = " + CStr(Me.cmb_driver.SelectedValue)
            End If
            If cmb_driver.SelectedIndex <> -1 And Me.DriveBindingSource.Position <> -1 Then
                Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(6) = Me.cmb_driver.SelectedItem(0)
            End If
        Catch
        End Try
    End Sub

    Private Sub cmb_car_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_car.GotFocus
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        load_combobox(cmb_car, "select car_id, concat(cast(car_id as char), ' - ', name) as valor from car", connection)
    End Sub

    Private Sub cmb_car_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_car.SelectedIndexChanged
        Try
            If IsNumeric(Me.cmb_car.SelectedValue) Then
                Me.CarBindingSource.Filter = "car_id = " + CStr(Me.cmb_car.SelectedValue)
            End If
            If cmb_car.SelectedIndex <> -1 And Me.DriveBindingSource.Position <> -1 Then
                Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(8) = Me.cmb_car.SelectedItem(0)
            End If
        Catch
        End Try
    End Sub

    Private Sub cmb_importer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_importer.GotFocus
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        load_combobox(cmb_importer, "select user_id, concat(cast(user_id as char), ' - ', vorname, ' ', name) as valor from user", connection)
    End Sub

    Private Sub cmb_importer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_importer.SelectedIndexChanged
        Try
            If IsNumeric(Me.cmb_importer.SelectedValue) Then
                Me.ImporterBindingSource.Filter = "user_id = " + CStr(Me.cmb_importer.SelectedValue)
            End If
            If cmb_importer.SelectedIndex <> -1 And Me.DriveBindingSource.Position <> -1 Then
                Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(7) = Me.cmb_importer.SelectedItem(0)
            End If
        Catch
        End Try
    End Sub

    Private Sub cmb_climate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_climate.SelectedIndexChanged
        If cmb_climate.SelectedIndex <> -1 And Me.DriveBindingSource.Position <> -1 Then
            Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(2) = Me.cmb_climate.SelectedItem
            combo = True
        End If
    End Sub

    Private Sub cmb_status_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_status.SelectedIndexChanged
        If cmb_status.SelectedIndex <> -1 And Me.DriveBindingSource.Position <> -1 Then
            Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(1) = Me.cmb_status.SelectedItem
            combo = True
        End If
    End Sub

    Private Sub cmb_drive_type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_drive_type.SelectedIndexChanged
        If cmb_drive_type.SelectedIndex <> -1 And Me.DriveBindingSource.Position <> -1 Then
            Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(9) = Me.cmb_drive_type.SelectedItem
            combo = True
        End If
    End Sub

    Private Sub cmb_usage_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_usage.GotFocus
        Me.Usage_typeTableAdapter.Fill(Me.Ffe_databaseDataSet.usage_type)
    End Sub

    Private Sub cmb_usage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_usage.SelectedIndexChanged

        If cmb_usage.SelectedIndex <> -1 And Me.DriveBindingSource.Position <> -1 Then
            Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(5) = Me.cmb_usage.SelectedValue
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            Me.Validate()
            Me.DriveBindingSource.EndEdit()
            Me.DriveTableAdapter.Update(Me.Ffe_databaseDataSet)
            DriveDataGridView.Sort(DriveDataGridView.Columns.Item(0), _
                                      System.ComponentModel.ListSortDirection.Ascending)

            rows = DriveDataGridView.Rows.Count
            Drive_idLabel1.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'No cambiar el orden
        cerrar_paneles()
        posicionar_combos()
    End Sub

    Private Sub posicionar_combos()
        Me.cmb_car.SelectedIndex = -1
        Me.cmb_climate.SelectedIndex = -1
        Me.cmb_drive_type.SelectedIndex = -1
        Me.cmb_driver.SelectedIndex = -1
        Me.cmb_importer.SelectedIndex = -1
        Me.cmb_status.SelectedIndex = -1
        Me.cmb_usage.SelectedIndex = -1
    End Sub

    Private Sub cerrar_paneles()
        If estado_car = True Then
            btn_expandir_car_Click(Me.btn_expandir_car, New System.EventArgs)
        End If

        If estado_drive = True Then
            btn_expandir_driver_Click(Me.btn_expandir_driver, New System.EventArgs)
        End If

        If estado_importer = True Then
            btn_importer_Click(Me.btn_importer, New System.EventArgs)
        End If
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Try
            Me.Validate()
            Me.DriveBindingSource.EndEdit()
            Me.DriveTableAdapter.Update(Me.Ffe_databaseDataSet)
            Ffe_databaseDataSet.drive.AcceptChanges()
            DriveDataGridView.Sort(DriveDataGridView.Columns.Item(0), _
                                      System.ComponentModel.ListSortDirection.Ascending)

            rows = DriveDataGridView.Rows.Count
            combo = False
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
    '    If MsgBox("Are you sure you want to delete the driver?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete driver") = MsgBoxResult.No Then
    '       Exit Sub
    '    End If
    'End Sub

    'Este procedimiento cambia el valor de los combos sincronizando con el valor de los datos 
    Private Sub data_2_combo()
        If Me.DriveBindingSource.Position <> -1 Then
            If Not Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(6).Equals(DBNull.Value) Then
                Me.cmb_driver.SelectedValue = Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(6)
            Else
                Me.cmb_driver.SelectedIndex = -1
            End If
            If Not Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(7).Equals(DBNull.Value) Then
                Me.cmb_importer.SelectedValue = Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(7)
            Else
                Me.cmb_importer.SelectedIndex = -1
            End If
            If Not Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(8).Equals(DBNull.Value) Then
                Me.cmb_car.SelectedValue = Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(8)
            Else
                Me.cmb_car.SelectedIndex = -1
            End If
            If Not Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(1).Equals(DBNull.Value) Then
                Me.cmb_status.SelectedItem = Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(1)
            Else
                Me.cmb_status.SelectedIndex = -1
            End If
            If Not Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(2).Equals(DBNull.Value) Then
                Me.cmb_climate.SelectedItem = Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(2)
            Else
                Me.cmb_climate.SelectedIndex = -1
            End If
            If Not Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(5).Equals(DBNull.Value) Then
                Me.cmb_usage.SelectedValue = Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(5)
            Else
                Me.cmb_usage.SelectedIndex = -1
            End If
            If Not Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(9).Equals(DBNull.Value) Then
                Me.cmb_drive_type.SelectedItem = Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(9)
            Else
                Me.cmb_drive_type.SelectedIndex = -1
            End If
        Else
            cerrar_paneles()
            posicionar_combos()
        End If

    End Sub

    Private Sub DriveBindingSource_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DriveBindingSource.PositionChanged
        'Mostrar datos en combo
        data_2_combo()
        combo = False
    End Sub

    'Private Sub View_data_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles View_data.CellClick
    '    View_data.Rows(e.RowIndex).Selected = True
    'End Sub


    Private Sub btn_import_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_import.Click
        Try
            Me.Validate()
            Me.DriveBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.Ffe_databaseDataSet)
            Dim import_full As New form_import_csv_full
            If Me.DriveBindingSource.Position <> -1 Then
                If Not Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(0).Equals(DBNull.Value) Then
                    import_full.id_drive = Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(0)
                    import_full.ShowDialog()
                    show_Data()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Drive_idLabel1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Drive_idLabel1.TextChanged
        show_Data()
    End Sub

    Private Sub btn_find_drive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_find_drive.Click
        Try
            Dim find_drive As New Form_find_drive
            find_drive.ShowDialog()
            Me.DriveBindingSource.Position = Me.DriveBindingSource.Find("drive_id", find_drive.Drive_fullDataGridView.CurrentRow.Cells.Item(0).Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        If Drive_idLabel1.Text <> "" Then
            Dim index As Integer = TabControl1.SelectedIndex + 1
            Select Case index
                Case FfE_Main.id_graphtec
                    Me.Data_fullTableAdapter.FillBydatafull _
                    (Me.Ffe_databaseDataSet.data_full, Drive_idLabel1.Text, FfE_Main.id_graphtec)
                    grid_configuration(Data_fullDataGridView)
                Case FfE_Main.id_gps
                    Me.Data_fullTableAdapter.FillBydatafull _
                    (Me.Ffe_databaseDataSet.data_full, Drive_idLabel1.Text, FfE_Main.id_gps)
                    grid_configuration(DataGridView1)
                Case FfE_Main.id_fluke
                    Me.Data_fullTableAdapter.FillBydatafull _
                    (Me.Ffe_databaseDataSet.data_full, Drive_idLabel1.Text, FfE_Main.id_fluke)
                    grid_configuration(DataGridView2)
                Case FfE_Main.id_canbus
                    Me.Data_fullTableAdapter.FillBydatafull _
                    (Me.Ffe_databaseDataSet.data_full, Drive_idLabel1.Text, FfE_Main.id_canbus)
                    grid_configuration(DataGridView3)
            End Select
        End If
    End Sub

    Private Sub grid_configuration(ByRef grid As DataGridView)
        grid.DataSource = ""
        grid.DataSource = Data_fullBindingSource
        grid.Columns.Remove(grid.Columns.Item(1))
        grid.Columns.Remove(grid.Columns.Item(1))
        grid.Columns.Remove(grid.Columns.Item(1))
        grid.Columns.Remove(grid.Columns.Item(3))
        grid.Columns.Item(0).HeaderText = "Data id"
        grid.Columns.Item(0).Width = 250
        grid.Columns.Item(1).HeaderText = "Time"
        grid.Columns.Item(2).HeaderText = "Value"
        grid.Columns.Item(3).HeaderText = "Unit"
        grid.Columns.Item(4).HeaderText = "Time step"
    End Sub

    Private Sub clear_grid(ByRef grid As DataGridView)
        grid.DataSource = ""
    End Sub

    Private Sub show_Data()
        clear_grid(Data_fullDataGridView)
        clear_grid(DataGridView1)
        clear_grid(DataGridView2)
        clear_grid(DataGridView3)
        TabControl1.SelectedIndex = 0
        Me.Data_fullTableAdapter.FillBydatafull _
        (Me.Ffe_databaseDataSet.data_full, Drive_idLabel1.Text, FfE_Main.id_graphtec)
        grid_configuration(Data_fullDataGridView)
        data_summary(Label19.Text, Label20.Text, Label21.Text, Label22.Text, Label23.Text)
    End Sub


    Private Sub data_summary(ByRef graphtec As String, ByRef gps As String, ByRef fluke As String, _
                             ByRef canbus As String, ByRef total As String)
        Dim x, y, tot_p, tot_ch As Integer
        tot_ch = 0
        tot_p = 0
        x = 0
        y = 0
        data_points_channels(x, y, FfE_Main.id_graphtec)
        tot_p += x
        tot_ch += y
        graphtec = x & " data points" & " (" & y & " channels)"
        data_points_channels(x, y, FfE_Main.id_gps)
        tot_p += x
        tot_ch += y
        gps = x & " data points" & " (" & y & " channels)"
        data_points_channels(x, y, FfE_Main.id_fluke)
        tot_p += x
        tot_ch += y
        fluke = x & " data points" & " (" & y & " channels)"
        data_points_channels(x, y, FfE_Main.id_canbus)
        tot_p += x
        tot_ch += y
        canbus = x & " data points" & " (" & y & " channels)"
        total = tot_p & " data points" & " (" & tot_ch & " channels)"
    End Sub

    Private Sub data_points_channels(ByRef points As String, ByRef channels As String, ByVal logger As Integer)
        execute_query("select count(*) from data where drive_id = " & Drive_idLabel1.Text _
                      & " and logger_id = " & logger, points)
        execute_query("select count(distinct data_id) from data where drive_id = " & Drive_idLabel1.Text _
                      & " and logger_id = " & logger, channels)
    End Sub

    Private Sub execute_query(ByVal sql As String, ByRef res As String)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim text As String = ""

        Try

            ' Abrir la conexión a Sql  
            cn.Open()

            ' Pasar la consulta sql y la conexión al Sql Command
            cmd.Connection = cn
            cmd.CommandText = sql
            query = cmd.ExecuteReader()
            query.Read()
            If query.HasRows() Then res = query.GetString(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub


    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delete.Click
        Try
            If MsgBox("Are you sure you want to delete this information?", _
                      MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                DriveBindingNavigator.Items(3).Visible = True
                DriveBindingNavigator.Items(3).PerformClick()
                DriveBindingNavigator.Items(3).Visible = False
                rows = Ffe_databaseDataSet.drive.Count
                If rows = 0 Then Drive_idLabel1.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripButton1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButton1.MouseUp
        sort_index()
    End Sub

    Private Sub sort_index()
        Try
            Dim current As Integer = 1
            For i = 1 To DriveDataGridView.Rows.Count
                If DriveDataGridView.Rows.Item(i - 1).Cells.Item(0).Value <> i Then
                    DriveDataGridView.Rows.Item(DriveDataGridView.Rows.Count - 1) _
                    .Cells.Item(0).Value = i
                    current = i
                    DriveDataGridView.Sort(DriveDataGridView.Columns.Item(0), _
                                          System.ComponentModel.ListSortDirection.Ascending)
                    DriveDataGridView.CurrentCell = _
                    DriveDataGridView.Rows.Item(current - 1).Cells.Item(1)
                    DriveDataGridView.ClearSelection()
                    i = DriveDataGridView.Rows.Count
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    
    Private Sub btn_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export.Click
        Try
            SaveFileDialog.Filter() = "CSV Files(*.csv)|*.csv;"
            If SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                export.Visible = True
                head_csv_file(SaveFileDialog.FileName)
                logger_csv_file(SaveFileDialog.FileName, FfE_Main.id_graphtec, "GRAPHTEC GL800", Label19.Text)
                logger_csv_file(SaveFileDialog.FileName, FfE_Main.id_gps, "COLUMBUS GPS", Label20.Text)
                logger_csv_file(SaveFileDialog.FileName, FfE_Main.id_fluke, "FLUKE", Label21.Text)
                logger_csv_file(SaveFileDialog.FileName, FfE_Main.id_canbus, "CAN-BUS", Label22.Text)
                MsgBox("Data-loggers were imported successfully", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            export.Visible = False
        End Try
    End Sub

    'configuracion del progressbar y labels que le acompañan
    Public Sub config_progressbar(ByVal max As Integer)
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = max
    End Sub

    'controla el objeto progressbar
    Public Sub progressbar(ByVal val As Integer)
        ProgressBar1.Value = val

        ' Visualizamos el porcentaje en el Label
        Label24.Text = CLng((ProgressBar1.Value * 100) / ProgressBar1.Maximum) & " %"
    End Sub

    Private Sub calculate_max(ByRef max As Integer, ByVal logger_id As Integer)
        Try
            Dim points, channels As Integer
            data_points_channels(points, channels, logger_id)
            max = points / channels
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub head_csv_file(ByVal path As String)
        Try
            Dim text As String
            Dim sw As New System.IO.StreamWriter(path)
            text = "DRIVE ID: " & Drive_idLabel1.Text & vbCrLf & _
                           "CAR: " & cmb_car.Text & vbCrLf & _
                           "CLIMATE: " & cmb_climate.Text & vbCrLf & _
                           "STATUS: " & cmb_status.Text & vbCrLf & _
                           "DRIVE TYPE: " & cmb_drive_type.Text & vbCrLf & _
                           "USAGE TYPE: " & cmb_usage.Text & vbCrLf & _
                           "DRIVER: " & cmb_driver.Text & vbCrLf & _
                           "IMPORTER: " & cmb_importer.Text & vbCrLf & _
                           "DATE: " & date_driver.Text & vbCrLf & _
                           "DESCRIPTION: " & txt_description.Text & vbCrLf & vbCrLf
            sw.WriteLine(text)
            sw.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub logger_csv_file(ByVal path As String, ByVal logger_id As Integer, _
                                ByVal logger As String, ByVal points As String)
        Try
            Dim text, sql, res As String
            Dim sw As New System.IO.StreamWriter(path, True)

            res = ""
            sql = "select timestep from data_full where drive_id = " & Drive_idLabel1.Text & _
                  " and logger_id = " & logger_id
            execute_query(sql, res)
            If res <> "" Then
                text = logger & vbCrLf & _
                        points & vbCrLf & _
                        "TIME STEP: " & res & vbCrLf
                sw.WriteLine(text)

                Select Case logger_id
                    Case FfE_Main.id_graphtec : execute_query_graphtec_gps_fluke(res, logger_id, logger)
                    Case FfE_Main.id_gps : execute_query_graphtec_gps_fluke(res, logger_id, logger)
                    Case FfE_Main.id_fluke : execute_query_graphtec_gps_fluke(res, logger_id, logger)
                    Case FfE_Main.id_canbus : execute_query_canbus(res)
                End Select
                sw.WriteLine(res)

            End If
            sw.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub execute_query_graphtec_gps_fluke(ByRef res As String, ByVal logger_id As Integer, _
                                                 ByVal logger As String)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sql As String
        Dim count, distinct, i, max As Integer
        res = ""

        Try

            ' Abrir la conexión a Sql  
            cn.Open()
            cmd.Connection = cn

            ' Pasar la consulta sql y la conexión al Sql Command
            sql = "select count(distinct data_id) from data_full where drive_id = " & Drive_idLabel1.Text & _
              " and logger_id = " & logger_id
            execute_query(sql, distinct)
            sql = "select distinct data_id, unit from data_full where drive_id = " & Drive_idLabel1.Text & _
              " and logger_id = " & logger_id
            cmd.CommandText = sql
            query = cmd.ExecuteReader()

            res = "INDEX,TIME"
            For i = 1 To distinct
                query.Read()
                res += "," & query.GetString(0) & "[" & query.GetString(1) & "]"
            Next
            res += vbCrLf
            cn.Close()

            cn.Open()
            sql = "select count(value) from data_full where drive_id = " & Drive_idLabel1.Text & _
              " and logger_id = " & logger_id & " order by data_index"
            execute_query(sql, count)
            sql = "select time,value from data_full where drive_id = " & Drive_idLabel1.Text & _
              " and logger_id = " & logger_id & " order by data_index"
            cmd.CommandText = sql
            query = cmd.ExecuteReader()


            Label25.Text = "Exporting " & logger & " logger"
            calculate_max(max, logger_id)
            config_progressbar(max)
            i = 1
            count = count / distinct
            query.Read()
            Do While i <= count
                res += i & "," & query.GetString(0)
                For j = 1 To distinct
                    res += "," & query.GetString(1).Replace(",", ".")
                    query.Read()
                Next
                progressbar(i)
                i += 1
                res += vbCrLf
                Application.DoEvents()
            Loop
            res += vbCrLf
            cn.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub


    Private Sub execute_query_canbus(ByRef res As String)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim text, sql As String
        Dim count, distinct, i As Integer
        res = ""

        Try

            ' Abrir la conexión a Sql  
            cn.Open()
            cmd.Connection = cn

            ' Pasar la consulta sql y la conexión al Sql Command
            'sql = "select count(distinct data_id) from data_full where drive_id = " & Drive_idLabel1.Text & _
            ' " and logger_id = " & FfE_Main.id_canbus
            'execute_query(sql, distinct)
            'sql = "select distinct data_id, unit from data_full where drive_id = " & Drive_idLabel1.Text & _
            '  " and logger_id = " & FfE_Main.id_canbus
            'cmd.CommandText = sql
            'query = cmd.ExecuteReader()

            res = "INDEX,TIME,CHANNEL,UNIT,VALUE"
            'For i = 1 To distinct
            'query.Read()
            'res += "," & query.GetString(0) & "[" & query.GetString(1) & "]"
            'Next
            res += vbCrLf
            'cn.Close()

            'cn.Open()
            sql = "select count(value) from data_full where drive_id = " & Drive_idLabel1.Text & _
              " and logger_id = " & FfE_Main.id_canbus & " order by data_index"
            execute_query(sql, count)
            sql = "select time,data_id,unit,value from data_full where drive_id = " & Drive_idLabel1.Text & _
              " and logger_id = " & FfE_Main.id_canbus & " order by data_index"
            cmd.CommandText = sql
            query = cmd.ExecuteReader()

            i = 1
            'count = count / distinct
            Label25.Text = "Exporting CAN-BUS logger"
            query.Read()
            Do While i <= count
                res += i & "," & query.GetString(0) & "," & query.GetString(1) & _
                "," & query.GetString(2) & "," & query.GetString(3).Replace(",", ".")
                query.Read()

                progressbar(i)
                i += 1
                res += vbCrLf
                Application.DoEvents()
            Loop
            cn.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

End Class