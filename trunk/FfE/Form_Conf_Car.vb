Public Class Form_Conf_Car
    Private rows As Integer

    Private Sub CarBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarBindingNavigatorSaveItem.Click
        Try
            Me.Validate()
            Me.CarBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.Ffe_databaseDataSet)
            Ffe_databaseDataSet.car.AcceptChanges()
            CarDataGridView.Sort(CarDataGridView.Columns.Item(0), _
                                System.ComponentModel.ListSortDirection.Ascending)
            rows = CarDataGridView.Rows.Count
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form_Conf_Car_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Me.Ffe_databaseDataSet.HasChanges() Or rows <> CarDataGridView.Rows.Count Then
                If MsgBox("Do you want to save changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    Me.Validate()
                    Me.CarBindingSource.EndEdit()
                    Me.CarTableAdapter.Update(Me.Ffe_databaseDataSet.car)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form_Conf_Car_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: esta línea de código carga datos en la tabla 'Ffe_databaseDataSet.car' Puede moverla o quitarla según sea necesario.
            Me.CarTableAdapter.Fill(Me.Ffe_databaseDataSet.car)
            CarDataGridView.Sort(CarDataGridView.Columns.Item(0), _
                                      System.ComponentModel.ListSortDirection.Ascending)
            rows = CarDataGridView.Rows.Count
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PhotoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PhotoPictureBox.Click
        OpenFileDialog.Filter() = "Image Files(*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png|All files (*.*)|*.* "
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PhotoPictureBox.Image = Image.FromFile(OpenFileDialog.FileName)
        End If
    End Sub

    Private Sub CarDataGridView_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CarDataGridView.MouseDoubleClick
        Try
            If Me.Ffe_databaseDataSet.HasChanges() Or rows <> CarDataGridView.Rows.Count Then
                Me.Validate()
                Me.CarBindingSource.EndEdit()
                Me.CarTableAdapter.Update(Me.Ffe_databaseDataSet.car)
                'Me.CarTableAdapter.Fill(Me.Ffe_databaseDataSet.car)
            End If

            Dim form_photo As New Form_car_photos
            form_photo.car = CarDataGridView.CurrentRow.Cells.Item(0).Value
            form_photo.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        Try
            If MsgBox("Are you sure you want to delete this information?", _
                      MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                CarBindingNavigator.Items(3).Visible = True
                CarBindingNavigator.Items(3).PerformClick()
                CarBindingNavigator.Items(3).Visible = False
        
                rows = CarDataGridView.Rows.Count
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BindingNavigatorAddNewItem_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BindingNavigatorAddNewItem.MouseUp
        sort_index()
        NameTextBox.Focus()
    End Sub

    Private Sub sort_index()
        Try
            Dim current As Integer = 1
            For i = 1 To CarDataGridView.Rows.Count
                If CarDataGridView.Rows.Item(i - 1).Cells.Item(0).Value <> i Then
                    CarDataGridView.Rows.Item(CarDataGridView.Rows.Count - 1) _
                    .Cells.Item(0).Value = i
                    current = i
                    CarDataGridView.Sort(CarDataGridView.Columns.Item(0), _
                                          System.ComponentModel.ListSortDirection.Ascending)
                    CarDataGridView.CurrentCell = _
                    CarDataGridView.Rows.Item(current - 1).Cells.Item(1)
                    CarDataGridView.ClearSelection()
                    i = CarDataGridView.Rows.Count
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
