<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.RXCounter = New System.Windows.Forms.Label()
        Me.TXCounter = New System.Windows.Forms.Label()
        Me.flagRX = New System.Windows.Forms.Label()
        Me.flagTX = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ipAddress = New System.Windows.Forms.TextBox()
        Me.Button36 = New System.Windows.Forms.Button()
        Me.Label163 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ActiveGraph = New System.Windows.Forms.CheckBox()
        Me.cmb_speed = New System.Windows.Forms.ComboBox()
        Me.ser1 = New System.Windows.Forms.PictureBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmb_serialPort = New System.Windows.Forms.ComboBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button58 = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.RequestTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TimeoutTimer = New System.Windows.Forms.Timer(Me.components)
        Me.msgsec = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.timeout_counter = New System.Windows.Forms.Label()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.GroupBox30 = New System.Windows.Forms.GroupBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.RadioButton11 = New System.Windows.Forms.RadioButton()
        Me.RadioButton10 = New System.Windows.Forms.RadioButton()
        Me.Label162 = New System.Windows.Forms.Label()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTime = New System.Windows.Forms.NumericUpDown()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.log_window_ad = New System.Windows.Forms.RichTextBox()
        Me.Button35 = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.RemainingTimeValue = New System.Windows.Forms.Label()
        Me.RemainingTime = New System.Windows.Forms.Label()
        Me.LabelFirmwareVersion = New System.Windows.Forms.Label()
        Me.LabelFirmwareTitle = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.x38 = New System.Windows.Forms.CheckBox()
        Me.ACC_3 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.x37 = New System.Windows.Forms.CheckBox()
        Me.ACC_Z = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.x36 = New System.Windows.Forms.CheckBox()
        Me.ACC_XY = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.funcNum = New System.Windows.Forms.NumericUpDown()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.x39 = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.x33 = New System.Windows.Forms.CheckBox()
        Me.x32 = New System.Windows.Forms.CheckBox()
        Me.x31 = New System.Windows.Forms.CheckBox()
        Me.SET_SPEED = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DRUM_SPEED = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SET_LEVEL = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.WATER_LEVEL = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.SET_TEMP = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.WATER_TEMP = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.x35 = New System.Windows.Forms.CheckBox()
        Me.x34 = New System.Windows.Forms.CheckBox()
        Me.i4 = New System.Windows.Forms.PictureBox()
        Me.i3 = New System.Windows.Forms.PictureBox()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.F20 = New System.Windows.Forms.CheckBox()
        Me.OUT20 = New System.Windows.Forms.PictureBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.F40 = New System.Windows.Forms.CheckBox()
        Me.F32 = New System.Windows.Forms.CheckBox()
        Me.F39 = New System.Windows.Forms.CheckBox()
        Me.F38 = New System.Windows.Forms.CheckBox()
        Me.F37 = New System.Windows.Forms.CheckBox()
        Me.F36 = New System.Windows.Forms.CheckBox()
        Me.F35 = New System.Windows.Forms.CheckBox()
        Me.F34 = New System.Windows.Forms.CheckBox()
        Me.F33 = New System.Windows.Forms.CheckBox()
        Me.F31 = New System.Windows.Forms.CheckBox()
        Me.F30 = New System.Windows.Forms.CheckBox()
        Me.F29 = New System.Windows.Forms.CheckBox()
        Me.F28 = New System.Windows.Forms.CheckBox()
        Me.F27 = New System.Windows.Forms.CheckBox()
        Me.F26 = New System.Windows.Forms.CheckBox()
        Me.F25 = New System.Windows.Forms.CheckBox()
        Me.F9 = New System.Windows.Forms.CheckBox()
        Me.x6 = New System.Windows.Forms.CheckBox()
        Me.F5 = New System.Windows.Forms.CheckBox()
        Me.F4 = New System.Windows.Forms.CheckBox()
        Me.F3 = New System.Windows.Forms.CheckBox()
        Me.F1 = New System.Windows.Forms.CheckBox()
        Me.F0 = New System.Windows.Forms.CheckBox()
        Me.F84 = New System.Windows.Forms.CheckBox()
        Me.F83 = New System.Windows.Forms.CheckBox()
        Me.F19 = New System.Windows.Forms.CheckBox()
        Me.F82 = New System.Windows.Forms.CheckBox()
        Me.F18 = New System.Windows.Forms.CheckBox()
        Me.F85 = New System.Windows.Forms.CheckBox()
        Me.F17 = New System.Windows.Forms.CheckBox()
        Me.OUT40 = New System.Windows.Forms.PictureBox()
        Me.OUT39 = New System.Windows.Forms.PictureBox()
        Me.OUT38 = New System.Windows.Forms.PictureBox()
        Me.OUT37 = New System.Windows.Forms.PictureBox()
        Me.OUT36 = New System.Windows.Forms.PictureBox()
        Me.OUT35 = New System.Windows.Forms.PictureBox()
        Me.OUT34 = New System.Windows.Forms.PictureBox()
        Me.OUT33 = New System.Windows.Forms.PictureBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.OUT32 = New System.Windows.Forms.PictureBox()
        Me.OUT31 = New System.Windows.Forms.PictureBox()
        Me.OUT30 = New System.Windows.Forms.PictureBox()
        Me.OUT29 = New System.Windows.Forms.PictureBox()
        Me.OUT28 = New System.Windows.Forms.PictureBox()
        Me.OUT27 = New System.Windows.Forms.PictureBox()
        Me.OUT26 = New System.Windows.Forms.PictureBox()
        Me.OUT25 = New System.Windows.Forms.PictureBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.OUT84 = New System.Windows.Forms.PictureBox()
        Me.OUT83 = New System.Windows.Forms.PictureBox()
        Me.OUT19 = New System.Windows.Forms.PictureBox()
        Me.OUT82 = New System.Windows.Forms.PictureBox()
        Me.OUT18 = New System.Windows.Forms.PictureBox()
        Me.OUT85 = New System.Windows.Forms.PictureBox()
        Me.OUT17 = New System.Windows.Forms.PictureBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.OUT9 = New System.Windows.Forms.PictureBox()
        Me.o3 = New System.Windows.Forms.PictureBox()
        Me.OUT5 = New System.Windows.Forms.PictureBox()
        Me.OUT4 = New System.Windows.Forms.PictureBox()
        Me.OUT3 = New System.Windows.Forms.PictureBox()
        Me.OUT1 = New System.Windows.Forms.PictureBox()
        Me.OUT0 = New System.Windows.Forms.PictureBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.activationTime = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.button14 = New System.Windows.Forms.Button()
        Me.quantityml = New System.Windows.Forms.TextBox()
        Me.pumpflowrate = New System.Windows.Forms.TextBox()
        Me.kgvalue = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.label95 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.rpm = New System.Windows.Forms.TextBox()
        Me.gforce = New System.Windows.Forms.TextBox()
        Me.diameter = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.label87 = New System.Windows.Forms.Label()
        Me.TabLogsFTDI = New System.Windows.Forms.TabPage()
        Me.rtbFtdiLog = New System.Windows.Forms.RichTextBox()
        Me.TimerTestSerialPort = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TimerAlert = New System.Windows.Forms.Timer(Me.components)
        Me.logftdi_window_new = New System.Windows.Forms.TabPage()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.CheckBoxDrier = New System.Windows.Forms.CheckBox()
        Me.OUT12 = New System.Windows.Forms.PictureBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ser1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage9.SuspendLayout()
        Me.GroupBox30.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage8.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.funcNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.i4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.i3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.OUT20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT84, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT83, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT82, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT85, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.o3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OUT0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.TabLogsFTDI.SuspendLayout()
        Me.logftdi_window_new.SuspendLayout()
        CType(Me.OUT12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RXCounter
        '
        Me.RXCounter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RXCounter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RXCounter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RXCounter.Location = New System.Drawing.Point(362, 631)
        Me.RXCounter.Name = "RXCounter"
        Me.RXCounter.Size = New System.Drawing.Size(62, 15)
        Me.RXCounter.TabIndex = 16
        Me.RXCounter.Text = "0"
        Me.RXCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TXCounter
        '
        Me.TXCounter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TXCounter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TXCounter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXCounter.Location = New System.Drawing.Point(147, 631)
        Me.TXCounter.Name = "TXCounter"
        Me.TXCounter.Size = New System.Drawing.Size(62, 15)
        Me.TXCounter.TabIndex = 15
        Me.TXCounter.Text = "0"
        Me.TXCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'flagRX
        '
        Me.flagRX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.flagRX.BackColor = System.Drawing.Color.PaleGreen
        Me.flagRX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.flagRX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.flagRX.Location = New System.Drawing.Point(215, 631)
        Me.flagRX.Name = "flagRX"
        Me.flagRX.Size = New System.Drawing.Size(141, 15)
        Me.flagRX.TabIndex = 14
        Me.flagRX.Text = "RECEPTIONS"
        Me.flagRX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'flagTX
        '
        Me.flagTX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.flagTX.BackColor = System.Drawing.Color.PaleGreen
        Me.flagTX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.flagTX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.flagTX.Location = New System.Drawing.Point(0, 631)
        Me.flagTX.Name = "flagTX"
        Me.flagTX.Size = New System.Drawing.Size(140, 15)
        Me.flagTX.TabIndex = 13
        Me.flagTX.Text = "TRASMISSIONS"
        Me.flagTX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox1.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(923, 68)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ipAddress)
        Me.Panel3.Controls.Add(Me.Button36)
        Me.Panel3.Controls.Add(Me.Label163)
        Me.Panel3.Location = New System.Drawing.Point(6, 69)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(481, 37)
        Me.Panel3.TabIndex = 114
        '
        'ipAddress
        '
        Me.ipAddress.Location = New System.Drawing.Point(84, 9)
        Me.ipAddress.Name = "ipAddress"
        Me.ipAddress.Size = New System.Drawing.Size(165, 20)
        Me.ipAddress.TabIndex = 113
        Me.ipAddress.Text = "192.168.0.89"
        Me.ipAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button36
        '
        Me.Button36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button36.ForeColor = System.Drawing.Color.Black
        Me.Button36.Location = New System.Drawing.Point(274, 5)
        Me.Button36.Name = "Button36"
        Me.Button36.Size = New System.Drawing.Size(170, 26)
        Me.Button36.TabIndex = 112
        Me.Button36.Text = "Connect"
        Me.Button36.UseVisualStyleBackColor = True
        '
        'Label163
        '
        Me.Label163.BackColor = System.Drawing.Color.Transparent
        Me.Label163.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label163.ForeColor = System.Drawing.Color.Black
        Me.Label163.Location = New System.Drawing.Point(19, 5)
        Me.Label163.Name = "Label163"
        Me.Label163.Size = New System.Drawing.Size(78, 26)
        Me.Label163.TabIndex = 114
        Me.Label163.Text = "IPAddress"
        Me.Label163.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ActiveGraph)
        Me.Panel2.Controls.Add(Me.cmb_speed)
        Me.Panel2.Controls.Add(Me.ser1)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.cmb_serialPort)
        Me.Panel2.Location = New System.Drawing.Point(8, 15)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(494, 40)
        Me.Panel2.TabIndex = 99
        '
        'ActiveGraph
        '
        Me.ActiveGraph.AutoSize = True
        Me.ActiveGraph.Checked = True
        Me.ActiveGraph.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ActiveGraph.Location = New System.Drawing.Point(320, 13)
        Me.ActiveGraph.Name = "ActiveGraph"
        Me.ActiveGraph.Size = New System.Drawing.Size(146, 17)
        Me.ActiveGraph.TabIndex = 55
        Me.ActiveGraph.Text = "Save Previous Graph"
        Me.ActiveGraph.UseVisualStyleBackColor = True
        '
        'cmb_speed
        '
        Me.cmb_speed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_speed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_speed.ForeColor = System.Drawing.Color.Black
        Me.cmb_speed.FormattingEnabled = True
        Me.cmb_speed.Items.AddRange(New Object() {"2400", "9600", "19200", "38400", "115200", "230400"})
        Me.cmb_speed.Location = New System.Drawing.Point(221, 10)
        Me.cmb_speed.Name = "cmb_speed"
        Me.cmb_speed.Size = New System.Drawing.Size(77, 21)
        Me.cmb_speed.TabIndex = 54
        Me.cmb_speed.Visible = False
        '
        'ser1
        '
        Me.ser1.Image = Global.UnivibeMonitor.My.Resources.Resources.RedCross
        Me.ser1.Location = New System.Drawing.Point(178, 10)
        Me.ser1.Name = "ser1"
        Me.ser1.Size = New System.Drawing.Size(22, 22)
        Me.ser1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ser1.TabIndex = 53
        Me.ser1.TabStop = False
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Location = New System.Drawing.Point(111, 8)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(61, 26)
        Me.Button4.TabIndex = 52
        Me.Button4.Text = "Refresh"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'cmb_serialPort
        '
        Me.cmb_serialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_serialPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_serialPort.ForeColor = System.Drawing.Color.Black
        Me.cmb_serialPort.FormattingEnabled = True
        Me.cmb_serialPort.Location = New System.Drawing.Point(10, 9)
        Me.cmb_serialPort.Name = "cmb_serialPort"
        Me.cmb_serialPort.Size = New System.Drawing.Size(95, 21)
        Me.cmb_serialPort.TabIndex = 50
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.White
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(508, 18)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(201, 37)
        Me.Button8.TabIndex = 98
        Me.Button8.Text = "START"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(720, 18)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(187, 37)
        Me.Button3.TabIndex = 139
        Me.Button3.Text = "GRAPH"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button58
        '
        Me.Button58.BackColor = System.Drawing.Color.White
        Me.Button58.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button58.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button58.Location = New System.Drawing.Point(763, 402)
        Me.Button58.Name = "Button58"
        Me.Button58.Size = New System.Drawing.Size(118, 37)
        Me.Button58.TabIndex = 115
        Me.Button58.Text = "SCAN NETWORK"
        Me.Button58.UseVisualStyleBackColor = False
        Me.Button58.Visible = False
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 2400
        '
        'RequestTimer
        '
        Me.RequestTimer.Interval = 1
        '
        'TimeoutTimer
        '
        Me.TimeoutTimer.Interval = 400
        '
        'msgsec
        '
        Me.msgsec.Enabled = True
        Me.msgsec.Interval = 1000
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(578, 631)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 15)
        Me.Label3.TabIndex = 110
        Me.Label3.Text = "0"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.PaleGreen
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(430, 631)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 15)
        Me.Label5.TabIndex = 111
        Me.Label5.Text = "CHKSUM ERROR"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.PaleGreen
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(646, 631)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 15)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "TIMEOUT"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'timeout_counter
        '
        Me.timeout_counter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.timeout_counter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.timeout_counter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.timeout_counter.ForeColor = System.Drawing.Color.Red
        Me.timeout_counter.Location = New System.Drawing.Point(794, 631)
        Me.timeout_counter.Name = "timeout_counter"
        Me.timeout_counter.Size = New System.Drawing.Size(62, 15)
        Me.timeout_counter.TabIndex = 112
        Me.timeout_counter.Text = "0"
        Me.timeout_counter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.GroupBox30)
        Me.TabPage9.ForeColor = System.Drawing.Color.Blue
        Me.TabPage9.Location = New System.Drawing.Point(4, 22)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage9.Size = New System.Drawing.Size(921, 455)
        Me.TabPage9.TabIndex = 7
        Me.TabPage9.Text = "Settings"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'GroupBox30
        '
        Me.GroupBox30.Controls.Add(Me.CheckBox3)
        Me.GroupBox30.Controls.Add(Me.RadioButton11)
        Me.GroupBox30.Controls.Add(Me.RadioButton10)
        Me.GroupBox30.Controls.Add(Me.Label162)
        Me.GroupBox30.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox30.Controls.Add(Me.Label7)
        Me.GroupBox30.Controls.Add(Me.TXTime)
        Me.GroupBox30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox30.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox30.Location = New System.Drawing.Point(27, 26)
        Me.GroupBox30.Name = "GroupBox30"
        Me.GroupBox30.Size = New System.Drawing.Size(335, 260)
        Me.GroupBox30.TabIndex = 111
        Me.GroupBox30.TabStop = False
        Me.GroupBox30.Text = "Communication and Machine settings"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox3.ForeColor = System.Drawing.Color.Black
        Me.CheckBox3.Location = New System.Drawing.Point(26, 222)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(168, 17)
        Me.CheckBox3.TabIndex = 112
        Me.CheckBox3.Text = "Don't reset price changed flag"
        Me.CheckBox3.UseVisualStyleBackColor = True
        Me.CheckBox3.Visible = False
        '
        'RadioButton11
        '
        Me.RadioButton11.AutoSize = True
        Me.RadioButton11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton11.ForeColor = System.Drawing.Color.Black
        Me.RadioButton11.Location = New System.Drawing.Point(26, 207)
        Me.RadioButton11.Name = "RadioButton11"
        Me.RadioButton11.Size = New System.Drawing.Size(161, 17)
        Me.RadioButton11.TabIndex = 112
        Me.RadioButton11.Text = "Use Ethernet communication"
        Me.RadioButton11.UseVisualStyleBackColor = True
        Me.RadioButton11.Visible = False
        '
        'RadioButton10
        '
        Me.RadioButton10.AutoSize = True
        Me.RadioButton10.Checked = True
        Me.RadioButton10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton10.ForeColor = System.Drawing.Color.Black
        Me.RadioButton10.Location = New System.Drawing.Point(26, 171)
        Me.RadioButton10.Name = "RadioButton10"
        Me.RadioButton10.Size = New System.Drawing.Size(166, 17)
        Me.RadioButton10.TabIndex = 111
        Me.RadioButton10.TabStop = True
        Me.RadioButton10.Text = "Use serial port communication"
        Me.RadioButton10.UseVisualStyleBackColor = True
        Me.RadioButton10.Visible = False
        '
        'Label162
        '
        Me.Label162.BackColor = System.Drawing.Color.Transparent
        Me.Label162.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label162.ForeColor = System.Drawing.Color.Black
        Me.Label162.Location = New System.Drawing.Point(32, 78)
        Me.Label162.Name = "Label162"
        Me.Label162.Size = New System.Drawing.Size(183, 26)
        Me.Label162.TabIndex = 110
        Me.Label162.Text = "Machine address"
        Me.Label162.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.UnivibeMonitor.My.MySettings.Default, "MachineAddress", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NumericUpDown2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown2.ForeColor = System.Drawing.Color.Black
        Me.NumericUpDown2.Location = New System.Drawing.Point(221, 83)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(56, 20)
        Me.NumericUpDown2.TabIndex = 109
        Me.NumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown2.Value = Global.UnivibeMonitor.My.MySettings.Default.MachineAddress
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(32, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(183, 26)
        Me.Label7.TabIndex = 108
        Me.Label7.Text = "Trasmission polling speed (mS)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXTime
        '
        Me.TXTime.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.UnivibeMonitor.My.MySettings.Default, "PolllingSpeed", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TXTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTime.ForeColor = System.Drawing.Color.Black
        Me.TXTime.Location = New System.Drawing.Point(221, 57)
        Me.TXTime.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.TXTime.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TXTime.Name = "TXTime"
        Me.TXTime.Size = New System.Drawing.Size(56, 20)
        Me.TXTime.TabIndex = 107
        Me.TXTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTime.Value = Global.UnivibeMonitor.My.MySettings.Default.PolllingSpeed
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.log_window_ad)
        Me.TabPage8.Controls.Add(Me.Button35)
        Me.TabPage8.ForeColor = System.Drawing.Color.Blue
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(921, 455)
        Me.TabPage8.TabIndex = 6
        Me.TabPage8.Text = "Log"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'log_window_ad
        '
        Me.log_window_ad.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.log_window_ad.DetectUrls = False
        Me.log_window_ad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.log_window_ad.Font = New System.Drawing.Font("Courier New", 13.0!)
        Me.log_window_ad.Location = New System.Drawing.Point(3, 3)
        Me.log_window_ad.Name = "log_window_ad"
        Me.log_window_ad.ReadOnly = True
        Me.log_window_ad.Size = New System.Drawing.Size(915, 449)
        Me.log_window_ad.TabIndex = 2
        Me.log_window_ad.Text = ""
        Me.log_window_ad.WordWrap = False
        '
        'Button35
        '
        Me.Button35.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button35.Location = New System.Drawing.Point(6, 641)
        Me.Button35.Name = "Button35"
        Me.Button35.Size = New System.Drawing.Size(125, 23)
        Me.Button35.TabIndex = 1
        Me.Button35.Text = "Clear log"
        Me.Button35.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.RemainingTimeValue)
        Me.TabPage1.Controls.Add(Me.RemainingTime)
        Me.TabPage1.Controls.Add(Me.LabelFirmwareVersion)
        Me.TabPage1.Controls.Add(Me.LabelFirmwareTitle)
        Me.TabPage1.Controls.Add(Me.Button58)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.funcNum)
        Me.TabPage1.Controls.Add(Me.Button10)
        Me.TabPage1.Controls.Add(Me.Button9)
        Me.TabPage1.Controls.Add(Me.Button7)
        Me.TabPage1.Controls.Add(Me.NumericUpDown1)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.ForeColor = System.Drawing.Color.Blue
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(946, 505)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Monitor data"
        '
        'RemainingTimeValue
        '
        Me.RemainingTimeValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RemainingTimeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RemainingTimeValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemainingTimeValue.ForeColor = System.Drawing.Color.Black
        Me.RemainingTimeValue.Location = New System.Drawing.Point(694, 427)
        Me.RemainingTimeValue.Name = "RemainingTimeValue"
        Me.RemainingTimeValue.Size = New System.Drawing.Size(67, 18)
        Me.RemainingTimeValue.TabIndex = 192
        Me.RemainingTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RemainingTime
        '
        Me.RemainingTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RemainingTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemainingTime.ForeColor = System.Drawing.Color.Black
        Me.RemainingTime.Location = New System.Drawing.Point(591, 427)
        Me.RemainingTime.Name = "RemainingTime"
        Me.RemainingTime.Size = New System.Drawing.Size(97, 18)
        Me.RemainingTime.TabIndex = 191
        Me.RemainingTime.Text = "Remaining Time"
        '
        'LabelFirmwareVersion
        '
        Me.LabelFirmwareVersion.AutoSize = True
        Me.LabelFirmwareVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFirmwareVersion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelFirmwareVersion.Location = New System.Drawing.Point(372, 377)
        Me.LabelFirmwareVersion.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelFirmwareVersion.Name = "LabelFirmwareVersion"
        Me.LabelFirmwareVersion.Size = New System.Drawing.Size(14, 13)
        Me.LabelFirmwareVersion.TabIndex = 149
        Me.LabelFirmwareVersion.Text = "_"
        '
        'LabelFirmwareTitle
        '
        Me.LabelFirmwareTitle.AutoSize = True
        Me.LabelFirmwareTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFirmwareTitle.Location = New System.Drawing.Point(260, 377)
        Me.LabelFirmwareTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelFirmwareTitle.Name = "LabelFirmwareTitle"
        Me.LabelFirmwareTitle.Size = New System.Drawing.Size(107, 13)
        Me.LabelFirmwareTitle.TabIndex = 148
        Me.LabelFirmwareTitle.Text = "Firmware Version:"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.White
        Me.GroupBox5.Controls.Add(Me.x38)
        Me.GroupBox5.Controls.Add(Me.ACC_3)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.x37)
        Me.GroupBox5.Controls.Add(Me.ACC_Z)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.x36)
        Me.GroupBox5.Controls.Add(Me.ACC_XY)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox5.Location = New System.Drawing.Point(6, 299)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(243, 105)
        Me.GroupBox5.TabIndex = 147
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Accelerometer"
        '
        'x38
        '
        Me.x38.AutoSize = True
        Me.x38.Checked = True
        Me.x38.CheckState = System.Windows.Forms.CheckState.Checked
        Me.x38.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_38", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.x38.Location = New System.Drawing.Point(10, 73)
        Me.x38.Name = "x38"
        Me.x38.Size = New System.Drawing.Size(15, 14)
        Me.x38.TabIndex = 234
        Me.x38.UseVisualStyleBackColor = True
        '
        'ACC_3
        '
        Me.ACC_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ACC_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ACC_3.ForeColor = System.Drawing.Color.Black
        Me.ACC_3.Location = New System.Drawing.Point(147, 73)
        Me.ACC_3.Name = "ACC_3"
        Me.ACC_3.Size = New System.Drawing.Size(37, 18)
        Me.ACC_3.TabIndex = 233
        Me.ACC_3.Text = "0"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(36, 73)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 18)
        Me.Label15.TabIndex = 232
        Me.Label15.Text = "Acc 3 Axis"
        '
        'x37
        '
        Me.x37.AutoSize = True
        Me.x37.Checked = True
        Me.x37.CheckState = System.Windows.Forms.CheckState.Checked
        Me.x37.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_37", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.x37.Location = New System.Drawing.Point(10, 49)
        Me.x37.Name = "x37"
        Me.x37.Size = New System.Drawing.Size(15, 14)
        Me.x37.TabIndex = 231
        Me.x37.UseVisualStyleBackColor = True
        '
        'ACC_Z
        '
        Me.ACC_Z.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ACC_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ACC_Z.ForeColor = System.Drawing.Color.Black
        Me.ACC_Z.Location = New System.Drawing.Point(147, 49)
        Me.ACC_Z.Name = "ACC_Z"
        Me.ACC_Z.Size = New System.Drawing.Size(37, 18)
        Me.ACC_Z.TabIndex = 230
        Me.ACC_Z.Text = "0"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(36, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 18)
        Me.Label11.TabIndex = 229
        Me.Label11.Text = "Acc Z Axis"
        '
        'x36
        '
        Me.x36.AutoSize = True
        Me.x36.Checked = True
        Me.x36.CheckState = System.Windows.Forms.CheckState.Checked
        Me.x36.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_36", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.x36.Location = New System.Drawing.Point(10, 25)
        Me.x36.Name = "x36"
        Me.x36.Size = New System.Drawing.Size(15, 14)
        Me.x36.TabIndex = 228
        Me.x36.UseVisualStyleBackColor = True
        '
        'ACC_XY
        '
        Me.ACC_XY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ACC_XY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ACC_XY.ForeColor = System.Drawing.Color.Black
        Me.ACC_XY.Location = New System.Drawing.Point(147, 25)
        Me.ACC_XY.Name = "ACC_XY"
        Me.ACC_XY.Size = New System.Drawing.Size(37, 18)
        Me.ACC_XY.TabIndex = 227
        Me.ACC_XY.Text = "0"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(36, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 18)
        Me.Label6.TabIndex = 226
        Me.Label6.Text = "Acc XY Axis"
        '
        'funcNum
        '
        Me.funcNum.Location = New System.Drawing.Point(695, 419)
        Me.funcNum.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.funcNum.Name = "funcNum"
        Me.funcNum.Size = New System.Drawing.Size(36, 20)
        Me.funcNum.TabIndex = 146
        Me.funcNum.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.funcNum.Visible = False
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(218, 416)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(124, 23)
        Me.Button10.TabIndex = 145
        Me.Button10.Text = "Get IOBoard add 2"
        Me.Button10.UseVisualStyleBackColor = True
        Me.Button10.Visible = False
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(361, 416)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(124, 23)
        Me.Button9.TabIndex = 144
        Me.Button9.Text = "Get article number"
        Me.Button9.UseVisualStyleBackColor = True
        Me.Button9.Visible = False
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(75, 416)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(124, 23)
        Me.Button7.TabIndex = 143
        Me.Button7.Text = "Get Regret Time"
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(647, 419)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(41, 20)
        Me.NumericUpDown1.TabIndex = 142
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Visible = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(504, 416)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(124, 23)
        Me.Button6.TabIndex = 141
        Me.Button6.Text = "Set Regret Time"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.x39)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.x33)
        Me.GroupBox2.Controls.Add(Me.x32)
        Me.GroupBox2.Controls.Add(Me.x31)
        Me.GroupBox2.Controls.Add(Me.SET_SPEED)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.DRUM_SPEED)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.SET_LEVEL)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.WATER_LEVEL)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.SET_TEMP)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.WATER_TEMP)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox2.Location = New System.Drawing.Point(263, 217)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(495, 145)
        Me.GroupBox2.TabIndex = 138
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Analog Input"
        '
        'Label21
        '
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(363, 100)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(84, 18)
        Me.Label21.TabIndex = 231
        Me.Label21.Text = "-"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'x39
        '
        Me.x39.AutoSize = True
        Me.x39.Checked = True
        Me.x39.CheckState = System.Windows.Forms.CheckState.Checked
        Me.x39.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_39", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.x39.Location = New System.Drawing.Point(11, 101)
        Me.x39.Name = "x39"
        Me.x39.Size = New System.Drawing.Size(15, 14)
        Me.x39.TabIndex = 228
        Me.x39.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(148, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 18)
        Me.Label4.TabIndex = 227
        Me.Label4.Text = "0"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(37, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 18)
        Me.Label9.TabIndex = 226
        Me.Label9.Text = "Weight (at start)"
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(321, 100)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 18)
        Me.Label13.TabIndex = 230
        Me.Label13.Text = "0"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(244, 101)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 18)
        Me.Label18.TabIndex = 229
        Me.Label18.Text = "Module Index"
        '
        'x33
        '
        Me.x33.AutoSize = True
        Me.x33.Checked = True
        Me.x33.CheckState = System.Windows.Forms.CheckState.Checked
        Me.x33.Location = New System.Drawing.Point(11, 76)
        Me.x33.Name = "x33"
        Me.x33.Size = New System.Drawing.Size(15, 14)
        Me.x33.TabIndex = 225
        Me.x33.UseVisualStyleBackColor = True
        '
        'x32
        '
        Me.x32.AutoSize = True
        Me.x32.Checked = True
        Me.x32.CheckState = System.Windows.Forms.CheckState.Checked
        Me.x32.Location = New System.Drawing.Point(11, 52)
        Me.x32.Name = "x32"
        Me.x32.Size = New System.Drawing.Size(15, 14)
        Me.x32.TabIndex = 224
        Me.x32.UseVisualStyleBackColor = True
        '
        'x31
        '
        Me.x31.AutoSize = True
        Me.x31.Checked = True
        Me.x31.CheckState = System.Windows.Forms.CheckState.Checked
        Me.x31.Location = New System.Drawing.Point(11, 29)
        Me.x31.Name = "x31"
        Me.x31.Size = New System.Drawing.Size(15, 14)
        Me.x31.TabIndex = 220
        Me.x31.UseVisualStyleBackColor = True
        '
        'SET_SPEED
        '
        Me.SET_SPEED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SET_SPEED.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SET_SPEED.ForeColor = System.Drawing.Color.Black
        Me.SET_SPEED.Location = New System.Drawing.Point(410, 75)
        Me.SET_SPEED.Name = "SET_SPEED"
        Me.SET_SPEED.Size = New System.Drawing.Size(37, 18)
        Me.SET_SPEED.TabIndex = 176
        Me.SET_SPEED.Text = "0"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(246, 75)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(139, 18)
        Me.Label14.TabIndex = 175
        Me.Label14.Text = "Drum speed setpoint"
        '
        'DRUM_SPEED
        '
        Me.DRUM_SPEED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DRUM_SPEED.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DRUM_SPEED.ForeColor = System.Drawing.Color.Black
        Me.DRUM_SPEED.Location = New System.Drawing.Point(148, 76)
        Me.DRUM_SPEED.Name = "DRUM_SPEED"
        Me.DRUM_SPEED.Size = New System.Drawing.Size(37, 18)
        Me.DRUM_SPEED.TabIndex = 174
        Me.DRUM_SPEED.Text = "0"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(37, 76)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(101, 18)
        Me.Label16.TabIndex = 173
        Me.Label16.Text = "Drum speed"
        '
        'SET_LEVEL
        '
        Me.SET_LEVEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SET_LEVEL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SET_LEVEL.ForeColor = System.Drawing.Color.Black
        Me.SET_LEVEL.Location = New System.Drawing.Point(410, 51)
        Me.SET_LEVEL.Name = "SET_LEVEL"
        Me.SET_LEVEL.Size = New System.Drawing.Size(37, 18)
        Me.SET_LEVEL.TabIndex = 172
        Me.SET_LEVEL.Text = "0"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(246, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 18)
        Me.Label10.TabIndex = 171
        Me.Label10.Text = "Water Level Setpoint"
        '
        'WATER_LEVEL
        '
        Me.WATER_LEVEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WATER_LEVEL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WATER_LEVEL.ForeColor = System.Drawing.Color.Black
        Me.WATER_LEVEL.Location = New System.Drawing.Point(148, 52)
        Me.WATER_LEVEL.Name = "WATER_LEVEL"
        Me.WATER_LEVEL.Size = New System.Drawing.Size(37, 18)
        Me.WATER_LEVEL.TabIndex = 170
        Me.WATER_LEVEL.Text = "0"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(37, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 18)
        Me.Label12.TabIndex = 169
        Me.Label12.Text = "Water Level"
        '
        'SET_TEMP
        '
        Me.SET_TEMP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SET_TEMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SET_TEMP.ForeColor = System.Drawing.Color.Black
        Me.SET_TEMP.Location = New System.Drawing.Point(410, 27)
        Me.SET_TEMP.Name = "SET_TEMP"
        Me.SET_TEMP.Size = New System.Drawing.Size(37, 18)
        Me.SET_TEMP.TabIndex = 168
        Me.SET_TEMP.Text = "0"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(246, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(139, 18)
        Me.Label8.TabIndex = 167
        Me.Label8.Text = "Water temperature setpoint"
        '
        'WATER_TEMP
        '
        Me.WATER_TEMP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WATER_TEMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WATER_TEMP.ForeColor = System.Drawing.Color.Black
        Me.WATER_TEMP.Location = New System.Drawing.Point(148, 28)
        Me.WATER_TEMP.Name = "WATER_TEMP"
        Me.WATER_TEMP.Size = New System.Drawing.Size(37, 18)
        Me.WATER_TEMP.TabIndex = 166
        Me.WATER_TEMP.Text = "0"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(37, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 18)
        Me.Label1.TabIndex = 165
        Me.Label1.Text = "Water temperature"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.x35)
        Me.GroupBox4.Controls.Add(Me.x34)
        Me.GroupBox4.Controls.Add(Me.i4)
        Me.GroupBox4.Controls.Add(Me.i3)
        Me.GroupBox4.Controls.Add(Me.Label101)
        Me.GroupBox4.Controls.Add(Me.Label102)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox4.Location = New System.Drawing.Point(6, 217)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(243, 76)
        Me.GroupBox4.TabIndex = 137
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Input Functions"
        '
        'x35
        '
        Me.x35.AutoSize = True
        Me.x35.Location = New System.Drawing.Point(10, 49)
        Me.x35.Name = "x35"
        Me.x35.Size = New System.Drawing.Size(15, 14)
        Me.x35.TabIndex = 229
        Me.x35.UseVisualStyleBackColor = True
        '
        'x34
        '
        Me.x34.AutoSize = True
        Me.x34.Location = New System.Drawing.Point(10, 29)
        Me.x34.Name = "x34"
        Me.x34.Size = New System.Drawing.Size(15, 14)
        Me.x34.TabIndex = 228
        Me.x34.UseVisualStyleBackColor = True
        '
        'i4
        '
        Me.i4.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.i4.Location = New System.Drawing.Point(31, 48)
        Me.i4.Name = "i4"
        Me.i4.Size = New System.Drawing.Size(15, 15)
        Me.i4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.i4.TabIndex = 125
        Me.i4.TabStop = False
        '
        'i3
        '
        Me.i3.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.i3.Location = New System.Drawing.Point(31, 28)
        Me.i3.Name = "i3"
        Me.i3.Size = New System.Drawing.Size(15, 15)
        Me.i3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.i3.TabIndex = 124
        Me.i3.TabStop = False
        '
        'Label101
        '
        Me.Label101.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label101.ForeColor = System.Drawing.Color.Black
        Me.Label101.Location = New System.Drawing.Point(52, 48)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(126, 18)
        Me.Label101.TabIndex = 116
        Me.Label101.Text = "DOOR LOCKED"
        '
        'Label102
        '
        Me.Label102.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label102.ForeColor = System.Drawing.Color.Black
        Me.Label102.Location = New System.Drawing.Point(52, 28)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(126, 18)
        Me.Label102.TabIndex = 115
        Me.Label102.Text = "DOOR CLOSED"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.CheckBoxDrier)
        Me.GroupBox3.Controls.Add(Me.OUT12)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.F20)
        Me.GroupBox3.Controls.Add(Me.OUT20)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.F40)
        Me.GroupBox3.Controls.Add(Me.F32)
        Me.GroupBox3.Controls.Add(Me.F39)
        Me.GroupBox3.Controls.Add(Me.F38)
        Me.GroupBox3.Controls.Add(Me.F37)
        Me.GroupBox3.Controls.Add(Me.F36)
        Me.GroupBox3.Controls.Add(Me.F35)
        Me.GroupBox3.Controls.Add(Me.F34)
        Me.GroupBox3.Controls.Add(Me.F33)
        Me.GroupBox3.Controls.Add(Me.F31)
        Me.GroupBox3.Controls.Add(Me.F30)
        Me.GroupBox3.Controls.Add(Me.F29)
        Me.GroupBox3.Controls.Add(Me.F28)
        Me.GroupBox3.Controls.Add(Me.F27)
        Me.GroupBox3.Controls.Add(Me.F26)
        Me.GroupBox3.Controls.Add(Me.F25)
        Me.GroupBox3.Controls.Add(Me.F9)
        Me.GroupBox3.Controls.Add(Me.x6)
        Me.GroupBox3.Controls.Add(Me.F5)
        Me.GroupBox3.Controls.Add(Me.F4)
        Me.GroupBox3.Controls.Add(Me.F3)
        Me.GroupBox3.Controls.Add(Me.F1)
        Me.GroupBox3.Controls.Add(Me.F0)
        Me.GroupBox3.Controls.Add(Me.F84)
        Me.GroupBox3.Controls.Add(Me.F83)
        Me.GroupBox3.Controls.Add(Me.F19)
        Me.GroupBox3.Controls.Add(Me.F82)
        Me.GroupBox3.Controls.Add(Me.F18)
        Me.GroupBox3.Controls.Add(Me.F85)
        Me.GroupBox3.Controls.Add(Me.F17)
        Me.GroupBox3.Controls.Add(Me.OUT40)
        Me.GroupBox3.Controls.Add(Me.OUT39)
        Me.GroupBox3.Controls.Add(Me.OUT38)
        Me.GroupBox3.Controls.Add(Me.OUT37)
        Me.GroupBox3.Controls.Add(Me.OUT36)
        Me.GroupBox3.Controls.Add(Me.OUT35)
        Me.GroupBox3.Controls.Add(Me.OUT34)
        Me.GroupBox3.Controls.Add(Me.OUT33)
        Me.GroupBox3.Controls.Add(Me.Label48)
        Me.GroupBox3.Controls.Add(Me.Label49)
        Me.GroupBox3.Controls.Add(Me.Label50)
        Me.GroupBox3.Controls.Add(Me.Label51)
        Me.GroupBox3.Controls.Add(Me.Label52)
        Me.GroupBox3.Controls.Add(Me.Label53)
        Me.GroupBox3.Controls.Add(Me.Label54)
        Me.GroupBox3.Controls.Add(Me.Label55)
        Me.GroupBox3.Controls.Add(Me.OUT32)
        Me.GroupBox3.Controls.Add(Me.OUT31)
        Me.GroupBox3.Controls.Add(Me.OUT30)
        Me.GroupBox3.Controls.Add(Me.OUT29)
        Me.GroupBox3.Controls.Add(Me.OUT28)
        Me.GroupBox3.Controls.Add(Me.OUT27)
        Me.GroupBox3.Controls.Add(Me.OUT26)
        Me.GroupBox3.Controls.Add(Me.OUT25)
        Me.GroupBox3.Controls.Add(Me.Label63)
        Me.GroupBox3.Controls.Add(Me.Label64)
        Me.GroupBox3.Controls.Add(Me.Label65)
        Me.GroupBox3.Controls.Add(Me.Label66)
        Me.GroupBox3.Controls.Add(Me.Label67)
        Me.GroupBox3.Controls.Add(Me.Label68)
        Me.GroupBox3.Controls.Add(Me.Label69)
        Me.GroupBox3.Controls.Add(Me.Label70)
        Me.GroupBox3.Controls.Add(Me.OUT84)
        Me.GroupBox3.Controls.Add(Me.OUT83)
        Me.GroupBox3.Controls.Add(Me.OUT19)
        Me.GroupBox3.Controls.Add(Me.OUT82)
        Me.GroupBox3.Controls.Add(Me.OUT18)
        Me.GroupBox3.Controls.Add(Me.OUT85)
        Me.GroupBox3.Controls.Add(Me.OUT17)
        Me.GroupBox3.Controls.Add(Me.Label79)
        Me.GroupBox3.Controls.Add(Me.Label81)
        Me.GroupBox3.Controls.Add(Me.Label82)
        Me.GroupBox3.Controls.Add(Me.Label83)
        Me.GroupBox3.Controls.Add(Me.Label84)
        Me.GroupBox3.Controls.Add(Me.Label85)
        Me.GroupBox3.Controls.Add(Me.Label86)
        Me.GroupBox3.Controls.Add(Me.OUT9)
        Me.GroupBox3.Controls.Add(Me.o3)
        Me.GroupBox3.Controls.Add(Me.OUT5)
        Me.GroupBox3.Controls.Add(Me.OUT4)
        Me.GroupBox3.Controls.Add(Me.OUT3)
        Me.GroupBox3.Controls.Add(Me.OUT1)
        Me.GroupBox3.Controls.Add(Me.OUT0)
        Me.GroupBox3.Controls.Add(Me.Label88)
        Me.GroupBox3.Controls.Add(Me.Label89)
        Me.GroupBox3.Controls.Add(Me.Label90)
        Me.GroupBox3.Controls.Add(Me.Label91)
        Me.GroupBox3.Controls.Add(Me.Label92)
        Me.GroupBox3.Controls.Add(Me.Label93)
        Me.GroupBox3.Controls.Add(Me.Label94)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox3.Location = New System.Drawing.Point(6, 14)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(899, 197)
        Me.GroupBox3.TabIndex = 136
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Output Functions"
        '
        'F20
        '
        Me.F20.AutoSize = True
        Me.F20.Checked = Global.UnivibeMonitor.My.MySettings.Default._20
        Me.F20.CheckState = System.Windows.Forms.CheckState.Checked
        Me.F20.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_20", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F20.Location = New System.Drawing.Point(212, 158)
        Me.F20.Name = "F20"
        Me.F20.Size = New System.Drawing.Size(15, 14)
        Me.F20.TabIndex = 246
        Me.F20.UseVisualStyleBackColor = True
        '
        'OUT20
        '
        Me.OUT20.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT20.Location = New System.Drawing.Point(233, 157)
        Me.OUT20.Name = "OUT20"
        Me.OUT20.Size = New System.Drawing.Size(15, 15)
        Me.OUT20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT20.TabIndex = 245
        Me.OUT20.TabStop = False
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(254, 157)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(151, 18)
        Me.Label17.TabIndex = 244
        Me.Label17.Text = "HOT TO BLEACH"
        '
        'F40
        '
        Me.F40.AutoSize = True
        Me.F40.Location = New System.Drawing.Point(665, 158)
        Me.F40.Name = "F40"
        Me.F40.Size = New System.Drawing.Size(15, 14)
        Me.F40.TabIndex = 243
        Me.F40.UseVisualStyleBackColor = True
        '
        'F32
        '
        Me.F32.AutoSize = True
        Me.F32.Checked = Global.UnivibeMonitor.My.MySettings.Default._32
        Me.F32.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_32", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F32.Location = New System.Drawing.Point(427, 158)
        Me.F32.Name = "F32"
        Me.F32.Size = New System.Drawing.Size(15, 14)
        Me.F32.TabIndex = 242
        Me.F32.UseVisualStyleBackColor = True
        '
        'F39
        '
        Me.F39.AutoSize = True
        Me.F39.Location = New System.Drawing.Point(665, 139)
        Me.F39.Name = "F39"
        Me.F39.Size = New System.Drawing.Size(15, 14)
        Me.F39.TabIndex = 241
        Me.F39.UseVisualStyleBackColor = True
        '
        'F38
        '
        Me.F38.AutoSize = True
        Me.F38.Location = New System.Drawing.Point(665, 120)
        Me.F38.Name = "F38"
        Me.F38.Size = New System.Drawing.Size(15, 14)
        Me.F38.TabIndex = 240
        Me.F38.UseVisualStyleBackColor = True
        '
        'F37
        '
        Me.F37.AutoSize = True
        Me.F37.Location = New System.Drawing.Point(665, 101)
        Me.F37.Name = "F37"
        Me.F37.Size = New System.Drawing.Size(15, 14)
        Me.F37.TabIndex = 239
        Me.F37.UseVisualStyleBackColor = True
        '
        'F36
        '
        Me.F36.AutoSize = True
        Me.F36.Location = New System.Drawing.Point(665, 82)
        Me.F36.Name = "F36"
        Me.F36.Size = New System.Drawing.Size(15, 14)
        Me.F36.TabIndex = 238
        Me.F36.UseVisualStyleBackColor = True
        '
        'F35
        '
        Me.F35.AutoSize = True
        Me.F35.Location = New System.Drawing.Point(665, 63)
        Me.F35.Name = "F35"
        Me.F35.Size = New System.Drawing.Size(15, 14)
        Me.F35.TabIndex = 237
        Me.F35.UseVisualStyleBackColor = True
        '
        'F34
        '
        Me.F34.AutoSize = True
        Me.F34.Location = New System.Drawing.Point(665, 44)
        Me.F34.Name = "F34"
        Me.F34.Size = New System.Drawing.Size(15, 14)
        Me.F34.TabIndex = 236
        Me.F34.UseVisualStyleBackColor = True
        '
        'F33
        '
        Me.F33.AutoSize = True
        Me.F33.Location = New System.Drawing.Point(665, 25)
        Me.F33.Name = "F33"
        Me.F33.Size = New System.Drawing.Size(15, 14)
        Me.F33.TabIndex = 235
        Me.F33.UseVisualStyleBackColor = True
        '
        'F31
        '
        Me.F31.AutoSize = True
        Me.F31.Checked = Global.UnivibeMonitor.My.MySettings.Default._31
        Me.F31.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_31", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F31.Location = New System.Drawing.Point(427, 139)
        Me.F31.Name = "F31"
        Me.F31.Size = New System.Drawing.Size(15, 14)
        Me.F31.TabIndex = 234
        Me.F31.UseVisualStyleBackColor = True
        '
        'F30
        '
        Me.F30.AutoSize = True
        Me.F30.Checked = Global.UnivibeMonitor.My.MySettings.Default._30
        Me.F30.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_30", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F30.Location = New System.Drawing.Point(427, 120)
        Me.F30.Name = "F30"
        Me.F30.Size = New System.Drawing.Size(15, 14)
        Me.F30.TabIndex = 233
        Me.F30.UseVisualStyleBackColor = True
        '
        'F29
        '
        Me.F29.AutoSize = True
        Me.F29.Checked = Global.UnivibeMonitor.My.MySettings.Default._29
        Me.F29.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_29", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F29.Location = New System.Drawing.Point(427, 101)
        Me.F29.Name = "F29"
        Me.F29.Size = New System.Drawing.Size(15, 14)
        Me.F29.TabIndex = 232
        Me.F29.UseVisualStyleBackColor = True
        '
        'F28
        '
        Me.F28.AutoSize = True
        Me.F28.Checked = Global.UnivibeMonitor.My.MySettings.Default._28
        Me.F28.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_28", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F28.Location = New System.Drawing.Point(427, 82)
        Me.F28.Name = "F28"
        Me.F28.Size = New System.Drawing.Size(15, 14)
        Me.F28.TabIndex = 231
        Me.F28.UseVisualStyleBackColor = True
        '
        'F27
        '
        Me.F27.AutoSize = True
        Me.F27.Checked = Global.UnivibeMonitor.My.MySettings.Default._27
        Me.F27.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_27", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F27.Location = New System.Drawing.Point(427, 63)
        Me.F27.Name = "F27"
        Me.F27.Size = New System.Drawing.Size(15, 14)
        Me.F27.TabIndex = 230
        Me.F27.UseVisualStyleBackColor = True
        '
        'F26
        '
        Me.F26.AutoSize = True
        Me.F26.Checked = Global.UnivibeMonitor.My.MySettings.Default._26
        Me.F26.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_26", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F26.Location = New System.Drawing.Point(427, 44)
        Me.F26.Name = "F26"
        Me.F26.Size = New System.Drawing.Size(15, 14)
        Me.F26.TabIndex = 229
        Me.F26.UseVisualStyleBackColor = True
        '
        'F25
        '
        Me.F25.AutoSize = True
        Me.F25.Checked = Global.UnivibeMonitor.My.MySettings.Default._25
        Me.F25.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_25", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F25.Location = New System.Drawing.Point(427, 25)
        Me.F25.Name = "F25"
        Me.F25.Size = New System.Drawing.Size(15, 14)
        Me.F25.TabIndex = 228
        Me.F25.UseVisualStyleBackColor = True
        '
        'F9
        '
        Me.F9.AutoSize = True
        Me.F9.Checked = Global.UnivibeMonitor.My.MySettings.Default._9
        Me.F9.CheckState = System.Windows.Forms.CheckState.Checked
        Me.F9.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_9", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F9.Location = New System.Drawing.Point(10, 139)
        Me.F9.Name = "F9"
        Me.F9.Size = New System.Drawing.Size(15, 14)
        Me.F9.TabIndex = 227
        Me.F9.UseVisualStyleBackColor = True
        '
        'x6
        '
        Me.x6.AutoSize = True
        Me.x6.Checked = Global.UnivibeMonitor.My.MySettings.Default._6
        Me.x6.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_6", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.x6.Location = New System.Drawing.Point(10, 120)
        Me.x6.Name = "x6"
        Me.x6.Size = New System.Drawing.Size(15, 14)
        Me.x6.TabIndex = 226
        Me.x6.UseVisualStyleBackColor = True
        '
        'F5
        '
        Me.F5.AutoSize = True
        Me.F5.Checked = Global.UnivibeMonitor.My.MySettings.Default._5
        Me.F5.CheckState = System.Windows.Forms.CheckState.Checked
        Me.F5.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_5", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F5.Location = New System.Drawing.Point(10, 101)
        Me.F5.Name = "F5"
        Me.F5.Size = New System.Drawing.Size(15, 14)
        Me.F5.TabIndex = 225
        Me.F5.UseVisualStyleBackColor = True
        '
        'F4
        '
        Me.F4.AutoSize = True
        Me.F4.Checked = Global.UnivibeMonitor.My.MySettings.Default._4
        Me.F4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.F4.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_4", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F4.Location = New System.Drawing.Point(10, 82)
        Me.F4.Name = "F4"
        Me.F4.Size = New System.Drawing.Size(15, 14)
        Me.F4.TabIndex = 224
        Me.F4.UseVisualStyleBackColor = True
        '
        'F3
        '
        Me.F3.AutoSize = True
        Me.F3.Checked = Global.UnivibeMonitor.My.MySettings.Default._3
        Me.F3.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_3", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F3.Location = New System.Drawing.Point(10, 63)
        Me.F3.Name = "F3"
        Me.F3.Size = New System.Drawing.Size(15, 14)
        Me.F3.TabIndex = 223
        Me.F3.UseVisualStyleBackColor = True
        '
        'F1
        '
        Me.F1.AutoSize = True
        Me.F1.Checked = Global.UnivibeMonitor.My.MySettings.Default._1
        Me.F1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.F1.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_1", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F1.Location = New System.Drawing.Point(10, 44)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(15, 14)
        Me.F1.TabIndex = 222
        Me.F1.UseVisualStyleBackColor = True
        '
        'F0
        '
        Me.F0.AutoSize = True
        Me.F0.Checked = Global.UnivibeMonitor.My.MySettings.Default._0
        Me.F0.CheckState = System.Windows.Forms.CheckState.Checked
        Me.F0.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_0", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F0.Location = New System.Drawing.Point(10, 25)
        Me.F0.Name = "F0"
        Me.F0.Size = New System.Drawing.Size(15, 14)
        Me.F0.TabIndex = 221
        Me.F0.UseVisualStyleBackColor = True
        '
        'F84
        '
        Me.F84.AutoSize = True
        Me.F84.Checked = Global.UnivibeMonitor.My.MySettings.Default._84
        Me.F84.CheckState = System.Windows.Forms.CheckState.Checked
        Me.F84.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_84", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F84.Location = New System.Drawing.Point(212, 139)
        Me.F84.Name = "F84"
        Me.F84.Size = New System.Drawing.Size(15, 14)
        Me.F84.TabIndex = 220
        Me.F84.UseVisualStyleBackColor = True
        '
        'F83
        '
        Me.F83.AutoSize = True
        Me.F83.Checked = Global.UnivibeMonitor.My.MySettings.Default._83
        Me.F83.CheckState = System.Windows.Forms.CheckState.Checked
        Me.F83.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_83", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F83.Location = New System.Drawing.Point(212, 120)
        Me.F83.Name = "F83"
        Me.F83.Size = New System.Drawing.Size(15, 14)
        Me.F83.TabIndex = 219
        Me.F83.UseVisualStyleBackColor = True
        '
        'F19
        '
        Me.F19.AutoSize = True
        Me.F19.Checked = Global.UnivibeMonitor.My.MySettings.Default._19
        Me.F19.CheckState = System.Windows.Forms.CheckState.Checked
        Me.F19.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_19", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F19.Location = New System.Drawing.Point(212, 101)
        Me.F19.Name = "F19"
        Me.F19.Size = New System.Drawing.Size(15, 14)
        Me.F19.TabIndex = 218
        Me.F19.UseVisualStyleBackColor = True
        '
        'F82
        '
        Me.F82.AutoSize = True
        Me.F82.Checked = Global.UnivibeMonitor.My.MySettings.Default._82
        Me.F82.CheckState = System.Windows.Forms.CheckState.Checked
        Me.F82.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_82", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F82.Location = New System.Drawing.Point(212, 82)
        Me.F82.Name = "F82"
        Me.F82.Size = New System.Drawing.Size(15, 14)
        Me.F82.TabIndex = 217
        Me.F82.UseVisualStyleBackColor = True
        '
        'F18
        '
        Me.F18.AutoSize = True
        Me.F18.Checked = Global.UnivibeMonitor.My.MySettings.Default._18
        Me.F18.CheckState = System.Windows.Forms.CheckState.Checked
        Me.F18.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_18", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F18.Location = New System.Drawing.Point(212, 63)
        Me.F18.Name = "F18"
        Me.F18.Size = New System.Drawing.Size(15, 14)
        Me.F18.TabIndex = 216
        Me.F18.UseVisualStyleBackColor = True
        '
        'F85
        '
        Me.F85.AutoSize = True
        Me.F85.Checked = Global.UnivibeMonitor.My.MySettings.Default._85
        Me.F85.CheckState = System.Windows.Forms.CheckState.Checked
        Me.F85.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_85", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F85.Location = New System.Drawing.Point(212, 44)
        Me.F85.Name = "F85"
        Me.F85.Size = New System.Drawing.Size(15, 14)
        Me.F85.TabIndex = 215
        Me.F85.UseVisualStyleBackColor = True
        '
        'F17
        '
        Me.F17.AutoSize = True
        Me.F17.Checked = Global.UnivibeMonitor.My.MySettings.Default._17
        Me.F17.CheckState = System.Windows.Forms.CheckState.Checked
        Me.F17.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_17", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.F17.Location = New System.Drawing.Point(212, 25)
        Me.F17.Name = "F17"
        Me.F17.Size = New System.Drawing.Size(15, 14)
        Me.F17.TabIndex = 214
        Me.F17.UseVisualStyleBackColor = True
        '
        'OUT40
        '
        Me.OUT40.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT40.Location = New System.Drawing.Point(686, 157)
        Me.OUT40.Name = "OUT40"
        Me.OUT40.Size = New System.Drawing.Size(15, 15)
        Me.OUT40.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT40.TabIndex = 206
        Me.OUT40.TabStop = False
        '
        'OUT39
        '
        Me.OUT39.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT39.Location = New System.Drawing.Point(686, 138)
        Me.OUT39.Name = "OUT39"
        Me.OUT39.Size = New System.Drawing.Size(15, 15)
        Me.OUT39.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT39.TabIndex = 205
        Me.OUT39.TabStop = False
        '
        'OUT38
        '
        Me.OUT38.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT38.Location = New System.Drawing.Point(686, 119)
        Me.OUT38.Name = "OUT38"
        Me.OUT38.Size = New System.Drawing.Size(15, 15)
        Me.OUT38.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT38.TabIndex = 204
        Me.OUT38.TabStop = False
        '
        'OUT37
        '
        Me.OUT37.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT37.Location = New System.Drawing.Point(686, 100)
        Me.OUT37.Name = "OUT37"
        Me.OUT37.Size = New System.Drawing.Size(15, 15)
        Me.OUT37.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT37.TabIndex = 203
        Me.OUT37.TabStop = False
        '
        'OUT36
        '
        Me.OUT36.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT36.Location = New System.Drawing.Point(686, 81)
        Me.OUT36.Name = "OUT36"
        Me.OUT36.Size = New System.Drawing.Size(15, 15)
        Me.OUT36.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT36.TabIndex = 202
        Me.OUT36.TabStop = False
        '
        'OUT35
        '
        Me.OUT35.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT35.Location = New System.Drawing.Point(686, 62)
        Me.OUT35.Name = "OUT35"
        Me.OUT35.Size = New System.Drawing.Size(15, 15)
        Me.OUT35.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT35.TabIndex = 201
        Me.OUT35.TabStop = False
        '
        'OUT34
        '
        Me.OUT34.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT34.Location = New System.Drawing.Point(686, 43)
        Me.OUT34.Name = "OUT34"
        Me.OUT34.Size = New System.Drawing.Size(15, 15)
        Me.OUT34.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT34.TabIndex = 200
        Me.OUT34.TabStop = False
        '
        'OUT33
        '
        Me.OUT33.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT33.Location = New System.Drawing.Point(686, 24)
        Me.OUT33.Name = "OUT33"
        Me.OUT33.Size = New System.Drawing.Size(15, 15)
        Me.OUT33.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT33.TabIndex = 199
        Me.OUT33.TabStop = False
        '
        'Label48
        '
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.Black
        Me.Label48.Location = New System.Drawing.Point(707, 119)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(186, 18)
        Me.Label48.TabIndex = 198
        Me.Label48.Text = "Pumb 14 - Impregnation"
        '
        'Label49
        '
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Black
        Me.Label49.Location = New System.Drawing.Point(707, 157)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(186, 18)
        Me.Label49.TabIndex = 197
        Me.Label49.Text = "Pumb 16 - Laundry ECO Degreaser"
        '
        'Label50
        '
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(707, 138)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(186, 18)
        Me.Label50.TabIndex = 196
        Me.Label50.Text = "Pumb 15 - Descaling"
        '
        'Label51
        '
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Black
        Me.Label51.Location = New System.Drawing.Point(707, 100)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(186, 18)
        Me.Label51.TabIndex = 195
        Me.Label51.Text = "Pumb 13 - Preservation"
        '
        'Label52
        '
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(707, 81)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(186, 18)
        Me.Label52.TabIndex = 194
        Me.Label52.Text = "Pumb 12 - FloorCare 3"
        '
        'Label53
        '
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.Black
        Me.Label53.Location = New System.Drawing.Point(707, 62)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(186, 18)
        Me.Label53.TabIndex = 193
        Me.Label53.Text = "Pumb 11 - FloorCare 2"
        '
        'Label54
        '
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.Black
        Me.Label54.Location = New System.Drawing.Point(707, 43)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(186, 18)
        Me.Label54.TabIndex = 192
        Me.Label54.Text = "Pumb 10 - L08 - Laundry Swan Bleach"
        '
        'Label55
        '
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.Black
        Me.Label55.Location = New System.Drawing.Point(707, 24)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(186, 18)
        Me.Label55.TabIndex = 191
        Me.Label55.Text = "Pumb 9 - L07 - Laundry Swan Gentle Wash"
        '
        'OUT32
        '
        Me.OUT32.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT32.Location = New System.Drawing.Point(448, 157)
        Me.OUT32.Name = "OUT32"
        Me.OUT32.Size = New System.Drawing.Size(15, 15)
        Me.OUT32.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT32.TabIndex = 179
        Me.OUT32.TabStop = False
        '
        'OUT31
        '
        Me.OUT31.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT31.Location = New System.Drawing.Point(448, 138)
        Me.OUT31.Name = "OUT31"
        Me.OUT31.Size = New System.Drawing.Size(15, 15)
        Me.OUT31.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT31.TabIndex = 178
        Me.OUT31.TabStop = False
        '
        'OUT30
        '
        Me.OUT30.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT30.Location = New System.Drawing.Point(448, 119)
        Me.OUT30.Name = "OUT30"
        Me.OUT30.Size = New System.Drawing.Size(15, 15)
        Me.OUT30.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT30.TabIndex = 177
        Me.OUT30.TabStop = False
        '
        'OUT29
        '
        Me.OUT29.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT29.Location = New System.Drawing.Point(448, 100)
        Me.OUT29.Name = "OUT29"
        Me.OUT29.Size = New System.Drawing.Size(15, 15)
        Me.OUT29.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT29.TabIndex = 176
        Me.OUT29.TabStop = False
        '
        'OUT28
        '
        Me.OUT28.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT28.Location = New System.Drawing.Point(448, 81)
        Me.OUT28.Name = "OUT28"
        Me.OUT28.Size = New System.Drawing.Size(15, 15)
        Me.OUT28.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT28.TabIndex = 175
        Me.OUT28.TabStop = False
        '
        'OUT27
        '
        Me.OUT27.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT27.Location = New System.Drawing.Point(448, 62)
        Me.OUT27.Name = "OUT27"
        Me.OUT27.Size = New System.Drawing.Size(15, 15)
        Me.OUT27.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT27.TabIndex = 174
        Me.OUT27.TabStop = False
        '
        'OUT26
        '
        Me.OUT26.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT26.Location = New System.Drawing.Point(448, 43)
        Me.OUT26.Name = "OUT26"
        Me.OUT26.Size = New System.Drawing.Size(15, 15)
        Me.OUT26.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT26.TabIndex = 173
        Me.OUT26.TabStop = False
        '
        'OUT25
        '
        Me.OUT25.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT25.Location = New System.Drawing.Point(448, 24)
        Me.OUT25.Name = "OUT25"
        Me.OUT25.Size = New System.Drawing.Size(15, 15)
        Me.OUT25.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT25.TabIndex = 172
        Me.OUT25.TabStop = False
        '
        'Label63
        '
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.Color.Black
        Me.Label63.Location = New System.Drawing.Point(467, 119)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(168, 18)
        Me.Label63.TabIndex = 171
        Me.Label63.Text = "Pump 6 - W01 - Lagoon sensitive detergant"
        '
        'Label64
        '
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.ForeColor = System.Drawing.Color.Black
        Me.Label64.Location = New System.Drawing.Point(467, 157)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(168, 18)
        Me.Label64.TabIndex = 170
        Me.Label64.Text = "Pump 8 - W03 - Lagoon sensitive conditioner"
        '
        'Label65
        '
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.ForeColor = System.Drawing.Color.Black
        Me.Label65.Location = New System.Drawing.Point(467, 138)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(168, 18)
        Me.Label65.TabIndex = 169
        Me.Label65.Text = "Pump 7 - W02 - Lagoon delicate detergent"
        '
        'Label66
        '
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.ForeColor = System.Drawing.Color.Black
        Me.Label66.Location = New System.Drawing.Point(467, 100)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(168, 18)
        Me.Label66.TabIndex = 168
        Me.Label66.Text = "Pump 5 - Disinfection"
        '
        'Label67
        '
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.ForeColor = System.Drawing.Color.Black
        Me.Label67.Location = New System.Drawing.Point(467, 81)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(168, 18)
        Me.Label67.TabIndex = 167
        Me.Label67.Text = "Pump 4 - FloorCare"
        '
        'Label68
        '
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.ForeColor = System.Drawing.Color.Black
        Me.Label68.Location = New System.Drawing.Point(467, 62)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(168, 18)
        Me.Label68.TabIndex = 166
        Me.Label68.Text = "Pump 3 - L04 - Laundry ECO Bleach"
        '
        'Label69
        '
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.ForeColor = System.Drawing.Color.Black
        Me.Label69.Location = New System.Drawing.Point(467, 43)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(168, 18)
        Me.Label69.TabIndex = 165
        Me.Label69.Text = "Pump 2 - L05 - Laundry ECO Softener"
        '
        'Label70
        '
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.ForeColor = System.Drawing.Color.Black
        Me.Label70.Location = New System.Drawing.Point(467, 24)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(168, 18)
        Me.Label70.TabIndex = 164
        Me.Label70.Text = "Pump 1 - L02 Laundry ECO Wash"
        '
        'OUT84
        '
        Me.OUT84.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT84.Location = New System.Drawing.Point(233, 138)
        Me.OUT84.Name = "OUT84"
        Me.OUT84.Size = New System.Drawing.Size(15, 15)
        Me.OUT84.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT84.TabIndex = 146
        Me.OUT84.TabStop = False
        '
        'OUT83
        '
        Me.OUT83.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT83.Location = New System.Drawing.Point(233, 119)
        Me.OUT83.Name = "OUT83"
        Me.OUT83.Size = New System.Drawing.Size(15, 15)
        Me.OUT83.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT83.TabIndex = 145
        Me.OUT83.TabStop = False
        '
        'OUT19
        '
        Me.OUT19.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT19.Location = New System.Drawing.Point(233, 100)
        Me.OUT19.Name = "OUT19"
        Me.OUT19.Size = New System.Drawing.Size(15, 15)
        Me.OUT19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT19.TabIndex = 144
        Me.OUT19.TabStop = False
        '
        'OUT82
        '
        Me.OUT82.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT82.Location = New System.Drawing.Point(233, 81)
        Me.OUT82.Name = "OUT82"
        Me.OUT82.Size = New System.Drawing.Size(15, 15)
        Me.OUT82.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT82.TabIndex = 143
        Me.OUT82.TabStop = False
        '
        'OUT18
        '
        Me.OUT18.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT18.Location = New System.Drawing.Point(233, 62)
        Me.OUT18.Name = "OUT18"
        Me.OUT18.Size = New System.Drawing.Size(15, 15)
        Me.OUT18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT18.TabIndex = 142
        Me.OUT18.TabStop = False
        '
        'OUT85
        '
        Me.OUT85.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT85.Location = New System.Drawing.Point(233, 43)
        Me.OUT85.Name = "OUT85"
        Me.OUT85.Size = New System.Drawing.Size(15, 15)
        Me.OUT85.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT85.TabIndex = 141
        Me.OUT85.TabStop = False
        '
        'OUT17
        '
        Me.OUT17.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT17.Location = New System.Drawing.Point(233, 24)
        Me.OUT17.Name = "OUT17"
        Me.OUT17.Size = New System.Drawing.Size(15, 15)
        Me.OUT17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT17.TabIndex = 140
        Me.OUT17.TabStop = False
        '
        'Label79
        '
        Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.Black
        Me.Label79.Location = New System.Drawing.Point(254, 119)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(151, 18)
        Me.Label79.TabIndex = 139
        Me.Label79.Text = "HOT TO SOFTENER"
        '
        'Label81
        '
        Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.Black
        Me.Label81.Location = New System.Drawing.Point(254, 138)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(151, 18)
        Me.Label81.TabIndex = 137
        Me.Label81.Text = "COLD TO BLEACH"
        '
        'Label82
        '
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.Black
        Me.Label82.Location = New System.Drawing.Point(254, 100)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(151, 18)
        Me.Label82.TabIndex = 136
        Me.Label82.Text = "COLD TO SOFTENER"
        '
        'Label83
        '
        Me.Label83.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.ForeColor = System.Drawing.Color.Black
        Me.Label83.Location = New System.Drawing.Point(254, 81)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(151, 18)
        Me.Label83.TabIndex = 135
        Me.Label83.Text = "HOT TO PREWASH"
        '
        'Label84
        '
        Me.Label84.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label84.ForeColor = System.Drawing.Color.Black
        Me.Label84.Location = New System.Drawing.Point(254, 62)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(151, 18)
        Me.Label84.TabIndex = 134
        Me.Label84.Text = "COLD TO PREASH"
        '
        'Label85
        '
        Me.Label85.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.ForeColor = System.Drawing.Color.Black
        Me.Label85.Location = New System.Drawing.Point(254, 43)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(151, 18)
        Me.Label85.TabIndex = 133
        Me.Label85.Text = "HOT_TO WASH"
        '
        'Label86
        '
        Me.Label86.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.ForeColor = System.Drawing.Color.Black
        Me.Label86.Location = New System.Drawing.Point(254, 25)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(151, 18)
        Me.Label86.TabIndex = 132
        Me.Label86.Text = "COLD TO WASH"
        '
        'OUT9
        '
        Me.OUT9.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT9.Location = New System.Drawing.Point(31, 138)
        Me.OUT9.Name = "OUT9"
        Me.OUT9.Size = New System.Drawing.Size(15, 15)
        Me.OUT9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT9.TabIndex = 131
        Me.OUT9.TabStop = False
        '
        'o3
        '
        Me.o3.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.o3.Location = New System.Drawing.Point(31, 119)
        Me.o3.Name = "o3"
        Me.o3.Size = New System.Drawing.Size(15, 15)
        Me.o3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.o3.TabIndex = 130
        Me.o3.TabStop = False
        '
        'OUT5
        '
        Me.OUT5.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT5.Location = New System.Drawing.Point(31, 100)
        Me.OUT5.Name = "OUT5"
        Me.OUT5.Size = New System.Drawing.Size(15, 15)
        Me.OUT5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT5.TabIndex = 128
        Me.OUT5.TabStop = False
        '
        'OUT4
        '
        Me.OUT4.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT4.Location = New System.Drawing.Point(31, 81)
        Me.OUT4.Name = "OUT4"
        Me.OUT4.Size = New System.Drawing.Size(15, 15)
        Me.OUT4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT4.TabIndex = 127
        Me.OUT4.TabStop = False
        '
        'OUT3
        '
        Me.OUT3.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT3.Location = New System.Drawing.Point(31, 62)
        Me.OUT3.Name = "OUT3"
        Me.OUT3.Size = New System.Drawing.Size(15, 15)
        Me.OUT3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.OUT3.TabIndex = 126
        Me.OUT3.TabStop = False
        '
        'OUT1
        '
        Me.OUT1.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT1.Location = New System.Drawing.Point(31, 43)
        Me.OUT1.Name = "OUT1"
        Me.OUT1.Size = New System.Drawing.Size(15, 15)
        Me.OUT1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.OUT1.TabIndex = 125
        Me.OUT1.TabStop = False
        '
        'OUT0
        '
        Me.OUT0.Cursor = System.Windows.Forms.Cursors.Default
        Me.OUT0.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT0.Location = New System.Drawing.Point(31, 24)
        Me.OUT0.Name = "OUT0"
        Me.OUT0.Size = New System.Drawing.Size(15, 15)
        Me.OUT0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.OUT0.TabIndex = 124
        Me.OUT0.TabStop = False
        '
        'Label88
        '
        Me.Label88.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.ForeColor = System.Drawing.Color.Black
        Me.Label88.Location = New System.Drawing.Point(52, 138)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(151, 18)
        Me.Label88.TabIndex = 122
        Me.Label88.Text = "HEATER"
        '
        'Label89
        '
        Me.Label89.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label89.ForeColor = System.Drawing.Color.Black
        Me.Label89.Location = New System.Drawing.Point(52, 119)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(151, 18)
        Me.Label89.TabIndex = 121
        Me.Label89.Text = "NEW"
        '
        'Label90
        '
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.Black
        Me.Label90.Location = New System.Drawing.Point(52, 100)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(151, 18)
        Me.Label90.TabIndex = 119
        Me.Label90.Text = "FLUSH VALVE"
        '
        'Label91
        '
        Me.Label91.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.ForeColor = System.Drawing.Color.Black
        Me.Label91.Location = New System.Drawing.Point(52, 81)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(151, 18)
        Me.Label91.TabIndex = 118
        Me.Label91.Text = "REC. PUMP"
        '
        'Label92
        '
        Me.Label92.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.ForeColor = System.Drawing.Color.Black
        Me.Label92.Location = New System.Drawing.Point(52, 62)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(151, 18)
        Me.Label92.TabIndex = 117
        Me.Label92.Text = "DRAIN"
        '
        'Label93
        '
        Me.Label93.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label93.ForeColor = System.Drawing.Color.Black
        Me.Label93.Location = New System.Drawing.Point(52, 43)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(151, 18)
        Me.Label93.TabIndex = 116
        Me.Label93.Text = "HOT TO DRUM"
        '
        'Label94
        '
        Me.Label94.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label94.ForeColor = System.Drawing.Color.Black
        Me.Label94.Location = New System.Drawing.Point(52, 24)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(151, 18)
        Me.Label94.TabIndex = 115
        Me.Label94.Text = "COLD TO DRUM"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage9)
        Me.TabControl1.Controls.Add(Me.TabLogsFTDI)
        Me.TabControl1.ItemSize = New System.Drawing.Size(110, 18)
        Me.TabControl1.Location = New System.Drawing.Point(9, 81)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(0, 0)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(954, 531)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 134
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox7)
        Me.TabPage2.Controls.Add(Me.GroupBox6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(921, 455)
        Me.TabPage2.TabIndex = 8
        Me.TabPage2.Text = "Utility"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.activationTime)
        Me.GroupBox7.Controls.Add(Me.Label23)
        Me.GroupBox7.Controls.Add(Me.button14)
        Me.GroupBox7.Controls.Add(Me.quantityml)
        Me.GroupBox7.Controls.Add(Me.pumpflowrate)
        Me.GroupBox7.Controls.Add(Me.kgvalue)
        Me.GroupBox7.Controls.Add(Me.Label24)
        Me.GroupBox7.Controls.Add(Me.Label25)
        Me.GroupBox7.Controls.Add(Me.Label26)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(352, 23)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(295, 239)
        Me.GroupBox7.TabIndex = 2
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Peristaltic pump Time"
        '
        'activationTime
        '
        Me.activationTime.Location = New System.Drawing.Point(190, 145)
        Me.activationTime.Name = "activationTime"
        Me.activationTime.Size = New System.Drawing.Size(61, 21)
        Me.activationTime.TabIndex = 10
        Me.activationTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(16, 148)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(139, 15)
        Me.Label23.TabIndex = 9
        Me.Label23.Text = "Activation time (min:sec)"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'button14
        '
        Me.button14.Location = New System.Drawing.Point(19, 186)
        Me.button14.Name = "button14"
        Me.button14.Size = New System.Drawing.Size(248, 26)
        Me.button14.TabIndex = 8
        Me.button14.Text = "Calculate Activation Time"
        Me.button14.UseVisualStyleBackColor = True
        '
        'quantityml
        '
        Me.quantityml.Location = New System.Drawing.Point(190, 105)
        Me.quantityml.Name = "quantityml"
        Me.quantityml.Size = New System.Drawing.Size(61, 21)
        Me.quantityml.TabIndex = 5
        Me.quantityml.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pumpflowrate
        '
        Me.pumpflowrate.Location = New System.Drawing.Point(190, 68)
        Me.pumpflowrate.Name = "pumpflowrate"
        Me.pumpflowrate.Size = New System.Drawing.Size(61, 21)
        Me.pumpflowrate.TabIndex = 4
        Me.pumpflowrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'kgvalue
        '
        Me.kgvalue.Location = New System.Drawing.Point(190, 34)
        Me.kgvalue.Name = "kgvalue"
        Me.kgvalue.Size = New System.Drawing.Size(61, 21)
        Me.kgvalue.TabIndex = 3
        Me.kgvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(16, 108)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(140, 15)
        Me.Label24.TabIndex = 2
        Me.Label24.Text = "Desired Quantity (ml/Kg)"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(16, 37)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(128, 15)
        Me.Label25.TabIndex = 1
        Me.Label25.Text = "Garments Weight (Kg)"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(16, 71)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(142, 15)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Pump Flow rate (ml/min)"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.label95)
        Me.GroupBox6.Controls.Add(Me.Label19)
        Me.GroupBox6.Controls.Add(Me.Button5)
        Me.GroupBox6.Controls.Add(Me.Button11)
        Me.GroupBox6.Controls.Add(Me.rpm)
        Me.GroupBox6.Controls.Add(Me.gforce)
        Me.GroupBox6.Controls.Add(Me.diameter)
        Me.GroupBox6.Controls.Add(Me.Label20)
        Me.GroupBox6.Controls.Add(Me.Label22)
        Me.GroupBox6.Controls.Add(Me.label87)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(26, 23)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(295, 188)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "G - RPM converter"
        '
        'label95
        '
        Me.label95.AutoSize = True
        Me.label95.ForeColor = System.Drawing.Color.Black
        Me.label95.Location = New System.Drawing.Point(69, 153)
        Me.label95.Name = "label95"
        Me.label95.Size = New System.Drawing.Size(168, 15)
        Me.label95.TabIndex = 9
        Me.label95.Text = "G = 1.118 * 10-5 * r * (rpm) ^2"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(16, 153)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 15)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Formula:"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(186, 66)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(98, 26)
        Me.Button5.TabIndex = 7
        Me.Button5.Text = "G -> RPM"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(186, 104)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(98, 26)
        Me.Button11.TabIndex = 6
        Me.Button11.Text = "RPM -> G"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'rpm
        '
        Me.rpm.Location = New System.Drawing.Point(115, 105)
        Me.rpm.Name = "rpm"
        Me.rpm.Size = New System.Drawing.Size(61, 21)
        Me.rpm.TabIndex = 5
        Me.rpm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gforce
        '
        Me.gforce.Location = New System.Drawing.Point(115, 68)
        Me.gforce.Name = "gforce"
        Me.gforce.Size = New System.Drawing.Size(61, 21)
        Me.gforce.TabIndex = 4
        Me.gforce.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'diameter
        '
        Me.diameter.Location = New System.Drawing.Point(115, 34)
        Me.diameter.Name = "diameter"
        Me.diameter.Size = New System.Drawing.Size(61, 21)
        Me.diameter.TabIndex = 3
        Me.diameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 108)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(35, 15)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "RPM"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(16, 37)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(91, 15)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "Diameter (mm)"
        '
        'label87
        '
        Me.label87.AutoSize = True
        Me.label87.Location = New System.Drawing.Point(16, 71)
        Me.label87.Name = "label87"
        Me.label87.Size = New System.Drawing.Size(50, 15)
        Me.label87.TabIndex = 0
        Me.label87.Text = "G Force"
        '
        'TabLogsFTDI
        '
        Me.TabLogsFTDI.Controls.Add(Me.rtbFtdiLog)
        Me.TabLogsFTDI.Location = New System.Drawing.Point(4, 22)
        Me.TabLogsFTDI.Margin = New System.Windows.Forms.Padding(2)
        Me.TabLogsFTDI.Name = "TabLogsFTDI"
        Me.TabLogsFTDI.Padding = New System.Windows.Forms.Padding(2)
        Me.TabLogsFTDI.Size = New System.Drawing.Size(921, 455)
        Me.TabLogsFTDI.TabIndex = 9
        Me.TabLogsFTDI.Text = "FTDI Logs"
        Me.TabLogsFTDI.UseVisualStyleBackColor = True
        '
        'rtbFtdiLog
        '
        Me.rtbFtdiLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbFtdiLog.Font = New System.Drawing.Font("Courier New", 12.25!)
        Me.rtbFtdiLog.HideSelection = False
        Me.rtbFtdiLog.Location = New System.Drawing.Point(2, 2)
        Me.rtbFtdiLog.Margin = New System.Windows.Forms.Padding(2)
        Me.rtbFtdiLog.Name = "rtbFtdiLog"
        Me.rtbFtdiLog.ReadOnly = True
        Me.rtbFtdiLog.Size = New System.Drawing.Size(917, 451)
        Me.rtbFtdiLog.TabIndex = 0
        Me.rtbFtdiLog.Text = ""
        Me.rtbFtdiLog.WordWrap = False
        '
        'TimerTestSerialPort
        '
        Me.TimerTestSerialPort.Interval = 1000
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'TimerAlert
        '
        Me.TimerAlert.Interval = 1000
        '
        'logftdi_window_new
        '
        Me.logftdi_window_new.Controls.Add(Me.RichTextBox1)
        Me.logftdi_window_new.Location = New System.Drawing.Point(4, 29)
        Me.logftdi_window_new.Name = "logftdi_window_new"
        Me.logftdi_window_new.Padding = New System.Windows.Forms.Padding(3)
        Me.logftdi_window_new.Size = New System.Drawing.Size(192, 67)
        Me.logftdi_window_new.TabIndex = 2
        Me.logftdi_window_new.Text = "TabPage5"
        Me.logftdi_window_new.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(110, -35)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(100, 96)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'CheckBoxDrier
        '
        Me.CheckBoxDrier.AutoSize = True
        Me.CheckBoxDrier.Checked = Global.UnivibeMonitor.My.MySettings.Default._20
        Me.CheckBoxDrier.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxDrier.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.UnivibeMonitor.My.MySettings.Default, "_20", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CheckBoxDrier.Location = New System.Drawing.Point(10, 159)
        Me.CheckBoxDrier.Name = "CheckBoxDrier"
        Me.CheckBoxDrier.Size = New System.Drawing.Size(15, 14)
        Me.CheckBoxDrier.TabIndex = 249
        Me.CheckBoxDrier.UseVisualStyleBackColor = True
        '
        'OUT12
        '
        Me.OUT12.Image = Global.UnivibeMonitor.My.Resources.Resources._1
        Me.OUT12.Location = New System.Drawing.Point(31, 158)
        Me.OUT12.Name = "OUT12"
        Me.OUT12.Size = New System.Drawing.Size(15, 15)
        Me.OUT12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OUT12.TabIndex = 248
        Me.OUT12.TabStop = False
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(52, 158)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(151, 18)
        Me.Label27.TabIndex = 247
        Me.Label27.Text = "drier1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1003, 647)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.timeout_counter)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RXCounter)
        Me.Controls.Add(Me.TXCounter)
        Me.Controls.Add(Me.flagRX)
        Me.Controls.Add(Me.flagTX)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UniVibe Monitor 1.3"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.ser1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage9.ResumeLayout(False)
        Me.GroupBox30.ResumeLayout(False)
        Me.GroupBox30.PerformLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.funcNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.i4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.i3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.OUT20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT84, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT83, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT82, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT85, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.o3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OUT0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.TabLogsFTDI.ResumeLayout(False)
        Me.logftdi_window_new.ResumeLayout(False)
        CType(Me.OUT12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RXCounter As System.Windows.Forms.Label
    Friend WithEvents TXCounter As System.Windows.Forms.Label
    Friend WithEvents flagRX As System.Windows.Forms.Label
    Friend WithEvents flagTX As System.Windows.Forms.Label
    Friend WithEvents cmb_serialPort As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents RequestTimer As System.Windows.Forms.Timer
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents TimeoutTimer As System.Windows.Forms.Timer
    Friend WithEvents ser1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmb_speed As ComboBox
    Friend WithEvents msgsec As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents timeout_counter As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ipAddress As TextBox
    Friend WithEvents Button36 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label163 As Label
    Friend WithEvents Button58 As Button
    Friend WithEvents TabPage9 As TabPage
    Friend WithEvents GroupBox30 As GroupBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents RadioButton11 As RadioButton
    Friend WithEvents RadioButton10 As RadioButton
    Friend WithEvents Label162 As Label
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents TXTime As NumericUpDown
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents log_window_ad As RichTextBox
    Friend WithEvents Button35 As Button
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents OUT40 As PictureBox
    Friend WithEvents OUT39 As PictureBox
    Friend WithEvents OUT38 As PictureBox
    Friend WithEvents OUT37 As PictureBox
    Friend WithEvents OUT36 As PictureBox
    Friend WithEvents OUT35 As PictureBox
    Friend WithEvents OUT34 As PictureBox
    Friend WithEvents OUT33 As PictureBox
    Friend WithEvents Label48 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Label55 As Label
    Friend WithEvents OUT32 As PictureBox
    Friend WithEvents OUT31 As PictureBox
    Friend WithEvents OUT30 As PictureBox
    Friend WithEvents OUT29 As PictureBox
    Friend WithEvents OUT28 As PictureBox
    Friend WithEvents OUT27 As PictureBox
    Friend WithEvents OUT26 As PictureBox
    Friend WithEvents OUT25 As PictureBox
    Friend WithEvents Label63 As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents Label67 As Label
    Friend WithEvents Label68 As Label
    Friend WithEvents Label69 As Label
    Friend WithEvents Label70 As Label
    Friend WithEvents OUT84 As PictureBox
    Friend WithEvents OUT83 As PictureBox
    Friend WithEvents OUT19 As PictureBox
    Friend WithEvents OUT82 As PictureBox
    Friend WithEvents OUT18 As PictureBox
    Friend WithEvents OUT85 As PictureBox
    Friend WithEvents OUT17 As PictureBox
    Friend WithEvents Label79 As Label
    Friend WithEvents Label81 As Label
    Friend WithEvents Label82 As Label
    Friend WithEvents Label83 As Label
    Friend WithEvents Label84 As Label
    Friend WithEvents Label85 As Label
    Friend WithEvents Label86 As Label
    Friend WithEvents OUT9 As PictureBox
    Friend WithEvents o3 As PictureBox
    Friend WithEvents OUT5 As PictureBox
    Friend WithEvents OUT4 As PictureBox
    Friend WithEvents OUT3 As PictureBox
    Friend WithEvents OUT1 As PictureBox
    Friend WithEvents OUT0 As PictureBox
    Friend WithEvents Label88 As Label
    Friend WithEvents Label89 As Label
    Friend WithEvents Label90 As Label
    Friend WithEvents Label91 As Label
    Friend WithEvents Label92 As Label
    Friend WithEvents Label93 As Label
    Friend WithEvents Label94 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents i4 As PictureBox
    Friend WithEvents i3 As PictureBox
    Friend WithEvents Label101 As Label
    Friend WithEvents Label102 As Label
    Friend WithEvents TimerTestSerialPort As Timer
    Friend WithEvents F32 As CheckBox
    Friend WithEvents F39 As CheckBox
    Friend WithEvents F38 As CheckBox
    Friend WithEvents F37 As CheckBox
    Friend WithEvents F36 As CheckBox
    Friend WithEvents F35 As CheckBox
    Friend WithEvents F34 As CheckBox
    Friend WithEvents F33 As CheckBox
    Friend WithEvents F31 As CheckBox
    Friend WithEvents F30 As CheckBox
    Friend WithEvents F29 As CheckBox
    Friend WithEvents F28 As CheckBox
    Friend WithEvents F27 As CheckBox
    Friend WithEvents F26 As CheckBox
    Friend WithEvents F25 As CheckBox
    Friend WithEvents F9 As CheckBox
    Friend WithEvents x6 As CheckBox
    Friend WithEvents F5 As CheckBox
    Friend WithEvents F4 As CheckBox
    Friend WithEvents F3 As CheckBox
    Friend WithEvents F1 As CheckBox
    Friend WithEvents F0 As CheckBox
    Friend WithEvents F84 As CheckBox
    Friend WithEvents F83 As CheckBox
    Friend WithEvents F19 As CheckBox
    Friend WithEvents F82 As CheckBox
    Friend WithEvents F18 As CheckBox
    Friend WithEvents F85 As CheckBox
    Friend WithEvents F17 As CheckBox
    Friend WithEvents F40 As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SET_SPEED As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents DRUM_SPEED As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents SET_LEVEL As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents WATER_LEVEL As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents SET_TEMP As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents WATER_TEMP As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents x33 As CheckBox
    Friend WithEvents x32 As CheckBox
    Friend WithEvents x31 As CheckBox
    Friend WithEvents x35 As CheckBox
    Friend WithEvents x34 As CheckBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TimerAlert As Timer
    Friend WithEvents Button6 As Button
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Button7 As Button
    Friend WithEvents F20 As CheckBox
    Friend WithEvents OUT20 As PictureBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents funcNum As NumericUpDown
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents x38 As CheckBox
    Friend WithEvents ACC_3 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents x37 As CheckBox
    Friend WithEvents ACC_Z As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents x36 As CheckBox
    Friend WithEvents ACC_XY As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents x39 As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents TabPage2 As TabPage
    Private WithEvents GroupBox7 As GroupBox
    Private WithEvents activationTime As TextBox
    Private WithEvents Label23 As Label
    Private WithEvents button14 As Button
    Private WithEvents quantityml As TextBox
    Private WithEvents pumpflowrate As TextBox
    Private WithEvents kgvalue As TextBox
    Private WithEvents Label24 As Label
    Private WithEvents Label25 As Label
    Private WithEvents Label26 As Label
    Private WithEvents GroupBox6 As GroupBox
    Private WithEvents label95 As Label
    Private WithEvents Label19 As Label
    Private WithEvents Button5 As Button
    Private WithEvents Button11 As Button
    Private WithEvents rpm As TextBox
    Private WithEvents gforce As TextBox
    Private WithEvents diameter As TextBox
    Private WithEvents Label20 As Label
    Private WithEvents Label22 As Label
    Private WithEvents label87 As Label
    Friend WithEvents logftdi_window_new As TabPage
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents TabLogsFTDI As TabPage
    Friend WithEvents rtbFtdiLog As RichTextBox
    Friend WithEvents LabelFirmwareTitle As Label
    Friend WithEvents LabelFirmwareVersion As Label
    Friend WithEvents RemainingTimeValue As Label
    Friend WithEvents RemainingTime As Label
    Friend WithEvents ActiveGraph As CheckBox
    Friend WithEvents CheckBoxDrier As CheckBox
    Friend WithEvents OUT12 As PictureBox
    Friend WithEvents Label27 As Label
End Class
