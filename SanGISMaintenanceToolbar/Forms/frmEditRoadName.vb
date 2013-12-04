
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports SanGISMaintenanceToolbar.Globals
Imports System.Windows.Forms

Public Class frmEditRoadName
    'Dim m_pWKSP As IWorkspace
    Dim m_ActiveView As IActiveView
    Dim m_pRDTable As ITable
    Dim m_pRDSTDTable As ITable
    Dim m_pWSE As IWorkspaceEdit
    Dim m_Rd20 As String
    Dim m_Rd30 As String
    Dim m_RdFull As String
    Dim m_Rd20Sfx As String
    Dim m_Rd30Sfx As String
    Dim m_RdFullSfx As String
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

#Region "Primaries Form"

    Private Sub frmEditRoadName_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not ItFailed Then
            Dim pDataset As IDataset
            pDataset = m_pRDTable
            m_pWSE = pDataset.Workspace
            If m_pWSE.IsBeingEdited Then
                m_pWSE.StopEditOperation()
                m_pWSE.StopEditing(True)
            End If
        End If
        m_ActiveView = Nothing
        m_pRDTable = Nothing
        'm_pWKSP = Nothing
        m_pWSE = Nothing

    End Sub

    Private Sub frmEditRoadName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F1 Then
            btnRDNMReset.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.F8 Then
            If ckbxRDNMSearch.Checked Then
                ckbxRDNMSearch.Checked = False
            Else
                ckbxRDNMSearch.Checked = True
            End If
        ElseIf e.KeyCode = Windows.Forms.Keys.F10 Then
            btnRDNMSave.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.F12 Then
            btnRDNMExit.PerformClick()
        End If
    End Sub

    Private Sub frmEditRoadName_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
            Dim pTableSourcename As String
            pTableSourcename = ROAD_NAME_DATASRC
            m_pRDTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename, False)
            If m_pRDTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If
            Dim pTableSourcename2 As String
            pTableSourcename2 = ROAD_STDS_DATASRC
            m_pRDSTDTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename2, True)
            If m_pRDSTDTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If
            'Fill the combos
            cboRDNMMultiJur.Items.Add("N")
            cboRDNMMultiJur.Items.Add("Y")

            cboRDNMRdNmPre.Items.Add("")
            cboRDNMRdNmPre.Items.Add("E")
            cboRDNMRdNmPre.Items.Add("N")
            cboRDNMRdNmPre.Items.Add("S")
            cboRDNMRdNmPre.Items.Add("W")
            cboRDNMRdNmPre.Items.Add("NE")
            cboRDNMRdNmPre.Items.Add("NW")
            cboRDNMRdNmPre.Items.Add("SE")
            cboRDNMRdNmPre.Items.Add("SW")

            cboRDNMRdNmPstDir.Items.Add("")
            cboRDNMRdNmPstDir.Items.Add("E")
            cboRDNMRdNmPstDir.Items.Add("N")
            cboRDNMRdNmPstDir.Items.Add("S")
            cboRDNMRdNmPstDir.Items.Add("W")
            cboRDNMRdNmPstDir.Items.Add("NE")
            cboRDNMRdNmPstDir.Items.Add("NW")
            cboRDNMRdNmPstDir.Items.Add("SE")
            cboRDNMRdNmPstDir.Items.Add("SW")

            cboRDNMRdNmSuf.Items.Add("")
            cboRDNMRdNmSuf.Items.Add("ALY")
            cboRDNMRdNmSuf.Items.Add("ARC")
            cboRDNMRdNmSuf.Items.Add("AVE")
            cboRDNMRdNmSuf.Items.Add("BLVD")
            cboRDNMRdNmSuf.Items.Add("BP")
            cboRDNMRdNmSuf.Items.Add("BRG")
            cboRDNMRdNmSuf.Items.Add("BYP")
            cboRDNMRdNmSuf.Items.Add("CAPE")
            cboRDNMRdNmSuf.Items.Add("CIR")
            cboRDNMRdNmSuf.Items.Add("COURT")
            cboRDNMRdNmSuf.Items.Add("COVE")
            cboRDNMRdNmSuf.Items.Add("CRES")
            cboRDNMRdNmSuf.Items.Add("CSWY")
            cboRDNMRdNmSuf.Items.Add("CTE")
            cboRDNMRdNmSuf.Items.Add("DR")
            cboRDNMRdNmSuf.Items.Add("DRWY")
            cboRDNMRdNmSuf.Items.Add("EXP")
            cboRDNMRdNmSuf.Items.Add("EXTN")
            cboRDNMRdNmSuf.Items.Add("FRY")
            cboRDNMRdNmSuf.Items.Add("FWY")
            cboRDNMRdNmSuf.Items.Add("GLEN")
            cboRDNMRdNmSuf.Items.Add("HWY")
            cboRDNMRdNmSuf.Items.Add("INTR")
            cboRDNMRdNmSuf.Items.Add("LN")
            cboRDNMRdNmSuf.Items.Add("LOOP")
            cboRDNMRdNmSuf.Items.Add("MALL")
            cboRDNMRdNmSuf.Items.Add("PASS")
            cboRDNMRdNmSuf.Items.Add("PATH")
            cboRDNMRdNmSuf.Items.Add("PKY")
            cboRDNMRdNmSuf.Items.Add("PL")
            cboRDNMRdNmSuf.Items.Add("PLZ")
            cboRDNMRdNmSuf.Items.Add("PT")
            cboRDNMRdNmSuf.Items.Add("PTE")
            cboRDNMRdNmSuf.Items.Add("RAMP")
            cboRDNMRdNmSuf.Items.Add("RD")
            cboRDNMRdNmSuf.Items.Add("ROW")
            cboRDNMRdNmSuf.Items.Add("SQ")
            cboRDNMRdNmSuf.Items.Add("ST")
            cboRDNMRdNmSuf.Items.Add("TER")
            cboRDNMRdNmSuf.Items.Add("TKL")
            cboRDNMRdNmSuf.Items.Add("TRL")
            cboRDNMRdNmSuf.Items.Add("WALK")
            cboRDNMRdNmSuf.Items.Add("WAY")
            cboRDNMRdNmSuf.Items.Add("XING")

            cboRDNMRdNmJur.Items.Add("")
            cboRDNMRdNmJur.Items.Add("CB")
            cboRDNMRdNmJur.Items.Add("CN")
            cboRDNMRdNmJur.Items.Add("CO")
            cboRDNMRdNmJur.Items.Add("CV")
            cboRDNMRdNmJur.Items.Add("DM")
            cboRDNMRdNmJur.Items.Add("EC")
            cboRDNMRdNmJur.Items.Add("EN")
            cboRDNMRdNmJur.Items.Add("ES")
            cboRDNMRdNmJur.Items.Add("IB")
            cboRDNMRdNmJur.Items.Add("LG")
            cboRDNMRdNmJur.Items.Add("LM")
            cboRDNMRdNmJur.Items.Add("NC")
            cboRDNMRdNmJur.Items.Add("OC")
            cboRDNMRdNmJur.Items.Add("PW")
            cboRDNMRdNmJur.Items.Add("SD")
            cboRDNMRdNmJur.Items.Add("SM")
            cboRDNMRdNmJur.Items.Add("SO")
            cboRDNMRdNmJur.Items.Add("ST")
            cboRDNMRdNmJur.Items.Add("VS")

        Catch ex As Exception
            System.Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Buttons"

    Private Sub btnRDNMSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRDNMSave.Click
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Try
            If txtRDNMRdFll.Text = "" Then
                MessageBox.Show("You didn't update the standard road names, not saving")
                Exit Sub
            End If
            'First trim outer spaces
            txtRDNMRd20Pre.Text = txtRDNMRd20Pre.Text.Trim(" ")
            txtRDNMRd20Nm.Text = txtRDNMRd20Nm.Text.Trim(" ")
            txtRDNMRd20Suf.Text = txtRDNMRd20Suf.Text.Trim(" ")
            txtRDNMRd30Pre.Text = txtRDNMRd30Pre.Text.Trim(" ")
            txtRDNMRd30Nm.Text = txtRDNMRd30Nm.Text.Trim(" ")
            txtRDNMRd30Suf.Text = txtRDNMRd30Suf.Text.Trim(" ")
            txtRDNMRd30PstDir.Text = txtRDNMRd30PstDir.Text.Trim(" ")
            txtRDNMRdFll.Text = txtRDNMRdFll.Text.Trim(" ")
            'then trim inner spaces
            txtRDNMRd20Nm.Text = txtRDNMRd20Nm.Text.Replace("  ", " ")
            txtRDNMRd30Nm.Text = txtRDNMRd30Nm.Text.Replace("  ", " ")
            txtRDNMRdFll.Text = txtRDNMRdFll.Text.Replace("  ", " ")

            'then check field lengths
            Dim flderrmsg As String
            Dim flderr As Boolean
            flderr = False
            flderrmsg = ""
            If txtRDNMRd20Nm.Text.Length > 20 Then
                flderr = True
                flderrmsg = flderrmsg & "RD20 NAME over 20 Characters" & vbNewLine
            End If
            If txtRDNMRd30Nm.Text.Length > 30 Then
                flderr = True
                flderrmsg = flderrmsg & "RD30 NAME over 30 Characters" & vbNewLine
            End If
            If txtRDNMRdFll.Text.Length > 50 Then
                flderr = True
                flderrmsg = flderrmsg & "RD FULL NAME over 50 Characters" & vbNewLine
            End If
            If txtRDNMRdNm.Text.Length < 1 Then
                flderr = True
                flderrmsg = flderrmsg & "ROAD NAME is Empty" & vbNewLine
            End If
            If (ckbxRDNMSearch.Checked Or ckbxRDNameSearch.Checked) And txtRDNMRoadID.Text = "" Then
                flderr = True
                flderrmsg = flderrmsg & "Update Roadname Checked, but no existing ROADID is selected" & vbNewLine
            End If
            If txtRDNMTomBro.Text <> "" Then
                Dim ptmpchktb As String
                ptmpchktb = txtRDNMTomBro.Text
                'replace any spaces with characters so they will get caught in the isnumberic check
                ptmpchktb = Replace(ptmpchktb, " ", "_")
                If ptmpchktb.Length = 6 Then
                    If Not IsNumeric(ptmpchktb.Substring(0, 4)) Then
                        flderr = True
                        flderrmsg = flderrmsg & "Thomas Brother field has invalid format: <####><Grid A-Z><Grid 1-9>" & vbNewLine
                    ElseIf Not IsNumeric(ptmpchktb.Substring(5, 1)) Then
                        flderr = True
                        flderrmsg = flderrmsg & "Thomas Brother field has invalid format: <####><Grid A-Z><Grid 1-9>" & vbNewLine
                    End If
                Else
                    flderr = True
                    flderrmsg = flderrmsg & "Thomas Brother field has invalid format: <####><Grid A-Z><Grid 1-9>" & vbNewLine
                End If
            End If
            If flderr Then
                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                flderrmsg = flderrmsg & "Please modify the entries and try to save again"
                MsgBox(flderrmsg, MsgBoxStyle.Critical, "EDITS NOT SAVED")
                Exit Sub
            End If

            Dim psvRow As IRow
            If (ckbxRDNMSearch.Checked Or ckbxRDNameSearch.Checked) Then
                Dim psvQF As IQueryFilter
                Dim psvRDID As Integer
                Dim psvCur As ICursor
                psvRDID = txtRDNMRoadID.Text
                psvQF = New QueryFilter
                psvQF.WhereClause = "ROAD_ID = " & psvRDID
                psvCur = m_pRDTable.Search(psvQF, False) 'changed this one
                psvRow = psvCur.NextRow
            Else
                Dim pchkname As String
                Dim pchkQF As IQueryFilter
                Dim pchkSS As ISelectionSet
                Dim pchkcnt As Integer
                pchkname = txtRDNMRdFll.Text
                pchkQF = New QueryFilter
                pchkQF.WhereClause = "FULL_NAME = '" & pchkname & "'"
                pchkSS = m_pRDTable.Select(pchkQF, esriSelectionType.esriSelectionTypeIDSet, esriSelectionOption.esriSelectionOptionNormal, Nothing)
                pchkcnt = pchkSS.Count
                pchkSS = Nothing
                If pchkcnt > 0 Then
                    Dim pmsgresult As MsgBoxResult
                    pmsgresult = MsgBox("Road Name: " & pchkname & "already exists in T.RoadName." & vbNewLine & "Would you like to continue to add a new record/roadid for this Road Name?", MsgBoxStyle.YesNo, "ROADNAME EXISTS")
                    If pmsgresult = MsgBoxResult.No Then
                        MsgBox("Did not create new record/roadid for road name: " & pchkname & vbNewLine & "Clearing Form")
                        btnRDNMReset.PerformClick()
                        Exit Sub
                    End If
                End If
                psvRow = m_pRDTable.CreateRow
            End If

            If Not psvRow Is Nothing Then
                'Key fields do not get calced

                'Changablefields
                If Not IsDBNull(cboRDNMRdNmPre.Text) And Not cboRDNMRdNmPre.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_RD30PREDIR_FLD_NAME)) = cboRDNMRdNmPre.Text
                End If
                If Not IsDBNull(txtRDNMRdNm.Text) And Not txtRDNMRdNm.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_RD30NAME_FLD_NAME)) = txtRDNMRdNm.Text
                End If
                If Not IsDBNull(cboRDNMRdNmSuf.Text) And Not cboRDNMRdNmSuf.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_RD30SUFFIX_FLD_NAME)) = cboRDNMRdNmSuf.Text
                End If
                If Not IsDBNull(cboRDNMRdNmPstDir.Text) And Not cboRDNMRdNmPstDir.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_RD30POSTDIR_FLD_NAME)) = cboRDNMRdNmPstDir.Text
                End If
                If Not IsDBNull(cboRDNMRdNmJur.Text) And Not cboRDNMRdNmJur.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_RESERVEJUR_FLD_NAME)) = cboRDNMRdNmJur.Text
                End If
                'Standardized Fields
                If Not IsDBNull(txtRDNMRd20Pre.Text) And Not txtRDNMRd20Pre.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_RD20PREDIR_FLD_NAME)) = txtRDNMRd20Pre.Text
                End If
                If Not IsDBNull(txtRDNMRd20Nm.Text) And Not txtRDNMRd20Nm.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_RD20NAME_FLD_NAME)) = txtRDNMRd20Nm.Text
                End If
                If Not IsDBNull(txtRDNMRd20Suf.Text) And Not txtRDNMRd20Suf.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_RD20SUFFIX_FLD_NAME)) = txtRDNMRd20Suf.Text
                End If
                If Not IsDBNull(txtRDNMRd30Pre.Text) And Not txtRDNMRd30Pre.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_RD30PREDIR_FLD_NAME)) = txtRDNMRd30Pre.Text
                End If
                If Not IsDBNull(txtRDNMRd30Nm.Text) And Not txtRDNMRd30Nm.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_RD30NAME_FLD_NAME)) = txtRDNMRd30Nm.Text
                End If
                If Not IsDBNull(txtRDNMRd30Suf.Text) And Not txtRDNMRd30Suf.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_RD30SUFFIX_FLD_NAME)) = txtRDNMRd30Suf.Text
                End If
                If Not IsDBNull(txtRDNMRd30PstDir.Text) And Not txtRDNMRd30PstDir.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_RD30POSTDIR_FLD_NAME)) = txtRDNMRd30PstDir.Text
                End If
                If Not IsDBNull(txtRDNMRdFll.Text) And Not txtRDNMRdFll.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_FULLNAME_FLD_NAME)) = txtRDNMRdFll.Text
                End If
                'mapfields
                If Not IsDBNull(txtRDNMReqBy.Text) And Not txtRDNMReqBy.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_RESERVEBYNM_FLD_NAME)) = txtRDNMReqBy.Text
                End If
                If Not IsDBNull(txtRDNMTentMap.Text) And Not txtRDNMTentMap.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_RESERVETENTMAP_FLD_NAME)) = txtRDNMTentMap.Text
                End If
                If Not IsDBNull(txtRDNMTomBro.Text) And Not txtRDNMTomBro.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_RESERVETOMBRO_NAME)) = txtRDNMTomBro.Text
                End If
                If Not IsDBNull(txtRDNMWkOrder.Text) And Not txtRDNMWkOrder.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_WORKORDERNUM_FLD_NAME)) = txtRDNMWkOrder.Text
                End If
                If Not IsDBNull(cboRDNMMultiJur.Text) And Not cboRDNMMultiJur.Text Is Nothing Then
                    psvRow.Value(psvRow.Fields.FindField(ROADNM_MULTIJUR_FLD_NAME)) = cboRDNMMultiJur.Text
                End If
                psvRow.Store()
            End If
            System.Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            If ckbxRDNMSearch.Checked Or ckbxRDNameSearch.Checked Then
                txtRDNMPstDate.Text = psvRow.Value(psvRow.Fields.FindField(ROADNM_POSTDATE_FLD_NAME))
                txtRDNMPstID.Text = psvRow.Value(psvRow.Fields.FindField(ROADNM_POSTOPERATOR_FLD_NAME))
                MsgBox("Updated: " & txtRDNMRdFll.Text)
            Else
                Dim pnewroadid As Integer
                pnewroadid = psvRow.Value(psvRow.Fields.FindField("ROAD_ID"))
                txtRDNMRoadID.Text = pnewroadid
                txtRDNMPstDate.Text = psvRow.Value(psvRow.Fields.FindField(ROADNM_POSTDATE_FLD_NAME))
                txtRDNMPstID.Text = psvRow.Value(psvRow.Fields.FindField(ROADNM_POSTOPERATOR_FLD_NAME))
                MsgBox("Added: " & txtRDNMRdFll.Text & vbNewLine & "With new RoadID of: " & pnewroadid)
            End If
            btnRDNMReset.PerformClick()
        Catch ex As Exception
            System.Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnRDNMClearStandard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRDNMClearStandard.Click
        ClearFormFields(False, True, False)
    End Sub

    Private Sub btnRDNMClearRoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRDNMResetStnd.Click
        Try
            ClearFormFields(False, True, False)
            m_Rd20 = ""
            m_Rd30 = ""
            m_RdFull = ""
            m_Rd20Sfx = ""
            m_Rd30Sfx = ""
            m_RdFullSfx = ""

            StandardizeRoadName(txtRDNMRdNm.Text)
            StandardizeSuffix(cboRDNMRdNmSuf.Text)
            txtRDNMRd20Nm.Text = m_Rd20
            txtRDNMRd20Pre.Text = cboRDNMRdNmPre.Text
            txtRDNMRd20Suf.Text = m_Rd20Sfx
            txtRDNMRd30Nm.Text = m_Rd30
            txtRDNMRd30Pre.Text = cboRDNMRdNmPre.Text
            txtRDNMRd30Suf.Text = m_Rd30Sfx
            txtRDNMRd30PstDir.Text = cboRDNMRdNmPstDir.Text
            'Build Full Name
            Dim prdfullbuild As String
            prdfullbuild = ""
            If cboRDNMRdNmPre.Text <> "" Then
                prdfullbuild = GetFullDir("full", cboRDNMRdNmPre.Text) & " "
            End If
            If txtRDNMRdNm.Text <> "" Then
                prdfullbuild = prdfullbuild & m_RdFull & " "
            End If
            If cboRDNMRdNmSuf.Text <> "" Then
                prdfullbuild = prdfullbuild & m_RdFullSfx & " "
            End If
            If cboRDNMRdNmPstDir.Text <> "" Then
                prdfullbuild = prdfullbuild & GetFullDir("full", cboRDNMRdNmPstDir.Text)
            End If
            prdfullbuild = CleanRdName(prdfullbuild)
            txtRDNMRdFll.Text = prdfullbuild
        Catch ex As Exception
            System.Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnRDNMExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRDNMExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnRDNMReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRDNMReset.Click
        Try
            ClearFormFields(True, True, True)
            ckbxRDNMSearch.Checked = False
            ckbxRDNameSearch.Checked = False
            cboRDNMRdNmPre.Focus()
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Custom"

    Private Sub ClearFormFields(ByVal ARdIDSection As Boolean, ByVal BStandardSection As Boolean, ByVal CMapSection As Boolean)
        Try
            If ARdIDSection Then
                txtRDNMRoadID.Text = ""
                txtRDNMPstDate.Text = ""
                txtRDNMPstID.Text = ""
                txtRDNMRdNm.Text = ""
                cboRDNMRdNmJur.Text = ""
                cboRDNMRdNmPre.Text = ""
                cboRDNMRdNmSuf.Text = ""
                cboRDNMRdNmPstDir.Text = ""
            End If
            If BStandardSection Then
                txtRDNMRd20Nm.Text = ""
                txtRDNMRd20Pre.Text = ""
                txtRDNMRd20Suf.Text = ""
                txtRDNMRd30Nm.Text = ""
                txtRDNMRd30Pre.Text = ""
                txtRDNMRd30Suf.Text = ""
                txtRDNMRd30PstDir.Text = ""
                txtRDNMRdFll.Text = ""
            End If
            If CMapSection Then
                txtRDNMReqBy.Text = ""
                txtRDNMTentMap.Text = ""
                txtRDNMTomBro.Text = ""
                txtRDNMWkOrder.Text = ""
                cboRDNMMultiJur.Text = ""
            End If
        Catch ex As Exception
            System.Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Sub GetRDInfo(ByVal RDID As Long)
        Try
            ClearFormFields(True, True, True)
            Dim pQueryfilter As IQueryFilter
            Dim pRDID As Integer
            Dim prdCur As ICursor
            Dim prdRow As IRow

            pRDID = RDID

            pQueryfilter = New QueryFilter
            pQueryfilter.WhereClause = "ROAD_ID = " & pRDID
            prdCur = m_pRDTable.Search(pQueryfilter, False) 'changed this one
            prdRow = prdCur.NextRow
            If Not prdRow Is Nothing Then
                'Key fields
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_POSTDATE_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_POSTDATE_FLD_NAME)) Is Nothing Then
                    txtRDNMPstDate.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_POSTDATE_FLD_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_POSTOPERATOR_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_POSTOPERATOR_FLD_NAME)) Is Nothing Then
                    txtRDNMPstID.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_POSTOPERATOR_FLD_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(RDNAME_ROADID_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(RDNAME_ROADID_FLD_NAME)) Is Nothing Then
                    txtRDNMRoadID.Text = prdRow.Value(prdRow.Fields.FindField(RDNAME_ROADID_FLD_NAME))
                End If
                'Changablefields
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30PREDIR_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30PREDIR_FLD_NAME)) Is Nothing Then
                    cboRDNMRdNmPre.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30PREDIR_FLD_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30NAME_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30NAME_FLD_NAME)) Is Nothing Then
                    txtRDNMRdNm.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30NAME_FLD_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30SUFFIX_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30SUFFIX_FLD_NAME)) Is Nothing Then
                    cboRDNMRdNmSuf.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30SUFFIX_FLD_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30POSTDIR_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30POSTDIR_FLD_NAME)) Is Nothing Then
                    cboRDNMRdNmPstDir.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30POSTDIR_FLD_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_RESERVEJUR_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_RESERVEJUR_FLD_NAME)) Is Nothing Then
                    cboRDNMRdNmJur.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_RESERVEJUR_FLD_NAME))
                End If
                'Standardized Fields
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_RD20PREDIR_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_RD20PREDIR_FLD_NAME)) Is Nothing Then
                    txtRDNMRd20Pre.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_RD20PREDIR_FLD_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_RD20NAME_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_RD20NAME_FLD_NAME)) Is Nothing Then
                    txtRDNMRd20Nm.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_RD20NAME_FLD_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_RD20SUFFIX_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_RD20SUFFIX_FLD_NAME)) Is Nothing Then
                    txtRDNMRd20Suf.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_RD20SUFFIX_FLD_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30PREDIR_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30PREDIR_FLD_NAME)) Is Nothing Then
                    txtRDNMRd30Pre.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30PREDIR_FLD_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30NAME_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30NAME_FLD_NAME)) Is Nothing Then
                    txtRDNMRd30Nm.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30NAME_FLD_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30SUFFIX_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30SUFFIX_FLD_NAME)) Is Nothing Then
                    txtRDNMRd30Suf.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30SUFFIX_FLD_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30POSTDIR_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30POSTDIR_FLD_NAME)) Is Nothing Then
                    txtRDNMRd30PstDir.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_RD30POSTDIR_FLD_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_NAME_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_NAME_FLD_NAME)) Is Nothing Then
                    txtRDNMRdFll.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_FULLNAME_FLD_NAME))
                End If
                'mapfields
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_RESERVEBYNM_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_RESERVEBYNM_FLD_NAME)) Is Nothing Then
                    txtRDNMReqBy.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_RESERVEBYNM_FLD_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_RESERVETENTMAP_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_RESERVETENTMAP_FLD_NAME)) Is Nothing Then
                    txtRDNMTentMap.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_RESERVETENTMAP_FLD_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_RESERVETOMBRO_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_RESERVETOMBRO_NAME)) Is Nothing Then
                    txtRDNMTomBro.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_RESERVETOMBRO_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_WORKORDERNUM_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_WORKORDERNUM_FLD_NAME)) Is Nothing Then
                    txtRDNMWkOrder.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_WORKORDERNUM_FLD_NAME))
                End If
                If Not IsDBNull(prdRow.Value(prdRow.Fields.FindField(ROADNM_MULTIJUR_FLD_NAME))) And Not prdRow.Value(prdRow.Fields.FindField(ROADNM_MULTIJUR_FLD_NAME)) Is Nothing Then
                    cboRDNMMultiJur.Text = prdRow.Value(prdRow.Fields.FindField(ROADNM_MULTIJUR_FLD_NAME))
                End If
                btnDeleteRDNM.Enabled = True
            Else
                btnDeleteRDNM.Enabled = False
            End If

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Function GetFullDir(ByVal pWhichfield As String, ByVal ptxttochange As String) As String 'inputs are rd20 or full
        GetFullDir = ""
        Dim pA As String
        Dim pB As String
        Dim prd30suf As String
        Try
            prd30suf = ptxttochange
            If prd30suf = ("E") Then
                pA = "EAST"
                pB = "EAST"
            ElseIf prd30suf = ("W") Then
                pA = "WEST"
                pB = "WEST"
            ElseIf prd30suf = ("N") Then
                pA = "NORTH"
                pB = "NORTH"
            ElseIf prd30suf = ("S") Then
                pA = "SOUTH"
                pB = "SOUTH"
            ElseIf prd30suf = ("NE") Then
                pA = "NORTHEAST"
                pB = "NORTHEAST"
            ElseIf prd30suf = ("NW") Then
                pA = "NORTHWEST"
                pB = "NORTHWEST"
            ElseIf prd30suf = ("SE") Then
                pA = "SOUTHEAST"
                pB = "SOUTHEAST"
            ElseIf prd30suf = ("SW") Then
                pA = "SOUTHWEST"
                pB = "SOUTHWEST"
            Else
                pA = ""
                pB = ""
            End If
            If pWhichfield = "rd20" Then
                GetFullDir = pA
            ElseIf pWhichfield = "full" Then
                GetFullDir = pB
            Else : GetFullDir = ""
            End If
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Function

    Private Sub StandardizeRoadName(ByVal NmRough As String)
        Try
            m_Rd20 = ""
            m_Rd30 = ""
            m_RdFull = ""

            'Break up the name
            Dim pnmRemain As String
            Dim pnmPart As New Collection
            Dim prdpartcnt As Integer
            Dim prdprt_QF As IQueryFilter
            prdprt_QF = New QueryFilter
            Dim prdprtCur As ICursor
            Dim prdprtRow As IRow

            'Prep the name 
            pnmRemain = CleanRdName(NmRough)
            'First see if entire name is in list (such as a state rd)
            prdprt_QF.WhereClause = "STD_TBL_SYNONYM_NM = '" & pnmRemain & "'"
            prdprtCur = m_pRDSTDTable.Search(prdprt_QF, False) 'changed this one
            prdprtRow = prdprtCur.NextRow()
            If Not prdprtRow Is Nothing Then
                m_Rd20 = prdprtRow.Value(prdprtRow.Fields.FindField("ROAD20_VALUE_NM"))
                m_Rd30 = prdprtRow.Value(prdprtRow.Fields.FindField("ROAD30_VALUE_NM"))
                m_RdFull = prdprtRow.Value(prdprtRow.Fields.FindField("NON_ABBREVIATED_NM"))
            Else
                prdprtCur = Nothing
                prdprtRow = Nothing
                While InStr(pnmRemain, " ") > 0
                    pnmPart.Add(pnmRemain.Substring(0, InStr(pnmRemain, " ") - 1))
                    pnmRemain = pnmRemain.Substring(InStr(pnmRemain, " "))
                End While
                pnmPart.Add(pnmRemain)

                For prdpartcnt = 1 To pnmPart.Count
                    prdprt_QF.WhereClause = "STD_TBL_SYNONYM_NM = '" & pnmPart(prdpartcnt) & "' AND SYNONYM_TYPE_CD <> '3'"
                    prdprtCur = m_pRDSTDTable.Search(prdprt_QF, False) 'changed this one
                    prdprtRow = prdprtCur.NextRow()
                    If Not prdprtRow Is Nothing Then
                        m_Rd20 = m_Rd20 & " " & prdprtRow.Value(prdprtRow.Fields.FindField("ROAD20_VALUE_NM"))
                        m_Rd30 = m_Rd30 & " " & prdprtRow.Value(prdprtRow.Fields.FindField("ROAD30_VALUE_NM"))
                        m_RdFull = m_RdFull & " " & prdprtRow.Value(prdprtRow.Fields.FindField("NON_ABBREVIATED_NM"))
                    Else
                        m_Rd20 = m_Rd20 & " " & pnmPart(prdpartcnt)
                        m_Rd30 = m_Rd30 & " " & pnmPart(prdpartcnt)
                        m_RdFull = m_RdFull & " " & pnmPart(prdpartcnt)
                    End If
                Next
            End If
            m_Rd20 = CleanRdName(m_Rd20)
            m_Rd30 = CleanRdName(m_Rd30)
            m_RdFull = CleanRdName(m_RdFull)
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub StandardizeSuffix(ByVal SfxRough As String)
        Try
            m_Rd20Sfx = ""
            m_Rd30Sfx = ""
            m_RdFullSfx = ""

            Dim prdsfx_QF As IQueryFilter
            prdsfx_QF = New QueryFilter
            Dim prdsfxCur As ICursor
            Dim prdsfxRow As IRow
            Dim psfxRemain As String

            'Prep the name 
            psfxRemain = CleanRdName(SfxRough)
            prdsfx_QF.WhereClause = "STD_TBL_SYNONYM_NM = '" & psfxRemain & "' AND SYNONYM_TYPE_CD = '3'"
            prdsfxCur = m_pRDSTDTable.Search(prdsfx_QF, False) 'changed this one
            prdsfxRow = prdsfxCur.NextRow()
            If Not prdsfxRow Is Nothing Then
                m_Rd20Sfx = prdsfxRow.Value(prdsfxRow.Fields.FindField("ROAD20_VALUE_NM"))
                m_Rd30Sfx = prdsfxRow.Value(prdsfxRow.Fields.FindField("ROAD30_VALUE_NM"))
                m_RdFullSfx = prdsfxRow.Value(prdsfxRow.Fields.FindField("NON_ABBREVIATED_NM"))
            Else
                prdsfxRow = Nothing
                prdsfxRow = Nothing
                m_Rd20Sfx = SfxRough
                m_Rd30Sfx = SfxRough
                m_RdFullSfx = SfxRough
            End If
            m_Rd20Sfx = CleanRdName(m_Rd20Sfx)
            m_Rd30Sfx = CleanRdName(m_Rd30Sfx)
            m_RdFullSfx = CleanRdName(m_RdFullSfx)
        Catch ex As Exception
            System.Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Public Function CleanRdName(ByVal RdToCln As String) As String
        CleanRdName = LTrim(RTrim(RdToCln))
        CleanRdName = Replace(CleanRdName, ".", " ")
        CleanRdName = Replace(CleanRdName, "  ", " ")
    End Function

