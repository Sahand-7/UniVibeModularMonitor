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

    Private Sub TerminateAll(obj As Short)
        isProcessingData = False
        dataProcessingThread.Abort()
        dataProcessingThread.Join()
    End Sub

    Private Sub AddBufferToQueue(obj() As Double)
        queue.Enqueue(obj)
    End Sub

    Public Sub StopProcessing()
        isProcessingData = False

        If dataProcessingThread IsNot Nothing AndAlso dataProcessingThread.IsAlive Then
            dataProcessingThread.Join()
        End If

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

    Private Sub ProcessDataFromQueue()
        Debug.WriteLine("Start thread isProcessingData")
        While isProcessingData
            SyncLock queue
                Try
                    Invoke(DirectCast(AddressOf UpdateQueueDisplay, Action))
                Catch generatedExceptionName As Exception
                    Debug.WriteLine("Error")
                End Try
            End SyncLock

            Thread.Sleep(20)
        End While
    End Sub

    Private Function UpdateQueueDisplay() As Object
        If queue.Count > 0 Then
            Dim array As Double() = queue.Dequeue()
            GiveMeNewDataFromQueue(array)
        End If
        Return Nothing
    End Function

    Private Sub GiveMeNewDataFromQueue(array() As Double)

        If PlotView1.InvokeRequired Then
            PlotView1.Invoke(New Action(Of Double())(AddressOf GiveMeNewDataFromQueue), array)
        Else
            Dim currentTime As DateTime = DateTime.Now

            If ((currentTime >= startTime.AddMinutes(numericUpDown1.Value)) And _ck_autorange.Checked) Then
                numericUpDown1.Value = numericUpDown1.Value + 1
            End If

            If startTimeAquired = False Then
                startTime = DateTime.Now
                startTimeAquired = True
            End If

            out_cold_water.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(0)))
            out_hot_water.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(1)))
            out_drain.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(2)))
            out_rec.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(3)))
            out_heater.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(4)))
            out_cold_wash.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(5)))
            out_hot_wash.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(6)))
            out_cold_prewash.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(7)))
            out_hot_prewash.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(8)))
            out_cold_softener.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(9)))
            out_hot_softener.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(10)))
            out_cold_bleach.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(11)))
            out_hot_bleach.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(12)))
            an_water_temp.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(14)))
            an_water_tempSetpoint.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(15)))
            an_water_level.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(16)))
            an_water_levelSetpoint.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(17)))
            an_drum_speed.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(18)))
            an_drum_speed_setpoint.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(19)))

            out_liquid_pump_1.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(20)))
            out_liquid_pump_2.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(21)))
            out_liquid_pump_3.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(22)))
            out_liquid_pump_4.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(23)))
            out_liquid_pump_5.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(24)))
            out_liquid_pump_6.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(25)))
            out_liquid_pump_7.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(26)))
            out_flush_valve.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(27)))

            an_axis_xy.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(28)))
            an_axis_z.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(29)))
            an_axis_3.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(30)))

            an_module.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(31) * 10))
            weight.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(32)))
            out_drier_heater_one.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(33)))
            out_drier_heater_two.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(34)))
            out_drier_heater_three.Points.Add(New DataPoint(DateTimeAxis.ToDouble(currentTime), array(35)))

            WATER_TEMP.Text = array(14).ToString("#0.0")
            WATER_LEVEL.Text = array(16).ToString("#0.0")
            SET_TEMP.Text = array(15).ToString("#0.0")
            SET_SPEED.Text = array(19).ToString("#0.0")
            DRUM_SPEED.Text = array(18).ToString("#0.0")
            SET_TEMP.Text = array(15).ToString("#0.0")

            plotModel.InvalidatePlot(True)

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
                programStartTime = DateTime.Now

                Dim nameAnn As New TextAnnotation()
                nameAnn.Text = currentProgramName
                nameAnn.TextPosition = New DataPoint(10, 10)
                nameAnn.Stroke = OxyColors.Transparent
                nameAnn.TextColor = OxyColors.Black
                nameAnn.FontWeight = FontWeights.Bold
                nameAnn.TextHorizontalAlignment = HorizontalAlignment.Left
                nameAnn.TextVerticalAlignment = VerticalAlignment.Top
                nameAnn.Layer = AnnotationLayer.AboveSeries

                plotModel.Subtitle = currentProgramName
                plotModel.SubtitleFontWeight = FontWeights.Bold
                plotModel.SubtitleColor = OxyColors.Black

                plotModel.InvalidatePlot(False)
                programAnnotations.Add(nameAnn)
                previousProgramName = currentProgramName
            End If

            Dim currentModuleValue = array(31)
            plotModel.Subtitle = Form1.MachineName + "  " + currentProgramName + " current mode: " + GetModuleName(currentModuleValue)

            If (previousModule <> currentModuleValue) Then
                If previousModule <> 0 Then
                    Dim rect As New RectangleAnnotation() With {
                        .MinimumX = DateTimeAxis.ToDouble(moduleStartTime),
                        .MaximumX = DateTimeAxis.ToDouble(DateTime.Now),
                        .MinimumY = 0,
                        .MaximumY = Double.PositiveInfinity,
                        .Fill = moduleBackgroundColor,
                        .Layer = AnnotationLayer.BelowSeries
                    }

                    plotModel.Annotations.Add(rect)

                    Dim midTime As DateTime = moduleStartTime + TimeSpan.FromTicks((DateTime.Now - moduleStartTime).Ticks \ 2)

                    Dim textAnn As New TextAnnotation() With {
                        .Text = GetModuleName(previousModule),
                        .TextPosition = New DataPoint(DateTimeAxis.ToDouble(midTime), yAxis.ActualTitle),
                        .Stroke = OxyColors.Transparent,
                        .TextColor = OxyColors.Black,
                        .FontWeight = FontWeights.Bold,
                        .TextVerticalAlignment = VerticalAlignment.Top,
                        .Layer = AnnotationLayer.BelowSeries
                    }

                    plotModel.Annotations.Add(textAnn)
                End If

                moduleStartTime = DateTime.Now
                moduleBackgroundColor = GetModuleColor(currentModuleValue)
                previousModule = currentModuleValue
            End If
        End If
    End Sub

End Class
