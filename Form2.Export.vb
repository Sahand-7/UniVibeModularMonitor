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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim header As String = "Time"
        Dim dataPointsList As New List(Of List(Of DataPoint))()

        For Each series As Series In plotModel.Series
            header += ";" & series.Title

            If TypeOf series Is LineSeries Then
                Dim lineSeries As LineSeries = DirectCast(series, LineSeries)
                Dim dataPoints As New List(Of DataPoint)()

                For Each dataPoint As DataPoint In lineSeries.Points
                    dataPoints.Add(dataPoint)
                Next

                dataPointsList.Add(dataPoints)
            End If
        Next

        Dim csvBuilder As New StringBuilder()
        csvBuilder.AppendLine(header)

        Dim maxPoints As Integer = dataPointsList.Max(Function(d) d.Count)

        For i As Integer = 0 To maxPoints - 1
            Dim lineBuilder As New StringBuilder()

            If i < dataPointsList(0).Count Then
                Dim time As DateTime = DateTime.FromOADate(dataPointsList(0)(i).X)
                lineBuilder.Append(time.ToString("HH:mm:ss.f"))
            End If

            For Each dataPoints As List(Of DataPoint) In dataPointsList
                If i < dataPoints.Count Then
                    lineBuilder.Append($";{dataPoints(i).Y}")
                Else
                    lineBuilder.Append(";")
                End If
            Next

            csvBuilder.AppendLine(lineBuilder.ToString())
        Next

        Dim takenDir As String = Form1.machineFolder
        If String.IsNullOrEmpty(Form1.DirectoryPerWashProgram) Then
            takenDir = Form1.machineFolder + "\" + "IDLE_Mode"
            currentProgramName = "Home_Screen"
            Directory.CreateDirectory(takenDir)
        Else
            takenDir = Form1.machineFolder + "\" + currentProgramName
            Directory.CreateDirectory(takenDir)
        End If

        Dim filename As String = takenDir & "\" & Form1.MachineName & "_" & currentProgramName & "_" & Form1.combinedVersion & "-" & DateTime.Now.ToString("yyyy-MM-dd_HH-mm") & ".csv"

        File.WriteAllText(filename, csvBuilder.ToString())
        MessageBox.Show("Data exported to " & filename, "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If Not String.IsNullOrEmpty(Form1.DirectoryPerWashProgram) Then
            imageName = Form1.DirectoryPerWashProgram.ToString & "\" & "FULLSCALE_" & Form1.ProgramIndexValue & "_" & Form1.combinedVersion & "-" & DateTime.Now.ToString("yyyy-MM-dd_HH-mm") & ".png"

            Dim exporter As New PngExporter With {
                .Width = 4000,
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

        If Not IO.Directory.Exists(takenDir) Then IO.Directory.CreateDirectory(takenDir)

        Dim bmp As New Bitmap(PlotView1.Width, PlotView1.Height)
        PlotView1.DrawToBitmap(bmp, New Rectangle(0, 0, bmp.Width, bmp.Height))
        bmp.Save(imageName, Imaging.ImageFormat.Png)
    End Sub

End Class
