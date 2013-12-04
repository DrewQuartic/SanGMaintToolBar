
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports SanGISMaintenanceToolbar.Globals
Imports System.Windows.Forms
Public Class frmEditSubdivisionLog
    'Dim m_pWKSP As IWorkspace
    Dim m_ActiveView As IActiveView
    Dim m_pSDATable As ITable
    Dim m_pSDLTable As ITable
    Dim m_pWSE As IWorkspaceEdit
    Dim m_QueryStatus As Boolean = False
    Private IsInitializing As Boolean
    Private IsLoaded As Boolean
    Private ItFailed As Boolean
    'lots
    Dim m_pLotTable As ITable
    Dim m_SubDivID As String = ""
    Private tableWrapper As ArcDataBinding.TableWrapper

#Region "Properties"

    Public Property FrmMap() As IActiveView
        Get
            Return m_ActiveView
        End Get

        Set(ByVal ActiveView As IActiveView)
            m_ActiveView = ActiveView
        End Set

    End Property

    Public Property pIsQuery() As Boolean
        Get
            Return m_QueryStatus
        End Get
        Set(ByVal vIsQuery As Boolean)
            m_QueryStatus = vIsQuery
            If vIsQuery Then
                btnSBDIVLGSave.Enabled = False
                btnSBDIVLGSave.Text = "QUERY ONLY MODE"
            End If
        End Set
    End Property

#End Region

