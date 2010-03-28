Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_measure

    Private Sub Form_measure_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: esta línea de código carga datos en la tabla 'Ffe_databaseDataSet.measure' Puede moverla o quitarla según sea necesario.
            Me.MeasureTableAdapter.Fill(Me.Ffe_databaseDataSet.measure)
            add_combobox_items()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'añade los items a los combobox
    Private Sub add_combobox_items()
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        load_combobox(ComboBox1, "select distinct measure_id from measure", connection)
        load_combobox(ComboBox2, "select distinct name from measure", connection)
        load_combobox(ComboBox3, "select distinct timestep from measure", connection)
        load_combobox(ComboBox4, "select distinct unit from measure", connection)
      
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

    'actualiza la busqueda segun el filtrado de los datos
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If CheckBox1.Checked Then
                MeasureBindingSource.Filter = "measure_id = " & ComboBox1.Text
            Else
                Dim query As String = ""
                query = analyze_query(query, ComboBox2, "name")
                query = analyze_query(query, ComboBox3, "timestep")
                query = analyze_query(query, ComboBox4, "unit")
                MeasureBindingSource.Filter = query
            End If
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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ComboBox1.Enabled = CheckBox1.CheckState
        check_combobox()
        enable_checkbox(Not CheckBox1.Checked)
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ComboBox2.Enabled = CheckBox2.Checked
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ComboBox3.Enabled = CheckBox3.Checked
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ComboBox4.Enabled = CheckBox4.Checked
    End Sub
    Private Sub enable_checkbox(ByVal value As Boolean)
        CheckBox2.Enabled = value
        CheckBox3.Enabled = value
        CheckBox4.Enabled = value
    End Sub

    'desactiva los combobox
    Private Sub check_combobox()
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
    End Sub

    Private Sub MeasureDataGridView_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MeasureDataGridView.MouseDoubleClick
        If MeasureDataGridView.RowCount > 0 Then
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim form_conf_measure As New Form_Conf_Measure
            form_conf_measure.MeasureBindingNavigator.Items(2).Visible = False
            form_conf_measure.ShowDialog()
            form_conf_measure.MeasureBindingNavigator.Items(2).Visible = True
            Me.MeasureTableAdapter.Fill(Me.Ffe_databaseDataSet.measure)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class