#End Region

#Region "Check Boxes and Data Grids"

    Private Sub ckbxRDNMSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbxRDNMSearch.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Try
                If Not ckbxRDNMSearch.Checked Then
                    cboRDNMSelectName.Items.Clear()
                    cboRDNMSelectName.SelectedText = ""
                    cboRDNMSelectName.Text = ""
                    cboRDNMSelectName.Enabled = False
                    ckbxRDNMSearch.ForeColor = Drawing.Color.Black
                    ckbxRDNMSearch.Text = "Search by Road ID"
                    btnRDNMSave.Text = "Add RoadName"
                    'clear out the form fields
                    ClearFormFields(True, True, False)
                    cboRDNMRdNmPre.Focus()
                Else
                    If ckbxRDNameSearch.Checked Then
                        ckbxRDNameSearch.Checked = False
                    End If
                    cboRDNMSelectName.Enabled = True
                    ckbxRDNMSearch.ForeColor = Drawing.Color.Red
                    ckbxRDNMSearch.Text = "UN-Check to ADD NEW Road Name"
                    btnRDNMSave.Text = "Save Updates"
                    'Fill it
                    Dim pCur As ICursor, pRow As IRow, lIdx As Long, lIdx2 As Long
                    lIdx = m_pRDTable.Fields.FindField("FULL_NAME")
                    lIdx2 = m_pRDTable.Fields.FindField("ROAD_ID")

                    ''add a queryfilter and queryfilterdefinition for sorting
                    Dim pQF As IQueryFilter
                    pQF = New QueryFilter
                    Dim pQFDef As IQueryFilterDefinition
                    pQFDef = pQF
                    pQFDef.PostfixClause = "order by ROAD_ID desc"
                    pCur = m_pRDTable.Search(pQF, False) 'changed this one
                    pRow = pCur.NextRow
                    'Build the combobox
                    Me.cboRDNMSelectName.Items.Add("ROAD ID / ROAD NAME")
                    Me.cboRDNMSelectName.Items.Add("")
                    Do While Not pRow Is Nothing
                        Me.cboRDNMSelectName.Items.Add(pRow.Value(lIdx2) & " / " & pRow.Value(lIdx))
                        pRow = pCur.NextRow
                    Loop
                    'display the 1st item
                    If Me.cboRDNMSelectName.Items.Count > 0 Then Me.cboRDNMSelectName.SelectedIndex = 0
                    System.Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                    cboRDNMSelectName.Focus()
                End If
            Catch ex As Exception
                System.Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub ckbxRDNameSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbxRDNameSearch.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Try
                If Not ckbxRDNameSearch.Checked Then
                    cboRDNMSelectName.Items.Clear()
                    cboRDNMSelectName.SelectedText = ""
                    cboRDNMSelectName.Text = ""
                    cboRDNMSelectName.Enabled = False
                    ckbxRDNameSearch.ForeColor = Drawing.Color.Black
                    ckbxRDNameSearch.Text = "Search by Road Name"
                    btnRDNMSave.Text = "Add RoadName"
                    'clear out the form fields
                    ClearFormFields(True, True, False)
                    cboRDNMRdNmPre.Focus()
                Else
                    If ckbxRDNMSearch.Checked Then
                        ckbxRDNMSearch.Checked = False
                    End If
                    cboRDNMSelectName.Enabled = True
                    ckbxRDNameSearch.ForeColor = Drawing.Color.Red
                    ckbxRDNameSearch.Text = "UN-Check to ADD NEW Road Name"
                    btnRDNMSave.Text = "Save Updates"
                    'Fill it
                    Dim pCur As ICursor, pRow As IRow, lIdx As Long, lIdx2 As Long
                    lIdx = m_pRDTable.Fields.FindField("FULL_NAME")
                    lIdx2 = m_pRDTable.Fields.FindField("ROAD_ID")

                    ''add a queryfilter and queryfilterdefinition for sorting
                    Dim pQF As IQueryFilter
                    pQF = New QueryFilter
                    Dim pQFDef As IQueryFilterDefinition
                    pQFDef = pQF
                    pQFDef.PostfixClause = "order by FULL_NAME"
                    pCur = m_pRDTable.Search(pQF, False) 'changed this one
                    pRow = pCur.NextRow
                    'Build the combobox
                    Me.cboRDNMSelectName.Items.Add("ROAD NAME / ROAD ID")
                    Me.cboRDNMSelectName.Items.Add("")
                    Do While Not pRow Is Nothing
                        Me.cboRDNMSelectName.Items.Add(pRow.Value(lIdx) & " / " & pRow.Value(lIdx2))
                        pRow = pCur.NextRow
                    Loop
                    'display the 1st item
                    If Me.cboRDNMSelectName.Items.Count > 0 Then Me.cboRDNMSelectName.SelectedIndex = 0
                    Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                    cboRDNMSelectName.Focus()
                End If
            Catch ex As Exception
                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

