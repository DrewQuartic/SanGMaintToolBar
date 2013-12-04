Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports SanGISMaintenanceToolbar.Globals
Public Class frmQueryRoadSegByRoadID
    Dim m_pWKSP As IWorkspace
    Dim m_ActiveView As IActiveView
    Dim m_pRDSGTable As ITable
    Dim m_pRDNMTable As ITable
    Dim m_pAddrTable As ITable
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

    Private Sub frmQueryRoadSegByRoadID_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            'm_RDSEG = ""
            'm_RDSEGID = ""
            Dim pTableSourcename As String
            pTableSourcename = V_BROWSEROADSEG_DATASRC
            m_pRDSGTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename, True)
            If m_pRDSGTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If
            Dim pTableSourcename2 As String
            pTableSourcename2 = ROAD_NAME_DATASRC
            m_pRDNMTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename2, True)
            If m_pRDNMTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If
            Dim pTableSourcename3 As String
            pTableSourcename3 = V_ADDRROADNAME_DATASRC
            m_pAddrTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename3, True)
            If m_pAddrTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If

            'if roadlayer in map then activate the 'select in map' button
            If CheckForLayer(ROAD_DATASRC, m_ActiveView) Then
                btnRdFindFtr.Enabled = True
                btnRdSegFindFtr.Enabled = True
            Else
                btnRdFindFtr.Enabled = False
                btnRdSegFindFtr.Enabled = False
            End If

        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub frmQueryRoadSegByRoadID_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        m_ActiveView = Nothing
        m_pRDSGTable = Nothing
        m_pAddrTable = Nothing
        m_pRDNMTable = Nothing
        m_pWKSP = Nothing
        m_pWSE = Nothing

    End Sub

    Private Sub frmQueryRoadSegByRoadID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F1 Then
            btnRSGRDClear.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.F8 Then
            If ckbxRSGRDSearch.Checked Then
                ckbxRSGRDSearch.Checked = False
            Else
                ckbxRSGRDNameSearch.Checked = True
            End If
        ElseIf e.KeyCode = Windows.Forms.Keys.F12 Then
            btnRSGRDExit.PerformClick()
        End If
    End Sub


#End Region

    Private Sub CheckTxtBoxes()
        If ckbxRSGRDNameSearch.Checked Or ckbxRSGRDSearch.Checked Or ckbxRSGRDSegIDSearch.Checked Then
            txtRSGRDSelectSegID.Text = ""
            txtRSGRDSelectRdID.Text = ""
            txtRSGRDSelectSegID.Enabled = False
            txtRSGRDSelectRdID.Enabled = False
        Else
            txtRSGRDSelectSegID.Text = ""
            txtRSGRDSelectRdID.Text = ""
            txtRSGRDSelectSegID.Enabled = True
            txtRSGRDSelectRdID.Enabled = True
        End If
        
    End Sub



