Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_view_data
    Dim drive_id As Integer
    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal id As Integer)
        Me.new()
        drive_id = id
    End Sub

    Private Sub show_loggers()
        
        show_data(DataGridView, FfE_Main.id_graphtec)
        show_data(DataGridView1, FfE_Main.id_gps)
        show_data(DataGridView2, FfE_Main.id_fluke)
        show_data(DataGridView3, FfE_Main.id_canbus)

    End Sub

    Private Sub format_grid(ByRef grid As DataGridView)
        grid.ReadOnly = True
        grid.AllowUserToAddRows = False
        grid.AllowUserToDeleteRows = False
        grid.Columns(0).Width = 60
        grid.Columns(1).Width = 60
        For i = 2 To grid.Columns.Count - 1
            grid.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
    End Sub

    Private Sub show_data(ByRef grid As DataGridView, ByVal logger_id As Integer)
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim sql As String = ""

        Try

            grid.DataSource = ""
            execute_query_loggers(sql, logger_id)

            ' Abrir la conexión a Sql  
            cn.Open()

            ' Pasar la consulta sql y la conexión al Sql Command   
            Dim cmd As New MySqlCommand(sql, cn)
            cmd.CommandTimeout = 1000

            ' Inicializar un nuevo SqlDataAdapter   
            Dim da As New MySqlDataAdapter(cmd)

            'Crear y Llenar un Dataset  
            Dim ds As New DataSet

            da.Fill(ds)

            Dim tbl As DataTable = ds.Tables(0) ' data table prepara la estructura de la tabla
            If tbl.Rows.Count > 0 Then
                grid.DataSource = tbl
                format_grid(grid)
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
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
            cmd.CommandTimeout = 0
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

    Private Sub execute_query_loggers(ByRef sql As String, ByVal logger_id As Integer)

        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim i As Integer
        sql = ""

        Try
            ' Abrir la conexión a Sql  
            cn.Open()
            cmd.Connection = cn

            sql = "select distinct data_id from data where drive_id = " & drive_id & _
             " and logger_id = " & logger_id
            cmd.CommandTimeout = 1000000
            cmd.CommandText = sql
            query = cmd.ExecuteReader()


            sql = "select data_index as 'Index',time as Time"
            While query.Read()
                sql += ",sum(value*(1-abs(sign(if(strcmp(data_id,'" & _
                    query.GetString(0) & "'),1,0))))) as '" & query.GetString(0) & "'"
            End While
            sql += " from data_full" & _
                " where drive_id = " & drive_id & _
                " and logger_id = " & logger_id & _
                " group by data_index,time;"

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

    Private Sub execute_list_channels(ByVal logger_id As Integer, ByVal list As CheckedListBox)

        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim i As Integer
        Dim sql As String = ""

        Try

            ' Abrir la conexión a Sql  
            cn.Open()
            cmd.Connection = cn

            sql = "select distinct data_id from data where drive_id = " & drive_id & _
             " and logger_id = " & logger_id
            cmd.CommandTimeout = 1000000
            cmd.CommandText = sql
            query = cmd.ExecuteReader()
            list.Items.Clear()
            i = 0
            While query.Read()
                list.Items.Add(query.GetString(0))
                list.SetItemChecked(i, True)
                i += 1
            End While

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

    Private Sub delete_channel(ByVal logger_id As Integer, ByVal list As CheckedListBox)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim i As Integer
        Dim sql As String = ""

        Try
            If list.Items.Count <> 0 And list.CheckedItems.Count <> 0 Then
                If MsgBox("Are yo sure to delete the selected channels?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    ' Abrir la conexión a Sql  
                    cn.Open()
                    cmd.Connection = cn
                    For Each i In list.CheckedIndices
                        sql = "delete from data where logger_id = " & logger_id & _
                             " and drive_id = " & drive_id & _
                             " and data_id like '" & list.Items(i) & "';"
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                    Next

                    cn.Close()

                End If
            End If

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

    Private Sub Form_view_data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        show_loggers()
    End Sub
End Class