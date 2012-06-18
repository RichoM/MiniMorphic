Imports System.Drawing

Public Class MouseEnterEvent
    Inherits MouseMoveEvent

    Sub New(ByVal position As PointF, ByVal lastPosition As PointF)
        MyBase.New(position, lastPosition)
    End Sub

    Public Overrides Function Accepts(ByVal eventHandler As EventHandler, ByVal morph As Morph) As Boolean
        Return morph.Bounds.Contains(Position) And Not morph.Bounds.Contains(LastPosition)
    End Function

    Public Overrides ReadOnly Property IsMouseEnter As Boolean
        Get
            Return True
        End Get
    End Property
End Class
