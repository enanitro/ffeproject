Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class form_import_csv_full
    Public long_graphtec, long_gps, long_fluke, long_canbus, id_drive As Integer
    Public id_measure_graphtec(), id_measure_gps(), id_measure_fluke(), id_measure_canbus() As Integer
    Public path_graphtec, path_gps, path_fluke, path_canbus As String
    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim logger As New logger
        logger.clean_logger(CheckedListBox1, TextBox1, Panel1, path_graphtec, long_graphtec)
        'id_logger = 1
        path_graphtec = logger.logger_dialog(OpenFileDialog, CheckedListBox1, FfE_Main.id_graphtec, _
                                             TextBox1, long_graphtec, id_measure_graphtec)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim logger As New logger
        logger.clean_logger(CheckedListBox2, TextBox2, Panel2, path_gps, long_gps)
        'id_logger = 2
        path_gps = logger.logger_dialog(OpenFileDialog, CheckedListBox2, FfE_Main.id_gps, TextBox2, long_gps, id_measure_gps)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim logger As New logger
        logger.clean_logger(CheckedListBox3, TextBox3, Panel3, path_fluke, long_fluke)
        'id_logger = 3
        path_fluke = logger.logger_dialog(OpenFileDialog, CheckedListBox3, FfE_Main.id_fluke, TextBox3, long_fluke, id_measure_fluke)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim logger As New logger
        logger.clean_logger(CheckedListBox1, TextBox1, Panel1, path_graphtec, long_graphtec)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim logger As New logger
        logger.clean_logger(CheckedListBox2, TextBox2, Panel2, path_gps, long_gps)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim logger As New logger
        logger.clean_logger(CheckedListBox3, TextBox3, Panel3, path_fluke, long_fluke)
    End Sub

    'import files
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim logger As New logger

        If path_graphtec <> "" And GroupBox_graphtec.Enabled _
        And CheckedListBox1.CheckedItems.Count <> 0 Then
            Panel1.Visible = True
            logger.insert_logger_graphtec_gl800(path_graphtec, CheckedListBox1, _
            TextBox1, Label5, Label6, ProgressBar1, FfE_Main.id_graphtec, id_drive, long_graphtec, id_measure_graphtec)
            'GroupBox_graphtec.Enabled = False
        End If

        If path_gps <> "" And GroupBox_columbusGPS.Enabled _
        And CheckedListBox2.CheckedItems.Count <> 0 Then
            Panel2.Visible = True
            logger.insert_logger_columbus_gps(path_gps, CheckedListBox2, _
            TextBox2, Label7, Label8, ProgressBar2, FfE_Main.id_gps, id_drive, long_gps, id_measure_gps)
            'GroupBox_columbusGPS.Enabled = False
        End If

        If path_fluke <> "" And GroupBox_fluke.Enabled _
        And CheckedListBox3.CheckedItems.Count <> 0 Then
            Panel3.Visible = True
            logger.insert_logger_fluke(path_fluke, CheckedListBox3, _
            TextBox3, Label9, Label10, ProgressBar3, FfE_Main.id_fluke, id_drive, long_fluke, id_measure_fluke)
            'GroupBox_fluke.Enabled = False
        End If

        If path_canbus <> "" And GroupBox_CANBUS.Enabled _
        And CheckedListBox4.CheckedItems.Count <> 0 Then
            'Panel3.Visible = True
            'logger.insert_logger_canbus(path_canbus, CheckedListBox4, _
            'textbox4, textbox11, textbox12, ProgressBar4, FfE_Main.id_canbus, id_drive, long_canbus, id_measure_canbus)
            'GroupBox_fluke.Enabled = False
        End If
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        select_measure(CheckedListBox1, id_measure_graphtec)
    End Sub

    Private Sub CheckedListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox2.SelectedIndexChanged
        select_measure(CheckedListBox2, id_measure_gps)
    End Sub

    Private Sub CheckedListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox3.SelectedIndexChanged
        select_measure(CheckedListBox3, id_measure_fluke)
    End Sub

    Private Sub CheckedListBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox4.SelectedIndexChanged
        select_measure(CheckedListBox4, id_measure_canbus)
    End Sub

    'seleccionar que medida se ajusta a la del canal
    Private Sub select_measure(ByRef list As CheckedListBox, ByRef measure() As Integer)
        Try
            If list.SelectedIndex <> -1 Then
                Dim form_measure As New Form_measure
                Dim name_measure As String
                Dim item As String = list.SelectedItem
                Dim index As Integer = list.SelectedIndex
                If list.GetItemChecked(list.SelectedIndex) Then
                    form_measure.ShowDialog()
                    If form_measure.MeasureDataGridView.Rows.Count > 0 Then
                        measure(index) = form_measure.MeasureDataGridView.CurrentRow.Cells.Item(0).Value
                        name_measure = form_measure.MeasureDataGridView.CurrentRow.Cells.Item(1).Value
                        list.Items.Remove(item)
                        list.Items.Insert(index, item & " -> " & name_measure)
                        list.SetItemChecked(index, True)
                        If check_channel(list.Items.Item(index)) Then
                            MsgBox("This channel-logger has already been imported", MsgBoxStyle.Exclamation)
                        End If
                    Else
                        list.SetItemChecked(index, False)
                    End If
                Else
                    list.Items.Remove(item)
                    item = item.Remove(item.IndexOf("-"), item.Count - item.IndexOf("-"))
                    item = item.Trim(" ")
                    list.Items.Insert(index, item)
                    list.SetItemChecked(index, False)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim logger As New logger
        logger.clean_logger(CheckedListBox4, TextBox4, Panel4, path_canbus, long_canbus)
        'id_logger = 3
        path_canbus = logger.logger_dialog(OpenFileDialog, CheckedListBox4, FfE_Main.id_canbus, _
                                           TextBox4, long_canbus, id_measure_canbus)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim logger As New logger
        logger.clean_logger(CheckedListBox4, TextBox4, Panel4, path_canbus, long_canbus)
    End Sub

    Function check_channel(ByVal channel As String)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)

        Try

            ' Abrir la conexión a Sql  
            cn.Open()

            ' Pasar la consulta sql y la conexión al Sql Command   
            Dim cmd As New MySqlCommand("select * from data where data_id like '" & channel & "'" _
                                        & " and drive_id =" & id_drive & ";", cn)

            ' Inicializar un nuevo SqlDataAdapter   
            Dim da As New MySqlDataAdapter(cmd)

            'Crear y Llenar un Dataset  
            Dim ds As New DataSet
            da.Fill(ds)

            If ds.Tables(0).Rows.Count = 0 Then
                cn.Close()
                check_channel = False
            Else
                cn.Close()
                check_channel = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Function

End Class