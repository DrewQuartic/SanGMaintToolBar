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

<ComClass(Lot_LotIDIncrementer.ClassId, Lot_LotIDIncrementer.InterfaceId, Lot_LotIDIncrementer.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Lot_LotIDIncrementer")> _
Public NotInheritable Class Lot_LotIDIncrementer
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "b16f5310-112f-40a5-aebc-d1a4c13a2acf"
    Public Const InterfaceId As String = "4c4a4e40-867b-4c50-9cd6-d23974d93ee1"
    Public Const EventsId As String = "780a5411-de5d-494b-b84b-f323a0d4eb12"
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
        MyBase.m_caption = "Assign New LotID"   'localizable text 
        MyBase.m_message = "Assign New LotID"   'localizable text 
        MyBase.m_toolTip = "Assign New LotID" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Lot_LotIDIncrementer"  'unique id, non-localizable (e.g. "MyCategory_ArcMapTool")

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
        If Not hook Is Nothing Then
            m_application = CType(hook, IApplication)

            'Disable if it is not ArcMap
            If TypeOf hook Is IMxApplication Then
                MyBase.m_enabled = True
            Else
                MyBase.m_enabled = False
            End If
        End If

        ' TODO:  Add other initialization code
    End Sub

    Public Overrides Sub OnClick()
        Try
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Lot_LotIDIncrementer.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Lot_LotIDIncrementer.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)

        Try
            Dim pClickPoint As IPoint
            Dim pSF As ISpatialFilter
            Dim pFeatureCursor As IFeatureCursor
            Dim pFClass As IFeatureClass
            Dim pFeature As IFeature
            Dim pFLayer As IFeatureLayer
            pClickPoint = m_pMXDoc.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y)
            pSF = New SpatialFilter
            With pSF
                .Geometry = pClickPoint.Envelope
                .GeometryField = "Shape"
                .SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects
            End With

            pFLayer = GetLayerByName(m_pMXDoc, LOT_DATASRC)

            If pFLayer Is Nothing Then
                MsgBox("Lot layer not present, please add it before proceeding")
                Exit Sub
            End If

            'get the lot that was clicked on by using a spatial filter
            pFClass = pFLayer.FeatureClass
            pFeatureCursor = pFClass.Search(pSF, False)
            pFeature = pFeatureCursor.NextFeature()
            m_pEditor.StartOperation()
            pFeature.Value(pFeature.Fields.FindField(LOT_LOTID_FLD_NAME)) = GetSequenceNumber(pFClass.FeatureDataset.Workspace, "", "T.LOT_SEQ")
            pFeature.Store()
            FlashIt(m_pMXDoc, pFLayer, pFeature.Shape, pFeature.OID)
            m_pEditor.StopOperation("Increment LotID")

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try

    End Sub

    Public Overrides ReadOnly Property Enabled() As Boolean
        Get
            Try
                Dim CrntActiveView As IActiveView
                m_pMXDoc = m_application.Document
                CrntActiveView = m_pMXDoc.ActivatedView
                'Disable if not editing
                m_pEditor = m_application.FindExtensionByName("ESRI Object Editor")
                If m_pEditor.EditState = esriEditState.esriStateEditing Then
                    'Disable if no lot layer
                    If CheckForLayer(LOT_DATASRC, CrntActiveView) Then
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

