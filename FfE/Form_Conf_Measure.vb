Public Class Form_Conf_Measure
    Private rows As Integer

    Private Sub MeasureBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MeasureBindingNavigatorSaveItem.Click
        Try
            Me.Validate()
            Me.MeasureBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.Ffe_databaseDataSet)
            Ffe_databaseDataSet.measure.AcceptChanges()
            MeasureDataGridView.Sort(MeasureDataGridView.Columns.Item(0), _
                                      System.ComponentModel.ListSortDirection.Ascending)
            rows = MeasureDataGridView.Rows.Count
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub From_Conf_Measure_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Me.Ffe_databaseDataSet.HasChanges() Or rows <> MeasureDataGridView.Rows.Count Then
                If MsgBox("Do you want to save changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Me.Validate()
                    Me.MeasureBindingSource.EndEdit()
                    Me.MeasureTableAdapter.Update(Me.Ffe_databaseDataSet.measure)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form_Conf_Measure_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Ffe_databaseDataSet.measure' Puede moverla o quitarla según sea necesario.
        Try
            Me.MeasureTableAdapter.Fill(Me.Ffe_databaseDataSet.measure)
            MeasureDataGridView.Sort(MeasureDataGridView.Columns.Item(0), _
                                      System.ComponentModel.ListSortDirection.Ascending)
            rows = MeasureDataGridView.Rows.Count
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        Try
            If MsgBox("Are you sure you want to delete this information?", _
                      MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                MeasureBindingNavigator.Items(3).Visible = True
                MeasureBindingNavigator.Items(3).PerformClick()
                MeasureBindingNavigator.Items(3).Visible = False

                rows = MeasureDataGridView.Rows.Count
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
            For i = 1 To MeasureDataGridView.Rows.Count
                If MeasureDataGridView.Rows.Item(i - 1).Cells.Item(0).Value <> i Then
                    MeasureDataGridView.Rows.Item(MeasureDataGridView.Rows.Count - 1) _
                    .Cells.Item(0).Value = i
                    current = i
                    MeasureDataGridView.Sort(MeasureDataGridView.Columns.Item(0), _
                                          System.ComponentModel.ListSortDirection.Ascending)
                    MeasureDataGridView.CurrentCell = _
                    MeasureDataGridView.Rows.Item(current - 1).Cells.Item(1)
                    MeasureDataGridView.ClearSelection()
                    i = MeasureDataGridView.Rows.Count
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class