Imports System.Drawing

Public Class Drawer

    Dim _color As Color = Color.White
    Public Property Color() As Color
        Get
            Return _color
        End Get
        Set(ByVal value As Color)
            _color = value
        End Set
    End Property

    Public Overridable Function DrawOn(ByVal morph As Morph, ByVal canvas As Canvas) As Drawer
        canvas.FillRectangle(Color, morph.Bounds)
        Return Me
    End Function

End Class