#Region "Combo boxes and Check boxes"

    Private Sub ckbxRSGRDSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbxRSGRDSearch.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Try
                'manage checkboxes
                If Not ckbxRSGRDSearch.Checked Then
                    If Not ckbxRSGRDNameSearch.Checked And Not ckbxRSGRDSegIDSearch.Checked Then
                        txtRSGRDSelectRdID.Enabled = True
                        txtRSGRDSelectSegID.Enabled = True
                    End If
                    'cboRSGRDSelectRdID.Items.Clear()
                    cboRSGRDSelectRdID.SelectedText = ""
                    cboRSGRDSelectRdID.Text = ""
                    cboRSGRDSelectRdID.Enabled = False
                    ckbxRSGRDSearch.ForeColor = Drawing.Color.Black
                    ckbxRSGRDSearch.Text = "List IDs"
                    'clear out the form fields
                    ClearFormFields(True, True, True)
                    txtRSGRDTentMap.Focus()
                Else
                    txtRSGRDSelectRdID.Enabled = False
                    txtRSGRDSelectSegID.Enabled = False
                    If ckbxRSGRDNameSearch.Checked Then
                        ckbxRSGRDNameSearch.Checked = False
                    End If
                    If ckbxRSGRDSegIDSearch.Checked Then
                        ckbxRSGRDSegIDSearch.Checked = False
                    End If
                    cboRSGRDSelectRdID.Enabled = True
                    ckbxRSGRDSearch.ForeColor = Drawing.Color.Red
                    ckbxRSGRDSearch.Text = "Search"
                    'Fill it
                    If cboRSGRDSelectRdID.Items.Count < 3 Then
                        Dim pCur As ICursor, pRow As IRow, lIdx As Long, lIdx2 As Long
                        lIdx = m_pRDNMTable.Fields.FindField("FULL_NAME")
                        lIdx2 = m_pRDNMTable.Fields.FindField("ROAD_ID")

                        ''add a queryfilter and queryfilterdefinition for sorting
                        Dim pQF As IQueryFilter
                        pQF = New QueryFilter
                        Dim pQFDef As IQueryFilterDefinition
                        pQFDef = pQF
                        pQFDef.PostfixClause = "order by ROAD_ID"
                        pCur = m_pRDNMTable.Search(pQF, False) 'changed this one
                        pRow = pCur.NextRow
                        'Build the combobox
                        Me.cboRSGRDSelectRdID.Items.Add("ROAD ID / ROAD NAME")
                        Me.cboRSGRDSelectRdID.Items.Add("")
                        Do While Not pRow Is Nothing
                            Me.cboRSGRDSelectRdID.Items.Add(pRow.Value(lIdx2) & " / " & pRow.Value(lIdx))
                            pRow = pCur.NextRow
                        Loop
                    End If
                    'display the 1st item
                    If Me.cboRSGRDSelectRdID.Items.Count > 0 Then Me.cboRSGRDSelectRdID.SelectedIndex = 0
                    'Handle Text searches
                    CheckTxtBoxes()
                    Cursor.Current = Windows.Forms.Cursors.Default
                    cboRSGRDSelectRdID.Focus()
                End If
            Catch ex As Exception
                Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub ckbxRSGRDNameSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbxRSGRDNameSearch.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Try
                If Not ckbxRSGRDNameSearch.Checked Then
                    If Not ckbxRSGRDSearch.Checked And Not ckbxRSGRDSegIDSearch.Checked Then
                        txtRSGRDSelectRdID.Enabled = True
                        txtRSGRDSelectSegID.Enabled = True
                    End If
                    'cboRSGRDSelectName.Items.Clear()
                    cboRSGRDSelectName.SelectedText = ""
                    cboRSGRDSelectName.Text = ""
                    cboRSGRDSelectName.Enabled = False
                    ckbxRSGRDNameSearch.ForeColor = Drawing.Color.Black
                    ckbxRSGRDNameSearch.Text = "List Names"
                    'clear out the form fields
                    ClearFormFields(True, True, True)
                    txtRSGRDTentMap.Focus()
                Else
                    txtRSGRDSelectRdID.Enabled = False
                    txtRSGRDSelectSegID.Enabled = False
                    If ckbxRSGRDSearch.Checked Then
                        ckbxRSGRDSearch.Checked = False
                    End If
                    If ckbxRSGRDSegIDSearch.Checked Then
                        ckbxRSGRDSegIDSearch.Checked = False
                    End If
                    cboRSGRDSelectName.Enabled = True
                    ckbxRSGRDNameSearch.ForeColor = Drawing.Color.Red
                    ckbxRSGRDNameSearch.Text = "Search"
                    'Fill it
                    If cboRSGRDSelectName.Items.Count < 3 Then
                        Dim pCur As ICursor, pRow As IRow, lIdx As Long, lIdx2 As Long
                        lIdx = m_pRDNMTable.Fields.FindField("FULL_NAME")
                        lIdx2 = m_pRDNMTable.Fields.FindField("ROAD_ID")

                        ''add a queryfilter and queryfilterdefinition for sorting
                        Dim pQF As IQueryFilter
                        pQF = New QueryFilter
                        Dim pQFDef As IQueryFilterDefinition
                        pQFDef = pQF
                        pQFDef.PostfixClause = "order by FULL_NAME"
                        pCur = m_pRDNMTable.Search(pQF, False) 'changed this one
                        pRow = pCur.NextRow
                        'Build the combobox
                        Me.cboRSGRDSelectName.Items.Add("ROAD NAME / ROAD ID")
                        Me.cboRSGRDSelectName.Items.Add("")
                        Do While Not pRow Is Nothing
                            Me.cboRSGRDSelectName.Items.Add(pRow.Value(lIdx) & " / " & pRow.Value(lIdx2))
                            pRow = pCur.NextRow
                        Loop
                    End If
                    'display the 1st item
                    If Me.cboRSGRDSelectName.Items.Count > 0 Then Me.cboRSGRDSelectName.SelectedIndex = 0
                    'Handle Text searches
                    CheckTxtBoxes()
                    Cursor.Current = Windows.Forms.Cursors.Default
                    cboRSGRDSelectName.Focus()
                    End If
            Catch ex As Exception
                Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub ckbxRSGRDSegIDSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbxRSGRDSegIDSearch.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Try
                If Not ckbxRSGRDSegIDSearch.Checked Then
                    If Not ckbxRSGRDSearch.Checked And Not ckbxRSGRDNameSearch.Checked Then
                        txtRSGRDSelectRdID.Enabled = True
                        txtRSGRDSelectSegID.Enabled = True
                    End If
                    'cboRSGRDSelectSegID.Items.Clear()
                    cboRSGRDSelectSegID.SelectedText = ""
                    cboRSGRDSelectSegID.Text = ""
                    cboRSGRDSelectSegID.Enabled = False
                    ckbxRSGRDSegIDSearch.ForeColor = Drawing.Color.Black
                    ckbxRSGRDSegIDSearch.Text = "List SegIDs"
                    'clear out the form fields
                    ClearFormFields(True, True, True)
                    txtRSGRDTentMap.Focus()
                Else
                    txtRSGRDSelectRdID.Enabled = False
                    txtRSGRDSelectSegID.Enabled = False
                    If ckbxRSGRDSearch.Checked Then
                        ckbxRSGRDSearch.Checked = False
                    End If
                    If ckbxRSGRDNameSearch.Checked Then
                        ckbxRSGRDNameSearch.Checked = False
                    End If
                    cboRSGRDSelectSegID.Enabled = True
                    ckbxRSGRDSegIDSearch.ForeColor = Drawing.Color.Red
                    ckbxRSGRDSegIDSearch.Text = "Search"
                    'Fill it if its not already
                    If cboRSGRDSelectSegID.Items.Count < 3 Then
                        Dim pCur As ICursor, pRow As IRow, lIdx As Long, lIdx2 As Long
                        lIdx = m_pRDSGTable.Fields.FindField("FULL_NAME")
                        lIdx2 = m_pRDSGTable.Fields.FindField("ROADSEGID")

                        ''add a queryfilter and queryfilterdefinition for sorting
                        Dim pQF As IQueryFilter
                        pQF = New QueryFilter
                        Dim pQFDef As IQueryFilterDefinition
                        pQFDef = pQF
                        pQFDef.PostfixClause = "order by ROADSEGID"
                        pCur = m_pRDSGTable.Search(pQF, False) 'changed this one
                        pRow = pCur.NextRow
                        'Build the combobox
                        Me.cboRSGRDSelectSegID.Items.Add("ROAD SEG ID / ROAD NAME")
                        Me.cboRSGRDSelectSegID.Items.Add("")
                        Do While Not pRow Is Nothing
                            Me.cboRSGRDSelectSegID.Items.Add(pRow.Value(lIdx2) & " / " & pRow.Value(lIdx))
                            pRow = pCur.NextRow
                        Loop
                    End If
                    'display the 1st item
                    If Me.cboRSGRDSelectSegID.Items.Count > 0 Then Me.cboRSGRDSelectSegID.SelectedIndex = 0
                    'Handle Text searches
                    CheckTxtBoxes()
                    Cursor.Current = Windows.Forms.Cursors.Default
                    cboRSGRDSelectSegID.Focus()
                End If
            Catch ex As Exception
                Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub cboRSGRDSelectName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRSGRDSelectName.SelectedIndexChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            If ckbxRSGRDNameSearch.Checked Then
                Try
                    dgRSGRD.DataSource = Nothing
                    dgRSADgrid.DataSource = Nothing
                    lblRSGRDRecCnt.Text = 0
                    ClearFormFields(True, True, True)
                    If cboRSGRDSelectName.SelectedIndex <> 0 Then  'to skip the initial load
                        Dim pQueryfilter As IQueryFilter
                        Dim pRDID As Integer
                        Dim pRDIDLOC As Integer
                        Dim pRDIDLstLoc As Integer
                        Dim tmpRDTEXT As String
                        Dim pRDNMTXTlen As Integer
                        Dim prdCur As ICursor
                        Dim prdRow As IRow
                        tmpRDTEXT = cboRSGRDSelectName.Text
                        pRDNMTXTlen = tmpRDTEXT.Length
                        pRDIDLOC = tmpRDTEXT.IndexOf("/") - 1
                        pRDIDLstLoc = tmpRDTEXT.LastIndexOf("/") - 1
                        If pRDIDLOC <= 0 Then
                            dgRSGRD.DataSource = Nothing
                            MsgBox("NO ROAD NAME found.  Choose a different Road Name Record or use ID search")
                            Exit Sub
                        End If
                        'In case a / exists in the road name
                        If pRDIDLOC <> pRDIDLstLoc Then
                            pRDID = tmpRDTEXT.Substring(pRDIDLstLoc + 2)
                        Else
                            pRDID = tmpRDTEXT.Substring(pRDIDLOC + 2)
                        End If
                        pQueryfilter = New QueryFilter
                        pQueryfilter.WhereClause = "ROADID = " & pRDID
                        prdCur = m_pRDSGTable.Search(pQueryfilter, False) 'changed this one
                        prdRow = prdCur.NextRow
                        If Not prdRow Is Nothing Then
                            PopGridList(pRDID)
                        End If
                    End If
            Catch ex As Exception
                Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
                End Try
            End If
        End If
    End Sub


