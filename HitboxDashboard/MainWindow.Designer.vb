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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.Worker_UpdateUI = New System.ComponentModel.BackgroundWorker()
        Me.Label_Status = New System.Windows.Forms.Label()
        Me.Label_Followers = New System.Windows.Forms.Label()
        Me.Label_Viewers = New System.Windows.Forms.Label()
        Me.TextBox_Password = New System.Windows.Forms.TextBox()
        Me.TextBox_Nick = New System.Windows.Forms.TextBox()
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
        Me.SuspendLayout()
        '
        'Worker_UpdateUI
        '
        '
        'Label_Status
        '
        Me.Label_Status.AutoSize = True
        Me.Label_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Status.ForeColor = System.Drawing.Color.Red
        Me.Label_Status.Location = New System.Drawing.Point(207, 9)
        Me.Label_Status.Name = "Label_Status"
        Me.Label_Status.Size = New System.Drawing.Size(70, 24)
        Me.Label_Status.TabIndex = 1
        Me.Label_Status.Text = "Offline"
        Me.Label_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Followers
        '
        Me.Label_Followers.AutoSize = True
        Me.Label_Followers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Followers.Location = New System.Drawing.Point(144, 42)
        Me.Label_Followers.Name = "Label_Followers"
        Me.Label_Followers.Size = New System.Drawing.Size(79, 16)
        Me.Label_Followers.TabIndex = 4
        Me.Label_Followers.Text = "Followers:"
        Me.Label_Followers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label_Viewers
        '
        Me.Label_Viewers.AutoSize = True
        Me.Label_Viewers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Viewers.Location = New System.Drawing.Point(13, 42)
        Me.Label_Viewers.Name = "Label_Viewers"
        Me.Label_Viewers.Size = New System.Drawing.Size(67, 16)
        Me.Label_Viewers.TabIndex = 5
        Me.Label_Viewers.Text = "Viewers:"
        '
        'TextBox_Password
        '
        Me.TextBox_Password.Location = New System.Drawing.Point(72, 152)
        Me.TextBox_Password.Name = "TextBox_Password"
        Me.TextBox_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Password.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Password.TabIndex = 9
        '
        'TextBox_Nick
        '
        Me.TextBox_Nick.Location = New System.Drawing.Point(72, 126)
        Me.TextBox_Nick.Name = "TextBox_Nick"
        Me.TextBox_Nick.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Nick.TabIndex = 8
        '
        'TextBox_Game
        '
        Me.TextBox_Game.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.TextBox_Game.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox_Game.Location = New System.Drawing.Point(72, 100)
        Me.TextBox_Game.Name = "TextBox_Game"
        Me.TextBox_Game.Size = New System.Drawing.Size(205, 20)
        Me.TextBox_Game.TabIndex = 7
        '
        'TextBox_Title
        '
        Me.TextBox_Title.Location = New System.Drawing.Point(72, 74)
        Me.TextBox_Title.Name = "TextBox_Title"
        Me.TextBox_Title.Size = New System.Drawing.Size(205, 20)
        Me.TextBox_Title.TabIndex = 6
        '
        'Label_SetTitle
        '
        Me.Label_SetTitle.AutoSize = True
        Me.Label_SetTitle.Location = New System.Drawing.Point(12, 77)
        Me.Label_SetTitle.Name = "Label_SetTitle"
        Me.Label_SetTitle.Size = New System.Drawing.Size(27, 13)
        Me.Label_SetTitle.TabIndex = 10
        Me.Label_SetTitle.Text = "Title"
        '
        'Label_SetGame
        '
        Me.Label_SetGame.AutoSize = True
        Me.Label_SetGame.Location = New System.Drawing.Point(13, 103)
        Me.Label_SetGame.Name = "Label_SetGame"
        Me.Label_SetGame.Size = New System.Drawing.Size(35, 13)
        Me.Label_SetGame.TabIndex = 11
        Me.Label_SetGame.Text = "Game"
        '
        'Label_SetNick
        '
        Me.Label_SetNick.AutoSize = True
        Me.Label_SetNick.Location = New System.Drawing.Point(13, 129)
        Me.Label_SetNick.Name = "Label_SetNick"
        Me.Label_SetNick.Size = New System.Drawing.Size(55, 13)
        Me.Label_SetNick.TabIndex = 12
        Me.Label_SetNick.Text = "Nickname"
        '
        'Label_SetPassword
        '
        Me.Label_SetPassword.AutoSize = True
        Me.Label_SetPassword.Location = New System.Drawing.Point(13, 155)
        Me.Label_SetPassword.Name = "Label_SetPassword"
        Me.Label_SetPassword.Size = New System.Drawing.Size(53, 13)
        Me.Label_SetPassword.TabIndex = 13
        Me.Label_SetPassword.Text = "Password"
        '
        'Button_UpdateData
        '
        Me.Button_UpdateData.Enabled = False
        Me.Button_UpdateData.Location = New System.Drawing.Point(178, 126)
        Me.Button_UpdateData.Name = "Button_UpdateData"
        Me.Button_UpdateData.Size = New System.Drawing.Size(99, 46)
        Me.Button_UpdateData.TabIndex = 14
        Me.Button_UpdateData.Text = "Update"
        Me.Button_UpdateData.UseVisualStyleBackColor = True
        '
        'TextBox_Channel
        '
        Me.TextBox_Channel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBox_Channel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_Channel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Channel.Location = New System.Drawing.Point(16, 7)
        Me.TextBox_Channel.Name = "TextBox_Channel"
        Me.TextBox_Channel.Size = New System.Drawing.Size(185, 29)
        Me.TextBox_Channel.TabIndex = 15
        '
        'Label_ViewerCount
        '
        Me.Label_ViewerCount.AutoSize = True
        Me.Label_ViewerCount.Location = New System.Drawing.Point(82, 44)
        Me.Label_ViewerCount.Name = "Label_ViewerCount"
        Me.Label_ViewerCount.Size = New System.Drawing.Size(13, 13)
        Me.Label_ViewerCount.TabIndex = 16
        Me.Label_ViewerCount.Text = "0"
        '
        'Label_FollowerCount
        '
        Me.Label_FollowerCount.AutoSize = True
        Me.Label_FollowerCount.Location = New System.Drawing.Point(225, 44)
        Me.Label_FollowerCount.Name = "Label_FollowerCount"
        Me.Label_FollowerCount.Size = New System.Drawing.Size(13, 13)
        Me.Label_FollowerCount.TabIndex = 17
        Me.Label_FollowerCount.Text = "0"
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 181)
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
        Me.Controls.Add(Me.TextBox_Nick)
        Me.Controls.Add(Me.TextBox_Password)
        Me.Controls.Add(Me.Label_Viewers)
        Me.Controls.Add(Me.Label_Followers)
        Me.Controls.Add(Me.Label_Status)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainWindow"
        Me.Text = "Dashbox"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Worker_UpdateUI As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label_Status As System.Windows.Forms.Label
    Friend WithEvents Label_Followers As System.Windows.Forms.Label
    Friend WithEvents Label_Viewers As System.Windows.Forms.Label
    Friend WithEvents TextBox_Password As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Nick As System.Windows.Forms.TextBox
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

End Class
