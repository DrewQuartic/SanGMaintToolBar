<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQueryParcelBacklog
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.dgMissingAPN = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFndCnt = New System.Windows.Forms.Label()
        Me.btnExportData = New System.Windows.Forms.Button()
        Me.cboMaintAreas = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgMissingAPN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(660, 283)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(110, 23)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'dgMissingAPN
        '
        Me.dgMissingAPN.AllowUserToAddRows = False
        Me.dgMissingAPN.AllowUserToDeleteRows = False
        Me.dgMissingAPN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgMissingAPN.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dgMissingAPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMissingAPN.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgMissingAPN.Location = New System.Drawing.Point(12, 36)
        Me.dgMissingAPN.MultiSelect = False
        Me.dgMissingAPN.Name = "dgMissingAPN"
        Me.dgMissingAPN.ReadOnly = True
        Me.dgMissingAPN.RowHeadersVisible = False
        Me.dgMissingAPN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgMissingAPN.Size = New System.Drawing.Size(780, 241)
        Me.dgMissingAPN.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 283)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Records Found:"
        '
        'lblFndCnt
        '
        Me.lblFndCnt.AutoSize = True
        Me.lblFndCnt.Location = New System.Drawing.Point(92, 283)
        Me.lblFndCnt.Name = "lblFndCnt"
        Me.lblFndCnt.Size = New System.Drawing.Size(13, 13)
        Me.lblFndCnt.TabIndex = 7
        Me.lblFndCnt.Text = "0"
        '
        'btnExportData
        '
        Me.btnExportData.Location = New System.Drawing.Point(482, 283)
        Me.btnExportData.Name = "btnExportData"
        Me.btnExportData.Size = New System.Drawing.Size(132, 23)
        Me.btnExportData.TabIndex = 8
        Me.btnExportData.Text = "Export List to Excel"
        Me.btnExportData.UseVisualStyleBackColor = True
        '
        'cboMaintAreas
        '
        Me.cboMaintAreas.FormattingEnabled = True
        Me.cboMaintAreas.Location = New System.Drawing.Point(259, 285)
        Me.cboMaintAreas.Name = "cboMaintAreas"
        Me.cboMaintAreas.Size = New System.Drawing.Size(121, 21)
        Me.cboMaintAreas.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(151, 288)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Maintenance Area(s):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(351, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Select the Maintenance Area to retrieve the list"
        '
        'frmQueryParcelBacklog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 313)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboMaintAreas)
        Me.Controls.Add(Me.btnExportData)
        Me.Controls.Add(Me.lblFndCnt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgMissingAPN)
        Me.Controls.Add(Me.btnExit)
        Me.KeyPreview = True
        Me.Name = "frmQueryParcelBacklog"
        Me.Text = "Parcel Backlog"
        CType(Me.dgMissingAPN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents dgMissingAPN As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFndCnt As System.Windows.Forms.Label
    Friend WithEvents btnExportData As System.Windows.Forms.Button
    Friend WithEvents cboMaintAreas As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
