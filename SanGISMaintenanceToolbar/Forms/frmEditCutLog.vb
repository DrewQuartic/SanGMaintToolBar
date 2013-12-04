Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports SanGISMaintenanceToolbar.Globals

Public Class frmEditCutLog
    'Dim m_pWKSP As IWorkspace
    Dim m_ActiveView As IActiveView
    Dim m_pCLTable As ITable
    Dim m_pCLDTTable As ITable
    Dim m_pCLASRTable As ITable
    Dim m_pCLSubTable As ITable
    Dim m_pCLSubLTable As ITable
    Dim m_pWSE As IWorkspaceEdit
    Dim m_pEdtCells As Collection
    Private tableWrapper As ArcDataBinding.TableWrapper
    Private IsInitializing As Boolean
    Private ItFailed As Boolean

#Region "Properties"

    Public Property FrmMap() As IActiveView
        Get
            Return m_ActiveView
        End Get

        Set(ByVal ActiveView As IActiveView)
            m_ActiveView = ActiveView
        End Set

    End Property

#End Region

#Region "Primaries"

    Private Sub frmEditCutLog_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not ItFailed Then
            Dim pDataset As IDataset
            pDataset = m_pCLASRTable
            m_pWSE = pDataset.Workspace
            If m_pWSE.IsBeingEdited Then
                m_pWSE.StopEditOperation()
                m_pWSE.StopEditing(True)
            End If
        End If
        m_ActiveView = Nothing
        m_pCLASRTable = Nothing
        m_pCLDTTable = Nothing
        m_pCLSubLTable = Nothing
        m_pCLSubTable = Nothing
        m_pCLTable = Nothing
        'm_pWKSP = Nothing
        m_pWSE = Nothing

    End Sub

    Private Sub frmEditCutLog_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F1 Then
            btnCtLgReset.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.F8 Then
            If ckbxCtLgSearch.Checked Then
                ckbxCtLgSearch.Checked = False
            Else
                ckbxCtLgSearch.Checked = True
            End If
        ElseIf e.KeyCode = Windows.Forms.Keys.F10 Then
            btnCtLgSave.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.F12 Then
            btnCtLgExit.PerformClick()
        End If
    End Sub

    Private Sub frmEditCutLog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            'Check if the user has edit privs on tables first
            ItFailed = False
            If CheckifEditable("ANY", FrmMap) Then
                'ok to edit
            Else
                MsgBox("You do not have the privileges to edit this version.")
                ItFailed = True
                Me.Close()
            End If

            'Load the tables
            m_CTNM = ""
            m_CTYR = ""
            m_CTYRNM = "0"
            m_pEdtCells = New Collection
            m_pEdtCells.Clear()
            'ATR table
            Dim pTableSourcename As String
            pTableSourcename = LOG_PARCEL_CUTLOG_DATASRC
            m_pCLTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename, False)
            If m_pCLTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If
            'DTL table
            Dim pTableSourcename2 As String
            pTableSourcename2 = LOG_PARCEL_CUTLOG_DTL_DATASRC
            m_pCLDTTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename2, False)
            If m_pCLDTTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If
            'ASR table
            Dim pTableSourcename3 As String
            pTableSourcename3 = LOG_PARCEL_ASR_CUTLOG_DATASRC
            m_pCLASRTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename3, False)
            If m_pCLASRTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If
            'Sub Divtable
            Dim pTableSourcename4 As String
            pTableSourcename4 = SUBDIV_ATR_DATASRC
            m_pCLSubTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename4, False)
            If m_pCLSubTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If
            'Sub Div logtable
            Dim pTableSourcename5 As String
            pTableSourcename5 = SUBDIV_LOG_DATASRC
            m_pCLSubLTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename5, False)
            If m_pCLSubLTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If

            'Fill the combos
            cboCtLgJur.Items.Add("")
            cboCtLgJur.Items.Add("CB")
            cboCtLgJur.Items.Add("CN")
            cboCtLgJur.Items.Add("CO")
            cboCtLgJur.Items.Add("CV")
            cboCtLgJur.Items.Add("DM")
            cboCtLgJur.Items.Add("EC")
            cboCtLgJur.Items.Add("EN")
            cboCtLgJur.Items.Add("ES")
            cboCtLgJur.Items.Add("IB")
            cboCtLgJur.Items.Add("LG")
            cboCtLgJur.Items.Add("LM")
            cboCtLgJur.Items.Add("NC")
            cboCtLgJur.Items.Add("OC")
            cboCtLgJur.Items.Add("PW")
            cboCtLgJur.Items.Add("SD")
            cboCtLgJur.Items.Add("SM")
            cboCtLgJur.Items.Add("SO")
            cboCtLgJur.Items.Add("ST")
            cboCtLgJur.Items.Add("VS")

            cboCtLgMapType.Items.Add("COC")
            cboCtLgMapType.Items.Add("DB")
            cboCtLgMapType.Items.Add("DP")
            cboCtLgMapType.Items.Add("FP")
            cboCtLgMapType.Items.Add("LP")
            cboCtLgMapType.Items.Add("LS")
            cboCtLgMapType.Items.Add("MAP")
            cboCtLgMapType.Items.Add("MM")
            cboCtLgMapType.Items.Add("MS")
            cboCtLgMapType.Items.Add("PB")
            cboCtLgMapType.Items.Add("PM")
            cboCtLgMapType.Items.Add("ROS")
            cboCtLgMapType.Items.Add("SCC")


            cboCtLgCondoOnly.Items.Add("Y")
            cboCtLgCondoOnly.Items.Add("N")

            cboCtLgStreetDed.Items.Add("Y")
            cboCtLgStreetDed.Items.Add("N")

            cboCtLgStreetVac.Items.Add("Y")
            cboCtLgStreetVac.Items.Add("N")

            cboCtLgOpenSpace.Items.Add("Y")
            cboCtLgOpenSpace.Items.Add("N")

            cboCtLgLandReq.Items.Add("Y")
            cboCtLgLandReq.Items.Add("N")

        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Custom"

    Public Sub ClearFormFields(ByVal ACTLGSection As Boolean, ByVal BAssrSection As Boolean, ByVal CSubdivSection As Boolean)
        Try
            If ACTLGSection Then
                txtCtLgPostID.Text = ""
                txtCtLgPostDate.Text = ""
                txtCtLgCutYear.Text = ""
                txtCtLgCutNum.Text = ""
                cboCtLgCondoOnly.Text = ""
                cboCtLgStreetDed.Text = ""
                cboCtLgStreetVac.Text = ""
                cboCtLgOpenSpace.Text = ""
                cboCtLgLandReq.Text = ""
                dtCtLgAssignedDate.Text = ""
                dtCtLgCompDate.Text = ""
                dtCtLgReceived.Text = ""
                dtCtLgAssignedDate.Checked = False
                dtCtLgCompDate.Checked = False
                dtCtLgReceived.Checked = False
                cboCtLgJur.Text = ""
                txtCtLgAssignedTo.Text = ""
                txtCtLgCompBy.Text = ""
                txtCtLgArea.Text = ""
                txtCtLgRemarks.Text = ""
                'DataGridView1 = 
                cboCtLgMapType.Text = ""
                txtCtLgMapNum.Text = ""
            End If
            If BAssrSection Then
                txtAssrCtLgToRC.Text = ""
                txtAssrCtLgApprID.Text = ""
                txtAssrCtLgArea.Text = ""
                txtAssrCtLgAppraiser.Text = ""
                txtAssrCtLgTech.Text = ""
                txtAssrCtLgMapNum.Text = ""
                txtAssrCtLgAuthority.Text = ""
                txtAssrCtLgToNote.Text = ""
                txtAssrCtLgToAPN.Text = ""
                txtAssrCtLgFromAPN.Text = ""
                txtAssrCtLgTo.Text = ""
                txtAssrCtLgFrom.Text = ""
                txtAssrCtLgCutType.Text = ""
            End If
            If CSubdivSection Then
                txtSbCtLgCompDate.Text = ""
                txtSbCtLgCompBy.Text = ""
                txtSbCtLgAssignDate.Text = ""
                txtSbCtLgAssignTo.Text = ""
                txtSbCtLgComments.Text = ""
                txtSbCtLgNAD83.Text = ""
                txtSbCtLgHaveDXF.Text = ""
                txtSbCtLgGetDXF.Text = ""
                txtSbCtLgArea.Text = ""
            End If
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try

    End Sub

    Private Sub FillGridData()
        'Fill the datagrid
        Try
            m_WrapperCaller = "FrmEditCutLog"
            tableWrapper = New ArcDataBinding.TableWrapper(m_pCLDTTable)
            DataGridView1.DataSource = tableWrapper
            With DataGridView1
                .AllowUserToAddRows = True
                .Columns("ObjectID").Visible = False
                .Columns("BOOK_PAGE").DisplayIndex = 0
                .Columns("BOOK_PAGE").Width = 77
                .Columns("REMARKS").DisplayIndex = 1
                .Columns("REMARKS").Width = 200
                .Columns("CUT_YEAR_NUM").DisplayIndex = 2
                .Columns("CUT_YEAR_NUM").Width = 130
                .Columns("CUT_YEAR_NUM").ReadOnly = True
                .Columns("CUT_YEAR").Visible = False
                .Columns("CUT_NUM").Visible = False
            End With
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub
#End Region

