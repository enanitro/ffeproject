﻿Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_restore_DB

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog.FileName = ""
        OpenFileDialog.ShowDialog()
        If My.Computer.FileSystem.FileExists(OpenFileDialog.FileName) Then
            Label1.Text = OpenFileDialog.FileName
        End If
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        'connection = connection.Remove(connection.IndexOf(connection.Split(";")(5)))
        Dim sql As String = ""
        Dim cn As New MySqlConnection(connection)
        Dim file As New System.IO.StreamReader(Label1.Text)
        Dim cmd As New MySqlCommand(sql, cn)
        Dim text As String = ""

        Try
            cn.Open()
            If Label1.Text <> "" Then
                text += file.ReadLine
                While text <> "exit;"
                    sql += text
                    If text = "commit;" Then
                        cmd.CommandText = sql
                        cmd.CommandTimeout = 1000
                        cmd.ExecuteNonQuery()
                        sql = ""
                    End If
                    text = file.ReadLine
                End While
                cmd.CommandText = "commit;"
                cmd.CommandTimeout = 1000
                cmd.ExecuteNonQuery()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            file.Close()
        End Try
    End Sub
End Class