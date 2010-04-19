Imports MySql.Data
Imports MySql.Data.MySqlClient


Public Class Form_fharprofil
    Public id_usage_type As Integer
    Dim sp_gps, sp_canbus As Integer
    Dim colores As New Colours
    Public isClosed As Boolean = False

    Private Sub Form_fharprofil_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        isClosed = True
    End Sub

    Private Sub Form_fharprofil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GroupBox1.Text = "Fahrprofil ID " & id_usage_type
        load_usage_type()
        load_speed_channels(sp_gps, sp_canbus)
        select_value_gps()
        'load_failure(DataGridView1)
    End Sub

    Private Sub load_usage_type()
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim res As String = ""

        Try
            Label5.Text = ""
            Label6.Text = ""
            cn.Open()
            cmd.Connection = cn
            cmd.CommandTimeout = 1000
            cmd.CommandText = "select name,usage_in_project,description from usage_type where usage_type_id = " & _
                              id_usage_type
            query = cmd.ExecuteReader()
            If query.HasRows Then
                query.Read()
                If query.IsDBNull(0) = False Then
                    Label5.Text = query.GetString(0) & " (" & query.GetString(1) & ")"
                    Label6.Text = query.GetString(2)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub select_value_gps()
        'este debe se el orden
        execute_status(DataGridView1, FfE_Main.id_gps, "'final'")
        execute_status(DataGridView1, FfE_Main.id_gps, "'waiting for approval'")
    End Sub

    Private Sub load_speed_channels(ByRef sp_gps As Integer, ByRef sp_canbus As Integer)
        Dim res As String
        sp_gps = 0
        sp_canbus = 0
        res = execute_simple("select measure_id from channel_name where channel like '%speed%'")
        If res <> "" Then sp_gps = res
        res = execute_simple("select measure_id from channel_name where channel like '%fahrzeuggeschwindigkeit%'")
        If res <> "" Then sp_canbus = res
    End Sub

    Private Function execute_simple(ByVal sql As String) As String
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim res As String = ""

        Try
            cn.Open()
            cmd.Connection = cn
            cmd.CommandTimeout = 1000
            cmd.CommandText = sql
            query = cmd.ExecuteReader()
            If query.HasRows Then
                query.Read()
                res = query.GetString(0)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
            execute_simple = res
        End Try
    End Function

    Private Sub execute_status(ByVal grid As DataGridView, _
                              ByVal logger_id As Integer, ByVal status As String)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sql As String
        Dim i As Integer
        Dim km_avg, speed_avg As Double
        Dim sec, sec_avg As Int64
        Dim t1, t2 As DateTime
        Dim interval As TimeSpan
        Dim dec() As Decimal
        Try
            cn.Open()
            cmd.Connection = cn
            cmd.CommandTimeout = 1000
            sql = "select drive_id,avg(value),max(time),min(time) from data" & _
                      " where (measure_id = " & sp_gps & " or data_id like '%speed%')" & _
                      " and logger_id = " & logger_id & " group by drive_id having drive_id in " & _
                      " (select drive_id from drive where usage_type_id = " & id_usage_type & _
                      " and status like " & status & ")"
            cmd.CommandText = sql
            query = cmd.ExecuteReader
            If query.HasRows Then
                If status = "'waiting for approval'" Then
                    While query.Read
                        grid.Rows.Add()
                        i = grid.Rows.Count - 1
                        grid(1, i).Value = query.GetString(0)
                        grid(5, i).Value = Math.Round((query.GetDouble(1)), 4)
                        t1 = query.GetString(2)
                        t2 = query.GetString(3)
                        grid(7, i).Value = t2.ToShortTimeString
                        grid(8, i).Value = t1.ToShortTimeString
                        interval = t1 - t2
                        grid(6, i).Value = interval.Hours.ToString & ":" & interval.Minutes.ToString & ":" & _
                                          interval.Seconds.ToString
                        sec = DateDiff(DateInterval.Second, t2, t1)
                        grid(2, i).Style.BackColor = colores.getNexColor
                        grid(4, i).Value = Math.Round((query.GetDouble(1) / 3600) * sec, 4)
                        If find_drive(grid(1, i).Value, grid, i) Then
                            grid(3, i).Value = check_drive(i, grid)
                        End If
                    End While
                Else ' status = 'final'
                    i = 0
                    km_avg = 0
                    sec_avg = 0
                    speed_avg = 0
                    While query.Read
                        grid.Rows.Add()
                        i = grid.Rows.Count - 1
                        grid(0, i).Value = True
                        grid(1, i).Value = query.GetString(0)
                        grid(5, i).Value = Math.Round((query.GetDouble(1)), 4)
                        t1 = query.GetString(2)
                        t2 = query.GetString(3)
                        grid(7, i).Value = t2.ToShortTimeString
                        grid(8, i).Value = t1.ToShortTimeString
                        interval = t1 - t2
                        grid(6, i).Value = interval.Hours.ToString & ":" & interval.Minutes.ToString & ":" & _
                                          interval.Seconds.ToString
                        sec = DateDiff(DateInterval.Second, t2, t1)
                        grid(2, i).Style.BackColor = Label1.BackColor
                        grid(4, i).Value = Math.Round((query.GetDouble(1) / 3600) * sec, 4)
                        speed_avg += Math.Round((query.GetDouble(1)), 4)
                        t1 = query.GetString(2)
                        t2 = query.GetString(3)
                        sec = DateDiff(DateInterval.Second, t2, t1)
                        sec_avg += sec
                        km_avg = Math.Round((query.GetDouble(1) / 3600) * sec_avg, 4)
                        'fharprofiles.Add(New fharprofile(query.GetInt32(0), True, Label1.BackColor, _
                        '                New Decimal() {Val(Math.Round((query.GetDouble(1) / 3600) * sec, 4)), _
                        '                              Val(Math.Round((query.GetDouble(1)), 4)), _
                        '                             Val(DateDiff(DateInterval.Second, t2, t1))}, True))
                        grid.Rows.Item(i).Visible = False
                        i += 1
                    End While
                    Label1.Text = km_avg / i
                    Label2.Text = speed_avg / i
                    Label3.Text = sec_to_time(sec_avg / i)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Function find_drive(ByVal drive_id As Integer, ByRef grid As DataGridView, ByVal index As Integer) As Boolean
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sql As String
        Dim find As Boolean = False
        Try
            cn.Open()
            cmd.Connection = cn
            sql = "select avg(value),max(time),min(time) from data where drive_id = " & drive_id & _
            " and (data_id like '%Fahrzeuggeschwindigkeit%' or measure_id = " & sp_canbus & ")"
            cmd.CommandTimeout = 1000
            cmd.CommandText = sql
            query = cmd.ExecuteReader
            If query.Read Then
                If query.IsDBNull(0) = False Then
                    grid(9, index).Value = Math.Round(query.GetDouble(0), 4)
                    grid(10, index).Value = query.GetString(2)
                    grid(11, index).Value = query.GetString(1)
                    find = True
                End If
            End If
            query.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
            find_drive = find
        End Try
    End Function

    Private Function check_drive(ByVal index As Integer, ByVal grid As DataGridView) As Boolean
        Dim ts1, ts2, te1, te2 As DateTime
        Dim interval1, interval2 As Double
        ts1 = grid(7, index).Value
        ts2 = grid(10, index).Value
        te1 = grid(8, index).Value
        te2 = grid(11, index).Value
        interval1 = DateDiff(DateInterval.Second, ts1, ts2)
        interval2 = DateDiff(DateInterval.Second, te1, te2)
        If grid(5, index).Value < grid(9, index).Value * 0.95 Or _
        grid(5, index).Value > grid(9, index).Value * 1.05 Or _
        interval1 < interval2 * 0.95 Or interval1 > interval2 * 1.05 Then
            check_drive = True
        Else
            check_drive = False
        End If
    End Function

    Private Function sec_to_time(ByVal sec As Double) As String
        Dim h, m, s As Integer
        h = Math.Truncate(sec / 3600)
        m = (sec / 60) Mod 60
        s = sec Mod 60
        sec_to_time = h & ":" & m & ":" & s
    End Function

    Private Sub load_failure(ByVal grid As DataGridView)
        If grid.Rows.Count > 0 Then
            TextBox1.Text = grid.CurrentRow.Cells(5).Value
            TextBox2.Text = grid.CurrentRow.Cells(7).Value
            TextBox3.Text = grid.CurrentRow.Cells(8).Value
            TextBox6.Text = grid.CurrentRow.Cells(9).Value
            TextBox5.Text = grid.CurrentRow.Cells(10).Value
            TextBox4.Text = grid.CurrentRow.Cells(11).Value
        End If
    End Sub

    Private Sub update_drives(ByVal grid As DataGridView, ByVal status As String)
        If MsgBox("Are you sure to update drives selected?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For i = 0 To grid.Rows.Count - 1
                If grid.Rows.Item(i).Visible = True And grid(0, i).Value = True Then
                    execute_simple("update drive set status = " & status & _
                                   " where drive_id = " & grid(1, i).Value)
                End If
            Next
        End If
    End Sub

    Private Sub load_fahrprofiles(ByVal grid As DataGridView, ByRef fahrprofiles As List(Of fharprofile))
        For i = 0 To grid.Rows.Count - 1
            If grid(0, i).Value = True Then
                fahrprofiles.Add(New fharprofile(grid(1, i).Value, True, grid(2, i).Style.BackColor, _
                         New Decimal() {Val(grid(4, i).Value), Val(grid(5, i).Value), _
                         Val(DateDiff(DateInterval.Second, grid(7, i).Value, grid(8, i).Value))}, False))
            End If
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fharprofiles As New List(Of fharprofile)
        load_fahrprofiles(DataGridView1, fharprofiles)
        Dim fg As New fharprofilGraphic(fharprofiles, fharprofilGraphic.type.km)
        pn_graphics.Controls.Clear()
        pn_graphics.Controls.Add(fg)
        pn_graphics.Controls(0).Dock = DockStyle.Fill
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim fharprofiles As New List(Of fharprofile)
        load_fahrprofiles(DataGridView1, fharprofiles)
        Dim fg As New fharprofilGraphic(fharprofiles, fharprofilGraphic.type.speed)
        pn_graphics.Controls.Clear()
        pn_graphics.Controls.Add(fg)
        pn_graphics.Controls(0).Dock = DockStyle.Fill
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim fharprofiles As New List(Of fharprofile)
        load_fahrprofiles(DataGridView1, fharprofiles)
        Dim fg As New fharprofilGraphic(fharprofiles, fharprofilGraphic.type.time)
        pn_graphics.Controls.Clear()
        pn_graphics.Controls.Add(fg)
        pn_graphics.Controls(0).Dock = DockStyle.Fill
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        load_failure(DataGridView1)
    End Sub

    Private Sub clear_window(ByRef grid As DataGridView)
        grid.Rows.Clear()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        update_drives(DataGridView1, "'Final'")
        clear_window(DataGridView1)
        select_value_gps()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        update_drives(DataGridView1, "'Check'")
        clear_window(DataGridView1)
        select_value_gps()
    End Sub
End Class