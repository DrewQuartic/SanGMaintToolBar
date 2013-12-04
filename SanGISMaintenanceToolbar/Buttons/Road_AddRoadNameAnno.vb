Imports System.Runtime.InteropServices
Imports System.Drawing
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.ArcMapUI
Imports System.Windows.Forms

Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Controls
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Editor
Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.Display
Imports ESRI.ArcGIS.esriSystem

<ComClass(Road_AddRoadNameAnno.ClassId, Road_AddRoadNameAnno.InterfaceId, Road_AddRoadNameAnno.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Road_AddRoadNameAnno")> _
Public NotInheritable Class Road_AddRoadNameAnno
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "b86ecee2-be32-4039-9343-b6343b559568"
    Public Const InterfaceId As String = "ae068f85-4014-47d2-b88c-e7f77186313a"
    Public Const EventsId As String = "1f6505de-6471-4c92-92c1-7dcee4e6b7c8"
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
        MyBase.m_caption = "Road Name"   'localizable text 
        MyBase.m_message = "Add Road Name Anno"   'localizable text 
        MyBase.m_toolTip = "Add Road Name Anno" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Road_AddRoadNameAnno"  'unique id, non-localizable (e.g. "MyCategory_MyCommand")

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

            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor

            Dim pFLayer As IFeatureLayer
            Dim pPoint As IPoint
            Dim pFCursor As IFeatureCursor
            Dim pSelSet As ISelectionSet
            Dim pFeatureSel As IFeatureSelection
            Dim pFeature As IFeature
            Dim pFeature2 As IFeature
            Dim pAnnoFeat As IAnnotationFeature
            Dim pElement As IElement
            Dim pTextElement As ITextElement
            Dim pTextSymbol As ITextSymbol
            Dim pFWorkspace As IFeatureWorkspace
            Dim pRelClass As IRelationshipClass
            Dim pSett As ISet
            Dim pObj As IObject
            Dim pFeatClass As IFeatureClass
            Dim pEnvelope As IEnvelope
            Dim pRefEnvelope As IEnvelope
            Dim ConcRDNM As String
            Dim pLine As ILine
            Dim pFrmPnt As IPoint
            Dim pToPnt As IPoint
            pFCursor = Nothing
            m_pMXDoc = m_application.Document

            pTextSymbol = New ESRI.ArcGIS.Display.TextSymbol
            With pTextSymbol
                .Size = 56
                .Angle = 0
            End With

            pFLayer = GetLayerByName(m_pMXDoc, ROAD_DATASRC)

            If pFLayer Is Nothing Then
                MsgBox("Road layer not found. Please add it to the map before trying to annotate Roads")
                Exit Sub
            End If

            pFeatureSel = pFLayer 'QI
            pFWorkspace = pFLayer.FeatureClass.FeatureDataset.Workspace
            pRelClass = pFWorkspace.OpenRelationshipClass("T.Rel_ROADSEGHASNAME")
            'Get the anno featureclass from workspace
            pFeatClass = pFWorkspace.OpenFeatureClass(Anno_Road_DATASRC)
            'get a set of the selected objects. If no parcels selected exit sub
            pSelSet = pFeatureSel.SelectionSet
            If pSelSet.Count = 0 Then
                MsgBox("No Road Selected", vbExclamation, "Add RoadName Anno")
                Exit Sub
            End If

            'Start editing
            m_pEditor.StartOperation()
            pSelSet.Search(Nothing, True, pFCursor)
            'Loop through the set getting each selected addresses related address number value
            pFeature = pFCursor.NextFeature
            Dim RdNmTxt As String
            Dim RdPreTxt As String
            Dim RdSufTxt As String
            Do Until pFeature Is Nothing
                RdNmTxt = ""
                RdPreTxt = ""
                RdSufTxt = ""
                ConcRDNM = ""
                pSett = pRelClass.GetObjectsRelatedToObject(pFeature)
                pObj = pSett.Next   'the related  record
                If pObj.Value(pObj.Fields.FindField(ROADNM_NAME_FLD_NAME)) Is System.DBNull.Value Then
                    RdNmTxt = ""
                Else
                    RdNmTxt = pObj.Value(pObj.Fields.FindField(ROADNM_NAME_FLD_NAME))
                End If
                If pObj.Value(pObj.Fields.FindField(ROADNM_PREDIR_FLD_NAME)) Is System.DBNull.Value Then
                    RdPreTxt = ""
                Else
                    RdPreTxt = pObj.Value(pObj.Fields.FindField(ROADNM_PREDIR_FLD_NAME))
                End If
                If pObj.Value(pObj.Fields.FindField(ROADNM_SUFFIX_FLD_NAME)) Is System.DBNull.Value Then
                    RdSufTxt = ""
                Else
                    RdSufTxt = pObj.Value(pObj.Fields.FindField(ROADNM_SUFFIX_FLD_NAME))
                End If

                If Not (RdNmTxt = "" Or RdNmTxt = " ") Then
                    If Not (RdPreTxt = "" Or RdPreTxt = " ") Then
                        ConcRDNM = ConcRDNM & RdPreTxt & " "
                    End If

                    ConcRDNM = ConcRDNM & RdNmTxt

                    If Not (RdSufTxt = "" Or RdSufTxt = " ") Then
                        ConcRDNM = ConcRDNM & " " & RdSufTxt
                    End If

                    'MsgBox ConcRDNM
                    pFeature2 = pFeatClass.CreateFeature     'create a new annotation feature
                    pAnnoFeat = pFeature2
                    pTextElement = New TextElement
                    'Create a new text element for each new annotation feqature and give its text value the RoadName value of the road name record
                    With pTextElement
                        .ScaleText = False
                        .Symbol = pTextSymbol
                        .Text = ConcRDNM
                    End With

                    Dim pGroupSymbolElement As IGroupSymbolElement
                    pGroupSymbolElement = pTextElement
                    pGroupSymbolElement.SymbolID = 0
                    pGroupSymbolElement.Size = 56

                    pEnvelope = pFeature.Shape.Envelope
                    pPoint = New ESRI.ArcGIS.Geometry.Point
                    pFrmPnt = New ESRI.ArcGIS.Geometry.Point
                    pToPnt = New ESRI.ArcGIS.Geometry.Point
                    pLine = New ESRI.ArcGIS.Geometry.Line

                    pPoint.X = ((pEnvelope.XMin + pEnvelope.XMax) \ 2 + 10)
                    pPoint.Y = ((pEnvelope.YMin + pEnvelope.YMax) \ 2 - 10)
                    pFrmPnt.X = pEnvelope.XMin
                    pFrmPnt.Y = pEnvelope.YMin
                    pToPnt.X = pEnvelope.XMax
                    pToPnt.Y = pEnvelope.YMax

                    pLine.FromPoint = pFrmPnt
                    pLine.ToPoint = pToPnt

                    'Set the Anno geometry the same os the selected road, and angle
                    Dim pT2D As ITransform2D 'added
                    pElement = pGroupSymbolElement 'pTextElement
                    pElement.Geometry = pPoint
                    pT2D = pElement ' added
                    pT2D.Rotate(pPoint, pLine.Angle)
                    pAnnoFeat.Annotation = pElement
                    pFeature2.Store()
                    pRefEnvelope = pEnvelope
                    pRefEnvelope.XMin = pEnvelope.XMin - 100
                    pRefEnvelope.YMin = pEnvelope.YMin - 100
                    pRefEnvelope.XMax = pEnvelope.XMax + 100
                    pRefEnvelope.YMax = pEnvelope.YMax + 100
                    m_pMXDoc.ActiveView.PartialRefresh(6, Nothing, pRefEnvelope)
                End If

                pFeature = pFCursor.NextFeature
            Loop

            m_pEditor.StopOperation("CreateAnno")
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_AddRoadNameAnno.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_AddRoadNameAnno.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_AddRoadNameAnno.OnMouseUp implementation
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

