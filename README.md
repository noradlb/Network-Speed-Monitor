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

### Step 1: Add the Control to Your Project
1. Copy the `ArrowIndicator.vb` file to your project
2. Build the project
3. The control will appear in the Toolbox

### Step 2: Add to Form
```vb.net
' Create the control programmatically
Dim indicator As New ArrowIndicator()
indicator.Location = New Point(20, 20)
indicator.Size = New Size(400, 80)
indicator.DisplayText = "Network Usage"
indicator.MaxSpeed = 10
indicator.AutoStart = True
Me.Controls.Add(indicator)
