# Network-Speed-Monitor
Network Speed Monitor ArrowIndicator - A beautiful, real-time network speed monitoring control with animated arrow indicator and statistics display.

![Main Interface](NetWorkSpeedMonitoring.gif)

## 📊 Overview

**Network-Speed-Monitor** is a custom Windows Forms control (VB.NET) that provides real-time network speed monitoring with a sleek, animated arrow indicator. It features a smooth sparkline chart, comprehensive statistics, and full control over displayed information.

## ✨ Features

### 🎯 Core Features
- **Real-time Network Monitoring** - Monitors network download speed in real-time using `System.Net.NetworkInformation`
- **Animated Arrow Indicator** - Visual arrow that moves along the chart based on current speed
- **Smooth Sparkline Chart** - Beautiful, anti-aliased line chart with glow effects
- **Async/Await Architecture** - Uses modern async/await patterns instead of timers for smooth performance
- **Design Mode Safe** - Control doesn't run in Visual Studio designer, only when application runs

### 📈 Statistics Display
- **Current Speed** - Real-time download speed in MB/s
- **Maximum Speed** - Highest speed recorded during session
- **Minimum Speed** - Lowest speed recorded during session
- **Average Speed** - Average speed over time
- **Speed Change** - Percentage change with ▲/▼ indicators

### 🎨 Customization Options
- **Line Colors** - Customize colors for up/down trends
- **Smoothness Level** - Adjustable smoothing (1-10)
- **Update Delay** - Control update frequency (500-1500ms)
- **Max Speed** - Set maximum scale for the chart
- **Display Text** - Customizable title

### 🎮 Control Features
- **Start/Stop Monitoring** - Toggle monitoring on/off
- **Show/Hide Statistics** - Individual checkboxes for each statistic
- **Reset Statistics** - Clear all historical data
- **Target Labels** - Assign any Label control to display values

## 🚀 Installation

### Prerequisites
- Windows OS
- Visual Studio 2019 or later
- .NET Framework 4.6.1 or higher
- VB.NET Windows Forms Project

## Step 1: Add the Control to Your Project

1. Copy the `ArrowIndicator.vb` file to your project.
2. Build the project.
3. The control will appear in the Toolbox.

---

## Step 2: Add to Form

```vb.net
' Create the control programmatically
Dim indicator As New ArrowIndicator()
indicator.Location = New Point(20, 20)
indicator.Size = New Size(400, 80)
indicator.DisplayText = "Network Usage"
indicator.MaxSpeed = 10
indicator.AutoStart = True
Me.Controls.Add(indicator)
```

---

## Step 3: Set Target Labels

```vb.net
' Assign labels to display statistics
indicator.TargetLabelSpeed = lblSpeed
indicator.TargetLabelMax = lblMax
indicator.TargetLabelMin = lblMin
indicator.TargetLabelAverage = lblAverage
indicator.TargetLabelChange = lblChange
```

---

## 🎯 Usage Examples

### Basic Usage

```vb.net
Public Class MainForm

    Private WithEvents indicator As ArrowIndicator

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        indicator = New ArrowIndicator()
        indicator.Location = New Point(20, 20)
        indicator.Size = New Size(400, 80)
        indicator.DisplayText = "Download Speed"
        indicator.MaxSpeed = 10
        indicator.AutoStart = True
        Me.Controls.Add(indicator)
    End Sub

End Class
```

---

### Full Example with CheckBox Controls

```vb.net
' CheckBox to control monitoring
Private Sub chkStartStop_CheckedChanged(sender As Object, e As EventArgs) _
    Handles chkStartStop.CheckedChanged

    If chkStartStop.Checked Then
        indicator.StartMonitoring()
    Else
        indicator.StopMonitoring()
    End If

End Sub

' CheckBox to toggle speed display
Private Sub chkShowSpeed_CheckedChanged(sender As Object, e As EventArgs) _
    Handles chkShowSpeed.CheckedChanged

    indicator.ShowSpeed = chkShowSpeed.Checked

End Sub
```

---

# ⚙️ Properties

## Appearance Properties

| Property | Type | Description | Default |
|----------|------|-------------|---------|
| DisplayText | String | Title text shown above chart | `"Network Usage"` |
| LineColor | Color | Default line color | Blue `(52,152,219)` |
| LineColorUp | Color | Line color when speed increases | Green `(46,204,113)` |
| LineColorDown | Color | Line color when speed decreases | Red `(231,76,60)` |
| Smoothness | Integer | Smoothness level `(1-10)` | `7` |
| UpdateDelay | Integer | Update interval in milliseconds `(500-1500)` | `700` |

## ⚙️ Behavior Properties

