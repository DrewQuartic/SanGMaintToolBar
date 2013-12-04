Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports SanGISMaintenanceToolbar.Globals
Imports System.Windows.Forms

Public Class frmEditAddressIssue

    Dim m_ActiveView As IActiveView
    Dim m_pAddrTable As ITable
    Dim m_pWSE As IWorkspaceEdit
    Private tableWrapper As ArcDataBinding.TableWrapper
    Private IsInitializing As Boolean
    Private ItFailed As Boolean
    Dim pTableSourcename As String = LOG_ADDRESSISSUE_DATASRC

    Public Property FrmMap() As IActiveView
        Get
            Return m_ActiveView
        End Get

        Set(ByVal ActiveView As IActiveView)
            m_ActiveView = ActiveView
        End Set
    End Property



    Private Sub frmEditAddressIssue_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            m_pAddrTable = GetUnVWorkspaceTable("ANY", FrmMap, pTableSourcename)
            If m_pAddrTable Is Nothing Then
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
            toolTip1.SetToolTip(Me.btnAddressGetFtr, "Find Address In Map")
            toolTip1.SetToolTip(Me.btnDelete, "Remove Record from Table")

            'Fill the combos
            cboIssue.Items.Add("ALL")
            cboIssue.Items.Add("Out of Range")
            cboIssue.Items.Add("Is Zero")
            cboIssue.Items.Add("No SegID")

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
            txtAddrApnID.Text = ""
            cboIssue.SelectedIndex = 0
            cboJur.SelectedIndex = 0
            dtPosted.Checked = False
            dtReviewed.Checked = False
            ckboxIncludeEx.Checked = False
            cboUpdtExcept.SelectedIndex = 0
            dtUpdtReviewDate.Text = Now
            txtUpdtNotes.Text = ""
            If Not dgADRIssueList.DataSource Is Nothing Then
                If dgADRIssueList.RowCount > 0 Then
                    dgADRIssueList.ClearSelection()
                    dgADRIssueList.Rows(0).Selected = True
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
                Case "Out of Range"
                    qry = "IS_OUTOFRANGE = 'Y' AND "
                Case "Is Zero"
                    qry = "IS_ZERO = 'Y' AND "
                Case "No SegID"
                    qry = "IS_MISSINGSEGID = 'Y' AND "
                Case Else
                    qry = ""
            End Select

            If cboJur.Text <> "ALL" Then qry = qry & "JURISDIC = '" & cboJur.Text & "' AND "

            If dtPosted.Checked Then qry = qry & "POSTDATE >= TO_DATE('" & dtPosted.Text & " ','MM/Dd/YYYY') AND "

            If dtReviewed.Checked Then qry = qry & "REVIEWDATE >= TO_DATE('" & dtReviewed.Text & " ','MM/Dd/YYYY') AND "

            If txtAddrApnID.Text <> "" And IsNumeric(txtAddrApnID.Text) Then qry = qry & "ADDRAPNID = " & txtAddrApnID.Text & " AND "

            If Not ckboxIncludeEx.Checked Then qry = qry & "(ISEXCEPTION <> 'Y' OR ISEXCEPTION IS NULL)"

            'clear out any left over ands
            If qry.EndsWith("AND ") Then qry = qry.Remove(qry.Length - 5)

            'Show the query on the form
            lblQuery.Text = "Query: " & qry

            pQueryfilter = New QueryFilter
            pQueryfilter.WhereClause = qry
            'Addr Log Table
            Dim pRwCnt As Integer
            pRwCnt = m_pAddrTable.RowCount(pQueryfilter)
            lblNumRecs.Text = pRwCnt
            If pRwCnt > 0 Then
                m_TWWhereClause = qry
                m_TWPostfixClause = "Order By ADDRAPNID"
            Else
                dgADRIssueList.DataSource = Nothing
                Exit Sub
            End If


            'Fill the datagrid

            m_WrapperCaller = "FrmEditAddressIssue"
            tableWrapper = New ArcDataBinding.TableWrapper(m_pAddrTable)
            dgADRIssueList.DataSource = tableWrapper
            With dgADRIssueList
                .Columns("ObjectID").Visible = False
                .Columns("ADDRAPNID").DisplayIndex = 0
                .Columns("ADDRAPNID").Width = 85
                .Columns("ADDRAPNID").DefaultCellStyle.ForeColor = Drawing.Color.Blue
                .Columns("ADDRNO").DisplayIndex = 1
                .Columns("ADDRNO").Width = 45
                .Columns("ADDRNO").HeaderText = "Addr No"
                .Columns("IS_OUTOFRANGE").DisplayIndex = 2
                .Columns("IS_OUTOFRANGE").Width = 50
                .Columns("IS_OUTOFRANGE").HeaderText = "Out of Range"
                .Columns("IS_OUTOFRANGE").DefaultCellStyle.ForeColor = Drawing.Color.DarkRed
                .Columns("IS_ZERO").DisplayIndex = 3
                .Columns("IS_ZERO").Width = 50
                .Columns("IS_ZERO").HeaderText = "Is Zero"
                .Columns("IS_ZERO").DefaultCellStyle.ForeColor = Drawing.Color.DarkRed
                .Columns("IS_MISSINGSEGID").DisplayIndex = 4
                .Columns("IS_MISSINGSEGID").Width = 45
                .Columns("IS_MISSINGSEGID").HeaderText = "No SegID"
                .Columns("IS_MISSINGSEGID").DefaultCellStyle.ForeColor = Drawing.Color.DarkRed
                .Columns("ROADSEGID").DisplayIndex = 5
                .Columns("ROADSEGID").Width = 45
                .Columns("ROADSEGID").HeaderText = "Road SegID"
                .Columns("JURISDIC").DisplayIndex = 6
                .Columns("JURISDIC").Width = 45
                .Columns("JURISDIC").HeaderText = "Juris"
                .Columns("POSTDATE").DisplayIndex = 7
                .Columns("POSTDATE").Width = 70
                .Columns("POSTDATE").HeaderText = "Posted"
                .Columns("REVIEWDATE").DisplayIndex = 8
                .Columns("REVIEWDATE").Width = 75
                .Columns("REVIEWDATE").HeaderText = "Reviewed"
                .Columns("ISEXCEPTION").DisplayIndex = 9
                .Columns("ISEXCEPTION").Width = 50
                .Columns("ISEXCEPTION").HeaderText = "Excep- tion"
                .Columns("ISEXCEPTION").DefaultCellStyle.ForeColor = Drawing.Color.DarkRed
                .Columns("REVIEWNOTES").DisplayIndex = 10
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


    Private Sub btnAddressGetFtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddressGetFtr.Click
        If Not dgADRIssueList Is Nothing Then
            If dgADRIssueList.SelectedRows.Count > 0 Then

                Dim pstnid As String
                pstnid = dgADRIssueList.CurrentRow.Cells.Item(dgADRIssueList.Columns("ADDRAPNID").Index).Value.ToString

                If IsNumeric(pstnid) Then
                    GetSelectedFeatures(ADDRESS_DATASRC, m_ActiveView, "ADDRAPNID", pstnid, True)
                End If
            Else
                MsgBox("No ADDRAPNID selected in list")
            End If
        Else
            MsgBox("Please select an ADDRAPNID")
        End If
    End Sub

    Private Sub Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearFormFields()
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


    Private Sub btnUpdt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdt.Click
        Try
            If IsNumeric(lblAddrAPN.Text) Then

                ' Dim pAddrTable As ITable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename, False)


                'grab the update values
                Dim pAdrAPN As Long
                Dim pReviewDate As String
                Dim pReviewNotes As String
                Dim pIsException As String
                pAdrAPN = lblAddrAPN.Text
                pReviewDate = dtUpdtReviewDate.Text
                pReviewNotes = txtUpdtNotes.Text
                If cboUpdtExcept.Text = "Y" Then
                    pIsException = "Y"
                Else
                    pIsException = "N"
                End If

                'check if any selected
                Dim psvQueryfilter As IQueryFilter
                Dim psvADCur As ICursor
                Dim psvADRow As IRow
                psvQueryfilter = New QueryFilter
                psvQueryfilter.WhereClause = "ADDRAPNID = " & pAdrAPN
                'Addr Log Table
                psvADCur = m_pAddrTable.Search(psvQueryfilter, True)
                psvADRow = psvADCur.NextRow
                If Not psvADRow Is Nothing Then
                    psvADRow.Value(psvADRow.Fields.FindField("ISEXCEPTION")) = pIsException
                    psvADRow.Value(psvADRow.Fields.FindField("REVIEWDATE")) = pReviewDate
                    psvADRow.Value(psvADRow.Fields.FindField("REVIEWNOTES")) = pReviewNotes
                    psvADRow.Store()
                    'pAddrTable = Nothing
                    MsgBox("Updated Address Issue Log for ADDRAPNID: " & pAdrAPN)
                    btnReset.PerformClick()
                    psvADRow = Nothing
                    psvADCur = Nothing
                End If
            Else
                MsgBox("ADDRAPNID must be Numeric")
            End If

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub dgADRIssueList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgADRIssueList.KeyPress
        If e.KeyChar = vbTab Then
            txtAddrApnID.Focus()
        End If
    End Sub



    Private Sub dgADRIssueList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgADRIssueList.SelectionChanged
        If Not IsInitializing And Not dgADRIssueList.DataSource Is Nothing And dgADRIssueList.SelectedRows.Count > 0 Then
            'update items in update group
            Dim pstnid As String
            pstnid = dgADRIssueList.CurrentRow.Cells.Item(dgADRIssueList.Columns("ADDRAPNID").Index).Value
            If IsNumeric(pstnid) Then
                lblAddrAPN.Text = pstnid
                If Not IsDBNull(dgADRIssueList.CurrentRow.Cells.Item(dgADRIssueList.Columns("ISEXCEPTION").Index).Value) And dgADRIssueList.CurrentRow.Cells.Item(dgADRIssueList.Columns("ISEXCEPTION").Index).Value.ToString <> "" Then
                    cboUpdtExcept.Text = dgADRIssueList.CurrentRow.Cells.Item(dgADRIssueList.Columns("ISEXCEPTION").Index).Value.ToString
                Else
                    cboUpdtExcept.SelectedIndex = 0
                End If
                If Not IsDBNull(dgADRIssueList.CurrentRow.Cells.Item(dgADRIssueList.Columns("REVIEWDATE").Index).Value) And dgADRIssueList.CurrentRow.Cells.Item(dgADRIssueList.Columns("REVIEWDATE").Index).Value.ToString <> "" Then
                    dtUpdtReviewDate.Text = dgADRIssueList.CurrentRow.Cells.Item(dgADRIssueList.Columns("REVIEWDATE").Index).Value
                Else
                    dtUpdtReviewDate.Text = Now()
                End If
                If Not IsDBNull(dgADRIssueList.CurrentRow.Cells.Item(dgADRIssueList.Columns("REVIEWNOTES").Index).Value) And dgADRIssueList.CurrentRow.Cells.Item(dgADRIssueList.Columns("REVIEWNOTES").Index).Value.ToString <> "" Then
                    txtUpdtNotes.Text = dgADRIssueList.CurrentRow.Cells.Item(dgADRIssueList.Columns("REVIEWNOTES").Index).Value.ToString
                Else
                    txtUpdtNotes.Text = ""
                End If
                'move map to address feature
                btnAddressGetFtr.PerformClick()

            Else
                lblAddrAPN.Text = "None"
            End If
        Else
            lblAddrAPN.Text = "None"
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Are you sure you want to delete this record?", "YOUR ARE ABOUT TO DELETE AN ADDRESS ISSUE", Windows.Forms.MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Try

                Dim Adrid As Long
                Adrid = lblAddrAPN.Text
                'go ahead and delete it
                Dim pQF As IQueryFilter
                pQF = New QueryFilter
                Dim pGeoCursor As ICursor
                Dim pGeoRow As IRow
                Dim pWhereClse As String
                pWhereClse = "ADDRAPNID = " & Adrid
                pQF.WhereClause = pWhereClse
                pGeoCursor = m_pAddrTable.Update(pQF, False)
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

    Private Sub txtAddrApnID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddrApnID.KeyPress
        If IsNumeric(e.KeyChar) Then

        ElseIf e.KeyChar = vbBack Then

        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtAddrApnID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddrApnID.TextChanged
        FillGridData()
    End Sub


    Private Sub btnSExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Try
            m_ActiveView = Nothing
            m_pAddrTable = Nothing
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
        ExportToExcel.ExportDGVtoExcel(dgADRIssueList)
    End Sub
End Class