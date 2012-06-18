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

    Public Overrides ReadOnly Property IsMouse As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overridable ReadOnly Property IsMouseDown As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overridable ReadOnly Property IsMouseUp As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overridable ReadOnly Property IsMouseMove As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overridable ReadOnly Property IsMouseEnter As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overridable ReadOnly Property IsMouseLeave As Boolean
        Get
            Return False
        End Get
    End Property
End Class
