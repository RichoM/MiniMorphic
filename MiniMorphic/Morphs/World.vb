Public Class World
    Inherits Morph

    Public Overrides ReadOnly Property World As World
        Get
            Return Me
        End Get
    End Property

    Private _hand As Morph
    Public ReadOnly Property Hand As Morph
        Get
            Return _hand
        End Get
    End Property

    Sub New()
        SetEventHandler(New EventHandler)

        _hand = New Morph
        _hand _
            .SetWidth(1).SetHeight(1) _
            .SetDrawer(New PluggableDrawer(Function(morph, canvas) canvas)) _
            .SetEventHandler(New EventHandler)

        AddMorph(_hand)
    End Sub

    Public Overrides Function HandleEvent(ByVal evt As MorphicEvent) As Morph
        'HACK!
        If evt.GetType.Equals(GetType(MouseMoveEvent)) Then
                _hand.SetCenter(DirectCast(evt, MouseMoveEvent).LastPosition)
        End If

        Return MyBase.HandleEvent(evt)
    End Function

End Class
