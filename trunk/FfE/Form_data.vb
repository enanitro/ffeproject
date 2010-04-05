Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_data
    Dim drive_id As Integer
    Private Sub Form_data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: esta línea de código carga datos en la tabla 'Ffe_databaseDataSet.drive_full' Puede moverla o quitarla según sea necesario.
            Me.Drive_fullTableAdapter.Fill(Me.Ffe_databaseDataSet.drive_full)

            add_combobox_items()
            'add_data_datagridview()
            check_combobox()

            drive_id = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'actualiza la busqueda segun el filtrado de los datos
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim query As String = ""
            query = analyze_query(query, ComboBox1, "status")
            query = analyze_query(query, ComboBox2, "climate")
            query = analyze_query(query, ComboBox3, "drive_type")
            query = analyze_query(query, ComboBox4, "car")
            query = analyze_query(query, ComboBox5, "usage_type")
            query = analyze_query(query, ComboBox6, "importer")
            query = analyze_query(query, ComboBox7, "driver")
            query = analyze_query_date1(query, DateTimePicker1, "date")
            query = analyze_query_date2(query, DateTimePicker2, "date")
            Drive_fullBindingSource.Filter = query
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function analyze_query(ByVal query As String, ByVal value As ComboBox, ByVal field As String) As String
        If value.Enabled Then
            If query <> "" Then query += " AND "
            query += field & " = " & "'" & value.Text & "'"
        End If
        analyze_query = query
    End Function

    Function analyze_query_date1(ByVal query As String, ByVal value As DateTimePicker, ByVal field As String) As String
        If value.Enabled Then
            If query <> "" Then query += " AND "
            query += field & " >= " & "'" & value.Text & "'"
        End If
        analyze_query_date1 = query
    End Function

    Function analyze_query_date2(ByVal query As String, ByVal value As DateTimePicker, ByVal field As String) As String
        If value.Enabled Then
            If query <> "" Then query += " AND "
            query += field & " <= " & "'" & value.Text & "'"
        End If
        analyze_query_date2 = query
    End Function

    'añade los items a los combobox
    Private Sub add_combobox_items()
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        load_combobox(ComboBox1, "select distinct status from drive_full", connection)
        load_combobox(ComboBox2, "select distinct climate from drive_full", connection)
        load_combobox(ComboBox3, "select distinct drive_type from drive_full", connection)
        load_combobox(ComboBox4, "select distinct car from drive_full", connection)
        load_combobox(ComboBox5, "select distinct usage_type from drive_full", connection)
        load_combobox(ComboBox7, "select distinct driver from drive_full", connection)
        load_combobox(ComboBox6, "select distinct importer from drive_full", connection)
        ComboBox1.Text = ""
    End Sub

    'cargar datos en un combobox
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
            ComboBox.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    'enable = false 
    Private Sub enable_checkbox(ByVal value As Boolean)
        CheckBox1.Enabled = value
        CheckBox2.Enabled = value
        CheckBox3.Enabled = value
        CheckBox4.Enabled = value
        CheckBox5.Enabled = value
        CheckBox6.Enabled = value
        CheckBox7.Enabled = value
        DateTimePicker1.Enabled = value
        DateTimePicker2.Enabled = value
    End Sub

    'desactiva los combobox
    Private Sub check_combobox()
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        CheckBox10.Checked = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        ComboBox1.Enabled = CheckBox1.Checked
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        ComboBox2.Enabled = CheckBox2.Checked
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        ComboBox4.Enabled = CheckBox4.Checked
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        ComboBox3.Enabled = CheckBox3.Checked
    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        ComboBox6.Enabled = CheckBox6.Checked
    End Sub

    Private Sub CheckBox7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox7.CheckedChanged
        ComboBox7.Enabled = CheckBox7.Checked
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged
        ComboBox5.Enabled = CheckBox5.Checked
    End Sub

    Private Sub CheckBox8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox8.CheckedChanged
        DateTimePicker1.Enabled = CheckBox8.Checked
    End Sub

    Private Sub CheckBox10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox10.CheckedChanged
        DateTimePicker2.Enabled = CheckBox10.Checked
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If DateTimePicker2.Enabled And DateTimePicker2.Value < DateTimePicker1.Value Then
            MsgBox("Start date should be less than final date", MsgBoxStyle.Information)
            DateTimePicker1.Value = DateTimePicker2.Value
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        If DateTimePicker1.Enabled And DateTimePicker2.Value < DateTimePicker1.Value Then
            MsgBox("Start date should be less than or equal to end date", MsgBoxStyle.Information)
            DateTimePicker2.Value = DateTimePicker1.Value
        End If
    End Sub

    Private Sub Drive_fullDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Drive_fullDataGridView.CellContentClick
        Try
            drive_id = Drive_fullDataGridView.CurrentRow.Cells.Item(0).Value
            clean_lists()
            show_loggers()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub show_loggers()
        GroupBox2.Visible = False

        execute_list_channels(FfE_Main.id_graphtec, CheckedListBox1)
        show_data(DataGridView, FfE_Main.id_graphtec, CheckedListBox1)
        CheckBox9.CheckState = CheckState.Checked

        execute_list_channels(FfE_Main.id_gps, CheckedListBox2)
        show_data(DataGridView1, FfE_Main.id_gps, CheckedListBox2)
        CheckBox11.CheckState = CheckState.Checked

        execute_list_channels(FfE_Main.id_fluke, CheckedListBox3)
        show_data(DataGridView2, FfE_Main.id_fluke, CheckedListBox3)
        CheckBox12.CheckState = CheckState.Checked

        execute_list_channels(FfE_Main.id_canbus, CheckedListBox4)
        show_data(DataGridView3, FfE_Main.id_canbus, CheckedListBox4)
        CheckBox13.CheckState = CheckState.Checked

        GroupBox2.Visible = True
    End Sub

    Private Sub clean_lists()
        CheckedListBox1.Items.Clear()
        CheckedListBox2.Items.Clear()
        CheckedListBox3.Items.Clear()
        CheckedListBox4.Items.Clear()
    End Sub

    Private Sub format_grid(ByRef grid As DataGridView)
        grid.ReadOnly = True
        grid.AllowUserToAddRows = False
        grid.AllowUserToDeleteRows = False
        grid.Columns(0).Width = 60
        grid.Columns(1).Width = 60
        For i = 2 To grid.Columns.Count - 1
            grid.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
    End Sub

    Private Sub show_data(ByRef grid As DataGridView, ByVal logger_id As Integer, ByVal list As CheckedListBox)
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim sql As String = ""

        Try

            grid.DataSource = ""
            execute_query_loggers(sql, logger_id, list)

            ' Abrir la conexión a Sql  
            cn.Open()

            ' Pasar la consulta sql y la conexión al Sql Command   
            Dim cmd As New MySqlCommand(sql, cn)
            cmd.CommandTimeout = 1000

            ' Inicializar un nuevo SqlDataAdapter   
            Dim da As New MySqlDataAdapter(cmd)

            'Crear y Llenar un Dataset  
            Dim ds As New DataSet

            da.Fill(ds)

            Dim tbl As DataTable = ds.Tables(0) ' data table prepara la estructura de la tabla
            If tbl.Rows.Count > 0 Then
                grid.DataSource = tbl
                format_grid(grid)
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
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
            cmd.CommandTimeout = 0
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

    Private Sub execute_query_loggers(ByRef sql As String, ByVal logger_id As Integer, ByVal list As CheckedListBox)

        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim i As Integer
        sql = ""

        Try
            ' Abrir la conexión a Sql  
            cn.Open()
            cmd.Connection = cn

            sql = "select distinct data_id from data where drive_id = " & drive_id & _
             " and logger_id = " & logger_id
            cmd.CommandTimeout = 1000000
            cmd.CommandText = sql
            query = cmd.ExecuteReader()


            sql = "select data_index as 'Index',time as Time"
            i = 0
            While query.Read()
                If list.GetItemChecked(i) = True Then
                    sql += ",sum(value*(1-abs(sign(if(strcmp(data_id,'" & _
                    query.GetString(0) & "'),1,0))))) as '" & query.GetString(0) & "'"
                    i += 1
                End If
            End While
            sql += " from data_full" & _
                " where drive_id = " & drive_id & _
                " and logger_id = " & logger_id & _
                " group by data_index,time;"

            cn.Close()

        Catch ex As Exception
            If ex.Message = "Export process aborted" Then
                Throw New Exception("Export process aborted")
            Else
                MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub execute_list_channels(ByVal logger_id As Integer, ByVal list As CheckedListBox)

        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim i As Integer
        Dim sql As String = ""

        Try

            ' Abrir la conexión a Sql  
            cn.Open()
            cmd.Connection = cn

            sql = "select distinct data_id from data where drive_id = " & drive_id & _
             " and logger_id = " & logger_id
            cmd.CommandTimeout = 1000000
            cmd.CommandText = sql
            query = cmd.ExecuteReader()
            list.Items.Clear()
            i = 0
            While query.Read()
                list.Items.Add(query.GetString(0))
                list.SetItemChecked(i, True)
                i += 1
            End While

            cn.Close()

        Catch ex As Exception
            If ex.Message = "Export process aborted" Then
                Throw New Exception("Export process aborted")
            Else
                MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub delete_channel(ByVal logger_id As Integer, ByVal list As CheckedListBox)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim i As Integer
        Dim sql As String = ""

        Try
            If list.Items.Count <> 0 And list.CheckedItems.Count <> 0 Then
                If MsgBox("Are yo sure to delete the selected channels?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    ' Abrir la conexión a Sql  
                    cn.Open()
                    cmd.Connection = cn
                    For Each i In list.CheckedIndices
                        sql = "delete from data where logger_id = " & logger_id & _
                             " and drive_id = " & drive_id & _
                             " and data_id like '" & list.Items(i) & "';"
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                    Next

                    cn.Close()

                End If
            End If

        Catch ex As Exception
            If ex.Message = "Export process aborted" Then
                Throw New Exception("Export process aborted")
            Else
                MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub select_all_channels(ByRef list As CheckedListBox, ByVal check As CheckBox)
        If check.CheckState <> CheckState.Indeterminate Then
            For i = 0 To list.Items.Count - 1
                list.SetItemChecked(i, check.CheckState)
            Next
        End If
    End Sub

    Private Sub no_select_all_channels(ByRef check As CheckBox, ByVal list As CheckedListBox)
        If list.CheckedItems.Count = list.Items.Count Then
            check.CheckState = CheckState.Checked
        Else
            If list.CheckedItems.Count = 0 Then
                check.CheckState = CheckState.Unchecked
            Else
                check.CheckState = CheckState.Indeterminate
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        show_data(DataGridView, FfE_Main.id_graphtec, CheckedListBox1)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        delete_channel(FfE_Main.id_graphtec, CheckedListBox1)
        execute_list_channels(FfE_Main.id_graphtec, CheckedListBox1)
        show_data(DataGridView, FfE_Main.id_graphtec, CheckedListBox1)
        CheckBox9.CheckState = CheckState.Checked
    End Sub

    Private Sub CheckBox9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox9.CheckedChanged
        select_all_channels(CheckedListBox1, CheckBox9)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        show_data(DataGridView, FfE_Main.id_gps, CheckedListBox2)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        delete_channel(FfE_Main.id_gps, CheckedListBox2)
        execute_list_channels(FfE_Main.id_gps, CheckedListBox2)
        show_data(DataGridView1, FfE_Main.id_gps, CheckedListBox2)
        CheckBox11.CheckState = CheckState.Checked
    End Sub

    Private Sub CheckBox11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox11.CheckedChanged
        select_all_channels(CheckedListBox2, CheckBox11)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        show_data(DataGridView, FfE_Main.id_fluke, CheckedListBox3)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        delete_channel(FfE_Main.id_fluke, CheckedListBox3)
        execute_list_channels(FfE_Main.id_fluke, CheckedListBox3)
        show_data(DataGridView2, FfE_Main.id_fluke, CheckedListBox3)
        CheckBox12.CheckState = CheckState.Checked
    End Sub

    Private Sub CheckBox12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox12.CheckedChanged
        select_all_channels(CheckedListBox3, CheckBox12)
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        no_select_all_channels(CheckBox9, CheckedListBox1)
    End Sub

    Private Sub CheckedListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox2.SelectedIndexChanged
        no_select_all_channels(CheckBox11, CheckedListBox2)
    End Sub

    Private Sub CheckedListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox3.SelectedIndexChanged
        no_select_all_channels(CheckBox12, CheckedListBox3)
    End Sub

    Private Sub CheckedListBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox4.SelectedIndexChanged
        no_select_all_channels(CheckBox13, CheckedListBox4)
    End Sub

    Private Sub CheckBox13_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox13.CheckedChanged
        select_all_channels(CheckedListBox4, CheckBox13)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        show_data(DataGridView3, FfE_Main.id_fluke, CheckedListBox4)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        delete_channel(FfE_Main.id_canbus, CheckedListBox4)
        execute_list_channels(FfE_Main.id_canbus, CheckedListBox4)
        show_data(DataGridView3, FfE_Main.id_canbus, CheckedListBox4)
        CheckBox13.CheckState = CheckState.Checked
    End Sub
End Class