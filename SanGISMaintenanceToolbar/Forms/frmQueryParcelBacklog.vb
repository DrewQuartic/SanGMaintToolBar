
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports SanGISMaintenanceToolbar.Globals


Public Class frmQueryParcelBacklog
    Dim m_pWKSP As IWorkspace
    Dim m_ActiveView As IActiveView
    Dim m_pParBckTable As ITable
    ' Dim m_pOldTable As ITable
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

    Private Sub QueryMisingAPNs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim pTableSourcename As String
            pTableSourcename = V_PARCELBACKLOG_DATASRC
            m_pParBckTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename, True)
            If m_pParBckTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If

            'update maint area combobox
            Dim mai As Integer
            cboMaintAreas.Items.Clear()
            cboMaintAreas.Items.Add("")
            cboMaintAreas.Items.Add("ALL")
            cboMaintAreas.Items.Add("Dans")
            cboMaintAreas.Items.Add("Not Dans")
            For mai = 1 To 20
                cboMaintAreas.Items.Add(mai)
            Next
            cboMaintAreas.SelectedItem = 0
          
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub QueryMisingAPNs_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        m_ActiveView = Nothing
        m_pParBckTable = Nothing
        m_pWKSP = Nothing
        m_pWSE = Nothing
    End Sub

    Private Sub QueryMisingAPNs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F1 Then
            'No clear button here
        ElseIf e.KeyCode = Windows.Forms.Keys.F8 Then
            cboMaintAreas.Text = ""
        ElseIf e.KeyCode = Windows.Forms.Keys.F12 Then
            btnExit.PerformClick()
        End If
    End Sub

#End Region

#Region "Custom"

    Private Sub PopGridList()
        Try
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Dim pRDIDQF As IQueryFilter
            pRDIDQF = New QueryFilter
            If cboMaintAreas.Text = "" Or cboMaintAreas.Text = "ALL" Then
                m_TWWhereClause = "APN IS NOT NULL"
            ElseIf cboMaintAreas.Text = "Dans" Then
                m_TWWhereClause = "MAINT_AREA IN (10,11,12,13,16,17,18,19,20)"
            ElseIf cboMaintAreas.Text = "Not Dans" Then
                m_TWWhereClause = "MAINT_AREA NOT IN (10,11,12,13,16,17,18,19,20)"
            Else
                m_TWWhereClause = "MAINT_AREA = " & cboMaintAreas.Text
            End If
            pRDIDQF.WhereClause = m_TWWhereClause
            m_TWPostfixClause = "Order By MAINT_AREA,APN"

            'check if any selected
            'Dim pRwCnt As Integer
            'pRwCnt = m_pParBckTable.RowCount(pRDIDQF)

            'lblFndCnt.Text = pRwCnt
            'If pRwCnt > 0 And pRwCnt < 1001 Then
            FillGridData()
            'ElseIf pRwCnt > 1000 Then
            'Dim prowlots As MsgBoxResult
            'prowlots = MsgBox(pRwCnt & " Records found, press OK to continue, CANCEL to start new search", MsgBoxStyle.OkCancel, "Thats a Lot of Records!")
            'If prowlots = MsgBoxResult.Ok Then
            '    FillGridData()
            'End If
            'Else
            'MsgBox("No Missing APN records found matching search criteria", MsgBoxStyle.Information)
            'End If
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
            tableWrapper = New ArcDataBinding.TableWrapper(m_pParBckTable)
            dgMissingAPN.DataSource = tableWrapper
            With dgMissingAPN
                .Columns("MAINT_AREA").DisplayIndex = 0
                .Columns("MAINT_AREA").Width = 80
                .Columns("MAINT_AREA").HeaderText = "MAINT_AREA"

                .Columns("APN").DisplayIndex = 1
                .Columns("APN").Width = 80
                .Columns("APN").HeaderText = "APN"

                .Columns("CUT_NUM").DisplayIndex = 2
                .Columns("CUT_NUM").Width = 55
                .Columns("CUT_NUM").HeaderText = "CUT NUM"

                .Columns("DATERC").DisplayIndex = 3
                .Columns("DATERC").Width = 65
                .Columns("DATERC").HeaderText = "Sangis Date"

                .Columns("SUBMAP").DisplayIndex = 4
                .Columns("SUBMAP").Width = 90
                .Columns("SUBMAP").HeaderText = "SubMap"
 
                .Columns("ORIG_CUT_NO").DisplayIndex = 5
                .Columns("ORIG_CUT_NO").Width = 55
                .Columns("ORIG_CUT_NO").HeaderText = "Org CutNo"

                .Columns("ORIG_CUT_DATE").DisplayIndex = 6
                .Columns("ORIG_CUT_DATE").Width = 55
                .Columns("ORIG_CUT_DATE").HeaderText = "Org CutDate"

                .Columns("BOOK").DisplayIndex = 7
                .Columns("BOOK").Width = 75
                .Columns("BOOK").HeaderText = "BOOK"

                .Columns("CONDO").DisplayIndex = 8
                .Columns("CONDO").Width = 75
                .Columns("CONDO").HeaderText = "CONDO"

                .Columns("REGPARCEL").DisplayIndex = 9
                .Columns("REGPARCEL").Width = 75
                .Columns("REGPARCEL").HeaderText = "REGPARCEL"

                .Columns("LEGLDESC").DisplayIndex = 10
                .Columns("LEGLDESC").Width = 260
                .Columns("LEGLDESC").HeaderText = "Legal Description"

                .Columns("DOCDATE").DisplayIndex = 11
                .Columns("DOCDATE").Width = 50
                .Columns("DOCDATE").HeaderText = "Doc Date"

                .Columns("DOCNMBR").DisplayIndex = 12
                .Columns("DOCNMBR").Width = 50
                .Columns("DOCNMBR").HeaderText = "Doc No"

                .Columns("RED_CUT_DATE").DisplayIndex = 13
                .Columns("RED_CUT_DATE").Width = 65
                .Columns("RED_CUT_DATE").HeaderText = "Reparcel CutDate"

                .Columns("RED_CUT_NO").DisplayIndex = 14
                .Columns("RED_CUT_NO").Width = 75
                .Columns("RED_CUT_NO").HeaderText = "Reparcel CutNo"

            End With
            Cursor.Current = Windows.Forms.Cursors.Default
            lblFndCnt.Text = dgMissingAPN.RowCount
            'dgRSGRD.Focus()
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Form Controls"

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

    Private Sub btnExportData_Click(sender As System.Object, e As System.EventArgs) Handles btnExportData.Click
        ExportToExcel.ExportDGVtoExcel(dgMissingAPN)
    End Sub


    Private Sub cboMaintAreas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMaintAreas.SelectedIndexChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Try
                If cboMaintAreas.Text = "" Then
                    dgMissingAPN.DataSource = Nothing
                    lblFndCnt.Text = "0"                  
                Else
                    'Fill it
                    PopGridList()
                End If
            Catch ex As Exception
                Cursor.Current = Windows.Forms.Cursors.Default
                Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
                Me.Close()
            End Try
        End If
    End Sub
End Class