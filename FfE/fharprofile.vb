Public Class fharprofile
    Public id As Integer
    Public col As Color
    Public fail As Boolean
    Public value() As Decimal
    Public isfinal As Boolean


    Public Sub New(ByVal id As Integer, ByVal C As Color, ByVal fail As Boolean, _
                   ByVal value() As Decimal, ByVal isfinal As Boolean)
        Me.id = id
        Me.col = c
        Me.fail = fail
        Me.value = value
        Me.isfinal = isfinal

        'Si el color está vacio lo inicializamos con ramdom
        If col = Nothing Then
            color = QBColor(Aleatorio(0, 15))

        End If
    End Sub


    Private Function Aleatorio(ByVal Minimo As Long, ByVal Maximo As Long) As Long
        Randomize()
        Aleatorio = CLng((Minimo - Maximo) * Rnd + Maximo)
    End Function
End Class
