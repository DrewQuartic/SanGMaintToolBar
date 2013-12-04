Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports SanGISMaintenanceToolbar.Globals
Public Class frmEditROSLog
    Dim m_pWKSP As IWorkspace
    Dim m_ActiveView As IActiveView
    Dim m_pROSTable As ITable
    Dim m_pWSE As IWorkspaceEdit
    Dim m_QueryStatus As Boolean = False
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

    Public Property pIsQuery() As Boolean
        Get
            Return m_QueryStatus
        End Get
        Set(ByVal vIsQuery As Boolean)
            m_QueryStatus = vIsQuery
            If vIsQuery Then
                btnROSLgSave.Enabled = False
                btnROSLgSave.Text = "QUERY ONLY MODE"
            End If
        End Set
    End Property

#End Region

#Region "Primaries Forms"

    Private Sub frmEditROSLog_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not pIsQuery And Not ItFailed Then
            Dim pDataset As IDataset
            pDataset = m_pROSTable
            m_pWSE = pDataset.Workspace
            If m_pWSE.IsBeingEdited Then
                m_pWSE.StopEditOperation()
                m_pWSE.StopEditing(True)
            End If
        End If

        m_ActiveView = Nothing
        m_pROSTable = Nothing
        m_pWKSP = Nothing
        m_pWSE = Nothing

    End Sub

    Private Sub frmEditROSLog_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F1 Then
            btnROSLgReset.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.F8 Then
            If ckbxROSLgSearch.Checked Then
                ckbxROSLgSearch.Checked = False
            Else
                ckbxROSLgSearch.Checked = True
            End If
        ElseIf e.KeyCode = Windows.Forms.Keys.F10 Then
            If Not pIsQuery Then
                btnROSLgSave.PerformClick()
            End If
        ElseIf e.KeyCode = Windows.Forms.Keys.F12 Then
            btnROSLgExit.PerformClick()
        End If
    End Sub

    Private Sub frmEditROSLog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            'Check if the user has edit privs on tables first  
            ItFailed = False
            If Not pIsQuery Then
                If CheckifEditable("ANY", FrmMap) Then
                    'ok to edit
                Else
                    MsgBox("You do not have the privileges to edit this version.")
                    ItFailed = True
                    Me.Close()
                End If
            End If

            'Load the tables
            Dim pTableSourcename As String
            pTableSourcename = LOG_ROS_DATASRC
            m_pROSTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename, pIsQuery)
            If m_pROSTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If

            'Fill the combos
            cboROSJur.Items.Add("")
            cboROSJur.Items.Add("CB")
            cboROSJur.Items.Add("CN")
            cboROSJur.Items.Add("CO")
            cboROSJur.Items.Add("CV")
            cboROSJur.Items.Add("DM")
            cboROSJur.Items.Add("EC")
            cboROSJur.Items.Add("EN")
            cboROSJur.Items.Add("ES")
            cboROSJur.Items.Add("IB")
            cboROSJur.Items.Add("LG")
            cboROSJur.Items.Add("LM")
            cboROSJur.Items.Add("NC")
            cboROSJur.Items.Add("OC")
            cboROSJur.Items.Add("PW")
            cboROSJur.Items.Add("SD")
            cboROSJur.Items.Add("SM")
            cboROSJur.Items.Add("SO")
            cboROSJur.Items.Add("ST")
            cboROSJur.Items.Add("VS")

            cboROSBsheet.Items.Add("Y")
            cboROSBsheet.Items.Add("N")
            cboROSBsheet.SelectedIndex = 0


            cboROSNad.Items.Add("27")
            cboROSNad.Items.Add("83")

        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Custom"

    Public Sub ClearFormFields()
        Try
            txtROSAssrBook.Text = ""
            txtROSCalCoord.Text = ""
            txtROSLocation.Text = ""
            txtROSMapnum.Text = ""
            txtROSNumShts.Text = ""
            cboROSBsheet.SelectedIndex = 0
            cboROSJur.Text = ""
            cboROSNad.Text = ""
            dtROSDocDate.Text = ""
            dtROSDocDate.Checked = False
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try


    End Sub

    Public Sub PopulateForm(ByVal pMapID As String)
        Try
                Dim pQueryfilter As IQueryFilter
                'ctlg
                Dim prlCur As ICursor
                Dim prlRow As IRow

                pQueryfilter = New QueryFilter
            pQueryfilter.WhereClause = "MAPNUM = '" & pMapID & "'"
                'CUT TABLE
                prlCur = m_pROSTable.Search(pQueryfilter, False) 'changed this one
                prlRow = prlCur.NextRow

                If Not prlRow Is Nothing Then
                    If Not IsDBNull(prlRow.Value(prlRow.Fields.FindField(ROSLG_MAPNUM_FLD_NAME))) And Not prlRow.Value(prlRow.Fields.FindField(ROSLG_MAPNUM_FLD_NAME)) Is Nothing Then
                        txtROSMapnum.Text = prlRow.Value(prlRow.Fields.FindField(ROSLG_MAPNUM_FLD_NAME))
                    End If
                    If Not IsDBNull(prlRow.Value(prlRow.Fields.FindField(ROSLG_LOCATION_FLD_NAME))) And Not prlRow.Value(prlRow.Fields.FindField(ROSLG_LOCATION_FLD_NAME)) Is Nothing Then
                        txtROSLocation.Text = prlRow.Value(prlRow.Fields.FindField(ROSLG_LOCATION_FLD_NAME))
                    End If
                    If Not IsDBNull(prlRow.Value(prlRow.Fields.FindField(ROSLG_NAD_FLD_NAME))) And Not prlRow.Value(prlRow.Fields.FindField(ROSLG_NAD_FLD_NAME)) Is Nothing Then
                        cboROSNad.Text = prlRow.Value(prlRow.Fields.FindField(ROSLG_NAD_FLD_NAME))
                    End If
                    If Not IsDBNull(prlRow.Value(prlRow.Fields.FindField(ROSLG_JUR_FLD_NAME))) And Not prlRow.Value(prlRow.Fields.FindField(ROSLG_JUR_FLD_NAME)) Is Nothing Then
                        cboROSJur.Text = prlRow.Value(prlRow.Fields.FindField(ROSLG_JUR_FLD_NAME))
                    End If
                    If Not IsDBNull(prlRow.Value(prlRow.Fields.FindField(ROSLG_BSHEET_FLD_NAME))) And Not prlRow.Value(prlRow.Fields.FindField(ROSLG_BSHEET_FLD_NAME)) Is Nothing Then
                        cboROSBsheet.Text = prlRow.Value(prlRow.Fields.FindField(ROSLG_BSHEET_FLD_NAME))
                    End If
                    If Not IsDBNull(prlRow.Value(prlRow.Fields.FindField(ROSLG_DOCDATE_FLD_NAME))) And Not prlRow.Value(prlRow.Fields.FindField(ROSLG_DOCDATE_FLD_NAME)) Is Nothing Then
                        dtROSDocDate.Text = prlRow.Value(prlRow.Fields.FindField(ROSLG_DOCDATE_FLD_NAME))
                    End If

                    If Not IsDBNull(prlRow.Value(prlRow.Fields.FindField(ROSLG_ASSRBOOK_FLD_NAME))) And Not prlRow.Value(prlRow.Fields.FindField(ROSLG_ASSRBOOK_FLD_NAME)) Is Nothing Then
                        txtROSAssrBook.Text = prlRow.Value(prlRow.Fields.FindField(ROSLG_ASSRBOOK_FLD_NAME))
                    End If
                    If Not IsDBNull(prlRow.Value(prlRow.Fields.FindField(ROSLG_NUMSHTS_FLD_NAME))) And Not prlRow.Value(prlRow.Fields.FindField(ROSLG_NUMSHTS_FLD_NAME)) Is Nothing Then
                        txtROSNumShts.Text = prlRow.Value(prlRow.Fields.FindField(ROSLG_NUMSHTS_FLD_NAME))
                    End If
                    If Not IsDBNull(prlRow.Value(prlRow.Fields.FindField(ROSLG_CALCOORD_FLD_NAME))) And Not prlRow.Value(prlRow.Fields.FindField(ROSLG_CALCOORD_FLD_NAME)) Is Nothing Then
                        txtROSCalCoord.Text = prlRow.Value(prlRow.Fields.FindField(ROSLG_CALCOORD_FLD_NAME))
                    End If
                End If

        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Buttons"

    Private Sub btnROSLgReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnROSLgReset.Click
        Try
            txtKnwnNum.Text = ""
            ClearFormFields()
            ckbxROSLgSearch.Checked = False
            txtROSMapnum.Focus()
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnROSLgExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnROSLgExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Text boxes"

    Private Sub txtROSNumShts_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtROSNumShts.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtROSNumShts.Text) And txtROSNumShts.Text <> "" Then
                MsgBox("Num Sheets must be numeric")
                Exit Sub
            End If
            cboROSBsheet.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtROSMapnum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtROSMapnum.KeyPress
        If e.KeyChar = vbTab Then
            dtROSDocDate.Focus()
        End If
    End Sub

    Private Sub txtROSLocation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtROSLocation.KeyPress
        If e.KeyChar = vbTab Then
            txtROSAssrBook.Focus()
        End If
    End Sub

    Private Sub txtROSAssrBook_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtROSAssrBook.KeyPress
        If e.KeyChar = vbTab Then
            cboROSNad.Focus()
        End If
    End Sub

    Private Sub txtROSCalCoord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtROSCalCoord.KeyPress
        If e.KeyChar = vbTab Then
            cboROSBsheet.Focus()
        End If
    End Sub

