Public Class From_Conf_User
    Private rows As Integer

    Private Sub UserBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserBindingNavigatorSaveItem.Click
        Try
            Me.Validate()
            Me.UserBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.Ffe_databaseDataSet)
            Ffe_databaseDataSet.user.AcceptChanges()
            UserDataGridView.Sort(UserDataGridView.Columns.Item(0), _
                                      System.ComponentModel.ListSortDirection.Ascending)
            rows = UserDataGridView.Rows.Count
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub From_Conf_User_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Me.Ffe_databaseDataSet.HasChanges() Or rows <> UserDataGridView.Rows.Count Then
                If MsgBox("Do you want to save changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Me.Validate()
                    Me.UserBindingSource.EndEdit()
                    Me.UserTableAdapter.Update(Me.Ffe_databaseDataSet.user)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub From_Conf_User_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: esta línea de código carga datos en la tabla 'Ffe_databaseDataSet.user' Puede moverla o quitarla según sea necesario.
            Me.UserTableAdapter.Fill(Me.Ffe_databaseDataSet.user)
            UserDataGridView.Sort(UserDataGridView.Columns.Item(0), _
                                      System.ComponentModel.ListSortDirection.Ascending)
            rows = UserDataGridView.Rows.Count
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

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        Try
            If MsgBox("Are you sure you want to delete this information?", _
                      MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                UserBindingNavigator.Items(3).Visible = True
                UserBindingNavigator.Items(3).PerformClick()
                UserBindingNavigator.Items(3).Visible = False
        
                rows = UserDataGridView.Rows.Count
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BindingNavigatorAddNewItem_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BindingNavigatorAddNewItem.MouseUp
        sort_index()
        VornameTextBox.Focus()
    End Sub

    Private Sub sort_index()
        Try
            Dim current As Integer = 1
            For i = 1 To UserDataGridView.Rows.Count
                If UserDataGridView.Rows.Item(i - 1).Cells.Item(0).Value <> i Then
                    UserDataGridView.Rows.Item(UserDataGridView.Rows.Count - 1) _
                    .Cells.Item(0).Value = i
                    current = i
                    UserDataGridView.Sort(UserDataGridView.Columns.Item(0), _
                                          System.ComponentModel.ListSortDirection.Ascending)
                    UserDataGridView.CurrentCell = _
                    UserDataGridView.Rows.Item(current - 1).Cells.Item(1)
                    UserDataGridView.ClearSelection()
                    i = UserDataGridView.Rows.Count
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class