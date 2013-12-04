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
Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Display
Imports ESRI.ArcGIS.esriSystem


<ComClass(Road_RoadSplitTool.ClassId, Road_RoadSplitTool.InterfaceId, Road_RoadSplitTool.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Road_RoadSplitTool")> _
Public NotInheritable Class Road_RoadSplitTool
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "04db206b-ab1b-4677-8110-d963f5525614"
    Public Const InterfaceId As String = "64db491b-e5b1-457f-8af5-4b5c05dc89af"
    Public Const EventsId As String = "000a8f35-21ec-43c4-8391-7fad62c465df"
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


    Private m_hookHelper As IHookHelper
    Private m_application As IApplication
    Private m_pEditor As IEditor2
    Private m_pMXDoc As IMxDocument
    Private m_pFeatureClass As IFeatureClass
    Private m_pFeatSel As IFeatureSelection

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()

        ' TODO: Define values for the public properties
        ' TODO: Define values for the public properties
        MyBase.m_category = "SanGIS"  'localizable text 
        MyBase.m_caption = "Split Road Segment"   'localizable text 
        MyBase.m_message = "Split Road Segment"   'localizable text 
        MyBase.m_toolTip = "Click on the selected road to Split it at that point" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Road_RoadSplitTool"  'unique id, non-localizable (e.g. "MyCategory_MyCommand")


        Try
            'TODO: change resource name if necessary
            Dim bitmapResourceName As String = Me.GetType().Name + ".bmp"
            MyBase.m_bitmap = New Bitmap(Me.GetType(), bitmapResourceName)
            MyBase.m_cursor = New System.Windows.Forms.Cursor(Me.GetType(), Me.GetType().Name + ".cur")
        Catch ex As Exception
            System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap")
        End Try
    End Sub


    Public Overrides Sub OnCreate(ByVal hook As Object)
        If m_hookHelper Is Nothing Then m_hookHelper = New HookHelperClass
        If Not hook Is Nothing Then
            If TypeOf hook Is IMxApplication Then
                m_application = CType(hook, IApplication)
                MyBase.m_enabled = True
            Else
                MyBase.m_enabled = False
            End If
        End If

        ' TODO:  Add other initialization code
    End Sub

    Public Overrides Sub OnClick()
        Try
            Dim pFeatureLayer As IFeatureLayer
            pFeatureLayer = GetLayerByName(m_pMXDoc, ROAD_DATASRC)

            If pFeatureLayer Is Nothing Then
                MsgBox("Warning Snapping for this tool not set")
                Exit Sub
            End If

            m_pFeatureClass = pFeatureLayer.FeatureClass

            'added to get the specific roadseg
            Dim pFsel As IFeatureSelection

            pFsel = pFeatureLayer
            If pFsel.SelectionSet.Count > 0 Then
                m_pFeatSel = pFsel
            End If

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_RoadSplitTool.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        Try
            'Code here to show the snap point ...
            Dim pSnapEnv As ISnapEnvironment
            Dim pSnapPoint As IPoint, pEnv As IEnvelope, bSnapped As Boolean
            '-get the snapping props from the Editor
            pSnapEnv = m_pEditor 'QI
            '-get a map point from the current mouse position (pixels)

            Dim pAV As IActiveView
            Dim pMap As IMap
            pSnapPoint = m_pMXDoc.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y)
            pEnv = pSnapPoint.Envelope 'a point's envelope is initially empty
            pEnv.Expand(80, 80, False) 'make the envelope 80'x80'
            '-refresh the portion of the display around the mouse (clean up any graphic "artifacts")
            pMap = m_pMXDoc.FocusMap
            pAV = pMap
            pAV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, Nothing, pEnv)
            Dim pMxApp As IMxApplication
            pMxApp = m_application
            pMxApp.Display.Invalidate(pEnv, True, esriScreenCache.esriNoScreenCache)
            pMxApp.Display.UpdateWindow()
            '-see if the current mouse position will snap to a road
            bSnapped = pSnapEnv.SnapPoint(pSnapPoint)
            '-if the point snapped, draw the editor's snapping agent
            If bSnapped Then
                m_pEditor.InvertAgent(pSnapPoint, pMxApp.Display.hDC)
            End If
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        Dim pRoadCursor As IFeatureCursor
        pRoadCursor = Nothing
        Dim pPointFilter As ISpatialFilter
        Dim pEnvel As IEnvelope
        Dim pRoadFeature As IFeature
        Dim intIsLowRoad As Integer
        Dim pLRoadFeature As IFeature, pHRoadFeature As IFeature
        Dim intSegIDFld As Integer, intLLAddFld As Integer, intLHAddFld As Integer, intRLAddFld As Integer, intRHAddFld As Integer, intLengthFld As Integer, intRoadIDFld As Integer
        Dim intTLEVFld As Integer, intFLEVFld As Integer, intFNODEFld As Integer
        Dim pSplitPoint As IPoint
        Try
            '-show the "hourglass" cursor while processing
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            '-get the point (in map units) that was clicked

            pSplitPoint = m_pMXDoc.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y) 'x/y are in pixels
            '-make sure the point snaps to a road. If not, exit the sub
            Dim pSnapEnv As ISnapEnvironment
            pSnapEnv = m_pEditor 'QI
            '-check the regular snapping first (does it snap to ANY road?)
            Dim bSnapOK As Boolean
            bSnapOK = pSnapEnv.SnapPoint(pSplitPoint)
            If Not bSnapOK Then 'point did not snap to a road
                MsgBox("The point you clicked did not snap to a road feature. You may wish to increase your snapping tolerance.", vbExclamation, "Split Road")
                Exit Sub
            End If
            '-find the road that was clicked

            pEnvel = pSplitPoint.Envelope
            pEnvel.Expand(2.5, 2.5, False)

            pPointFilter = New SpatialFilter 'spatial filter that uses the click point to locate a road
            pPointFilter.Geometry = pEnvel
            pPointFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects

            'Changed true to false in upgrade to Arc10
            'pRoadCursor = m_pFeatureClass.Search(pPointFilter, False) ' True)
            'to fix snapping to the wrong road
            m_pFeatSel.SelectionSet.Search(pPointFilter, False, pRoadCursor)

            pRoadFeature = pRoadCursor.NextFeature


            '-should only be one feature (road) ... code assumes there's either 1 or 0 (takes the first one that's found)
            If pRoadFeature Is Nothing Then '*should* always find one, the point already snapped to a road!
                MsgBox("Split point did not locate a road feature.", vbCritical, "Split Road")
                Exit Sub
            End If


            intSegIDFld = pRoadFeature.Fields.FindField(RD_ROADSEGID_FLD_NAME)
            intLLAddFld = pRoadFeature.Fields.FindField(RD_LLOWADDR_FLD_NAME)
            intLHAddFld = pRoadFeature.Fields.FindField(RD_LHIGHADDR_FLD_NAME)
            intRLAddFld = pRoadFeature.Fields.FindField(RD_RLOWADDR_FLD_NAME)
            intRHAddFld = pRoadFeature.Fields.FindField(RD_RHIGHADDR_FLD_NAME)
            intLengthFld = pRoadFeature.Fields.FindField(RD_LENGTH_FLD_NAME)
            intRoadIDFld = pRoadFeature.Fields.FindField(RD_ROADID_FLD_NAME)
            intFLEVFld = pRoadFeature.Fields.FindField(RD_FLEVEL_FLD_NAME)
            intTLEVFld = pRoadFeature.Fields.FindField(RD_TLEVEL_FLD_NAME)
            intFNODEFld = pRoadFeature.Fields.FindField(RD_FNODE_FLD_NAME)
            '-make sure the fields are found
            If intSegIDFld < 0 Or intLLAddFld < 0 Or intLHAddFld < 0 Or intLengthFld < 0 Or intRLAddFld < 0 Or intRHAddFld < 0 Or intFLEVFld < 0 Or intTLEVFld < 0 Then
                MsgBox("One of the following fields was not found in the Road attribute table: " & vbCr & _
                                "Road Segment ID:  ROADSEGID" & vbCr & _
                                "Road ID: ROADID" & vbCr & _
                                "Low address (left): LLOWADDR" & vbCr & _
                                "High address (left): LHIGHADDR" & vbCr & _
                                "Low address (right): RLOWADDR" & vbCr & _
                                "T_LEVEL" & vbCr & _
                                "F_LEVEL" & vbCr & _
                                "High address (right): RHIGHADDR" & vbCr & _
                                "Length: LENGTH", vbCritical, "Split Road")
                Exit Sub
            End If
            '-record info about the original road (segID, from/to address range, length)

            Dim intOrigSegID As Long, intLLowAdd As Long, intLHighAdd As Long, intRLowAdd As Long, intRHighAdd As Long, dblRoadLength As Double
            Dim intOrigTLEV As Short, intOrigFLEV As Short, intOrigFNODE As Long
            intOrigSegID = pRoadFeature.Value(intSegIDFld)
            intLLowAdd = pRoadFeature.Value(intLLAddFld)
            intLHighAdd = pRoadFeature.Value(intLHAddFld)
            intRLowAdd = pRoadFeature.Value(intRLAddFld)
            intRHighAdd = pRoadFeature.Value(intRHAddFld)
            dblRoadLength = pRoadFeature.Value(intLengthFld)
            If Not IsDBNull(pRoadFeature.Value(intFLEVFld)) Then
                intOrigFLEV = pRoadFeature.Value(intFLEVFld)
            Else
                intOrigFLEV = 1
            End If
            If Not IsDBNull(pRoadFeature.Value(intTLEVFld)) Then
                intOrigTLEV = pRoadFeature.Value(intTLEVFld)
            Else
                intOrigTLEV = 1
            End If

            intOrigFNODE = pRoadFeature.Value(intFNODEFld)
            '-get the table that contains road names


            Dim pRoadNameTable As ITable
            pRoadNameTable = GetWorkspaceTable("ANY", m_pMXDoc.ActiveView, ROAD_NAME_DATASRC, False)
            If pRoadNameTable Is Nothing Then
                MsgBox("The road names table ROADNAME was not found in the database.", vbCritical, "Split Road")
                Exit Sub
            End If


            '-do the split
            m_pEditor.StartOperation() 'required when editing ArcSDE geodatabase!

            'disconnect the segaliases if there are any and assign the roadsegid alias flag since it can not be null
            Dim ptmpsegid As Long = -990099
            Dim pRoadAliasTable2 As ITable, pRoadAliasCursor2 As ICursor, pRoadAliasRow2 As IRow
            pRoadAliasTable2 = GetWorkspaceTable("ANY", m_pMXDoc.ActiveView, ROAD_ALIAS_DATASRC, False)
            If Not pRoadAliasTable2 Is Nothing Then
                Dim intAiasIDFld2 As Long = pRoadAliasTable2.Fields.FindField(RD_ROADSEGID_FLD_NAME)
                'check if road has aliases
                Dim pQFA2 As QueryFilter
                pQFA2 = New QueryFilter
                Dim pWhereClseA2 As String
                pWhereClseA2 = RD_ROADSEGID_FLD_NAME & " = " & intOrigSegID
                pQFA2.WhereClause = pWhereClseA2
                If pRoadAliasTable2.RowCount(pQFA2) > 0 Then
                    pRoadAliasCursor2 = pRoadAliasTable2.Update(pQFA2, False)         
                    pRoadAliasRow2 = pRoadAliasCursor2.NextRow
                    Do Until pRoadAliasRow2 Is Nothing
                        pRoadAliasRow2.Value(intAiasIDFld2) = ptmpsegid
                        pRoadAliasCursor2.UpdateRow(pRoadAliasRow2)
                        pRoadAliasRow2 = pRoadAliasCursor2.NextRow
                    Loop
                End If
            End If
            pRoadAliasTable2 = Nothing
            pRoadAliasCursor2 = Nothing
            pRoadAliasRow2 = Nothing


            '-set the RoadID to a flag that indicates a split edit is occuring (so ClassExtension code can handle the edit appropriately)
            'However we want to retain the existing RoadID so we can reassign it to the new feature after the split. This is
            'when the class extension events fire so we need to reasign the RoadID's after the split
            Dim lngOldRoadID As Long
            lngOldRoadID = pRoadFeature.Value(intRoadIDFld)
            pRoadFeature.Value(intRoadIDFld) = -99999
            pRoadFeature.Store()

            Dim pFeatureEdit As IFeatureEdit
            pFeatureEdit = pRoadFeature 'QI ifeature edit

            Dim pSplitSet As ISet

            pSplitSet = pFeatureEdit.Split(pSplitPoint)  'the split returns a "Set" object containing the 2 new roads
            '-store the original road's "To point" (will use it to see which road contains low end of address ranges)

            Dim pRoadLine As ICurve
            pRoadLine = pRoadFeature.ShapeCopy

            Dim pHighAddrPoint As IPoint
            pHighAddrPoint = pRoadLine.ToPoint

            '-call a procedure that will perform a test to determine which of the 2 new lines should have the high end of the address range
            '-Low/High road features are passed ByRef and set in this procedure
            'SetHighAndLowRoads pSplitSet, pLRoadFeature, pHRoadFeature, pHighAddrPoint
            Dim pTempSeg1 As IFeature
            Dim pTempSeg2 As IFeature
            pTempSeg1 = pSplitSet.Next 'pull out the first split segment
            pTempSeg2 = pSplitSet.Next 'second
            '-highlight one of the split segments on the map
            '-call a procedure to make a line graphic with one of the segments
            Dim pRoadGraphic As ILineElement
            pRoadGraphic = MakeRoadGraphic(pTempSeg1.ShapeCopy)
            '-add the graphic to the map, refresh
            m_pMXDoc.ActiveView.GraphicsContainer.AddElement(pRoadGraphic, 0)
            m_pMXDoc.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, pRoadGraphic, Nothing)

            'On Error Resume Next
            pLRoadFeature = Nothing
            pHRoadFeature = Nothing
            intIsLowRoad = MsgBox("Does the red segment have the low end of the previous address range?", vbYesNo, "Split Road")
            Select Case intIsLowRoad
                Case vbYes
                    pLRoadFeature = pTempSeg1
                    pHRoadFeature = pTempSeg2
                Case vbNo
                    pLRoadFeature = pTempSeg2
                    pHRoadFeature = pTempSeg1
                Case vbCancel
                    GoTo CleanUp
                Case Else 'closed dialog, e.g.
                    'code below will raise an error and exit ...
            End Select
            '-make sure the high and low roads were set properly
            If pLRoadFeature Is Nothing Or pHRoadFeature Is Nothing Then
                MsgBox("High and low address range road segments could not be identified.", vbCritical, "Split Road")
                GoTo CleanUp
            End If

            'Now that the 2 new road segments have been created and the class extension events have fired we can reassign the
            'old RoadID value
            pLRoadFeature.Value(intRoadIDFld) = lngOldRoadID
            pHRoadFeature.Value(intRoadIDFld) = lngOldRoadID
            'we can also determine which one gets the original from and to levels
            If pLRoadFeature.Value(intFNODEFld) = intOrigFNODE Then
                pLRoadFeature.Value(intFLEVFld) = intOrigFLEV
                pHRoadFeature.Value(intFLEVFld) = intOrigTLEV               
            Else
                pLRoadFeature.Value(intFLEVFld) = intOrigTLEV
                pHRoadFeature.Value(intFLEVFld) = intOrigFLEV                
            End If
            pLRoadFeature.Value(intTLEVFld) = intOrigTLEV
            pHRoadFeature.Value(intTLEVFld) = intOrigTLEV

            '-determine the proportional address ranges based on the ratio of the split segment to the whole
            '-first, get the proportion of the new roads to the original (percentage)
            Dim dblLowSegLength As Double, dblLowSegPct As Double, pLLine As ICurve
            pLLine = pLRoadFeature.ShapeCopy
            dblLowSegLength = pLLine.Length
            dblLowSegPct = (dblLowSegLength / dblRoadLength)  'percent of total (original) length
            '-determine which side (R/L) has even values, which has odd (make sure the new values conform)
            Dim bRightIsEven As Boolean
            bRightIsEven = (intRHighAdd Mod 2 = 0) 'the "Mod" operator returns the remainder after division, even #s should have no remainder when divided by 2
            '-Addr1=low segment end, Addr2=high
            Dim intLLAddr1 As Long, intLHAddr1 As Long, intRLAddr1 As Long, intRHAddr1 As Long
            Dim intLLAddr2 As Long, intLHAddr2 As Long, intRLAddr2 As Long, intRHAddr2 As Long
            '-first calc values for the low segment (Addr1)
            '-low segment low values stay the same
            intLLAddr1 = intLLowAdd 'original road's value
            intRLAddr1 = intRLowAdd
            '-high values (on the "low" seg) are the proportion of the length + the minimum
            If intLHighAdd = 0 Then
                intLHAddr1 = 0
            Else
                intLHAddr1 = intLLAddr1 + ((intLHighAdd - intLLowAdd) * dblLowSegPct)
            End If
            If intRHighAdd = 0 Then
                intRHAddr1 = 0
            Else
                intRHAddr1 = intRLAddr1 + ((intRHighAdd - intRLowAdd) * dblLowSegPct)
            End If

            '-see if they should be made even or odd
            If bRightIsEven Then 'right-side address values should be even, left should be odd
                '-see if they already have the correct "evenness"
                If Not intRHAddr1 Mod 2 = 0 And intRHAddr1 <> 0 Then '(don't need to check the  low values, they were simply copied from the original segment)
                    intRHAddr1 = intRHAddr1 + 1 'if it's odd, adding one will make it even (at least on this planet ;-)
                End If
                If Not intLHAddr1 Mod 2 = 1 And intLHAddr1 <> 0 Then 'left should be odd
                    intLHAddr1 = intLHAddr1 + 1
                End If
            Else 'left-side addresses should be even, right odd
                '-same logic as above, just reversed (left-right)
                If Not intLHAddr1 Mod 2 = 0 And intLHAddr1 <> 0 Then '(don't need to check the  low values, they were simply copied from the original segment)
                    intLHAddr1 = intLHAddr1 + 1
                End If
                If Not intRHAddr1 Mod 2 = 1 And intRHAddr1 <> 0 Then 'right should be odd
                    intRHAddr1 = intRHAddr1 + 1
                End If
            End If
            '-now do "high" segment (Addr2) ...
            If intLHAddr1 = 0 Then
                intLLAddr2 = intLHAddr1
            Else
                intLLAddr2 = intLHAddr1 + 2 'add 2 to the high of the last segment (left side)
            End If
            If intRHAddr1 = 0 Then
                intRLAddr2 = intRHAddr1
            Else
                intRLAddr2 = intRHAddr1 + 2 '(right side)
            End If
            intLHAddr2 = intLHighAdd 'original high (left)
            intRHAddr2 = intRHighAdd '(right)
            '-set attributes for the "low" end of the segment ...
            pLRoadFeature.Value(intLLAddFld) = intLLAddr1
            pLRoadFeature.Value(intLHAddFld) = intLHAddr1
            pLRoadFeature.Value(intRLAddFld) = intRLAddr1
            pLRoadFeature.Value(intRHAddFld) = intRHAddr1
            pLRoadFeature.Store()
            '-now calc the "high" end of the original segment with appropriate values
            pHRoadFeature.Value(intLLAddFld) = intLLAddr2
            pHRoadFeature.Value(intRLAddFld) = intRLAddr2
            pHRoadFeature.Value(intLHAddFld) = intLHAddr2
            pHRoadFeature.Value(intRHAddFld) = intRHAddr2
            pHRoadFeature.Store()


            Dim SplitRdInfoForm As New frmSplitRoadAttributes

            '-show the editing form for specifying attribute info for the new segment
            '-set properties on the form that identify the two segments
            SplitRdInfoForm.SegmentOne = pLRoadFeature
            SplitRdInfoForm.SegmentTwo = pHRoadFeature
            SplitRdInfoForm.RoadDoc = m_pMXDoc  'These two lines set the doc property of the form and the utilities
            SplitRdInfoForm.FrmMap = m_pMXDoc.ActiveView
            SplitRdInfoForm.ShowDialog()
            '-if the user clicked "Close" or "X'd" out of the dialog, exit the procedure
            If SplitRdInfoForm.s_blCanceled Then
                m_pEditor.StopOperation("Split Road")
                m_pMXDoc.OperationStack.Undo()
                DeleteGraphicByName(m_pMXDoc, "RoadGraphic")
                m_application.CurrentTool = Nothing
                Exit Sub
            End If

            '-user can use the form to update the feature attributes ...
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            '==note: the code above to set the mouse cursor must be set before the msgbox is displayed (msgbox interferes with windows messaging)
            '**call a sub that reassigns the address points to the appropriate segment (if the user chooses to)
            If MsgBox("Would you like addresses associated with this segment to be automatically reassigned?", vbYesNo, "Split Road") = vbYes Then
                ReassignAddressesAfterSplit(pLRoadFeature, pHRoadFeature, intOrigSegID)
            End If

            'update the seg aliases if there are any
            UpdateRdSegAliasTbl(pLRoadFeature, pHRoadFeature, ptmpsegid)

            '***********************************************************************
            '***********************************************************************
            '  Begin code to replace Road Geometry Table with fields in T.Road
            '  Use a boolean b_useGeomTable to turn on and off the use of the geometry table
            '  If true it will populate the table and the road fields
            '  If false it will skip the geometry table, and only do the Roads fc fields
            '
            '--------------------------------------------------------------------------
            Dim b_useGeomTable As Boolean = False
            If b_useGeomTable Then

                '**Remove any duplicate road geometry table
                ClearDupGeometryTbl(pLRoadFeature, pHRoadFeature)

            End If
            '--------------------------------------------------------------------------
            '  END code to skip Road Geometry Table w
            '
            '*************************************************************************** 



            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

