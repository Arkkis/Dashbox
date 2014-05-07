<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.FollowersLabel = New System.Windows.Forms.Label()
        Me.ViewersLabel = New System.Windows.Forms.Label()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.NickTextBox = New System.Windows.Forms.TextBox()
        Me.GameTextBox = New System.Windows.Forms.TextBox()
        Me.TitleTextBox = New System.Windows.Forms.TextBox()
        Me.SetTitleLabel = New System.Windows.Forms.Label()
        Me.SetGameLabel = New System.Windows.Forms.Label()
        Me.SetNickLabel = New System.Windows.Forms.Label()
        Me.SetPasswordLabel = New System.Windows.Forms.Label()
        Me.UpdateDataButton = New System.Windows.Forms.Button()
        Me.ChannelTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        '
        'StatusLabel
        '
        Me.StatusLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusLabel.ForeColor = System.Drawing.Color.Green
        Me.StatusLabel.Location = New System.Drawing.Point(191, 9)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(86, 24)
        Me.StatusLabel.TabIndex = 1
        Me.StatusLabel.Text = "Offline"
        Me.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FollowersLabel
        '
        Me.FollowersLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FollowersLabel.Location = New System.Drawing.Point(141, 40)
        Me.FollowersLabel.Name = "FollowersLabel"
        Me.FollowersLabel.Size = New System.Drawing.Size(136, 20)
        Me.FollowersLabel.TabIndex = 4
        Me.FollowersLabel.Text = "Followers"
        Me.FollowersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ViewersLabel
        '
        Me.ViewersLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewersLabel.Location = New System.Drawing.Point(13, 42)
        Me.ViewersLabel.Name = "ViewersLabel"
        Me.ViewersLabel.Size = New System.Drawing.Size(100, 17)
        Me.ViewersLabel.TabIndex = 5
        Me.ViewersLabel.Text = "Viewers"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Location = New System.Drawing.Point(72, 152)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PasswordTextBox.TabIndex = 9
        '
        'NickTextBox
        '
        Me.NickTextBox.Location = New System.Drawing.Point(72, 126)
        Me.NickTextBox.Name = "NickTextBox"
        Me.NickTextBox.Size = New System.Drawing.Size(100, 20)
        Me.NickTextBox.TabIndex = 8
        '
        'GameTextBox
        '
        Me.GameTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.GameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.GameTextBox.Location = New System.Drawing.Point(72, 100)
        Me.GameTextBox.Name = "GameTextBox"
        Me.GameTextBox.Size = New System.Drawing.Size(205, 20)
        Me.GameTextBox.TabIndex = 7
        '
        'TitleTextBox
        '
        Me.TitleTextBox.Location = New System.Drawing.Point(72, 74)
        Me.TitleTextBox.Name = "TitleTextBox"
        Me.TitleTextBox.Size = New System.Drawing.Size(205, 20)
        Me.TitleTextBox.TabIndex = 6
        '
        'SetTitleLabel
        '
        Me.SetTitleLabel.AutoSize = True
        Me.SetTitleLabel.Location = New System.Drawing.Point(12, 77)
        Me.SetTitleLabel.Name = "SetTitleLabel"
        Me.SetTitleLabel.Size = New System.Drawing.Size(27, 13)
        Me.SetTitleLabel.TabIndex = 10
        Me.SetTitleLabel.Text = "Title"
        '
        'SetGameLabel
        '
        Me.SetGameLabel.AutoSize = True
        Me.SetGameLabel.Location = New System.Drawing.Point(13, 103)
        Me.SetGameLabel.Name = "SetGameLabel"
        Me.SetGameLabel.Size = New System.Drawing.Size(35, 13)
        Me.SetGameLabel.TabIndex = 11
        Me.SetGameLabel.Text = "Game"
        '
        'SetNickLabel
        '
        Me.SetNickLabel.AutoSize = True
        Me.SetNickLabel.Location = New System.Drawing.Point(13, 129)
        Me.SetNickLabel.Name = "SetNickLabel"
        Me.SetNickLabel.Size = New System.Drawing.Size(55, 13)
        Me.SetNickLabel.TabIndex = 12
        Me.SetNickLabel.Text = "Nickname"
        '
        'SetPasswordLabel
        '
        Me.SetPasswordLabel.AutoSize = True
        Me.SetPasswordLabel.Location = New System.Drawing.Point(13, 155)
        Me.SetPasswordLabel.Name = "SetPasswordLabel"
        Me.SetPasswordLabel.Size = New System.Drawing.Size(53, 13)
        Me.SetPasswordLabel.TabIndex = 13
        Me.SetPasswordLabel.Text = "Password"
        '
        'UpdateDataButton
        '
        Me.UpdateDataButton.Location = New System.Drawing.Point(178, 126)
        Me.UpdateDataButton.Name = "UpdateDataButton"
        Me.UpdateDataButton.Size = New System.Drawing.Size(99, 46)
        Me.UpdateDataButton.TabIndex = 14
        Me.UpdateDataButton.Text = "Update"
        Me.UpdateDataButton.UseVisualStyleBackColor = True
        '
        'ChannelTextBox
        '
        Me.ChannelTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ChannelTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ChannelTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChannelTextBox.Location = New System.Drawing.Point(16, 7)
        Me.ChannelTextBox.Name = "ChannelTextBox"
        Me.ChannelTextBox.Size = New System.Drawing.Size(169, 29)
        Me.ChannelTextBox.TabIndex = 15
        Me.ChannelTextBox.Text = "pelilegacy"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 181)
        Me.Controls.Add(Me.ChannelTextBox)
        Me.Controls.Add(Me.UpdateDataButton)
        Me.Controls.Add(Me.SetPasswordLabel)
        Me.Controls.Add(Me.SetNickLabel)
        Me.Controls.Add(Me.SetGameLabel)
        Me.Controls.Add(Me.SetTitleLabel)
        Me.Controls.Add(Me.TitleTextBox)
        Me.Controls.Add(Me.GameTextBox)
        Me.Controls.Add(Me.NickTextBox)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.ViewersLabel)
        Me.Controls.Add(Me.FollowersLabel)
        Me.Controls.Add(Me.StatusLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Dashbox"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents FollowersLabel As System.Windows.Forms.Label
    Friend WithEvents ViewersLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NickTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TitleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SetTitleLabel As System.Windows.Forms.Label
    Friend WithEvents SetGameLabel As System.Windows.Forms.Label
    Friend WithEvents SetNickLabel As System.Windows.Forms.Label
    Friend WithEvents SetPasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UpdateDataButton As System.Windows.Forms.Button
    Friend WithEvents ChannelTextBox As System.Windows.Forms.TextBox

End Class
