﻿Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_export_full

    Private Sub btn_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export.Click
        Try
            If path_graphtec.Text <> "" Then
                ProgressBar1.Visible = True
                percent_graphtec.Visible = True
                logger_csv_file(path_graphtec.Text, FfE_Main.id_graphtec, "GRAPHTEC GL800")
            End If
            If path_graphtec.Text <> "" Then
                ProgressBar2.Visible = True
                percent_gps.Visible = True
                logger_csv_file(path_gps.Text, FfE_Main.id_gps, "COLUMBUS GPS")
            End If
            If path_graphtec.Text <> "" Then
                ProgressBar3.Visible = True
                percent_fluke.Visible = True
                logger_csv_file(path_fluke.Text, FfE_Main.id_fluke, "FLUKE")
            End If
            'logger_csv_file(SaveFileDialog.FileName, FfE_Main.id_canbus, "CAN-BUS", Label22.Text)
            MsgBox("Data-loggers were imported successfully", MsgBoxStyle.Information)
            clean_groups()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub

    Private Sub clean_groups()
        ProgressBar1.Visible = False
        percent_graphtec.Visible = False
        ProgressBar2.Visible = False
        percent_gps.Visible = False
        ProgressBar4.Visible = False
        percent_fluke.Visible = False
        ProgressBar3.Visible = False
        percent_canbus.Visible = False
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
        Try
            Dim text, sql, res, points, channels As String
            Dim sw As New System.IO.StreamWriter(path)

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
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            sql = "select distinct data_id, unit from data_full where drive_id = " & drive_id.Text & _
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
            sql = "select count(value) from data_full where drive_id = " & drive_id.Text & _
              " and logger_id = " & logger_id & " order by data_index"
            execute_query(sql, count)
            sql = "select time,value from data_full where drive_id = " & drive_id.Text & _
              " and logger_id = " & logger_id & " order by data_index"
            cmd.CommandText = sql
            query = cmd.ExecuteReader()


            calculate_max(max, logger_id)
            config_progressbar(max, bar)
            i = 1
            count = count / distinct
            query.Read()
            Do While i <= count
                res += i & "," & query.GetString(0)
                For j = 1 To distinct
                    res += "," & query.GetString(1).Replace(",", ".")
                    query.Read()
                Next
                progressbar(i, percent.Text, bar)
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
        Try
            SaveFileDialog.Filter() = "CSV Files(*.csv)|*.csv;"
            If SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                path_canbus.Text = SaveFileDialog.FileName
                path_canbus.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class