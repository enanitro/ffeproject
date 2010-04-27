Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_drive
    Dim estado_drive As Boolean = False
    Dim estado_car As Boolean = False
    Dim estado_importer As Boolean = False
    Dim binding_complete As Integer = 0
    Dim rows As Integer
    Dim combo As Boolean = False

    'Visión de ventanas 
    Dim show_Data As Form_view_data
    Dim form_export As Form_export_full
    Dim import_full As form_import_csv_full
    Dim del_channel As Form_delete_channel
    Dim form_fahrprofil As Form_fharprofil


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
            combo = True
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
            combo = True
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
            combo = True
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
            combo = True
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
            Me.DriveTableAdapter.Update(Me.Ffe_databaseDataSet.drive)
            Ffe_databaseDataSet.drive.AcceptChanges()
            DriveDataGridView.Sort(DriveDataGridView.Columns.Item(0), _
                                      System.ComponentModel.ListSortDirection.Ascending)

            rows = DriveDataGridView.Rows.Count
            combo = False
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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


    Private Sub btn_import_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_import.Click
        Try
            Me.Validate()
            Me.DriveBindingSource.EndEdit()
            Me.DriveTableAdapter.Update(Me.Ffe_databaseDataSet.drive)
            If import_full Is Nothing Then
                import_full = New form_import_csv_full
            Else
                If import_full.isClosed Then
                    import_full = New form_import_csv_full
                Else
                    import_full.Focus()
                End If
            End If

            If Me.DriveBindingSource.Position <> -1 Then
                If Not Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(0).Equals(DBNull.Value) Then
                    import_full.id_drive = Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(0)
                    import_full.MdiParent = Me.MdiParent
                    import_full.Show()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

   
    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delete.Click
        Try
            If MsgBox("Are you sure you want to delete this information?", _
                      MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                DriveBindingSource.RemoveCurrent()
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
            If form_export Is Nothing Then
                showExport()
            Else
                If form_export.isClosed Then
                    showExport()
                Else
                    form_export.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'export.Visible = False
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Drive_idLabel1.Text <> "" Then
            If Not show_Data Is Nothing Then
                If show_Data.isClosed Then
                    showData()
                Else
                    show_Data.Focus()
                End If
            Else
                showData()
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Drive_idLabel1.Text <> "" Then
            del_channel = New Form_delete_channel(Drive_idLabel1.Text)
            del_channel.ShowDialog()
        End If
    End Sub

    Private Sub showData()
        show_Data = New Form_view_data(Drive_idLabel1.Text)
        show_Data.lbl_drive_id.Text = Drive_idLabel1.Text
        show_Data.datef.Text = date_driver.Text
        show_Data.climate.Text = cmb_climate.Text
        show_Data.status.Text = cmb_status.Text
        show_Data.drive_type.Text = cmb_drive_type.Text
        show_Data.usage_type.Text = cmb_usage.Text
        show_Data.driver.Text = cmb_driver.Text
        show_Data.car.Text = cmb_car.Text
        show_Data.importer.Text = cmb_importer.Text
        show_Data.description.Text = txt_description.Text
        show_Data.MdiParent = Me.MdiParent
        show_Data.Show()
    End Sub

    Private Sub showExport()
        form_export = New Form_export_full
        form_export.drive_id.Text = Drive_idLabel1.Text
        form_export.datef.Text = date_driver.Text
        form_export.climate.Text = cmb_climate.Text
        form_export.status.Text = cmb_status.Text
        form_export.drive_type.Text = cmb_drive_type.Text
        form_export.usage_type.Text = cmb_usage.Text
        form_export.driver.Text = cmb_driver.Text
        form_export.car.Text = cmb_car.Text
        form_export.importer.Text = cmb_importer.Text
        form_export.description.Text = txt_description.Text
        form_export.MdiParent = Me.MdiParent
        form_export.Show()
    End Sub

    Private Sub showFahrprofil()
        If Not Me.DriveBindingSource.Item(Me.DriveBindingSource.Position)(5).Equals(DBNull.Value) Then
            Form_fharprofil.id_usage_type = DriveBindingSource.Item(DriveBindingSource.Position)(5)
            Form_fharprofil.MdiParent = Me.MdiParent
            Form_fharprofil.Show()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If form_fahrprofil Is Nothing Then
                showFahrprofil()
            Else
                If form_fahrprofil.isClosed Then
                    showFahrprofil()
                Else
                    form_export.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'export.Visible = False
        End Try
        
    End Sub

    Private Sub ToolStripButton5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButton5.MouseDown
        If combo = True Then
            Dim pos As Integer = DriveBindingSource.Position
            DriveTableAdapter.Fill(Ffe_databaseDataSet.drive)
            DriveBindingSource.Position = pos
        End If
    End Sub

    Private Sub ToolStripButton4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButton4.MouseDown
        If combo = True Then
            Dim pos As Integer = DriveBindingSource.Position
            DriveTableAdapter.Fill(Ffe_databaseDataSet.drive)
            DriveBindingSource.Position = pos
        End If
    End Sub

    Private Sub ToolStripButton6_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButton6.MouseDown
        If combo = True Then
            Dim pos As Integer = DriveBindingSource.Position
            DriveTableAdapter.Fill(Ffe_databaseDataSet.drive)
            DriveBindingSource.Position = pos
        End If
    End Sub

    Private Sub ToolStripButton3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButton3.MouseDown
        If combo = True Then
            Dim pos As Integer = DriveBindingSource.Position
            DriveTableAdapter.Fill(Ffe_databaseDataSet.drive)
            DriveBindingSource.Position = pos
        End If
    End Sub

    Private Sub DriveDataGridView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DriveDataGridView.MouseDown
        If combo = True Then
            Dim pos As Integer = DriveBindingSource.Position
            DriveTableAdapter.Fill(Ffe_databaseDataSet.drive)
            DriveBindingSource.Position = pos
        End If
    End Sub

End Class