Imports System.Windows.Forms

Public Class FfE_Main
    Public id_graphtec As Integer = -1
    Public id_gps As Integer = -1
    Public id_fluke As Integer = -1
    Public id_canbus As Integer = -1

    Private Sub CarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarToolStripMenuItem.Click
        Dim conf_car As New Form_Conf_Car

        conf_car.MdiParent = Me
        conf_car.Show()
    End Sub

    Private Sub UserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserToolStripMenuItem.Click
        Dim conf_user As New From_Conf_User

        conf_user.MdiParent = Me
        conf_user.Show()

    End Sub

    Private Sub ImToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim import_cvs_full As New form_import_csv_full

        import_cvs_full.MdiParent = Me
        import_cvs_full.id_drive = 1
        import_cvs_full.Show()

    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Dim drive As New Form_drive

        drive.MdiParent = Me
        drive.Show()
    End Sub

    Private Sub ConnectionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim form_conn As New Form_Connection

        'form_conn.MdiParent = Me
        form_conn.ShowDialog()
    End Sub

    Private Sub MeasureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MeasureToolStripMenuItem.Click
        Dim measure As New Form_Conf_Measure

        measure.MdiParent = Me
        measure.Show()
    End Sub


    Private Sub FahrprofileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FahrprofileToolStripMenuItem.Click
        Dim usage_type As New Form_conf_usage_type

        usage_type.MdiParent = Me
        usage_type.Show()
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
        Dim form_data As New Form_data
        form_data.MdiParent = Me
        form_data.Show()
    End Sub

    Private Sub ConnectionToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectionToolStripMenuItem2.Click
        Dim form_conn As New Form_Connection

        'form_conn.MdiParent = Me
        form_conn.ShowDialog()
    End Sub

    Private Sub IDTableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IDTableToolStripMenuItem.Click
        Dim form_canbus As New form_canbus_ids
        form_canbus.MdiParent = Me
        form_canbus.Show()
    End Sub
End Class
