Imports System.Drawing

Public Class MouseUpEvent
    Inherits MouseEvent

    Sub New(ByVal position As PointF)
        MyBase.New(position)
    End Sub

    Public Overrides ReadOnly Property IsMouseUp As Boolean
        Get
            Return True
        End Get
    End Property
End Class
