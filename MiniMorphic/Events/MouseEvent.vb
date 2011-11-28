Imports System.Drawing

Public Class MouseEvent
    Inherits MorphicEvent

    Dim _position As PointF
    Public ReadOnly Property Position As PointF
        Get
            Return _position
        End Get
    End Property

    Sub New(ByVal position As PointF)
        _position = position
    End Sub

    Public Overrides Function Accepts(ByVal eventHandler As EventHandler, ByVal morph As Morph) As Boolean
        Return morph.Bounds.Contains(_position)
    End Function

End Class
