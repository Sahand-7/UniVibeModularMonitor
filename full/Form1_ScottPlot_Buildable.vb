Imports System.IO
Imports System.IO.Ports
Imports System.Management
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Timers
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Public Class Form1

    Dim debug_machine As Boolean = False
    Dim TX As Integer = 0
    Dim RX As Integer = 0
    Dim err As Integer = 0
    Dim miss As Integer = 0
    Dim rxtimer As Stopwatch
    Dim diag As Boolean = False
    Dim running As Boolean = False
    Dim chkErrors As Integer = 0
    Dim requestID As Integer = 0
    Dim FunctionType As Integer = 0
    Dim requestList As List(Of Integer)
    Dim machineAddress As Integer = 1
    Dim ProtocolIdentifier As String = "CMIS"
    Dim TrasmissionOnSerialPort As Boolean = True
    Dim TrasmissionOnEthernetPort As Boolean = False
    Dim StartButtonClicked As Boolean = False
    Dim connectionFound As Boolean = False

    Public moduleRemainingTimes As New List(Of Integer)
    Private remainingTimesLock As New Object
    Private _lastProgramIndex As Integer? = Nothing


    Dim offsetDigitalOutput As Integer = &H1000
    Dim offsetDigitalInput As Integer = &H2000
    Dim offsetAnalogInput As Integer = &H4000
    Dim offsetCMISProtocol As Integer = &H8000
    Dim offsetGeneralProtocol As Integer = &H10000
    Dim offsetDrierIO As Integer = &H20000

    Const maxspeed As Integer = 230400
    'Const maxspeed As Integer = 38400
    Const fortest As Boolean = False
    Dim remoteserviceRequest As Integer = 0
    Dim identificationRequest As Integer = 0
    Private WithEvents FtdiPort As New SerialPort()
    Private FirmwareVersionInitialized As Boolean = False
    Private versionStr As String = ""
    Private articleVersion As String = ""
    Private machineVersion As String = ""
    Private FtdiConnected As Boolean = False
    Private hasReadCommand01 As Boolean = True
    Public Shared ProgramIndexValue As String
    Private programNameCMISFound As Boolean = False
    Const mailmailaddress As String = "lorenzo.manera@electroluxprofessional.com"

    'Const maxspeed As Integer = 2400
    Public Shared ResultsFolderPath As String
    Public Shared programName As String
    Public Shared machineFolder As String
    Public Shared logFileName As String
    Public Shared combinedVersion As String
    ' At class level
    Public Shared DirectoryPerWashProgram As String
    Public Shared MachineName As String = "UNKNOWN"


    Public inTempC As Double = 0
    Public outTempC As Double = 0
    Public rmcValue As Long = 0



    Dim ProgramsTemperature As String = "Not Set"
    'Window load event
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ' your other UI setup code...
        cmb_serialPort.SelectedItem = My.Settings.sport
        cmb_speed.SelectedItem = My.Settings.rate
        Panel3.Location = Panel2.Location
        Panel3.Visible = False

        Dim wf = New waitingForm()
        wf.Show()
        UpdateAvailableSerialPorts()
        wf.Close()
    End Sub



#Region "Checksum calculation and verification"

    'Checksum calculation
    Private Function checksumCalulate(list1 As List(Of Byte)) As Integer
        Dim i As Integer
        Dim sum = 0
        If (list1.Count < 3) Then Return 0
        For i = 0 To list1.Count - 1
            sum = sum + list1(i)
        Next
        Dim num1 As Integer = sum << 1
        Dim num2 As Byte = ((num1 >> 8) Or &HC0) And &HFF
        Dim num3 As Byte = ((num1 >> 1) And &HFF) And &H7F
        Dim result As Integer = Int(num3)
        result = (result << 8) + Int(num2)

        Return result
    End Function

    'Checksum verification
    Private Function checksumVerification(list1 As List(Of Byte)) As Boolean
        Dim i As Integer
        Dim sum = 0
        If (list1.Count < 3) Then Return False
        For i = 0 To list1.Count - 3
            sum = sum + list1(i)
        Next

        Dim num1 As Integer = sum << 1
        Dim num2 As Byte = ((num1 >> 8) Or &HC0) And &HFF
        Dim num3 As Byte = ((num1 >> 1) And &HFF) And &H7F
        If (num3 = list1(list1.Count - 2)) And (num2 = list1(list1.Count - 1)) Then
            Return True
        End If
        Return False
    End Function

#End Region

