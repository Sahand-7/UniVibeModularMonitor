Imports System.IO
Imports System.Reflection.Emit
Imports System.Text
Imports System.Threading
Imports System.Collections.Concurrent
Imports System.Web.UI.WebControls
Imports OxyPlot
Imports OxyPlot.Annotations
Imports OxyPlot.Axes
Imports OxyPlot.Legends
Imports OxyPlot.Series
Imports OxyPlot.WindowsForms

Public Class Form2

    Private ReadOnly queue As New ConcurrentQueue(Of Double())()
    Private ReadOnly plotRefreshTimer As New Timer()
    Private ReadOnly sessionHistory As New List(Of GraphSample)()
    Private ReadOnly sessionHistoryLock As New Object()
    Private lastPlotRefreshUtc As DateTime = DateTime.MinValue
    Private lastUiRefreshUtc As DateTime = DateTime.MinValue
    Private Const PlotRefreshIntervalMs As Integer = 250
    Private Const UiRefreshIntervalMs As Integer = 200
    Private Const QueueDrainBatchSize As Integer = 25
    Private Const MaxPointsPerSeries As Integer = 5000
    Private Const MaxAnnotations As Integer = 200

    Public imageName As String

    Dim lastDataPointTime As DateTime
    Dim blink As Boolean = False
    Dim blinkCounter As Integer = 0

    '0 : Cold water
    '1 : Hot water
    '2 : Hard water
    '3 : Drain
    '4 : heater
    '5 : Hot to wash 
    '6 : Cold to wash
    '7 : Hot to prewash
    '8: Cold to prewash
    '9: Hot to softener
    '10: Cold to softener
    '11: Hot to bleach
    '12: Cold to bleach
    '13: Door lock signal
    '14: Water temperature
    '15: Water temperature setpoint
    '16: Water level
    '17: Water level setpoint
    '18: drum speed
    '19: drum speed setpoint
    '20: Output pump 1
    '21: Output pump 2
    '22: Output pump 3
    '23: Output pump 4
    '24: Output pump 5
    '25: Output pump 6
    '26: Output pump 7
    '27: Output Flush valve
    '28: Axis XY
    '29: Axis Z
    '30: Axis 3
    '31: Module Index



    Dim out_cold_water As LineSeries
    Dim out_hot_water As LineSeries
    Dim out_hard_water As LineSeries
    Dim out_drain As LineSeries
    Dim out_rec As LineSeries
    Dim out_heater As LineSeries
    Dim out_hot_wash As LineSeries
    Dim out_cold_wash As LineSeries
    Dim out_hot_prewash As LineSeries
    Dim out_cold_prewash As LineSeries
    Dim out_hot_softener As LineSeries
    Dim out_cold_softener As LineSeries
    Dim out_hot_bleach As LineSeries
    Dim out_cold_bleach As LineSeries
    Dim out_liquid_pump_1 As LineSeries
    Dim out_liquid_pump_2 As LineSeries
    Dim out_liquid_pump_3 As LineSeries
    Dim out_liquid_pump_4 As LineSeries
    Dim out_liquid_pump_5 As LineSeries
    Dim out_liquid_pump_6 As LineSeries
    Dim out_liquid_pump_7 As LineSeries
    Dim out_flush_valve As LineSeries
    Dim an_water_temp As LineSeries
    Dim an_water_tempSetpoint As LineSeries
    Dim an_water_level As LineSeries
    Dim an_water_levelSetpoint As LineSeries
    Dim an_drum_speed As LineSeries
    Dim an_drum_speed_setpoint As LineSeries
    Dim an_axis_xy As LineSeries
    Dim an_axis_z As LineSeries
    Dim an_axis_3 As LineSeries
    Dim an_module As LineSeries
    Dim weight As LineSeries
    Dim out_drier_heater_one As LineSeries
    Dim out_drier_heater_two As LineSeries
    Dim out_drier_heater_three As LineSeries


    Dim plotModel As PlotModel

    Dim xAxis As DateTimeAxis
    Dim yAxis As LinearAxis
    Dim datetimeOrigin As DateTime
    Private dataProcessingThread As Thread
    Dim isProcessingData As Boolean = False
    Dim offset As Integer
    Dim previousModule As Integer = 0
    Dim moduleStartTime As DateTime
    Dim moduleBackgroundColor As OxyColor = OxyColors.Transparent
    Private programAnnotations As New List(Of TextAnnotation)
    Private previousProgramName As String = ""
    Public Shared currentProgramName As String = ""

    Private Structure GraphSample
        Public Property Timestamp As DateTime
        Public Property Values As Double()
    End Structure

    Private programStartTime As DateTime
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Inizializza il modello del grafico
        plotModel = New PlotModel()
        plotModel.Background = OxyColors.DarkGray

        ' Aggiungi un asse X di tipo DateTime
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

        'Creazione dell'asse Y
        yAxis = New LinearAxis() With {
            .Position = AxisPosition.Left,
            .MajorGridlineStyle = OxyPlot.LineStyle.Dash,
            .MajorGridlineColor = OxyColors.LightGray,
            .MajorTickSize = 10,
            .MinorTicklineColor = OxyColors.Red
        }

        '0 : Cold water
        '1 : Hot water
        '2 : Hard water
        '3 : Drain
        '4 : heater
        '5 : Hot to wash 
        '6 : Cold to wash
        '7 : Hot to prewash
        '8: Cold to prewash
        '9: Hot to softener
        '10: Cold to softener
        '11: Hot to bleach
        '12: Cold to bleach
        '13: Door lock signal
        '14: Water temperature
        '15: Water temperature setpoint
        '16: Water level
        '17: Water level setpoint
        '18: drum speed
        '19: drum speed setpoint
        '20: Output pump 1
        '21: Output pump 2
        '22: Output pump 3
        '23: Output pump 4
        '24: Output pump 5
        '25: Output pump 6
        '26: Output pump 7
        '27: Flush valve
        '28: Axis XY
        '29: Axis Z
        '30: Axis 3
        '31: Module Index

        'Line series definition
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
        '' out_drier_heater_three = New LineSeries() With {.Title = "RMC", .Color = OxyColors.SkyBlue, .fill = OxyColor.FromAColor(80, OxyColors.SkyBlue), .IsVisible = True}
        out_drier_heater_three = New AreaSeries() With {.Title = "RMC", .Color = OxyColors.SkyBlue, .Fill = OxyColor.FromAColor(80, OxyColors.SkyBlue), .IsVisible = True}

        'Aggiungi l'asse delle X al modello del grafico
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
        'Inizializza l'ultima marca temporale dei dati
        lastDataPointTime = DateTime.Now

        ' Aggiungi una legenda al grafico
        Dim legend As New Legend() With {
            .LegendPlacement = LegendPlacement.Outside,
            .LegendPosition = LegendPosition.RightTop,
            .LegendBackground = OxyColors.DarkGray, 'Colore di sfondo della legenda
            .LegendBorder = OxyColors.Gray, 'Colore del bordo della legenda
            .LegendTextColor = OxyColor.FromRgb(0, 0, 0),
            .FontSize = 7
        }
        plotModel.Legends.Add(legend)
        plotModel.IsLegendVisible = True

        'Riposiziona l'asse delle X per visualizzare l'intervallo di tempo desiderato
        Dim currentTime As DateTime = DateTime.Now
        datetimeOrigin = currentTime

        xAxis.Minimum = DateTimeAxis.ToDouble(currentTime)
        xAxis.Maximum = DateTimeAxis.ToDouble(currentTime.AddMinutes(numericUpDown1.Value))

        yAxis.Minimum = Convert.ToDouble(numericUpDown2.Value)
        yAxis.Maximum = Convert.ToDouble(numericUpDown3.Value)

        'Associa il modello del grafico al PlotView
        PlotView1.Model = plotModel




    End Sub


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SubscribeToBufferAddedEvent(AddressOf AddBufferToQueue)
        SubscribeToMainFormClosedEvent(AddressOf TerminateAll)

        plotRefreshTimer.Interval = PlotRefreshIntervalMs
        AddHandler plotRefreshTimer.Tick, AddressOf PlotRefreshTimer_Tick
        plotRefreshTimer.Start()

        isProcessingData = True
        If Form1.isCommunicating Then
            Button8.Text = "STOP"
        Else
            Button8.Text = "START"
        End If

    End Sub
    Private Function GetModuleName(moduleId As Integer) As String

        Select Case moduleId
            Case 0 : Return "IDLE"
            Case 17 : Return "WEIGHING"
            Case 1 : Return "PRE-WASH"
            Case 2 : Return "MAIN WASH"
            Case 3 : Return "RINSE"
            Case 4 : Return "PRE-RINSE"
            Case 6 : Return "COOL DOWN"
            Case 7 : Return "DRAIN"
            Case 8 : Return "EXTRACTION"
            Case 15 : Return "END_WAIT"
            Case Else : Return "UNKNOWN"
        End Select

    End Function
    Private Function GetModuleColor(moduleId As Integer) As OxyColor

        Select Case moduleId

            Case 0 ' IDLE
                Return OxyColor.FromAColor(30, OxyColors.Gray)

            Case 17 ' WEIGHING
                Return OxyColor.FromAColor(60, OxyColors.LightSkyBlue)

            Case 1 ' PRE-WASH
                Return OxyColor.FromAColor(60, OxyColors.LightGreen)

            Case 2 ' MAIN WASH
                Return OxyColor.FromAColor(60, OxyColors.DodgerBlue)

            Case 3 ' RINSE
                Return OxyColor.FromAColor(60, OxyColors.Aqua)

            Case 4 ' PRE-RINSE
                Return OxyColor.FromAColor(60, OxyColors.Cyan)

            Case 6 ' COOL DOWN
                Return OxyColor.FromAColor(60, OxyColors.LightSteelBlue)

            Case 7 ' DRAIN
                Return OxyColor.FromAColor(60, OxyColors.SaddleBrown)

            Case 8 ' EXTRACTION
                Return OxyColor.FromAColor(60, OxyColors.OrangeRed)

            Case 15 ' END WAIT
                Return OxyColor.FromAColor(60, OxyColors.DarkGray)

            Case Else
                Return OxyColor.FromAColor(40, OxyColors.Yellow)

        End Select

    End Function




    'This event is raised when I close the main form and is used to terminate the process that manage the incoming graph data in the queue
    Private Sub PlotRefreshTimer_Tick(sender As Object, e As EventArgs)
        DrainQueueAndRefresh()
    End Sub

    Private Sub TerminateAll(obj As Short)
        StopProcessing()
    End Sub

    Private Sub AddBufferToQueue(obj() As Double)
        If obj Is Nothing Then Return
        queue.Enqueue(DirectCast(obj.Clone(), Double()))
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True     ' prevent disposal
        Me.Hide()           ' keep running in background
    End Sub
    Public Sub StopProcessing()
        isProcessingData = False
        plotRefreshTimer.Stop()
        UnsubscribeToBufferAddedEvent(AddressOf AddBufferToQueue)
    End Sub


    Public Sub SubscribeToBufferAddedEvent(handler As Action(Of Double()))
        Dim form1 As Form1 = Application.OpenForms.OfType(Of Form1)().FirstOrDefault()
        If form1 IsNot Nothing Then
            Debug.WriteLine("Add handler BufferAdded in the graphic module")
            AddHandler form1.BufferAdded, handler
        End If
    End Sub

    Public Sub SubscribeToMainFormClosedEvent(handler As Action(Of Int16))
        Dim form1 As Form1 = Application.OpenForms.OfType(Of Form1)().FirstOrDefault()
        If form1 IsNot Nothing Then
            Debug.WriteLine("Add handler BufferAdded in the graphic module")
            AddHandler form1.MainFormClosed, handler
        End If
    End Sub

    Public Sub UnsubscribeToBufferAddedEvent(handler As Action(Of Double()))
        Dim form1 As Form1 = Application.OpenForms.OfType(Of Form1)().FirstOrDefault()
        If form1 IsNot Nothing Then
            Debug.WriteLine("Remove handler BufferAdded in the graphic module")
            RemoveHandler form1.BufferAdded, handler
        End If
    End Sub

    Dim startTimeAquired As Boolean = False
    Dim startTime As DateTime

    Private Sub DrainQueueAndRefresh()
        If Not isProcessingData Then Return

        Dim processedCount As Integer = 0
        Dim requiresPlotRefresh As Boolean = False
        Dim latestUiArray As Double() = Nothing
        Dim sample As Double() = Nothing

        While processedCount < QueueDrainBatchSize AndAlso queue.TryDequeue(sample)
            ProcessSample(sample)
            latestUiArray = sample
            requiresPlotRefresh = True
            processedCount += 1
        End While

        Dim nowUtc As DateTime = DateTime.UtcNow

        If latestUiArray IsNot Nothing AndAlso (lastUiRefreshUtc = DateTime.MinValue OrElse (nowUtc - lastUiRefreshUtc).TotalMilliseconds >= UiRefreshIntervalMs) Then
            UpdateLiveReadouts(latestUiArray)
            lastUiRefreshUtc = nowUtc
        End If

        If requiresPlotRefresh AndAlso (lastPlotRefreshUtc = DateTime.MinValue OrElse (nowUtc - lastPlotRefreshUtc).TotalMilliseconds >= PlotRefreshIntervalMs) Then
            plotModel.InvalidatePlot(False)
            lastPlotRefreshUtc = nowUtc
        End If
    End Sub

    Private Sub ProcessSample(array() As Double)
        Dim currentTime As DateTime = DateTime.Now

        If startTimeAquired = False Then
            startTime = currentTime
            startTimeAquired = True
        End If

        AppendHistorySample(currentTime, array)

        If ((currentTime >= startTime.AddMinutes(numericUpDown1.Value)) AndAlso _ck_autorange.Checked) Then
            numericUpDown1.Value = numericUpDown1.Value + 1
        End If

        Dim currentTimeDouble As Double = DateTimeAxis.ToDouble(currentTime)

        AddPointWithTrim(out_cold_water, currentTimeDouble, array(0))
        AddPointWithTrim(out_hot_water, currentTimeDouble, array(1))
        AddPointWithTrim(out_drain, currentTimeDouble, array(2))
        AddPointWithTrim(out_rec, currentTimeDouble, array(3))
        AddPointWithTrim(out_heater, currentTimeDouble, array(4))
        AddPointWithTrim(out_cold_wash, currentTimeDouble, array(5))
        AddPointWithTrim(out_hot_wash, currentTimeDouble, array(6))
        AddPointWithTrim(out_cold_prewash, currentTimeDouble, array(7))
        AddPointWithTrim(out_hot_prewash, currentTimeDouble, array(8))
        AddPointWithTrim(out_cold_softener, currentTimeDouble, array(9))
        AddPointWithTrim(out_hot_softener, currentTimeDouble, array(10))
        AddPointWithTrim(out_cold_bleach, currentTimeDouble, array(11))
        AddPointWithTrim(out_hot_bleach, currentTimeDouble, array(12))
        AddPointWithTrim(an_water_temp, currentTimeDouble, array(14))
        AddPointWithTrim(an_water_tempSetpoint, currentTimeDouble, array(15))
        AddPointWithTrim(an_water_level, currentTimeDouble, array(16))
        AddPointWithTrim(an_water_levelSetpoint, currentTimeDouble, array(17))
        AddPointWithTrim(an_drum_speed, currentTimeDouble, array(18))
        AddPointWithTrim(an_drum_speed_setpoint, currentTimeDouble, array(19))
        AddPointWithTrim(out_liquid_pump_1, currentTimeDouble, array(20))
        AddPointWithTrim(out_liquid_pump_2, currentTimeDouble, array(21))
        AddPointWithTrim(out_liquid_pump_3, currentTimeDouble, array(22))
        AddPointWithTrim(out_liquid_pump_4, currentTimeDouble, array(23))
        AddPointWithTrim(out_liquid_pump_5, currentTimeDouble, array(24))
        AddPointWithTrim(out_liquid_pump_6, currentTimeDouble, array(25))
        AddPointWithTrim(out_liquid_pump_7, currentTimeDouble, array(26))
        AddPointWithTrim(out_flush_valve, currentTimeDouble, array(27))
        AddPointWithTrim(an_axis_xy, currentTimeDouble, array(28))
        AddPointWithTrim(an_axis_z, currentTimeDouble, array(29))
        AddPointWithTrim(an_axis_3, currentTimeDouble, array(30))
        AddPointWithTrim(an_module, currentTimeDouble, array(31) * 10)
        AddPointWithTrim(weight, currentTimeDouble, array(32))
        AddPointWithTrim(out_drier_heater_one, currentTimeDouble, array(33))
        AddPointWithTrim(out_drier_heater_two, currentTimeDouble, array(34))
        AddPointWithTrim(out_drier_heater_three, currentTimeDouble, array(35))

        blinkCounter += 1
        If blinkCounter >= 2 Then
            blinkCounter = 0
            If blink Then
                blink = False
                Label6.ForeColor = Color.Red
            Else
                blink = True
                Label6.ForeColor = Color.Black
            End If
        End If

        currentProgramName = Form1.programName

        If Not String.IsNullOrWhiteSpace(currentProgramName) AndAlso currentProgramName <> previousProgramName Then
            programStartTime = currentTime
            plotModel.Subtitle = currentProgramName
            plotModel.SubtitleFontWeight = FontWeights.Bold
            plotModel.SubtitleColor = OxyColors.Black
            previousProgramName = currentProgramName
        End If

        Dim currentModuleValue = array(31)
        plotModel.Subtitle = Form1.MachineName & "  " & currentProgramName & " current mode: " & GetModuleName(currentModuleValue)

        If previousModule <> currentModuleValue Then
            If previousModule <> 0 Then
                Dim rect As New RectangleAnnotation() With {
                    .MinimumX = DateTimeAxis.ToDouble(moduleStartTime),
                    .MaximumX = currentTimeDouble,
                    .MinimumY = 0,
                    .MaximumY = Double.PositiveInfinity,
                    .Fill = moduleBackgroundColor,
                    .Layer = AnnotationLayer.BelowSeries
                }

                plotModel.Annotations.Add(rect)

                Dim midTime As DateTime = moduleStartTime + TimeSpan.FromTicks((currentTime - moduleStartTime).Ticks \ 2)
                Dim textAnn As New TextAnnotation() With {
                    .Text = GetModuleName(previousModule),
                    .TextPosition = New DataPoint(DateTimeAxis.ToDouble(midTime), yAxis.ActualMaximum),
                    .Stroke = OxyColors.Transparent,
                    .TextColor = OxyColors.Black,
                    .FontWeight = FontWeights.Bold,
                    .TextVerticalAlignment = VerticalAlignment.Top,
                    .Layer = AnnotationLayer.BelowSeries
                }

                plotModel.Annotations.Add(textAnn)
                TrimAnnotations()
            End If

            moduleStartTime = currentTime
            moduleBackgroundColor = GetModuleColor(currentModuleValue)
            previousModule = currentModuleValue
        End If
    End Sub

    Private Sub UpdateLiveReadouts(array() As Double)
        WATER_TEMP.Text = array(14).ToString("#0.0")
        WATER_LEVEL.Text = array(16).ToString("#0.0")
        SET_TEMP.Text = array(15).ToString("#0.0")
        SET_SPEED.Text = array(19).ToString("#0.0")
        DRUM_SPEED.Text = array(18).ToString("#0.0")
    End Sub

    Private Sub AppendHistorySample(timestamp As DateTime, values As Double())
        SyncLock sessionHistoryLock
            sessionHistory.Add(New GraphSample With {
                .Timestamp = timestamp,
                .Values = DirectCast(values.Clone(), Double())
            })
        End SyncLock
    End Sub

    Private Sub AddPointWithTrim(series As Object, x As Double, y As Double)
        If TypeOf series Is LineSeries Then
            Dim lineSeries = DirectCast(series, LineSeries)
            lineSeries.Points.Add(New DataPoint(x, y))
            TrimDataPointCollection(lineSeries.Points)
        ElseIf TypeOf series Is AreaSeries Then
            Dim areaSeries = DirectCast(series, AreaSeries)
            areaSeries.Points.Add(New DataPoint(x, y))
            TrimDataPointCollection(areaSeries.Points)
        End If
    End Sub

    Private Sub TrimDataPointCollection(points As IList(Of DataPoint))
        If points Is Nothing Then Return

        Dim overflow As Integer = points.Count - MaxPointsPerSeries
        If overflow <= 0 Then Return

        For i As Integer = 1 To overflow
            points.RemoveAt(0)
        Next
    End Sub

    Private Sub TrimAnnotations()
        While plotModel.Annotations.Count > MaxAnnotations
            plotModel.Annotations.RemoveAt(0)
        End While
    End Sub


    Private Sub numericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles numericUpDown2.ValueChanged
        If Not (yAxis Is Nothing) Then
            yAxis.Minimum = numericUpDown2.Value

            'Repaint the graph
            plotModel.InvalidatePlot(True)

        End If
    End Sub

    Private Sub numericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles numericUpDown3.ValueChanged
        If Not (yAxis Is Nothing) Then
            yAxis.Maximum = numericUpDown3.Value

            'Ridisegna il grafico
            plotModel.InvalidatePlot(True)

        End If
    End Sub

    Private Sub numericUpDown4_ValueChanged(sender As Object, e As EventArgs) Handles numericUpDown4.ValueChanged

        If Not (yAxis Is Nothing) Then
            offset = numericUpDown4.Value
            xAxis.Minimum = DateTimeAxis.ToDouble(datetimeOrigin.AddMinutes(offset))
            xAxis.Maximum = DateTimeAxis.ToDouble(datetimeOrigin.AddMinutes((offset + numericUpDown1.Value)))

            'Ridisegna il grafico
            plotModel.InvalidatePlot(True)

        End If

    End Sub

    Private Sub numericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles numericUpDown1.ValueChanged
        Dim currentTime As DateTime = DateTime.Now

        If Not (yAxis Is Nothing) Then
            'Riposiziona l'asse delle X per visualizzare l'intervallo di tempo desiderato
            xAxis.Minimum = DateTimeAxis.ToDouble(startTime) + DateTimeAxis.ToDouble(datetimeOrigin.AddMinutes(offset))
            xAxis.Maximum = DateTimeAxis.ToDouble(startTime.AddMinutes(numericUpDown1.Value))

            'Inizializza l'ultima marca temporale dei dati
            lastDataPointTime = DateTime.Now

            offset = numericUpDown4.Value
            xAxis.Minimum = DateTimeAxis.ToDouble(datetimeOrigin.AddMinutes(offset))
            xAxis.Maximum = DateTimeAxis.ToDouble(datetimeOrigin.AddMinutes((offset + numericUpDown1.Value)))

            'Ridisegna il grafico
            plotModel.InvalidatePlot(True)

        End If


    End Sub


    Public Sub ClearGraph()

        'Clear all line series points
        For Each s As Series In plotModel.Series
            If TypeOf s Is LineSeries Then
                DirectCast(s, LineSeries).Points.Clear()
            ElseIf TypeOf s Is AreaSeries Then
                DirectCast(s, AreaSeries).Points.Clear()
            End If
        Next

        'Remove module rectangles and labels
        plotModel.Annotations.Clear()

        'Clear queued incoming data
        Dim discarded As Double() = Nothing
        While queue.TryDequeue(discarded)
        End While

        SyncLock sessionHistoryLock
            sessionHistory.Clear()
        End SyncLock

        'Reset internal state
        startTimeAquired = False
        previousModule = 0
        previousProgramName = ""
        currentProgramName = ""
        lastPlotRefreshUtc = DateTime.MinValue
        lastUiRefreshUtc = DateTime.MinValue

        'Redraw
        plotModel.InvalidatePlot(True)

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim snapshot As List(Of GraphSample)

        SyncLock sessionHistoryLock
            snapshot = New List(Of GraphSample)(sessionHistory)
        End SyncLock

        If snapshot.Count = 0 Then
            MessageBox.Show("No graph data available to export yet.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim headers As String() = {
            "Cold water", "Hot water", "Drain", "Recirculation", "Heater",
            "Cold to Wash", "Hot to Wash", "Cold to Prewash", "Hot to Prewash",
            "Cold to Softener", "Hot to Softener", "Cold to Bleach", "Hot to Bleach",
            "Door lock signal", "Water temperature", "Water temperature setpoint",
            "Water level", "Water level setpoint", "Drum speed", "Drum speed setpoint",
            "Pump 1", "Pump 2", "Pump 3", "Pump 4", "Pump 5", "Pump 6", "Pump 7",
            "Flush valve", "Axis XY", "Axis Z", "Axis 3", "Module Index", "Weight hg",
            "Dryer Heater 1", "Dryer Heater 2", "RMC"
        }

        Dim csvBuilder As New StringBuilder()
        csvBuilder.Append("Time")
        For Each header In headers
            csvBuilder.Append(";"c).Append(header)
        Next
        csvBuilder.AppendLine()

        For Each item In snapshot
            csvBuilder.Append(item.Timestamp.ToString("HH:mm:ss.fff"))
            For Each value In item.Values
                csvBuilder.Append(";"c).Append(value.ToString(Globalization.CultureInfo.InvariantCulture))
            Next
            csvBuilder.AppendLine()
        Next

        Dim takenDir As String = Form1.machineFolder
        If String.IsNullOrEmpty(Form1.DirectoryPerWashProgram) Then
            takenDir = Form1.machineFolder & "\\IDLE_Mode"
            currentProgramName = "Home_Screen"
            Directory.CreateDirectory(takenDir)
        Else
            takenDir = Form1.machineFolder & "\\" & currentProgramName
            Directory.CreateDirectory(takenDir)
        End If

        Dim filename As String = takenDir & "\\" & Form1.MachineName & "_" & currentProgramName & "_" & Form1.combinedVersion & "-" & DateTime.Now.ToString("yyyy-MM-dd_HH-mm") & ".csv"

        File.WriteAllText(filename, csvBuilder.ToString())
        MessageBox.Show("Data exported to " & filename, "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub PlotView1_DoubleClick(sender As Object, e As EventArgs) Handles PlotView1.DoubleClick
        ' Resetta gli assi X e Y
        Dim xAxis = TryCast(plotModel.Axes(0), LinearAxis)
        Dim yAxis = TryCast(plotModel.Axes(1), LinearAxis)

        xAxis.Reset()
        yAxis.Reset()

        ' Aggiorna il grafico
        ' Aggiorna il modello del grafico
        plotModel.InvalidatePlot(True)

        ' Aggiorna la visualizzazione del grafico
        PlotView1.Refresh()

    End Sub

    Private Sub PlotView1_Click(sender As Object, e As EventArgs) Handles PlotView1.Click

    End Sub
    Public Sub SyncStartStopButton(isRunning As Boolean)
        Button8.Text = If(isRunning, "STOP", "START")
    End Sub




    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        If Not String.IsNullOrEmpty(Form1.DirectoryPerWashProgram) Then

            imageName = Form1.DirectoryPerWashProgram.ToString & "\" & "FULLSCALE_" & Form1.ProgramIndexValue & "_" & Form1.combinedVersion & "-" & DateTime.Now.ToString("yyyy-MM-dd_HH-mm") & ".png"

            Dim exporter As New PngExporter With {
        .Width = 4000,   ' any size you want
        .Height = 2000
        }

            Using stream = File.Create(imageName)
                exporter.Export(PlotView1.Model, stream)
            End Using
        End If

        Form1.ToggleCommunication()
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim takenDir = Form1.DirectoryPerWashProgram
        If String.IsNullOrEmpty(takenDir) Then
            takenDir = Form1.machineFolder + "\" + "IDLE_Mode"
            currentProgramName = "Home_Screen"

        End If

        Dim safeProgramName As String = String.Join("_", currentProgramName.Split(IO.Path.GetInvalidFileNameChars()))
        Dim safeVersion As String = String.Join("_", Form1.combinedVersion.Split(IO.Path.GetInvalidFileNameChars()))

        imageName = IO.Path.Combine(takenDir, $"{Form1.MachineName}_{safeProgramName}_{safeVersion}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png")

        ' Ensure the folder exists
        If Not IO.Directory.Exists(takenDir) Then IO.Directory.CreateDirectory(takenDir)



        Dim bmp As New Bitmap(PlotView1.Width, PlotView1.Height)
        PlotView1.DrawToBitmap(bmp, New Rectangle(0, 0, bmp.Width, bmp.Height))

        bmp.Save(imageName, Imaging.ImageFormat.Png)
    End Sub


    Public Sub Label15_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub timeStart_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub timeEnd_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub WATER_LEVEL_Click(sender As Object, e As EventArgs) Handles WATER_LEVEL.Click

    End Sub

    Private Sub Label15_Click_1(sender As Object, e As EventArgs)

    End Sub

    Public Sub TempPerMin_Click(sender As Object, e As EventArgs) Handles TempPerMin.Click

    End Sub

    Private Sub WATER_TEMP_Click(sender As Object, e As EventArgs) Handles WATER_TEMP.Click

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SpeedInfo_Click(sender As Object, e As EventArgs) Handles SpeedInfo.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub
End Class