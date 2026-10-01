' *******************************************************
' Team Name: Binary Bros
' Team Member 1 Details: Haily P (225035860)
' Team Member 2 Details: Metiso NL (225207578)
' Practical: Group Project
' Class name: LakeSource
' *******************************************************


' INHERITANCE + INTERFACE — same pattern as RiverSource.
Public Class LakeSource
    Inherits WaterSource
    Implements ITestable

    ' Lake-specific attribute: the surface area in square kilometres.
    Private _surfaceAreaKm2 As Double

    Public Sub New(sourceID As String, location As String, sample As WaterSample, surfaceArea As Double)
        MyBase.New(sourceID, location, sample)
        _surfaceAreaKm2 = surfaceArea
    End Sub

    Public Property SurfaceAreaKm2() As Double
        Get
            Return _surfaceAreaKm2
        End Get
        Set(value As Double)
            _surfaceAreaKm2 = value
        End Set
    End Property

    ' POLYMORPHISM — different formula to RiverSource.Bigger lakes dilute pollution
    ' better, so they get a bonus based on size, capped at 15.
    Public Overrides Function CalculateSafetyRating() As Double
        Dim baseScore As Double = CurrentSample.GetQualityScore()

        ' Larger lakes dilute pollution better.
        Dim sizeBonus As Double = _surfaceAreaKm2 / 10
        If sizeBonus > 15 Then sizeBonus = 15

        Dim finalScore As Double = baseScore + sizeBonus
        If finalScore > 100 Then finalScore = 100
        Return finalScore
    End Function

    Public Overrides Function GetSourceType() As String
        Return "Lake"
    End Function


    ' INTERFACE IMPLEMENTATION — required by ITestable.
    Public Sub RunWaterTest() Implements ITestable.RunWaterTest
        ' Placeholder.
    End Sub

    Public Function GetTestSummary() As String Implements ITestable.GetTestSummary
        Return "Lake Test Summary for " & SourceID
    End Function

End Class