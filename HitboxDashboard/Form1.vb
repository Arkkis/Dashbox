Imports System
Imports System.Net
Imports System.Threading

Public Class Form1

    Dim dburl As String = DownloadString("https://googledrive.com/host/0BwXzp8oa9Tx4eU93R0xUNkFHa00/dashboard.txt")
    Dim data, status, title, game, followers, viewers As String
    Dim dataArray As Array

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        data = DownloadString(dburl + "?needed")
        UpdateUI(data)
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        data = DownloadString(dburl + "?needed")
        e.Result = data
        Thread.Sleep(5000)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        data = e.Result
        DataLabel.Text = e.Result
        UpdateUI(data)
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Function DownloadString(ByVal address As String)
        Dim client As WebClient = New WebClient()
        Dim reply As String = client.DownloadString(address)

        Return reply
    End Function

    Function UpdateUI(data As String)
        dataArray = Split(data, "||")
        status = dataArray(0)
        title = dataArray(1)
        game = dataArray(2)
        followers = dataArray(3)
        viewers = dataArray(4)
        StatusLabel.Text = status
        TitleLabel.Text = title
        GameLabel.Text = game
        FollowersLabel.Text = followers
        ViewersLabel.Text = viewers
    End Function

End Class
