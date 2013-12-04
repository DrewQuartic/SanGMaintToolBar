Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.esriSystem

Public Class frmEditCityAddress
    'Dim m_pWKSP As IWorkspace
    Dim m_ActiveView As IActiveView
    Dim m_pAddrTable As ITable
    Dim m_pWSE As IWorkspaceEdit
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

    Private Sub frmEditCityAddress_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not ItFailed Then
            Dim pDataset As IDataset
            pDataset = m_pAddrTable
            m_pWSE = pDataset.Workspace
            If m_pWSE.IsBeingEdited Then
                m_pWSE.StopEditOperation()
                m_pWSE.StopEditing(True)
            End If

            m_ActiveView = Nothing
            m_pAddrTable = Nothing
            'm_pWKSP = Nothing
            m_pWSE = Nothing
        End If
    End Sub

    Private Sub frmEditCityAddress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F1 Then
            btnAdrLgReset.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.F8 Then
            PopRoadList(txtRdSearchQF.Text)
        ElseIf e.KeyCode = Windows.Forms.Keys.F10 Then
            btnAdrLgSave.PerformClick()
        ElseIf e.KeyCode = Windows.Forms.Keys.F12 Then
            btnAdrLgExit.PerformClick()
        End If
    End Sub

    Private Sub frmEditCityAddress_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
            pTableSourcename = LOG_SDADDRESS_DATASRC
            m_pAddrTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename, False)
            If m_pAddrTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If
            'Fill the combos
            cboAdrCompleted.Items.Add("Y")
            cboAdrCompleted.Items.Add("N")

        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Custom"

    Public Sub ClearFormFields(ByVal pbtmfrm As Boolean, ByVal ptpfrm As Boolean)
        Try
            If pbtmfrm Then
                txtAdrWONum.Text = ""
                cboAdrCompleted.Text = ""
                txtAdrAPN.Text = ""
                txtAdrMapName.Text = ""
                txtAdrRdsegID.Text = ""
                txtAdrCityID.Text = ""
                dtAdrToSanGIS.Text = ""
                txtAdrAdress.Text = ""
                txtAdrFraction.Text = ""
                txtAdrUnit.Text = ""
                txtAdrPreDir.Text = ""
                txtAdrRdName.Text = ""
                txtAdrRdSfx.Text = ""
                txtAdrRdSDir.Text = ""
                txtAdrAbLOaddr.Text = ""
                txtAdrAbHiaddr.Text = ""
                txtAdrLLowAddr.Text = ""
                txtAdrLHiAddr.Text = ""
                txtAdrRtLowAddr.Text = ""
                txtAdrRtHiAddr.Text = ""
            End If
            If ptpfrm Then
                txtRdSearchQF.Text = ""
                cboAdrLgSelectName.Items.Clear()
                cboAdrLgSelectName.Enabled = False
                dgvAdrLogList.DataSource = Nothing
            End If

        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try

    End Sub

    Private Sub PopRoadList(ByVal pRdNmQry)
        Try
            ClearFormFields(True, False)
            cboAdrLgSelectName.Items.Clear()
            cboAdrLgSelectName.Enabled = True
            'Fill it
            Dim pCur As ICursor, lIdx As Long
            lIdx = m_pAddrTable.Fields.FindField(ADRLG_ROADFULL_FLD_NAME)
            'add a queryfilter and queryfilterdefinition for sorting
            Dim pQF As IQueryFilter
            pQF = New QueryFilter
            If Not txtRdSearchQF.Text = "" Then
                pQF.WhereClause = ADRLG_ROADFULL_FLD_NAME & " LIKE '" & txtRdSearchQF.Text & "%'"
            End If
            Dim pQFDef As IQueryFilterDefinition
            pQFDef = pQF
            pQFDef.PostfixClause = "order by ROADFULL"
            pCur = m_pAddrTable.Search(pQF, False) 'changed this one
            'Use this to get the Uniques Road Names
            Dim pData As IDataStatistics
            Dim pEnumVar As IEnumerator
            Dim prdnmval As String
            pData = New DataStatistics
            pData.Field = "ROADFULL"
            pData.Cursor = pCur
            pEnumVar = pData.UniqueValues
            pEnumVar.Reset()
            Do While pEnumVar.MoveNext
                prdnmval = CType(pEnumVar.Current, String)
                cboAdrLgSelectName.Items.Add(prdnmval)
            Loop
            'display the 1st item
            If cboAdrLgSelectName.Items.Count > 0 Then cboAdrLgSelectName.SelectedIndex = 0
            Cursor.Current = Windows.Forms.Cursors.Default
            cboAdrLgSelectName.Focus()

        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub FillGridData()
        'Fill the datagrid
        Try


            m_WrapperCaller = "FrmEditCityAddress"
            tableWrapper = New ArcDataBinding.TableWrapper(m_pAddrTable)
            dgvAdrLogList.DataSource = tableWrapper
            With dgvAdrLogList
                .Columns("ObjectID").Visible = False
                .Columns("ID").DisplayIndex = 0
                .Columns("ID").Width = 45
                .Columns("ID").DefaultCellStyle.ForeColor = Drawing.Color.Blue
                .Columns("Address").DisplayIndex = 1
                .Columns("Address").Width = 50
                .Columns("Address").HeaderText = "ADDR"
                .Columns("RoadFull").DisplayIndex = 2
                .Columns("RoadFull").Width = 190
                .Columns("RoadFull").HeaderText = "Road Name"
                .Columns("Mapname").DisplayIndex = 3
                .Columns("Mapname").Width = 190
                .Columns("Mapname").DefaultCellStyle.ForeColor = Drawing.Color.Blue
                .Columns("Mapname").HeaderText = "Map Name"
                .Columns("Wrkordid").DisplayIndex = 4
                .Columns("Wrkordid").Width = 130
                .Columns("Wrkordid").HeaderText = "WO ID"
            End With

        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Form Controls"

    Private Sub dgvAdrLogList_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAdrLogList.CellContentDoubleClick
        Try
            ClearFormFields(True, False)
            If dgvAdrLogList.CurrentCell.OwningColumn.DisplayIndex = 0 Or dgvAdrLogList.CurrentCell.OwningColumn.DisplayIndex = 3 Then
                Dim pAdrID As Integer
                pAdrID = dgvAdrLogList.CurrentRow.Cells.Item(0).Value
                If IsNumeric(pAdrID) Then
                    Dim peQueryfilter As IQueryFilter
                    Dim peADCur As ICursor
                    Dim peADRow As IRow

                    peQueryfilter = New QueryFilter
                    peQueryfilter.WhereClause = "ID = " & pAdrID
                    'Addr Log Table
                    peADCur = m_pAddrTable.Search(peQueryfilter, False) 'changed this one
                    peADRow = peADCur.NextRow
                    If Not peADRow Is Nothing Then
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_WRKORDID_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_WRKORDID_FLD_NAME)) Is Nothing Then
                            txtAdrWONum.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_WRKORDID_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_COMPLETED_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_COMPLETED_FLD_NAME)) Is Nothing Then
                            cboAdrCompleted.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_COMPLETED_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_APN_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_APN_FLD_NAME)) Is Nothing Then
                            txtAdrAPN.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_APN_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_MAPNAME_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_MAPNAME_FLD_NAME)) Is Nothing Then
                            txtAdrMapName.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_MAPNAME_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_ROADSEGID_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_ROADSEGID_FLD_NAME)) Is Nothing Then
                            txtAdrRdsegID.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_ROADSEGID_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_ID_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_ID_FLD_NAME)) Is Nothing Then
                            txtAdrCityID.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_ID_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_TOSANGIS_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_TOSANGIS_FLD_NAME)) Is Nothing Then
                            dtAdrToSanGIS.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_TOSANGIS_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_ADDRESS_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_ADDRESS_FLD_NAME)) Is Nothing Then
                            txtAdrAdress.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_ADDRESS_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_FRACTION_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_FRACTION_FLD_NAME)) Is Nothing Then
                            txtAdrFraction.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_FRACTION_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_UNIT_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_UNIT_FLD_NAME)) Is Nothing Then
                            txtAdrUnit.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_UNIT_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_ROADPDIR_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_ROADPDIR_FLD_NAME)) Is Nothing Then
                            txtAdrPreDir.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_ROADPDIR_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_ROADNAME_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_ROADNAME_FLD_NAME)) Is Nothing Then
                            txtAdrRdName.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_ROADNAME_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_ROADSFX_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_ROADSFX_FLD_NAME)) Is Nothing Then
                            txtAdrRdSfx.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_ROADSFX_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_ROADSDIR_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_ROADSDIR_FLD_NAME)) Is Nothing Then
                            txtAdrRdSDir.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_ROADSDIR_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_ABLOADDR_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_ABLOADDR_FLD_NAME)) Is Nothing Then
                            txtAdrAbLOaddr.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_ABLOADDR_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_ABHIADDR_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_ABHIADDR_FLD_NAME)) Is Nothing Then
                            txtAdrAbHiaddr.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_ABHIADDR_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_LLOWADDR_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_LLOWADDR_FLD_NAME)) Is Nothing Then
                            txtAdrLLowAddr.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_LLOWADDR_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_LHIGHADDR_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_LHIGHADDR_FLD_NAME)) Is Nothing Then
                            txtAdrLHiAddr.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_LHIGHADDR_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_RLOWADDR_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_RLOWADDR_FLD_NAME)) Is Nothing Then
                            txtAdrRtLowAddr.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_RLOWADDR_FLD_NAME))
                        End If
                        If Not IsDBNull(peADRow.Value(peADRow.Fields.FindField(ADRLG_RHIGHADDR_FLD_NAME))) And Not peADRow.Value(peADRow.Fields.FindField(ADRLG_RHIGHADDR_FLD_NAME)) Is Nothing Then
                            txtAdrRtHiAddr.Text = peADRow.Value(peADRow.Fields.FindField(ADRLG_RHIGHADDR_FLD_NAME))
                        End If

                    End If

                End If

            End If
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub txtRdSearchQF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRdSearchQF.KeyPress
        Try

            If e.KeyChar = vbTab Then
                txtAdrWONum.Focus()
            End If
            If e.KeyChar = ChrW(Windows.Forms.Keys.Return) Then
                If txtRdSearchQF.Text = "" Then
                    MsgBox("Enter Text for Road Name search criteria")
                    Exit Sub
                Else
                    Dim prdsrch As String
                    prdsrch = txtRdSearchQF.Text
                    PopRoadList(prdsrch)
                End If
            End If
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnAdrLgReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdrLgReset.Click
        ClearFormFields(True, True)
    End Sub

    Private Sub txtAdrWONum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdrWONum.KeyPress
        If e.KeyChar = vbTab Then
            cboAdrCompleted.Focus()
        End If
    End Sub

    Private Sub txtAdrAPN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdrAPN.KeyPress
        If e.KeyChar = vbTab Then
            txtAdrMapName.Focus()
        End If
    End Sub

    Private Sub txtAdrMapName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdrMapName.KeyPress
        If e.KeyChar = vbTab Then
            btnAdrLgSave.Focus()
        End If
    End Sub

    Private Sub cboAdrCompleted_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAdrCompleted.KeyPress
        If e.KeyChar = vbTab Then
            txtAdrAPN.Focus()
        End If
    End Sub

    Private Sub cboAdrLgSelectName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAdrLgSelectName.SelectedIndexChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Try
                ClearFormFields(True, False)
                Dim pQueryfilter As IQueryFilter
                Dim pADID As String

                pADID = cboAdrLgSelectName.Text
                pQueryfilter = New QueryFilter
                pQueryfilter.WhereClause = "ROADFULL = " & "'" & pADID & "'"
                'Addr Log Table
                Dim pRwCnt As Integer
                pRwCnt = m_pAddrTable.RowCount(pQueryfilter)
                If pRwCnt > 0 Then
                    m_TWWhereClause = "ROADFULL = " & "'" & pADID & "'"
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

    Private Sub btnAdrLgSave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnAdrLgSave.KeyPress
        If e.KeyChar = vbTab Then
            btnAdrLgReset.Focus()
        End If
    End Sub

    Private Sub btnAdrLgReset_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnAdrLgReset.KeyPress
        If e.KeyChar = vbTab Then
            btnAdrLgExit.Focus()
        End If
    End Sub

    Private Sub btnAdrLgExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdrLgExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnAdrLgExit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnAdrLgExit.KeyPress
        If e.KeyChar = vbTab Then
            txtRdSearchQF.Focus()
        End If
    End Sub

    Private Sub btnAdrSaveSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdrSaveSel.Click
        Try
            Dim pmsgResult As MsgBoxResult
            pmsgResult = MsgBox("Are you sure you want to update " & dgvAdrLogList.SelectedRows.Count & " record(s) with the following information?" & _
            vbNewLine & vbNewLine & _
            "Work Order ID: " & txtAdrWONum.Text & vbNewLine & _
            "Completed: " & cboAdrCompleted.Text & vbNewLine & _
            "Map Name: " & txtAdrMapName.Text, MsgBoxStyle.OkCancel, "MULTI-ADDRESS UPDATE!")
            If pmsgResult = MsgBoxResult.Cancel Then
                MsgBox("No Addresses Updated", MsgBoxStyle.Exclamation)
            ElseIf pmsgResult = MsgBoxResult.Ok Then

                Dim psvAdrID As Integer
                Dim psvQueryfilter As IQueryFilter
                Dim psvADCur As ICursor
                Dim psvADRow As IRow
                Dim i As Integer
                Dim pAdrIDlst As String

                pAdrIDlst = ""
                psvQueryfilter = New QueryFilter
                For i = 0 To dgvAdrLogList.SelectedRows.Count - 1
                    psvAdrID = (dgvAdrLogList.SelectedRows.Item(i).Cells.Item(0).Value)
                    pAdrIDlst = pAdrIDlst & "," & psvAdrID
                    psvQueryfilter.WhereClause = "ID = " & psvAdrID
                    'Addr Log Table
                    psvADCur = m_pAddrTable.Search(psvQueryfilter, False) 'changed this one
                    psvADRow = psvADCur.NextRow
                    If Not psvADRow Is Nothing Then
                        If Not IsDBNull(txtAdrWONum.Text) And Not txtAdrWONum.Text Is Nothing Then
                            psvADRow.Value(psvADRow.Fields.FindField(ADRLG_WRKORDID_FLD_NAME)) = txtAdrWONum.Text
                        End If
                        If Not IsDBNull(cboAdrCompleted.Text) And Not cboAdrCompleted.Text Is Nothing Then
                            psvADRow.Value(psvADRow.Fields.FindField(ADRLG_COMPLETED_FLD_NAME)) = cboAdrCompleted.Text
                        End If
                        If Not IsDBNull(txtAdrMapName.Text) And Not txtAdrMapName.Text Is Nothing Then
                            psvADRow.Value(psvADRow.Fields.FindField(ADRLG_MAPNAME_FLD_NAME)) = txtAdrMapName.Text
                        End If

                        psvADRow.Store()

                    End If
                Next
                MsgBox("Updated Address IDs: " & pAdrIDlst)
                FillGridData()
            End If
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnAdrSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdrSaveAll.Click
        Try
            Dim pmsgResult As MsgBoxResult
            pmsgResult = MsgBox("Are you sure you want to update " & dgvAdrLogList.Rows.Count & " record(s) with the following information?" & _
            vbNewLine & vbNewLine & _
            "Work Order ID: " & txtAdrWONum.Text & vbNewLine & _
            "Completed: " & cboAdrCompleted.Text & vbNewLine & _
            "Map Name: " & txtAdrMapName.Text, MsgBoxStyle.OkCancel, "MULTI-ADDRESS UPDATE!")
            If pmsgResult = MsgBoxResult.Cancel Then
                MsgBox("No Addresses Updated", MsgBoxStyle.Exclamation)
            ElseIf pmsgResult = MsgBoxResult.Ok Then
                Dim psvAdrID As Integer
                Dim psvQueryfilter As IQueryFilter
                Dim psvADCur As ICursor
                Dim psvADRow As IRow
                Dim i As Integer
                Dim pAdrIDlst As String

                pAdrIDlst = ""
                psvQueryfilter = New QueryFilter
                For i = 0 To dgvAdrLogList.Rows.Count - 1
                    psvAdrID = (dgvAdrLogList.Rows.Item(i).Cells.Item(0).Value)
                    pAdrIDlst = pAdrIDlst & "," & psvAdrID
                    psvQueryfilter.WhereClause = "ID = " & psvAdrID
                    'Addr Log Table
                    psvADCur = m_pAddrTable.Search(psvQueryfilter, False) 'changed this one
                    psvADRow = psvADCur.NextRow
                    If Not psvADRow Is Nothing Then
                        If Not IsDBNull(txtAdrWONum.Text) And Not txtAdrWONum.Text Is Nothing Then
                            psvADRow.Value(psvADRow.Fields.FindField(ADRLG_WRKORDID_FLD_NAME)) = txtAdrWONum.Text
                        End If
                        If Not IsDBNull(cboAdrCompleted.Text) And Not cboAdrCompleted.Text Is Nothing Then
                            psvADRow.Value(psvADRow.Fields.FindField(ADRLG_COMPLETED_FLD_NAME)) = cboAdrCompleted.Text
                        End If
                        If Not IsDBNull(txtAdrMapName.Text) And Not txtAdrMapName.Text Is Nothing Then
                            psvADRow.Value(psvADRow.Fields.FindField(ADRLG_MAPNAME_FLD_NAME)) = txtAdrMapName.Text
                        End If

                        psvADRow.Store()

                    End If
                Next
                MsgBox("Updated Address IDs: " & pAdrIDlst)
                FillGridData()
            End If
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub btnAdrLgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdrLgSave.Click
        Try
            If IsNumeric(txtAdrCityID.Text) Then
                Dim psvAdrID As Integer
                psvAdrID = txtAdrCityID.Text
                Dim psvQueryfilter As IQueryFilter
                Dim psvADCur As ICursor
                Dim psvADRow As IRow

                psvQueryfilter = New QueryFilter
                psvQueryfilter.WhereClause = "ID = " & psvAdrID
                'Addr Log Table
                psvADCur = m_pAddrTable.Search(psvQueryfilter, False) 'changed this one
                psvADRow = psvADCur.NextRow
                If Not psvADRow Is Nothing Then
                    If Not IsDBNull(txtAdrWONum.Text) And Not txtAdrWONum.Text Is Nothing Then
                        psvADRow.Value(psvADRow.Fields.FindField(ADRLG_WRKORDID_FLD_NAME)) = txtAdrWONum.Text
                    End If
                    If Not IsDBNull(cboAdrCompleted.Text) And Not cboAdrCompleted.Text Is Nothing Then
                        psvADRow.Value(psvADRow.Fields.FindField(ADRLG_COMPLETED_FLD_NAME)) = cboAdrCompleted.Text
                    End If
                    If Not IsDBNull(txtAdrAPN.Text) And Not txtAdrAPN.Text Is Nothing Then
                        psvADRow.Value(psvADRow.Fields.FindField(ADRLG_APN_FLD_NAME)) = txtAdrAPN.Text
                    End If
                    If Not IsDBNull(txtAdrMapName.Text) And Not txtAdrMapName.Text Is Nothing Then
                        psvADRow.Value(psvADRow.Fields.FindField(ADRLG_MAPNAME_FLD_NAME)) = txtAdrMapName.Text
                    End If

                    psvADRow.Store()

                    MsgBox("Upaded Address Log for ID: " & psvAdrID)
                    btnAdrLgReset.PerformClick()
                    psvADRow = Nothing
                End If
            Else
                MsgBox("City Address ID must be Numeric")
            End If

        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

    Private Sub txtRdSearchQF_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRdSearchQF.TextChanged

    End Sub

    Private Sub btnExportData_Click(sender As System.Object, e As System.EventArgs) Handles btnExportData.Click
        ExportToExcel.ExportDGVtoExcel(dgvAdrLogList)
    End Sub
End Class