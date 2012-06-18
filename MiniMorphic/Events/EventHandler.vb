Public Class EventHandler

    Protected _functions As New Dictionary(Of Type, Func(Of MorphicEvent, Morph, Morph))

    Public Overridable Function OnEventDo(ByVal eventType As Type, ByVal func As Func(Of MorphicEvent, Morph, Morph)) As EventHandler
        _functions(eventType) = func
        Return Me
    End Function

    Public Overridable Function HandlesEvent(ByVal evt As MorphicEvent, ByVal morph As Morph) As Boolean
        Return _functions.ContainsKey(evt.GetType()) AndAlso evt.Accepts(Me, morph)
    End Function

    Public Overridable Function HandleEvent(ByVal evt As MorphicEvent, ByVal morph As Morph) As EventHandler
        _functions(evt.GetType())(evt, morph)
        Return Me
    End Function

End Class