#End Region

#Region "Combo Box"

    Private Sub cboRDNMSelectName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRDNMSelectName.SelectedIndexChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Try
                If cboRDNMSelectName.SelectedIndex <> 0 Then  'to skip the initial load

                    Dim pRDID As Long
                    Dim pRDIDLOC As Integer
                    Dim tmpRDTEXT As String
                    Dim pRDNMTXTlen As Integer
                    tmpRDTEXT = cboRDNMSelectName.Text
                    pRDNMTXTlen = tmpRDTEXT.Length
                    pRDIDLOC = tmpRDTEXT.IndexOf("/") - 1
                    If ckbxRDNMSearch.Checked Then
                        If pRDIDLOC <= 0 Then
                            MsgBox("NO ROAD ID found.  Choose a different Road Name Record or use Name search")
                            Exit Sub
                        End If
                        pRDID = tmpRDTEXT.Substring(0, pRDIDLOC)
                    ElseIf ckbxRDNameSearch.Checked Then
                        If pRDIDLOC <= 0 Then
                            MsgBox("NO ROAD NAME found.  Choose a different Road Name Record or use ID search")
                            Exit Sub
                        End If
                        pRDID = tmpRDTEXT.Substring(pRDIDLOC + 2)
                    End If
                    GetRDInfo(pRDID)
                End If
            Catch ex As Exception
                System.Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

