Public Class PluggableDrawer
    Inherits Drawer

    Dim _drawFunction As Func(Of Morph, Canvas, Canvas)

    Sub New(ByVal drawFunction As Func(Of Morph, Canvas, Canvas))
        _drawFunction = drawFunction
    End Sub

    Public Overrides Function DrawOn(ByVal morph As Morph, ByVal canvas As Canvas) As Drawer
        _drawFunction(morph, canvas)
        Return Me
    End Function
End Class
