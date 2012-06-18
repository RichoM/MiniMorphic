Public Class DefaultEventHandler
    Inherits EventHandler

    Sub New()
        _functions(GetType(MouseDownEvent)) = AddressOf HandleMouseDown
        _functions(GetType(MouseUpEvent)) = AddressOf HandleMouseUp

    End Sub

    Private Function HandleMouseDown(ByVal evt As MorphicEvent, ByVal morph As Morph) As Morph
        Dim hand As Morph = morph.World.Hand
        If Not hand.Submorphs.Contains(morph) Then
            morph.Owner.RemoveMorph(morph)
            hand.AddMorph(morph)
        End If
        Return morph
    End Function

    Private Function HandleMouseUp(ByVal evt As MorphicEvent, ByVal morph As Morph) As Morph
        Dim hand As Morph = morph.World.Hand
        If hand.Submorphs.Contains(morph) Then
            hand.RemoveMorph(morph)
            hand.World.AddMorph(morph)
        End If
        Return morph
    End Function

End Class
