Imports System.Net

Public Class Form1

    Dim cdn As String = DownloadString("https://docs.google.com/document/d/1m41TZWmNuKDwuYOHA2_ZX9J9Gd6gGTTIfJV6DHcjlpI/edit?usp=sharing")

    Function DownloadString(ByVal address As String)
        Dim client As WebClient = New WebClient()
        Dim reply As String = client.DownloadString(address)

        Return reply
    End Function
End Class
