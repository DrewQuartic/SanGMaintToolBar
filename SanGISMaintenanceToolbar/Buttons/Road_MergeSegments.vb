Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.Editor
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Controls
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Display

<ComClass(Road_MergeSegments.ClassId, Road_MergeSegments.InterfaceId, Road_MergeSegments.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Road_MergeSegments")> _
Public NotInheritable Class Road_MergeSegments
    Inherits BaseTool
    Implements IShapeConstructorTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "b095ccc8-a91a-45ac-bc78-557a95f08942"
    Public Const InterfaceId As String = "ed88a971-e95d-4a59-a6b9-2dfcaf7b6bb0"
    Public Const EventsId As String = "6077caa7-c7fa-467d-ac4b-e10ce3405481"
#End Region
#Region "COM Registration Function(s)"
    <ComRegisterFunction(), ComVisibleAttribute(False)> _
    Public Shared Sub RegisterFunction(ByVal registerType As Type)
        ' Required for ArcGIS Component Category Registrar support
        ArcGISCategoryRegistration(registerType)

        'Add any COM registration code after the ArcGISCategoryRegistration() call

    End Sub

    <ComUnregisterFunction(), ComVisibleAttribute(False)> _
    Public Shared Sub UnregisterFunction(ByVal registerType As Type)
        ' Required for ArcGIS Component Category Registrar support
        ArcGISCategoryUnregistration(registerType)

        'Add any COM unregistration code after the ArcGISCategoryUnregistration() call

    End Sub

#Region "ArcGIS Component Category Registrar generated code"
    Private Shared Sub ArcGISCategoryRegistration(ByVal registerType As Type)
        Dim regKey As String = String.Format("HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID)
        MxCommands.Register(regKey)

    End Sub
    Private Shared Sub ArcGISCategoryUnregistration(ByVal registerType As Type)
        Dim regKey As String = String.Format("HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID)
        MxCommands.Unregister(regKey)

    End Sub

#End Region
#End Region

    Private m_application As IApplication
    Private m_editor As IEditor3
    Private m_editEvents As IEditEvents_Event
    Private m_editEvents5 As IEditEvents5_Event
    Private m_edSketch As IEditSketch3
    Private m_csc As IShapeConstructor

    Private m_hookHelper As IHookHelper
    Private m_pMXDoc As IMxDocument

    Dim pFeatcls As IFeatureClass

    Dim pUID As New UID                         
    Dim pcommand As ICommandItem


    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()

        ' TODO: Define values for the public properties
        MyBase.m_category = "SanGIS"  'localizable text 
        MyBase.m_caption = "Merge Road Segments"   'localizable text 
        MyBase.m_message = "Merge Road Segments"   'localizable text 
        MyBase.m_toolTip = "Merge Road Segments" & vbNewLine & "ONLY the Road Segments can be selected" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Road_MergeSegments" 'unique id, non-localizable (e.g. "MyCategory_MyTool")

        Try
            'TODO: change resource name if necessary
            Dim bitmapResourceName As String = Me.GetType().Name + ".bmp"
            MyBase.m_bitmap = New Bitmap(Me.GetType(), bitmapResourceName)
            MyBase.m_cursor = New System.Windows.Forms.Cursor(Me.GetType(), Me.GetType().Name + ".cur")
        Catch ex As Exception
            System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap")
        End Try
    End Sub

    ''' <summary>
    ''' Occurs when this tool is created
    ''' </summary>
    ''' <param name="hook">Instance of the application</param>
    Public Overrides Sub OnCreate(ByVal hook As Object)
        ' m_application = TryCast(hook, IApplication)

        If m_hookHelper Is Nothing Then m_hookHelper = New HookHelperClass
        If Not hook Is Nothing Then
            If TypeOf hook Is IMxApplication Then
                m_application = CType(hook, IApplication)
                MyBase.m_enabled = True
            Else
                MyBase.m_enabled = False
            End If
        End If

        'get the editor
        Dim editorUid As New UID()
        editorUid.Value = "esriEditor.Editor"
        m_editor = TryCast(m_application.FindExtensionByCLSID(editorUid), IEditor3)
        m_editEvents = TryCast(m_editor, IEditEvents_Event)
        m_editEvents5 = TryCast(m_editor, IEditEvents5_Event)
    End Sub

    ''' <summary>
    ''' Criteria for enabling the tool
    ''' </summary>
    Public Overrides ReadOnly Property Enabled() As Boolean
        Get
            Try
                pUID.Value = "{DB56FE71-F74D-11D1-849A-0000F875B9C6}"
                '{DB56FE71-F74D-11D1-849A-0000F875B9C6}
                'esriEditor.MergeCommand()
                pcommand = m_application.Document.CommandBars.Find(pUID)
                Dim CrntActiveView As IActiveView
                CrntActiveView = m_hookHelper.ActiveView
                m_pMXDoc = m_application.Document
                CrntActiveView = m_pMXDoc.ActivatedView
                'Disable if not editing
                If m_editor.EditState = esriEditState.esriStateEditing Then
                    'check if layer is selected and polyline
                    If CheckForLayer(ROAD_DATASRC, CrntActiveView) Then
                        Dim pFlayer As IFeatureLayer
                        Dim pFsel As IFeatureSelection
                        pFlayer = GetLayerByName(m_pMXDoc, ROAD_DATASRC)
                        pFsel = pFlayer
                        If pFsel.SelectionSet.Count > 1 And pFsel.SelectionSet.Count = CrntActiveView.FocusMap.SelectionCount Then
                            pcommand.Caption = "(Use Toolbar Merge)"
                            Return True
                        Else
                            pcommand.Caption = "Merge"
                            Return False
                        End If
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property

    ''' <summary>
    ''' Occurs when this tool is clicked
    ''' </summary>
    Public Overrides Sub OnClick()

        m_application.CurrentTool = Nothing

        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor

        Try

            Dim pEnumFeature As IEnumFeature

            pEnumFeature = m_editor.EditSelection
            Dim pChkFeature As IFeature
            pChkFeature = pEnumFeature.Next

            pFeatcls = pChkFeature.Class

            'Check road segements for different RoadIDs, FireDrive, and stop the merge
            Dim pchkFlds As IFields
            pchkFlds = pFeatcls.Fields
            Dim pchkFld As IField
            Dim chki As Long
            Dim chkvarName As String
            Dim chkvar As String
            Dim lstRDID As String = ""
            Dim lstFRDRV As String = ""
            Dim lstOneWay As String = ""
            Dim lstSegClass As String = ""
            Dim lstSpeed As String = ""
            Dim lstRTWAY As String = ""
            Dim lstOBMH As String = ""
            Dim levVar As Integer = 0
            Dim lstLEVEL As New List(Of Integer)
            Dim sumFLEV As Integer = 0
            Dim sumTLEV As Integer = 0
            Dim finFLEV As Integer = 1
            Dim finTLEV As Integer = 1
            Dim strOBJID1 As String
            Dim strOBJID2 As String

            Do
                ' Create a list of all unique values for each field, and stop if crucial (roadid) or warn if not (speed)
                '20131215 Drew: change to popup a form with option to choose which conflicting values to keep.

                For chki = 0 To pchkFlds.FieldCount - 1

                    pchkFld = pchkFlds.Field(chki)
                    chkvarName = pchkFld.Name
                    Select Case chkvarName
                        Case RD_ROADID_FLD_NAME
                            chkvar = pChkFeature.Value(chki).ToString()
                            If System.Array.IndexOf(New String() {lstRDID}, chkvar) <> -1 Then
                                'skip, its in the list
                            Else
                                If lstRDID = "" Then
                                    lstRDID = chkvar
                                Else
                                    lstRDID = lstRDID & "," & chkvar
                                End If
                            End If

                        Case RD_FIREDRIV_FLD_NAME
                            chkvar = pChkFeature.Value(chki).ToString()
                            If System.Array.IndexOf(New String() {lstFRDRV}, chkvar) <> -1 Then
                                'skip, its in the list
                            Else
                                If lstFRDRV = "" Then
                                    lstFRDRV = chkvar
                                Else
                                    lstFRDRV = lstFRDRV & "," & chkvar
                                End If
                            End If
                        Case RD_ONEWAY_FLD_NAME
                            chkvar = pChkFeature.Value(chki).ToString()
                            If System.Array.IndexOf(New String() {lstOneWay}, chkvar) <> -1 Then
                                'skip, its in the list
                            Else
                                If lstOneWay = "" Then
                                    lstOneWay = chkvar
                                Else
                                    lstOneWay = lstOneWay & "," & chkvar
                                End If
                            End If
                        Case RD_SEGCLASS_FLD_NAME
                            chkvar = pChkFeature.Value(chki).ToString()
                            If System.Array.IndexOf(New String() {lstSegClass}, chkvar) <> -1 Then
                                'skip, its in the list
                            Else
                                If lstSegClass = "" Then
                                    lstSegClass = chkvar
                                Else
                                    lstSegClass = lstSegClass & "," & chkvar
                                End If
                            End If
                        Case RD_SPEED_FLD_NAME
                            chkvar = pChkFeature.Value(chki).ToString()
                            If System.Array.IndexOf(New String() {lstSpeed}, chkvar) <> -1 Then
                                'skip, its in the list
                            Else
                                If lstSpeed = "" Then
                                    lstSpeed = chkvar
                                Else
                                    lstSpeed = lstSpeed & "," & chkvar
                                End If
                            End If
                        Case RD_RIGHTWAY_FLD_NAME
                            chkvar = pChkFeature.Value(chki).ToString()
                            If System.Array.IndexOf(New String() {lstRTWAY}, chkvar) <> -1 Then
                                'skip, its in the list
                            Else
                                If lstRTWAY = "" Then
                                    lstRTWAY = chkvar
                                Else
                                    lstRTWAY = lstRTWAY & "," & chkvar
                                End If
                            End If
                        Case RD_OBMH_FLD_NAME
                            chkvar = pChkFeature.Value(chki).ToString()
                            If System.Array.IndexOf(New String() {lstOBMH}, chkvar) <> -1 Then
                                'skip, its in the list
                            Else
                                If lstOBMH = "" Then
                                    lstOBMH = chkvar
                                Else
                                    lstOBMH = lstOBMH & "," & chkvar
                                End If
                            End If
                        Case RD_FLEVEL_FLD_NAME
                            levVar = pChkFeature.Value(chki)
                            sumFLEV = sumFLEV + levVar
                            lstLEVEL.Add(levVar)
                        Case RD_TLEVEL_FLD_NAME
                            levVar = pChkFeature.Value(chki)
                            sumTLEV = sumTLEV + levVar
                            lstLEVEL.Add(levVar)
                    End Select

                Next chki
                pChkFeature = pEnumFeature.Next
            Loop Until pChkFeature Is Nothing
            ''now stop, warn, or continue based on the info
            'If lstRDID.Contains(",") Or lstFRDRV.Contains(",") Then
            '    MessageBox.Show("Either RoadID or FireDriv do not match across segements, please review/change before continueing", "MERGE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            '    Exit Sub
            'End If

            'If lstOBMH.Contains(",") Or lstOneWay.Contains(",") Or lstRTWAY.Contains(",") Or lstSegClass.Contains(",") Or lstSpeed.Contains(",") Then
            '    If MessageBox.Show("SEGCLASS, OBMH, ONEWAY, RIGHTWAY, or SPEED do not match!" & vbNewLine & "ARE YOU SURE YOU WANT TO MERGE?", "MERGE DATA MISMATCH", Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            '        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            '        MessageBox.Show("Merge Cancelled")
            '        Exit Sub
            '    End If
            'End If

            Dim lstcomparisons As New List(Of String)
            lstcomparisons.Add(lstRDID)
            lstcomparisons.Add(lstFRDRV)
            lstcomparisons.Add(lstOBMH)
            lstcomparisons.Add(lstOneWay)
            lstcomparisons.Add(lstRTWAY)
            lstcomparisons.Add(lstSegClass)
            lstcomparisons.Add(lstSpeed)
            'Dim dictionary As New Dictionary(Of Integer, String)
            'dictionary.Add(0, lstOBMH)
            'dictionary.Add(1, lstOneWay)
            'dictionary.Add(2, lstRTWAY)
            'dictionary.Add(3, lstSegClass)
            'dictionary.Add(5, lstSpeed)
            Dim rdattcompRoadID As New roadattCompare
            rdattcompRoadID.AttName = "ROADID"
            rdattcompRoadID.AttValue = lstRDID
            Dim rdattcompFireDrive As New roadattCompare
            rdattcompFireDrive.AttName = "FireDR"
            rdattcompFireDrive.AttValue = lstFRDRV
            Dim rdattcompOBMH As New roadattCompare
            rdattcompOBMH.AttName = "OBMH"
            rdattcompOBMH.AttValue = lstOBMH
            Dim rdattcompOneWay As New roadattCompare
            rdattcompOneWay.AttName = "OneWay"
            rdattcompOneWay.AttValue = lstOneWay
            Dim rdattcomplstRTWAY As New roadattCompare
            rdattcomplstRTWAY.AttName = "RTWAY"
            rdattcomplstRTWAY.AttValue = lstRTWAY
            Dim rdattcomplstSegClass As New roadattCompare
            rdattcomplstSegClass.AttName = "SegClass"
            rdattcomplstSegClass.AttValue = lstSegClass
            Dim rdattcomplstSpeed As New roadattCompare
            rdattcomplstSpeed.AttName = "Speed"
            rdattcomplstSpeed.AttValue = lstSpeed
            Dim dictionary As New Dictionary(Of Integer, roadattCompare)
            dictionary.Add(0, rdattcompRoadID)
            dictionary.Add(1, rdattcompFireDrive)
            dictionary.Add(2, rdattcomplstRTWAY)
            dictionary.Add(3, rdattcomplstSegClass)
            dictionary.Add(5, rdattcomplstSpeed)
            dictionary.Add(6, rdattcompOBMH)
            dictionary.Add(7, rdattcompOneWay)


            Dim pair As KeyValuePair(Of Integer, roadattCompare)
            Dim frmMerge As frmRoadMerge
            Dim ucRoadItemCompare(dictionary.Count) As ucRoadItemCompare
            For Each pair In dictionary
                If pair.Value.AttValue.Contains(",") Then
                    If frmMerge Is Nothing Then
                        frmMerge = New frmRoadMerge
                        frmMerge.AutoSizeMode = AutoSizeMode.GrowAndShrink
                        frmMerge.AutoSize = True
                        pEnumFeature.Reset()
                        pChkFeature = pEnumFeature.Next
                        frmMerge.lblSeg2.Text = pChkFeature.Value(pChkFeature.Fields.FindField(RD_ROADSEGID_FLD_NAME))
                        pChkFeature = pEnumFeature.Next
                        frmMerge.lblSeg1.Text = pChkFeature.Value(pChkFeature.Fields.FindField(RD_ROADSEGID_FLD_NAME))
                    End If
                    ucRoadItemCompare(pair.Key) = New ucRoadItemCompare
                    ucRoadItemCompare(pair.Key).SegVal1 = pair.Value.AttValue.Substring(0, pair.Value.AttValue.IndexOf(","))
                    ucRoadItemCompare(pair.Key).SegVal2 = pair.Value.AttValue.Substring(pair.Value.AttValue.IndexOf(",") + 1)
                    ucRoadItemCompare(pair.Key).gbName = pair.Value.AttName
                    ucRoadItemCompare(pair.Key).Top = frmMerge.Controls(frmMerge.Controls.Count - 1).Bottom
                    ucRoadItemCompare(pair.Key).Left = frmMerge.lblSeg1.Left
                    'frmMerge.Controls.Add(ucRoadItemCompare(pair.Key))
                    frmMerge.flpGroups.Controls.Add(ucRoadItemCompare(pair.Key))
                End If
            Next

            If Not frmMerge Is Nothing Then
                'frmMerge.btnMerge.Top = frmMerge.Controls(frmMerge.Controls.Count - 1).Bottom
                'frmMerge.btnCancel.Top = frmMerge.Controls(frmMerge.Controls.Count - 1).Bottom

                'frmMerge.Refresh()
                frmMerge.ShowDialog()
            End If
            'If frmMerge Is Nothing Then
            '    Exit Sub
            'End If
            pEnumFeature.Reset()
            ' get the first feature
            'pCurFeature = pEnumFeature.Next



            Dim levi As Integer
            'Determine the from and to levels)
            finFLEV = lstLEVEL.Item(0)
            finTLEV = lstLEVEL.Item(0)
            If sumFLEV > sumTLEV Then
                'flev gets the highest number

                For levi = 0 To lstLEVEL.Count - 1
                    If finFLEV < lstLEVEL.Item(levi) Then finFLEV = lstLEVEL.Item(levi)
                    If finTLEV > lstLEVEL.Item(levi) Then finTLEV = lstLEVEL.Item(levi)
                Next
            Else
                'flev gets the lowest number
                For levi = 0 To lstLEVEL.Count - 1
                    If finFLEV > lstLEVEL.Item(levi) Then finFLEV = lstLEVEL.Item(levi)
                    If finTLEV < lstLEVEL.Item(levi) Then finTLEV = lstLEVEL.Item(levi)
                Next
            End If


            ' create a new feature to be the merge feature
            Dim pCurFeature As IFeature
            Dim pNewFeature As IFeature
            Dim lCount As Long
            pNewFeature = pFeatcls.CreateFeature

            ' create the new geometry.
            Dim pGeom As IGeometry
            Dim pTmpGeom As IGeometry
            Dim pOutputGeometry As IGeometry
            Dim pTopoOperator As ITopologicalOperator

            Dim pAddrCursor As IFeatureCursor
            Dim pQF As IQueryFilter, pAddrFeature As IFeature
            Dim kpRoadSegID As Long
            Dim tmpRoadSegID As Long = -8899
            Dim DlRoadSegID As Long
            'address reset info
            Dim AdrCnt As Integer = 0
            Dim pAddressFtClass As IFeatureClass
            pAddressFtClass = GetWorkspaceTable("ANY", m_pMXDoc.ActiveView, ADDRESS_DATASRC, False)

            ' start edit operation
            m_editor.StartOperation()

            pEnumFeature.Reset()
            ' get the first feature
            pCurFeature = pEnumFeature.Next
            Dim pFlds As IFields
            pFlds = pFeatcls.Fields
            Dim pFld As IField
            Dim i As Long

            lCount = 1
            Do
                ' get the geometry
                pGeom = pCurFeature.ShapeCopy
                If lCount = 1 Then ' if its the first feature
                    pTmpGeom = pGeom

                Else ' merge the geometry of the features
                    pTopoOperator = pTmpGeom
                    pOutputGeometry = pTopoOperator.Union(pGeom)
                    pTmpGeom = pOutputGeometry
                End If

                ' now go through each field, and get the proper data
                For i = 0 To pFlds.FieldCount - 1
                    pFld = pFlds.Field(i)

                    Dim varName As String = pFld.Name
                    If System.Array.IndexOf(New String() {pFeatcls.LengthField.Name, pFeatcls.OIDFieldName, RD_ROADSEGID_FLD_NAME}, varName) <> -1 Then
                        'skip, can't edit the objectid or shape fields
                    ElseIf lCount = 1 Then ' if its the first feature
                        pNewFeature.Value(i) = pCurFeature.Value(i)
                    ElseIf System.Array.IndexOf(New String() {RD_ABHIADDR_FLD_NAME, RD_LHIGHADDR_FLD_NAME, RD_RHIGHADDR_FLD_NAME}, varName) <> -1 Then
                        If pCurFeature.Value(i) > pNewFeature.Value(i) Then
                            pNewFeature.Value(i) = pCurFeature.Value(i)
                        End If
                    ElseIf System.Array.IndexOf(New String() {RD_ABLOADDR_FLD_NAME, RD_LLOWADDR_FLD_NAME, RD_RLOWADDR_FLD_NAME}, varName) <> -1 Then
                        If pCurFeature.Value(i) < pNewFeature.Value(i) Then
                            pNewFeature.Value(i) = pCurFeature.Value(i)
                        End If
                        'Else
                        '    pNewFeature.Value(i) = pCurFeature.Value(i)
                    End If
                    'get the roadsegid that is going away
                    If varName = RD_ROADSEGID_FLD_NAME Then
                        DlRoadSegID = pCurFeature.Value(i)
                        pCurFeature.Value(i) = -99999
                    End If

                Next i

                'set the level fields based on previous decision
                pNewFeature.Value(pNewFeature.Fields.FindField(RD_TLEVEL_FLD_NAME)) = finTLEV
                pNewFeature.Value(pNewFeature.Fields.FindField(RD_FLEVEL_FLD_NAME)) = finFLEV

                '-get all the existing address points using one of the segids
                'and calc to the tempid
                pQF = New QueryFilter
                Dim pWhereClse As String
                pWhereClse = ADDR_ROADSEGID_FLD_NAME & " = " & DlRoadSegID
                pQF.WhereClause = pWhereClse
                If pAddressFtClass.FeatureCount(pQF) > 0 Then
                    AdrCnt = AdrCnt + pAddressFtClass.FeatureCount(pQF)
                    '-get the address points from the address point feature class
                    pAddrCursor = pAddressFtClass.Update(pQF, False)
                    pAddrFeature = pAddrCursor.NextFeature
                    Do Until pAddrFeature Is Nothing
                        pAddrFeature.Value(pAddrFeature.Fields.FindField(ADDR_ROADSEGID_FLD_NAME)) = tmpRoadSegID
                        pAddrFeature.Store()
                        pAddrFeature = pAddrCursor.NextFeature
                    Loop
                End If


                pCurFeature.Delete() ' delete the feature

                pCurFeature = pEnumFeature.Next
                lCount = lCount + 1
            Loop Until pCurFeature Is Nothing

            'If different values exited between the input segments for certain key fields the user should already have selected
            'Which one to keep on the frmMerge object. Get the selected values and apply to the new road segment
            If Not frmMerge Is Nothing Then
                For Each cControl As Control In frmMerge.flpGroups.Controls
                    If (TypeOf cControl Is ucRoadItemCompare) Then
                        Dim ucIC As ucRoadItemCompare = CType(cControl, ucRoadItemCompare)
                        Dim rb As RadioButton
                        For Each b As RadioButton In ucIC.gbControl.Controls()
                            If b.Checked = True Then
                                rb = b
                            End If
                        Next
                        Select Case ucIC.gbName
                            Case "OBMH"
                                If Not rb Is Nothing Then
                                    pNewFeature.Value(pNewFeature.Fields.FindField(RD_OBMH_FLD_NAME)) = rb.Text
                                End If

                            Case "OneWay"
                                If Not rb Is Nothing Then
                                    pNewFeature.Value(pNewFeature.Fields.FindField(RD_ONEWAY_FLD_NAME)) = rb.Text
                                End If
                            Case "RTWAY"
                                If Not rb Is Nothing Then
                                    pNewFeature.Value(pNewFeature.Fields.FindField(RD_RIGHTWAY_FLD_NAME)) = rb.Text
                                End If
                            Case "SegClass"
                                If Not rb Is Nothing Then
                                    pNewFeature.Value(pNewFeature.Fields.FindField(RD_SEGCLASS_FLD_NAME)) = rb.Text
                                End If
                            Case "Speed"
                                If Not rb Is Nothing Then
                                    pNewFeature.Value(pNewFeature.Fields.FindField(RD_SPEED_FLD_NAME)) = rb.Text
                                End If
                            Case "ROADID"
                                If Not rb Is Nothing Then
                                    pNewFeature.Value(pNewFeature.Fields.FindField(RD_ROADID_FLD_NAME)) = rb.Text
                                End If
                            Case "FireDR"
                                If Not rb Is Nothing Then
                                    pNewFeature.Value(pNewFeature.Fields.FindField(RD_FIREDRIV_FLD_NAME)) = rb.Text
                                End If
                            Case Else

                        End Select
                    End If
                Next
            End If
            

            pNewFeature.Shape = pOutputGeometry
            pNewFeature.Store()
            kpRoadSegID = pNewFeature.Value(pNewFeature.Fields.FindField(RD_ROADSEGID_FLD_NAME))

            '-get all the addresses calced to the temp id and calc to the new one now that it is created
            'and calc to the tempid
            'had to wait for the road to store to get the newly created roadsegid
            If AdrCnt > 0 Then
                Dim pupdQF As IQueryFilter
                pupdQF = New QueryFilter
                Dim pupdWhereClse As String
                pupdWhereClse = ADDR_ROADSEGID_FLD_NAME & " = " & tmpRoadSegID
                pupdQF.WhereClause = pupdWhereClse
                If pAddressFtClass.FeatureCount(pupdQF) > 0 Then
                    '-get the address points from the address point feature class
                    pAddrCursor = pAddressFtClass.Update(pupdQF, False)
                    pAddrFeature = pAddrCursor.NextFeature
                    Do Until pAddrFeature Is Nothing
                        pAddrFeature.Value(pAddrFeature.Fields.FindField(ADDR_ROADSEGID_FLD_NAME)) = kpRoadSegID
                        pAddrFeature.Store()
                        pAddrFeature = pAddrCursor.NextFeature
                    Loop
                End If
            End If

            ' finish edit operation
            m_editor.StopOperation("Features merged")

            ' refresh features
            Dim pRefresh As IInvalidArea
            pRefresh = New InvalidArea
            pRefresh.Display = m_editor.Display
            pRefresh.Add(pNewFeature)
            pRefresh.Invalidate(esriScreenCache.esriAllScreenCaches)

            ' select new feature
            Dim pMap As IMap
            pMap = m_editor.Map
            pMap.ClearSelection()

            pMap.SelectFeature(GetLayerByName(m_pMXDoc, ROAD_DATASRC), pNewFeature)
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub
End Class


