Imports System.Runtime.InteropServices
Imports System.Drawing
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.ArcMapUI
Imports System.Windows.Forms
Imports ESRI.ArcGIS.Controls
Imports ESRI.ArcGIS.Carto
Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.Geodatabase

<ComClass(Intersection_SelectUnderReivew.ClassId, Intersection_SelectUnderReivew.InterfaceId, Intersection_SelectUnderReivew.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Intersection_SelectUnderReivew")> _
Public NotInheritable Class Intersection_SelectUnderReivew
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "c33ad191-2394-49cb-850d-213ae3891a89"
    Public Const InterfaceId As String = "86e8041f-ee30-4447-85f3-0f071f308624"
    Public Const EventsId As String = "892d1b0c-b282-4d2c-baae-787e5c370053"
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
        MyBase.m_caption = "Show Under Review Intersections in Current View"   'localizable text 
        MyBase.m_message = "Show Under Review Intersections in Current View"   'localizable text 
        MyBase.m_toolTip = "Show Under Review Intersections in Current View" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Intersection_SelectUnderReivew"  'unique id, non-localizable (e.g. "MyCategory_ArcMapTool")

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
    End Sub

    Public Overrides Sub OnClick()

        Dim pActiveView As IActiveView
        Dim pDocDirty As IDocumentDirty
        Dim pFeatLayer As IFeatureLayer
        Dim pFeatClass As IFeatureClass
        Dim pFeatSelection As IFeatureSelection

        Dim pSpatialFilter As ISpatialFilter

        Try
            '-show the "hourglass" cursor while processing
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor

            m_application.CurrentTool = Nothing

            pActiveView = m_pMXDoc.ActiveView

            pFeatLayer = GetLayerByName(m_pMXDoc, INTERSECTION_DATASRC)
            If pFeatLayer Is Nothing Then
                MessageBox.Show("Intersection Layer not Found, Please Load")
                Exit Sub
            End If
            pFeatClass = pFeatLayer.FeatureClass

            pSpatialFilter = New SpatialFilter
            pSpatialFilter.Geometry = pActiveView.Extent
            pSpatialFilter.GeometryField = pFeatClass.ShapeFieldName
            pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects
            pSpatialFilter.WhereClause = "Type = 'R'"


            'Invalidate Selection cache
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, pFeatLayer, pActiveView.Extent)
            'Select
            pFeatSelection = pFeatLayer
            pFeatSelection.SelectFeatures(pSpatialFilter, esriSelectionResultEnum.esriSelectionResultNew, False)
            pFeatSelection.SelectionChanged()
            'Refresh
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, pFeatLayer, pActiveView.Extent)


            pDocDirty = m_pMXDoc
            pDocDirty.SetDirty()

            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Catch ex As Exception
            m_application.CurrentTool = Nothing
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Intersection_SelectUnderReivew.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Intersection_SelectUnderReivew.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Intersection_SelectUnderReivew.OnMouseUp implementation
    End Sub
    Public Overrides ReadOnly Property Enabled() As Boolean
        Get
            Try
                Dim CrntActiveView As IActiveView
                m_pMXDoc = m_application.Document
                CrntActiveView = m_pMXDoc.ActivatedView
                'Disable if no road layer
                If CheckForLayer(INTERSECTION_DATASRC, CrntActiveView) Then
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

