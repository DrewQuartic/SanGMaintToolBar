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

<ComClass(Address_AddAddressAnno.ClassId, Address_AddAddressAnno.InterfaceId, Address_AddAddressAnno.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Address_AddAddressAnno")> _
Public NotInheritable Class Address_AddAddressAnno
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "563ec75c-35cc-49b5-ac73-80207f15e16f"
    Public Const InterfaceId As String = "1b30f922-b56a-4c6c-a00f-da47d85275b0"
    Public Const EventsId As String = "2403fd58-0522-4317-92d1-a598b85bc9f0"
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
        MyBase.m_caption = "Address"   'localizable text 
        MyBase.m_message = "Add Anno to Existing Address Point"   'localizable text 
        MyBase.m_toolTip = "Add Anno to Existing Address Point" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Address_AddAddressAnno"  'unique id, non-localizable (e.g. "MyCategory_ArcMapTool")

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
        Try
            pFCursor = Nothing

            m_application.CurrentTool = Nothing

            pMouseCursor = New MouseCursor
            pMouseCursor.SetCursor(2)
            pMXDoc = m_application.Document

            pTextSymbol = New ESRI.ArcGIS.Display.TextSymbol
            With pTextSymbol
                .Size = 34.56
                .Angle = 0
            End With

            pFLayer = GetLayerByName(pMXDoc, ADDRESS_DATASRC)

            If pFLayer Is Nothing Then
                MsgBox("AddressPoint layer not found. Please add it to the map before trying to annotate addresses")
                Exit Sub
            End If

            pFeatureSel = pFLayer 'QI
            pFWorkspace = pFLayer.FeatureClass.FeatureDataset.Workspace
            'Get the anno featureclass from workspace
            pFeatClass = pFWorkspace.OpenFeatureClass(Anno_Address_DATASRC)
            'get a set of the selected objects. If no parcels selected exit sub
            pSelSet = pFeatureSel.SelectionSet
            If pSelSet.Count = 0 Then
                MsgBox("No Addresses Selected", vbExclamation, "Add Address Anno")
                Exit Sub
            End If

            'Start editing
            m_pEditor.StartOperation()
            pSelSet.Search(Nothing, True, pFCursor)
            'Loop through the set getting each selected addresses related address number value
            pFeature = pFCursor.NextFeature
            Do Until pFeature Is Nothing
                Dim pAddrNoChk As String
                pAddrNoChk = pFeature.Value(pFeature.Fields.FindField(ADDR_ADDRNO_FLD_NAME))
                If Not pAddrNoChk = "" Then
                    pFeature2 = pFeatClass.CreateFeature     'create a new annotation feature
                    pAnnoFeat = pFeature2
                    pTextElement = New TextElement
                    'Create a new text element for each new annotation feqature and give its text value the APN value of the APN_ATR record
                    With pTextElement
                        .ScaleText = False
                        .Symbol = pTextSymbol
                        .Text = pFeature.Value(pFeature.Fields.FindField(ADDR_ADDRNO_FLD_NAME))
                    End With

                    Dim pGroupSymbolElement As IGroupSymbolElement
                    pGroupSymbolElement = pTextElement
                    pGroupSymbolElement.SymbolID = 0
                    pGroupSymbolElement.Size = 34.56


                    pEnvelope = pFeature.Shape.Envelope
                    pPoint = New ESRI.ArcGIS.Geometry.Point

                    pPoint.X = ((pEnvelope.XMin + pEnvelope.XMax) \ 2)
                    pPoint.Y = (((pEnvelope.YMin + pEnvelope.YMax) \ 2) - 20)

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
            pFCursor = Nothing
        Catch ex As Exception
            pFCursor = Nothing
            m_application.CurrentTool = Nothing
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try

    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Address_AddAddressAnno.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Address_AddAddressAnno.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Address_AddAddressAnno.OnMouseUp implementation
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
                    If CheckForLayer(ADDRESS_DATASRC, CrntActiveView) Then
                        Dim pFlayer As IFeatureLayer
                        Dim pFsel As IFeatureSelection
                        pFlayer = GetLayerByName(m_pMXDoc, ADDRESS_DATASRC)
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

