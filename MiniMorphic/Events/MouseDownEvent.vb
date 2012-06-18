Imports System.Drawing

Public Class MouseDownEvent
    Inherits MouseEvent

    Sub New(ByVal position As PointF)
        MyBase.New(position)
    End Sub

    Public Overrides ReadOnly Property IsMouseDown As Boolean
        Get
            Return True
        End Get
    End Property
End Class
