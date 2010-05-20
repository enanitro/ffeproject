Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class form_import_csv_full
    Dim long_graphtec(), long_gps(), long_lmg(), long_canbus() As Integer
    Dim id_measure_graphtec(), id_measure_gps(), id_measure_lmg(), id_measure_canbus() As Integer
    Dim name_measure_graphtec(), name_measure_gps(), name_measure_lmg(), name_measure_canbus() As String
    Dim path_graphtec(0), path_gps(0), path_lmg(0), path_canbus(0) As String
    Dim length_graphtec, length_gps, length_lmg, length_canbus As Integer
    Public abort As Boolean = False
    Public isClosed As Boolean = False
    Public id_drive As Integer

    Private Sub all_channels(ByRef channels() As String, ByVal list As CheckedListBox)
        Array.Resize(channels, list.Items.Count)
        For i = 0 To list.Items.Count - 1
            channels(i) = list.Items(i)
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim logger As New logger
        Dim txt As String
        'logger.clean_logger(CheckedListBox1, TextBox1, Panel1, path_graphtec, long_graphtec)
        'id_logger = 1
        If length_graphtec = 0 Then
            ReDim path_graphtec(0)
            ReDim long_graphtec(0)
            length_graphtec = 1
            path_graphtec(0) = logger.logger_dialog(OpenFileDialog, CheckedListBox1, FfE_Main.id_graphtec, _
                                             TextBox1, long_graphtec(0), id_measure_graphtec, length_graphtec - 1)
            If path_graphtec(path_graphtec.Length - 1) = "" Then
                Array.Resize(path_graphtec, path_graphtec.Length - 1)
                Array.Resize(long_graphtec, long_graphtec.Length - 1)
                length_graphtec -= 1
            End If
            If CheckedListBox1.Items.Count > 0 Then
                all_channels(name_measure_graphtec, CheckedListBox1)
            End If
        Else
            Array.Resize(path_graphtec, path_graphtec.Length + 1)
            Array.Resize(long_graphtec, long_graphtec.Length + 1)
            length_graphtec += 1
            path_graphtec(path_graphtec.Length - 1) = logger.logger_dialog(OpenFileDialog, CheckedListBox1, _
                                                    FfE_Main.id_graphtec, TextBox1, long_graphtec(length_graphtec - 1), _
                                                    id_measure_graphtec, length_graphtec - 1)
            If path_graphtec(path_graphtec.Length - 1) = "" Then
                Array.Resize(path_graphtec, path_graphtec.Length - 1)
                Array.Resize(long_graphtec, long_graphtec.Length - 1)
                length_graphtec -= 1
            End If
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim logger As New logger
        'logger.clean_logger(CheckedListBox2, TextBox2, Panel2, path_gps, long_gps)
        'id_logger = 2
        If length_gps = 0 Then
            ReDim path_gps(0)
            ReDim long_gps(0)
            length_gps = 1
            path_gps(0) = logger.logger_dialog(OpenFileDialog, CheckedListBox2, FfE_Main.id_gps, _
                                            TextBox2, long_gps(0), id_measure_gps, length_gps - 1)
            If path_gps(path_gps.Length - 1) = "" Then
                Array.Resize(path_gps, path_gps.Length - 1)
                Array.Resize(long_gps, long_gps.Length - 1)
                length_gps -= 1
            End If
            If CheckedListBox2.Items.Count > 0 Then
                all_channels(name_measure_gps, CheckedListBox2)
            End If
        Else
            Array.Resize(path_gps, path_gps.Length + 1)
            Array.Resize(long_gps, long_gps.Length + 1)
            length_gps += 1
            path_gps(path_gps.Length - 1) = logger.logger_dialog(OpenFileDialog, CheckedListBox2, _
                                                    FfE_Main.id_gps, TextBox2, long_gps(length_gps - 1), _
                                                    id_measure_gps, length_gps - 1)
            If path_gps(path_gps.Length - 1) = "" Then
                Array.Resize(path_gps, path_gps.Length - 1)
                Array.Resize(long_gps, long_gps.Length - 1)
                length_gps -= 1
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim logger As New logger
        'logger.clean_logger(CheckedListBox3, TextBox3, Panel3, path_lmg, long_lmg)
        'id_logger = 3
        If length_lmg = 0 Then
            ReDim path_lmg(0)
            ReDim long_lmg(0)
            length_lmg = 1
            path_lmg(0) = logger.logger_dialog(OpenFileDialog, CheckedListBox3, FfE_Main.id_lmg, _
                                              TextBox3, long_lmg(0), id_measure_lmg, length_lmg - 1)
            If path_lmg(path_lmg.Length - 1) = "" Then
                Array.Resize(path_lmg, path_lmg.Length - 1)
                Array.Resize(long_lmg, long_lmg.Length - 1)
                length_lmg -= 1
            End If
            If CheckedListBox3.Items.Count > 0 Then
                all_channels(name_measure_lmg, CheckedListBox3)
            End If
        Else
            Array.Resize(path_lmg, path_lmg.Length + 1)
            Array.Resize(long_lmg, long_lmg.Length + 1)
            length_lmg += 1
            path_lmg(path_lmg.Length - 1) = logger.logger_dialog(OpenFileDialog, CheckedListBox3, _
                                                    FfE_Main.id_lmg, TextBox3, long_lmg(length_lmg - 1), _
                                                    id_measure_lmg, length_lmg - 1)
            If path_lmg(path_lmg.Length - 1) = "" Then
                Array.Resize(path_lmg, path_lmg.Length - 1)
                Array.Resize(long_lmg, long_lmg.Length - 1)
                length_lmg -= 1
            End If
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim logger As New logger
        'logger.clean_logger(CheckedListBox4, TextBox4, Panel4, path_canbus, long_canbus)
        'id_logger = 4
        If length_canbus = 0 Then
            ReDim path_canbus(0)
            ReDim long_canbus(0)
            length_canbus = 1
            path_canbus(0) = logger.logger_dialog(OpenFileDialog, CheckedListBox4, FfE_Main.id_canbus, _
                                               TextBox4, long_canbus(0), id_measure_canbus, length_canbus - 1)
            If path_canbus(path_canbus.Length - 1) = "" Then
                Array.Resize(path_canbus, path_canbus.Length - 1)
                Array.Resize(long_canbus, long_canbus.Length - 1)
                length_canbus -= 1
            End If
            If CheckedListBox4.Items.Count > 0 Then
                all_channels(name_measure_canbus, CheckedListBox4)
            End If
        Else
            Array.Resize(path_canbus, path_canbus.Length + 1)
            Array.Resize(long_canbus, long_canbus.Length + 1)
            length_canbus += 1
            path_canbus(path_canbus.Length - 1) = logger.logger_dialog(OpenFileDialog, CheckedListBox4, _
                                                    FfE_Main.id_canbus, TextBox4, long_canbus(length_canbus - 1), _
                                                    id_measure_canbus, length_canbus - 1)
            If path_canbus(path_canbus.Length - 1) = "" Then
                Array.Resize(path_canbus, path_canbus.Length - 1)
                Array.Resize(long_canbus, long_canbus.Length - 1)
                length_canbus -= 1
            End If
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim logger As New logger
        logger.clean_logger(CheckedListBox4, TextBox4, Panel4, path_canbus, long_canbus, length_canbus)
        length_canbus = 0
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim logger As New logger
        logger.clean_logger(CheckedListBox1, TextBox1, Panel1, path_graphtec, long_graphtec, length_graphtec)
        length_graphtec = 0
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim logger As New logger
        logger.clean_logger(CheckedListBox2, TextBox2, Panel2, path_gps, long_gps, length_gps)
        length_gps = 0
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim logger As New logger
        logger.clean_logger(CheckedListBox3, TextBox3, Panel3, path_lmg, long_lmg, length_lmg)
        length_lmg = 0
    End Sub

    'import files
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim logger As New logger
        Dim imp As Boolean = False
        Try
            Button7.Enabled = False
            If length_graphtec <> 0 And GroupBox_graphtec.Enabled _
            And CheckedListBox1.CheckedItems.Count <> 0 Then
                Panel1.Visible = True
                For i = 0 To length_graphtec - 1
                    Label6.Text = "Importing File " & i + 1
                    logger.insert_logger_graphtec_gl800(path_graphtec(i), CheckedListBox1, _
                    TextBox1, Label5, Label6, ProgressBar1, FfE_Main.id_graphtec, id_drive, _
                    long_graphtec(i), id_measure_graphtec)
                Next
                'GroupBox_graphtec.Enabled = False
                imp = True
            End If

            If length_gps <> 0 And GroupBox_columbusGPS.Enabled _
            And CheckedListBox2.CheckedItems.Count <> 0 Then
                Panel2.Visible = True
                For i = 0 To length_gps - 1
                    Label8.Text = "Importing File " & i + 1
                    logger.insert_logger_columbus_gps(path_gps(i), CheckedListBox2, _
                    TextBox2, Label7, Label8, ProgressBar2, FfE_Main.id_gps, id_drive, _
                    long_gps(i), id_measure_gps)
                Next
                'GroupBox_columbusGPS.Enabled = False
                imp = True
            End If

            If length_lmg <> 0 And GroupBox_fluke.Enabled _
            And CheckedListBox3.CheckedItems.Count <> 0 Then
                Panel3.Visible = True
                For i = 0 To length_lmg - 1
                    Label10.Text = "Importing File " & i + 1
                    logger.insert_logger_lmg500(path_lmg(i), CheckedListBox3, _
                    TextBox3, Label9, Label10, ProgressBar3, FfE_Main.id_lmg, id_drive, _
                    long_lmg(i), id_measure_lmg)
                Next
                'GroupBox_fluke.Enabled = False
                imp = True
            End If

            If length_canbus <> 0 And GroupBox_CANBUS.Enabled _
            And CheckedListBox4.CheckedItems.Count <> 0 Then
                Panel4.Visible = True
                For i = 0 To length_canbus - 1
                    Label12.Text = "Importing File " & i + 1
                    logger.insert_logger_canbus(path_canbus(i), CheckedListBox4, _
                    TextBox4, Label11, Label12, ProgressBar4, FfE_Main.id_canbus, id_drive, _
                    long_canbus(i), id_measure_canbus)
                Next
                'GroupBox_CANBUS.Enabled = False
                imp = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If abort = True Then
                procesing.Show()
                Application.DoEvents()
                logger.delete_rows(CheckedListBox1, id_drive, FfE_Main.id_graphtec)
                logger.delete_rows(CheckedListBox2, id_drive, FfE_Main.id_gps)
                logger.delete_rows(CheckedListBox3, id_drive, FfE_Main.id_lmg)
                logger.delete_rows(CheckedListBox4, id_drive, FfE_Main.id_canbus)
                procesing.Close()
                abort = False
            Else
                If imp = True Then MsgBox("Files were imported successfully", MsgBoxStyle.Information)
            End If
            logger.clean_logger(CheckedListBox1, TextBox1, Panel1, path_graphtec, long_graphtec, length_graphtec)
            logger.clean_logger(CheckedListBox2, TextBox2, Panel2, path_gps, long_gps, length_gps)
            logger.clean_logger(CheckedListBox3, TextBox3, Panel3, path_lmg, long_lmg, length_lmg)
            logger.clean_logger(CheckedListBox4, TextBox4, Panel4, path_canbus, long_canbus, length_canbus)
            length_graphtec = 0
            length_gps = 0
            length_lmg = 0
            length_canbus = 0
            Button7.Enabled = True
        End Try
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        select_measure(CheckedListBox1, id_measure_graphtec, FfE_Main.id_graphtec, name_measure_graphtec)
    End Sub

    Private Sub CheckedListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox2.SelectedIndexChanged
        select_measure(CheckedListBox2, id_measure_gps, FfE_Main.id_gps, name_measure_gps)
    End Sub

    Private Sub CheckedListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox3.SelectedIndexChanged
        select_measure(CheckedListBox3, id_measure_lmg, FfE_Main.id_lmg, name_measure_lmg)
    End Sub

    Private Sub CheckedListBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox4.SelectedIndexChanged
        select_measure(CheckedListBox4, id_measure_canbus, FfE_Main.id_canbus, name_measure_canbus)
    End Sub

    Private Function search_measure(ByVal logger_id As Integer, ByVal sel As String, _
                                    ByVal name As String, ByVal find As String, ByRef ind As Integer) As String
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sql As String = ""
        Dim res As String = ""

        Try

            ' Abrir la conexión a Sql  
            cn.Open()

            ' Pasar la consulta sql y la conexión al Sql Command   
            sql = "select " & sel & ", measure_id from channel_name where logger_id = " & logger_id & _
                  " and " & find & " = '" & name & "';"
            cmd.Connection = cn
            cmd.CommandText = sql
            query = cmd.ExecuteReader()
            query.Read()
            If query.HasRows() Then
                res = query.GetString(0)
                ind = query.GetString(1)
            End If

            cn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            search_measure = res
        End Try
    End Function

    'seleccionar que medida se ajusta a la del canal
    Private Sub select_measure_2(ByRef list As CheckedListBox, ByRef measure() As Integer, _
                               ByVal logger As Integer, ByVal list_ch() As String)
        Try
            If list.SelectedIndex <> -1 Then
                Dim form_measure As New Form_measure
                Dim name_measure, unit As String
                Dim item As String = list.SelectedItem
                Dim index As Integer = list.SelectedIndex
                Dim str As String = ""
                Dim ind As Integer
                str = search_measure(logger, "name", list.SelectedItem, "channel", ind)
                If list.GetItemChecked(list.SelectedIndex) Then
                    If str <> "" Then
                        list.Items.Remove(item)
                        list.Items.Insert(index, str)
                        list.SetItemChecked(index, True)
                        measure(index) = ind
                    Else
                        form_measure.ShowDialog()
                        If form_measure.MeasureDataGridView.Rows.Count > 0 Then
                            measure(index) = form_measure.MeasureDataGridView.CurrentRow.Cells.Item(0).Value
                            name_measure = form_measure.MeasureDataGridView.CurrentRow.Cells.Item(1).Value
                            unit = form_measure.MeasureDataGridView.CurrentRow.Cells.Item(3).Value
                            list.Items.Remove(item)
                            list.Items.Insert(index, item & " -> " & name_measure & " [" & unit & "]")
                            list.SetItemChecked(index, True)
                            If check_channel(list.Items.Item(index)) Then
                                MsgBox("This channel-logger has already been imported", MsgBoxStyle.Exclamation)
                            End If
                        Else
                            list.SetItemChecked(index, False)
                        End If
                    End If
                Else
                    list.Items.Remove(item)
                    list.Items.Insert(index, list_ch(index))
                    list.SetItemChecked(index, False)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'seleccionar que medida se ajusta a la del canal
    Private Sub select_measure(ByRef list As CheckedListBox, ByRef measure() As Integer, _
                                        ByVal logger As Integer, ByVal list_ch() As String)
        Try
            If list.SelectedIndex <> -1 Then
                Dim form_measure As New Form_measure
                Dim name_measure, unit, text As String
                Dim item As String = list.SelectedItem
                Dim index As Integer = list.SelectedIndex
                Dim str As String = ""
                Dim ind As Integer
                If list.GetItemChecked(list.SelectedIndex) Then
                    str = search_measure(logger, "name", list.SelectedItem, "channel", ind)
                    If str <> "" Then
                        list.Items.Remove(item)
                        list.Items.Insert(index, str)
                        list.SetItemChecked(index, True)
                        measure(index) = ind
                    Else
                        form_measure.ShowDialog()
                        If form_measure.MeasureDataGridView.Rows.Count > 0 Then
                            measure(index) = form_measure.MeasureDataGridView.CurrentRow.Cells.Item(0).Value
                            name_measure = form_measure.MeasureDataGridView.CurrentRow.Cells.Item(1).Value
                            unit = form_measure.MeasureDataGridView.CurrentRow.Cells.Item(3).Value
                            list.Items.Remove(item)
                            text = (index + 1) & ". "
                            text += " " & name_measure & " [" & unit & "]"
                            list.Items.Insert(index, item & " -> " & text)
                            list.SetItemChecked(index, True)
                        Else
                            list.SetItemChecked(index, False)
                        End If
                    End If
                    If check_channel(list.Items.Item(index)) Then
                        MsgBox("This channel-logger has already been imported", MsgBoxStyle.Exclamation)
                    End If
                Else
                    list.Items.Remove(item)
                    list.Items.Insert(index, list_ch(index))
                    list.SetItemChecked(index, False)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If Button7.Enabled = False Then
            If MsgBox("Do you want to abort import process?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If CheckedListBox1.Visible = True Then path_graphtec(0) = ""
                If CheckedListBox2.Visible = True Then path_gps(0) = ""
                If CheckedListBox3.Visible = True Then path_lmg(0) = ""
                If CheckedListBox4.Visible = True Then path_canbus(0) = ""
                abort = True
                Throw New Exception("Import process aborted")
            End If
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub associations(ByRef list As CheckedListBox, ByVal logger_id As Integer, ByVal measure() As Integer)
        Try
            If list.Items.Count <> 0 And list.CheckedItems.Count <> 0 Then
                Dim asc As New association
                asc.logger = logger_id
                asc.measure = measure
                asc.list = list
                asc.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub put_ch_list(ByVal list As CheckedListBox, ByVal logger_id As Integer, ByVal ch() As String)
        Dim str As String = ""
        Dim x As Integer
        For Each i In list.CheckedIndices
            str = search_measure(logger_id, "name", ch(i), "channel", x)
            If str = "" Then
                If list.Items(i).ToString.Split("-")(0).Trim <> ch(i) Then
                    str = ch(i) & " -> " & list.Items(i).ToString.Split("-")(0).Trim
                Else
                    str = list.Items(i)
                End If
            End If
            list.Items(i) = str
        Next
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        associations(CheckedListBox1, FfE_Main.id_graphtec, id_measure_graphtec)
        put_ch_list(CheckedListBox1, FfE_Main.id_graphtec, name_measure_graphtec)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        associations(CheckedListBox2, FfE_Main.id_gps, id_measure_gps)
        put_ch_list(CheckedListBox2, FfE_Main.id_gps, name_measure_gps)
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        associations(CheckedListBox3, FfE_Main.id_lmg, id_measure_lmg)
        put_ch_list(CheckedListBox3, FfE_Main.id_lmg, name_measure_lmg)
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        associations(CheckedListBox4, FfE_Main.id_canbus, id_measure_canbus)
        put_ch_list(CheckedListBox4, FfE_Main.id_canbus, name_measure_canbus)
    End Sub

    Private Sub form_import_csv_full_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        isClosed = True
    End Sub

    Private Sub form_import_csv_full_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        length_graphtec = 0
        length_gps = 0
        length_lmg = 0
        length_canbus = 0
    End Sub
End Class