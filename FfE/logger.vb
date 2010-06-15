Imports MySql.Data
Imports MySql.Data.MySqlClient

'0 Bremspedalstellung
'1 Batteriespannung
'2 HV-Batterie Stromfluss
'3 Gaspedalstellung
'4 ICE Drehzahl
'5 Fahrzeuggeschwindigkeit
'6 SOC
'7 max. Batterietemperatur
'8 min. Batterietemperatur
'9 Einspritzung
'10 EV Modus
'11 Motor-Kühlmitteltemeratur
'12 Scheinwerfer
'13 Tankfüllstand


Public Class logger

    Private Class str_canbus
        Public id As Integer
        Public startbit As Integer
        Public longbits As Integer
        Public sequence As String
        Public signed As Boolean
        Public factor As Double
        Public offset As Integer
        Public average As Boolean
        Public value As Double
        Public time As String
        Public count As Double

        Public Sub New(ByVal i As Integer, ByVal sb As Integer, ByVal lg As Integer, _
                       ByVal sq As String, ByVal sg As Boolean, ByVal dec As Double, _
                       ByVal os As Integer, ByVal av As Boolean)
            id = i
            startbit = sb
            longbits = lg
            sequence = sq
            signed = sg
            factor = dec
            offset = os
            average = av
            value = 0
            time = ""
            count = 0
        End Sub

    End Class

    Public unit As String
    Dim table_canbus As New Dictionary(Of Integer, str_canbus)
    Dim ids_chs As New Dictionary(Of Integer, Integer())

    Private Sub load_ids_chs(ByVal list As CheckedListBox)
        Dim v() As Integer
        For Each i In list.CheckedIndices
            If ids_chs.TryGetValue(table_canbus(i).id, v) Then
                Array.Resize(v, v.Length + 1)
                v(v.Length - 1) = i
                ids_chs.Item(table_canbus(i).id) = v
            Else
                ReDim v(0)
                v(0) = i
                ids_chs.Add(table_canbus(i).id, v)
            End If
        Next
    End Sub

    Private Sub Load_table_canbus(ByVal list As CheckedListBox)
        Dim cn As New MySqlConnection(Global.FfE.My.MySettings.Default.ffe_databaseConnectionString)
        Dim s As String
        Dim cmd As New MySqlCommand
        Dim dr As MySqlDataReader

        For Each i In list.CheckedIndices
            cn.Open()
            cmd.Connection = cn
            s = "select channel_id, dec_id, startbit, longbits, sequence, signed, factor, offset, average " & _
                " from ids_canbus where channel_id = " & i & ";"
            cmd.CommandText = s
            dr = cmd.ExecuteReader
            dr.Read()
            table_canbus.Add(i, New str_canbus(dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8)))
            cn.Close()
        Next
    End Sub


    Public Function logger_dialog(ByVal filedialog As OpenFileDialog, ByRef list As CheckedListBox, ByVal id As Integer, _
                             ByRef text As TextBox, ByRef long_file As Integer, ByRef measure() As Integer, _
                             ByVal n_file As Integer, ByRef check As CheckBox) As String
        filedialog.FileName = ""
        filedialog.ShowDialog()
        If My.Computer.FileSystem.FileExists(filedialog.FileName) Then
            analizar_CVS(filedialog.FileName, id, text, n_file, list, long_file, measure)
        End If
        If list.Items.Count <> 0 Then
            list.Visible = True
            text.Visible = True
            check.Visible = True
            logger_dialog = filedialog.FileName
        Else
            logger_dialog = ""
        End If
    End Function


    'analiza la cabecera del archivo
    Public Sub analizar_CVS(ByVal path As String, ByVal id As String, ByRef text As TextBox, ByVal n_file As Integer, _
                            ByRef list As CheckedListBox, ByRef long_file As String, ByRef measure() As Integer)
        procesing.Show()
        Application.DoEvents()
        If id = FfE_Main.id_graphtec Then
            analyze_logger_graphtec_gl800(path, list, text, id, long_file, measure, n_file)
        Else
            If id = FfE_Main.id_gps Then
                analyze_logger_columbus_gps(path, list, text, id, long_file, measure, n_file)
            Else
                If id = FfE_Main.id_lmg Then
                    analyze_logger_lmg(path, list, text, id, long_file, measure, n_file)
                ElseIf id = FfE_Main.id_canbus Then
                    analyze_logger_canbus(path, list, text, id, long_file, measure, n_file)
                End If
            End If
        End If
        procesing.Close()
    End Sub

    'analisis del archivo cvs del logger graphtec gl800
    Public Sub analyze_logger_graphtec_gl800(ByVal path As String, ByRef list As CheckedListBox, _
                                             ByRef text As TextBox, ByVal id As Integer, ByRef long_file As String, _
                                             ByRef measure() As Integer, ByVal n_file As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea1, linea2, name As String
        Dim datos1(), datos2() As String
        Dim i, j, count As Integer

        Try
            text.Text += "File: " & (n_file + 1) & vbCrLf

            'comprobar si es un archivo del logger graphtec gl800
            linea1 = fichero.ReadLine
            datos1 = linea1.Split(",")

            text.Text += datos1(1) & vbCrLf

            'leer cabecera y mostrarla por pantalla
            For i = 0 To 3
                linea1 = fichero.ReadLine
                datos1 = linea1.Split(",")
                text.Text += datos1(0) & ": "
                text.Text += datos1(1) & vbCrLf
                If i = 2 Then unit = datos1(1)
                If i = 3 Then count = datos1(1)
            Next

            For i = 0 To 2
                linea1 = fichero.ReadLine
                datos1 = linea1.Split(",")
                text.Text += datos1(0) & ": "
                text.Text += datos1(1) & " "
                text.Text += datos1(2) & vbCrLf
            Next
            text.Text += vbCrLf

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
            If n_file = 0 Then
                For j = 2 To i + 1
                    datos2(j) = datos2(j).Trim("""")
                    name = datos1(j) + " (" + datos2(j) + ")"
                    list.Items.Add(name)
                Next
                Array.Resize(measure, list.Items.Count)
            End If

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
    Public Sub analyze_logger_columbus_gps(ByVal path As String, ByRef list As CheckedListBox, _
                                           ByRef text As TextBox, ByVal id As Integer, ByRef long_file As String, _
                                           ByRef measure() As Integer, ByVal n_file As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea1, linea2, name As String
        Dim datos1(), datos2() As String
        Dim stime, etime As String
        Dim interval As Integer = 0
        Dim i As Integer

        Try
            text.Text += "File: " & (n_file + 1) & vbCrLf

            'leer cabecera, hacer comprobaciones, mostrarla por pantalla
            linea1 = fichero.ReadLine
            datos1 = linea1.Split(",")

            If n_file = 0 Then
                'introducir los canales en checklistbox
                For i = 4 To datos1.Length - 2
                    'name = (i - 3) & " (" & datos1(i) & ")"
                    name = datos1(i)
                    list.Items.Add(name)
                Next
                Array.Resize(measure, list.Items.Count)
            End If

            linea1 = fichero.ReadLine
            datos1 = linea1.Split(",")

            'hora de comienzo
            stime = make_date(datos1(2)) & " " & make_time(datos1(3), time_gps(make_date(datos1(2))))

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
            etime = make_date(datos1(2)) & " " & make_time(datos1(3), time_gps(make_date(datos1(2))))

            'calculo el intervalo aprox. de tiempo
            interval = DateDiff("s", FormatDateTime(stime), FormatDateTime(etime))
            interval = interval / i

            'escribo cabecera
            text.Text += "Columbus GPS" & vbCrLf & _
                        "Sampling interval: " & interval & "s" & vbCrLf & _
                        "Total data points: " & i & vbCrLf & _
                        "Start time: " & stime & vbCrLf & _
                        "End time: " & etime & vbCrLf & vbCrLf
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'analisis del archivo cvs del logger columbus GPS
    Public Sub analyze_logger_lmg(ByVal path As String, ByRef list As CheckedListBox, _
                                  ByRef text As TextBox, ByVal id As Integer, ByRef long_file As String, _
                                  ByRef measure() As Integer, ByVal n_file As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea1, linea2, name As String
        Dim datos1(), datos2() As String
        Dim interval As Integer = 0
        Dim i As Integer

        Try
            text.Text += "File: " & (n_file + 1) & vbCrLf
            'escribo cabecera
            text.Text += "LMG500" & vbCrLf

            linea1 = fichero.ReadLine
            linea1 = fichero.ReadLine
            text.Text += "Start time: " & linea1.TrimEnd.Substring(linea1.Length - 9).TrimStart & vbCrLf

            'leemos los canales y sus unidades
            linea1 = fichero.ReadLine
            datos1 = linea1.Split(",")
            While datos1(0) <> "dt/s"
                linea1 = fichero.ReadLine
                datos1 = linea1.Split(",")
            End While

            'introducir los canales en checklistbox
            If n_file = 0 Then
                For i = 1 To datos1.Length - 1
                    list.Items.Add(datos1(i))
                Next
                Array.Resize(measure, list.Items.Count)
            End If

            long_file = 0
            Do
                linea1 = fichero.ReadLine
                If linea1 <> Nothing Then long_file += 1
            Loop Until linea1 Is Nothing

            text.Text += "Total data points: " & long_file & vbCrLf & vbCrLf
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'analisis del archivo cvs del logger CANBUS
    Public Sub analyze_logger_canbus(ByVal path As String, ByRef list As CheckedListBox, _
                                     ByRef text As TextBox, ByVal id As Integer, ByRef long_file As String, _
                                     ByRef measure() As Integer, ByVal n_file As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea1 As String
        Dim datos1(), datos2() As String
        Dim interval As String = ""
        Dim i As Integer

        Try
            text.Text += "File: " & (n_file + 1) & vbCrLf

            'leer cabecera, hacer comprobaciones, mostrarla por pantalla
            text.Text += "CAN-BUS" & vbCrLf
            linea1 = fichero.ReadLine
            datos1 = linea1.Split(vbTab)
            linea1 = fichero.ReadLine
            datos2 = linea1.Split(vbTab)
            text.Text += datos1(0).Trim(";") & ": " & datos2(0) & vbCrLf
            text.Text += datos1(1).Trim(";") & ": " & datos2(1) & vbCrLf
            text.Text += "Date/Time: " & datos2(4) & vbCrLf

            linea1 = fichero.ReadLine
            Do While linea1(0) = "0"
                linea1 = fichero.ReadLine
            Loop

            long_file = 1
            Do
                linea1 = fichero.ReadLine
                long_file += 1
            Loop While linea1 <> Nothing
            text.Text += "Data points: " & long_file & vbCrLf & vbCrLf

            If n_file = 0 Then
                load_channels_canbus(list)
                Array.Resize(measure, list.Items.Count)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub load_channels_canbus(ByRef list As CheckedListBox)
        Dim cn As New MySqlConnection(Global.FfE.My.MySettings.Default.ffe_databaseConnectionString)
        Try
            ' Abrir la conexión a Sql  
            cn.Open()

            Dim s As String
            s = "select name from ids_canbus group by channel_id;"

            ' Pasar la consulta sql y la conexión al Sql Command   
            Dim cmd As New MySqlCommand(s, cn)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read()
                list.Items.Add(dr.GetString(0))
            End While

            cn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Function find_last_index(ByVal id_logger As Integer, ByVal id_drive As Integer) As Integer
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sql As String = ""
        Dim res As Integer = 0

        cn.Open()
        cmd.Connection = cn
        sql = "select if(max(data_index)is not null,max(data_index),0) from data where drive_id = " & id_drive & _
              " and logger_id = " & id_logger
        cmd.CommandText = sql
        query = cmd.ExecuteReader()
        query.Read()
        If query.HasRows() Then
            res = query.GetInt32(0)
        End If
        cn.Close()

        find_last_index = res
    End Function

    Private Function find_all_channels(ByVal id_logger As Integer, ByVal id_drive As Integer, _
                                       ByVal list As CheckedListBox) As Boolean
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sql As String = ""
        Dim res As Boolean = True

        cn.Open()
        cmd.Connection = cn
        sql = "select count(distinct(data_id)) from data where drive_id = " & id_drive & " and logger_id = " & id_logger
        cmd.CommandText = sql
        query = cmd.ExecuteReader()
        query.Read()
        If query.GetInt32(0) = list.CheckedItems.Count Then
            cn.Close()
            cn.Open()
            cmd.Connection = cn
            sql = "select distinct(data_id) from data where drive_id = " & id_drive & " and logger_id = " & id_logger
            cmd.CommandText = sql
            query = cmd.ExecuteReader()
            While query.Read() And res = True
                For i = 0 To list.CheckedItems.Count - 1
                    If query.GetString(0) = list.CheckedItems.Item(i) Then
                        res = True
                    Else
                        res = False
                    End If
                Next
            End While
        Else
            res = False
        End If
        cn.Close()

        find_all_channels = res
    End Function

    'inserta los datos del fichero en la tabla data (logger graphtec GL800)
    Public Sub insert_logger_graphtec_gl800(ByVal path As String, ByRef list As CheckedListBox, ByRef text As TextBox, _
                                    ByRef percent As Label, ByRef n_data As Label, ByRef bar As ProgressBar, _
                                    ByVal id_logger As Integer, ByVal id_drive As Integer, ByRef long_file As String, _
                                    ByVal measure() As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea, aux, val, time, flag, sql As String
        Dim time1, time2, sync As Date
        Dim datos() As String
        Dim num_lines As Integer = 0
        Dim data_points As Integer = 0
        Dim index As Integer = 0
        Dim clock As Integer = 0
        Dim sec As Long
        Dim ch39 As Integer = 1
        Dim value As Double

        index = find_last_index(id_logger, id_drive)
        If index <> 0 Then
            If Not find_all_channels(id_logger, id_drive, list) Then
                index = 0
            End If
        End If

        'For i = 1 To list.Items.Count + 14
        'linea = fichero.ReadLine
        'Next

        'leemos hasta la declaracion de los canales
        Do
            linea = fichero.ReadLine
            datos = linea.Split(",")
        Loop Until datos(0) = "CH"

        'buscamos en que posicion esta el ch39(batterie spannung)
        Do
            linea = fichero.ReadLine
            datos = linea.Split(",")
            ch39 += 1
        Loop Until datos(0) = "CH39" Or datos(0) = "Logic/Pulse"

        'si no se ha encontrado ch39, no lo tendremos en cuenta
        If datos(0) = "Logic/Pulse" Then ch39 = -1

        'leemos las lines que que faltan hasta llegar a los datos
        Do
            linea = fichero.ReadLine
            datos = linea.Split(",")
        Loop Until datos(0) = "NO."

        'descartamos las filas que no deben almacenarse porque ch39=0 
        If index = 0 And ch39 <> -1 Then
            Do
                linea = fichero.ReadLine
                datos = linea.Split(",")
                val = datos(ch39)
                num_lines += 1
            Loop Until val > 0
            num_lines = (num_lines - 1) * list.CheckedItems.Count
            'inicializo la primera hora
            time1 = FormatDateTime(datos(1), DateFormat.LongTime)
        Else
            sql = "select max(time) from data where drive_id = " & id_drive & " and logger_id = " & id_logger
            time1 = search_time_sync(sql)
        End If

        'busco la hora para sincronizar el primer valor
        sql = "select time from data where drive_id = " & id_drive & " and logger_id = " & FfE_Main.id_canbus & _
              " and data_index = (select min(data_index) from data where drive_id = " & _
              id_drive & " and logger_id = " & FfE_Main.id_canbus & _
              " and (data_id like '2.%' or data_id like '%-> 2.%') and value > 0)"
        flag = search_time_sync(sql)
        If flag <> "" Then sync = CType(flag, DateTime)

        config_progressbar(bar, long_file, list, n_data)

        Dim ins As New insert_Data
        ins.init_string()

        Do
            If linea <> Nothing Then
                Application.DoEvents()
                datos = linea.Split(",")
                index += 1
                'calcular el tiempo
                If flag <> "" Then
                    time2 = time1
                    time1 = FormatDateTime(datos(1), DateFormat.LongTime)
                    sec = Math.Abs(DateDiff(DateInterval.Second, time2, time1))
                    sync = DateAdd(DateInterval.Second, sec, sync)
                    time = sync.ToString("HH:mm:ss")
                Else
                    time = FormatDateTime(datos(1), DateFormat.LongTime)
                End If
                For i = 0 To list.CheckedIndices.Count - 1
                    num_lines += 1

                    'En caso de que el valor sea numerico
                    If IsNumeric(datos(list.CheckedIndices.Item(i) + 2)) Then
                        data_points += 1
                        clock += 1

                        aux = "(" & index & ",'" & list.CheckedItems.Item(i) & "'," & id_drive _
                        & "," & id_logger & "," & measure(list.CheckedIndices.Item(i)) & "," _
                        & "'" & time & "'" & "," _
                        & "NULL," & datos(list.CheckedIndices.Item(i) + 2) & ")"
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
            linea = fichero.ReadLine
        Loop Until linea Is Nothing
        If Not ins.is_empty Then
            ins.insert_into_string()
        End If

    End Sub

    'inserta los datos del fichero en la tabla data (logger Columbus GPS)
    Public Sub insert_logger_columbus_gps(ByVal path As String, ByRef list As CheckedListBox, ByRef text As TextBox, _
                                    ByRef percent As Label, ByRef n_data As Label, ByRef bar As ProgressBar, _
                                    ByVal id_logger As Integer, ByVal id_drive As Integer, ByRef long_file As String, _
                                    ByVal measure() As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea, aux, val, sql, flag, time As String
        Dim sync, time1, time2 As Date
        Dim datos() As String
        Dim num_lines As Integer = 0
        Dim data_points As Integer = 0
        Dim index As Integer = 0
        Dim clock As Integer = 0
        Dim value As Double
        Dim sec As Long
        Dim s_w_time As String = ""
        Dim add_hour As Integer

        index = find_last_index(id_logger, id_drive)
        If index <> 0 Then
            If Not find_all_channels(id_logger, id_drive, list) Then
                index = 0
            End If
        End If

        'leo la primera linea que pertenece a la cabecera
        linea = fichero.ReadLine

        Dim ins As New insert_Data
        ins.init_string()

        If index = 0 Then
            Do
                linea = fichero.ReadLine
                datos = linea.Split(",")
                val = datos(7)
                If val(val.Count - 1) = Nothing Then
                    Do
                        val = val.Remove(val.Count - 1)
                    Loop Until val(val.Count - 1) <> Nothing
                End If
                num_lines += 1
            Loop Until val >= 10
            num_lines = (num_lines - 1) * list.CheckedItems.Count

            'inicializo la primera hora
            s_w_time = make_date(datos(2))
            add_hour = time_gps(s_w_time)
            time1 = FormatDateTime(make_time(datos(3), add_hour), DateFormat.LongTime)
        Else
            sql = "select max(time) from data where drive_id = " & id_drive & " and logger_id = " & id_logger
            time1 = search_time_sync(sql)
            linea = fichero.ReadLine
            datos = linea.Split(",")
            s_w_time = make_date(datos(2))
            add_hour = time_gps(s_w_time)
        End If

        'busco la hora para sincronizar el primer valor
        sql = "select time from data where drive_id = " & id_drive & " and logger_id = " & FfE_Main.id_canbus & _
              " and data_index = (select min(data_index) from data where drive_id = " & _
              id_drive & " and logger_id = " & FfE_Main.id_canbus & _
              " and (data_id like '6.%' or data_id like '%-> 6.%') and value >= 10)"
        flag = search_time_sync(sql)
        If flag <> "" Then sync = CType(flag, DateTime)

        config_progressbar(bar, long_file, list, n_data)

        Do
            If linea <> Nothing Then
                Application.DoEvents()
                datos = linea.Split(",")
                index += 1
                'calcular el tiempo
                If flag <> "" Then
                    time2 = time1
                    time1 = FormatDateTime(make_time(datos(3), add_hour), DateFormat.LongTime)
                    sec = Math.Abs(DateDiff(DateInterval.Second, time2, time1))
                    sync = DateAdd(DateInterval.Second, sec, sync)
                    time = sync.ToString("HH:mm:ss")
                Else
                    time = FormatDateTime(make_time(datos(3), add_hour), DateFormat.LongTime)
                End If
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
                        & "'" & time & "'" & "," _
                        & "NULL," & val & ")"
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
            linea = fichero.ReadLine
        Loop Until linea Is Nothing
        If Not ins.is_empty Then
            ins.insert_into_string()
        End If

    End Sub

    'inserta los datos del fichero en la tabla data (logger Fluke)
    Public Sub insert_logger_lmg500(ByVal path As String, ByRef list As CheckedListBox, ByRef text As TextBox, _
                                    ByRef percent As Label, ByRef n_data As Label, ByRef bar As ProgressBar, _
                                    ByVal id_logger As Integer, ByVal id_drive As Integer, ByRef long_file As String, _
                                    ByVal measure() As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea, aux, val, tm, milsec, time, sql, flag As String
        Dim time1, time2, sync As Date
        Dim datos() As String
        Dim num_lines As Integer = 0
        Dim data_points As Integer = 0
        Dim sec As Long
        Dim index As Integer = 0
        Dim clock As Integer = 0
        Dim value As Double

        index = find_last_index(id_logger, id_drive)
        If index <> 0 Then
            If Not find_all_channels(id_logger, id_drive, list) Then
                index = 0
            End If
        End If

        linea = fichero.ReadLine
        linea = fichero.ReadLine
        tm = linea.TrimEnd.Substring(linea.Length - 9).TrimStart()
        linea = fichero.ReadLine
        datos = linea.Split(",")
        While datos(0) <> "dt/s"
            linea = fichero.ReadLine
            datos = linea.Split(",")
        End While

        If index = 0 Then
            Do
                linea = fichero.ReadLine
                datos = linea.Split(",")
                val = datos(18)
                num_lines += 1
            Loop Until val > 0
            num_lines = (num_lines - 1) * list.CheckedItems.Count
            'inicializo la primera hora
            time1 = format_time2(format_number(datos(0)), 1, tm, milsec)
        Else
            sql = "select max(time) from data where drive_id = " & id_drive & " and logger_id = " & id_logger
            time1 = search_time_sync(sql)
        End If


        'busco la hora para sincronizar el primer valor
        sql = "select time from data where drive_id = " & id_drive & " and logger_id = " & FfE_Main.id_canbus & _
              " and data_index = (select min(data_index) from data where drive_id = " & _
              id_drive & " and logger_id = " & FfE_Main.id_canbus & _
              " and (data_id like '2.%' or data_id like '%-> 2.%') and value > 0)"
        flag = search_time_sync(sql)
        If flag <> "" Then sync = CType(flag, DateTime)

        Dim ins As New insert_Data
        ins.init_string()

        config_progressbar(bar, long_file, list, n_data)

        Do
            If linea <> Nothing Then
                Application.DoEvents()
                datos = linea.Split(",")
                index += 1
                'calculo el tiempo
                If flag <> "" Then
                    time2 = time1
                    time1 = format_time2(format_number(datos(0)), 1, tm, milsec)
                    sec = Math.Abs(DateDiff(DateInterval.Second, time2, time1))
                    sync = DateAdd(DateInterval.Second, sec, sync)
                    time = sync.ToString("HH:mm:ss")
                Else
                    time = format_time2(format_number(datos(0)), 1, tm, milsec)
                End If
                For i = 0 To list.CheckedIndices.Count - 1
                    num_lines += 1
                    If IsNumeric(datos(list.CheckedIndices.Item(i) + 1)) Then
                        data_points += 1
                        clock += 1
                        val = datos(list.CheckedIndices.Item(i) + 1)
                        aux = "(" & index & ",'" & list.CheckedItems.Item(i) & "'," & id_drive _
                        & "," & id_logger & "," & measure(list.CheckedIndices.Item(i)) & "," _
                        & "'" & time & "'" & "," _
                        & "NULL," & val & ")"
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
            linea = fichero.ReadLine
        Loop Until linea Is Nothing
        If Not ins.is_empty Then
            ins.insert_into_string()
        End If
        
    End Sub


    'inserta los datos del fichero en la tabla data (logger CANBUS)
    Public Sub insert_logger_canbus(ByVal path As String, ByRef list As CheckedListBox, ByRef text As TextBox, _
                                    ByRef percent As Label, ByRef n_data As Label, ByRef bar As ProgressBar, _
                                    ByVal id_logger As Integer, ByVal id_drive As Integer, ByRef long_file As String, _
                                    ByVal measure() As Integer)
        Dim fichero As New System.IO.StreamReader(path)
        Dim linea, aux, time, tm, val, avg, milsec As String
        Dim datos() As String
        Dim div As Int64 = 0
        Dim num_lines As Integer = 0
        Dim data_points As Integer = 0
        Dim index As Integer = 0
        Dim clock As Integer = 0
        Dim value, id_ch() As Integer
        Dim res, res2, t As Double
        Dim str As str_canbus
        Dim flag As Boolean = False

        index = find_last_index(id_logger, id_drive)
        If index <> 0 Then
            If Not find_all_channels(id_logger, id_drive, list) Then
                index = 0
                Load_table_canbus(list)
                load_ids_chs(list)
            Else
                flag = True
            End If
        Else
            Load_table_canbus(list)
            load_ids_chs(list)
        End If

        linea = fichero.ReadLine
        'If linea.Split(vbTab)(0).Split("[")(1).Trim("]") = "ns" Then
        '
        'Else
        'If linea.Split(vbTab)(0).Split("[")(1).Trim("]") = "µs" Then div = 1000000
        'End If
        linea = fichero.ReadLine
        div = 1000000000
        datos = linea.Split(vbTab)
        time = datos(4)
        time = time.Split(" ")(3)

        linea = fichero.ReadLine
        Do While linea(0) = "0"
            linea = fichero.ReadLine
        Loop

        val = 0
        If index = 0 Then
            Do
                linea = fichero.ReadLine
                datos = linea.Split(vbTab)
                If datos.Length = 8 Then
                    If datos(5).Split(":")(0) = "Dlc" Then
                        If datos(6).Trim = "id:59" Then
                            val = datos(7).Split(" ")(3)
                        End If
                    End If
                End If
                num_lines += 1
            Loop Until val > 0
        End If

        Dim ins As New insert_Data
        ins.init_string()

        long_file = long_file / list.CheckedIndices.Count
        config_progressbar(bar, long_file, list, n_data)

        Do
            If linea <> Nothing Then
                Application.DoEvents()
                datos = linea.Split(vbTab)
                index += 1

                num_lines += 1
                If datos.Length = 8 Then
                    If datos(5).Split(":")(0) = "Dlc" Then
                        value = datos(6).Split(":")(1)
                        If ids_chs.TryGetValue(value, id_ch) Then
                            data_points += 1
                            clock += 1
                            For Each x In id_ch
                                aux = hex_to_dec(datos(7).Split(":")(1))
                                res = read_string(aux, table_canbus(x))
                                res2 = res
                                val = CType(res, String)
                                val = val.Replace(",", ".")
                                t = CType(datos(0), Double)
                                tm = format_time2(t, div, time, milsec)
                                If table_canbus(x).average = True Then
                                    'inicializamos por primera vez los datos
                                    If table_canbus(x).time = "" Then
                                        table_canbus(x).time = tm
                                        table_canbus(x).value = res2
                                        table_canbus(x).count = 1
                                    Else
                                        'todavia estamos en la misma hora, sumamos los valores
                                        If table_canbus(x).time = tm Then
                                            table_canbus(x).value += res2
                                            table_canbus(x).count += 1
                                        Else
                                            If value = "970" And flag = False Then
                                                If val >= 10 Then
                                                    'hemos cambiado de hora, guardamos la media 
                                                    res = table_canbus(x).value / table_canbus(x).count
                                                    avg = CType(res, String)
                                                    avg = avg.Replace(",", ".")
                                                    aux = "(" & num_lines & ",'" & list.Items(x) & "'," & id_drive _
                                                    & "," & id_logger & "," & measure(x) & "," _
                                                    & "'" & FormatDateTime(table_canbus(x).time, DateFormat.LongTime) & "'" & "," _
                                                    & "NULL," & val & ")"
                                                    ins.set_string(aux)
                                                    flag = True
                                                End If
                                            Else
                                                'hemos cambiado de hora, guardamos la media 
                                                res = table_canbus(x).value / table_canbus(x).count
                                                avg = CType(res, String)
                                                avg = avg.Replace(",", ".")
                                                aux = "(" & num_lines & ",'" & list.Items(x) & "'," & id_drive _
                                                & "," & id_logger & "," & measure(x) & "," _
                                                & "'" & FormatDateTime(table_canbus(x).time, DateFormat.LongTime) & "'" & "," _
                                                & "NULL," & val & ")"
                                                ins.set_string(aux)
                                            End If
                                            'inicializamos el valor para el siguiente segundo
                                            table_canbus(x).time = tm
                                            table_canbus(x).value = res2
                                            table_canbus(x).count = 1
                                        End If
                                    End If
                                Else
                                    aux = "(" & num_lines & ",'" & list.Items(x) & "'," & id_drive _
                                    & "," & id_logger & "," & measure(x) & "," _
                                    & "'" & FormatDateTime(tm, DateFormat.LongTime) & "'" & ",'" _
                                    & milsec & "'," & val & ")"
                                    ins.set_string(aux)
                                End If

                            Next
                            progressbar(num_lines, bar, percent)
                        End If

                    End If
                End If
                If clock >= 1000 Then
                    If Not ins.is_empty Then
                        ins.insert_into_string()
                        ins.init_string()
                        clock = 1
                    End If
                End If
            End If
            linea = fichero.ReadLine
        Loop Until linea Is Nothing

        'hay que comprobar que valores quedan por ser importados porque el ultimo cambio de hora no se reconoce
        For Each x In list.CheckedIndices
            If table_canbus(x).average = True And table_canbus(x).time <> "" Then
                'guardamos la media 
                res = table_canbus(x).value / table_canbus(x).count
                avg = CType(res, String)
                avg = avg.Replace(",", ".")
                aux = "(" & num_lines & ",'" & list.Items(x) & "'," & id_drive _
                & "," & id_logger & "," & measure(x) & "," _
                & "'" & FormatDateTime(table_canbus(x).time, DateFormat.LongTime) & "'" & "," _
                & "NULL," & avg & ")"
                ins.set_string(aux)
            End If
        Next

        If Not ins.is_empty Then
            ins.insert_into_string()
        End If

    End Sub

    Private Function read_string(ByVal str As String, ByVal tb As str_canbus) As Double
        Dim i As Integer
        Dim res As Double
        Dim sq() As String
        Dim aux As String = ""

        sq = tb.sequence.Split("-")
        For Each i In sq
            aux += str(i)
        Next

        res = bin_to_dec(aux, tb.signed)
        res = res * tb.factor
        read_string = res

    End Function

    Private Function hex_to_dec(ByVal data As String) As String
        Dim res As String = ""
        For Each values In data.Split(" ")
            If values <> "" Then
                res += dec_to_bin(values)
            End If
        Next
        hex_to_dec = res
    End Function

    Private Function bin_to_dec(ByVal BinStr As String, ByVal sign As Boolean) As Double
        Dim mult As Double = 1
        Dim DecNum As Double = 0
        Dim s As String = 0
        If sign = True Then
            If BinStr(0) = "1" Then
                s = "-"
                BinStr = complement_plusone(BinStr)
            Else
                s = ""
            End If
        End If

        For i = Len(BinStr) To 1 Step -1
            If Mid(BinStr, i, 1) = "1" Then
                DecNum = DecNum + mult
            End If
            mult = mult * 2
        Next i
        s = s & DecNum
        bin_to_dec = s
    End Function

    Private Function complement_plusone(ByVal binstr As String) As String
        Dim res As String = ""
        For i = 0 To binstr.Length - 1
            If binstr(i) = "0" Then
                res += "1"
            Else
                res += "0"
            End If
        Next

        If res(res.Length - 1) = "0" Then
            res = res.Remove(res.Length - 1) & "1"
        Else
            res = res.Remove(res.Length - 2) & "10"
        End If

        complement_plusone = res
    End Function

    Private Function dec_to_bin(ByVal value As String) As String
        Dim BinStr As String
        BinStr = ""
        Do While value <> 0
            If (value Mod 2) = 1 Then
                BinStr = "1" & BinStr
            Else
                BinStr = "0" & BinStr
            End If
            value = value \ 2
        Loop
        BinStr = "00000000" & BinStr
        BinStr = BinStr.Substring(BinStr.Length - 8)
        dec_to_bin = BinStr
    End Function

    Public Sub clean_logger(ByRef list As CheckedListBox, ByRef text As TextBox, ByRef panel As Panel, _
                            ByRef path() As String, ByRef long_file() As Integer, ByRef length As Integer, _
                            ByRef check As CheckBox)
        panel.Visible = False
        list.Items.Clear()
        list.Visible = False
        text.Text = ""
        text.Visible = False
        path = Nothing
        long_file = Nothing
        check.Visible = False
        check.CheckState = CheckState.Unchecked
        length = 0
    End Sub

    Private Function time_gps(ByVal val As String) As Integer
        Dim localtime As System.TimeZoneInfo
        Dim d As DateTime
        localtime = TimeZoneInfo.Local
        d = FormatDateTime(val, DateFormat.GeneralDate)
        d = TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(d), localtime)
        Return d.Hour
    End Function

    Private Function make_date(ByVal day As String) As String
        Dim yyyy, mm, dd As String
        yyyy = "20" & day(0) & day(1)
        mm = day(2) & day(3)
        dd = day(4) & day(5)
        make_date = yyyy & "-" & mm & "-" & dd
    End Function

    Private Function make_time(ByVal time As String, ByVal h As Integer) As String
        Dim hh, mm, ss As String
        hh = time(0) & time(1)
        mm = time(2) & time(3)
        ss = time(4) & time(5)
        h = CType(hh, Integer) + h
        If h >= 24 Then
            h = h Mod 24
        End If
        hh = h
        make_time = hh & ":" & mm & ":" & ss
    End Function

    Private Function format_time(ByVal time As Double, ByVal unit As Integer, ByRef ini As String) As String
        Dim res As String
        Dim h, m, s, ss As Integer
        Dim format() As String
        h = m = s = 0
        format = ini.Split(":")
        h = format(0)
        m = format(1)
        ss = format(2)

        time = time / unit
        s = Math.Truncate(time)
        s = s + ss

        Do While (s >= 60)
            s = s - 60
            m += 1
            If m >= 60 Then
                Do While (m >= 60)
                    m = m - 60
                    h += 1
                Loop
            End If
        Loop

        If h >= 24 Then
            h = h Mod 24
        End If

        res = h & ":" & m & ":" & s

        format_time = CType(FormatDateTime(res, DateFormat.LongTime), String)
    End Function

    Private Function format_time2(ByVal time As Double, ByVal unit As Integer, _
                                  ByVal ini As String, ByRef milsec As String) As String
        Dim res As String
        Dim h, m, s, ss, rest As Double
        Dim format() As String
        ss = 0
        format = ini.Split(":")
        h = format(0)
        m = format(1)
        s = format(2)

        time = time / unit
        'rest = time Mod Math.Truncate(time)
        milsec = CType(time, String).Split(",")(1)
        ss = Math.Truncate(time)
        ss = ss + s

        m = m + Math.Truncate(ss / 60)
        s = ss Mod 60
        h = h + Math.Truncate(m / 60)
        m = m Mod 60

        If h >= 24 Then
            h = h Mod 24
        End If

        res = h & ":" & m & ":" & s

        format_time2 = CType(FormatDateTime(res, DateFormat.LongTime), String)
    End Function

    Private Function format_number(ByVal value As String) As Double
        Dim res As Double
        Dim exp, point As Integer

        exp = value.Split("E")(1)
        value = value.Split("E")(0).Trim
        point = value.IndexOf(".")
        value = value.Remove(point, 1)
        point += exp
        value = "0" & value.Insert(point, ",") & "0"
        res = value

        format_number = res
    End Function

    'configuracion del progressbar y labels que le acompañan
    Private Sub config_progressbar(ByRef bar As ProgressBar, ByVal max As Double, _
                                   ByVal list As CheckedListBox, ByRef n_data As Label)
        'n_data.Text = ""
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
            Dim dr As MySqlDataReader
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

    Private Function search_time_sync(ByVal sql As String) As String
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim res As String = ""

        cn.Open()
        cmd.Connection = cn
        cmd.CommandTimeout = 1000
        cmd.CommandText = sql
        query = cmd.ExecuteReader()
        If query.HasRows Then
            query.Read()
            res = query.GetString(0)
        Else
            res = ""
        End If
        cn.Close()
        search_time_sync = res
    End Function

End Class