#End Region

#Region "Text boxes"

    Private Sub txtRDNMRdNm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRDNMRdNm.KeyPress
        If e.KeyChar = vbTab Then
            cboRDNMRdNmSuf.Focus()
        End If
    End Sub

    Private Sub txtRDNMTentMap_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRDNMTentMap.KeyPress
        If e.KeyChar = vbTab Then
            txtRDNMReqBy.Focus()
        End If
    End Sub

    Private Sub txtRDNMReqBy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRDNMReqBy.KeyPress
        If e.KeyChar = vbTab Then
            cboRDNMMultiJur.Focus()
        End If
    End Sub

    Private Sub cboRDNMMultiJur_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRDNMMultiJur.KeyPress
        If e.KeyChar = vbTab Then
            txtRDNMTomBro.Focus()
        End If
    End Sub

    Private Sub txtRDNMTomBro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRDNMTomBro.KeyPress
        If e.KeyChar = vbTab Then
            txtRDNMWkOrder.Focus()
        End If
    End Sub

    Private Sub txtRDNMWkOrder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRDNMWkOrder.KeyPress
        If e.KeyChar = vbTab Then
            btnRDNMSave.Focus()
        End If
    End Sub

    Private Sub btnRDNMResetStnd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnRDNMResetStnd.KeyPress
        If e.KeyChar = vbTab Then
            txtRDNMTentMap.Focus()
        ElseIf e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnRDNMResetStnd.PerformClick()
        End If
    End Sub

    Private Sub txtRDNMRd20Pre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRDNMRd20Pre.KeyPress
        If e.KeyChar = vbTab Then
            txtRDNMRd20Nm.Focus()
        End If
    End Sub

    Private Sub txtRDNMRd30Nm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRDNMRd30Nm.KeyPress
        If e.KeyChar = vbTab Then
            txtRDNMRd30Suf.Focus()
        End If
    End Sub

    Private Sub txtRDNMRd30Suf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRDNMRd30Suf.KeyPress
        If e.KeyChar = vbTab Then
            txtRDNMRd30PstDir.Focus()
        End If
    End Sub

    Private Sub txtRDNMRd30PstDir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRDNMRd30PstDir.KeyPress
        If e.KeyChar = vbTab Then
            txtRDNMRd20Pre.Focus()
        End If
    End Sub

    Private Sub txtRDNMRd20Nm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRDNMRd20Nm.KeyPress
        If e.KeyChar = vbTab Then
            txtRDNMRd20Suf.Focus()
        End If
    End Sub

    Private Sub txtRDNMRd20Suf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRDNMRd20Suf.KeyPress
        If e.KeyChar = vbTab Then
            txtRDNMRdFll.Focus()
        End If
    End Sub

    Private Sub txtRDNMRdFll_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRDNMRdFll.KeyPress
        If e.KeyChar = vbTab Then
            txtRDNMTentMap.Focus()
        End If
    End Sub

    Private Sub txtRDNMRd30Pre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRDNMRd30Pre.KeyPress
        If e.KeyChar = vbTab Then
            txtRDNMRd30Nm.Focus()
        End If
    End Sub

    Private Sub txtKnwnRDID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKnwnRDID.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing

        ElseIf e.KeyChar = ChrW(Keys.Return) Then
            Dim pRDID As Long
            'if its empty do nothing
            If txtKnwnRDID.Text <> "" Then
                pRDID = txtKnwnRDID.Text
                GetRDInfo(pRDID)
            End If
        Else
            ' MsgBox(e.KeyChar)
            e.KeyChar = ChrW(0)
        End If
    End Sub

