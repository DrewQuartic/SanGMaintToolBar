<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQualityChecker
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
        Me.tblpDataCheck = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDnAddrAPN = New System.Windows.Forms.Label()
        Me.lblDnApnAtr = New System.Windows.Forms.Label()
        Me.lblDnLotID = New System.Windows.Forms.Label()
        Me.lblDnPendPar = New System.Windows.Forms.Label()
        Me.lblDnFirDriv = New System.Windows.Forms.Label()
        Me.lblErrDupRdSeg = New System.Windows.Forms.Label()
        Me.lblErrRdFrDriv = New System.Windows.Forms.Label()
        Me.lblErrParcelPend = New System.Windows.Forms.Label()
        Me.lblErrLotNull = New System.Windows.Forms.Label()
        Me.lblErrAPNATRNulls = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblStatDupRdSeg = New System.Windows.Forms.Label()
        Me.lblStatRdFrDriv = New System.Windows.Forms.Label()
        Me.lblStatParcelPend = New System.Windows.Forms.Label()
        Me.lblStatLotNull = New System.Windows.Forms.Label()
        Me.lblStatAPNATRNulls = New System.Windows.Forms.Label()
        Me.lblStatAddrAPNNull = New System.Windows.Forms.Label()
        Me.lblErrAddrAPNNull = New System.Windows.Forms.Label()
        Me.lblDnDupRdSegs = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblDnRoadIDs = New System.Windows.Forms.Label()
        Me.lblStatRoadID = New System.Windows.Forms.Label()
        Me.lblErrRoadID = New System.Windows.Forms.Label()
        Me.btnFinish = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblFinalStatus = New System.Windows.Forms.Label()
        Me.lblDnIntType = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblStatInterType = New System.Windows.Forms.Label()
        Me.lblErrInterType = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblStatBadFCERelate = New System.Windows.Forms.Label()
        Me.lblErrBadEFCRelate = New System.Windows.Forms.Label()
        Me.lblDnBadEFCRel = New System.Windows.Forms.Label()
        Me.lblDnLevel = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblStatLevel = New System.Windows.Forms.Label()
        Me.lblErrLevel = New System.Windows.Forms.Label()
        Me.lblDnPSBlock = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblStatPSBlock = New System.Windows.Forms.Label()
        Me.lblErrPSBlock = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tblpDataCheck.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tblpDataCheck
        '
        Me.tblpDataCheck.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tblpDataCheck.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.tblpDataCheck.ColumnCount = 4
        Me.tblpDataCheck.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.805496!))
        Me.tblpDataCheck.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.27598!))
        Me.tblpDataCheck.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.95811!))
        Me.tblpDataCheck.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.96041!))
        Me.tblpDataCheck.Controls.Add(Me.lblDnAddrAPN, 0, 7)
        Me.tblpDataCheck.Controls.Add(Me.lblDnApnAtr, 0, 6)
        Me.tblpDataCheck.Controls.Add(Me.lblDnLotID, 0, 5)
        Me.tblpDataCheck.Controls.Add(Me.lblDnPendPar, 0, 4)
        Me.tblpDataCheck.Controls.Add(Me.lblDnFirDriv, 0, 3)
        Me.tblpDataCheck.Controls.Add(Me.lblErrDupRdSeg, 3, 2)
        Me.tblpDataCheck.Controls.Add(Me.lblErrRdFrDriv, 3, 3)
        Me.tblpDataCheck.Controls.Add(Me.lblErrParcelPend, 3, 4)
        Me.tblpDataCheck.Controls.Add(Me.lblErrLotNull, 3, 5)
        Me.tblpDataCheck.Controls.Add(Me.lblErrAPNATRNulls, 3, 6)
        Me.tblpDataCheck.Controls.Add(Me.Label1, 1, 0)
        Me.tblpDataCheck.Controls.Add(Me.Label4, 1, 2)
        Me.tblpDataCheck.Controls.Add(Me.Label5, 1, 3)
        Me.tblpDataCheck.Controls.Add(Me.Label6, 1, 4)
        Me.tblpDataCheck.Controls.Add(Me.Label7, 1, 5)
        Me.tblpDataCheck.Controls.Add(Me.Label8, 1, 6)
        Me.tblpDataCheck.Controls.Add(Me.Label9, 1, 7)
        Me.tblpDataCheck.Controls.Add(Me.Label2, 2, 0)
        Me.tblpDataCheck.Controls.Add(Me.Label3, 3, 0)
        Me.tblpDataCheck.Controls.Add(Me.lblStatDupRdSeg, 2, 2)
        Me.tblpDataCheck.Controls.Add(Me.lblStatRdFrDriv, 2, 3)
        Me.tblpDataCheck.Controls.Add(Me.lblStatParcelPend, 2, 4)
        Me.tblpDataCheck.Controls.Add(Me.lblStatLotNull, 2, 5)
        Me.tblpDataCheck.Controls.Add(Me.lblStatAPNATRNulls, 2, 6)
        Me.tblpDataCheck.Controls.Add(Me.lblStatAddrAPNNull, 2, 7)
        Me.tblpDataCheck.Controls.Add(Me.lblErrAddrAPNNull, 3, 7)
        Me.tblpDataCheck.Controls.Add(Me.lblDnDupRdSegs, 0, 2)
        Me.tblpDataCheck.Controls.Add(Me.Label17, 1, 1)
        Me.tblpDataCheck.Controls.Add(Me.lblDnRoadIDs, 0, 1)
        Me.tblpDataCheck.Controls.Add(Me.lblStatRoadID, 2, 1)
        Me.tblpDataCheck.Controls.Add(Me.lblErrRoadID, 3, 1)
        Me.tblpDataCheck.Controls.Add(Me.btnFinish, 1, 12)
        Me.tblpDataCheck.Controls.Add(Me.Button1, 2, 12)
        Me.tblpDataCheck.Controls.Add(Me.lblFinalStatus, 3, 12)
        Me.tblpDataCheck.Controls.Add(Me.lblDnIntType, 0, 9)
        Me.tblpDataCheck.Controls.Add(Me.Label10, 1, 9)
        Me.tblpDataCheck.Controls.Add(Me.lblStatInterType, 2, 9)
        Me.tblpDataCheck.Controls.Add(Me.lblErrInterType, 3, 9)
        Me.tblpDataCheck.Controls.Add(Me.Label16, 1, 8)
        Me.tblpDataCheck.Controls.Add(Me.lblStatBadFCERelate, 2, 8)
        Me.tblpDataCheck.Controls.Add(Me.lblErrBadEFCRelate, 3, 8)
        Me.tblpDataCheck.Controls.Add(Me.lblDnBadEFCRel, 0, 8)
        Me.tblpDataCheck.Controls.Add(Me.lblDnLevel, 0, 10)
        Me.tblpDataCheck.Controls.Add(Me.Label19, 1, 10)
        Me.tblpDataCheck.Controls.Add(Me.lblStatLevel, 2, 10)
        Me.tblpDataCheck.Controls.Add(Me.lblErrLevel, 3, 10)
        Me.tblpDataCheck.Controls.Add(Me.lblDnPSBlock, 0, 11)
        Me.tblpDataCheck.Controls.Add(Me.Label20, 1, 11)
        Me.tblpDataCheck.Controls.Add(Me.lblStatPSBlock, 2, 11)
        Me.tblpDataCheck.Controls.Add(Me.lblErrPSBlock, 3, 11)
        Me.tblpDataCheck.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblpDataCheck.Location = New System.Drawing.Point(0, 0)
        Me.tblpDataCheck.Name = "tblpDataCheck"
        Me.tblpDataCheck.RowCount = 13
        Me.tblpDataCheck.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblpDataCheck.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tblpDataCheck.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tblpDataCheck.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tblpDataCheck.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tblpDataCheck.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tblpDataCheck.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tblpDataCheck.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tblpDataCheck.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tblpDataCheck.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tblpDataCheck.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tblpDataCheck.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tblpDataCheck.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.tblpDataCheck.Size = New System.Drawing.Size(600, 448)
        Me.tblpDataCheck.TabIndex = 0
        '
        'lblDnAddrAPN
        '
        Me.lblDnAddrAPN.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDnAddrAPN.AutoSize = True
        Me.lblDnAddrAPN.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDnAddrAPN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDnAddrAPN.Location = New System.Drawing.Point(6, 242)
        Me.lblDnAddrAPN.Name = "lblDnAddrAPN"
        Me.lblDnAddrAPN.Size = New System.Drawing.Size(14, 17)
        Me.lblDnAddrAPN.TabIndex = 37
        Me.lblDnAddrAPN.Text = "-"
        Me.lblDnAddrAPN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDnApnAtr
        '
        Me.lblDnApnAtr.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDnApnAtr.AutoSize = True
        Me.lblDnApnAtr.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDnApnAtr.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDnApnAtr.Location = New System.Drawing.Point(6, 210)
        Me.lblDnApnAtr.Name = "lblDnApnAtr"
        Me.lblDnApnAtr.Size = New System.Drawing.Size(14, 17)
        Me.lblDnApnAtr.TabIndex = 36
        Me.lblDnApnAtr.Text = "-"
        Me.lblDnApnAtr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDnLotID
        '
        Me.lblDnLotID.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDnLotID.AutoSize = True
        Me.lblDnLotID.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDnLotID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDnLotID.Location = New System.Drawing.Point(6, 178)
        Me.lblDnLotID.Name = "lblDnLotID"
        Me.lblDnLotID.Size = New System.Drawing.Size(14, 17)
        Me.lblDnLotID.TabIndex = 35
        Me.lblDnLotID.Text = "-"
        Me.lblDnLotID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDnPendPar
        '
        Me.lblDnPendPar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDnPendPar.AutoSize = True
        Me.lblDnPendPar.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDnPendPar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDnPendPar.Location = New System.Drawing.Point(6, 146)
        Me.lblDnPendPar.Name = "lblDnPendPar"
        Me.lblDnPendPar.Size = New System.Drawing.Size(14, 17)
        Me.lblDnPendPar.TabIndex = 34
        Me.lblDnPendPar.Text = "-"
        Me.lblDnPendPar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDnFirDriv
        '
        Me.lblDnFirDriv.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDnFirDriv.AutoSize = True
        Me.lblDnFirDriv.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDnFirDriv.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDnFirDriv.Location = New System.Drawing.Point(6, 114)
        Me.lblDnFirDriv.Name = "lblDnFirDriv"
        Me.lblDnFirDriv.Size = New System.Drawing.Size(14, 17)
        Me.lblDnFirDriv.TabIndex = 33
        Me.lblDnFirDriv.Text = "-"
        Me.lblDnFirDriv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblErrDupRdSeg
        '
        Me.lblErrDupRdSeg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblErrDupRdSeg.AutoSize = True
        Me.lblErrDupRdSeg.ForeColor = System.Drawing.Color.DarkRed
        Me.lblErrDupRdSeg.Location = New System.Drawing.Point(281, 84)
        Me.lblErrDupRdSeg.Name = "lblErrDupRdSeg"
        Me.lblErrDupRdSeg.Size = New System.Drawing.Size(27, 13)
        Me.lblErrDupRdSeg.TabIndex = 24
        Me.lblErrDupRdSeg.Text = "N/A"
        Me.lblErrDupRdSeg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblErrRdFrDriv
        '
        Me.lblErrRdFrDriv.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblErrRdFrDriv.AutoSize = True
        Me.lblErrRdFrDriv.ForeColor = System.Drawing.Color.DarkRed
        Me.lblErrRdFrDriv.Location = New System.Drawing.Point(281, 116)
        Me.lblErrRdFrDriv.Name = "lblErrRdFrDriv"
        Me.lblErrRdFrDriv.Size = New System.Drawing.Size(27, 13)
        Me.lblErrRdFrDriv.TabIndex = 25
        Me.lblErrRdFrDriv.Text = "N/A"
        Me.lblErrRdFrDriv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblErrParcelPend
        '
        Me.lblErrParcelPend.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblErrParcelPend.AutoSize = True
        Me.lblErrParcelPend.ForeColor = System.Drawing.Color.DarkRed
        Me.lblErrParcelPend.Location = New System.Drawing.Point(281, 148)
        Me.lblErrParcelPend.Name = "lblErrParcelPend"
        Me.lblErrParcelPend.Size = New System.Drawing.Size(27, 13)
        Me.lblErrParcelPend.TabIndex = 26
        Me.lblErrParcelPend.Text = "N/A"
        Me.lblErrParcelPend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblErrLotNull
        '
        Me.lblErrLotNull.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblErrLotNull.AutoSize = True
        Me.lblErrLotNull.ForeColor = System.Drawing.Color.DarkRed
        Me.lblErrLotNull.Location = New System.Drawing.Point(281, 180)
        Me.lblErrLotNull.Name = "lblErrLotNull"
        Me.lblErrLotNull.Size = New System.Drawing.Size(27, 13)
        Me.lblErrLotNull.TabIndex = 27
        Me.lblErrLotNull.Text = "N/A"
        Me.lblErrLotNull.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblErrAPNATRNulls
        '
        Me.lblErrAPNATRNulls.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblErrAPNATRNulls.AutoSize = True
        Me.lblErrAPNATRNulls.ForeColor = System.Drawing.Color.DarkRed
        Me.lblErrAPNATRNulls.Location = New System.Drawing.Point(281, 212)
        Me.lblErrAPNATRNulls.Name = "lblErrAPNATRNulls"
        Me.lblErrAPNATRNulls.Size = New System.Drawing.Size(27, 13)
        Me.lblErrAPNATRNulls.TabIndex = 28
        Me.lblErrAPNATRNulls.Text = "N/A"
        Me.lblErrAPNATRNulls.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 40)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Data Check"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Duplicate Road SegIDs"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Road FireDriv Null Values"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Pending Parcels"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 180)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Lot LotID Null Values"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 212)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "APN ATR Null, Empty, 0s"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(29, 244)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Address Null AdrAPNIds"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(217, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 40)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Status"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(281, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 40)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Errors"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatDupRdSeg
        '
        Me.lblStatDupRdSeg.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblStatDupRdSeg.AutoSize = True
        Me.lblStatDupRdSeg.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStatDupRdSeg.Location = New System.Drawing.Point(221, 93)
        Me.lblStatDupRdSeg.Name = "lblStatDupRdSeg"
        Me.lblStatDupRdSeg.Size = New System.Drawing.Size(46, 13)
        Me.lblStatDupRdSeg.TabIndex = 17
        Me.lblStatDupRdSeg.Text = "Pending"
        Me.lblStatDupRdSeg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatRdFrDriv
        '
        Me.lblStatRdFrDriv.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblStatRdFrDriv.AutoSize = True
        Me.lblStatRdFrDriv.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStatRdFrDriv.Location = New System.Drawing.Point(221, 125)
        Me.lblStatRdFrDriv.Name = "lblStatRdFrDriv"
        Me.lblStatRdFrDriv.Size = New System.Drawing.Size(46, 13)
        Me.lblStatRdFrDriv.TabIndex = 18
        Me.lblStatRdFrDriv.Text = "Pending"
        Me.lblStatRdFrDriv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatParcelPend
        '
        Me.lblStatParcelPend.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblStatParcelPend.AutoSize = True
        Me.lblStatParcelPend.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStatParcelPend.Location = New System.Drawing.Point(221, 157)
        Me.lblStatParcelPend.Name = "lblStatParcelPend"
        Me.lblStatParcelPend.Size = New System.Drawing.Size(46, 13)
        Me.lblStatParcelPend.TabIndex = 19
        Me.lblStatParcelPend.Text = "Pending"
        Me.lblStatParcelPend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatLotNull
        '
        Me.lblStatLotNull.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblStatLotNull.AutoSize = True
        Me.lblStatLotNull.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStatLotNull.Location = New System.Drawing.Point(221, 189)
        Me.lblStatLotNull.Name = "lblStatLotNull"
        Me.lblStatLotNull.Size = New System.Drawing.Size(46, 13)
        Me.lblStatLotNull.TabIndex = 20
        Me.lblStatLotNull.Text = "Pending"
        Me.lblStatLotNull.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatAPNATRNulls
        '
        Me.lblStatAPNATRNulls.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblStatAPNATRNulls.AutoSize = True
        Me.lblStatAPNATRNulls.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStatAPNATRNulls.Location = New System.Drawing.Point(221, 221)
        Me.lblStatAPNATRNulls.Name = "lblStatAPNATRNulls"
        Me.lblStatAPNATRNulls.Size = New System.Drawing.Size(46, 13)
        Me.lblStatAPNATRNulls.TabIndex = 21
        Me.lblStatAPNATRNulls.Text = "Pending"
        Me.lblStatAPNATRNulls.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatAddrAPNNull
        '
        Me.lblStatAddrAPNNull.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblStatAddrAPNNull.AutoSize = True
        Me.lblStatAddrAPNNull.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStatAddrAPNNull.Location = New System.Drawing.Point(221, 253)
        Me.lblStatAddrAPNNull.Name = "lblStatAddrAPNNull"
        Me.lblStatAddrAPNNull.Size = New System.Drawing.Size(46, 13)
        Me.lblStatAddrAPNNull.TabIndex = 22
        Me.lblStatAddrAPNNull.Text = "Pending"
        Me.lblStatAddrAPNNull.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblErrAddrAPNNull
        '
        Me.lblErrAddrAPNNull.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblErrAddrAPNNull.AutoSize = True
        Me.lblErrAddrAPNNull.ForeColor = System.Drawing.Color.DarkRed
        Me.lblErrAddrAPNNull.Location = New System.Drawing.Point(281, 244)
        Me.lblErrAddrAPNNull.Name = "lblErrAddrAPNNull"
        Me.lblErrAddrAPNNull.Size = New System.Drawing.Size(27, 13)
        Me.lblErrAddrAPNNull.TabIndex = 23
        Me.lblErrAddrAPNNull.Text = "N/A"
        Me.lblErrAddrAPNNull.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDnDupRdSegs
        '
        Me.lblDnDupRdSegs.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDnDupRdSegs.AutoSize = True
        Me.lblDnDupRdSegs.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDnDupRdSegs.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDnDupRdSegs.Location = New System.Drawing.Point(6, 82)
        Me.lblDnDupRdSegs.Name = "lblDnDupRdSegs"
        Me.lblDnDupRdSegs.Size = New System.Drawing.Size(14, 17)
        Me.lblDnDupRdSegs.TabIndex = 31
        Me.lblDnDupRdSegs.Text = "-"
        Me.lblDnDupRdSegs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(29, 52)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 13)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "Bad Road IDs"
        '
        'lblDnRoadIDs
        '
        Me.lblDnRoadIDs.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDnRoadIDs.AutoSize = True
        Me.lblDnRoadIDs.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDnRoadIDs.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDnRoadIDs.Location = New System.Drawing.Point(6, 50)
        Me.lblDnRoadIDs.Name = "lblDnRoadIDs"
        Me.lblDnRoadIDs.Size = New System.Drawing.Size(14, 17)
        Me.lblDnRoadIDs.TabIndex = 38
        Me.lblDnRoadIDs.Text = "-"
        Me.lblDnRoadIDs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatRoadID
        '
        Me.lblStatRoadID.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblStatRoadID.AutoSize = True
        Me.lblStatRoadID.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStatRoadID.Location = New System.Drawing.Point(221, 61)
        Me.lblStatRoadID.Name = "lblStatRoadID"
        Me.lblStatRoadID.Size = New System.Drawing.Size(46, 13)
        Me.lblStatRoadID.TabIndex = 40
        Me.lblStatRoadID.Text = "Pending"
        Me.lblStatRoadID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblErrRoadID
        '
        Me.lblErrRoadID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblErrRoadID.AutoSize = True
        Me.lblErrRoadID.ForeColor = System.Drawing.Color.DarkRed
        Me.lblErrRoadID.Location = New System.Drawing.Point(281, 52)
        Me.lblErrRoadID.Name = "lblErrRoadID"
        Me.lblErrRoadID.Size = New System.Drawing.Size(27, 13)
        Me.lblErrRoadID.TabIndex = 41
        Me.lblErrRoadID.Text = "N/A"
        Me.lblErrRoadID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnFinish
        '
        Me.btnFinish.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFinish.Enabled = False
        Me.btnFinish.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinish.Location = New System.Drawing.Point(29, 399)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(178, 44)
        Me.btnFinish.TabIndex = 29
        Me.btnFinish.Text = "Press to Exit"
        Me.btnFinish.UseVisualStyleBackColor = True
        Me.btnFinish.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(215, 399)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(58, 44)
        Me.Button1.TabIndex = 42
        Me.Button1.Text = "BEGIN"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblFinalStatus
        '
        Me.lblFinalStatus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFinalStatus.AutoSize = True
        Me.lblFinalStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinalStatus.Location = New System.Drawing.Point(281, 414)
        Me.lblFinalStatus.Name = "lblFinalStatus"
        Me.lblFinalStatus.Size = New System.Drawing.Size(85, 13)
        Me.lblFinalStatus.TabIndex = 30
        Me.lblFinalStatus.Text = "Processing...."
        Me.lblFinalStatus.Visible = False
        '
        'lblDnIntType
        '
        Me.lblDnIntType.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDnIntType.AutoSize = True
        Me.lblDnIntType.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDnIntType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDnIntType.Location = New System.Drawing.Point(6, 306)
        Me.lblDnIntType.Name = "lblDnIntType"
        Me.lblDnIntType.Size = New System.Drawing.Size(14, 17)
        Me.lblDnIntType.TabIndex = 43
        Me.lblDnIntType.Text = "-"
        Me.lblDnIntType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(29, 308)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 13)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Intersection Invalid Types"
        '
        'lblStatInterType
        '
        Me.lblStatInterType.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblStatInterType.AutoSize = True
        Me.lblStatInterType.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStatInterType.Location = New System.Drawing.Point(221, 317)
        Me.lblStatInterType.Name = "lblStatInterType"
        Me.lblStatInterType.Size = New System.Drawing.Size(46, 13)
        Me.lblStatInterType.TabIndex = 45
        Me.lblStatInterType.Text = "Pending"
        Me.lblStatInterType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblErrInterType
        '
        Me.lblErrInterType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblErrInterType.AutoSize = True
        Me.lblErrInterType.ForeColor = System.Drawing.Color.DarkRed
        Me.lblErrInterType.Location = New System.Drawing.Point(281, 308)
        Me.lblErrInterType.Name = "lblErrInterType"
        Me.lblErrInterType.Size = New System.Drawing.Size(27, 13)
        Me.lblErrInterType.TabIndex = 46
        Me.lblErrInterType.Text = "N/A"
        Me.lblErrInterType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(29, 276)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(156, 13)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "FC Easement Bad Relate Value"
        '
        'lblStatBadFCERelate
        '
        Me.lblStatBadFCERelate.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblStatBadFCERelate.AutoSize = True
        Me.lblStatBadFCERelate.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStatBadFCERelate.Location = New System.Drawing.Point(221, 285)
        Me.lblStatBadFCERelate.Name = "lblStatBadFCERelate"
        Me.lblStatBadFCERelate.Size = New System.Drawing.Size(46, 13)
        Me.lblStatBadFCERelate.TabIndex = 48
        Me.lblStatBadFCERelate.Text = "Pending"
        Me.lblStatBadFCERelate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblErrBadEFCRelate
        '
        Me.lblErrBadEFCRelate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblErrBadEFCRelate.AutoSize = True
        Me.lblErrBadEFCRelate.ForeColor = System.Drawing.Color.DarkRed
        Me.lblErrBadEFCRelate.Location = New System.Drawing.Point(281, 276)
        Me.lblErrBadEFCRelate.Name = "lblErrBadEFCRelate"
        Me.lblErrBadEFCRelate.Size = New System.Drawing.Size(27, 13)
        Me.lblErrBadEFCRelate.TabIndex = 49
        Me.lblErrBadEFCRelate.Text = "N/A"
        Me.lblErrBadEFCRelate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDnBadEFCRel
        '
        Me.lblDnBadEFCRel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDnBadEFCRel.AutoSize = True
        Me.lblDnBadEFCRel.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDnBadEFCRel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDnBadEFCRel.Location = New System.Drawing.Point(6, 274)
        Me.lblDnBadEFCRel.Name = "lblDnBadEFCRel"
        Me.lblDnBadEFCRel.Size = New System.Drawing.Size(14, 17)
        Me.lblDnBadEFCRel.TabIndex = 50
        Me.lblDnBadEFCRel.Text = "-"
        Me.lblDnBadEFCRel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDnLevel
        '
        Me.lblDnLevel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDnLevel.AutoSize = True
        Me.lblDnLevel.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDnLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDnLevel.Location = New System.Drawing.Point(6, 338)
        Me.lblDnLevel.Name = "lblDnLevel"
        Me.lblDnLevel.Size = New System.Drawing.Size(14, 17)
        Me.lblDnLevel.TabIndex = 51
        Me.lblDnLevel.Text = "-"
        Me.lblDnLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(29, 340)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(139, 13)
        Me.Label19.TabIndex = 52
        Me.Label19.Text = "Road F/T Level Null Values"
        '
        'lblStatLevel
        '
        Me.lblStatLevel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblStatLevel.AutoSize = True
        Me.lblStatLevel.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStatLevel.Location = New System.Drawing.Point(221, 349)
        Me.lblStatLevel.Name = "lblStatLevel"
        Me.lblStatLevel.Size = New System.Drawing.Size(46, 13)
        Me.lblStatLevel.TabIndex = 53
        Me.lblStatLevel.Text = "Pending"
        Me.lblStatLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblErrLevel
        '
        Me.lblErrLevel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblErrLevel.AutoSize = True
        Me.lblErrLevel.ForeColor = System.Drawing.Color.DarkRed
        Me.lblErrLevel.Location = New System.Drawing.Point(281, 340)
        Me.lblErrLevel.Name = "lblErrLevel"
        Me.lblErrLevel.Size = New System.Drawing.Size(27, 13)
        Me.lblErrLevel.TabIndex = 54
        Me.lblErrLevel.Text = "N/A"
        Me.lblErrLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDnPSBlock
        '
        Me.lblDnPSBlock.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDnPSBlock.AutoSize = True
        Me.lblDnPSBlock.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDnPSBlock.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDnPSBlock.Location = New System.Drawing.Point(6, 370)
        Me.lblDnPSBlock.Name = "lblDnPSBlock"
        Me.lblDnPSBlock.Size = New System.Drawing.Size(14, 17)
        Me.lblDnPSBlock.TabIndex = 55
        Me.lblDnPSBlock.Text = "-"
        Me.lblDnPSBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(29, 372)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(150, 13)
        Me.Label20.TabIndex = 56
        Me.Label20.Text = "Census PSBLOCK Null Values"
        '
        'lblStatPSBlock
        '
        Me.lblStatPSBlock.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblStatPSBlock.AutoSize = True
        Me.lblStatPSBlock.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStatPSBlock.Location = New System.Drawing.Point(221, 381)
        Me.lblStatPSBlock.Name = "lblStatPSBlock"
        Me.lblStatPSBlock.Size = New System.Drawing.Size(46, 13)
        Me.lblStatPSBlock.TabIndex = 57
        Me.lblStatPSBlock.Text = "Pending"
        Me.lblStatPSBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblErrPSBlock
        '
        Me.lblErrPSBlock.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblErrPSBlock.AutoSize = True
        Me.lblErrPSBlock.ForeColor = System.Drawing.Color.DarkRed
        Me.lblErrPSBlock.Location = New System.Drawing.Point(281, 372)
        Me.lblErrPSBlock.Name = "lblErrPSBlock"
        Me.lblErrPSBlock.Size = New System.Drawing.Size(27, 13)
        Me.lblErrPSBlock.TabIndex = 58
        Me.lblErrPSBlock.Text = "N/A"
        Me.lblErrPSBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.DarkRed
        Me.Label11.Location = New System.Drawing.Point(12, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(1, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "N/A"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 59)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(1, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Duplicate Road SegIDs"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.805496!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.27598!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.95811!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.96041!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 0, 6)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(5, 157)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(1, 17)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "-"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(5, 135)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(1, 17)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "-"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(5, 123)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(1, 17)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "-"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmQualityChecker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 448)
        Me.Controls.Add(Me.tblpDataCheck)
        Me.Name = "frmQualityChecker"
        Me.Text = "Run Data Checks"
        Me.tblpDataCheck.ResumeLayout(False)
        Me.tblpDataCheck.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tblpDataCheck As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblStatDupRdSeg As System.Windows.Forms.Label
    Friend WithEvents lblStatRdFrDriv As System.Windows.Forms.Label
    Friend WithEvents lblStatParcelPend As System.Windows.Forms.Label
    Friend WithEvents lblStatLotNull As System.Windows.Forms.Label
    Friend WithEvents lblStatAPNATRNulls As System.Windows.Forms.Label
    Friend WithEvents lblStatAddrAPNNull As System.Windows.Forms.Label
    Friend WithEvents lblErrDupRdSeg As System.Windows.Forms.Label
    Friend WithEvents lblErrRdFrDriv As System.Windows.Forms.Label
    Friend WithEvents lblErrParcelPend As System.Windows.Forms.Label
    Friend WithEvents lblErrLotNull As System.Windows.Forms.Label
    Friend WithEvents lblErrAPNATRNulls As System.Windows.Forms.Label
    Friend WithEvents lblErrAddrAPNNull As System.Windows.Forms.Label
    Friend WithEvents btnFinish As System.Windows.Forms.Button
    Friend WithEvents lblFinalStatus As System.Windows.Forms.Label
    Friend WithEvents lblDnDupRdSegs As System.Windows.Forms.Label
    Friend WithEvents lblDnAddrAPN As System.Windows.Forms.Label
    Friend WithEvents lblDnApnAtr As System.Windows.Forms.Label
    Friend WithEvents lblDnLotID As System.Windows.Forms.Label
    Friend WithEvents lblDnPendPar As System.Windows.Forms.Label
    Friend WithEvents lblDnFirDriv As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblDnRoadIDs As System.Windows.Forms.Label
    Friend WithEvents lblStatRoadID As System.Windows.Forms.Label
    Friend WithEvents lblErrRoadID As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblDnIntType As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblStatInterType As System.Windows.Forms.Label
    Friend WithEvents lblErrInterType As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblStatBadFCERelate As System.Windows.Forms.Label
    Friend WithEvents lblErrBadEFCRelate As System.Windows.Forms.Label
    Friend WithEvents lblDnBadEFCRel As System.Windows.Forms.Label
    Friend WithEvents lblDnLevel As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblStatLevel As System.Windows.Forms.Label
    Friend WithEvents lblErrLevel As System.Windows.Forms.Label
    Friend WithEvents lblDnPSBlock As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblStatPSBlock As System.Windows.Forms.Label
    Friend WithEvents lblErrPSBlock As System.Windows.Forms.Label
End Class
