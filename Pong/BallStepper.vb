Imports MiniMorphic

Public Class BallStepper
    Inherits Stepper

    Dim _speed As PointF
    Dim _leftPaddle, _rightPaddle As Morph
    Dim _game As PongGame

    Sub New(ByVal ballSpeed As Vector, ByVal leftPaddle As Morph, ByVal rightPaddle As Morph, ByVal game As PongGame)
        _speed = ballSpeed.TerminalPoint
        _leftPaddle = leftPaddle
        _rightPaddle = rightPaddle
        _game = game

        StepTime = 1
    End Sub


    Public Overrides Function StepOn(ByVal morph As Morph) As Stepper
        If morph.Owner Is Nothing Then Return Me

        CheckForVerticalBouncing(morph)
        If CheckForGoals(morph) Then Return Me
        CheckForCollisions(morph)

        morph.SetX(morph.X + _speed.X).SetY(morph.Y + _speed.Y)

        KeepInsideOwner(morph)

        Return Me
    End Function

    Public Function CheckForVerticalBouncing(ByVal morph As Morph) As Stepper
        If morph.Top <= morph.Owner.Top Or morph.Bottom >= morph.Owner.Bottom Then _speed = New PointF(_speed.X, _speed.Y * -1)
        Return Me
    End Function

    Public Function CheckForGoals(ByVal morph As Morph) As Boolean
        If morph.Left <= morph.Owner.Left Then
            _game.RightGoal()
            Return True
        End If

        If morph.Right >= morph.Owner.Right Then
            _game.LeftGoal()
            Return True
        End If
        Return False
    End Function

    Public Function CheckForCollisions(ByVal morph As Morph) As Stepper
        If morph.Bounds.IntersectsWith(_leftPaddle.Bounds) Then HandleCollision(morph, _leftPaddle)
        If morph.Bounds.IntersectsWith(_rightPaddle.Bounds) Then HandleCollision(morph, _rightPaddle)
        Return Me
    End Function

    Public Function HandleCollision(ByVal ball As Morph, ByVal paddle As Morph) As Stepper
        Dim v As Vector = (New Vector(paddle.Center, ball.Center)) _
                          .SetInitialPoint(New PointF(0, 0)) _
                          .SetMagnitude((New Vector(_speed).Magnitude))
        _speed = v.TerminalPoint
        Return Me
    End Function

    Public Function KeepInsideOwner(ByVal morph As Morph) As Stepper
        If morph.Bottom > morph.Owner.Bottom Then morph.Bottom = morph.Owner.Bottom
        If morph.Top < morph.Owner.Top Then morph.Top = morph.Owner.Top
        Return Me
    End Function
End Class
