Imports System.Windows.Forms
Imports System.Drawing

Public Class Morphic

    Dim _canvas As New Canvas
    Dim _world As New World

    Public ReadOnly Property World As World
        Get
            Return _world
        End Get
    End Property

    Public Function AddMorph(ByVal morph As Morph) As Morphic
        _world.AddMorph(morph)
        Return Me
    End Function

    Public Function RemoveMorph(ByVal morph As Morph) As Morphic
        _world.RemoveMorph(morph)
        Return Me
    End Function

    Public ReadOnly Property Submorphs() As Morph()
        Get
            Return _world.Submorphs
        End Get
    End Property

    Private Sub MorphicWorld_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        _canvas.Draw(_world, e.Graphics)
    End Sub


    Private Sub MorphicWorld_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        _world.Bounds = New RectangleF(0, 0, Me.Width, Me.Height)
    End Sub

    Private Sub MorphicWorld_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SteppingTimer.Enabled = True
        Me.SetStyle(ControlStyles.DoubleBuffer Or _
                    ControlStyles.UserPaint Or _
                    ControlStyles.AllPaintingInWmPaint, _
                    True)

    End Sub

    Private Sub SteppingTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SteppingTimer.Tick
        Me.Refresh()
        _world.FullStep()
    End Sub

    Private Sub Morphic_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        _world.HandleEvent(New MouseDownEvent(e.Location))
    End Sub

    Private Sub Morphic_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        _world.HandleEvent(New MouseUpEvent(e.Location))
    End Sub

    Dim lastPosition As New PointF
    Private Sub Morphic_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        _world.HandleEvent(New MouseMoveEvent(e.Location, lastPosition)) _
            .HandleEvent(New MouseEnterEvent(e.Location, lastPosition)) _
            .HandleEvent(New MouseLeaveEvent(e.Location, lastPosition))

        lastPosition = e.Location
    End Sub
End Class
