'Copyright (C) 2014  Joni Nieminen

'This program is free software: you can redistribute it and/or modify
'it under the terms of the GNU General Public License as published by
'the Free Software Foundation, either version 3 of the License, or
'(at your option) any later version.

'This program is distributed in the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License for more details.

'You should have received a copy of the GNU General Public License
'along with this program.  If not, see <http://www.gnu.org/licenses/>.

Imports System.IO
Imports System.Net
Imports System.ComponentModel

Public Class Main

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar_Update.Maximum = 3
        ProgressBar_Update.Minimum = 0
        ProgressBar_Update.Value = 0
        ProgressBar_Update.Step = 1
        MsgBox("Updating Dashbox and required files now.")
        BackgroundWorker.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker.DoWork
        Dim array As Array
        Dim path As String = Application.StartupPath & "\"
        Dim dwnurl As String

        If GblVars.updatedb.Contains("||") Then
            array = Split(GblVars.updatedb, "||")
            dwnurl = "https://832ac22bda8f93ababab398a8cd812b70a6eb164.googledrive.com/host/0BwXzp8oa9Tx4eU93R0xUNkFHa00/"

            For i As Integer = 1 To UBound(array) Step +1

                GblVars.report = "Updating " & array(i) & "..."
                BackgroundWorker.ReportProgress(i)

                Try
                    File.Delete(path & array(i))
                Catch ex As Exception
                    MsgBox(array(i) & " is in use!" & vbCrLf & ex.ToString)
                End Try

                Try
                    My.Computer.Network.DownloadFile(dwnurl & array(i), path & array(i), "", "", False, 3000, True)
                    'InputBox("", "", dwnurl)
                Catch ex As Exception
                    MsgBox("Can't update " & array(i) & "! File might be read-only or in use!" & vbCrLf & ex.ToString)
                End Try
            Next
        End If
    End Sub

    Private Sub BackgroundWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker.ProgressChanged
        Label_Updating.Text = GblVars.report
        ProgressBar_Update.PerformStep()
    End Sub

    Private Sub BackgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker.RunWorkerCompleted
        Me.Hide()
        MsgBox("Updating completed! Starting Dashbox!")
        Try
            Process.Start(Application.StartupPath & "\Dashbox.exe")
        Catch ex As Win32Exception
            MsgBox("No rights to start Dashbox.exe")
            Application.Exit()
        End Try
        Application.Exit()
    End Sub
End Class

Public Class GblVars
    Public Shared updatedb As String = DownloadString("https://googledrive.com/host/0BwXzp8oa9Tx4eU93R0xUNkFHa00/update.txt").ToString
    Public Shared report As String

    Shared Function DownloadString(ByVal address As String) As String
        Dim client As WebClient = New WebClient()
        Dim reply As String = client.DownloadString(address)
        Return reply
    End Function
End Class