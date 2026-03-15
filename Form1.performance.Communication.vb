Imports System.IO
Imports System.IO.Ports
Imports System.Management
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Timers
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Imports OxyPlot.WindowsForms
Partial Public Class Form1
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

    Private Sub AppendLogTextCore(textLog As String, textColor As Color, Optional highlightsColor As Color? = Nothing)
        If log_window_ad.IsDisposed Then Return

        If log_window_ad.InvokeRequired Then
            log_window_ad.BeginInvoke(New Action(Of String, Color, Color?)(AddressOf AppendLogTextCore), textLog, textColor, highlightsColor)
            Return
        End If

        log_window_ad.SuspendLayout()
        log_window_ad.Select(log_window_ad.TextLength, 0)
        log_window_ad.SelectionColor = textColor

        If highlightsColor.HasValue Then
            log_window_ad.SelectionBackColor = highlightsColor.Value
        End If

        log_window_ad.AppendText(vbNewLine & textLog)

        If highlightsColor.HasValue Then
            log_window_ad.SelectionBackColor = log_window_ad.BackColor
        End If

        TrimLogWindowIfNeeded()
        log_window_ad.ResumeLayout()
    End Sub

    Private Sub TrimLogWindowIfNeeded()
        Const maxLogLines As Integer = 5000
        Const targetLogLines As Integer = 4000

        If log_window_ad.Lines.Length <= maxLogLines Then Return

        Dim linesToKeep = log_window_ad.Lines.Skip(Math.Max(0, log_window_ad.Lines.Length - targetLogLines)).ToArray()
        log_window_ad.Lines = linesToKeep
        log_window_ad.SelectionStart = log_window_ad.TextLength
    End Sub

    ''' <summary>
    ''' Function to add a text to the log text viewer
    ''' </summary>
    ''' <param name="textLog">Text to append to the log</param>
    Private Sub append_log_text(textLog As String)
        AppendLogTextCore(textLog, Color.Black)
    End Sub

    Private Sub append_log_text(textLog As String, textColor As Color)
        AppendLogTextCore(textLog, textColor)
    End Sub

    Private Sub append_log_text(textLog As String, textColor As Color, highlightsColor As Color)
        AppendLogTextCore(textLog, textColor, highlightsColor)
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

End Class
