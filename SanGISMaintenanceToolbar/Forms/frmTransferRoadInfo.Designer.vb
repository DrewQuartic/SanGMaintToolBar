<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferRoadInfo
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
        Me.chkAttrs = New System.Windows.Forms.CheckBox
        Me.chkAddrs = New System.Windows.Forms.CheckBox
        Me.chkAlias = New System.Windows.Forms.CheckBox
        Me.chkRemove = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'chkAttrs
        '
        Me.chkAttrs.AutoSize = True
        Me.chkAttrs.Checked = True
        Me.chkAttrs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAttrs.Location = New System.Drawing.Point(24, 63)
        Me.chkAttrs.Name = "chkAttrs"
        Me.chkAttrs.Size = New System.Drawing.Size(97, 17)
        Me.chkAttrs.TabIndex = 0
        Me.chkAttrs.Text = "Copy Attributes"
        Me.chkAttrs.UseVisualStyleBackColor = True
        '
        'chkAddrs
        '
        Me.chkAddrs.AutoSize = True
        Me.chkAddrs.Checked = True
        Me.chkAddrs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAddrs.Location = New System.Drawing.Point(24, 86)
        Me.chkAddrs.Name = "chkAddrs"
        Me.chkAddrs.Size = New System.Drawing.Size(125, 17)
        Me.chkAddrs.TabIndex = 1
        Me.chkAddrs.Text = "Re-assign Addresses"
        Me.chkAddrs.UseVisualStyleBackColor = True
        '
        'chkAlias
        '
        Me.chkAlias.AutoSize = True
        Me.chkAlias.Checked = True
        Me.chkAlias.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAlias.Location = New System.Drawing.Point(24, 109)
        Me.chkAlias.Name = "chkAlias"
        Me.chkAlias.Size = New System.Drawing.Size(132, 17)
        Me.chkAlias.TabIndex = 2
        Me.chkAlias.Text = "Re-Assign Seg Aliases"
        Me.chkAlias.UseVisualStyleBackColor = True
        '
        'chkRemove
        '
        Me.chkRemove.AutoSize = True
        Me.chkRemove.Checked = True
        Me.chkRemove.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRemove.Location = New System.Drawing.Point(24, 132)
        Me.chkRemove.Name = "chkRemove"
        Me.chkRemove.Size = New System.Drawing.Size(149, 17)
        Me.chkRemove.TabIndex = 3
        Me.chkRemove.Text = "Remove Original Segment"
        Me.chkRemove.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 39)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "I want to do the following FROM" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " my Selected Road Segment TO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " the Road Segment " & _
            "I will choose"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(12, 164)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(104, 164)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmTransferRoadInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(191, 195)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkRemove)
        Me.Controls.Add(Me.chkAlias)
        Me.Controls.Add(Me.chkAddrs)
        Me.Controls.Add(Me.chkAttrs)
        Me.Name = "frmTransferRoadInfo"
        Me.Text = "Transfer Road Info"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkAttrs As System.Windows.Forms.CheckBox
    Friend WithEvents chkAddrs As System.Windows.Forms.CheckBox
    Friend WithEvents chkAlias As System.Windows.Forms.CheckBox
    Friend WithEvents chkRemove As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
