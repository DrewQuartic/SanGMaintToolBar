<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditRoadName
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditRoadName))
        Me.txtRDNMRoadID = New System.Windows.Forms.TextBox()
        Me.lblRDNMSelectName = New System.Windows.Forms.Label()
        Me.btnRDNMSave = New System.Windows.Forms.Button()
        Me.ckbxRDNMSearch = New System.Windows.Forms.CheckBox()
        Me.cboRDNMSelectName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboRDNMRdNmPre = New System.Windows.Forms.ComboBox()
        Me.cboRDNMRdNmSuf = New System.Windows.Forms.ComboBox()
        Me.txtRDNMRdNm = New System.Windows.Forms.TextBox()
        Me.cboRDNMRdNmPstDir = New System.Windows.Forms.ComboBox()
        Me.cboRDNMRdNmJur = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRDNMRd30Pre = New System.Windows.Forms.TextBox()
        Me.txtRDNMRd30Nm = New System.Windows.Forms.TextBox()
        Me.txtRDNMRd30PstDir = New System.Windows.Forms.TextBox()
        Me.txtRDNMRd30Suf = New System.Windows.Forms.TextBox()
        Me.txtRDNMRd20Pre = New System.Windows.Forms.TextBox()
        Me.txtRDNMRd20Nm = New System.Windows.Forms.TextBox()
        Me.txtRDNMRd20Suf = New System.Windows.Forms.TextBox()
        Me.txtRDNMRdFll = New System.Windows.Forms.TextBox()
        Me.btnRDNMClearStandard = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtRDNMWkOrder = New System.Windows.Forms.TextBox()
        Me.txtRDNMTomBro = New System.Windows.Forms.TextBox()
        Me.cboRDNMMultiJur = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtRDNMReqBy = New System.Windows.Forms.TextBox()
        Me.txtRDNMTentMap = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.btnRDNMResetStnd = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnRDNMExit = New System.Windows.Forms.Button()
        Me.btnRDNMReset = New System.Windows.Forms.Button()
        Me.txtRDNMPstID = New System.Windows.Forms.TextBox()
        Me.txtRDNMPstDate = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.ckbxRDNameSearch = New System.Windows.Forms.CheckBox()
        Me.btnResetNoMap = New System.Windows.Forms.Button()
        Me.btnDeleteRDNM = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtKnwnRDID = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRDNMRoadID
        '
        Me.txtRDNMRoadID.Enabled = False
        Me.txtRDNMRoadID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRDNMRoadID.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtRDNMRoadID.Location = New System.Drawing.Point(131, 84)
        Me.txtRDNMRoadID.Name = "txtRDNMRoadID"
        Me.txtRDNMRoadID.Size = New System.Drawing.Size(126, 20)
        Me.txtRDNMRoadID.TabIndex = 43
        Me.txtRDNMRoadID.TabStop = False
        '
        'lblRDNMSelectName
        '
        Me.lblRDNMSelectName.AutoSize = True
        Me.lblRDNMSelectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRDNMSelectName.Location = New System.Drawing.Point(405, 9)
        Me.lblRDNMSelectName.Name = "lblRDNMSelectName"
        Me.lblRDNMSelectName.Size = New System.Drawing.Size(268, 13)
        Me.lblRDNMSelectName.TabIndex = 100
        Me.lblRDNMSelectName.Text = "Select RoadID/RoadName from List to Display Attributes"
        '
        'btnRDNMSave
        '
        Me.btnRDNMSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRDNMSave.Location = New System.Drawing.Point(37, 499)
        Me.btnRDNMSave.Name = "btnRDNMSave"
        Me.btnRDNMSave.Size = New System.Drawing.Size(87, 36)
        Me.btnRDNMSave.TabIndex = 20
        Me.btnRDNMSave.Text = "Add RoadName"
        Me.btnRDNMSave.UseVisualStyleBackColor = True
        '
        'ckbxRDNMSearch
        '
        Me.ckbxRDNMSearch.AutoSize = True
        Me.ckbxRDNMSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbxRDNMSearch.Location = New System.Drawing.Point(248, 12)
        Me.ckbxRDNMSearch.Name = "ckbxRDNMSearch"
        Me.ckbxRDNMSearch.Size = New System.Drawing.Size(134, 17)
        Me.ckbxRDNMSearch.TabIndex = 42
        Me.ckbxRDNMSearch.TabStop = False
        Me.ckbxRDNMSearch.Text = "Search by Road ID"
        Me.ckbxRDNMSearch.UseVisualStyleBackColor = True
        '
        'cboRDNMSelectName
        '
        Me.cboRDNMSelectName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRDNMSelectName.Enabled = False
        Me.cboRDNMSelectName.FormattingEnabled = True
        Me.cboRDNMSelectName.Location = New System.Drawing.Point(408, 25)
        Me.cboRDNMSelectName.MaxDropDownItems = 20
        Me.cboRDNMSelectName.Name = "cboRDNMSelectName"
        Me.cboRDNMSelectName.Size = New System.Drawing.Size(265, 21)
        Me.cboRDNMSelectName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Road Name"
        '
        'cboRDNMRdNmPre
        '
        Me.cboRDNMRdNmPre.FormattingEnabled = True
        Me.cboRDNMRdNmPre.Location = New System.Drawing.Point(131, 125)
        Me.cboRDNMRdNmPre.Name = "cboRDNMRdNmPre"
        Me.cboRDNMRdNmPre.Size = New System.Drawing.Size(71, 21)
        Me.cboRDNMRdNmPre.TabIndex = 1
        '
        'cboRDNMRdNmSuf
        '
        Me.cboRDNMRdNmSuf.FormattingEnabled = True
        Me.cboRDNMRdNmSuf.Location = New System.Drawing.Point(441, 125)
        Me.cboRDNMRdNmSuf.Name = "cboRDNMRdNmSuf"
        Me.cboRDNMRdNmSuf.Size = New System.Drawing.Size(81, 21)
        Me.cboRDNMRdNmSuf.TabIndex = 3
        '
        'txtRDNMRdNm
        '
        Me.txtRDNMRdNm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRDNMRdNm.Location = New System.Drawing.Point(223, 126)
        Me.txtRDNMRdNm.Name = "txtRDNMRdNm"
        Me.txtRDNMRdNm.Size = New System.Drawing.Size(203, 20)
        Me.txtRDNMRdNm.TabIndex = 2
        Me.txtRDNMRdNm.WordWrap = False
        '
        'cboRDNMRdNmPstDir
        '
        Me.cboRDNMRdNmPstDir.FormattingEnabled = True
        Me.cboRDNMRdNmPstDir.Location = New System.Drawing.Point(529, 126)
        Me.cboRDNMRdNmPstDir.Name = "cboRDNMRdNmPstDir"
        Me.cboRDNMRdNmPstDir.Size = New System.Drawing.Size(66, 21)
        Me.cboRDNMRdNmPstDir.TabIndex = 4
        '
        'cboRDNMRdNmJur
        '
        Me.cboRDNMRdNmJur.FormattingEnabled = True
        Me.cboRDNMRdNmJur.Location = New System.Drawing.Point(131, 159)
        Me.cboRDNMRdNmJur.Name = "cboRDNMRdNmJur"
        Me.cboRDNMRdNmJur.Size = New System.Drawing.Size(71, 21)
        Me.cboRDNMRdNmJur.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(65, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Jurisdiction"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(74, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 101
        Me.Label3.Text = "RoadID"
        '
        'txtRDNMRd30Pre
        '
        Me.txtRDNMRd30Pre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRDNMRd30Pre.Location = New System.Drawing.Point(186, 251)
        Me.txtRDNMRd30Pre.MaxLength = 1
        Me.txtRDNMRd30Pre.Name = "txtRDNMRd30Pre"
        Me.txtRDNMRd30Pre.Size = New System.Drawing.Size(47, 20)
        Me.txtRDNMRd30Pre.TabIndex = 7
        '
        'txtRDNMRd30Nm
        '
        Me.txtRDNMRd30Nm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRDNMRd30Nm.Location = New System.Drawing.Point(248, 251)
        Me.txtRDNMRd30Nm.MaxLength = 30
        Me.txtRDNMRd30Nm.Name = "txtRDNMRd30Nm"
        Me.txtRDNMRd30Nm.Size = New System.Drawing.Size(233, 20)
        Me.txtRDNMRd30Nm.TabIndex = 8
        '
        'txtRDNMRd30PstDir
        '
        Me.txtRDNMRd30PstDir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRDNMRd30PstDir.Location = New System.Drawing.Point(567, 249)
        Me.txtRDNMRd30PstDir.MaxLength = 1
        Me.txtRDNMRd30PstDir.Name = "txtRDNMRd30PstDir"
        Me.txtRDNMRd30PstDir.Size = New System.Drawing.Size(64, 20)
        Me.txtRDNMRd30PstDir.TabIndex = 10
        '
        'txtRDNMRd30Suf
        '
        Me.txtRDNMRd30Suf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRDNMRd30Suf.Location = New System.Drawing.Point(492, 249)
        Me.txtRDNMRd30Suf.MaxLength = 4
        Me.txtRDNMRd30Suf.Name = "txtRDNMRd30Suf"
        Me.txtRDNMRd30Suf.Size = New System.Drawing.Size(64, 20)
        Me.txtRDNMRd30Suf.TabIndex = 9
        '
        'txtRDNMRd20Pre
        '
        Me.txtRDNMRd20Pre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRDNMRd20Pre.Location = New System.Drawing.Point(186, 277)
        Me.txtRDNMRd20Pre.MaxLength = 1
        Me.txtRDNMRd20Pre.Name = "txtRDNMRd20Pre"
        Me.txtRDNMRd20Pre.Size = New System.Drawing.Size(47, 20)
        Me.txtRDNMRd20Pre.TabIndex = 11
        '
        'txtRDNMRd20Nm
        '
        Me.txtRDNMRd20Nm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRDNMRd20Nm.Location = New System.Drawing.Point(248, 277)
        Me.txtRDNMRd20Nm.MaxLength = 20
        Me.txtRDNMRd20Nm.Name = "txtRDNMRd20Nm"
        Me.txtRDNMRd20Nm.Size = New System.Drawing.Size(233, 20)
        Me.txtRDNMRd20Nm.TabIndex = 12
        '
        'txtRDNMRd20Suf
        '
        Me.txtRDNMRd20Suf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRDNMRd20Suf.Location = New System.Drawing.Point(492, 277)
        Me.txtRDNMRd20Suf.MaxLength = 2
        Me.txtRDNMRd20Suf.Name = "txtRDNMRd20Suf"
        Me.txtRDNMRd20Suf.Size = New System.Drawing.Size(64, 20)
        Me.txtRDNMRd20Suf.TabIndex = 13
        '
        'txtRDNMRdFll
        '
        Me.txtRDNMRdFll.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRDNMRdFll.Location = New System.Drawing.Point(186, 303)
        Me.txtRDNMRdFll.MaxLength = 50
        Me.txtRDNMRdFll.Name = "txtRDNMRdFll"
        Me.txtRDNMRdFll.Size = New System.Drawing.Size(424, 20)
        Me.txtRDNMRdFll.TabIndex = 14
        '
        'btnRDNMClearStandard
        '
        Me.btnRDNMClearStandard.Location = New System.Drawing.Point(37, 298)
        Me.btnRDNMClearStandard.Name = "btnRDNMClearStandard"
        Me.btnRDNMClearStandard.Size = New System.Drawing.Size(75, 23)
        Me.btnRDNMClearStandard.TabIndex = 23
        Me.btnRDNMClearStandard.TabStop = False
        Me.btnRDNMClearStandard.Text = "Clear"
        Me.btnRDNMClearStandard.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(34, 229)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "STANDARDIZED:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(130, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 111
        Me.Label5.Text = "Road-30"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(130, 277)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "Road-20"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(155, 303)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 13)
        Me.Label7.TabIndex = 113
        Me.Label7.Text = "Full"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtRDNMWkOrder)
        Me.GroupBox1.Controls.Add(Me.txtRDNMTomBro)
        Me.GroupBox1.Controls.Add(Me.cboRDNMMultiJur)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtRDNMReqBy)
        Me.GroupBox1.Controls.Add(Me.txtRDNMTentMap)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Location = New System.Drawing.Point(37, 389)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(619, 100)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        '
        'txtRDNMWkOrder
        '
        Me.txtRDNMWkOrder.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRDNMWkOrder.Location = New System.Drawing.Point(455, 69)
        Me.txtRDNMWkOrder.MaxLength = 10
        Me.txtRDNMWkOrder.Name = "txtRDNMWkOrder"
        Me.txtRDNMWkOrder.Size = New System.Drawing.Size(118, 20)
        Me.txtRDNMWkOrder.TabIndex = 19
        '
        'txtRDNMTomBro
        '
        Me.txtRDNMTomBro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRDNMTomBro.Location = New System.Drawing.Point(455, 39)
        Me.txtRDNMTomBro.MaxLength = 6
        Me.txtRDNMTomBro.Name = "txtRDNMTomBro"
        Me.txtRDNMTomBro.Size = New System.Drawing.Size(118, 20)
        Me.txtRDNMTomBro.TabIndex = 18
        '
        'cboRDNMMultiJur
        '
        Me.cboRDNMMultiJur.FormattingEnabled = True
        Me.cboRDNMMultiJur.Location = New System.Drawing.Point(455, 12)
        Me.cboRDNMMultiJur.Name = "cboRDNMMultiJur"
        Me.cboRDNMMultiJur.Size = New System.Drawing.Size(64, 21)
        Me.cboRDNMMultiJur.TabIndex = 17
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(401, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(43, 13)
        Me.Label15.TabIndex = 116
        Me.Label15.Text = "Multiple"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(365, 72)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 13)
        Me.Label14.TabIndex = 118
        Me.Label14.Text = "Work Order No"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(357, 42)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 13)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "Thomas Brothers"
        '
        'txtRDNMReqBy
        '
        Me.txtRDNMReqBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRDNMReqBy.Location = New System.Drawing.Point(173, 65)
        Me.txtRDNMReqBy.MaxLength = 20
        Me.txtRDNMReqBy.Name = "txtRDNMReqBy"
        Me.txtRDNMReqBy.Size = New System.Drawing.Size(135, 20)
        Me.txtRDNMReqBy.TabIndex = 16
        '
        'txtRDNMTentMap
        '
        Me.txtRDNMTentMap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRDNMTentMap.Location = New System.Drawing.Point(173, 35)
        Me.txtRDNMTentMap.MaxLength = 14
        Me.txtRDNMTentMap.Name = "txtRDNMTentMap"
        Me.txtRDNMTentMap.Size = New System.Drawing.Size(135, 20)
        Me.txtRDNMTentMap.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(93, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 115
        Me.Label12.Text = "Requested By"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(91, 42)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 13)
        Me.Label11.TabIndex = 114
        Me.Label11.Text = "Tentative Map"
        '
        'TextBox11
        '
        Me.TextBox11.Enabled = False
        Me.TextBox11.Location = New System.Drawing.Point(37, 363)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(619, 20)
        Me.TextBox11.TabIndex = 29
        Me.TextBox11.TabStop = False
        '
        'btnRDNMResetStnd
        '
        Me.btnRDNMResetStnd.Location = New System.Drawing.Point(261, 159)
        Me.btnRDNMResetStnd.Name = "btnRDNMResetStnd"
        Me.btnRDNMResetStnd.Size = New System.Drawing.Size(182, 23)
        Me.btnRDNMResetStnd.TabIndex = 6
        Me.btnRDNMResetStnd.Text = "Reset Standardized Fields"
        Me.btnRDNMResetStnd.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(670, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = resources.GetString("Label8.Text")
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 196)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(670, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = resources.GetString("Label9.Text")
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 338)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(670, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = resources.GetString("Label10.Text")
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnRDNMExit
        '
        Me.btnRDNMExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRDNMExit.Location = New System.Drawing.Point(581, 499)
        Me.btnRDNMExit.Name = "btnRDNMExit"
        Me.btnRDNMExit.Size = New System.Drawing.Size(75, 36)
        Me.btnRDNMExit.TabIndex = 22
        Me.btnRDNMExit.Text = "EXIT"
        Me.btnRDNMExit.UseVisualStyleBackColor = True
        '
        'btnRDNMReset
        '
        Me.btnRDNMReset.Location = New System.Drawing.Point(441, 499)
        Me.btnRDNMReset.Name = "btnRDNMReset"
        Me.btnRDNMReset.Size = New System.Drawing.Size(104, 36)
        Me.btnRDNMReset.TabIndex = 21
        Me.btnRDNMReset.Text = "RESET ENTIRE FORM"
        Me.btnRDNMReset.UseVisualStyleBackColor = True
        '
        'txtRDNMPstID
        '
        Me.txtRDNMPstID.Enabled = False
        Me.txtRDNMPstID.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtRDNMPstID.Location = New System.Drawing.Point(326, 86)
        Me.txtRDNMPstID.Name = "txtRDNMPstID"
        Me.txtRDNMPstID.Size = New System.Drawing.Size(100, 20)
        Me.txtRDNMPstID.TabIndex = 44
        Me.txtRDNMPstID.TabStop = False
        '
        'txtRDNMPstDate
        '
        Me.txtRDNMPstDate.Enabled = False
        Me.txtRDNMPstDate.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtRDNMPstDate.Location = New System.Drawing.Point(501, 86)
        Me.txtRDNMPstDate.Name = "txtRDNMPstDate"
        Me.txtRDNMPstDate.Size = New System.Drawing.Size(100, 20)
        Me.txtRDNMPstDate.TabIndex = 45
        Me.txtRDNMPstDate.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label16.Location = New System.Drawing.Point(281, 89)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 13)
        Me.Label16.TabIndex = 102
        Me.Label16.Text = "PostID"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label17.Location = New System.Drawing.Point(441, 88)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 13)
        Me.Label17.TabIndex = 103
        Me.Label17.Text = "Post Date"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(194, 232)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 13)
        Me.Label18.TabIndex = 107
        Me.Label18.Text = "Pre-Dir"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(323, 232)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(79, 13)
        Me.Label19.TabIndex = 108
        Me.Label19.Text = "Preferred name"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(508, 232)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(33, 13)
        Me.Label20.TabIndex = 109
        Me.Label20.Text = "Suffix"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(575, 232)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(44, 13)
        Me.Label21.TabIndex = 110
        Me.Label21.Text = "Post-Dir"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(51, 538)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(31, 13)
        Me.Label22.TabIndex = 114
        Me.Label22.Text = "(F10)"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(482, 538)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(25, 13)
        Me.Label23.TabIndex = 115
        Me.Label23.Text = "(F1)"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(600, 538)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(31, 13)
        Me.Label24.TabIndex = 116
        Me.Label24.Text = "(F12)"
        '
        'ckbxRDNameSearch
        '
        Me.ckbxRDNameSearch.AutoSize = True
        Me.ckbxRDNameSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbxRDNameSearch.Location = New System.Drawing.Point(248, 39)
        Me.ckbxRDNameSearch.Name = "ckbxRDNameSearch"
        Me.ckbxRDNameSearch.Size = New System.Drawing.Size(153, 17)
        Me.ckbxRDNameSearch.TabIndex = 117
        Me.ckbxRDNameSearch.TabStop = False
        Me.ckbxRDNameSearch.Text = "Search by Road Name"
        Me.ckbxRDNameSearch.UseVisualStyleBackColor = True
        '
        'btnResetNoMap
        '
        Me.btnResetNoMap.Location = New System.Drawing.Point(315, 499)
        Me.btnResetNoMap.Name = "btnResetNoMap"
        Me.btnResetNoMap.Size = New System.Drawing.Size(112, 36)
        Me.btnResetNoMap.TabIndex = 118
        Me.btnResetNoMap.Text = "RESET FORM" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (Leave Map Detail)"
        Me.btnResetNoMap.UseVisualStyleBackColor = True
        '
        'btnDeleteRDNM
        '
        Me.btnDeleteRDNM.Enabled = False
        Me.btnDeleteRDNM.ForeColor = System.Drawing.Color.Red
        Me.btnDeleteRDNM.Location = New System.Drawing.Point(143, 500)
        Me.btnDeleteRDNM.Name = "btnDeleteRDNM"
        Me.btnDeleteRDNM.Size = New System.Drawing.Size(81, 35)
        Me.btnDeleteRDNM.TabIndex = 119
        Me.btnDeleteRDNM.Text = "DELETE " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ROAD NAME"
        Me.btnDeleteRDNM.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(21, 9)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(107, 26)
        Me.Label25.TabIndex = 120
        Me.Label25.Text = "Input Known RoadID" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (and press Enter)"
        '
        'txtKnwnRDID
        '
        Me.txtKnwnRDID.Location = New System.Drawing.Point(24, 39)
        Me.txtKnwnRDID.Name = "txtKnwnRDID"
        Me.txtKnwnRDID.Size = New System.Drawing.Size(100, 20)
        Me.txtKnwnRDID.TabIndex = 121
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(176, 15)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(57, 31)
        Me.Label26.TabIndex = 122
        Me.Label26.Text = "OR"
        '
        'frmEditRoadName
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 554)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtKnwnRDID)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.btnDeleteRDNM)
        Me.Controls.Add(Me.btnResetNoMap)
        Me.Controls.Add(Me.ckbxRDNameSearch)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtRDNMPstDate)
        Me.Controls.Add(Me.txtRDNMPstID)
        Me.Controls.Add(Me.btnRDNMReset)
        Me.Controls.Add(Me.btnRDNMExit)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnRDNMResetStnd)
        Me.Controls.Add(Me.TextBox11)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnRDNMClearStandard)
        Me.Controls.Add(Me.txtRDNMRdFll)
        Me.Controls.Add(Me.txtRDNMRd20Suf)
        Me.Controls.Add(Me.txtRDNMRd20Nm)
        Me.Controls.Add(Me.txtRDNMRd20Pre)
        Me.Controls.Add(Me.txtRDNMRd30Suf)
        Me.Controls.Add(Me.txtRDNMRd30PstDir)
        Me.Controls.Add(Me.txtRDNMRd30Nm)
        Me.Controls.Add(Me.txtRDNMRd30Pre)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboRDNMRdNmJur)
        Me.Controls.Add(Me.cboRDNMRdNmPstDir)
        Me.Controls.Add(Me.txtRDNMRdNm)
        Me.Controls.Add(Me.cboRDNMRdNmSuf)
        Me.Controls.Add(Me.cboRDNMRdNmPre)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboRDNMSelectName)
        Me.Controls.Add(Me.ckbxRDNMSearch)
        Me.Controls.Add(Me.btnRDNMSave)
        Me.Controls.Add(Me.lblRDNMSelectName)
        Me.Controls.Add(Me.txtRDNMRoadID)
        Me.KeyPreview = True
        Me.Name = "frmEditRoadName"
        Me.Text = "EDIT ROAD NAME"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRDNMRoadID As System.Windows.Forms.TextBox
    Friend WithEvents lblRDNMSelectName As System.Windows.Forms.Label
    Friend WithEvents btnRDNMSave As System.Windows.Forms.Button
    Friend WithEvents ckbxRDNMSearch As System.Windows.Forms.CheckBox
    Friend WithEvents cboRDNMSelectName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboRDNMRdNmPre As System.Windows.Forms.ComboBox
    Friend WithEvents cboRDNMRdNmSuf As System.Windows.Forms.ComboBox
    Friend WithEvents txtRDNMRdNm As System.Windows.Forms.TextBox
    Friend WithEvents cboRDNMRdNmPstDir As System.Windows.Forms.ComboBox
    Friend WithEvents cboRDNMRdNmJur As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRDNMRd30Pre As System.Windows.Forms.TextBox
    Friend WithEvents txtRDNMRd30Nm As System.Windows.Forms.TextBox
    Friend WithEvents txtRDNMRd30PstDir As System.Windows.Forms.TextBox
    Friend WithEvents txtRDNMRd30Suf As System.Windows.Forms.TextBox
    Friend WithEvents txtRDNMRd20Pre As System.Windows.Forms.TextBox
    Friend WithEvents txtRDNMRd20Nm As System.Windows.Forms.TextBox
    Friend WithEvents txtRDNMRd20Suf As System.Windows.Forms.TextBox
    Friend WithEvents txtRDNMRdFll As System.Windows.Forms.TextBox
    Friend WithEvents btnRDNMClearStandard As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents btnRDNMResetStnd As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtRDNMReqBy As System.Windows.Forms.TextBox
    Friend WithEvents txtRDNMTentMap As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtRDNMTomBro As System.Windows.Forms.TextBox
    Friend WithEvents cboRDNMMultiJur As System.Windows.Forms.ComboBox
    Friend WithEvents txtRDNMWkOrder As System.Windows.Forms.TextBox
    Friend WithEvents btnRDNMExit As System.Windows.Forms.Button
    Friend WithEvents btnRDNMReset As System.Windows.Forms.Button
    Friend WithEvents txtRDNMPstID As System.Windows.Forms.TextBox
    Friend WithEvents txtRDNMPstDate As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        IsInitializing = True
        InitializeComponent()
        IsInitializing = False

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Friend WithEvents ckbxRDNameSearch As System.Windows.Forms.CheckBox
    Friend WithEvents btnResetNoMap As System.Windows.Forms.Button
    Friend WithEvents btnDeleteRDNM As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtKnwnRDID As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
End Class
