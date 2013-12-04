Imports System.Runtime.InteropServices
Imports System.Drawing
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.ArcMapUI
Imports System.Windows.Forms
Imports ESRI.ArcGIS.Controls
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Editor
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Geodatabase
Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.esriSystem

Public Class frmAddRoadSegAlias
    Private m_pFeat As IFeature
    Private m_pWKSP As IWorkspace
    Private m_ActiveView As IActiveView

#Region "Primaries"

    Private Sub frmAddRoadSegAlias_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            'Fill the form dropdowns
            Dim pFieldList As New List(Of String)
            pFieldList.Add(RD_LMIXADDR_FLD_NAME)
            pFieldList.Add(RD_RMIXADDR_FLD_NAME)
            cboLMix.Items.Clear()
            cboRMix.Items.Clear()
            Dim pcodedvldomain As ICodedValueDomain
            Dim intDomainCount As Integer
            For Each FieldName As String In pFieldList
                pcodedvldomain = Nothing
                pcodedvldomain = GetDmn(m_pWKSP, m_pFeat.Class, FieldName)
                For intDomainCount = 0 To (pcodedvldomain.CodeCount - 1)
                    If FieldName = RD_LMIXADDR_FLD_NAME Then
                        cboLMix.Items.Add(pcodedvldomain.Name(intDomainCount))
                    ElseIf FieldName = RD_RMIXADDR_FLD_NAME Then
                        cboRMix.Items.Add(pcodedvldomain.Name(intDomainCount))
                    End If
                Next
            Next
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Properties"

    Public Property Seg() As IFeature
        '-this property will be set before the form is opened so the user can scroll thru all selected roads on the map
        Get
            Return m_pFeat
        End Get

        Set(ByVal feat As IFeature)
            m_pFeat = feat
        End Set

    End Property

    Public Property Workspace() As IWorkspace
        '-this property will be set before the form is opened so the user can scroll thru all selected roads on the map
        Get
            Return m_pWKSP
        End Get

        Set(ByVal WS As IWorkspace)
            m_pWKSP = WS
        End Set

    End Property

    Public Property FrmMap() As IActiveView
        Get
            Return m_ActiveView
        End Get

        Set(ByVal ActiveView As IActiveView)
            m_ActiveView = ActiveView
        End Set

    End Property

#End Region

#Region "Form Controls"

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            Dim pversionW As IVersionedWorkspace

            pversionW = m_pWKSP
            Dim pVersion As IVersion
            pVersion = pversionW
            Dim pversioninfo As IVersionInfo
            pversioninfo = pVersion.VersionInfo
            Dim pFeatWorkSpace As IFeatureWorkspace
            pFeatWorkSpace = m_pWKSP 'QI
            Dim pTable As ITable
            pTable = pFeatWorkSpace.OpenTable(ROADSEG_ALIAS_DATASRC)
            If pTable Is Nothing Then
                MsgBox("Could not open the road seg alias table, this operation has failed")
                Me.Close()
                Exit Sub
            End If
            Dim pRow As IRow
            Dim nVal As Int32
            Dim pSrchVal As String
            Dim tVal As String
            pRow = pTable.CreateRow
            pRow.Value(pRow.Fields.FindField(RDSEG_ALIAS_ROADSEGID_FLD_NAME)) = m_pFeat.Value(m_pFeat.Fields.FindField(RD_ROADSEGID_FLD_NAME))
            pRow.Value(pRow.Fields.FindField(RDSEG_ALIAS_POSTDATE_FLD_NAME)) = Date.Now
            pRow.Value(pRow.Fields.FindField(RDSEG_ALIAS_POSTID_FLD_NAME)) = Environment.UserName

            pRow.Value(pRow.Fields.FindField(RDSEG_ALIAS_PREDIR_FLD_NAME)) = txtPreDir.Text
            pRow.Value(pRow.Fields.FindField(RDSEG_ALIAS_NAME_FLD_NAME)) = txtName.Text
            pRow.Value(pRow.Fields.FindField(RDSEG_ALIAS_SUFFIX_FLD_NAME)) = txtSuffix.Text
            pRow.Value(pRow.Fields.FindField(RDSEG_ALIAS_POST_FLD_NAME)) = txtPostDir.Text
            nVal = CType(txtLLAddress.Text, Int32)
            pRow.Value(pRow.Fields.FindField(RDSEG_ALIAS_LLOW_FLD_NAME)) = nVal
            nVal = CType(txtRLAddress.Text, Int32)
            pRow.Value(pRow.Fields.FindField(RDSEG_ALIAS_RLOW_FLD_NAME)) = nVal
            nVal = CType(txtLHAddress.Text, Int32)
            pRow.Value(pRow.Fields.FindField(RDSEG_ALIAS_LHI_FLD_NAME)) = nVal
            nVal = CType(txtRHAddress.Text, Int32)
            pRow.Value(pRow.Fields.FindField(RDSEG_ALIAS_RHI_FLD_NAME)) = nVal
            pSrchVal = ""
            pSrchVal = cboLMix.Text
            If Not pSrchVal = "" Then
                tVal = GetCddDmnValues(pFeatWorkSpace, m_pFeat.Class, RD_LMIXADDR_FLD_NAME, "GetCode", pSrchVal)
                pRow.Value(pRow.Fields.FindField(RDSEG_ALIAS_LMIX_FLD_NAME)) = tVal
            End If
            pSrchVal = ""
            pSrchVal = cboRMix.Text
            If Not pSrchVal = "" Then
                tVal = GetCddDmnValues(pFeatWorkSpace, m_pFeat.Class, RD_RMIXADDR_FLD_NAME, "GetCode", pSrchVal)
                pRow.Value(pRow.Fields.FindField(RDSEG_ALIAS_RMIX_FLD_NAME)) = tVal
            End If

            pRow.Store()

            Me.Close()
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub txtLLAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLLAddress.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtLLAddress.Text) And Not txtLLAddress.Text = "" Then
                MsgBox("Addr must be numeric")
                Exit Sub
            End If
            txtRLAddress.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtRLAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRLAddress.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtRLAddress.Text) And Not txtRLAddress.Text = "" Then
                MsgBox("Addr must be numeric")
                Exit Sub
            End If
            txtLHAddress.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtLHAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLHAddress.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtLHAddress.Text) And Not txtLHAddress.Text = "" Then
                MsgBox("Addr must be numeric")
                Exit Sub
            End If
            txtRHAddress.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub txtRHAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRHAddress.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            'do nothing 
        ElseIf e.KeyChar = vbBack Then
            'do nothing
        ElseIf e.KeyChar = vbTab Then
            If Not IsNumeric(txtRHAddress.Text) And Not txtRHAddress.Text = "" Then
                MsgBox("Addr must be numeric")
                Exit Sub
            End If
            cboLMix.Focus()
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub

#End Region

End Class