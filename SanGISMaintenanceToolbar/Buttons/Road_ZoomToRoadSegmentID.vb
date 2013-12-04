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

<ComClass(Road_ZoomToRoadSegmentID.ClassId, Road_ZoomToRoadSegmentID.InterfaceId, Road_ZoomToRoadSegmentID.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Road_ZoomToRoadSegmentID")> _
Public NotInheritable Class Road_ZoomToRoadSegmentID
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "5923744a-bb00-4af0-a37e-a4ae341dbb7a"
    Public Const InterfaceId As String = "97116e80-336c-42d0-bf68-05a483746a7a"
    Public Const EventsId As String = "da7c4abb-32eb-4a57-b333-17e9a4591a84"
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

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()

        ' TODO: Define values for the public properties
        ' TODO: Define values for the public properties
        MyBase.m_category = "SanGIS"  'localizable text 
        MyBase.m_caption = "Zoom to Road Seg by SegID"   'localizable text 
        MyBase.m_message = "Zoom to Road Seg by SegID"   'localizable text 
        MyBase.m_toolTip = "Zoom to Road Seg by SegID" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Road_ZoomToRoadSegmentID"  'unique id, non-localizable (e.g. "MyCategory_MyCommand")

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
            m_application.CurrentTool = Nothing
            Dim sRdSeg As String
            Dim pActiveView As IActiveView
            Dim pDocDirty As IDocumentDirty
            Dim pFeatLayer As IFeatureLayer
            Dim pFeatClass As IFeatureClass
            Dim pFeatCursor As IFeatureCursor
            Dim pFeatSelSegment As IFeatureSelection
            Dim pFeature As IFeature
            pActiveView = m_pMXDoc.ActiveView
            sRdSeg = ""
            Do While sRdSeg = ""
                sRdSeg = InputBox("Enter RoadSegID", "Road Segment Search")
                If sRdSeg = "" Then Exit Sub
                If Not IsNumeric(sRdSeg) Then
                    MsgBox(sRdSeg & " is not numeric", vbExclamation, "Road Segment Search Error")
                    sRdSeg = ""
                End If
            Loop

            '-show the "hourglass" cursor while processing

            'Set pMouseCursor = New MouseCursor
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor


            Dim pQF2 As IQueryFilter
            pQF2 = New QueryFilter
            pQF2.WhereClause = RD_ROADSEGID_FLD_NAME & " = " & sRdSeg
            pFeatLayer = GetLayerByName(m_pMXDoc, ROAD_DATASRC)
            If pFeatLayer Is Nothing Then
                MessageBox.Show("Road Layer not Found, Please Load")
                Exit Sub
            End If
            pFeatClass = pFeatLayer.FeatureClass
            pFeatSelSegment = pFeatLayer
            pFeatSelSegment.SelectFeatures(pQF2, esriSelectionResultEnum.esriSelectionResultNew, False)
            pFeatCursor = pFeatClass.Search(pQF2, True)
            pFeature = pFeatCursor.NextFeature
            'If no roads were found, stop now
            If pFeature Is Nothing Then
                MsgBox("No Road Segment was found matching RoadSegID " & sRdSeg, vbExclamation, _
                       "RoadSegID Search")
                pActiveView.Refresh()
                Exit Sub
            End If

            Dim pEnv As IEnvelope
            pEnv = New Envelope
            Do Until pFeature Is Nothing
                pEnv.Union(pFeature.Extent)
                pFeature = pFeatCursor.NextFeature
            Loop
            If pEnv.IsEmpty Then
                MsgBox("Unable to zoom to the selected road(s)", vbExclamation, _
                       "RoadSegID Search Error")
                pActiveView.Refresh()
                Exit Sub
            End If

            'Zoom to the new extent
            pEnv.Expand(4, 4, True)
            pActiveView.Extent = pEnv
            pActiveView.Refresh()

            pDocDirty = m_pMXDoc
            pDocDirty.SetDirty()

            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_ZoomToRoadSegmentID.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_ZoomToRoadSegmentID.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_ZoomToRoadSegmentID.OnMouseUp implementation

    End Sub

    Public Overrides ReadOnly Property Enabled() As Boolean
        Get
            Try
                Dim CrntActiveView As IActiveView
                m_pMXDoc = m_application.Document
                CrntActiveView = m_pMXDoc.ActivatedView
                'Disable if no road layer
                If CheckForLayer(ROAD_DATASRC, CrntActiveView) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property

End Class

