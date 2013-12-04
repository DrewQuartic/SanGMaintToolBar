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

<ComClass(Address_AddAddressPoint.ClassId, Address_AddAddressPoint.InterfaceId, Address_AddAddressPoint.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Address_AddAddressPoint")> _
Public NotInheritable Class Address_AddAddressPoint
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "aae9951c-613d-44df-91be-f6b266a0d4e6"
    Public Const InterfaceId As String = "42f7edcc-f91a-4586-9e61-0308f3cde743"
    Public Const EventsId As String = "34e0e98e-aa2a-4e19-b266-b728ad870861"
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

    Private m_pFlayer As IFeatureLayer
    Private m_pLotFeatClass As IFeatureClass
    Private m_pFeatureLayer As IFeatureLayer
    Private m_pFeatWorkspace As IFeatureWorkspace


    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()

        ' TODO: Define values for the public properties
        ' TODO: Define values for the public properties
        MyBase.m_category = "SanGIS"  'localizable text 
        MyBase.m_caption = "Add Address Point"   'localizable text 
        MyBase.m_message = "Add Address Point"   'localizable text 
        MyBase.m_toolTip = "Add Address Point" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Address_AddAddressPoint"  'unique id, non-localizable (e.g. "MyCategory_ArcMapTool")

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
        Dim pFeatSel As IFeatureSelection
        Dim pSelSet As ISelectionSet
        Dim pMXDoc As IMxDocument
        Dim pFLayer As IFeatureLayer

        pMXDoc = m_application.Document
        pFLayer = GetLayerByName(pMXDoc, ROAD_DATASRC)
        '-complain if the Roads layer was not found in the map
        If pFLayer Is Nothing Then
            MsgBox("Error: the roads layer was not located in the map (" & ROAD_DATASRC & ").", vbCritical, "Check Address Overlap")
            Exit Sub
        End If
        pFeatSel = pFLayer   'QI
        pSelSet = pFeatSel.SelectionSet

        If pSelSet.Count > 1 Then
            MsgBox("More than 1 Road segment is selected. Please only select one")
            m_application.CurrentTool = Nothing
            Exit Sub
        End If


    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)

        Dim pAddressPoint As IPoint
        Dim pMXDoc As IMxDocument
        Dim pFLayer As IFeatureLayer
        Dim pFeatClass As IFeatureClass
        Dim pFeature As IFeature
        Dim pEnvelope As IEnvelope

        Try
            pMXDoc = m_application.Document

            pAddressPoint = pMXDoc.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y)  'x/y are in pixels
            pFLayer = GetLayerByName(pMXDoc, ADDRESS_DATASRC)

            pFeatClass = pFLayer.FeatureClass
            m_pEditor.StartOperation()
            pFeature = pFeatClass.CreateFeature
            pFeature.Shape = pAddressPoint

            If pFeature.HasOID Then


                pFeature.Store()

                'Add Address Anno after address add
                Dim pFWorkspace As IFeatureWorkspace
                Dim pAFeatClass As IFeatureClass
                Dim pFeature2 As IFeature
                Dim pAnnoFeat As IAnnotationFeature
                Dim pElement As IElement
                Dim pTextElement As ITextElement
                Dim pTextSymbol As ITextSymbol
                Dim pPoint As IPoint
                Dim pRefEnvelope As IEnvelope

                pTextSymbol = New ESRI.ArcGIS.Display.TextSymbol
                With pTextSymbol
                    .Size = 34.56
                    .Angle = 0
                End With
                pFWorkspace = pFLayer.FeatureClass.FeatureDataset.Workspace
                'Get the anno featureclass from workspace
                pAFeatClass = pFWorkspace.OpenFeatureClass(Anno_Address_DATASRC)

                If Not pFeature Is Nothing Then
                    Dim pAddrNoChk As String
                    pAddrNoChk = pFeature.Value(pFeature.Fields.FindField(ADDR_ADDRNO_FLD_NAME))
                    If Not pAddrNoChk = "" Then

                        pFeature2 = pAFeatClass.CreateFeature     'create a new annotation feature
                        pAnnoFeat = pFeature2
                        pTextElement = New TextElement
                        'Create a new text element for each new annotation feqature and give its text value the APN value of the APN_ATR record
                        With pTextElement
                            .ScaleText = False
                            .Symbol = pTextSymbol
                            .Text = pFeature.Value(pFeature.Fields.FindField(ADDR_ADDRNO_FLD_NAME))
                        End With

                        pEnvelope = pFeature.Shape.Envelope
                        pPoint = New ESRI.ArcGIS.Geometry.Point

                        pPoint.X = ((pEnvelope.XMin + pEnvelope.XMax) \ 2)
                        pPoint.Y = (((pEnvelope.YMin + pEnvelope.YMax) \ 2) - 20)

                        'Set the Anno geometry the same os the selected parcel
                        pElement = pTextElement
                        pElement.Geometry = pPoint
                        pAnnoFeat.Annotation = pElement
                        pFeature2.Store()
                        pRefEnvelope = pEnvelope
                        pRefEnvelope.XMin = pEnvelope.XMin - 100
                        pRefEnvelope.YMin = pEnvelope.YMin - 100
                        pRefEnvelope.XMax = pEnvelope.XMax + 100
                        pRefEnvelope.YMax = pEnvelope.YMax + 100
                        pMXDoc.ActiveView.PartialRefresh(6, Nothing, pRefEnvelope)
                    End If
                End If
            End If
            m_pEditor.StopOperation("Add Address Point")
            m_application.CurrentTool = Nothing

        Catch ex As Exception
            m_pEditor.StopOperation("Add Address Point")
            m_application.CurrentTool = Nothing
            Throw New InvalidOperationException("Add Addr Cancelled, and Add Pnt")
            'Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            'Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Address_AddAddressPoint.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Address_AddAddressPoint.OnMouseUp implementation
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
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property

End Class