#Region "Combo boxes"

    Private Sub cboCtLgSelectName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCtLgSelectName.SelectedIndexChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Try
                ClearFormFields(True, True, True)
                If cboCtLgSelectName.SelectedIndex <> 0 Then  'to skip the initial load
                    Dim pQueryfilter As IQueryFilter
                    Dim pCLID As Integer
                    'ctlg
                    Dim pclCur As ICursor
                    Dim pclRow As IRow
                    'ctlg assr
                    Dim pclaCur As ICursor
                    Dim pclaRow As IRow

                    pCLID = cboCtLgSelectName.Text
                    'MsgBox(pSDID)
                    pQueryfilter = New QueryFilter
                    pQueryfilter.WhereClause = "CUT_YEAR_NUM = " & pCLID
                    'CUT TABLE
                    pclCur = m_pCLTable.Search(pQueryfilter, False) 'changed this one
                    pclRow = pclCur.NextRow
                    'ASR TABLE
                    pclaCur = m_pCLASRTable.Search(pQueryfilter, False) 'changed this one
                    pclaRow = pclaCur.NextRow

                    'CUT TABLE
                    If Not pclRow Is Nothing Then
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_POSTID_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_POSTID_FLD_NAME)) Is Nothing Then
                            txtCtLgPostID.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_POSTID_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_POSTDATE_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_POSTDATE_FLD_NAME)) Is Nothing Then
                            txtCtLgPostDate.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_POSTDATE_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_CUT_YEAR_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_CUT_YEAR_FLD_NAME)) Is Nothing Then
                            txtCtLgCutYear.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_CUT_YEAR_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_CUT_NUM_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_CUT_NUM_FLD_NAME)) Is Nothing Then
                            txtCtLgCutNum.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_CUT_NUM_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_CONDO_ONLY_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_CONDO_ONLY_FLD_NAME)) Is Nothing Then
                            cboCtLgCondoOnly.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_CONDO_ONLY_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_STREET_DEDICATION_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_STREET_DEDICATION_FLD_NAME)) Is Nothing Then
                            cboCtLgStreetDed.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_STREET_DEDICATION_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_STREET_VACATION_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_STREET_VACATION_FLD_NAME)) Is Nothing Then
                            cboCtLgStreetVac.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_STREET_VACATION_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_OPEN_SPACE_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_OPEN_SPACE_FLD_NAME)) Is Nothing Then
                            cboCtLgOpenSpace.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_OPEN_SPACE_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_LAND_REQ_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_LAND_REQ_FLD_NAME)) Is Nothing Then
                            cboCtLgLandReq.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_LAND_REQ_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_ASSIGNED_DATE_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_ASSIGNED_DATE_FLD_NAME)) Is Nothing Then
                            dtCtLgAssignedDate.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_ASSIGNED_DATE_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_COMP_DATE_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_COMP_DATE_FLD_NAME)) Is Nothing Then
                            dtCtLgCompDate.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_COMP_DATE_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_RECEIVED_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_RECEIVED_FLD_NAME)) Is Nothing Then
                            dtCtLgReceived.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_RECEIVED_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_JUR_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_JUR_FLD_NAME)) Is Nothing Then
                            cboCtLgJur.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_JUR_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_ASSIGNED_TO_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_ASSIGNED_TO_FLD_NAME)) Is Nothing Then
                            txtCtLgAssignedTo.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_ASSIGNED_TO_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_COMP_BY_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_COMP_BY_FLD_NAME)) Is Nothing Then
                            txtCtLgCompBy.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_COMP_BY_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_AREA_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_AREA_FLD_NAME)) Is Nothing Then
                            txtCtLgArea.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_AREA_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_REMARKS_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_REMARKS_FLD_NAME)) Is Nothing Then
                            txtCtLgRemarks.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_REMARKS_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_MAP_TYPE_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_MAP_TYPE_FLD_NAME)) Is Nothing Then
                            cboCtLgMapType.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_MAP_TYPE_FLD_NAME))
                        End If
                        If Not IsDBNull(pclRow.Value(pclRow.Fields.FindField(PARCUTLG_MAP_NUM_FLD_NAME))) And Not pclRow.Value(pclRow.Fields.FindField(PARCUTLG_MAP_NUM_FLD_NAME)) Is Nothing Then
                            txtCtLgMapNum.Text = pclRow.Value(pclRow.Fields.FindField(PARCUTLG_MAP_NUM_FLD_NAME))
                        End If
                    End If

                    'ASR TABLE
                    If Not pclaRow Is Nothing Then
                        If Not IsDBNull(pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_DATE_TO_RC_FLD_NAME))) And Not pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_DATE_TO_RC_FLD_NAME)) Is Nothing Then
                            txtAssrCtLgToRC.Text = pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_DATE_TO_RC_FLD_NAME))
                        End If
                        If Not IsDBNull(pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_APPR_ID_FLD_NAME))) And Not pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_APPR_ID_FLD_NAME)) Is Nothing Then
                            txtAssrCtLgApprID.Text = pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_APPR_ID_FLD_NAME))
                        End If
                        If Not IsDBNull(pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_SUPERVISOR_AREA_FLD_NAME))) And Not pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_SUPERVISOR_AREA_FLD_NAME)) Is Nothing Then
                            txtAssrCtLgArea.Text = pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_SUPERVISOR_AREA_FLD_NAME))
                        End If
                        If Not IsDBNull(pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_APPR_NAME_FLD_NAME))) And Not pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_APPR_NAME_FLD_NAME)) Is Nothing Then
                            txtAssrCtLgAppraiser.Text = pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_APPR_NAME_FLD_NAME))
                        End If
                        If Not IsDBNull(pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_TECH_INITIALS_FLD_NAME))) And Not pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_TECH_INITIALS_FLD_NAME)) Is Nothing Then
                            txtAssrCtLgTech.Text = pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_TECH_INITIALS_FLD_NAME))
                        End If
                        If Not IsDBNull(pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_MAP_NUM_FLD_NAME))) And Not pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_MAP_NUM_FLD_NAME)) Is Nothing Then
                            txtAssrCtLgMapNum.Text = pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_MAP_NUM_FLD_NAME))
                        End If
                        If Not IsDBNull(pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_AUTHORITY_FLD_NAME))) And Not pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_AUTHORITY_FLD_NAME)) Is Nothing Then
                            txtAssrCtLgAuthority.Text = pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_AUTHORITY_FLD_NAME))
                        End If
                        If Not IsDBNull(pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_TONOTE_FLD_NAME))) And Not pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_TONOTE_FLD_NAME)) Is Nothing Then
                            txtAssrCtLgToNote.Text = pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_TONOTE_FLD_NAME))
                        End If
                        If Not IsDBNull(pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGDTL_CUT_NUM_FLD_NAME))) And Not pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGDTL_CUT_NUM_FLD_NAME)) Is Nothing Then
                            txtAssrCtLgToAPN.Text = pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGDTL_CUT_NUM_FLD_NAME))
                        End If
                        If Not IsDBNull(pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_FROM_APN_FLD_NAME))) And Not pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_FROM_APN_FLD_NAME)) Is Nothing Then
                            txtAssrCtLgFromAPN.Text = pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_FROM_APN_FLD_NAME))
                        End If
                        If Not IsDBNull(pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_NUM_FROM_FLD_NAME))) And Not pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_NUM_FROM_FLD_NAME)) Is Nothing Then
                            txtAssrCtLgTo.Text = pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_NUM_FROM_FLD_NAME))
                        End If
                        If Not IsDBNull(pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_NUM_FROM_FLD_NAME))) And Not pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_NUM_FROM_FLD_NAME)) Is Nothing Then
                            txtAssrCtLgFrom.Text = pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_NUM_FROM_FLD_NAME))
                        End If
                        If Not IsDBNull(pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_CUT_TYPE_FLD_NAME))) And Not pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_CUT_TYPE_FLD_NAME)) Is Nothing Then
                            txtAssrCtLgCutType.Text = pclaRow.Value(pclaRow.Fields.FindField(PARCUTLGASR_CUT_TYPE_FLD_NAME))
                        End If
                    End If

                    'subdiv from map num and type
                    Dim pclsdaCur As ICursor
                    Dim pclsdaRow As IRow
                    Dim psubQueryfilter As IQueryFilter
                    'ctlg (subdiv log)
                    Dim pclsdCur As ICursor
                    Dim pclsdRow As IRow
                    Dim psublQueryfilter As IQueryFilter
                    psubQueryfilter = New QueryFilter
                    psubQueryfilter.WhereClause = "MAPTYPE = '" & cboCtLgMapType.Text & "' AND MAPNUM = '" & txtCtLgMapNum.Text & "'"
                    pclsdaCur = m_pCLSubTable.Search(psubQueryfilter, False) 'changed this one
                    pclsdaRow = pclsdaCur.NextRow
                    If Not pclsdaRow Is Nothing Then
                        psublQueryfilter = New QueryFilter
                        psublQueryfilter.WhereClause = "Subdivid = " & pclsdaRow.Value(pclsdaRow.Fields.FindField(SUBDIV_ATR_SUBDIVID_FLD_NAME))
                        'MsgBox("subdivid = " & pclsdaRow.Value(pclsdaRow.Fields.FindField(SUBDIV_ATR_SUBDIVID_FLD_NAME)))
                        pclsdCur = m_pCLSubLTable.Search(psublQueryfilter, False) 'changed this one
                        pclsdRow = pclsdCur.NextRow

                        If Not pclsdRow Is Nothing Then
                            If Not IsDBNull(pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_COMPDATE_NAME))) And Not pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_COMPDATE_NAME)) Is Nothing Then
                                txtSbCtLgCompDate.Text = pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_COMPDATE_NAME))
                            End If
                            If Not IsDBNull(pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_COMP_BY_FLD_NAME))) And Not pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_COMP_BY_FLD_NAME)) Is Nothing Then
                                txtSbCtLgCompBy.Text = pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_COMP_BY_FLD_NAME))
                            End If
                            If Not IsDBNull(pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_ASGNDATE_FLD_NAME))) And Not pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_ASGNDATE_FLD_NAME)) Is Nothing Then
                                txtSbCtLgAssignDate.Text = pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_ASGNDATE_FLD_NAME))
                            End If
                            If Not IsDBNull(pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_ASGNTO_FLD_NAME))) And Not pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_ASGNTO_FLD_NAME)) Is Nothing Then
                                txtSbCtLgAssignTo.Text = pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_ASGNTO_FLD_NAME))
                            End If
                            If Not IsDBNull(pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_COMMENTS_NAME))) And Not pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_COMMENTS_NAME)) Is Nothing Then
                                txtSbCtLgComments.Text = pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_COMMENTS_NAME))
                            End If
                            If Not IsDBNull(pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_NAD83_FLD_NAME))) And Not pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_NAD83_FLD_NAME)) Is Nothing Then
                                txtSbCtLgNAD83.Text = pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_NAD83_FLD_NAME))
                            End If
                            If Not IsDBNull(pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_HAVEDXF_FLD_NAME))) And Not pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_HAVEDXF_FLD_NAME)) Is Nothing Then
                                txtSbCtLgHaveDXF.Text = pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_HAVEDXF_FLD_NAME))
                            End If
                            If Not IsDBNull(pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_GETDXF_FLD_NAME))) And Not pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_GETDXF_FLD_NAME)) Is Nothing Then
                                txtSbCtLgGetDXF.Text = pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_GETDXF_FLD_NAME))
                            End If
                            If Not IsDBNull(pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_MAPAREA_FLD_NAME))) And Not pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_MAPAREA_FLD_NAME)) Is Nothing Then
                                txtSbCtLgArea.Text = pclsdRow.Value(pclsdRow.Fields.FindField(SUBDIV_LOG_MAPAREA_FLD_NAME))
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub cboCtLgJur_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCtLgJur.KeyPress
        If e.KeyChar = vbTab Then
            dtCtLgReceived.Focus()
        End If
    End Sub

