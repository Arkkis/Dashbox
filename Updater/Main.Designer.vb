<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Label_Updating = New System.Windows.Forms.Label()
        Me.ProgressBar_Update = New System.Windows.Forms.ProgressBar()
        Me.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'Label_Updating
        '
        Me.Label_Updating.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Updating.Location = New System.Drawing.Point(12, 9)
        Me.Label_Updating.Name = "Label_Updating"
        Me.Label_Updating.Size = New System.Drawing.Size(440, 13)
        Me.Label_Updating.TabIndex = 3
        Me.Label_Updating.Text = "Updating..."
        '
        'ProgressBar_Update
        '
        Me.ProgressBar_Update.Location = New System.Drawing.Point(12, 25)
        Me.ProgressBar_Update.Name = "ProgressBar_Update"
        Me.ProgressBar_Update.Size = New System.Drawing.Size(440, 23)
        Me.ProgressBar_Update.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar_Update.TabIndex = 2
        '
        'BackgroundWorker
        '
        Me.BackgroundWorker.WorkerReportsProgress = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 64)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label_Updating)
        Me.Controls.Add(Me.ProgressBar_Update)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label_Updating As System.Windows.Forms.Label
    Friend WithEvents ProgressBar_Update As System.Windows.Forms.ProgressBar
    Friend WithEvents BackgroundWorker As System.ComponentModel.BackgroundWorker
End Class
