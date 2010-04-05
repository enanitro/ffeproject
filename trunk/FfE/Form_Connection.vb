Public Class Form_Connection

    Private Sub Form_Connection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cadena As String = Global.FfE.My.MySettings.Default.ffe_databaseConnectionString
        Dim campos() As String

        campos = cadena.Split(";")
        Me.txt_host.Text = campos(0).Split("=")(1)
        Me.txt_port.Text = campos(1).Split("=")(1)
        Me.txt_user.Text = campos(2).Split("=")(1)
        Me.txt_password.Text = campos(3).Split("=")(1)
        Me.txt_database.Text = campos(5).Split("=")(1)
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Dim appCfg As New cAppConfig
        Dim Conexion As String
        'Selecciono el Tipo de Archivo de Configuracion Web/App
        appCfg.ConfigType = Convert.ToInt32(ConfigFileType.AppConfig)


        Conexion = "server=" & Me.txt_host.Text & ";" & _
                   "Port=" & Me.txt_port.Text & ";" & _
                   "User Id=" & Me.txt_user.Text & ";" & _
                   "password=" & Me.txt_password.Text & ";" & _
                   "Persist Security Info=True;" & _
                   "database=" & Me.txt_database.Text
        appCfg.removeElement("FfE.My.MySettings.ffe_databaseConnectionString")
        appCfg.SetValue("connectionStrings", Conexion)

        Global.FfE.My.MySettings.Default.ffe_databaseConnectionString = Conexion
        'Form_Connection_Load(Me, e)
        If test() Then
            Dim get_id As New logger
            FfE_Main.id_graphtec = get_id.get_logger_id("GRAPHTEC GL800")
            FfE_Main.id_gps = get_id.get_logger_id("COLUMBUS GPS")
            FfE_Main.id_fluke = get_id.get_logger_id("LMG 500")
            FfE_Main.id_canbus = get_id.get_logger_id("CAN-BUS")
        End If
    End Sub

    Function test() As Boolean
        Try
            Dim conexion As New MySql.Data.MySqlClient.MySqlConnection(Global.FfE.My.MySettings.Default.ffe_databaseConnectionString)
            conexion.Open()
            conexion.Close()
            MsgBox("Connection successful", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Test connection")
            test = True
        Catch ex As Exception
            MsgBox("Connection failed", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Test connection")
            test = False
        End Try
    End Function
End Class