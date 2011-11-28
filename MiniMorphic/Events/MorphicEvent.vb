Imports System.Drawing

Public Class MorphicEvent

    Dim _wasHandled As Boolean = False
    Public ReadOnly Property WasHandled As Boolean
        Get
            Return _wasHandled
        End Get
    End Property

    Public Overridable Function Accepts(ByVal eventHandler As EventHandler, ByVal morph As Morph) As Boolean
        Return True
    End Function

    Public Overridable Function HandledBy(ByVal eventHandler As EventHandler, ByVal morph As Morph) As MorphicEvent
        eventHandler.HandleEvent(Me, morph)
        _wasHandled = True
        Return Me
    End Function
End Class
