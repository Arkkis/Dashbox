Imports System
Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Threading.Thread
Imports System.Drawing.Color
Imports Newtonsoft.Json.Linq
Imports System.Text

Public Class MainWindow

    Dim vurl As String = DownloadString("https://googledrive.com/host/0BwXzp8oa9Tx4eU93R0xUNkFHa00/version.txt")
    Dim remote_ver As String = DownloadString(vurl)
    Dim version As Double = 20140515000300, remote_version As Double = Double.Parse(remote_ver)

    Dim data, status, title, game, followers, viewers, AuthToken, buf, login, nick, pass, server, chan, settitle, setgame As String
    Dim lastgame As String = "", lasttitle As String = ""
    Dim dataArray As Array

    Dim port As Integer, connectionclose As Integer = 0, found As Integer = 0
    Dim input As TextReader
    Dim output As TextWriter

    Dim sr As StreamReader = Nothing
    Dim AutoCompleteGame As New AutoCompleteStringCollection

    Public Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If version < remote_version And Not IsNothing(remote_version) Then
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
        If Not chan = "" Then
            data = DownloadString("http://www.hitbox.tv/api/media/live/" & chan & "/list")
        Else
            data = ""
        End If
        e.Result = data
        Sleep(2500)
    End Sub

    Private Sub Worker_UpdateUI_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles Worker_UpdateUI.RunWorkerCompleted
        data = e.Result

        If DataCheck(data) = 1 Then
            Button_Chat.Enabled = True
            UpdateUI(data)
        Else
            Button_Chat.Enabled = False
        End If

        If Not Worker_UpdateUI.IsBusy Then
            Worker_UpdateUI.RunWorkerAsync()
        End If
    End Sub

    Function StringBetween(str As String, start As String, ending As String)
        Dim reply As String
        Dim parse1, parse2 As Array
        parse1 = Split(str, start)
        If UBound(parse1) > 0 Then
            parse2 = Split(parse1(1), ending)
            reply = parse2(0)
        Else
            reply = ""
        End If
        Return reply
    End Function

    Function DownloadString(ByVal address As String)
        Dim client As WebClient = New WebClient()
        Try
            Dim reply As String = client.DownloadString(address)
            Return reply
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Function UpdateUI(data As String)

        If DataCheck(data) = 1 Then
            status = StringBetween(data, """media_is_live"":""", """")
            title = StringBetween(data, """media_status"":""", """")
            game = StringBetween(data, """category_name"":""", """")
            followers = StringBetween(data, """followers"":""", """")
            viewers = StringBetween(data, """media_views"":""", """")
            Label_FollowerCount.Text = followers
            Label_ViewerCount.Text = viewers
            chan = TextBox_Channel.Text.ToLower

            If Not TextBox_Nick.Text = "" And Not TextBox_Password.Text = "" Then
                Button_UpdateData.Enabled = True
                Button_UpdateWithGlados.Enabled = True
            End If

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
        Else
            Label_FollowerCount.Text = 0
            Label_ViewerCount.Text = 0

            TextBox_Title.Text = ""
            TextBox_Game.Text = ""
            Button_UpdateData.Enabled = False
            Button_UpdateWithGlados.Enabled = False
        End If

        Return 1
    End Function

    Function DataCheck(data As String)
        If Not data = "" Then
            found = 1
            Debug.WriteLine("Found 1")
        Else
            found = 0
            Debug.WriteLine("Found 0")
        End If

        Return found
    End Function

    Function UpdateData()
        Dim titledone = 0, gamedone = 0
        If found = 1 Then
            If UpdateTitle(TextBox_Nick.Text, TextBox_Title.Text) Then
                titledone = 1
            End If

            If Not IsNumeric(GetGame(TextBox_Game.Text)) Then
                If UpdateGame(TextBox_Nick.Text, TextBox_Game.Text) Then
                    gamedone = 1
                End If
            End If

            If titledone = 1 And gamedone = 1 Then
                MsgBox("Game and Title updated!")
            ElseIf titledone = 1 Then
                MsgBox("Title updated! Couldn't update game!")
            ElseIf gamedone = 1 Then
                MsgBox("Game updated! Couldn't update title!")
            ElseIf titledone = 0 And gamedone = 0 Then
                MsgBox("Nothing was updated!")
            End If
            Return 1
        Else
            Return 0
        End If

    End Function

    Function UpdateWithGlados()
        If found = 1 Then

            If Not IsNumeric(GetGame(TextBox_Game.Text)) Then

                Button_UpdateData.Enabled = False
                Button_UpdateWithGlados.Enabled = False

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

                        Debug.WriteLine(buf)



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
                            If buf.Contains("GLaDOS") Then
                                output.Write("PRIVMSG " & "#" & chan & " :!title " & settitle & vbCr & vbLf)
                                output.Flush()
                                output.Write("PRIVMSG " & "#" & chan & " :!game " & setgame & vbCr & vbLf)
                                output.Flush()
                                output.Write("QUIT :Disconnected" & vbCr & vbLf)
                                output.Flush()
                                MsgBox("Game and Title updated!")
                            Else
                                MsgBox("GLaDOS is not in selected channel!")
                            End If
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
                Button_UpdateWithGlados.Enabled = True
                Button_UpdateData.Enabled = True
                Return 1
            End If
        Else
            Return 0
        End If
    End Function

    Public Function GetAuth(username As String, password As String) As String
        Dim request As HttpWebRequest = DirectCast(WebRequest.Create("http://api.hitbox.tv/auth/token"), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"
        Dim postData As String = "login=" & username & "&pass=" & password & "&app=desktop"
        request.ContentLength = postData.Length

        Dim writer As New StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII)
        writer.Write(postData)
        writer.Close()

        Dim stream As Stream = request.GetResponse().GetResponseStream()
        Dim reader As New StreamReader(stream)
        Dim response As String = String.Empty
        response = reader.ReadLine()

        Dim array As Array = Split(response, """")

        Return array(3)
    End Function

    Function UpdateTitle(username As String, title As String)
        Dim AuthToken = GetAuth(TextBox_Nick.Text, TextBox_Password.Text)
        Dim request = WebRequest.CreateHttp("http://www.hitbox.tv/api/media/live/" & username & "/list?authToken=" & AuthToken & "&filter=recent&hiddenOnly=false&limit=1&nocache=true&publicOnly=false&yt=false")
        request.Headers.Add("Accept-Encoding", "gzip,deflate")
        request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate

        Dim user As JObject = Nothing
        Using response = request.GetResponse()
            Using readStream As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                user = JObject.Parse(readStream.ReadToEnd())
            End Using
        End Using

        Dim livestreams = user.Value(Of JArray)("livestream")
        If livestreams.Count > 0 Then
            user("livestream")(0)("media_status") = title
        End If

        Dim toWrite = user.ToString()

        Dim request2 = WebRequest.CreateHttp("http://www.hitbox.tv/api/media/live/" & username & "/list?authToken=" & AuthToken & "&filter=recent&hiddenOnly=false&limit=1&nocache=true&publicOnly=false&yt=false")
        request2.Method = "PUT"
        request2.ContentType = "application/json"
        request2.Headers.Add("Accept-Encoding", "gzip,deflate")
        request2.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
        Dim bytes As Byte() = Encoding.ASCII.GetBytes(toWrite)
        request2.ContentLength = bytes.Length
        Dim os As Stream = request2.GetRequestStream()
        os.Write(bytes, 0, bytes.Length)
        'Push it out there
        os.Close()
        Using response = request2.GetResponse()
            Using readStream As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                Return True
            End Using
        End Using

    End Function

    Function UpdateGame(username As String, game As String)
        Dim AuthToken = GetAuth(TextBox_Nick.Text, TextBox_Password.Text)
        Dim user As JObject = Nothing
        Dim request = WebRequest.CreateHttp("http://www.hitbox.tv/api/media/live/" & username & "/list?authToken=" & AuthToken & "&filter=recent&hiddenOnly=false&limit=1&nocache=true&publicOnly=false&yt=false")
        request.Headers.Add("Accept-Encoding", "gzip,deflate")
        request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate

        Using response = request.GetResponse()
            Using readStream As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                user = JObject.Parse(readStream.ReadToEnd())
            End Using
        End Using

        Dim livestreams = user.Value(Of JArray)("livestream")
        If livestreams.Count > 0 Then
            user("livestream")(0)("media_category_id") = GetGame(game)
        End If

        Dim toWrite = user.ToString()

        Dim request2 = WebRequest.CreateHttp("http://www.hitbox.tv/api/media/live/" & username & "/list?authToken=" & AuthToken & "&filter=recent&hiddenOnly=false&limit=1&nocache=true&publicOnly=false&yt=false")
        request2.Method = "PUT"
        request2.ContentType = "application/json"
        request2.Headers.Add("Accept-Encoding", "gzip,deflate")
        request2.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
        Dim bytes As Byte() = Encoding.ASCII.GetBytes(toWrite)
        request2.ContentLength = bytes.Length
        Dim os As Stream = request2.GetRequestStream()
        os.Write(bytes, 0, bytes.Length)
        os.Close()
        Using response = request2.GetResponse()
            Using readStream As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                Return True
            End Using
        End Using

    End Function

    Function GetGame(game As String)
        Dim request = WebRequest.CreateHttp("http://www.hitbox.tv/api/games?q=" & HttpUtility.UrlEncode(game) & "&limit=100")
        request.Headers.Add("Accept-Encoding", "gzip,deflate")
        request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate

        Using response = request.GetResponse()
            Using readStream As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                Dim json = JObject.Parse(readStream.ReadToEnd()).Value(Of JArray)("categories")

                For i As Integer = 0 To json.Count

                    If json.Count > 0 Then
                        If json.Item(i)("category_name").ToString.Equals(game) Then
                            Return json.Item(i)
                        End If
                    Else
                        Return 0
                    End If
                Next

            End Using
        End Using
    End Function

    Private Sub UpdateDataButton_Click(sender As Object, e As EventArgs) Handles Button_UpdateData.Click
        UpdateData()
    End Sub

    Private Sub Label_Status_Click(sender As Object, e As EventArgs) Handles Label_Status.Click
        If found = 1 Then
            Process.Start("http://www.hitbox.tv/" & chan)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button_UpdateWithGlados.Click
        UpdateWithGlados()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button_Chat.Click
        Process.Start("http://www.hitbox.tv/embedchat/" & chan)
    End Sub
End Class
