<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkStartStop = New System.Windows.Forms.CheckBox()
        Me.chkShowSpeed = New System.Windows.Forms.CheckBox()
        Me.chkShowMax = New System.Windows.Forms.CheckBox()
        Me.chkShowMin = New System.Windows.Forms.CheckBox()
        Me.chkShowAverage = New System.Windows.Forms.CheckBox()
        Me.chkShowChange = New System.Windows.Forms.CheckBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.grpControls = New System.Windows.Forms.GroupBox()
        Me.grpStatistics = New System.Windows.Forms.GroupBox()
        Me.ArrowIndicator1 = New CyrexRat_New_Disgen_monstermc.ArrowIndicator()
        Me.grpControls.SuspendLayout()
        Me.grpStatistics.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(15, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Avg: 0.00 MB/s"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(15, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Avg: 0.00 MB/s"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(15, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Max: 0.00 MB/s"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(15, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 17)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Min: 0.00 MB/s"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(15, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 17)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "0.00 MB/s"
        '
        'chkStartStop
        '
        Me.chkStartStop.AutoSize = True
        Me.chkStartStop.Checked = True
        Me.chkStartStop.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkStartStop.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStartStop.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.chkStartStop.Location = New System.Drawing.Point(10, 22)
        Me.chkStartStop.Name = "chkStartStop"
        Me.chkStartStop.Size = New System.Drawing.Size(116, 19)
        Me.chkStartStop.TabIndex = 8
        Me.chkStartStop.Text = "▶ Start Monitor"
        Me.chkStartStop.UseVisualStyleBackColor = True
        '
        'chkShowSpeed
        '
        Me.chkShowSpeed.AutoSize = True
        Me.chkShowSpeed.Checked = True
        Me.chkShowSpeed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowSpeed.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowSpeed.Location = New System.Drawing.Point(10, 47)
        Me.chkShowSpeed.Name = "chkShowSpeed"
        Me.chkShowSpeed.Size = New System.Drawing.Size(90, 17)
        Me.chkShowSpeed.TabIndex = 9
        Me.chkShowSpeed.Text = "Show Speed"
        Me.chkShowSpeed.UseVisualStyleBackColor = True
        '
        'chkShowMax
        '
        Me.chkShowMax.AutoSize = True
        Me.chkShowMax.Checked = True
        Me.chkShowMax.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowMax.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowMax.Location = New System.Drawing.Point(10, 70)
        Me.chkShowMax.Name = "chkShowMax"
        Me.chkShowMax.Size = New System.Drawing.Size(79, 17)
        Me.chkShowMax.TabIndex = 10
        Me.chkShowMax.Text = "Show Max"
        Me.chkShowMax.UseVisualStyleBackColor = True
        '
        'chkShowMin
        '
        Me.chkShowMin.AutoSize = True
        Me.chkShowMin.Checked = True
        Me.chkShowMin.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowMin.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowMin.Location = New System.Drawing.Point(115, 47)
        Me.chkShowMin.Name = "chkShowMin"
        Me.chkShowMin.Size = New System.Drawing.Size(78, 17)
        Me.chkShowMin.TabIndex = 11
        Me.chkShowMin.Text = "Show Min"
        Me.chkShowMin.UseVisualStyleBackColor = True
        '
        'chkShowAverage
        '
        Me.chkShowAverage.AutoSize = True
        Me.chkShowAverage.Checked = True
        Me.chkShowAverage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowAverage.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowAverage.Location = New System.Drawing.Point(115, 70)
        Me.chkShowAverage.Name = "chkShowAverage"
        Me.chkShowAverage.Size = New System.Drawing.Size(99, 17)
        Me.chkShowAverage.TabIndex = 12
        Me.chkShowAverage.Text = "Show Average"
        Me.chkShowAverage.UseVisualStyleBackColor = True
        '
        'chkShowChange
        '
        Me.chkShowChange.AutoSize = True
        Me.chkShowChange.Checked = True
        Me.chkShowChange.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowChange.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowChange.Location = New System.Drawing.Point(210, 47)
        Me.chkShowChange.Name = "chkShowChange"
        Me.chkShowChange.Size = New System.Drawing.Size(98, 17)
        Me.chkShowChange.TabIndex = 13
        Me.chkShowChange.Text = "Show Change"
        Me.chkShowChange.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReset.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.Color.White
        Me.btnReset.Location = New System.Drawing.Point(219, 72)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(115, 25)
        Me.btnReset.TabIndex = 14
        Me.btnReset.Text = "↺ Reset Stats"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'grpControls
        '
        Me.grpControls.Controls.Add(Me.chkStartStop)
        Me.grpControls.Controls.Add(Me.btnReset)
        Me.grpControls.Controls.Add(Me.chkShowSpeed)
        Me.grpControls.Controls.Add(Me.chkShowChange)
        Me.grpControls.Controls.Add(Me.chkShowMax)
        Me.grpControls.Controls.Add(Me.chkShowAverage)
        Me.grpControls.Controls.Add(Me.chkShowMin)
        Me.grpControls.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpControls.Location = New System.Drawing.Point(12, 168)
        Me.grpControls.Name = "grpControls"
        Me.grpControls.Size = New System.Drawing.Size(340, 105)
        Me.grpControls.TabIndex = 15
        Me.grpControls.TabStop = False
        Me.grpControls.Text = "Controls"
        '
        'grpStatistics
        '
        Me.grpStatistics.Controls.Add(Me.Label1)
        Me.grpStatistics.Controls.Add(Me.Label2)
        Me.grpStatistics.Controls.Add(Me.Label3)
        Me.grpStatistics.Controls.Add(Me.Label5)
        Me.grpStatistics.Controls.Add(Me.Label4)
        Me.grpStatistics.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpStatistics.Location = New System.Drawing.Point(358, 168)
        Me.grpStatistics.Name = "grpStatistics"
        Me.grpStatistics.Size = New System.Drawing.Size(140, 150)
        Me.grpStatistics.TabIndex = 16
        Me.grpStatistics.TabStop = False
        Me.grpStatistics.Text = "Statistics"
        '
        'ArrowIndicator1
        '
        Me.ArrowIndicator1.AutoStart = True
        Me.ArrowIndicator1.BackColor = System.Drawing.Color.White
        Me.ArrowIndicator1.CurrentSpeed = 0R
        Me.ArrowIndicator1.DisplayText = "Network Usage"
        Me.ArrowIndicator1.IsRunning = False
        Me.ArrowIndicator1.LineColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.ArrowIndicator1.LineColorDown = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ArrowIndicator1.LineColorUp = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.ArrowIndicator1.Location = New System.Drawing.Point(12, 12)
        Me.ArrowIndicator1.MaxPoints = 60
        Me.ArrowIndicator1.MaxSpeed = 10.0R
        Me.ArrowIndicator1.MinimumSize = New System.Drawing.Size(150, 50)
        Me.ArrowIndicator1.Name = "ArrowIndicator1"
        Me.ArrowIndicator1.Padding = New System.Windows.Forms.Padding(5)
        Me.ArrowIndicator1.ShowAverage = True
        Me.ArrowIndicator1.ShowChange = True
        Me.ArrowIndicator1.ShowMax = True
        Me.ArrowIndicator1.ShowMin = True
        Me.ArrowIndicator1.ShowSpeed = True
        Me.ArrowIndicator1.Size = New System.Drawing.Size(486, 75)
        Me.ArrowIndicator1.Smoothness = 7
        Me.ArrowIndicator1.TabIndex = 17
        Me.ArrowIndicator1.TargetLabelAverage = Nothing
        Me.ArrowIndicator1.TargetLabelChange = Nothing
        Me.ArrowIndicator1.TargetLabelMax = Nothing
        Me.ArrowIndicator1.TargetLabelMin = Nothing
        Me.ArrowIndicator1.TargetLabelSpeed = Nothing
        Me.ArrowIndicator1.UpdateDelay = 700
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(510, 330)
        Me.Controls.Add(Me.ArrowIndicator1)
        Me.Controls.Add(Me.grpStatistics)
        Me.Controls.Add(Me.grpControls)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "📊 Network Speed Monitor"
        Me.grpControls.ResumeLayout(False)
        Me.grpControls.PerformLayout()
        Me.grpStatistics.ResumeLayout(False)
        Me.grpStatistics.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents chkStartStop As CheckBox
    Friend WithEvents chkShowSpeed As CheckBox
    Friend WithEvents chkShowMax As CheckBox
    Friend WithEvents chkShowMin As CheckBox
    Friend WithEvents chkShowAverage As CheckBox
    Friend WithEvents chkShowChange As CheckBox
    Friend WithEvents btnReset As Button
    Friend WithEvents grpControls As GroupBox
    Friend WithEvents grpStatistics As GroupBox
    Friend WithEvents ArrowIndicator1 As ArrowIndicator
End Class