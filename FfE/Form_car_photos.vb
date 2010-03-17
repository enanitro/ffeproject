Public Class Form_car_photos
    Public car As Integer

    Private Sub PhotosBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PhotosBindingNavigatorSaveItem.Click
        Try
            Me.Validate()
            Me.PhotosBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.Ffe_databaseDataSet)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form_car_photos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Me.Ffe_databaseDataSet.HasChanges() Then
                If MsgBox("Do you want to save changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Me.Validate()
                    Me.PhotosBindingSource.EndEdit()
                    Me.TableAdapterManager.UpdateAll(Me.Ffe_databaseDataSet)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form_car_photos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: esta línea de código carga datos en la tabla 'Ffe_databaseDataSet.photos' Puede moverla o quitarla según sea necesario.
            Me.PhotosTableAdapter.Fill(Me.Ffe_databaseDataSet.photos)
            Me.PhotosBindingSource.Filter = "car_id = " & car
            Car_idTextBox.Text = car
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BindingNavigatorAddNewItem_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BindingNavigatorAddNewItem.MouseUp
        OpenFileDialog.Filter() = "Image Files(*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png|All files (*.*)|*.* "
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog.FileName)
            PathTextBox.Text = OpenFileDialog.FileName
        End If
        Car_idTextBox.Text = car
    End Sub

End Class