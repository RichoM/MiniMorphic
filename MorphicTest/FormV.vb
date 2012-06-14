Imports MiniMorphic


Public Class FormV

    Dim rnd As New Random


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Randomize()

        Dim morph As New Morph
        morph.SetStepper(New PluggableStepper(500, Function(m) m.SetColor(Color.FromArgb(rnd.Next)))) _
            .SetCenter(New PointF(Convert.ToSingle(rnd.NextDouble * Morphic.Width), _
                                  Convert.ToSingle(rnd.NextDouble * Morphic.Height))) _
            .SetHeight(Convert.ToSingle(rnd.NextDouble * 500)) _
            .SetWidth(Convert.ToSingle(rnd.NextDouble * 500)) _
            .SetColor(Color.FromArgb(Convert.ToInt16(rnd.NextDouble * 100) + 50, _
                                     Convert.ToInt16(rnd.NextDouble * 255), _
                                     Convert.ToInt16(rnd.NextDouble * 255), _
                                     Convert.ToInt16(rnd.NextDouble * 255)))

        Morphic.AddMorph(morph)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim origin As New PointF(Convert.ToSingle(rnd.NextDouble * Morphic.Width), Convert.ToSingle(rnd.NextDouble * Morphic.Height))
        For i As Integer = 1 To 30
            Randomize()

            Dim morph As New Morph
            morph.SetStepper(New BouncingStepper(Convert.ToSingle(rnd.NextDouble * 20) - 10, _
                                                 Convert.ToSingle(rnd.NextDouble * 20) - 10)) _
                .SetDrawer(New CircleDrawer) _
                .SetPosition(origin) _
                .SetColor(Color.FromArgb(Convert.ToInt16(rnd.NextDouble * 255), _
                                         Convert.ToInt16(rnd.NextDouble * 255), _
                                         Convert.ToInt16(rnd.NextDouble * 255), _
                                         Convert.ToInt16(rnd.NextDouble * 255))) _
                .OnMouseDownDo(Function(evt, m) m.SetColor(Color.Black)) _
                .OnMouseUpDo(Function(evt, m) m.SetTop(0))

            Morphic.AddMorph(morph)
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim morph1, morph2 As New Morph
        Morphic.AddMorph(morph1).AddMorph(morph2)

        morph1.SetColor(Color.BurlyWood) _
            .SetHeight(200) _
            .SetWidth(300) _
            .SetPosition(New PointF(50, 50)) _
            .AddMorph(morph2) _
            .SetStepper(New BouncingStepper(2, 1)) _
            .SubmorphsDo(Function(m) m.SetDrawer(New CircleDrawer).SetStepper(New BouncingStepper(1, 2)))

        morph2.SetColor(Color.BlanchedAlmond) _
            .SetPosition(New PointF(50, 50))

    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        For Each m As Morph In Morphic.Submorphs
            Morphic.RemoveMorph(m)
        Next
    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Morphic.World.SetStepper(New PluggableStepper(100, Function(m) m.SetColor(Color.FromArgb(rnd.Next))))
        Else
            Morphic.World.SetStepper(New Stepper())
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim morph As New Morph
        Dim image As New Bitmap("Estrella.png")

        morph.SetDrawer(New ImageDrawer(image)) _
            .SetStepper(New BouncingStepper(10, 7)) _
            .SetWidth(image.Width) _
            .SetHeight(image.Height)

        Morphic.AddMorph(morph)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        Dim animation, pacman As New Morph
        Dim pacmans As New List(Of Image)
        pacmans.Add(New Bitmap("pacmans\\d1.png"))
        pacmans.Add(New Bitmap("pacmans\\d2.png"))
        pacmans.Add(New Bitmap("pacmans\\d3.png"))
        pacmans.Add(New Bitmap("pacmans\\d4.png"))


        pacman.SetStepper(New PluggableStepper(1, AddressOf PacmanStep)) _
            .AddMorph(animation) _
            .SetDrawer(New PluggableDrawer(Function(m, c) c)) _
            .SetWidth(70) _
            .SetHeight(71) _
            .SetY(CSng(rnd.NextDouble * Morphic.Height))

        animation.SetStepper(New AnimationStepper(pacmans.ToArray()).SetStepTime(100))

        Morphic.AddMorph(pacman)
    End Sub

    Private Function PacmanStep(ByVal m As Morph) As Morph
        m.SetX(m.X + 5)
        If m.Left > m.Owner.Right Then m.Right = 0
        Return m
    End Function

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim morph As New Morph
        morph.SetDrawer(New CircleDrawer()).SetColor(Color.CornflowerBlue) _
            .SetHeight(100).SetWidth(100).SetCenter(Morphic.World.Center) _
            .OnMouseDownDo(AddressOf MorphicMouseDown) _
        .OnMouseEnterDo(Function(evt, m) m.SetColor(Color.BlueViolet)) _
        .OnMouseLeaveDo(Function(evt, m) m.SetColor(Color.Chartreuse))
        '.SetStepper(New PluggableStepper(1, AddressOf VectorStep)) _

        '.OnMouseMoveDo(Function(evt, m) m.SetStepper(New Stepper()).SetCenter(evt.Position))

        Morphic.AddMorph(morph)

    End Sub

    Private Function VectorStep(ByVal m As Morph) As Morph
        Dim v As New Vector((rnd.NextDouble * 360).Degrees, rnd.NextDouble * 30)
        m.SetX(m.X + v.TerminalPoint.X).SetY(m.Y + v.TerminalPoint.Y)
        Return m
    End Function

    Private Function MorphicMouseDown(ByVal evt As MorphicEvent, ByVal m As Morph) As Morph
        If m.Color = Color.CornflowerBlue Then
            m.Color = Color.Brown
        Else
            m.Color = Color.CornflowerBlue
        End If
        Return m
    End Function

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim line As New LineMorph(Morphic.World.Center, Morphic.World.Center)
        line.SetColor(Color.Black)

        Morphic.AddMorph(line)

        Morphic.World.OnMouseMoveDo(Function(evt, m)
                                        line.EndPoint = evt.Position
                                        Return line
                                    End Function)
    End Sub
End Class
