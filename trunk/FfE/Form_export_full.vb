Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_export_full
    Dim abort As Boolean = False

    Private Sub btn_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export.Click
        Dim into As Boolean = False
        Try
            btn_export.Enabled = False
            If path_graphtec.Text <> "" And abort = False And CheckBox1.CheckState = CheckState.Unchecked Then
                logger_csv_file(path_graphtec.Text, FfE_Main.id_graphtec, "GRAPHTEC GL800")
                into = True
            End If
            If path_gps.Text <> "" And abort = False And CheckBox2.CheckState = CheckState.Unchecked Then
                logger_csv_file(path_gps.Text, FfE_Main.id_gps, "COLUMBUS GPS")
                into = True
            End If
            If path_fluke.Text <> "" And abort = False And CheckBox3.CheckState = CheckState.Unchecked Then
                logger_csv_file(path_fluke.Text, FfE_Main.id_fluke, "LMG 500")
                into = True
            End If
            If path_canbus.Text <> "" And abort = False And CheckBox4.CheckState = CheckState.Unchecked Then
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
                        execute_query_loggers(res, logger_id, logger, ProgressBar1, percent_graphtec)
                    Case FfE_Main.id_gps
                        execute_query_loggers(res, logger_id, logger, ProgressBar2, percent_gps)
                    Case FfE_Main.id_fluke
                        execute_query_loggers(res, logger_id, logger, ProgressBar3, percent_fluke)
                    Case FfE_Main.id_canbus
                        execute_query_loggers(res, logger_id, logger, ProgressBar4, percent_canbus)
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

            sql = "select convert(concat(data_index,',',time"
            res = "INDEX,TIME"

            While query.Read()
                res += "," & query.GetString(0)
                sql += ",',',sum(value*(1-abs(sign(IF(STRCMP(data_id,'" & query.GetString(0) & "'),1,0)))))"
            End While

            sql += ") using utf8) as format_row from data" & _
                " where drive_id = " & drive_id.Text & _
                " and logger_id = " & logger_id & _
                " group by data_index;"
            res += vbCrLf
            cn.Close()

            show_data(sql)



            'cn.Open()
            'cmd.CommandTimeout = 1000
            'cmd.CommandText = sql
            'query = cmd.ExecuteReader()

            'sql = "select max(data_index) from data_full where drive_id = " & drive_id.Text & _
            '" and logger_id = " & logger_id & " order by data_index, time"
            'execute_query(sql, max)

            'bar.Visible = True
            'percent.Visible = True
            'config_progressbar(max, bar)
            'i = 1
            'While query.Read()
            ' res += query.GetString(0)
            'i = query.GetString(0).Split(",")(0)
            'progressbar(i, percent.Text, bar)
            'i += 1
            'res += vbCrLf
            'Application.DoEvents()
            'End While

            'res += vbCrLf
            'cn.Close()


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

    Private Sub show_data(ByVal text As String)
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim sql As String = ""

        Try

            'grid.DataSource = ""
            'execute_query_loggers(sql, logger_id)

            ' Abrir la conexión a Sql  
            cn.Open()

            ' Pasar la consulta sql y la conexión al Sql Command   
            Dim cmd As New MySqlCommand(text, cn)
            cmd.CommandTimeout = 1000

            ' Inicializar un nuevo SqlDataAdapter   
            Dim da As New MySqlDataAdapter(cmd)

            'Crear y Llenar un Dataset  
            Dim ds As New DataSet

            'da.FillSchema(ds, SchemaType.Mapped)
            da.Fill(ds)

            Dim tbl As DataTable = ds.Tables(0) ' data table prepara la estructura de la tabla
            Dim sw As New System.IO.StreamWriter("C:\Users\enanitro\Desktop\Alemania\FfE\prueba000000.txt")
            For Each r In tbl.Rows
                sw.WriteLine(r.item(0))
            Next
            sw.Close()


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
        SQL_channels()
    End Sub

    Private Sub SQL_channels()
        SQL_syntax(FfE_Main.id_graphtec, "GRAPHTEC GL800", TextBox1)
        SQL_syntax(FfE_Main.id_gps, "COLUMBUS GPS", TextBox2)
        SQL_syntax(FfE_Main.id_fluke, "LMG 500", TextBox3)
        SQL_syntax(FfE_Main.id_canbus, "CAN-BUS", TextBox4)
    End Sub

    Private Sub SQL_syntax(ByVal logger_id As Integer, ByVal logger As String, ByVal text As TextBox)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString

        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sql As String
        Dim head As String

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
            head = "INDEX,TIME"

            While query.Read()
                head += "," & query.GetString(0)
                sql += ",','" & vbCrLf & ",sum(value*(1-abs(sign(IF(STRCMP(data_id,'" & query.GetString(0) & "'),1,0)))))"
            End While

            sql += ") as '" & head & "' from data" & _
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

End Class