CleanUp:
            '-make sure to stop the edit operation
            m_pEditor.StopOperation("Split Road")
            '-call a sub to remove any road graphics that are still on the map
            DeleteGraphicByName(m_pMXDoc, "RoadGraphic") 'in "Utilities" module
            '-flash the new segments (if they were successfully created)
            If Not pLRoadFeature Is Nothing And Not pHRoadFeature Is Nothing Then
                '-call a sub that flashes the features

                Dim pLayer As ILayer
                pLayer = GetLayerByName(m_pMXDoc, ROAD_DATASRC) ' m_pMXDoc.SelectedLayer
                Dim pRFeatureLayer As IFeatureLayer
                pRFeatureLayer = pLayer
                FlashIt(m_pMXDoc, pRFeatureLayer, pSplitPoint, pLRoadFeature.OID)   'new "low" segment
                FlashIt(m_pMXDoc, pRFeatureLayer, pSplitPoint, pHRoadFeature.OID)   '"high" segment
                '***Uncomment the code below to verify that a proper RoadID was entered
                '-call a sub that verifies that a proper RoadID was provided
                '-if the user did not give a proper RoadID, they will be prompted for one (again!)
                ' VerifyRoadID pLRoadFeature, pRoadNameTable '"low" segment
                ' VerifyRoadID pHRoadFeature, pRoadNameTable '"high" segment
                '***END
            End If
            pRoadCursor = Nothing

        Catch ex As Exception
            pRoadCursor = Nothing
            m_pEditor.StopOperation("Split Road")
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try



    End Sub


    Private Sub ReassignAddressesAfterSplit(ByVal NewLowFeature As IFeature, ByVal NewHighFeature As IFeature, ByVal OriginalSegID As Long)

        'This function will find address points that are related to a newly split road feature
        'it will then decide which addresses belong to each new segment (by default, the addresses are randomly assigned to one of the segments)

        Dim pAddrCursor As IFeatureCursor, intAddrCount As Long
        Dim pQF As IQueryFilter, pAddrFeature As IFeature
        Dim intRoadSegIDFld As Integer, intAddrPointSegIDFld As Integer, intLHFld As Integer, intRHFld As Integer
        Dim intLowSegID As Long, intHighSegID As Long, intMaxLoAddr As Long
        Dim pAddrATRTable As ITable, pAddrATRCursor As ICursor, pAddrATRRow As IRow
        Dim intAPNIDFld As Integer, intAddrNoFld As Integer, intAddrATRSegIDFld As Integer, intAddrNo As Long
        Try
            pAddrATRCursor = Nothing
            pAddrCursor = Nothing
            pAddrATRRow = Nothing
            pAddrATRTable = Nothing
            '-get the Address attributes (stored in a separate table)
            pAddrATRTable = GetWorkspaceTable("ANY", m_pMXDoc.ActiveView, ADDRESS_DATASRC, False)
            '-make sure we got the table
            If pAddrATRTable Is Nothing Then
                MsgBox("Address attribute table (" & ADDRESS_DATASRC & ") was not found in the database." & vbCr & _
                               "Address points were NOT reassigned for the split road.", vbCritical, "Split Road")
                Exit Sub
            End If
            '-get the new low/high seg IDs
            intRoadSegIDFld = NewLowFeature.Fields.FindField(RD_ROADSEGID_FLD_NAME)
            intLowSegID = NewLowFeature.Value(intRoadSegIDFld)
            intHighSegID = NewHighFeature.Value(intRoadSegIDFld)
            '-find the cutoff point for addresses (highest value on the "low" segment)
            intLHFld = NewLowFeature.Fields.FindField(RD_LHIGHADDR_FLD_NAME)
            intRHFld = NewLowFeature.Fields.FindField(RD_RHIGHADDR_FLD_NAME)
            '-get the highest value from the Right and Left sides ...
            intMaxLoAddr = NewLowFeature.Value(intLHFld)
            If NewLowFeature.Value(intRHFld) > intMaxLoAddr Then intMaxLoAddr = NewLowFeature.Value(intRHFld)


            '-get the address point feature class (it doesn't have to be in the map, we'll get it from the database)
            Dim pDS As IDataset, pFWS As IFeatureWorkspace
            pDS = m_pFeatureClass 'QI
            pFWS = pDS.Workspace 'get the workspace that contains the Roads layer (and presumably the Address feature class)

            '-call a function that will return the Address Points feature class
            Dim pAddressFtClass As IFeatureClass
            pAddressFtClass = GetWorkspaceTable("ANY", m_pMXDoc.ActiveView, ADDRESS_DATASRC, False)
            '-Find the segment that the addresses went to so you can loop through them

            '-get all the existing address points using one of the segids
            pQF = New QueryFilter
            Dim pWhereClse As String
            pWhereClse = ADDR_ROADSEGID_FLD_NAME & " = " & OriginalSegID
            pQF.WhereClause = pWhereClse
            If pAddressFtClass.FeatureCount(pQF) = 0 Then
                pWhereClse = ADDR_ROADSEGID_FLD_NAME & " = " & intLowSegID
                pQF.WhereClause = pWhereClse
                If pAddressFtClass.FeatureCount(pQF) = 0 Then
                    pWhereClse = ADDR_ROADSEGID_FLD_NAME & " = " & intHighSegID
                    pQF.WhereClause = pWhereClse
                End If
            End If

            intAddrCount = pAddressFtClass.FeatureCount(pQF)
            '730: MsgBox ("address count: " & intAddrCount)

            '-get the address points from the address point feature class
            pAddrCursor = pAddressFtClass.Update(pQF, False)

            '-get the key field for the related (ATR) table
            intAPNIDFld = pAddressFtClass.Fields.FindField(ADDR_APNID_FLD_NAME)

            '-complain if the field wasn't found, exit the sub
            If intAPNIDFld < 0 Then
                MsgBox("The following field was not found in the 'Address Points' feature class:" & vbCr & _
                               ADDR_APNID_FLD_NAME & vbCr & _
                               "Address points were NOT reassigned for the split road.", MsgBoxStyle.Critical, "Split Road")
                Exit Sub
            End If
            '-get the address number field from the ATR table
            intAddrNoFld = pAddrATRTable.FindField(ADDR_ADDRNO_FLD_NAME)
            '-complain if the field wasn't found, exit the sub
            If intAddrNoFld < 0 Then
                MsgBox("The following field was not found in the 'Address ATR' table:" & vbCr & _
                               ADDR_ADDRNO_FLD_NAME & vbCr & _
                               "Address points were NOT reassigned for the split road.", MsgBoxStyle.Critical, "Split Road")
                Exit Sub
            End If
            '-get the road segment ID field from the Address ATR table
            intAddrATRSegIDFld = pAddrATRTable.FindField(ADDR_ROADSEGID_FLD_NAME)
            '-complain if the field wasn't found, exit the sub
            If intAddrATRSegIDFld < 0 Then
                MsgBox("The following field was not found in the 'Address ATR' table:" & vbCr & _
                               ADDR_ROADSEGID_FLD_NAME & vbCr & _
                               "Address points were NOT reassigned for the split road.", MsgBoxStyle.Critical, "Split Road")
                Exit Sub
            End If
            '-get the road segment ID field from the Address Point feature class
            intAddrPointSegIDFld = pAddressFtClass.Fields.FindField(ADDR_ROADSEGID_FLD_NAME)
            '-complain if the field wasn't found, exit the sub
            If intAddrPointSegIDFld < 0 Then
                MsgBox("The following field was not found in the 'Address Points' feature class:" & vbCr & _
                               ADDR_ROADSEGID_FLD_NAME & vbCr & _
                               "Address points were NOT reassigned for the split road.", MsgBoxStyle.Critical, "Split Road")
                Exit Sub
            End If

            'Check for orphans and pop up only 1 message box
            Dim OrphanAddrCnt As Integer
            Dim padrapncnt As Integer = 0
            OrphanAddrCnt = 0
            '-loop thru all address point features
            pAddrFeature = pAddrCursor.NextFeature

            Do Until pAddrFeature Is Nothing
                '*get records from ATR table that relate to this address (APNID field) ... *should* only be one
                pQF.WhereClause = ADDR_APNID_FLD_NAME & " = " & pAddrFeature.Value(intAPNIDFld)
                pAddrATRCursor = pAddrATRTable.Search(pQF, True)
                '*loop thru ATR recs, get AddrNo and compare it to the cut off (maximum on the low seg)
                pAddrATRRow = pAddrATRCursor.NextRow 'should be the only related rec
                '-complain if a matching record wasn't found
                If pAddrATRRow Is Nothing Then
                    MsgBox("Error accessing related address records in " & ADDRESS_DATASRC & " . Address points have NOT been successfully reassigned for the split road.", vbCritical, "Split Road")
                    Exit Sub
                End If


                If pAddrATRRow.Value(pAddrATRRow.Fields.FindField(ADDR_SUBTYPE_FLD_NAME)) = 2 Then



                    intAddrNo = pAddrATRRow.Value(intAddrNoFld) 'get the address number
                    '*if the ATR rec is lower than the cutoff, assign it to the low seg, otherwise the high
                    '783:         MsgBox (intAddrNo & "   for intMaxLoAddr   ")
                    If intAddrNo <= intMaxLoAddr Then

                        '*update ATR RoadSegID value with the "low" seg ID
                        pAddrATRRow.Value(intAddrATRSegIDFld) = intLowSegID
                        '*update AddrPt RoadSegID value with the "low" seg ID
                        pAddrFeature.Value(intAddrPointSegIDFld) = intLowSegID
                    Else
                        '*update ATR RoadSegID value with the "high" seg ID
                        pAddrATRRow.Value(intAddrATRSegIDFld) = intHighSegID
                        '*update AddrPt RoadSegID value with the "high" seg ID
                        pAddrFeature.Value(intAddrPointSegIDFld) = intHighSegID
                    End If

                    '-call the update methods on the cursor objects
                    'pAddrATRCursor.UpdateRow pAddrATRRow '<--doesn't work (?)
                    pAddrCursor.UpdateFeature(pAddrFeature)
                    '-call Store on the row
                    If pAddrATRRow.Value(pAddrATRRow.Fields.FindField(ADDR_SUBTYPE_FLD_NAME)) <> 2 Then
                        'Had to comment this out in upgrade to 10 for some reasons.  Probably a cursor change.
                        'pAddrATRRow.Store()
                    Else
                        OrphanAddrCnt = OrphanAddrCnt + 1
                    End If

                    '-see if there's another related address record, complain if there is
                    'changed to only inform at the end, but keep going.
                    pAddrATRRow = pAddrATRCursor.NextRow

                    If Not pAddrATRRow Is Nothing Then
                        padrapncnt = padrapncnt + 1
                        'MsgBox("Duplicate matching records found in table " & ADDRESS_DATASRC & " when executing query " & vbCr & _
                        'pQF.WhereClause & vbCr & _
                        '"Only the first record has been updated." & vbNewLine & "Please MANUALLY check and adjust your Addresses!", vbExclamation, "Split Road")
                    End If




                End If 'orphan test





                pAddrFeature = pAddrCursor.NextFeature
            Loop
            If padrapncnt > 0 Then
                MsgBox(padrapncnt & " Multiple Addresse(s) found with duplicated APNIDs during split." & vbCr & "These may be duplicated Addrs and should be checked", vbOKOnly, "Multi Addresses on APN")
            End If
            If OrphanAddrCnt > 0 Then
                MsgBox(OrphanAddrCnt & " Orphan Addresse(s) found during split." & vbCr & "These may not have been assigned correctly", vbOKOnly, "Ophan Addresses")
            End If
            pAddrATRCursor = Nothing
            pAddrCursor = Nothing
            pAddrATRRow = Nothing
            pAddrATRTable = Nothing
            Exit Sub 'avoid error handling code
        Catch ex As Exception
            pAddrATRCursor = Nothing
            pAddrCursor = Nothing
            pAddrATRRow = Nothing
            pAddrATRTable = Nothing
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try

    End Sub


    Private Sub ClearDupGeometryTbl(ByVal NewLowFeature As IFeature, ByVal NewHighFeature As IFeature)
        'This function will find dup geometry table entries and remove them

        Dim pQF As IQueryFilter
        Dim intRoadSegIDFld As Integer
        Dim intLowSegID As Long, intHighSegID As Long
        Dim pGeoTable As ITable, pGeoCursor As ICursor, pGeoRow As IRow
        '-get the Address attributes (stored in a separate table)
        pGeoTable = GetWorkspaceTable("ANY", m_pMXDoc.ActiveView, RD_GEOM_DATASRC, False)
        '-make sure we got the table
        If pGeoTable Is Nothing Then
            MsgBox("Road Geometry attribute table (" & RD_GEOM_DATASRC & ") was not found in the database." & vbCr & _
                           "Duplicate Geometry Records were not cleared for the split road.", vbCritical, "Split Road")
            Exit Sub
        End If
        '-get the new low/high seg IDs
        intRoadSegIDFld = NewLowFeature.Fields.FindField(RD_ROADSEGID_FLD_NAME)
        intLowSegID = NewLowFeature.value(intRoadSegIDFld)
        intHighSegID = NewHighFeature.value(intRoadSegIDFld)


        '-get all the existing address points using one of the segids
        pQF = New QueryFilter
        Dim pWhereClse As String
        pWhereClse = RD_ROADSEGID_FLD_NAME & " = " & intLowSegID
        pQF.WhereClause = pWhereClse
        If pGeoTable.RowCount(pQF) > 1 Then
            pGeoCursor = pGeoTable.Update(pQF, False)
        Else
            pWhereClse = RD_ROADSEGID_FLD_NAME & " = " & intHighSegID
            pQF.WhereClause = pWhereClse
            If pGeoTable.RowCount(pQF) > 1 Then
                pGeoCursor = pGeoTable.Update(pQF, False)
            Else
                'no dups
                pGeoTable = Nothing
                Exit Sub
            End If
        End If
        pGeoRow = pGeoCursor.NextRow
        If Not pGeoRow Is Nothing Then
            pGeoRow.Delete()
            'MsgBox ("Deleted Duplicate Geo")
            pGeoRow = Nothing
            pGeoCursor = Nothing
            pGeoTable = Nothing
        End If
        Exit Sub

    End Sub

    Private Sub UpdateRdSegAliasTbl(ByVal NewLowFeature As IFeature, ByVal NewHighFeature As IFeature, ByVal OriginalSegID As Long)
        'This function will update the roadseg alias table


        Dim pQF As IQueryFilter
        Dim intRoadSegIDFld As Integer
        Dim intLowSegID As Long, intHighSegID As Long, intAliasIDFld As Long
        Dim pRoadAliasTable As ITable, pRoadAliasCursor As ICursor, pRoadAliasRow As IRow
        Dim pRoadAddAliasCur As ICursor
        '-get the Address attributes (stored in a separate table)
        pRoadAliasTable = GetWorkspaceTable("ANY", m_pMXDoc.ActiveView, ROAD_ALIAS_DATASRC, False)
        '-make sure we got the table
        If pRoadAliasTable Is Nothing Then
            'MsgBox("Road Geometry attribute table (" & RD_GEOM_DATASRC & ") was not found in the database." & vbCr & _
            '               "Duplicate Geometry Records were not cleared for the split road.", vbCritical, "Split Road")
            Exit Sub
        End If
        '-get the new low/high seg IDs
        intAliasIDFld = pRoadAliasTable.Fields.FindField(RD_ROADSEGID_FLD_NAME)
        intRoadSegIDFld = NewLowFeature.Fields.FindField(RD_ROADSEGID_FLD_NAME)
        intLowSegID = NewLowFeature.Value(intRoadSegIDFld)
        intHighSegID = NewHighFeature.Value(intRoadSegIDFld)


        '-get all the existing aliases points using one of the segids
        pQF = New QueryFilter
        Dim pWhereClse As String
        pWhereClse = RD_ROADSEGID_FLD_NAME & " = " & OriginalSegID
        pQF.WhereClause = pWhereClse
        If pRoadAliasTable.RowCount(pQF) > 0 Then

            '--------------------------------
            'insert rows for the high seg id of the split
            pRoadAddAliasCur = pRoadAliasTable.Insert(True)
            'set up the row buffer and insert
            Dim pSrchCurs As ICursor
            pSrchCurs = pRoadAliasTable.Search(pQF, False)
            Dim rowBuffer As IRowBuffer = pSrchCurs.NextRow
            'Obtain all of the fields in table.
            Dim fields As IFields = rowBuffer.Fields
            'Loop through all of the rows.
            Dim Count As Integer = fields.FieldCount
            Do Until rowBuffer Is Nothing
                rowBuffer.Value(rowBuffer.Fields.FindField(RD_ROADSEGID_FLD_NAME)) = intHighSegID
                pRoadAddAliasCur.InsertRow(rowBuffer)
                'Go to the next row.
                rowBuffer = pSrchCurs.NextRow
            Loop

            'flush the cursor. The records are actually stored to the data source during this operation
            pRoadAddAliasCur.Flush()

            pRoadAddAliasCur = Nothing
            rowBuffer = Nothing
            pSrchCurs = Nothing

            '---------------------------------------

            'Then update the existing to the low end
            pRoadAliasCursor = pRoadAliasTable.Update(pQF, False)

            pRoadAliasRow = pRoadAliasCursor.NextRow
            Do Until pRoadAliasRow Is Nothing
                pRoadAliasRow.Value(intAliasIDFld) = intLowSegID
                ' pRoadAliasRow.Store()
                pRoadAliasCursor.UpdateRow(pRoadAliasRow)
                pRoadAliasRow = pRoadAliasCursor.NextRow
            Loop
            pRoadAliasCursor = Nothing
            pRoadAliasRow = Nothing



        Else
            'no segs
            pRoadAliasTable = Nothing
            Exit Sub
        End If
        Exit Sub

    End Sub

    Public Overrides ReadOnly Property Enabled() As Boolean
        Get
            Try
                Dim CrntActiveView As IActiveView
                CrntActiveView = m_hookHelper.ActiveView
                m_pMXDoc = m_application.Document
                CrntActiveView = m_pMXDoc.ActivatedView
                'Disable if not editing
                m_pEditor = m_application.FindExtensionByName("ESRI Object Editor")
                If m_pEditor.EditState = esriEditState.esriStateEditing Then
                    'check if layer is selected and polyline
                    If CheckForLayer(ROAD_DATASRC, CrntActiveView) Then
                        Dim pFlayer As IFeatureLayer
                        Dim pFsel As IFeatureSelection
                        pFlayer = GetLayerByName(m_pMXDoc, ROAD_DATASRC)
                        pFsel = pFlayer
                        If pFsel.SelectionSet.Count > 0 Then
                            Return True
                        Else
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
End Class

