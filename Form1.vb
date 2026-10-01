' *******************************************************
' Team Name: Binary Bros
' Team Member 1 Details: Haily P (225035860)
' Team Member 2 Details: Metiso NL (225207578)
' Practical: Group Project
' Class name: Form1
' *******************************************************

' FileStream, BinaryWriter and BinaryReader all come from System.IO 
Imports System.IO

Public Class Form1

    ' POLYMORPHISM: A single array of the base type WaterSource.
    ' It can hold RiverSource, LakeSource, or BoreholeSource objects.
    ' The benefit: we can loop through all of them the same way, and
    ' calling Display() or CalculateSafetyRating() automatically picks
    ' the correct version for each object.
    Private _sources(2) As WaterSource

    ' Variables for the random-access file (Lecture 17 & 19)
    Private Const FILE_NAME As String = "sources.dat"
    Private Const REC_SIZE As Integer = 40   ' 4 (Integer ID length) + 30 (15-char string) + 6 (Double rating) ~= 40
    Private Const NUM_RECS As Integer = 3

    ' ComboBox setup when the form loads
    ' Runs automatically when the form first opens.
    ' We use it to populate the ComboBox with filter options
    ' and set the DateTimePicker to today.
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbFilterType.Items.Add("All")
        cmbFilterType.Items.Add("River")
        cmbFilterType.Items.Add("Lake")
        cmbFilterType.Items.Add("Borehole")
        cmbFilterType.SelectedIndex = 0

        dtpReportDate.Value = Date.Now
    End Sub

    ' LOAD SAMPLE DATA — creates the three drone-style water objects.
    ' Creates three WaterSample objects and three WaterSource objects.
    Private Sub btnLoadSamples_Click(sender As Object, e As EventArgs) Handles btnLoadSamples.Click

        Dim sample1 As New WaterSample(7.2, 3.5, 2, Date.Now)
        Dim sample2 As New WaterSample(6.5, 8.0, 15, Date.Now)
        Dim sample3 As New WaterSample(7.8, 1.2, 0, Date.Now)

        ' UPCASTING  — derived objects stored in the base-type array.
        _sources(0) = New RiverSource("RIV-001", "Vaal River", sample1, 45.5)
        _sources(1) = New LakeSource("LAK-002", "Hartbeespoort Dam", sample2, 120)
        _sources(2) = New BoreholeSource("BOR-003", "Soweto Borehole 12", sample3, 85)

        txtOutput.Clear()
        txtOutput.AppendText("Sample data loaded successfully.")
        txtOutput.AppendText(Environment.NewLine)
        txtOutput.AppendText("3 water sources created.")
        txtOutput.AppendText(Environment.NewLine)
        txtOutput.AppendText("Click 'Analyse All Sources' to view them.")
    End Sub

    ' ANALYSE button — loops through the base-typed array (POLYMORPHISM).
    Private Sub btnAnalyse_Click(sender As Object, e As EventArgs) Handles btnAnalyse.Click

        ' Safety check: has the user clicked Load Sample Data yet?
        If _sources(0) Is Nothing Then
            txtOutput.Clear()
            txtOutput.AppendText("Please click 'Load Sample Data' first.")
            Exit Sub
        End If

        txtOutput.Clear()
        txtOutput.AppendText("SDG 6 Water Report - " & dtpReportDate.Value.ToShortDateString())
        txtOutput.AppendText(Environment.NewLine)
        txtOutput.AppendText("Team: Binary Bros")
        txtOutput.AppendText(Environment.NewLine)
        txtOutput.AppendText(Environment.NewLine)

        ' Read the filter from the ComboBox (BONUS CATEGORY D).
        Dim filter As String = cmbFilterType.SelectedItem.ToString()

        ' POLYMORPHISM: Each source object calls its own version of Display().
        ' Loop through every source and call Display() on it.
        For Each source As WaterSource In _sources
            If filter <> "All" AndAlso source.GetSourceType() <> filter Then
                Continue For
            End If
            txtOutput.AppendText(source.Display())
            txtOutput.AppendText(Environment.NewLine)
        Next

    End Sub

    ' SAVE REPORT — uses FileStream + BinaryWriter 
    ' BONUS CATEGORY C.
    Private Sub btnSaveReport_Click(sender As Object, e As EventArgs) Handles btnSaveReport.Click

        If _sources(0) Is Nothing Then
            txtOutput.AppendText(Environment.NewLine)
            txtOutput.AppendText("Load the data first before saving.")
            Exit Sub
        End If

        Try
            ' Create the file for writing (FileMode.Create, FileAccess.Write).
            ' Declare the FileStream and BinaryWriter.
            Dim FS As FileStream
            Dim BW As BinaryWriter

            ' Create the file. FileMode.Create overwrites any existing file.
            ' FileAccess.Write means we can only write, not read.
            FS = New FileStream("BinaryBros_Report.dat", FileMode.Create, FileAccess.Write)
            BW = New BinaryWriter(FS)

            ' Save the report header.
            BW.Write("SDG 6 Water Report")
            BW.Write(dtpReportDate.Value.ToShortDateString())
            BW.Write("Team: Binary Bros")

            ' Save each water source's key data.
            For Each source As WaterSource In _sources
                If source IsNot Nothing Then
                    BW.Write(source.SourceID)
                    BW.Write(source.Location)
                    BW.Write(source.GetSourceType())
                    BW.Write(source.CalculateSafetyRating())
                End If
            Next

            ' Flush any buffered data, then close the connection
            BW.Flush()
            FS.Close()
            BW = Nothing

            txtOutput.AppendText(Environment.NewLine)
            txtOutput.AppendText("*** Report saved as: BinaryBros_Report.dat ***")

        Catch ex As Exception
            ' EXCEPTION HANDLING: if anything goes wrong (e.g. file is locked), we show
            ' a friendly message instead of crashing
            txtOutput.AppendText(Environment.NewLine)
            txtOutput.AppendText("Error saving file: " & ex.Message)
        End Try

    End Sub

End Class