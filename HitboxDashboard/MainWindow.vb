Imports System
Imports System.IO
Imports System.Net
Imports System.Threading.Thread
Imports System.Drawing.Color

Public Class MainWindow

    Dim dburl As String = DownloadString("https://googledrive.com/host/0BwXzp8oa9Tx4eU93R0xUNkFHa00/dashboard.txt")
    Dim vurl As String = DownloadString("https://googledrive.com/host/0BwXzp8oa9Tx4eU93R0xUNkFHa00/version.txt")
    Dim remote_ver As String = DownloadString(vurl)
    Dim version As Double = 20140511005000, remote_version As Double = Double.Parse(remote_ver)

    Dim data, status, title, game, followers, viewers As String
    Dim lastgame As String = "", lasttitle As String = ""
    Dim dataArray As Array

    Dim port As Integer, connectionclose As Integer = 0, found As Integer = 0
    Dim buf As String, login, nick As String, pass As String, server As String, chan As String, settitle As String, setgame As String
    Dim input As TextReader
    Dim output As TextWriter

    Dim sr As StreamReader = Nothing
    Dim AutoCompleteGame As New AutoCompleteStringCollection

    Public Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If version < remote_version Then
            MsgBox("New version available!")
            Process.Start(Application.StartupPath & "\Updater.exe")
            Close()
        End If

        If File.Exists(Application.StartupPath & "\db.txt") Then
            sr = File.OpenText(Application.StartupPath & "\db.txt")

            While Not sr.EndOfStream
                AutoCompleteGame.Add(sr.ReadLine)
            End While

            sr.Close()
        End If

        TextBox_Game.AutoCompleteCustomSource = AutoCompleteGame
        TextBox_Game.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextBox_Game.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        Worker_UpdateUI.RunWorkerAsync()
    End Sub

    Private Sub Worker_UpdateUI_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles Worker_UpdateUI.DoWork
        chan = TextBox_Channel.Text.ToLower
        data = DownloadString(dburl + "?channel=" & chan)
        e.Result = data
        Sleep(1500)
        'Debug.WriteLine("Finished DoWork... " & chan)
    End Sub

    Private Sub Worker_UpdateUI_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles Worker_UpdateUI.RunWorkerCompleted
        data = e.Result
        'Debug.WriteLine("Found is " & found)
        If DataCheck(data) Then
            UpdateUI(data)
        End If
        'Debug.WriteLine("Finished WorkerCompleted... " & chan)
        If Not Worker_UpdateUI.IsBusy Then
            Worker_UpdateUI.RunWorkerAsync()
        End If
    End Sub

    Function DownloadString(ByVal address As String)
        Dim client As WebClient = New WebClient()
        Dim reply As String = client.DownloadString(address)
        Return reply
    End Function

    Function UpdateUI(data As String)

        'Debug.WriteLine("Starting UI update... " & chan)

        If DataCheck(data) Then
            'Debug.WriteLine("Data found... " & chan)
            dataArray = Split(data, "||")
            status = dataArray(0)
            title = dataArray(1)
            game = dataArray(2)
            followers = dataArray(3)
            viewers = dataArray(4)
            Label_FollowerCount.Text = followers
            Label_ViewerCount.Text = viewers
            chan = TextBox_Channel.Text.ToLower

            If Not TextBox_Nick.Text = "" And Not TextBox_Password.Text = "" Then
                Button_UpdateData.Enabled = True
            End If
            'Debug.WriteLine("Setting found to 1... " & chan)

            If Not lastgame = game Then
                TextBox_Game.Text = game
            End If

            If Not lasttitle = title Then
                TextBox_Title.Text = title
            End If

            lastgame = game
            lasttitle = title

            If status = 1 Then
                Label_Status.Text = "Online"
                Label_Status.ForeColor = Green
            Else
                Label_Status.Text = "Offline"
                Label_Status.ForeColor = Red
            End If

            found = 1
        Else
            Label_FollowerCount.Text = 0
            Label_ViewerCount.Text = 0

            TextBox_Title.Text = ""
            TextBox_Game.Text = ""
            Button_UpdateData.Enabled = False
            'Debug.WriteLine("Setting found to 0... " & chan)
            found = 0
        End If

        Return 1
    End Function

    Function DataCheck(data As String)
        If Not data.Contains("not found") And Not data = "" Then
            found = 1
        Else
            found = 0
        End If

        Return found
    End Function

    Function UpdateData()
        If found = 1 Then

            Button_UpdateData.Enabled = False

            Dim sock As New System.Net.Sockets.TcpClient()

            nick = TextBox_Nick.Text
            pass = TextBox_Password.Text
            server = "irc.glados.tv"
            port = Convert.ToInt32("6667")

            settitle = TextBox_Title.Text
            setgame = TextBox_Game.Text

            sock.Connect(server, port)
            If Not sock.Connected Then
                Debug.WriteLine("Failed to connect!")
            Else
                input = New System.IO.StreamReader(sock.GetStream())
                output = New System.IO.StreamWriter(sock.GetStream())

                'Starting USER and NICK login commands 
                'output.Write("PASS " & pass & vbCr & vbLf & "USER " & nick & " 0 * :" & owner & vbCr & vbLf & "NICK " & nick & vbCr & vbLf)
                login = "PASS " & pass & vbCr & vbLf & "NICK " & nick & vbCr & vbLf & "USER " & nick & " 0 * :" & nick & vbCr & vbLf
                'Debug.WriteLine(login)
                output.Write(login)
                output.Flush()

                buf = input.ReadLine()
                'Debug.WriteLine(buf)
                connectionclose = 0

                While connectionclose = 0

                    If buf.StartsWith("PING ") Then
                        output.Write(buf.Replace("PING", "PONG") & vbCr & vbLf)
                        output.Flush()
                    End If
                    If buf(0) <> ":"c Then
                        Continue While
                    End If

                    If buf.Split(" "c)(1) = "001" Then
                        output.Write("MODE " & nick & " +B" & vbCr & vbLf & "JOIN " & "#" & chan & vbCr & vbLf)
                        output.Flush()
                    End If

                    If buf.Split(" "c)(1) = "366" Then
                        output.Write("PRIVMSG " & "#" & chan & " :!title " & settitle & vbCr & vbLf)
                        output.Flush()
                        output.Write("PRIVMSG " & "#" & chan & " :!game " & setgame & vbCr & vbLf)
                        output.Flush()
                        output.Write("QUIT :Disconnected" & vbCr & vbLf)
                        output.Flush()
                        'System.Threading.Thread.Sleep(3000)
                        connectionclose = 1
                    End If

                    If buf.Split(" "c)(1) = "464" Then
                        MsgBox("Username and password does not match!")
                        connectionclose = 1
                    End If

                    'Debug.WriteLine(buf)
                    If connectionclose = 1 Then
                        sock.Close()
                    Else
                        buf = input.ReadLine()
                    End If
                End While
            End If
            Button_UpdateData.Enabled = True
        End If
        Return 1
    End Function

    Private Sub UpdateDataButton_Click(sender As Object, e As EventArgs) Handles Button_UpdateData.Click
        UpdateData()
    End Sub

    Private Sub Label_Status_Click(sender As Object, e As EventArgs) Handles Label_Status.Click
        If found = 1 Then
            Process.Start("http://www.hitbox.tv/" & chan)
        End If
    End Sub
End Class
