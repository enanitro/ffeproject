Public Class fharprofile
    Public id As Integer
    Public colour As Color
    Public fail As Boolean
    Public value() As Decimal
    Public isfinal As Boolean


    Public Sub New(ByVal id As Integer, ByVal fail As Boolean, _
                   ByVal value() As Decimal, ByVal isfinal As Boolean)
        Me.id = id
        Me.fail = fail
        Me.value = value
        Me.isfinal = isfinal
        Dim c As New ColorConverter
        If Not isfinal Then
            colour = System.Drawing.Color.FromArgb(255, Aleatorio, Aleatorio, Aleatorio)
        Else
            colour = Color.Green
        End If

    End Sub


    Private Function Aleatorio(Optional ByVal Minimo As Short = 0, Optional ByVal Maximo As Short = 255) As Short
        Randomize()
        Aleatorio = CShort((Minimo - Maximo) * Rnd() + Maximo)
    End Function
End Class
