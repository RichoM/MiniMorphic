Imports System.Drawing

Public Class Morph



#Region "Inst vars & Properties"

    Dim _submorphs As New List(Of Morph)

    Public ReadOnly Property Submorphs() As Morph()
        Get
            Return _submorphs.ToArray()
        End Get
    End Property

    Private _drawer As New Drawer
    Public Property Drawer() As Drawer
        Get
            Return _drawer
        End Get
        Set(ByVal value As Drawer)
            _drawer = value
        End Set
    End Property

    Public Property Color() As Color
        Get
            Return _drawer.Color
        End Get
        Set(ByVal value As Color)
            _drawer.Color = value
        End Set
    End Property

    Public Overridable Function SetColor(ByVal color As Color) As Morph
        Me.Color = color
        Return Me
    End Function

    Private _stepper As New Stepper
    Public Property Stepper() As Stepper
        Get
            Return _stepper
        End Get
        Set(ByVal value As Stepper)
            _stepper = value
        End Set
    End Property

    Private _eventHandler As New EventHandler
    Public Property EventHandler() As EventHandler
        Get
            Return _eventHandler
        End Get
        Set(ByVal value As EventHandler)
            _eventHandler = value
        End Set
    End Property

    Private _owner As Morph
    Public Property Owner() As Morph
        Get
            Return _owner
        End Get
        Set(ByVal value As Morph)
            _owner = value
        End Set
    End Property

    Dim _bounds As New RectangleF(0, 0, 50, 50)
    Public Property Bounds() As RectangleF
        Get
            Return _bounds
        End Get
        Set(ByVal value As RectangleF)
            _bounds = value
        End Set
    End Property

    Public Property Height() As Single
        Get
            Return Bounds.Height
        End Get
        Set(ByVal value As Single)
            Bounds = New RectangleF(X, Y, Width, value)
        End Set
    End Property

    Public Overridable Function SetHeight(ByVal height As Single) As Morph
        Me.Height = height
        Return Me
    End Function

    Public Property Width() As Single
        Get
            Return Bounds.Width
        End Get
        Set(ByVal value As Single)
            Bounds = New RectangleF(X, Y, value, Height)
        End Set
    End Property

    Public Overridable Function SetWidth(ByVal width As Single) As Morph
        Me.Width = width
        Return Me
    End Function

    Public Property Position() As PointF
        Get
            Return New PointF(Left, Top)
        End Get
        Set(ByVal value As PointF)
            MoveDelta(value.X - X, value.Y - Y)
        End Set
    End Property

    Public Overridable Function SetPosition(ByVal position As PointF) As Morph
        Me.Position = position
        Return Me
    End Function

    Public Property Center() As PointF
        Get
            Return New PointF(Position.X + Width / 2, Position.Y + Height / 2)
        End Get
        Set(ByVal value As PointF)
            Position = New PointF(value.X - Width / 2, value.Y - Height / 2)
        End Set
    End Property

    Public Overridable Function SetCenter(ByVal center As PointF) As Morph
        Me.Center = center
        Return Me
    End Function

    Public Property Top() As Single
        Get
            Return Bounds.Top
        End Get
        Set(ByVal value As Single)
            Position = New PointF(Left, value)
        End Set
    End Property

    Public Overridable Function SetTop(ByVal top As Single) As Morph
        Me.Top = top
        Return Me
    End Function

    Public Property Bottom() As Single
        Get
            Return Bounds.Bottom
        End Get
        Set(ByVal value As Single)
            Position = New PointF(X, value - Height)
        End Set
    End Property

    Public Overridable Function SetBottom(ByVal bottom As Single) As Morph
        Me.Bottom = bottom
        Return Me
    End Function

    Public Property Left() As Single
        Get
            Return Bounds.Left
        End Get
        Set(ByVal value As Single)
            Position = New PointF(value, Top)
        End Set
    End Property

    Public Overridable Function SetLeft(ByVal left As Single) As Morph
        Me.Left = left
        Return Me
    End Function

    Public Property Right() As Single
        Get
            Return Bounds.Right
        End Get
        Set(ByVal value As Single)
            Position = New PointF(value - Width, Y)
        End Set
    End Property

    Public Overridable Function SetRight(ByVal right As Single) As Morph
        Me.Right = right
        Return Me
    End Function

    Public Property X() As Single
        Get
            Return Left
        End Get
        Set(ByVal value As Single)
            Left = value
        End Set
    End Property

    Public Overridable Function SetX(ByVal x As Single) As Morph
        Me.X = x
        Return Me
    End Function

    Public Property Y() As Single
        Get
            Return Top
        End Get
        Set(ByVal value As Single)
            Top = value
        End Set
    End Property

    Public Overridable Function SetY(ByVal y As Single) As Morph
        Me.Y = y
        Return Me
    End Function

