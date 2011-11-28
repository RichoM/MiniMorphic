Imports System.Runtime.CompilerServices

Public Module Extensions


    <Extension()> _
    Public Function DegreesToRadians(ByVal aNumber As Double) As Double
        Return aNumber * 0.0174532925199433
    End Function

    <Extension()> _
    Public Function RadiansToDegrees(ByVal aNumber As Double) As Double
        Return aNumber / 0.0174532925199433
    End Function

    <Extension()> _
    Public Function Radians(ByVal aNumber As Double) As Angle
        Return Angle.InRadians(aNumber)
    End Function

    <Extension()> _
    Public Function Radians(ByVal aNumber As Integer) As Angle
        Return Angle.InRadians(CDbl(aNumber))
    End Function

    <Extension()> _
    Public Function Degrees(ByVal aNumber As Double) As Angle
        Return Angle.InDegrees(aNumber)
    End Function

    <Extension()> _
    Public Function Degrees(ByVal aNumber As Integer) As Angle
        Return Angle.InDegrees(CDbl(aNumber))
    End Function

    <Extension()> _
    Public Function IsCloseTo(ByVal self As Double, ByVal num As Double) As Boolean
        If self = num Then Return True
        Return (self - num).Abs / self.Abs.Max(num.Abs) < 0.0001
    End Function

    <Extension()> _
    Public Function Abs(ByVal aNumber As Double) As Double
        Return Math.Abs(aNumber)
    End Function

    <Extension()> _
    Public Function Cos(ByVal aNumber As Double) As Double
        Return Math.Cos(aNumber)
    End Function

    <Extension()> _
    Public Function Sin(ByVal aNumber As Double) As Double
        Return Math.Sin(aNumber)
    End Function

    <Extension()> _
    Public Function Max(ByVal self As Double, ByVal aNumber As Double) As Double
        If self > aNumber Then
            Return self
        Else
            Return aNumber
        End If
    End Function

    <Extension()> _
    Public Function Min(ByVal self As Double, ByVal aNumber As Double) As Double
        If self < aNumber Then
            Return self
        Else
            Return aNumber
        End If
    End Function

    <Extension()> _
    Public Function MinMax(ByVal self As Double, ByVal min As Double, ByVal max As Double) As Double
        Return self.Min(min).Max(max)
    End Function

    <Extension()> _
    Public Function Max(ByVal self As Single, ByVal aNumber As Single) As Single
        If self > aNumber Then
            Return self
        Else
            Return aNumber
        End If
    End Function

    <Extension()> _
    Public Function Min(ByVal self As Single, ByVal aNumber As Single) As Single
        If self < aNumber Then
            Return self
        Else
            Return aNumber
        End If
    End Function

    <Extension()> _
    Public Function MinMax(ByVal self As Single, ByVal min As Single, ByVal max As Single) As Single
        Return self.Min(min).Max(max)
    End Function

End Module
