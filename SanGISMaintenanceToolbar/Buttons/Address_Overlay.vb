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


<ComClass(Address_Overlay.ClassId, Address_Overlay.InterfaceId, Address_Overlay.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Address_Overlay")> _
Public NotInheritable Class Address_Overlay
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "720ac8e8-7d81-4795-9e78-86d9fd279d61"
    Public Const InterfaceId As String = "18407ea1-8bd9-4214-a31a-71a8735b5d9c"
    Public Const EventsId As String = "0e532ec5-3cd6-419e-800b-060268776b1c"
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
    Private m_hookHelper As IHookHelper
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
        MyBase.m_message = "Update Address Overlay Attributes"   'localizable text 
        MyBase.m_toolTip = "Update Address Overlay Attributes" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Address_Overlay"  'unique id, non-localizable (e.g. "MyCategory_ArcMapTool")

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

            '-show the "hourglass" cursor while processing
            'Set pMouseCursor = New MouseCursor
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor

            Dim pFeatLayer As IFeatureLayer
            Dim pFeatSel As IFeatureSelection
            Dim pSelSet As ISelectionSet
            Dim pFeatureCursor As IFeatureCursor
            Dim pFeat As IFeature
            pFeatureCursor = Nothing

            m_pEditor.StartOperation()
            pFeatLayer = GetLayerByName(m_pMXDoc, ADDRESS_DATASRC)
            If pFeatLayer Is Nothing Then
                MsgBox("Address Layer not found. Please add it to continue")
                m_pEditor.AbortOperation()
                Exit Sub
            End If
            pFeatSel = pFeatLayer
            pSelSet = pFeatSel.SelectionSet

            If pSelSet.Count < 1 Then
                MsgBox("No Addresses Selected to update")
                m_pEditor.AbortOperation()
                Exit Sub
            End If

            pSelSet.Search(Nothing, False, pFeatureCursor)
            pFeat = pFeatureCursor.NextFeature
            While Not pFeat Is Nothing

                pFeat.Store()
                pFeat = pFeatureCursor.NextFeature
            End While
            m_pEditor.StopOperation("Update Underlying Address Polygons")
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Address_Overlay.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Address_Overlay.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Address_Overlay.OnMouseUp implementation
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

