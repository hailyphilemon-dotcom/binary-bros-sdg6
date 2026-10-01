' *******************************************************
' Team Name: Binary Bros
' Team Member 1 Details: Haily P (225035860)
' Team Member 2 Details: Metiso NL (225207578)
' Practical: Group Project
' Class name: WaterSource
' *******************************************************

Imports System.IO

' ABSTRACT CLASS (BONUS CATEGORY B)
' MustInherit means we cannot create a plain WaterSource —
' we always create a specific type like River, Lake or Borehole.
Public MustInherit Class WaterSource

    ' BONUS CATEGORY A — a Shared constant.
    ' Shared means it belongs to the class, not to any one object.
    Public Const MAX_SAFE_TURBIDITY As Double = 5.0

    ' ENCAPSULATION — private attributes.
    Private _sourceID As String
    Private _location As String
    Private _lastTested As Date

    ' COMPOSITION — a WaterSource HAS-A WaterSample.
    ' The sample Object Is stored inside
    ' the source object. Without the source, the sample has no meaning.
    Private _currentSample As WaterSample

    ' CONSTRUCTOR:
    ' Accepts shared values plus a sample object. Sets lastTested to today.
    Public Sub New(sourceID As String, location As String, sample As WaterSample)
        _sourceID = sourceID
        _location = location
        _currentSample = sample
        _lastTested = Date.Now
    End Sub

    ' ---- PROPERTY METHODS (ENCAPSULATION) ----

    ' ReadOnly: the source ID should never change after creation.
    Public ReadOnly Property SourceID() As String
        Get
            Return _sourceID
        End Get
    End Property

    Public Property Location() As String
        Get
            Return _location
        End Get
        Set(value As String)
            _location = value
        End Set
    End Property

    ' ReadOnly: the last tested date is set at construction.
    Public ReadOnly Property LastTested() As Date
        Get
            Return _lastTested
        End Get
    End Property

    ' Exposes the composed WaterSample object. Datatype is the class name.
    Public Property CurrentSample() As WaterSample
        Get
            Return _currentSample
        End Get
        Set(value As WaterSample)
            _currentSample = value
        End Set
    End Property

    ' ---- ABSTRACT METHODS ----
    ' POLYMORPHISM — no body here. Each derived class MUST provide its own.
    ' Each derived class MUST provide its own version, Or it won't compile.
    ' This is how we ensure rivers, lakes and boreholes each calculate
    ' their safety rating differently.
    Public MustOverride Function CalculateSafetyRating() As Double
    Public MustOverride Function GetSourceType() As String

    ' ---- OVERRIDABLE METHOD ----
    ' POLYMORPHISM — has a body but derived classes can replace it.
    ' Overridable means this method HAS a body, but derived classes can
    ' optionally replace it with their own version.
    ' In this case, all three derived classes override it — but they could
    ' have simply used this base version if they wanted.
    Public Overridable Function Display() As String
        Dim output As String = ""
        output &= "=================================" & Environment.NewLine
        output &= "Source ID:     " & _sourceID & Environment.NewLine
        output &= "Type:          " & GetSourceType() & Environment.NewLine
        output &= "Location:      " & _location & Environment.NewLine
        output &= "Last Tested:   " & _lastTested.ToShortDateString() & Environment.NewLine
        output &= "pH Level:      " & _currentSample.PHLevel & Environment.NewLine
        output &= "Turbidity:     " & _currentSample.Turbidity & " NTU" & Environment.NewLine
        output &= "Bacteria:      " & _currentSample.BacteriaCount & " per 100ml" & Environment.NewLine
        output &= "Safety Rating: " & CalculateSafetyRating().ToString("0.0") & "%" & Environment.NewLine
        output &= "Quality Score: " & _currentSample.GetQualityScore().ToString("0.0") & Environment.NewLine
        Return output
    End Function

End Class