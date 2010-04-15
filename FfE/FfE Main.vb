Imports System.Windows.Forms

Public Class FfE_Main
    Public id_graphtec As Integer = -1
    Public id_gps As Integer = -1
    Public id_fluke As Integer = -1
    Public id_canbus As Integer = -1

    Private Sub CarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarToolStripMenuItem.Click
        Form_Conf_Car.MdiParent = Me
        Form_Conf_Car.Show()
        Form_Conf_Car.Focus()

    End Sub

    Private Sub UserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserToolStripMenuItem.Click
        From_Conf_User.MdiParent = Me
        From_Conf_User.Show()
        From_Conf_User.Focus()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Form_drive.MdiParent = Me
        Form_drive.Show()
        Form_drive.Focus()
    End Sub

    Private Sub MeasureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MeasureToolStripMenuItem.Click
        Dim measure As New Form_Conf_Measure

        measure.MdiParent = Me
        measure.Show()
    End Sub


    Private Sub FahrprofileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FahrprofileToolStripMenuItem.Click
        Form_conf_usage_type.MdiParent = Me
        Form_conf_usage_type.Show()
        Form_conf_usage_type.Focus()
    End Sub

    Private Sub FfE_Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim conection As New MySql.Data.MySqlClient.MySqlConnection(Global.FfE.My.MySettings.Default.ffe_databaseConnectionString())
            conection.Open()
            conection.Close()
            Dim get_id As New logger
            id_graphtec = get_id.get_logger_id("GRAPHTEC GL800")
            id_gps = get_id.get_logger_id("COLUMBUS GPS")
            id_fluke = get_id.get_logger_id("LMG 500")
            id_canbus = get_id.get_logger_id("CAN-BUS")
        Catch ex As Exception
            Dim conf_conection As New Form_Connection
            conf_conection.ShowDialog()
        End Try
    End Sub

    Private Sub DataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataToolStripMenuItem.Click
        Form_data.MdiParent = Me
        Form_data.Show()
        Form_data.Focus()
    End Sub

    Private Sub ConnectionToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectionToolStripMenuItem2.Click
        Dim form_conn As New Form_Connection

        'form_conn.MdiParent = Me
        form_conn.ShowDialog()
    End Sub

    Private Sub ChannelsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChannelsToolStripMenuItem.Click
        form_canbus_ids.MdiParent = Me
        form_canbus_ids.Show()
        form_canbus_ids.Focus()
    End Sub

    Private Sub RestoreDBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreDBToolStripMenuItem.Click
        'Form_restore_DB.MdiParent = Me
        'Form_restore_DB.Show()
        'Form_restore_DB.Focus()
    End Sub

    Private Sub BackupDBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupDBToolStripMenuItem.Click
        Form_backup_DB.MdiParent = Me
        Form_backup_DB.Show()
        Form_backup_DB.Focus()
    End Sub
End Class
