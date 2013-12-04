Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports SanGISMaintenanceToolbar.Globals
Public Class frmQueryControl
    Dim m_pWKSP As IWorkspace
    Dim m_ActiveView As IActiveView
    Dim m_pCntlTable As ITable
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

    Private Sub frmQueryControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim pTableSourcename As String
            pTableSourcename = CONTROL_DATASRC
            m_pCntlTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename, True)
            If m_pCntlTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If

            'if control in map then activate the 'select in map' button
            If CheckForLayer(CONTROL_DATASRC, m_ActiveView) Then
                btnControlFindFtr.Enabled = True
            Else
                btnControlFindFtr.Enabled = False
            End If

        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub frmQueryControl_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        m_ActiveView = Nothing
        m_pCntlTable = Nothing
        m_pWKSP = Nothing
        m_pWSE = Nothing
    End Sub

    Private Sub frmQueryControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F1 Then
            btnCntrlClear.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.F8 Then
            If ckbxCntrlStationIDSearch.Checked Then
                ckbxCntrlStationIDSearch.Checked = False
            Else
                ckbxCntrlStationSearch.Checked = True
            End If
        ElseIf e.KeyCode = Windows.Forms.Keys.F12 Then
            btnControlExit.PerformClick()
        End If
    End Sub

#End Region