#Region "Primaries Form"

    Private Sub frmEditSubdivisionLog_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not pIsQuery And Not ItFailed Then
            Dim pDataset As IDataset
            pDataset = m_pSDATable
            m_pWSE = pDataset.Workspace
            If m_pWSE.IsBeingEdited Then
                m_pWSE.StopEditOperation()
                m_pWSE.StopEditing(True)
            End If
        End If

        m_ActiveView = Nothing
        m_pSDLTable = Nothing
        m_pSDATable = Nothing
        'm_pWKSP = Nothing
        m_pWSE = Nothing

    End Sub

    Private Sub frmEditSubdivisionLog_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F1 Then
            btnSBDIVLGReset.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.F8 Then
            If ckbxSBDIVLGSearch.Checked Then
                ckbxSBDIVLGSearch.Checked = False
            Else
                ckbxSBDIVLGSearch.Checked = True
            End If
        ElseIf e.KeyCode = Windows.Forms.Keys.F10 Then
            If Not pIsQuery Then
                btnSBDIVLGSave.PerformClick()
            End If
        ElseIf e.KeyCode = Windows.Forms.Keys.F12 Then
            btnSBDIVLGExit.PerformClick()
        End If
    End Sub

    Private Sub frmEditSubdivisionLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IsLoaded = False
        Try
            ItFailed = False
            'Check if the user has edit privs on tables first  
            If Not pIsQuery Then
                If CheckifEditable("ANY", FrmMap) Then
                    'ok to edit
                Else
                    MsgBox("You do not have the privileges to edit this version.")
                    ItFailed = True
                    Me.Close()
                End If
            End If
            'set textbox to blank
            txtSBDIVLGSelectSub.Text = ""
            'Load the tables
            Dim pTableSourcename As String
            pTableSourcename = SUBDIV_ATR_DATASRC
            m_pSDATable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename, pIsQuery)
            If m_pSDATable Is Nothing Then
                Me.Close()
                Exit Sub
            End If
            Dim pTableSourcename2 As String
            pTableSourcename2 = SUBDIV_LOG_DATASRC
            m_pSDLTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename2, pIsQuery)
            If m_pSDLTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If
            Dim pLotTableSourcename As String
            pLotTableSourcename = LOT_DATASRC
            m_pLotTable = GetWorkspaceTable("ANY", FrmMap, pLotTableSourcename, True)
            If m_pLotTable Is Nothing Then
                lblNoneFound.Visible = True
                Me.Close()
                Exit Sub
            End If
            'Fill the combos

            cboSBDIVLGJur.Items.Add("")
            cboSBDIVLGJur.Items.Add("CB")
            cboSBDIVLGJur.Items.Add("CN")
            cboSBDIVLGJur.Items.Add("CO")
            cboSBDIVLGJur.Items.Add("CV")
            cboSBDIVLGJur.Items.Add("DM")
            cboSBDIVLGJur.Items.Add("EC")
            cboSBDIVLGJur.Items.Add("EN")
            cboSBDIVLGJur.Items.Add("ES")
            cboSBDIVLGJur.Items.Add("IB")
            cboSBDIVLGJur.Items.Add("LG")
            cboSBDIVLGJur.Items.Add("LM")
            cboSBDIVLGJur.Items.Add("NC")
            cboSBDIVLGJur.Items.Add("OC")
            cboSBDIVLGJur.Items.Add("PW")
            cboSBDIVLGJur.Items.Add("SD")
            cboSBDIVLGJur.Items.Add("SM")
            cboSBDIVLGJur.Items.Add("SO")
            cboSBDIVLGJur.Items.Add("ST")
            cboSBDIVLGJur.Items.Add("VS")

            cboSBDIVLGmaptype.Items.Add("COC")
            cboSBDIVLGmaptype.Items.Add("DB")
            cboSBDIVLGmaptype.Items.Add("DP")
            cboSBDIVLGmaptype.Items.Add("FP")
            cboSBDIVLGmaptype.Items.Add("LP")
            cboSBDIVLGmaptype.Items.Add("LS")
            cboSBDIVLGmaptype.Items.Add("MAP")
            cboSBDIVLGmaptype.Items.Add("MM")
            cboSBDIVLGmaptype.Items.Add("MS")
            cboSBDIVLGmaptype.Items.Add("PB")
            cboSBDIVLGmaptype.Items.Add("PM")
            cboSBDIVLGmaptype.Items.Add("ROS")
            cboSBDIVLGmaptype.Items.Add("SCC")

            cboSBDIVLGRefMapType.Items.Add("COC")
            cboSBDIVLGRefMapType.Items.Add("DB")
            cboSBDIVLGRefMapType.Items.Add("DP")
            cboSBDIVLGRefMapType.Items.Add("FP")
            cboSBDIVLGRefMapType.Items.Add("LP")
            cboSBDIVLGRefMapType.Items.Add("LS")
            cboSBDIVLGRefMapType.Items.Add("MAP")
            cboSBDIVLGRefMapType.Items.Add("MM")
            cboSBDIVLGRefMapType.Items.Add("MS")
            cboSBDIVLGRefMapType.Items.Add("PB")
            cboSBDIVLGRefMapType.Items.Add("PM")
            cboSBDIVLGRefMapType.Items.Add("ROS")
            cboSBDIVLGRefMapType.Items.Add("SCC")

            cboSBLGHaveDXF.Items.Add("Y")
            cboSBLGHaveDXF.Items.Add("N")

            cboSBLGNad83.Items.Add("Y")
            cboSBLGNad83.Items.Add("N")

            'Populate the lot sort by combo box
            cboLotSort.Items.Add("LOTNO")
            cboLotSort.Items.Add("BLOCKNO")
            cboLotSort.Items.Add("SUB_TYPE")
            cboLotSort.Text = "LOTNO"

            'if subdiv layer in map then activate the 'select in map' button
            If CheckForLayer(SUBDIVISION_DATASRC, m_ActiveView) Then
                btnSubDivFindFtr.Enabled = True
            Else
                btnSubDivFindFtr.Enabled = False
            End If
            IsLoaded = True
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Custom"

    Private Sub ClearFormFields(ByVal ASubdivSection As Boolean, ByVal BTieInfoSection As Boolean, ByVal CLogRecord As Boolean)
        Try
            If ASubdivSection Then
                txtSBDIVLGsubdivid.Text = ""
                cboSBDIVLGJur.Text = ""
                txtSBDIVLGPostDate.Text = ""
                txtSBDIVLGPostID.Text = ""
                cboSBDIVLGmaptype.Text = ""
                txtSBDIVLGworkorder.Text = ""
                txtSBDIVLGtentmap.Text = ""
                txtSBDIVLGmapnum.Text = ""
                dtSBDIVLGrecdate.Text = ""
                dtSBDIVLGrecdate.Checked = False
                txtSBDIVLGnumlots.Text = ""
                txtSBDIVLGsubdivname.Text = ""
                txtSBDIVLGsubacreage.Text = ""
                txtSBDIVLGsubstatus.Text = "R"
                dtSBDIVLGengsigndt.Text = ""
                dtSBDIVLGengsigndt.Checked = False
                txtSBDIVLGtbgrid.Text = ""
                txtSBDIVLGmaptietype.Text = ""
                btnSUBDIVViewLots.Enabled = False
                dgLotInfo.DataSource = Nothing
                txtLOTSubDivID.Text = ""
            End If
            If BTieInfoSection Then
                txtSBDIVLGtiepostid.Text = ""
                dtSBDIVLGTiePostDate.Text = ""
                dtSBDIVLGTiePostDate.Checked = False
                txtSBDIVLGRotationAngle.Text = ""
                txtSBDIVLGPivotEasting.Text = ""
                txtSBDIVLGPivotNorthing.Text = ""
                cboSBDIVLGRefMapType.Text = ""
                txtSBDIVLGRefMapNum.Text = ""
                'Tie1
                txtSBDIVLGTie1Bearing.Text = ""
                txtSBDIVLGTie1Distance.Text = ""
                txtSBDIVLGTie1Point.Text = ""
                txtSBDIVLGPT1StationID.Text = ""
                txtSBDIVLGTie1DistType.Text = ""
                'Tie2
                txtSBDIVLGTie2Bearing.Text = ""
                txtSBDIVLGTie2Distance.Text = ""
                txtSBDIVLGTie2Point.Text = ""
                txtSBDIVLGPT2StationID.Text = ""
                txtSBDIVLGTie2DistType.Text = ""
                'GPS
                txtSBDIVLGGPSPT1North.Text = ""
                txtSBDIVLGGPSPT1East.Text = ""
                txtSBDIVLGGPSPT2North.Text = ""
                txtSBDIVLGGPSPT2East.Text = ""
            End If
            If CLogRecord Then
                dtSBLOGRecieced.Text = ""
                dtSBLOGRecieced.Checked = False
                txtSBLGAsgnTo.Text = ""
                dtSBLGAsgnDate.Text = ""
                dtSBLGAsgnDate.Checked = False
                txtSBLGMArea.Text = ""
                cboSBLGNad83.Text = ""
                cboSBLGHaveDXF.Text = ""
                txtSBLGgetDXF.Text = ""
                txtSBLGCompby.Text = ""
                dtSBLGCompDate.Text = ""
                dtSBLGCompDate.Checked = False
                txtSBLGComments.Text = ""
            End If
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Sub SearchAndFillSubdiv(ByVal subdivid As Integer)

        Try
            ClearFormFields(True, True, True)
            Dim pQueryfilter As IQueryFilter
            Dim pSDID As Integer
            Dim psdCur As ICursor
            Dim psdRow As IRow
            Dim pslCur As ICursor
            Dim pslRow As IRow

            pSDID = subdivid
            pQueryfilter = New QueryFilter
            pQueryfilter.WhereClause = "SUBDIVID = " & pSDID
            'ATR TABLE
            psdCur = m_pSDATable.Search(pQueryfilter, False) 'changed this one
            psdRow = psdCur.NextRow
            'LOG TABLE
            pslCur = m_pSDLTable.Search(pQueryfilter, False) 'changed this one
            pslRow = pslCur.NextRow
            If psdRow Is Nothing Then
                MessageBox.Show("SUBDIVID " & pSDID & " was not found in the subdiv_atr table")
            End If
            If Not psdRow Is Nothing Then
                'Key fields
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_POSTDATE_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_POSTDATE_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGPostDate.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_POSTDATE_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_POSTID_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_POSTID_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGPostID.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_POSTID_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_SUBDIVID_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_SUBDIVID_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGsubdivid.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_SUBDIVID_FLD_NAME))
                End If
                'Subdivision Fields
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_JURISDIC_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_JURISDIC_FLD_NAME)) Is Nothing Then
                    cboSBDIVLGJur.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_JURISDIC_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_WRKORDID_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_WRKORDID_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGworkorder.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_WRKORDID_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_MAPTYPE_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_MAPTYPE_FLD_NAME)) Is Nothing Then
                    cboSBDIVLGmaptype.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_MAPTYPE_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TENTMAP_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TENTMAP_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGtentmap.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TENTMAP_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_MAPNUM_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_MAPNUM_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGmapnum.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_MAPNUM_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_RECDATE_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_RECDATE_FLD_NAME)) Is Nothing And IsDate(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_RECDATE_FLD_NAME))) Then
                    dtSBDIVLGrecdate.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_RECDATE_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_NUMLOTS_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_NUMLOTS_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGnumlots.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_NUMLOTS_FLD_NAME))
                End If
                If txtSBDIVLGsubdivid.Text <> "" Then
                    btnSUBDIVViewLots.Enabled = True
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_SUBNAME_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_SUBNAME_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGsubdivname.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_SUBNAME_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_ACREAGE_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_ACREAGE_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGsubacreage.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_ACREAGE_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_STATUS_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_STATUS_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGsubstatus.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_STATUS_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_ENG_SIGNDATE_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_ENG_SIGNDATE_FLD_NAME)) Is Nothing And IsDate(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_ENG_SIGNDATE_FLD_NAME))) Then
                    dtSBDIVLGengsigndt.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_ENG_SIGNDATE_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TB_GRID_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TB_GRID_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGtbgrid.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TB_GRID_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_MAP_TIETYPE_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_MAP_TIETYPE_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGmaptietype.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_MAP_TIETYPE_FLD_NAME))
                End If

                ''Tie Fields
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE_POSTID_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE_POSTID_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGtiepostid.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE_POSTID_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE_POSTDATE_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE_POSTDATE_FLD_NAME)) Is Nothing Then
                    dtSBDIVLGTiePostDate.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE_POSTDATE_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_ROTATION_ANGLE_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_ROTATION_ANGLE_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGRotationAngle.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_ROTATION_ANGLE_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_PIVOT_POINT_E_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_PIVOT_POINT_E_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGPivotEasting.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_PIVOT_POINT_E_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_PIVOT_POINT_N_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_PIVOT_POINT_N_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGPivotNorthing.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_PIVOT_POINT_N_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_REF_MAP_TYPE_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_REF_MAP_TYPE_FLD_NAME)) Is Nothing Then
                    cboSBDIVLGRefMapType.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_REF_MAP_TYPE_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_REF_MAP_NUM_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_REF_MAP_NUM_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGRefMapNum.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_REF_MAP_NUM_FLD_NAME))
                End If
                'Tie1
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE1_BEARING_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE1_BEARING_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGTie1Bearing.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE1_BEARING_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE1_DIST_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE1_DIST_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGTie1Distance.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE1_DIST_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE1_POINT_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE1_POINT_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGTie1Point.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE1_POINT_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_PT1_STATIONID_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_PT1_STATIONID_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGPT1StationID.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_PT1_STATIONID_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE1_DISTTYPE_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE1_DISTTYPE_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGTie1DistType.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE1_DISTTYPE_FLD_NAME))
                End If
                'Tie2
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE2_BEARING_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE2_BEARING_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGTie2Bearing.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE2_BEARING_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE2_DIST_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE2_DIST_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGTie2Distance.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE2_DIST_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE2_POINT_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE2_POINT_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGTie2Point.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE2_POINT_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_PT2_STATIONID_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_PT2_STATIONID_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGPT2StationID.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_PT2_STATIONID_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE2_DISTTYPE_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE2_DISTTYPE_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGTie2DistType.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_TIE2_DISTTYPE_FLD_NAME))
                End If
                'GPS
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_GPS_PT1_N_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_GPS_PT1_N_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGGPSPT1North.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_GPS_PT1_N_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_GPS_PT1_E_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_GPS_PT1_E_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGGPSPT1East.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_GPS_PT1_E_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_GPS_PT2_N_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_GPS_PT2_N_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGGPSPT2North.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_GPS_PT2_N_FLD_NAME))
                End If
                If Not IsDBNull(psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_GPS_PT2_E_FLD_NAME))) And Not psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_GPS_PT2_E_FLD_NAME)) Is Nothing Then
                    txtSBDIVLGGPSPT2East.Text = psdRow.Value(psdRow.Fields.FindField(SUBDIV_ATR_GPS_PT2_E_FLD_NAME))
                End If
            End If
            '
            If Not pslRow Is Nothing Then
                ''Record Log Fields
                If Not IsDBNull(psdRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_RECEIVED_FLD_NAME))) And Not pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_RECEIVED_FLD_NAME)) Is Nothing And IsDate(pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_RECEIVED_FLD_NAME))) Then
                    dtSBLOGRecieced.Text = pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_RECEIVED_FLD_NAME))
                End If
                If Not IsDBNull(pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_ASGNTO_FLD_NAME))) And Not pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_ASGNTO_FLD_NAME)) Is Nothing Then
                    txtSBLGAsgnTo.Text = pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_ASGNTO_FLD_NAME))
                End If
                If Not IsDBNull(pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_ASGNDATE_FLD_NAME))) And Not pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_ASGNDATE_FLD_NAME)) Is Nothing And IsDate(pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_ASGNDATE_FLD_NAME))) Then
                    dtSBLGAsgnDate.Text = pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_ASGNDATE_FLD_NAME))
                End If
                If Not IsDBNull(pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_MAPAREA_FLD_NAME))) And Not pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_MAPAREA_FLD_NAME)) Is Nothing Then
                    txtSBLGMArea.Text = pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_MAPAREA_FLD_NAME))
                End If
                If Not IsDBNull(pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_NAD83_FLD_NAME))) And Not pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_NAD83_FLD_NAME)) Is Nothing Then
                    cboSBLGNad83.Text = pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_NAD83_FLD_NAME))
                End If
                If Not IsDBNull(pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_HAVEDXF_FLD_NAME))) And Not pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_HAVEDXF_FLD_NAME)) Is Nothing Then
                    cboSBLGHaveDXF.Text = pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_HAVEDXF_FLD_NAME))
                End If
                If Not IsDBNull(pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_GETDXF_FLD_NAME))) And Not pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_GETDXF_FLD_NAME)) Is Nothing Then
                    txtSBLGgetDXF.Text = pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_GETDXF_FLD_NAME))
                End If
                If Not IsDBNull(pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_COMP_BY_FLD_NAME))) And Not pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_COMP_BY_FLD_NAME)) Is Nothing Then
                    txtSBLGCompby.Text = pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_COMP_BY_FLD_NAME))
                End If
                If Not IsDBNull(pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_COMPDATE_NAME))) And Not pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_COMPDATE_NAME)) Is Nothing And IsDate(pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_ASGNDATE_FLD_NAME))) Then
                    dtSBLGCompDate.Text = pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_COMPDATE_NAME))
                End If
                If Not IsDBNull(pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_COMMENTS_NAME))) And Not pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_COMMENTS_NAME)) Is Nothing Then
                    txtSBLGComments.Text = pslRow.Value(pslRow.Fields.FindField(SUBDIV_LOG_COMMENTS_NAME))
                End If
            End If
            'txtSBLGCompby.Focus()
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try

    End Sub