#End Region

#Region "Check boxes, date pickers and Data grids"

    Private Sub ckbxCtLgSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbxCtLgSearch.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Try
                If Not ckbxCtLgSearch.Checked Then
                    cboCtLgSelectName.Items.Clear()
                    cboCtLgSelectName.SelectedText = ""
                    cboCtLgSelectName.Text = ""
                    cboCtLgSelectName.Enabled = False
                    ckbxCtLgSearch.Text = "Check to Search/Edit Existing Cut Log"
                    btnCtLgSave.Text = "Add Cut Log"
                    'clear out the form fields
                    ClearFormFields(True, True, True)
                    cboCtLgJur.Focus()
                Else
                    cboCtLgSelectName.Enabled = True
                    ckbxCtLgSearch.Text = "UN-Check to ADD NEW Cut Log"
                    btnCtLgSave.Text = "Save Updates"
                    'Fill it
                    Dim pCur As ICursor, pRow As IRow, lIdx As Long
                    lIdx = m_pCLTable.Fields.FindField(PARCUTLG_CUT_YEAR_NUM_FLD_NAME)
                    ''add a queryfilter and queryfilterdefinition for sorting
                    Dim pQF As IQueryFilter
                    pQF = New QueryFilter
                    Dim pQFDef As IQueryFilterDefinition
                    pQFDef = pQF
                    pQFDef.PostfixClause = "order by CUT_YEAR desc,CUT_NUM desc"
                    pCur = m_pCLTable.Search(pQF, False) 'changed this one
                    pRow = pCur.NextRow
                    'Build the combobox
                    cboCtLgSelectName.Items.Add("CUT YEAR and NUMBER")
                    Do While Not pRow Is Nothing
                        If Not pRow.Value(lIdx) Is System.DBNull.Value Then
                            cboCtLgSelectName.Items.Add(pRow.Value(lIdx))
                        End If
                        pRow = pCur.NextRow
                    Loop
                    'display the 1st item
                    If cboCtLgSelectName.Items.Count > 0 Then cboCtLgSelectName.SelectedIndex = 0
                    Cursor.Current = Windows.Forms.Cursors.Default
                    cboCtLgSelectName.Focus()
                End If
            Catch ex As Exception
                Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub dtCtLgReceived_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtCtLgReceived.KeyPress
        If e.KeyChar = vbTab Then
            txtCtLgAssignedTo.Focus()
        End If
    End Sub

    Private Sub dtCtLgAssignedDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtCtLgAssignedDate.KeyPress
        If e.KeyChar = vbTab Then
            txtCtLgCompBy.Focus()
        End If
    End Sub

    Private Sub dtCtLgCompDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtCtLgCompDate.KeyPress
        If e.KeyChar = vbTab Then
            cboCtLgCondoOnly.Focus()
        End If
    End Sub

