Imports System.Runtime.InteropServices
Imports System.Drawing
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.ArcMapUI
Imports System.Windows.Forms
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Controls
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Editor
Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Display

<ComClass(Road_AddRoadBlockAnno.ClassId, Road_AddRoadBlockAnno.InterfaceId, Road_AddRoadBlockAnno.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Road_AddRoadBlockAnno")> _
Public NotInheritable Class Road_AddRoadBlockAnno
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "eec8b8fb-dcd6-43ca-9d18-4be90ad7e4c5"
    Public Const InterfaceId As String = "ea5b2b79-3dc7-4037-b213-97e77a515ac4"
    Public Const EventsId As String = "4c30466f-d8e7-4309-8150-84378464b6d4"
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
        MyBase.m_caption = "Add Road Block Anno"   'localizable text 
        MyBase.m_message = "Add Road Block Anno"   'localizable text 
        MyBase.m_toolTip = "Add Road Block Anno" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Road_AddRoadBlockAnno"  'unique id, non-localizable (e.g. "MyCategory_MyCommand")

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
        Dim pMXDoc As IMxDocument
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
        Dim pFeatClass As IFeatureClass
        Dim pMouseCursor As MouseCursor
        Dim pEnvelope As IEnvelope
        Dim pRefEnvelope As IEnvelope
        Dim ConcRDNM As String
        Dim pLine As ILine
        Dim pFrmPnt As IPoint
        Dim pToPnt As IPoint
        Dim pT2D As ITransform2D
        Dim pGeometry As IGeometry
        Dim pPolyLine As IPolyline
        Dim pLnAngle As Double
        Dim pLine2 As ILine
        Dim pLnAngle2 As Double
        Dim ROWDIS As Integer
        Dim pGroupSymbolElement As IGroupSymbolElement



        Try
            pFCursor = Nothing
            m_application.CurrentTool = Nothing

            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor


            pMouseCursor = New MouseCursor
            pMouseCursor.SetCursor(2)
            pMXDoc = m_application.Document

            pTextSymbol = New ESRI.ArcGIS.Display.TextSymbol
            With pTextSymbol
                .Size = 43.2
                .Angle = 0
            End With

            pFLayer = GetLayerByName(m_pMXDoc, ROAD_DATASRC)

            If pFLayer Is Nothing Then
                MsgBox("Road layer not found. Please add it to the map before trying to annotate Roads")
                Exit Sub
            End If

            pFeatureSel = pFLayer 'QI
            pFWorkspace = pFLayer.FeatureClass.FeatureDataset.Workspace
            'Get the anno featureclass from workspace
            pFeatClass = pFWorkspace.OpenFeatureClass(Anno_Block_DATASRC)
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

            Do Until pFeature Is Nothing
                pGeometry = pFeature.Shape
                pPolyLine = pGeometry

                pEnvelope = pFeature.Shape.Envelope
                pFrmPnt = New ESRI.ArcGIS.Geometry.Point
                pToPnt = New ESRI.ArcGIS.Geometry.Point
                pLine = New ESRI.ArcGIS.Geometry.Line
                pLine2 = New ESRI.ArcGIS.Geometry.Line
                pLine.FromPoint = pPolyLine.FromPoint
                pLine.ToPoint = pPolyLine.ToPoint
                'Give true radian angle to determine text and offsets
                pLnAngle = (180 - (pLine.Angle * 180) / 3.14159265358979)
                'Get Envelope angle to determin rotation of test (everything left/right bottom/top)
                pFrmPnt.x = pEnvelope.XMin
                pFrmPnt.y = pEnvelope.YMin
                pToPnt.x = pEnvelope.XMax
                pToPnt.y = pEnvelope.YMax
                pLine2.FromPoint = pFrmPnt
                pLine2.ToPoint = pToPnt
                pLnAngle2 = pLine2.Angle

                'Get the Right of Way Distance, or default to 50
                If Not IsDBNull(pFeature.Value(pFeature.Fields.FindField(RD_RIGHTWAY_FLD_NAME))) And IsNumeric(pFeature.Value(pFeature.Fields.FindField(RD_RIGHTWAY_FLD_NAME))) Then
                    If pFeature.Value(pFeature.Fields.FindField(RD_RIGHTWAY_FLD_NAME)) > 40 Then
                        ROWDIS = pFeature.Value(pFeature.Fields.FindField(RD_RIGHTWAY_FLD_NAME))
                    Else
                        ROWDIS = 50
                    End If
                Else
                    ROWDIS = 50
                End If
                'MsgBox ROWDIS
                'Build the LEFT LOW Block Range Anno
                If IsNumeric(pFeature.Value(pFeature.Fields.FindField(RD_LLOWADDR_FLD_NAME))) Then
                    ConcRDNM = ""

                    pFeature2 = pFeatClass.CreateFeature     'create a new annotation feature
                    pAnnoFeat = pFeature2
                    pTextElement = New TextElement
                    pPoint = New ESRI.ArcGIS.Geometry.Point
                    'East
                    If pLnAngle >= 135 And pLnAngle <= 225 Then
                        pPoint.X = ((pPolyLine.FromPoint.X) + 60)
                        pPoint.Y = ((pPolyLine.FromPoint.Y) + ROWDIS - 10)
                        ConcRDNM = pFeature.Value(pFeature.Fields.FindField(RD_LLOWADDR_FLD_NAME)) & ">"
                        'North
                    ElseIf pLnAngle > 45 And pLnAngle < 135 Then
                        pPoint.X = ((pPolyLine.FromPoint.X) - ROWDIS + 10)
                        pPoint.Y = ((pPolyLine.FromPoint.Y) + 60)
                        ConcRDNM = pFeature.Value(pFeature.Fields.FindField(RD_LLOWADDR_FLD_NAME)) & ">"
                        'West
                    ElseIf pLnAngle >= 315 Or pLnAngle <= 45 Then
                        pPoint.X = ((pPolyLine.FromPoint.X) - 60)
                        pPoint.Y = ((pPolyLine.FromPoint.Y) - ROWDIS)
                        ConcRDNM = "<" & pFeature.Value(pFeature.Fields.FindField(RD_LLOWADDR_FLD_NAME))
                        'South
                    ElseIf pLnAngle > 225 And pLnAngle < 315 Then
                        pPoint.X = ((pPolyLine.FromPoint.X) + ROWDIS - 5)
                        pPoint.Y = ((pPolyLine.FromPoint.Y) - 60)
                        ConcRDNM = "<" & pFeature.Value(pFeature.Fields.FindField(RD_LLOWADDR_FLD_NAME))
                    End If

                    'Create a new text element for each new annotation feqature and give its text value the APN value of the APN_ATR record
                    With pTextElement
                        .ScaleText = False
                        .Symbol = pTextSymbol
                        .Text = ConcRDNM
                    End With


                    pGroupSymbolElement = pTextElement
                    pGroupSymbolElement.SymbolID = 0
                    pGroupSymbolElement.Size = 43.2

                    'Set the Anno geometry the same os the selected road, and angle
                    pElement = pGroupSymbolElement 'pTextElement
                    pElement.Geometry = pPoint
                    pT2D = pElement ' added
                    pT2D.Rotate(pPoint, pLnAngle2)
                    pAnnoFeat.Annotation = pElement
                    pFeature2.Store()
                    pRefEnvelope = pEnvelope
                    pRefEnvelope.XMin = pEnvelope.XMin - 100
                    pRefEnvelope.YMin = pEnvelope.YMin - 100
                    pRefEnvelope.XMax = pEnvelope.XMax + 100
                    pRefEnvelope.YMax = pEnvelope.YMax + 100
                    'MsgBox (pRefEnvelope.XMin & " , " & pRefEnvelope.XMax & " , " & pRefEnvelope.YMin & " , " & pRefEnvelope.YMax)
                    pMXDoc.ActiveView.PartialRefresh(6, Nothing, pRefEnvelope)
                End If 'Left Block

                'Create the Right Low Address Range
                If IsNumeric(pFeature.Value(pFeature.Fields.FindField(RD_RLOWADDR_FLD_NAME))) Then
                    ConcRDNM = ""

                    pFeature2 = pFeatClass.CreateFeature     'create a new annotation feature
                    pAnnoFeat = pFeature2
                    pTextElement = New TextElement
                    pPoint = New ESRI.ArcGIS.Geometry.Point
                    'East
                    If pLnAngle >= 135 And pLnAngle <= 225 Then
                        pPoint.X = ((pPolyLine.FromPoint.X) + 60)
                        pPoint.Y = ((pPolyLine.FromPoint.Y) - ROWDIS)
                        ConcRDNM = pFeature.Value(pFeature.Fields.FindField(RD_RLOWADDR_FLD_NAME)) & ">"
                        'North
                    ElseIf pLnAngle > 45 And pLnAngle < 135 Then
                        pPoint.X = ((pPolyLine.FromPoint.X) + ROWDIS)
                        pPoint.Y = ((pPolyLine.FromPoint.Y) + 60)
                        ConcRDNM = pFeature.Value(pFeature.Fields.FindField(RD_RLOWADDR_FLD_NAME)) & ">"
                        'West
                    ElseIf pLnAngle >= 315 Or pLnAngle <= 45 Then
                        pPoint.X = ((pPolyLine.FromPoint.X) - 60)
                        pPoint.Y = ((pPolyLine.FromPoint.Y) + ROWDIS - 10)
                        ConcRDNM = "<" & pFeature.Value(pFeature.Fields.FindField(RD_RLOWADDR_FLD_NAME))
                        'South
                    ElseIf pLnAngle > 225 And pLnAngle < 315 Then
                        pPoint.X = ((pPolyLine.FromPoint.X) - ROWDIS + 5)
                        pPoint.Y = ((pPolyLine.FromPoint.Y) - 60)
                        ConcRDNM = "<" & pFeature.Value(pFeature.Fields.FindField(RD_RLOWADDR_FLD_NAME))
                    End If

                    'Create a new text element for each new annotation feqature and give its text value the APN value of the APN_ATR record
                    With pTextElement
                        .ScaleText = False
                        .Symbol = pTextSymbol
                        .Text = ConcRDNM
                    End With

                    pGroupSymbolElement = pTextElement
                    pGroupSymbolElement.SymbolID = 0
                    pGroupSymbolElement.Size = 43.2


                    'Set the Anno geometry the same os the selected road, and angle
                    pElement = pGroupSymbolElement 'pTextElement
                    pElement.Geometry = pPoint
                    pT2D = pElement ' added
                    pT2D.Rotate(pPoint, pLnAngle2)
                    pAnnoFeat.Annotation = pElement
                    pFeature2.Store()
                    pRefEnvelope = pEnvelope
                    pRefEnvelope.XMin = pEnvelope.XMin - 100
                    pRefEnvelope.YMin = pEnvelope.YMin - 100
                    pRefEnvelope.XMax = pEnvelope.XMax + 100
                    pRefEnvelope.YMax = pEnvelope.YMax + 100
                    'MsgBox (pRefEnvelope.XMin & " , " & pRefEnvelope.XMax & " , " & pRefEnvelope.YMin & " , " & pRefEnvelope.YMax)
                    pMXDoc.ActiveView.PartialRefresh(6, Nothing, pRefEnvelope)
                End If 'Right address

                pFeature = pFCursor.NextFeature
            Loop

            m_pEditor.StopOperation("CreateAnno")
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            pFCursor = Nothing
        Catch ex As Exception
            pFCursor = Nothing
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_AddRoadBlockAnno.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_AddRoadBlockAnno.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_AddRoadBlockAnno.OnMouseUp implementation
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