#End Region

#Region "Combos and Checkboxes"

    Private Sub dtROSDocDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtROSDocDate.KeyPress
        If e.KeyChar = vbTab Then
            txtROSLocation.Focus()
        End If
    End Sub

    Private Sub cboROSNad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboROSNad.KeyPress
        If e.KeyChar = vbTab Then
            cboROSJur.Focus()
        End If
    End Sub

    Private Sub cboROSJur_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboROSJur.KeyPress
        If e.KeyChar = vbTab Then
            txtROSNumShts.Focus()
        End If
    End Sub

    Private Sub cboROSBsheet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboROSBsheet.KeyPress
        If e.KeyChar = vbTab Then
            btnROSLgSave.Focus()
        End If
    End Sub

    Private Sub ckbxROSLgSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbxROSLgSearch.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else          
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Try
                txtKnwnNum.Text = ""
                If Not ckbxROSLgSearch.Checked Then
                    txtKnwnNum.Enabled = True
                    cboROSLgSelectName.Items.Clear()
                    cboROSLgSelectName.SelectedText = ""
                    cboROSLgSelectName.Text = ""
                    cboROSLgSelectName.Enabled = False
                    ckbxROSLgSearch.Text = "Search/Edit" & vbNewLine & "Existing"
                    If Not pIsQuery Then
                        btnROSLgSave.Text = "Add ROS Log"
                    End If

                    'clear out the form fields
                    ClearFormFields()
                    dtROSDocDate.Focus()
                Else
                    txtKnwnNum.Enabled = False
                    cboROSLgSelectName.Enabled = True
                    If Not pIsQuery Then
                        ckbxROSLgSearch.Text = "UN-Check to " & vbNewLine & " ADD NEW"
                        btnROSLgSave.Text = "Save Updates"
                    End If
                    'Fill it
                    Dim pCur As ICursor, pRow As IRow, lIdx As Long
                    lIdx = m_pROSTable.Fields.FindField(ROSLG_MAPNUM_FLD_NAME)
                    ''add a queryfilter and queryfilterdefinition for sorting
                    Dim pQF As IQueryFilter
                    pQF = New QueryFilter
                    Dim pQFDef As IQueryFilterDefinition
                    pQFDef = pQF
                    pQFDef.PostfixClause = "order by MAPNUM desc"
                    pCur = m_pROSTable.Search(pQF, False) 'changed this one
                    pRow = pCur.NextRow
                    'Build the combobox
                    cboROSLgSelectName.Items.Add("MAP NUM")
                    cboROSLgSelectName.Items.Add("")
                    Do While Not pRow Is Nothing
                        cboROSLgSelectName.Items.Add(pRow.Value(lIdx))
                        pRow = pCur.NextRow
                    Loop
                    'display the 1st item
                    If cboROSLgSelectName.Items.Count > 0 Then cboROSLgSelectName.SelectedIndex = 0
                    Cursor.Current = Windows.Forms.Cursors.Default
                    cboROSLgSelectName.Focus()
                End If
            Catch ex As Exception
                Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub cboROSLgSelectName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboROSLgSelectName.SelectedIndexChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Try
                ClearFormFields()
                If cboROSLgSelectName.SelectedIndex <> 0 Then  'to skip the initial load
                    Dim pMapnum As String
                    pMapnum = cboROSLgSelectName.Text
                    PopulateForm(pMapnum)
                End If
            Catch ex As Exception
                Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

