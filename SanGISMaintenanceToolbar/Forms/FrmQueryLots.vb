Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports SanGISMaintenanceToolbar.Globals
Public Class FrmQueryLots
    Dim m_pWKSP As IWorkspace
    Dim m_ActiveView As IActiveView
    Dim m_pLotTable As ITable
    Dim m_pWSE As IWorkspaceEdit
    Dim m_SubDivID As String = ""
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

    Public Property pSubDivID() As String
        Get
            Return m_SubDivID
        End Get
        Set(ByVal vSubDivID As String)
            m_SubDivID = vSubDivID
            If vSubDivID <> "" Then
                txtLOTSubDivID.Text = vSubDivID
            End If
        End Set
    End Property

#End Region

#Region "Primaries Form"

    Private Sub FrmQueryLots_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        m_ActiveView = Nothing
        m_pLotTable = Nothing
        m_pWKSP = Nothing
        m_pWSE = Nothing
    End Sub

    Private Sub FrmQueryLots_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim pTableSourcename As String
            pTableSourcename = V_LOTSUBDIVINFO_DATASRC
            m_pLotTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename, True)
            If m_pLotTable Is Nothing Then
                Me.Close()
                Exit Sub
            Else
                If m_SubDivID <> "" Then
                    'Populate the sort by combo box
                    'Build the combobox
                    cboLotSort.Items.Add("ADDRNO")
                    cboLotSort.Items.Add("LOTNO")
                    cboLotSort.Items.Add("APN")
                    cboLotSort.Items.Add("ROAD20_NM")
                    cboLotSort.Text = "ADDRNO"
                    'fill the grid
                    PopGridList(m_SubDivID)
                Else
                    MsgBox("Bad SubDivID")
                    Me.Close()
                    Exit Sub
                End If
            End If
            'End If

        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Custom"

    Private Sub PopGridList(ByVal pqRDID As String)
        Try
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Dim pRDIDQF As IQueryFilter
            Dim pRDID As String
            Dim pOrdby As String
            pOrdby = cboLotSort.Text
            pRDID = pqRDID
            pRDIDQF = New QueryFilter

            If pRDID <> "" Then
                m_TWWhereClause = "SUBDIVID = " & pRDID
                pRDIDQF.WhereClause = m_TWWhereClause
                m_TWPostfixClause = "Order By " & pOrdby
            Else
                MsgBox("No Valid SUBDIV ID selected.")
                Cursor.Current = Windows.Forms.Cursors.Default
                Exit Sub
            End If
            'check if any selected
            Dim pRwCnt As Integer
            pRwCnt = m_pLotTable.RowCount(pRDIDQF)

            lblLotFndCnt.Text = pRwCnt
            If pRwCnt > 0 And pRwCnt < 1001 Then
                lblNoneFound.Visible = False
                FillGridData()
            ElseIf pRwCnt > 1000 Then
                lblNoneFound.Visible = False
                Dim prowlots As MsgBoxResult
                prowlots = MsgBox(pRwCnt & " Records found, press OK to continue, CANCEL to start new search", MsgBoxStyle.OkCancel, "Thats a Lot of Records!")
                If prowlots = MsgBoxResult.Ok Then
                    FillGridData()
                End If
            Else
                lblNoneFound.Visible = True
                'MsgBox("No SUBDIVID records found matching search criteria", MsgBoxStyle.Information)
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
            tableWrapper = New ArcDataBinding.TableWrapper(m_pLotTable)
            dgLotInfo.DataSource = tableWrapper
            With dgLotInfo
                .Columns("ADDRNO").DisplayIndex = 0
                .Columns("ADDRNO").Width = 50
                .Columns("ADDRNO").HeaderText = "Addrno"

                .Columns("ADDRFRAC").DisplayIndex = 1
                .Columns("ADDRFRAC").Width = 30
                .Columns("ADDRFRAC").HeaderText = "Frac"

                .Columns("ADDRUNIT").DisplayIndex = 2
                .Columns("ADDRUNIT").Width = 30
                .Columns("ADDRUNIT").HeaderText = "Unit"

                .Columns("ROAD20_PREDIR_IND").DisplayIndex = 3
                .Columns("ROAD20_PREDIR_IND").Width = 30
                .Columns("ROAD20_PREDIR_IND").HeaderText = "Pdir"

                .Columns("ROAD20_NM").DisplayIndex = 4
                .Columns("ROAD20_NM").Width = 180
                .Columns("ROAD20_NM").HeaderText = "Road20"

                .Columns("ROAD20_SUFFIX_NM").DisplayIndex = 5
                .Columns("ROAD20_SUFFIX_NM").Width = 30
                .Columns("ROAD20_SUFFIX_NM").HeaderText = "Sfx"

                .Columns("BLOCKNO").DisplayIndex = 6
                .Columns("BLOCKNO").Width = 55
                .Columns("BLOCKNO").HeaderText = "Blockno"

                .Columns("LOTNO").DisplayIndex = 7
                .Columns("LOTNO").Width = 55
                .Columns("LOTNO").HeaderText = "Lotno"

                .Columns("LOTID").DisplayIndex = 8
                .Columns("LOTID").Width = 55
                .Columns("LOTID").HeaderText = "Lotid"

                .Columns("APN").DisplayIndex = 9
                .Columns("APN").Width = 80
                .Columns("APN").HeaderText = "APN"


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

#Region "Form Controls"

    Private Sub btnLotExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLotExit.Click
        Me.Close()
    End Sub

    Private Sub cboLotSort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotSort.SelectedIndexChanged
        dgLotInfo.DataSource = Nothing
        PopGridList(m_SubDivID)
    End Sub

#End Region

    Private Sub btnExporttoExcelAdr_Click(sender As System.Object, e As System.EventArgs) Handles btnExporttoExcel.Click
        ExportToExcel.ExportDGVtoExcel(dgLotInfo)
    End Sub
End Class