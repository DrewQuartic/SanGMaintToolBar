
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

Public Class frmPasteRoadAttributes
    Private m_pMXDoc As IMxDocument
    Private m_pRoadFC As IFeatureClass 'module variable to reference the Roads dataset
    Private m_pRoadOIDs As IEnumIDs  'module variable to contain the currently selected road features (FIDs)
    Private m_intCurrentOID As Long 'variable containing the current feature ID
    Private m_pCurrentFeature As IFeature 'variable to track the currently highlighted feature
    Private m_pWrkspace As IWorkspace
    Private pFieldList As New List(Of String)
 
    '-variant array of unique Road IDs (from RoadName table)
    Private m_vRoadIDs As Object

    Dim m_ActiveView As IActiveView
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

    Public Property Roads() As IEnumIDs
        '-this property will be set before the form is opened so the user can scroll thru all selected roads on the map
        Get
            Return m_pRoadOIDs
        End Get

        Set(ByVal ids As IEnumIDs)
            m_pRoadOIDs = ids
        End Set

    End Property

    Public Property RoadDataset() As IFeatureClass

        '-this property will be set before the form is opened so the user can scroll thru all selected roads on the map
        Get
            Return m_pRoadFC
        End Get

        Set(ByVal fc As IFeatureClass)
            m_pRoadFC = fc
        End Set

    End Property

    Public Property MapDoc() As IMxDocument
        Get
            Return m_pMXDoc
        End Get
        Set(ByVal Map As IMxDocument)
            m_pMXDoc = Map
        End Set
    End Property
#End Region

#Region "Primaries Form"
    Private Sub frmPasteRoadAttributes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        DeleteGraphicByName(m_pMXDoc, "RoadGraphic")
        m_pMXDoc.ActiveView.Refresh()
        m_pMXDoc = Nothing
        m_pRoadFC = Nothing
        m_pRoadOIDs = Nothing
        m_pCurrentFeature = Nothing
    End Sub

    Private Sub frmPasteRoadAttributes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Fill the field list
            pFieldList.Add(RD_SEGCLASS_FLD_NAME)
            pFieldList.Add(RD_ONEWAY_FLD_NAME)
            pFieldList.Add(RD_FIREDRIV_FLD_NAME)
            pFieldList.Add(RD_SEGSTAT_FLD_NAME)
            pFieldList.Add(RD_CARTO_FLD_NAME)
            pFieldList.Add(RD_DEDSTAT_FLD_NAME)
            pFieldList.Add(RD_RJURIS_FLD_NAME)
            pFieldList.Add(RD_LJURIS_FLD_NAME)
            pFieldList.Add(RD_LMIXADDR_FLD_NAME)
            pFieldList.Add(RD_RMIXADDR_FLD_NAME)
            pFieldList.Add(RD_OBMH_FLD_NAME)
            pFieldList.Add(RD_FUNCLASS_FLD_NAME)
            pFieldList.Add(RD_L_ZIP_FLD_NAME)
            pFieldList.Add(RD_R_ZIP_FLD_NAME)
            pFieldList.Add(RD_FLEVEL_FLD_NAME)
            pFieldList.Add(RD_TLEVEL_FLD_NAME)

            '-move the pointer above the first OID in the enum
            m_pRoadOIDs.Reset()

            '-get the first OID
            m_intCurrentOID = m_pRoadOIDs.Next

            If m_intCurrentOID < 0 Then
                MsgBox("no Object Id's found", vbCritical, frmPasteRoadAttributes.ActiveForm)
                Exit Sub 'when no ID is found in the enum, -1 is returned
            End If
            '-get a feature using it's OID
            m_pCurrentFeature = m_pRoadFC.GetFeature(m_intCurrentOID)
            m_pWrkspace = m_pRoadFC.FeatureDataset.Workspace
            '-call a sub that will fill the form controls with values for the current feature (segment)
            FillFormControls()
            '-disable the save button (until a change is made)
            btnSave.Enabled = False
            '-call a sub that will highlight the segment currently being edited (with a red line graphic)
            HighlightRoad()
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub
 
#End Region

