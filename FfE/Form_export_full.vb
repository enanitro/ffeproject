﻿Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_export_full
    Dim abort As Boolean = False

    Private Sub btn_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export.Click
        Dim into As Boolean = False
        Try
            btn_export.Enabled = False
            If path_graphtec.Text <> "" And abort = False And CheckBox1.CheckState = CheckState.Unchecked Then
                TextBox1.Visible = False
                logger_csv_file(path_graphtec.Text, FfE_Main.id_graphtec, "GRAPHTEC GL800")
                into = True
            End If
            If path_gps.Text <> "" And abort = False And CheckBox2.CheckState = CheckState.Unchecked Then
                TextBox2.Visible = False
                logger_csv_file(path_gps.Text, FfE_Main.id_gps, "COLUMBUS GPS")
                into = True
            End If
            If path_fluke.Text <> "" And abort = False And CheckBox3.CheckState = CheckState.Unchecked Then
                TextBox3.Visible = False
                logger_csv_file(path_fluke.Text, FfE_Main.id_fluke, "LMG 500")
                into = True
            End If
            If path_canbus.Text <> "" And abort = False And CheckBox4.CheckState = CheckState.Unchecked Then
                TextBox4.Visible = False
                logger_csv_file(path_canbus.Text, FfE_Main.id_canbus, "CAN-BUS")
                into = True
            End If
            If abort <> True And into <> False Then
                MsgBox("Data-loggers were exported successfully", MsgBoxStyle.Information)
            End If
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
        TextBox1.Visible = False
        ProgressBar2.Visible = False
        percent_gps.Visible = False
        path_gps.Text = ""
        TextBox2.Visible = False
        ProgressBar4.Visible = False
        percent_fluke.Visible = False
        path_fluke.Text = ""
        TextBox3.Visible = False
        ProgressBar3.Visible = False
        percent_canbus.Visible = False
        path_canbus.Text = ""
        TextBox4.Visible = False
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
            'He añadido esto: por defecto commandTimeOut vale 30, pero si le pones cero espera indefinidamente, supongo que con esto funcionará
            cmd.CommandTimeout = 1000
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
                        execute_query_loggers(res, logger_id, logger, ProgressBar1, percent_graphtec, TextBox1)
                    Case FfE_Main.id_gps
                        execute_query_loggers(res, logger_id, logger, ProgressBar2, percent_gps, TextBox2)
                    Case FfE_Main.id_fluke
                        execute_query_loggers(res, logger_id, logger, ProgressBar3, percent_fluke, TextBox3)
                    Case FfE_Main.id_canbus
                        execute_query_loggers(res, logger_id, logger, ProgressBar4, percent_canbus, TextBox4)
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
                                      ByRef percent As Label, ByRef tb As TextBox)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString

        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sql As String
        Dim i, max As Integer
        res = ""

        Try

            ' Abrir la conexión a Sql  
            cn.Open()
            cmd.Connection = cn

            sql = "select distinct data_id from data_full where drive_id = " & drive_id.Text & _
             " and logger_id = " & logger_id
            cmd.CommandTimeout = 1000
            cmd.CommandText = sql
            query = cmd.ExecuteReader()

            sql = "select concat(data_index,',',time"
            res = "INDEX,TIME"

            While query.Read()
                res += "," & query.GetString(0)
                sql += ",','" & vbCrLf & ",sum(value*(1-abs(sign(IF(STRCMP(data_id,'" & query.GetString(0) & "'),1,0)))))"
            End While

            sql += ") as format_row from data" & _
                " where drive_id = " & drive_id.Text & _
                " and logger_id = " & logger_id & _
                " group by data_index;"
            res += vbCrLf
            cn.Close()

            tb.Text = sql
            tb.Visible = True


            cn.Open()
            cmd.CommandTimeout = 1000
            cmd.CommandText = sql
            query = cmd.ExecuteReader()

            sql = "select max(data_index) from data_full where drive_id = " & drive_id.Text & _
            " and logger_id = " & logger_id & " order by data_index, time"
            execute_query(sql, max)

            bar.Visible = True
            percent.Visible = True
            config_progressbar(max, bar)
            i = 1
            While query.Read()
                res += query.GetString(0)
                i = query.GetString(0).Split(",")(0)
                progressbar(i, percent.Text, bar)
                i += 1
                res += vbCrLf
                Application.DoEvents()
            End While

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
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        TextBox4.Visible = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub SQL_syntax(ByVal logger_id As Integer, ByVal logger As String, ByVal text As TextBox)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString

        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sql As String

        Try

            ' Abrir la conexión a Sql  
            cn.Open()
            cmd.Connection = cn

            sql = "select distinct data_id from data_full where drive_id = " & drive_id.Text & _
             " and logger_id = " & logger_id
            cmd.CommandTimeout = 1000
            cmd.CommandText = sql
            query = cmd.ExecuteReader()

            sql = "select concat(data_index,',',time"

            While query.Read()
                sql += ",','" & vbCrLf & ",sum(value*(1-abs(sign(IF(STRCMP(data_id,'" & query.GetString(0) & "'),1,0)))))"
            End While

            sql += ") as format_row from data" & _
                " where drive_id = " & drive_id.Text & _
                " and logger_id = " & logger_id & _
                " group by data_index;"
            cn.Close()

            text.Text = sql

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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            If TextBox1.Text = "" Then
                SQL_syntax(FfE_Main.id_graphtec, "GRAPHTEC GL800", TextBox1)
            End If
            TextBox1.Visible = True
        Else
            TextBox1.Visible = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.CheckState = CheckState.Checked Then
            If TextBox2.Text = "" Then
                SQL_syntax(FfE_Main.id_gps, "COLUMBUS GPS", TextBox2)
            End If
            TextBox2.Visible = True
        Else
            TextBox2.Visible = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.CheckState = CheckState.Checked Then
            If TextBox3.Text = "" Then
                SQL_syntax(FfE_Main.id_fluke, "LMG 500", TextBox3)
            End If
            TextBox3.Visible = True
        Else
            TextBox3.Visible = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.CheckState = CheckState.Checked Then
            If TextBox4.Text = "" Then
                SQL_syntax(FfE_Main.id_canbus, "CAN-BUS", TextBox4)
            End If
            TextBox4.Visible = True
        Else
            TextBox4.Visible = False
        End If
    End Sub

    Private Sub SQL_channels()
        SQL_syntax(FfE_Main.id_graphtec, "GRAPHTEC GL800", TextBox1)
        SQL_syntax(FfE_Main.id_gps, "COLUMBUS GPS", TextBox2)
        SQL_syntax(FfE_Main.id_fluke, "LMG 500", TextBox3)
        SQL_syntax(FfE_Main.id_canbus, "CAN-BUS", TextBox4)
    End Sub
End Class