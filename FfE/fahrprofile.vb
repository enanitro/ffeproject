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
        Me.id = id
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
        'ReDim allColors(colorsArray.Length)
        ReDim allColors(15)
        allColors(0) = KnownColor.Green
        allColors(1) = KnownColor.Blue
        allColors(2) = KnownColor.Beige
        allColors(3) = KnownColor.Red
        allColors(4) = KnownColor.Yellow
        allColors(5) = KnownColor.Violet
        allColors(6) = KnownColor.Brown
        allColors(7) = KnownColor.Orange
        allColors(8) = KnownColor.Gray
        allColors(9) = KnownColor.Salmon
        allColors(10) = KnownColor.Azure
        allColors(11) = KnownColor.Coral
        allColors(12) = KnownColor.Cyan
        allColors(13) = KnownColor.Magenta
        allColors(14) = KnownColor.Olive
        

        'Array.Copy(colorsArray, allColors, colorsArray.Length)

        'Posicion del color actual
        pos = 0
    End Sub

    Public Function getColor() As Color
        getColor = Color.FromKnownColor(Me.allColors(pos))
    End Function

    Public Function getNexColor() As Color
        'pos = (pos + 20) Mod allColors.Length
        pos = (pos + 1) Mod 15
        'If pos = 79 Then
        'pos += 1 'Aseguramos que el color verde no se asinga
        'End If
        If pos = 0 Then
            pos += 1 'Aseguramos que el color verde no se asinga
        End If
        getNexColor = Color.FromKnownColor(Me.allColors(pos))
    End Function
End Class
