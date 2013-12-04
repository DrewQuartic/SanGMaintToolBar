<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQueryApn
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgAPNList = New System.Windows.Forms.DataGridView()
        Me.dgAdrList = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAPNQF = New System.Windows.Forms.TextBox()
        Me.txtParcelIDQF = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnExporttoExcelAdr = New System.Windows.Forms.Button()
        Me.lblAdrRowCount = New System.Windows.Forms.Label()
        Me.lblAPNID = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblNumRecFound = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnParcelGetFtr = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.btnExportData = New System.Windows.Forms.Button()
        CType(Me.dgAPNList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgAdrList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgAPNList
        '
        Me.dgAPNList.AllowUserToAddRows = False
        Me.dgAPNList.AllowUserToDeleteRows = False
        Me.dgAPNList.AllowUserToResizeColumns = False
        Me.dgAPNList.AllowUserToResizeRows = False
        Me.dgAPNList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dgAPNList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAPNList.Location = New System.Drawing.Point(12, 54)
        Me.dgAPNList.MultiSelect = False
        Me.dgAPNList.Name = "dgAPNList"
        Me.dgAPNList.ReadOnly = True
        Me.dgAPNList.RowHeadersVisible = False
        Me.dgAPNList.RowTemplate.DividerHeight = 4
        Me.dgAPNList.RowTemplate.Height = 20
        Me.dgAPNList.RowTemplate.ReadOnly = True
        Me.dgAPNList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgAPNList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAPNList.ShowCellToolTips = False
        Me.dgAPNList.Size = New System.Drawing.Size(898, 293)
        Me.dgAPNList.TabIndex = 0
        '
        'dgAdrList
        '
        Me.dgAdrList.AllowUserToAddRows = False
        Me.dgAdrList.AllowUserToDeleteRows = False
        Me.dgAdrList.AllowUserToResizeColumns = False
        Me.dgAdrList.AllowUserToResizeRows = False
        Me.dgAdrList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgAdrList.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgAdrList.Location = New System.Drawing.Point(33, 20)
        Me.dgAdrList.MultiSelect = False
        Me.dgAdrList.Name = "dgAdrList"
        Me.dgAdrList.ReadOnly = True
        Me.dgAdrList.RowHeadersVisible = False
        Me.dgAdrList.RowTemplate.DividerHeight = 3
        Me.dgAdrList.RowTemplate.Height = 20
        Me.dgAdrList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgAdrList.ShowCellToolTips = False
        Me.dgAdrList.Size = New System.Drawing.Size(838, 125)
        Me.dgAdrList.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(24, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 15)
        Me.Label2.TabIndex = 199
        Me.Label2.Text = "APN Search"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(356, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 15)
        Me.Label3.TabIndex = 200
        Me.Label3.Text = "ParcelID Search"
        '
        'txtAPNQF
        '
        Me.txtAPNQF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAPNQF.ForeColor = System.Drawing.Color.Blue
        Me.txtAPNQF.Location = New System.Drawing.Point(27, 27)
        Me.txtAPNQF.Name = "txtAPNQF"
        Me.txtAPNQF.Size = New System.Drawing.Size(195, 20)
        Me.txtAPNQF.TabIndex = 201
        '
        'txtParcelIDQF
        '
        Me.txtParcelIDQF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtParcelIDQF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParcelIDQF.ForeColor = System.Drawing.Color.Green
        Me.txtParcelIDQF.Location = New System.Drawing.Point(360, 27)
        Me.txtParcelIDQF.Name = "txtParcelIDQF"
        Me.txtParcelIDQF.Size = New System.Drawing.Size(205, 21)
        Me.txtParcelIDQF.TabIndex = 202
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.GroupBox1.Controls.Add(Me.btnExporttoExcelAdr)
        Me.GroupBox1.Controls.Add(Me.lblAdrRowCount)
        Me.GroupBox1.Controls.Add(Me.dgAdrList)
        Me.GroupBox1.Controls.Add(Me.lblAPNID)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 381)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(898, 182)
        Me.GroupBox1.TabIndex = 204
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Row Above to Show Related Addresses"
        '
        'btnExporttoExcelAdr
        '
        Me.btnExporttoExcelAdr.Location = New System.Drawing.Point(676, 151)
        Me.btnExporttoExcelAdr.Name = "btnExporttoExcelAdr"
        Me.btnExporttoExcelAdr.Size = New System.Drawing.Size(173, 22)
        Me.btnExporttoExcelAdr.TabIndex = 244
        Me.btnExporttoExcelAdr.Text = "Export List to Excel"
        Me.btnExporttoExcelAdr.UseVisualStyleBackColor = True
        '
        'lblAdrRowCount
        '
        Me.lblAdrRowCount.AutoSize = True
        Me.lblAdrRowCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdrRowCount.Location = New System.Drawing.Point(315, 148)
        Me.lblAdrRowCount.Name = "lblAdrRowCount"
        Me.lblAdrRowCount.Size = New System.Drawing.Size(14, 13)
        Me.lblAdrRowCount.TabIndex = 216
        Me.lblAdrRowCount.Text = "0"
        '
        'lblAPNID
        '
        Me.lblAPNID.AutoSize = True
        Me.lblAPNID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAPNID.ForeColor = System.Drawing.Color.Blue
        Me.lblAPNID.Location = New System.Drawing.Point(89, 148)
        Me.lblAPNID.Name = "lblAPNID"
        Me.lblAPNID.Size = New System.Drawing.Size(91, 13)
        Me.lblAPNID.TabIndex = 218
        Me.lblAPNID.Text = "None Selected"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(197, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 13)
        Me.Label7.TabIndex = 215
        Me.Label7.Text = "# of Records found:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(34, 148)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 217
        Me.Label8.Text = "APNID:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(606, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 13)
        Me.Label4.TabIndex = 206
        Me.Label4.Text = "# of Records found:"
        '
        'lblNumRecFound
        '
        Me.lblNumRecFound.AutoSize = True
        Me.lblNumRecFound.Location = New System.Drawing.Point(724, 33)
        Me.lblNumRecFound.Name = "lblNumRecFound"
        Me.lblNumRecFound.Size = New System.Drawing.Size(14, 13)
        Me.lblNumRecFound.TabIndex = 207
        Me.lblNumRecFound.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(9, 350)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(431, 16)
        Me.Label5.TabIndex = 208
        Me.Label5.Text = "**Double click on the ParcID to view only APNs for that Parcel"
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(468, 569)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 209
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(652, 570)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 22)
        Me.btnExit.TabIndex = 210
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(157, 9)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 13)
        Me.Label25.TabIndex = 213
        Me.Label25.Text = "(F8 or Enter)"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(733, 576)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(31, 13)
        Me.Label24.TabIndex = 212
        Me.Label24.Text = "(F12)"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(549, 575)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(25, 13)
        Me.Label23.TabIndex = 211
        Me.Label23.Text = "(F1)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(500, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 214
        Me.Label6.Text = "(F8 or Enter)"
        '
        'btnParcelGetFtr
        '
        Me.btnParcelGetFtr.Location = New System.Drawing.Point(64, 570)
        Me.btnParcelGetFtr.Name = "btnParcelGetFtr"
        Me.btnParcelGetFtr.Size = New System.Drawing.Size(220, 23)
        Me.btnParcelGetFtr.TabIndex = 215
        Me.btnParcelGetFtr.Text = "Get Selected Parcel in Map"
        Me.btnParcelGetFtr.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(262, 14)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(57, 31)
        Me.Label26.TabIndex = 216
        Me.Label26.Text = "OR"
        '
        'btnExportData
        '
        Me.btnExportData.Location = New System.Drawing.Point(688, 350)
        Me.btnExportData.Name = "btnExportData"
        Me.btnExportData.Size = New System.Drawing.Size(173, 25)
        Me.btnExportData.TabIndex = 243
        Me.btnExportData.Text = "Export List to Excel"
        Me.btnExportData.UseVisualStyleBackColor = True
        '
        'frmQueryApn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 599)
        Me.Controls.Add(Me.btnExportData)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.btnParcelGetFtr)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblNumRecFound)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtParcelIDQF)
        Me.Controls.Add(Me.txtAPNQF)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgAPNList)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "frmQueryApn"
        Me.Text = "Query by APN or Parcel ID"
        CType(Me.dgAPNList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgAdrList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgAPNList As System.Windows.Forms.DataGridView
    Friend WithEvents dgAdrList As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAPNQF As System.Windows.Forms.TextBox
    Friend WithEvents txtParcelIDQF As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblNumRecFound As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblAdrRowCount As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblAPNID As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnParcelGetFtr As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents btnExporttoExcelAdr As System.Windows.Forms.Button
    Friend WithEvents btnExportData As System.Windows.Forms.Button
End Class
