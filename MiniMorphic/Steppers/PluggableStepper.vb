Public Class PluggableStepper
    Inherits Stepper

    Dim _stepFunction As Func(Of Morph, Morph)

    Sub New(ByVal stepTime As Integer, ByVal stepFunction As Func(Of Morph, Morph))
        Me.StepTime = stepTime
        _stepFunction = stepFunction
    End Sub

    Public Overrides Function StepOn(ByVal morph As Morph) As Stepper
        _stepFunction(morph)
        Return Me
    End Function
End Class
