Imports System.Drawing

Public Class MouseMoveEvent
    Inherits MouseEvent

    Dim _lastPosition As PointF
    Public ReadOnly Property LastPosition As PointF
        Get
            Return _lastPosition
        End Get
    End Property

    Public Overrides Function Accepts(ByVal eventHandler As EventHandler, ByVal morph As Morph) As Boolean
        Return MyBase.Accepts(eventHandler, morph) OrElse morph.Bounds.Contains(_lastPosition)
    End Function

    Sub New(ByVal position As PointF, ByVal lastPosition As PointF)
        MyBase.New(position)
        _lastPosition = lastPosition
    End Sub

End Class
