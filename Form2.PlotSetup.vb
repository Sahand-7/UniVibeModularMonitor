Imports System.IO
Imports System.Reflection.Emit
Imports System.Text
Imports System.Threading
Imports System.Web.UI.WebControls
Imports OxyPlot
Imports OxyPlot.Annotations
Imports OxyPlot.Axes
Imports OxyPlot.Legends
Imports OxyPlot.Series
Imports OxyPlot.WindowsForms

Public Partial Class Form2

    Private Sub InitializePlotModel()
        plotModel = New PlotModel()
        plotModel.Background = OxyColors.DarkGray

        xAxis = New DateTimeAxis() With {
            .Position = AxisPosition.Bottom,
            .StringFormat = "HH:mm:ss.f",
            .IntervalType = DateTimeIntervalType.Manual,
            .IntervalLength = 30,
            .Title = "Time",
            .Angle = -70,
            .MajorGridlineStyle = OxyPlot.LineStyle.Dash,
            .MajorGridlineColor = OxyColors.LightGray,
            .MajorTickSize = 10,
            .MinorTicklineColor = OxyColors.Red
        }

        yAxis = New LinearAxis() With {
            .Position = AxisPosition.Left,
            .MajorGridlineStyle = OxyPlot.LineStyle.Dash,
            .MajorGridlineColor = OxyColors.LightGray,
            .MajorTickSize = 10,
            .MinorTicklineColor = OxyColors.Red
        }
    End Sub

    Private Sub InitializeSeries()
        out_cold_water = New LineSeries() With {.Title = "Cold water", .Color = OxyColors.Blue, .IsVisible = True}
        out_hot_water = New LineSeries() With {.Title = "Hot water", .Color = OxyColors.Red, .IsVisible = True}
        out_hard_water = New LineSeries() With {.Title = "Hard water", .Color = OxyColors.DarkGray, .IsVisible = False}

        out_drain = New LineSeries() With {.Title = "Drain", .Color = OxyColors.White, .IsVisible = False}
        out_rec = New LineSeries() With {.Title = "Rec.Pump", .Color = OxyColors.Black, .IsVisible = True}
        out_heater = New LineSeries() With {.Title = "Heater", .Color = OxyColors.Orange, .IsVisible = True}

        an_water_temp = New LineSeries() With {.Title = "Temperature", .Color = OxyColors.DarkRed, .IsVisible = True}
        an_water_tempSetpoint = New LineSeries() With {.Title = "Temp. Setpoint", .Color = OxyColors.DarkRed, .LineStyle = LineStyle.DashDot, .IsVisible = True}
        an_water_level = New LineSeries() With {.Title = "Water Level", .Color = OxyColors.DarkOrchid, .IsVisible = True}
        an_water_levelSetpoint = New LineSeries() With {.Title = "Level Setpoint", .Color = OxyColors.DarkOrchid, .LineStyle = LineStyle.DashDot, .IsVisible = True}
        an_drum_speed = New LineSeries() With {.Title = "Drum Speed", .Color = OxyColors.DarkGreen}
        an_drum_speed_setpoint = New LineSeries() With {.Title = "Speed Setpoint", .Color = OxyColors.DarkGreen, .LineStyle = LineStyle.DashDot}

        out_hot_wash = New LineSeries() With {.Title = "Hot to Wash", .Color = OxyColors.GreenYellow, .IsVisible = True}
        out_cold_wash = New LineSeries() With {.Title = "Cold to Wash", .Color = OxyColors.Honeydew, .IsVisible = True}
        out_hot_prewash = New LineSeries() With {.Title = "Hot to Prewash", .Color = OxyColors.HotPink, .IsVisible = True}
        out_cold_prewash = New LineSeries() With {.Title = "Cold to Prewash", .Color = OxyColors.Cyan, .IsVisible = True}
        out_hot_softener = New LineSeries() With {.Title = "Hot to Softener", .Color = OxyColors.DarkSalmon, .IsVisible = True}
        out_cold_softener = New LineSeries() With {.Title = "Cold to Softener", .Color = OxyColors.Brown, .IsVisible = True}
        out_hot_bleach = New LineSeries() With {.Title = "Hot to Bleach", .Color = OxyColors.Azure, .IsVisible = True}
        out_cold_bleach = New LineSeries() With {.Title = "Cold to Bleach", .Color = OxyColors.DarkSlateGray, .IsVisible = False}

        out_liquid_pump_1 = New LineSeries() With {.Title = "Pump 1", .Color = OxyColors.GreenYellow, .IsVisible = False}
        out_liquid_pump_2 = New LineSeries() With {.Title = "Pump 2", .Color = OxyColors.Honeydew, .IsVisible = False}
        out_liquid_pump_3 = New LineSeries() With {.Title = "Pump 3", .Color = OxyColors.HotPink, .IsVisible = False}
        out_liquid_pump_4 = New LineSeries() With {.Title = "Pump 4", .Color = OxyColors.IndianRed, .IsVisible = False}
        out_liquid_pump_5 = New LineSeries() With {.Title = "Pump 5", .Color = OxyColors.DarkSalmon, .IsVisible = False}
        out_liquid_pump_6 = New LineSeries() With {.Title = "Pump 6", .Color = OxyColors.Brown, .IsVisible = False}
        out_liquid_pump_7 = New LineSeries() With {.Title = "Pump 7", .Color = OxyColors.Azure, .IsVisible = False}

        out_flush_valve = New LineSeries() With {.Title = "Flush Valve", .Color = OxyColors.BlueViolet, .IsVisible = True}
        an_axis_xy = New LineSeries() With {.Title = "Axis XY", .Color = OxyColors.Brown, .IsVisible = True}
        an_axis_z = New LineSeries() With {.Title = "Axis Z", .Color = OxyColors.DarkSlateGray, .IsVisible = True}
        an_axis_3 = New LineSeries() With {.Title = "Axis 3", .Color = OxyColors.CornflowerBlue, .IsVisible = True}

        an_module = New LineSeries() With {.Title = "Module", .Color = OxyColors.Chocolate, .IsVisible = False}
        weight = New LineSeries() With {.Title = "Weight hg", .Color = OxyColors.DarkKhaki, .IsVisible = False}

        out_drier_heater_one = New LineSeries() With {.Title = "HearterOne", .Color = OxyColors.Red, .IsVisible = True}
        out_drier_heater_two = New LineSeries() With {.Title = "HearterTwo", .Color = OxyColors.Blue, .IsVisible = True}
        out_drier_heater_three = New AreaSeries() With {.Title = "RMC", .Color = OxyColors.SkyBlue, .Fill = OxyColor.FromAColor(80, OxyColors.SkyBlue), .IsVisible = True}
    End Sub

    Private Sub ConfigurePlotAxesAndLegend()
        plotModel.Axes.Add(xAxis)
        plotModel.Axes.Add(yAxis)
        plotModel.PlotAreaBorderColor = OxyColors.Blue

        plotModel.Series.Add(out_cold_water)
        plotModel.Series.Add(out_hot_water)
        plotModel.Series.Add(out_hard_water)
        plotModel.Series.Add(out_drain)
        plotModel.Series.Add(out_heater)
        plotModel.Series.Add(out_rec)
        plotModel.Series.Add(an_water_temp)
        plotModel.Series.Add(an_water_tempSetpoint)
        plotModel.Series.Add(an_water_level)
        plotModel.Series.Add(an_water_levelSetpoint)
        plotModel.Series.Add(an_drum_speed)
        plotModel.Series.Add(an_drum_speed_setpoint)

        plotModel.Series.Add(out_hot_wash)
        plotModel.Series.Add(out_cold_wash)
        plotModel.Series.Add(out_hot_prewash)
        plotModel.Series.Add(out_cold_prewash)
        plotModel.Series.Add(out_hot_softener)
        plotModel.Series.Add(out_cold_softener)
        plotModel.Series.Add(out_cold_bleach)
        plotModel.Series.Add(out_hot_bleach)

        plotModel.Series.Add(out_liquid_pump_1)
        plotModel.Series.Add(out_liquid_pump_2)
        plotModel.Series.Add(out_liquid_pump_3)
        plotModel.Series.Add(out_liquid_pump_4)
        plotModel.Series.Add(out_liquid_pump_5)
        plotModel.Series.Add(out_liquid_pump_6)
        plotModel.Series.Add(out_liquid_pump_7)
        plotModel.Series.Add(out_flush_valve)

        plotModel.Series.Add(an_axis_xy)
        plotModel.Series.Add(an_axis_z)
        plotModel.Series.Add(an_axis_3)

        plotModel.Series.Add(an_module)
        plotModel.Series.Add(weight)
        plotModel.Series.Add(out_drier_heater_one)
        plotModel.Series.Add(out_drier_heater_two)
        plotModel.Series.Add(out_drier_heater_three)

        lastDataPointTime = DateTime.Now

        Dim legend As New Legend() With {
            .LegendPlacement = LegendPlacement.Outside,
            .LegendPosition = LegendPosition.RightTop,
            .LegendBackground = OxyColors.DarkGray,
            .LegendBorder = OxyColors.Gray,
            .LegendTextColor = OxyColor.FromRgb(0, 0, 0),
            .FontSize = 7
        }
        plotModel.Legends.Add(legend)
        plotModel.IsLegendVisible = True

        Dim currentTime As DateTime = DateTime.Now
        datetimeOrigin = currentTime

        xAxis.Minimum = DateTimeAxis.ToDouble(currentTime)
        xAxis.Maximum = DateTimeAxis.ToDouble(currentTime.AddMinutes(numericUpDown1.Value))

        yAxis.Minimum = Convert.ToDouble(numericUpDown2.Value)
        yAxis.Maximum = Convert.ToDouble(numericUpDown3.Value)
    End Sub

End Class
