Imports System.Drawing


Public Class LineMorph
    Inherits Morph

    Sub New(ByVal startPoint As PointF, ByVal endPoint As PointF)
        _startPoint = startPoint
        _endPoint = endPoint
        UpdateDrawer()
    End Sub

    Private Sub UpdateDrawer()
        Dim color As Color = Me.Color
        Drawer = New LineDrawer(_startPoint, _endPoint)
        Drawer.Color = color
    End Sub

    Private _startPoint As PointF
    Public Property StartPoint() As PointF
        Get
            Return _startPoint
        End Get
        Set(ByVal value As PointF)
            _startPoint = value
            UpdateDrawer()
        End Set
    End Property


    Private _endPoint As PointF
    Public Property EndPoint() As PointF
        Get
            Return _endPoint
        End Get
        Set(ByVal value As PointF)
            _endPoint = value
            UpdateDrawer()
        End Set
    End Property



End Class
