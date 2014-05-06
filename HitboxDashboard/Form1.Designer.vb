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
        Me.DataLabel = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.GameLabel = New System.Windows.Forms.Label()
        Me.FollowersLabel = New System.Windows.Forms.Label()
        Me.ViewersLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'DataLabel
        '
        Me.DataLabel.AutoSize = True
        Me.DataLabel.Location = New System.Drawing.Point(13, 13)
        Me.DataLabel.Name = "DataLabel"
        Me.DataLabel.Size = New System.Drawing.Size(30, 13)
        Me.DataLabel.TabIndex = 0
        Me.DataLabel.Text = "Data"
        '
        'BackgroundWorker1
        '
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Location = New System.Drawing.Point(13, 26)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(37, 13)
        Me.StatusLabel.TabIndex = 1
        Me.StatusLabel.Text = "Status"
        '
        'TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Location = New System.Drawing.Point(13, 39)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(27, 13)
        Me.TitleLabel.TabIndex = 2
        Me.TitleLabel.Text = "Title"
        '
        'GameLabel
        '
        Me.GameLabel.AutoSize = True
        Me.GameLabel.Location = New System.Drawing.Point(13, 52)
        Me.GameLabel.Name = "GameLabel"
        Me.GameLabel.Size = New System.Drawing.Size(35, 13)
        Me.GameLabel.TabIndex = 3
        Me.GameLabel.Text = "Game"
        '
        'FollowersLabel
        '
        Me.FollowersLabel.AutoSize = True
        Me.FollowersLabel.Location = New System.Drawing.Point(13, 65)
        Me.FollowersLabel.Name = "FollowersLabel"
        Me.FollowersLabel.Size = New System.Drawing.Size(51, 13)
        Me.FollowersLabel.TabIndex = 4
        Me.FollowersLabel.Text = "Followers"
        '
        'ViewersLabel
        '
        Me.ViewersLabel.AutoSize = True
        Me.ViewersLabel.Location = New System.Drawing.Point(13, 78)
        Me.ViewersLabel.Name = "ViewersLabel"
        Me.ViewersLabel.Size = New System.Drawing.Size(44, 13)
        Me.ViewersLabel.TabIndex = 5
        Me.ViewersLabel.Text = "Viewers"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 253)
        Me.Controls.Add(Me.ViewersLabel)
        Me.Controls.Add(Me.FollowersLabel)
        Me.Controls.Add(Me.GameLabel)
        Me.Controls.Add(Me.TitleLabel)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.DataLabel)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataLabel As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents TitleLabel As System.Windows.Forms.Label
    Friend WithEvents GameLabel As System.Windows.Forms.Label
    Friend WithEvents FollowersLabel As System.Windows.Forms.Label
    Friend WithEvents ViewersLabel As System.Windows.Forms.Label

End Class
