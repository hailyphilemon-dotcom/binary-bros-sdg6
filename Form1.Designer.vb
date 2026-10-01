<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbFilterType = New System.Windows.Forms.ComboBox()
        Me.dtpReportDate = New System.Windows.Forms.DateTimePicker()
        Me.btnLoadSamples = New System.Windows.Forms.Button()
        Me.btnAnalyse = New System.Windows.Forms.Button()
        Me.btnSaveReport = New System.Windows.Forms.Button()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(427, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Binary Bros — SDG 6 Water Quality Tracker"
        '
        'cmbFilterType
        '
        Me.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterType.FormattingEnabled = True
        Me.cmbFilterType.Location = New System.Drawing.Point(86, 101)
        Me.cmbFilterType.Name = "cmbFilterType"
        Me.cmbFilterType.Size = New System.Drawing.Size(121, 24)
        Me.cmbFilterType.TabIndex = 1
        '
        'dtpReportDate
        '
        Me.dtpReportDate.Location = New System.Drawing.Point(331, 103)
        Me.dtpReportDate.Name = "dtpReportDate"
        Me.dtpReportDate.Size = New System.Drawing.Size(245, 22)
        Me.dtpReportDate.TabIndex = 2
        '
        'btnLoadSamples
        '
        Me.btnLoadSamples.Location = New System.Drawing.Point(26, 161)
        Me.btnLoadSamples.Name = "btnLoadSamples"
        Me.btnLoadSamples.Size = New System.Drawing.Size(140, 23)
        Me.btnLoadSamples.TabIndex = 3
        Me.btnLoadSamples.Text = "Load Sample Data"
        Me.btnLoadSamples.UseVisualStyleBackColor = True
        '
        'btnAnalyse
        '
        Me.btnAnalyse.Location = New System.Drawing.Point(247, 161)
        Me.btnAnalyse.Name = "btnAnalyse"
        Me.btnAnalyse.Size = New System.Drawing.Size(159, 23)
        Me.btnAnalyse.TabIndex = 4
        Me.btnAnalyse.Text = "Analyse All Sources"
        Me.btnAnalyse.UseVisualStyleBackColor = True
        '
        'btnSaveReport
        '
        Me.btnSaveReport.Location = New System.Drawing.Point(505, 161)
        Me.btnSaveReport.Name = "btnSaveReport"
        Me.btnSaveReport.Size = New System.Drawing.Size(108, 23)
        Me.btnSaveReport.TabIndex = 5
        Me.btnSaveReport.Text = "Save Report"
        Me.btnSaveReport.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.Font = New System.Drawing.Font("Consolas", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutput.Location = New System.Drawing.Point(1, 198)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOutput.Size = New System.Drawing.Size(678, 300)
        Me.txtOutput.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(83, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Filter Source Type:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(328, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Report Date:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 510)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.btnSaveReport)
        Me.Controls.Add(Me.btnAnalyse)
        Me.Controls.Add(Me.btnLoadSamples)
        Me.Controls.Add(Me.dtpReportDate)
        Me.Controls.Add(Me.cmbFilterType)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "SDG 6 Water Quality Tracker"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmbFilterType As ComboBox
    Friend WithEvents dtpReportDate As DateTimePicker
    Friend WithEvents btnLoadSamples As Button
    Friend WithEvents btnAnalyse As Button
    Friend WithEvents btnSaveReport As Button
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
