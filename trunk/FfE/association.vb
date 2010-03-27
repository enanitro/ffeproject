Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class association
    Public logger As Integer
    Public measure() As Integer
    Public list As CheckedListBox
    Public ids() As Integer
    
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
        Try
            For Each i In list.CheckedIndices
                ids.Aggregate(i)
            Next

            For Each ch In list.CheckedItems
                name = ch.split("->")
                If name.Length = 0 Then
                    ch = search_measure(logger, "channel", ch, "name") & " -> " & ch
                End If
                CheckedListBox1.Items.Add(ch)
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
        Dim i As Integer
        Try
            For Each ch In CheckedListBox1.CheckedItems
                name = ch.split("->")
                name(0) = name(0).TrimEnd
                name(1) = name(1).Trim(">").TrimStart
                insert_association(logger, name(0), name(1), i)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class