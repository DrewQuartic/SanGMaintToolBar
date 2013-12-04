<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSplitRoadAttributes
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
        Me.gbxRoadInfo = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnGetUniqueRoadIDs = New System.Windows.Forms.Button()
        Me.cboRoadIDs = New System.Windows.Forms.ComboBox()
        Me.lblRoadName = New System.Windows.Forms.Label()
        Me.gbSegInfo = New System.Windows.Forms.GroupBox()
        Me.cboCarto = New System.Windows.Forms.ComboBox()
        Me.cboFunClass = New System.Windows.Forms.ComboBox()
        Me.cboSegStat = New System.Windows.Forms.ComboBox()
        Me.cboSegClass = New System.Windows.Forms.ComboBox()
        Me.cboDedStat = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtAddrHR = New System.Windows.Forms.TextBox()
        Me.txtAddrLR = New System.Windows.Forms.TextBox()
        Me.txtAddrHL = New System.Windows.Forms.TextBox()
        Me.txtAddrLL = New System.Windows.Forms.TextBox()
        Me.txtSpeed = New System.Windows.Forms.TextBox()
        Me.txtRightWay = New System.Windows.Forms.TextBox()
        Me.cboR_Zip = New System.Windows.Forms.ComboBox()
        Me.cboL_Zip = New System.Windows.Forms.ComboBox()
        Me.cboOBMH = New System.Windows.Forms.ComboBox()
        Me.cboRMixAddr = New System.Windows.Forms.ComboBox()
        Me.cboLMixAddr = New System.Windows.Forms.ComboBox()
        Me.cboOneWay = New System.Windows.Forms.ComboBox()
        Me.cboFireDriv = New System.Windows.Forms.ComboBox()
        Me.cboRJurisdic = New System.Windows.Forms.ComboBox()
        Me.cboLJurisdic = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNextSeg = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.gbBlockRange = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbAreaAttr = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboFLEV = New System.Windows.Forms.ComboBox()
        Me.cboTLEV = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.gbxRoadInfo.SuspendLayout()
        Me.gbSegInfo.SuspendLayout()
        Me.gbBlockRange.SuspendLayout()
        Me.gbAreaAttr.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxRoadInfo
        '
        Me.gbxRoadInfo.Controls.Add(Me.Label12)
        Me.gbxRoadInfo.Controls.Add(Me.btnGetUniqueRoadIDs)
        Me.gbxRoadInfo.Controls.Add(Me.cboRoadIDs)
        Me.gbxRoadInfo.Controls.Add(Me.lblRoadName)
        Me.gbxRoadInfo.Location = New System.Drawing.Point(12, 10)
        Me.gbxRoadInfo.Name = "gbxRoadInfo"
        Me.gbxRoadInfo.Size = New System.Drawing.Size(351, 102)
        Me.gbxRoadInfo.TabIndex = 0
        Me.gbxRoadInfo.TabStop = False
        Me.gbxRoadInfo.Text = "Road Information"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Road ID:"
        '
        'btnGetUniqueRoadIDs
        '
        Me.btnGetUniqueRoadIDs.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetUniqueRoadIDs.Location = New System.Drawing.Point(248, 13)
        Me.btnGetUniqueRoadIDs.Name = "btnGetUniqueRoadIDs"
        Me.btnGetUniqueRoadIDs.Size = New System.Drawing.Size(90, 37)
        Me.btnGetUniqueRoadIDs.TabIndex = 8
        Me.btnGetUniqueRoadIDs.Text = "Get IDs RoadName"
        Me.btnGetUniqueRoadIDs.UseVisualStyleBackColor = True
        '
        'cboRoadIDs
        '
        Me.cboRoadIDs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRoadIDs.FormattingEnabled = True
        Me.cboRoadIDs.Location = New System.Drawing.Point(72, 22)
        Me.cboRoadIDs.Name = "cboRoadIDs"
        Me.cboRoadIDs.Size = New System.Drawing.Size(160, 21)
        Me.cboRoadIDs.TabIndex = 10
        '
        'lblRoadName
        '
        Me.lblRoadName.BackColor = System.Drawing.SystemColors.Control
        Me.lblRoadName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoadName.Location = New System.Drawing.Point(15, 64)
        Me.lblRoadName.Name = "lblRoadName"
        Me.lblRoadName.Size = New System.Drawing.Size(323, 19)
        Me.lblRoadName.TabIndex = 0
        Me.lblRoadName.Text = "Road Name"
        Me.lblRoadName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbSegInfo
        '
        Me.gbSegInfo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.gbSegInfo.Controls.Add(Me.cboCarto)
        Me.gbSegInfo.Controls.Add(Me.cboFunClass)
        Me.gbSegInfo.Controls.Add(Me.cboSegStat)
        Me.gbSegInfo.Controls.Add(Me.cboSegClass)
        Me.gbSegInfo.Controls.Add(Me.cboDedStat)
        Me.gbSegInfo.Controls.Add(Me.Label15)
        Me.gbSegInfo.Controls.Add(Me.Label8)
        Me.gbSegInfo.Controls.Add(Me.Label7)
        Me.gbSegInfo.Controls.Add(Me.Label5)
        Me.gbSegInfo.Controls.Add(Me.Label2)
        Me.gbSegInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSegInfo.Location = New System.Drawing.Point(12, 118)
        Me.gbSegInfo.Name = "gbSegInfo"
        Me.gbSegInfo.Size = New System.Drawing.Size(351, 177)
        Me.gbSegInfo.TabIndex = 8
        Me.gbSegInfo.TabStop = False
        Me.gbSegInfo.Text = "Segement 1: 99999"
        '
        'cboCarto
        '
        Me.cboCarto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCarto.FormattingEnabled = True
        Me.cboCarto.Location = New System.Drawing.Point(64, 137)
        Me.cboCarto.Name = "cboCarto"
        Me.cboCarto.Size = New System.Drawing.Size(125, 21)
        Me.cboCarto.TabIndex = 30
        '
        'cboFunClass
        '
        Me.cboFunClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFunClass.FormattingEnabled = True
        Me.cboFunClass.Location = New System.Drawing.Point(64, 111)
        Me.cboFunClass.Name = "cboFunClass"
        Me.cboFunClass.Size = New System.Drawing.Size(125, 21)
        Me.cboFunClass.TabIndex = 26
        '
        'cboSegStat
        '
        Me.cboSegStat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSegStat.FormattingEnabled = True
        Me.cboSegStat.Location = New System.Drawing.Point(64, 25)
        Me.cboSegStat.Name = "cboSegStat"
        Me.cboSegStat.Size = New System.Drawing.Size(125, 21)
        Me.cboSegStat.TabIndex = 25
        '
        'cboSegClass
        '
        Me.cboSegClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSegClass.FormattingEnabled = True
        Me.cboSegClass.Location = New System.Drawing.Point(64, 84)
        Me.cboSegClass.Name = "cboSegClass"
        Me.cboSegClass.Size = New System.Drawing.Size(125, 21)
        Me.cboSegClass.TabIndex = 23
        '
        'cboDedStat
        '
        Me.cboDedStat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDedStat.FormattingEnabled = True
        Me.cboDedStat.Location = New System.Drawing.Point(64, 54)
        Me.cboDedStat.Name = "cboDedStat"
        Me.cboDedStat.Size = New System.Drawing.Size(125, 21)
        Me.cboDedStat.TabIndex = 20
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(25, 140)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Carto:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 114)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "FunClass:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "SegStat:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "SegClass:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "DedStat:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 88)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(53, 13)
        Me.Label22.TabIndex = 41
        Me.Label22.Text = "Zip Code:"
        '
        'txtAddrHR
        '
        Me.txtAddrHR.Location = New System.Drawing.Point(130, 84)
        Me.txtAddrHR.Name = "txtAddrHR"
        Me.txtAddrHR.Size = New System.Drawing.Size(62, 20)
        Me.txtAddrHR.TabIndex = 40
        '
        'txtAddrLR
        '
        Me.txtAddrLR.Location = New System.Drawing.Point(130, 52)
        Me.txtAddrLR.Name = "txtAddrLR"
        Me.txtAddrLR.Size = New System.Drawing.Size(62, 20)
        Me.txtAddrLR.TabIndex = 39
        '
        'txtAddrHL
        '
        Me.txtAddrHL.Location = New System.Drawing.Point(61, 84)
        Me.txtAddrHL.Name = "txtAddrHL"
        Me.txtAddrHL.Size = New System.Drawing.Size(57, 20)
        Me.txtAddrHL.TabIndex = 38
        '
        'txtAddrLL
        '
        Me.txtAddrLL.Location = New System.Drawing.Point(61, 52)
        Me.txtAddrLL.Name = "txtAddrLL"
        Me.txtAddrLL.Size = New System.Drawing.Size(57, 20)
        Me.txtAddrLL.TabIndex = 37
        '
        'txtSpeed
        '
        Me.txtSpeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpeed.Location = New System.Drawing.Point(292, 298)
        Me.txtSpeed.Name = "txtSpeed"
        Me.txtSpeed.Size = New System.Drawing.Size(71, 20)
        Me.txtSpeed.TabIndex = 36
        '
        'txtRightWay
        '
        Me.txtRightWay.Location = New System.Drawing.Point(292, 411)
        Me.txtRightWay.Name = "txtRightWay"
        Me.txtRightWay.Size = New System.Drawing.Size(71, 20)
        Me.txtRightWay.TabIndex = 35
        '
        'cboR_Zip
        '
        Me.cboR_Zip.FormattingEnabled = True
        Me.cboR_Zip.Location = New System.Drawing.Point(130, 85)
        Me.cboR_Zip.Name = "cboR_Zip"
        Me.cboR_Zip.Size = New System.Drawing.Size(62, 21)
        Me.cboR_Zip.TabIndex = 33
        '
        'cboL_Zip
        '
        Me.cboL_Zip.FormattingEnabled = True
        Me.cboL_Zip.Location = New System.Drawing.Point(61, 85)
        Me.cboL_Zip.Name = "cboL_Zip"
        Me.cboL_Zip.Size = New System.Drawing.Size(57, 21)
        Me.cboL_Zip.TabIndex = 32
        '
        'cboOBMH
        '
        Me.cboOBMH.FormattingEnabled = True
        Me.cboOBMH.Location = New System.Drawing.Point(292, 357)
        Me.cboOBMH.Name = "cboOBMH"
        Me.cboOBMH.Size = New System.Drawing.Size(71, 21)
        Me.cboOBMH.TabIndex = 31
        '
        'cboRMixAddr
        '
        Me.cboRMixAddr.FormattingEnabled = True
        Me.cboRMixAddr.Location = New System.Drawing.Point(130, 113)
        Me.cboRMixAddr.Name = "cboRMixAddr"
        Me.cboRMixAddr.Size = New System.Drawing.Size(62, 21)
        Me.cboRMixAddr.TabIndex = 29
        '
        'cboLMixAddr
        '
        Me.cboLMixAddr.FormattingEnabled = True
        Me.cboLMixAddr.Location = New System.Drawing.Point(61, 113)
        Me.cboLMixAddr.Name = "cboLMixAddr"
        Me.cboLMixAddr.Size = New System.Drawing.Size(57, 21)
        Me.cboLMixAddr.TabIndex = 28
        '
        'cboOneWay
        '
        Me.cboOneWay.FormattingEnabled = True
        Me.cboOneWay.Location = New System.Drawing.Point(292, 384)
        Me.cboOneWay.Name = "cboOneWay"
        Me.cboOneWay.Size = New System.Drawing.Size(71, 21)
        Me.cboOneWay.TabIndex = 27
        '
        'cboFireDriv
        '
        Me.cboFireDriv.FormattingEnabled = True
        Me.cboFireDriv.Location = New System.Drawing.Point(292, 327)
        Me.cboFireDriv.Name = "cboFireDriv"
        Me.cboFireDriv.Size = New System.Drawing.Size(71, 21)
        Me.cboFireDriv.TabIndex = 24
        '
        'cboRJurisdic
        '
        Me.cboRJurisdic.FormattingEnabled = True
        Me.cboRJurisdic.Location = New System.Drawing.Point(130, 50)
        Me.cboRJurisdic.Name = "cboRJurisdic"
        Me.cboRJurisdic.Size = New System.Drawing.Size(62, 21)
        Me.cboRJurisdic.TabIndex = 22
        '
        'cboLJurisdic
        '
        Me.cboLJurisdic.FormattingEnabled = True
        Me.cboLJurisdic.Location = New System.Drawing.Point(61, 50)
        Me.cboLJurisdic.Name = "cboLJurisdic"
        Me.cboLJurisdic.Size = New System.Drawing.Size(57, 21)
        Me.cboLJurisdic.TabIndex = 21
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 87)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(51, 13)
        Me.Label21.TabIndex = 19
        Me.Label21.Text = "High Adr:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 55)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(49, 13)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = "Low Adr:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(245, 360)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 13)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "OBMH:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(235, 301)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 13)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "SPEED:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(230, 413)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "RightWay:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 116)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "MixAddr:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(235, 387)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "OneWay:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(241, 330)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "FireDriv:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "PS_Jur:"
        '
        'cmdClose
        '
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(311, 557)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(48, 23)
        Me.cmdClose.TabIndex = 12
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(233, 499)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(125, 23)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save Segment 1"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNextSeg
        '
        Me.btnNextSeg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextSeg.Location = New System.Drawing.Point(234, 528)
        Me.btnNextSeg.Name = "btnNextSeg"
        Me.btnNextSeg.Size = New System.Drawing.Size(125, 23)
        Me.btnNextSeg.TabIndex = 9
        Me.btnNextSeg.Text = "Show Segment 2"
        Me.btnNextSeg.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(233, 557)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(53, 23)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'gbBlockRange
        '
        Me.gbBlockRange.Controls.Add(Me.Label1)
        Me.gbBlockRange.Controls.Add(Me.txtAddrHR)
        Me.gbBlockRange.Controls.Add(Me.Label4)
        Me.gbBlockRange.Controls.Add(Me.txtAddrLR)
        Me.gbBlockRange.Controls.Add(Me.txtAddrLL)
        Me.gbBlockRange.Controls.Add(Me.txtAddrHL)
        Me.gbBlockRange.Controls.Add(Me.Label11)
        Me.gbBlockRange.Controls.Add(Me.Label20)
        Me.gbBlockRange.Controls.Add(Me.Label21)
        Me.gbBlockRange.Controls.Add(Me.cboLMixAddr)
        Me.gbBlockRange.Controls.Add(Me.cboRMixAddr)
        Me.gbBlockRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbBlockRange.Location = New System.Drawing.Point(12, 301)
        Me.gbBlockRange.Name = "gbBlockRange"
        Me.gbBlockRange.Size = New System.Drawing.Size(210, 153)
        Me.gbBlockRange.TabIndex = 14
        Me.gbBlockRange.TabStop = False
        Me.gbBlockRange.Text = "Block Range Info"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(137, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "RIGHT"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(69, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "LEFT"
        '
        'gbAreaAttr
        '
        Me.gbAreaAttr.Controls.Add(Me.Label10)
        Me.gbAreaAttr.Controls.Add(Me.Label18)
        Me.gbAreaAttr.Controls.Add(Me.Label22)
        Me.gbAreaAttr.Controls.Add(Me.Label3)
        Me.gbAreaAttr.Controls.Add(Me.cboR_Zip)
        Me.gbAreaAttr.Controls.Add(Me.cboLJurisdic)
        Me.gbAreaAttr.Controls.Add(Me.cboL_Zip)
        Me.gbAreaAttr.Controls.Add(Me.cboRJurisdic)
        Me.gbAreaAttr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAreaAttr.Location = New System.Drawing.Point(12, 460)
        Me.gbAreaAttr.Name = "gbAreaAttr"
        Me.gbAreaAttr.Size = New System.Drawing.Size(210, 120)
        Me.gbAreaAttr.TabIndex = 15
        Me.gbAreaAttr.TabStop = False
        Me.gbAreaAttr.Text = "Area Attributes"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(137, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "RIGHT"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(69, 26)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(37, 13)
        Me.Label18.TabIndex = 42
        Me.Label18.Text = "LEFT"
        '
        'cboFLEV
        '
        Me.cboFLEV.Enabled = False
        Me.cboFLEV.FormattingEnabled = True
        Me.cboFLEV.Location = New System.Drawing.Point(292, 439)
        Me.cboFLEV.Name = "cboFLEV"
        Me.cboFLEV.Size = New System.Drawing.Size(71, 21)
        Me.cboFLEV.TabIndex = 40
        '
        'cboTLEV
        '
        Me.cboTLEV.Enabled = False
        Me.cboTLEV.FormattingEnabled = True
        Me.cboTLEV.Location = New System.Drawing.Point(292, 468)
        Me.cboTLEV.Name = "cboTLEV"
        Me.cboTLEV.Size = New System.Drawing.Size(71, 21)
        Me.cboTLEV.TabIndex = 39
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(238, 471)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 13)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "T_Level:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(239, 441)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 13)
        Me.Label19.TabIndex = 38
        Me.Label19.Text = "F_Level:"
        '
        'frmSplitRoadAttributes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(371, 591)
        Me.Controls.Add(Me.cboFLEV)
        Me.Controls.Add(Me.cboTLEV)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtSpeed)
        Me.Controls.Add(Me.gbAreaAttr)
        Me.Controls.Add(Me.txtRightWay)
        Me.Controls.Add(Me.gbBlockRange)
        Me.Controls.Add(Me.cboOBMH)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.cboOneWay)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.gbSegInfo)
        Me.Controls.Add(Me.cboFireDriv)
        Me.Controls.Add(Me.gbxRoadInfo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnNextSeg)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Name = "frmSplitRoadAttributes"
        Me.Text = "Split Road Attributes"
        Me.gbxRoadInfo.ResumeLayout(False)
        Me.gbxRoadInfo.PerformLayout()
        Me.gbSegInfo.ResumeLayout(False)
        Me.gbSegInfo.PerformLayout()
        Me.gbBlockRange.ResumeLayout(False)
        Me.gbBlockRange.PerformLayout()
        Me.gbAreaAttr.ResumeLayout(False)
        Me.gbAreaAttr.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbxRoadInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblRoadName As System.Windows.Forms.Label
    Friend WithEvents gbSegInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtAddrHR As System.Windows.Forms.TextBox
    Friend WithEvents txtAddrLR As System.Windows.Forms.TextBox
    Friend WithEvents txtAddrHL As System.Windows.Forms.TextBox
    Friend WithEvents txtAddrLL As System.Windows.Forms.TextBox
    Friend WithEvents txtSpeed As System.Windows.Forms.TextBox
    Friend WithEvents txtRightWay As System.Windows.Forms.TextBox
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
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnGetUniqueRoadIDs As System.Windows.Forms.Button
    Friend WithEvents cboRoadIDs As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnNextSeg As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents gbBlockRange As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbAreaAttr As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboFLEV As System.Windows.Forms.ComboBox
    Friend WithEvents cboTLEV As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
