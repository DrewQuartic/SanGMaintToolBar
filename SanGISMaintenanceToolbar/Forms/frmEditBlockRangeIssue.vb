Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.esriSystem
Imports System.Windows.Forms


Public Class frmEditBlockRangeIssue
    Dim m_ActiveView As IActiveView
    Dim m_pBRTable As ITable
    Dim m_pWSE As IWorkspaceEdit
    Private tableWrapper As ArcDataBinding.TableWrapper
    Private IsInitializing As Boolean
    Private ItFailed As Boolean
    Dim pTableSourcename As String = LOG_OVERLAP_DATASRC

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

    Private Sub frmEditBlockRangeIssue_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            IsInitializing = True
            Dim crntDate As Date = Now.ToShortDateString
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
            m_pBRTable = GetUnVWorkspaceTable("ANY", FrmMap, pTableSourcename)
            If m_pBRTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If

            'Set up the tooltips
            Dim toolTip1 As New System.Windows.Forms.ToolTip()
            ' Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000
            toolTip1.InitialDelay = 1000
            toolTip1.ReshowDelay = 500
            ' Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = True

            ' Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(Me.btnRoadGetFtr, "Find Road In Map")
            toolTip1.SetToolTip(Me.btnDelete, "Remove Record from Table")

            'Fill the combos
            cboIssue.Items.Add("ALL")
            cboIssue.Items.Add("OVERLAP")

            'Add Jurisdictions
            cboJur.Items.Add("ALL")
            cboJur.Items.Add("CB")
            cboJur.Items.Add("CN")
            cboJur.Items.Add("CO")
            cboJur.Items.Add("CV")
            cboJur.Items.Add("DM")
            cboJur.Items.Add("EC")
            cboJur.Items.Add("EN")
            cboJur.Items.Add("ES")
            cboJur.Items.Add("IB")
            cboJur.Items.Add("LG")
            cboJur.Items.Add("LM")
            cboJur.Items.Add("NC")
            cboJur.Items.Add("OC")
            cboJur.Items.Add("PW")
            cboJur.Items.Add("SD")
            cboJur.Items.Add("SM")
            cboJur.Items.Add("SO")
            cboJur.Items.Add("ST")
            cboJur.Items.Add("VS")

            'exception combo
            cboUpdtExcept.Items.Add("")
            cboUpdtExcept.Items.Add("Y")
            cboUpdtExcept.Items.Add("N")

            ClearFormFields()
            FillGridData()

            IsInitializing = False
            btnReset.PerformClick()

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try

    End Sub