#Region "Serial handling"

    Dim trasmissionBuffer() As Byte
    Dim TXBufferList As List(Of Byte)
    Dim RXBufferList As List(Of Byte)
    Dim RXBufferReceived As List(Of Byte)

    'Communication timeout control
    Dim timeout As Integer = 0
    Dim retry As Integer = 0
    Dim manualCommand As Boolean = False


    'Open serial port
    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    openSerialPort()
    'End Sub

    'Close serial port
    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '   closeSerialPort()
    'End Sub

    Private Sub openSerialPort()
        'Open the serial port
        If SerialPort1.IsOpen = False Then
            Try
                'Configure the serial port
                SerialPort1.PortName = cmb_serialPort.Text
                'SerialPort1.BaudRate = 2400

                If cmb_speed.SelectedItem = "2400" Then
                    SerialPort1.BaudRate = 2400
                ElseIf cmb_speed.SelectedItem = "9600" Then
                    SerialPort1.BaudRate = 9600
                ElseIf cmb_speed.SelectedItem = "19200" Then
                    SerialPort1.BaudRate = 19200
                ElseIf cmb_speed.SelectedItem = "38400" Then
                    SerialPort1.BaudRate = 38400
                ElseIf cmb_speed.SelectedItem = "115200" Then
                    SerialPort1.BaudRate = 115200
                ElseIf cmb_speed.SelectedItem = "230400" Then
                    SerialPort1.BaudRate = maxspeed
                Else SerialPort1.BaudRate = 2400
                End If

                SerialPort1.ReceivedBytesThreshold = 1
                SerialPort1.DataBits = 8
                SerialPort1.StopBits = 1
                SerialPort1.Handshake = IO.Ports.Handshake.None

                SerialPort1.Open()
                Debug.WriteLine("Serial port open")
                ser1.Image = My.Resources.Green_tick

                'Enable close port button and disable open port button
                'Button1.Enabled = False
                'Button2.Enabled = True
                Button8.Enabled = True
                'Save the serial port
                My.Settings.sport = SerialPort1.PortName
                My.Settings.rate = cmb_speed.SelectedItem
                cmb_serialPort.Enabled = False
                cmb_speed.Enabled = False

                RadioButton10.Enabled = False
                RadioButton11.Enabled = False

                TrasmissionOnEthernetPort = False
                TrasmissionOnSerialPort = True


            Catch ex As Exception
                Debug.WriteLine("Error to open serial port")
                MsgBox("Error to open the serial port", MsgBoxStyle.Critical, "Error")

                RadioButton10.Enabled = True
                RadioButton11.Enabled = True
            End Try
        Else
            Debug.WriteLine("Serial port is already open")
        End If
    End Sub

    Private Sub closeSerialPort()
        If SerialPort1.IsOpen() Then

            SerialPort1.ReadExisting()
            SerialPort1.Close()
            TX = 0
            TXCounter.Text = TX
            RX = 0
            RXCounter.Text = RX
            ser1.Image = My.Resources.RedCross
            cmb_serialPort.Enabled = True
            Debug.WriteLine("Serial port closed")

            'Enable open port button and disable close port button
            'Button1.Enabled = True
            'Button2.Enabled = False
            TimeoutTimer.Enabled = False
            timeout = 0
            running = False
            ''Button8.Text = "START"
            ''Button8.Enabled = False
            cmb_serialPort.Enabled = True
            cmb_speed.Enabled = True

            RadioButton10.Enabled = True
            RadioButton11.Enabled = True

            TrasmissionOnEthernetPort = False
            TrasmissionOnSerialPort = False
        Else
            Debug.WriteLine("Serial port is already closed")
        End If
    End Sub
    Private Function selectPort() As String
        Dim targetPort As String = Nothing

        targetPort = FindComByVidPid("1FC9", "0094")
        If targetPort Is Nothing Then targetPort = FindComByVidPid("067B", "2303")
        If targetPort Is Nothing Then targetPort = FindComByVidPid("0403", "6001")
        If targetPort Is Nothing Then targetPort = FindComByVidPid("0403", "6015")
        If targetPort Is Nothing Then targetPort = FindComByVidPid("0557", "2008")
        Return targetPort
    End Function

    Private Sub AppendLog(text As String)

        ' Detect if user is selecting text
        Dim userSelecting As Boolean = rtbFtdiLog.SelectionLength > 0

        ' Detect if user is at bottom
        Dim isAtBottom As Boolean = rtbFtdiLog.SelectionStart = rtbFtdiLog.TextLength

        ' Save current selection position
        Dim selStart As Integer = rtbFtdiLog.SelectionStart
        Dim selLength As Integer = rtbFtdiLog.SelectionLength

        ' Remove any existing CR or LF from the text
        text = text.TrimEnd(vbCr, vbLf)

        ' Append new text with a single line feed
        rtbFtdiLog.AppendColoredText(text & vbLf, Color.Blue)  ' vbLf is enough for RichTextBox

        ' Only autoscroll if user was already at bottom AND not selecting
        If isAtBottom AndAlso Not userSelecting Then
            rtbFtdiLog.SelectionStart = rtbFtdiLog.TextLength
            rtbFtdiLog.ScrollToCaret()
        Else
            ' Restore user selection
            rtbFtdiLog.SelectionStart = selStart
            rtbFtdiLog.SelectionLength = selLength
        End If

    End Sub


    'Update serial port list
    Private Sub UpdateAvailableSerialPorts()
        Dim ports() As String = System.IO.Ports.SerialPort.GetPortNames()
        Dim targetPort As String = Nothing


        Dim ftdiCom As String = FindComforFtdiPodowa()
        If ftdiCom IsNot Nothing Then
            rtbFtdiLog.AppendText("FTDI detected on " & ftdiCom & Environment.NewLine)

            Try
                FtdiPort.PortName = ftdiCom
                FtdiPort.BaudRate = 480200

                Thread.Sleep(1000)
                FtdiConnected = True
                rtbFtdiLog.AppendText("FTDI port opened." & Environment.NewLine)

            Catch ex As Exception
                rtbFtdiLog.AppendText("Failed to open FTDI port: " & ex.Message & Environment.NewLine)
                FtdiConnected = False
            End Try
        End If

        targetPort = selectPort()

        Do While String.IsNullOrEmpty(targetPort)

            Dim result As DialogResult = MessageBox.Show(
        "No connection to Machine found! Check the connection and Retry?" & vbCrLf &
        "Possible reasons:" & vbCrLf &
        "- Drivers of the port are not installed" & vbCrLf &
        "- Connection is not stable",
        "Connection Error",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                targetPort = selectPort()
            Else
                Exit Do
            End If

        Loop

        cmb_serialPort.Items.Clear()
        For Each p In ports
            cmb_serialPort.Items.Add(p)
        Next

        If targetPort IsNot Nothing AndAlso cmb_serialPort.Items.Contains(targetPort) Then
            cmb_serialPort.SelectedItem = targetPort
        ElseIf cmb_serialPort.Items.Count > 0 Then
            cmb_serialPort.SelectedIndex = 0
        End If
    End Sub



    Public Function FindComforFtdiPodowa() As String
        Dim query As String = "SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%(COM%'"
        Dim searcher As New ManagementObjectSearcher(query)

        For Each obj As ManagementObject In searcher.Get()
            Dim deviceId As String = CStr(obj("PNPDeviceID"))

            If (deviceId IsNot Nothing AndAlso deviceId.Contains("FTDPODOWA")) OrElse deviceId.Contains("FTDPN329A") Then

                ' Extract COM number from the Name property
                Dim name As String = CStr(obj("Name"))
                Dim m = Regex.Match(name, "COM(\d+)")
                If m.Success Then
                    Return "COM" & m.Groups(1).Value
                End If

            End If
        Next

        Return Nothing
    End Function



    Public Function FindComByVidPid(vid As String, pid As String) As String
        Dim query As String = "SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%(COM%'"
        Dim searcher As New ManagementObjectSearcher(query)

        For Each obj As ManagementObject In searcher.Get()
            Dim deviceId As String = CStr(obj("PNPDeviceID"))

            If deviceId IsNot Nothing Then
                If deviceId.Contains("VID_" & vid) AndAlso deviceId.Contains("PID_" & pid) AndAlso Not deviceId.Contains("FTDPODOWA") AndAlso Not deviceId.Contains("FTDPN329A") Then

                    Dim name As String = CStr(obj("Name"))
                    Dim m = Regex.Match(name, "COM(\d+)")
                    If m.Success Then
                        connectionFound = True
                        Return "COM" & m.Groups(1).Value

                    End If
                Else
                    ''MessageBox.Show("No connection found!")
                End If

            End If

        Next

        Return Nothing

    End Function


    Public Function FindComByVidPidTEMP(vid As String, pid As String) As String

        Dim query As String = "SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%(COM%'"
        Dim searcher As New ManagementObjectSearcher(query)

        For Each obj As ManagementObject In searcher.Get()

            Dim deviceId As String = TryCast(obj("PNPDeviceID"), String)
            If String.IsNullOrEmpty(deviceId) Then Continue For

            ' Check VID + PID
            If deviceId.Contains("VID_" & vid) AndAlso
           deviceId.Contains("PID_" & pid) Then

                ' Extract serial number (last part after last \)
                Dim parts() As String = deviceId.Split("\"c)
                Dim serialNumber As String = parts(parts.Length - 1)

                ' ====== FILTER HERE ======
                ' Example: ignore two known devices
                If serialNumber = "FTDPODOWA" OrElse
               serialNumber = "FTDPN329A" Then
                    Continue For
                End If
                ' ==========================

                ' Extract COM port
                Dim name As String = CStr(obj("Name"))
                Dim m = Regex.Match(name, "COM(\d+)")
                If m.Success Then
                    connectionFound = True
                    Return "COM" & m.Groups(1).Value
                End If

            End If

        Next

        Return Nothing

    End Function






    Private Delegate Sub DelegateReceiveData(data As Byte)
    Dim byteIndex As Integer = 0
    Dim rxBuffer(2000) As Byte
    Dim flagSTART, flagSTOP As Boolean
    Dim rxbytes As Integer

    'Ricezione dati dalla porta seriale
    Private Sub SerialPort1_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        If SerialPort1.IsOpen = False Then Exit Sub
        While SerialPort1.BytesToRead > 0
            Dim handler As New DelegateReceiveData(AddressOf MethodDelegateReceiveData)
            Dim val As Byte = SerialPort1.ReadByte()
            Try
                Me.BeginInvoke(handler, val)
            Catch ex As Exception

            End Try
        End While
    End Sub


    Public Const CPRO = &HAE
    Public Const CVIBE = &HB1
    Public Const MACHINE_TYPE_CPRO = &HAE
    Public Const MACHINE_TYPE_CVIBE = &HB1
    Public Const MACHINE_TYPE_UNIVIBE = &HB3

    Private Sub MethodDelegateReceiveData(data As Byte)

        If (data = MACHINE_TYPE_CPRO) Or (data = MACHINE_TYPE_CVIBE) Or (data = MACHINE_TYPE_UNIVIBE) Then

            'Wait to detect the START
            'If (data = &HAE) Then
            'Debug.WriteLine("Start detected")
            RXBufferReceived.Add(data)
            'Debug.Write(" " & Hex(data))
            flagSTART = True
            flagSTOP = False
            rxbytes = 0
            'Avoid request while we are receiving a new message
            RequestTimer.Stop()

            Return
        End If

        'Detect the STOP
        If flagSTART And ((data And &HC0) = &HC0) Then
            flagSTOP = True
            'Debug.WriteLine("Stop detected")
        End If

        'Read all byte in the message (STOP excluded)
        If flagSTART = True And flagSTOP = False Then
            RXBufferReceived.Add(data)
            'Debug.Write(" " & Hex(data))
        End If

        'Append the data in the buffer if the message is started
        If flagSTART = True And flagSTOP = True Then
            RXBufferReceived.Add(data)
            If checksumVerification(RXBufferReceived) Then

                'Start timeout control
                TimeoutTimer.Stop()

                RX += 1
                RXCounter.Text = RX
                parseIncomingMessage(RXBufferReceived)

                'Clear RXBuffer
                RXBufferReceived.Clear()

            Else

                chkErrors = chkErrors + 1
                Label3.Text = chkErrors
                Debug.Write("Checksum Error:")

                'Clear RXBuffer
                RXBufferReceived.Clear()
                RequestTimer.Interval = TXTime.Value

            End If

            If testSerialPort = False Then
                RequestTimer.Start()
            End If

            flagSTART = False
            flagSTOP = False
        End If
    End Sub


    Public Sub ToggleCommunication()
        Button8.PerformClick()
    End Sub

    Public Sub UpdateButtonText()
        Button8.Text = If(isCommunicating, "STOP", "START")
    End Sub
    Private Sub ShowGForm()

        ' Create form if needed
        If gform Is Nothing OrElse gform.IsDisposed Then
            gform = New Form2()
        End If

        If ActiveGraph.Checked Then

            ' Show form
            If Not gform.Visible Then
                gform.Show()
            End If

            gform.WindowState = FormWindowState.Normal

        Else

            ' Always clear graph when disabling
            gform.ClearGraph()

            If gform.Visible Then
                gform.Hide()
            End If

        End If

        ' Start timer
        Timer1.Enabled = True

    End Sub

    Dim gform As Form2
    'Start/Stop request from UI
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            If Not isCommunicating Then
                openSerialPort()
                If SerialPort.GetPortNames().Contains(FtdiPort.PortName) Then
                    FtdiPort.Open()
                Else
                    '' l.Show("FTDI device not connected!")
                End If
                requestList = New List(Of Integer)
                updateRequestList()
                StartStopCommand()

                Dim currentDir As New DirectoryInfo(Directory.GetCurrentDirectory())
                ResultsFolderPath = Path.Combine(currentDir.FullName, "Results")
                Directory.CreateDirectory(ResultsFolderPath)
                Dim timestampFolder As String = Now.ToString("yyyy_MM_dd")

                isCommunicating = True
                Button8.Text = "STOP"
                Button8.Enabled = True

                If gform IsNot Nothing AndAlso Not gform.IsDisposed Then
                    gform.SyncStartStopButton(isCommunicating)
                End If
                ShowGForm()
                ActiveGraph.Enabled = False

            Else
                StartStopCommand()
                closeSerialPort()

                If FtdiPort IsNot Nothing AndAlso FtdiPort.IsOpen Then
                    FtdiPort.Close()
                End If

                isCommunicating = False
                Button8.Text = "START"
                Button8.Enabled = True

                Timer1.Enabled = False
                ActiveGraph.Enabled = True
                ' Deactivate & hide gform when stopping
                If gform IsNot Nothing AndAlso Not gform.IsDisposed Then

                    If ActiveGraph.Checked Then
                        gform.Show()
                        gform.Hide()
                    Else
                        gform.Dispose()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Button8.Enabled = True
        End Try
    End Sub




    Private Sub CheckSerialPortSpeed()

    End Sub

    'Start/Stop execution
    Private Sub StartStopCommand()

        'Update machine address
        machineAddress = NumericUpDown2.Value

        If running Then
            Button8.Text = "START"
            running = False
            trasmissionBuffer = Nothing
            msgsec.Enabled = False
            requestID = 0
            serialportTested = False
            enable_disable_Allcheckbox(True)
        Else

            'serialportTested = True

            If (serialportTested = False) Then
                testSerialPort = True
                messageReceived = False
                TimerTestSerialPort.Interval = 1000
                TimerTestSerialPort.Enabled = True
                Button8.Text = "CHECK SPEED..."
                enable_disable_Allcheckbox(False)
                Return
            End If

            'Start the requests
            RequestTimer.Enabled = True
            RequestTimer.Start()
            RequestTimer.Interval = TXTime.Value

            msgsec.Enabled = True
            TimeoutTimer.Enabled = True
            TimeoutTimer.Stop()
            running = True
            requestID = 0
            Button8.Text = "STOP"

            RadioButton10.Enabled = False
            RadioButton11.Enabled = False

        End If
    End Sub

    Private Sub enable_disable_Allcheckbox(value As Boolean)
        F0.Enabled = value
        F1.Enabled = value
        F3.Enabled = value
        F4.Enabled = value
        F5.Enabled = value
        F5.Enabled = value
        x6.Enabled = value
        F9.Enabled = value
        F17.Enabled = value
        F85.Enabled = value
        F18.Enabled = value
        F82.Enabled = value
        F19.Enabled = value
        F83.Enabled = value
        F84.Enabled = value
        F25.Enabled = value
        F26.Enabled = value
        F27.Enabled = value
        F28.Enabled = value
        F29.Enabled = value
        F30.Enabled = value
        F31.Enabled = value
        F32.Enabled = value
        F33.Enabled = value
        F34.Enabled = value
        F35.Enabled = value
        F36.Enabled = value
        F37.Enabled = value
        F38.Enabled = value
        F39.Enabled = value
        F39.Enabled = value
        F40.Enabled = value
        x31.Enabled = value
        x32.Enabled = value
        x33.Enabled = value
        x34.Enabled = value
        x35.Enabled = value
        x36.Enabled = value
        x37.Enabled = value
        x38.Enabled = value
        x39.Enabled = value
        F20.Enabled = value
    End Sub

    Private Sub TimeoutTimer_Tick(sender As Object, e As EventArgs) Handles TimeoutTimer.Tick
        If running = False And testSerialPort = False Then Return

        TimeoutTimer.Enabled = False
        timeout = timeout + 1
        timeout_counter.Text = timeout.ToString

        Dim msg As String = $"{TimeString} RX < TIMEOUT"
        If msg IsNot Nothing Then
            append_log_text(msg, Color.Red, Color.Yellow)
        End If

        'Start the new requests if the serial port speed test is not running
        If testSerialPort = False Then
            RequestTimer.Enabled = True
            RequestTimer.Interval = TXTime.Value

        Else
            serialSpeedChangeStatus = 0

            If (SerialPort1.BaudRate = 2400) Then
                'If the serial port is at 2400 an we got timeout , try 230400
                Debug.WriteLine("TestSpeed: Serial port timeout at 2400, test serial port at " & maxspeed)
                SerialPort1.BaudRate = maxspeed
                TimerTestSerialPort.Enabled = True
            ElseIf (SerialPort1.BaudRate = maxspeed) Then
                'If the serial port is at maxspeed an we got timeout , try 2400
                Debug.WriteLine("TestSpeed: Serial port timeout at " & maxspeed & ", test serial port at 2400")
                SerialPort1.BaudRate = 2400
                TimerTestSerialPort.Enabled = True
            ElseIf (SerialPort1.BaudRate = 115200) Then
                'If the serial port is at 115200 an we got timeout , try 2400
                Debug.WriteLine("TestSpeed: Serial port timeout at 115200, test serial port at 2400")
                SerialPort1.BaudRate = 2400
                TimerTestSerialPort.Enabled = True
            End If

        End If

        If Not (rxtimer Is Nothing) Then
            rxtimer.Reset()
        End If

    End Sub

    'Send request over serial port
    Private Sub SendTXBuffer_Serial(timeoutRequired As Boolean)
        If running = False And testSerialPort = False Then Return

        If SerialPort1.IsOpen = False Then Exit Sub
        trasmissionBuffer = TXBufferList.ToArray

        Dim TXData As String = ""
        For i = 0 To trasmissionBuffer.Count - 1
            Dim v As Integer = trasmissionBuffer(i)
            Dim str = v.ToString("X2")
            TXData = TXData & str & " "
        Next
        'Debug.WriteLine("TX > " & TXData)
        Dim timestring As String = Date.Now.Hour.ToString("00") & ":" & Date.Now.Minute.ToString("00") & ":" & Date.Now.Second.ToString("00") & ":" & Date.Now.Millisecond.ToString("000")
        append_log_text((timestring & " TX > " & TXData))

        If (timeoutRequired) Then
            'Start timeout control
            TimeoutTimer.Enabled = True
        End If

        TX += 1
        TXCounter.Text = TX

        SerialPort1.Write(trasmissionBuffer, 0, trasmissionBuffer.Length)

    End Sub

    ''' <summary>
    ''' Function to add a text to the log text viewer
    ''' </summary>
    ''' <param name="textLog">Text to append to the log</param>
    Private Sub append_log_text(textLog As String)
        log_window_ad.Select(log_window_ad.TextLength, 0)
        log_window_ad.SelectionColor = Color.Black
        log_window_ad.AppendText(vbNewLine & textLog)
        log_window_ad.Refresh()
        'Automatic clean after 20000 lines
        If log_window_ad.Lines.Count > 20000 Then
            log_window_ad.Clear()
        End If

    End Sub





    Private Sub append_log_text(textLog As String, textColor As Color)
        log_window_ad.Select(log_window_ad.TextLength, 0)
        log_window_ad.SelectionColor = textColor
        log_window_ad.AppendText(vbNewLine & textLog)
    End Sub

    Private Sub append_log_text(textLog As String, textColor As Color, highlightsColor As Color)
        log_window_ad.Select(log_window_ad.TextLength, 0)
        log_window_ad.SelectionColor = textColor
        log_window_ad.SelectionBackColor = highlightsColor
        log_window_ad.AppendText(vbNewLine & textLog)
        log_window_ad.SelectionBackColor = log_window_ad.BackColor
    End Sub


    'Refresh available serial ports
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        UpdateAvailableSerialPorts()
    End Sub

    'Reset timeout counter
    Private Sub Label1_DoubleClick(sender As Object, e As EventArgs)
        timeout = 0
        timeout_counter.Text = "0"
    End Sub

    'Reset TX and RX Counters
    Private Sub TXCounter_DoubleClick(sender As Object, e As EventArgs) Handles TXCounter.DoubleClick
        TX = 0
        RX = 0
        TXCounter.Text = "0"
        RXCounter.Text = "0"
    End Sub

    'Reset Checksum errors
    Private Sub Label3_DoubleClick(sender As Object, e As EventArgs)
        Label3.Text = "0"
        chkErrors = 0
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs)
        TX = 0
        RX = 0
        TXCounter.Text = "0"
        RXCounter.Text = "0"
    End Sub

#End Region


#Region "General Protocol commands"


    Private Sub GP_CMD_00()

        Dim command As New List(Of Byte) From {
            &H81,            ' Start byte
            machineAddress,  ' Machine address
            &H0              ' Command 00
        }

        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)

        TXBufferList = command
    End Sub
    Private Sub GP_CMD_01(readType As Byte)

        Dim command As New List(Of Byte) From {
            &H81,            ' Start byte
            machineAddress,  ' Machine address
            &H1,             ' Command 01
            readType         ' 
        }

        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)

        TXBufferList = command
    End Sub
    Private Sub GP_CMD_02()

        Dim command As New List(Of Byte) From {
        &H81,            ' Start byte
        machineAddress,  ' Machine address
        &H3              ' Command 02 (or 03 depending on your machine)
    }

        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)

        TXBufferList = command
    End Sub

