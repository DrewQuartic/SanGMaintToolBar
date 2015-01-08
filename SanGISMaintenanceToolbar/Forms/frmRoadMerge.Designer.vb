<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRoadMerge
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblSeg2 = New System.Windows.Forms.Label()
        Me.lblSeg1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnMerge = New System.Windows.Forms.Button()
        Me.flpGroups = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(15, 48)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(0, 0)
        Me.FlowLayoutPanel1.TabIndex = 5
        '
        'lblSeg2
        '
        Me.lblSeg2.AutoSize = True
        Me.lblSeg2.Location = New System.Drawing.Point(187, 51)
        Me.lblSeg2.Name = "lblSeg2"
        Me.lblSeg2.Size = New System.Drawing.Size(39, 13)
        Me.lblSeg2.TabIndex = 9
        Me.lblSeg2.Text = "Label2"
        '
        'lblSeg1
        '
        Me.lblSeg1.AutoSize = True
        Me.lblSeg1.Location = New System.Drawing.Point(275, 51)
        Me.lblSeg1.Name = "lblSeg1"
        Me.lblSeg1.Size = New System.Drawing.Size(39, 13)
        Me.lblSeg1.TabIndex = 8
        Me.lblSeg1.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "SegIds Being Merged:"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(28, 103)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnMerge
        '
        Me.btnMerge.Location = New System.Drawing.Point(28, 71)
        Me.btnMerge.Name = "btnMerge"
        Me.btnMerge.Size = New System.Drawing.Size(75, 23)
        Me.btnMerge.TabIndex = 5
        Me.btnMerge.Text = "Merge"
        Me.btnMerge.UseVisualStyleBackColor = True
        '
        'flpGroups
        '
        Me.flpGroups.AutoSize = True
        Me.flpGroups.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpGroups.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpGroups.Location = New System.Drawing.Point(162, 64)
        Me.flpGroups.Name = "flpGroups"
        Me.flpGroups.Size = New System.Drawing.Size(0, 0)
        Me.flpGroups.TabIndex = 10
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(15, 48)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(0, 0)
        Me.FlowLayoutPanel2.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "SegIds Being Merged:"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(12, 8)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(382, 34)
        Me.TextBox1.TabIndex = 12
        Me.TextBox1.Text = "Conflicting values found between the 2 segments being merged. Please select the v" & _
    "alue to keep"
        '
        'frmRoadMerge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(431, 248)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnMerge)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.lblSeg2)
        Me.Controls.Add(Me.lblSeg1)
        Me.Controls.Add(Me.flpGroups)
        Me.Name = "frmRoadMerge"
        Me.Text = "Choose the correct conflicting value "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSeg2 As System.Windows.Forms.Label
    Friend WithEvents lblSeg1 As System.Windows.Forms.Label
    Friend WithEvents btnMerge As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents flpGroups As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