#End Region

#Region "Buttons"

    Private Sub btnCtLgExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtLgExit.Click
        Try
            If m_pWSE.IsBeingEdited Then
                m_pWSE.StopEditOperation()
                m_pWSE.StopEditing(True)
            End If
            Me.Close()
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnCtLgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtLgSave.Click
        Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Try
            'first check field values
            Dim flderrmsg As String
            Dim flderr As Boolean
            flderr = False
            flderrmsg = ""
            If txtCtLgCutYear.Text = "" Or IsDBNull(txtCtLgCutYear.Text) Then
                flderr = True
                flderrmsg = flderrmsg & "Cut Year can not be blank" & vbNewLine
            End If
            If txtCtLgCutNum.Text = "" Or IsDBNull(txtCtLgCutNum.Text) Then
                flderr = True
                flderrmsg = flderrmsg & "Cut Num can not be blank" & vbNewLine
            End If
            If txtCtLgCutYear.Text < 1900 Or txtCtLgCutYear.Text > 2100 Then
                flderr = True
                flderrmsg = flderrmsg & "Cut Year is not a valid year between 1900 and 2100" & vbNewLine
            End If
            If flderr Then
                Cursor.Current = Windows.Forms.Cursors.Default
                flderrmsg = flderrmsg & "Please modify the entries and try to save again"
                MsgBox(flderrmsg, MsgBoxStyle.Critical, "EDITS NOT SAVED")
                Exit Sub
            End If

            Dim psvcRow As IRow

            If ckbxCtLgSearch.Checked Then
                Dim psvcQF As IQueryFilter
                Dim psvcSDID As Integer
                psvcSDID = cboCtLgSelectName.Text
                psvcQF = New QueryFilter
                psvcQF.WhereClause = "CUT_YEAR_NUM = " & psvcSDID
                'Cut Log
                Dim psvcCur As ICursor
                psvcCur = m_pCLTable.Search(psvcQF, False) 'changed this one
                psvcRow = psvcCur.NextRow
            Else
                psvcRow = m_pCLTable.CreateRow 'cut log
            End If

            'Subdiv ATR
            If Not psvcRow Is Nothing Then
                If Not IsDBNull(txtCtLgCutYear.Text) And Not txtCtLgCutYear.Text Is Nothing Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_CUT_YEAR_FLD_NAME)) = txtCtLgCutYear.Text
                End If
                If Not IsDBNull(txtCtLgCutNum.Text) And Not txtCtLgCutNum.Text Is Nothing Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_CUT_NUM_FLD_NAME)) = txtCtLgCutNum.Text
                End If
                If Not IsDBNull(cboCtLgCondoOnly.Text) And Not cboCtLgCondoOnly.Text Is Nothing Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_CONDO_ONLY_FLD_NAME)) = cboCtLgCondoOnly.Text
                End If
                If Not IsDBNull(cboCtLgStreetDed.Text) And Not cboCtLgStreetDed.Text Is Nothing Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_STREET_DEDICATION_FLD_NAME)) = cboCtLgStreetDed.Text
                End If
                If Not IsDBNull(cboCtLgStreetVac.Text) And Not cboCtLgStreetVac.Text Is Nothing Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_STREET_VACATION_FLD_NAME)) = cboCtLgStreetVac.Text
                End If
                If Not IsDBNull(cboCtLgOpenSpace.Text) And Not cboCtLgOpenSpace.Text Is Nothing Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_OPEN_SPACE_FLD_NAME)) = cboCtLgOpenSpace.Text
                End If
                If Not IsDBNull(cboCtLgLandReq.Text) And Not cboCtLgLandReq.Text Is Nothing Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_LAND_REQ_FLD_NAME)) = cboCtLgLandReq.Text
                End If
                If Not IsDBNull(dtCtLgAssignedDate.Text) And Not dtCtLgAssignedDate.Text Is Nothing And dtCtLgAssignedDate.Checked Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_ASSIGNED_DATE_FLD_NAME)) = dtCtLgAssignedDate.Text
                End If
                If Not IsDBNull(dtCtLgCompDate.Text) And Not dtCtLgCompDate.Text Is Nothing And dtCtLgCompDate.Checked Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_COMP_DATE_FLD_NAME)) = dtCtLgCompDate.Text
                End If
                If Not IsDBNull(dtCtLgReceived.Text) And Not dtCtLgReceived.Text Is Nothing And dtCtLgReceived.Checked Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_RECEIVED_FLD_NAME)) = dtCtLgReceived.Text
                End If
                If Not IsDBNull(cboCtLgJur.Text) And Not cboCtLgJur.Text Is Nothing Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_JUR_FLD_NAME)) = cboCtLgJur.Text
                End If
                If Not IsDBNull(txtCtLgAssignedTo.Text) And Not txtCtLgAssignedTo.Text Is Nothing Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_ASSIGNED_TO_FLD_NAME)) = txtCtLgAssignedTo.Text
                End If
                If Not IsDBNull(txtCtLgCompBy.Text) And Not txtCtLgCompBy.Text Is Nothing Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_COMP_BY_FLD_NAME)) = txtCtLgCompBy.Text
                End If
                If Not IsDBNull(txtCtLgArea.Text) And Not txtCtLgArea.Text Is Nothing Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_AREA_FLD_NAME)) = txtCtLgArea.Text
                End If
                If Not IsDBNull(txtCtLgRemarks.Text) And Not txtCtLgRemarks.Text Is Nothing Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_REMARKS_FLD_NAME)) = txtCtLgRemarks.Text
                End If
                If Not IsDBNull(cboCtLgMapType.Text) And Not cboCtLgMapType.Text Is Nothing Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_MAP_TYPE_FLD_NAME)) = cboCtLgMapType.Text
                End If
                If Not IsDBNull(txtCtLgMapNum.Text) And Not txtCtLgMapNum.Text Is Nothing Then
                    psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_MAP_NUM_FLD_NAME)) = txtCtLgMapNum.Text
                End If
                txtCtLgPostID.Text = UCase(Environment.UserName)
                psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_POSTID_FLD_NAME)) = txtCtLgPostID.Text
                txtCtLgPostDate.Text = Now
                psvcRow.Value(psvcRow.Fields.FindField(PARCUTLG_POSTDATE_FLD_NAME)) = txtCtLgPostDate.Text
                Dim ctyrnum As Integer
                ctyrnum = txtCtLgCutYear.Text & txtCtLgCutNum.Text
                psvcRow.Value(psvcRow.Fields.FindField(PARCUTLGASR_CUT_YEAR_NUM_FLD_NAME)) = ctyrnum

                psvcRow.Store()

                'Detail
                m_WrapperCaller = "FrmEditCutLog"
                If m_pEdtCells.Count > 0 Then
                    Dim pedtrow As IRow
                    Dim edtcnt As Integer
                    For edtcnt = 1 To m_pEdtCells.Count
                        pedtrow = tableWrapper.Item(m_pEdtCells.Item(edtcnt))
                        pedtrow.Store()
                    Next
                    pedtrow = Nothing
                End If

            End If

            If ckbxCtLgSearch.Checked Then
                MsgBox("Updated: " & txtCtLgCutYear.Text & " / " & txtCtLgCutNum.Text)
            Else
                MsgBox("Added: " & txtCtLgCutYear.Text & " / " & txtCtLgCutNum.Text)
                btnCtLgReset.PerformClick()
                psvcRow = Nothing
            End If
            btnCtLgReset.PerformClick()

        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnCtLgReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtLgReset.Click
        Try
            ClearFormFields(True, True, True)
            ckbxCtLgSearch.Checked = False
            txtCtLgCutYear.Focus()
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Text boxes"

    Private Sub txtCtLgCutYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCtLgCutYear.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtCtLgCutYear.Text) And Not txtCtLgCutYear.Text = "" Then
                MsgBox("Cut Year must be numeric")
                Exit Sub
            End If
            txtCtLgCutNum.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtCtLgCutNum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCtLgCutNum.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtCtLgCutNum.Text) And Not txtCtLgCutNum.Text = "" Then
                MsgBox("Cut Num must be numeric")
                Exit Sub
            End If
            txtCtLgArea.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtCtLgArea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCtLgArea.KeyPress
        If e.KeyChar = vbTab Then
            cboCtLgJur.Focus()
        End If
    End Sub

    Private Sub txtCtLgAssignedTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCtLgAssignedTo.KeyPress
        If e.KeyChar = vbTab Then
            dtCtLgAssignedDate.Focus()
        End If
    End Sub

    Private Sub txtCtLgCompBy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCtLgCompBy.KeyPress
        If e.KeyChar = vbTab Then
            dtCtLgCompDate.Focus()
        End If
    End Sub


