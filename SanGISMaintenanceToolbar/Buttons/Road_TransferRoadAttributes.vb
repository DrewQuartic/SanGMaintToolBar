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
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Display


<ComClass(Road_TransferRoadAttributes.ClassId, Road_TransferRoadAttributes.InterfaceId, Road_TransferRoadAttributes.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Road_TransferRoadAttributes")> _
Public NotInheritable Class Road_TransferRoadAttributes
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "48a38978-9203-43e7-b320-b67ea93bd557"
    Public Const InterfaceId As String = "363a2395-e7d7-4412-8022-e9fa39cc0e22"
    Public Const EventsId As String = "c89df249-2ac6-4f46-9f97-95df557e6e37"
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
    Private m_pTransferFeat As IFeature
    Private m_pRoadLayer As IFeatureLayer
    Private TranAttrs As Boolean
    Private TranAddrs As Boolean
    Private TranAlias As Boolean
    Private TranRemove As Boolean

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()

        ' TODO: Define values for the public properties
        ' TODO: Define values for the public properties
        MyBase.m_category = "SanGIS"  'localizable text
        MyBase.m_caption = "Transfer Road Attributes"   'localizable text 
        MyBase.m_message = "Transfer Road Attributes"   'localizable text 
        MyBase.m_toolTip = "Transfer Road Attributes" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Road_TransferRoadAttributes"  'unique id, non-localizable (e.g. "MyCategory_MyCommand")

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
        Dim pSnapVertex As IFeatureSnapAgent
        Dim pSnapEnvironment As ISnapEnvironment
        Dim pFeatureLayer As IFeatureLayer
        Dim TransferRdInfoForm As New frmTransferRoadInfo

        Try
            pFeatureLayer = GetLayerByName(m_pMXDoc, ROAD_DATASRC)
            m_pRoadLayer = pFeatureLayer

            If pFeatureLayer Is Nothing Then
                MsgBox("Warning Snapping for this tool not set")
                m_application.CurrentTool = Nothing
                Exit Sub
            End If

            Dim pFeatSel As IFeatureSelection
            pFeatSel = pFeatureLayer 'QI

            Dim pSelSet As ISelectionSet
            pSelSet = pFeatSel.SelectionSet

            Dim pEnumIDs As IEnumIDs
            pEnumIDs = pSelSet.IDs
            Dim i As Integer
            i = 0
            Dim lngTest As Long
            lngTest = pEnumIDs.Next
            Do Until lngTest = -1
                i = i + 1
                lngTest = pEnumIDs.Next
            Loop
            If i > 1 Then
                MsgBox(" More than one Feature Selected in the roads layer ", vbCritical, "Trasfer Tool Error")
                m_application.CurrentTool = Nothing
                Exit Sub
            ElseIf i = 0 Then
                MsgBox("No feature selected in the roads layer .", vbCritical, "Trasfer Tool Error")
                m_application.CurrentTool = Nothing
                Exit Sub
            End If
            pEnumIDs.Reset()
            Dim lngID As Long
            lngID = pEnumIDs.Next

            TransferRdInfoForm.ShowDialog()
            '-if the user clicked "Close" or "X'd" out of the dialog, exit the procedure
            If Not TransferRdInfoForm.p_NotCanceled Then
                TransferRdInfoForm.Close()
                m_application.CurrentTool = Nothing
                Exit Sub
            End If
            'Get the choices for transfering from the choices form
            TranAttrs = TransferRdInfoForm.chkAttrs.Checked
            TranAddrs = TransferRdInfoForm.chkAddrs.Checked
            TranAlias = TransferRdInfoForm.chkAlias.Checked
            TranRemove = TransferRdInfoForm.chkRemove.Checked
            TransferRdInfoForm.Close()

            m_pTransferFeat = pFeatureLayer.FeatureClass.GetFeature(lngID)

            pSnapVertex = New FeatureSnap

            pSnapVertex.FeatureClass = m_pRoadLayer.FeatureClass
            pSnapVertex.HitType = ESRI.ArcGIS.Geometry.esriGeometryHitPartType.esriGeometryPartBoundary

            pSnapEnvironment = m_pEditor 'QI
            pSnapEnvironment.AddSnapAgent(pSnapVertex)
        Catch ex As Exception
            m_application.CurrentTool = Nothing
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            TransferRdInfoForm.Close()
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_TransferRoadAttributes.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        Try
            'Code here to show the snap point ...
            Dim pSnapEnv As ISnapEnvironment
            Dim pSnapPoint As IPoint, pEnv As IEnvelope, bSnapped As Boolean
            '-get the snapping props from the Editor
            pSnapEnv = m_pEditor 'QI
            '-get a map point from the current mouse position (pixels)

            Dim pMxApp As IMxApplication
            pMxApp = m_application
            pSnapPoint = pMxApp.Display.DisplayTransformation.ToMapPoint(X, Y)
            pEnv = pSnapPoint.Envelope 'a point's envelope is initially empty
            pEnv.Expand(80, 80, False) 'make the envelope 80'x80'
            '-refresh the portion of the display around the mouse (clean up any graphic "artifacts")

            pMxApp.Display.Invalidate(pEnv, True, esriScreenCache.esriNoScreenCache) ' esriNoScreenCache)
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
        Try
            '-When the mouse comes up on the transfer tool assign attributes accordingly
            Dim pClickPoint As IPoint, pSnapEnv As ISnapEnvironment, bSnapOK As Boolean, pFSel As IFeatureSelection
            Dim pRoadCursor As IFeatureCursor, pRoadFeature As IFeature
            Dim pPointFilter As ISpatialFilter
            Dim pTestCursor As IFeatureCursor
            Dim pFeatLayer As IFeatureLayer
            Dim pFeatureclass As IFeatureClass
            Dim pWorkspace As IWorkspace
            Dim pFeatWorkSpace As IFeatureWorkspace
            Dim pTable As ITable
            Dim pCursor As ICursor
            Dim pRow As IRow
            pTestCursor = Nothing

            '-show the "hourglass" cursor while processing
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor


            '-get the point (in map units) that was clicked
            Dim pMxApp As IMxApplication
            pMxApp = m_application
            pClickPoint = pMxApp.Display.DisplayTransformation.ToMapPoint(X, Y) 'x/y are in pixels

            '-make sure the point snaps to a road. If not, exit the sub
            pSnapEnv = m_pEditor 'QI

            '-check the regular snapping first (does it snap to ANY road?)
            bSnapOK = pSnapEnv.SnapPoint(pClickPoint)
            If Not bSnapOK Then 'point did not snap to a road
                MsgBox("The point you clicked did not snap to a road feature in T.Road. You may set snapping layers or increase your snapping tolerance.", vbExclamation, "Split Road")
                Exit Sub
            End If

            '-find the road that was clicked, will be called "pRoadFeature"
            m_pEditor.StartOperation()  'required when editing ArcSDE geodatabase!
            pPointFilter = New SpatialFilter 'spatial filter that uses the click point to locate a road
            pPointFilter.Geometry = pClickPoint
            pPointFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects

            pFeatLayer = GetLayerByName(m_pMXDoc, ROAD_DATASRC) 'QI      Only transfering from between roads in the same layer.
            pRoadCursor = pFeatLayer.FeatureClass.Update(pPointFilter, False)
            pRoadFeature = pRoadCursor.NextFeature

            If pRoadFeature Is Nothing Then
                MsgBox("You didn't click on a feature in the T.Road layer")
                m_pEditor.StopOperation("Transfer Attributes")
                Exit Sub
            End If

            '-should only be one feature (road) ... code assumes there's either 1 or 0 (takes the first one that's found)
            If pRoadFeature Is Nothing Then '*should* always find one, the point already snapped to a road!
                MsgBox("Transfer point did not locate a road feature.", vbCritical, "Transfer Attributes")
                m_pEditor.StopOperation("Transfer Attributes")
                Exit Sub
            End If

            '-see if the user clicked on the road source,Transfer, road. If so exit
            pFSel = pFeatLayer 'QI
            'Get the seleted feature
            Dim pSelectionSet As ISelectionSet
            pSelectionSet = pFSel.SelectionSet
            pSelectionSet.Search(Nothing, False, pTestCursor)
            Dim pFeat As IFeature
            '-get the selected road
            pFeat = pTestCursor.NextFeature
            '-make sure its not the same feature being used as the source, if it is, exit
            If m_pTransferFeat.OID = pRoadFeature.OID Then
                MsgBox("Source and target still the same")
                MsgBox("m_pTransferFeat roadid  = " & m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_ROADID_FLD_NAME)) & vbCrLf & "pRoadFeature roadid = " & pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_ROADID_FLD_NAME)))
                m_pEditor.StopOperation("Transfer Attributes")
                Exit Sub
            End If

            'First get the old and the new ROADSEGID's
            Dim lngOldRoadSegID As Long
            Dim lngNewRoadSegID As Long
            lngOldRoadSegID = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_ROADSEGID_FLD_NAME))
            lngNewRoadSegID = pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_ROADSEGID_FLD_NAME))


            If TranAttrs Then
                'Finally transfer the attributes from the source road to the clicked on road
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_ROADID_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_ROADID_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_DEDSTAT_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_DEDSTAT_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_SEGSTAT_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_SEGSTAT_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_RIGHTWAY_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_RIGHTWAY_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_FUNCLASS_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_FUNCLASS_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_LJURIS_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_LJURIS_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_RJURIS_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_RJURIS_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_RMIXADDR_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_RMIXADDR_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_LMIXADDR_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_LMIXADDR_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_CARTO_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_CARTO_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_OBMH_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_OBMH_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_FIREDRIV_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_FIREDRIV_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_ONEWAY_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_ONEWAY_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_SEGCLASS_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_SEGCLASS_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_LLOWADDR_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_LLOWADDR_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_LHIGHADDR_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_LHIGHADDR_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_RLOWADDR_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_RLOWADDR_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_RHIGHADDR_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_RHIGHADDR_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_ABLOADDR_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_ABLOADDR_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_ABHIADDR_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_ABHIADDR_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_SPEED_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_SPEED_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_FLEVEL_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_FLEVEL_FLD_NAME))
                pRoadFeature.Value(pRoadFeature.Fields.FindField(RD_TLEVEL_FLD_NAME)) = m_pTransferFeat.Value(m_pTransferFeat.Fields.FindField(RD_TLEVEL_FLD_NAME))
                pRoadFeature.Store()
                pRoadCursor.UpdateFeature(pRoadFeature)
                pRoadFeature = pRoadCursor.NextFeature
            End If
            pRoadCursor = Nothing
            pRoadFeature = Nothing

            'Next use the old ROADSEGID to create a queryfilter 
            Dim pQueryFilter As IQueryFilter
            pQueryFilter = New QueryFilter
            pQueryFilter.WhereClause = "ROADSEGID = '" & lngOldRoadSegID & "'"
            'get the workspace to get the tables to modify
            pFeatureclass = m_pRoadLayer.FeatureClass
            pWorkspace = pFeatureclass.FeatureDataset.Workspace
            pFeatWorkSpace = pWorkspace 'QI
            'Addresses if checked in form
            If TranAddrs Then
                'Must also change the associated ROADSEGID values in the Addrapn_ATR to maintain link.
                'To do this select all records in Addrapn_ATR with the old roadsegid and change that value
                'to the new roadsegid
                pTable = pFeatWorkSpace.OpenTable(ADDRESS_DATASRC)
                pCursor = pTable.Update(pQueryFilter, False)
                pRow = pCursor.NextRow
                Do Until pRow Is Nothing
                    pRow.Value(pRow.Fields.FindField(ADDR_ROADSEGID_FLD_NAME)) = lngNewRoadSegID
                    pCursor.UpdateRow(pRow)
                    pRow = pCursor.NextRow
                Loop
                pTable = Nothing
                pCursor = Nothing
                pRow = Nothing
            End If
            'Aliases if chosen
            If TranAlias Then
                'Finally update the RoadsegAlias table to maintain the link
                pTable = pFeatWorkSpace.OpenTable(ROADSEG_ALIAS_DATASRC)
                pCursor = pTable.Update(pQueryFilter, False)
                pRow = pCursor.NextRow
                Do Until pRow Is Nothing
                    pRow.Value(pRow.Fields.FindField(RDSEG_ALIAS_ROADSEGID_FLD_NAME)) = lngNewRoadSegID
                    pCursor.UpdateRow(pRow)
                    pRow = pCursor.NextRow
                Loop
                pTable = Nothing
                pCursor = Nothing
                pRow = Nothing
            End If

            Dim pEnvelope As IEnvelope
            pEnvelope = m_pTransferFeat.Shape.Envelope

            'Remove original road segment if chosen
            If TranRemove Then
                m_pTransferFeat.Delete()
            Else
                Dim pFeatRdSel As IFeatureSelection
                pFeatRdSel = m_pRoadLayer 'QI
                pFeatRdSel.Clear()
            End If

            'Do not need to do the Road Geometry because it is updated on any change
            'Do not need to do the roadnames, because they are based on the RoadID which carried over
            m_pEditor.StopOperation("Transfer Attributes")
            m_pMXDoc.ActivatedView.PartialRefresh(65535, pFeatLayer, pEnvelope)
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            m_application.CurrentTool = Nothing

        Catch ex As Exception
            m_application.CurrentTool = Nothing
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
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

