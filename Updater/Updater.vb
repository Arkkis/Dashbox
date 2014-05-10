Imports System.IO
Imports System.Net

Public Class Updater

    Public Shared Sub Main()
        MsgBox("Updating now.")
        Dim updateurl As String = DownloadString("https://googledrive.com/host/0BwXzp8oa9Tx4eU93R0xUNkFHa00/update.txt")
        Dim updatedb As String = DownloadString(updateurl), dwnurl As String
        Dim array As Array
        Dim path As String = Application.StartupPath & "\"

        If updatedb.Contains("||") Then
            array = Split(updatedb, "||")
            dwnurl = array(0)

            For i As Integer = 1 To UBound(array) Step +1
                'MsgBox(array(i))
                File.Delete(path & array(i))
                'MsgBox("Downloading: " & dwnurl & array(i))
                My.Computer.Network.DownloadFile(dwnurl & array(i), path & array(i))
            Next
        End If
        Process.Start(path & "Dashbox.exe")
    End Sub

    Shared Function DownloadString(ByVal address As String)
        Dim client As WebClient = New WebClient()
        Dim reply As String = client.DownloadString(address)
        Return reply
    End Function

End Class