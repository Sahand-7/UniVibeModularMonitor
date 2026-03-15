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

    Private queue As New Queue(Of Double())()
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
    Private programStartTime As DateTime
    Dim startTimeAquired As Boolean = False
    Dim startTime As DateTime

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        InitializePlotModel()
        InitializeSeries()
        ConfigurePlotAxesAndLegend()

        'Associa il modello del grafico al PlotView
        PlotView1.Model = plotModel
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SubscribeToBufferAddedEvent(AddressOf AddBufferToQueue)
        SubscribeToMainFormClosedEvent(AddressOf TerminateAll)
        ' Creazione e avvio del thread per l'elaborazione dei dati
        dataProcessingThread = New Thread(AddressOf ProcessDataFromQueue)
        isProcessingData = True
        dataProcessingThread.Start()
        dataProcessingThread.Priority = ThreadPriority.Normal
        If Form1.isCommunicating Then
            Button8.Text = "STOP"
        Else
            Button8.Text = "START"
        End If

    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True     ' prevent disposal
        Me.Hide()           ' keep running in background
    End Sub

    Private Sub numericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles numericUpDown2.ValueChanged
        If Not (yAxis Is Nothing) Then
            yAxis.Minimum = numericUpDown2.Value
            plotModel.InvalidatePlot(True)
        End If
    End Sub

    Private Sub numericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles numericUpDown3.ValueChanged
        If Not (yAxis Is Nothing) Then
            yAxis.Maximum = numericUpDown3.Value
            plotModel.InvalidatePlot(True)
        End If
    End Sub

    Private Sub numericUpDown4_ValueChanged(sender As Object, e As EventArgs) Handles numericUpDown4.ValueChanged
        If Not (yAxis Is Nothing) Then
            offset = numericUpDown4.Value
            xAxis.Minimum = DateTimeAxis.ToDouble(datetimeOrigin.AddMinutes(offset))
            xAxis.Maximum = DateTimeAxis.ToDouble(datetimeOrigin.AddMinutes((offset + numericUpDown1.Value)))
            plotModel.InvalidatePlot(True)
        End If
    End Sub

    Private Sub numericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles numericUpDown1.ValueChanged
        If Not (yAxis Is Nothing) Then
            xAxis.Minimum = DateTimeAxis.ToDouble(startTime) + DateTimeAxis.ToDouble(datetimeOrigin.AddMinutes(offset))
            xAxis.Maximum = DateTimeAxis.ToDouble(startTime.AddMinutes(numericUpDown1.Value))

            lastDataPointTime = DateTime.Now

            offset = numericUpDown4.Value
            xAxis.Minimum = DateTimeAxis.ToDouble(datetimeOrigin.AddMinutes(offset))
            xAxis.Maximum = DateTimeAxis.ToDouble(datetimeOrigin.AddMinutes((offset + numericUpDown1.Value)))
            plotModel.InvalidatePlot(True)
        End If
    End Sub

    Public Sub ClearGraph()

        For Each s As Series In plotModel.Series
            If TypeOf s Is LineSeries Then
                DirectCast(s, LineSeries).Points.Clear()
            End If
        Next

        plotModel.Annotations.Clear()
        queue.Clear()
        startTimeAquired = False
        previousModule = 0
        previousProgramName = ""
        currentProgramName = ""
        plotModel.InvalidatePlot(True)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub PlotView1_DoubleClick(sender As Object, e As EventArgs) Handles PlotView1.DoubleClick
        Dim xAxis = TryCast(plotModel.Axes(0), LinearAxis)
        Dim yAxis = TryCast(plotModel.Axes(1), LinearAxis)

        xAxis.Reset()
        yAxis.Reset()

        plotModel.InvalidatePlot(True)
        PlotView1.Refresh()
    End Sub

    Private Sub PlotView1_Click(sender As Object, e As EventArgs) Handles PlotView1.Click
    End Sub

    Public Sub SyncStartStopButton(isRunning As Boolean)
        Button8.Text = If(isRunning, "STOP", "START")
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
