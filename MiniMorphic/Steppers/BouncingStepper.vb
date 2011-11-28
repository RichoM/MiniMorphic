Imports System.Drawing

Public Class BouncingStepper
    Inherits Stepper

    Dim xStep As Single = 10
    Dim yStep As Single = 10
    Dim gravity As Single = 1


    Sub New(ByVal xStep As Single, ByVal yStep As Single)
        Me.xStep = xStep
        Me.yStep = yStep
        Me.StepTime = 1
    End Sub

    Public Overrides Function StepOn(ByVal morph As Morph) As Stepper

        yStep += gravity

        If morph.Right + xStep > morph.Owner.Right Or morph.Left + xStep < morph.Owner.Left Then xStep *= -1
        If morph.Bottom + yStep > morph.Owner.Bottom Or morph.Top + yStep < morph.Owner.Top Then
            yStep = CSng(yStep / -1.5)
            Return Me
        End If

        morph.Center = New PointF(morph.Center.X + xStep, morph.Center.Y + yStep)



        Return Me
    End Function

End Class