#End Region

#Region "Text boxes"

    Private Sub txtSBDIVLGnumlots_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGnumlots.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGnumlots.Text) And txtSBDIVLGnumlots.Text <> "" Then
                MsgBox("Num of Lots must be numeric")
                Exit Sub
            End If
            txtSBDIVLGsubdivname.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGsubacreage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGsubacreage.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = CChar(".") Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGsubacreage.Text) And txtSBDIVLGsubacreage.Text <> "" Then
                MsgBox("Acreage must be numeric")
                Exit Sub
            End If
            txtSBDIVLGsubstatus.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGmaptietype_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGmaptietype.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGmaptietype.Text) And txtSBDIVLGmaptietype.Text <> "" Then
                MsgBox("Map Tie Type must be numeric")
                Exit Sub
            End If
            txtSBDIVLGtiepostid.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGtiepostid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGtiepostid.KeyPress
        If e.KeyChar = vbTab Then
            dtSBDIVLGTiePostDate.Focus()
        End If
    End Sub

    Private Sub txtSBDIVLGRotationAngle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGRotationAngle.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = CChar(".") Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGRotationAngle.Text) And txtSBDIVLGRotationAngle.Text <> "" Then
                MsgBox("Rotation Angle must be numeric")
                Exit Sub
            End If
            txtSBDIVLGPivotEasting.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGPivotEasting_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGPivotEasting.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = CChar(".") Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGPivotEasting.Text) And txtSBDIVLGPivotEasting.Text <> "" Then
                MsgBox("Pivot Easting must be numeric")
                Exit Sub
            End If
            txtSBDIVLGPivotNorthing.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGPivotNorthing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGPivotNorthing.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = CChar(".") Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGPivotNorthing.Text) And txtSBDIVLGPivotNorthing.Text <> "" Then
                MsgBox("Pivot Northing must be numeric")
                Exit Sub
            End If
            cboSBDIVLGRefMapType.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGRefMapNum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGRefMapNum.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGRefMapNum.Text) And txtSBDIVLGRefMapNum.Text <> "" Then
                MsgBox("Ref Map Num must be numeric")
                Exit Sub
            End If
            txtSBDIVLGTie1Bearing.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGTie1Bearing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGTie1Bearing.KeyPress
        If e.KeyChar = vbTab Then
            txtSBDIVLGTie1Distance.Focus()
        End If
    End Sub

    Private Sub txtSBDIVLGTie1Distance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGTie1Distance.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGTie1Distance.Text) And txtSBDIVLGTie1Distance.Text <> "" Then
                MsgBox("Ref Map Num must be numeric")
                Exit Sub
            End If
            txtSBDIVLGTie1Point.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGTie1Point_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGTie1Point.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGTie1Point.Text) And txtSBDIVLGTie1Point.Text <> "" Then
                MsgBox("Ref Map Num must be numeric")
                Exit Sub
            End If
            txtSBDIVLGPT1StationID.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGPT1StationID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGPT1StationID.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGPT1StationID.Text) And txtSBDIVLGPT1StationID.Text <> "" Then
                MsgBox("Ref Map Num must be numeric")
                Exit Sub
            End If
            txtSBDIVLGTie1DistType.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGTie1DistType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGTie1DistType.KeyPress
        If e.KeyChar = vbTab Then
            txtSBDIVLGTie2Bearing.Focus()
        End If
    End Sub

    Private Sub txtSBDIVLGTie2Bearing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGTie2Bearing.KeyPress
        If e.KeyChar = vbTab Then
            txtSBDIVLGTie2Distance.Focus()
        End If
    End Sub

    Private Sub txtSBDIVLGTie2Distance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGTie2Distance.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGTie2Distance.Text) And txtSBDIVLGTie2Distance.Text <> "" Then
                MsgBox("Ref Map Num must be numeric")
                Exit Sub
            End If
            txtSBDIVLGTie2Point.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGTie2Point_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGTie2Point.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGTie2Point.Text) And txtSBDIVLGTie2Point.Text <> "" Then
                MsgBox("Ref Map Num must be numeric")
                Exit Sub
            End If
            txtSBDIVLGPT2StationID.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGPT2StationID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGPT2StationID.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGPT2StationID.Text) And txtSBDIVLGPT2StationID.Text <> "" Then
                MsgBox("Ref Map Num must be numeric")
                Exit Sub
            End If
            txtSBDIVLGTie2DistType.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGTie2DistType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGTie2DistType.KeyPress
        If e.KeyChar = vbTab Then
            txtSBDIVLGGPSPT1North.Focus()
        End If
    End Sub

    Private Sub txtSBDIVLGGPSPT1North_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGGPSPT1North.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = CChar(".") Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGGPSPT1North.Text) And txtSBDIVLGGPSPT1North.Text <> "" Then
                MsgBox("Ref Map Num must be numeric")
                Exit Sub
            End If
            txtSBDIVLGGPSPT1East.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGGPSPT1East_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGGPSPT1East.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = CChar(".") Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGGPSPT1East.Text) And txtSBDIVLGGPSPT1East.Text <> "" Then
                MsgBox("Ref Map Num must be numeric")
                Exit Sub
            End If
            txtSBDIVLGGPSPT2North.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGGPSPT2North_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGGPSPT2North.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = CChar(".") Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGGPSPT2North.Text) And txtSBDIVLGGPSPT2North.Text <> "" Then
                MsgBox("Ref Map Num must be numeric")
                Exit Sub
            End If
            txtSBDIVLGGPSPT2East.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGGPSPT2East_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGGPSPT2East.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = CChar(".") Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtSBDIVLGGPSPT2East.Text) And txtSBDIVLGGPSPT2East.Text <> "" Then
                MsgBox("Ref Map Num must be numeric")
                Exit Sub
            End If
            dtSBLOGRecieced.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtSBDIVLGworkorder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGworkorder.KeyPress
        If e.KeyChar = vbTab Then
            txtSBDIVLGtentmap.Focus()
        End If
    End Sub

    Private Sub txtSBDIVLGtentmap_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGtentmap.KeyPress
        If e.KeyChar = vbTab Then
            dtSBDIVLGrecdate.Focus()
        End If
    End Sub

    Private Sub txtSBDIVLGmapnum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGmapnum.KeyPress
        If e.KeyChar = vbTab Then
            txtSBDIVLGnumlots.Focus()
        End If
    End Sub

    Private Sub txtSBDIVLGsubdivname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGsubdivname.KeyPress
        If e.KeyChar = vbTab Then
            txtSBDIVLGsubacreage.Focus()
        End If
    End Sub

    Private Sub txtSBDIVLGsubstatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGsubstatus.KeyPress
        If e.KeyChar = vbTab Then
            txtSBDIVLGtbgrid.Focus()
        End If
    End Sub

    Private Sub txtSBDIVLGtbgrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGtbgrid.KeyPress
        If e.KeyChar = vbTab Then
            dtSBDIVLGengsigndt.Focus()
        End If
    End Sub

    Private Sub txtSBLGAsgnTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBLGAsgnTo.KeyPress
        If e.KeyChar = vbTab Then
            dtSBLGAsgnDate.Focus()
        End If
    End Sub

    Private Sub txtSBLGMArea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBLGMArea.KeyPress
        If e.KeyChar = vbTab Then
            cboSBLGNad83.Focus()
        End If
    End Sub

    Private Sub txtSBLGgetDXF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBLGgetDXF.KeyPress
        If e.KeyChar = vbTab Then
            txtSBLGCompby.Focus()
        End If
    End Sub

    Private Sub txtSBLGCompby_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBLGCompby.KeyPress
        If e.KeyChar = vbTab Then
            dtSBLGCompDate.Focus()
        End If
    End Sub

    Private Sub txtSBLGComments_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBLGComments.KeyPress
        If e.KeyChar = vbTab Then
            btnSBDIVLGSave.Focus()
        End If
    End Sub

    Private Sub txtSBDIVLGSelectSub_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSBDIVLGSelectSub.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Tab) Then
            'need to allow tab and return to run the process, but need to handle them so they are not part of the actual text input
            e.Handled = True
            'check if anything is entered or if its a number
            If txtSBDIVLGSelectSub.Text = "" Or (Not IsNumeric(txtSBDIVLGSelectSub.Text)) Then
                MsgBox("Enter valid SubDivID, or check off SubDivID Search")
                Exit Sub
            End If
            'check if the number is larger than an integer which is invalid
            If txtSBDIVLGSelectSub.Text > 2147483647 Then
                MsgBox("Enter valid SubDivID, or check off SubDivID Search")
                Exit Sub
            End If
            'run the search and form fill
            SearchAndFillSubdiv(txtSBDIVLGSelectSub.Text)

            If e.KeyChar = ChrW(Keys.Tab) Then txtSBDIVLGworkorder.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub
