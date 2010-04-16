Public Class fharprofile
    Public id As Integer
    Public color As Color
    Public fail As Boolean
    Public value() As Decimal
    Public isfinal As Boolean


    Public Sub New(ByVal id As Integer, ByVal color As Color, ByVal fail As Boolean, _
                   ByVal value() As Decimal, ByVal isfinal As Boolean)
        Me.id = id
        Me.color = color
        Me.fail = fail
        Me.value = value
        Me.isfinal = isfinal
    End Sub

End Class