#End Region

#Region "Buttons"

    Private Sub btnRSGRDClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRSGRDClear.Click
        Try
            ckbxRSGRDNameSearch.Checked = False
            ckbxRSGRDSearch.Checked = False
            ckbxRSGRDSegIDSearch.Checked = False
            cboRSGRDSelectName.Text = ""
            'clear grid
            dgRSGRD.DataSource = Nothing
            dgRSADgrid.DataSource = Nothing
            ClearFormFields(True, True, True)
            txtRSGRDTentMap.Focus()
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnRSGRDExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRSGRDExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnGoBackFront_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoBackFront.Click
        TBRDSG.SelectedTab = tbpgRDSGSearch
    End Sub

    Private Sub btnRdFindFtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRdFindFtr.Click
        If IsNumeric(txtRdRoadID.Text) Then
            GetSelectedFeatures(ROAD_DATASRC, m_ActiveView, "ROADID", txtRdRoadID.Text, True)
        Else
            MsgBox("Choose a valid Road or Road Segment")
        End If
    End Sub

    Private Sub btnRdSegFindFtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRdSegFindFtr.Click
        If IsNumeric(txtCurrentSegID.Text) Then
            GetSelectedFeatures(ROAD_DATASRC, m_ActiveView, "ROADSEGID", txtCurrentSegID.Text, True)
        Else
            MsgBox("Choose a valid Road or Road Segment")
        End If
    End Sub

    Private Sub btnRSGRDSegIDInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRSGRDSegIDInfo.Click
        Dim pRdSEGID As String
        pRdSEGID = txtRSGADRdSegID.Text
        lblNoAddressFnd.Visible = False
        TBRDSG.SelectedTab = tbRDSGInfo
        PopAdrGRidList(pRdSEGID)
    End Sub

#End Region

