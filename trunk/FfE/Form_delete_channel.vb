Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_delete_channel
    Dim drive_id As Integer
    Public isClosed As Boolean = False

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal id As Integer)
        Me.new()
        drive_id = id
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
                list.SetItemChecked(i, False)
                i += 1
            End While

            cn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
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
        delete_channel(FfE_Main.id_gps, CheckedListBox2)
        execute_list_channels(FfE_Main.id_gps, CheckedListBox2)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        delete_channel(FfE_Main.id_graphtec, CheckedListBox1)
        execute_list_channels(FfE_Main.id_graphtec, CheckedListBox1)
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
        delete_channel(FfE_Main.id_lmg, CheckedListBox3)
        execute_list_channels(FfE_Main.id_lmg, CheckedListBox3)
    End Sub

    Private Sub CheckedListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox3.SelectedIndexChanged
        no_select_all_channels(CheckBox2, CheckedListBox3)
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        select_all_channels(CheckedListBox3, CheckBox2)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        delete_channel(FfE_Main.id_canbus, CheckedListBox4)
        execute_list_channels(FfE_Main.id_canbus, CheckedListBox4)
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

    Private Sub Form_delete_channel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        execute_list_channels(FfE_Main.id_gps, CheckedListBox2)
        execute_list_channels(FfE_Main.id_graphtec, CheckedListBox1)
        execute_list_channels(FfE_Main.id_lmg, CheckedListBox3)
        execute_list_channels(FfE_Main.id_canbus, CheckedListBox4)
    End Sub

    End Class