#Region "Custom"
    Public Sub ClearFormFields()
        Try
            txtRoadSegID.Text = ""
            cboIssue.SelectedIndex = 0
            cboJur.SelectedIndex = 0
            dtPosted.Checked = False
            dtReviewed.Checked = False
            ckboxIncludeEx.Checked = False
            cboUpdtExcept.SelectedIndex = 0
            dtUpdtReviewDate.Text = Now
            txtUpdtNotes.Text = ""
            If Not dgBRIssueList.DataSource Is Nothing Then
                If dgBRIssueList.RowCount > 0 Then
                    dgBRIssueList.ClearSelection()
                    dgBRIssueList.Rows(0).Selected = True
                End If
            End If
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try

    End Sub


    Private Sub FillGridData()

        Try
            'Build the query on any change
            Dim pQueryfilter As IQueryFilter
            Dim pADRJUR As String = ""
            Dim pADRISSUE As String = ""
            Dim qry As String = ""

            Select Case cboIssue.Text
                Case "OVERLAP"
                    qry = "ISSUETYPE = 'OVERLAP' AND "
                Case Else
                    qry = ""
            End Select

            If cboJur.Text <> "ALL" Then qry = qry & "JURISDIC = '" & cboJur.Text & "' AND "

            If dtPosted.Checked Then qry = qry & "POSTDATE >= TO_DATE('" & dtPosted.Text & " ','MM/Dd/YYYY') AND "

            If dtReviewed.Checked Then qry = qry & "REVIEWDATE >= TO_DATE('" & dtReviewed.Text & " ','MM/Dd/YYYY') AND "

            If txtRoadSegID.Text <> "" And IsNumeric(txtRoadSegID.Text) Then qry = qry & "ROADID = " & txtRoadSegID.Text & " AND "

            If Not ckboxIncludeEx.Checked Then qry = qry & "(ISEXCEPTION <> 'Y' OR ISEXCEPTION IS NULL)"

            'clear out any left over ands
            If qry.EndsWith("AND ") Then qry = qry.Remove(qry.Length - 5)

            'Show the query on the form
            lblQuery.Text = "Query: " & qry

            pQueryfilter = New QueryFilter
            pQueryfilter.WhereClause = qry
            'Addr Log Table
            Dim pRwCnt As Integer
            pRwCnt = m_pBRTable.RowCount(pQueryfilter)
            lblNumRecs.Text = pRwCnt
            If pRwCnt > 0 Then
                m_TWWhereClause = qry
                m_TWPostfixClause = "Order By ROADID"
            Else
                dgBRIssueList.DataSource = Nothing
                Exit Sub
            End If


            'Fill the datagrid

            m_WrapperCaller = "FrmBlockRangeIssue"
            tableWrapper = New ArcDataBinding.TableWrapper(m_pBRTable)
            dgBRIssueList.DataSource = tableWrapper
            With dgBRIssueList
                .Columns("OBJECTID").Visible = False
                .Columns("ROADID").DisplayIndex = 0
                .Columns("ROADID").Width = 85
                .Columns("ROADID").HeaderText = "RoadID"
                .Columns("ROADID").DefaultCellStyle.ForeColor = Drawing.Color.Blue
                .Columns("ISSUETYPE").DisplayIndex = 1
                .Columns("ISSUETYPE").Width = 100
                .Columns("ISSUETYPE").HeaderText = "Issue Type"
                .Columns("ISSUETYPE").DefaultCellStyle.ForeColor = Drawing.Color.DarkRed
                .Columns("JURISDIC").DisplayIndex = 2
                .Columns("JURISDIC").Width = 45
                .Columns("JURISDIC").HeaderText = "Juris"
                .Columns("ROADNAME").DisplayIndex = 3
                .Columns("ROADNAME").Width = 45
                .Columns("ROADNAME").HeaderText = "Road Name"
                .Columns("POSTDATE").DisplayIndex = 4
                .Columns("POSTDATE").Width = 140
                .Columns("POSTDATE").HeaderText = "Posted"
                .Columns("REVIEWDATE").DisplayIndex = 5
                .Columns("REVIEWDATE").Width = 75
                .Columns("REVIEWDATE").HeaderText = "Reviewed"
                .Columns("ISEXCEPTION").DisplayIndex = 6
                .Columns("ISEXCEPTION").Width = 70
                .Columns("ISEXCEPTION").HeaderText = "Exception"
                .Columns("ISEXCEPTION").DefaultCellStyle.ForeColor = Drawing.Color.DarkRed
                .Columns("REVIEWNOTES").DisplayIndex = 7
                .Columns("REVIEWNOTES").Width = 120
                .Columns("REVIEWNOTES").HeaderText = "Notes"
            End With

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub
#End Region

#Region "Search"

    Private Sub txtRoadSegID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRoadSegID.KeyPress
        If IsNumeric(e.KeyChar) Then

        ElseIf e.KeyChar = vbBack Then

        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtRoadSegID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRoadSegID.TextChanged
        FillGridData()
    End Sub

    Private Sub dtPosted_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtPosted.ValueChanged
        FillGridData()
    End Sub

    Private Sub dtReviewed_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtReviewed.ValueChanged
        FillGridData()
    End Sub

    Private Sub cboIssue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIssue.SelectedIndexChanged
        FillGridData()
    End Sub

    Private Sub cboJur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboJur.SelectedIndexChanged
        FillGridData()
    End Sub

    Private Sub ckboxIncludeEx_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckboxIncludeEx.CheckedChanged
        FillGridData()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearFormFields()
        FillGridData()
    End Sub

#End Region

