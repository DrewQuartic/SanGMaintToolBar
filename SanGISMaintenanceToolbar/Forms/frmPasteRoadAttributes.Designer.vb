<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPasteRoadAttributes
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGetUniqueRoadIDs = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.cboRoadIDs = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gbSegInfo = New System.Windows.Forms.GroupBox()
        Me.txtAddrHR = New System.Windows.Forms.TextBox()
        Me.txtAddrLR = New System.Windows.Forms.TextBox()
        Me.txtAddrHL = New System.Windows.Forms.TextBox()
        Me.txtAddrLL = New System.Windows.Forms.TextBox()
        Me.txtSpeed = New System.Windows.Forms.TextBox()
        Me.txtRightWay = New System.Windows.Forms.TextBox()
        Me.cboR_Zip = New System.Windows.Forms.ComboBox()
        Me.cboL_Zip = New System.Windows.Forms.ComboBox()
        Me.cboOBMH = New System.Windows.Forms.ComboBox()
        Me.cboCarto = New System.Windows.Forms.ComboBox()
        Me.cboRMixAddr = New System.Windows.Forms.ComboBox()
        Me.cboLMixAddr = New System.Windows.Forms.ComboBox()
        Me.cboOneWay = New System.Windows.Forms.ComboBox()
        Me.cboFunClass = New System.Windows.Forms.ComboBox()
        Me.cboSegStat = New System.Windows.Forms.ComboBox()
        Me.cboFireDriv = New System.Windows.Forms.ComboBox()
        Me.cboSegClass = New System.Windows.Forms.ComboBox()
        Me.cboRJurisdic = New System.Windows.Forms.ComboBox()
        Me.cboLJurisdic = New System.Windows.Forms.ComboBox()
        Me.cboDedStat = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTLEV = New System.Windows.Forms.ComboBox()
        Me.cboFLEV = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.gbSegInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Road ID:"
        '
        'btnGetUniqueRoadIDs
        '
        Me.btnGetUniqueRoadIDs.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetUniqueRoadIDs.Location = New System.Drawing.Point(67, 25)
        Me.btnGetUniqueRoadIDs.Name = "btnGetUniqueRoadIDs"
        Me.btnGetUniqueRoadIDs.Size = New System.Drawing.Size(39, 37)
        Me.btnGetUniqueRoadIDs.TabIndex = 1
        Me.btnGetUniqueRoadIDs.Text = "GET IDS"
        Me.btnGetUniqueRoadIDs.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(293, 32)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(54, 23)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = ">>"
        Me.btnNext.UseVisualStyleBackColor = True
        Me.btnNext.Visible = False
        '
        'cboRoadIDs
        '
        Me.cboRoadIDs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRoadIDs.FormattingEnabled = True
        Me.cboRoadIDs.Location = New System.Drawing.Point(112, 32)
        Me.cboRoadIDs.Name = "cboRoadIDs"
        Me.cboRoadIDs.Size = New System.Drawing.Size(160, 21)
        Me.cboRoadIDs.TabIndex = 3
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(147, 70)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(89, 23)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(267, 70)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gbSegInfo)
        Me.GroupBox1.Controls.Add(Me.cmdClose)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnGetUniqueRoadIDs)
        Me.GroupBox1.Controls.Add(Me.cboRoadIDs)
        Me.GroupBox1.Controls.Add(Me.btnNext)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(375, 575)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Alter Road Attributes"
        '
        'gbSegInfo
        '
        Me.gbSegInfo.Controls.Add(Me.cboTLEV)
        Me.gbSegInfo.Controls.Add(Me.cboFLEV)
        Me.gbSegInfo.Controls.Add(Me.Label4)
        Me.gbSegInfo.Controls.Add(Me.Label11)
        Me.gbSegInfo.Controls.Add(Me.txtAddrHR)
        Me.gbSegInfo.Controls.Add(Me.txtAddrLR)
        Me.gbSegInfo.Controls.Add(Me.txtAddrHL)
        Me.gbSegInfo.Controls.Add(Me.txtAddrLL)
        Me.gbSegInfo.Controls.Add(Me.txtSpeed)
        Me.gbSegInfo.Controls.Add(Me.txtRightWay)
        Me.gbSegInfo.Controls.Add(Me.cboR_Zip)
        Me.gbSegInfo.Controls.Add(Me.cboL_Zip)
        Me.gbSegInfo.Controls.Add(Me.cboOBMH)
        Me.gbSegInfo.Controls.Add(Me.cboCarto)
        Me.gbSegInfo.Controls.Add(Me.cboRMixAddr)
        Me.gbSegInfo.Controls.Add(Me.cboLMixAddr)
        Me.gbSegInfo.Controls.Add(Me.cboOneWay)
        Me.gbSegInfo.Controls.Add(Me.cboFunClass)
        Me.gbSegInfo.Controls.Add(Me.cboSegStat)
        Me.gbSegInfo.Controls.Add(Me.cboFireDriv)
        Me.gbSegInfo.Controls.Add(Me.cboSegClass)
        Me.gbSegInfo.Controls.Add(Me.cboRJurisdic)
        Me.gbSegInfo.Controls.Add(Me.cboLJurisdic)
        Me.gbSegInfo.Controls.Add(Me.cboDedStat)
        Me.gbSegInfo.Controls.Add(Me.Label21)
        Me.gbSegInfo.Controls.Add(Me.Label20)
        Me.gbSegInfo.Controls.Add(Me.Label19)
        Me.gbSegInfo.Controls.Add(Me.Label18)
        Me.gbSegInfo.Controls.Add(Me.Label17)
        Me.gbSegInfo.Controls.Add(Me.Label16)
        Me.gbSegInfo.Controls.Add(Me.Label15)
        Me.gbSegInfo.Controls.Add(Me.Label14)
        Me.gbSegInfo.Controls.Add(Me.Label13)
        Me.gbSegInfo.Controls.Add(Me.Label10)
        Me.gbSegInfo.Controls.Add(Me.Label9)
        Me.gbSegInfo.Controls.Add(Me.Label8)
        Me.gbSegInfo.Controls.Add(Me.Label7)
        Me.gbSegInfo.Controls.Add(Me.Label6)
        Me.gbSegInfo.Controls.Add(Me.Label5)
        Me.gbSegInfo.Controls.Add(Me.Label3)
        Me.gbSegInfo.Controls.Add(Me.Label2)
        Me.gbSegInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSegInfo.Location = New System.Drawing.Point(14, 113)
        Me.gbSegInfo.Name = "gbSegInfo"
        Me.gbSegInfo.Size = New System.Drawing.Size(351, 455)
        Me.gbSegInfo.TabIndex = 7
        Me.gbSegInfo.TabStop = False
        Me.gbSegInfo.Text = "Segement 1: 99999"
        '
        'txtAddrHR
        '
        Me.txtAddrHR.Location = New System.Drawing.Point(222, 380)
        Me.txtAddrHR.Name = "txtAddrHR"
        Me.txtAddrHR.Size = New System.Drawing.Size(89, 20)
        Me.txtAddrHR.TabIndex = 40
        '
        'txtAddrLR
        '
        Me.txtAddrLR.Location = New System.Drawing.Point(222, 348)
        Me.txtAddrLR.Name = "txtAddrLR"
        Me.txtAddrLR.Size = New System.Drawing.Size(89, 20)
        Me.txtAddrLR.TabIndex = 39
        '
        'txtAddrHL
        '
        Me.txtAddrHL.Location = New System.Drawing.Point(98, 380)
        Me.txtAddrHL.Name = "txtAddrHL"
        Me.txtAddrHL.Size = New System.Drawing.Size(96, 20)
        Me.txtAddrHL.TabIndex = 38
        '
        'txtAddrLL
        '
        Me.txtAddrLL.Location = New System.Drawing.Point(98, 348)
        Me.txtAddrLL.Name = "txtAddrLL"
        Me.txtAddrLL.Size = New System.Drawing.Size(96, 20)
        Me.txtAddrLL.TabIndex = 37
        '
        'txtSpeed
        '
        Me.txtSpeed.Location = New System.Drawing.Point(254, 85)
        Me.txtSpeed.Name = "txtSpeed"
        Me.txtSpeed.Size = New System.Drawing.Size(87, 20)
        Me.txtSpeed.TabIndex = 36
        '
        'txtRightWay
        '
        Me.txtRightWay.Location = New System.Drawing.Point(253, 144)
        Me.txtRightWay.Name = "txtRightWay"
        Me.txtRightWay.Size = New System.Drawing.Size(88, 20)
        Me.txtRightWay.TabIndex = 35
        '
        'cboR_Zip
        '
        Me.cboR_Zip.FormattingEnabled = True
        Me.cboR_Zip.Location = New System.Drawing.Point(222, 416)
        Me.cboR_Zip.Name = "cboR_Zip"
        Me.cboR_Zip.Size = New System.Drawing.Size(89, 21)
        Me.cboR_Zip.TabIndex = 33
        '
        'cboL_Zip
        '
        Me.cboL_Zip.FormattingEnabled = True
        Me.cboL_Zip.Location = New System.Drawing.Point(98, 416)
        Me.cboL_Zip.Name = "cboL_Zip"
        Me.cboL_Zip.Size = New System.Drawing.Size(96, 21)
        Me.cboL_Zip.TabIndex = 32
        '
        'cboOBMH
        '
        Me.cboOBMH.FormattingEnabled = True
        Me.cboOBMH.Location = New System.Drawing.Point(65, 146)
        Me.cboOBMH.Name = "cboOBMH"
        Me.cboOBMH.Size = New System.Drawing.Size(87, 21)
        Me.cboOBMH.TabIndex = 31
        '
        'cboCarto
        '
        Me.cboCarto.FormattingEnabled = True
        Me.cboCarto.Location = New System.Drawing.Point(65, 84)
        Me.cboCarto.Name = "cboCarto"
        Me.cboCarto.Size = New System.Drawing.Size(109, 21)
        Me.cboCarto.TabIndex = 30
        '
        'cboRMixAddr
        '
        Me.cboRMixAddr.FormattingEnabled = True
        Me.cboRMixAddr.Location = New System.Drawing.Point(222, 285)
        Me.cboRMixAddr.Name = "cboRMixAddr"
        Me.cboRMixAddr.Size = New System.Drawing.Size(106, 21)
        Me.cboRMixAddr.TabIndex = 29
        '
        'cboLMixAddr
        '
        Me.cboLMixAddr.FormattingEnabled = True
        Me.cboLMixAddr.Location = New System.Drawing.Point(85, 285)
        Me.cboLMixAddr.Name = "cboLMixAddr"
        Me.cboLMixAddr.Size = New System.Drawing.Size(109, 21)
        Me.cboLMixAddr.TabIndex = 28
        '
        'cboOneWay
        '
        Me.cboOneWay.FormattingEnabled = True
        Me.cboOneWay.Location = New System.Drawing.Point(65, 114)
        Me.cboOneWay.Name = "cboOneWay"
        Me.cboOneWay.Size = New System.Drawing.Size(87, 21)
        Me.cboOneWay.TabIndex = 27
        '
        'cboFunClass
        '
        Me.cboFunClass.FormattingEnabled = True
        Me.cboFunClass.Location = New System.Drawing.Point(254, 57)
        Me.cboFunClass.Name = "cboFunClass"
        Me.cboFunClass.Size = New System.Drawing.Size(87, 21)
        Me.cboFunClass.TabIndex = 26
        '
        'cboSegStat
        '
        Me.cboSegStat.FormattingEnabled = True
        Me.cboSegStat.Location = New System.Drawing.Point(254, 29)
        Me.cboSegStat.Name = "cboSegStat"
        Me.cboSegStat.Size = New System.Drawing.Size(87, 21)
        Me.cboSegStat.TabIndex = 25
        '
        'cboFireDriv
        '
        Me.cboFireDriv.FormattingEnabled = True
        Me.cboFireDriv.Location = New System.Drawing.Point(253, 117)
        Me.cboFireDriv.Name = "cboFireDriv"
        Me.cboFireDriv.Size = New System.Drawing.Size(88, 21)
        Me.cboFireDriv.TabIndex = 24
        '
        'cboSegClass
        '
        Me.cboSegClass.FormattingEnabled = True
        Me.cboSegClass.Location = New System.Drawing.Point(65, 57)
        Me.cboSegClass.Name = "cboSegClass"
        Me.cboSegClass.Size = New System.Drawing.Size(109, 21)
        Me.cboSegClass.TabIndex = 23
        '
        'cboRJurisdic
        '
        Me.cboRJurisdic.FormattingEnabled = True
        Me.cboRJurisdic.Location = New System.Drawing.Point(222, 253)
        Me.cboRJurisdic.Name = "cboRJurisdic"
        Me.cboRJurisdic.Size = New System.Drawing.Size(109, 21)
        Me.cboRJurisdic.TabIndex = 22
        '
        'cboLJurisdic
        '
        Me.cboLJurisdic.FormattingEnabled = True
        Me.cboLJurisdic.Location = New System.Drawing.Point(85, 249)
        Me.cboLJurisdic.Name = "cboLJurisdic"
        Me.cboLJurisdic.Size = New System.Drawing.Size(109, 21)
        Me.cboLJurisdic.TabIndex = 21
        '
        'cboDedStat
        '
        Me.cboDedStat.FormattingEnabled = True
        Me.cboDedStat.Location = New System.Drawing.Point(65, 29)
        Me.cboDedStat.Name = "cboDedStat"
        Me.cboDedStat.Size = New System.Drawing.Size(109, 21)
        Me.cboDedStat.TabIndex = 20
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(48, 381)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(44, 16)
        Me.Label21.TabIndex = 19
        Me.Label21.Text = "High:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(54, 349)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 16)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = "Low:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(251, 220)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 16)
        Me.Label19.TabIndex = 17
        Me.Label19.Text = "Right"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(119, 220)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(33, 16)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "Left"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label17.Location = New System.Drawing.Point(9, 315)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 18)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Address"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(15, 149)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 13)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "OBMH:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(22, 87)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Carto:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(204, 88)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Speed:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(188, 147)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "RightWay:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(27, 288)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "MixAddr:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 117)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "OneWay:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(197, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "FunClass:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(202, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "SegStat:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(201, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "FireDriv:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "SegClass:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 252)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Jurisdic:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "DedStat:"
        '
        'cboTLEV
        '
        Me.cboTLEV.FormattingEnabled = True
        Me.cboTLEV.Location = New System.Drawing.Point(254, 176)
        Me.cboTLEV.Name = "cboTLEV"
        Me.cboTLEV.Size = New System.Drawing.Size(87, 21)
        Me.cboTLEV.TabIndex = 44
        '
        'cboFLEV
        '
        Me.cboFLEV.FormattingEnabled = True
        Me.cboFLEV.Location = New System.Drawing.Point(65, 176)
        Me.cboFLEV.Name = "cboFLEV"
        Me.cboFLEV.Size = New System.Drawing.Size(87, 21)
        Me.cboFLEV.TabIndex = 43
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(205, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "T_Level:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 179)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "F_Level:"
        '
        'frmPasteRoadAttributes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 587)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmPasteRoadAttributes"
        Me.Text = "Set Attributes of Pasted Roads"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbSegInfo.ResumeLayout(False)
        Me.gbSegInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGetUniqueRoadIDs As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents cboRoadIDs As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbSegInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboR_Zip As System.Windows.Forms.ComboBox
    Friend WithEvents cboL_Zip As System.Windows.Forms.ComboBox
    Friend WithEvents cboOBMH As System.Windows.Forms.ComboBox
    Friend WithEvents cboCarto As System.Windows.Forms.ComboBox
    Friend WithEvents cboRMixAddr As System.Windows.Forms.ComboBox
    Friend WithEvents cboLMixAddr As System.Windows.Forms.ComboBox
    Friend WithEvents cboOneWay As System.Windows.Forms.ComboBox
    Friend WithEvents cboFunClass As System.Windows.Forms.ComboBox
    Friend WithEvents cboSegStat As System.Windows.Forms.ComboBox
    Friend WithEvents cboFireDriv As System.Windows.Forms.ComboBox
    Friend WithEvents cboSegClass As System.Windows.Forms.ComboBox
    Friend WithEvents cboRJurisdic As System.Windows.Forms.ComboBox
    Friend WithEvents cboLJurisdic As System.Windows.Forms.ComboBox
    Friend WithEvents cboDedStat As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtAddrHR As System.Windows.Forms.TextBox
    Friend WithEvents txtAddrLR As System.Windows.Forms.TextBox
    Friend WithEvents txtAddrHL As System.Windows.Forms.TextBox
    Friend WithEvents txtAddrLL As System.Windows.Forms.TextBox
    Friend WithEvents txtSpeed As System.Windows.Forms.TextBox
    Friend WithEvents txtRightWay As System.Windows.Forms.TextBox
    Friend WithEvents cboTLEV As System.Windows.Forms.ComboBox
    Friend WithEvents cboFLEV As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
