Public Class fahrprofile
    Public id As String
    Public colour As Color
    Public fail As Boolean
    Public value() As Double
    Public isfinal As Boolean


    Public Sub New(ByVal id As String, ByVal fail As Boolean, ByVal colour As Color, _
                   ByVal value() As Double, ByVal isfinal As Boolean)
        Me.id = id
        Me.fail = fail
        Me.value = value
        Me.isfinal = isfinal
        Me.colour = colour
        Dim c As New ColorConverter
        If isfinal Then
            Me.colour = Color.Green
            Me.id = id & "(final)"
        End If

    End Sub


    Private Function Aleatorio(Optional ByVal Minimo As Short = 0, Optional ByVal Maximo As Short = 255) As Short
        Randomize()
        Aleatorio = CShort((Minimo - Maximo) * Rnd() + Maximo)
    End Function
End Class


'Funcion que genera colores a partir de los colores del sistema
Public Class Colours
    Dim allColors() As KnownColor
    Dim pos As Integer

    Public Sub New()
        Dim colorsArray As Array
        colorsArray = [Enum].GetValues(GetType(KnownColor))
        ReDim allColors(colorsArray.Length)

        Array.Copy(colorsArray, allColors, colorsArray.Length)

        'Posicion del color actual
        pos = 0
    End Sub

    Public Function getColor() As Color
        getColor = Color.FromKnownColor(Me.allColors(pos))
    End Function

    Public Function getNexColor() As Color
        pos = (pos + 1) Mod allColors.Length
        If pos = 79 Then
            pos += 1 'Aseguramos que el color verde no se asinga
        End If
        getNexColor = Color.FromKnownColor(Me.allColors(pos))
    End Function
End Class
