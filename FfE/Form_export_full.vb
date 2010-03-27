Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_export_full
    Dim abort As Boolean = False

    Private Sub btn_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export.Click
        Try
            btn_export.Enabled = False
            If path_graphtec.Text <> "" And abort = False Then
                ProgressBar1.Visible = True
                percent_graphtec.Visible = True
                logger_csv_file(path_graphtec.Text, FfE_Main.id_graphtec, "GRAPHTEC GL800")
            End If
            If path_gps.Text <> "" And abort = False Then
                ProgressBar2.Visible = True
                percent_gps.Visible = True
                logger_csv_file(path_gps.Text, FfE_Main.id_gps, "COLUMBUS GPS")
            End If
            If path_fluke.Text <> "" And abort = False Then
                ProgressBar3.Visible = True
                percent_fluke.Visible = True
                logger_csv_file(path_fluke.Text, FfE_Main.id_fluke, "FLUKE")
            End If
            'logger_csv_file(SaveFileDialog.FileName, FfE_Main.id_canbus, "CAN-BUS", Label22.Text)
            If abort <> True Then MsgBox("Data-loggers were imported successfully", MsgBoxStyle.Information)
        Catch ex As Exception       
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clean_groups()
            btn_export.Enabled = True
            abort = False
        End Try
    End Sub

    Private Sub clean_groups()
        ProgressBar1.Visible = False
        percent_graphtec.Visible = False
        path_graphtec.Text = ""
        ProgressBar2.Visible = False
        percent_gps.Visible = False
        path_gps.Text = ""
        ProgressBar4.Visible = False
        percent_fluke.Visible = False
        path_fluke.Text = ""
        ProgressBar3.Visible = False
        percent_canbus.Visible = False
        path_canbus.Text = ""
    End Sub

    'configuracion del progressbar y labels que le acompañan
    Public Sub config_progressbar(ByVal max As Integer, ByRef bar As ProgressBar)
        bar.Minimum = 0
        bar.Maximum = max
    End Sub

    'controla el objeto progressbar
    Public Sub progressbar(ByVal val As Integer, ByRef percent As String, ByRef bar As ProgressBar)
        bar.Value = val

        ' Visualizamos el porcentaje en el Label
        percent = CLng((bar.Value * 100) / bar.Maximum) & " %"
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

    Private Sub data_points_channels(ByRef points As String, ByRef channels As String, ByVal logger As Integer)
        execute_query("select count(*) from data where drive_id = " & drive_id.Text _
                      & " and logger_id = " & logger, points)
        execute_query("select count(distinct data_id) from data where drive_id = " & drive_id.Text _
                      & " and logger_id = " & logger, channels)
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

    Private Sub head_csv_file(ByRef text As String)
        Try
            text = "DRIVE ID: " & drive_id.Text & vbCrLf & _
                           "CAR: " & car.Text & vbCrLf & _
                           "CLIMATE: " & climate.Text & vbCrLf & _
                           "STATUS: " & status.Text & vbCrLf & _
                           "DRIVE TYPE: " & drive_type.Text & vbCrLf & _
                           "USAGE TYPE: " & usage_type.Text & vbCrLf & _
                           "DRIVER: " & driver.Text & vbCrLf & _
                           "IMPORTER: " & importer.Text & vbCrLf & _
                           "DATE: " & driver.Text & vbCrLf & _
                           "DESCRIPTION: " & description.Text & vbCrLf & vbCrLf
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub logger_csv_file(ByVal path As String, ByVal logger_id As Integer, _
                                ByVal logger As String)

        Dim text, sql, res, points, channels As String
        Dim sw As New System.IO.StreamWriter(path)
        Try
            data_points_channels(points, channels, logger_id)
            head_csv_file(text)
            res = ""
            sql = "select timestep from data_full where drive_id = " & drive_id.Text & _
                  " and logger_id = " & logger_id
            execute_query(sql, res)
            If res <> "" Then
                text += logger & vbCrLf & _
                        points & " data points (" & channels & "channels)" & vbCrLf & _
                        "TIME STEP: " & res & vbCrLf
                sw.WriteLine(text)

                Select Case logger_id
                    Case FfE_Main.id_graphtec
                        execute_query_loggers(res, logger_id, logger, ProgressBar1, percent_graphtec)
                    Case FfE_Main.id_gps
                        execute_query_loggers(res, logger_id, logger, ProgressBar2, percent_gps)
                    Case FfE_Main.id_fluke
                        execute_query_loggers(res, logger_id, logger, ProgressBar3, percent_fluke)
                        'Case FfE_Main.id_canbus : execute_query_canbus(res)
                End Select
                sw.WriteLine(res)

            End If
            sw.Close()
        Catch ex As Exception
            If ex.Message = "Export process aborted" Then
                sw.Close()
                If My.Computer.FileSystem.FileExists(path_graphtec.Text) Then
                    My.Computer.FileSystem.DeleteFile(path_graphtec.Text)
                End If
                If My.Computer.FileSystem.FileExists(path_gps.Text) Then
                    My.Computer.FileSystem.DeleteFile(path_gps.Text)
                End If
                If My.Computer.FileSystem.FileExists(path_fluke.Text) Then
                    My.Computer.FileSystem.DeleteFile(path_fluke.Text)
                End If
                If My.Computer.FileSystem.FileExists(path_canbus.Text) Then
                    My.Computer.FileSystem.DeleteFile(path_canbus.Text)
                End If
                path_graphtec.Text = ""
                path_gps.Text = ""
                path_fluke.Text = ""
                path_canbus.Text = ""
                MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub execute_query_loggers(ByRef res As String, ByVal logger_id As Integer, _
                                      ByVal logger As String, ByRef bar As ProgressBar, _
                                      ByRef percent As Label)
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
            sql = "select count(distinct data_id) from data_full where drive_id = " & drive_id.Text & _
              " and logger_id = " & logger_id
            execute_query(sql, distinct)
            sql = "select distinct data_id from data_full where drive_id = " & drive_id.Text & _
             " and logger_id = " & logger_id
            cmd.CommandText = sql
            query = cmd.ExecuteReader()


            sql = "select concat(data_index,',',time"
            res = "INDEX,TIME"
            For i = 1 To distinct
                query.Read()
                res += "," & query.GetString(0)
                sql += ",',',sum(value*(1-abs(sign(IF(STRCMP(data_id,'" & query.GetString(0) & "'),1,0)))))"
            Next
            sql += ") as format_row from data" & _
                " where drive_id = " & drive_id.Text & _
                " and logger_id = " & logger_id & _
                " group by data_index;"
            res += vbCrLf
            cn.Close()


            cn.Open()
            cmd.CommandText = sql
            query = cmd.ExecuteReader()


            sql = "select count(value) from data_full where drive_id = " & drive_id.Text & _
              " and logger_id = " & logger_id & " order by data_index, time"
            execute_query(sql, count)

            calculate_max(max, logger_id)
            config_progressbar(max, bar)
            i = 1
            count = count / distinct
            query.Read()

            Do While i <= count
                res += query.GetString(0)
                query.Read()
                progressbar(i, percent.Text, bar)
                i += 1
                res += vbCrLf
                Application.DoEvents()
            Loop
            res += vbCrLf
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
            'sql = "select count(value) from data_full where drive_id = " & Drive_idLabel1.Text & _
            '  " and logger_id = " & FfE_Main.id_canbus & " order by data_index"
            'execute_query(sql, count)
            'sql = "select time,data_id,unit,value from data_full where drive_id = " & Drive_idLabel1.Text & _
            '  " and logger_id = " & FfE_Main.id_canbus & " order by data_index"
            'cmd.CommandText = sql
            'query = cmd.ExecuteReader()

            i = 1
            'count = count / distinct
            'Label25.Text = "Exporting CAN-BUS logger"
            query.Read()
            Do While i <= count
                res += i & "," & query.GetString(0) & "," & query.GetString(1) & _
                "," & query.GetString(2) & "," & query.GetString(3).Replace(",", ".")
                query.Read()

                'progressbar(i)
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

    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            SaveFileDialog.Filter() = "CSV Files(*.csv)|*.csv;"
            If SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                path_graphtec.Text = SaveFileDialog.FileName
                path_graphtec.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            SaveFileDialog.Filter() = "CSV Files(*.csv)|*.csv;"
            If SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                path_gps.Text = SaveFileDialog.FileName
                path_gps.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            SaveFileDialog.Filter() = "CSV Files(*.csv)|*.csv;"
            If SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                path_fluke.Text = SaveFileDialog.FileName
                path_fluke.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Try
        'SaveFileDialog.Filter() = "CSV Files(*.csv)|*.csv;"
        'If SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
        'path_canbus.Text = SaveFileDialog.FileName
        'path_canbus.Visible = True
        'End If
        'Catch ex As Exception
        ' MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If btn_export.Enabled = False Then
            If MsgBox("Do you want to abort import process?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                abort = True
                Throw New Exception("Export process aborted")
            End If
        End If
    End Sub

    Private Sub Form_export_full_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        path_graphtec.Text = ""
        path_gps.Text = ""
        path_fluke.Text = ""
        path_canbus.Text = ""
    End Sub
End Class