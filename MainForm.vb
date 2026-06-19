Imports System.Windows.Forms

Public Class MainForm

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup ArrowIndicator with target labels
        ArrowIndicator1.TargetLabelSpeed = Label1
        ArrowIndicator1.TargetLabelMax = Label3
        ArrowIndicator1.TargetLabelMin = Label4
        ArrowIndicator1.TargetLabelAverage = Label5
        ArrowIndicator1.TargetLabelChange = Label2

        ' Set default visibility based on checkboxes
        UpdateLabelVisibility()
    End Sub

    ' CheckBox Events
    Private Sub chkStartStop_CheckedChanged(sender As Object, e As EventArgs) Handles chkStartStop.CheckedChanged
        If chkStartStop.Checked Then
            ArrowIndicator1.StartMonitoring()
            chkStartStop.ForeColor = Color.FromArgb(46, 204, 113)
            chkStartStop.Text = "▶ Start Monitor"
        Else
            ArrowIndicator1.StopMonitoring()
            chkStartStop.ForeColor = Color.FromArgb(231, 76, 60)
            chkStartStop.Text = "⏹ Stop Monitor"
        End If
    End Sub

    Private Sub chkShowSpeed_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowSpeed.CheckedChanged
        ArrowIndicator1.ShowSpeed = chkShowSpeed.Checked
        UpdateLabelVisibility()
    End Sub

    Private Sub chkShowMax_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowMax.CheckedChanged
        ArrowIndicator1.ShowMax = chkShowMax.Checked
        UpdateLabelVisibility()
    End Sub

    Private Sub chkShowMin_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowMin.CheckedChanged
        ArrowIndicator1.ShowMin = chkShowMin.Checked
        UpdateLabelVisibility()
    End Sub

    Private Sub chkShowAverage_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowAverage.CheckedChanged
        ArrowIndicator1.ShowAverage = chkShowAverage.Checked
        UpdateLabelVisibility()
    End Sub

    Private Sub chkShowChange_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowChange.CheckedChanged
        ArrowIndicator1.ShowChange = chkShowChange.Checked
        UpdateLabelVisibility()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ArrowIndicator1.ResetStatistics()
    End Sub

    ' Update Label Visibility based on CheckBoxes
    Private Sub UpdateLabelVisibility()
        Label1.Visible = chkShowSpeed.Checked
        Label2.Visible = chkShowChange.Checked
        Label3.Visible = chkShowMax.Checked
        Label4.Visible = chkShowMin.Checked
        Label5.Visible = chkShowAverage.Checked
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If ArrowIndicator1 IsNot Nothing Then
            ArrowIndicator1.StopMonitoring()
        End If
        MyBase.OnFormClosing(e)
    End Sub
End Class