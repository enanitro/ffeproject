﻿Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_view_data
    Dim drive_id As Integer
    Public isClosed As Boolean = False
    Dim sqls(0) As String

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
        show_data(DataGridView2, FfE_Main.id_lmg)
        'show_data_canbus(DataGridView3, FfE_Main.id_canbus)
        show_data(DataGridView3, FfE_Main.id_canbus)
        show_einspritzung_channel(DataGridView4, FfE_Main.id_canbus)
        check_grid_canbus()
        check_grids_canbus_same_index()

    End Sub

    Private Sub format_grid(ByRef grid As DataGridView)
        grid.ReadOnly = True
        grid.AllowUserToAddRows = False
        grid.AllowUserToDeleteRows = False
        grid.Columns(0).Width = 60
        grid.Columns(1).Width = 60
        Dim ch As String
        For i = 2 To grid.Columns.Count - 1
            grid.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            grid.Columns(i).HeaderCell.Value = grid.Columns(i).HeaderCell.Value.ToString.Replace("Â", "") _
            .Replace("Ã¶", "ö").Replace("Ã¼", "ü").Replace("Ã¤", "ä")
        Next
    End Sub

    Private Sub show_data(ByRef grid As DataGridView, ByVal logger_id As Integer)
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim sql As String = ""

        Try

            grid.DataSource = ""
            sql = execute_query_loggers(sql, logger_id)

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

    Private Sub show_data_canbus(ByRef grid As DataGridView, ByVal logger_id As Integer)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sql, res As String
        'Dim sqls(0) As String
        Dim i, j, count As Integer
        res = ""

        Try

            sql = "select distinct data_id from data_full where drive_id = " & drive_id & _
                " and logger_id = " & logger_id & " order by data_id"
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = sql
            cmd.CommandTimeout = 1000
            query = cmd.ExecuteReader

            count = 0
            grid.Rows.Clear()
            grid.Columns.Clear()
            While query.Read
                grid.Columns.Add("TIME", "TIME")
                grid.Columns.Add(query.GetString(0), query.GetString(0))
                Array.Resize(sqls, count + 1)
                sqls(count) = "select time,value from data where drive_id = " & drive_id & _
                      " and logger_id = " & logger_id & " and data_id like '" & query.GetString(0) & "'"
                count += 1
            End While
            cn.Close()

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
                        grid(i * 2, j).Value = query.GetString(0)
                        grid(i * 2 + 1, j).Value = query.GetString(1)
                        j += 1
                    End While
                End If
                cn.Close()
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Close()
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

    Private Function execute_query_loggers(ByRef sql As String, ByVal logger_id As Integer) As String

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
             " and logger_id = " & logger_id & " order by cast(substring_index(data_id,'.',1) as unsigned) asc"
            cmd.CommandTimeout = 1000000
            cmd.CommandText = sql
            query = cmd.ExecuteReader()

            Dim ch As String
            sql = "select data_index as 'Index',time as Time"
            While query.Read()
                sql += ",sum(value*(1-abs(sign(if(strcmp(data_id,'" & _
                    query.GetString(0) & "'),1,0))))) as '" & query.GetString(0) & "'"
            End While
            sql += " from data_full" & _
                " where drive_id = " & drive_id & _
                " and logger_id = " & logger_id & _
                " group by data_index,time" & _
                " having data_index > 0"

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
            execute_query_loggers = sql
        End Try
    End Function

    Private Sub show_einspritzung_channel(ByRef grid As DataGridView, ByVal logger_id As Integer)

        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim sql As String = ""

        Try

            grid.DataSource = ""
            sql = "select data_index*(-1) as 'Index', cast(concat(time,'.',milsec) as char) as 'Time', value as 'Einspritzung'" & _
                  " from data where drive_id = " & drive_id & _
                  " and logger_id = " & logger_id & " and data_index < 0 order by data_index*(-1)"

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

    Private Sub check_grid_canbus()

        For i = 0 To DataGridView3.ColumnCount - 1
            If DataGridView3.Columns(i).HeaderCell.Value Like "*Einspritzung*" Then
                DataGridView3.Columns(i).Visible = False
            End If
        Next

    End Sub

    Private Sub check_grids_canbus_same_index()
        Dim index_ini As Integer

        If DataGridView3.RowCount > DataGridView4.RowCount Then

            index_ini = DataGridView3.RowCount - DataGridView4.RowCount

            ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
            Dim dt As DataTable = DirectCast(DataGridView4.DataSource, DataTable)
            For i = 0 To index_ini - 1
                ' Añadimos una nueva fila
                Dim row As DataRow = dt.NewRow
                ' Cumplimentamos los datos de los campos
                For j = 0 To DataGridView4.ColumnCount - 1
                    row.Item(j) = 0
                Next
                ' Añadimos la fila a la colección de filas del objeto DataTable.
                dt.Rows.Add(row)
            Next


        Else

            index_ini = DataGridView4.RowCount - DataGridView3.RowCount

            ' Referenciamos el objeto DataTable enlazado con el control DataGridView.
            Dim dt As DataTable = DirectCast(DataGridView3.DataSource, DataTable)
            For i = 0 To index_ini - 1
                ' Añadimos una nueva fila
                Dim row As DataRow = dt.NewRow
                ' Cumplimentamos los datos de los campos
                For j = 0 To DataGridView3.ColumnCount - 1
                    row.Item(j) = 0
                Next
                ' Añadimos la fila a la colección de filas del objeto DataTable.
                dt.Rows.Add(row)
            Next

        End If

    End Sub

    Private Sub execute_list_channels(ByVal logger_id As Integer, ByVal list As CheckedListBox, ByVal check As CheckBox)

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
                list.SetItemChecked(i, False)
                i += 1
            End While
            check.Checked = False

            cn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Function delete_channel(ByVal logger_id As Integer, ByVal list As CheckedListBox) As Boolean
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim i As Integer
        Dim sql As String = ""
        Dim res As Boolean = False

        Try
            If list.Items.Count <> 0 And list.CheckedItems.Count <> 0 Then
                If MsgBox("Are yo sure to delete the selected channels?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    procesing.Show()
                    Application.DoEvents()

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
                    procesing.Close()
                    res = True
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
            procesing.Close()
            delete_channel = res
        End Try
    End Function

    Private Sub Form_view_data_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        isClosed = True
    End Sub

    Private Sub Form_view_data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        show_loggers()
        channel_load()
    End Sub

    Private Sub channel_load()
        execute_list_channels(FfE_Main.id_gps, CheckedListBox2, CheckBox9)
        execute_list_channels(FfE_Main.id_graphtec, CheckedListBox1, CheckBox1)
        execute_list_channels(FfE_Main.id_lmg, CheckedListBox3, CheckBox2)
        execute_list_channels(FfE_Main.id_canbus, CheckedListBox4, CheckBox3)
    End Sub

    Private Sub select_all_channels(ByRef list As CheckedListBox, ByVal check As CheckBox)
        If check.CheckState <> CheckState.Indeterminate Then
            For i = 0 To list.Items.Count - 1
                list.SetItemChecked(i, check.CheckState)
            Next
        End If
    End Sub

    Private Sub no_select_all_channels(ByRef check As CheckBox, ByVal list As CheckedListBox)
        If list.CheckedItems.Count = list.Items.Count Then
            check.CheckState = CheckState.Checked
        Else
            If list.CheckedItems.Count = 0 Then
                check.CheckState = CheckState.Unchecked
            Else
                check.CheckState = CheckState.Indeterminate
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If delete_channel(FfE_Main.id_graphtec, CheckedListBox1) Then
            procesing.Show()
            Application.DoEvents()
            show_data(DataGridView, FfE_Main.id_graphtec)
            execute_list_channels(FfE_Main.id_graphtec, CheckedListBox1, CheckBox9)
            procesing.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If delete_channel(FfE_Main.id_gps, CheckedListBox2) Then
            procesing.Show()
            Application.DoEvents()
            show_data(DataGridView1, FfE_Main.id_gps)
            execute_list_channels(FfE_Main.id_gps, CheckedListBox2, CheckBox1)
            procesing.Close()
        End If
    End Sub

    Private Sub CheckBox9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox9.CheckedChanged
        select_all_channels(CheckedListBox1, CheckBox9)
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        no_select_all_channels(CheckBox9, CheckedListBox1)
    End Sub

    Private Sub CheckedListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox2.SelectedIndexChanged
        no_select_all_channels(CheckBox1, CheckedListBox2)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        select_all_channels(CheckedListBox2, CheckBox1)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If delete_channel(FfE_Main.id_lmg, CheckedListBox3) Then
            procesing.Show()
            Application.DoEvents()
            show_data(DataGridView2, FfE_Main.id_lmg)
            execute_list_channels(FfE_Main.id_lmg, CheckedListBox3, CheckBox2)
            procesing.Close()
        End If
    End Sub

    Private Sub CheckedListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox3.SelectedIndexChanged
        no_select_all_channels(CheckBox2, CheckedListBox3)
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        select_all_channels(CheckedListBox3, CheckBox2)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If delete_channel(FfE_Main.id_canbus, CheckedListBox4) Then
            procesing.Show()
            Application.DoEvents()
            'show_data_canbus(DataGridView3, FfE_Main.id_canbus)
            show_data(DataGridView3, FfE_Main.id_canbus)
            show_einspritzung_channel(DataGridView4, FfE_Main.id_canbus)
            execute_list_channels(FfE_Main.id_canbus, CheckedListBox4, CheckBox3)
            procesing.Close()
        End If
    End Sub

    Private Sub CheckedListBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox4.SelectedIndexChanged
        no_select_all_channels(CheckBox3, CheckedListBox4)
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        select_all_channels(CheckedListBox4, CheckBox3)
    End Sub

    Private Sub Form_delete_channel_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        isClosed = True
    End Sub

End Class