Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_restore_DB
    Dim db As String

    Private Sub Form_restore_DB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        write_database()
        clean_labels()
    End Sub

    Private Function read_lines() As Integer
        Dim file As New System.IO.StreamReader(Label1.Text)
        Dim lines As Integer = 0
        Dim cad As String
        Try
            procesing.Show()
            procesing.Focus()
            cad = file.ReadLine
            While cad <> "exit"
                lines += 1
                cad = file.ReadLine
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            procesing.Close()
            read_lines = lines
        End Try
    End Function

    Private Sub write_database()
        Dim cadena As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim fields() As String
        fields = cadena.Split(";")
        db = fields(5).Split("=")(1)
        GroupBox1.Text = db
    End Sub

    Private Sub clean_labels()
        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""
        Label4.Text = ""
        ProgressBar1.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog.FileName = ""
        OpenFileDialog.ShowDialog()
        If My.Computer.FileSystem.FileExists(OpenFileDialog.FileName) Then
            Label1.Text = OpenFileDialog.FileName
        End If
    End Sub

    Private Sub restore_DB()
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim sql As String = ""
        Dim cn As New MySqlConnection(connection)
        Dim trs As MySqlTransaction
        Dim cmd As New MySqlCommand(sql, cn)
        Dim file As New System.IO.StreamReader(Label1.Text)
        Dim text As String = ""
        Dim count As Integer = 0
        Try
            If Label1.Text <> "" Then
                count = read_lines()
                config_progressbar(ProgressBar1, count)
                count = 0
                cn.Open()
                'trs = cn.BeginTransaction
                'cmd.Transaction = trs
                text = file.ReadLine()
                While text <> "exit"
                    count += 1
                    progressbar(count, ProgressBar1, Label4.Text)
                    Application.DoEvents()
                    If text <> "" Then
                        If text(0) <> "-" Then
                            sql += text
                            If text(text.Length - 1) = ";" Then
                                cmd.CommandText = sql
                                cmd.CommandTimeout = 1000
                                cmd.ExecuteNonQuery()
                                Application.DoEvents()
                                sql = ""
                            End If
                        Else
                            Label3.Text = text.Substring(2)
                            Application.DoEvents()
                        End If
                    End If
                    text = file.ReadLine
                End While
                'trs.Commit()
            End If

            MsgBox("Restore completed successfully", MsgBoxStyle.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            file.Close()
            cn.Close()
        End Try
    End Sub

    'configuracion del progressbar y labels que le acompañan
    Private Sub config_progressbar(ByRef bar As ProgressBar, ByVal max As Double)
        bar.Visible = True
        bar.Minimum = 0
        bar.Maximum = max
    End Sub

    'controla el objeto progressbar
    Private Sub progressbar(ByVal val As Integer, ByRef bar As ProgressBar, ByRef percent As String)
        bar.Value = val
        percent = CLng((bar.Value * 100) / bar.Maximum) & " %"
        Application.DoEvents()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        restore_DB()
        clean_labels()
    End Sub
End Class