#End Region


#Region "Date Pickers"

    Private Sub dtSBLGCompDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtSBLGCompDate.KeyPress
        If e.KeyChar = vbTab Then
            txtSBLGComments.Focus()
        End If
    End Sub

    Private Sub dtSBLGAsgnDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtSBLGAsgnDate.KeyPress
        If e.KeyChar = vbTab Then
            txtSBLGMArea.Focus()
        End If
    End Sub

    Private Sub dtSBDIVLGTiePostDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtSBDIVLGTiePostDate.KeyPress
        If e.KeyChar = vbTab Then
            txtSBDIVLGRotationAngle.Focus()
        End If
    End Sub

    Private Sub dtSBLOGRecieced_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtSBLOGRecieced.KeyPress
        If e.KeyChar = vbTab Then
            txtSBLGAsgnTo.Focus()
        End If
    End Sub

    Private Sub dtSBDIVLGrecdate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtSBDIVLGrecdate.KeyPress
        If e.KeyChar = vbTab Then
            cboSBDIVLGmaptype.Focus()
        End If
    End Sub

    Private Sub dtSBDIVLGengsigndt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtSBDIVLGengsigndt.KeyPress
        If e.KeyChar = vbTab Then
            txtSBDIVLGmaptietype.Focus()
        End If
    End Sub

#End Region

