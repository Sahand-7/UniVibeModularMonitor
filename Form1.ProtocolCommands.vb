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

End Class
