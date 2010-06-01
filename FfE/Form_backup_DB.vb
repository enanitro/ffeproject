Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_backup_DB
    Dim db As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        Label1.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub Form_backup_DB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        write_database()
        clean_labels()
    End Sub

    Private Sub write_database()
        Dim cadena As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim fields() As String
        fields = cadena.Split(";")
        db = fields(5).Split("=")(1)
        GroupBox1.Text = db
    End Sub

    Private Sub clean_labels()
        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""
        Label4.Text = ""
        ProgressBar1.Visible = False
    End Sub

    Private Function backup_file() As String
        Dim res As String
        res = DateTime.Now.ToString("yyyyMMdd_HHmmss") & "_ESF_DB_Backup.sql"
        backup_file = res
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Label1.Text = "" Then
            MsgBox("Folder doesn't exist", MsgBoxStyle.Exclamation)
        Else
            Label2.Text = backup_file()
            start_backup(Label1.Text & "\" & Label2.Text)
        End If
    End Sub

    Private Sub start_backup(ByVal path As String)
        Dim sw As New System.IO.StreamWriter(path)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim res, sql As String

        Try
            Dim lock_tables As String = "lock tables car write, user write, measure write, usage_type write, " & _
                          "drive write, data write, photos write, " & _
                          "channel_name write, ids_canbus write, logger write;"

            sw.WriteLine("-- " & path)
            sw.WriteLine()
            sw.Close()

            If CheckBox0.Checked = True Then create_query("logger", path)
            If CheckBox1.Checked = True Then create_query("user", path)
            If CheckBox2.Checked = True Then
                create_query("car", path)
                create_query("photos", path)
            End If
            If CheckBox3.Checked = True Then create_query("measure", path)
            If CheckBox4.Checked = True Then create_query("usage_type", path)
            If CheckBox5.Checked = True Then create_query("drive", path)
            If CheckBox6.Checked = True Then
                create_query("data", path)
                create_query("channel_name", path)
                create_query("ids_canbus", path)
            End If

            Dim sr As New System.IO.StreamWriter(path, True)
            sr.WriteLine("exit")
            sr.Close()

            MsgBox("Backup completed successfully", MsgBoxStyle.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clean_labels()
            cn.Close()
        End Try
    End Sub


    Private Sub create_query(ByVal table As String, ByVal path As String)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        ' nueva conexión indicando al SqlConnection la cadena de conexión  
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim res, value, text, head1, head2 As String

        cn.Open()
        cmd.CommandTimeout = 1000
        cmd.Connection = cn
        cmd.CommandText = "desc " & table
        query = cmd.ExecuteReader()
        If query.HasRows() Then
            text = "select concat('(',"
            head2 = "insert into " & table & "("
            head1 = "-- " & db & "." & table & vbCrLf & "delete from " & db & "." & table & ";"
            While query.Read
                res = query.GetString(1).Substring(0, 3)
                value = query.GetString(0)
                head2 += value & ","
                Select Case res
                    Case "int", "dec", "bol", "tin"
                        text += "if (" & value & " is null,'NULL'," & value & "),',',"
                    Case "var", "tim", "dat"
                        text += "if (" & value & " is null,'NULL',concat(''''," & value & ",'''')),',',"
                    Case "med"
                        text += "'NULL',',',"
                End Select
            End While
            text = text.Substring(0, text.Length - 4) & "')') from " & table
            head2 = head2.TrimEnd(",") & ") values "
            execute_query_backup(text, path, table, head1, head2)
        End If
        cn.Close()
    End Sub


    Private Sub execute_query_backup(ByVal sql As String, ByVal path As String, ByVal table As String, _
                                     ByVal head1 As String, ByVal head2 As String)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sw As New System.IO.StreamWriter(path, True)
        Dim res As String = ""
        Dim lock_tables As String = "lock tables car write, user write, measure write, usage_type write, " & _
                          "drive write, data write, photos write, " & _
                          "channel_name write, ids_canbus write, logger write;"
        Dim i As Integer = 0

        Label3.Text = "Importing table " & table.ToUpper
        Application.DoEvents()
        System.Threading.Thread.Sleep(1500)
        cn.Open()
        cmd.CommandTimeout = 1000
        cmd.Connection = cn
        cmd.CommandText = lock_tables
        cmd.ExecuteNonQuery()

        cmd.CommandTimeout = 1000
        cmd.Connection = cn
        cmd.CommandText = "select count(*) from " & table
        query = cmd.ExecuteReader()
        If query.HasRows Then
            query.Read()
            config_progressbar(ProgressBar1, query.GetValue(0))

            query.Close()
            cmd.CommandTimeout = 1000
            cmd.Connection = cn
            cmd.CommandText = sql
            query = cmd.ExecuteReader()

            Dim count As Integer = 0
            If query.HasRows Then
                sw.WriteLine(head1)
                While query.Read()
                    res += query.GetString(0) & ","
                    i += 1
                    count += 1
                    progressbar(count, ProgressBar1, Label4.Text)
                    If i >= 1000 Then
                        res = res.Remove(res.Length - 1) & ";" & vbCrLf
                        sw.Write(head2 & res)
                        res = ""
                        i = 0
                    End If
                    Application.DoEvents()
                End While
                If res <> "" Then
                    res = res.Remove(res.Length - 1) & ";" & vbCrLf
                    sw.Write(head2 & res)
                End If
                sw.WriteLine()
            End If
        End If

        query.Close()
        cmd.CommandTimeout = 1000
        cmd.Connection = cn
        cmd.CommandText = "unlock tables;"
        cmd.ExecuteNonQuery()
        Application.DoEvents()
        System.Threading.Thread.Sleep(1500)

        cn.Close()
        sw.Close()

    End Sub

    'configuracion del progressbar y labels que le acompañan
    Private Sub config_progressbar(ByRef bar As ProgressBar, ByVal max As Double)
        bar.Visible = True
        bar.Minimum = 0
        bar.Maximum = max
    End Sub

    'controla el objeto progressbar
    Private Sub progressbar(ByVal val As Integer, ByRef bar As ProgressBar, ByRef percent As String)
        bar.Value = val
        percent = CLng((bar.Value * 100) / bar.Maximum) & " %"
        Application.DoEvents()
    End Sub

    Private Sub start_backup2(ByVal path As String)
        Dim sw As New System.IO.StreamWriter(path)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim res, sql As String

        Try
            Dim lock_tables As String = "lock tables car write, user write, measure write, usage_type write, " & _
                          "drive write, data write, photos write, " & _
                          "channel_name write, ids_canbus write, logger write;"

            sw.WriteLine("-- " & path)
            sw.WriteLine(vbCrLf)
            sw.Close()


            execute_query_backup("select concat('(',logger_id,','," & _
                                 "if(name is null,'NULL',concat('''',name,'''')),','," & _
                                 "if(description is null,'NULL',concat('''',description,''''))," & _
                                 "')') from logger;", path, "logger", _
                                 "-- ffe_database.logger " & vbCrLf & "delete from logger;" & vbCrLf, _
                                 "insert into logger(logger_id,name,description) values ")


            execute_query_backup("select concat('(',car_id,','," & _
                                 "if(name is null,'NULL',concat('''',name,'''')),','," & _
                                 "if(type is null,'NULL',concat('''',type,'''')),','," & _
                                 "if(license_plate is null,'NULL',concat('''',license_plate,'''')),','," & _
                                 "if(owner is null,'NULL',concat('''',owner,'''')),','," & _
                                 "'NULL',')') from car;", path, "car", _
                                 "-- ffe_database.car " & vbCrLf & "delete from car;" & vbCrLf, _
                                 "insert into car(car_id,name,type,license_plate,owner,photo) values ")


            execute_query_backup("select concat('(',usage_type_id,','," & _
                                 "if(name is null,'NULL',concat('''',name,'''')),','," & _
                                 "if(description is null,'NULL',concat('''',description,'''')),','," & _
                                 "if(usage_in_project is null,'NULL',concat('''',usage_in_project,''''))," & _
                                 "')') from usage_type;", path, "usage_type", _
                                 "-- ffe_database.usage_type " & vbCrLf & "delete from usage_type;" & vbCrLf, _
                                 "insert into usage_type(usage_type_id,name,description,usage_in_project) values ")


            execute_query_backup("select concat('(',user_id,','," & _
                                 "if(vorname is null,'NULL',concat('''',vorname,'''')),','," & _
                                 "if(name is null,'NULL',concat('''',name,'''')),','," & _
                                 "if(email is null,'NULL',concat('''',email,'''')),','," & _
                                 "if(link is null,'NULL',concat('''',link,'''')),','," & _
                                 "if(ma_art is null,'NULL',concat('''',ma_art,'''')),','," & _
                                 "'NULL',')') from user;", path, "user", _
                                 "-- ffe_database.user " & vbCrLf & "delete from user;" & vbCrLf, _
                                 "insert into user(user_id,vorname,name,email,link,ma_art,photo) values ")


            execute_query_backup("select concat('(',measure_id,','," & _
                                 "if(name is null,'NULL',concat('''',name,'''')),','," & _
                                 "if(timestep is null,'NULL',concat('''',timestep,'''')),','," & _
                                 "if(unit is null,'NULL',concat('''',unit,'''')),','," & _
                                 "if(description is null,'NULL',concat('''',description,''''))," & _
                                 "')') from measure;", path, "measure", _
                                 "-- ffe_database.measure " & vbCrLf & "delete from measure;" & vbCrLf, _
                                 "insert into measure(measure_id,name,timestep,unit,description) values ")


            execute_query_backup("select concat('(',drive_id,','," & _
                                 "if(status is null,'NULL',concat('''',status,'''')),','," & _
                                 "if(climate is null,'NULL',concat('''',climate,'''')),','," & _
                                 "if(date is null,'NULL',concat('''',date,'''')),','," & _
                                 "if(description is null,'NULL',concat('''',description,'''')),','," & _
                                 "if(usage_type_id is null,'NULL',usage_type_id),','," & _
                                 "if(driver_id is null,'NULL',driver_id),','," & _
                                 "if(importer_id is null,'NULL',importer_id),','," & _
                                 "if(car_id is null,'NULL',car_id),','," & _
                                 "if(drive_type is null,'NULL',concat('''',drive_type,''''))," & _
                                 "')') from drive;", path, "drive", _
                                 "-- ffe_database.drive " & vbCrLf & "delete from drive;" & vbCrLf, _
                                 "insert into drive(drive_id,status,climate,date,description,usage_type_id," & _
                                 "driver_id,importer_id,car_id,drive_type) values ")


            execute_query_backup("select concat('(',data_index,',''',data_id,''',',drive_id,',',logger_id,','" & _
                                ",measure_id,',''',time,''',',value,')') from data;", path, "data", _
                                "-- ffe_database.data " & vbCrLf & "delete from data;" & vbCrLf, _
                                "insert into data(data_index,data_id,drive_id,logger_id,measure_id,time,value) values ")


            'execute_query_backup("select concat('(',data_index,',''',data_id,''',',drive_id,',',logger_id,','" & _
            '                    ",measure_id,',''',time,''',',value,')') from copy_data;", path, "copy_data", _
            '                    "-- ffe_database.copy_data " & vbCrLf & "delete from copy_data;", _
            '                    "insert into copy_data(data_index,data_id,drive_id,logger_id,measure_id,time,value) values ")


            execute_query_backup("select concat('(',photo_id,','," & _
                                 "if(car_id is null,'NULL',car_id),','," & _
                                 "if(path is null,'NULL',concat('''',path,'''')),','," & _
                                 "'NULL',')') from photos;", path, "photos", _
                                 "-- ffe_database.photos " & vbCrLf & "delete from photos;" & vbCrLf, _
                                 "insert into photos(photo_id,car_id,path,photo) values ")


            execute_query_backup("select concat('(',logger_id,','," & _
                                 "if(channel is null,'NULL',concat('''',channel,'''')),','," & _
                                 "if(name is null,'NULL',concat('''',name,'''')),','," & _
                                 "if(measure_id is null,'NULL',measure_id)," & _
                                 "')') from channel_name;", path, "channel_name", _
                                 "-- ffe_database.channel_name " & vbCrLf & "delete from channel_name;" & vbCrLf, _
                                 "insert into channel_name(logger_id,channel,name,measure_id) values ")


            execute_query_backup("select concat('(',channel_id,','," & _
                                 "if(hex_id is null,'NULL',concat('''',hex_id,'''')),','," & _
                                 "if(dec_id is null,'NULL',dec_id),','," & _
                                 "if(name is null,'NULL',concat('''',name,'''')),','," & _
                                 "if(startbit is null,'NULL',startbit),','," & _
                                 "if(longbits is null,'NULL',longbits),','," & _
                                 "if(sequence is null,'NULL',concat('''',sequence,'''')),','," & _
                                 "if(signed is null,'NULL',concat('''',signed,'''')),','," & _
                                 "if(factor is null,'NULL',factor),','," & _
                                 "if(offset is null,'NULL',offset)," & _
                                 "')') from ids_canbus;", path, "ids_canbus", _
                                 "-- ffe_database.ids_canbus " & vbCrLf & "delete from ids_canbus;" & vbCrLf, _
                                 "insert into ids_canbus(channel_id,hex_id,dec_id,name,startbit,longbits," & _
                                 "sequence,signed,factor,offset) values ")

            Dim sr As New System.IO.StreamWriter(path, True)
            sr.WriteLine("exit;")
            sr.Close()

            MsgBox("Backup completed successfully", MsgBoxStyle.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clean_labels()
            cn.Close()
        End Try
    End Sub

End Class