#Region "Combo boxes and Check boxes"

    Private Sub ckbxSBDIVLGSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbxSBDIVLGSearch.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Try
                If Not ckbxSBDIVLGSearch.Checked Then
                    cboSBDIVLGSelectSub.Items.Clear()
                    cboSBDIVLGSelectSub.SelectedText = ""
                    cboSBDIVLGSelectSub.Text = ""
                    cboSBDIVLGSelectSub.Enabled = False
                    ckbxSBDIVLGSearch.ForeColor = Drawing.Color.Black
                    ckbxSBDIVLGSearch.Text = "Look Up SubDivID"
                    If Not pIsQuery Then
                        btnSBDIVLGSave.Text = "Add Subdivision"
                    End If
                    'clear out the form fields
                    ClearFormFields(True, True, True)
                    cboSBDIVLGJur.Focus()
                Else
                    If ckbxSDMapNumSearch.Checked Then
                        ckbxSDMapNumSearch.Checked = False
                    End If
                    If ckbxSBDIVLGText.Checked Then
                        ckbxSBDIVLGText.Checked = False
                    End If
                    cboSBDIVLGSelectSub.Enabled = True
                    ckbxSBDIVLGSearch.ForeColor = Drawing.Color.Red
                    If Not pIsQuery Then
                        ckbxSBDIVLGSearch.Text = "UN-Check to ADD NEW"
                        btnSBDIVLGSave.Text = "Save Updates"
                    End If
                    'Fill it
                    Dim pCur As ICursor, pRow As IRow, lIdx As Long, lIdx2 As Long, lIdx3 As Long
                    lIdx = m_pSDATable.Fields.FindField(SUBDIV_ATR_SUBDIVID_FLD_NAME)
                    lIdx2 = m_pSDATable.Fields.FindField(SUBDIV_ATR_SUBNAME_FLD_NAME)
                    lIdx3 = m_pSDATable.Fields.FindField(SUBDIV_ATR_MAPTYPE_FLD_NAME)

                    ''add a queryfilter and queryfilterdefinition for sorting
                    Dim pQF As IQueryFilter
                    pQF = New QueryFilter
                    Dim pQFDef As IQueryFilterDefinition
                    pQFDef = pQF
                    pQFDef.PostfixClause = "order by SUBDIVID desc"
                    pCur = m_pSDATable.Search(pQF, False) 'changed this one
                    pRow = pCur.NextRow
                    'Build the combobox
                    cboSBDIVLGSelectSub.Items.Add("SUBDIV ID / SUBDIV NAME / MAP TYPE")
                    cboSBDIVLGSelectSub.Items.Add("")
                    Do While Not pRow Is Nothing
                        cboSBDIVLGSelectSub.Items.Add(pRow.Value(lIdx) & " / " & pRow.Value(lIdx2) & " / " & pRow.Value(lIdx3))
                        pRow = pCur.NextRow
                    Loop
                    'display the 1st item
                    If cboSBDIVLGSelectSub.Items.Count > 0 Then cboSBDIVLGSelectSub.SelectedIndex = 0
                    Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                    'cboSBDIVLGSelectSub.Focus()
                End If
            Catch ex As Exception
                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub cboSBDIVLGSelectSub_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSBDIVLGSelectSub.SelectedIndexChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Try
                ClearFormFields(True, True, True)
                If cboSBDIVLGSelectSub.SelectedIndex <> 0 Then  'to skip the initial load
                    ' Dim pQueryfilter As IQueryFilter
                    Dim pSDID As Integer
                    Dim pSDIDLOC As Integer
                    Dim tmpSDTEXT As String
                    Dim pSDNMTXTlen As Integer
                    ' Dim psdCur As ICursor
                    ' Dim psdRow As IRow
                    ' Dim pslCur As ICursor
                    ' Dim pslRow As IRow

                    tmpSDTEXT = cboSBDIVLGSelectSub.Text

                    pSDNMTXTlen = tmpSDTEXT.Length
                    pSDIDLOC = tmpSDTEXT.IndexOf("/") - 1
                    If ckbxSBDIVLGSearch.Checked Then
                        If pSDIDLOC <= 0 Then
                            MsgBox("NO SUBDIVID found.  Choose a different Record or Search by MapNum")
                            Exit Sub
                        End If
                        pSDID = tmpSDTEXT.Substring(0, pSDIDLOC)
                        'MsgBox(pSDID)
                    ElseIf ckbxSDMapNumSearch.Checked Then
                        If pSDIDLOC <= 0 Then
                            MsgBox("NO MAPNUM found.  Choose a different Record or use the SubDiv search")
                            Exit Sub
                        End If
                        pSDID = tmpSDTEXT.Substring(pSDIDLOC + 2)
                        'MsgBox(pSDID)
                    End If
                    SearchAndFillSubdiv(pSDID)
                End If
                'txtSBLGCompby.Focus()
            Catch ex As Exception
                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub cboSBDIVLGJur_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSBDIVLGJur.KeyPress
        If e.KeyChar = vbTab Then
            txtSBDIVLGworkorder.Focus()
        End If
    End Sub

    Private Sub cboSBDIVLGmaptype_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSBDIVLGmaptype.KeyPress
        If e.KeyChar = vbTab Then
            txtSBDIVLGmapnum.Focus()
        End If
    End Sub

    Private Sub cboSBLGHaveDXF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSBLGHaveDXF.KeyPress
        If e.KeyChar = vbTab Then
            txtSBLGgetDXF.Focus()
        End If
    End Sub

    Private Sub cboSBLGNad83_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSBLGNad83.KeyPress
        If e.KeyChar = vbTab Then
            cboSBLGHaveDXF.Focus()
        End If
    End Sub

    Private Sub cboSBDIVLGRefMapType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSBDIVLGRefMapType.KeyPress
        If e.KeyChar = vbTab Then
            txtSBDIVLGRefMapNum.Focus()
        End If
    End Sub

    Private Sub ckbxSDMapNumSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbxSDMapNumSearch.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Try
                If Not ckbxSDMapNumSearch.Checked Then
                    cboSBDIVLGSelectSub.Items.Clear()
                    cboSBDIVLGSelectSub.SelectedText = ""
                    cboSBDIVLGSelectSub.Text = ""
                    cboSBDIVLGSelectSub.Enabled = False
                    ckbxSDMapNumSearch.ForeColor = Drawing.Color.Black
                    ckbxSDMapNumSearch.Text = "Search on Map Num"
                    If Not pIsQuery Then
                        btnSBDIVLGSave.Text = "Add Subdivision"
                    End If
                    'clear out the form fields
                    ClearFormFields(True, True, True)
                    cboSBDIVLGJur.Focus()
                Else
                    If ckbxSBDIVLGSearch.Checked Then
                        ckbxSBDIVLGSearch.Checked = False
                    End If
                    If ckbxSBDIVLGText.Checked Then
                        ckbxSBDIVLGText.Checked = False
                    End If
                    cboSBDIVLGSelectSub.Enabled = True
                    ckbxSDMapNumSearch.ForeColor = Drawing.Color.Red
                    If Not pIsQuery Then
                        ckbxSDMapNumSearch.Text = "UN-Check to ADD NEW"
                        btnSBDIVLGSave.Text = "Save Updates"
                    End If
                    'Fill it
                    Dim pCur As ICursor, pRow As IRow, lIdx As Long, lIdx2 As Long, lIdx3 As Long
                    lIdx = m_pSDATable.Fields.FindField(SUBDIV_ATR_MAPNUM_FLD_NAME)
                    lIdx2 = m_pSDATable.Fields.FindField(SUBDIV_ATR_SUBDIVID_FLD_NAME)
                    lIdx3 = m_pSDATable.Fields.FindField(SUBDIV_ATR_MAPTYPE_FLD_NAME)

                    ''add a queryfilter and queryfilterdefinition for sorting
                    Dim pQF As IQueryFilter
                    pQF = New QueryFilter
                    Dim pQFDef As IQueryFilterDefinition
                    pQFDef = pQF
                    pQFDef.PostfixClause = "order by MAPNUM desc"
                    pCur = m_pSDATable.Search(pQF, False) 'changed this one
                    pRow = pCur.NextRow
                    'Build the combobox
                    cboSBDIVLGSelectSub.Items.Add("MAP NUM - MAP TYPE / SUBDIV ID")
                    cboSBDIVLGSelectSub.Items.Add("")
                    Do While Not pRow Is Nothing
                        cboSBDIVLGSelectSub.Items.Add(pRow.Value(lIdx) & " - " & pRow.Value(lIdx3) & " / " & pRow.Value(lIdx2))
                        pRow = pCur.NextRow
                    Loop
                    'display the 1st item
                    If cboSBDIVLGSelectSub.Items.Count > 0 Then cboSBDIVLGSelectSub.SelectedIndex = 0
                    Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                    'cboSBDIVLGSelectSub.Focus()
                End If
            Catch ex As Exception
                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub ckbxSBDIVLGText_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbxSBDIVLGText.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Try
                If Not ckbxSBDIVLGText.Checked Then
                    txtSBDIVLGSelectSub.Text = ""
                    txtSBDIVLGSelectSub.Enabled = False
                    ckbxSBDIVLGText.ForeColor = Drawing.Color.Black
                    ckbxSBDIVLGText.Text = "Type In SubDivID"
                    If Not pIsQuery Then
                        btnSBDIVLGSave.Text = "Add Subdivision"
                    End If
                    'clear out the form fields
                    ClearFormFields(True, True, True)
                    cboSBDIVLGJur.Focus()
                Else
                    If ckbxSDMapNumSearch.Checked Then
                        ckbxSDMapNumSearch.Checked = False
                    End If
                    If ckbxSBDIVLGSearch.Checked Then
                        ckbxSBDIVLGSearch.Checked = False
                    End If
                    txtSBDIVLGSelectSub.Enabled = True
                    ckbxSBDIVLGText.ForeColor = Drawing.Color.Red
                    If Not pIsQuery Then
                        ckbxSBDIVLGText.Text = "UN-Check to ADD NEW"
                        btnSBDIVLGSave.Text = "Save Updates"
                    End If
                    'Fill it
                    Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                    txtSBDIVLGSelectSub.Focus()
                End If
            Catch ex As Exception
                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub


