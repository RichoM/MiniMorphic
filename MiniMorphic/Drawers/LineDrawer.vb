Imports System.Drawing

Public Class LineDrawer
    Inherits Drawer

    Dim pt1, pt2 As PointF

    Sub New(ByVal startPoint As PointF, ByVal endPoint As PointF)
        pt1 = startPoint
        pt2 = endPoint
    End Sub


    Public Overrides Function DrawOn(ByVal morph As Morph, ByVal canvas As Canvas) As Drawer
        canvas.DrawLine(Color, pt1, pt2)
        Return Me
    End Function

End Class
