Imports System.Drawing

Public Class ImageDrawer
    Inherits Drawer

    Dim _image As Image

    Sub New(ByVal image As Image)
        _image = image
    End Sub

    Public Overrides Function DrawOn(ByVal morph As Morph, ByVal canvas As Canvas) As Drawer
        canvas.DrawImage(_image, morph.Position)
        Return Me
    End Function

End Class
