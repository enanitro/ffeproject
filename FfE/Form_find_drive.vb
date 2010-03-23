Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_find_drive
    Private Sub Form_import_cvs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: esta línea de código carga datos en la tabla 'Ffe_databaseDataSet.drive_full' Puede moverla o quitarla según sea necesario.
            Me.Drive_fullTableAdapter.Fill(Me.Ffe_databaseDataSet.drive_full)

            add_combobox_items()
            'add_data_datagridview()
            check_combobox()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'actualiza la busqueda segun el filtrado de los datos
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim query As String = ""
            query = analyze_query(query, ComboBox1, "status")
            query = analyze_query(query, ComboBox2, "climate")
            query = analyze_query(query, ComboBox3, "drive_type")
            query = analyze_query(query, ComboBox4, "car")
            query = analyze_query(query, ComboBox5, "usage_type")
            query = analyze_query(query, ComboBox6, "importer")
            query = analyze_query(query, ComboBox7, "driver")
            query = analyze_query_date1(query, DateTimePicker1, "date")
            query = analyze_query_date2(query, DateTimePicker2, "date")
            Drive_fullBindingSource.Filter = query
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function analyze_query(ByVal query As String, ByVal value As ComboBox, ByVal field As String) As String
        If value.Enabled Then
            If query <> "" Then query += " AND "
            query += field & " = " & "'" & value.Text & "'"
        End If
        analyze_query = query
    End Function

    Function analyze_query_date1(ByVal query As String, ByVal value As DateTimePicker, ByVal field As String) As String
        If value.Enabled Then
            If query <> "" Then query += " AND "
            query += field & " >= " & "'" & value.Text & "'"
        End If
        analyze_query_date1 = query
    End Function

    Function analyze_query_date2(ByVal query As String, ByVal value As DateTimePicker, ByVal field As String) As String
        If value.Enabled Then
            If query <> "" Then query += " AND "
            query += field & " <= " & "'" & value.Text & "'"
        End If
        analyze_query_date2 = query
    End Function

    'añade los items a los combobox
    Private Sub add_combobox_items()
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        load_combobox(ComboBox1, "select distinct status from drive_full", connection)
        load_combobox(ComboBox2, "select distinct climate from drive_full", connection)
        load_combobox(ComboBox3, "select distinct drive_type from drive_full", connection)
        load_combobox(ComboBox4, "select distinct car from drive_full", connection)
        load_combobox(ComboBox5, "select distinct usage_type from drive_full", connection)
        load_combobox(ComboBox7, "select distinct driver from drive_full", connection)
        load_combobox(ComboBox6, "select distinct importer from drive_full", connection)
        ComboBox1.Text = ""
    End Sub

    'cargar datos en un combobox
    Private Sub load_combobox(ByVal ComboBox As ComboBox, ByVal sql As String, ByVal cs As String)

        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(cs)

        Try

            ' Abrir la conexión a Sql  
            cn.Open()

            ' Pasar la consulta sql y la conexión al Sql Command   
            Dim cmd As New MySqlCommand(sql, cn)

            ' Inicializar un nuevo SqlDataAdapter   
            Dim da As New MySqlDataAdapter(cmd)

            'Crear y Llenar un Dataset  
            Dim ds As New DataSet
            da.Fill(ds)

            ' asignar el DataSource al combobox  
            ComboBox.DataSource = ds.Tables(0)

            ' Asignar el campo a la propiedad DisplayMember del combo   
            ComboBox.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    'enable = false 
    Private Sub enable_checkbox(ByVal value As Boolean)
        CheckBox1.Enabled = value
        CheckBox2.Enabled = value
        CheckBox3.Enabled = value
        CheckBox4.Enabled = value
        CheckBox5.Enabled = value
        CheckBox6.Enabled = value
        CheckBox7.Enabled = value
        DateTimePicker1.Enabled = value
        DateTimePicker2.Enabled = value
    End Sub

    'desactiva los combobox
    Private Sub check_combobox()
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        CheckBox10.Checked = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        ComboBox1.Enabled = CheckBox1.Checked
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        ComboBox2.Enabled = CheckBox2.Checked
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        ComboBox4.Enabled = CheckBox4.Checked
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        ComboBox3.Enabled = CheckBox3.Checked
    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        ComboBox6.Enabled = CheckBox6.Checked
    End Sub

    Private Sub CheckBox7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox7.CheckedChanged
        ComboBox7.Enabled = CheckBox7.Checked
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged
        ComboBox5.Enabled = CheckBox5.Checked
    End Sub

    Private Sub Drive_fullDataGridView_MouseDoubleClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Drive_fullDataGridView.MouseDoubleClick
        Me.Close()
    End Sub

    Private Sub CheckBox8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox8.CheckedChanged
        DateTimePicker1.Enabled = CheckBox8.Checked
    End Sub

    Private Sub CheckBox10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox10.CheckedChanged
        DateTimePicker2.Enabled = CheckBox10.Checked
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If DateTimePicker2.Enabled And DateTimePicker2.Value < DateTimePicker1.Value Then
            MsgBox("Start date should be less than final date", MsgBoxStyle.Information)
            DateTimePicker1.Value = DateTimePicker2.Value
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        If DateTimePicker1.Enabled And DateTimePicker2.Value < DateTimePicker1.Value Then
            MsgBox("Start date should be less than or equal to end date", MsgBoxStyle.Information)
            DateTimePicker2.Value = DateTimePicker1.Value
        End If
    End Sub
End Class