#End Region


 
    Private Sub cboCtLgCondoOnly_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCtLgCondoOnly.KeyPress
        If e.KeyChar = vbTab Then
            cboCtLgStreetDed.Focus()
        End If
    End Sub

    Private Sub cboCtLgStreetDed_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCtLgStreetDed.KeyPress
        If e.KeyChar = vbTab Then
            cboCtLgStreetVac.Focus()
        End If
    End Sub

    Private Sub cboCtLgStreetVac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCtLgStreetVac.KeyPress
        If e.KeyChar = vbTab Then
            cboCtLgOpenSpace.Focus()
        End If
    End Sub

    Private Sub cboCtLgOpenSpace_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCtLgOpenSpace.KeyPress
        If e.KeyChar = vbTab Then
            cboCtLgLandReq.Focus()
        End If
    End Sub

    Private Sub cboCtLgLandReq_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCtLgLandReq.KeyPress
        If e.KeyChar = vbTab Then
            cboCtLgMapType.Focus()
        End If
    End Sub

    Private Sub cboCtLgMapType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCtLgMapType.KeyPress
        If e.KeyChar = vbTab Then
            txtCtLgMapNum.Focus()
        End If
    End Sub

    Private Sub txtCtLgMapNum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCtLgMapNum.KeyPress
        If e.KeyChar = vbTab Then
            txtCtLgRemarks.Focus()
        End If
    End Sub

    Private Sub txtCtLgRemarks_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCtLgRemarks.KeyPress
        If e.KeyChar = vbTab Then
            btnCtLgSave.Focus()
        End If
    End Sub

    Private Sub btnCtLgSave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnCtLgSave.KeyPress
        If e.KeyChar = vbTab Then
            btnCtLgReset.Focus()
        End If
    End Sub

    Private Sub btnCtLgReset_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnCtLgReset.KeyPress
        If e.KeyChar = vbTab Then
            btnCtLgExit.Focus()
        End If
    End Sub

    Private Sub btnCtLgExit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnCtLgExit.KeyPress
        If e.KeyChar = vbTab Then
            cboCtLgSelectName.Focus()
        End If
    End Sub

    Private Sub txtCtLgCutNum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCtLgCutNum.TextChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Try

                m_CTNM = txtCtLgCutNum.Text
                m_CTYRNM = txtCtLgCutYear.Text & txtCtLgCutNum.Text
                If txtCtLgCutNum.Text = "" Or IsDBNull(txtCtLgCutNum.Text) Or txtCtLgCutYear.Text = "" Or IsDBNull(txtCtLgCutYear.Text) Then
                    DataGridView1.Enabled = False
                    DataGridView1.DataSource = Nothing
                    m_pEdtCells.Clear()
                ElseIf txtCtLgCutYear.Text < 1900 Or txtCtLgCutYear.Text > 2100 Then
                    DataGridView1.Enabled = False
                    DataGridView1.DataSource = Nothing
                    m_pEdtCells.Clear()
                Else
                    m_pEdtCells.Clear()
                    DataGridView1.Enabled = True
                    m_TWWhereClause = "CUT_YEAR_NUM = " & m_CTYRNM
                    m_TWPostfixClause = ""
                    FillGridData()
                End If
            Catch ex As Exception
                Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub txtCtLgCutYear_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCtLgCutYear.TextChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Try
                m_CTYR = txtCtLgCutYear.Text
                m_CTYRNM = txtCtLgCutYear.Text & txtCtLgCutNum.Text
                If txtCtLgCutNum.Text = "" Or IsDBNull(txtCtLgCutNum.Text) Or txtCtLgCutYear.Text = "" Or IsDBNull(txtCtLgCutYear.Text) Then
                    DataGridView1.Enabled = False
                    DataGridView1.DataSource = Nothing
                    m_pEdtCells.Clear()
                ElseIf txtCtLgCutYear.Text < 1900 Or txtCtLgCutYear.Text > 2100 Then
                    DataGridView1.Enabled = False
                    DataGridView1.DataSource = Nothing
                    m_pEdtCells.Clear()
                Else
                    m_pEdtCells.Clear()
                    DataGridView1.Enabled = True
                    m_TWWhereClause = "CUT_YEAR_NUM = " & m_CTYRNM
                    m_TWPostfixClause = ""
                    FillGridData()
                End If
            Catch ex As Exception
                Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Try
            m_pEdtCells.Add(DataGridView1.CurrentRow.Index)
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

End Class