#End Region

#Region "Buttons"

    Private Sub btnROSLgSave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnROSLgSave.KeyPress
        If e.KeyChar = vbTab Then
            btnROSLgReset.Focus()
        End If
    End Sub

    Private Sub btnROSLgReset_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnROSLgReset.KeyPress
        If e.KeyChar = vbTab Then
            btnROSLgExit.Focus()
        End If
    End Sub

    Private Sub btnROSLgExit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnROSLgExit.KeyPress
        If e.KeyChar = vbTab Then
            txtROSMapnum.Focus()
        End If
    End Sub

    Private Sub btnROSLgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnROSLgSave.Click
        Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Try
            'first check field values
            Dim flderrmsg As String
            Dim flderr As Boolean
            flderr = False
            flderrmsg = ""
            If txtROSMapnum.Text = "" Or IsDBNull(txtROSMapnum.Text) Then
                flderr = True
                flderrmsg = flderrmsg & "MapNum can not be blank" & vbNewLine
            End If
            If txtROSNumShts.Text = "" Or IsDBNull(txtROSNumShts.Text) Then
                flderr = True
                flderrmsg = flderrmsg & "Num Sheets can not be blank" & vbNewLine
            End If
            If flderr Then
                Cursor.Current = Windows.Forms.Cursors.Default
                flderrmsg = flderrmsg & "Please modify the entries and try to save again"
                MsgBox(flderrmsg, MsgBoxStyle.Critical, "EDITS NOT SAVED")
                Exit Sub
            End If

            Dim psvrRow As IRow

            Dim psvrQF As IQueryFilter
            Dim psvrmpnm As String
            psvrmpnm = txtROSMapnum.Text ' cboROSLgSelectName.Text
            psvrQF = New QueryFilter
            psvrQF.WhereClause = "MAPNUM = '" & psvrmpnm & "'"
            'Cut Log
            Dim psvrCur As ICursor
            psvrCur = m_pROSTable.Search(psvrQF, False) 'changed this one
            psvrRow = psvrCur.NextRow

            If ckbxROSLgSearch.Checked Then
                'nothing because it will update the info of the existing record
            Else
                'Check if it exists otherwise it creates empty field
                If psvrRow Is Nothing Then
                    psvrRow = m_pROSTable.CreateRow 'cut log
                Else
                    'already exists so update or stop?
                    Dim Buttons As Windows.Forms.MessageBoxButtons = Windows.Forms.MessageBoxButtons.YesNo
                    Dim Result As Windows.Forms.DialogResult
                    Result = Windows.Forms.MessageBox.Show("Overwrite Existing Information?", "MAPNUM ALREADY EXISTS!", Buttons)
                    'If yes then just jump and save the info, else don't do anything but alert that nothing is saved.
                    If Result = Windows.Forms.DialogResult.No Then
                        MsgBox("INFORMATION NOT SAVED", MsgBoxStyle.Critical)
                        psvrRow = Nothing
                        psvrCur = Nothing
                        Exit Sub
                    End If
                End If
            End If

            'ROS LOG
            If Not psvrRow Is Nothing Then
                If Not IsDBNull(txtROSMapnum.Text) And Not txtROSMapnum.Text Is Nothing Then
                    psvrRow.Value(psvrRow.Fields.FindField(ROSLG_MAPNUM_FLD_NAME)) = txtROSMapnum.Text
                End If
                If Not IsDBNull(txtROSLocation.Text) And Not txtROSLocation.Text Is Nothing Then
                    psvrRow.Value(psvrRow.Fields.FindField(ROSLG_LOCATION_FLD_NAME)) = txtROSLocation.Text
                End If
                If Not IsDBNull(cboROSNad.Text) And Not cboROSNad.Text Is Nothing Then
                    psvrRow.Value(psvrRow.Fields.FindField(ROSLG_NAD_FLD_NAME)) = cboROSNad.Text
                End If
                If Not IsDBNull(cboROSJur.Text) And Not cboROSJur.Text Is Nothing Then
                    psvrRow.Value(psvrRow.Fields.FindField(ROSLG_JUR_FLD_NAME)) = cboROSJur.Text
                End If
                If Not IsDBNull(cboROSBsheet.Text) And Not cboROSBsheet.Text Is Nothing Then
                    psvrRow.Value(psvrRow.Fields.FindField(ROSLG_BSHEET_FLD_NAME)) = cboROSBsheet.Text
                End If
                If Not IsDBNull(dtROSDocDate.Text) And Not dtROSDocDate.Text Is Nothing And dtROSDocDate.Checked Then
                    psvrRow.Value(psvrRow.Fields.FindField(ROSLG_DOCDATE_FLD_NAME)) = dtROSDocDate.Text
                End If

                If Not IsDBNull(txtROSAssrBook.Text) And Not txtROSAssrBook.Text Is Nothing Then
                    psvrRow.Value(psvrRow.Fields.FindField(ROSLG_ASSRBOOK_FLD_NAME)) = txtROSAssrBook.Text
                End If
                If Not IsDBNull(txtROSNumShts.Text) And Not txtROSNumShts.Text Is Nothing Then
                    psvrRow.Value(psvrRow.Fields.FindField(ROSLG_NUMSHTS_FLD_NAME)) = txtROSNumShts.Text
                End If
                If Not IsDBNull(txtROSCalCoord.Text) And Not txtROSCalCoord.Text Is Nothing Then
                    psvrRow.Value(psvrRow.Fields.FindField(ROSLG_CALCOORD_FLD_NAME)) = txtROSCalCoord.Text
                End If

                psvrRow.Store()
            End If

            If ckbxROSLgSearch.Checked Then
                MsgBox("Updated: " & txtROSMapnum.Text)
            Else
                MsgBox("Added: " & txtROSMapnum.Text)
                btnROSLgReset.PerformClick()
                psvrRow = Nothing
            End If
            btnROSLgReset.PerformClick()

        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

    Private Sub txtKnwnNum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKnwnNum.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing

        ElseIf e.KeyChar = ChrW(Windows.Forms.Keys.Return) Then
            ClearFormFields()
            Dim pID As Long
            'if its empty do nothing
            If txtKnwnNum.Text <> "" Then
                pID = txtKnwnNum.Text
                PopulateForm(pID)
            End If
        Else
            'MsgBox(e.KeyChar)
            e.KeyChar = ChrW(0)
        End If
        If txtKnwnNum.Text = "" Then
            If Not pIsQuery Then
                btnROSLgSave.Text = "Add ROS Log"
            End If
        Else
            btnROSLgSave.Text = "Save Updates"
        End If
        

    End Sub
  
    Private Sub txtKnwnNum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKnwnNum.TextChanged

    End Sub
End Class