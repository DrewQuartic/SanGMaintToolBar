Imports System.Runtime.InteropServices
Imports System.Drawing
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.ArcMapUI
Imports System.Windows.Forms
Imports ESRI.ArcGIS.Controls
Imports ESRI.ArcGIS.Editor
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Display
Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.esriSystem

<ComClass(MapNum_AddAnno.ClassId, MapNum_AddAnno.InterfaceId, MapNum_AddAnno.EventsId), _
 ProgId("SanGISMaintenanceToolbar.MapNum_AddAnno")> _
Public NotInheritable Class MapNum_AddAnno
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "9ee40872-70be-4606-b979-09a6f355cd26"
    Public Const InterfaceId As String = "7eddb088-e52b-4c3a-b8b7-e2256bb02668"
    Public Const EventsId As String = "d6624b1c-cbf0-4561-ab63-fec90e1e5771"
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
        MyBase.m_caption = "MapNum"   'localizable text 
        MyBase.m_message = "Add MapNum Anno"   'localizable text 
        MyBase.m_toolTip = "Add MapNum Anno" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_MapNum_AddAnno"  'unique id, non-localizable (e.g. "MyCategory_ArcMapTool")

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
        'TODO: Add MapNum_AddAnno.OnClick implementation
    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        Try

            Dim pMXDoc As IMxDocument
            Dim pFLayer As IFeatureLayer
            Dim pPoint As IPoint
            Dim pFeature2 As IFeature
            Dim pAnnoFeat As IAnnotationFeature
            Dim pElement As IElement
            Dim pTextElement As ITextElement
            Dim pFWorkspace As IFeatureWorkspace
            Dim pFeatClass As IFeatureClass
            Dim pMouseCursor As MouseCursor
            Dim pEnvelope As IEnvelope
            Dim pRefEnvelope As IEnvelope
            m_application.CurrentTool = Nothing

            pMouseCursor = New MouseCursor
            pMouseCursor.SetCursor(2)
            pMXDoc = m_application.Document

            '-get the point (in map units) that was clicked
            Dim pLocalPoint As IPoint
            pLocalPoint = New ESRI.ArcGIS.Geometry.Point
            pLocalPoint = m_pMXDoc.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y) 'x/y are in pixels
            Dim pScreenPoint As System.Drawing.Point
            'pScreenPoint = New ESRI.ArcGIS.Geometry.Point
            pScreenPoint = System.Windows.Forms.Cursor.Position
            'popup text dialog at that point
            Dim txtinput As String = ""
            Dim ipBox As New CustInputBox
            If ipBox.ShowDialog("Enter MapNum", "MapNum: ", "", txtinput, False, pScreenPoint) = Windows.Forms.DialogResult.Cancel Then
                ' Cancel Pressed
                Exit Sub
            End If



            '------------------------------------------------------
            'find any layer to get the workspace
            pFLayer = GetLayerByName(pMXDoc, PARCEL_DATASRC)
            If pFLayer Is Nothing Then
                MsgBox("Parcel layer not found. Please add it to the map before trying to annotate mapnum")
                Exit Sub
            End If
            pFWorkspace = pFLayer.FeatureClass.FeatureDataset.Workspace
            '------------------------------------------
            'Get the anno featureclass from workspace
            pFeatClass = pFWorkspace.OpenFeatureClass(Anno_MAPNO_DATASRC)

            'Start editing
            m_pEditor.StartOperation()
            'Loop through the set getting each selected addresses related address number value

            pFeature2 = pFeatClass.CreateFeature     'create a new annotation feature
            pAnnoFeat = pFeature2
            pTextElement = New TextElement
            'Create a new text element for each new annotation feqature and give its text value the APN value of the APN_ATR record
            With pTextElement
                .ScaleText = False
                '.Symbol = pTextSymbol
                .Text = txtinput
            End With

            Dim pGroupSymbolElement As IGroupSymbolElement
            pGroupSymbolElement = pTextElement
            pGroupSymbolElement.SymbolID = 0
            pGroupSymbolElement.Size = 58.32
            pGroupSymbolElement.VerticalAlignment = esriTextVerticalAlignment.esriTVABaseline
            pGroupSymbolElement.HorizontalAlignment = esriTextHorizontalAlignment.esriTHALeft



            pPoint = New ESRI.ArcGIS.Geometry.Point
            pPoint.X = pLocalPoint.X
            pPoint.Y = pLocalPoint.Y

            'Set the Anno geometry the same as the click
            pElement = pGroupSymbolElement 'pTextElement
            pElement.Geometry = pPoint
            pAnnoFeat.Annotation = pElement
            pFeature2.Store()

            pEnvelope = pPoint.Envelope
            pEnvelope.Expand(100, 100, False)
            pRefEnvelope = pEnvelope
            pRefEnvelope.XMin = pEnvelope.XMin - 100
            pRefEnvelope.YMin = pEnvelope.YMin - 100
            pRefEnvelope.XMax = pEnvelope.XMax + 100
            pRefEnvelope.YMax = pEnvelope.YMax + 100
            'MsgBox (pRefEnvelope.XMin & " , " & pRefEnvelope.XMax & " , " & pRefEnvelope.YMin & " , " & pRefEnvelope.YMax)
            pMXDoc.ActiveView.PartialRefresh(6, Nothing, pRefEnvelope)

            m_pEditor.StopOperation("CreateAnno")

        Catch ex As Exception
            m_application.CurrentTool = Nothing
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add MapNum_AddAnno.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add MapNum_AddAnno.OnMouseUp implementation
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
                    If CheckForLayer(PARCEL_DATASRC, CrntActiveView) Then
                        Return True
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

