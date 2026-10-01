' *******************************************************
' Team Name: Binary Bros
' Team Member 1 Details: Haily P (225035860)
' Team Member 2 Details: Metiso NL (225207578)
' Practical: Group Project
' Class name: WaterSample
' *******************************************************

' This class stores water quality data for one sample.
' It is USED BY WaterSource through COMPOSITION — a WaterSource
' "has-a" WaterSample. This is our composition relationship.
Public Class WaterSample

    ' ENCAPSULATION: All fields are Private.
    ' Outside code must go through the properties below.
    Private _pHLevel As Double
    Private _turbidity As Double
    Private _bacteriaCount As Integer
    Private _sampleDate As Date


    ' CONSTRUCTOR:
    ' Runs when a new WaterSample object is created.
    ' Takes all four values as parameters and stores them in the fields.
    Public Sub New(pH As Double, turbidity As Double, bacteria As Integer, sampleDate As Date)
        _pHLevel = pH
        _turbidity = turbidity
        _bacteriaCount = bacteria
        _sampleDate = sampleDate
    End Sub


    ' ---- PROPERTY METHODS (ENCAPSULATION) ----
    ' Property for pH level. Uses validation: pH must be between 0 and 14.
    ' If the value is out of range, the field is simply not updated.
    Public Property PHLevel() As Double
        Get
            Return _pHLevel
        End Get
        Set(value As Double)
            ' pH must be between 0 and 14
            If value >= 0 And value <= 14 Then
                _pHLevel = value
            End If
        End Set
    End Property

    ' Property for turbidity. Cannot be negative.
    Public Property Turbidity() As Double
        Get
            Return _turbidity
        End Get
        Set(value As Double)
            If value >= 0 Then
                _turbidity = value
            End If
        End Set
    End Property

    ' Property for bacteria count. Cannot be negative.
    Public Property BacteriaCount() As Integer
        Get
            Return _bacteriaCount
        End Get
        Set(value As Integer)
            If value >= 0 Then
                _bacteriaCount = value
            End If
        End Set
    End Property

    ' Property for the sample date. No validation needed — a date is a date.
    Public Property SampleDate() As Date
        Get
            Return _sampleDate
        End Get
        Set(value As Date)
            _sampleDate = value
        End Set
    End Property

    ' Gives a score out of 100 for this sample.
    ' The formula: start with 100 and subtract penalties for bad readings.
    ' This is used by WaterSource to help calculate the Safety Rating.
    Public Function GetQualityScore() As Double
        Dim score As Double = 100

        ' Penalty for pH being far from neutral (7).
        score -= Math.Abs(7 - _pHLevel) * 5

        ' Penalty for turbidity above 5 NTU.
        If _turbidity > 5 Then
            score -= (_turbidity - 5) * 2
        End If

        ' Penalty for each bacteria unit.
        score -= _bacteriaCount * 3

        If score < 0 Then score = 0
        Return score
    End Function

End Class