#Region "Combo boxes and Check boxes"

    Private Sub ckbxCntrlStationSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbxCntrlStationSearch.CheckedChanged

        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Try
                If Not ckbxCntrlStationSearch.Checked Then
                    cboCntrlSelectName.Items.Clear()
                    cboCntrlSelectName.SelectedText = ""
                    cboCntrlSelectName.Text = ""
                    cboCntrlSelectName.Enabled = False
                    ckbxCntrlStationSearch.ForeColor = Drawing.Color.Black
                    ckbxCntrlStationSearch.Text = "Search by Station"
                    'clear out the form fields
                    ClearFormFields()
                Else
                    If ckbxCntrlStationIDSearch.Checked Then
                        ckbxCntrlStationIDSearch.Checked = False
                    End If
                    If ckbxSearchAll.Checked Then
                        ckbxSearchAll.Checked = False
                    End If
                    cboCntrlSelectName.Enabled = True
                    ckbxCntrlStationSearch.ForeColor = Drawing.Color.Red
                    ckbxCntrlStationSearch.Text = "Search By Station"
                    'Fill it
                    Dim pCur As ICursor, pRow As IRow, lIdx As Long, lIdx2 As Long
                    lIdx = m_pCntlTable.Fields.FindField("STATION")
                    lIdx2 = m_pCntlTable.Fields.FindField("STATIONID")

                    ''add a queryfilter and queryfilterdefinition for sorting
                    Dim pQF As IQueryFilter
                    pQF = New QueryFilter
                    Dim pQFDef As IQueryFilterDefinition
                    pQFDef = pQF
                    pQFDef.PostfixClause = "order by STATION"
                    pCur = m_pCntlTable.Search(pQF, False) 'changed this one
                    pRow = pCur.NextRow
                    'Build the combobox
                    Me.cboCntrlSelectName.Items.Add("STATION NAME / STATION ID")
                    Me.cboCntrlSelectName.Items.Add("")
                    Do While Not pRow Is Nothing
                        Me.cboCntrlSelectName.Items.Add(pRow.Value(lIdx) & " / " & pRow.Value(lIdx2))
                        pRow = pCur.NextRow
                    Loop
                    'display the 1st item
                    If Me.cboCntrlSelectName.Items.Count > 0 Then Me.cboCntrlSelectName.SelectedIndex = 0
                    CheckTxtBoxes()
                    Cursor.Current = Windows.Forms.Cursors.Default
                    cboCntrlSelectName.Focus()
                End If
            Catch ex As Exception
                Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub ckbxCntrlStationIDSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbxCntrlStationIDSearch.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Try
                If Not ckbxCntrlStationIDSearch.Checked Then
                    cboCntrlSelectName.Items.Clear()
                    cboCntrlSelectName.SelectedText = ""
                    cboCntrlSelectName.Text = ""
                    cboCntrlSelectName.Enabled = False
                    ckbxCntrlStationIDSearch.ForeColor = Drawing.Color.Black
                    ckbxCntrlStationIDSearch.Text = "Search by StationID"
                    'clear out the form fields
                    ClearFormFields()
                Else
                    If ckbxCntrlStationSearch.Checked Then
                        ckbxCntrlStationSearch.Checked = False
                    End If
                    If ckbxSearchAll.Checked Then
                        ckbxSearchAll.Checked = False
                    End If
                    cboCntrlSelectName.Enabled = True
                    ckbxCntrlStationIDSearch.ForeColor = Drawing.Color.Red
                    ckbxCntrlStationIDSearch.Text = "Search By StationID"
                    'Fill it
                    Dim pCur As ICursor, pRow As IRow, lIdx As Long, lIdx2 As Long
                    lIdx = m_pCntlTable.Fields.FindField("STATION")
                    lIdx2 = m_pCntlTable.Fields.FindField("STATIONID")

                    ''add a queryfilter and queryfilterdefinition for sorting
                    Dim pQF As IQueryFilter
                    pQF = New QueryFilter
                    Dim pQFDef As IQueryFilterDefinition
                    pQFDef = pQF
                    pQFDef.PostfixClause = "order by STATIONID"
                    pCur = m_pCntlTable.Search(pQF, False) 'changed this one
                    pRow = pCur.NextRow
                    'Build the combobox
                    Me.cboCntrlSelectName.Items.Add("STATION ID / STATION NAME")
                    Me.cboCntrlSelectName.Items.Add("")
                    Do While Not pRow Is Nothing
                        Me.cboCntrlSelectName.Items.Add(pRow.Value(lIdx2) & " / " & pRow.Value(lIdx))
                        pRow = pCur.NextRow
                    Loop
                    'display the 1st item
                    If cboCntrlSelectName.Items.Count > 0 Then
                        cboCntrlSelectName.SelectedIndex = 0
                    End If
                    CheckTxtBoxes()
                    Cursor.Current = Windows.Forms.Cursors.Default
                    cboCntrlSelectName.Focus()
                End If
            Catch ex As Exception
                Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub ckbxSearchAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbxSearchAll.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Try
                If Not ckbxSearchAll.Checked Then
                    cboCntrlSelectName.Items.Clear()
                    cboCntrlSelectName.SelectedText = ""
                    cboCntrlSelectName.Text = ""
                    cboCntrlSelectName.Enabled = False
                    ckbxSearchAll.ForeColor = Drawing.Color.Black
                    ckbxSearchAll.Text = "Show All Control"
                    'clear out the form fields
                    ClearFormFields()
                Else
                    If ckbxCntrlStationIDSearch.Checked Then
                        ckbxCntrlStationIDSearch.Checked = False
                    End If
                    If ckbxCntrlStationSearch.Checked Then
                        ckbxCntrlStationSearch.Checked = False
                    End If
                    cboCntrlSelectName.Enabled = False
                    ckbxSearchAll.ForeColor = Drawing.Color.Red
                    ckbxCntrlStationSearch.Text = "Show All Control"
                    'Fill it
                    PopGridList("")
                End If
                CheckTxtBoxes()
                Cursor.Current = Windows.Forms.Cursors.Default
            Catch ex As Exception
                Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub cboCntrlSelectName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCntrlSelectName.SelectedIndexChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Try
                dgCntrl.DataSource = Nothing
                lblCntrolCnt.Text = 0
                If cboCntrlSelectName.SelectedIndex <> 0 Then  'to skip the initial load
                    Dim pQueryfilter As IQueryFilter
                    Dim pRDID As Integer
                    Dim pRDIDLOC As Integer
                    Dim tmpRDTEXT As String
                    Dim pRDNMTXTlen As Integer
                    Dim prdCur As ICursor
                    Dim prdRow As IRow
                    tmpRDTEXT = cboCntrlSelectName.Text
                    pRDNMTXTlen = tmpRDTEXT.Length
                    pRDIDLOC = tmpRDTEXT.IndexOf("/") - 1
                    If ckbxCntrlStationIDSearch.Checked Then
                        If pRDIDLOC <= 0 Then
                            dgCntrl.DataSource = Nothing
                            MsgBox("NO STATION ID found.  Choose a different Station Name Record or use Name search")
                            Exit Sub
                        End If
                        pRDID = tmpRDTEXT.Substring(0, pRDIDLOC)
                    ElseIf ckbxCntrlStationSearch.Checked Then
                        If pRDIDLOC <= 0 Then
                            dgCntrl.DataSource = Nothing
                            MsgBox("NO STATION NAME found.  Choose a different Station Name Record or use ID search")
                            Exit Sub
                        End If
                        pRDID = tmpRDTEXT.Substring(pRDIDLOC + 2)
                    End If
                    pQueryfilter = New QueryFilter
                    pQueryfilter.WhereClause = "STATIONID = " & pRDID
                    'MsgBox("STATIONID = " & pRDID)
                    prdCur = m_pCntlTable.Search(pQueryfilter, False) 'changed this one
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
    End Sub

#End Region

