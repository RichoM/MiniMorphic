
Public Class Angle

    Dim _value As Double

    Public ReadOnly Property ValueInRadians() As Double
        Get
            Return _value
        End Get
    End Property

    Public ReadOnly Property ValueInDegrees() As Double
        Get
            Return _value.RadiansToDegrees
        End Get
    End Property

    Private Sub New()
    End Sub

    Private Sub New(ByVal radians As Double)
        _value = radians
    End Sub

    Public Shared Function InDegrees(ByVal aNumber As Double) As Angle
        Return InRadians(aNumber.DegreesToRadians)
    End Function

    Public Shared Function InRadians(ByVal aNumber As Double) As Angle
        Return New Angle(aNumber)
    End Function

    Public Shared Operator *(ByVal self As Angle, ByVal aNumber As Double) As Angle
        Return (self.ValueInRadians * aNumber).Radians
    End Operator

    Public Shared Operator +(ByVal self As Angle, ByVal anAngle As Angle) As Angle
        Return (anAngle.ValueInRadians + self.ValueInRadians).Radians
    End Operator

    Public Shared Operator -(ByVal self As Angle, ByVal anAngle As Angle) As Angle
        Return (self.ValueInRadians - anAngle.ValueInRadians).Radians
    End Operator

    Public Shared Operator /(ByVal self As Angle, ByVal aNumber As Double) As Angle
        Return (self.ValueInRadians / aNumber).Radians
    End Operator

    Public Function Negated() As Angle
        Return (0 - Me.ValueInRadians).Radians
    End Function

    Public Function Opposite() As Angle
        Return Me + Angle.InDegrees(180)
    End Function


    Public Shared Operator <(ByVal self As Angle, ByVal anAngle As Angle) As Boolean
        Return self.ValueInRadians < anAngle.ValueInRadians
    End Operator

    Public Shared Operator <=(ByVal self As Angle, ByVal anAngle As Angle) As Boolean
        Return self.ValueInRadians <= anAngle.ValueInRadians
    End Operator

    Public Shared Operator >(ByVal self As Angle, ByVal anAngle As Angle) As Boolean
        Return self.ValueInRadians > anAngle.ValueInRadians
    End Operator

    Public Shared Operator >=(ByVal self As Angle, ByVal anAngle As Angle) As Boolean
        Return self.ValueInRadians >= anAngle.ValueInRadians
    End Operator

    Public Shared Operator =(ByVal self As Angle, ByVal anAngle As Angle) As Boolean
        Return self.ValueInRadians.IsCloseTo(anAngle.ValueInRadians)
    End Operator

    Public Shared Operator <>(ByVal self As Angle, ByVal anAngle As Angle) As Boolean
        Return Not self = anAngle
    End Operator

    Public Function IsBetween(ByVal min As Angle, ByVal max As Angle) As Boolean
        Return Me >= min And Me <= max
    End Function

    Public Function Max(ByVal anAngle As Angle) As Angle
        If Me > anAngle Then
            Return Me
        Else
            Return anAngle
        End If
    End Function

    Public Function Min(ByVal anAngle As Angle) As Angle
        If Me < anAngle Then
            Return Me
        Else
            Return anAngle
        End If
    End Function

    Public Function MinMax(ByVal min As Angle, ByVal max As Angle) As Angle
        Return Me.Min(min).Max(max)
    End Function

    Public Function Abs() As Angle
        Return Me.ValueInRadians.Abs.Radians()
    End Function

    Public Function Cos() As Double
        Return Me.ValueInRadians.Cos()
    End Function

    Public Function Sin() As Double
        Return Me.ValueInRadians.Sin()
    End Function

    Public Function Quadrant() As Int16
        Dim sin As Double = Me.Sin
        Dim cos As Double = Me.Cos
        If sin >= 0 And cos >= 0 Then Return 1
        If sin >= 0 And cos < 0 Then Return 2
        If sin < 0 And cos < 0 Then Return 3
        If sin < 0 And cos >= 0 Then Return 4
    End Function

    Public Function Dist(ByVal anAngle As Angle) As Angle
        Return Me.DistCounterClockwise(anAngle).Min(Me.DistClockwise(anAngle))
    End Function

    Public Function DistClockwise(ByVal anAngle As Angle) As Angle
        Return (Me.Wrapped - anAngle.Wrapped).Wrapped
    End Function

    Public Function DistCounterClockwise(ByVal anAngle As Angle) As Angle
        Return (anAngle.Wrapped - Me.Wrapped).Wrapped
    End Function

    Public Function Wrapped() As Angle
        Return Modulo(Me.ValueInRadians, Math.PI * 2).Radians
    End Function

    Public Function Modulo(ByVal a As Double, ByVal b As Double) As Double
        'Redefined to comply with Squeak's implementation
        '-1 Mod 2 -----> -1 (.Net)
        '-1 \\ 2  ----->  1 (Squeak)

        Return a - Math.Floor(a / b) * b
    End Function


End Class
