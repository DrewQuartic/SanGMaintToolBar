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

<ComClass(Road_AddRoadSegAlias.ClassId, Road_AddRoadSegAlias.InterfaceId, Road_AddRoadSegAlias.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Road_AddRoadSegAlias")> _
Public NotInheritable Class Road_AddRoadSegAlias
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "18cd57fd-56dd-405f-ba76-39571edb6e69"
    Public Const InterfaceId As String = "4e6907fb-7113-43eb-bbab-9ba190a9f62e"
    Public Const EventsId As String = "5b206c50-19cb-42cb-af8c-832323715440"
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
    Private m_pFeatureLayer As IFeatureLayer

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()

        ' TODO: Define values for the public properties
        ' TODO: Define values for the public properties
        MyBase.m_category = "SanGIS"  'localizable text 
        MyBase.m_caption = "Add Road Seg Alias to Road Seg"   'localizable text 
        MyBase.m_message = "Add Road Seg Alias to Road Seg"   'localizable text 
        MyBase.m_toolTip = "Add Road Seg Alias to Road Seg" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Road_AddRoadSegAlias"  'unique id, non-localizable (e.g. "MyCategory_MyCommand")



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

            m_pFeatureLayer = GetLayerByName(m_pMXDoc, ROAD_DATASRC)
            Dim pFeatureSel As IFeatureSelection
            pFeatureSel = m_pFeatureLayer 'QI
            Dim pSelectionSet As ISelectionSet
            pSelectionSet = pFeatureSel.SelectionSet
            If pSelectionSet.Count = 0 Then
                MsgBox("No Road Segment Selected", vbExclamation, "Add Road Seg Alias")
                Exit Sub
            End If
            Dim pFeatCurs As IFeatureCursor
            pFeatCurs = Nothing
            pSelectionSet.Search(Nothing, False, pFeatCurs)

            Dim AddRoadSegAliasForm As New frmAddRoadSegAlias
            'PasteRoadAttributesForm.FrmMap = m_hookHelper.ActiveView
            AddRoadSegAliasForm.FrmMap = m_pMXDoc.ActiveView
            AddRoadSegAliasForm.Seg = pFeatCurs.NextFeature
            AddRoadSegAliasForm.Workspace = m_pFeatureLayer.FeatureClass.FeatureDataset.Workspace
            m_pEditor.StartOperation()
            AddRoadSegAliasForm.ShowDialog()
            m_pEditor.StopOperation("Add RoadSeg Alias")
        Catch ex As Exception

        End Try
    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_AddRoadSegAlias.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_AddRoadSegAlias.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_AddRoadSegAlias.OnMouseUp implementation
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

