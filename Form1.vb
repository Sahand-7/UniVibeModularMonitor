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
