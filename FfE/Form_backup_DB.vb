Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form_backup_DB

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        Label1.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub Form_backup_DB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clean_labels()
    End Sub

    Private Sub clean_labels()
        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""
        Label4.Text = ""
    End Sub

    Private Function backup_file() As String
        Dim res As String
        res = DateTime.Now.ToString("yyyyMMdd_HHmmss") & "_ESF_DB_Backup.txt"
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
        Dim res, sql As String

        Try
            Dim lock_tables As String = "lock tables car write, user write, measure write, usage_type write, " & _
                          "drive write, data write, copy_data write, photos write, " & _
                          "channel_name write, ids_canbus write, logger write;"
            cn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cn
            'cmd.CommandText = lock_tables
            'cmd.ExecuteNonQuery()

            sw.WriteLine("-- " & path)
            sw.WriteLine(vbCrLf)
            sw.Close()


            execute_query_backup("select concat('(',logger_id,','," & _
                                 "if(name is null,'NULL',concat('''',name,'''')),','," & _
                                 "if(description is null,'NULL',concat('''',description,''''))," & _
                                 "')') from logger;", path, _
                                 "-- ffe_database.logger --" & vbCrLf & "delete from logger;" & vbCrLf & _
                                 "insert into logger(logger_id,name,description) values ")


            execute_query_backup("select concat('(',car_id,','," & _
                                 "if(name is null,'NULL',concat('''',name,'''')),','," & _
                                 "if(type is null,'NULL',concat('''',type,'''')),','," & _
                                 "if(license_plate is null,'NULL',concat('''',license_plate,'''')),','," & _
                                 "if(owner is null,'NULL',concat('''',owner,'''')),','," & _
                                 "'NULL',')') from car;", path, _
                                 "-- ffe_database.car --" & vbCrLf & "delete from car;" & vbCrLf & _
                                 "insert into car(car_id,name,type,license_plate,owner,photo) values ")


            execute_query_backup("select concat('(',usage_type_id,','," & _
                                 "if(name is null,'NULL',concat('''',name,'''')),','," & _
                                 "if(description is null,'NULL',concat('''',description,'''')),','," & _
                                 "if(usage_in_project is null,'NULL',concat('''',usage_in_project,''''))," & _
                                 "')') from usage_type;", path, _
                                 "-- ffe_database.usage_type --" & vbCrLf & "delete from usage_type;" & vbCrLf & _
                                 "insert into usage_type(usage_type_id,name,description,usage_in_project) values ")


            execute_query_backup("select concat('(',user_id,','," & _
                                 "if(vorname is null,'NULL',concat('''',vorname,'''')),','," & _
                                 "if(name is null,'NULL',concat('''',name,'''')),','," & _
                                 "if(email is null,'NULL',concat('''',email,'''')),','," & _
                                 "if(link is null,'NULL',concat('''',link,'''')),','," & _
                                 "if(ma_art is null,'NULL',concat('''',ma_art,'''')),','," & _
                                 "'NULL',')') from user;", path, _
                                 "-- ffe_database.user --" & vbCrLf & "delete from user;" & vbCrLf & _
                                 "insert into user(user_id,vorname,name,email,link,ma_art,photo) values ")


            execute_query_backup("select concat('(',measure_id,','," & _
                                 "if(name is null,'NULL',concat('''',name,'''')),','," & _
                                 "if(timestep is null,'NULL',concat('''',timestep,'''')),','," & _
                                 "if(unit is null,'NULL',concat('''',unit,'''')),','," & _
                                 "if(description is null,'NULL',concat('''',description,''''))," & _
                                 "')') from measure;", path, _
                                 "-- ffe_database.measure --" & vbCrLf & "delete from measure;" & vbCrLf & _
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
                                 "')') from drive;", path, _
                                 "-- ffe_database.drive --" & vbCrLf & "delete from drive;" & vbCrLf & _
                                 "insert into drive(drive_id,status,climate,date,description,usage_type_id," & _
                                 "driver_id,importer_id,car_id,drive_type) values ")


            execute_query_backup("select concat('(',data_index,',''',data_id,''',',drive_id,',',logger_id,','" & _
                                ",measure_id,',''',time,''',',value,')') from data;", path, _
                                "-- ffe_database.data --" & vbCrLf & "delete from data;" & vbCrLf & _
                                "insert into data(data_index,data_id,drive_id,logger_id,measure_id,time,value) values ")


            execute_query_backup("select concat('(',data_index,',''',data_id,''',',drive_id,',',logger_id,','" & _
                                ",measure_id,',''',time,''',',value,')') from copy_data;", path, _
                                "-- ffe_database.copy_data --" & vbCrLf & "delete from copy_data;" & _
                                "insert into copy_data(data_index,data_id,drive_id,logger_id,measure_id,time,value) values ")


            execute_query_backup("select concat('(',photo_id,','," & _
                                 "if(car_id is null,'NULL',car_id),','," & _
                                 "if(path is null,'NULL',concat('''',path,'''')),','," & _
                                 "'NULL',')') from photos;", path, _
                                 "-- ffe_database.photos --" & vbCrLf & "delete from photos;" & vbCrLf & _
                                 "insert into photos(photo_id,car_id,path,photo) values ")


            execute_query_backup("select concat('(',logger_id,','," & _
                                 "if(channel is null,'NULL',concat('''',channel,'''')),','," & _
                                 "if(name is null,'NULL',concat('''',name,'''')),','," & _
                                 "if(measure_id is null,'NULL',measure_id)," & _
                                 "')') from channel_name;", path, _
                                 "-- ffe_database.channel_name --" & vbCrLf & "delete from channel_name;" & vbCrLf & _
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
                                 "')') from ids_canbus;", path, _
                                 "-- ffe_database.ids_canbus --" & vbCrLf & "delete from ids_canbus;" & vbCrLf & _
                                 "insert into ids_canbus(channel_id,hex_id,dec_id,name,startbit,longbits," & _
                                 "sequence,signed,factor,offset) values ")

            Dim sr As New System.IO.StreamWriter(path, True)
            sr.WriteLine("exit;")
            sr.Close()

            MsgBox("Backup completed successfully", MsgBoxStyle.Information)

            cmd.CommandText = "unlock tables;"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clean_labels()
            cn.Close()
        End Try
    End Sub

    Private Sub execute_query_backup(ByVal sql As String, ByVal path As String, ByVal head As String)
        Dim connection As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim cn As New MySqlConnection(connection)
        Dim cmd As New MySqlCommand
        Dim query As MySqlDataReader
        Dim sw As New System.IO.StreamWriter(path, True)
        Dim res As String = ""
        Dim lock_tables As String = "lock tables car write, user write, measure write, usage_type write, " & _
                          "drive write, data write, copy_data write, photos write, " & _
                          "channel_name write, ids_canbus write, logger write;"
        Dim i As Integer = 0

        Label3.Text = "Importing table " & head.Split(".")(1).Split("-")(0).ToUpper
        Application.DoEvents()
        System.Threading.Thread.Sleep(1500)
        cn.Open()
        cmd.CommandTimeout = 1000
        cmd.Connection = cn
        cmd.CommandText = lock_tables
        cmd.ExecuteNonQuery()

        cmd.CommandTimeout = 1000
        cmd.Connection = cn
        cmd.CommandText = "select count(*) from " & head.Split(".")(1).Split("-")(0)
        query = cmd.ExecuteReader()
        If query.HasRows Then
            query.Read()
            config_progressbar(ProgressBar1, query.GetValue(0))

            query.Close()
            cmd.CommandTimeout = 1000
            cmd.Connection = cn
            cmd.CommandText = sql
            query = cmd.ExecuteReader()

            If query.HasRows Then
                While query.Read()
                    res += query.GetString(0) & "," & vbCrLf
                    i += 1
                    progressbar(i, ProgressBar1, Label3.Text)

                    If i >= 1000 Then
                        sw.WriteLine(head)
                        res = res.Remove(res.Length - 3) & ";" & vbCrLf & "commit;" & vbCrLf
                        sw.Write(res)
                        res = ""
                        i = 0
                    End If
                    Application.DoEvents()
                End While
                If res <> "" Then
                    sw.WriteLine(head)
                    res = res.Remove(res.Length - 3) & ";" & vbCrLf & "commit;" & vbCrLf
                    sw.Write(res)
                End If
            End If
            sw.WriteLine(vbCrLf)
        End If

        cn.Close()
        sw.Close()

    End Sub

    'configuracion del progressbar y labels que le acompañan
    Private Sub config_progressbar(ByRef bar As ProgressBar, ByVal max As Double)
        bar.Minimum = 0
        bar.Maximum = max
    End Sub

    'controla el objeto progressbar
    Private Sub progressbar(ByVal val As Integer, ByRef bar As ProgressBar, ByRef percent As String)
        bar.Value = val
        percent = CLng((bar.Value * 100) / bar.Maximum) & " %"
        Application.DoEvents()
    End Sub

End Class