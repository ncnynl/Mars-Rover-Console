
Imports System.ComponentModel

Public Class Form1

    Private wrkrError As Exception = Nothing
    Private blnExit As Boolean = False
    Private blnStopRequested As Boolean = False
    Private intIntervalValue As Integer = 10
    Private baseTemp As Integer = 20
    Private basePressure As Integer = 600
    Private baseWind As Integer = 100
    Private baseMethane As Integer = 5
    Private filePath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\MarsData\MarsData.txt"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            numInterval.Text = intIntervalValue
            lbl_FilePath.Text = filePath
            Timer1.Enabled = True
            ToolStripComboBox1.SelectedIndex = ToolStripComboBox1.Items.IndexOf(intIntervalValue.ToString())
            ss_ErrorStrip.Text = "Error Strip"

            If Not System.IO.Directory.Exists(filePath) Then
                System.IO.Directory.CreateDirectory(filePath)
            End If

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message)
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Try
            Timer1.Enabled = False
            Me.Hide()
            ToolStripComboBox1.SelectedText = intIntervalValue
            wrkrMarsData.RunWorkerAsync()
            ss_ErrorStrip.Text = "Worker Started"

        Catch ex As Exception
            ss_ErrorStrip.Text = ex.Message
        End Try

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Try
            My.Settings.Save()
            Me.Hide()
            e.Cancel = Not blnExit

        Catch ex As Exception
            e.Cancel = Not blnExit
        End Try

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        Try
            blnExit = True
            Me.Close()

        Catch ex As Exception
            ss_ErrorStrip.Text = ex.Message
        End Try

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

        Try
            Me.Show()

        Catch ex As Exception
            ss_ErrorStrip.Text = ex.Message
        End Try

    End Sub



    Private Sub wrkrMarsData_DoWork(sender As Object, e As DoWorkEventArgs) Handles wrkrMarsData.DoWork

        Try
            wrkrError = Nothing
            Dim Rnd As New Random
            Dim dtStartTime As DateTime
            Dim intInterval = e.Argument
            Dim alState As New ArrayList
            For Index As Integer = 0 To 5
                alState.Add("")
            Next
            Dim allowchar() As Char = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Dim resultString As String = ""
            Dim stringLength As Integer = 2

            dtStartTime = DateTime.Now
            Do While Not blnStopRequested
                intInterval = intIntervalValue

                alState(0) = "NewValues"
                alState(1) = "-" + FormatNumber(Rnd.NextDouble.ToString + Rnd.Next(baseTemp * 0.9, baseTemp * 1.2), 2).ToString() + "'C"
                alState(2) = FormatNumber(Rnd.Next(basePressure * 0.9, basePressure * 1.2).ToString + Rnd.NextDouble(), 2).ToString + "Pa"
                alState(3) = FormatNumber(Rnd.Next(baseWind * 0.9, baseWind * 1.2).ToString + Rnd.NextDouble().ToString, 2) + "kn"
                alState(4) = FormatNumber(Rnd.Next(baseMethane * 0.9, baseMethane * 1.2).ToString + Rnd.NextDouble().ToString, 2) + "ppb"

                resultString = ""
                For i As Integer = 0 To stringLength - 1
                    resultString += allowchar(Rnd.Next(0, allowchar.Length))
                Next
                resultString += "-" + Rnd.Next(1000, 9999).ToString
                alState(5) = resultString
                wrkrMarsData.ReportProgress(0, alState)


                If (DateTime.Now - dtStartTime).TotalMilliseconds >= intInterval * 1000 Then
                    dtStartTime = DateTime.Now
                    alState(0) = "WriteFile" : wrkrMarsData.ReportProgress(0, alState) : Threading.Thread.Sleep(50)
                End If

                Threading.Thread.Sleep(1000)
            Loop

            e.Result = "Complete"

        Catch ex As Exception
            wrkrError = ex
            e.Result = "Error"
        End Try

    End Sub

    Private Sub wrkrMarsData_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles wrkrMarsData.ProgressChanged

        Try
            Select Case e.UserState(0)

                Case "NewValues"
                    ListBox1.Items.Clear()
                    ListBox1.Items.Add(e.UserState(1))
                    ListBox1.Items.Add(e.UserState(2))
                    ListBox1.Items.Add(e.UserState(3))
                    ListBox1.Items.Add(e.UserState(4))
                    ListBox1.Items.Add(e.UserState(5))

                Case "WriteFile"
                    Dim strData As String = ""
                    If ListBox1.Items.Count > 0 Then
                        For intItem As Integer = 0 To ListBox1.Items.Count - 1
                            Using outFile As New System.IO.StreamWriter(Split(lbl_FilePath.Text, ".").First & (intItem + 1) & "." & Split(lbl_FilePath.Text, ".").Last)
                                outFile.Write(ListBox1.Items(intItem).ToString)
                            End Using
                        Next
                    End If

            End Select
        Catch ex As Exception
            ss_ErrorStrip.Text = ex.Message
        End Try

    End Sub

    Private Sub wrkrMarsData_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles wrkrMarsData.RunWorkerCompleted
        Try
            Select Case e.Result
                Case "Error"
                    ss_ErrorStrip.Text = wrkrError.Message
                Case "Complete"
                    ss_ErrorStrip.Text = "Worker Stopped"
            End Select
        Catch ex As Exception
            ss_ErrorStrip.Text = ex.Message
        Finally
            blnStopRequested = False
        End Try
    End Sub

    Private Sub btn_Start_Click(sender As Object, e As EventArgs) Handles btn_Start.Click
        Try
            wrkrMarsData.RunWorkerAsync()
            ss_ErrorStrip.Text = "Worker Started"
        Catch ex As Exception
            ss_ErrorStrip.Text = ex.Message
        End Try

    End Sub

    Private Sub btn_Stop_Click(sender As Object, e As EventArgs) Handles btn_Stop.Click
        Try
            blnStopRequested = True
        Catch ex As Exception
            ss_ErrorStrip.Text = ex.Message
        End Try
    End Sub
    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        Try
            intIntervalValue = CInt(ToolStripComboBox1.SelectedItem.ToString)
            numInterval.Text = intIntervalValue
            ToolStripComboBox1.SelectedText = intIntervalValue
        Catch ex As Exception
            ss_ErrorStrip.Text = ex.Message
        End Try
    End Sub
End Class
