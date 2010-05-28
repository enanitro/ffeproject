Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_export_full
    Dim abort As Boolean = False
    Public isClosed As Boolean = False

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
            If path_lmg.Text <> "" And abort = False And CheckBox3.CheckState = CheckState.Unchecked Then
                TextBox3.Visible = False
                logger_csv_file(path_lmg.Text, FfE_Main.id_lmg, "LMG 500")
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
        percent_lmg500.Visible = False
        path_lmg.Text = ""
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
                           "DATE: " & datef.Text & vbCrLf & _
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
            procesing.Show()
            Application.DoEvents()
            data_points_channels(points, channels, logger_id)
            head_csv_file(text)
            res = ""
            sql = "select if(timestep is null,'no defined',timestep) from data_full where drive_id = " & _
                    drive_id.Text & " and logger_id = " & logger_id
            execute_query(sql, res)
            If res <> "" Then
                text += logger & vbCrLf & _
                        points & " data points (" & channels & "channels)" & vbCrLf & _
                        "TIME STEP: " & res & vbCrLf
                sw.WriteLine(text)
                sw.Close()

                Select Case logger_id
                    Case FfE_Main.id_graphtec
                        execute_query_loggers(logger_id, logger, ProgressBar1, percent_graphtec, TextBox1, path)
                    Case FfE_Main.id_gps
                        execute_query_loggers(logger_id, logger, ProgressBar2, percent_gps, TextBox2, path)
                    Case FfE_Main.id_lmg
                        execute_query_logger_lmg(logger_id, logger, ProgressBar3, percent_lmg500, TextBox3, path)
                    Case FfE_Main.id_canbus
                        execute_query_logger_canbus(logger_id, logger, ProgressBar4, percent_canbus, TextBox4, path)
                End Select

            End If

        Catch ex As Exception
            If ex.Message = "Export process aborted" Then
                sw.Close()
                If My.Computer.FileSystem.FileExists(path_graphtec.Text) Then
                    My.Computer.FileSystem.DeleteFile(path_graphtec.Text)
                End If
                If My.Computer.FileSystem.FileExists(path_gps.Text) Then
                    My.Computer.FileSystem.DeleteFile(path_gps.Text)
                End If
                If My.Computer.FileSystem.FileExists(path_lmg.Text) Then
                    My.Computer.FileSystem.DeleteFile(path_lmg.Text)
                End If
                If My.Computer.FileSystem.FileExists(path_canbus.Text) Then
                    My.Computer.FileSystem.DeleteFile(path_canbus.Text)
                End If
                path_graphtec.Text = ""
                path_gps.Text = ""
                path_lmg.Text = ""
                path_canbus.Text = ""
                MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            abort = True
        Finally
            procesing.Close()
        End Try
    End Sub


    Private Sub execute_query_loggers(ByVal logger_id As Integer, ByVal logger As String, ByRef bar As ProgressBar, _
                                      ByRef percent As Label, ByRef tb As TextBox, ByVal path As String)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim sw As New System.IO.StreamWriter(path, True)
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sql, res As String
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
                res += "," & query.GetString(0).Replace(",", ".")
                sql += ",','" & vbCrLf & ",sum(value*(1-abs(sign(IF(STRCMP(data_id,'" & query.GetString(0) & "'),1,0)))))"
            End While

            sql += ") as format_row from data" & _
                " where drive_id = " & drive_id.Text & _
                " and logger_id = " & logger_id & _
                " group by data_index"
            cn.Close()

            tb.Text = sql
            tb.Visible = True

            sw.WriteLine(res)
            res = ""

            cn.Open()
            cmd.CommandTimeout = 1000
            cmd.CommandText = sql
            query = cmd.ExecuteReader()

            sql = "select max(data_index) from data_full where drive_id = " & drive_id.Text & _
            " and logger_id = " & logger_id & " order by data_index, time"
            execute_query(sql, max)

            bar.Visible = True
            percent.Visible = True
            procesing.Close()
            config_progressbar(max, bar)
            i = 1
            While query.Read()
                res += query.GetString(0)
                i = query.GetString(0).Split(",")(0)
                progressbar(i, percent.Text, bar)
                If (i Mod 1001) >= 1000 Then
                    sw.Write(res)
                    res = ""
                End If
                i += 1
                res += vbCrLf

                Application.DoEvents()
            End While

            res += vbCrLf
            sw.WriteLine(res)

        Catch ex As Exception
            If ex.Message = "Export process aborted" Then
                Throw New Exception("Export process aborted")
            Else
                MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            abort = True
        Finally
            sw.Close()
            cn.Close()
        End Try
    End Sub

    Private Sub execute_query_logger_lmg(ByVal logger_id As Integer, ByVal logger As String, ByRef bar As ProgressBar, _
                                      ByRef percent As Label, ByRef tb As TextBox, ByVal path As String)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim sw As New System.IO.StreamWriter(path, True)
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sql, res, head As String
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
            head = ",Zeit differenz,MG1,,,,,,,MG2,,,,,,,Klimakompressor,,,HV-Batterie,,"
            res = "INDEX,TIME"

            While query.Read()
                res += "," & query.GetString(0).Replace(",", ".")
                sql += ",','" & vbCrLf & ",sum(value*(1-abs(sign(IF(STRCMP(data_id,'" & query.GetString(0) & "'),1,0)))))"
            End While

            sql += ") as format_row from data" & _
                " where drive_id = " & drive_id.Text & _
                " and logger_id = " & logger_id & _
                " group by data_index"
            cn.Close()

            tb.Text = sql
            tb.Visible = True

            sw.WriteLine(head)
            sw.WriteLine(res)
            res = ""

            cn.Open()
            cmd.CommandTimeout = 1000
            cmd.CommandText = sql
            query = cmd.ExecuteReader()

            sql = "select max(data_index) from data_full where drive_id = " & drive_id.Text & _
            " and logger_id = " & logger_id & " order by data_index, time"
            execute_query(sql, max)

            bar.Visible = True
            percent.Visible = True
            procesing.Close()
            config_progressbar(max, bar)
            i = 1
            While query.Read()
                res += query.GetString(0)
                i = query.GetString(0).Split(",")(0)
                progressbar(i, percent.Text, bar)
                If (i Mod 1001) >= 1000 Then
                    sw.Write(res)
                    res = ""
                End If
                i += 1
                res += vbCrLf

                Application.DoEvents()
            End While

            res += vbCrLf
            sw.WriteLine(res)

        Catch ex As Exception
            If ex.Message = "Export process aborted" Then
                Throw New Exception("Export process aborted")
            Else
                MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            abort = True
        Finally
            sw.Close()
            cn.Close()
        End Try
    End Sub

    Private Sub execute_query_logger_canbus(ByVal logger_id As Integer, ByVal logger As String, ByRef bar As ProgressBar, _
                                      ByRef percent As Label, ByRef tb As TextBox, ByVal path As String)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sw As New System.IO.StreamWriter(path, True)
        Dim sql, res, time, aux As String
        Dim i, j, max, count, num, index As Integer
        Dim avg, total As Double
        res = ""

        Try
            SQL_syntax_canbus(FfE_Main.id_canbus, "CAN-BUS", TextBox4)
            tb.Visible = True

            Dim sqls(0) As String

            cn.Open()
            cmd.Connection = cn
            sql = "select distinct data_id from data_full where drive_id = " & drive_id.Text & _
             " and logger_id = " & logger_id & " order by data_id"
            cmd.CommandTimeout = 1000
            cmd.CommandText = sql
            query = cmd.ExecuteReader()

            sql = ""
            res = ""
            count = 0
            While query.Read
                grid.Columns.Add(query.GetString(0), query.GetString(0))
                Array.Resize(sqls, count + 1)
                sqls(count) = "select concat(time,if(milsec is null,'',concat('.',milsec)),',',value) from data" & _
                " where drive_id = " & drive_id.Text & " and logger_id = " & logger_id & _
                " and data_id like '" & query.GetString(0) & "'"
                res += "TIME," & query.GetString(0).Replace(",", ".") & ","
                count += 1
            End While
            cn.Close()
            res = res.Remove(res.Length - 1)
            sw.WriteLine(res)
            res = ""

            For i = 0 To count - 1
                cn.Open()
                cmd.Connection = cn
                cmd.CommandText = sqls(i)
                cmd.CommandTimeout = 1000
                query = cmd.ExecuteReader
                j = 0
                If query.HasRows Then
                    While query.Read
                        If grid.Rows.Count - 1 < j Then
                            grid.Rows.Add()
                        End If
                        grid(i, j).Value = query.GetString(0) & ","
                        j += 1
                    End While
                End If
                cn.Close()
            Next

            bar.Visible = True
            percent.Visible = True
            config_progressbar(grid.Rows.Count, bar)

            procesing.Close()
            num = 0
            For i = 0 To grid.Rows.Count - 1
                For j = 0 To grid.Columns.Count - 1
                    If grid(j, i).Value = "" Then
                        res += ",,"
                    Else
                        res += grid(j, i).Value
                        progressbar(i, percent.Text, bar)
                        Application.DoEvents()
                    End If
                Next
                res = res.Remove(res.Length - 1) & vbCrLf
                If i Mod 1000 = 0 Then
                    sw.Write(res)
                    res = ""
                End If
            Next

            'i = 1
            'While query.Read()
            ' execute_query_canbus_channel(logger_id, logger, ProgressBar4, percent_canbus, TextBox4, path, _
            '                            query.GetString(0), i)
            'End While

            res += vbCrLf
            sw.WriteLine(res)
            sw.Close()

        Catch ex As Exception
            If ex.Message = "Export process aborted" Then
                Throw New Exception("Export process aborted")
            Else
                MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            abort = True
        Finally
            sw.Close()
            cn.Close()
        End Try
    End Sub

    Private Sub execute_query_canbus_channel(ByVal logger_id As Integer, ByVal logger As String, _
                                             ByRef bar As ProgressBar, ByRef percent As Label, _
                                             ByRef tb As TextBox, ByVal path As String, _
                                             ByVal ch As String, ByRef i As Integer)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim sw As New System.IO.StreamWriter(path, True)
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sql, res As String
        res = ""

        Try

            cn.Open()
            cmd.Connection = cn
            cmd.CommandTimeout = 1000
            sql = "select concat(data_index,',',time,',',value) from data" & _
                " where drive_id = " & drive_id.Text & " and logger_id = " & logger_id & _
                " and data_id like '" & ch & "'"
            cmd.CommandText = sql
            query = cmd.ExecuteReader()
            res = "INDEX,TIME," & ch
            sw.WriteLine(res)
            res = ""

            While query.Read()
                res += query.GetString(0)
                progressbar(i, percent.Text, bar)
                If (i Mod 1001) >= 1000 Then
                    sw.Write(res)
                    res = ""
                End If
                i += 1
                res += vbCrLf
                Application.DoEvents()
            End While

            res += vbCrLf
            sw.WriteLine(res)

        Catch ex As Exception
            If ex.Message = "Export process aborted" Then
                Throw New Exception("Export process aborted")
            Else
                MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            abort = True
        Finally
            cn.Close()
            sw.Close()
        End Try

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            SaveFileDialog.Filter() = "CSV Files(*.csv)|*.csv"
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
            SaveFileDialog.Filter() = "CSV Files(*.csv)|*.csv"
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
            SaveFileDialog.Filter() = "CSV Files(*.csv)|*.csv"
            If SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                path_lmg.Text = SaveFileDialog.FileName
                path_lmg.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            SaveFileDialog.Filter() = "CSV Files(*.csv)|*.csv"
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

    Private Sub Form_export_full_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        isClosed = True
    End Sub

    Private Sub search_loggers()
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader

        Try
            cn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cn
            cmd.CommandText = "select distinct(logger_id) from data where drive_id = " & drive_id.Text
            query = cmd.ExecuteReader()
            If query.HasRows() Then
                While query.Read()
                    Select Case query.GetString(0)
                        Case FfE_Main.id_graphtec
                            GroupBox2.Enabled = True
                        Case FfE_Main.id_gps
                            GroupBox3.Enabled = True
                        Case FfE_Main.id_lmg
                            GroupBox5.Enabled = True
                        Case FfE_Main.id_canbus
                            GroupBox4.Enabled = True
                    End Select
                End While
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub Form_export_full_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        path_graphtec.Text = ""
        path_gps.Text = ""
        path_lmg.Text = ""
        path_canbus.Text = ""
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        TextBox4.Visible = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        GroupBox5.Enabled = False
        GroupBox4.Enabled = False
        search_loggers()
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
                " group by data_index"
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

    Private Sub SQL_syntax_canbus(ByVal logger_id As Integer, ByVal logger As String, ByVal text As TextBox)
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
             " and logger_id = " & logger_id & " order by data_id"
            cmd.CommandTimeout = 1000
            cmd.CommandText = sql
            query = cmd.ExecuteReader()
            sql = ""

            While query.Read()
                sql += "select concat(data_index,',',time,',',value) from data" & _
                " where drive_id = " & drive_id.Text & " and logger_id = " & logger_id & _
                " and data_id like '" & query.GetString(0) & "'" & vbCrLf
            End While

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
                SQL_syntax(FfE_Main.id_lmg, "LMG 500", TextBox3)
            End If
            TextBox3.Visible = True
        Else
            TextBox3.Visible = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.CheckState = CheckState.Checked Then
            If TextBox4.Text = "" Then
                SQL_syntax_canbus(FfE_Main.id_canbus, "CAN-BUS", TextBox4)
            End If
            TextBox4.Visible = True
        Else
            TextBox4.Visible = False
        End If
    End Sub

    Private Sub SQL_channels()
        SQL_syntax(FfE_Main.id_graphtec, "GRAPHTEC GL800", TextBox1)
        SQL_syntax(FfE_Main.id_gps, "COLUMBUS GPS", TextBox2)
        SQL_syntax(FfE_Main.id_lmg, "LMG 500", TextBox3)
        SQL_syntax_canbus(FfE_Main.id_canbus, "CAN-BUS", TextBox4)
    End Sub
End Class