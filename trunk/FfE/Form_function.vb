Public Class Form_function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text <> "" Then
                procesing.Show()
                procesing.Focus()
                Application.DoEvents()
                Dim kms As New functions
                Label2.Text = kms.function_kms(TextBox1.Text) & " kms"
                procesing.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            procesing.Close()
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length <> 0 Then
            If Not IsNumeric(TextBox1.Text) Then
                TextBox1.Text = ""
            End If
        End If
    End Sub
End Class