#Region "Custom"

    Private Sub ClearFormFields(ByVal pjstflds As Boolean, ByVal pjstlbl As Boolean, ByVal pjstAddInfo As Boolean)
        Try
            'm_RDSEG = ""
            'm_RDSEGID = ""
            If pjstflds Then
                txtRSGRDJur.Text = ""
                txtRSGRDMultiJur.Text = ""
                txtRSGRDRd20Nm.Text = ""
                txtRSGRDRd20Pre.Text = ""
                txtRSGRDRd30Nm.Text = ""
                txtRSGRDRd30Pre.Text = ""
                txtRSGRDRd30Suf.Text = ""
                txtRSGRDRd30Type.Text = ""
                txtRSGRDRdNmFull.Text = ""
                txtRSGRDRdTyp.Text = ""
                txtRSGRDReserved.Text = ""
                txtRSGRDTentMap.Text = ""
                txtRSGRDThomas.Text = ""
                txtRSGRDWO.Text = ""
                txtRdRoadID.Text = ""
            End If
            If pjstlbl Then
                txtCurrentSegID.Text = 0
                lblRSGRDRecCnt.Text = 0
                lblAddrsFnd.Text = 0
            End If
            If pjstAddInfo Then
                txtRSGADRdSegID.Text = ""
                txtRSGADPostID.Text = ""
                txtRSGADPostDt.Text = ""
                txtRSGADRdNmFull.Text = ""
                txtRSGADRdID.Text = ""
                txtRSGADSegClss.Text = ""
                txtRSGADSpeed.Text = ""
                txtRSGADFireDriv.Text = ""
                txtRSGADSubdiv.Text = ""
                txtRSGADOneWay.Text = ""
                txtRSGADPending.Text = ""
                txtRSGADRangeFrm.Text = ""
                txtRSGADRangeTo.Text = ""
                txtRSGADLMix.Text = ""
                txtRSGADLZip.Text = ""
                txtRSGADLTract.Text = ""
                txtRSGADLBlock.Text = ""
                txtRSGADLPSBLOCK.Text = ""
                txtRSGADRMix.Text = ""
                txtRSGADRZip.Text = ""
                txtRSGADRTract.Text = ""
                txtRSGADRBlock.Text = ""
                txtRSGADRPSBLOCK.Text = ""
            End If
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub PopGridList(ByVal pqRDID As String)
        Try
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Dim pRDIDQF As IQueryFilter
            Dim pRDID As String
            pRDID = pqRDID
            pRDIDQF = New QueryFilter

            If pRDID <> "" Then
                If ckbxRSGRDSegIDSearch.Checked Or (txtRSGRDSelectSegID.Enabled And txtRSGRDSelectSegID.Text <> "") Then
                    m_TWWhereClause = "ROADSEGID = " & pRDID
                Else
                    m_TWWhereClause = "ROADID = " & pRDID
                End If
                pRDIDQF.WhereClause = m_TWWhereClause
                m_TWPostfixClause = "Order By ROADSEGID"
            Else
                MsgBox("No Valid Road ID selected.")
                Cursor.Current = Windows.Forms.Cursors.Default
                Exit Sub
            End If
            'check if any selected
            Dim pRwCnt As Integer
            pRwCnt = m_pRDSGTable.RowCount(pRDIDQF)

            lblRSGRDRecCnt.Text = pRwCnt
            If pRwCnt > 0 And pRwCnt < 1001 Then
                FillGridData()
            ElseIf pRwCnt > 1000 Then
                Dim prowlots As MsgBoxResult
                prowlots = MsgBox(pRwCnt & " Records found, press OK to continue, CANCEL to start new search", MsgBoxStyle.OkCancel, "Thats a Lot of Records!")
                If prowlots = MsgBoxResult.Ok Then
                    FillGridData()
                End If
            Else
                MsgBox("No RoadSegID records found matching ROADID search criteria", MsgBoxStyle.Information)
            End If
            Cursor.Current = Windows.Forms.Cursors.Default
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try

    End Sub

    Private Sub PopAdrGRidList(ByVal pqRDSGID As String)
        Try
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Dim pRDSGIDQF As IQueryFilter
            Dim pRDSGID As String
            pRDSGID = pqRDSGID
            pRDSGIDQF = New QueryFilter

            If pRDSGID <> "" Then
                m_TWWhereClause = "ROADSEGID = " & pRDSGID
                pRDSGIDQF.WhereClause = m_TWWhereClause
                m_TWPostfixClause = "Order By ADDRNO"
            Else
                MsgBox("No Valid RoadSeg ID selected.")
                Cursor.Current = Windows.Forms.Cursors.Default
                TBRDSG.SelectedTab = tbpgRDSGSearch
                Exit Sub
            End If
            'check if any selected
            Dim pRwCnt As Integer
            pRwCnt = m_pAddrTable.RowCount(pRDSGIDQF)

            lblAddrsFnd.Text = pRwCnt
            If pRwCnt > 0 And pRwCnt < 1001 Then
                FillAddrGridData()
            ElseIf pRwCnt > 1000 Then
                Dim prowlots As MsgBoxResult
                prowlots = MsgBox(pRwCnt & " Records found, press OK to continue, CANCEL to start new search", MsgBoxStyle.OkCancel, "Thats a Lot of Records!")
                If prowlots = MsgBoxResult.Ok Then
                    FillAddrGridData()
                End If
            Else
                lblNoAddressFnd.Visible = True
                'MsgBox("No Address records found matching ROADSEGID search criteria", MsgBoxStyle.Information)
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
            tableWrapper = New ArcDataBinding.TableWrapper(m_pRDSGTable)
            dgRSGRD.DataSource = tableWrapper
            With dgRSGRD
                .Columns("ROADSEGID").DisplayIndex = 0
                .Columns("ROADSEGID").Width = 60
                .Columns("ROADSEGID").DefaultCellStyle.ForeColor = Drawing.Color.Blue
                .Columns("ROADSEGID").HeaderText = "RdSeg ID"

                .Columns("ABLOADDR").DisplayIndex = 1
                .Columns("ABLOADDR").Width = 60
                .Columns("ABLOADDR").HeaderText = "Abloaddr"

                .Columns("ABHIADDR").DisplayIndex = 2
                .Columns("ABHIADDR").Width = 60
                .Columns("ABHIADDR").HeaderText = "Abhiaddr"

                .Columns("NAD83E").DisplayIndex = 3
                .Columns("NAD83E").Width = 80
                .Columns("NAD83E").HeaderText = "NAD83E"

                .Columns("NAD83N").DisplayIndex = 4
                .Columns("NAD83N").Width = 80
                .Columns("NAD83N").HeaderText = "NAD83N"

                .Columns("LJURISDIC").DisplayIndex = 5
                .Columns("LJURISDIC").Width = 40
                .Columns("LJURISDIC").HeaderText = "LJur"
                .Columns("LJURISDIC").DefaultCellStyle.ForeColor = Drawing.Color.Green

                .Columns("LLOWADDR").DisplayIndex = 6
                .Columns("LLOWADDR").Width = 55
                .Columns("LLOWADDR").HeaderText = "LLow Addr"
                .Columns("LLOWADDR").DefaultCellStyle.ForeColor = Drawing.Color.Green

                .Columns("LHIGHADDR").DisplayIndex = 7
                .Columns("LHIGHADDR").Width = 55
                .Columns("LHIGHADDR").HeaderText = "LHi Addr"
                .Columns("LHIGHADDR").DefaultCellStyle.ForeColor = Drawing.Color.Green

                .Columns("RJURISDIC").DisplayIndex = 8
                .Columns("RJURISDIC").Width = 40
                .Columns("RJURISDIC").HeaderText = "RJur"
                .Columns("RJURISDIC").DefaultCellStyle.ForeColor = Drawing.Color.Orange

                .Columns("RLOWADDR").DisplayIndex = 9
                .Columns("RLOWADDR").Width = 55
                .Columns("RLOWADDR").HeaderText = "RLow Addr"
                .Columns("RLOWADDR").DefaultCellStyle.ForeColor = Drawing.Color.Orange

                .Columns("RHIGHADDR").DisplayIndex = 10
                .Columns("RHIGHADDR").Width = 55
                .Columns("RHIGHADDR").HeaderText = "RHi Addr"
                .Columns("RHIGHADDR").DefaultCellStyle.ForeColor = Drawing.Color.Orange

                Cursor.Current = Windows.Forms.Cursors.Default
            End With
            'dgRSGRD.Focus()
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub FillAddrGridData()
        'Fill the datagrid
        Try
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            tableWrapper = New ArcDataBinding.TableWrapper(m_pAddrTable)
            dgRSADgrid.DataSource = tableWrapper
            With dgRSADgrid
                .Columns("JURISDIC").DisplayIndex = 0
                .Columns("JURISDIC").Width = 40
                '.Columns("JURISDIC").DefaultCellStyle.ForeColor = Drawing.Color.Blue
                .Columns("JURISDIC").HeaderText = "JUR"

                .Columns("ADDRNO").DisplayIndex = 1
                .Columns("ADDRNO").Width = 60
                .Columns("ADDRNO").HeaderText = "ADDRNO"

                .Columns("ADDRFRAC").DisplayIndex = 2
                .Columns("ADDRFRAC").Width = 40
                .Columns("ADDRFRAC").HeaderText = "FRAC"

                .Columns("ADDRUNIT").DisplayIndex = 3
                .Columns("ADDRUNIT").Width = 40
                .Columns("ADDRUNIT").HeaderText = "UNIT"

                .Columns("TYPE").DisplayIndex = 4
                .Columns("TYPE").Width = 40
                .Columns("TYPE").HeaderText = "TYPE"

                .Columns("APN").DisplayIndex = 5
                .Columns("APN").Width = 80
                .Columns("APN").HeaderText = "APN"
                '.Columns("LJURISDIC").DefaultCellStyle.ForeColor = Drawing.Color.Green

                .Columns("MAPTYPE").DisplayIndex = 6
                .Columns("MAPTYPE").Width = 75
                .Columns("MAPTYPE").HeaderText = "MAPTYPE"
                '.Columns("LLOWADDR").DefaultCellStyle.ForeColor = Drawing.Color.Green

                .Columns("MAPNUM").DisplayIndex = 7
                .Columns("MAPNUM").Width = 75
                .Columns("MAPNUM").HeaderText = "MAPNUM"
                '.Columns("LHIGHADDR").DefaultCellStyle.ForeColor = Drawing.Color.Green

                .Columns("WRKORDID").DisplayIndex = 8
                .Columns("WRKORDID").Width = 80
                .Columns("WRKORDID").HeaderText = "WrkOrdID"
                '.Columns("RJURISDIC").DefaultCellStyle.ForeColor = Drawing.Color.Orange

                .Columns("TENTMAP").DisplayIndex = 9
                .Columns("TENTMAP").Width = 80
                .Columns("TENTMAP").HeaderText = "TentMap"
                '.Columns("RLOWADDR").DefaultCellStyle.ForeColor = Drawing.Color.Orange

                '.Columns("LOTNO").DisplayIndex = 10
                '.Columns("LOTNO").Width = 100
                '.Columns("LOTNO").HeaderText = "Lot No"
                '.Columns("RHIGHADDR").DefaultCellStyle.ForeColor = Drawing.Color.Orange

                Cursor.Current = Windows.Forms.Cursors.Default
            End With
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub FillRoadSegInfo(ByVal pqRdsegID As String)
        ClearFormFields(True, False, True)
        Dim pRdsegID As String
        pRdsegID = pqRdsegID
        If pRdsegID <> "" Then
            Dim prdsgQF As IQueryFilter
            Dim prdsegCur As ICursor
            Dim prdsegRow As IRow
            prdsgQF = New QueryFilter
            prdsgQF.WhereClause = "ROADSEGID = " & pRdsegID
            prdsegCur = m_pRDSGTable.Search(prdsgQF, False) 'changed this one
            prdsegRow = prdsegCur.NextRow
            If Not prdsegRow Is Nothing Then
                'Fill the main menu
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD30PREDIR_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD30PREDIR_FLD_NAME)) Is Nothing Then
                    txtRSGRDRd30Pre.Text = prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD30PREDIR_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD30NAME_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD30NAME_FLD_NAME)) Is Nothing Then
                    txtRSGRDRd30Nm.Text = prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD30NAME_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD30SUFFIX_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD30SUFFIX_FLD_NAME)) Is Nothing Then
                    txtRSGRDRd30Type.Text = prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD30SUFFIX_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD30POSTDIR_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD30POSTDIR_FLD_NAME)) Is Nothing Then
                    txtRSGRDRd30Suf.Text = prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD30POSTDIR_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RESERVEJUR_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RESERVEJUR_FLD_NAME)) Is Nothing Then
                    txtRSGRDJur.Text = prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RESERVEJUR_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD20PREDIR_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD20PREDIR_FLD_NAME)) Is Nothing Then
                    txtRSGRDRd20Pre.Text = prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD20PREDIR_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD20NAME_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD20NAME_FLD_NAME)) Is Nothing Then
                    txtRSGRDRd20Nm.Text = prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD20NAME_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD20SUFFIX_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD20SUFFIX_FLD_NAME)) Is Nothing Then
                    txtRSGRDRdTyp.Text = prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RD20SUFFIX_FLD_NAME))
                End If

                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_FULLNAME_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_FULLNAME_FLD_NAME)) Is Nothing Then
                    txtRSGRDRdNmFull.Text = prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_FULLNAME_FLD_NAME))
                End If

                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RESERVEBYNM_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RESERVEBYNM_FLD_NAME)) Is Nothing Then
                    txtRSGRDReserved.Text = prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RESERVEBYNM_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RESERVETENTMAP_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RESERVETENTMAP_FLD_NAME)) Is Nothing Then
                    txtRSGRDTentMap.Text = prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RESERVETENTMAP_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RESERVETOMBRO_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RESERVETOMBRO_NAME)) Is Nothing Then
                    txtRSGRDThomas.Text = prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_RESERVETOMBRO_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_WORKORDERNUM_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_WORKORDERNUM_FLD_NAME)) Is Nothing Then
                    txtRSGRDWO.Text = prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_WORKORDERNUM_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_MULTIJUR_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_MULTIJUR_FLD_NAME)) Is Nothing Then
                    txtRSGRDMultiJur.Text = prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_MULTIJUR_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RD_ROADID_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RD_ROADID_FLD_NAME)) Is Nothing Then
                    txtRdRoadID.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RD_ROADID_FLD_NAME))
                End If

                'Fill the second tab
                txtRSGADRdSegID.Text = pRdsegID
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RD_POSTID_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RD_POSTID_FLD_NAME)) Is Nothing Then
                    txtRSGADPostID.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RD_POSTID_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RD_POSTDATE_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RD_POSTDATE_FLD_NAME)) Is Nothing Then
                    txtRSGADPostDt.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RD_POSTDATE_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_FULLNAME_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_FULLNAME_FLD_NAME)) Is Nothing Then
                    txtRSGADRdNmFull.Text = prdsegRow.Value(prdsegRow.Fields.FindField(ROADNM_FULLNAME_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RD_ROADID_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RD_ROADID_FLD_NAME)) Is Nothing Then
                    txtRSGADRdID.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RD_ROADID_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RD_SEGCLASS_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RD_SEGCLASS_FLD_NAME)) Is Nothing Then
                    txtRSGADSegClss.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RD_SEGCLASS_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RD_SPEED_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RD_SPEED_FLD_NAME)) Is Nothing Then
                    txtRSGADSpeed.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RD_SPEED_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RD_FIREDRIV_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RD_FIREDRIV_FLD_NAME)) Is Nothing Then
                    txtRSGADFireDriv.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RD_FIREDRIV_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField("SUBDIVID"))) And Not prdsegRow.Value(prdsegRow.Fields.FindField("SUBDIVID")) Is Nothing Then
                    txtRSGADSubdiv.Text = prdsegRow.Value(prdsegRow.Fields.FindField("SUBDIVID"))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RD_ONEWAY_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RD_ONEWAY_FLD_NAME)) Is Nothing Then
                    txtRSGADOneWay.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RD_ONEWAY_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField("PENDING"))) And Not prdsegRow.Value(prdsegRow.Fields.FindField("PENDING")) Is Nothing Then
                    txtRSGADPending.Text = prdsegRow.Value(prdsegRow.Fields.FindField("PENDING"))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RD_ABLOADDR_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RD_ABLOADDR_FLD_NAME)) Is Nothing Then
                    txtRSGADRangeFrm.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RD_ABLOADDR_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RD_ABHIADDR_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RD_ABHIADDR_FLD_NAME)) Is Nothing Then
                    txtRSGADRangeTo.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RD_ABHIADDR_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RD_LMIXADDR_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RD_LMIXADDR_FLD_NAME)) Is Nothing Then
                    txtRSGADLMix.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RD_LMIXADDR_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RD_L_ZIP_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RD_L_ZIP_FLD_NAME)) Is Nothing Then
                    txtRSGADLZip.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RD_L_ZIP_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_L_TRACT_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_L_TRACT_FLD_NAME)) Is Nothing Then
                    txtRSGADLTract.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_L_TRACT_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_L_BLOCK_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_L_BLOCK_FLD_NAME)) Is Nothing Then
                    txtRSGADLBlock.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_L_BLOCK_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_L_PSBLOCK_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_L_PSBLOCK_FLD_NAME)) Is Nothing Then
                    txtRSGADLPSBLOCK.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_L_PSBLOCK_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RD_RMIXADDR_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RD_RMIXADDR_FLD_NAME)) Is Nothing Then
                    txtRSGADRMix.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RD_RMIXADDR_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RD_R_ZIP_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RD_R_ZIP_FLD_NAME)) Is Nothing Then
                    txtRSGADRZip.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RD_R_ZIP_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_R_TRACT_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_R_TRACT_FLD_NAME)) Is Nothing Then
                    txtRSGADRTract.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_R_TRACT_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_R_BLOCK_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_R_BLOCK_FLD_NAME)) Is Nothing Then
                    txtRSGADRBlock.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_R_BLOCK_FLD_NAME))
                End If
                If Not IsDBNull(prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_R_PSBLOCK_FLD_NAME))) And Not prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_R_PSBLOCK_FLD_NAME)) Is Nothing Then
                    txtRSGADRPSBLOCK.Text = prdsegRow.Value(prdsegRow.Fields.FindField(RDGEOM_R_PSBLOCK_FLD_NAME))
                End If
            End If
        End If
    End Sub

