Imports ZedGraph

Public Class fharprofilGraphic
    Dim listf As List(Of fharprofile)
    Dim Xtitle As String
    Dim labels() As String

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

    Public Sub New(ByVal l As List(Of fharprofile), ByVal Xtitle As String, _
                   ByVal labels() As String)
        Me.New()
        Me.listf = l
        Me.Xtitle = Xtitle
        Me.labels = labels
    End Sub


    Private Sub fharprofilGraphic_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        show_histogram()

        'Select Case typ
        '   Case type.km
        'ShowKm()
        '   Case type.speed
        'ShowSpeed()
        '   Case type.time
        'ShowTime()
        ' End Select
    End Sub


    Private Sub ShowKm()
        myPane.GraphPane.Title.Text = "Km"
        myPane.GraphPane.YAxis.Title.Text = "km"
        myPane.GraphPane.XAxis.Title.Text = "Drives"

        Dim i As Integer = 10
        For Each ele In listf
            ' Generate a red bar with "Curve 1" in the legend
            Dim myCurve As BarItem = myPane.GraphPane.AddBar(ele.id, Nothing, New Double() {ele.value(type.km)}, Nothing)
            ' Fill the bar with a red-white-red color gradient for a 3d look
            myCurve.Bar.Fill = New Fill(ele.colour, Color.White, ele.colour)
            i = i + 10
        Next

        ' Draw the X tics between the labels instead of at the labels
        myPane.GraphPane.XAxis.MajorTic.IsBetweenLabels = False

        ' Set the XAxis to Text type
        myPane.GraphPane.XAxis.Type = AxisType.Text

        ' Set the bar type to stack, which stacks the bars by automatically accumulating the values
        myPane.GraphPane.BarSettings.Type = BarType.Cluster

        myPane.AxisChange()
    End Sub

    Private Sub ShowSpeed()
        myPane.GraphPane.Title.Text = "Speed"
        myPane.GraphPane.YAxis.Title.Text = "Speed"
        myPane.GraphPane.XAxis.Title.Text = "Drives"

        Dim i As Integer = 10
        For Each ele In listf
            ' Generate a red bar with "Curve 1" in the legend
            Dim myCurve As BarItem = myPane.GraphPane.AddBar(ele.id, Nothing, New Double() {ele.value(type.speed)}, Nothing)
            ' Fill the bar with a red-white-red color gradient for a 3d look
            myCurve.Bar.Fill = New Fill(ele.colour, Color.White, ele.colour)
            i = i + 10
        Next

        ' Draw the X tics between the labels instead of at the labels
        myPane.GraphPane.XAxis.MajorTic.IsBetweenLabels = True

        ' Set the XAxis to Text type
        myPane.GraphPane.XAxis.Type = AxisType.Text

        ' Set the bar type to stack, which stacks the bars by automatically accumulating the values
        myPane.GraphPane.BarSettings.Type = BarType.Cluster

        myPane.AxisChange()
    End Sub

    Private Sub ShowTime()
        myPane.GraphPane.Title.Text = "Time"
        myPane.GraphPane.YAxis.Title.Text = "Time(seconds)"
        myPane.GraphPane.XAxis.Title.Text = "Drives"

        Dim i As Integer = 10
        For Each ele In listf
            ' Generate a red bar with "Curve 1" in the legend
            Dim myCurve As BarItem = myPane.GraphPane.AddBar(ele.id, Nothing, New Double() {ele.value(type.time)}, Nothing)
            ' Fill the bar with a red-white-red color gradient for a 3d look
            myCurve.Bar.Fill = New Fill(ele.colour, Color.White, ele.colour)
            i = i + 10
        Next

        ' Draw the X tics between the labels instead of at the labels
        myPane.GraphPane.XAxis.MajorTic.IsBetweenLabels = True

        ' Set the XAxis to Text type
        myPane.GraphPane.XAxis.Type = AxisType.Text

        ' Set the bar type to stack, which stacks the bars by automatically accumulating the values
        myPane.GraphPane.BarSettings.Type = BarType.Cluster

        myPane.AxisChange()
    End Sub

    Private Sub show_histogram()

        myPane.GraphPane.Title.Text = "Histogram"
        myPane.GraphPane.YAxis.Title.Text = "Frequency"
        myPane.GraphPane.XAxis.Title.Text = Xtitle
        For Each ele In listf
            Dim myCurve As BarItem = myPane.GraphPane.AddBar(ele.id, Nothing, ele.value, Nothing)
            myCurve.Bar.Fill = New Fill(ele.colour, Color.White, ele.colour)
        Next
        'Draw the X tics between the labels instead of at the labels
        myPane.GraphPane.XAxis.MajorTic.IsBetweenLabels = True

        'Set the XAxis to Text type
        myPane.GraphPane.XAxis.Type = AxisType.Text
        'Set the XAxis labels

        myPane.GraphPane.XAxis.Scale.TextLabels = labels
        myPane.GraphPane.XAxis.Scale.FontSpec.Size = 10.0F

        myPane.GraphPane.BarSettings.Type = BarType.Stack
        myPane.GraphPane.BarSettings.MinClusterGap = 0

        myPane.GraphPane.AxisChange()

    End Sub

End Class
