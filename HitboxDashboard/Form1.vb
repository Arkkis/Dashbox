Imports System
Imports System.IO
Imports System.Net
Imports System.Threading

Public Class Form1

    Dim dburl As String = DownloadString("https://googledrive.com/host/0BwXzp8oa9Tx4eU93R0xUNkFHa00/dashboard.txt")
    Dim data, status, title, game, followers, viewers As String
    Dim dataArray As Array

    Dim port As Integer, connectionclose As Integer = 0
    Dim buf As String, login, nick As String, pass As String, owner As String, server As String, chan As String, settitle As String, setgame As String
    Dim input As TextReader
    Dim output As TextWriter

    Dim sr As StreamReader = Nothing
    Dim MyContents As New AutoCompleteStringCollection

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If File.Exists(Application.StartupPath & "\db.txt") Then
            sr = File.OpenText(Application.StartupPath & "\db.txt")

            While Not sr.EndOfStream
                MyContents.Add(sr.ReadLine)
            End While

            sr.Close()
        End If

        GameTextBox.AutoCompleteCustomSource = MyContents
        GameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        GameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
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
        TitleTextBox.Text = title
        GameTextBox.Text = game
        FollowersLabel.Text = "Followers: " & followers
        ViewersLabel.Text = "Viewers: " & viewers

        If status = 1 Then
            StatusLabel.Text = "Online"
        Else
            StatusLabel.Text = "Offline"
        End If

    End Function

    Function UpdateData()
        Dim sock As New System.Net.Sockets.TcpClient()

        nick = NickTextBox.Text
        pass = PasswordTextBox.Text
        owner = NickTextBox.Text
        server = "irc.glados.tv"
        port = Convert.ToInt32("6667")
        chan = "#pelilegacy"

        settitle = TitleTextBox.Text
        setgame = GameTextBox.Text

        sock.Connect(server, port)
        If Not sock.Connected Then
            Debug.WriteLine("Failed to connect!")
        Else
            input = New System.IO.StreamReader(sock.GetStream())
            output = New System.IO.StreamWriter(sock.GetStream())

            'Starting USER and NICK login commands 
            'output.Write("PASS " & pass & vbCr & vbLf & "USER " & nick & " 0 * :" & owner & vbCr & vbLf & "NICK " & nick & vbCr & vbLf)
            login = "PASS " & pass & vbCr & vbLf & "NICK " & nick & vbCr & vbLf & "USER " & nick & " 0 * :" & owner & vbCr & vbLf
            Debug.WriteLine(login)
            output.Write(login)
            output.Flush()

            buf = input.ReadLine()
            'lastbuf = ""
            'log = ""
            While connectionclose = 0

                If buf.StartsWith("PING ") Then
                    output.Write(buf.Replace("PING", "PONG") & vbCr & vbLf)
                    output.Flush()
                End If
                If buf(0) <> ":"c Then
                    Continue While
                End If

                If buf.Split(" "c)(1) = "001" Then
                    output.Write("MODE " & nick & " +B" & vbCr & vbLf & "JOIN " & chan & vbCr & vbLf)
                    output.Flush()
                End If

                If buf.Split(" "c)(1) = "366" Then
                    output.Write("PRIVMSG #pelilegacy :!title " & settitle & vbCr & vbLf)
                    output.Flush()
                    output.Write("PRIVMSG #pelilegacy :!game " & setgame & vbCr & vbLf)
                    output.Flush()
                    output.Write("QUIT :Disconnected" & vbCr & vbLf)
                    output.Flush()
                    System.Threading.Thread.Sleep(3000)
                    connectionclose = 1
                End If
                buf = input.ReadLine()
                If connectionclose = 1 Then
                    sock.Close()
                End If
            End While
        End If
    End Function

    Private Sub UpdateDataButton_Click(sender As Object, e As EventArgs) Handles UpdateDataButton.Click
        UpdateData()
    End Sub
End Class
