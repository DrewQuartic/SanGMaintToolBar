<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQueryControl
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
        Me.ckbxCntrlStationIDSearch = New System.Windows.Forms.CheckBox()
        Me.cboCntrlSelectName = New System.Windows.Forms.ComboBox()
        Me.ckbxCntrlStationSearch = New System.Windows.Forms.CheckBox()
        Me.lblRDNMSelectName = New System.Windows.Forms.Label()
        Me.dgCntrl = New System.Windows.Forms.DataGridView()
        Me.btnCntrlClear = New System.Windows.Forms.Button()
        Me.btnControlExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCntrolCnt = New System.Windows.Forms.Label()
        Me.ckbxSearchAll = New System.Windows.Forms.CheckBox()
        Me.btnControlFindFtr = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtKnwnID = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btnExporttoExcelAdr = New System.Windows.Forms.Button()
        CType(Me.dgCntrl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ckbxCntrlStationIDSearch
        '
        Me.ckbxCntrlStationIDSearch.AutoSize = True
        Me.ckbxCntrlStationIDSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbxCntrlStationIDSearch.Location = New System.Drawing.Point(238, 35)
        Me.ckbxCntrlStationIDSearch.Name = "ckbxCntrlStationIDSearch"
        Me.ckbxCntrlStationIDSearch.Size = New System.Drawing.Size(144, 17)
        Me.ckbxCntrlStationIDSearch.TabIndex = 126
        Me.ckbxCntrlStationIDSearch.TabStop = False
        Me.ckbxCntrlStationIDSearch.Text = "Search by Station ID"
        Me.ckbxCntrlStationIDSearch.UseVisualStyleBackColor = True
        '
        'cboCntrlSelectName
        '
        Me.cboCntrlSelectName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCntrlSelectName.Enabled = False
        Me.cboCntrlSelectName.FormattingEnabled = True
        Me.cboCntrlSelectName.Location = New System.Drawing.Point(395, 31)
        Me.cboCntrlSelectName.MaxDropDownItems = 20
        Me.cboCntrlSelectName.Name = "cboCntrlSelectName"
        Me.cboCntrlSelectName.Size = New System.Drawing.Size(281, 21)
        Me.cboCntrlSelectName.TabIndex = 123
        '
        'ckbxCntrlStationSearch
        '
        Me.ckbxCntrlStationSearch.AutoSize = True
        Me.ckbxCntrlStationSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbxCntrlStationSearch.Location = New System.Drawing.Point(238, 12)
        Me.ckbxCntrlStationSearch.Name = "ckbxCntrlStationSearch"
        Me.ckbxCntrlStationSearch.Size = New System.Drawing.Size(127, 17)
        Me.ckbxCntrlStationSearch.TabIndex = 124
        Me.ckbxCntrlStationSearch.TabStop = False
        Me.ckbxCntrlStationSearch.Text = "Search by Station"
        Me.ckbxCntrlStationSearch.UseVisualStyleBackColor = True
        '
        'lblRDNMSelectName
        '
        Me.lblRDNMSelectName.AutoSize = True
        Me.lblRDNMSelectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRDNMSelectName.Location = New System.Drawing.Point(392, 13)
        Me.lblRDNMSelectName.Name = "lblRDNMSelectName"
        Me.lblRDNMSelectName.Size = New System.Drawing.Size(284, 13)
        Me.lblRDNMSelectName.TabIndex = 125
        Me.lblRDNMSelectName.Text = "Select StationID/StationName from List to Display Attributes"
        '
        'dgCntrl
        '
        Me.dgCntrl.AllowUserToAddRows = False
        Me.dgCntrl.AllowUserToDeleteRows = False
        Me.dgCntrl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgCntrl.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgCntrl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCntrl.Location = New System.Drawing.Point(30, 81)
        Me.dgCntrl.MultiSelect = False
        Me.dgCntrl.Name = "dgCntrl"
        Me.dgCntrl.ReadOnly = True
        Me.dgCntrl.RowHeadersVisible = False
        Me.dgCntrl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCntrl.Size = New System.Drawing.Size(646, 274)
        Me.dgCntrl.TabIndex = 127
        '
        'btnCntrlClear
        '
        Me.btnCntrlClear.Location = New System.Drawing.Point(273, 387)
        Me.btnCntrlClear.Name = "btnCntrlClear"
        Me.btnCntrlClear.Size = New System.Drawing.Size(75, 23)
        Me.btnCntrlClear.TabIndex = 128
        Me.btnCntrlClear.Text = "Clear"
        Me.btnCntrlClear.UseVisualStyleBackColor = True
        '
        'btnControlExit
        '
        Me.btnControlExit.Location = New System.Drawing.Point(561, 393)
        Me.btnControlExit.Name = "btnControlExit"
        Me.btnControlExit.Size = New System.Drawing.Size(75, 23)
        Me.btnControlExit.TabIndex = 129
        Me.btnControlExit.Text = "Exit"
        Me.btnControlExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label1.Location = New System.Drawing.Point(558, 377)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Total Control: "
        '
        'lblCntrolCnt
        '
        Me.lblCntrolCnt.AutoSize = True
        Me.lblCntrolCnt.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblCntrolCnt.Location = New System.Drawing.Point(637, 377)
        Me.lblCntrolCnt.Name = "lblCntrolCnt"
        Me.lblCntrolCnt.Size = New System.Drawing.Size(13, 13)
        Me.lblCntrolCnt.TabIndex = 131
        Me.lblCntrolCnt.Text = "0"
        '
        'ckbxSearchAll
        '
        Me.ckbxSearchAll.AutoSize = True
        Me.ckbxSearchAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbxSearchAll.Location = New System.Drawing.Point(238, 58)
        Me.ckbxSearchAll.Name = "ckbxSearchAll"
        Me.ckbxSearchAll.Size = New System.Drawing.Size(119, 17)
        Me.ckbxSearchAll.TabIndex = 132
        Me.ckbxSearchAll.TabStop = False
        Me.ckbxSearchAll.Text = "Show All Control"
        Me.ckbxSearchAll.UseVisualStyleBackColor = True
        '
        'btnControlFindFtr
        '
        Me.btnControlFindFtr.Location = New System.Drawing.Point(41, 388)
        Me.btnControlFindFtr.Name = "btnControlFindFtr"
        Me.btnControlFindFtr.Size = New System.Drawing.Size(197, 23)
        Me.btnControlFindFtr.TabIndex = 133
        Me.btnControlFindFtr.Text = "Find Control in Map"
        Me.btnControlFindFtr.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(170, 31)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(57, 31)
        Me.Label26.TabIndex = 136
        Me.Label26.Text = "OR"
        '
        'txtKnwnID
        '
        Me.txtKnwnID.Location = New System.Drawing.Point(30, 42)
        Me.txtKnwnID.Name = "txtKnwnID"
        Me.txtKnwnID.Size = New System.Drawing.Size(122, 20)
        Me.txtKnwnID.TabIndex = 135
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(27, 13)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(137, 26)
        Me.Label25.TabIndex = 134
        Me.Label25.Text = "Input Station Search String " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (and press Enter)"
        '
        'btnExporttoExcelAdr
        '
        Me.btnExporttoExcelAdr.Location = New System.Drawing.Point(395, 388)
        Me.btnExporttoExcelAdr.Name = "btnExporttoExcelAdr"
        Me.btnExporttoExcelAdr.Size = New System.Drawing.Size(109, 22)
        Me.btnExporttoExcelAdr.TabIndex = 245
        Me.btnExporttoExcelAdr.Text = "Export List to Excel"
        Me.btnExporttoExcelAdr.UseVisualStyleBackColor = True
        '
        'frmQueryControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 423)
        Me.Controls.Add(Me.btnExporttoExcelAdr)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtKnwnID)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.btnControlFindFtr)
        Me.Controls.Add(Me.ckbxSearchAll)
        Me.Controls.Add(Me.lblCntrolCnt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnControlExit)
        Me.Controls.Add(Me.btnCntrlClear)
        Me.Controls.Add(Me.dgCntrl)
        Me.Controls.Add(Me.ckbxCntrlStationIDSearch)
        Me.Controls.Add(Me.cboCntrlSelectName)
        Me.Controls.Add(Me.ckbxCntrlStationSearch)
        Me.Controls.Add(Me.lblRDNMSelectName)
        Me.KeyPreview = True
        Me.Name = "frmQueryControl"
        Me.Text = "Query Control Monument"
        CType(Me.dgCntrl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ckbxCntrlStationIDSearch As System.Windows.Forms.CheckBox
    Friend WithEvents cboCntrlSelectName As System.Windows.Forms.ComboBox
    Friend WithEvents ckbxCntrlStationSearch As System.Windows.Forms.CheckBox
    Friend WithEvents lblRDNMSelectName As System.Windows.Forms.Label
    Friend WithEvents dgCntrl As System.Windows.Forms.DataGridView
    Friend WithEvents btnCntrlClear As System.Windows.Forms.Button
    Friend WithEvents btnControlExit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCntrolCnt As System.Windows.Forms.Label
    Friend WithEvents ckbxSearchAll As System.Windows.Forms.CheckBox
    Friend WithEvents btnControlFindFtr As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtKnwnID As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btnExporttoExcelAdr As System.Windows.Forms.Button
End Class
