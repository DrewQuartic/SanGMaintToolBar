<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucRoadItemCompare
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.gbControl = New System.Windows.Forms.GroupBox()
        Me.rb2 = New System.Windows.Forms.RadioButton()
        Me.rb1 = New System.Windows.Forms.RadioButton()
        Me.gbControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbControl
        '
        Me.gbControl.AutoSize = True
        Me.gbControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gbControl.Controls.Add(Me.rb2)
        Me.gbControl.Controls.Add(Me.rb1)
        Me.gbControl.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.gbControl.Location = New System.Drawing.Point(16, 13)
        Me.gbControl.Name = "gbControl"
        Me.gbControl.Size = New System.Drawing.Size(198, 55)
        Me.gbControl.TabIndex = 3
        Me.gbControl.TabStop = False
        '
        'rb2
        '
        Me.rb2.AutoSize = True
        Me.rb2.Location = New System.Drawing.Point(102, 19)
        Me.rb2.Name = "rb2"
        Me.rb2.Size = New System.Drawing.Size(90, 17)
        Me.rb2.TabIndex = 1
        Me.rb2.TabStop = True
        Me.rb2.Text = "RadioButton2"
        Me.rb2.UseVisualStyleBackColor = True
        '
        'rb1
        '
        Me.rb1.AutoSize = True
        Me.rb1.Location = New System.Drawing.Point(6, 19)
        Me.rb1.Name = "rb1"
        Me.rb1.Size = New System.Drawing.Size(90, 17)
        Me.rb1.TabIndex = 0
        Me.rb1.TabStop = True
        Me.rb1.Text = "RadioButton1"
        Me.rb1.UseVisualStyleBackColor = True
        '
        'ucRoadItemCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.gbControl)
        Me.Name = "ucRoadItemCompare"
        Me.Size = New System.Drawing.Size(237, 86)
        Me.gbControl.ResumeLayout(False)
        Me.gbControl.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbControl As System.Windows.Forms.GroupBox
    Friend WithEvents rb2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb1 As System.Windows.Forms.RadioButton

End Class