#End Region

#Region "Buttons"

    Private Sub btnSBDIVLGExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSBDIVLGExit.Click
        Try
            m_ActiveView = Nothing
            m_pLotTable = Nothing
            m_pWSE = Nothing
            m_pWSE = Nothing
            Me.Close()
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnSBDIVLGReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSBDIVLGReset.Click
        Try
            ClearFormFields(True, True, True)
            ckbxSBDIVLGSearch.Checked = False
            ckbxSDMapNumSearch.Checked = False
            cboSBDIVLGJur.Focus()
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnSBDIVLGSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSBDIVLGSave.Click
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Try
            'first check field lengths
            Dim flderrmsg As String
            Dim flderr As Boolean
            flderr = False
            flderrmsg = ""
            If txtSBDIVLGsubdivname.Text.Length > 64 Then
                flderr = True
                flderrmsg = flderrmsg & "Subdivision Name has to be 64 characters or less" & vbNewLine
            End If
            If (ckbxSBDIVLGSearch.Checked Or ckbxSDMapNumSearch.Checked) And txtSBDIVLGsubdivid.Text = "" Then
                flderr = True
                flderrmsg = flderrmsg & "Update Subdivision Checked, but no existing SUBDIVID is selected" & vbNewLine
            End If
            If txtSBDIVLGmaptietype.Text = "" Then
                flderr = True
                flderrmsg = flderrmsg & "Map Tie Type can not be empty" & vbNewLine
            End If
            If flderr Then
                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                flderrmsg = flderrmsg & "Please modify the entries and try to save again"
                MsgBox(flderrmsg, MsgBoxStyle.Critical, "EDITS NOT SAVED")
                Exit Sub
            End If

            Dim psvRow As IRow
            Dim psvlRow As IRow
            If ckbxSBDIVLGSearch.Checked Or ckbxSDMapNumSearch.Checked Then
                Dim psvQF As IQueryFilter
                Dim psvSDID As Integer
                psvSDID = txtSBDIVLGsubdivid.Text
                psvQF = New QueryFilter
                psvQF.WhereClause = "SUBDIVID = " & psvSDID
                'SubDiv ATR
                Dim psvCur As ICursor
                psvCur = m_pSDATable.Search(psvQF, False) 'changed this one
                psvRow = psvCur.NextRow
                'SubDiv Log
                Dim psvlCur As ICursor
                psvlCur = m_pSDLTable.Search(psvQF, False) 'changed this one
                psvlRow = psvlCur.NextRow
                'In case no log was ever created, create one
                If psvlRow Is Nothing Then
                    psvlRow = m_pSDLTable.CreateRow
                End If
            Else
                psvRow = m_pSDATable.CreateRow 'subdiv atr
                psvlRow = m_pSDLTable.CreateRow 'subdiv log
            End If

            'Subdiv ATR
            If Not psvRow Is Nothing Then
                ''Key fields do not get calced
                'Subdivision Fields
                If Not IsDBNull(cboSBDIVLGJur.Text) And Not cboSBDIVLGJur.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_JURISDIC_FLD_NAME)) = cboSBDIVLGJur.Text
                End If
                If Not IsDBNull(txtSBDIVLGworkorder.Text) And Not txtSBDIVLGworkorder.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_WRKORDID_FLD_NAME)) = txtSBDIVLGworkorder.Text
                End If
                If Not IsDBNull(cboSBDIVLGmaptype.Text) And Not cboSBDIVLGmaptype.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_MAPTYPE_FLD_NAME)) = cboSBDIVLGmaptype.Text
                End If
                If Not IsDBNull(txtSBDIVLGtentmap.Text) And Not txtSBDIVLGtentmap.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_TENTMAP_FLD_NAME)) = txtSBDIVLGtentmap.Text
                End If
                If Not IsDBNull(txtSBDIVLGmapnum.Text) And Not txtSBDIVLGmapnum.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_MAPNUM_FLD_NAME)) = txtSBDIVLGmapnum.Text
                End If
                If Not IsDBNull(dtSBDIVLGrecdate.Text) And Not dtSBDIVLGrecdate.Text Is Nothing And dtSBDIVLGrecdate.Checked Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_RECDATE_FLD_NAME)) = dtSBDIVLGrecdate.Text
                End If
                If IsNumeric(txtSBDIVLGnumlots.Text) And Not txtSBDIVLGnumlots.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_NUMLOTS_FLD_NAME)) = txtSBDIVLGnumlots.Text
                End If
                If Not IsDBNull(txtSBDIVLGsubdivname.Text) And Not txtSBDIVLGsubdivname.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_SUBNAME_FLD_NAME)) = txtSBDIVLGsubdivname.Text
                End If
                If IsNumeric(txtSBDIVLGsubacreage.Text) And Not txtSBDIVLGsubacreage.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_ACREAGE_FLD_NAME)) = txtSBDIVLGsubacreage.Text
                End If
                If Not IsDBNull(txtSBDIVLGsubstatus.Text) And Not txtSBDIVLGsubstatus.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_STATUS_FLD_NAME)) = txtSBDIVLGsubstatus.Text
                End If
                If Not IsDBNull(dtSBDIVLGengsigndt.Text) And Not dtSBDIVLGengsigndt.Text Is Nothing And dtSBDIVLGengsigndt.Checked Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_ENG_SIGNDATE_FLD_NAME)) = dtSBDIVLGengsigndt.Text
                End If
                If Not IsDBNull(txtSBDIVLGtbgrid.Text) And Not txtSBDIVLGtbgrid.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_TB_GRID_FLD_NAME)) = txtSBDIVLGtbgrid.Text
                End If
                If IsNumeric(txtSBDIVLGmaptietype.Text) And Not txtSBDIVLGmaptietype.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_MAP_TIETYPE_FLD_NAME)) = txtSBDIVLGmaptietype.Text
                End If

                'Tie fields
                If Not IsDBNull(txtSBDIVLGtiepostid.Text) And Not txtSBDIVLGtiepostid.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_TIE_POSTID_FLD_NAME)) = txtSBDIVLGtiepostid.Text
                End If
                If Not IsDBNull(dtSBDIVLGTiePostDate.Text) And Not dtSBDIVLGTiePostDate.Text Is Nothing And dtSBDIVLGTiePostDate.Checked Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_TIE_POSTDATE_FLD_NAME)) = dtSBDIVLGTiePostDate.Text
                End If
                If IsNumeric(txtSBDIVLGRotationAngle.Text) And Not txtSBDIVLGRotationAngle.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_ROTATION_ANGLE_FLD_NAME)) = txtSBDIVLGRotationAngle.Text
                End If
                If IsNumeric(txtSBDIVLGPivotEasting.Text) And Not txtSBDIVLGPivotEasting.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_PIVOT_POINT_E_FLD_NAME)) = txtSBDIVLGPivotEasting.Text
                End If
                If IsNumeric(txtSBDIVLGPivotNorthing.Text) And Not txtSBDIVLGPivotNorthing.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_PIVOT_POINT_N_FLD_NAME)) = txtSBDIVLGPivotNorthing.Text
                End If
                If Not IsDBNull(cboSBDIVLGRefMapType.Text) And Not cboSBDIVLGRefMapType.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_REF_MAP_TYPE_FLD_NAME)) = cboSBDIVLGRefMapType.Text
                End If
                If IsNumeric(txtSBDIVLGRefMapNum.Text) And Not txtSBDIVLGRefMapNum.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_REF_MAP_NUM_FLD_NAME)) = txtSBDIVLGRefMapNum.Text
                End If
                'Tie1
                If Not IsDBNull(txtSBDIVLGTie1Bearing.Text) And Not txtSBDIVLGTie1Bearing.Text Is Nothing And Not txtSBDIVLGTie1Bearing.Text.Replace(" ", "") = "--" Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_TIE1_BEARING_FLD_NAME)) = txtSBDIVLGTie1Bearing.Text
                End If
                If IsNumeric(txtSBDIVLGTie1Distance.Text) And Not txtSBDIVLGTie1Distance.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_TIE1_DIST_FLD_NAME)) = txtSBDIVLGTie1Distance.Text
                End If
                If IsNumeric(txtSBDIVLGTie1Point.Text) And Not txtSBDIVLGTie1Point.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_TIE1_POINT_FLD_NAME)) = txtSBDIVLGTie1Point.Text
                End If
                If IsNumeric(txtSBDIVLGPT1StationID.Text) And Not txtSBDIVLGPT1StationID.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_PT1_STATIONID_FLD_NAME)) = txtSBDIVLGPT1StationID.Text
                End If
                If Not IsDBNull(txtSBDIVLGTie1DistType.Text) And Not txtSBDIVLGTie1DistType.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_TIE1_DISTTYPE_FLD_NAME)) = txtSBDIVLGTie1DistType.Text
                End If
                'Tie2
                If Not IsDBNull(txtSBDIVLGTie2Bearing.Text) And Not txtSBDIVLGTie2Bearing.Text Is Nothing And Not txtSBDIVLGTie2Bearing.Text.Replace(" ", "") = "--" Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_TIE2_BEARING_FLD_NAME)) = txtSBDIVLGTie2Bearing.Text
                End If
                If IsNumeric(txtSBDIVLGTie2Distance.Text) And Not txtSBDIVLGTie2Distance.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_TIE2_DIST_FLD_NAME)) = txtSBDIVLGTie2Distance.Text
                End If
                If IsNumeric(txtSBDIVLGTie2Point.Text) And Not txtSBDIVLGTie2Point.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_TIE2_POINT_FLD_NAME)) = txtSBDIVLGTie2Point.Text
                End If
                If IsNumeric(txtSBDIVLGPT2StationID.Text) And Not txtSBDIVLGPT2StationID.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_PT2_STATIONID_FLD_NAME)) = txtSBDIVLGPT2StationID.Text
                End If
                If Not IsDBNull(txtSBDIVLGTie2DistType.Text) And Not txtSBDIVLGTie2DistType.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_TIE2_DISTTYPE_FLD_NAME)) = txtSBDIVLGTie2DistType.Text
                End If
                'GPS
                If IsNumeric(txtSBDIVLGGPSPT1North.Text) And Not txtSBDIVLGGPSPT1North.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_GPS_PT1_N_FLD_NAME)) = txtSBDIVLGGPSPT1North.Text
                End If
                If IsNumeric(txtSBDIVLGGPSPT1East.Text) And Not txtSBDIVLGGPSPT1East.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_GPS_PT1_E_FLD_NAME)) = txtSBDIVLGGPSPT1East.Text
                End If
                If IsNumeric(txtSBDIVLGGPSPT2North.Text) And Not txtSBDIVLGGPSPT2North.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_GPS_PT2_N_FLD_NAME)) = txtSBDIVLGGPSPT2North.Text
                End If
                If IsNumeric(txtSBDIVLGGPSPT2East.Text) And Not txtSBDIVLGGPSPT2East.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_GPS_PT2_E_FLD_NAME)) = txtSBDIVLGGPSPT2East.Text
                End If
                psvRow.Store()
                'Fill the atr primary info txt boxes
                Dim pnewsubid As Integer
                pnewsubid = psvRow.Value(psvRow.Fields.FindField("SUBDIVID"))
                txtSBDIVLGsubdivid.Text = pnewsubid
                txtSBDIVLGPostDate.Text = psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_POSTDATE_FLD_NAME))
                txtSBDIVLGPostID.Text = psvRow.Value(psvRow.Fields.FindField(SUBDIV_ATR_POSTID_FLD_NAME))

                'Subdiv Log table
                If Not psvlRow Is Nothing Then
                    'primary fields
                    If Not IsDBNull(txtSBDIVLGsubdivid.Text) And Not txtSBDIVLGsubdivid.Text Is Nothing Then
                        psvlRow.Value(psvlRow.Fields.FindField(SUBDIV_LOG_SUBDIVID_FLD_NAME)) = txtSBDIVLGsubdivid.Text
                    End If
                    'log fields
                    If Not IsDBNull(dtSBLOGRecieced.Text) And Not dtSBLOGRecieced.Text Is Nothing And dtSBLOGRecieced.Checked Then
                        psvlRow.Value(psvlRow.Fields.FindField(SUBDIV_LOG_RECEIVED_FLD_NAME)) = dtSBLOGRecieced.Text
                    End If
                    If Not IsDBNull(txtSBLGAsgnTo.Text) And Not txtSBLGAsgnTo.Text Is Nothing Then
                        psvlRow.Value(psvlRow.Fields.FindField(SUBDIV_LOG_ASGNTO_FLD_NAME)) = txtSBLGAsgnTo.Text
                    End If
                    If Not IsDBNull(dtSBLGAsgnDate.Text) And Not dtSBLGAsgnDate.Text Is Nothing And dtSBLGAsgnDate.Checked Then
                        psvlRow.Value(psvlRow.Fields.FindField(SUBDIV_LOG_ASGNDATE_FLD_NAME)) = dtSBLGAsgnDate.Text
                    End If
                    If Not IsDBNull(txtSBLGMArea.Text) And Not txtSBLGMArea.Text Is Nothing Then
                        psvlRow.Value(psvlRow.Fields.FindField(SUBDIV_LOG_MAPAREA_FLD_NAME)) = txtSBLGMArea.Text
                    End If
                    If Not IsDBNull(cboSBLGNad83.Text) And Not cboSBLGNad83.Text Is Nothing Then
                        psvlRow.Value(psvlRow.Fields.FindField(SUBDIV_LOG_NAD83_FLD_NAME)) = cboSBLGNad83.Text
                    End If
                    If Not IsDBNull(cboSBLGHaveDXF.Text) And Not cboSBLGHaveDXF.Text Is Nothing Then
                        psvlRow.Value(psvlRow.Fields.FindField(SUBDIV_LOG_HAVEDXF_FLD_NAME)) = cboSBLGHaveDXF.Text
                    End If
                    If Not IsDBNull(txtSBLGgetDXF.Text) And Not txtSBLGgetDXF.Text Is Nothing Then
                        psvlRow.Value(psvlRow.Fields.FindField(SUBDIV_LOG_GETDXF_FLD_NAME)) = txtSBLGgetDXF.Text
                    End If
                    If Not IsDBNull(txtSBLGCompby.Text) And Not txtSBLGCompby.Text Is Nothing Then
                        psvlRow.Value(psvlRow.Fields.FindField(SUBDIV_LOG_COMP_BY_FLD_NAME)) = txtSBLGCompby.Text
                    End If
                    If Not IsDBNull(dtSBLGCompDate.Text) And Not dtSBLGCompDate.Text Is Nothing And dtSBLGCompDate.Checked Then
                        psvlRow.Value(psvlRow.Fields.FindField(SUBDIV_LOG_COMPDATE_NAME)) = dtSBLGCompDate.Text
                    End If
                    If Not IsDBNull(txtSBLGComments.Text) And Not txtSBLGComments.Text Is Nothing Then
                        psvlRow.Value(psvlRow.Fields.FindField(SUBDIV_LOG_COMMENTS_NAME)) = txtSBLGComments.Text
                    End If
                End If

                psvlRow.Store()

            End If
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            If ckbxSBDIVLGSearch.Checked Or ckbxSDMapNumSearch.Checked Then
                MsgBox("Updated: " & txtSBDIVLGsubdivid.Text & " / " & txtSBDIVLGsubdivname.Text)
            Else
                MsgBox("Added: " & txtSBDIVLGsubdivname.Text & " with subdivID of " & txtSBDIVLGsubdivid.Text)
                btnSBDIVLGReset.PerformClick()
                psvlRow = Nothing
                psvRow = Nothing
            End If
            btnSBDIVLGReset.PerformClick()
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnSBDIVLGExit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnSBDIVLGExit.KeyPress
        If e.KeyChar = vbTab Then
            cboSBDIVLGJur.Focus()
        ElseIf e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnSBDIVLGExit.PerformClick()
        End If
    End Sub

    Private Sub btnSBDIVLGReset_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnSBDIVLGReset.KeyPress
        If e.KeyChar = vbTab Then
            cboSBDIVLGJur.Focus()
        ElseIf e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnSBDIVLGReset.PerformClick()
        End If
    End Sub

    Private Sub btnSBDIVLGSave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnSBDIVLGSave.KeyPress
        If e.KeyChar = vbTab Then
            cboSBDIVLGJur.Focus()
        ElseIf e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnSBDIVLGSave.PerformClick()
        End If
    End Sub

    Private Sub btnSUBDIVViewLots_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSUBDIVViewLots.Click
        'Dim ShowLotInfoForm As New FrmQueryLots
        'ShowLotInfoForm.FrmMap = Me.FrmMap
        'ShowLotInfoForm.pSubDivID = Me.txtSBDIVLGsubdivid.Text
        'ShowLotInfoForm.ShowDialog()
        lblNoneFound.Visible = False
        Try
            dgLotInfo.DataSource = Nothing
            m_SubDivID = txtSBDIVLGsubdivid.Text
            txtLOTSubDivID.Text = m_SubDivID

            If m_SubDivID <> "" Then
                'fill the grid
                PopGridList(m_SubDivID)
            Else
                MsgBox("Bad SubDivID")
                ' Me.Close()
                lblNoneFound.Visible = True
                Exit Sub
            End If

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")

        End Try
        TabSubdivForm.SelectedTab = TabLot

    End Sub

    Private Sub btnSubDivFindFtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubDivFindFtr.Click
        If IsNumeric(txtSBDIVLGsubdivid.Text) Then
            GetSelectedFeatures(SUBDIVISION_DATASRC, m_ActiveView, "SUBDIVID", txtSBDIVLGsubdivid.Text, True)
        Else
            MsgBox("Please select a valid Subdivision ID")
        End If
    End Sub