#End Region

#Region "CMIS Protocol commands"


    'CMIS command: Perform a Inquire question
    Private Sub CMIS_CMD_07()

        'Debug.WriteLine("     Command 07")

        'Start byte
        'Machine address
        'Command code 07
        Dim command As List(Of Byte) = New List(Of Byte) From {
            &HB0,
            machineAddress,
            &H7
        }

        'Calculate and add crc
        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)
        TXBufferList = command

    End Sub

    'CMIS command: start allowance
    Private Sub CMIS_CMD_04()

        'Start byte
        'Machine address
        'Command code 07
        Dim command As List(Of Byte) = New List(Of Byte) From {
            &HB0,
            machineAddress,
            &H4,
            &H5A        'Start program is always allowed
        }

        'Calculate and add crc
        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)
        TXBufferList = command

    End Sub

    Private Sub CMIS_CMD_40_01()

        'Debug.WriteLine("     Command 40_01")
        Dim L1 As Byte = 0
        Dim L2 As Byte = 0
        Dim L3 As Byte = 0 '&H4
        Dim L4 As Byte = 0 '&H1D
        Dim RF As Byte = 16 'Short description
        Dim BC As Byte = 0


        If (L1 And 128) Then
            BC = BC Or &H1
        End If
        If (L2 And 128) Then
            BC = BC Or &H2
        End If
        If (L3 And 128) Then
            BC = BC Or &H4
        End If
        If (L4 And 128) Then
            BC = BC Or &H8
        End If
        If (RF And 128) Then
            BC = BC Or &H10
        End If

        L1 = L1 And &H7F
        L2 = L2 And &H7F
        L3 = L3 And &H7F
        L4 = L4 And &H7F
        RF = RF And &H7F

        'Start byte
        'Machine address
        'Program group code
        'Command code 01
        'L1
        'L2
        'L3
        'L4
        'RF
        'BC
        Dim command As New List(Of Byte) From {
          &HB0,
          machineAddress,
          &H40,
          1,
          L1,
          L2,
          L3,
          L4,
          RF,
          BC
      }


        'Calculate and add crc
        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)
        TXBufferList = command

    End Sub



    'Service command: Request analog function value
    Private Sub CMIS_CMD_41_01(FunctionId)

        Dim command As List(Of Byte) = New List(Of Byte) From {
            &HB0,
            machineAddress,
            &H41,
            &H1,
            &H0,            'MSB
            FunctionId,     'LSB
            0               'Bit 7 for previus value (always 0 in this case because FunctionId is <127)
        }
        'Calculate and add crc
        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)
        TXBufferList = command

    End Sub

    'Service command: Request weight
    Private Sub CMIS_CMD_41_03(FunctionId)

        'Start byte
        'Machine address
        'Command code 41 01
        Dim command As List(Of Byte) = New List(Of Byte) From {
            &HB0,
            machineAddress,
            &H41,
            &H3,
            &H1            'Weight at program start
        }
        'Calculate and add crc
        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)
        TXBufferList = command

    End Sub


    Private Sub CMIS_CMD_0A_45(FunctionId)

        'Start byte
        'Machine address
        'Command code 41 01
        Dim command As List(Of Byte) = New List(Of Byte) From {
            &HB4,
            machineAddress,
            &HA,
            &H45,
            &H0,            'MSB
            FunctionId,     'LSB
            0               'Bit 7 for previus value (always 0 in this case because FunctionId is <127)
        }
        'Calculate and add crc
        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)
        TXBufferList = command

    End Sub


#End Region

#Region "GENERAL PROTOCOL COMMANDS"

    'General command, set new baudrate
    Private Sub GENERAL_CMD_SET_BAUDRATE(Value)
        Dim codespeed As Short = 0

        If maxspeed = 230400 Then
            codespeed = 15
        ElseIf maxspeed = 38400 Then
            codespeed = 10
        End If

        'Start byte
        'Machine address
        'Command code 07
        Dim command As List(Of Byte) = New List(Of Byte) From {
            &H81,
            machineAddress,
            &H51,
            codespeed
        }

        'Calculate and add crc
        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)
        TXBufferList = command

    End Sub


#End Region

