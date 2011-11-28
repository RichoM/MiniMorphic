Imports System.Drawing

Public Class Vector

    Dim _initialPoint, _terminalPoint As PointF

    Public ReadOnly Property InitialPoint As PointF
        Get
            Return _initialPoint
        End Get
    End Property

    Public Function SetInitialPoint(ByVal aPoint As PointF) As Vector
        Return New Vector(aPoint, Angle, Magnitude)
    End Function

    Public ReadOnly Property TerminalPoint As PointF
        Get
            Return _terminalPoint
        End Get
    End Property

    Public Function SetTerminalPoint(ByVal aPoint As PointF) As Vector
        Return New Vector(InitialPoint, aPoint)
    End Function

    Public ReadOnly Property Angle As Angle
        Get
            Dim diff As PointF = PointF.Subtract(TerminalPoint, New SizeF(InitialPoint))
            If diff.X = 0 Then
                If diff.Y = 0 Then Return 0.Degrees
                If diff.Y > 0 Then Return 90.Degrees
                Return 270.Degrees
            End If
            Dim ang As Double = Math.Atan2(CDbl(diff.Y).Abs, CDbl(diff.X).Abs).RadiansToDegrees
            If diff.X > 0 Then
                If Not diff.Y >= 0 Then ang = 360 - ang
            Else
                If diff.Y >= 0 Then
                    ang = 180 - ang
                Else
                    ang = 180 + ang
                End If
            End If
            Return ang.Degrees
        End Get
    End Property

    Public Function SetAngle(ByVal anAngle As Angle) As Vector
        Return New Vector(InitialPoint, anAngle, Magnitude)
    End Function

    Public ReadOnly Property Magnitude As Double
        Get
            Dim diff As PointF = PointF.Subtract(TerminalPoint, New SizeF(InitialPoint))
            Return Math.Sqrt(diff.X * diff.X + diff.Y * diff.Y)
        End Get
    End Property

    Public Function SetMagnitude(ByVal aNumber As Double) As Vector
        Return New Vector(InitialPoint, Angle, aNumber)
    End Function

    Private Sub New()
    End Sub

    Sub New(ByVal initialPoint As PointF, ByVal terminalPoint As PointF)
        _initialPoint = initialPoint
        _terminalPoint = terminalPoint
    End Sub

    Sub New(ByVal angle As Angle, ByVal magnitude As Double)
        Dim o As Double = angle.Sin * magnitude
        Dim a As Double = angle.Cos * magnitude
        _initialPoint = New PointF(0, 0)
        _terminalPoint = PointF.Add(_initialPoint, New SizeF(CSng(a), CSng(o)))
    End Sub

    Sub New(ByVal initialPoint As PointF, ByVal angle As Angle, ByVal magnitude As Double)
        Dim o As Double = angle.Sin * magnitude
        Dim a As Double = angle.Cos * magnitude
        _initialPoint = initialPoint
        _terminalPoint = PointF.Add(initialPoint, New SizeF(CSng(a), CSng(o)))
    End Sub

    Sub New(ByVal terminalPoint As PointF)
        _initialPoint = New PointF(0, 0)
        _terminalPoint = terminalPoint
    End Sub

    Public Shared Operator =(ByVal self As Vector, ByVal aVector As Vector) As Boolean
        Return self.InitialPoint = aVector.InitialPoint And self.TerminalPoint = aVector.TerminalPoint
    End Operator

    Public Shared Operator <>(ByVal self As Vector, ByVal aVector As Vector) As Boolean
        Return Not self = aVector
    End Operator


End Class