#Region "Custom"

    Private Sub HighlightRoad()
        Try

            'This sub will draw a red line graphic to highlight the road that is currently being edited
            Dim pElem As IElement
            pElem = MakeRoadGraphic(m_pCurrentFeature.ShapeCopy)
            m_pMXDoc.ActiveView.GraphicsContainer.AddElement(pElem, 0)
            m_pMXDoc.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, Nothing, m_pMXDoc.ActiveView.Extent)

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub Enabler()
        Try
            'centralized logic to control whether the "Save" button is enabled or not
            'called from all (most) controls on the form

            'If the RoadID value is -99999 then disable
            If cboRoadIDs.Text = "-99999" Then
                btnSave.Enabled = False
            Else
                btnSave.Enabled = True
            End If
            '-if the road ID has not been set with an appropriate value, make the control red
            If cboRoadIDs.Text = "" Or InStr(cboRoadIDs.Text, "-9") > 0 Then
                cboRoadIDs.BackColor = Color.MediumVioletRed
            Else
                cboRoadIDs.BackColor = Color.White
            End If
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try

    End Sub

    Private Sub FillFormControls()

        Try
            Dim strFrameCaption As String
            strFrameCaption = "Segment ID: " & m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_ROADSEGID_FLD_NAME))

            cboSegClass.Items.Clear()
            cboOneWay.Items.Clear()
            cboFireDriv.Items.Clear()
            cboSegStat.Items.Clear()
            cboCarto.Items.Clear()
            cboDedStat.Items.Clear()
            cboRJurisdic.Items.Clear()
            cboLJurisdic.Items.Clear()
            cboLMixAddr.Items.Clear()
            cboRMixAddr.Items.Clear()
            cboOBMH.Items.Clear()
            cboFunClass.Items.Clear()
            cboOBMH.Items.Clear()
            cboFunClass.Items.Clear()

            Dim pcodedvldomain As ICodedValueDomain
            Dim intDomainCount As Integer
            For Each FieldName As String In pFieldList
                pcodedvldomain = Nothing
                pcodedvldomain = GetDmn(m_pWrkspace, m_pRoadFC, FieldName)
                For intDomainCount = 0 To (pcodedvldomain.CodeCount - 1)
                    If FieldName = RD_SEGCLASS_FLD_NAME Then
                        cboSegClass.Items.Add(pcodedvldomain.Name(intDomainCount))
                    ElseIf FieldName = RD_ONEWAY_FLD_NAME Then
                        cboOneWay.Items.Add(pcodedvldomain.Name(intDomainCount))
                    ElseIf FieldName = RD_FIREDRIV_FLD_NAME Then
                        cboFireDriv.Items.Add(pcodedvldomain.Name(intDomainCount))
                    ElseIf FieldName = RD_SEGSTAT_FLD_NAME Then
                        cboSegStat.Items.Add(pcodedvldomain.Name(intDomainCount))
                    ElseIf FieldName = RD_CARTO_FLD_NAME Then
                        cboCarto.Items.Add(pcodedvldomain.Name(intDomainCount))
                    ElseIf FieldName = RD_DEDSTAT_FLD_NAME Then
                        cboDedStat.Items.Add(pcodedvldomain.Name(intDomainCount))
                    ElseIf FieldName = RD_RJURIS_FLD_NAME Then
                        cboRJurisdic.Items.Add(pcodedvldomain.Name(intDomainCount))
                    ElseIf FieldName = RD_LJURIS_FLD_NAME Then
                        cboLJurisdic.Items.Add(pcodedvldomain.Name(intDomainCount))
                    ElseIf FieldName = RD_LMIXADDR_FLD_NAME Then
                        cboLMixAddr.Items.Add(pcodedvldomain.Name(intDomainCount))
                    ElseIf FieldName = RD_RMIXADDR_FLD_NAME Then
                        cboRMixAddr.Items.Add(pcodedvldomain.Name(intDomainCount))
                    ElseIf FieldName = RD_OBMH_FLD_NAME Then
                        cboOBMH.Items.Add(pcodedvldomain.Name(intDomainCount))
                    ElseIf FieldName = RD_FUNCLASS_FLD_NAME Then
                        cboFunClass.Items.Add(pcodedvldomain.Name(intDomainCount))
                    ElseIf FieldName = RD_L_ZIP_FLD_NAME Then
                        cboL_Zip.Items.Add(pcodedvldomain.Name(intDomainCount))
                    ElseIf FieldName = RD_R_ZIP_FLD_NAME Then
                        cboR_Zip.Items.Add(pcodedvldomain.Name(intDomainCount))
                    ElseIf FieldName = RD_FLEVEL_FLD_NAME Then
                        cboTLEV.Items.Add(pcodedvldomain.Name(intDomainCount))
                    ElseIf FieldName = RD_TLEVEL_FLD_NAME Then
                        cboFLEV.Items.Add(pcodedvldomain.Name(intDomainCount))
                    End If
                Next
            Next

            '-put the current RoadID into the form's combo box
            Dim vVal As String
            vVal = m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_ROADID_FLD_NAME))
            If Not IsDBNull(vVal) Then
                If (cboRoadIDs.Items.Count < 1) Then cboRoadIDs.Items.Add(vVal)
                cboRoadIDs.Text = vVal
            End If

            '-put the current values into the form controls
            Dim pFieldVal As String
            For Each FieldName As String In pFieldList
                If Not m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(FieldName)) Is Nothing And Not m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(FieldName)) Is System.DBNull.Value Then
                    pFieldVal = GetCddDmnValues(m_pWrkspace, m_pRoadFC, FieldName, "GetDescription", m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(FieldName)))
                    If FieldName = RD_SEGCLASS_FLD_NAME Then
                        cboSegClass.SelectedItem = pFieldVal
                    ElseIf FieldName = RD_ONEWAY_FLD_NAME Then
                        cboOneWay.SelectedItem = pFieldVal
                    ElseIf FieldName = RD_FIREDRIV_FLD_NAME Then
                        cboFireDriv.SelectedItem = pFieldVal
                    ElseIf FieldName = RD_SEGSTAT_FLD_NAME Then
                        cboSegStat.SelectedItem = pFieldVal
                    ElseIf FieldName = RD_CARTO_FLD_NAME Then
                        cboCarto.SelectedItem = pFieldVal
                    ElseIf FieldName = RD_DEDSTAT_FLD_NAME Then
                        cboDedStat.SelectedItem = pFieldVal
                    ElseIf FieldName = RD_RJURIS_FLD_NAME Then
                        cboRJurisdic.SelectedItem = pFieldVal
                    ElseIf FieldName = RD_LJURIS_FLD_NAME Then
                        cboLJurisdic.SelectedItem = pFieldVal
                    ElseIf FieldName = RD_LMIXADDR_FLD_NAME Then
                        cboLMixAddr.SelectedItem = pFieldVal
                    ElseIf FieldName = RD_RMIXADDR_FLD_NAME Then
                        cboRMixAddr.SelectedItem = pFieldVal
                    ElseIf FieldName = RD_OBMH_FLD_NAME Then
                        cboOBMH.SelectedItem = pFieldVal
                    ElseIf FieldName = RD_FUNCLASS_FLD_NAME Then
                        cboFunClass.SelectedItem = pFieldVal
                    ElseIf FieldName = RD_L_ZIP_FLD_NAME Then
                        cboL_Zip.SelectedItem = pFieldVal
                    ElseIf FieldName = RD_R_ZIP_FLD_NAME Then
                        cboR_Zip.SelectedItem = pFieldVal
                    ElseIf FieldName = RD_TLEVEL_FLD_NAME Then
                        cboTLEV.SelectedItem = pFieldVal
                    ElseIf FieldName = RD_FLEVEL_FLD_NAME Then
                        cboFLEV.SelectedItem = pFieldVal
                    End If
                Else
                    pFieldVal = ""
                End If

            Next

            vVal = m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_LHIGHADDR_FLD_NAME))
            If Not IsDBNull(vVal) Then txtAddrHL.Text = vVal
            vVal = m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_RHIGHADDR_FLD_NAME))
            If Not IsDBNull(vVal) Then txtAddrHR.Text = vVal
            vVal = m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_LLOWADDR_FLD_NAME))
            If Not IsDBNull(vVal) Then txtAddrLL.Text = vVal
            vVal = m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_RLOWADDR_FLD_NAME))
            If Not IsDBNull(vVal) Then txtAddrLR.Text = vVal
            vVal = m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_RIGHTWAY_FLD_NAME))
            If Not IsDBNull(vVal) Then txtRightWay.Text = vVal
            'vVal = m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD__FLD_NAME))
            'If Not IsDBNull(vVal) Then txtTravelWay.Text = vVal
            vVal = m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_SPEED_FLD_NAME))
            If Not IsDBNull(vVal) Then txtSpeed.Text = vVal

            '-set the frame's caption to identify the current segment
            gbSegInfo.Text = strFrameCaption
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub WriteRoadEdits()
        Try
            'This sub will write all the info provided on the form to the attribute table for the current feature
            Dim strErrorMsg As String, bIDisOK As Boolean
            '-get each value from the form's combo boxes, update the current feature's attributes
            '--RoadID
            strErrorMsg = "Invalid RoadID (value not found in the RoadName table)"
            bIDisOK = VerifyRoadID(CLng(cboRoadIDs.Text))
            If Not bIDisOK Then
                MsgBox(strErrorMsg, MsgBoxStyle.Exclamation, "Edits Not Saved")
                Exit Sub
            End If
            strErrorMsg = "?"
            m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_ROADID_FLD_NAME)) = CLng(cboRoadIDs.Text)
            '--Address Range
            strErrorMsg = "Invalid address range value"
            Dim nVal As Int32
            nVal = CType(txtAddrHL.Text, Int32)
            m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_LHIGHADDR_FLD_NAME)) = nVal
            nVal = CType(txtAddrHR.Text, Int32)
            m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_RHIGHADDR_FLD_NAME)) = nVal
            nVal = CType(txtAddrLL.Text, Int32)
            m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_LLOWADDR_FLD_NAME)) = nVal
            nVal = CType(txtAddrLR.Text, Int32)
            m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_RLOWADDR_FLD_NAME)) = nVal
            strErrorMsg = "?"

            '--Rightway
            nVal = CType(txtRightWay.Text, Int32)
            m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_RIGHTWAY_FLD_NAME)) = nVal
            '--Speed
            nVal = CType(txtSpeed.Text, Int32)
            m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_SPEED_FLD_NAME)) = nVal

            nVal = CType(cboFLEV.Text, Short)
            m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_FLEVEL_FLD_NAME)) = nVal
            nVal = CType(cboTLEV.Text, Short)
            m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(RD_TLEVEL_FLD_NAME)) = nVal

            Dim tVal As String
            Dim pSrchVal As String
            For Each FieldName As String In pFieldList
                If FieldName = RD_SEGCLASS_FLD_NAME And cboSegClass.SelectedIndex <> -1 Then
                    pSrchVal = cboSegClass.Text
                ElseIf FieldName = RD_ONEWAY_FLD_NAME And cboSegClass.SelectedIndex <> -1 Then
                    pSrchVal = cboSegClass.Text
                ElseIf FieldName = RD_FIREDRIV_FLD_NAME And cboFireDriv.SelectedIndex <> -1 Then
                    pSrchVal = cboFireDriv.Text
                ElseIf FieldName = RD_SEGSTAT_FLD_NAME And cboSegStat.SelectedIndex <> -1 Then
                    pSrchVal = cboSegStat.Text
                ElseIf FieldName = RD_CARTO_FLD_NAME And cboCarto.SelectedIndex <> -1 Then
                    pSrchVal = cboCarto.Text
                ElseIf FieldName = RD_DEDSTAT_FLD_NAME And cboDedStat.SelectedIndex <> -1 Then
                    pSrchVal = cboDedStat.Text
                ElseIf FieldName = RD_RJURIS_FLD_NAME And cboRJurisdic.SelectedIndex <> -1 Then
                    pSrchVal = cboRJurisdic.Text
                ElseIf FieldName = RD_LJURIS_FLD_NAME And cboLJurisdic.SelectedIndex <> -1 Then
                    pSrchVal = cboLJurisdic.Text
                ElseIf FieldName = RD_LMIXADDR_FLD_NAME And cboLMixAddr.SelectedIndex <> -1 Then
                    pSrchVal = cboLMixAddr.Text
                ElseIf FieldName = RD_RMIXADDR_FLD_NAME And cboRMixAddr.SelectedIndex <> -1 Then
                    pSrchVal = cboRMixAddr.Text
                ElseIf FieldName = RD_OBMH_FLD_NAME And cboOBMH.SelectedIndex <> -1 Then
                    pSrchVal = cboOBMH.Text
                ElseIf FieldName = RD_FUNCLASS_FLD_NAME And cboFunClass.SelectedIndex <> -1 Then
                    pSrchVal = cboFunClass.Text
                ElseIf FieldName = RD_L_ZIP_FLD_NAME And cboL_Zip.SelectedIndex <> -1 Then
                    pSrchVal = cboL_Zip.Text
                ElseIf FieldName = RD_R_ZIP_FLD_NAME And cboR_Zip.SelectedIndex <> -1 Then
                    pSrchVal = cboR_Zip.Text
                Else
                    pSrchVal = ""
                End If
                If FieldName = RD_FIREDRIV_FLD_NAME And UCase(cboFireDriv.Text) <> "NO" Then
                    tVal = " "
                    m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(FieldName)) = tVal
                ElseIf pSrchVal <> "" Then
                    tVal = GetCddDmnValues(m_pWrkspace, m_pRoadFC, FieldName, "GetCode", pSrchVal)
                    m_pCurrentFeature.Value(m_pCurrentFeature.Fields.FindField(FieldName)) = tVal
                End If
            Next

            m_pCurrentFeature.Store()
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try

    End Sub

    Private Function VerifyRoadID(ByVal ID As Long) As Boolean
        Try
            'This function will check to see if the RoadID entered is valid (it exists in the RoadName table)
            '-set required variables to get the Roadname table
            Dim pDS As IDataset, pFWS As IFeatureWorkspace, pRoadNameTable As ITable
            Dim pRoadNameCursor As ICursor, pQF As IQueryFilter, pRec As IRow
            pDS = m_pRoadFC   'QI
            pFWS = pDS.Workspace
            '-get the table (constant for the data path name is set in the "Globals" module)
            pRoadNameTable = GetWorkspaceTable("ANY", FrmMap, ROAD_NAME_DATASRC, True)
            '-make a new query filter to find records with the passed in RoadID
            pQF = New QueryFilter
            pQF.WhereClause = RDNAME_ROADID_FLD_NAME & " = " & ID
            '-get a cursor of records that have the ID passed in (should be either 1 or 0)
            pRoadNameCursor = pRoadNameTable.Search(pQF, True)
            pRec = pRoadNameCursor.NextRow
            '-if a record was found, ID is valid, otherwise it is not
            VerifyRoadID = Not pRec Is Nothing
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Function

