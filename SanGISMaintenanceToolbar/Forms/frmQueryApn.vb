Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.esriSystem
Public Class frmQueryApn
    Dim m_pWKSP As IWorkspace
    Dim m_ActiveView As IActiveView
    Dim m_pAPNView As ITable
    Dim m_pADRView As ITable
    Dim m_pWSE As IWorkspaceEdit
    Private tableWrapper As ArcDataBinding.TableWrapper
    Private tableWrapper2 As ArcDataBinding.TableWrapper
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

    Private Sub frmQueryApn_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        m_ActiveView = Nothing
        m_pAPNView = Nothing
        m_pADRView = Nothing
        m_pWKSP = Nothing
        m_pWSE = Nothing
    End Sub

    Private Sub frmQueryApn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F1 Then
            btnReset.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.F8 Then
            chkQFs()
        ElseIf e.KeyCode = Windows.Forms.Keys.F12 Then
            btnExit.PerformClick()
        End If
    End Sub

    Private Sub frmQueryApn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Dim pTableSourcename As String
            pTableSourcename = V_APNPARCEL_DATASRC
            m_pAPNView = GetWorkspaceTable("ANY", FrmMap, pTableSourcename, True)
            If m_pAPNView Is Nothing Then
                Me.Close()
                Exit Sub
            End If
            Dim pTableSourcename2 As String
            pTableSourcename2 = V_ADRROADAPN_DATASRC
            m_pADRView = GetWorkspaceTable("ANY", FrmMap, pTableSourcename2, True)
            If m_pADRView Is Nothing Then
                Me.Close()
                Exit Sub
            End If

            'if parcel layer in map then activate the 'select in map' button
            If CheckForLayer(PARCEL_DATASRC, m_ActiveView) Then
                btnParcelGetFtr.Enabled = True
            Else
                btnParcelGetFtr.Enabled = False
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
        If txtAPNQF.Text <> "" Or txtParcelIDQF.Text <> "" Then
            Dim pAPNsrch As String
            Dim pPARsrch As String
            pAPNsrch = txtAPNQF.Text
            pPARsrch = txtParcelIDQF.Text
            PopAPNList(pAPNsrch, pPARsrch)
        Else
            MsgBox("No Search Criteria Entered")
            Exit Sub
        End If
    End Sub

    Private Sub PopAPNList(ByVal pAPN As String, ByVal pPAR As String)
        Try
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Dim pAPNQF As IQueryFilter
            Dim pAPNID As String
            Dim pPARID As String
            pAPNID = txtAPNQF.Text
            pPARID = txtParcelIDQF.Text
            pAPNQF = New QueryFilter
            If pAPNID <> "" And pPARID = "" Then
                m_TWWhereClause = "APN LIKE '" & pAPNID & "'"
                pAPNQF.WhereClause = m_TWWhereClause
                m_TWPostfixClause = "Order By APN"
            ElseIf pAPNID = "" And pPARID <> "" Then
                m_TWWhereClause = "PARCELID LIKE '" & pPARID & "'"
                pAPNQF.WhereClause = m_TWWhereClause
                m_TWPostfixClause = "Order By PARCELID"
            Else
                MsgBox("No Search Criteria Entered.")
                Cursor.Current = Windows.Forms.Cursors.Default
                Exit Sub
            End If
            'check if any selected
            Dim pRwCnt As Integer
            pRwCnt = m_pAPNView.RowCount(pAPNQF)
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

    Private Sub PopADRList(ByVal pADRAPNID As Integer)
        Try
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Dim pAdrQF As IQueryFilter
            pAdrQF = New QueryFilter
            m_TWWhereClause = "APNID = " & pADRAPNID
            m_TWPostfixClause = "Order By ADDRNO"
            pAdrQF.WhereClause = m_TWWhereClause
            'check if any selected
            Dim pAdrRwCnt As Integer
            pAdrRwCnt = m_pADRView.RowCount(pAdrQF)
            lblAPNID.Text = pADRAPNID
            lblAdrRowCount.Text = pAdrRwCnt
            If pAdrRwCnt > 0 Then
                'm_ADRAPNID = pADRAPNID
                FillAdrGrid()
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
            m_WrapperCaller = "FrmQueryAPN"
            tableWrapper = New ArcDataBinding.TableWrapper(m_pAPNView)
            dgAPNList.DataSource = tableWrapper
            With dgAPNList
                .Columns("APN").DisplayIndex = 0
                .Columns("APN").Width = 95
                .Columns("APN").DefaultCellStyle.ForeColor = Drawing.Color.Blue
                '.Columns("APN").SortMode = Windows.Forms.DataGridViewColumnSortMode.Programmatic
                .Columns("ParcelID").DisplayIndex = 1
                .Columns("ParcelID").Width = 70
                .Columns("ParcelID").HeaderText = "Parcel ID"
                .Columns("ParcelID").DefaultCellStyle.ForeColor = Drawing.Color.Green
                '.Columns("ParcelID").SortMode = Windows.Forms.DataGridViewColumnSortMode.Automatic
                .Columns("APNID").DisplayIndex = 2
                .Columns("APNID").Width = 70
                .Columns("APNID").HeaderText = "APN ID"
                '.Columns("APNID").SortMode = Windows.Forms.DataGridViewColumnSortMode.Automatic
                .Columns("Pending").DisplayIndex = 3
                .Columns("Pending").Width = 35
                .Columns("Pending").HeaderText = "PEN"
                .Columns("POSTID").DisplayIndex = 4
                .Columns("POSTID").Width = 85
                .Columns("POSTID").HeaderText = "POST ID"
                .Columns("POSTDATE").DisplayIndex = 5
                .Columns("POSTDATE").Width = 80
                .Columns("POSTDATE").DefaultCellStyle.Format = "d"
                .Columns("POSTDATE").HeaderText = "POST DATE"
                .Columns("X_COORD").DisplayIndex = 6
                .Columns("X_COORD").Width = 90
                .Columns("X_COORD").DefaultCellStyle.Format = "F3"
                .Columns("Y_COORD").DisplayIndex = 7
                .Columns("Y_COORD").Width = 90
                .Columns("Y_COORD").DefaultCellStyle.Format = "F3"
                '.Columns("TILENAME").DisplayIndex = 8
                '.Columns("TILENAME").Width = 55
                '.Columns("TILENAME").HeaderText = "TILE NAME"
                .Columns("OVERLAY_JURIS").DisplayIndex = 8
                .Columns("OVERLAY_JURIS").Width = 36
                .Columns("OVERLAY_JURIS").HeaderText = "Jur"
                .Columns("ADDID").DisplayIndex = 9
                .Columns("ADDID").Width = 87
                .Columns("ADDID").HeaderText = "Add ID"
                .Columns("ADDDATE").DisplayIndex = 10
                .Columns("ADDDATE").Width = 82
                .Columns("ADDDATE").DefaultCellStyle.Format = "d"
                .Columns("ADDDATE").HeaderText = "ADD DATE"
                Cursor.Current = Windows.Forms.Cursors.Default
            End With
            dgAPNList.Focus()
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub FillAdrGrid()
        'Fill the datagrid
        Try
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            m_WrapperCaller = "FrmQueryAPN_ADR"
            tableWrapper2 = New ArcDataBinding.TableWrapper(m_pADRView)
            dgAdrList.DataSource = tableWrapper2
            With dgAdrList
                .Columns("ADDRNO").DisplayIndex = 0
                .Columns("ADDRNO").Width = 100
                .Columns("ADDRNO").DefaultCellStyle.ForeColor = Drawing.Color.Blue
                .Columns("ADDRNO").HeaderText = "Addr No"
                .Columns("ADDRUNIT").DisplayIndex = 1
                .Columns("ADDRUNIT").Width = 50
                .Columns("ADDRUNIT").HeaderText = "Unit"
                .Columns("ADDRFRAC").DisplayIndex = 2
                .Columns("ADDRFRAC").Width = 50
                .Columns("ADDRFRAC").HeaderText = "Frac"
                .Columns("ROAD20_PREDIR_IND").DisplayIndex = 3
                .Columns("ROAD20_PREDIR_IND").Width = 50
                .Columns("ROAD20_PREDIR_IND").HeaderText = "Dir"
                .Columns("ROAD20_NM").DisplayIndex = 4
                .Columns("ROAD20_NM").Width = 250
                .Columns("ROAD20_NM").HeaderText = "Road Name"
                .Columns("ROAD20_SUFFIX_NM").DisplayIndex = 5
                .Columns("ROAD20_SUFFIX_NM").Width = 50
                .Columns("ROAD20_SUFFIX_NM").HeaderText = "Sfx"
                .Columns("JURISDIC").DisplayIndex = 6
                .Columns("JURISDIC").Width = 50
                .Columns("JURISDIC").HeaderText = "Jur"
                .Columns("ROADSEGID").DisplayIndex = 7
                .Columns("ROADSEGID").Width = 120
                .Columns("ROADSEGID").HeaderText = "RoadSeg ID"
                .Columns("ROAD_ID").DisplayIndex = 8
                .Columns("ROAD_ID").Width = 160
                .Columns("ROAD_ID").HeaderText = "Road ID"
            End With
            dgAdrList.ClearSelection()
            Cursor.Current = Windows.Forms.Cursors.Default
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Form controls"

    Private Sub txtAPNQF_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAPNQF.GotFocus
        txtParcelIDQF.Text = ""
    End Sub

    Private Sub txtAPNQF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAPNQF.KeyPress
        If e.KeyChar = vbTab Then
            txtParcelIDQF.Focus()
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

    Private Sub txtParcelIDQF_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtParcelIDQF.GotFocus
        txtAPNQF.Text = ""
    End Sub

    Private Sub txtParcelIDQF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtParcelIDQF.KeyPress
        If e.KeyChar = vbTab Then
            txtAPNQF.Focus()
        End If
        If e.KeyChar = ChrW(Windows.Forms.Keys.Return) Then
            If txtParcelIDQF.Text = "" Then
                MsgBox("Enter Text for PARCELID search criteria")
                Exit Sub
            Else
                chkQFs()
            End If
        End If
    End Sub

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
        txtAPNQF.Text = ""
        txtParcelIDQF.Text = ""
        lblNumRecFound.Text = ""
        lblAdrRowCount.Text = ""
        lblAPNID.Text = ""
        dgAdrList.DataSource = Nothing
        dgAPNList.DataSource = Nothing
    End Sub

    Private Sub dgAPNList_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAPNList.CellContentDoubleClick
        If dgAPNList.CurrentCell.OwningColumn.DisplayIndex = 1 Then
            'reset list to that ParcelID only
            'dgAdrList.DataSource = Nothing
            Dim pPARID As Integer
            pPARID = dgAPNList.CurrentCell.Value
            btnReset.PerformClick()
            'repopulate apn/parcel table
            txtAPNQF.Text = ""
            txtParcelIDQF.Text = pPARID
            chkQFs()
        End If
    End Sub

    Private Sub dgAPNList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgAPNList.SelectionChanged
        dgAdrList.DataSource = Nothing
        Dim pADRAPNID As Integer
        pADRAPNID = dgAPNList.CurrentRow.Cells.Item(dgAPNList.Columns("APNID").Index).Value
        'populate adr table
        PopADRList(pADRAPNID)
    End Sub

    Private Sub btnParcelGetFtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParcelGetFtr.Click
        If Not dgAPNList Is Nothing Then
            If dgAPNList.SelectedRows.Count > 0 Then
                Dim pParID As String
                pParID = dgAPNList.CurrentRow.Cells.Item(dgAPNList.Columns("PARCELID").Index).Value
                If IsNumeric(pParID) Then
                    GetSelectedFeatures(PARCEL_DATASRC, m_ActiveView, "PARCELID", pParID, True)
                End If
            Else
                MsgBox("No APN selected in list")
            End If
        Else
            MsgBox("Please select an APN")
        End If
    End Sub

#End Region

    Private Sub btnExportData_Click(sender As System.Object, e As System.EventArgs) Handles btnExportData.Click
        ExportToExcel.ExportDGVtoExcel(dgAPNList)
    End Sub

    Private Sub btnExporttoExcelAdr_Click(sender As System.Object, e As System.EventArgs) Handles btnExporttoExcelAdr.Click
        ExportToExcel.ExportDGVtoExcel(dgAdrList)
    End Sub

    Private Sub txtAPNQF_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAPNQF.TextChanged

    End Sub
End Class