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
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.Display
Imports ESRI.ArcGIS.Geometry

<ComClass(Lot_AddLotAnno.ClassId, Lot_AddLotAnno.InterfaceId, Lot_AddLotAnno.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Lot_AddLotAnno")> _
Public NotInheritable Class Lot_AddLotAnno
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "a38d8efc-2029-4c50-a5e4-a55afc81b129"
    Public Const InterfaceId As String = "a5a87809-9488-4858-a18f-4624daa19e13"
    Public Const EventsId As String = "34162470-ae4b-4f06-b040-82cd273b3e9f"
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
        MyBase.m_caption = "LotNo"   'localizable text 
        MyBase.m_message = "Add LotNo Anno"   'localizable text 
        MyBase.m_toolTip = "Add LotNo Anno" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Lot_AddLotAnno"  'unique id, non-localizable (e.g. "MyCategory_ArcMapTool")

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

        ''------------------------------------------
        ''ADDED 10112012 on removal of linked anno
        Dim pFCursor As IFeatureCursor
        Dim pFeature As IFeature

        ''-----------------------------------------------

        Try

            Dim pMXDoc As IMxDocument
            Dim pFLayer As IFeatureLayer
            Dim pSelSet As ISelectionSet
            Dim pFeatureSel As IFeatureSelection
            Dim pFWorkspace As IFeatureWorkspace

            m_application.CurrentTool = Nothing
            pMXDoc = m_application.Document

            pFLayer = GetLayerByName(pMXDoc, LOT_DATASRC)

            If pFLayer Is Nothing Then
                MsgBox("Lot layer not found. Please add it to the map before trying to annotate lots")
                Exit Sub
            End If

            pFeatureSel = pFLayer 'QI
            pFWorkspace = pFLayer.FeatureClass.FeatureDataset.Workspace
            'get a set of the selected objects. If no lots selected exit sub
            pSelSet = pFeatureSel.SelectionSet
            If pSelSet.Count = 0 Then
                MsgBox("No Lots Selected", vbExclamation, "Add LotNo Anno")
                Exit Sub
            End If

            ''----------------------------------------------------------
            ''ADDED 10112012 on removal of linked anno

            'Start editing
            m_pEditor.StartOperation()
            pSelSet.Search(Nothing, True, pFCursor)
            'Loop through the set getting each selected addresses related address number value
            pFeature = pFCursor.NextFeature
            Do Until pFeature Is Nothing

                AddLotNoAnno(pFeature, pFWorkspace, pMXDoc.ActiveView)

                pFeature = pFCursor.NextFeature
            Loop

            m_pEditor.StopOperation("CreateAnno")
            pFCursor = Nothing


            '---------------------------------------------------
            'COMMENTED OUT 10112012 on removal of linked anno
            ''Because it is feature linked, we have to open the ESRI layer context menu to add linked annotation
            'm_pMXDoc.CurrentContentsView.ContextItem = GetLayerByName(pMXDoc, LOT_DATASRC)

            'Dim pUID As New UID
            'pUID.Value = "{BF64319A-9062-11D2-AE71-080009EC732A}"
            'pUID.SubType = 13
            'm_application.Document.CommandBars.Find(pUID).Execute()
            '------------------------------------------------------


        Catch ex As Exception
            pFCursor = Nothing
            m_application.CurrentTool = Nothing
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try


    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Lot_AddLotAnno.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Lot_AddLotAnno.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Lot_AddLotAnno.OnMouseUp implementation
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
                    If CheckForLayer(LOT_DATASRC, CrntActiveView) Then
                        'If CheckForLayer("Lot Anno -  Lot Number", CrntActiveView) Then
                        Dim pFlayer As IFeatureLayer
                        Dim pFsel As IFeatureSelection
                        pFlayer = GetLayerByName(m_pMXDoc, LOT_DATASRC)
                        pFsel = pFlayer
                        If pFsel.SelectionSet.Count > 0 Then
                            Return True
                        Else
                            Return False
                        End If
                        'Else
                        'Return False
                        'End If
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

