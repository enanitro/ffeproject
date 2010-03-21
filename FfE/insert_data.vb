Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class insert_Data
    Public insert_string As String
    Public Sub insert_into_string()
        Try
            Dim cn As New MySqlConnection(Global.FfE.My.MySettings.Default.ffe_databaseConnectionString)
            ' Abrir la conexión a Sql  
            cn.Open()

            Dim s As String = 0
            s = insert_string.Remove(insert_string.LastIndexOf(","))
            s += "; commit;"

            ' Pasar la consulta sql y la conexión al Sql Command   
            Dim cmd As New MySqlCommand(s, cn)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub init_string()
        insert_string = "insert high_priority into data (data_index, data_id, drive_id, logger_id, measure_id, time, value) VALUES "
    End Sub

    Public Sub set_string(ByVal cadena As String)
        insert_string += cadena & ","
    End Sub

    Function is_empty() As Boolean
        If insert_string = "insert high_priority into data (data_index, data_id, drive_id, logger_id, measure_id, time, value) VALUES " Then
            Return True
        Else
            Return False
        End If
    End Function

End Class