Imports MiniMorphic

Public Class PaddleStepper
    Inherits Stepper

    Dim ball As Morph
    Dim speed As Integer = 5

    Sub New(ByVal ball As Morph)
        Me.ball = ball
        StepTime = 1
    End Sub



    Public Overrides Function StepOn(ByVal morph As Morph) As Stepper
        If morph.Owner Is Nothing Then Return Me

        If Math.Abs(ball.Center.Y - morph.Center.Y) < 30 Then Return Me

        If ball.Center.Y < morph.Center.Y Then
            morph.Y -= speed
        Else
            morph.Y += speed
        End If

        If morph.Bottom > morph.Owner.Bottom Then morph.Bottom = morph.Owner.Bottom
        If morph.Top < morph.Owner.Top Then morph.Top = morph.Owner.Top
        Return Me
    End Function

End Class
