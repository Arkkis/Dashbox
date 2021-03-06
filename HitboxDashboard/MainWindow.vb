﻿'Copyright (C) 2014  Joni Nieminen

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

Imports System
Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Threading.Thread
Imports System.Drawing.Color
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports System.ComponentModel
'Imports Alchemy
'Imports Alchemy.Classes

Public Class MainWindow

    'Dim vurl As String = DownloadString("https://googledrive.com/host/0BwXzp8oa9Tx4eU93R0xUNkFHa00/version.txt")
    Dim remote_ver As String = DownloadString("https://googledrive.com/host/0BwXzp8oa9Tx4eU93R0xUNkFHa00/version.txt")
    Public version As Double = 20140609035100, remote_version As Double = Double.Parse(remote_ver)

    Dim data, status, title, game, followers, viewers, AuthToken, buf, login, nick, pass, server, chan, settitle, setgame As String
    Dim lastchan = "", lastgame = "", lasttitle = "", passcode = "Dashboxx", inifile = Application.StartupPath & "\conf.ini"
    Dim dataArray As Array

    Dim port As Integer, connectionclose = 0, found = 0, dataupdate = 1
    Dim input As TextReader
    Dim output As TextWriter

    Dim sr As StreamReader = Nothing
    Dim AutoCompleteGame As New AutoCompleteStringCollection



    Public Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim ChatSocket As New WebSocketClient("ws://54.204.156.212/socket.io/1/websocket/j26ULqsLWYoTIRtXXKMC")

        'ChatSocket.Connect()
        'ChatSocket.Send("dada")

        'While 1

        'End While

        If Not File.Exists(inifile) Then
            Try
                Dim fs As FileStream
                fs = File.OpenWrite(inifile)
                fs.Close()
            Catch ex As UnauthorizedAccessException
                MsgBox("Couldn't create conf.ini! Try running program as administrator!")
            End Try
        End If

        If Not ReadINI(inifile, "Settings", "channel") = "" Then
            TextBox_Channel.Text = ReadINI(inifile, "Settings", "channel")
        End If

        TextBox_Username.Text = ReadINI(inifile, "Settings", "username")
        TextBox_Password.Text = AES_Decrypt(ReadINI(inifile, "Settings", "password"), passcode)

        Check_Update()
        Load_Gamelist()
        Worker_UpdateUI.RunWorkerAsync()
    End Sub

    Private Sub Button_Save_Click(sender As Object, e As EventArgs) Handles Button_Save.Click

        chan = TextBox_Channel.Text
        nick = TextBox_Username.Text
        pass = TextBox_Password.Text

        If Not chan = ReadINI(inifile, "Settings", "channel") And Not chan = "" Then
            WriteINI(inifile, "Settings", "channel", chan)
        End If

        If Not nick = ReadINI(inifile, "Settings", "username") And Not nick = "" Then
            WriteINI(inifile, "Settings", "username", nick)
        End If

        If Not AES_Encrypt(pass, passcode) = ReadINI(inifile, "Settings", "password") And Not pass = "" Then
            WriteINI(inifile, "Settings", "password", AES_Encrypt(pass, passcode))
        End If

        MsgBox("Login details saved!")
    End Sub

    Private Sub Worker_UpdateUI_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles Worker_UpdateUI.DoWork
        chan = TextBox_Channel.Text

        If Not chan = lastchan Then
            dataupdate = 1
            lastchan = chan
        Else
            dataupdate = 0
        End If

        If chan.Trim.Length Then
            data = DownloadString("http://www.hitbox.tv/api/media/live/" & chan & "/list")
        Else
            data = ""
        End If
        e.Result = data
        Sleep(500)
    End Sub

    Private Sub Worker_UpdateUI_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles Worker_UpdateUI.RunWorkerCompleted
        data = e.Result

        If Check_Data(data) = 1 Then
            Button_Chat.Enabled = True
            UpdateUI(data)
        Else
            Label_Status.ForeColor = Red
            Label_Status.Text = "Channel not found!"
            TextBox_Title.Text = ""
            TextBox_Game.Text = ""
            Label_ViewerCount.Text = "0"
            Label_FollowerCount.Text = "0"
            Button_Chat.Enabled = False
            Button_UpdateData.Enabled = False
            Button_UpdateWithGlados.Enabled = False
        End If

        If Worker_UpdateUI.IsBusy = False Then
            Worker_UpdateUI.RunWorkerAsync()
        End If
    End Sub

    Public Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
        End Try
    End Function

    Public Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
        End Try
    End Function

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

        status = StringBetween(data, """media_is_live"":""", """")
        title = StringBetween(data, """media_status"":""", """")
        game = StringBetween(data, """category_name"":""", """")
        followers = StringBetween(data, """followers"":""", """")
        viewers = StringBetween(data, """media_views"":""", """")
        Label_FollowerCount.Text = followers
        Label_ViewerCount.Text = viewers
        chan = TextBox_Channel.Text.ToLower

        If Not TextBox_Username.Text = "" And Not TextBox_Password.Text = "" Then
            Button_UpdateData.Enabled = True
            Button_UpdateWithGlados.Enabled = True
        End If

        If dataupdate = 1 Then
            If Not game = "" Then
                TextBox_Game.Text = game
                lastgame = game
            End If

            If Not title = "" Then
                TextBox_Title.Text = title
                lasttitle = title
            End If
        End If

        If status = "1" Then
            Label_Status.Text = "Online"
            Label_Status.ForeColor = Green
        Else
            Label_Status.Text = "Offline"
            Label_Status.ForeColor = Red
        End If

    End Function

    Function Check_Data(data As String)
        If Not data = "" And Not data = "no_media_found" Then
            found = 1
        Else
            found = 0
        End If

        Return found
    End Function

    Function Check_Update()

        If version < remote_version And Not IsNothing(remote_version) Then
            Try
                My.Computer.Network.DownloadFile("https://googledrive.com/host/0BwXzp8oa9Tx4eU93R0xUNkFHa00/Updater.exe", Application.StartupPath & "\Updater.exe", "", "", False, 3000, True)
            Catch ex As WebException
                MsgBox("Can't access Updater.exe! File might be read-only! Closing Dashbox..")
                Application.Exit()
            End Try

            MsgBox("New version available!")

            Try
                Process.Start(Application.StartupPath & "\Updater.exe")
            Catch ex As Win32Exception
                MsgBox("No rights to start Updater.exe")
                Application.Exit()
            End Try

            Application.Exit()
            Return True
        Else
            Return False
        End If
    End Function

    Function Load_Gamelist()
        If File.Exists(Application.StartupPath & "\db.txt") Then
            sr = File.OpenText(Application.StartupPath & "\db.txt")

            While Not sr.EndOfStream
                AutoCompleteGame.Add(sr.ReadLine)
            End While

            sr.Close()

            TextBox_Game.AutoCompleteCustomSource = AutoCompleteGame
            TextBox_Game.AutoCompleteSource = AutoCompleteSource.CustomSource
            TextBox_Game.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Return 1
        Else
            Return 0
        End If
    End Function

    Function UpdateData()
        Me.Enabled = False
        Dim titledone = 0, gamedone = 0
        nick = TextBox_Username.Text
        pass = TextBox_Password.Text
        settitle = TextBox_Title.Text
        setgame = TextBox_Game.Text

        If found = 1 Then
            If UpdateTitle(settitle) = True Then
                titledone = 1
            End If

            If TypeOf GetGame(setgame) Is JObject Then
                If UpdateGame(setgame) Then
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
        End If
        Me.Enabled = True
    End Function

    Function UpdateWithGlados()
        Me.Enabled = False

        nick = TextBox_Username.Text
        pass = TextBox_Password.Text
        server = "irc.glados.tv"
        port = Convert.ToInt32("6667")
        settitle = TextBox_Title.Text
        setgame = TextBox_Game.Text
        connectionclose = 0

        If found = 1 And TypeOf GetGame(setgame) Is JObject Then
            Dim sock As New System.Net.Sockets.TcpClient()

            sock.SendTimeout = 10000
            sock.ReceiveTimeout = 10000

            Try
                sock.Connect(server, port)
            Catch ex As Exception
                connectionclose = 1
                MsgBox("Couldn't connect to GLaDOS server in given time! (Timeout: 10sec)")
            End Try

            If Not connectionclose = 1 Then
                input = New System.IO.StreamReader(sock.GetStream())
                output = New System.IO.StreamWriter(sock.GetStream())
                output.Write("PASS " & pass & vbCr & vbLf & "NICK " & nick & vbCr & vbLf & "USER " & nick & " 0 * :" & nick & vbCr & vbLf)
                output.Flush()

                Try
                    buf = input.ReadLine()
                Catch ex As Exception
                    connectionclose = 1
                    MsgBox("Couldn't connect to GLaDOS server in given time! (Timeout: 10sec)")
                    'Me.Enabled = True
                    'Return 0
                End Try

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

                    If buf.Split(" "c)(1) = "353" Then
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
                        connectionclose = 1
                    End If

                    If buf.Split(" "c)(1) = "464" Then
                        MsgBox("Username and password does not match!")
                        connectionclose = 1
                    End If

                    If connectionclose = 1 Then
                        sock.Close()
                    Else
                        buf = input.ReadLine()
                    End If
                End While
            End If
        Else
            MsgBox("Channel or game is not recognized!")
        End If

        Me.Enabled = True
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

        Try
            Dim stream As Stream = request.GetResponse().GetResponseStream()
            Dim reader As New StreamReader(stream)
            Dim response As String = String.Empty
            response = reader.ReadLine()

            Dim array As Array = Split(response, """")

            Return array(3)
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Function UpdateTitle(title As String)

        chan = TextBox_Channel.Text
        nick = TextBox_Username.Text
        pass = TextBox_Password.Text

        Dim AuthToken = GetAuth(nick, pass)

        If AuthToken = "" Then
            MsgBox("Couldn't authenticate to change title!")
            Return False
        End If

        Dim request = WebRequest.CreateHttp("http://www.hitbox.tv/api/media/live/" & chan & "/list?authToken=" & AuthToken & "&filter=recent&hiddenOnly=false&limit=1&nocache=true&publicOnly=false&yt=false")
        request.Headers.Add("Accept-Encoding", "gzip,deflate")
        request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
        request.Timeout = 10000

        Dim user As JObject = Nothing

        Try
            Dim response = request.GetResponse()
            Dim readStream As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
            user = JObject.Parse(readStream.ReadToEnd())
        Catch ex As Exception
            Return False
        End Try

        Dim livestreams = user.Value(Of JArray)("livestream")
        If livestreams.Count > 0 Then
            user("livestream")(0)("media_status") = title
        End If

        Dim toWrite = user.ToString()

        Dim request2 = WebRequest.CreateHttp("http://www.hitbox.tv/api/media/live/" & chan & "/list?authToken=" & AuthToken & "&filter=recent&hiddenOnly=false&limit=1&nocache=true&publicOnly=false&yt=false")
        request2.Method = "PUT"
        request2.ContentType = "application/json"
        request2.Headers.Add("Accept-Encoding", "gzip,deflate")
        request2.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
        request2.Timeout = 10000
        Dim bytes As Byte() = Encoding.ASCII.GetBytes(toWrite)
        request2.ContentLength = bytes.Length
        Dim os As Stream = request2.GetRequestStream()
        os.Write(bytes, 0, bytes.Length)
        'Push it out there
        os.Close()
        Try
            Dim response = request2.GetResponse()
            Dim readStream As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
            Return True
        Catch ex As Exception
            MsgBox("No access to update title!")
            Return False
        End Try

    End Function

    Function UpdateGame(game As String)

        chan = TextBox_Channel.Text
        nick = TextBox_Username.Text
        pass = TextBox_Password.Text

        Dim AuthToken = GetAuth(nick, pass)

        If AuthToken = "" Then
            MsgBox("Couldn't authenticate to change game!")
            Return False
        End If

        Dim user As JObject = Nothing
        Dim request = WebRequest.CreateHttp("http://www.hitbox.tv/api/media/live/" & chan & "/list?authToken=" & AuthToken & "&filter=recent&hiddenOnly=false&limit=1&nocache=true&publicOnly=false&yt=false")
        request.Headers.Add("Accept-Encoding", "gzip,deflate")
        request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
        request.Timeout = 10000

        Try
            Dim response = request.GetResponse()
            Dim readStream As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
            user = JObject.Parse(readStream.ReadToEnd())
        Catch ex As Exception
            MsgBox("Couldn't update game! Check it for correct spelling!")
            Return False
        End Try

        Dim livestreams = user.Value(Of JArray)("livestream")
        If livestreams.Count > 0 Then
            user("livestream")(0)("media_category_id") = GetGame(game)
        End If

        Dim toWrite = user.ToString()

        Dim request2 = WebRequest.CreateHttp("http://www.hitbox.tv/api/media/live/" & chan & "/list?authToken=" & AuthToken & "&filter=recent&hiddenOnly=false&limit=1&nocache=true&publicOnly=false&yt=false")
        request2.Method = "PUT"
        request2.ContentType = "application/json"
        request2.Headers.Add("Accept-Encoding", "gzip,deflate")
        request2.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
        request2.Timeout = 10000
        Dim bytes As Byte() = Encoding.ASCII.GetBytes(toWrite)
        request2.ContentLength = bytes.Length
        Dim os As Stream = request2.GetRequestStream()
        os.Write(bytes, 0, bytes.Length)
        os.Close()

        Try
            Dim response = request2.GetResponse()
            Dim readStream As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
        Catch ex As Exception
            MsgBox("No access to update game!")
            Return False
        End Try

        Return True
    End Function

    Function GetGame(game As String)
        If game = "" Then
            Return False
        End If

        Dim request = WebRequest.CreateHttp("http://www.hitbox.tv/api/games?q=" & HttpUtility.UrlEncode(game) & "&limit=100")
        request.Headers.Add("Accept-Encoding", "gzip,deflate")
        request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
        request.Timeout = 10000

        Try
            Dim response = request.GetResponse()
            Dim readStream As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
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
        Catch ex As Exception
            MsgBox("Couldn't update game! Check it for correct spelling!")
            Return False
        End Try
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Shared Function GetPrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Shared Function WritePrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Boolean
    End Function

    Public Shared Function ReadINI(ByVal File As String, ByVal Section As String, ByVal Key As String) As String
        Dim sb As New StringBuilder(500)
        GetPrivateProfileString(Section, Key, "", sb, sb.Capacity, File)
        Return sb.ToString
    End Function

    Public Shared Sub WriteINI(ByVal File As String, ByVal Section As String, ByVal Key As String, ByVal Value As String)
        WritePrivateProfileString(Section, Key, Value, File)
    End Sub

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

    Private Sub TextBox_Channel_MouseHover(sender As Object, e As EventArgs) Handles TextBox_Channel.MouseHover
        ToolTip_Channel.SetToolTip(TextBox_Channel, "Type channel here you want to control.")
    End Sub

    Private Sub TextBox_Title_MouseHover(sender As Object, e As EventArgs) Handles TextBox_Title.MouseHover
        ToolTip_Title.SetToolTip(TextBox_Title, "Type title to change it.")
    End Sub

    Private Sub TextBox_Game_MouseHover(sender As Object, e As EventArgs) Handles TextBox_Game.MouseHover
        ToolTip_Game.SetToolTip(TextBox_Game, "Type game you are going to play. (Autocomplete ON)")
    End Sub

    Private Sub TextBox_Username_MouseHover(sender As Object, e As EventArgs) Handles TextBox_Username.MouseHover
        ToolTip_Username.SetToolTip(TextBox_Username, "Type your Hitbox username here.")
    End Sub

    Private Sub TextBox_Password_MouseHover(sender As Object, e As EventArgs) Handles TextBox_Password.MouseHover
        ToolTip_Password.SetToolTip(TextBox_Password, "Type your Hitbox password here.")
    End Sub

    'Private Function OnReceive(context As UserContext) As OnEventDelegate
    '    Throw New NotImplementedException
    'End Function

    'Private Function OnSend() As OnEventDelegate
    '    Throw New NotImplementedException
    'End Function

End Class
