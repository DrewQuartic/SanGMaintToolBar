<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmZipperInput
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			Static fTerminateCalled As Boolean
			If Not fTerminateCalled Then
				Form_Terminate_renamed()
				fTerminateCalled = True
			End If
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents cmdAllTopo As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents lstLayers As System.Windows.Forms.CheckedListBox
	Public WithEvents txtDistance As System.Windows.Forms.TextBox
  Public WithEvents lblHeading As System.Windows.Forms.Label
  Public WithEvents lblDistance As System.Windows.Forms.Label
  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.cmdAllTopo = New System.Windows.Forms.Button
    Me.cmdOK = New System.Windows.Forms.Button
    Me.cmdCancel = New System.Windows.Forms.Button
    Me.lstLayers = New System.Windows.Forms.CheckedListBox
    Me.txtDistance = New System.Windows.Forms.TextBox
    Me.lblHeading = New System.Windows.Forms.Label
    Me.lblDistance = New System.Windows.Forms.Label
    Me.SuspendLayout()
    '
    'cmdAllTopo
    '
    Me.cmdAllTopo.BackColor = System.Drawing.SystemColors.Control
    Me.cmdAllTopo.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdAllTopo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cmdAllTopo.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdAllTopo.Location = New System.Drawing.Point(260, 78)
    Me.cmdAllTopo.Name = "cmdAllTopo"
    Me.cmdAllTopo.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdAllTopo.Size = New System.Drawing.Size(66, 25)
    Me.cmdAllTopo.TabIndex = 6
    Me.cmdAllTopo.Text = "&All Topo"
    Me.cmdAllTopo.UseVisualStyleBackColor = False
    '
    'cmdOK
    '
    Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
    Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdOK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdOK.Location = New System.Drawing.Point(260, 156)
    Me.cmdOK.Name = "cmdOK"
    Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdOK.Size = New System.Drawing.Size(66, 25)
    Me.cmdOK.TabIndex = 5
    Me.cmdOK.Text = "&OK"
    Me.cmdOK.UseVisualStyleBackColor = False
    '
    'cmdCancel
    '
    Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
    Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
    Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
    Me.cmdCancel.Location = New System.Drawing.Point(260, 188)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdCancel.Size = New System.Drawing.Size(66, 25)
    Me.cmdCancel.TabIndex = 4
    Me.cmdCancel.Text = "&Cancel"
    Me.cmdCancel.UseVisualStyleBackColor = False
    '
    'lstLayers
    '
    Me.lstLayers.BackColor = System.Drawing.SystemColors.Window
    Me.lstLayers.CheckOnClick = True
    Me.lstLayers.Cursor = System.Windows.Forms.Cursors.Default
    Me.lstLayers.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lstLayers.ForeColor = System.Drawing.SystemColors.WindowText
    Me.lstLayers.Location = New System.Drawing.Point(20, 72)
    Me.lstLayers.Name = "lstLayers"
    Me.lstLayers.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lstLayers.Size = New System.Drawing.Size(222, 139)
    Me.lstLayers.TabIndex = 3
    '
    'txtDistance
    '
    Me.txtDistance.AcceptsReturn = True
    Me.txtDistance.BackColor = System.Drawing.SystemColors.Window
    Me.txtDistance.Cursor = System.Windows.Forms.Cursors.IBeam
    Me.txtDistance.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtDistance.ForeColor = System.Drawing.SystemColors.WindowText
    Me.txtDistance.Location = New System.Drawing.Point(102, 5)
    Me.txtDistance.MaxLength = 0
    Me.txtDistance.Name = "txtDistance"
    Me.txtDistance.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.txtDistance.Size = New System.Drawing.Size(71, 20)
    Me.txtDistance.TabIndex = 1
    '
    'lblHeading
    '
    Me.lblHeading.BackColor = System.Drawing.SystemColors.Control
    Me.lblHeading.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblHeading.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblHeading.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lblHeading.Location = New System.Drawing.Point(14, 38)
    Me.lblHeading.Name = "lblHeading"
    Me.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblHeading.Size = New System.Drawing.Size(312, 29)
    Me.lblHeading.TabIndex = 2
    Me.lblHeading.Text = "Layers to consider (Click on All Topo button to select all layers from the curren" & _
        "t topology):"
    '
    'lblDistance
    '
    Me.lblDistance.BackColor = System.Drawing.SystemColors.Control
    Me.lblDistance.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblDistance.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblDistance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lblDistance.Location = New System.Drawing.Point(14, 5)
    Me.lblDistance.Name = "lblDistance"
    Me.lblDistance.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblDistance.Size = New System.Drawing.Size(97, 18)
    Me.lblDistance.TabIndex = 0
    Me.lblDistance.Text = "Search Distance:"
    '
    'frmZipperInput
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(332, 220)
    Me.Controls.Add(Me.cmdAllTopo)
    Me.Controls.Add(Me.cmdOK)
    Me.Controls.Add(Me.cmdCancel)
    Me.Controls.Add(Me.lstLayers)
    Me.Controls.Add(Me.txtDistance)
    Me.Controls.Add(Me.lblHeading)
    Me.Controls.Add(Me.lblDistance)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    Me.Location = New System.Drawing.Point(2, 18)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmZipperInput"
    Me.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.ShowInTaskbar = False
    Me.Text = "Zipper Parameters"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
#End Region 
End Class