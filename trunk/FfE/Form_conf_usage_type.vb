Public Class Form_conf_usage_type
    Private rows As Integer

    Private Sub Usage_typeBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Usage_typeBindingNavigatorSaveItem.Click
        Try
            Me.Validate()
            Me.Usage_typeBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.Ffe_databaseDataSet)
            Ffe_databaseDataSet.usage_type.AcceptChanges()
            Usage_typeDataGridView.Sort(Usage_typeDataGridView.Columns.Item(0), _
                                                      System.ComponentModel.ListSortDirection.Ascending)
            rows = Usage_typeDataGridView.Rows.Count
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form_conf_usage_type_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Me.Ffe_databaseDataSet.HasChanges() Or rows <> Usage_typeDataGridView.Rows.Count Then
                If MsgBox("Do you want to save changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Me.Validate()
                    Me.Usage_typeBindingSource.EndEdit()
                    Me.Usage_typeTableAdapter.Update(Me.Ffe_databaseDataSet.usage_type)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form_conf_usage_type_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: esta línea de código carga datos en la tabla 'Ffe_databaseDataSet.usage_type' Puede moverla o quitarla según sea necesario.
            Me.Usage_typeTableAdapter.Fill(Me.Ffe_databaseDataSet.usage_type)
            Usage_typeDataGridView.Sort(Usage_typeDataGridView.Columns.Item(0), _
                                          System.ComponentModel.ListSortDirection.Ascending)
            rows = Usage_typeDataGridView.Rows.Count
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        Try
            If MsgBox("Are you sure you want to delete this information?", _
                      MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Usage_typeBindingNavigator.Items(3).Visible = True
                Usage_typeBindingNavigator.Items(3).PerformClick()
                Usage_typeBindingNavigator.Items(3).Visible = False

                rows = Usage_typeDataGridView.Rows.Count
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
            For i = 1 To Usage_typeDataGridView.Rows.Count
                If Usage_typeDataGridView.Rows.Item(i - 1).Cells.Item(0).Value <> i Then
                    Usage_typeDataGridView.Rows.Item(Usage_typeDataGridView.Rows.Count - 1) _
                    .Cells.Item(0).Value = i
                    current = i
                    Usage_typeDataGridView.Sort(Usage_typeDataGridView.Columns.Item(0), _
                                          System.ComponentModel.ListSortDirection.Ascending)
                    Usage_typeDataGridView.ClearSelection()
                    Usage_typeDataGridView.CurrentCell = _
                    Usage_typeDataGridView.Rows.Item(current - 1).Cells.Item(1)
                    Usage_typeDataGridView.ClearSelection()
                    i = Usage_typeDataGridView.Rows.Count
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Validate()
            Me.Usage_typeBindingSource.EndEdit()
            Me.Usage_typeTableAdapter.Update(Me.Ffe_databaseDataSet.usage_type)
            Usage_typeDataGridView.Sort(Usage_typeDataGridView.Columns.Item(0), _
                                      System.ComponentModel.ListSortDirection.Ascending)
            rows = Usage_typeDataGridView.Rows.Count
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class