#Region "SERVICE COMMANDS"


    'Service command: Request output function status
    Private Sub SERVICE_CMD_GET_OUTPUT_FUNCTION(FunctionId)

        'Start byte
        'Machine address
        'Command code 07
        Dim command As List(Of Byte) = New List(Of Byte) From {
            &HB4,
            machineAddress,
            &HA,
            &H41,
            0,
            FunctionId,
            0
        }
        'Calculate and add crc
        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)
        TXBufferList = command

    End Sub

    Private Sub SERVICE_CMD_GET_DRIER_TEMPERATURE(boardAddress As Byte)

        Dim command As List(Of Byte) = New List(Of Byte) From {
        &HB4,               'Master ID
        machineAddress,     'Machine address
        &H6,               'I/O group
        &H0,               'Get IN/OUT temperature
        boardAddress        'I/O board address
    }

        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF

        command.Add(crcH)
        command.Add(crcL)

        TXBufferList = command

    End Sub


    Private Sub SERVICE_CMD_GET_RMC(boardAddress As Byte)

        Dim command As List(Of Byte) = New List(Of Byte) From {
        &HB4,
        machineAddress,
        &H6,
        &H1,               'Get RMC value
        boardAddress
    }

        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF

        command.Add(crcH)
        command.Add(crcL)

        TXBufferList = command

    End Sub
    'Service command: Request output function status
    Private Sub SERVICE_CMD_GET_INPUT_FUNCTION(FunctionId)

        'Start byte
        'Machine address
        'Command code 07
        Dim command As List(Of Byte) = New List(Of Byte) From {
            &HB4,
            machineAddress,
            &HA,
            &H42,
            0,
            FunctionId,
            0
        }
        'Calculate and add crc
        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)
        TXBufferList = command

    End Sub

    'Service command: Request output function status
    Private Sub SERVICE_CMD_GET_ANALOG_FUNCTION(FunctionId)

        'Start byte
        'Machine address
        'Command code 07
        Dim command As List(Of Byte) = New List(Of Byte) From {
            &HB4,
            machineAddress,
            &HA,
            &H45,
            0,
            FunctionId,
            0
        }
        'Calculate and add crc
        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)
        TXBufferList = command

    End Sub



    'Service command: Request output function status
    Private Sub SERVICE_CMD_SETMODE(Mode)

        'Start byte
        'Machine address
        'Command code 07
        Dim command As List(Of Byte) = New List(Of Byte) From {
            &H82,
            machineAddress,
            &H70,
            Mode
        }
        'Calculate and add crc
        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)
        TXBufferList = command

    End Sub

    Private Sub SERVICE_CMD_GETARTICLESOFTWARE(Mode)

        'Start byte
        'Machine address
        'Command code 01
        Dim command As List(Of Byte) = New List(Of Byte) From {
            &H81,
            machineAddress,
            &H1,
            1
        }
        'Calculate and add crc
        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)
        TXBufferList = command

    End Sub


    Private Sub SERVICE_CMD_GETBOARDINFO(address)

        'Start byte
        'Machine address
        'Command code 01
        Dim command As List(Of Byte) = New List(Of Byte) From {
            &HB4,
            machineAddress,
            &HA,
            &HF,
            address
        }
        'Calculate and add crc
        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)
        TXBufferList = command

    End Sub


    'Service command: Request output function status
    Private Sub SERVICE_CMD_WRITE_CONFIG_VALUE(ParameterIndex, Value)

        Dim index1, index2, value1, value2, value3, value4 As Byte

        'Get bytes for Index
        index1 = (ParameterIndex >> 8) And &HFF
        index2 = ParameterIndex And &HFF

        ' Get bytes for value
        value1 = ((Value >> 24) And &HFF)
        value2 = ((Value >> 16) And &HFF)
        value3 = ((Value >> 8) And &HFF)
        value4 = (Value And &HFF)


        'Get collector bit
        Dim BC As Byte = 0

        'Update data with collectr bits
        If (index1 And 128) Then : BC = BC Or &H1 : End If
        If (index2 And 128) Then : BC = BC Or &H2 : End If

        If (value1 And 128) Then : BC = BC Or &H4 : End If
        If (value2 And 128) Then : BC = BC Or &H8 : End If
        If (value3 And 128) Then : BC = BC Or &H10 : End If
        If (value4 And 128) Then : BC = BC Or &H20 : End If

        'Reset th highest bit
        value1 = value1 And &H7F
        value2 = value2 And &H7F
        value3 = value3 And &H7F
        value4 = value4 And &H7F

        'Start byte
        'Machine address
        'Command code 07
        Dim command As List(Of Byte) = New List(Of Byte) From {
            &HB4,
            machineAddress,
            &H14,
            &H1,
            1,              'CT
            index1,         'Index MSB
            index2,         'Index LSB
            value1,         'Value MSB
            value2,
            value3,
            value4,         'Value LSB
            BC              'Collector byte
        }
        'Calculate and add crc
        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)
        TXBufferList = command

    End Sub

    'Service command: Request output function status
    Private Sub SERVICE_CMD_READ_CONFIG_VALUE(ParameterIndex)

        Dim index1, index2 As Byte

        'Get bytes for Index
        index1 = (ParameterIndex >> 8) And &HFF
        index2 = ParameterIndex And &HFF

        'Get collector bit
        Dim BC As Byte = 0

        'Update data with collectr bits
        If (index1 And 128) Then : BC = BC Or &H1 : End If
        If (index2 And 128) Then : BC = BC Or &H2 : End If

        'Reset th highest bit
        index1 = index1 And &H7F
        index2 = index2 And &H7F

        'Start byte
        'Machine address
        'Command code 07
        Dim command As List(Of Byte) = New List(Of Byte) From {
            &HB4,
            machineAddress,
            &H14,
            &H0,
            1,              'CT
            index1,         'Index MSB
            index2,         'Index LSB
            BC              'Collector byte
        }
        'Calculate and add crc
        Dim crc As Integer = checksumCalulate(command)
        Dim crcH As Byte = (crc >> 8) And &HFF
        Dim crcL As Byte = crc And &HFF
        command.Add(crcH)
        command.Add(crcL)
        TXBufferList = command

    End Sub

#End Region

#Region "CMIS/SERVICE Commands trasmission handler"
    Dim RequestIndex As Integer

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles RequestTimer.Tick
        RequestTimer.Interval = TXTime.Value
        RequestTimer.Stop()
        If manualscan Then Return

        'Prepare the receive buffer
        RXBufferReceived = New List(Of Byte)

        'Send request
        If requestList.Count = 0 Then
            requestID = offsetDigitalOutput
        Else

            If RequestIndex >= requestList.Count Then
                RequestIndex = 0
            End If

            requestID = requestList(RequestIndex)
            RequestIndex += 1

        End If
        'Check if manual command is requested
        If manualCommand Then

            requestID = 0

            If remoteserviceRequest = 1 Then

                remoteserviceRequest = 2
                'Send command to activate the remote service
                SERVICE_CMD_SETMODE(2)


            ElseIf remoteserviceRequest = 2 Then

                remoteserviceRequest = 3

                'Prepare the manual command
                SERVICE_CMD_WRITE_CONFIG_VALUE(2, 60 * NumericUpDown1.Value)

            ElseIf remoteserviceRequest = 3 Then

                'Prepare the manual command
                SERVICE_CMD_SETMODE(0)

                remoteserviceRequest = 0
                manualCommand = 0

                'Exit from the manual command

            ElseIf remoteserviceRequest = 4 Then

                remoteserviceRequest = 5

                'Send command to activate the remote service
                SERVICE_CMD_SETMODE(2)

            ElseIf remoteserviceRequest = 5 Then

                remoteserviceRequest = 6

                'Prepare the manual command
                SERVICE_CMD_READ_CONFIG_VALUE(2)

            ElseIf remoteserviceRequest = 6 Then

                'Prepare the manual command
                SERVICE_CMD_SETMODE(0)

                remoteserviceRequest = 0
                manualCommand = 0

            ElseIf remoteserviceRequest = 8 Then

                'Prepare the manual command
                SERVICE_CMD_GETARTICLESOFTWARE(0)

                remoteserviceRequest = 0
                manualCommand = 0

            ElseIf remoteserviceRequest = 9 Then

                'Prepare the manual command
                SERVICE_CMD_GETBOARDINFO(2)

                remoteserviceRequest = 0
                manualCommand = 0

            End If

            '' End If

        Else
            If (requestID And offsetDigitalOutput) Then
                SERVICE_CMD_GET_OUTPUT_FUNCTION(requestID - offsetDigitalOutput)
                'Debug.WriteLine("---------------------------------------------------- Request output function " & (requestID - offsetDigitalOutput).ToString)

            ElseIf (requestID And offsetDigitalInput) Then
                SERVICE_CMD_GET_INPUT_FUNCTION(requestID - offsetDigitalInput)

            ElseIf (requestID And offsetAnalogInput) Then
                SERVICE_CMD_GET_ANALOG_FUNCTION(requestID - offsetAnalogInput)
                'Debug.WriteLine("---------------------------------------------------- Request analog input infunction " & (requestID - offsetAnalogInput).ToString)
            ElseIf (requestID And offsetDrierIO) Then

                Dim cmd = requestID - offsetDrierIO

                If cmd = 0 Then
                    SERVICE_CMD_GET_DRIER_TEMPERATURE(1)
                ElseIf cmd = 1 Then
                    SERVICE_CMD_GET_RMC(1)
                End If

            ElseIf (requestID And offsetCMISProtocol) Then

                If (requestID - offsetCMISProtocol) = 7 Then          'Check the enquire message
                    'Debug.WriteLine("Request Enquire status!")
                    CMIS_CMD_07()
                ElseIf (requestID - offsetCMISProtocol) = 4 Then      'Check the start allowance
                    'Debug.WriteLine("Request to send start allowance!")
                    CMIS_CMD_04()
                ElseIf (requestID - offsetCMISProtocol) = 3 Then      'Check the start allowance
                    CMIS_CMD_41_03(requestID - offsetCMISProtocol)      'Get weight
                ElseIf (requestID - offsetCMISProtocol) = 1 AndAlso Not programNameCMISFound Then      'Check the program name
                    CMIS_CMD_40_01()      'get name of program
                Else
                    CMIS_CMD_41_01(requestID - offsetCMISProtocol)      'Check other CMIS commands
                End If

            ElseIf (requestID And offsetGeneralProtocol) Then

                Dim cmd As Integer = requestID - offsetGeneralProtocol

                Select Case cmd
                    Case 0
                        'General protocol command 00
                        GP_CMD_00()
                    Case 1
                        If flagforCMD_01_H2 Then
                            GP_CMD_01(&H1)
                        Else
                            GP_CMD_01(&H2)
                        End If
                End Select

            End If

        End If



        If TrasmissionOnSerialPort Then
            'Trasmission to serial port
            SendTXBuffer_Serial(True)
        End If

    End Sub

