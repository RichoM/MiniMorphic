Imports System.Drawing

Public Class Canvas
    Dim graphic As Graphics

    Public Function DrawLine(ByVal color As Color, ByVal pt1 As PointF, ByVal pt2 As PointF) As Canvas
        Dim pen As New Pen(color)
        graphic.DrawLine(pen, pt1, pt2)
        Return Me
    End Function

    Public Function FillRectangle(ByVal color As Color, ByVal rect As RectangleF) As Canvas
        Dim pen As New Pen(color)
        graphic.FillRectangle(pen.Brush, rect)
        Return Me
    End Function


    Public Function FillOval(ByVal color As Color, ByVal rect As RectangleF) As Canvas
        Dim pen As New Pen(color)
        graphic.FillEllipse(pen.Brush, rect)
        Return Me
    End Function

    Public Function DrawImage(ByVal image As Image, ByVal position As PointF) As Canvas
        graphic.DrawImage(image, position)
        Return Me
    End Function

    Public Function Clip(ByVal rect As RectangleF) As Canvas
        graphic.Clip = New Region(rect)
        Return Me
    End Function

    Public Function ClipDuring(ByVal rect As RectangleF, ByVal f As Func(Of Morph)) As Canvas
        Dim old As Region = graphic.Clip
        Clip(rect)
        f()
        graphic.Clip = old
        Return Me
    End Function


    Public Function Draw(ByVal morph As Morph, ByVal graphic As Graphics) As Canvas
        Me.graphic = graphic
        morph.FullDrawOn(Me)

        Return Me
    End Function

End Class
