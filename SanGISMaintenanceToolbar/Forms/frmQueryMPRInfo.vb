Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.esriSystem
Public Class frmQueryMPRInfo

    Dim m_pWKSP As IWorkspace
    Dim m_ActiveView As IActiveView
    Dim m_pMPROrg As ITable
    Dim m_pMPROwn As ITable
    Dim m_pAPNParView As ITable
    Dim m_pWSE As IWorkspaceEdit
    Private tableWrapper As ArcDataBinding.TableWrapper
    Private IsInitializing As Boolean

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

#Region "Primaries Form"

    Private Sub QueryMPRInfo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        m_ActiveView = Nothing
        m_pMPROrg = Nothing
        m_pMPROwn = Nothing
        m_pWKSP = Nothing
        m_pWSE = Nothing
    End Sub

    Private Sub QueryMPRInfo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F1 Then
            tbMPRForm.SelectedTab = TabPage1
            btnReset.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.F6 Then
            btnDetails.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.F5 Then
            tbMPRForm.SelectedTab = TabPage1
        ElseIf e.KeyCode = Windows.Forms.Keys.F8 Then
            tbMPRForm.SelectedTab = TabPage1
            chkQFs()
        ElseIf e.KeyCode = Windows.Forms.Keys.F12 Then
            tbMPRForm.SelectedTab = TabPage1
            btnExit.PerformClick()
        End If
    End Sub

    Private Sub QueryMPRInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Dim pTableSourcename As String
            pTableSourcename = MPR_ORG_DATASRC
            m_pMPROrg = GetWorkspaceTable("ANY", FrmMap, pTableSourcename, True)
            If m_pMPROrg Is Nothing Then
                Me.Close()
                Exit Sub
            End If
            Dim pTableSourcename2 As String
            pTableSourcename2 = MPR_OWNER_DATASRC
            m_pMPROwn = GetWorkspaceTable("ANY", FrmMap, pTableSourcename2, True)
            If m_pMPROwn Is Nothing Then
                Me.Close()
                Exit Sub
            End If

            'Pop the ComboBox
            cboSearchType.Items.Add("Browse Assessor Parcels")
            cboSearchType.Items.Add("Browse Assessor MPR Addresses")
            cboSearchType.Items.Add("Browse Assessor MPR Owner Names")
            cboSearchType.SelectedIndex = 0

            'if parcel layer in map then activate the 'select in map' button
            If CheckForLayer(PARCEL_DATASRC, m_ActiveView) Then
                btnMPRFindFtr.Enabled = True
                'get the apn view to get the parcel to select it in the map
                Dim pAPNTableSourcename As String
                pAPNTableSourcename = V_APNPARCEL_DATASRC
                m_pAPNParView = GetWorkspaceTable("ANY", FrmMap, pAPNTableSourcename, True)
                If m_pAPNParView Is Nothing Then
                    btnMPRFindFtr.Enabled = False
                End If
            Else
                btnMPRFindFtr.Enabled = False
            End If

        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Custom"

    Private Sub chkQFs()
        dgMPRParcelList.DataSource = Nothing
        If txtAPNQF.Text <> "" Or txtSearch2QF.Text <> "" Then
            Dim pAPNsrch As String
            Dim pScndsrch As String
            pAPNsrch = txtAPNQF.Text
            pScndsrch = txtSearch2QF.Text
            PopGridList(pAPNsrch, pScndsrch)
        Else
            MsgBox("No Search Criteria Entered")
            Exit Sub
        End If
    End Sub

    Private Sub PopGridList(ByVal pAPN As String, ByVal pPAR As String)
        Try
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Dim pAPNQF As IQueryFilter
            Dim pAPNID As String
            Dim pScndID As String
            pAPNID = txtAPNQF.Text
            pScndID = txtSearch2QF.Text
            pAPNQF = New QueryFilter
            'If cboSearchType.SelectedIndex = 0 Then
            '    m_WrapperCaller = "MPRInfo_Parcel"
            'ElseIf cboSearchType.SelectedIndex = 1 Then
            '    m_WrapperCaller = "MPRInfo_Address"
            'ElseIf cboSearchType.SelectedIndex = 2 Then
            '    m_WrapperCaller = "MPRInfo_Owner"
            'Else
            '    MsgBox("Select a Search Type from the List")
            '    Exit Sub
            'End If
            If pAPNID <> "" And pScndID = "" Then
                m_TWWhereClause = "APN LIKE '" & pAPNID & "'"
                pAPNQF.WhereClause = m_TWWhereClause
                m_TWPostfixClause = "Order By APN"
            ElseIf pAPNID = "" And pScndID <> "" Then
                If cboSearchType.SelectedIndex = 0 Then
                    m_TWWhereClause = "MAP_NUMBER LIKE '" & pScndID & "'"
                    pAPNQF.WhereClause = m_TWWhereClause
                    m_TWPostfixClause = "Order By MAP_NUMBER,APN"
                ElseIf cboSearchType.SelectedIndex = 1 Then
                    m_TWWhereClause = "NUCLEUS_SITUS_ST_NAME LIKE '" & pScndID & "'"
                    pAPNQF.WhereClause = m_TWWhereClause
                    m_TWPostfixClause = "Order By SITUS_STREET,APN"
                ElseIf cboSearchType.SelectedIndex = 2 Then
                    m_TWWhereClause = "NAME1 LIKE '" & pScndID & "' or NAME2 LIKE '" & pScndID & "' or NAME3 LIKE '" & pScndID & "'"
                    pAPNQF.WhereClause = m_TWWhereClause
                    m_TWPostfixClause = "Order By NAME1,APN"
                Else
                    MsgBox("Select a Search Type from the List")
                    Exit Sub
                End If
            Else
                MsgBox("No Search Criteria Entered.")
                Cursor.Current = Windows.Forms.Cursors.Default
                Exit Sub
            End If
            'check if any selected
            Dim pRwCnt As Integer
            If cboSearchType.SelectedIndex < 2 Then
                pRwCnt = m_pMPROrg.RowCount(pAPNQF)
            ElseIf cboSearchType.SelectedIndex = 2 Then
                pRwCnt = m_pMPROwn.RowCount(pAPNQF)
            End If
            lblNumRecFound.Text = pRwCnt
            If pRwCnt > 0 And pRwCnt < 1001 Then
                'm_APNID = pAPNID
                'm_PARID = pPARID
                FillGridData()
            ElseIf pRwCnt > 1000 Then
                Dim prowlots As MsgBoxResult
                prowlots = MsgBox(pRwCnt & " Records found, press OK to continue, CANCEL to start new search", MsgBoxStyle.OkCancel, "Thats a Lot of Records!")
                If prowlots = MsgBoxResult.Ok Then
                    'm_APNID = pAPNID
                    'm_PARID = pPARID
                    FillGridData()
                End If
            Else
                MsgBox("No records found matching search criteria", MsgBoxStyle.Information)
            End If
            Cursor.Current = Windows.Forms.Cursors.Default
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try

    End Sub

    Private Sub FillGridData()
        'Fill the datagrid
        Try
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            If cboSearchType.SelectedIndex < 2 Then
                tableWrapper = New ArcDataBinding.TableWrapper(m_pMPROrg)
            ElseIf cboSearchType.SelectedIndex = 2 Then
                tableWrapper = New ArcDataBinding.TableWrapper(m_pMPROwn)
            End If
            dgMPRParcelList.DataSource = tableWrapper
            With dgMPRParcelList
                .Columns("APN").DisplayIndex = 0
                .Columns("APN").Width = 90
                .Columns("APN").DefaultCellStyle.ForeColor = Drawing.Color.Blue
                If cboSearchType.SelectedIndex = 0 Then
                    .Columns("TAX_RATE_AREA").DisplayIndex = 1
                    .Columns("TAX_RATE_AREA").Width = 45
                    .Columns("TAX_RATE_AREA").HeaderText = "TRA"
                    .Columns("MAP_NUMBER").DisplayIndex = 2
                    .Columns("MAP_NUMBER").Width = 70
                    .Columns("MAP_NUMBER").HeaderText = "Map Number"
                    .Columns("MAP_NUMBER").DefaultCellStyle.ForeColor = Drawing.Color.Green
                    .Columns("PROP_DESCR_CODE").DisplayIndex = 3
                    .Columns("PROP_DESCR_CODE").Width = 30
                    .Columns("PROP_DESCR_CODE").HeaderText = ""
                    .Columns("PROP_DESCR_CHAR").DisplayIndex = 4
                    .Columns("PROP_DESCR_CHAR").Width = 365
                    .Columns("PROP_DESCR_CHAR").HeaderText = "Property Description"
                    .Columns("TAX_STATUS").DisplayIndex = 5
                    .Columns("TAX_STATUS").Width = 80
                    .Columns("TAX_STATUS").HeaderText = "T/N"
                    Cursor.Current = Windows.Forms.Cursors.Default
                ElseIf cboSearchType.SelectedIndex = 1 Then
                    .Columns("TAX_RATE_AREA").DisplayIndex = 1
                    .Columns("TAX_RATE_AREA").Width = 45
                    .Columns("TAX_RATE_AREA").HeaderText = "TRA"
                    .Columns("NUCLEUS_SITUS_ST_NBR").DisplayIndex = 2
                    .Columns("NUCLEUS_SITUS_ST_NBR").Width = 65
                    .Columns("NUCLEUS_SITUS_ST_NBR").HeaderText = "Number"
                    .Columns("NUCLEUS_SITUS_FRACTION").DisplayIndex = 3
                    .Columns("NUCLEUS_SITUS_FRACTION").Width = 40
                    .Columns("NUCLEUS_SITUS_FRACTION").HeaderText = "Suite"
                    .Columns("NUCLEUS_SITUS_PRFX_DIR").DisplayIndex = 4
                    .Columns("NUCLEUS_SITUS_PRFX_DIR").Width = 40
                    .Columns("NUCLEUS_SITUS_PRFX_DIR").HeaderText = "Pre Dir"
                    .Columns("NUCLEUS_SITUS_ST_Name").DisplayIndex = 5
                    .Columns("NUCLEUS_SITUS_ST_Name").Width = 270
                    .Columns("NUCLEUS_SITUS_ST_Name").HeaderText = "Road Name"
                    .Columns("NUCLEUS_SITUS_ST_Name").DefaultCellStyle.ForeColor = Drawing.Color.Green
                    .Columns("NUCLEUS_SITUS_ST_TYPE").DisplayIndex = 6
                    .Columns("NUCLEUS_SITUS_ST_TYPE").Width = 50
                    .Columns("NUCLEUS_SITUS_ST_TYPE").HeaderText = "Sfx"
                    .Columns("NUCLEUS_SITUS_SFFX_DIR").DisplayIndex = 7
                    .Columns("NUCLEUS_SITUS_SFFX_DIR").Width = 40
                    .Columns("NUCLEUS_SITUS_SFFX_DIR").HeaderText = "Post Dir"
                    Cursor.Current = Windows.Forms.Cursors.Default
                ElseIf cboSearchType.SelectedIndex = 2 Then
                    .Columns("TRANUM").DisplayIndex = 1
                    .Columns("TRANUM").Width = 55
                    .Columns("TRANUM").HeaderText = "TRA"
                    .Columns("NAME1").DisplayIndex = 2
                    .Columns("NAME1").Width = 190
                    .Columns("NAME1").HeaderText = "NAME1"
                    .Columns("NAME1").DefaultCellStyle.ForeColor = Drawing.Color.Green
                    .Columns("NAME2").DisplayIndex = 3
                    .Columns("NAME2").Width = 170
                    .Columns("NAME2").HeaderText = "NAME2"
                    .Columns("NAME2").DefaultCellStyle.ForeColor = Drawing.Color.Green
                    .Columns("NAME3").DisplayIndex = 4
                    .Columns("NAME3").Width = 200
                    .Columns("NAME3").HeaderText = "NAME3"
                    .Columns("NAME3").DefaultCellStyle.ForeColor = Drawing.Color.Green
                    Cursor.Current = Windows.Forms.Cursors.Default
                End If
            End With
            dgMPRParcelList.Focus()
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Sub ClearDetailFields()
        'Key fields
        txtDtlAPN.Text = ""
        txtDtlTra.Text = ""
        txtDtlDoc1.Text = ""
        txtDtlDoc2.Text = ""
        txtDtlDoc3.Text = ""
        txtDtlAssyear.Text = ""
        txtDtlTaxstatus.Text = ""
        txtDtlTransDate.Text = ""
        txtDtlMartStatus.Text = ""
        txtDtlOwnStatus.Text = ""
        txtDtlMailAdr.Text = ""
        txtDtlMailZip.Text = ""
        txtDtlLand.Text = ""
        txtDtlImps.Text = ""
        txtDtlPpy.Text = ""
        txtDtlNet.Text = ""
        txtExpCd1.Text = ""
        txtExpCd2.Text = ""
        txtExpCd3.Text = ""
        txtExmp1.Text = ""
        txtExmp2.Text = ""
        txtExmp3.Text = ""
        txtSldCode.Text = ""
        txtSldYear.Text = ""
        txtApplsYear.Text = ""
        txtDtlMPRZn.Text = ""
        txtDtlMPRCd.Text = ""
        txtDtlNucZn.Text = ""
        txtDtlNucCd.Text = ""
        txtDtlMailFlag.Text = ""
        txtDtlAddr.Text = ""
        txtDtlFrac.Text = ""
        txtDtlUnit.Text = ""
        txtDtlPreDir.Text = ""
        txtDtlRdNam.Text = ""
        txtDtlSfx.Text = ""
        txtDtlPstDir.Text = ""
        txtDtlSitComm.Text = ""
        txtDtlSiteState.Text = ""
        txtDtlSitezip.Text = ""
        txtDtlMapNum.Text = ""
        txtDtlAcreage.Text = ""
        txtDtlNumUnits.Text = ""
        txtDtlPropDescCd.Text = ""
        txtDtlPropDesc.Text = ""
        txtDtlRgCutNo.Text = ""
        txtDtlRegCutDate.Text = ""
        txtDtlPreParCutNo.Text = ""
        txtDtlPrParCutDate.Text = ""
        txtDtlTraCutNo.Text = ""
        txtDtlTraCutDate.Text = ""
        txtDtlPriorPar1.Text = ""
        txtDtlPriorPar2.Text = ""
        txtDtlPriorPar3.Text = ""
        txtDtlPriorPar4.Text = ""
        txtDtlPriorTRA.Text = ""
        txtDtlParentPar.Text = ""
    End Sub

