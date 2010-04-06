Public Class form_canbus_ids
    Private rows As Integer

    Private Sub Ids_canbusBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ids_canbusBindingNavigatorSaveItem.Click
        Try
            Me.Validate()
            Me.Ids_canbusBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.Ffe_databaseDataSet)
            Ffe_databaseDataSet.car.AcceptChanges()
            Ids_canbusDataGridView.Sort(Ids_canbusDataGridView.Columns.Item(0), _
                                System.ComponentModel.ListSortDirection.Ascending)
            rows = Ids_canbusDataGridView.Rows.Count
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub form_canbus_ids_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Me.Ffe_databaseDataSet.HasChanges() Or rows <> Ids_canbusDataGridView.Rows.Count Then
                If MsgBox("Do you want to save changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    Me.Validate()
                    Me.Ids_canbusBindingSource.EndEdit()
                    Me.Ids_canbusTableAdapter.Update(Me.Ffe_databaseDataSet.ids_canbus)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub form_canbus_ids_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'Ffe_databaseDataSet.ids_canbus' table. You can move, or remove it, as needed.
            Me.Ids_canbusTableAdapter.Fill(Me.Ffe_databaseDataSet.ids_canbus)
            Ids_canbusDataGridView.Sort(Ids_canbusDataGridView.Columns.Item(0), _
                                      System.ComponentModel.ListSortDirection.Ascending)
            rows = Ids_canbusDataGridView.Rows.Count
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        Try
            If MsgBox("Are you sure you want to delete this information?", _
                      MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Ids_canbusBindingNavigator.Items(3).Visible = True
                Ids_canbusBindingNavigator.Items(3).PerformClick()
                Ids_canbusBindingNavigator.Items(3).Visible = False

                rows = Ids_canbusDataGridView.Rows.Count
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
            For i = 1 To Ids_canbusDataGridView.Rows.Count
                If Ids_canbusDataGridView.Rows.Item(i - 1).Cells.Item(0).Value <> i Then
                    Ids_canbusDataGridView.Rows.Item(Ids_canbusDataGridView.Rows.Count - 1) _
                    .Cells.Item(0).Value = i
                    current = i
                    Ids_canbusDataGridView.Sort(Ids_canbusDataGridView.Columns.Item(0), _
                                          System.ComponentModel.ListSortDirection.Ascending)
                    Ids_canbusDataGridView.CurrentCell = _
                    Ids_canbusDataGridView.Rows.Item(current - 1).Cells.Item(1)
                    Ids_canbusDataGridView.ClearSelection()
                    i = Ids_canbusDataGridView.Rows.Count
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Hex_idTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dec_idTextBox.Text = HexToDec(Hex_idTextBox.Text)
    End Sub

    Private Function HexToDec(ByVal HexStr As String) As Double
        Dim mult As Double
        Dim DecNum As Double
        Dim ch As String
        mult = 1
        DecNum = 0

        Dim i As Integer
        For i = Len(HexStr) To 1 Step -1
            ch = Mid(HexStr, i, 1)
            If (ch >= "0") And (ch <= "9") Then
                DecNum = DecNum + (Val(ch) * mult)
            Else
                If (ch >= "A") And (ch <= "F") Then
                    DecNum = DecNum + ((Asc(ch) - Asc("A") + 10) * mult)
                Else
                    If (ch >= "a") And (ch <= "f") Then
                        DecNum = DecNum + ((Asc(ch) - Asc("a") + 10) * mult)
                    Else
                        HexToDec = 0
                        Exit Function
                    End If
                End If
            End If
            mult = mult * 16
        Next i
        HexToDec = DecNum
    End Function

End Class