#End Region


    Private Function MoveDelta(ByVal x As Single, ByVal y As Single) As Morph
        Bounds = New RectangleF(Position.X + x, Position.Y + y, Width, Height)
        SubmorphsDo(Function(submorph) submorph.MoveDelta(x, y))
        Return Me
    End Function

    Public Overridable Function AddMorph(ByVal morph As Morph) As Morph
        _submorphs.Add(morph)
        morph.Owner = Me
        Return Me
    End Function

    Public Overridable Function RemoveMorph(ByVal morph As Morph) As Morph
        _submorphs.Remove(morph)
        morph.Owner = Nothing
        Return Me
    End Function

    Public Overridable Function FullDrawOn(ByVal canvas As Canvas) As Morph
        DrawOn(canvas)
        SubmorphsDo(Function(submorph) submorph.FullDrawOn(canvas))
        Return Me
    End Function

    Public Overridable Function DrawOn(ByVal canvas As Canvas) As Morph
        _drawer.DrawOn(Me, canvas)
        Return Me
    End Function

    Public Overridable Function FullStep() As Morph
        [Step]()
        SubmorphsDo(Function(submorph) submorph.FullStep)
        Return Me
    End Function

    Public Overridable Function [Step]() As Morph
        _stepper.StepNowIfPosible(Me)
        Return Me
    End Function

    Public Overridable Function SubmorphsDo(ByVal f As Func(Of Morph, Morph)) As Morph
        For Each submorph As Morph In Submorphs
            f(submorph)
        Next
        Return Me
    End Function

    Public Overridable Function SubmorphsReversedDo(ByVal f As Func(Of Morph, Morph)) As Morph
        Dim submorphs As Morph() = Me.Submorphs
        For i As Integer = submorphs.Count - 1 To 0 Step -1
            f(submorphs(i))
        Next
        Return Me
    End Function

    Public Overridable Function Delete() As Morph
        Owner.RemoveMorph(Me)
        Return Me
    End Function

    Public Overridable Function SetDrawer(ByVal drawer As Drawer) As Morph
        Me.Drawer = drawer
        Return Me
    End Function

    Public Overridable Function SetStepper(ByVal stepper As Stepper) As Morph
        Me.Stepper = stepper
        Return Me
    End Function

    Public Overridable Function SetEventHandler(ByVal eventHandler As EventHandler) As Morph
        Me.EventHandler = eventHandler
        Return Me
    End Function

    Public Overridable Function OnEventDo(ByVal eventType As Type, ByVal func As Func(Of MorphicEvent, Morph, Morph)) As Morph
        _eventHandler.OnEventDo(eventType, func)
        Return Me
    End Function

    Public Overridable Function OnMouseDownDo(ByVal func As Func(Of MouseDownEvent, Morph, Morph)) As Morph
        _eventHandler.OnEventDo(GetType(MouseDownEvent), Function(evt, m) func(DirectCast(evt, MouseDownEvent), m))
        Return Me
    End Function

    Public Overridable Function OnMouseUpDo(ByVal func As Func(Of MorphicEvent, Morph, Morph)) As Morph
        _eventHandler.OnEventDo(GetType(MouseUpEvent), func)
        Return Me
    End Function

    Public Overridable Function OnMouseMoveDo(ByVal func As Func(Of MouseMoveEvent, Morph, Morph)) As Morph
        _eventHandler.OnEventDo(GetType(MouseMoveEvent), Function(evt, m) func(DirectCast(evt, MouseMoveEvent), m))
        Return Me
    End Function

    Public Overridable Function OnMouseEnterDo(ByVal func As Func(Of MouseEnterEvent, Morph, Morph)) As Morph
        _eventHandler.OnEventDo(GetType(MouseEnterEvent), Function(evt, m) func(DirectCast(evt, MouseEnterEvent), m))
        Return Me
    End Function

    Public Overridable Function OnMouseLeaveDo(ByVal func As Func(Of MouseLeaveEvent, Morph, Morph)) As Morph
        _eventHandler.OnEventDo(GetType(MouseLeaveEvent), Function(evt, m) func(DirectCast(evt, MouseLeaveEvent), m))
        Return Me
    End Function

    Public Overridable Function HandleEvent(ByVal evt As MorphicEvent) As Morph
        SubmorphsReversedDo(Function(submorph) submorph.HandleEvent(evt))
        If Not evt.WasHandled AndAlso _eventHandler.HandlesEvent(evt, Me) Then evt.HandledBy(_eventHandler, Me)
        Return Me
    End Function

End Class