#End Region



    Private Sub TabLot_Click(sender As System.Object, e As System.EventArgs) Handles TabLot.Click

    End Sub

    Private Sub TabLot_Enter(sender As Object, e As System.EventArgs) Handles TabLot.Enter
        If IsLoaded And m_SubDivID <> "" Then
            btnSUBDIVViewLots.PerformClick()
        Else
            txtLOTSubDivID.Text = ""
            dgLotInfo.DataSource = Nothing
        End If


    End Sub

    Private Sub PopGridList(ByVal pqRDID As String)
        Try
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Dim pRDIDQF As IQueryFilter
            Dim pRDID As String
            Dim pOrdby As String
            pOrdby = cboLotSort.Text
            pRDID = pqRDID
            pRDIDQF = New QueryFilter

            If pRDID <> "" Then
                m_TWWhereClause = "SUBDIVID = " & pRDID
                pRDIDQF.WhereClause = m_TWWhereClause
                m_TWPostfixClause = "Order By " & pOrdby
            Else
                MsgBox("No Valid SUBDIV ID selected.")
                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                Exit Sub
            End If
            'check if any selected
            Dim pRwCnt As Integer
            pRwCnt = m_pLotTable.RowCount(pRDIDQF)

            lblLotFndCnt.Text = pRwCnt
            If pRwCnt > 0 And pRwCnt < 1001 Then
                lblNoneFound.Visible = False
                FillGridData()
            ElseIf pRwCnt > 1000 Then
                lblNoneFound.Visible = False
                Dim prowlots As MsgBoxResult
                prowlots = MsgBox(pRwCnt & " Records found, press OK to continue, CANCEL to start new search", MsgBoxStyle.OkCancel, "Thats a Lot of Records!")
                If prowlots = MsgBoxResult.Ok Then
                    FillGridData()
                End If
            Else
                lblNoneFound.Visible = True
                'MsgBox("No SUBDIVID records found matching search criteria", MsgBoxStyle.Information)
            End If
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")

        End Try

    End Sub

    Private Sub FillGridData()
        'Fill the datagrid
        Try
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            tableWrapper = New ArcDataBinding.TableWrapper(m_pLotTable)
            dgLotInfo.DataSource = tableWrapper
            With dgLotInfo

                .Columns("BLOCKNO").DisplayIndex = 0
                .Columns("BLOCKNO").Width = 55
                .Columns("BLOCKNO").HeaderText = "Blockno"

                .Columns("LOTNO").DisplayIndex = 1
                .Columns("LOTNO").Width = 55
                .Columns("LOTNO").HeaderText = "Lotno"

                .Columns("LOTID").DisplayIndex = 2
                .Columns("LOTID").Width = 55
                .Columns("LOTID").HeaderText = "Lotid"

                .Columns("SUB_TYPE").DisplayIndex = 3
                .Columns("SUB_TYPE").Width = 80
                .Columns("SUB_TYPE").HeaderText = "SUBTYPE"


                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            End With
            'dgRSGRD.Focus()
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")

        End Try
    End Sub


    Private Sub btnLotExit_Click(sender As System.Object, e As System.EventArgs) Handles btnLotExit.Click
        TabSubdivForm.SelectedTab = TabSubdiv
    End Sub

    Private Sub TabSubdiv_Click(sender As System.Object, e As System.EventArgs) Handles TabSubdiv.Click

    End Sub

    Private Sub TabSubdiv_Enter(sender As Object, e As System.EventArgs) Handles TabSubdiv.Enter
        btnLotExit.PerformClick()
    End Sub

    Private Sub cboLotSort_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboLotSort.SelectedIndexChanged
        If IsLoaded Then
            dgLotInfo.DataSource = Nothing
            PopGridList(m_SubDivID)
        End If
    End Sub

    Private Sub btnExporttoExcelAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnExporttoExcelAdd.Click
        ExportToExcel.ExportDGVtoExcel(dgLotInfo)
    End Sub

    Private Sub txtSBDIVLGSelectSub_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSBDIVLGSelectSub.TextChanged

    End Sub
End Class