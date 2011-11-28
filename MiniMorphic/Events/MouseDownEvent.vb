Imports System.Drawing

Public Class MouseDownEvent
    Inherits MouseEvent

    Sub New(ByVal position As PointF)
        MyBase.New(position)
    End Sub
End Class
