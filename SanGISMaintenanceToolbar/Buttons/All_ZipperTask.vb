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

<ComClass(All_ZipperTask.ClassId, All_ZipperTask.InterfaceId, All_ZipperTask.EventsId), _
 ProgId("SanGISMaintenanceToolbar.All_ZipperTask")> _
Public NotInheritable Class All_ZipperTask
    Inherits BaseTool
    Implements IShapeConstructorTool, ISketchTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "b6444398-609a-4da0-8d12-f805ab981f43"
    Public Const InterfaceId As String = "b356972a-12f1-4593-9fe7-f908deb21f51"
    Public Const EventsId As String = "fdf7ebd2-0fde-42e7-a363-b2531dfb44d3"
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
    Private m_Utils As Zipper_Utilities = Nothing

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()

        ' TODO: Define values for the public properties
        ' TODO: Define values for the public properties
        MyBase.m_category = "SanGIS"  'localizable text 
        MyBase.m_caption = "Zipper Tool"   'localizable text 
        MyBase.m_message = "Zipper Tool"   'localizable text 
        MyBase.m_toolTip = "Zip features together" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_All_ZipperTask"  'unique id, non-localizable (e.g. "MyCategory_ArcMapTool")

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
        m_application = TryCast(hook, IApplication)

        'get the editor
        Dim editorUid As New UID()
        editorUid.Value = "esriEditor.Editor"
        m_editor = TryCast(m_application.FindExtensionByCLSID(editorUid), IEditor3)
        m_editEvents = TryCast(m_editor, IEditEvents_Event)
        m_editEvents5 = TryCast(m_editor, IEditEvents5_Event)

        'Initialize the Utilities class for doing all the work
        m_Utils = New Zipper_Utilities()
        m_Utils.Distance = 5
        m_Utils.SelColl = New Collection
    End Sub

    Public Overrides ReadOnly Property Enabled() As Boolean
        Get
            Try
                'Enable the tool while editing
                Return m_editor.EditState = esriEditState.esriStateEditing
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property

    Public Overrides Sub OnClick()
        m_edSketch = TryCast(m_editor, IEditSketch3)

        'Activate a shape constructor based on the current sketch geometry
        'Sketch geometry can be set by either the user selecting a template or the developer setting a current layer
        ' and/or sketch geometry
        m_edSketch.GeometryType = esriGeometryType.esriGeometryPolyline

        m_csc = New StraightConstructorClass()
        m_csc.Initialize(m_editor)
        m_edSketch.ShapeConstructor = m_csc
        m_csc.Activate()

        'set the current task to null
        m_editor.CurrentTask = Nothing

        'setup events
        AddHandler m_editEvents.OnSketchModified, AddressOf m_editEvents_OnSketchModified
        AddHandler m_editEvents5.OnShapeConstructorChanged, AddressOf m_editEvents5_OnShapeConstructorChanged
        AddHandler m_editEvents.OnSketchFinished, AddressOf m_editEvents_OnSketchFinished
    End Sub

  

#Region "Other Events"

    Private Sub m_editEvents_OnSketchFinished()
        'send a shift-tab to hide the construction toolbar
        OnKeyDown(9, 1)

        'call developer code
        m_Utils.ZipFeatureGeometries(m_edSketch)
    End Sub

    Private Sub m_editEvents_OnSketchModified()
        m_csc.SketchModified()
    End Sub

    Private Sub m_editEvents5_OnShapeConstructorChanged()
        'activate new constructor
        m_csc.Deactivate()
        m_csc = Nothing
        m_csc = m_edSketch.ShapeConstructor
        'error on stopping edit session with tool active, causes crash.  Handle where?
        If Not m_csc Is Nothing Then
            m_csc.Activate()
        End If
    End Sub
#End Region

#Region "ISketchTool Members - Pass to shape constructor"
    'pass to constructor
    Public Sub AddPoint(ByVal point As IPoint, ByVal Clone As Boolean, ByVal allowUndo As Boolean) Implements ISketchTool.AddPoint
        m_csc.AddPoint(point, Clone, allowUndo)
    End Sub

    Public ReadOnly Property Anchor() As IPoint Implements ISketchTool.Anchor
        Get
            Return m_csc.Anchor
        End Get
    End Property

    Public Property AngleConstraint() As Double Implements ISketchTool.AngleConstraint
        Get
            Return m_csc.AngleConstraint
        End Get
        Set(ByVal value As Double)
            m_csc.AngleConstraint = value
        End Set
    End Property

    Public Property Constraint() As esriSketchConstraint Implements ISketchTool.Constraint
        Get
            Return m_csc.Constraint
        End Get
        Set(ByVal value As esriSketchConstraint)
            m_csc.Constraint = value
        End Set
    End Property

    Public Property DistanceConstraint() As Double Implements ISketchTool.DistanceConstraint
        Get
            Return m_csc.DistanceConstraint
        End Get
        Set(ByVal value As Double)
            m_csc.DistanceConstraint = value
        End Set
    End Property

    Public Property IsStreaming() As Boolean Implements ISketchTool.IsStreaming
        Get
            Return m_csc.IsStreaming
        End Get
        Set(ByVal value As Boolean)
            m_csc.IsStreaming = value
        End Set
    End Property

    Public ReadOnly Property Location() As IPoint Implements ISketchTool.Location
        Get
            Return m_csc.Location
        End Get
    End Property

#End Region


#Region "ITool Members - Pass to shape constructor"
    'pass to constructor
    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        m_csc.OnMouseDown(Button, Shift, X, Y)
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        m_csc.OnMouseMove(Button, Shift, X, Y)
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        m_csc.OnMouseUp(Button, Shift, X, Y)
    End Sub

    Public Overrides Function OnContextMenu(ByVal X As Integer, ByVal Y As Integer) As Boolean
        Return m_csc.OnContextMenu(X, Y)
    End Function

    Public Overrides Sub OnKeyDown(ByVal keyCode As Integer, ByVal Shift As Integer)
        m_csc.OnKeyDown(keyCode, Shift)
    End Sub

    Public Overrides Sub OnKeyUp(ByVal keyCode As Integer, ByVal Shift As Integer)
        m_csc.OnKeyUp(keyCode, Shift)
    End Sub

    Public Overrides Sub Refresh(ByVal hDC As Integer)
        m_csc.Refresh(hDC)
    End Sub

    Public Overrides ReadOnly Property Cursor() As Integer
        Get
            Return m_csc.Cursor
        End Get
    End Property

    Public Overrides Sub OnDblClick()
        If Control.ModifierKeys = Keys.Shift Then
            Dim pso As ISketchOperation = New SketchOperation()
            pso.MenuString_2 = "Finish Sketch Part"
            pso.Start(m_editor)
            m_edSketch.FinishSketchPart()
            pso.Finish(Nothing)
        Else
            m_edSketch.FinishSketch()
        End If
    End Sub

    Public Overrides Function Deactivate() As Boolean
        'unsubscribe events
        RemoveHandler m_editEvents.OnSketchModified, AddressOf m_editEvents_OnSketchModified
        RemoveHandler m_editEvents5.OnShapeConstructorChanged, AddressOf m_editEvents5_OnShapeConstructorChanged
        RemoveHandler m_editEvents.OnSketchFinished, AddressOf m_editEvents_OnSketchFinished
        Return MyBase.Deactivate()
    End Function

#End Region
   
End Class

