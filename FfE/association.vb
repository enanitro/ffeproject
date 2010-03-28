Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class association
    Public logger As Integer
    Public measure() As Integer
    Public list As CheckedListBox

    Private Function search_measure(ByVal logger_id As Integer, ByVal sel As String, _
                                    ByVal name As String, ByVal find As String) As String
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sql As String = ""
        Dim res As String = ""

        Try

            ' Abrir la conexión a Sql  
            cn.Open()

            ' Pasar la consulta sql y la conexión al Sql Command   
            sql = "select " & sel & " from channel_name where logger_id = " & logger_id & _
                  " and " & find & " = '" & name & "';"
            cmd.Connection = cn
            cmd.CommandText = sql
            query = cmd.ExecuteReader()
            query.Read()
            If query.HasRows() Then res = query.GetString(0)

            cn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            search_measure = res
        End Try
    End Function

    Private Sub load_checkedlistbox()
        Dim name() As String
        Dim str, ch As String
        Try
            For Each i In list.CheckedIndices
                ch = list.Items(i)
                name = ch.split("->")
                str = ch
                If name.Length <= 1 Then
                    ch = search_measure(logger, "channel", ch, "name") & " -> " & ch
                End If
                CheckedListBox1.Items.Add(ch)
                list.Items.Item(i) = str
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub association_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_checkedlistbox()
    End Sub

    Private Sub insert_association(ByVal logger_id As Integer, ByVal ch As String, _
                                    ByVal name As String, ByVal id As Integer)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim sql As String = ""
        Dim res As String = ""

        Try

            ' Abrir la conexión a Sql  
            cn.Open()

            ' Pasar la consulta sql y la conexión al Sql Command   
            sql = "insert into channel_name values (" & logger & ",'" & ch & "','" & name & "'," & id & ");"
            cmd.Connection = cn
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

        Dim name() As String
        Dim str, s1, s2 As String
        Dim msg As String = "The following associations already exist:"
        Dim id As Integer
        Try
            For Each ch In CheckedListBox1.CheckedItems
                For i = 0 To list.CheckedIndices.Count - 1
                    If ch = list.CheckedItems.Item(i) Then
                        id = measure(list.CheckedIndices(i))
                        i = list.CheckedIndices.Count
                    End If
                Next
                name = ch.split(">")
                name(0) = name(0).TrimEnd("-").TrimEnd
                name(1) = name(1).Trim(">").TrimStart
                str = search_measure(logger, "name", name(0), "channel")
                If str <> name(1) Then
                    insert_association(logger, name(0), name(1), id)
                Else
                    msg += vbCrLf & ch
                End If
            Next
            If msg <> "The following associations already exist:" Then
                MsgBox(msg, MsgBoxStyle.Information)
            End If

            MsgBox("Associations created", MsgBoxStyle.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub delete_association(ByVal logger_id As Integer, ByVal ch As String, _
                                    ByVal name As String)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim sql As String = ""
        Dim res As String = ""

        Try

            ' Abrir la conexión a Sql  
            cn.Open()

            ' Pasar la consulta sql y la conexión al Sql Command   
            sql = "delete from channel_name where logger_id = " & logger & _
                  " and channel like '" & ch & "' and name like '" & name & "';"
            cmd.Connection = cn
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim name() As String
        Dim str As String = ""
        Try
            For Each ch In CheckedListBox1.CheckedItems
                name = ch.split("->")
                name(0) = name(0).TrimEnd
                name(1) = name(1).Trim(">").TrimStart
                str = search_measure(logger, "name", name(0), "channel")
                If str <> "" Then
                    delete_association(logger, name(0), name(1))
                End If
            Next
            MsgBox("Associations deleted", MsgBoxStyle.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        select_all_channels(CheckedListBox1, CheckBox1)
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        no_select_all_channels(CheckBox1, CheckedListBox1)
    End Sub
End Class