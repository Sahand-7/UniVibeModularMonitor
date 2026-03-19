<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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
        Me.FormsPlot1 = New ScottPlot.WinForms.FormsPlot()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me._ck_autorange = New System.Windows.Forms.CheckBox()
        Me.numericUpDown3 = New System.Windows.Forms.NumericUpDown()
        Me.numericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.numericUpDown4 = New System.Windows.Forms.NumericUpDown()
        Me.numericUpDown1 = New System.Windows.Forms.NumericUpDown()
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.TempPerMin = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SpeedInfo = New System.Windows.Forms.Label()
        CType(Me.numericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericUpDown4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FormsPlot1
        '
        Me.FormsPlot1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FormsPlot1.BackColor = System.Drawing.Color.Silver
        Me.FormsPlot1.Location = New System.Drawing.Point(5, 6)
        Me.FormsPlot1.Name = "FormsPlot1"
        Me.FormsPlot1.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.FormsPlot1.Size = New System.Drawing.Size(1553, 443)
        Me.FormsPlot1.TabIndex = 0
        Me.FormsPlot1.Text = "FormsPlot1"
        Me.FormsPlot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
        Me.FormsPlot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.FormsPlot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(1501, 471)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(62, 49)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'label4
        '
        Me.label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(253, 468)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(35, 13)
        Me.label4.TabIndex = 9
        Me.label4.Text = "Offset"
        '
        'label3
        '
        Me.label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(253, 494)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(37, 13)
        Me.label3.TabIndex = 4
        Me.label3.Text = "Y Max"
        '
        'label2
        '
        Me.label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(139, 494)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(34, 13)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Y Min"
        '
        'label1
        '
        Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(138, 468)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(39, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Range"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(1433, 471)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(62, 49)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Export CSV"
        Me.Button2.UseVisualStyleBackColor = True
        '
        '_ck_autorange
        '
        Me._ck_autorange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me._ck_autorange.AutoSize = True
        Me._ck_autorange.Location = New System.Drawing.Point(12, 465)
        Me._ck_autorange.Name = "_ck_autorange"
        Me._ck_autorange.Size = New System.Drawing.Size(78, 17)
        Me._ck_autorange.TabIndex = 5
        Me._ck_autorange.Text = "Auto range"
        Me._ck_autorange.UseVisualStyleBackColor = True
        '
        'numericUpDown3
        '
        Me.numericUpDown3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.numericUpDown3.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.UnivibeMonitor.My.MySettings.Default, "graph_max", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.numericUpDown3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numericUpDown3.Location = New System.Drawing.Point(293, 490)
        Me.numericUpDown3.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.numericUpDown3.Name = "numericUpDown3"
        Me.numericUpDown3.Size = New System.Drawing.Size(55, 22)
        Me.numericUpDown3.TabIndex = 5
        Me.numericUpDown3.Value = Global.UnivibeMonitor.My.MySettings.Default.graph_max
        '
        'numericUpDown2
        '
        Me.numericUpDown2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.numericUpDown2.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.UnivibeMonitor.My.MySettings.Default, "graph_min", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.numericUpDown2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numericUpDown2.Location = New System.Drawing.Point(179, 490)
        Me.numericUpDown2.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numericUpDown2.Minimum = New Decimal(New Integer() {2000, 0, 0, -2147483648})
        Me.numericUpDown2.Name = "numericUpDown2"
        Me.numericUpDown2.Size = New System.Drawing.Size(55, 22)
        Me.numericUpDown2.TabIndex = 3
        Me.numericUpDown2.Value = Global.UnivibeMonitor.My.MySettings.Default.graph_min
        '
        'numericUpDown4
        '
        Me.numericUpDown4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.numericUpDown4.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.UnivibeMonitor.My.MySettings.Default, "graph_offset", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.numericUpDown4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numericUpDown4.Location = New System.Drawing.Point(293, 464)
        Me.numericUpDown4.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.numericUpDown4.Name = "numericUpDown4"
        Me.numericUpDown4.Size = New System.Drawing.Size(55, 22)
        Me.numericUpDown4.TabIndex = 8
        Me.numericUpDown4.Value = Global.UnivibeMonitor.My.MySettings.Default.graph_offset
        '
        'numericUpDown1
        '
        Me.numericUpDown1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.numericUpDown1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.UnivibeMonitor.My.MySettings.Default, "graph_range", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.numericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numericUpDown1.Location = New System.Drawing.Point(179, 464)
        Me.numericUpDown1.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.numericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numericUpDown1.Name = "numericUpDown1"
        Me.numericUpDown1.Size = New System.Drawing.Size(54, 22)
        Me.numericUpDown1.TabIndex = 1
        Me.numericUpDown1.Value = Global.UnivibeMonitor.My.MySettings.Default.graph_range
        '
        'SET_SPEED
        '
        Me.SET_SPEED.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SET_SPEED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SET_SPEED.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SET_SPEED.ForeColor = System.Drawing.Color.Black
        Me.SET_SPEED.Location = New System.Drawing.Point(618, 507)
        Me.SET_SPEED.Name = "SET_SPEED"
        Me.SET_SPEED.Size = New System.Drawing.Size(43, 18)
        Me.SET_SPEED.TabIndex = 188
        Me.SET_SPEED.Text = "0"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(507, 507)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(139, 18)
        Me.Label14.TabIndex = 187
        Me.Label14.Text = "Drum speed setpoint"
        '
        'DRUM_SPEED
        '
        Me.DRUM_SPEED.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DRUM_SPEED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DRUM_SPEED.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DRUM_SPEED.ForeColor = System.Drawing.Color.Black
        Me.DRUM_SPEED.Location = New System.Drawing.Point(432, 507)
        Me.DRUM_SPEED.Name = "DRUM_SPEED"
        Me.DRUM_SPEED.Size = New System.Drawing.Size(50, 18)
        Me.DRUM_SPEED.TabIndex = 186
        Me.DRUM_SPEED.Text = "0"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(360, 507)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(101, 18)
        Me.Label16.TabIndex = 185
        Me.Label16.Text = "Drum speed"
        '
        'SET_LEVEL
        '
        Me.SET_LEVEL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SET_LEVEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SET_LEVEL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SET_LEVEL.ForeColor = System.Drawing.Color.Black
        Me.SET_LEVEL.Location = New System.Drawing.Point(618, 486)
        Me.SET_LEVEL.Name = "SET_LEVEL"
        Me.SET_LEVEL.Size = New System.Drawing.Size(43, 18)
        Me.SET_LEVEL.TabIndex = 184
        Me.SET_LEVEL.Text = "0"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(507, 486)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 18)
        Me.Label10.TabIndex = 183
        Me.Label10.Text = "Water Level Setpoint"
        '
        'WATER_LEVEL
        '
        Me.WATER_LEVEL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.WATER_LEVEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WATER_LEVEL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WATER_LEVEL.ForeColor = System.Drawing.Color.Black
        Me.WATER_LEVEL.Location = New System.Drawing.Point(432, 486)
        Me.WATER_LEVEL.Name = "WATER_LEVEL"
        Me.WATER_LEVEL.Size = New System.Drawing.Size(50, 18)
        Me.WATER_LEVEL.TabIndex = 182
        Me.WATER_LEVEL.Text = "0"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(360, 486)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 18)
        Me.Label12.TabIndex = 181
        Me.Label12.Text = "Water Level"
        '
        'SET_TEMP
        '
        Me.SET_TEMP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SET_TEMP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SET_TEMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SET_TEMP.ForeColor = System.Drawing.Color.Black
        Me.SET_TEMP.Location = New System.Drawing.Point(618, 464)
        Me.SET_TEMP.Name = "SET_TEMP"
        Me.SET_TEMP.Size = New System.Drawing.Size(43, 18)
        Me.SET_TEMP.TabIndex = 180
        Me.SET_TEMP.Text = "0"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(507, 464)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 18)
        Me.Label8.TabIndex = 179
        Me.Label8.Text = "Water temp Set"
        '
        'WATER_TEMP
        '
        Me.WATER_TEMP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.WATER_TEMP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WATER_TEMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WATER_TEMP.ForeColor = System.Drawing.Color.Black
        Me.WATER_TEMP.Location = New System.Drawing.Point(432, 464)
        Me.WATER_TEMP.Name = "WATER_TEMP"
        Me.WATER_TEMP.Size = New System.Drawing.Size(50, 18)
        Me.WATER_TEMP.TabIndex = 178
        Me.WATER_TEMP.Text = "0"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(360, 464)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 18)
        Me.Label5.TabIndex = 177
        Me.Label5.Text = "Water temp"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 501)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 37)
        Me.Label6.TabIndex = 196
        Me.Label6.Text = "*"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(26, 505)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 18)
        Me.Label13.TabIndex = 197
        Me.Label13.Text = "Active"
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(12, 483)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(115, 17)
        Me.CheckBox1.TabIndex = 198
        Me.CheckBox1.Text = "Stop-Export at End"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(1365, 471)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(62, 49)
        Me.Button3.TabIndex = 199
        Me.Button3.Text = "Capture"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button8.BackColor = System.Drawing.Color.White
        Me.Button8.Enabled = False
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(1286, 471)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(62, 49)
        Me.Button8.TabIndex = 195
        Me.Button8.Text = "STOP"
        Me.Button8.UseVisualStyleBackColor = False
        Me.Button8.Visible = False
        '
        'TempPerMin
        '
        Me.TempPerMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TempPerMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TempPerMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TempPerMin.ForeColor = System.Drawing.Color.Black
        Me.TempPerMin.Location = New System.Drawing.Point(797, 464)
        Me.TempPerMin.Name = "TempPerMin"
        Me.TempPerMin.Size = New System.Drawing.Size(33, 18)
        Me.TempPerMin.TabIndex = 201
        Me.TempPerMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(688, 466)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 18)
        Me.Label15.TabIndex = 202
        Me.Label15.Text = "Temp/Min:"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(688, 489)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 18)
        Me.Label7.TabIndex = 205
        Me.Label7.Text = "Time to reach T is:"
        '
        'SpeedInfo
        '
        Me.SpeedInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SpeedInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SpeedInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedInfo.ForeColor = System.Drawing.Color.Black
        Me.SpeedInfo.Location = New System.Drawing.Point(797, 486)
        Me.SpeedInfo.Name = "SpeedInfo"
        Me.SpeedInfo.Size = New System.Drawing.Size(33, 21)
        Me.SpeedInfo.TabIndex = 204
        Me.SpeedInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1570, 531)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.SpeedInfo)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TempPerMin)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.SET_SPEED)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.DRUM_SPEED)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.SET_LEVEL)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.WATER_LEVEL)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.SET_TEMP)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.WATER_TEMP)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.numericUpDown3)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me._ck_autorange)
        Me.Controls.Add(Me.numericUpDown2)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.numericUpDown4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.FormsPlot1)
        Me.Controls.Add(Me.numericUpDown1)
        Me.Controls.Add(Me.label1)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Graph"
        CType(Me.numericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericUpDown4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FormsPlot1 As ScottPlot.WinForms.FormsPlot
    Friend WithEvents Button1 As Button
    Private WithEvents label4 As Label
    Private WithEvents numericUpDown4 As NumericUpDown
    Private WithEvents numericUpDown3 As NumericUpDown
    Private WithEvents label3 As Label
    Private WithEvents numericUpDown2 As NumericUpDown
    Private WithEvents label2 As Label
    Private WithEvents numericUpDown1 As NumericUpDown
    Private WithEvents label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents _ck_autorange As CheckBox
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
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents TempPerMin As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents SpeedInfo As Label
End Class
