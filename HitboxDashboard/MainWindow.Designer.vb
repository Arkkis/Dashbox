<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.Worker_UpdateUI = New System.ComponentModel.BackgroundWorker()
        Me.Label_Status = New System.Windows.Forms.Label()
        Me.Label_Followers = New System.Windows.Forms.Label()
        Me.Label_Viewers = New System.Windows.Forms.Label()
        Me.TextBox_Password = New System.Windows.Forms.TextBox()
        Me.TextBox_Username = New System.Windows.Forms.TextBox()
        Me.TextBox_Game = New System.Windows.Forms.TextBox()
        Me.TextBox_Title = New System.Windows.Forms.TextBox()
        Me.Label_SetTitle = New System.Windows.Forms.Label()
        Me.Label_SetGame = New System.Windows.Forms.Label()
        Me.Label_SetNick = New System.Windows.Forms.Label()
        Me.Label_SetPassword = New System.Windows.Forms.Label()
        Me.Button_UpdateData = New System.Windows.Forms.Button()
        Me.TextBox_Channel = New System.Windows.Forms.TextBox()
        Me.Label_ViewerCount = New System.Windows.Forms.Label()
        Me.Label_FollowerCount = New System.Windows.Forms.Label()
        Me.Button_UpdateWithGlados = New System.Windows.Forms.Button()
        Me.Button_Chat = New System.Windows.Forms.Button()
        Me.Button_Save = New System.Windows.Forms.Button()
        Me.ToolTip_Channel = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip_Title = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip_Game = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip_Username = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip_Password = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Worker_UpdateUI
        '
        '
        'Label_Status
        '
        Me.Label_Status.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Status.ForeColor = System.Drawing.Color.Red
        Me.Label_Status.Location = New System.Drawing.Point(12, 9)
        Me.Label_Status.Name = "Label_Status"
        Me.Label_Status.Size = New System.Drawing.Size(207, 22)
        Me.Label_Status.TabIndex = 1
        Me.Label_Status.Text = "Offline"
        Me.Label_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Followers
        '
        Me.Label_Followers.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Followers.Location = New System.Drawing.Point(119, 31)
        Me.Label_Followers.Name = "Label_Followers"
        Me.Label_Followers.Size = New System.Drawing.Size(101, 25)
        Me.Label_Followers.TabIndex = 4
        Me.Label_Followers.Text = "Followers:"
        Me.Label_Followers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Viewers
        '
        Me.Label_Viewers.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Viewers.Location = New System.Drawing.Point(11, 31)
        Me.Label_Viewers.Name = "Label_Viewers"
        Me.Label_Viewers.Size = New System.Drawing.Size(101, 25)
        Me.Label_Viewers.TabIndex = 5
        Me.Label_Viewers.Text = "Viewers:"
        Me.Label_Viewers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox_Password
        '
        Me.TextBox_Password.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Password.Location = New System.Drawing.Point(119, 218)
        Me.TextBox_Password.Name = "TextBox_Password"
        Me.TextBox_Password.Size = New System.Drawing.Size(100, 22)
        Me.TextBox_Password.TabIndex = 5
        Me.TextBox_Password.UseSystemPasswordChar = True
        '
        'TextBox_Username
        '
        Me.TextBox_Username.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Username.Location = New System.Drawing.Point(12, 218)
        Me.TextBox_Username.Name = "TextBox_Username"
        Me.TextBox_Username.Size = New System.Drawing.Size(100, 22)
        Me.TextBox_Username.TabIndex = 4
        '
        'TextBox_Game
        '
        Me.TextBox_Game.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.TextBox_Game.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox_Game.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Game.Location = New System.Drawing.Point(12, 171)
        Me.TextBox_Game.Name = "TextBox_Game"
        Me.TextBox_Game.Size = New System.Drawing.Size(207, 22)
        Me.TextBox_Game.TabIndex = 3
        '
        'TextBox_Title
        '
        Me.TextBox_Title.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Title.Location = New System.Drawing.Point(12, 130)
        Me.TextBox_Title.Name = "TextBox_Title"
        Me.TextBox_Title.Size = New System.Drawing.Size(207, 22)
        Me.TextBox_Title.TabIndex = 2
        '
        'Label_SetTitle
        '
        Me.Label_SetTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_SetTitle.Location = New System.Drawing.Point(12, 114)
        Me.Label_SetTitle.Name = "Label_SetTitle"
        Me.Label_SetTitle.Size = New System.Drawing.Size(207, 13)
        Me.Label_SetTitle.TabIndex = 10
        Me.Label_SetTitle.Text = "Title"
        Me.Label_SetTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_SetGame
        '
        Me.Label_SetGame.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_SetGame.Location = New System.Drawing.Point(12, 155)
        Me.Label_SetGame.Name = "Label_SetGame"
        Me.Label_SetGame.Size = New System.Drawing.Size(207, 13)
        Me.Label_SetGame.TabIndex = 11
        Me.Label_SetGame.Text = "Game"
        Me.Label_SetGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_SetNick
        '
        Me.Label_SetNick.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_SetNick.Location = New System.Drawing.Point(12, 202)
        Me.Label_SetNick.Name = "Label_SetNick"
        Me.Label_SetNick.Size = New System.Drawing.Size(100, 13)
        Me.Label_SetNick.TabIndex = 12
        Me.Label_SetNick.Text = "Username"
        Me.Label_SetNick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_SetPassword
        '
        Me.Label_SetPassword.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_SetPassword.Location = New System.Drawing.Point(119, 202)
        Me.Label_SetPassword.Name = "Label_SetPassword"
        Me.Label_SetPassword.Size = New System.Drawing.Size(100, 13)
        Me.Label_SetPassword.TabIndex = 13
        Me.Label_SetPassword.Text = "Password"
        Me.Label_SetPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button_UpdateData
        '
        Me.Button_UpdateData.Enabled = False
        Me.Button_UpdateData.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_UpdateData.Location = New System.Drawing.Point(12, 246)
        Me.Button_UpdateData.Name = "Button_UpdateData"
        Me.Button_UpdateData.Size = New System.Drawing.Size(207, 24)
        Me.Button_UpdateData.TabIndex = 6
        Me.Button_UpdateData.Text = "Update"
        Me.Button_UpdateData.UseVisualStyleBackColor = True
        '
        'TextBox_Channel
        '
        Me.TextBox_Channel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBox_Channel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_Channel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Channel.Location = New System.Drawing.Point(12, 82)
        Me.TextBox_Channel.Name = "TextBox_Channel"
        Me.TextBox_Channel.Size = New System.Drawing.Size(207, 29)
        Me.TextBox_Channel.TabIndex = 1
        Me.TextBox_Channel.Text = "type channel name here"
        Me.TextBox_Channel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_ViewerCount
        '
        Me.Label_ViewerCount.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ViewerCount.Location = New System.Drawing.Point(12, 56)
        Me.Label_ViewerCount.Name = "Label_ViewerCount"
        Me.Label_ViewerCount.Size = New System.Drawing.Size(100, 23)
        Me.Label_ViewerCount.TabIndex = 16
        Me.Label_ViewerCount.Text = "0"
        Me.Label_ViewerCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_FollowerCount
        '
        Me.Label_FollowerCount.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_FollowerCount.Location = New System.Drawing.Point(119, 56)
        Me.Label_FollowerCount.Name = "Label_FollowerCount"
        Me.Label_FollowerCount.Size = New System.Drawing.Size(100, 23)
        Me.Label_FollowerCount.TabIndex = 17
        Me.Label_FollowerCount.Text = "0"
        Me.Label_FollowerCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button_UpdateWithGlados
        '
        Me.Button_UpdateWithGlados.Enabled = False
        Me.Button_UpdateWithGlados.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_UpdateWithGlados.Location = New System.Drawing.Point(12, 276)
        Me.Button_UpdateWithGlados.Name = "Button_UpdateWithGlados"
        Me.Button_UpdateWithGlados.Size = New System.Drawing.Size(207, 24)
        Me.Button_UpdateWithGlados.TabIndex = 7
        Me.Button_UpdateWithGlados.Text = "Update with GlaDOS"
        Me.Button_UpdateWithGlados.UseVisualStyleBackColor = True
        '
        'Button_Chat
        '
        Me.Button_Chat.Enabled = False
        Me.Button_Chat.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Chat.Location = New System.Drawing.Point(12, 350)
        Me.Button_Chat.Name = "Button_Chat"
        Me.Button_Chat.Size = New System.Drawing.Size(207, 24)
        Me.Button_Chat.TabIndex = 9
        Me.Button_Chat.Text = "Open Chat"
        Me.Button_Chat.UseVisualStyleBackColor = True
        '
        'Button_Save
        '
        Me.Button_Save.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Save.Location = New System.Drawing.Point(12, 321)
        Me.Button_Save.Name = "Button_Save"
        Me.Button_Save.Size = New System.Drawing.Size(207, 23)
        Me.Button_Save.TabIndex = 8
        Me.Button_Save.Text = "Save Login"
        Me.Button_Save.UseVisualStyleBackColor = True
        '
        'ToolTip_Channel
        '
        Me.ToolTip_Channel.AutomaticDelay = 1000
        Me.ToolTip_Channel.IsBalloon = True
        '
        'ToolTip_Title
        '
        Me.ToolTip_Title.AutomaticDelay = 1000
        Me.ToolTip_Title.IsBalloon = True
        '
        'ToolTip_Game
        '
        Me.ToolTip_Game.AutomaticDelay = 1000
        Me.ToolTip_Game.IsBalloon = True
        '
        'ToolTip_Username
        '
        Me.ToolTip_Username.AutomaticDelay = 1000
        Me.ToolTip_Username.IsBalloon = True
        '
        'ToolTip_Password
        '
        Me.ToolTip_Password.AutomaticDelay = 1000
        Me.ToolTip_Password.IsBalloon = True
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(231, 384)
        Me.Controls.Add(Me.Button_Save)
        Me.Controls.Add(Me.Button_Chat)
        Me.Controls.Add(Me.Button_UpdateWithGlados)
        Me.Controls.Add(Me.Label_FollowerCount)
        Me.Controls.Add(Me.Label_ViewerCount)
        Me.Controls.Add(Me.TextBox_Channel)
        Me.Controls.Add(Me.Button_UpdateData)
        Me.Controls.Add(Me.Label_SetPassword)
        Me.Controls.Add(Me.Label_SetNick)
        Me.Controls.Add(Me.Label_SetGame)
        Me.Controls.Add(Me.Label_SetTitle)
        Me.Controls.Add(Me.TextBox_Title)
        Me.Controls.Add(Me.TextBox_Game)
        Me.Controls.Add(Me.TextBox_Username)
        Me.Controls.Add(Me.TextBox_Password)
        Me.Controls.Add(Me.Label_Viewers)
        Me.Controls.Add(Me.Label_Followers)
        Me.Controls.Add(Me.Label_Status)
        Me.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainWindow"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Dashbox 1.2.3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Worker_UpdateUI As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label_Status As System.Windows.Forms.Label
    Friend WithEvents Label_Followers As System.Windows.Forms.Label
    Friend WithEvents Label_Viewers As System.Windows.Forms.Label
    Friend WithEvents TextBox_Password As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Username As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Game As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Title As System.Windows.Forms.TextBox
    Friend WithEvents Label_SetTitle As System.Windows.Forms.Label
    Friend WithEvents Label_SetGame As System.Windows.Forms.Label
    Friend WithEvents Label_SetNick As System.Windows.Forms.Label
    Friend WithEvents Label_SetPassword As System.Windows.Forms.Label
    Friend WithEvents Button_UpdateData As System.Windows.Forms.Button
    Friend WithEvents TextBox_Channel As System.Windows.Forms.TextBox
    Friend WithEvents Label_ViewerCount As System.Windows.Forms.Label
    Friend WithEvents Label_FollowerCount As System.Windows.Forms.Label
    Friend WithEvents Button_UpdateWithGlados As System.Windows.Forms.Button
    Friend WithEvents Button_Chat As System.Windows.Forms.Button
    Friend WithEvents Button_Save As System.Windows.Forms.Button
    Friend WithEvents ToolTip_Channel As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip_Title As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip_Game As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip_Username As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip_Password As System.Windows.Forms.ToolTip

End Class
