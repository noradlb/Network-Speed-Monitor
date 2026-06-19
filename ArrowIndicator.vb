Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Threading.Tasks

Public Class ArrowIndicator
    Inherits Panel

    ' Private Fields
    Private _currentSpeed As Double = 0
    Private _maxSpeed As Double = 10
    Private _labelText As String = "Network Usage"
    Private _lineColor As Color = Color.FromArgb(52, 152, 219)
    Private _lineColorUp As Color = Color.FromArgb(46, 204, 113)
    Private _lineColorDown As Color = Color.FromArgb(231, 76, 60)
    Private _isRunning As Boolean = False
    Private _autoStart As Boolean = True
    Private _values As New List(Of Double)()
    Private _maxPoints As Integer = 60
    Private _designMode As Boolean = False
    Private _smoothness As Integer = 7
    Private _updateDelay As Integer = 700

    ' Target Labels
    Private _targetLabelSpeed As Label = Nothing
    Private _targetLabelMax As Label = Nothing
    Private _targetLabelMin As Label = Nothing
    Private _targetLabelAverage As Label = Nothing
    Private _targetLabelChange As Label = Nothing

    ' Show/Hide options
    Private _showSpeed As Boolean = True
    Private _showMax As Boolean = False
    Private _showMin As Boolean = False
    Private _showAverage As Boolean = False
    Private _showChange As Boolean = False

    ' Network Monitoring
    Private _networkInterface As NetworkInterface = Nothing
    Private _previousBytes As Long = 0
    Private _isMonitoringActive As Boolean = False
    Private _monitoringTask As Task = Nothing
    Private _cancellationTokenSource As System.Threading.CancellationTokenSource = Nothing

    ' Statistics
    Private _speedHistory As New List(Of Double)()
    Private _maxSpeedHistory As Double = 0
    Private _minSpeedHistory As Double = Double.MaxValue
    Private _totalSpeed As Double = 0
    Private _speedCount As Integer = 0
    Private _smoothedValues As New List(Of Double)()
    Private _lastDisplaySpeed As Double = 0
    Private _speedBuffer As New List(Of Double)()

    ' Constructor
    Public Sub New()
        MyBase.New()

        _designMode = IsDesignMode()

        Me.Size = New Size(350, 70)
        Me.BackColor = Color.White
        Me.DoubleBuffered = True
        Me.ResizeRedraw = True
        Me.MinimumSize = New Size(150, 50)
        Me.Padding = New Padding(5)

        If Not _designMode AndAlso _autoStart Then
            StartMonitoring()
        End If
    End Sub

    Private Function IsDesignMode() As Boolean
        Return DesignMode OrElse
               System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime
    End Function

    ' Properties
    <Category("Appearance")>
    <Description("Current speed in MB/s")>
    Public Property CurrentSpeed() As Double
        Get
            Return _currentSpeed
        End Get
        Set(value As Double)
            _currentSpeed = Math.Max(0, value)
            If _currentSpeed > _maxSpeed Then
                _maxSpeed = _currentSpeed * 1.1
            End If
            UpdateAllLabels()
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    <Description("Maximum speed limit")>
    Public Property MaxSpeed() As Double
        Get
            Return _maxSpeed
        End Get
        Set(value As Double)
            _maxSpeed = Math.Max(1, value)
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    <Description("Title text")>
    Public Property DisplayText() As String
        Get
            Return _labelText
        End Get
        Set(value As String)
            _labelText = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    <Description("Line color (default)")>
    Public Property LineColor() As Color
        Get
            Return _lineColor
        End Get
        Set(value As Color)
            _lineColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    <Description("Line color when going up")>
    Public Property LineColorUp() As Color
        Get
            Return _lineColorUp
        End Get
        Set(value As Color)
            _lineColorUp = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    <Description("Line color when going down")>
    Public Property LineColorDown() As Color
        Get
            Return _lineColorDown
        End Get
        Set(value As Color)
            _lineColorDown = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    <Description("Smoothness level (1-10)")>
    Public Property Smoothness() As Integer
        Get
            Return _smoothness
        End Get
        Set(value As Integer)
            _smoothness = Math.Max(1, Math.Min(10, value))
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    <Description("Update delay in milliseconds (500-1500)")>
    Public Property UpdateDelay() As Integer
        Get
            Return _updateDelay
        End Get
        Set(value As Integer)
            _updateDelay = Math.Max(500, Math.Min(1500, value))
        End Set
    End Property

    ' Target Labels Properties
    <Category("Target Labels")>
    <Description("Label to display current speed")>
    Public Property TargetLabelSpeed() As Label
        Get
            Return _targetLabelSpeed
        End Get
        Set(value As Label)
            _targetLabelSpeed = value
            If _targetLabelSpeed IsNot Nothing AndAlso _showSpeed Then
                UpdateLabelSpeed()
            End If
        End Set
    End Property

    <Category("Target Labels")>
    <Description("Label to display maximum speed")>
    Public Property TargetLabelMax() As Label
        Get
            Return _targetLabelMax
        End Get
        Set(value As Label)
            _targetLabelMax = value
            If _targetLabelMax IsNot Nothing AndAlso _showMax Then
                UpdateLabelMax()
            End If
        End Set
    End Property

    <Category("Target Labels")>
    <Description("Label to display minimum speed")>
    Public Property TargetLabelMin() As Label
        Get
            Return _targetLabelMin
        End Get
        Set(value As Label)
            _targetLabelMin = value
            If _targetLabelMin IsNot Nothing AndAlso _showMin Then
                UpdateLabelMin()
            End If
        End Set
    End Property

    <Category("Target Labels")>
    <Description("Label to display average speed")>
    Public Property TargetLabelAverage() As Label
        Get
            Return _targetLabelAverage
        End Get
        Set(value As Label)
            _targetLabelAverage = value
            If _targetLabelAverage IsNot Nothing AndAlso _showAverage Then
                UpdateLabelAverage()
            End If
        End Set
    End Property

    <Category("Target Labels")>
    <Description("Label to display speed change")>
    Public Property TargetLabelChange() As Label
        Get
            Return _targetLabelChange
        End Get
        Set(value As Label)
            _targetLabelChange = value
            If _targetLabelChange IsNot Nothing AndAlso _showChange Then
                UpdateLabelChange()
            End If
        End Set
    End Property

    ' Show/Hide Properties
    <Category("Display Options")>
    <Description("Show current speed in target label")>
    Public Property ShowSpeed() As Boolean
        Get
            Return _showSpeed
        End Get
        Set(value As Boolean)
            _showSpeed = value
            If _showSpeed Then
                UpdateLabelSpeed()
            ElseIf _targetLabelSpeed IsNot Nothing Then
                _targetLabelSpeed.Text = ""
            End If
        End Set
    End Property

    <Category("Display Options")>
    <Description("Show maximum speed in target label")>
    Public Property ShowMax() As Boolean
        Get
            Return _showMax
        End Get
        Set(value As Boolean)
            _showMax = value
            If _showMax Then
                UpdateLabelMax()
            ElseIf _targetLabelMax IsNot Nothing Then
                _targetLabelMax.Text = ""
            End If
        End Set
    End Property

    <Category("Display Options")>
    <Description("Show minimum speed in target label")>
    Public Property ShowMin() As Boolean
        Get
            Return _showMin
        End Get
        Set(value As Boolean)
            _showMin = value
            If _showMin Then
                UpdateLabelMin()
            ElseIf _targetLabelMin IsNot Nothing Then
                _targetLabelMin.Text = ""
            End If
        End Set
    End Property

    <Category("Display Options")>
    <Description("Show average speed in target label")>
    Public Property ShowAverage() As Boolean
        Get
            Return _showAverage
        End Get
        Set(value As Boolean)
            _showAverage = value
            If _showAverage Then
                UpdateLabelAverage()
            ElseIf _targetLabelAverage IsNot Nothing Then
                _targetLabelAverage.Text = ""
            End If
        End Set
    End Property

    <Category("Display Options")>
    <Description("Show speed change in target label")>
    Public Property ShowChange() As Boolean
        Get
            Return _showChange
        End Get
        Set(value As Boolean)
            _showChange = value
            If _showChange Then
                UpdateLabelChange()
            ElseIf _targetLabelChange IsNot Nothing Then
                _targetLabelChange.Text = ""
            End If
        End Set
    End Property

    <Category("Behavior")>
    <Description("Auto-start monitoring when form loads")>
    Public Property AutoStart() As Boolean
        Get
            Return _autoStart
        End Get
        Set(value As Boolean)
            _autoStart = value
            If _autoStart AndAlso Not _isRunning AndAlso Not _designMode Then
                StartMonitoring()
            End If
        End Set
    End Property

    <Category("Behavior")>
    <Description("Maximum points to keep in history")>
    Public Property MaxPoints() As Integer
        Get
            Return _maxPoints
        End Get
        Set(value As Integer)
            _maxPoints = Math.Max(10, value)
            While _values.Count > _maxPoints
                _values.RemoveAt(0)
            End While
            Me.Invalidate()
        End Set
    End Property

    <Category("Behavior")>
    <Description("Start/Stop monitoring")>
    Public Property IsRunning() As Boolean
        Get
            Return _isRunning
        End Get
        Set(value As Boolean)
            If value Then
                StartMonitoring()
            Else
                StopMonitoring()
            End If
        End Set
    End Property

    ' Read-only properties
    <Browsable(False)>
    Public ReadOnly Property IsMonitoringActive As Boolean
        Get
            Return _isMonitoringActive
        End Get
    End Property

    <Browsable(False)>
    Public ReadOnly Property CurrentValue As Double
        Get
            Return _currentSpeed
        End Get
    End Property

    ' Initialize Network
    Private Function GetActiveNetworkInterface() As NetworkInterface
        Try
            Dim interfaces As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()

            For Each ni As NetworkInterface In interfaces
                If ni.OperationalStatus = OperationalStatus.Up AndAlso
                   ni.NetworkInterfaceType <> NetworkInterfaceType.Loopback AndAlso
                   ni.NetworkInterfaceType <> NetworkInterfaceType.Tunnel Then
                    Return ni
                End If
            Next
        Catch
            Return Nothing
        End Try

        Return Nothing
    End Function

    ' Start/Stop Monitoring with Async
    Public Sub StartMonitoring()
        If _isMonitoringActive OrElse _designMode Then Return

        _isRunning = True
        _isMonitoringActive = True

        _cancellationTokenSource = New System.Threading.CancellationTokenSource()
        _monitoringTask = StartNetworkMonitoring(_cancellationTokenSource.Token)
    End Sub

    Public Sub StopMonitoring()
        _isMonitoringActive = False
        _isRunning = False

        If _cancellationTokenSource IsNot Nothing Then
            _cancellationTokenSource.Cancel()
            _cancellationTokenSource = Nothing
        End If

        _monitoringTask = Nothing
    End Sub

    ' Async network monitoring with smoother updates
    Private Async Function StartNetworkMonitoring(cancellationToken As System.Threading.CancellationToken) As Task
        Dim networkInterface As NetworkInterface = GetActiveNetworkInterface()
        Dim delay As Integer = _updateDelay

        While _isMonitoringActive AndAlso Not cancellationToken.IsCancellationRequested
            Try
                If networkInterface Is Nothing Then
                    networkInterface = GetActiveNetworkInterface()
                    If networkInterface Is Nothing Then
                        Await Task.Delay(1000, cancellationToken)
                        Continue While
                    End If
                End If

                Dim stats As IPv4InterfaceStatistics = networkInterface.GetIPv4Statistics()
                Dim currentBytes As Long = stats.BytesReceived

                If _previousBytes > 0 Then
                    Dim bytesPerSecond As Double = (currentBytes - _previousBytes) / (delay / 1000.0)
                    Dim speedInMBs As Double = bytesPerSecond / (1024 * 1024)

                    Dim smoothedSpeed As Double = SmoothSpeed(speedInMBs)
                    Dim displaySpeed As Double = SmoothDisplaySpeed(smoothedSpeed)

                    UpdateStatistics(displaySpeed)
                    CurrentSpeed = displaySpeed

                    _values.Add(displaySpeed)
                    While _values.Count > _maxPoints
                        _values.RemoveAt(0)
                    End While
                End If

                _previousBytes = currentBytes

            Catch ex As Exception
                networkInterface = Nothing
            End Try

            Try
                Await Task.Delay(delay, cancellationToken)
            Catch ex As OperationCanceledException
                Exit While
            End Try
        End While

        _isMonitoringActive = False
    End Function

    Private Function SmoothSpeed(newSpeed As Double) As Double
        _smoothedValues.Add(newSpeed)
        If _smoothedValues.Count > _smoothness Then
            _smoothedValues.RemoveAt(0)
        End If

        If _smoothedValues.Count = 0 Then Return newSpeed

        Dim sum As Double = 0
        Dim weightSum As Double = 0

        For i As Integer = 0 To _smoothedValues.Count - 1
            Dim weight As Double = (i + 1) / _smoothedValues.Count
            sum += _smoothedValues(i) * weight
            weightSum += weight
        Next

        Return sum / weightSum
    End Function

    Private Function SmoothDisplaySpeed(newSpeed As Double) As Double
        _speedBuffer.Add(newSpeed)
        If _speedBuffer.Count > 3 Then
            _speedBuffer.RemoveAt(0)
        End If

        If _speedBuffer.Count = 0 Then Return newSpeed

        Dim avg As Double = _speedBuffer.Average()

        If _lastDisplaySpeed = 0 Then
            _lastDisplaySpeed = avg
        Else
            _lastDisplaySpeed = _lastDisplaySpeed * 0.7 + avg * 0.3
        End If

        Return _lastDisplaySpeed
    End Function

    Private Sub UpdateStatistics(speed As Double)
        _speedHistory.Add(speed)
        _totalSpeed += speed
        _speedCount += 1

        If speed > _maxSpeedHistory Then
            _maxSpeedHistory = speed
        End If

        If speed < _minSpeedHistory Then
            _minSpeedHistory = speed
        End If

        While _speedHistory.Count > 100
            _speedHistory.RemoveAt(0)
        End While

        UpdateAllLabels()
    End Sub

    Private Sub UpdateAllLabels()
        UpdateLabelSpeed()
        UpdateLabelMax()
        UpdateLabelMin()
        UpdateLabelAverage()
        UpdateLabelChange()
    End Sub

    Private Sub UpdateLabelSpeed()
        Try
            If _targetLabelSpeed IsNot Nothing AndAlso Not _targetLabelSpeed.IsDisposed AndAlso _showSpeed Then
                _targetLabelSpeed.Text = String.Format("{0:F2} MB/s", _currentSpeed)
            End If
        Catch
        End Try
    End Sub

    Private Sub UpdateLabelMax()
        Try
            If _targetLabelMax IsNot Nothing AndAlso Not _targetLabelMax.IsDisposed AndAlso _showMax Then
                _targetLabelMax.Text = String.Format("Max: {0:F2} MB/s", _maxSpeedHistory)
            End If
        Catch
        End Try
    End Sub

    Private Sub UpdateLabelMin()
        Try
            If _targetLabelMin IsNot Nothing AndAlso Not _targetLabelMin.IsDisposed AndAlso _showMin Then
                Dim minValue As Double = If(_minSpeedHistory = Double.MaxValue, 0, _minSpeedHistory)
                _targetLabelMin.Text = String.Format("Min: {0:F2} MB/s", minValue)
            End If
        Catch
        End Try
    End Sub

    Private Sub UpdateLabelAverage()
        Try
            If _targetLabelAverage IsNot Nothing AndAlso Not _targetLabelAverage.IsDisposed AndAlso _showAverage Then
                Dim avg As Double = If(_speedCount > 0, _totalSpeed / _speedCount, 0)
                _targetLabelAverage.Text = String.Format("Avg: {0:F2} MB/s", avg)
            End If
        Catch
        End Try
    End Sub

    Private Sub UpdateLabelChange()
        Try
            If _targetLabelChange IsNot Nothing AndAlso Not _targetLabelChange.IsDisposed AndAlso _showChange Then
                If _speedHistory.Count >= 2 Then
                    Dim oldVal As Double = _speedHistory(_speedHistory.Count - 2)
                    Dim change As Double = If(oldVal > 0, ((_currentSpeed - oldVal) / oldVal) * 100, 0)
                    Dim direction As String = If(change >= 0, "▲", "▼")
                    Dim color As Color = If(change >= 0, _lineColorUp, _lineColorDown)
                    _targetLabelChange.ForeColor = color
                    _targetLabelChange.Text = String.Format("{0} {1:F1}%", direction, Math.Abs(change))
                Else
                    _targetLabelChange.Text = "0%"
                End If
            End If
        Catch
        End Try
    End Sub

    Public Sub UpdateSpeed(speedInMBs As Double)
        If _designMode Then Return
        Dim smoothedSpeed As Double = SmoothSpeed(speedInMBs)
        Dim displaySpeed As Double = SmoothDisplaySpeed(smoothedSpeed)
        CurrentSpeed = displaySpeed
        _values.Add(displaySpeed)
        While _values.Count > _maxPoints
            _values.RemoveAt(0)
        End While
        Me.Invalidate()
    End Sub

    Public Sub ResetStatistics()
        _speedHistory.Clear()
        _smoothedValues.Clear()
        _speedBuffer.Clear()
        _lastDisplaySpeed = 0
        _maxSpeedHistory = 0
        _minSpeedHistory = Double.MaxValue
        _totalSpeed = 0
        _speedCount = 0
        _values.Clear()
        UpdateAllLabels()
        Me.Invalidate()
    End Sub

    ' Paint Method
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        If Me.Width < 50 OrElse Me.Height < 50 Then
            Return
        End If

        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.HighQuality
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.Clear(Me.BackColor)

        Dim padding As Integer = 10
        Dim titleHeight As Integer = 18
        Dim lineHeight As Integer = 28

        Dim titleY As Integer = padding
        Dim lineY As Integer = titleY + titleHeight + 8
        Dim lineWidth As Integer = Me.Width - (padding * 2) - 55
        If lineWidth < 10 Then lineWidth = 10

        ' Draw title
        Using titleFont As New Font("Segoe UI", 9, FontStyle.Regular)
            Using titleBrush As New SolidBrush(Color.FromArgb(80, 80, 80))
                g.DrawString(_labelText, titleFont, titleBrush, padding, titleY)
            End Using
        End Using

        ' Draw speed value on control
        Using speedFont As New Font("Segoe UI", 12, FontStyle.Bold)
            Using speedBrush As New SolidBrush(Color.FromArgb(50, 50, 50))
                Dim speedText As String = String.Format("{0:F2}", _currentSpeed)
                Dim speedSize As SizeF = g.MeasureString(speedText, speedFont)
                Dim speedX As Single = Me.Width - padding - speedSize.Width - 45
                g.DrawString(speedText, speedFont, speedBrush, speedX, titleY - 2)
            End Using
        End Using

        ' Draw "MB/s"
        Using unitFont As New Font("Segoe UI", 7, FontStyle.Regular)
            Using unitBrush As New SolidBrush(Color.FromArgb(150, 150, 150))
                Dim unitText As String = "MB/s"
                Dim unitSize As SizeF = g.MeasureString(unitText, unitFont)
                Dim unitX As Single = Me.Width - padding - unitSize.Width - 45
                g.DrawString(unitText, unitFont, unitBrush, unitX, titleY + 16)
            End Using
        End Using

        ' Draw Sparkline
        If _values.Count >= 2 Then
            DrawSparkline(g, padding, lineY, lineWidth, lineHeight)
        Else
            Using pen As New Pen(Color.FromArgb(200, 200, 200), 1.5)
                pen.DashStyle = DashStyle.Dash
                Dim midY As Single = CSng(lineY + lineHeight / 2)
                g.DrawLine(pen, padding, midY, padding + lineWidth, midY)
            End Using
        End If

        ' Draw reference values
        Using refFont As New Font("Segoe UI", 7, FontStyle.Regular)
            Using refBrush As New SolidBrush(Color.FromArgb(130, 130, 130))
                g.DrawString("0", refFont, refBrush, padding - 2, lineY + lineHeight + 3)

                Dim maxText As String = String.Format("{0:F0}", _maxSpeed)
                Dim maxSize As SizeF = g.MeasureString(maxText, refFont)
                Dim maxX As Single = padding + lineWidth - maxSize.Width + 2
                If maxX < padding Then maxX = padding
                g.DrawString(maxText, refFont, refBrush, maxX, lineY + lineHeight + 3)
            End Using
        End Using

        ' Draw background grid lines
        Using gridPen As New Pen(Color.FromArgb(30, 200, 200, 200), 0.5)
            For i As Integer = 1 To 3
                Dim yPos As Integer = lineY + CInt((lineHeight * i) / 4)
                g.DrawLine(gridPen, padding, yPos, padding + lineWidth, yPos)
            Next
        End Using
    End Sub

    ' Draw Sparkline with glow effect
    Private Sub DrawSparkline(g As Graphics, padding As Integer, lineY As Integer, lineWidth As Integer, lineHeight As Integer)
        If _values.Count < 2 Then Return

        Dim minVal As Double = _values.Min()
        Dim maxVal As Double = _values.Max()

        If maxVal = minVal Then
            maxVal = minVal + 1
        End If

        Dim range As Double = maxVal - minVal
        Dim margin As Double = range * 0.15
        minVal = Math.Max(0, minVal - margin)
        maxVal = maxVal + margin

        If maxVal <= minVal Then
            maxVal = minVal + 1
        End If

        Dim startX As Integer = padding
        Dim endX As Integer = padding + lineWidth
        Dim width As Integer = endX - startX

        If width <= 0 Then Return

        ' Create points list
        Dim points As New List(Of PointF)()

        For i As Integer = 0 To _values.Count - 1
            Dim x As Single = CSng(startX + (i * width / (_values.Count - 1)))
            Dim y As Single = CSng(lineY + lineHeight - ((_values(i) - minVal) * lineHeight / (maxVal - minVal)))
            points.Add(New PointF(x, y))
        Next

        If points.Count < 2 Then Return

        ' Get line color
        Dim lineColor As Color = GetLineColor()

        ' Draw glow effect
        Using glowPen As New Pen(Color.FromArgb(40, lineColor), 8)
            glowPen.LineJoin = LineJoin.Round
            For i As Integer = 0 To points.Count - 2
                g.DrawLine(glowPen, points(i), points(i + 1))
            Next
        End Using

        ' Draw main line
        Using pen As New Pen(lineColor, 2.5)
            pen.LineJoin = LineJoin.Round
            pen.StartCap = LineCap.Round
            pen.EndCap = LineCap.Round

            For i As Integer = 0 To points.Count - 2
                g.DrawLine(pen, points(i), points(i + 1))
            Next
        End Using

        ' Draw fill area under the line
        If points.Count >= 2 Then
            Try
                Using path As New GraphicsPath()
                    Dim pathPoints As PointF() = points.ToArray()
                    path.AddPolygon(pathPoints)

                    Dim bottomLeft As New PointF(startX, lineY + lineHeight)
                    Dim bottomRight As New PointF(endX, lineY + lineHeight)
                    path.AddLine(pathPoints(pathPoints.Length - 1), bottomRight)
                    path.AddLine(bottomRight, bottomLeft)
                    path.AddLine(bottomLeft, pathPoints(0))

                    Using fillBrush As New LinearGradientBrush(
                        New Rectangle(startX, lineY, width, lineHeight),
                        Color.FromArgb(60, lineColor),
                        Color.FromArgb(10, lineColor),
                        LinearGradientMode.Vertical)
                        g.FillPath(fillBrush, path)
                    End Using
                End Using
            Catch
                ' If fill fails, continue without fill
            End Try
        End If

        ' Draw last point
        If points.Count > 0 Then
            Dim lastPoint As PointF = points(points.Count - 1)

            ' Glow for last point
            Using glowBrush As New SolidBrush(Color.FromArgb(60, lineColor))
                g.FillEllipse(glowBrush, lastPoint.X - 6, lastPoint.Y - 6, 12, 12)
            End Using

            ' Main point
            Using brush As New SolidBrush(lineColor)
                g.FillEllipse(CType(brush, Brush), CSng(lastPoint.X - 3.5), CSng(lastPoint.Y - 3.5), 7, 7)
            End Using

            ' Inner white point
            Using innerBrush As New SolidBrush(Color.White)
                g.FillEllipse(CType(innerBrush, Brush), CSng(lastPoint.X - 1.5), CSng(lastPoint.Y - 1.5), 3, 3)
            End Using
        End If
    End Sub

    Private Function GetLineColor() As Color
        If _values.Count >= 2 Then
            If _values.Last() > _values(_values.Count - 2) Then
                Return _lineColorUp
            ElseIf _values.Last() < _values(_values.Count - 2) Then
                Return _lineColorDown
            End If
        End If
        Return _lineColor
    End Function

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)
        If Not _designMode AndAlso _autoStart AndAlso Not _isMonitoringActive Then
            StartMonitoring()
        End If
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            StopMonitoring()
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class