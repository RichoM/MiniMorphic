Public Class Stepper

    Private _stepTime As Integer = 1000
    Public Property StepTime() As Integer
        Get
            Return _stepTime
        End Get
        Set(ByVal value As Integer)
            _stepTime = value
        End Set
    End Property

    Public Overridable Function SetStepTime(ByVal value As Integer) As Stepper
        StepTime = value
        Return Me
    End Function

    Public Overridable Function StepOn(ByVal morph As Morph) As Stepper
        'Do nothing by default
        Return Me
    End Function

    Dim lastTimeStep As Integer = 0
    Public Overridable Function StepNowIfPosible(ByVal morph As Morph) As Stepper
        Dim now As Integer = Environment.TickCount
        If now - lastTimeStep >= StepTime Then
            StepOn(morph)
            lastTimeStep = now
        End If
        Return Me
    End Function


End Class