#End Region

    Dim currentCompStatus As Boolean = False
    Dim currentProgramStatus As Boolean = False
    Dim previousCompStatus As Boolean = False
    Dim previousProgramStatus As Boolean = False
    Public isCommunicating As Boolean = False  '' TO be updated latwer
    Dim flagforCMD_01_H1 As Boolean = False
    Dim flagforCMD_01_H2 As Boolean = False
    Private Function StripAnsi(input As String) As String
        If String.IsNullOrEmpty(input) Then Return input

        ' Matches ANSI escape sequences like ESC[0m, ESC[0;32m, etc.
        Return Regex.Replace(input, "\x1B\[[0-9;]*[A-Za-z]", "")
    End Function

    Private Function ExtractIntAfter(line As String, key As String) As Integer?
        Dim pattern As String = $"{Regex.Escape(key)}\s*(\d+)"
        Dim m As Match = Regex.Match(line, pattern, RegexOptions.IgnoreCase)

        If m.Success Then
            Return Integer.Parse(m.Groups(1).Value)
        End If

        Return Nothing
    End Function
    Private Function ExtractProgramIndex(line As String) As Integer?
        Dim m = System.Text.RegularExpressions.Regex.Match(
        line,
        "programIndex:\s*(\d+)",
        System.Text.RegularExpressions.RegexOptions.IgnoreCase)

        If m.Success Then
            Return Integer.Parse(m.Groups(1).Value)
        End If

        Return Nothing
    End Function



    Private Sub FtdiPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles FtdiPort.DataReceived

        If Not FtdiConnected Then
            Exit Sub
        End If

        Dim data As String = FtdiPort.ReadExisting()
        If String.IsNullOrEmpty(data) Then Exit Sub

        Dim ts As String = Date.Now.ToString("HH:mm:ss:fff")
        Dim cleanData As String = StripAnsi(data)
        For Each line As String In cleanData.Split({vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)

            Dim remainingTime As Integer? =
        ExtractIntAfter(line, "module remaining Time:")


            If remainingTime.HasValue Then
                SyncLock remainingTimesLock
                    moduleRemainingTimes.Add(remainingTime.Value)
                End SyncLock
                Me.BeginInvoke(Sub()
                                   RemainingTimeValue.Text = remainingTime.Value.ToString()
                               End Sub)
            End If


            Dim now As DateTime = Date.Now

                If String.IsNullOrEmpty(combinedVersion) Then
                    combinedVersion = ""
                Else
                    combinedVersion = String.Concat(combinedVersion.Split(Path.GetInvalidFileNameChars()))
                End If

                Dim timestampFolder As String = now.ToString("yy_MM_dd")
                Dim timestampFile As String = now.ToString("HHmmss")



            Dim fileName As String = $"{MachineName}_{programName}_{combinedVersion}_{DateTime.Now:yyyy-MM-dd}.txt"
            If String.IsNullOrEmpty(DirectoryPerWashProgram) Then
                Dim temp = machineFolder + "\" + "IDLE_Mode"
                logFileName = Path.Combine(temp, fileName)
                Else
                    logFileName = Path.Combine(DirectoryPerWashProgram, fileName)
            End If
            Me.BeginInvoke(Sub()

                           End Sub)

        Next


        Dim logLine As String = ts & " RX < " & cleanData

        If Not String.IsNullOrWhiteSpace(logFileName) AndAlso programNameCMISFound Then
            Try
                File.AppendAllText(logFileName, logLine & Environment.NewLine)
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If

        Me.Invoke(Sub()
                      AppendLog(logLine)
                  End Sub)
    End Sub




    Private Sub parseCommand00(list1 As List(Of Byte))

        Dim V1 As Integer = list1(3)
        Dim V2 As Integer = list1(4)
        Dim MO As Integer = list1(5)
        Dim MA As Integer = list1(6)
        Dim R1 As Integer = list1(7)
        Dim R2 As Integer = list1(8)
        Dim FS As Integer = list1(9)
        Dim X1 As Integer = list1(10)
        Dim CT As Integer = list1(11)
        Dim B1 As Integer = list1(12)
        Dim B2 As Integer = list1(13)
        Dim MT As Integer = list1(14)
        Dim ES As Integer = list1(15)
        Dim X2 As Integer = list1(16)

        ' Apply collector bits (X1)
        If (X1 And &H1) <> 0 Then V1 = V1 Or &H80
        If (X1 And &H2) <> 0 Then V2 = V2 Or &H80
        If (X1 And &H4) <> 0 Then MO = MO Or &H80
        If (X1 And &H8) <> 0 Then MA = MA Or &H80
        If (X1 And &H10) <> 0 Then R1 = R1 Or &H80
        If (X1 And &H20) <> 0 Then R2 = R2 Or &H80
        If (X1 And &H40) <> 0 Then FS = FS Or &H80

        ' Apply collector bits (X2)
        If (X2 And &H1) <> 0 Then CT = CT Or &H80
        If (X2 And &H2) <> 0 Then B1 = B1 Or &H80
        If (X2 And &H4) <> 0 Then B2 = B2 Or &H80
        If (X2 And &H8) <> 0 Then MT = MT Or &H80
        If (X2 And &H10) <> 0 Then ES = ES Or &H80

        ' Build firmware version
        Dim version As Integer = (V1 << 8) + V2
        Dim major As Integer = version >> 8
        Dim minor As Integer = version And &HFF

        versionStr = major & "." & minor

        ' Bootloader version
        Dim boot_version As Integer = (B1 << 8) + B2

    End Sub
    Private Sub parseCommand01(list1 As List(Of Byte))

        Dim asciiBytes As New List(Of Byte)
        For i = 4 To list1.Count - 4
            asciiBytes.Add(list1(i))
        Next

        Dim parsedValue As String =
        Encoding.ASCII.GetString(asciiBytes.ToArray()).Trim()
        'Dim test As String = parsedValue
        Select Case list1(3)
            Case &H1
                machineVersion = parsedValue

                flagforCMD_01_H1 = True
            Case &H2
                articleVersion = parsedValue
                MachineName = MachineSWToEUT(articleVersion.ToString())
                machineFolder = Path.Combine(ResultsFolderPath, MachineName)
                Directory.CreateDirectory(machineFolder)
                flagforCMD_01_H2 = True
        End Select


        ' Only continue when articleVersion is available
        If String.IsNullOrWhiteSpace(articleVersion) Then Exit Sub

        Dim parts() As String = articleVersion.Split(" "c)

        Dim articleNumber As String = parts(0)
        Dim suffix As String = ""

        If parts.Length > 1 Then
            suffix = String.Join(" ", parts.Skip(1))
        End If



        LabelFirmwareVersion.Text = versionStr & "_" & articleVersion
        If flagforCMD_01_H1 And flagforCMD_01_H2 Then
            combinedVersion = machineVersion & "_" & articleVersion & "_" & versionStr.Replace(".", "-")

            If suffix <> "" Then
                combinedVersion &= "." & suffix.Replace(" ", "")
            End If
            requestList.Remove(offsetGeneralProtocol + 0)
            requestList.Remove(offsetGeneralProtocol + 1)
        End If

    End Sub

    Private Sub parseCommand02(list1 As List(Of Byte))
        Dim asciiBytes As New List(Of Byte)
        For i = 4 To list1.Count - 4
            asciiBytes.Add(list1(i))
        Next

        Dim baseArticle As String = Encoding.ASCII.GetString(asciiBytes.ToArray()).Trim()
        append_log_text("RAW: " & BitConverter.ToString(list1.ToArray()), Color.Blue)
        append_log_text("CMD: " & list1(2).ToString("X2"), Color.Blue)

    End Sub
    Private Sub parseCommand06_00(list1 As List(Of Byte))

        Dim I1 As Integer = list1(4)
        Dim I2 As Integer = list1(5)
        Dim O1 As Integer = list1(6)
        Dim O2 As Integer = list1(7)
        Dim XX As Integer = list1(8)

        'Apply collector bits
        If (XX And &H1) <> 0 Then I1 = I1 Or &H80
        If (XX And &H2) <> 0 Then I2 = I2 Or &H80
        If (XX And &H4) <> 0 Then O1 = O1 Or &H80
        If (XX And &H8) <> 0 Then O2 = O2 Or &H80

        Dim inTempF As Integer = (I1 << 8) Or I2
        Dim outTempF As Integer = (O1 << 8) Or O2

        'optional conversion
        inTempC = (inTempF - 32) * 5 / 9
        outTempC = (outTempF - 32) * 5 / 9

    End Sub

    Private Sub parseCommand06_01(list1 As List(Of Byte))

        Dim R1 As Integer = list1(4)
        Dim R2 As Integer = list1(5)
        Dim R3 As Integer = list1(6)
        Dim R4 As Integer = list1(7)
        Dim XX As Integer = list1(8)

        'Apply collector bits
        If (XX And &H1) <> 0 Then R1 = R1 Or &H80
        If (XX And &H2) <> 0 Then R2 = R2 Or &H80
        If (XX And &H4) <> 0 Then R3 = R3 Or &H80
        If (XX And &H8) <> 0 Then R4 = R4 Or &H80

        rmcValue =
        (CLng(R1) << 24) Or
        (CLng(R2) << 16) Or
        (CLng(R3) << 8) Or
        R4

    End Sub

    Private lastTemp As Double = Double.NaN
    Private lastSampleTime As DateTime = DateTime.MinValue
    Dim currentStep As Integer = -1
    Dim stepStartTemp As Double = Double.NaN
    Dim stepStartTime As DateTime
    Private startTempAvg As Boolean = False
    Private Function MachineSWToEUT(sw As String) As String

        Select Case sw.Trim()

            Case "480060001"
                Return "EUT_001964"

            Case "480060012"
                Return "EUT_002008"

            Case "480060003"
                Return "EUT_001963"

            Case "418830201"
                Return "EUT_001937"

            Case "418830102"
                Return "EUT_001969"

            Case "418830101"
                Return "EUT_001972"

            Case "418830203"
                Return "EUT_001934"

            Case "418830202"
                Return "EUT_001941"

            Case Else
                Return "Unknown EUT (" & sw & ")"

        End Select

    End Function

    'General parsing of incoming commands
    Private Sub parseIncomingMessage(list1 As List(Of Byte))
        Dim function_value As Boolean = False
        Dim im As Image = My.Resources._1

        Dim RXData As String = ""
        For i = 0 To list1.Count - 1
            Dim v As Integer = list1(i)
            Dim str = v.ToString("X2")
            RXData = RXData & str & " "
        Next
        'Debug.WriteLine("RX < " & RXData)
        Dim timestring As String = Date.Now.Hour.ToString("00") & ":" & Date.Now.Minute.ToString("00") & ":" & Date.Now.Second.ToString("00") & ":" & Date.Now.Millisecond.ToString("000")
        append_log_text((timestring & " RX < " & RXData), Color.Brown)


        If testSerialPort Then
            messageReceived = True
            If (serialSpeedChangeStatus = 0) Then
                serialSpeedChangeStatus = 1
                TimerTestSerialPort.Enabled = True
            End If
            Return
        End If

        ''Parse General Protocol Input Function
        If requestID And offsetGeneralProtocol Then
            requestID = requestID - offsetGeneralProtocol

            Select Case requestID
                Case &H0
                    parseCommand00(list1)
                Case &H1
                    parseCommand01(list1)
            End Select
        End If

        'Parse Drier IO commands
        If requestID And offsetDrierIO Then

            Dim cmd As Integer = requestID - offsetDrierIO

            Select Case cmd

                Case 0
                    parseCommand06_00(list1)   'Temperature

                Case 1
                    parseCommand06_01(list1)   'RMC

            End Select

        End If

        'Parse CMIS Protocol Input Function
        If requestID And offsetCMISProtocol Then
            requestID = requestID - offsetCMISProtocol

            Select Case requestID
                Case 1
                    'Parse resonse of Program name
                    If Not programNameCMISFound Then
                        parseCommand40_01(list1)
                    End If


                Case 7
                    'Parse Enquire message to check the start allowance bit
                    Dim BP1 As Byte = list1(3)
                    Dim BP2 As Byte = list1(4)
                    Dim BP3 As Byte = list1(5)
                    Dim BP4 As Byte = list1(6)
                    Dim PS14 As Byte = list1(7)
                    Dim PS24 As Byte = list1(8)
                    Dim PPS As Byte = list1(9)


                    'Check if the start allowance is request (this is used to allow the start of program automatically when CMIS is acvie)
                    If (BP1 And 1) Then
                        'Add a command in the list to allow the start the program
                        requestList.Add(offsetCMISProtocol + 4)
                    End If

                    'Parse the current module step: byte PPS we don't need to check the last bit
                    Label13.Text = PPS.ToString()
                    Label21.Text = getModuleNameFromIndex(PPS)

                    If Not PS24.ToString = "0" Then
                        If Not requestList.Contains(offsetCMISProtocol + 1) Then
                            requestList.Add(offsetCMISProtocol + 1)
                            programNameCMISFound = False
                        End If
                        ''updateRequestList()
                    Else
                        If requestList.Contains(offsetCMISProtocol + 1) Then
                            requestList.Remove(offsetCMISProtocol + 1)
                        End If
                    End If



                    'Parse the remaining time to end
                    'TODO

                Case 3
                    'Read the weight at program start
                    'Parse Enquire message to check the start allowance bit
                    Dim W_msb As Byte = list1(5)
                    Dim W_lsb As Byte = list1(6)
                    Dim XX As Byte = list1(7)

                    'Update data with collectr bits
                    If (XX And &H1) Then W_msb = W_msb Or &H80
                    If (XX And &H2) Then W_lsb = W_lsb Or &H80

                    Dim weight As Short = (W_msb * 256) + W_lsb

                    'Parse the current module step: byte PPS we don't need to check the last bit
                    Label4.Text = weight.ToString()


                Case 4
                    Debug.WriteLine("Start allowance sent and received! Program should start now")
                    requestList.Remove(offsetCMISProtocol + 4)

                Case 10

                    'Parse temperature
                    Dim isValueMSB As Byte = list1(4)
                    Dim isValueLSB As Byte = list1(5)
                    Dim setValueMSB As Byte = list1(6)
                    Dim setValueLSB As Byte = list1(7)
                    Dim xx As Byte = list1(8)

                    'Update data with collectr bits
                    If (xx And &H1) Then isValueMSB = isValueMSB Or &H80
                    If (xx And &H2) Then isValueLSB = isValueLSB Or &H80
                    If (xx And &H4) Then setValueMSB = setValueMSB Or &H80
                    If (xx And &H8) Then setValueLSB = setValueLSB Or &H80

                    Dim Temperature As Short = (isValueMSB * 256) + isValueLSB
                    Dim x = BinaryToComplement2(Temperature)
                    Dim TemperatureC As Double = (x - 32) * 5 / 9

                    WATER_TEMP.Text = TemperatureC.ToString("0.0")


                    Dim currentTemp As Double = Convert.ToDouble(WATER_TEMP.Text)

                    If OUT9.Tag = "0" And startTempAvg = False Then
                        stepStartTime = DateTime.Now
                        stepStartTemp = TemperatureC

                    End If

                    If OUT9.Tag = "1" Then
                        startTempAvg = True
                        Dim elapsedMinutes As Double =
                        (DateTime.Now - stepStartTime).TotalMinutes

                        If elapsedMinutes > 0 Then
                            Dim delta As Double = TemperatureC - stepStartTemp
                            Dim avg As Double = delta / elapsedMinutes

                            gform.TempPerMin.Text = avg.ToString("0.00")

                            ' If already passed the target temperature
                            If Math.Abs(avg) < 0.0001 Then
                                gform.SpeedInfo.Text = "Loading..."

                            Else
                                ' Safe calculation
                                Dim minutes As Integer = CInt((ProgramsTemperature - TemperatureC) / avg)
                                gform.SpeedInfo.Font = New Font(gform.SpeedInfo.Font, FontStyle.Bold)
                                gform.SpeedInfo.Text = $"{minutes} min"
                            End If
                        End If




                    End If


                    'Parse set temperature
                    Dim setTemperature As Short = (setValueMSB * 256) + setValueLSB
                    x = BinaryToComplement2(setTemperature)
                    Dim setTemperatureC As Double = (x - 32) * 5 / 9

                    SET_TEMP.Text = setTemperatureC.ToString("0.0")

                Case 12
                    'Parse water level and set level
                    Dim isValueMSB As Byte = list1(4)
                    Dim isValueLSB As Byte = list1(5)
                    Dim setValueMSB As Byte = list1(6)
                    Dim setValueLSB As Byte = list1(7)
                    Dim xx As Byte = list1(8)

                    'Update data with collectr bits
                    If (xx And &H1) Then isValueMSB = isValueMSB Or &H80
                    If (xx And &H2) Then isValueLSB = isValueLSB Or &H80
                    If (xx And &H4) Then setValueMSB = setValueMSB Or &H80
                    If (xx And &H8) Then setValueLSB = setValueLSB Or &H80

                    'Water level
                    Dim Level As Short = (isValueMSB * 256) + isValueLSB
                    Dim x = BinaryToComplement2(Level)
                    WATER_LEVEL.Text = x.ToString("0")

                    'Water level setpoint
                    Dim setLevel As Short = (setValueMSB * 256) + setValueLSB
                    x = BinaryToComplement2(setLevel)
                    SET_LEVEL.Text = x.ToString("0")

                Case 14
                    'Parse drum speed and set speed
                    Dim isValueMSB As Byte = list1(4)
                    Dim isValueLSB As Byte = list1(5)
                    Dim setValueMSB As Byte = list1(6)
                    Dim setValueLSB As Byte = list1(7)
                    Dim xx As Byte = list1(8)

                    'Update data with collectr bits
                    If (xx And &H1) Then isValueMSB = isValueMSB Or &H80
                    If (xx And &H2) Then isValueLSB = isValueLSB Or &H80
                    If (xx And &H4) Then setValueMSB = setValueMSB Or &H80
                    If (xx And &H8) Then setValueLSB = setValueLSB Or &H80

                    'Drum speed
                    Dim speed As Short = (isValueMSB * 256) + isValueLSB
                    Dim x = BinaryToComplement2(speed)
                    DRUM_SPEED.Text = x.ToString("0")

                    'Drum set speed
                    Dim setspeed As Short = (setValueMSB * 256) + setValueLSB
                    x = BinaryToComplement2(setspeed)
                    SET_SPEED.Text = x.ToString("0")

                Case 31
                    'Parse drum speed and set speed
                    Dim rc As Byte = list1(4)
                    Dim setValueMSB As Byte = list1(5)
                    Dim setValueLSB As Byte = list1(6)
                    Dim xx As Byte = list1(7)

                    'Update data with collectr bits
                    If (xx And &H1) Then rc = rc Or &H80
                    If (xx And &H2) Then setValueMSB = setValueMSB Or &H80
                    If (xx And &H4) Then setValueLSB = setValueLSB Or &H80

                    'Drum speed
                    Dim speed As Short = (setValueMSB * 256) + setValueLSB
                    Debug.Print("Compressor: " & speed.ToString())

                    'Check if the heater is on
                    If (speed) Then
                        im = My.Resources._2

                    Else
                        im = My.Resources._1

                    End If


            End Select



        End If

        'Parse Service protocol - Analog Input function
        If requestID And offsetAnalogInput Then
            requestID = requestID - offsetAnalogInput
            Dim info As String = "0"


            Select Case requestID

                'XY Axis
                Case 2
                    Dim rc As Byte = list1(4)
                    Dim dataValueMSB As Byte = list1(5)
                    Dim dataValueLSB As Byte = list1(6)
                    Dim xx As Byte = list1(7)

                    'Update data with collectr bits
                    If (xx And &H1) Then rc = rc Or &H80
                    If (xx And &H2) Then dataValueMSB = dataValueMSB Or &H80
                    If (xx And &H4) Then dataValueLSB = dataValueLSB Or &H80

                    'XY Axis
                    Dim xy As Short = (dataValueMSB * 256) + dataValueLSB
                    ACC_XY.Text = xy.ToString()

                'Z Axis
                Case 3
                    Dim rc As Byte = list1(4)
                    Dim dataValueMSB As Byte = list1(5)
                    Dim dataValueLSB As Byte = list1(6)
                    Dim xx As Byte = list1(7)

                    'Update data with collectr bits
                    If (xx And &H1) Then rc = rc Or &H80
                    If (xx And &H2) Then dataValueMSB = dataValueMSB Or &H80
                    If (xx And &H4) Then dataValueLSB = dataValueLSB Or &H80

                    'XY Axis
                    Dim xy As Short = (dataValueMSB * 256) + dataValueLSB
                    ACC_Z.Text = xy.ToString()


                '3 Axis
                Case 4

                    Dim rc As Byte = list1(4)
                    Dim dataValueMSB As Byte = list1(5)
                    Dim dataValueLSB As Byte = list1(6)
                    Dim xx As Byte = list1(7)

                    'Update data with collectr bits
                    If (xx And &H1) Then rc = rc Or &H80
                    If (xx And &H2) Then dataValueMSB = dataValueMSB Or &H80
                    If (xx And &H4) Then dataValueLSB = dataValueLSB Or &H80

                    'XY Axis
                    Dim xy As Short = (dataValueMSB * 256) + dataValueLSB
                    ACC_3.Text = xy.ToString()

            End Select



        End If

        'Parse Service protocol -  Digital Input function
        If requestID And offsetDigitalInput Then
            requestID = requestID - offsetDigitalInput
            Dim info As String = "0"

            If list1(4) = 1 Then
                im = My.Resources._2
                info = "1"
            Else
                im = My.Resources._1
                info = "0"
            End If

            Select Case requestID
            ' 'Digital Input : In the request ID there is an offset of 1000
                Case 3                      'DOOR CLOSED
                    i3.Image = im
                    i3.Tag = info
                    requestID = offsetDigitalOutput + 4

                Case 4                      'DOOR LOCKED
                    i4.Image = im
                    i4.Tag = info
                    requestID = 2010
            End Select
        End If

        'Parse Service protocol -  Digital Output
        If requestID And offsetDigitalOutput Then
            requestID = requestID - offsetDigitalOutput

            Dim info As String = "0"
            If list1(4) = 1 Then
                info = "1"
                im = My.Resources._2
            Else
                info = "0"
                im = My.Resources._1
            End If

            'Check the answer for specific request
            Select Case requestID
                Case 0                      'Cold to drum
                    OUT0.Image = im
                    OUT0.Tag = info
                Case 1                      'Hot to drum
                    OUT1.Image = im
                    OUT1.Tag = info
                Case 3                      'Drain
                    OUT3.Image = im
                    OUT3.Tag = info
                Case 24                      'FLush valve
                    OUT5.Image = im
                    OUT5.Tag = info
                Case 74                     'Recirculation pump
                    OUT4.Image = im
                    OUT4.Tag = info
                Case 9                      'Heater
                    OUT9.Image = im
                    OUT9.Tag = info
                Case 17                      'Cold to wash
                    OUT17.Image = im
                    OUT17.Tag = info
                Case 85                     'Hot to wash
                    OUT85.Image = im
                    OUT85.Tag = info
                Case 18                      'Cold to prewash
                    OUT18.Image = im
                    OUT18.Tag = info
                Case 82                     'Hot to prewash
                    OUT82.Image = im
                    OUT82.Tag = info
                Case 19                     'Cold to softener
                    OUT19.Image = im
                    OUT19.Tag = info
                Case 83                     'Hot to softener
                    OUT83.Image = im
                    OUT83.Tag = info
                Case 84                     'Cold to bleach
                    OUT84.Image = im
                    OUT84.Tag = info
                Case 20                     'Hot to bleach
                    OUT20.Image = im
                    OUT20.Tag = info
                Case 25                     'pump 1
                    OUT25.Image = im
                    OUT25.Tag = info
                Case 26                     'pump 2
                    OUT26.Image = im
                    OUT26.Tag = info
                Case 27                     'pump 3
                    OUT27.Image = im
                    OUT27.Tag = info
                Case 28                     'pump 4
                    OUT28.Image = im
                    OUT28.Tag = info
                Case 29                     'pump 5
                    OUT29.Image = im
                    OUT29.Tag = info
                Case 30                     'pump 6
                    OUT30.Image = im
                    OUT30.Tag = info
                Case 31                     'pump 7
                    OUT31.Image = im
                    OUT31.Tag = info
                Case 32                     'pump 8
                    OUT32.Image = im
                    OUT32.Tag = info
                Case 33                     'pump 9
                    OUT33.Image = im
                    OUT33.Tag = info
                Case 34                     'pump 10
                    OUT34.Image = im
                    OUT34.Tag = info
                Case 35                     'pump 11
                    OUT35.Image = im
                    OUT35.Tag = info
                Case 36                     'pump 12
                    OUT36.Image = im
                    OUT36.Tag = info
                Case 37                     'pump 13
                    OUT37.Image = im
                    OUT37.Tag = info
                Case 38                     'pump 14
                    OUT38.Image = im
                    OUT38.Tag = info
                Case 39                     'pump 15
                    OUT39.Image = im
                    OUT39.Tag = info
                Case 40                     'pump 16
                    OUT40.Image = im
                    OUT40.Tag = info
            End Select



        End If

        RequestTimer.Start()

    End Sub

    Private Function getModuleNameFromIndex(pPS As Byte) As String
        Select Case pPS
            Case 0
                Return "IDLE"
            Case 17
                Return "WEIGHING"
            Case 1
                Return "PRE-WASH"
            Case 2
                Return "MAIN WASH"
            Case 3
                Return "RINSE"
            Case 4
                Return "PRE-RINSE"
            Case 6
                Return "COOL DOWN"
            Case 7
                Return "DRAIN"
            Case 8
                Return "EXTRACTION"
            Case 15
                Return "END_WAIT"
        End Select



    End Function

    Function BinaryToComplement2(value As Short) As Short

        ' Se il bit più significativo è 1, il numero è negativo
        If value And &H8000 Then
            ' Inverti tutti i bit
            value = value Xor &HFFFF
            ' Aggiungi 1
            value += 1
            ' Moltiplica per -1 per ottenere il valore negativo
            value *= -1
        End If

        Return value
    End Function

#Region "Parse CMIS Commands"

    Private Sub parseCommand64()
        Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!! Unknown command")
    End Sub

    Private Sub parseCommand66()
        Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!! NAK ")
    End Sub
    Private Sub parseCommand40_01(list1 As List(Of Byte))
        Dim FG As Integer = list1(4)
        Dim IH As Integer = list1(5)
        Dim IL As Integer = list1(6)
        Dim C1 As Integer = list1(7)
        Dim C2 As Integer = list1(8)
        Dim C3 As Integer = list1(9)
        Dim C4 As Integer = list1(10)
        Dim BC As Integer = list1(11)
        Dim LH As Integer = list1(12)
        Dim LL As Integer = list1(13)
        Dim BC2 As Integer = list1(14)

        'Update data with collector bits for cs1
        If (BC And &H1) Then FG = FG Or &H80
        If (BC And &H2) Then IH = IH Or &H80
        If (BC And &H4) Then IL = IL Or &H80
        If (BC And &H8) Then C1 = C1 Or &H80
        If (BC And &H10) Then C2 = C2 Or &H80
        If (BC And &H20) Then C3 = C3 Or &H80
        If (BC And &H40) Then C4 = C4 Or &H80

        Dim programSlot = (IH << 8) + IL
        '' TextBox5.Text = programSlot.ToString()
        Dim textLen As Integer = (LH << 8) + LL
        Dim offset As Integer = 0
        Dim nextAvailableByte As Integer = 1
        Dim cbcounter = 0
        Dim str As String = ""
        Dim sb As New System.Text.StringBuilder()

        While textLen > 0
            If cbcounter < 7 Then
                sb.Append(Chr(list1(15 + cbcounter + offset)))
                cbcounter += 1
                textLen -= 1
            Else
                offset += 8
                cbcounter = 0
                nextAvailableByte += 1
            End If
        End While

        programName = sb.ToString().Split(vbNullChar)(0)
        If Not String.IsNullOrEmpty(programName) Then
            programNameCMISFound = True
            ProgramsTemperature = Regex.Match(programName, "\d+").Value
            gform.Label7.Text = $"Time to reach {ProgramsTemperature} is: "
            Dim timestampFolder As String = Now.ToString("yyyy_MM_dd")
            machineFolder = Path.Combine(ResultsFolderPath, MachineName)
            Dim timestampFile As String = Now.ToString("HHmmss")

            ''Directory.CreateDirectory(dateFolder)

            DirectoryPerWashProgram = Path.Combine(machineFolder, $"{programName}")
            Directory.CreateDirectory(DirectoryPerWashProgram)
        End If

    End Sub
#End Region


    ''' <summary>
    ''' Parse Status3 answer
    ''' </summary>
    ''' <param name="list1">Received Message buffer</param>
    Private Sub parseStatus3(list1 As List(Of Byte))

        Dim ST As Byte = list1(3)
        Dim AT As Byte = list1(4)
        Dim SW1 As Byte = list1(5)
        Dim SW2 As Byte = list1(6)
        Dim AW1 As Byte = list1(7)
        Dim AW2 As Byte = list1(8)
        Dim notUsed1 As Byte = list1(9)
        Dim xx As Byte = list1(10)

        'Update data with collectr bits
        If (xx And &H1) Then ST = ST Or &H80
        If (xx And &H2) Then AT = AT Or &H80
        If (xx And &H4) Then SW1 = SW1 Or &H80
        If (xx And &H8) Then SW2 = SW2 Or &H80
        If (xx And &H10) Then AW1 = AW1 Or &H80
        If (xx And &H20) Then AW2 = AW2 Or &H80
        If (xx And &H40) Then notUsed1 = notUsed1 Or &H80

        'Parse set temperature
        Dim SetTemperature As Short = ST
        Dim SetTemperatureC As Double = (SetTemperature - 32) * 5 / 9
        SET_TEMP.Text = SetTemperatureC.ToString("0.0")

        'Parse actual temperature
        Dim ActualTemperature As Short = AT
        Dim ActualTemperatureC As Double = (ActualTemperature - 32) * 5 / 9
        WATER_TEMP.Text = ActualTemperatureC.ToString("0.0")

        'Parse set water level
        Dim num As Short = SW2
        num = num << 8
        Dim SetWaterLevel As Integer = (num + SW1)
        SET_LEVEL.Text = SetWaterLevel.ToString()

        'Parse actual water level
        num = AW2
        num = num << 8
        Dim ActualWaterLevel As Integer = (num + AW1)
        WATER_LEVEL.Text = ActualWaterLevel.ToString()

    End Sub

    'Clear Log
    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        log_window_ad.Text = ""
    End Sub

    Delegate Sub DelegateToUpdateForm(ByVal data As Byte())
    Delegate Sub DelegateToUpdateStartStopButton(ByVal data As Boolean)


#Region "Ethernet communication"

    'Handle the message arrived from tcp thread
    Private Sub ReceivedMessageFormEthernet(ByVal data As Byte())

        'Call the parser in the current therad
        parseIncomingMessage(data.ToList())

        RX += 1
        RXCounter.Text = RX
        RequestTimer.Start()

    End Sub

    Private Sub updateStartStopButton(ByVal data As Boolean)
        If data Then
            Button8.Enabled = True
            Button8.Text = "START POLLING"
            Button36.Text = "Disconnect"
            RadioButton10.Enabled = False
            RadioButton11.Enabled = False
            ipAddress.BackColor = Color.LightGreen

        Else
            Button8.Enabled = False
            Button8.Text = "STOP POLLING"
            Button36.Text = "Connect"
            ipAddress.BackColor = Color.White
        End If
    End Sub


    'Select serial port communication
    Private Sub RadioButton10_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton10.CheckedChanged
        Dim TrasmissionOnSerialPort As Boolean = True
        Dim TrasmissionOnEthernetPort As Boolean = False
        Panel2.Visible = True
        Panel3.Visible = False
    End Sub


    Dim manualscan As Boolean = False
    Dim manualAddress As Integer = 1


    Private Sub log_window_ad_TextChanged(sender As Object, e As EventArgs) Handles log_window_ad.TextChanged
        log_window_ad.SelectionStart = log_window_ad.Text.Length
        'scroll it automatically
        log_window_ad.ScrollToCaret()
    End Sub



    'Select ethernet communication
    Private Sub RadioButton11_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton11.CheckedChanged
        Dim TrasmissionOnSerialPort As Boolean = False
        Dim TrasmissionOnEthernetPort As Boolean = True
        Panel3.Visible = True
        Panel2.Visible = False
    End Sub

#End Region

#Region "Change serial port speed"

    Dim serialSpeedChangeStatus As Integer = 0
    Dim testSerialPort As Boolean = False
    Dim noanswerRequest As Boolean = False
    Dim messageReceived As Boolean = False
    Dim serialportTested As Boolean = False


    Private Sub Button58_Click(sender As Object, e As EventArgs) Handles Button58.Click

    End Sub

    'Update the request list
    Private Sub x7_CheckedChanged(sender As Object, e As EventArgs)
        updateRequestList()


    End Sub


    Private Sub updateRequestList()

        Debug.WriteLine("List update")
        If Not requestList Is Nothing Then
            requestList.Clear()

            'Enquire message always present
            requestList.Add(offsetCMISProtocol + 7)

            'Check program name
            '' requestList.Add(offsetCMISProtocol + 1)


            'Firmware version request (GENERAL protocol)
            requestList.Add(offsetGeneralProtocol + 0)
            requestList.Add(offsetGeneralProtocol + 1)

            If F0.Checked Then requestList.Add(offsetDigitalOutput + 0)     'Cold to drum
            If F1.Checked Then requestList.Add(offsetDigitalOutput + 1)     'Hot to drum
            If F3.Checked Then requestList.Add(offsetDigitalOutput + 3)     'Drain
            If F4.Checked Then requestList.Add(offsetDigitalOutput + 74)    'Recirculation pump
            If F5.Checked Then requestList.Add(offsetDigitalOutput + 24)    'Flush valve
            If F9.Checked Then requestList.Add(offsetDigitalOutput + 9)     'Heater

            requestList.Add(offsetDrierIO + 0)   'Temperature
            requestList.Add(offsetDrierIO + 1)   'RMC

            If F17.Checked Then requestList.Add(offsetDigitalOutput + 17)   'COLD TO WASH
            If F85.Checked Then requestList.Add(offsetDigitalOutput + 85)   'HOT  TO WASH
            If F18.Checked Then requestList.Add(offsetDigitalOutput + 18)   'COLD TO PREWASH
            If F82.Checked Then requestList.Add(offsetDigitalOutput + 82)   'HOT  TO PREWASH
            If F19.Checked Then requestList.Add(offsetDigitalOutput + 19)   'COLD TO SOFTENER
            If F83.Checked Then requestList.Add(offsetDigitalOutput + 83)   'HOT  TO SOFTENER
            If F84.Checked Then requestList.Add(offsetDigitalOutput + 84)   'COLD TO BLEACH
            If F20.Checked Then requestList.Add(offsetDigitalOutput + 20)   'HOT TO BLEACH
            If F25.Checked Then requestList.Add(offsetDigitalOutput + 25)   'PUMP 1
            If F26.Checked Then requestList.Add(offsetDigitalOutput + 26)   'PUMP 2
            If F27.Checked Then requestList.Add(offsetDigitalOutput + 27)   'PUMP 3
            If F28.Checked Then requestList.Add(offsetDigitalOutput + 28)   'PUMP 4
            If F29.Checked Then requestList.Add(offsetDigitalOutput + 29)   'PUMP 5
            If F30.Checked Then requestList.Add(offsetDigitalOutput + 30)   'PUMP 6
            If F31.Checked Then requestList.Add(offsetDigitalOutput + 31)   'PUMP 7
            If F32.Checked Then requestList.Add(offsetDigitalOutput + 32)   'PUMP 8
            If F33.Checked Then requestList.Add(offsetDigitalOutput + 33)   'PUMP 9
            If F34.Checked Then requestList.Add(offsetDigitalOutput + 34)   'PUMP 10
            If F35.Checked Then requestList.Add(offsetDigitalOutput + 35)   'PUMP 11
            If F36.Checked Then requestList.Add(offsetDigitalOutput + 36)   'PUMP 12
            If F37.Checked Then requestList.Add(offsetDigitalOutput + 37)   'PUMP 13
            If F38.Checked Then requestList.Add(offsetDigitalOutput + 38)   'PUMP 14
            If F39.Checked Then requestList.Add(offsetDigitalOutput + 40)   'PUMP 15
            If F40.Checked Then requestList.Add(offsetDigitalOutput + 41)   'PUMP 16

            If x31.Checked Then requestList.Add(offsetCMISProtocol + 10)    'TEMPERATURE (note!! with this index will be used command 41_10)
            If x32.Checked Then requestList.Add(offsetCMISProtocol + 12)    'WATER LEVEL (note!! with this index will be used command 41_12)
            If x33.Checked Then requestList.Add(offsetCMISProtocol + 14)    'DRUM SPEED (note!! with this index will be used command 41_14)

            If x34.Checked Then requestList.Add(offsetDigitalInput + 3)     'DOOR CLOSED
            If x35.Checked Then requestList.Add(offsetDigitalInput + 4)     'DOOR LOCKED

            If x36.Checked Then requestList.Add(offsetAnalogInput + 2)      'Acc XY
            If x37.Checked Then requestList.Add(offsetAnalogInput + 3)      'Acc Z 
            If x38.Checked Then requestList.Add(offsetAnalogInput + 4)      'Acc 3
            If x39.Checked Then requestList.Add(offsetCMISProtocol + 3)     'Weight at start (note!! with this index will be used command 41_03)

            'List ready
        End If

    End Sub


    'Dim gform As Form2
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If gform Is Nothing OrElse gform.IsDisposed Then
            gform = New Form2()
        End If

        gform.Show()
        Timer1.Enabled = True

    End Sub



    Private Sub TimerTestSerialPort_Tick(sender As Object, e As EventArgs) Handles TimerTestSerialPort.Tick

        Select Case serialSpeedChangeStatus

            Case 0
                Debug.WriteLine("TestSpeed: Start test serial port speed, now testing..." & SerialPort1.BaudRate)
                'disable the test timer
                TimerTestSerialPort.Enabled = False

                'change speed of the serial port to 2400 and try to comunicate with 2400
                requestID = 0
                messageReceived = False

                'Prepare the receive buffer
                RXBufferReceived = New List(Of Byte)

                'Trasmission to serial port
                SERVICE_CMD_GET_OUTPUT_FUNCTION(0)
                SendTXBuffer_Serial(True)


            Case 1


                'Check if I reach already the max speed..
                If SerialPort1.BaudRate = maxspeed Then

                    'change speed of the serial port to 2400 and try to comunicate with 2400
                    Debug.WriteLine("TestSpeed: Max speed already set in the machine and in the serial port, comunication can start...")
                    requestID = 0
                    SerialPort1.BaudRate = maxspeed
                    running = False
                    serialSpeedChangeStatus = 0
                    testSerialPort = False
                    messageReceived = False
                    TimerTestSerialPort.Enabled = False
                    serialportTested = True

                    TX = 0
                    RX = 0
                    TXCounter.Text = "0"
                    RXCounter.Text = "0"

                    'Start the polling at max speed
                    StartStopCommand()

                Else

                    'received a message from serial port at 2400. Send the message to set serial port speed at max speed in the slave
                    Debug.WriteLine("TestSpeed: Message received at " & SerialPort1.BaudRate & " , ready to jump at " & maxspeed & "! Send messagage at 2400 to change speed at " & maxspeed)

                    'Send the command to update the baud in the machine
                    serialSpeedChangeStatus = 2
                    TimerTestSerialPort.Enabled = True
                    noanswerRequest = True

                    'Prepare the receive buffer
                    RXBufferReceived = New List(Of Byte)

                    GENERAL_CMD_SET_BAUDRATE(0)
                    SendTXBuffer_Serial(False)

                End If


            Case 2

                'change speed of the serial port to 2400 and try to comunicate with 2400
                Debug.WriteLine("TestSpeed: New speed at " & maxspeed & " is set in the machine, change speed and start comunication...")
                requestID = 0
                SerialPort1.BaudRate = maxspeed
                running = False
                serialSpeedChangeStatus = 0
                testSerialPort = False
                messageReceived = False
                TimerTestSerialPort.Enabled = False
                serialportTested = True

                TX = 0
                RX = 0
                TXCounter.Text = "0"
                RXCounter.Text = "0"

                'Start the polling at max speed
                StartStopCommand()

            Case Else

        End Select


    End Sub


#End Region

    'Event raised when we have new data in the buffer for the graph
    Public Event BufferAdded As Action(Of Double())

    'Event raised when the main form is closed
    Public Event MainFormClosed As Action(Of Int16)

    ''' <summary>
    ''' Funzione per aggiungere un buffer nella coda
    ''' </summary>
    ''' <param name="buffer"></param>
    Private Sub AddBufferToQueue(buffer As Double())
        If running Then
            ' Chiama l'evento per gestire la coda nel modulo del grafico
            RaiseEvent BufferAdded(buffer)
        End If
    End Sub


    Private Function isCBC_double(item As PictureBox, offset As Double) As Double
        If item.Tag = "1" Then
            Return offset
        End If
        Return 0


        'If item.Then Then
        '    Return offset
        'End If
        'Return 0
    End Function

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        RaiseEvent MainFormClosed(0)

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim min As Integer = 200

        'Hot to drum
        'Cold to drum
        'Hard water
        'Drain
        'Heater

        'COLD TO WASH
        'HOT  TO WASH
        'COLD TO PREWASH
        'HOT  TO PREWASH
        'COLD TO SOFTENER
        'HOT  TO PREWASH
        'COLD TO BLEACH
        'COLD TO BLEACH

        'PUMP 1
        'PUMP 2
        'PUMP 3
        'PUMP 4
        'PUMP 5
        'PUMP 6
        'PUMP 7
        'PUMP 8
        'PUMP 9
        'PUMP 10
        'PUMP 11
        'PUMP 12
        'PUMP 13
        'PUMP 14
        'PUMP 15
        'PUMP 16

        Dim dataArray As Double() = {
            isCBC_double(OUT0, min + 0),              '0 : Cold water to drum
            isCBC_double(OUT1, min + 1.5),            '1 : Hot water to drum
            isCBC_double(OUT3, min + 1.2),            '2 : Drain
            isCBC_double(OUT4, min + 5.3),            '3 : Recirculation pump
            isCBC_double(OUT9, min + 1.8),            '4 : heater
            isCBC_double(OUT17, min + 2.1),           '5 : Cold to wash 
            isCBC_double(OUT85, min + 2.4),           '6 : Hot to wash
            isCBC_double(OUT18, min + 2.7),           '7 : Cold to prewash
            isCBC_double(OUT82, min + 3.0),           '8 : Hot to prewash
            isCBC_double(OUT19, min + 3.3),           '9 : Cold to softener
            isCBC_double(OUT83, min + 3.6),           '10: Hot to softener
            isCBC_double(OUT84, min + 3.9),           '11: Cold to bleach
            isCBC_double(OUT20, min + 4.2),           '12: Hot to bleach
            isCBC_double(i4, min + 4.5),              '13: Door lock signal
            Convert.ToDouble(WATER_TEMP.Text),        '14: Water temperature
            Convert.ToDouble(SET_TEMP.Text),          '15: Water temperature setpoint
            Convert.ToDouble(WATER_LEVEL.Text),       '16: Water level
            Convert.ToDouble(SET_LEVEL.Text),         '17: Water level setpoint
            Convert.ToDouble(DRUM_SPEED.Text),        '18: drum speed
            Convert.ToDouble(SET_SPEED.Text),         '19: drum speed setpoint
            isCBC_double(OUT25, min + 6.8),           '20: Output pump 1
            isCBC_double(OUT26, min + 6.1),           '21: Output pump 2
            isCBC_double(OUT27, min + 6.4),           '22: Output pump 3
            isCBC_double(OUT28, min + 6.7),           '23: Output pump 4
            isCBC_double(OUT29, min + 7.0),           '24: Output pump 5
            isCBC_double(OUT30, min + 7.3),           '25: Output pump 6
            isCBC_double(OUT31, min + 7.6),           '26: Output pump 7
            isCBC_double(OUT5, min + 5.5),            '27: Flush valve
            Convert.ToDouble(ACC_XY.Text),            '28: Axis XY
            Convert.ToDouble(ACC_Z.Text),             '29: Axis Z
            Convert.ToDouble(ACC_3.Text),             '30: Axis 3
            Convert.ToDouble(Label13.Text),           '31: Module Index
            Convert.ToDouble(Label4.Text),             '32: Weight
            inTempC,
            outTempC,
            rmcValue
        }


        AddBufferToQueue(dataArray)

    End Sub










    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        manualCommand = True
        remoteserviceRequest = 1
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        manualCommand = True
        remoteserviceRequest = 4
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        manualCommand = True
        remoteserviceRequest = 8
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        manualCommand = True
        remoteserviceRequest = 9
    End Sub

    Private Sub PlotView1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label69_Click(sender As Object, e As EventArgs) Handles Label69.Click

    End Sub


    Private Sub TabControl4_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub rtbFtdiLog_TextChanged(sender As Object, e As EventArgs) Handles rtbFtdiLog.TextChanged
        rtbFtdiLog.SelectionStart = rtbFtdiLog.Text.Length
        rtbFtdiLog.ScrollToCaret()
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs)


    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs)

    End Sub

    Private Sub LabelFirmwareVersion_Click(sender As Object, e As EventArgs) Handles LabelFirmwareVersion.Click

    End Sub

    Private Sub RemainingTimeValue_Click(sender As Object, e As EventArgs) Handles RemainingTimeValue.Click

    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click

    End Sub

    Private Sub x34_CheckedChanged(sender As Object, e As EventArgs) Handles x34.CheckedChanged

    End Sub

    Private Sub i3_Click(sender As Object, e As EventArgs) Handles i3.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToggleButton1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ActiveGraph_CheckedChanged(sender As Object, e As EventArgs) Handles ActiveGraph.CheckedChanged

    End Sub

    Private Sub Label70_Click(sender As Object, e As EventArgs) Handles Label70.Click

    End Sub

    Private Sub Label66_Click(sender As Object, e As EventArgs) Handles Label66.Click

    End Sub

    Private Sub OUT26_Click(sender As Object, e As EventArgs) Handles OUT26.Click

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub OUT84_Click(sender As Object, e As EventArgs) Handles OUT84.Click

    End Sub

    Private Sub Label94_Click(sender As Object, e As EventArgs) Handles Label94.Click

    End Sub

    Private Sub F0_CheckedChanged(sender As Object, e As EventArgs) Handles F0.CheckedChanged

    End Sub

    Private Sub OUT0_Click(sender As Object, e As EventArgs) Handles OUT0.Click

    End Sub

    Private Sub CheckBoxDrier_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDrier.CheckedChanged

    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles OUT12.Click

    End Sub

    Dim timeToNotify As Integer = 0

End Class

