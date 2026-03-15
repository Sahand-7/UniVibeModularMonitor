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

    Private Function GetModuleColor(moduleId As Integer) As OxyColor
        Select Case moduleId
            Case 0
                Return OxyColor.FromAColor(30, OxyColors.Gray)
            Case 17
                Return OxyColor.FromAColor(60, OxyColors.LightSkyBlue)
            Case 1
                Return OxyColor.FromAColor(60, OxyColors.LightGreen)
            Case 2
                Return OxyColor.FromAColor(60, OxyColors.DodgerBlue)
            Case 3
                Return OxyColor.FromAColor(60, OxyColors.Aqua)
            Case 4
                Return OxyColor.FromAColor(60, OxyColors.Cyan)
            Case 6
                Return OxyColor.FromAColor(60, OxyColors.LightSteelBlue)
            Case 7
                Return OxyColor.FromAColor(60, OxyColors.SaddleBrown)
            Case 8
                Return OxyColor.FromAColor(60, OxyColors.OrangeRed)
            Case 15
                Return OxyColor.FromAColor(60, OxyColors.DarkGray)
            Case Else
                Return OxyColor.FromAColor(40, OxyColors.Yellow)
        End Select
    End Function

End Class
