Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class logger
    Public unit As String
    Function logger_dialog(ByVal filedialog As OpenFileDialog, ByRef list As CheckedListBox, ByVal id As Integer, _
                             ByRef text As TextBox, ByRef long_file As Integer, ByRef measure() As Integer) As String
        filedialog.FileName = ""
        filedialog.ShowDialog()
        If My.Computer.FileSystem.FileExists(filedialog.FileName) Then
            analizar_CVS(filedialog.FileName, id, text, list, long_file, measure)
        End If
        If list.Items.Count <> 0 Then
            list.Visible = True
            text.Visible = True
            logger_dialog = filedialog.FileName
        Else
            logger_dialog = ""
        End If
    End Function


    'analiza la cabecera del archivo
    Public Sub analizar_CVS(ByVal path As String, ByVal id As String, ByRef text As TextBox, _
                            ByRef list As CheckedListBox, ByRef long_file As String, ByRef measure() As Integer)
        If id = FfE_Main.id_graphtec Then
            analyze_logger_graphtec_gl800(path, list, text, id, long_file, measure)
        Else
            If id = FfE_Main.id_gps Then
                analyze_logger_columbus_gps(path, list, text, id, long_file, measure)
            Else
                If id = FfE_Main.id_fluke Then
                    analyze_logger_fluke(path, list, text, id, long_file, measure)
                End If
            End If
        End If
    End Sub

    'analisis del archivo cvs del logger graphtec gl800
    Public Sub analyze_logger_graphtec_gl800(ByVal path As String, ByRef list As CheckedListBox, ByRef text As TextBox, _
                                              ByVal id As Integer, ByRef long_file As String, ByRef measure() As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea1, linea2, name As String
        Dim datos1(), datos2() As String
        Dim data As New ffe_databaseDataSet.dataDataTable
        Dim i, j, count As Integer

        Try
            'limpiar
            list.Items.Clear()
            text.Text = ""

            'comprobar si es un archivo del logger graphtec gl800
            linea1 = fichero.ReadLine
            datos1 = linea1.Split(",")
            If datos1(1) <> """" & "GRAPHTEC Corporation" & """" Then
                MsgBox("error", MsgBoxStyle.Critical)
                Exit Sub
            End If
            text.Text = datos1(1) + vbCrLf

            'leer cabecera y mostrarla por pantalla
            For i = 0 To 3
                linea1 = fichero.ReadLine
                datos1 = linea1.Split(",")
                text.Text += datos1(0) + ": "
                text.Text += datos1(1) + vbCrLf
                If i = 2 Then unit = datos1(1)
                If i = 3 Then count = datos1(1)
            Next

            For i = 0 To 2
                linea1 = fichero.ReadLine
                datos1 = linea1.Split(",")
                text.Text += datos1(0) + ": "
                text.Text += datos1(1) + " "
                text.Text += datos1(2) + vbCrLf
            Next

            linea1 = fichero.ReadLine
            linea1 = fichero.ReadLine

            'leer el numero de canales
            i = 0
            Do
                linea1 = fichero.ReadLine
                datos1 = linea1.Split(",")
                i = i + 1
            Loop Until datos1(0) = "Logic/Pulse"
            i = i - 1

            'crear los items para cada canal
            linea1 = fichero.ReadLine
            linea1 = fichero.ReadLine
            datos1 = linea1.Split(",")
            linea2 = fichero.ReadLine
            datos2 = linea2.Split(",")
            For j = 2 To i + 1
                datos2(j) = datos2(j).Trim("""")
                name = datos1(j) + " (" + datos2(j) + ")"
                list.Items.Add(name)
            Next
            Array.Resize(measure, list.Items.Count)

            'comprobar si el archivo es correcto
            long_file = -1
            Do
                linea1 = fichero.ReadLine
                long_file += 1
            Loop Until linea1 Is Nothing
            If long_file <> count Then
                MsgBox("Total data points found: " & long_file & vbCrLf & _
                       "The head file specifies " & count & " data points " & vbCrLf & _
                       "The file may be corrupt", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'analisis del archivo cvs del logger columbus GPS
    Public Sub analyze_logger_columbus_gps(ByVal path As String, ByRef list As CheckedListBox, ByRef text As TextBox, _
                                              ByVal id As Integer, ByRef long_file As String, ByRef measure() As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea1, linea2, name As String
        Dim datos1(), datos2() As String
        Dim stime, etime As String
        Dim interval As Integer = 0
        Dim i As Integer

        Try
            'leer cabecera, hacer comprobaciones, mostrarla por pantalla
            linea1 = fichero.ReadLine
            datos1 = linea1.Split(",")
            If datos1(0) <> "INDEX" Or datos1(datos1.Length - 1) <> "VOX" Or datos1.Length <> 15 Then
                MsgBox("error", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'introducir los canales en checklistbox
            For i = 4 To datos1.Length - 2
                name = "CH" & (i - 3) & " (" & datos1(i) & ")"
                list.Items.Add(name)
            Next
            Array.Resize(measure, list.Items.Count)

            linea1 = fichero.ReadLine
            datos1 = linea1.Split(",")

            'hora de comienzo
            stime = make_date(datos1(2)) & " " & make_time(datos1(3))

            'contamos el numero de registros
            i = 1
            Do
                linea2 = fichero.ReadLine
                If linea2 <> Nothing Then
                    datos2 = linea2.Split(",")
                    datos2.CopyTo(datos1, 0)
                    i += 1
                End If
            Loop Until linea2 Is Nothing

            'asigno la longitud real del archivo
            long_file = i

            'hora de finalizacion
            etime = make_date(datos1(2)) & " " & make_time(datos1(3))

            'calculo el intervalo aprox. de tiempo
            interval = DateDiff("s", FormatDateTime(stime), FormatDateTime(etime))
            interval = interval / i

            'escribo cabecera
            text.Text = "Columbus GPS" & vbCrLf & _
                        "Sampling interval: " & interval & "s" & vbCrLf & _
                        "Total data points: " & i & vbCrLf & _
                        "Start time: " & stime & vbCrLf & _
                        "End time: " & etime
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'analisis del archivo cvs del logger columbus GPS
    Public Sub analyze_logger_fluke(ByVal path As String, ByRef list As CheckedListBox, ByRef text As TextBox, _
                                    ByVal id As Integer, ByRef long_file As String, ByRef measure() As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea1, linea2, name As String
        Dim datos1(), datos2() As String
        Dim interval As Integer = 0
        Dim i As Integer

        Try
            'leer cabecera, hacer comprobaciones, mostrarla por pantalla
            linea1 = fichero.ReadLine
            datos1 = linea1.Split(";")
            If datos1(0) <> "PQ Log" Then
                MsgBox("error", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'leo cabecera
            text.Text = linea1 + vbCrLf
            linea1 = fichero.ReadLine
            datos1 = linea1.Split(";")
            text.Text += datos1(0) & ", " & datos1(1) + vbCrLf
            text.Text += datos1(2) + vbCrLf
            For i = 0 To 4
                linea1 = fichero.ReadLine
                datos1 = linea1.Split(";")
                text.Text += linea1 + vbCrLf
            Next
            linea1 = fichero.ReadLine
            datos1 = linea1.Split(";")
            datos2 = datos1(1).Split(":")
            text.Text += datos1(0) & ", " & datos2(0) + vbCrLf
            text.Text += datos2(1) & ", " & datos1(2) & ", " & datos1(3) + vbCrLf

            linea1 = fichero.ReadLine

            'leemos los canales y sus unidades
            linea1 = fichero.ReadLine
            datos1 = linea1.Split(";")
            linea2 = fichero.ReadLine
            datos2 = linea2.Split(";")

            'introducir los canales en checklistbox
            For i = 2 To datos1.Length - 1
                If datos2(i) <> "" Then
                    name = datos1(i) & " (" & datos2(i) & ")"
                Else
                    name = datos1(i)
                End If
                list.Items.Add(name)
            Next
            Array.Resize(measure, list.Items.Count)

            long_file = 0
            Do
                linea1 = fichero.ReadLine
                If linea1 <> Nothing Then long_file += 1
            Loop Until linea1 Is Nothing

            'escribo cabecera
            text.Text += "Total data points: " & long_file
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'inserta los datos del fichero en la tabla data (logger graphtec GL800)
    Public Sub insert_logger_graphtec_gl800(ByVal path As String, ByRef list As CheckedListBox, ByRef text As TextBox, _
                                    ByRef percent As Label, ByRef n_data As Label, ByRef bar As ProgressBar, _
                                    ByVal id_logger As Integer, ByVal id_drive As Integer, ByRef long_file As String, _
                                    ByVal measure() As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea, aux As String
        Dim datos() As String
        Dim num_lines As Integer = 0
        Dim clock As Integer = 1
        Dim value As Double

        Try
            'sumo el numero de canales + 14 lineas de datos que contiene la cabecera del logger graphtec gl800
            For i = 1 To list.Items.Count + 14
                linea = fichero.ReadLine
            Next

            config_progressbar(bar, long_file, list)

            Dim ins As New insert_Data
            ins.init_string()

            Do
                linea = fichero.ReadLine
                If linea <> Nothing Then
                    Application.DoEvents()
                    datos = linea.Split(",")
                    For i = 0 To list.CheckedIndices.Count - 1
                        num_lines += 1
                        clock += 1
                        'En caso de que el valor sea numerico
                        If IsNumeric(datos(list.CheckedIndices.Item(i) + 2)) Then
                            aux = "('" & list.CheckedItems.Item(i) & "'," & id_drive & "," & id_logger & "," _
                            & measure(list.CheckedIndices.Item(i)) & "," _
                            & "'" & FormatDateTime(datos(1), DateFormat.LongTime) & "'" & "," _
                            & datos(list.CheckedIndices.Item(i) + 2) & ")"
                            ins.set_string(aux)
                            progressbar(num_lines, bar, percent, n_data)
                        End If
                    Next
                    If clock > 1000 Then
                        ins.insert_into_string()
                        ins.init_string()
                        clock = 1
                    End If
                End If
            Loop Until linea Is Nothing

            ins.insert_into_string()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'inserta los datos del fichero en la tabla data (logger Columbus GPS)
    Public Sub insert_logger_columbus_gps(ByVal path As String, ByRef list As CheckedListBox, ByRef text As TextBox, _
                                    ByRef percent As Label, ByRef n_data As Label, ByRef bar As ProgressBar, _
                                    ByVal id_logger As Integer, ByVal id_drive As Integer, ByRef long_file As String, _
                                    ByVal measure() As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea, aux, val As String
        Dim datos() As String
        Dim num_lines As Integer = 0
        Dim clock As Integer = 1
        Dim value As Double

        Try
            'leo la primera linea que pertenece a la cabecera
            linea = fichero.ReadLine

            Dim ins As New insert_Data
            ins.init_string()
            clock = 0

            config_progressbar(bar, long_file, list)

            Do
                linea = fichero.ReadLine
                If linea <> Nothing Then
                    Application.DoEvents()
                    datos = linea.Split(",")

                    For i = 0 To list.CheckedIndices.Count - 1
                        num_lines += 1
                        clock += 1
                        'If IsNumeric(datos(list.CheckedIndices.Item(i) + 2)) Then
                        val = datos(list.CheckedIndices.Item(i) + 4) '.Replace(".", ",")
                        If val.Last = "N" Or val.Last = "E" Then
                            val = "+" & val
                            val = val.Remove(val.Count - 1)
                        ElseIf val.Last = "S" Or val.Last = "W" Then
                            val = "-" & val
                            val = val.Remove(val.Count - 1)
                            End
                        End If

                        'quitar valores NUL
                        If val(val.Count - 1) = Nothing Then
                            Do
                                val = val.Remove(val.Count - 1)
                            Loop Until val(val.Count - 1) <> Nothing
                        End If

                        aux = "('" & list.CheckedItems.Item(i) & "'," & id_drive & "," & id_logger & "," _
                        & measure(list.CheckedIndices.Item(i)) & "," _
                        & "'" & FormatDateTime(make_time(datos(3)), DateFormat.LongTime) & "'" & "," _
                        & val & ")"
                        ins.set_string(aux)
                    Next
                    If clock > 1000 Then
                        ins.insert_into_string()
                        ins.init_string()
                        clock = 1
                    End If
                    progressbar(num_lines, bar, percent, n_data)
                End If
            Loop Until linea Is Nothing

            ins.insert_into_string()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'inserta los datos del fichero en la tabla data (logger Fluke)
    Public Sub insert_logger_fluke(ByVal path As String, ByRef list As CheckedListBox, ByRef text As TextBox, _
                                    ByRef percent As Label, ByRef n_data As Label, ByRef bar As ProgressBar, _
                                    ByVal id_logger As Integer, ByVal id_drive As Integer, ByRef long_file As String, _
                                    ByVal measure() As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea, aux, val As String
        Dim datos() As String
        Dim num_lines As Integer = 0
        Dim clock As Integer = 1
        Dim value As Double

        Try
            'leo la primera linea que pertenece a la cabecera
            For i = 0 To 10
                linea = fichero.ReadLine
            Next

            Dim ins As New insert_Data
            ins.init_string()
            clock = 0

            config_progressbar(bar, long_file, list)

            Do
                linea = fichero.ReadLine
                If linea <> Nothing Then
                    Application.DoEvents()
                    datos = linea.Split(";")
                    For i = 0 To list.CheckedIndices.Count - 1
                        num_lines += 1
                        clock += 1

                        If IsNumeric(datos(list.CheckedIndices.Item(i) + 2)) Then
                            val = datos(list.CheckedIndices.Item(i) + 2).Replace(",", ".")
                            aux = "('" & list.CheckedItems.Item(i) & "'," & id_drive & "," & id_logger & "," _
                            & measure(list.CheckedIndices.Item(i)) & "," _
                            & "'" & FormatDateTime(datos(1), DateFormat.LongTime) & "'" & "," _
                            & val & ")"
                            ins.set_string(aux)
                        End If
                    Next
                    If clock > 1000 Then
                        ins.insert_into_string()
                        ins.init_string()
                        clock = 1
                    End If
                    progressbar(num_lines, bar, percent, n_data)
                End If
            Loop Until linea Is Nothing
            ins.insert_into_string()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub clean_logger(ByRef list As CheckedListBox, ByRef text As TextBox, ByRef panel As Panel, _
                            ByRef path As String, ByRef long_file As Integer)
        panel.Visible = False
        list.Items.Clear()
        list.Visible = False
        text.Text = ""
        text.Visible = False
        path = ""
        long_file = 0
    End Sub

    Function make_date(ByVal day As String) As String
        Dim yyyy, mm, dd As String
        yyyy = "20" & day(0) & day(1)
        mm = day(2) & day(3)
        dd = day(4) & day(5)
        make_date = yyyy & "-" & mm & "-" & dd
    End Function

    Function make_time(ByVal time As String) As String
        Dim hh, nn, ss As String
        hh = time(0) & time(1)
        nn = time(2) & time(3)
        ss = time(4) & time(5)
        make_time = hh & ":" & nn & ":" & ss
    End Function

    'configuracion del progressbar y labels que le acompañan
    Private Sub config_progressbar(ByRef bar As ProgressBar, ByVal max As Integer, ByVal list As CheckedListBox)
        bar.Minimum = 0
        bar.Maximum = max * list.CheckedIndices.Count
    End Sub

    'controla el objeto progressbar
    Private Sub progressbar(ByVal val As Integer, ByRef bar As ProgressBar, ByRef percent As Label, ByRef n_data As Label)
        bar.Value = val

        ' Visualizamos el porcentaje en el Label
        percent.Text = CLng((bar.Value * 100) / bar.Maximum) & " %"
        n_data.Text = val & " of " & bar.Maximum & " data points"
        Application.DoEvents()
    End Sub

    Function get_logger_id(ByVal logger_name As String) As Integer
        Dim cn As New MySqlConnection(Global.FfE.My.MySettings.Default.ffe_databaseConnectionString)
        Try
            ' Abrir la conexión a Sql  
            cn.Open()

            Dim s As String
            s = "select logger_id from logger where name like '" & logger_name & "';"

            ' Pasar la consulta sql y la conexión al Sql Command   
            Dim cmd As New MySqlCommand(s, cn)
            Dim dr As System.Data.IDataReader
            dr = cmd.ExecuteReader()
            dr.Read()
            get_logger_id = dr(0)

            cn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Function

End Class