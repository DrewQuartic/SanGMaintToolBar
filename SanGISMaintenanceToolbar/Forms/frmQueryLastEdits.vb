Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports SanGISMaintenanceToolbar.Globals
Imports System.Windows.Forms

Public Class frmQueryLastEdits

    Dim m_pWKSP As IWorkspace
    Dim m_ActiveView As IActiveView
    Dim m_pRprtTable As ITable
    Dim m_pWSE As IWorkspaceEdit
    Dim m_pTableSourcename As String = ROAD_DATASRC

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



    Private Sub frmQueryLastEdits_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            'load dropdown
            cboLayerSelectName.Items.Clear()
            cboLayerSelectName.Items.Add("")
            cboLayerSelectName.Items.Add(ROAD_DATASRC)
            cboLayerSelectName.Items.Add(PARCEL_DATASRC)
            cboLayerSelectName.Items.Add(ADDRESS_DATASRC)
            cboLayerSelectName.Items.Add(APN_ATR_DATASRC)
            ' cboLayerSelectName.Items.Add(CONTROL_DATASRC)
            cboLayerSelectName.Items.Add(INTERSECTION_DATASRC)
            cboLayerSelectName.Items.Add(LAW_BEAT_DATASRC)
            cboLayerSelectName.Items.Add(LOT_DATASRC)
            cboLayerSelectName.Items.Add(SUBDIV_ATR_DATASRC)
            cboLayerSelectName.Items.Add(ROAD_ALIAS_DATASRC)
            ' cboLayerSelectName.Items.Add(EASEMENT_DATASRC)
            cboLayerSelectName.Items.Add(EASFLOODCONTROL_DATASRC)
            cboLayerSelectName.Items.Add(EASFLOODCONTROL_DOC_DATASRC)
            cboLayerSelectName.Items.Add(LOTSWORKAREA_DATASRC)
            cboLayerSelectName.Sorted = True
            ClearFormFields()
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub frmQueryLastEdits_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        m_ActiveView = Nothing
        m_pRprtTable = Nothing
        m_pWKSP = Nothing
        m_pWSE = Nothing
    End Sub

    Private Function SetTableSelected() As Boolean
        SetTableSelected = False
        m_pRprtTable = Nothing
        If cboLayerSelectName.Text = "" Then
            ClearFormFields()
            Exit Function
        End If
        m_pTableSourcename = cboLayerSelectName.Text
        m_pRprtTable = GetWorkspaceTable("ANY", FrmMap, m_pTableSourcename, True)
        If m_pRprtTable Is Nothing Then
            MessageBox.Show("Table or Layer not found")
            dgRprtEdits.DataSource = Nothing
            Return False
        Else
            Return True
        End If
    End Function



    Private Sub cboCntrlSelectName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboLayerSelectName.SelectedIndexChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Try
                If SetTableSelected() Then
                    PopGridList()
                End If
            Catch ex As Exception
                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub PopGridList()
        Try
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor

            If Not IsNumeric(txtdays.Text) Then
                ClearFormFields()
                Exit Sub
            End If
            lblNoneFound.Visible = False
            Dim time As DateTime = DateTime.Now().AddDays(-(txtdays.Text))
            Dim dtformat As String = "yyyy-MM-dd" '"MMM ddd d HH:mm yyyy"
            Dim srchDate As String
            srchDate = time.ToString(dtformat)
            '2012-01-15 15:32:28

            ''add a queryfilter and queryfilterdefinition for sorting
            Dim pRDIDQF As IQueryFilter
            pRDIDQF = New QueryFilter
            m_TWWhereClause = "POSTDATE >= TO_DATE('" & srchDate & "','YYYY-MM-DD') AND POSTDATE IS NOT NULL" ' HH24:MI:SS')"
            m_TWPostfixClause = "order by POSTDATE desc"

            pRDIDQF.WhereClause = m_TWWhereClause

            'check if any selected
            Dim pRwCnt As Integer
            pRwCnt = m_pRprtTable.RowCount(pRDIDQF)

            lblEditCnt.Text = pRwCnt
            If pRwCnt > 0 Then
                FillGridData()         
            Else
                lblNoneFound.Visible = True
                dgRprtEdits.DataSource = Nothing
                'MsgBox("Norecords found matching search criteria", MsgBoxStyle.Information)
                'ClearFormFields()
            End If
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try

    End Sub

    Private Sub FillGridData()
        'Fill the datagrid
        Try
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            tableWrapper = New ArcDataBinding.TableWrapper(m_pRprtTable)
            dgRprtEdits.DataSource = tableWrapper
            With dgRprtEdits
                .Columns("POSTDATE").DisplayIndex = 0
                .Columns("POSTDATE").Width = 180
                .Columns("POSTDATE").HeaderText = "POSTDATE"

                .Columns("POSTID").DisplayIndex = 1
                .Columns("POSTID").Width = 60
                .Columns("POSTID").HeaderText = "POSTID"

            End With
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            'dgRSGRD.Focus()
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        ClearFormFields()
    End Sub

    Private Sub btnExporttoExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExporttoExcel.Click
        ExportToExcel.ExportDGVtoExcel(dgRprtEdits)
    End Sub

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Sub ClearFormFields()
        cboLayerSelectName.SelectedIndex = 0
        dgRprtEdits.DataSource = Nothing
        txtdays.Text = "0"
        lblNoneFound.Visible = True
    End Sub

    Private Sub txtdays_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtdays.KeyPress
        txtdays.ForeColor = Drawing.Color.Red
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = ChrW(Windows.Forms.Keys.Return) Then
            If Me.IsInitializing = True Then
                Exit Sub
            ElseIf txtdays.Text <> "" And cboLayerSelectName.Text <> "" Then
                txtdays.ForeColor = Drawing.Color.Black
                PopGridList()
            Else
                ClearFormFields()
            End If
        Else
            e.KeyChar = ChrW(0)
        End If

    End Sub

 

    Private Sub dgRprtEdits_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRprtEdits.CellContentClick

    End Sub

    Private Sub dgRprtEdits_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgRprtEdits.SelectionChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            If cboLayerSelectName.Text = "" Or dgRprtEdits.DataSource Is Nothing Or dgRprtEdits.SelectedRows.Count = 0 Then
                btnFindFtr.Enabled = False
                Exit Sub
            End If
 
            'if datasource in map then activate the 'select in map' button
            If CheckForLayer(m_pTableSourcename, m_ActiveView) And Not dgRprtEdits.DataSource Is Nothing Then
                btnFindFtr.Enabled = True
            Else
                btnFindFtr.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnFindFtr_Click(sender As System.Object, e As System.EventArgs) Handles btnFindFtr.Click
        If Not dgRprtEdits Is Nothing Then
            If dgRprtEdits.SelectedRows.Count > 0 And cboLayerSelectName.Text <> "" Then

                Dim pstnid As String
                pstnid = dgRprtEdits.CurrentRow.Cells.Item(dgRprtEdits.Columns("OBJECTID").Index).Value

                If IsNumeric(pstnid) Then
                    GetSelectedFeatures(cboLayerSelectName.Text, m_ActiveView, "OBJECTID", pstnid, True)
                End If
            Else
                MsgBox("No Feature selected in list")
            End If
        Else
            MsgBox("Please select an Feature")
        End If
    End Sub
End Class