Public Class Form_function

    'calculate
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text <> "" Then
                'show "data processing" while the computer executes the function
                procesing.Show()
                procesing.Focus()
                Application.DoEvents()
                'create a New class "functions" to work
                Dim kms As New functions
                'call "functions_kms" and write result
                Label2.Text = kms.function_kms(TextBox1.Text) & " kms"
                'close "data processing"
                procesing.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'close "data processing" 
            procesing.Close()
        End Try
    End Sub

    'drive ID must be a numeric value
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length <> 0 Then
            If Not IsNumeric(TextBox1.Text) Then
                TextBox1.Text = ""
            End If
        End If
    End Sub

End Class