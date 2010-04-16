Imports ZedGraph

Public Class fharprofilGraphic
    Dim listf As List(Of fharprofile)
    Dim typ As Integer

    Public Enum type As Integer
        km = 0
        speed = 1
        time = 2
    End Enum

    Public Sub New()
        Dim c As Color = Color.Coral
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal l As List(Of fharprofile), ByVal t As type)
        Me.New()

        listf = l
        typ = t
    End Sub


    Private Sub fharprofilGraphic_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case typ
            Case type.km
                ShowKm()
            Case type.speed
                'ShowSpeed()
            Case type.time
                'ShowTime()
        End Select
    End Sub


    Private Sub ShowKm()
        Dim myPane As New GraphPane(Pane.GraphPane)

        myPane.Title.Text = "Show Km"
        myPane.YAxis.Title.Text = "km"
        myPane.XAxis.Title.Text = "Id Drive"

        Dim labels As New List(Of String)
        Dim x As New List(Of Decimal)
        For Each ele In listf
            labels.Add(ele.id)
            x.Add(ele.value(type.km))
        Next


        'Draw the Y tics between the labels instead of at the labels
        myPane.YAxis.MajorTic.IsBetweenLabels = True

        'Set the YAxis labels
        myPane.YAxis.Scale.TextLabels = labels.ToArray

        'Set the YAxis to Text type
        myPane.YAxis.Type = AxisType.Text

        'Set the bar type to stack, which stacks the bars by automatically accumulating the values
        myPane.BarSettings.Type = BarType.Stack
        '
        'Make the bars horizontal by setting the BarBase to "Y"
        myPane.BarSettings.Base = BarBase.Y

        'Fill the axis background with a color gradient
        myPane.Chart.Fill = New Fill(Color.White, Color.FromArgb(255, 255, 166), 45.0F)

        Pane.AxisChange()

        'Pane.GraphPane = myPane
    End Sub

End Class
