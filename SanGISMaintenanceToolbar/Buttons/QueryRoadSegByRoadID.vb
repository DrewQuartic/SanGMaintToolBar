Imports System.Runtime.InteropServices
Imports System.Drawing
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.ArcMapUI
Imports System.Windows.Forms
Imports ESRI.ArcGIS.Carto
Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.Controls

<ComClass(QueryRoadSegByRoadID.ClassId, QueryRoadSegByRoadID.InterfaceId, QueryRoadSegByRoadID.EventsId), _
 ProgId("SanGISMaintenanceToolbar.QueryRoadSegByRoadID")> _
Public NotInheritable Class QueryRoadSegByRoadID
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "2f2da2b9-ac55-408a-afde-10b68e779de4"
    Public Const InterfaceId As String = "2fb46720-941e-4f61-bde3-f0275f8e251d"
    Public Const EventsId As String = "f5825b92-243c-42d5-820d-1b7185c60a36"
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
    Private m_app As IApplication

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()

        ' TODO: Define values for the public properties
        ' TODO: Define values for the public properties
        MyBase.m_category = "SanGIS"  'localizable text 
        MyBase.m_caption = "Query Roads or RoadSegs"   'localizable text 
        MyBase.m_message = "Allows User to Query Roads and RoadSegs"   'localizable text 
        MyBase.m_toolTip = "Query Roads or RoadSegs" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_QueryRoadSegByRoadID"  'unique id, non-localizable (e.g. "MyCategory_ArcMapTool")


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
            Try
                m_hookHelper.Hook = hook
                If m_hookHelper.ActiveView Is Nothing Then m_hookHelper = Nothing
            Catch
                m_hookHelper = Nothing
            End Try
            m_app = hook
            'Disable if hook fails
            If m_hookHelper Is Nothing Then
                MyBase.m_enabled = False
            Else
                MyBase.m_enabled = True
            End If
        End If
    End Sub

    Public Overrides Sub OnClick()
        Dim QueryRoadSegIDRoadIDForm As New frmQueryRoadSegByRoadID
        QueryRoadSegIDRoadIDForm.FrmMap = m_hookHelper.ActiveView
        QueryRoadSegIDRoadIDForm.Show()
        m_app.CurrentTool = Nothing
    End Sub


    Public Overrides ReadOnly Property Enabled() As Boolean
        Get
            Try
                Dim CrntActiveView As IActiveView
                CrntActiveView = m_hookHelper.ActiveView
                If CheckForLayer("ANY", CrntActiveView) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add QueryRoadSeg.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add QueryRoadSeg.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add QueryRoadSeg.OnMouseUp implementation
    End Sub
End Class