#End Region

#Region "Combo boxes and Check boxes"

    Private Sub cboSegClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSegClass.SelectedIndexChanged
        Try
            Select Case cboSegClass.Text
                Case "Freeway/Expressway"
                    txtSpeed.Text = "50"
                Case "Highway/State Route"
                    txtSpeed.Text = "45"
                Case "Minor Highway/Major Road"
                    txtSpeed.Text = "35"
                Case "Arterial or Collector"
                    txtSpeed.Text = "35"
                Case "Local Street"
                    txtSpeed.Text = "20"
                Case "Unpaved Road"
                    txtSpeed.Text = "8"
                Case "Private Road"
                    txtSpeed.Text = "10"
                Case "Freeway Tramsition Ramp"
                    txtSpeed.Text = "40"
                Case "Freeway On/Off Ramp"
                    txtSpeed.Text = "18"
                Case "Alley"
                    txtSpeed.Text = "10"
                Case "Speed Hump"
                    txtSpeed.Text = "5"
                Case "Military Street Within Base"
                    txtSpeed.Text = "15"
                Case "Paper Street"
                    txtSpeed.Text = "0"
                Case "Walkway"
                    txtSpeed.Text = "0"
                Case Else
                    txtSpeed.Text = "0"
            End Select
            Enabler()
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub cboDedStat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDedStat.SelectedIndexChanged
        Enabler()
    End Sub

    Private Sub cboLJurisdic_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLJurisdic.SelectedIndexChanged
        Enabler()
    End Sub

    Private Sub cboRJurisdic_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRJurisdic.SelectedIndexChanged
        Enabler()
    End Sub

    Private Sub cboFireDriv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFireDriv.SelectedIndexChanged
        Enabler()
    End Sub

    Private Sub cboSegStat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSegStat.SelectedIndexChanged
        Enabler()
    End Sub

    Private Sub cboFunClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFunClass.SelectedIndexChanged
        Enabler()
    End Sub

    Private Sub cboOneWay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOneWay.SelectedIndexChanged
        Enabler()
    End Sub

    Private Sub cboLMixAddr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLMixAddr.SelectedIndexChanged
        Enabler()
    End Sub

    Private Sub RMixAddr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRMixAddr.SelectedIndexChanged
        Enabler()
    End Sub

    Private Sub cboCarto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarto.SelectedIndexChanged
        Enabler()
    End Sub

    Private Sub cboOBMH_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBMH.SelectedIndexChanged
        Enabler()
    End Sub

    Private Sub cboL_Zip_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboL_Zip.SelectedIndexChanged
        Enabler()
    End Sub

    Private Sub cboR_Zip_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboR_Zip.SelectedIndexChanged
        Enabler()
    End Sub

    Private Sub cboRoadIDs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRoadIDs.SelectedIndexChanged
        Enabler()
    End Sub
