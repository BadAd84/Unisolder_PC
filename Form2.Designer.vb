<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.SsChart2 = New SSControls.SSChart()
        Me.DGTrackBar = New System.Windows.Forms.TrackBar()
        Me.DGLabel = New System.Windows.Forms.Label()
        Me.KiLabel = New System.Windows.Forms.Label()
        Me.KiTrackBar = New System.Windows.Forms.TrackBar()
        Me.KpLabel = New System.Windows.Forms.Label()
        Me.KpTrackBar = New System.Windows.Forms.TrackBar()
        Me.OVFGLabel = New System.Windows.Forms.Label()
        Me.OVFGTrackBar = New System.Windows.Forms.TrackBar()
        Me.GLabel = New System.Windows.Forms.Label()
        Me.GTrackBar = New System.Windows.Forms.TrackBar()
        Me.Button8 = New System.Windows.Forms.Button()
        CType(Me.DGTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KiTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KpTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OVFGTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(153, 751)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(168, 44)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Device Info"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(326, 751)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(193, 44)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Operating mode"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(526, 751)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(193, 44)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Update Firmware"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Location = New System.Drawing.Point(725, 751)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(193, 44)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "Jump to Application"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.Location = New System.Drawing.Point(923, 751)
        Me.Button5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(193, 44)
        Me.Button5.TabIndex = 9
        Me.Button5.Text = "Jump to bootloader"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Button6.Location = New System.Drawing.Point(1122, 751)
        Me.Button6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(193, 44)
        Me.Button6.TabIndex = 11
        Me.Button6.Text = "Query device"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button7.Location = New System.Drawing.Point(8, 751)
        Me.Button7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(139, 44)
        Me.Button7.TabIndex = 13
        Me.Button7.Text = "RLE TEST"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'SsChart2
        '
        Me.SsChart2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SsChart2.BackColor = System.Drawing.Color.Black
        Me.SsChart2.DrawingsNum = CType(1, Long)
        Me.SsChart2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SsChart2.Location = New System.Drawing.Point(12, 12)
        Me.SsChart2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SsChart2.Name = "SsChart2"
        Me.SsChart2.Padding = New System.Windows.Forms.Padding(5)
        Me.SsChart2.ScaleNum = CType(2, Long)
        Me.SsChart2.ScaleOnResize = False
        Me.SsChart2.Size = New System.Drawing.Size(1303, 665)
        Me.SsChart2.TabIndex = 15
        '
        'DGTrackBar
        '
        Me.DGTrackBar.Location = New System.Drawing.Point(1122, 690)
        Me.DGTrackBar.Maximum = 32
        Me.DGTrackBar.Name = "DGTrackBar"
        Me.DGTrackBar.Size = New System.Drawing.Size(193, 56)
        Me.DGTrackBar.TabIndex = 17
        '
        'DGLabel
        '
        Me.DGLabel.AutoSize = True
        Me.DGLabel.Location = New System.Drawing.Point(1191, 726)
        Me.DGLabel.Name = "DGLabel"
        Me.DGLabel.Size = New System.Drawing.Size(48, 17)
        Me.DGLabel.TabIndex = 18
        Me.DGLabel.Text = "DGain"
        '
        'KiLabel
        '
        Me.KiLabel.AutoSize = True
        Me.KiLabel.Location = New System.Drawing.Point(992, 726)
        Me.KiLabel.Name = "KiLabel"
        Me.KiLabel.Size = New System.Drawing.Size(20, 17)
        Me.KiLabel.TabIndex = 20
        Me.KiLabel.Text = "Ki"
        '
        'KiTrackBar
        '
        Me.KiTrackBar.LargeChange = 100
        Me.KiTrackBar.Location = New System.Drawing.Point(923, 690)
        Me.KiTrackBar.Maximum = 3277
        Me.KiTrackBar.Name = "KiTrackBar"
        Me.KiTrackBar.Size = New System.Drawing.Size(193, 56)
        Me.KiTrackBar.SmallChange = 10
        Me.KiTrackBar.TabIndex = 19
        '
        'KpLabel
        '
        Me.KpLabel.AutoSize = True
        Me.KpLabel.Location = New System.Drawing.Point(793, 726)
        Me.KpLabel.Name = "KpLabel"
        Me.KpLabel.Size = New System.Drawing.Size(25, 17)
        Me.KpLabel.TabIndex = 22
        Me.KpLabel.Text = "Kp"
        '
        'KpTrackBar
        '
        Me.KpTrackBar.LargeChange = 1000
        Me.KpTrackBar.Location = New System.Drawing.Point(724, 690)
        Me.KpTrackBar.Maximum = 32767
        Me.KpTrackBar.Name = "KpTrackBar"
        Me.KpTrackBar.Size = New System.Drawing.Size(193, 56)
        Me.KpTrackBar.SmallChange = 100
        Me.KpTrackBar.TabIndex = 21
        '
        'OVFGLabel
        '
        Me.OVFGLabel.AutoSize = True
        Me.OVFGLabel.Location = New System.Drawing.Point(579, 726)
        Me.OVFGLabel.Name = "OVFGLabel"
        Me.OVFGLabel.Size = New System.Drawing.Size(66, 17)
        Me.OVFGLabel.TabIndex = 25
        Me.OVFGLabel.Text = "OVFGain"
        '
        'OVFGTrackBar
        '
        Me.OVFGTrackBar.LargeChange = 10
        Me.OVFGTrackBar.Location = New System.Drawing.Point(525, 690)
        Me.OVFGTrackBar.Maximum = 100
        Me.OVFGTrackBar.Name = "OVFGTrackBar"
        Me.OVFGTrackBar.Size = New System.Drawing.Size(193, 56)
        Me.OVFGTrackBar.TabIndex = 24
        '
        'GLabel
        '
        Me.GLabel.AutoSize = True
        Me.GLabel.Location = New System.Drawing.Point(380, 726)
        Me.GLabel.Name = "GLabel"
        Me.GLabel.Size = New System.Drawing.Size(38, 17)
        Me.GLabel.TabIndex = 28
        Me.GLabel.Text = "Gain"
        '
        'GTrackBar
        '
        Me.GTrackBar.LargeChange = 8
        Me.GTrackBar.Location = New System.Drawing.Point(326, 690)
        Me.GTrackBar.Maximum = 256
        Me.GTrackBar.Name = "GTrackBar"
        Me.GTrackBar.Size = New System.Drawing.Size(193, 56)
        Me.GTrackBar.TabIndex = 27
        '
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button8.Location = New System.Drawing.Point(8, 699)
        Me.Button8.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(139, 44)
        Me.Button8.TabIndex = 30
        Me.Button8.Text = "STOP"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1327, 807)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.GLabel)
        Me.Controls.Add(Me.GTrackBar)
        Me.Controls.Add(Me.OVFGLabel)
        Me.Controls.Add(Me.OVFGTrackBar)
        Me.Controls.Add(Me.KpLabel)
        Me.Controls.Add(Me.KpTrackBar)
        Me.Controls.Add(Me.KiLabel)
        Me.Controls.Add(Me.KiTrackBar)
        Me.Controls.Add(Me.DGLabel)
        Me.Controls.Add(Me.DGTrackBar)
        Me.Controls.Add(Me.SsChart2)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.DGTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KiTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KpTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OVFGTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents SsChart2 As SSControls.SSChart
    Friend WithEvents DGTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents DGLabel As System.Windows.Forms.Label
    Friend WithEvents KiLabel As System.Windows.Forms.Label
    Friend WithEvents KiTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents KpLabel As System.Windows.Forms.Label
    Friend WithEvents KpTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents OVFGLabel As System.Windows.Forms.Label
    Friend WithEvents OVFGTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents GLabel As System.Windows.Forms.Label
    Friend WithEvents GTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents Button8 As System.Windows.Forms.Button
End Class
