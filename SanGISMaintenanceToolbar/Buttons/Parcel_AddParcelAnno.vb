Imports System.Runtime.InteropServices
Imports System.Drawing
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Controls
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Editor
Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Display
Imports ESRI.ArcGIS.esriSystem

<ComClass(Parcel_AddParcelAnno.ClassId, Parcel_AddParcelAnno.InterfaceId, Parcel_AddParcelAnno.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Parcel_AddParcelAnno")> _
Public NotInheritable Class Parcel_AddParcelAnno
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "05adbdfa-ae91-4d7c-8540-d703f5981cdd"
    Public Const InterfaceId As String = "c3abe609-6680-437c-9788-0f40c9de9b48"
    Public Const EventsId As String = "b6fcdd0f-3a9e-4258-8bcf-ce23cb595305"
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
        MyBase.m_caption = "Parcel APN"   'localizable text 
        MyBase.m_message = "Add Parcel APN Anno"   'localizable text 
        MyBase.m_toolTip = "Add Parcel APN Anno" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Parcel_AddParcelAnno"  'unique id, non-localizable (e.g. "MyCategory_ArcMapTool")

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
            Dim pFWorkspace As IFeatureWorkspace
            Dim pFeatClass As IFeatureClass
            Dim pMouseCursor As MouseCursor
            Dim pEnvelope As IEnvelope
            Dim pRefEnvelope As IEnvelope
            Dim pRelClass As IRelationshipClass
            Dim pSett As ISet
            Dim pObj As IObject
            pFCursor = Nothing
            m_application.CurrentTool = Nothing

            pMouseCursor = New MouseCursor
            pMouseCursor.SetCursor(2)
            pMXDoc = m_application.Document


            'pTextSymbol = New ESRI.ArcGIS.Display.TextSymbol
            'With pTextSymbol
            '    .Size = 38.88
            '    .Angle = 0
            '    .HorizontalAlignment = esriTextHorizontalAlignment.esriTHALeft
            '    .VerticalAlignment = esriTextVerticalAlignment.esriTVABaseline
            'End With

            pFLayer = GetLayerByName(pMXDoc, PARCEL_DATASRC)


            If pFLayer Is Nothing Then
                MsgBox("Parcel layer not found. Please add it to the map before trying to annotate parcels")
                Exit Sub
            End If

            pFeatureSel = pFLayer 'QI
            pFWorkspace = pFLayer.FeatureClass.FeatureDataset.Workspace
            'Get the anno featureclass from workspace
            pFeatClass = pFWorkspace.OpenFeatureClass(Anno_APN_DATASRC)
            'get a set of the selected objects. If no parcels selected exit sub
            pSelSet = pFeatureSel.SelectionSet
            If pSelSet.Count = 0 Then
                MsgBox("No Parcels Selected", vbExclamation, "Add Parcel APN Anno")
                Exit Sub
            End If
            'Get the Relationship class for the APN
            pRelClass = pFWorkspace.OpenRelationshipClass("T.Rel_ParcelHasAPN")


            'Start editing
            m_pEditor.StartOperation()
            pSelSet.Search(Nothing, True, pFCursor)
            'Loop through the set getting each selected addresses related address number value
            pFeature = pFCursor.NextFeature
            Do Until pFeature Is Nothing

                If pFeature.Value(pFeature.Fields.FindField(PARCEL_PARCEL_TYPE_FLD_NAME)) = 1 Then
                    pSett = pRelClass.GetObjectsRelatedToObject(pFeature)
                    pObj = pSett.Next   'the related APN_ATR record

                    pFeature2 = pFeatClass.CreateFeature     'create a new annotation feature
                    pAnnoFeat = pFeature2
                    pTextElement = New TextElement
                    'Create a new text element for each new annotation feqature and give its text value the APN value of the APN_ATR record
                    With pTextElement
                        .ScaleText = False
                        '.Symbol = pTextSymbol
                        .Text = Mid(pObj.Value(pObj.Fields.FindField(PAR_ANNO_APN_FLD_NAME)), 1, 8)
                    End With

                    Dim pGroupSymbolElement As IGroupSymbolElement
                    pGroupSymbolElement = pTextElement
                    pGroupSymbolElement.SymbolID = 0
                    pGroupSymbolElement.Size = 38.88
                    pGroupSymbolElement.VerticalAlignment = esriTextVerticalAlignment.esriTVABaseline
                    pGroupSymbolElement.HorizontalAlignment = esriTextHorizontalAlignment.esriTHACenter


                    pEnvelope = pFeature.Shape.Envelope
                    Dim pArea As IArea
                    pArea = pFeature.ShapeCopy
                    pPoint = New ESRI.ArcGIS.Geometry.Point

                    pPoint.X = pArea.LabelPoint.X
                    pPoint.Y = pArea.LabelPoint.Y

                    'Set the Anno geometry the same os the selected parcel
                    pElement = pGroupSymbolElement 'pTextElement
                    pElement.Geometry = pPoint
                    pAnnoFeat.Annotation = pElement
                    'pFeature2.value(pFeature2.Fields.FindField(PAR_ANNO_PARCELID_FLD_NAME)) = pFeature.value(pFeature.Fields.FindField(PARCEL_PARCELID_FLD_NAME)) ' save the parcelid as an attribute, may eventually allow featurelinked
                    pFeature2.Store()
                    pRefEnvelope = pEnvelope
                    pRefEnvelope.XMin = pEnvelope.XMin - 100
                    pRefEnvelope.YMin = pEnvelope.YMin - 100
                    pRefEnvelope.XMax = pEnvelope.XMax + 100
                    pRefEnvelope.YMax = pEnvelope.YMax + 100
                    'MsgBox (pRefEnvelope.XMin & " , " & pRefEnvelope.XMax & " , " & pRefEnvelope.YMin & " , " & pRefEnvelope.YMax)
                    pMXDoc.ActiveView.PartialRefresh(6, Nothing, pRefEnvelope)
                End If

                pFeature = pFCursor.NextFeature

            Loop

            m_pEditor.StopOperation("CreateAnno")

        Catch ex As Exception
            m_application.CurrentTool = Nothing
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try

    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Parcel_AddParcelAnno.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Parcel_AddParcelAnno.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Parcel_AddParcelAnno.OnMouseUp implementation
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
                        Dim pFlayer As IFeatureLayer
                        Dim pFsel As IFeatureSelection
                        pFlayer = GetLayerByName(m_pMXDoc, PARCEL_DATASRC)
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

