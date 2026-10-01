' *******************************************************
' Team Name: Binary Bros
' Team Member 1 Details: Haily P (225035860)
' Team Member 2 Details: Metiso NL (225207578)
' Practical: Group Project
' Class name: RiverSource
' *******************************************************


' INHERITANCE + INTERFACE:
' "Inherits WaterSource" is the IS-A relationship (a river IS-A water source).
' "Implements ITestable" is the CAN-DO relationship (a river CAN-BE-TESTED).
' RiverSource INHERITS WaterSource (INHERITANCE) and IMPLEMENTS ITestable (BONUS CATEGORY B).
Public Class RiverSource
    Inherits WaterSource
    Implements ITestable

    ' River-specific attribute — not shared with Lakes or Boreholes.
    Private _flowRate As Double

    ' CONSTRUCTOR:
    ' MyBase.New(...) calls the parent (WaterSource) constructor FIRST,
    ' then continues with the river-specific setup.
    Public Sub New(sourceID As String, location As String, sample As WaterSample, flowRate As Double)
        ' MyBase.New calls the parent constructor first.
        MyBase.New(sourceID, location, sample)
        _flowRate = flowRate
    End Sub

    Public Property FlowRate() As Double
        Get
            Return _flowRate
        End Get
        Set(value As Double)
            _flowRate = value
        End Set
    End Property

    ' POLYMORPHISM — overriding the abstract method from WaterSource.
    ' it  Overrides -we're replacing the abstract method
    ' declared in WaterSource. Our river-specific formula adds a bonus
    ' for flow rate (faster rivers dilute pollution better).
    Public Overrides Function CalculateSafetyRating() As Double
        Dim baseScore As Double = CurrentSample.GetQualityScore()
        Dim flowBonus As Double = _flowRate * 2
        Dim finalScore As Double = baseScore + flowBonus

        If finalScore > 100 Then finalScore = 100
        Return finalScore
    End Function

    ' POLYMORPHISM — override the second abstract method.
    ' We  override this abstract method too. Each source type returns
    ' its own name so the form can display and filter them.
    Public Overrides Function GetSourceType() As String
        Return "River"
    End Function

    ' INTERFACE — required because we said Implements ITestable.
    Public Sub RunWaterTest() Implements ITestable.RunWaterTest
        ' Placeholder for what would be real hardware interaction.
    End Sub

    Public Function GetTestSummary() As String Implements ITestable.GetTestSummary
        Return "River Test Summary for " & SourceID
    End Function

End Class