Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_fharprofil
    Public id_usage_type As Integer

    Private Sub Form_fharprofil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        execute_query_fharprofil()
    End Sub

    Private Sub execute_query_fharprofil()
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim i As Integer
        Dim sql1, sql2 As String

        Try

            ' Abrir la conexión a Sql  
            cn.Open()
            cmd.Connection = cn
            cmd.CommandTimeout = 1000
            cmd.CommandText = "select distinct data_id from data where drive_id in " & _
                              " (select drive_id from drive where usage_type_id = " & id_usage_type & _
                              " and status like 'waiting for approval' and logger_id = 2);"
            query = cmd.ExecuteReader()

            sql1 = "select drive_id"
            sql2 = "select "
            While query.Read()
                sql1 += ",avg(if(strcmp(data_id,'" & query.GetString(0) & "'),null,value)) as '" & query.GetString(0) & "'"
                sql2 += "avg(avg(if(strcmp(data_id,'" & query.GetString(0) & "'),null,value))) as '" & query.GetString(0) & "',"
            End While
            sql2 += sql2.Remove(sql2.Length - 1)
            sql1 += " from data group by drive_id having drive_id in " & _
                              " (select drive_id from drive where usage_type_id = " & id_usage_type & _
                              " and status like 'waiting for approval';);"

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
End Class