#Region "Custom"

    Sub ClearFormFields()
        cboCntrlSelectName.Items.Clear()
        cboCntrlSelectName.SelectedText = ""
        cboCntrlSelectName.Text = ""
        cboCntrlSelectName.Enabled = False
        dgCntrl.DataSource = Nothing
        txtKnwnID.Text = ""
        txtKnwnID.Enabled = True
    End Sub


    Private Sub CheckTxtBoxes()
        If ckbxCntrlStationIDSearch.Checked Or ckbxCntrlStationSearch.Checked Or ckbxSearchAll.Checked Then
            txtKnwnID.Text = ""
            txtKnwnID.Enabled = False
        Else
           txtKnwnID.Text = ""
            txtKnwnID.Enabled = True
        End If
    End Sub

    Private Sub PopGridList(ByVal pqRDID As String)
        Try
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Dim pRDIDQF As IQueryFilter
            Dim pRDID As String
            pRDID = pqRDID
            pRDIDQF = New QueryFilter

            If pqRDID = "STATION NAME" Then
                Dim pID As String
                pID = txtKnwnID.Text.ToUpper
                m_TWWhereClause = "STATION LIKE '%" & pID & "%'"
                pRDIDQF.WhereClause = m_TWWhereClause
                m_TWPostfixClause = "Order By STATION"
            ElseIf pRDID <> "" Then
                m_TWWhereClause = "STATIONID = " & pRDID
                pRDIDQF.WhereClause = m_TWWhereClause
                m_TWPostfixClause = "Order By STATIONID"
            ElseIf ckbxSearchAll.Checked Then
                m_TWWhereClause = "STATIONID LIKE '%'"
                pRDIDQF.WhereClause = m_TWWhereClause
                m_TWPostfixClause = "Order By STATION"
            Else
                MsgBox("No Valid Station ID selected.")
                Cursor.Current = Windows.Forms.Cursors.Default
                Exit Sub
            End If
            'check if any selected
            Dim pRwCnt As Integer
            pRwCnt = m_pCntlTable.RowCount(pRDIDQF)

            lblCntrolCnt.Text = pRwCnt
            If pRwCnt > 0 And pRwCnt < 1001 Then
                FillGridData()
            ElseIf pRwCnt > 1000 Then
                Dim prowlots As MsgBoxResult
                prowlots = MsgBox(pRwCnt & " Records found, press OK to continue, CANCEL to start new search", MsgBoxStyle.OkCancel, "Thats a Lot of Records!")
                If prowlots = MsgBoxResult.Ok Then
                    FillGridData()
                End If
            Else
                MsgBox("No Station records found matching search criteria", MsgBoxStyle.Information)
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
            tableWrapper = New ArcDataBinding.TableWrapper(m_pCntlTable)
            dgCntrl.DataSource = tableWrapper
            With dgCntrl
                .Columns("STATION").DisplayIndex = 0
                .Columns("STATION").Width = 180
                .Columns("STATION").HeaderText = "Station"

                .Columns("STATIONID").DisplayIndex = 1
                .Columns("STATIONID").Width = 60
                .Columns("STATIONID").HeaderText = "StationID"

                .Columns("NAD83N").DisplayIndex = 2
                .Columns("NAD83N").Width = 80
                .Columns("NAD83N").HeaderText = "NAD83N"

                .Columns("NAD83E").DisplayIndex = 3
                .Columns("NAD83E").Width = 80
                .Columns("NAD83E").HeaderText = "NAD83E"

                .Columns("ORDERNO").DisplayIndex = 4
                .Columns("ORDERNO").Width = 40
                .Columns("ORDERNO").HeaderText = "Ord"

                .Columns("JURISDIC").DisplayIndex = 5
                .Columns("JURISDIC").Width = 40
                .Columns("JURISDIC").HeaderText = "Jur"

                .Columns("SECTION").DisplayIndex = 6
                .Columns("SECTION").Width = 55
                .Columns("SECTION").HeaderText = "Section"

                .Columns("RANCHO").DisplayIndex = 7
                .Columns("RANCHO").Width = 100
                .Columns("RANCHO").HeaderText = "Rancho"

                Cursor.Current = Windows.Forms.Cursors.Default
            End With
            'dgRSGRD.Focus()
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Buttons"

    Private Sub btnControlExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnControlExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnCntrlClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCntrlClear.Click
        ClearFormFields()
        ckbxCntrlStationIDSearch.Checked = False
        ckbxCntrlStationSearch.Checked = False
        ckbxSearchAll.Checked = False
    End Sub

    Private Sub btnControlFindFtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnControlFindFtr.Click
        If Not dgCntrl Is Nothing Then
            If dgCntrl.SelectedRows.Count > 0 Then

                Dim pstnid As String
                pstnid = dgCntrl.CurrentRow.Cells.Item(dgCntrl.Columns("STATIONID").Index).Value

                If IsNumeric(pstnid) Then
                    GetSelectedFeatures(CONTROL_DATASRC, m_ActiveView, "STATIONID", pstnid, True)
                End If
            Else
                MsgBox("No StationID selected in list")
            End If
        Else
            MsgBox("Please select an StationID")
        End If
    End Sub

#End Region

    Private Sub txtKnwnID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKnwnID.KeyPress
        If e.KeyChar = ChrW(Windows.Forms.Keys.Return) Then
            ckbxCntrlStationIDSearch.Checked = False
            ckbxCntrlStationSearch.Checked = False
            ckbxSearchAll.Checked = False
            'if its empty do nothing
            If txtKnwnID.Text <> "" Then
                'send station name text so search and queries use the text box
                PopGridList("STATION NAME")
            End If
        End If
    End Sub

 

    Private Sub txtKnwnID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKnwnID.TextChanged

    End Sub

    Private Sub btnExporttoExcelAdr_Click(sender As System.Object, e As System.EventArgs) Handles btnExporttoExcelAdr.Click
        ExportToExcel.ExportDGVtoExcel(dgCntrl)
    End Sub
End Class