#End Region

#Region "Text boxes"

    Private Sub txtAPNQF_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAPNQF.GotFocus
        txtSearch2QF.Text = ""
    End Sub

    Private Sub txtMapNumQF_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch2QF.GotFocus
        txtAPNQF.Text = ""
    End Sub

    Private Sub txtAPNQF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAPNQF.KeyPress
        If e.KeyChar = vbTab Then
            txtSearch2QF.Focus()
        End If
        If e.KeyChar = ChrW(Windows.Forms.Keys.Return) Then
            If txtAPNQF.Text = "" Then
                MsgBox("Enter Text for APN search criteria")
                Exit Sub
            Else
                chkQFs()
            End If
        End If
    End Sub

    Private Sub txtMapNumQF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch2QF.KeyPress
        If e.KeyChar = vbTab Then
            txtAPNQF.Focus()
        End If
        If e.KeyChar = ChrW(Windows.Forms.Keys.Return) Then
            If txtSearch2QF.Text = "" Then
                MsgBox("Enter Text for the Second Search criteria")
                Exit Sub
            Else
                chkQFs()
            End If
        End If
    End Sub

#End Region

#Region "Buttons"

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearDetailFields()
        txtAPNQF.Text = ""
        txtSearch2QF.Text = ""
        lblNumRecFound.Text = ""
        dgMPRParcelList.DataSource = Nothing
    End Sub

    Private Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        Try
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            If dgMPRParcelList.SelectedRows.Count > 0 Then
                Dim pMPRAPNID As String
                pMPRAPNID = dgMPRParcelList.CurrentRow.Cells.Item(dgMPRParcelList.Columns("APN").Index).Value
                'Fill The Details
                ClearDetailFields()
                Dim pDtlQueryfilter As IQueryFilter
                Dim pDtlCur As ICursor
                Dim pDtlRow As IRow
                If pMPRAPNID = "" Then
                    MsgBox("NO APN found.  Choose a different Record")
                    Exit Sub
                End If
                pDtlQueryfilter = New QueryFilter
                pDtlQueryfilter.WhereClause = "APN = " & pMPRAPNID
                pDtlCur = m_pMPROrg.Search(pDtlQueryfilter, False) 'changed this one
                pDtlRow = pDtlCur.NextRow
                If Not pDtlRow Is Nothing Then
                    'Key fields
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_APN_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_APN_FLD_NAME)) Is Nothing Then
                        txtDtlAPN.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_APN_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_TRA_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_TRA_FLD_NAME)) Is Nothing Then
                        txtDtlTra.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_TRA_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_DOCTYPE_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_DOCTYPE_FLD_NAME)) Is Nothing Then
                        txtDtlDoc1.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_DOCTYPE_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_DOCDATE_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_DOCDATE_FLD_NAME)) Is Nothing Then
                        Dim pDocDate As String
                        pDocDate = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_DOCDATE_FLD_NAME))
                        pDocDate = pDocDate.Insert(4, "/")
                        pDocDate = pDocDate.Insert(2, "/")
                        txtDtlDoc2.Text = pDocDate
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_DOCNO_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_DOCNO_FLD_NAME)) Is Nothing Then
                        txtDtlDoc3.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_DOCNO_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_ASSYR_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_ASSYR_FLD_NAME)) Is Nothing Then
                        txtDtlAssyear.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_ASSYR_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_TXSTATUS_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_TXSTATUS_FLD_NAME)) Is Nothing Then
                        txtDtlTaxstatus.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_TXSTATUS_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_TRANSDATE_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_TRANSDATE_FLD_NAME)) Is Nothing Then
                        Dim pTrDate As String
                        pTrDate = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_TRANSDATE_FLD_NAME))
                        pTrDate = pTrDate.Insert(4, "/")
                        pTrDate = pTrDate.Insert(2, "/")
                        txtDtlTransDate.Text = pTrDate
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MARTSTATUS_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MARTSTATUS_FLD_NAME)) Is Nothing Then
                        txtDtlMartStatus.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MARTSTATUS_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_OWNSTATUS_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_OWNSTATUS_FLD_NAME)) Is Nothing Then
                        txtDtlOwnStatus.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_OWNSTATUS_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_OWNNAME_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_OWNNAME_FLD_NAME)) Is Nothing Then
                        txtDtlOwner.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_OWNNAME_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MAILADDR_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MAILADDR_FLD_NAME)) Is Nothing Then
                        txtDtlMailAdr.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MAILADDR_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_ZIP_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_ZIP_FLD_NAME)) Is Nothing Then
                        txtDtlMailZip.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_ZIP_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_LANDV_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_LANDV_FLD_NAME)) Is Nothing Then
                        txtDtlLand.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_LANDV_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_IMPSV_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_IMPSV_FLD_NAME)) Is Nothing Then
                        txtDtlImps.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_IMPSV_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PPYV_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PPYV_FLD_NAME)) Is Nothing Then
                        txtDtlPpy.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PPYV_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_NETV_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_NETV_FLD_NAME)) Is Nothing Then
                        txtDtlNet.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_NETV_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPCD1_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPCD1_FLD_NAME)) Is Nothing Then
                        txtExpCd1.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPCD1_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPCD2_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPCD2_FLD_NAME)) Is Nothing Then
                        txtExpCd2.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPCD2_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPCD3_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPCD3_FLD_NAME)) Is Nothing Then
                        txtExpCd3.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPCD3_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPV1_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPV1_FLD_NAME)) Is Nothing Then
                        txtExmp1.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPV1_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPV2_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPV2_FLD_NAME)) Is Nothing Then
                        txtExmp2.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPV2_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPV3_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPV3_FLD_NAME)) Is Nothing Then
                        txtExmp3.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_EXMPV3_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_SLDREDCD_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_SLDREDCD_FLD_NAME)) Is Nothing Then
                        txtSldCode.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_SLDREDCD_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_SLDREDYR_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_SLDREDYR_FLD_NAME)) Is Nothing Then
                        txtSldYear.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_SLDREDYR_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_APPLSYR_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_APPLSYR_FLD_NAME)) Is Nothing Then
                        txtApplsYear.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_APPLSYR_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MPRZN_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MPRZN_FLD_NAME)) Is Nothing Then
                        txtDtlMPRZn.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MPRZN_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MPRCD_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MPRCD_FLD_NAME)) Is Nothing Then
                        txtDtlMPRCd.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MPRCD_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_NUCZN_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_NUCZN_FLD_NAME)) Is Nothing Then
                        txtDtlNucZn.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_NUCZN_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_NUCCD_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_NUCCD_FLD_NAME)) Is Nothing Then
                        txtDtlNucCd.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_NUCCD_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MLFLAG_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MLFLAG_FLD_NAME)) Is Nothing Then
                        txtDtlMailFlag.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MLFLAG_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_ADDR_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_ADDR_FLD_NAME)) Is Nothing Then
                        txtDtlAddr.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_ADDR_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_FRAC_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_FRAC_FLD_NAME)) Is Nothing Then
                        txtDtlFrac.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_FRAC_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_ADDRUNIT_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_ADDRUNIT_FLD_NAME)) Is Nothing Then
                        txtDtlUnit.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_ADDRUNIT_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PREDIR_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PREDIR_FLD_NAME)) Is Nothing Then
                        txtDtlPreDir.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PREDIR_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_RDNAME_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_RDNAME_FLD_NAME)) Is Nothing Then
                        txtDtlRdNam.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_RDNAME_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_RDSFXFLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_RDSFXFLD_NAME)) Is Nothing Then
                        txtDtlSfx.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_RDSFXFLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PSTDIR_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PSTDIR_FLD_NAME)) Is Nothing Then
                        txtDtlPstDir.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PSTDIR_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_SITCOMM_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_SITCOMM_FLD_NAME)) Is Nothing Then
                        txtDtlSitComm.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_SITCOMM_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_SITESTATE_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_SITESTATE_FLD_NAME)) Is Nothing Then
                        txtDtlSiteState.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_SITESTATE_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_SITEZIP_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_SITEZIP_FLD_NAME)) Is Nothing Then
                        txtDtlSitezip.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_SITEZIP_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MAPNUMBER_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MAPNUMBER_FLD_NAME)) Is Nothing Then
                        txtDtlMapNum.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_MAPNUMBER_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_ACREAGE_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_ACREAGE_FLD_NAME)) Is Nothing Then
                        Dim pAcrTxt As String
                        Dim pAcrNum As Double
                        pAcrTxt = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_ACREAGE_FLD_NAME))
                        pAcrTxt = pAcrTxt.Insert(Len(pAcrTxt) - 2, ".")
                        pAcrNum = pAcrTxt
                        txtDtlAcreage.Text = pAcrNum
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_UNITS_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_UNITS_FLD_NAME)) Is Nothing Then
                        txtDtlNumUnits.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_UNITS_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PROPDESCRCD_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PROPDESCRCD_FLD_NAME)) Is Nothing Then
                        txtDtlPropDescCd.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PROPDESCRCD_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PROPDESC_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PROPDESC_FLD_NAME)) Is Nothing Then
                        txtDtlPropDesc.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PROPDESC_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_REGCUTNO_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_REGCUTNO_FLD_NAME)) Is Nothing Then
                        txtDtlRgCutNo.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_REGCUTNO_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_REGCUTDT_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_REGCUTDT_FLD_NAME)) Is Nothing Then
                        txtDtlRegCutDate.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_REGCUTDT_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PREPARCUTNO_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PREPARCUTNO_FLD_NAME)) Is Nothing Then
                        txtDtlPreParCutNo.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PREPARCUTNO_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PREPARCUTDATE_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PREPARCUTDATE_FLD_NAME)) Is Nothing Then
                        txtDtlPrParCutDate.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PREPARCUTDATE_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_TRACUTNO_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_TRACUTNO_FLD_NAME)) Is Nothing Then
                        txtDtlTraCutNo.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_TRACUTNO_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_TRACUTDT_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_TRACUTDT_FLD_NAME)) Is Nothing Then
                        txtDtlTraCutDate.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_TRACUTDT_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PRIORPAR1_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PRIORPAR1_FLD_NAME)) Is Nothing Then
                        txtDtlPriorPar1.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PRIORPAR1_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PRIORPAR2_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PRIORPAR2_FLD_NAME)) Is Nothing Then
                        txtDtlPriorPar2.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PRIORPAR2_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PRIORPAR3_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PRIORPAR3_FLD_NAME)) Is Nothing Then
                        txtDtlPriorPar3.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PRIORPAR3_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PRIORPAR4_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PRIORPAR4_FLD_NAME)) Is Nothing Then
                        txtDtlPriorPar4.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PRIORPAR4_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PRIORTRA_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PRIORTRA_FLD_NAME)) Is Nothing Then
                        txtDtlPriorTRA.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PRIORTRA_FLD_NAME))
                    End If
                    If Not IsDBNull(pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PARENTPARCEL_FLD_NAME))) And Not pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PARENTPARCEL_FLD_NAME)) Is Nothing Then
                        txtDtlParentPar.Text = pDtlRow.Value(pDtlRow.Fields.FindField(MPR_PARENTPARCEL_FLD_NAME))
                    End If
                    tbMPRForm.SelectedTab = TabPage2
                Else
                    Cursor.Current = Windows.Forms.Cursors.Default
                    MsgBox("No MPR Record found for APN: " & pMPRAPNID)
                    tbMPRForm.SelectedTab = TabPage1
                    ClearDetailFields()
                End If
            Else
                Cursor.Current = Windows.Forms.Cursors.Default
                MsgBox("Select a Record to Show Detials")
                tbMPRForm.SelectedTab = TabPage1
                ClearDetailFields()
            End If
            Cursor.Current = Windows.Forms.Cursors.Default
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnBacktoBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBacktoBrowse.Click
        tbMPRForm.SelectedTab = TabPage1
        ClearDetailFields()
    End Sub

    Private Sub btnMPRFindFtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMPRFindFtr.Click
        Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Try
            If Not dgMPRParcelList Is Nothing Then
                If dgMPRParcelList.SelectedRows.Count > 0 Then
                    Dim pMPRAPNID As String
                    Dim pAPNParID As String
                    pAPNParID = ""
                    pMPRAPNID = dgMPRParcelList.CurrentRow.Cells.Item(dgMPRParcelList.Columns("APN").Index).Value
                    'Get the parcel id from the apn table to select the parcel in the map
                    If IsNumeric(pMPRAPNID) Then
                        'query the apn view and get the parcelid
                        Dim papnQF As IQueryFilter
                        Dim papnCur As ICursor
                        Dim papnRow As IRow
                        papnQF = New QueryFilter
                        papnQF.WhereClause = "APN = " & pMPRAPNID
                        papnCur = m_pAPNParView.Search(papnQF, False) 'changed this one
                        papnRow = papnCur.NextRow
                        If Not papnRow Is Nothing Then
                            'Fill the main menu
                            If Not IsDBNull(papnRow.Value(papnRow.Fields.FindField(APN_ATR_PARCELID_FLD_NAME))) And Not papnRow.Value(papnRow.Fields.FindField(APN_ATR_PARCELID_FLD_NAME)) Is Nothing Then
                                pAPNParID = papnRow.Value(papnRow.Fields.FindField(APN_ATR_PARCELID_FLD_NAME))
                            End If
                        Else
                            MsgBox("APN not found in Parcel Layer")
                            Cursor.Current = Windows.Forms.Cursors.Default
                            Exit Sub
                        End If

                        If IsNumeric(pAPNParID) Then
                            GetSelectedFeatures(PARCEL_DATASRC, m_ActiveView, "PARCELID", pAPNParID, True)
                        End If
                    Else
                        MsgBox("No Valid APN selected in list")
                    End If
                Else
                    MsgBox("No APN selected in list")
                End If
            Else
                MsgBox("Please select an APN")
            End If
            Cursor.Current = Windows.Forms.Cursors.Default
            Exit Sub
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
            Cursor.Current = Windows.Forms.Cursors.Default
        End Try

    End Sub

#End Region

#Region "Combo boxes and tabs"

    Private Sub cboSearchType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchType.SelectedIndexChanged
        dgMPRParcelList.DataSource = Nothing
        lblNumRecFound.Text = 0
        txtSearch2QF.Text = ""
        If cboSearchType.SelectedIndex = 0 Then
            lblSearch2.Text = "Map # Search"
        ElseIf cboSearchType.SelectedIndex = 1 Then
            lblSearch2.Text = "Road Name Search"
        ElseIf cboSearchType.SelectedIndex = 2 Then
            lblSearch2.Text = "Owner Name Search"
        Else
            MsgBox("Need to Select a Selection Type")
            Exit Sub
        End If
        If txtAPNQF.Text <> "" Then
            chkQFs()
        End If
    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click
        btnDetails.PerformClick()
    End Sub

    Private Sub TabPage2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Enter
        btnDetails.PerformClick()
    End Sub

#End Region


    Private Sub btnExporttoExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExporttoExcel.Click
        ExportToExcel.ExportDGVtoExcel(dgMPRParcelList)
    End Sub

    Private Sub dgMPRParcelList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMPRParcelList.CellContentClick

    End Sub
End Class