#End Region

#Region "Grids and Tabs"

    Private Sub dgRSGRD_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgRSGRD.SelectionChanged
        Dim pcrntrdsegid As String
        pcrntrdsegid = dgRSGRD.CurrentRow.Cells.Item(dgRSGRD.Columns("ROADSEGID").Index).Value
        'm_RDSEG = txtRdRoadID.Text
        'm_RDSEGID = pcrntrdsegid
        txtCurrentSegID.Text = pcrntrdsegid
        dgRSADgrid.DataSource = Nothing
        FillRoadSegInfo(pcrntrdsegid)
    End Sub

    Private Sub tbRDSGInfo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbRDSGInfo.Enter
        btnRSGRDSegIDInfo.PerformClick()
    End Sub

#End Region

    Private Sub cboRSGRDSelectRdID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRSGRDSelectRdID.SelectedIndexChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            If ckbxRSGRDSearch.Checked Then
                Try
                    dgRSGRD.DataSource = Nothing
                    dgRSADgrid.DataSource = Nothing
                    lblRSGRDRecCnt.Text = 0
                    ClearFormFields(True, True, True)
                    If cboRSGRDSelectRdID.SelectedIndex <> 0 Then  'to skip the initial load
                        Dim pQueryfilter As IQueryFilter
                        Dim pRDID As Integer
                        Dim pRDIDLOC As Integer
                        Dim pRDIDLstLoc As Integer
                        Dim tmpRDTEXT As String
                        Dim pRDNMTXTlen As Integer
                        Dim prdCur As ICursor
                        Dim prdRow As IRow
                        tmpRDTEXT = cboRSGRDSelectRdID.Text
                        pRDNMTXTlen = tmpRDTEXT.Length
                        pRDIDLOC = tmpRDTEXT.IndexOf("/") - 1
                        pRDIDLstLoc = tmpRDTEXT.LastIndexOf("/") - 1
                        If pRDIDLOC <= 0 Then
                            dgRSGRD.DataSource = Nothing
                            MsgBox("NO ROAD ID found.  Choose a different Road Name Record or use Name search")
                            Exit Sub
                        End If
                        pRDID = tmpRDTEXT.Substring(0, pRDIDLOC)
                        pQueryfilter = New QueryFilter
                        pQueryfilter.WhereClause = "ROADID = " & pRDID
                        prdCur = m_pRDSGTable.Search(pQueryfilter, False) 'changed this one
                        prdRow = prdCur.NextRow
                        If Not prdRow Is Nothing Then
                            PopGridList(pRDID)
                        End If
                    End If
            Catch ex As Exception
                Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub cboRSGRDSelectSegID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRSGRDSelectSegID.SelectedIndexChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            If ckbxRSGRDSegIDSearch.Checked Then
                Try
                    dgRSGRD.DataSource = Nothing
                    dgRSADgrid.DataSource = Nothing
                    lblRSGRDRecCnt.Text = 0
                    ClearFormFields(True, True, True)
                    If cboRSGRDSelectSegID.SelectedIndex <> 0 Then  'to skip the initial load
                        Dim pQueryfilter As IQueryFilter
                        Dim pRDID As Integer
                        Dim pRDIDLOC As Integer
                        Dim pRDIDLstLoc As Integer
                        Dim tmpRDTEXT As String
                        Dim pRDNMTXTlen As Integer
                        Dim prdCur As ICursor
                        Dim prdRow As IRow
                        tmpRDTEXT = cboRSGRDSelectSegID.Text
                        pRDNMTXTlen = tmpRDTEXT.Length
                        pRDIDLOC = tmpRDTEXT.IndexOf("/") - 1
                        pRDIDLstLoc = tmpRDTEXT.LastIndexOf("/") - 1
                        If pRDIDLOC <= 0 Then
                            dgRSGRD.DataSource = Nothing
                            MsgBox("NO ROAD SEG ID found.  Choose a different Road SEG Record or use Name search")
                            Exit Sub
                        End If
                        pRDID = tmpRDTEXT.Substring(0, pRDIDLOC)
                        pQueryfilter = New QueryFilter
                        If ckbxRSGRDSegIDSearch.Checked Then
                            pQueryfilter.WhereClause = "ROADSEGID = " & pRDID
                        Else
                            pQueryfilter.WhereClause = "ROADID = " & pRDID
                        End If
                        prdCur = m_pRDSGTable.Search(pQueryfilter, False) 'changed this one
                        prdRow = prdCur.NextRow
                        If Not prdRow Is Nothing Then
                            PopGridList(pRDID)
                        End If
                    End If
                Catch ex As Exception
                    Cursor.Current = Windows.Forms.Cursors.Default
                    Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                    Me.Close()
                End Try
            End If
            End If
    End Sub

    Private Sub Label42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label42.Click

    End Sub

    Private Sub tbpgRDSGSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbpgRDSGSearch.Click

    End Sub

    Private Sub txtRSGRDSelectRdID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRSGRDSelectRdID.TextChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            If Not ckbxRSGRDSearch.Checked And Not ckbxRSGRDNameSearch.Checked And Not ckbxRSGRDSegIDSearch.Checked And txtRSGRDSelectRdID.Enabled Then
                Try
                    txtRSGRDSelectSegID.Enabled = False
                    dgRSGRD.DataSource = Nothing
                    dgRSADgrid.DataSource = Nothing
                    lblRSGRDRecCnt.Text = 0
                    ClearFormFields(True, True, True)
                    If txtRSGRDSelectRdID.Text <> "" Then  'to skip the initial load
                        Dim pQueryfilter As IQueryFilter
                        Dim pRDID As Integer
                        Dim prdCur As ICursor
                        Dim prdRow As IRow
                        pRDID = txtRSGRDSelectRdID.Text
                        pQueryfilter = New QueryFilter
                        pQueryfilter.WhereClause = "ROADID = " & pRDID
                        prdCur = m_pRDSGTable.Search(pQueryfilter, False) 'changed this one
                        prdRow = prdCur.NextRow
                        If Not prdRow Is Nothing Then
                            PopGridList(pRDID)
                        End If
                    Else
                        txtRSGRDSelectSegID.Enabled = True
                    End If
                Catch ex As Exception
                    Cursor.Current = Windows.Forms.Cursors.Default
                    Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                    Me.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub txtRSGRDSelectSegID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRSGRDSelectSegID.TextChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            If Not ckbxRSGRDSearch.Checked And Not ckbxRSGRDNameSearch.Checked And Not ckbxRSGRDSegIDSearch.Checked And txtRSGRDSelectSegID.Enabled Then
                Try
                    txtRSGRDSelectRdID.Enabled = False
                    dgRSGRD.DataSource = Nothing
                    dgRSADgrid.DataSource = Nothing
                    lblRSGRDRecCnt.Text = 0
                    ClearFormFields(True, True, True)
                    If txtRSGRDSelectSegID.Text <> "" Then  'to skip the initial load
                        Dim pQueryfilter As IQueryFilter
                        Dim pRDID As Integer
                        Dim prdCur As ICursor
                        Dim prdRow As IRow
                        pRDID = txtRSGRDSelectSegID.Text
                        pQueryfilter = New QueryFilter
                        pQueryfilter.WhereClause = "ROADSEGID = " & pRDID
                        prdCur = m_pRDSGTable.Search(pQueryfilter, False) 'changed this one
                        prdRow = prdCur.NextRow
                        If Not prdRow Is Nothing Then
                            PopGridList(pRDID)
                        End If
                    Else
                        txtRSGRDSelectRdID.Enabled = True
                    End If
                Catch ex As Exception
                    Cursor.Current = Windows.Forms.Cursors.Default
                    Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                    Me.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub tbRDSGInfo_Click(sender As System.Object, e As System.EventArgs) Handles tbRDSGInfo.Click

    End Sub

    Private Sub btnExportData_Click(sender As System.Object, e As System.EventArgs) Handles btnExportData.Click
        ExportToExcel.ExportDGVtoExcel(dgRSGRD)
    End Sub

    Private Sub btnExporttoExcelAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnExporttoExcelAdd.Click
        ExportToExcel.ExportDGVtoExcel(dgRSADgrid)
    End Sub
End Class