#End Region

#Region "Buttons"

    Private Sub btnRDNMSave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnRDNMSave.KeyPress
        If e.KeyChar = vbTab Then
            btnRDNMReset.Focus()
        ElseIf e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnRDNMSave.PerformClick()
        End If
    End Sub

    Private Sub btnRDNMReset_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnRDNMReset.KeyPress
        If e.KeyChar = vbTab Then
            btnRDNMExit.Focus()
        ElseIf e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnRDNMReset.PerformClick()
        End If
    End Sub

    Private Sub btnRDNMExit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnRDNMExit.KeyPress
        If e.KeyChar = vbTab Then
            cboRDNMRdNmPre.Focus()
        ElseIf e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnRDNMExit.PerformClick()
        End If
    End Sub

    Private Sub btnResetNoMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetNoMap.Click
        Try
            ClearFormFields(True, True, False)
            ckbxRDNMSearch.Checked = False
            ckbxRDNameSearch.Checked = False
            cboRDNMRdNmPre.Focus()
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnDeleteRDNM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteRDNM.Click
        If MessageBox.Show("Are you sure you want to delete this record?", "YOUR ARE ABOUT TO DELETE A ROADNAME", Windows.Forms.MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Try
                'check to see if roadname id is in use in the roadseg table
                Dim pRdFCTable As ITable
                pRdFCTable = GetWorkspaceTable(ROAD_DATASRC, m_ActiveView, ROAD_DATASRC, True)
                If pRdFCTable Is Nothing Then
                    MessageBox.Show("T.Road not found to verify RoadName ID isn't in use, exiting")
                    Exit Sub
                End If
                Dim rdidqf As IQueryFilter
                rdidqf = New QueryFilter
                Dim pSelSet As ISelectionSet
                Dim rdid As Long
                rdid = txtRDNMRoadID.Text
                rdidqf.WhereClause = "ROADID = " & rdid
                Dim pDataset As IDataset
                pDataset = m_pRDTable
                Dim wkspc As IWorkspace
                wkspc = pDataset.Workspace
                pSelSet = pRdFCTable.Select(rdidqf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, wkspc)
                If pSelSet.Count > 0 Then
                    MessageBox.Show("Can NOT delete RoadName.  It is being used by " & pSelSet.Count & " Road Segments", "WARNING", MessageBoxButtons.OK)
                    rdidqf = Nothing
                    pSelSet = Nothing
                    wkspc = Nothing
                Else
                    'go ahead and delete it
                    Dim pQF As IQueryFilter
                    pQF = New QueryFilter
                    Dim pGeoCursor As ICursor
                    Dim pGeoRow As IRow
                    Dim pWhereClse As String
                    pWhereClse = RDNAME_ROADID_FLD_NAME & " = " & rdid
                    pQF.WhereClause = pWhereClse




                    'If m_pRDTable.RowCount(pQF) > 1 Then
                    pGeoCursor = m_pRDTable.Update(pQF, False)
                    pGeoRow = pGeoCursor.NextRow
                    If Not pGeoRow Is Nothing Then
                        pGeoRow.Delete()
                        'pGeoRow.Store()
                        'MsgBox ("Deleted Road Name")
                        pGeoRow = Nothing
                        pGeoCursor = Nothing
                    End If
                    pGeoRow = Nothing
                    pGeoCursor = Nothing
                    btnRDNMReset.PerformClick()
                    'Else
                    'no roadname with that id, which would be wierd
                    'End If
                End If
                rdidqf = Nothing
                pSelSet = Nothing
                wkspc = Nothing

            Catch ex As Exception
                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        Else
            MessageBox.Show("Deletion Cancelled")
        End If
    End Sub

#End Region

    Private Sub txtKnwnRDID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKnwnRDID.TextChanged

    End Sub

    Private Sub Label26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label26.Click

    End Sub

    Private Sub Label25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label25.Click

    End Sub
End Class