#Region "Update"

    Private Sub btnUpdt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdt.Click
        Try
            If IsNumeric(lblRoadSeg.Text) Then

                'grab the update values
                Dim pRdSeg As Long
                Dim pReviewDate As String
                Dim pReviewNotes As String
                Dim pIsException As String
                pRdSeg = lblRoadSeg.Text
                pReviewDate = dtUpdtReviewDate.Text
                pReviewNotes = txtUpdtNotes.Text
                If cboUpdtExcept.Text = "Y" Then
                    pIsException = "Y"
                Else
                    pIsException = "N"
                End If

                'check if any selected
                Dim psvQueryfilter As IQueryFilter
                Dim psvRDCur As ICursor
                Dim psvRDRow As IRow
                psvQueryfilter = New QueryFilter
                psvQueryfilter.WhereClause = "ROADID = " & pRdSeg
                'Addr Log Table
                psvRDCur = m_pBRTable.Search(psvQueryfilter, True)
                psvRDRow = psvRDCur.NextRow
                If Not psvRDRow Is Nothing Then
                    psvRDRow.Value(psvRDRow.Fields.FindField("ISEXCEPTION")) = pIsException
                    psvRDRow.Value(psvRDRow.Fields.FindField("REVIEWDATE")) = pReviewDate
                    psvRDRow.Value(psvRDRow.Fields.FindField("REVIEWNOTES")) = pReviewNotes
                    psvRDRow.Store()
                    'pAddrTable = Nothing
                    MsgBox("Updated BlockRange Issue Log for ROADID: " & pRdSeg)
                    btnReset.PerformClick()
                    psvRDRow = Nothing
                    psvRDCur = Nothing
                End If
            Else
                MsgBox("ROADID must be Numeric")
            End If

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnRoadGetFtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoadGetFtr.Click
        If Not dgBRIssueList Is Nothing Then
            If dgBRIssueList.SelectedRows.Count > 0 Then

                Dim pstnid As String
                pstnid = dgBRIssueList.CurrentRow.Cells.Item(dgBRIssueList.Columns("ROADID").Index).Value.ToString

                If IsNumeric(pstnid) Then
                    GetSelectedFeatures(ROAD_DATASRC, m_ActiveView, "ROADID", pstnid, True)
                End If
            Else
                MsgBox("No ROADID selected in list")
            End If
        Else
            MsgBox("Please select a ROADID")
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Are you sure you want to delete this record?", "YOUR ARE ABOUT TO DELETE A BLOCK RANGE ISSUE", Windows.Forms.MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim RDid As Long
                RDid = lblRoadSeg.Text
                'go ahead and delete it
                Dim pQF As IQueryFilter
                pQF = New QueryFilter
                Dim pGeoCursor As ICursor
                Dim pGeoRow As IRow
                Dim pWhereClse As String
                pWhereClse = "ROADID = " & RDid
                pQF.WhereClause = pWhereClse
                pGeoCursor = m_pBRTable.Update(pQF, False)
                pGeoRow = pGeoCursor.NextRow
                If Not pGeoRow Is Nothing Then
                    pGeoRow.Delete()
                    pGeoRow = Nothing
                    pGeoCursor = Nothing
                End If
                pGeoRow = Nothing
                pGeoCursor = Nothing
                btnReset.PerformClick()

            Catch ex As Exception
                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        Else
            MessageBox.Show("Delete Record Cancelled", "CANCEL")
        End If
    End Sub

#End Region


    Private Sub dgBRIssueList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgBRIssueList.KeyPress
        If e.KeyChar = vbTab Then
            txtRoadSegID.Focus()
        End If
    End Sub

    Private Sub dgBRIssueList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgBRIssueList.SelectionChanged
        If Not IsInitializing And Not dgBRIssueList.DataSource Is Nothing And dgBRIssueList.SelectedRows.Count > 0 Then
            'update items in update group
            Dim pstnid As String
            pstnid = dgBRIssueList.CurrentRow.Cells.Item(dgBRIssueList.Columns("ROADID").Index).Value
            If IsNumeric(pstnid) Then
                lblRoadSeg.Text = pstnid
                If Not IsDBNull(dgBRIssueList.CurrentRow.Cells.Item(dgBRIssueList.Columns("ISEXCEPTION").Index).Value) And dgBRIssueList.CurrentRow.Cells.Item(dgBRIssueList.Columns("ISEXCEPTION").Index).Value.ToString <> "" Then
                    cboUpdtExcept.Text = dgBRIssueList.CurrentRow.Cells.Item(dgBRIssueList.Columns("ISEXCEPTION").Index).Value.ToString
                Else
                    cboUpdtExcept.SelectedIndex = 0
                End If
                If Not IsDBNull(dgBRIssueList.CurrentRow.Cells.Item(dgBRIssueList.Columns("REVIEWDATE").Index).Value) And dgBRIssueList.CurrentRow.Cells.Item(dgBRIssueList.Columns("REVIEWDATE").Index).Value.ToString <> "" Then
                    dtUpdtReviewDate.Text = dgBRIssueList.CurrentRow.Cells.Item(dgBRIssueList.Columns("REVIEWDATE").Index).Value
                Else
                    dtUpdtReviewDate.Text = Now()
                End If
                If Not IsDBNull(dgBRIssueList.CurrentRow.Cells.Item(dgBRIssueList.Columns("REVIEWNOTES").Index).Value) And dgBRIssueList.CurrentRow.Cells.Item(dgBRIssueList.Columns("REVIEWNOTES").Index).Value.ToString <> "" Then
                    txtUpdtNotes.Text = dgBRIssueList.CurrentRow.Cells.Item(dgBRIssueList.Columns("REVIEWNOTES").Index).Value.ToString
                Else
                    txtUpdtNotes.Text = ""
                End If
                'move map to address feature
                btnRoadGetFtr.PerformClick()

            Else
                lblRoadSeg.Text = "None"
            End If
        Else
            lblRoadSeg.Text = "None"
        End If
    End Sub

    Private Sub btnSExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Try
            m_ActiveView = Nothing
            m_pBRTable = Nothing
            m_pWSE = Nothing
            m_pWSE = Nothing
            Me.Close()
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnExporttoExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExporttoExcel.Click
        ExportToExcel.ExportDGVtoExcel(dgBRIssueList)
    End Sub
End Class