| Property    | Type      | Description              | Default |
| ----------- | --------- | ------------------------ | ------- |
| `MaxSpeed`  | `Double`  | Maximum scale value      | `10`    |
| `AutoStart` | `Boolean` | Auto-start monitoring    | `True`  |
| `IsRunning` | `Boolean` | Current monitoring state | `False` |
| `MaxPoints` | `Integer` | Maximum history points   | `60`    |

---

## 🖥️ Display Properties

| Property      | Type      | Description        | Default |
| ------------- | --------- | ------------------ | ------- |
| `ShowSpeed`   | `Boolean` | Show current speed | `True`  |
| `ShowMax`     | `Boolean` | Show maximum speed | `False` |
| `ShowMin`     | `Boolean` | Show minimum speed | `False` |
| `ShowAverage` | `Boolean` | Show average speed | `False` |
| `ShowChange`  | `Boolean` | Show speed change  | `False` |

---

## 🎯 Target Label Properties

| Property             | Type    | Description             |
| -------------------- | ------- | ----------------------- |
| `TargetLabelSpeed`   | `Label` | Label for current speed |
| `TargetLabelMax`     | `Label` | Label for maximum speed |
| `TargetLabelMin`     | `Label` | Label for minimum speed |
| `TargetLabelAverage` | `Label` | Label for average speed |
| `TargetLabelChange`  | `Label` | Label for speed change  |

---

## 🔧 Methods

### Public Methods

| Method                         | Description                      |
| ------------------------------ | -------------------------------- |
| `StartMonitoring()`            | Start network speed monitoring   |
| `StopMonitoring()`             | Stop network speed monitoring    |
| `ResetStatistics()`            | Reset all statistics and history |
| `UpdateSpeed(speed As Double)` | Manually update the speed value  |

---

### Read-Only Properties

| Property             | Description                            |
| -------------------- | -------------------------------------- |
| `IsMonitoringActive` | Returns `True` if monitoring is active |
| `CurrentValue`       | Current speed value                    |
| `MaxValue`           | Maximum recorded speed                 |
| `MinValue`           | Minimum recorded speed                 |
| `AverageValue`       | Average speed                          |

---

# 🖥️ User Interface

## Main Components

* **Title Bar** - Customizable title text.
* **Speed Value** - Current speed displayed in MB/s.
* **Sparkline Chart** - Smooth animated line with glow effects.
* **Reference Marks** - `0` and `Max` values with tick marks.
* **Grid Lines** - Subtle background grid.
* **Statistics Panel** - Displays all statistics in an organized layout.

# ☑️ CheckBox Controls

* **Start/Stop Monitor** - Toggle monitoring.
* **Show Speed** - Show or hide the current speed.
* **Show Max** - Show or hide the maximum speed.
* **Show Min** - Show or hide the minimum speed.
* **Show Average** - Show or hide the average speed.
* **Show Change** - Show or hide the percentage change.
* **Reset Stats** - Reset all statistics.

---

# 📝 Code Structure

```text
Network-Speed-Monitor/
├── ArrowIndicator.vb         # Main control class
├── MainForm.vb               # Example form implementation
├── MainForm.Designer.vb      # Form designer code
└── README.md                 # This file
```

---

# 🎨 Design Features

## Sparkline Chart

* **Anti-aliased Rendering** - Smooth and professional appearance.
* **Glow Effect** - Subtle glow surrounding the line.
* **Gradient Fill** - Beautiful gradient beneath the chart line.
* **Animated Point** - Pulsing endpoint with glow animation.
* **Color Coding** - Line color changes according to trend direction.

---

## 🚀 Performance Optimizations

* **Double Buffering** - Eliminates flickering during redraw.
* **Async/Await** - Non-blocking network monitoring.
* **Smart Smoothing** - Weighted moving average for smoother output.
* **Efficient Painting** - Redraws only when necessary.
* **Memory Management** - Automatic cleanup when disposed.

---

# 🐛 Troubleshooting

## Control Doesn't Appear in the Toolbox

1. Build the project.
2. If it still doesn't appear, restart Visual Studio.
3. Right-click **Toolbox** → **Choose Items...** → **Browse...** → Select your compiled DLL.

---

## Design Mode Errors

The control automatically detects **Design Mode** and disables monitoring while the designer is open.

---

## Network Interface Not Found

* Ensure an active network connection is available.
* The control automatically retries every second.
* Check Windows Firewall or network security settings.

---

## Performance Issues

* Reduce **Smoothness** to `1-5`.
* Increase **UpdateDelay** to `1000-1500 ms`.
* Reduce **MaxPoints** to `20-40`.

---

# 📋 Requirements

| Requirement          | Value                     |
| -------------------- | ------------------------- |
| **.NET Framework**   | 4.6.1 or higher           |
| **Operating System** | Windows 7 or higher       |
| **Permissions**      | Internet / Network access |

