Imports MiniMorphic

Public Class PongGame

    Dim rnd As New Random

    Dim ballSpeed As New Vector(0.Degrees, 5)


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Morphic.World.Color = Color.Black
        NewGame()
    End Sub

    Private Sub NewGame()
        Randomize()
        Morphic.World.SubmorphsDo(Function(m) m.Delete)
        Dim ball As New Morph
        Dim leftPaddle As New Morph
        Dim rightPaddle As New Morph

        Dim newMagnitude As Double = ballSpeed.Magnitude + 1
        Do
            ballSpeed = New Vector((rnd.NextDouble * 360).Degrees, newMagnitude)
        Loop While ballSpeed.Angle.Dist(90.Degrees) < 45.Degrees _
            Or ballSpeed.Angle.Dist(270.Degrees) < 45.Degrees

        ball.SetWidth(20) _
            .SetHeight(20) _
            .SetCenter(Morphic.World.Center) _
            .SetStepper(New BallStepper(ballSpeed, leftPaddle, rightPaddle, Me))

        leftPaddle.SetWidth(20) _
            .SetHeight(100) _
            .SetCenter(New PointF(Morphic.World.Left + 30, Morphic.World.Center.Y)) _
            .SetStepper(New PaddleStepper(ball))

        rightPaddle.SetWidth(20) _
            .SetHeight(100) _
            .SetCenter(New PointF(Morphic.World.Right - 30, Morphic.World.Center.Y)) _
            '.SetStepper(New PaddleStepper(ball))

        Morphic.World.OnMouseMoveDo(Function(evt, ign) rightPaddle.SetCenter(New PointF(rightPaddle.Center.X, evt.Position.Y.MinMax(Morphic.World.Height - rightPaddle.Height / 2, rightPaddle.Height / 2))))

        Morphic.AddMorph(ball).AddMorph(leftPaddle).AddMorph(rightPaddle)
    End Sub

    Public Sub LeftGoal()
        LeftScoreLabel.Text = (Integer.Parse(LeftScoreLabel.Text) + 1).ToString()
        NewGame()
    End Sub

    Public Sub RightGoal()
        RightScoreLabel.Text = (Integer.Parse(RightScoreLabel.Text) + 1).ToString()
        NewGame()
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        NewGame()
    End Sub
End Class
