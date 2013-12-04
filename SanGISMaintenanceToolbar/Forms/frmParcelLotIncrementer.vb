
Imports System.Runtime.InteropServices
Imports ESRI.ArcGIS.Framework
Imports System.Windows.Forms
Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Carto



Public Class frmParcelLotIncrementer
    Private IncApp As IApplication
    Private CrntCntrl As String


#Region "Properties"

    Public Property MapApp() As IApplication
        Get
            Return IncApp
        End Get

        Set(ByVal PassApp As IApplication)
            IncApp = PassApp
        End Set

    End Property

#End Region

#Region "Primaries Form"

    Private Sub frmParcelLotIncrementer_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        'Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub

    Private Sub frmParcelLotIncrementer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cboSubDivIDs.SelectedIndex = 0
        IncApp.CurrentTool = Nothing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub frmParcelLotIncrementer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        'Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Cross
    End Sub

    Private Sub frmParcelLotIncrementer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cboSubDivIDs.Items.Clear()
        cboSubDivIDs.Items.Add("NONE")
        cboSubDivIDs.SelectedIndex = 0
    End Sub

#End Region

#Region "Custom"

    Private Sub ChangeToLotLayout()
        txtPG.Visible = False
        txtBK.Visible = False
        txtSID.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        Label4.Visible = False
        lblSubdivID.Visible = True
        cboSubDivIDs.Visible = True
        btnSubDivLst.Visible = True
        Label3.Width = 41
        Label3.Left = 80
        Label3.Text = "Next Lot Number"
        txtCurrentValue.MaxLength = 0
        txtCurrentValue.Left = 100
        txtCurrentValue.Text = 0
        If Me.Visible Then
            txtCurrentValue.Focus()
        End If
    End Sub

    Private Sub ChangeToParcelLayout()
        txtPG.Visible = True
        txtBK.Visible = True
        txtSID.Visible = True
        Label1.Visible = True
        Label2.Visible = True
        Label4.Visible = True
        lblSubdivID.Visible = False
        cboSubDivIDs.Visible = False
        btnSubDivLst.Visible = False
        Label3.Width = 12
        Label3.Left = 150
        Label3.Text = "ParNo"
        txtCurrentValue.MaxLength = 2
        txtCurrentValue.Left = 153
        txtCurrentValue.Text = "01"
        txtBK.Focus()
    End Sub

#End Region

#Region "Text boxes"

    Private Sub txtPG_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPG.GotFocus
        txtPG.SelectionStart = 0
        txtPG.SelectionLength = Len(txtPG.Text)
    End Sub

    Private Sub txtPG_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPG.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'ok
        ElseIf e.KeyChar = vbBack Then
            'ok
        ElseIf e.KeyChar = vbTab Then
            txtCurrentValue.Focus()
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtBK_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBK.GotFocus
        txtBK.SelectionStart = 0
        txtBK.SelectionLength = Len(txtBK.Text)
    End Sub

    Private Sub txtBK_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBK.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'ok
        ElseIf e.KeyChar = vbBack Then
            'ok
        ElseIf e.KeyChar = vbTab Then
            txtPG.Focus()
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCurrentValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCurrentValue.GotFocus
        txtCurrentValue.SelectionStart = 0
        txtCurrentValue.SelectionLength = Len(txtCurrentValue.Text)
    End Sub

    Private Sub txtCurrentValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCurrentValue.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'ok
        ElseIf e.KeyChar = vbBack Then
            'ok
        ElseIf e.KeyChar = vbTab Then
            If optParcelAPN.Checked Then
                txtSID.Focus()
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtSID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSID.GotFocus
        txtSID.SelectionStart = 0
        txtSID.SelectionLength = Len(txtSID.Text)
    End Sub

    Private Sub txtSID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSID.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'ok
        ElseIf e.KeyChar = vbBack Then
            'ok
        ElseIf e.KeyChar = vbTab Then
            txtBK.Focus()
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtBK_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBK.TextChanged
        If txtBK.Text.Length = 3 Then
            txtPG.Focus()
        End If
    End Sub

    Private Sub txtPG_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPG.TextChanged
        If txtPG.Text.Length = 3 Then
            txtCurrentValue.Focus()
        End If
    End Sub

    Private Sub txtCurrentValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCurrentValue.TextChanged
        If txtCurrentValue.Text.Length = 2 And optParcelAPN.Checked = True Then
            txtSID.Focus()
        End If
    End Sub

    Private Sub txtSID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSID.TextChanged
        If txtSID.Text.Length = 2 Then
            txtBK.Focus()
        End If
    End Sub

#End Region

#Region "Other form controls"

    Private Sub btnSubDivLst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubDivLst.Click
        Try
            Dim pFeatLayer As IFeatureLayer
            pFeatLayer = GetLayerByName(IncApp.Document, LOT_DATASRC)
            Dim pDS As IDataset, pFWS As IFeatureWorkspace
            pDS = pFeatLayer.FeatureClass   'QI
            pFWS = pDS.Workspace
            Dim pSubDiv_ATR As ITable
            pSubDiv_ATR = pFWS.OpenTable(SUBDIV_ATR_DATASRC)

            Dim pSubDivCursor As ICursor
            Dim pData As IDataStatistics
            Dim pEnumerator As System.Collections.IEnumerator = Nothing

            '-get an array of unique SubDivID's from the SubDiv_ATR table
            '-first, set the mouse cursor to the "hourglass" (this might take a while!)
            System.Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            '-set required variables to get the SubDiv_ATR table

            Dim pTableSort As ITableSort
            pTableSort = New TableSort
            With pTableSort
                .Fields = SUBDIV_ATR_SUBDIVID_FLD_NAME
                .Ascending(SUBDIV_ATR_SUBDIVID_FLD_NAME) = True
                .CaseSensitive(SUBDIV_ATR_SUBDIVID_FLD_NAME) = False
                .QueryFilter = Nothing
                .Table = pSubDiv_ATR
            End With

            pTableSort.Sort(Nothing)
            pSubDivCursor = pTableSort.Rows

            pData = New DataStatistics
            pData.Field = SUBDIV_ATR_SUBDIVID_FLD_NAME
            pData.Cursor = pSubDivCursor
            pEnumerator = pData.UniqueValues
            pEnumerator.Reset()
            Do While pEnumerator.MoveNext
                cboSubDivIDs.Items.Add(pEnumerator.Current.ToString)
            Loop

            System.Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Exit Sub
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Private Sub cboSubDivIDs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSubDivIDs.KeyPress
        'Only allow numbers and backspace
        Dim keyInput As String = e.KeyChar.ToString()
        If Char.IsNumber(e.KeyChar) Then
        ElseIf e.KeyChar = vbBack Then
        ElseIf e.KeyChar = vbTab Then

        Else
            e.Handled = True
        End If

    End Sub

    Private Sub optParcelAPN_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optParcelAPN.CheckedChanged
        If optParcelAPN.Checked Then
            ChangeToParcelLayout()
        Else
            'ChangeToLotLayout()
        End If
    End Sub

    Private Sub optLotBlock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optLotBlock.CheckedChanged
        If optLotBlock.Checked Then
            ChangeToLotLayout()
        Else
            'ChangeToParcelLayout()
        End If

    End Sub

#End Region

End Class