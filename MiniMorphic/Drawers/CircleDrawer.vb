Imports System.Drawing

Public Class CircleDrawer
    Inherits Drawer

    Public Overrides Function DrawOn(ByVal morph As Morph, ByVal canvas As Canvas) As Drawer
        canvas.FillOval(Color, morph.Bounds)
        Return Me
    End Function

End Class
