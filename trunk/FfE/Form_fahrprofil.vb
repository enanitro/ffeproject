Imports MySql.Data
Imports MySql.Data.MySqlClient


Public Class Form_fahrprofil
    Public id_usage_type As Integer
    Dim sp_gps, sp_canbus As Integer
    Dim colores As New Colours
    Public isClosed As Boolean = False

    Private Sub Form_fharprofil_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        isClosed = True
    End Sub

    Private Sub Form_fharprofil_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim pos As Integer = Form_drive.DriveBindingSource.Position
        Form_drive.DriveTableAdapter.Fill(Form_drive.Ffe_databaseDataSet.drive)
        Form_drive.DriveBindingSource.Position = pos
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
            sql = "select drive_id,avg(value),max(data_index),min(data_index) from data" & _
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
                        t1 = execute_simple("select time from data where drive_id = " & query.GetString(0) & _
                                       " and logger_id = " & logger_id & " and data_index = " & query.GetString(2))
                        t2 = execute_simple("select time from data where drive_id = " & query.GetString(0) & _
                                       " and logger_id = " & logger_id & " and data_index = " & query.GetString(3))
                        't1 = query.GetString(2)
                        't2 = query.GetString(3)
                        grid(7, i).Value = t2.ToLongTimeString
                        grid(8, i).Value = t1.ToLongTimeString
                        interval = t1 - t2
                        'grid(6, i).Value = interval.Hours.ToString & ":" & interval.Minutes.ToString & ":" & _
                        'interval.Seconds.ToString()
                        grid(6, i).Value = interval.ToString.Trim("-")
                        sec = Math.Abs(DateDiff(DateInterval.Second, t2, t1))
                        grid(2, i).Style.BackColor = colores.getNexColor
                        grid(4, i).Value = Math.Round((query.GetDouble(1) / 3600) * sec, 4)
                        grid(12, i).Value = False
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
                        t1 = execute_simple("select time from data where drive_id = " & query.GetString(0) & _
                                       " and logger_id = " & logger_id & " and data_index = " & query.GetString(2))
                        t2 = execute_simple("select time from data where drive_id = " & query.GetString(0) & _
                                       " and logger_id = " & logger_id & " and data_index = " & query.GetString(3))
                        't1 = query.GetString(2)
                        't2 = query.GetString(3)
                        grid(7, i).Value = t2.ToLongTimeString
                        grid(8, i).Value = t1.ToLongTimeString
                        interval = t1 - t2
                        'grid(6, i).Value = interval.Hours.ToString & ":" & interval.Minutes.ToString & ":" & _
                        'interval.Seconds.ToString()
                        grid(6, i).Value = interval.ToString.Trim("-")
                        sec = Math.Abs(DateDiff(DateInterval.Second, t2, t1))
                        grid(2, i).Style.BackColor = Color.Green
                        grid(4, i).Value = Math.Round((query.GetDouble(1) / 3600) * sec, 4)
                        grid(12, i).Value = True
                        speed_avg += Math.Round((query.GetDouble(1)), 4)
                        't1 = query.GetString(2)
                        't2 = query.GetString(3)
                        'sec = DateDiff(DateInterval.Second, t2, t1)
                        sec_avg += sec
                        km_avg = Math.Round((query.GetDouble(1) / 3600) * sec_avg, 4)
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
            sql = "select avg(value),max(data_index),min(data_index) from data where drive_id = " & drive_id & _
            " and (data_id like '%Fahrzeuggeschwindigkeit%' or measure_id = " & sp_canbus & ")"
            cmd.CommandTimeout = 1000
            cmd.CommandText = sql
            query = cmd.ExecuteReader
            If query.Read Then
                If query.IsDBNull(0) = False Then
                    grid(9, index).Value = Math.Round(query.GetDouble(0), 4)
                    grid(10, index).Value = execute_simple("select time from data where drive_id = " & drive_id & _
                                " and logger_id = " & FfE_Main.id_canbus & " and data_index = " & query.GetString(2))
                    grid(11, index).Value = execute_simple("select time from data where drive_id = " & drive_id & _
                                " and logger_id = " & FfE_Main.id_canbus & " and data_index = " & query.GetString(1))
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
            procesing.Show()
            Application.DoEvents()
            For i = 0 To grid.Rows.Count - 1
                If grid.Rows.Item(i).Visible = True And grid(0, i).Value = True Then
                    execute_simple("update drive set status = " & status & _
                                   " where drive_id = " & grid(1, i).Value)
                End If
            Next
            clear_window(DataGridView1)
            select_value_gps()
            procesing.Close()
        End If
    End Sub

    Private Sub load_fahrprofiles(ByVal grid As DataGridView, ByRef fahrprofiles As List(Of fahrprofile), _
                                   ByRef labels() As String, ByVal intervals() As Double, _
                                   ByVal pos As Integer)
        For i = 0 To grid.Rows.Count - 1
            If grid(0, i).Value = True Then
                Dim values(intervals.Count - 1) As Double
                For j = 0 To intervals.Count - 1
                    If grid(pos, i).Value < intervals(j) Then
                        values(j) = 1
                        j = intervals.Count
                    End If
                Next
                fahrprofiles.Add(New fahrprofile(grid(1, i).Value, grid(3, i).Value, _
                                                 grid(2, i).Style.BackColor, values, grid(12, i).Value))
            End If
        Next

        Dim labs(intervals.Count - 1) As String
        For i = 0 To intervals.Count - 1
            labs(i) = intervals(i)
        Next
        labels = labs
    End Sub

    Private Function calculate_range_km(ByVal grid As DataGridView) As Double()
        Dim max, min As Double
        Dim count As Integer = 0
        min = grid(4, 0).Value
        max = grid(4, 0).Value
        For i = 0 To grid.Rows.Count - 1
            If grid(0, i).Value = True Then
                If max < grid(4, i).Value Then
                    max = grid(4, i).Value
                Else
                    If min > grid(4, i).Value Then
                        min = grid(4, i).Value
                    End If
                End If
            End If
        Next
        max = Math.Truncate(max) + 1
        min = Math.Truncate(min)
        Dim value As String = CType(CType(min, Integer), String)
        value = value.Remove(value.Length - 1) & "0"

        count = Math.Truncate((max - value) / 5) '5 km

        Dim intervals(count) As Double
        intervals(0) = value + 5
        For i = 1 To count
            intervals(i) = intervals(i - 1) + 5
        Next

        calculate_range_km = intervals
    End Function

    Private Function calculate_range_speed(ByVal grid As DataGridView) As Double()
        Dim max, min As Double
        Dim count As Integer = 0
        min = grid(5, 0).Value
        max = grid(5, 0).Value
        For i = 0 To grid.Rows.Count - 1
            If grid(0, i).Value = True Then
                If max < grid(5, i).Value Then
                    max = grid(5, i).Value
                Else
                    If min > grid(5, i).Value Then
                        min = grid(5, i).Value
                    End If
                End If
            End If
        Next
        max = Math.Truncate(max) + 1
        min = Math.Truncate(min)
        Dim value As String = CType(CType(min, Integer), String)
        value = value.Remove(value.Length - 1) & "0"

        count = Math.Truncate((max - value) / 10) '10 km/h

        Dim intervals(count) As Double
        intervals(0) = value + 10
        For i = 1 To count
            intervals(i) = intervals(i - 1) + 10
        Next

        calculate_range_speed = intervals

    End Function

    Private Sub load_fahrprofiles_time(ByVal grid As DataGridView, ByRef fahrprofiles As List(Of fahrprofile), _
                                   ByRef labels() As String, ByVal intervals() As DateTime)
        For i = 0 To grid.Rows.Count - 1
            If grid(0, i).Value = True Then
                Dim values(intervals.Count - 1) As Double
                For j = 0 To intervals.Count - 1
                    If grid(6, i).Value < intervals(j) Then
                        values(j) = 1
                        j = intervals.Count
                    End If
                Next
                fahrprofiles.Add(New fahrprofile(grid(1, i).Value, grid(3, i).Value, _
                                                 grid(2, i).Style.BackColor, values, grid(12, i).Value))
            End If
        Next

        Dim labs(intervals.Count - 1) As String
        For i = 0 To intervals.Count - 1
            labs(i) = intervals(i).ToString("HH:mm")
        Next
        labels = labs
    End Sub


    Private Function calculate_range_time(ByVal grid As DataGridView) As DateTime()
        Dim max, min As DateTime
        Dim count As Integer = 0
        min = grid(6, 0).Value
        max = grid(6, 0).Value
        For i = 0 To grid.Rows.Count - 1
            If grid(0, i).Value = True Then
                If max < grid(6, i).Value Then
                    max = grid(6, i).Value
                Else
                    If min > grid(6, i).Value Then
                        min = grid(6, i).Value
                    End If
                End If
            End If
        Next

        max = max.ToString.Remove(max.ToString.Length - 3)
        max = max.AddMinutes(1)
        min = min.ToString.Remove(min.ToString.Length - 4) & "0"

        count = DateDiff(DateInterval.Minute, min, max) / 5 '5 min
        count = Math.Truncate(count)

        Dim intervals(count) As DateTime
        intervals(0) = min.AddMinutes(5)
        For i = 1 To count
            intervals(i) = intervals(i - 1).AddMinutes(5)
        Next

        calculate_range_time = intervals
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        procesing.Show()
        Application.DoEvents()
        Dim fharprofiles As New List(Of fahrprofile)
        Dim labels() As String
        load_fahrprofiles(DataGridView1, fharprofiles, labels, calculate_range_km(DataGridView1), 4)
        Dim fg As New fharprofilGraphic(fharprofiles, "Kms", labels)
        pn_graphics.Controls.Clear()
        pn_graphics.Controls.Add(fg)
        pn_graphics.Controls(0).Dock = DockStyle.Fill
        procesing.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        procesing.Show()
        Application.DoEvents()
        Dim fharprofiles As New List(Of fahrprofile)
        Dim labels() As String
        load_fahrprofiles(DataGridView1, fharprofiles, labels, calculate_range_speed(DataGridView1), 5)
        Dim fg As New fharprofilGraphic(fharprofiles, "Km/h", labels)
        pn_graphics.Controls.Clear()
        pn_graphics.Controls.Add(fg)
        pn_graphics.Controls(0).Dock = DockStyle.Fill
        procesing.Close()
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        procesing.Show()
        Application.DoEvents()
        Dim fharprofiles As New List(Of fahrprofile)
        Dim labels() As String
        load_fahrprofiles_time(DataGridView1, fharprofiles, labels, calculate_range_time(DataGridView1))
        Dim fg As New fharprofilGraphic(fharprofiles, "Time", labels)
        pn_graphics.Controls.Clear()
        pn_graphics.Controls.Add(fg)
        pn_graphics.Controls(0).Dock = DockStyle.Fill
        procesing.Close()
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        load_failure(DataGridView1)
    End Sub

    Private Sub clear_window(ByRef grid As DataGridView)
        grid.Rows.Clear()
        pn_graphics.Controls.Clear()
        colores = New Colours
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        update_drives(DataGridView1, "'Final'")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        update_drives(DataGridView1, "'Check'")
    End Sub
End Class