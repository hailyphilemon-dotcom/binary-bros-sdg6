' *******************************************************
' Team Name: Binary Bros
' Team Member 1 Details: Haily P (225035860)
' Team Member 2 Details: Metiso NL (225207578)
' Practical: Group Project
' Class name: BoreholeSource
' *******************************************************

' INHERITANCE + INTERFACE.
Public Class BoreholeSource
    Inherits WaterSource
    Implements ITestable

    ' Borehole-specific attribute: depth in metres.
    Private _depthMeters As Double

    Public Sub New(sourceID As String, location As String, sample As WaterSample, depth As Double)
        MyBase.New(sourceID, location, sample)
        _depthMeters = depth
    End Sub

    Public Property DepthMeters() As Double
        Get
            Return _depthMeters
        End Get
        Set(value As Double)
            _depthMeters = value
        End Set
    End Property

    ' POLYMORPHISM — yet another formula. A third different formula. Deeper boreholes tend to have cleaner
    ' water because surface contamination doesn't reach them.
    Public Overrides Function CalculateSafetyRating() As Double
        Dim baseScore As Double = CurrentSample.GetQualityScore()

        ' Deeper boreholes are usually cleaner.
        Dim depthBonus As Double = _depthMeters / 5
        If depthBonus > 20 Then depthBonus = 20

        Dim finalScore As Double = baseScore + depthBonus
        If finalScore > 100 Then finalScore = 100
        Return finalScore
    End Function

    Public Overrides Function GetSourceType() As String
        Return "Borehole"
    End Function

    ' INTERFACE IMPLEMENTATION.
    Public Sub RunWaterTest() Implements ITestable.RunWaterTest
        ' Placeholder.
    End Sub

    Public Function GetTestSummary() As String Implements ITestable.GetTestSummary
        Return "Borehole Test Summary for " & SourceID
    End Function

End Class