#End Region

#Region "Text boxes"

    Private Sub txtTravelWay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Enabler()
    End Sub

    Private Sub txtRightWay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRightWay.TextChanged
        Enabler()
    End Sub

    Private Sub txtSpeed_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSpeed.TextChanged
        Enabler()
    End Sub

    Private Sub txtAddrLL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddrLL.TextChanged
        Enabler()
    End Sub

    Private Sub txtAddrLH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddrHL.TextChanged
        Enabler()
    End Sub

    Private Sub txtAddrLR_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddrLR.TextChanged
        Enabler()
    End Sub

    Private Sub txtAddrHR_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddrHR.TextChanged
        Enabler()
    End Sub

#End Region

#Region "Buttons"

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            '-Write the new info to the current feature's attribute table
            WriteRoadEdits()
            '-disable the save button again (until a change is made)
            btnSave.Enabled = False
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        If btnSave.Enabled = True Then
            If (MsgBox("Close without saving edits?", vbYesNo, "Edit Attributes") = vbNo) Then
                'DeleteGraphicByName("RoadGraphic")
                'm_pMXDoc.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, Nothing, m_pMXDoc.ActiveView.Extent)
                Me.Close()
            End If
        Else
            'DeleteGraphicByName("RoadGraphic")
            'm_pMXDoc.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, Nothing, m_pMXDoc.ActiveView.Extent)
            Me.Close()
        End If


    End Sub

    Private Sub btnGetUniqueRoadIDs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetUniqueRoadIDs.Click
        Dim pRoadNameTable As ITable
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Try
            Dim pTableSourcename As String
            pTableSourcename = ROAD_NAME_DATASRC
            pRoadNameTable = GetWorkspaceTable("ANY", FrmMap, pTableSourcename, True)
            If pRoadNameTable Is Nothing Then
                Me.Close()
                Exit Sub
            End If

            Dim pCur As ICursor, pRow As IRow, lIdx As Long
            lIdx = pRoadNameTable.Fields.FindField("ROAD_ID")

            ''add a queryfilter and queryfilterdefinition for sorting
            Dim pQF As IQueryFilter
            pQF = New QueryFilter
            Dim pQFDef As IQueryFilterDefinition
            pQFDef = pQF
            pQFDef.PostfixClause = "order by ROAD_ID"
            pCur = pRoadNameTable.Search(pQF, False) 'changed this one
            pRow = pCur.NextRow
            'Build the combobox
            Do While Not pRow Is Nothing
                Me.cboRoadIDs.Items.Add(pRow.Value(lIdx))
                pRow = pCur.NextRow
            Loop
            'display the 1st item
            If Me.cboRoadIDs.Items.Count > 0 Then Me.cboRoadIDs.SelectedIndex = 0
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            cboRoadIDs.Focus()

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Try
            Dim iTrack As Integer
            MsgBox(iTrack)
            iTrack = iTrack + 1

            'Before moving on to the next segment, make sure there are no edits to save
            If btnSave.Enabled = True Then
                '-if there have been edits made, see if the user wants to discard them
                If (MsgBox("Move to the next feature without saving edits?", vbYesNo, "Edit Attributes") = vbNo) Then Exit Sub
            End If
            '-get the next OID in the enum, get the corresponding feature, then highlight it on the display
            m_intCurrentOID = m_pRoadOIDs.Next
            If m_intCurrentOID < 0 Then ' "-1" is returned when the enum is empty
                m_pRoadOIDs.Reset() 'move back to the top
                m_intCurrentOID = m_pRoadOIDs.Next
            End If
            MsgBox(iTrack)
            iTrack = iTrack + 1
            '-use the OID to get the feature, highlight it ...
            m_pCurrentFeature = m_pRoadFC.GetFeature(m_intCurrentOID)
            '-fill the form controls with attributes for the current feature
            MsgBox(iTrack)
            iTrack = iTrack + 1
            FillFormControls()
            MsgBox(iTrack)
            iTrack = iTrack + 1
            DeleteGraphicByName(m_pMXDoc, "RoadGraphic")
            MsgBox(iTrack)
            iTrack = iTrack + 1
            HighlightRoad()
            MsgBox(iTrack)
            iTrack = iTrack + 1
            '-disable the save button (until a change is made)
            btnSave.Enabled = False
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
            Me.Close()
        End Try
    End Sub

#End Region
 
 
End Class