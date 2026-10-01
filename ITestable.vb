' *******************************************************
' Team Name: Binary Bros
' Team Member 1 Details: Haily P (225035860)
' Team Member 2 Details: Metiso NL (225207578)
' Practical: Group Project
' Class name: ITestable
' *******************************************************

' INTERFACE (BONUS CATEGORY B)
' A contract that any class implementing it MUST follow.
' Interfaces have no access modifiers and no code — just signatures.
Public Interface ITestable

    ' Any implementing class must provide this Sub and Function.
    Sub RunWaterTest()
    Function GetTestSummary() As String

End Interface