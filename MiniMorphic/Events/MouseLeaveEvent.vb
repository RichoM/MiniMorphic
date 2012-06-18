Imports System.Drawing

Public Class MouseLeaveEvent
    Inherits MouseMoveEvent

    Sub New(ByVal position As PointF, ByVal lastPosition As PointF)
        MyBase.New(position, lastPosition)
    End Sub

    Public Overrides Function Accepts(ByVal eventHandler As EventHandler, ByVal morph As Morph) As Boolean
        Return morph.Bounds.Contains(LastPosition) And Not morph.Bounds.Contains(Position)
    End Function

    Public Overrides ReadOnly Property IsMouseLeave As Boolean
        Get
            Return True
        End Get
    End Property
End Class
