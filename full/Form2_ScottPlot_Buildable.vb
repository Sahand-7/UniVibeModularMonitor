Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports ScottPlot
Imports ScottPlot.Plottables
Imports ScottPlot.WinForms

Public Class Form2

    Private ReadOnly queue As New Queue(Of Double())()
    Public imageName As String

    Private lastDataPointTime As DateTime
    Private blink As Boolean = False
    Private blinkCounter As Integer = 0

    Private dataProcessingThread As Thread
    Private isProcessingData As Boolean = False
    Private offset As Integer
    Private previousModule As Integer = 0
    Private previousProgramName As String = ""
    Public Shared currentProgramName As String = ""
    Private startTimeAquired As Boolean = False
    Private startTime As DateTime
    Private datetimeOrigin As DateTime

    Private ReadOnly channels As New List(Of ChannelLogger)

    Private out_cold_water As ChannelLogger
    Private out_hot_water As ChannelLogger
    Private out_hard_water As ChannelLogger
    Private out_drain As ChannelLogger
    Private out_rec As ChannelLogger
    Private out_heater As ChannelLogger
    Private out_hot_wash As ChannelLogger
    Private out_cold_wash As ChannelLogger
    Private out_hot_prewash As ChannelLogger
    Private out_cold_prewash As ChannelLogger
    Private out_hot_softener As ChannelLogger
    Private out_cold_softener As ChannelLogger
    Private out_hot_bleach As ChannelLogger
    Private out_cold_bleach As ChannelLogger
    Private out_liquid_pump_1 As ChannelLogger
    Private out_liquid_pump_2 As ChannelLogger
    Private out_liquid_pump_3 As ChannelLogger
    Private out_liquid_pump_4 As ChannelLogger
    Private out_liquid_pump_5 As ChannelLogger
    Private out_liquid_pump_6 As ChannelLogger
    Private out_liquid_pump_7 As ChannelLogger
    Private out_flush_valve As ChannelLogger
    Private an_water_temp As ChannelLogger
    Private an_water_tempSetpoint As ChannelLogger
    Private an_water_level As ChannelLogger
    Private an_water_levelSetpoint As ChannelLogger
    Private an_drum_speed As ChannelLogger
    Private an_drum_speed_setpoint As ChannelLogger
    Private an_axis_xy As ChannelLogger
    Private an_axis_z As ChannelLogger
    Private an_axis_3 As ChannelLogger
    Private an_module As ChannelLogger
    Private weight As ChannelLogger
    Private out_drier_heater_one As ChannelLogger
    Private out_drier_heater_two As ChannelLogger
    Private out_drier_heater_three As ChannelLogger

    Private Const MAX_POINTS_PER_SERIES As Integer = 10000

    Private Class ChannelLogger
        Public Property Title As String
        Public Property Logger As DataLogger

        Public Sub New(title As String, logger As DataLogger)
            Me.Title = title
            Me.Logger = logger
        End Sub

        Public Sub AddPoint(x As Double, y As Double)
            Logger.Add(x, y)
            Dim extra As Integer = Logger.Data.Coordinates.Count - Form2.MAX_POINTS_PER_SERIES
            If extra > 0 Then
                Logger.Data.Coordinates.RemoveRange(0, extra)
            End If
        End Sub

        Public ReadOnly Property Coordinates As IReadOnlyList(Of Coordinates)
            Get
                Return Logger.Data.Coordinates
            End Get
        End Property

        Public Sub Clear()
            Logger.Data.Coordinates.Clear()
        End Sub
    End Class

    Public Sub New()
        InitializeComponent()
        InitializePlot()
    End Sub

    Private Sub InitializePlot()
        Dim plt = FormsPlot1.Plot
        plt.Clear()
        plt.Axes.DateTimeTicksBottom()
        plt.Axes.SetLimitsY(CDbl(numericUpDown2.Value), CDbl(numericUpDown3.Value))
        plt.XLabel("Time")
        plt.YLabel("Value")
        plt.Title("Graph")
        plt.ShowLegend(Edge.Right)

        datetimeOrigin = DateTime.Now
        lastDataPointTime = DateTime.Now

        out_cold_water = CreateChannel("Cold water", True)
        out_hot_water = CreateChannel("Hot water", True)
        out_hard_water = CreateChannel("Hard water", False)
        out_drain = CreateChannel("Drain", False)
        out_rec = CreateChannel("Rec.Pump", True)
        out_heater = CreateChannel("Heater", True)

        an_water_temp = CreateChannel("Temperature", True)
        an_water_tempSetpoint = CreateChannel("Temp. Setpoint", True)
        an_water_level = CreateChannel("Water Level", True)
        an_water_levelSetpoint = CreateChannel("Level Setpoint", True)
        an_drum_speed = CreateChannel("Drum Speed", True)
        an_drum_speed_setpoint = CreateChannel("Speed Setpoint", True)

        out_hot_wash = CreateChannel("Hot to Wash", True)
        out_cold_wash = CreateChannel("Cold to Wash", True)
        out_hot_prewash = CreateChannel("Hot to Prewash", True)
        out_cold_prewash = CreateChannel("Cold to Prewash", True)
        out_hot_softener = CreateChannel("Hot to Softener", True)
        out_cold_softener = CreateChannel("Cold to Softener", True)
        out_hot_bleach = CreateChannel("Hot to Bleach", True)
        out_cold_bleach = CreateChannel("Cold to Bleach", False)

        out_liquid_pump_1 = CreateChannel("Pump 1", False)
        out_liquid_pump_2 = CreateChannel("Pump 2", False)
        out_liquid_pump_3 = CreateChannel("Pump 3", False)
        out_liquid_pump_4 = CreateChannel("Pump 4", False)
        out_liquid_pump_5 = CreateChannel("Pump 5", False)
        out_liquid_pump_6 = CreateChannel("Pump 6", False)
        out_liquid_pump_7 = CreateChannel("Pump 7", False)
        out_flush_valve = CreateChannel("Flush Valve", True)

        an_axis_xy = CreateChannel("Axis XY", True)
        an_axis_z = CreateChannel("Axis Z", True)
        an_axis_3 = CreateChannel("Axis 3", True)

        an_module = CreateChannel("Module", False)
        weight = CreateChannel("Weight hg", False)
        out_drier_heater_one = CreateChannel("HeaterOne", True)
        out_drier_heater_two = CreateChannel("HeaterTwo", True)
        out_drier_heater_three = CreateChannel("RMC", True)

        UpdateAxisLimits()
        FormsPlot1.Refresh()
    End Sub

    Private Function CreateChannel(title As String, isVisible As Boolean) As ChannelLogger
        Dim logger = FormsPlot1.Plot.Add.DataLogger()
        logger.LegendText = title
        logger.IsVisible = isVisible
        logger.LineWidth = 1
        Dim channel = New ChannelLogger(title, logger)
        channels.Add(channel)
        Return channel
    End Function

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SubscribeToBufferAddedEvent(AddressOf AddBufferToQueue)
        SubscribeToMainFormClosedEvent(AddressOf TerminateAll)

        dataProcessingThread = New Thread(AddressOf ProcessDataFromQueue)
        isProcessingData = True
        dataProcessingThread.IsBackground = True
        dataProcessingThread.Start()
        dataProcessingThread.Priority = ThreadPriority.Normal

        Button8.Text = If(Form1.isCommunicating, "STOP", "START")
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

    Private Sub TerminateAll(obj As Short)
        StopProcessing()
    End Sub

    Private Sub AddBufferToQueue(obj() As Double)
        SyncLock queue
            queue.Enqueue(DirectCast(obj.Clone(), Double()))
        End SyncLock
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Public Sub StopProcessing()
        isProcessingData = False

        If dataProcessingThread IsNot Nothing AndAlso dataProcessingThread.IsAlive Then
            dataProcessingThread.Join(500)
        End If

        UnsubscribeToBufferAddedEvent(AddressOf AddBufferToQueue)
    End Sub

    Public Sub SubscribeToBufferAddedEvent(handler As Action(Of Double()))
        Dim form1 As Form1 = Application.OpenForms.OfType(Of Form1)().FirstOrDefault()
        If form1 IsNot Nothing Then AddHandler form1.BufferAdded, handler
    End Sub

    Public Sub SubscribeToMainFormClosedEvent(handler As Action(Of Int16))
        Dim form1 As Form1 = Application.OpenForms.OfType(Of Form1)().FirstOrDefault()
        If form1 IsNot Nothing Then AddHandler form1.MainFormClosed, handler
    End Sub

    Public Sub UnsubscribeToBufferAddedEvent(handler As Action(Of Double()))
        Dim form1 As Form1 = Application.OpenForms.OfType(Of Form1)().FirstOrDefault()
        If form1 IsNot Nothing Then RemoveHandler form1.BufferAdded, handler
    End Sub

    Private Sub ProcessDataFromQueue()
        While isProcessingData
            Try
                If IsHandleCreated Then
                    BeginInvoke(DirectCast(AddressOf UpdateQueueDisplay, Action))
                End If
            Catch
            End Try
            Thread.Sleep(20)
        End While
    End Sub

    Private Sub UpdateQueueDisplay()
        Dim array As Double() = Nothing

        SyncLock queue
            If queue.Count > 0 Then
                array = queue.Dequeue()
            End If
        End SyncLock

        If array IsNot Nothing Then
            GiveMeNewDataFromQueue(array)
        End If
    End Sub

    Private Sub GiveMeNewDataFromQueue(array() As Double)
        If FormsPlot1.InvokeRequired Then
            FormsPlot1.Invoke(New Action(Of Double())(AddressOf GiveMeNewDataFromQueue), array)
            Return
        End If

        Dim currentTime As DateTime = DateTime.Now

        If startTimeAquired = False Then
            startTime = currentTime
            datetimeOrigin = currentTime
            startTimeAquired = True
        End If

        If currentTime >= startTime.AddMinutes(CDbl(numericUpDown1.Value)) AndAlso _ck_autorange.Checked Then
            numericUpDown1.Value += 1D
        End If

        Dim x As Double = currentTime.ToOADate()

        out_cold_water.AddPoint(x, array(0))
        out_hot_water.AddPoint(x, array(1))
        out_drain.AddPoint(x, array(2))
        out_rec.AddPoint(x, array(3))
        out_heater.AddPoint(x, array(4))
        out_cold_wash.AddPoint(x, array(5))
        out_hot_wash.AddPoint(x, array(6))
        out_cold_prewash.AddPoint(x, array(7))
        out_hot_prewash.AddPoint(x, array(8))
        out_cold_softener.AddPoint(x, array(9))
        out_hot_softener.AddPoint(x, array(10))
        out_cold_bleach.AddPoint(x, array(11))
        out_hot_bleach.AddPoint(x, array(12))
        an_water_temp.AddPoint(x, array(14))
        an_water_tempSetpoint.AddPoint(x, array(15))
        an_water_level.AddPoint(x, array(16))
        an_water_levelSetpoint.AddPoint(x, array(17))
        an_drum_speed.AddPoint(x, array(18))
        an_drum_speed_setpoint.AddPoint(x, array(19))
        out_liquid_pump_1.AddPoint(x, array(20))
        out_liquid_pump_2.AddPoint(x, array(21))
        out_liquid_pump_3.AddPoint(x, array(22))
        out_liquid_pump_4.AddPoint(x, array(23))
        out_liquid_pump_5.AddPoint(x, array(24))
        out_liquid_pump_6.AddPoint(x, array(25))
        out_liquid_pump_7.AddPoint(x, array(26))
        out_flush_valve.AddPoint(x, array(27))
        an_axis_xy.AddPoint(x, array(28))
        an_axis_z.AddPoint(x, array(29))
        an_axis_3.AddPoint(x, array(30))
        an_module.AddPoint(x, array(31) * 10)
        weight.AddPoint(x, array(32))
        out_drier_heater_one.AddPoint(x, array(33))
        out_drier_heater_two.AddPoint(x, array(34))
        out_drier_heater_three.AddPoint(x, array(35))

        WATER_TEMP.Text = array(14).ToString("#0.0")
        WATER_LEVEL.Text = array(16).ToString("#0.0")
        SET_TEMP.Text = array(15).ToString("#0.0")
        SET_SPEED.Text = array(19).ToString("#0.0")
        DRUM_SPEED.Text = array(18).ToString("#0.0")
        SET_LEVEL.Text = array(17).ToString("#0.0")
        TempPerMin.Text = array(35).ToString("#0.0")
        SpeedInfo.Text = GetModuleName(CInt(array(31)))

        blinkCounter += 1
        If blinkCounter >= 2 Then
            blinkCounter = 0
            blink = Not blink
            Label6.ForeColor = If(blink, Color.Black, Color.Red)
        End If

        currentProgramName = Form1.programName
        Dim currentModuleValue As Integer = CInt(array(31))

        If Not String.IsNullOrWhiteSpace(currentProgramName) AndAlso currentProgramName <> previousProgramName Then
            previousProgramName = currentProgramName
        End If

        If previousModule <> currentModuleValue Then
            previousModule = currentModuleValue
        End If

        FormsPlot1.Plot.Title(Form1.MachineName & "  " & currentProgramName & " current mode: " & GetModuleName(currentModuleValue))
        UpdateAxisLimits()
        FormsPlot1.Refresh()
    End Sub

    Private Sub UpdateAxisLimits()
        Dim yMin As Double = CDbl(numericUpDown2.Value)
        Dim yMax As Double = CDbl(numericUpDown3.Value)
        FormsPlot1.Plot.Axes.SetLimitsY(yMin, yMax)

        If startTimeAquired Then
            offset = CInt(numericUpDown4.Value)
            Dim leftDt As DateTime = datetimeOrigin.AddMinutes(offset)
            Dim rightDt As DateTime = leftDt.AddMinutes(CDbl(numericUpDown1.Value))
            FormsPlot1.Plot.Axes.SetLimitsX(leftDt.ToOADate(), rightDt.ToOADate())
        End If
    End Sub

    Private Sub numericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles numericUpDown2.ValueChanged
        UpdateAxisLimits()
        FormsPlot1.Refresh()
    End Sub

    Private Sub numericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles numericUpDown3.ValueChanged
        UpdateAxisLimits()
        FormsPlot1.Refresh()
    End Sub

    Private Sub numericUpDown4_ValueChanged(sender As Object, e As EventArgs) Handles numericUpDown4.ValueChanged
        UpdateAxisLimits()
        FormsPlot1.Refresh()
    End Sub

    Private Sub numericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles numericUpDown1.ValueChanged
        lastDataPointTime = DateTime.Now
        UpdateAxisLimits()
        FormsPlot1.Refresh()
    End Sub

    Public Sub ClearGraph()
        For Each channel In channels
            channel.Clear()
        Next

        SyncLock queue
            queue.Clear()
        End SyncLock

        startTimeAquired = False
        previousModule = 0
        previousProgramName = ""
        currentProgramName = ""
        FormsPlot1.Plot.Title("Graph")
        FormsPlot1.Refresh()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim header As String = "Time"
        For Each channel In channels
            header &= ";" & channel.Title
        Next

        Dim maxPoints As Integer = channels.Select(Function(c) c.Coordinates.Count).DefaultIfEmpty(0).Max()
        Dim csvBuilder As New StringBuilder()
        csvBuilder.AppendLine(header)

        For i As Integer = 0 To maxPoints - 1
            Dim lineBuilder As New StringBuilder()
            If channels.Count > 0 AndAlso i < channels(0).Coordinates.Count Then
                lineBuilder.Append(DateTime.FromOADate(channels(0).Coordinates(i).X).ToString("HH:mm:ss.f"))
            End If

            For Each channel In channels
                If i < channel.Coordinates.Count Then
                    lineBuilder.Append($";{channel.Coordinates(i).Y}")
                Else
                    lineBuilder.Append(";")
                End If
            Next

            csvBuilder.AppendLine(lineBuilder.ToString())
        Next

        Dim takenDir As String = Form1.machineFolder
        If String.IsNullOrEmpty(Form1.DirectoryPerWashProgram) Then
            takenDir = Path.Combine(Form1.machineFolder, "IDLE_Mode")
            currentProgramName = "Home_Screen"
            Directory.CreateDirectory(takenDir)
        Else
            takenDir = Path.Combine(Form1.machineFolder, currentProgramName)
            Directory.CreateDirectory(takenDir)
        End If

        Dim filename As String = Path.Combine(takenDir, $"{Form1.MachineName}_{currentProgramName}_{Form1.combinedVersion}-{DateTime.Now:yyyy-MM-dd_HH-mm}.csv")
        File.WriteAllText(filename, csvBuilder.ToString())
        MessageBox.Show("Data exported to " & filename, "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub FormsPlot1_DoubleClick(sender As Object, e As EventArgs) Handles FormsPlot1.DoubleClick
        UpdateAxisLimits()
        FormsPlot1.Refresh()
    End Sub

    Private Sub FormsPlot1_Click(sender As Object, e As EventArgs) Handles FormsPlot1.Click
    End Sub

    Public Sub SyncStartStopButton(isRunning As Boolean)
        Button8.Text = If(isRunning, "STOP", "START")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If Not String.IsNullOrEmpty(Form1.DirectoryPerWashProgram) Then
            imageName = Path.Combine(Form1.DirectoryPerWashProgram, $"FULLSCALE_{Form1.ProgramIndexValue}_{Form1.combinedVersion}-{DateTime.Now:yyyy-MM-dd_HH-mm}.png")
            FormsPlot1.Plot.SavePng(imageName, 4000, 2000)
        End If
        Form1.ToggleCommunication()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim takenDir = Form1.DirectoryPerWashProgram
        If String.IsNullOrEmpty(takenDir) Then
            takenDir = Path.Combine(Form1.machineFolder, "IDLE_Mode")
            currentProgramName = "Home_Screen"
        End If

        Dim safeProgramName As String = String.Join("_", currentProgramName.Split(Path.GetInvalidFileNameChars()))
        Dim safeVersion As String = String.Join("_", Form1.combinedVersion.Split(Path.GetInvalidFileNameChars()))
        imageName = Path.Combine(takenDir, $"{Form1.MachineName}_{safeProgramName}_{safeVersion}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png")

        If Not Directory.Exists(takenDir) Then Directory.CreateDirectory(takenDir)
        FormsPlot1.Plot.SavePng(imageName, FormsPlot1.Width, FormsPlot1.Height)
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
