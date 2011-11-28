Imports System.Drawing

Public Class AnimationStepper
    Inherits Stepper

    Dim _index As Integer = 0
    Dim _images As Image()

    Sub New(ByVal images As Image())
        _images = images
        _index = images.Length
    End Sub

    Public Overrides Function StepOn(ByVal morph As Morph) As Stepper
        LoadImageOn(NextImage(), morph)
        Return Me
    End Function

    Public Function NextImage() As Image
        _index = (_index + 1) Mod _images.Length
        Return _images(_index)
    End Function

    Public Function LoadImageOn(ByVal image As Image, ByVal morph As Morph) As Stepper
        morph.Drawer = New ImageDrawer(image)
        morph.SetWidth(image.Width).SetHeight(image.Height)
        Return Me
    End Function

End Class
