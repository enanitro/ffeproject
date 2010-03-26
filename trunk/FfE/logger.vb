Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class logger
    Dim ids_ch_canbus As New Dictionary(Of String, Integer)

    Private Class str_canbus
        Public tam As Integer
        Public Startbit() As Integer
        Public lange() As Integer
        Public Byteanordnung() As Integer
        Public Wertetyp() As Boolean
        Public name() As String
        Public checklist() As Boolean

        Public Sub New(ByVal canbus_long As Integer, ByVal sb() As Integer, ByVal lg() As Integer, _
                       ByVal bd() As Integer, ByVal wt() As Boolean, ByVal n() As String)
            tam = canbus_long
            Startbit = sb
            lange = lg
            Byteanordnung = bd
            Wertetyp = wt
            name = n
            checklist = New Boolean() {False, False, False}
        End Sub

        Public Function get_tam() As Integer
            Return tam
        End Function

        Public Function get_startbit(ByVal index As Integer) As Integer
            Return Startbit(index)
        End Function

        Public Function get_lange(ByVal index As Integer) As Integer
            Return lange(index)
        End Function

        Public Function get_Byteanordnung(ByVal index As Integer) As Integer
            Return Byteanordnung(index)
        End Function

        Public Function get_Wertetyp(ByVal index As Integer) As Boolean
            Return Wertetyp(index)
        End Function

        Public Function get_name(ByVal index As Integer) As String
            Return name(index)
        End Function

        Public Sub checked_channel(ByVal ch As String, ByVal state As Boolean)
            Dim index As Integer
            For i As Integer = 0 To tam
                If name(i) = ch Then
                    index = i
                End If
            Next
            checklist(index) = state
        End Sub
    End Class

    

    Public unit As String
    Dim table_canbus As Dictionary(Of Integer, str_canbus)


    Private Sub Load_table_canbus()
        Dim aux As New str_canbus(3, New Integer() {16, 40, 32}, New Integer() {16, 8, 8}, New Integer() {24, 40, 32}, _
                                  New Boolean() {False, True, True}, _
                                  New String() {"SOC", "max. Batterietemperatur", "min. Batterietemperatur"})
        table_canbus.Add(971, aux)

        aux = New str_canbus(2, New Integer() {16, 0}, New Integer() {16, 12}, New Integer() {24, 8}, _
                             New Boolean() {False, True}, New String() {"Batteriespannung", "HV-Batterie Stromfluss"})
        table_canbus.Add(59, aux)

        aux = New str_canbus(1, New Integer() {32}, New Integer() {8}, New Integer() {8}, New Boolean() {False}, _
                             New String() {"Bremspedalstellung"})
        table_canbus.Add(48, aux)

        aux = New str_canbus(1, New Integer() {16}, New Integer() {8}, New Integer() {16}, New Boolean() {False}, _
                             New String() {"Fahrzeuggeschwindigkeit"})
        table_canbus.Add(970, aux)

        aux = New str_canbus(1, New Integer() {8}, New Integer() {8}, New Integer() {8}, New Boolean() {False}, _
                             New String() {"Motor-Kühlmitteltemeratur"})
        table_canbus.Add(1324, aux)

        aux = New str_canbus(1, New Integer() {32}, New Integer() {8}, New Integer() {32}, New Boolean() {False}, _
                             New String() {"EV Modus"})
        table_canbus.Add(1321, aux)

        aux = New str_canbus(1, New Integer() {8}, New Integer() {16}, New Integer() {16}, New Boolean() {False}, _
                             New String() {"Einspritzung"})
        table_canbus.Add(1312, aux)

        aux = New str_canbus(1, New Integer() {8}, New Integer() {8}, New Integer() {8}, New Boolean() {False}, _
                             New String() {"Tankfüllstand"})
        table_canbus.Add(1444, aux)

        aux = New str_canbus(1, New Integer() {48}, New Integer() {8}, New Integer() {48}, New Boolean() {False}, _
                             New String() {"Gaspedalstellung"})
        table_canbus.Add(580, aux)

        aux = New str_canbus(1, New Integer() {16}, New Integer() {16}, New Integer() {16}, New Boolean() {False}, _
                             New String() {"ICE Drehzahl"})
        table_canbus.Add(980, aux)
    End Sub

    Private Sub count_channels(ByVal list As CheckedListBox)
        For Each name In list.CheckedItems
            name = CType(name, String).Substring(0, CType(name, String).IndexOf(" ->"))
            checked_list_canbus(name, True)
        Next
    End Sub

    Private Sub checked_list_canbus(ByVal name As String, ByVal state As Boolean)
        Dim ch As Integer
        ch = ids_ch_canbus(name)
        table_canbus(ch).checked_channel(name, state)
    End Sub


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
                ElseIf id = FfE_Main.id_canbus Then
                    analyze_logger_canbus(path, list, text, id, long_file, measure)
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
                'name = (i - 3) & " (" & datos1(i) & ")"
                name = datos1(i)
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
                    'name = (i - 1) & " " & datos1(i) & " (" & datos2(i) & ")"
                    name = datos1(i) & " (" & datos2(i) & ")"
                Else
                    'name = (i - 1) & " " & datos1(i)
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

    'analisis del archivo cvs del logger CANBUS
    Public Sub analyze_logger_canbus(ByVal path As String, ByRef list As CheckedListBox, ByRef text As TextBox, _
                                    ByVal id As Integer, ByRef long_file As String, ByRef measure() As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea1, linea2, name As String
        Dim datos1(), datos2() As String
        Dim interval As String = ""
        Dim i, st, ft As Integer

        Try
            'leer cabecera, hacer comprobaciones, mostrarla por pantalla
            text.Text = ""
            linea1 = fichero.ReadLine
            For i = 1 To 6
                linea1 = fichero.ReadLine
                text.Text += linea1
            Next



            list.Items.Add("Bremspedalstellung")
            list.Items.Add("Batteriespannung")
            list.Items.Add("HV-Batterie Stromfluss")
            list.Items.Add("Gaspedalstellung")
            list.Items.Add("ICE Drehzahl")
            list.Items.Add("Fahrzeuggeschwindigkeit")
            list.Items.Add("SOC")
            list.Items.Add("max. Batterietemperatur")
            list.Items.Add("min. Batterietemperatur")
            list.Items.Add("Einspritzung")
            list.Items.Add("EV Modus")
            list.Items.Add("Motor-Kühlmitteltemeratur")
            list.Items.Add("Tankfüllstand")

            Array.Resize(measure, 13)



        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Public Sub 

    'inserta los datos del fichero en la tabla data (logger graphtec GL800)
    Public Sub insert_logger_graphtec_gl800(ByVal path As String, ByRef list As CheckedListBox, ByRef text As TextBox, _
                                    ByRef percent As Label, ByRef n_data As Label, ByRef bar As ProgressBar, _
                                    ByVal id_logger As Integer, ByVal id_drive As Integer, ByRef long_file As String, _
                                    ByVal measure() As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea, aux As String
        Dim datos() As String
        Dim num_lines As Integer = 0
        Dim data_points As Integer = 0
        Dim index As Integer = 0
        Dim clock As Integer = 0
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
                    index += 1
                    For i = 0 To list.CheckedIndices.Count - 1
                        num_lines += 1

                        'En caso de que el valor sea numerico
                        If IsNumeric(datos(list.CheckedIndices.Item(i) + 2)) Then
                            data_points += 1
                            clock += 1

                            aux = "(" & index & ",'" & list.CheckedItems.Item(i) & "'," & id_drive _
                            & "," & id_logger & "," & measure(list.CheckedIndices.Item(i)) & "," _
                            & "'" & FormatDateTime(datos(1), DateFormat.LongTime) & "'" & "," _
                            & datos(list.CheckedIndices.Item(i) + 2) & ")"
                            ins.set_string(aux)
                        End If
                        progressbar(num_lines, bar, percent)
                    Next
                    If clock >= 1000 Then
                        ins.insert_into_string()
                        ins.init_string()
                        clock = 1
                    End If
                End If
            Loop Until linea Is Nothing
            If Not ins.is_empty Then
                ins.insert_into_string()
            End If
            data_summary(num_lines, n_data, data_points)
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
        Dim data_points As Integer = 0
        Dim index As Integer = 0
        Dim clock As Integer = 0
        Dim value As Double

        Try
            'leo la primera linea que pertenece a la cabecera
            linea = fichero.ReadLine

            Dim ins As New insert_Data
            ins.init_string()

            config_progressbar(bar, long_file, list)

            Do
                linea = fichero.ReadLine
                If linea <> Nothing Then
                    Application.DoEvents()
                    datos = linea.Split(",")
                    index += 1
                    For i = 0 To list.CheckedIndices.Count - 1
                        num_lines += 1
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
                        If val <> "" Then
                            data_points += 1
                            clock += 1

                            aux = "(" & index & ",'" & list.CheckedItems.Item(i) & "'," & id_drive _
                            & "," & id_logger & "," & measure(list.CheckedIndices.Item(i)) & "," _
                            & "'" & FormatDateTime(make_time(datos(3)), DateFormat.LongTime) & "'" & "," _
                            & val & ")"
                            ins.set_string(aux)
                        End If
                        progressbar(num_lines, bar, percent)
                    Next
                    If clock >= 1000 Then
                        ins.insert_into_string()
                        ins.init_string()
                        clock = 1
                    End If
                End If
            Loop Until linea Is Nothing
            If Not ins.is_empty Then
                ins.insert_into_string()
            End If
            data_summary(num_lines, n_data, data_points)
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
        Dim data_points As Integer = 0
        Dim index As Integer = 0
        Dim clock As Integer = 0
        Dim value As Double

        Try
            'leo la primera linea que pertenece a la cabecera
            For i = 0 To 10
                linea = fichero.ReadLine
            Next

            Dim ins As New insert_Data
            ins.init_string()

            config_progressbar(bar, long_file, list)

            Do
                linea = fichero.ReadLine
                If linea <> Nothing Then
                    Application.DoEvents()
                    datos = linea.Split(";")
                    index += 1
                    For i = 0 To list.CheckedIndices.Count - 1
                        num_lines += 1

                        If IsNumeric(datos(list.CheckedIndices.Item(i) + 2)) Then
                            data_points += 1
                            clock += 1

                            val = datos(list.CheckedIndices.Item(i) + 2).Replace(",", ".")
                            aux = "(" & index & ",'" & list.CheckedItems.Item(i) & "'," & id_drive _
                            & "," & id_logger & "," & measure(list.CheckedIndices.Item(i)) & "," _
                            & "'" & FormatDateTime(datos(1), DateFormat.LongTime) & "'" & "," _
                            & val & ")"
                            ins.set_string(aux)
                        End If
                        progressbar(num_lines, bar, percent)
                    Next
                    If clock >= 1000 Then
                        ins.insert_into_string()
                        ins.init_string()
                        clock = 1
                    End If
                End If
            Loop Until linea Is Nothing
            If Not ins.is_empty Then
                ins.insert_into_string()
            End If
            data_summary(num_lines, n_data, data_points)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub init_Dictionary()
        ids_ch_canbus.Add("Bremspedalstellung", 48)
        ids_ch_canbus.Add("Batteriespannung", 59)
        ids_ch_canbus.Add("HV-Batterie Stromfluss", 59)
        ids_ch_canbus.Add("Gaspedalstellung", 580)
        ids_ch_canbus.Add("ICE Drehzahl", 968)
        ids_ch_canbus.Add("Fahrzeuggeschwindigkeit", 970)
        ids_ch_canbus.Add("SOC", 971)
        ids_ch_canbus.Add("max. Batterietemperatur", 971)
        ids_ch_canbus.Add("min. Batterietemperatur", 971)
        ids_ch_canbus.Add("Einspritzung", 1312)
        ids_ch_canbus.Add("EV Modus", 1321)
        ids_ch_canbus.Add("Motor-Kühlmitteltemeratur", 1324)
        ids_ch_canbus.Add("Tankfüllstand", 1444)
    End Sub

    'inserta los datos del fichero en la tabla data (logger CANBUS)
    Public Sub insert_logger_canbus(ByVal path As String, ByRef list As CheckedListBox, ByRef text As TextBox, _
                                    ByRef percent As Label, ByRef n_data As Label, ByRef bar As ProgressBar, _
                                    ByVal id_logger As Integer, ByVal id_drive As Integer, ByRef long_file As String, _
                                    ByVal measure() As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea, aux As String
        Dim datos() As String
        Dim num_lines As Integer = 0
        Dim data_points As Integer = 0
        Dim index As Integer = 0
        Dim clock As Integer = 0
        Dim value As Integer

        init_Dictionary()
        Try
            'leo las 7 primeras lineas que pertenecen a la cabecera
            For i = 0 To 6
                linea = fichero.ReadLine
            Next

            Dim ins As New insert_Data
            ins.init_string()

            config_progressbar(bar, long_file, list)
            count_channels(list)

            Do
                linea = fichero.ReadLine
                If linea <> Nothing Then
                    Application.DoEvents()
                    datos = linea.Split(vbTab)
                    index += 1
                    'For i = 0 To list.CheckedIndices.Count - 1
                    num_lines += 1

                    value = Val(datos(6))

                    For i = 0 To table_canbus(value).tam
                        If table_canbus(value).checklist(i) = True Then

                        End If
                    Next

                    'If Val() <> "" Then
                    data_points += 1
                    clock += 1

                    'aux = "(" & num_lines & ",'" & list.CheckedItems.Item(i) & "'," & id_drive _
                    '& "," & id_logger & "," & measure(list.CheckedIndices.Item(i)) & "," _
                    '& "'" & FormatDateTime(format_time(datos(0), 10000000), DateFormat.LongTime) & "'" & "," _
                    '& Val() & ")"
                    'ins.set_string(aux)
                    'End If
                    progressbar(num_lines, bar, percent)
                    'Next
                    If clock >= 1000 Then
                        ins.insert_into_string()
                        ins.init_string()
                        clock = 1
                    End If
                End If
            Loop Until linea Is Nothing
            If Not ins.is_empty Then
                ins.insert_into_string()
            End If
            data_summary(num_lines, n_data, data_points)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function hex_to_dec(ByVal data As String) As String
        Dim values() As String
        values = data.Split(" ")
        dec_to_bin(values(5))
        hex_to_dec = values(5)
    End Function

    Private Function dec_to_bin(ByVal value As String) As String
        Dim BinStr As String
        BinStr = CBool(value)
        BinStr = "00000000" & BinStr
        BinStr = BinStr.Substring(BinStr.Length - 8)
        dec_to_bin = BinStr
    End Function

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
        Dim hh, mm, ss As String
        hh = time(0) & time(1)
        mm = time(2) & time(3)
        ss = time(4) & time(5)
        make_time = hh & ":" & mm & ":" & ss
    End Function

    Function format_time(ByVal time As String, ByVal unit As Integer)
        Dim res As String
        Dim h, m, s As Integer
        h = m = s = 0
        s = CType(time, Integer)
        s = s / unit

        Do While (s > 60)
            s = s - 60
            m += 1
            If m > 60 Then
                Do While (m > 60)
                    m = m - 60
                    h += 1
                Loop
            End If
        Loop

        res = h & ":" & m & ":" & s

        Return res
    End Function

    'configuracion del progressbar y labels que le acompañan
    Private Sub config_progressbar(ByRef bar As ProgressBar, ByVal max As Integer, ByVal list As CheckedListBox)
        bar.Minimum = 0
        bar.Maximum = max * list.CheckedIndices.Count
    End Sub

    'controla el objeto progressbar
    Private Sub progressbar(ByVal val As Integer, ByRef bar As ProgressBar, ByRef percent As Label)
        bar.Value = val

        ' Visualizamos el porcentaje en el Label
        percent.Text = CLng((bar.Value * 100) / bar.Maximum) & " %"
        Application.DoEvents()
    End Sub

    Private Sub data_summary(ByVal val As Integer, ByRef n_data As Label, ByVal data_points As Integer)
        n_data.Text = val & " data points were read" & vbCrLf & vbCrLf
        n_data.Text += data_points & " data points were imported"
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

    Public Sub delete_rows(ByVal list As CheckedListBox, ByVal drive_id As Integer, ByVal logger_id As Integer)
        Dim cn As New MySqlConnection(Global.FfE.My.MySettings.Default.ffe_databaseConnectionString)
        Try
            ' Abrir la conexión a Sql  
            cn.Open()

            Dim s As String
            ' Pasar la consulta sql y la conexión al Sql Command   
            Dim cmd As New MySqlCommand

            For i = 0 To list.CheckedIndices.Count - 1

                s = "delete from data where drive_id = " & drive_id & _
                    " and logger_id = " & logger_id & _
                    " and data_id = '" & list.CheckedItems.Item(i) & "';"
                cmd.Connection = cn
                cmd.CommandText = s
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

End Class