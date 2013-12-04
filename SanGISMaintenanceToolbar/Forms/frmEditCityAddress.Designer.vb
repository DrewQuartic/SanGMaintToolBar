<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditCityAddress
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
        Me.btnAdrLgReset = New System.Windows.Forms.Button()
        Me.btnAdrLgExit = New System.Windows.Forms.Button()
        Me.btnAdrLgSave = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cboAdrLgSelectName = New System.Windows.Forms.ComboBox()
        Me.lblAdrSelectName = New System.Windows.Forms.Label()
        Me.dgvAdrLogList = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtAdrWONum = New System.Windows.Forms.TextBox()
        Me.txtAdrAPN = New System.Windows.Forms.TextBox()
        Me.txtAdrMapName = New System.Windows.Forms.TextBox()
        Me.txtAdrRdsegID = New System.Windows.Forms.TextBox()
        Me.txtAdrCityID = New System.Windows.Forms.TextBox()
        Me.txtAdrAdress = New System.Windows.Forms.TextBox()
        Me.txtAdrFraction = New System.Windows.Forms.TextBox()
        Me.txtAdrRdName = New System.Windows.Forms.TextBox()
        Me.txtAdrUnit = New System.Windows.Forms.TextBox()
        Me.txtAdrRdSfx = New System.Windows.Forms.TextBox()
        Me.txtAdrPreDir = New System.Windows.Forms.TextBox()
        Me.txtAdrRdSDir = New System.Windows.Forms.TextBox()
        Me.txtAdrAbLOaddr = New System.Windows.Forms.TextBox()
        Me.txtAdrAbHiaddr = New System.Windows.Forms.TextBox()
        Me.txtAdrLLowAddr = New System.Windows.Forms.TextBox()
        Me.txtAdrLHiAddr = New System.Windows.Forms.TextBox()
        Me.txtAdrRtLowAddr = New System.Windows.Forms.TextBox()
        Me.txtAdrRtHiAddr = New System.Windows.Forms.TextBox()
        Me.cboAdrCompleted = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtRdSearchQF = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnAdrSaveAll = New System.Windows.Forms.Button()
        Me.dtAdrToSanGIS = New System.Windows.Forms.TextBox()
        Me.btnAdrSaveSel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnExportData = New System.Windows.Forms.Button()
        CType(Me.dgvAdrLogList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAdrLgReset
        '
        Me.btnAdrLgReset.Location = New System.Drawing.Point(384, 572)
        Me.btnAdrLgReset.Name = "btnAdrLgReset"
        Me.btnAdrLgReset.Size = New System.Drawing.Size(75, 36)
        Me.btnAdrLgReset.TabIndex = 132
        Me.btnAdrLgReset.Text = "RESET FORM"
        Me.btnAdrLgReset.UseVisualStyleBackColor = True
        '
        'btnAdrLgExit
        '
        Me.btnAdrLgExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAdrLgExit.Location = New System.Drawing.Point(560, 572)
        Me.btnAdrLgExit.Name = "btnAdrLgExit"
        Me.btnAdrLgExit.Size = New System.Drawing.Size(67, 36)
        Me.btnAdrLgExit.TabIndex = 133
        Me.btnAdrLgExit.Text = "EXIT"
        Me.btnAdrLgExit.UseVisualStyleBackColor = True
        '
        'btnAdrLgSave
        '
        Me.btnAdrLgSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdrLgSave.Location = New System.Drawing.Point(272, 572)
        Me.btnAdrLgSave.Name = "btnAdrLgSave"
        Me.btnAdrLgSave.Size = New System.Drawing.Size(104, 36)
        Me.btnAdrLgSave.TabIndex = 131
        Me.btnAdrLgSave.Text = "Update Single Address"
        Me.btnAdrLgSave.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(592, 13)
        Me.Label8.TabIndex = 196
        Me.Label8.Text = "---------------------------------------------------------------------------------" & _
    "--------------------------------------------------------------------------------" & _
    "----------------------------------"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(117, 48)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 13)
        Me.Label25.TabIndex = 195
        Me.Label25.Text = "(F8 or Enter)"
        '
        'cboAdrLgSelectName
        '
        Me.cboAdrLgSelectName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAdrLgSelectName.Enabled = False
        Me.cboAdrLgSelectName.FormattingEnabled = True
        Me.cboAdrLgSelectName.Location = New System.Drawing.Point(354, 25)
        Me.cboAdrLgSelectName.MaxDropDownItems = 20
        Me.cboAdrLgSelectName.Name = "cboAdrLgSelectName"
        Me.cboAdrLgSelectName.Size = New System.Drawing.Size(236, 21)
        Me.cboAdrLgSelectName.TabIndex = 192
        '
        'lblAdrSelectName
        '
        Me.lblAdrSelectName.AutoSize = True
        Me.lblAdrSelectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdrSelectName.Location = New System.Drawing.Point(358, 48)
        Me.lblAdrSelectName.Name = "lblAdrSelectName"
        Me.lblAdrSelectName.Size = New System.Drawing.Size(193, 13)
        Me.lblAdrSelectName.TabIndex = 194
        Me.lblAdrSelectName.Text = "Select Road Name to display Addresses"
        '
        'dgvAdrLogList
        '
        Me.dgvAdrLogList.AllowUserToAddRows = False
        Me.dgvAdrLogList.AllowUserToDeleteRows = False
        Me.dgvAdrLogList.AllowUserToResizeColumns = False
        Me.dgvAdrLogList.AllowUserToResizeRows = False
        Me.dgvAdrLogList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dgvAdrLogList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAdrLogList.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAdrLogList.Location = New System.Drawing.Point(34, 80)
        Me.dgvAdrLogList.Name = "dgvAdrLogList"
        Me.dgvAdrLogList.ReadOnly = True
        Me.dgvAdrLogList.RowHeadersVisible = False
        Me.dgvAdrLogList.RowTemplate.DividerHeight = 2
        Me.dgvAdrLogList.RowTemplate.Height = 20
        Me.dgvAdrLogList.RowTemplate.ReadOnly = True
        Me.dgvAdrLogList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAdrLogList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvAdrLogList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAdrLogList.Size = New System.Drawing.Size(567, 175)
        Me.dgvAdrLogList.TabIndex = 197
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 312)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 199
        Me.Label2.Text = "Work Order"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 345)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 200
        Me.Label3.Text = "Map Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 381)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 201
        Me.Label4.Text = "RoadSegID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 413)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 202
        Me.Label5.Text = "To SanGIS"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(46, 448)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 203
        Me.Label6.Text = "Address"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(37, 482)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 204
        Me.Label7.Text = "AbLoAddr"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(39, 511)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 205
        Me.Label9.Text = "AbHiAddr"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(241, 312)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 13)
        Me.Label11.TabIndex = 206
        Me.Label11.Text = "Completed"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(387, 312)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 207
        Me.Label12.Text = "APN"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(260, 381)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 13)
        Me.Label13.TabIndex = 208
        Me.Label13.Text = "City ID"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(202, 482)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 13)
        Me.Label14.TabIndex = 209
        Me.Label14.Text = "LLowAddr"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(388, 482)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 13)
        Me.Label15.TabIndex = 210
        Me.Label15.Text = "RLowAddr"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(212, 511)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 13)
        Me.Label16.TabIndex = 211
        Me.Label16.Text = "LHiAddr"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(398, 511)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 13)
        Me.Label17.TabIndex = 212
        Me.Label17.Text = "RHiAddr"
        '
        'txtAdrWONum
        '
        Me.txtAdrWONum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdrWONum.Location = New System.Drawing.Point(95, 309)
        Me.txtAdrWONum.Name = "txtAdrWONum"
        Me.txtAdrWONum.Size = New System.Drawing.Size(121, 20)
        Me.txtAdrWONum.TabIndex = 213
        '
        'txtAdrAPN
        '
        Me.txtAdrAPN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdrAPN.Location = New System.Drawing.Point(422, 309)
        Me.txtAdrAPN.Name = "txtAdrAPN"
        Me.txtAdrAPN.Size = New System.Drawing.Size(184, 20)
        Me.txtAdrAPN.TabIndex = 214
        '
        'txtAdrMapName
        '
        Me.txtAdrMapName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdrMapName.Location = New System.Drawing.Point(95, 342)
        Me.txtAdrMapName.Name = "txtAdrMapName"
        Me.txtAdrMapName.Size = New System.Drawing.Size(427, 20)
        Me.txtAdrMapName.TabIndex = 215
        '
        'txtAdrRdsegID
        '
        Me.txtAdrRdsegID.Location = New System.Drawing.Point(95, 378)
        Me.txtAdrRdsegID.Name = "txtAdrRdsegID"
        Me.txtAdrRdsegID.ReadOnly = True
        Me.txtAdrRdsegID.Size = New System.Drawing.Size(121, 20)
        Me.txtAdrRdsegID.TabIndex = 216
        '
        'txtAdrCityID
        '
        Me.txtAdrCityID.Location = New System.Drawing.Point(308, 378)
        Me.txtAdrCityID.Name = "txtAdrCityID"
        Me.txtAdrCityID.ReadOnly = True
        Me.txtAdrCityID.Size = New System.Drawing.Size(100, 20)
        Me.txtAdrCityID.TabIndex = 217
        '
        'txtAdrAdress
        '
        Me.txtAdrAdress.Location = New System.Drawing.Point(99, 448)
        Me.txtAdrAdress.Name = "txtAdrAdress"
        Me.txtAdrAdress.ReadOnly = True
        Me.txtAdrAdress.Size = New System.Drawing.Size(73, 20)
        Me.txtAdrAdress.TabIndex = 218
        '
        'txtAdrFraction
        '
        Me.txtAdrFraction.Location = New System.Drawing.Point(178, 448)
        Me.txtAdrFraction.Name = "txtAdrFraction"
        Me.txtAdrFraction.ReadOnly = True
        Me.txtAdrFraction.Size = New System.Drawing.Size(31, 20)
        Me.txtAdrFraction.TabIndex = 219
        '
        'txtAdrRdName
        '
        Me.txtAdrRdName.Location = New System.Drawing.Point(322, 448)
        Me.txtAdrRdName.Name = "txtAdrRdName"
        Me.txtAdrRdName.ReadOnly = True
        Me.txtAdrRdName.Size = New System.Drawing.Size(206, 20)
        Me.txtAdrRdName.TabIndex = 220
        '
        'txtAdrUnit
        '
        Me.txtAdrUnit.Location = New System.Drawing.Point(215, 448)
        Me.txtAdrUnit.Name = "txtAdrUnit"
        Me.txtAdrUnit.ReadOnly = True
        Me.txtAdrUnit.Size = New System.Drawing.Size(40, 20)
        Me.txtAdrUnit.TabIndex = 221
        '
        'txtAdrRdSfx
        '
        Me.txtAdrRdSfx.Location = New System.Drawing.Point(534, 448)
        Me.txtAdrRdSfx.Name = "txtAdrRdSfx"
        Me.txtAdrRdSfx.ReadOnly = True
        Me.txtAdrRdSfx.Size = New System.Drawing.Size(35, 20)
        Me.txtAdrRdSfx.TabIndex = 222
        '
        'txtAdrPreDir
        '
        Me.txtAdrPreDir.Location = New System.Drawing.Point(289, 448)
        Me.txtAdrPreDir.Name = "txtAdrPreDir"
        Me.txtAdrPreDir.ReadOnly = True
        Me.txtAdrPreDir.Size = New System.Drawing.Size(24, 20)
        Me.txtAdrPreDir.TabIndex = 223
        '
        'txtAdrRdSDir
        '
        Me.txtAdrRdSDir.Location = New System.Drawing.Point(575, 448)
        Me.txtAdrRdSDir.Name = "txtAdrRdSDir"
        Me.txtAdrRdSDir.ReadOnly = True
        Me.txtAdrRdSDir.Size = New System.Drawing.Size(31, 20)
        Me.txtAdrRdSDir.TabIndex = 224
        '
        'txtAdrAbLOaddr
        '
        Me.txtAdrAbLOaddr.Location = New System.Drawing.Point(99, 479)
        Me.txtAdrAbLOaddr.Name = "txtAdrAbLOaddr"
        Me.txtAdrAbLOaddr.ReadOnly = True
        Me.txtAdrAbLOaddr.Size = New System.Drawing.Size(73, 20)
        Me.txtAdrAbLOaddr.TabIndex = 225
        '
        'txtAdrAbHiaddr
        '
        Me.txtAdrAbHiaddr.Location = New System.Drawing.Point(99, 508)
        Me.txtAdrAbHiaddr.Name = "txtAdrAbHiaddr"
        Me.txtAdrAbHiaddr.ReadOnly = True
        Me.txtAdrAbHiaddr.Size = New System.Drawing.Size(73, 20)
        Me.txtAdrAbHiaddr.TabIndex = 226
        '
        'txtAdrLLowAddr
        '
        Me.txtAdrLLowAddr.Location = New System.Drawing.Point(264, 479)
        Me.txtAdrLLowAddr.Name = "txtAdrLLowAddr"
        Me.txtAdrLLowAddr.ReadOnly = True
        Me.txtAdrLLowAddr.Size = New System.Drawing.Size(100, 20)
        Me.txtAdrLLowAddr.TabIndex = 227
        '
        'txtAdrLHiAddr
        '
        Me.txtAdrLHiAddr.Location = New System.Drawing.Point(264, 508)
        Me.txtAdrLHiAddr.Name = "txtAdrLHiAddr"
        Me.txtAdrLHiAddr.ReadOnly = True
        Me.txtAdrLHiAddr.Size = New System.Drawing.Size(100, 20)
        Me.txtAdrLHiAddr.TabIndex = 228
        '
        'txtAdrRtLowAddr
        '
        Me.txtAdrRtLowAddr.Location = New System.Drawing.Point(451, 479)
        Me.txtAdrRtLowAddr.Name = "txtAdrRtLowAddr"
        Me.txtAdrRtLowAddr.ReadOnly = True
        Me.txtAdrRtLowAddr.Size = New System.Drawing.Size(100, 20)
        Me.txtAdrRtLowAddr.TabIndex = 229
        '
        'txtAdrRtHiAddr
        '
        Me.txtAdrRtHiAddr.Location = New System.Drawing.Point(451, 508)
        Me.txtAdrRtHiAddr.Name = "txtAdrRtHiAddr"
        Me.txtAdrRtHiAddr.ReadOnly = True
        Me.txtAdrRtHiAddr.Size = New System.Drawing.Size(100, 20)
        Me.txtAdrRtHiAddr.TabIndex = 230
        '
        'cboAdrCompleted
        '
        Me.cboAdrCompleted.FormattingEnabled = True
        Me.cboAdrCompleted.Location = New System.Drawing.Point(308, 309)
        Me.cboAdrCompleted.Name = "cboAdrCompleted"
        Me.cboAdrCompleted.Size = New System.Drawing.Size(51, 21)
        Me.cboAdrCompleted.TabIndex = 231
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(57, 258)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(533, 16)
        Me.Label18.TabIndex = 233
        Me.Label18.Text = "Double Click ID or MAP NAME to enter Work Order and to update Completed"
        '
        'txtRdSearchQF
        '
        Me.txtRdSearchQF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRdSearchQF.Location = New System.Drawing.Point(42, 25)
        Me.txtRdSearchQF.Name = "txtRdSearchQF"
        Me.txtRdSearchQF.Size = New System.Drawing.Size(246, 20)
        Me.txtRdSearchQF.TabIndex = 234
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(39, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(249, 13)
        Me.Label19.TabIndex = 235
        Me.Label19.Text = "Enter Road Name (or Partial) to Search On"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 283)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(592, 13)
        Me.Label1.TabIndex = 236
        Me.Label1.Text = "---------------------------------------------------------------------------------" & _
    "--------------------------------------------------------------------------------" & _
    "----------------------------------"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(22, 546)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(592, 13)
        Me.Label10.TabIndex = 237
        Me.Label10.Text = "---------------------------------------------------------------------------------" & _
    "--------------------------------------------------------------------------------" & _
    "----------------------------------"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAdrSaveAll
        '
        Me.btnAdrSaveAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdrSaveAll.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnAdrSaveAll.Location = New System.Drawing.Point(19, 19)
        Me.btnAdrSaveAll.Name = "btnAdrSaveAll"
        Me.btnAdrSaveAll.Size = New System.Drawing.Size(67, 33)
        Me.btnAdrSaveAll.TabIndex = 238
        Me.btnAdrSaveAll.Text = "All Listed"
        Me.btnAdrSaveAll.UseVisualStyleBackColor = True
        '
        'dtAdrToSanGIS
        '
        Me.dtAdrToSanGIS.Location = New System.Drawing.Point(95, 410)
        Me.dtAdrToSanGIS.Name = "dtAdrToSanGIS"
        Me.dtAdrToSanGIS.ReadOnly = True
        Me.dtAdrToSanGIS.Size = New System.Drawing.Size(121, 20)
        Me.dtAdrToSanGIS.TabIndex = 239
        '
        'btnAdrSaveSel
        '
        Me.btnAdrSaveSel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdrSaveSel.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnAdrSaveSel.Location = New System.Drawing.Point(131, 19)
        Me.btnAdrSaveSel.Name = "btnAdrSaveSel"
        Me.btnAdrSaveSel.Size = New System.Drawing.Size(73, 33)
        Me.btnAdrSaveSel.TabIndex = 240
        Me.btnAdrSaveSel.Text = "Selected"
        Me.btnAdrSaveSel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAdrSaveAll)
        Me.GroupBox1.Controls.Add(Me.btnAdrSaveSel)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 562)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(254, 62)
        Me.GroupBox1.TabIndex = 241
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Update Multiple with WO, Comp, MapNm"
        '
        'btnExportData
        '
        Me.btnExportData.Location = New System.Drawing.Point(474, 572)
        Me.btnExportData.Name = "btnExportData"
        Me.btnExportData.Size = New System.Drawing.Size(77, 36)
        Me.btnExportData.TabIndex = 242
        Me.btnExportData.Text = "Export List to Excel"
        Me.btnExportData.UseVisualStyleBackColor = True
        '
        'frmEditCityAddress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 630)
        Me.Controls.Add(Me.btnExportData)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtAdrToSanGIS)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtRdSearchQF)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cboAdrCompleted)
        Me.Controls.Add(Me.txtAdrRtHiAddr)
        Me.Controls.Add(Me.txtAdrRtLowAddr)
        Me.Controls.Add(Me.txtAdrLHiAddr)
        Me.Controls.Add(Me.txtAdrLLowAddr)
        Me.Controls.Add(Me.txtAdrAbHiaddr)
        Me.Controls.Add(Me.txtAdrAbLOaddr)
        Me.Controls.Add(Me.txtAdrRdSDir)
        Me.Controls.Add(Me.txtAdrPreDir)
        Me.Controls.Add(Me.txtAdrRdSfx)
        Me.Controls.Add(Me.txtAdrUnit)
        Me.Controls.Add(Me.txtAdrRdName)
        Me.Controls.Add(Me.txtAdrFraction)
        Me.Controls.Add(Me.txtAdrAdress)
        Me.Controls.Add(Me.txtAdrCityID)
        Me.Controls.Add(Me.txtAdrRdsegID)
        Me.Controls.Add(Me.txtAdrMapName)
        Me.Controls.Add(Me.txtAdrAPN)
        Me.Controls.Add(Me.txtAdrWONum)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvAdrLogList)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.cboAdrLgSelectName)
        Me.Controls.Add(Me.lblAdrSelectName)
        Me.Controls.Add(Me.btnAdrLgReset)
        Me.Controls.Add(Me.btnAdrLgExit)
        Me.Controls.Add(Me.btnAdrLgSave)
        Me.Name = "frmEditCityAddress"
        Me.Text = "Edit City Address"
        CType(Me.dgvAdrLogList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAdrLgReset As System.Windows.Forms.Button
    Friend WithEvents btnAdrLgExit As System.Windows.Forms.Button
    Friend WithEvents btnAdrLgSave As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboAdrLgSelectName As System.Windows.Forms.ComboBox
    Friend WithEvents lblAdrSelectName As System.Windows.Forms.Label
    Friend WithEvents dgvAdrLogList As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtAdrWONum As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrAPN As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrMapName As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrRdsegID As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrCityID As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrAdress As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrFraction As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrRdName As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrRdSfx As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrPreDir As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrRdSDir As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrAbLOaddr As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrAbHiaddr As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrLLowAddr As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrLHiAddr As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrRtLowAddr As System.Windows.Forms.TextBox
    Friend WithEvents txtAdrRtHiAddr As System.Windows.Forms.TextBox
    Friend WithEvents cboAdrCompleted As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtRdSearchQF As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnAdrSaveAll As System.Windows.Forms.Button
    Friend WithEvents dtAdrToSanGIS As System.Windows.Forms.TextBox
    Friend WithEvents btnAdrSaveSel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExportData As System.Windows.Forms.Button
End Class
