Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class functions

    Public Function function_kms(ByVal drive As Integer) As Double
        'variables
        Dim sql, res, measure As String
        Dim avg, kms As Double
        Dim time1, time2 As DateTime
        Dim sec As Int64

        'search measure_id
        measure = ""
        sql = "select measure_id from channel_name where channel like '%speed%'"
        measure = execute_query(sql)

        If measure = "" Then
            'if not exist search channel "speed"
            measure = "data_id like '%speed%'"
        Else
            measure = "measure_id = " & measure
        End If

        'get average value
        sql = "select avg(value) from data" & _
              " where " & measure & _
              " and logger_id = " & FfE_Main.id_gps & " and drive_id = " & drive
        avg = execute_query(sql)

        'get first(min) "time"
        sql = "select min(data_index) from data" & _
              " where " & measure & _
              " and logger_id = " & FfE_Main.id_gps & " and drive_id = " & drive
        res = execute_query(sql)
        sql = "select time from data" & _
              " where " & measure & " and data_index = " & res & _
              " and logger_id = " & FfE_Main.id_gps & " and drive_id = " & drive
        time1 = execute_query(sql)

        'get last(max) "time"
        sql = "select max(data_index) from data" & _
              " where " & measure & _
              " and logger_id = " & FfE_Main.id_gps & " and drive_id = " & drive
        res = execute_query(sql)
        sql = "select time from data" & _
              " where " & measure & " and data_index = " & res & _
              " and logger_id = " & FfE_Main.id_gps & " and drive_id = " & drive
        time2 = execute_query(sql)

        'calculating interval in seconds
        sec = Math.Abs(DateDiff(DateInterval.Second, time1, time2))

        'calculating kms
        kms = (avg / 3600) * sec

        'return result
        function_kms = kms
    End Function

    'execute a query (to get only one result)
    Private Function execute_query(ByVal sql As String) As String
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
            execute_query = res
        End Try
    End Function

End Class
