Imports MySql.Data
Imports MySql.Data.MySqlClient


Public Class Form_fharprofil
    Public id_usage_type As Integer
    Dim fharprofiles As New List(Of fharprofile)
    Dim colores As New Colours

    Private Sub Form_fharprofil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        select_value_gps()
    End Sub

    Private Sub select_value_gps()
        Dim sql As String
        Dim res As Integer = -1

        Try
            sql = "select measure_id from channel_name where channel like '%speed%'"
            res = execute_simple(sql)
            If res <> -1 Then
                execute_status(DataGridView1, res, FfE_Main.id_gps, "'waiting for approval'")
                'execute_status(DataGridView1, res, FfE_Main.id_gps, "'final'")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub execute_status(ByVal grid As DataGridView, ByVal measure_id As String, _
                              ByVal logger_id As Integer, ByVal status As String)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sql As String
        Dim i As Integer
        Dim sec As Int64
        Dim t1, t2 As DateTime
        Dim interval As TimeSpan
        Dim dec() As Decimal

        Try
            cn.Open()
            cmd.Connection = cn
            cmd.CommandTimeout = 1000
            sql = "select drive.drive_id,avg(value),max(time),min(time) from data,drive " & _
                      "where measure_id = " & measure_id & " and logger_id = " & logger_id & _
                      " group by drive.drive_id having drive_id in " & _
                      " (select drive_id from drive where usage_type_id = " & id_usage_type & _
                      " and status like " & status & ")"
            cmd.CommandText = sql
            query = cmd.ExecuteReader
            If query.HasRows Then
                If status = "'waiting for approval'" Then
                    i = 0
                    While query.Read
                        grid.Rows.Add()
                        grid(1, i).Value = query.GetString(0)
                        grid(5, i).Value = Math.Round((query.GetDouble(1)), 4)
                        t1 = query.GetString(2)
                        t2 = query.GetString(3)
                        interval = t1 - t2
                        grid(6, i).Value = interval.Hours.ToString & ":" & interval.Minutes.ToString & ":" & _
                                          interval.Seconds.ToString
                        sec = DateDiff(DateInterval.Second, t2, t1)
                        grid(4, i).Value = Math.Round((query.GetDouble(1) / 3600) * sec, 4)
                        fharprofiles.Add(New fharprofile(query.GetInt32(0), True, colores.getNexColor, _
                                         New Decimal() {Val(grid(4, i).Value), Val(grid(5, i).Value), Val(grid(6, i).Value)}, False))
                        i += 1
                    End While
                Else
                    
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fg As New fharprofilGraphic(fharprofiles, fharprofilGraphic.type.km)

        pn_graphics.Controls.Add(fg)
        pn_graphics.Controls(0).Dock = DockStyle.Fill
    End Sub
End Class