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
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Display
Imports ESRI.ArcGIS.esriSystem

<ComClass(Road_GetConnectedRoads.ClassId, Road_GetConnectedRoads.InterfaceId, Road_GetConnectedRoads.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Road_GetConnectedRoads")> _
Public NotInheritable Class Road_GetConnectedRoads
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "29752b34-7d6f-4f27-9773-90e73a8cfc52"
    Public Const InterfaceId As String = "9e2f82a1-aae2-44c2-b8a4-8d70c6dbdc18"
    Public Const EventsId As String = "f57c6381-4c78-48c2-8728-b1d6af7e9559"
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
    Private m_pEditor As IEditor2
    Private m_pMXDoc As IMxDocument
    Private m_pFeatureClass As IFeatureClass
    Private m_hookHelper As IHookHelper

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()

        ' TODO: Define values for the public properties
        ' TODO: Define values for the public properties
        MyBase.m_category = "SanGIS"  'localizable text 
        MyBase.m_caption = "Find Roads Connected"   'localizable text 
        MyBase.m_message = "Find Roads Connected"   'localizable text 
        MyBase.m_toolTip = "Find Roads Connected" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Road_GetConnectedRoads"  'unique id, non-localizable (e.g. "MyCategory_MyCommand")

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
        m_application.CurrentTool = Nothing
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Try
            Dim pFselLayer As IFeatureLayer
            Dim pQF As IQueryFilter
            Dim pFeatureCursor As IFeatureCursor
            Dim pFClass As IFeatureClass
            Dim pselFeature As IFeature
            Dim pFeature As IFeature
            Dim pFLayer As IFeatureLayer
            Dim pWhrString As String
            Dim pFnodeID As Integer
            Dim pTnodeID As Integer
            Dim pSelSet As ISelectionSet
            Dim pFeatureSel As IFeatureSelection
            Dim pFselCursor As IFeatureCursor
            pFselCursor = Nothing

            'Get the selected intersection point
            pFselLayer = GetLayerByName(m_pMXDoc, "T.Road")
            pFeatureSel = pFselLayer 'QI
            pSelSet = pFeatureSel.SelectionSet
            If pSelSet.Count = 0 Then
                MsgBox("No Road Selected", vbExclamation, "Get Connected Roads")
                Exit Sub
            End If

            pSelSet.Search(Nothing, True, pFselCursor)
            'Loop through the set getting each selected road connected road
            pselFeature = pFselCursor.NextFeature

            If pselFeature.Value(pselFeature.Fields.FindField(RD_FNODE_FLD_NAME)) Is System.DBNull.Value Then
                pFnodeID = 0
            Else
                pFnodeID = pselFeature.Value(pselFeature.Fields.FindField(RD_FNODE_FLD_NAME))
            End If
            If pselFeature.Value(pselFeature.Fields.FindField(RD_TNODE_FLD_NAME)) Is System.DBNull.Value Then
                pTnodeID = 0
            Else
                pTnodeID = pselFeature.Value(pselFeature.Fields.FindField(RD_TNODE_FLD_NAME))
            End If

            pWhrString = "FNODE = " & pFnodeID & " OR TNODE = " & pFnodeID & _
                         " OR FNODE = " & pTnodeID & " OR TNODE = " & pTnodeID

            pQF = New QueryFilter
            pQF.WhereClause = pWhrString

            pFLayer = GetLayerByName(m_pMXDoc, ROAD_DATASRC)

            If pFLayer Is Nothing Then
                MsgBox("Road layer not present, please add it before proceeding")
                Exit Sub
            End If

            'get the lot that was clicked on by using a spatial filter
            pFClass = pFLayer.FeatureClass
            pFeatureCursor = pFClass.Search(pQF, False)

            pFeature = pFeatureCursor.NextFeature()
            Do Until pFeature Is Nothing
                FlashIt(m_pMXDoc, pFLayer, pFeature.Shape, pFeature.OID)
                pFeature = pFeatureCursor.NextFeature
            Loop
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try

    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_GetConnectedRoads.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_GetConnectedRoads.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_GetConnectedRoads.OnMouseUp implementation
    End Sub

    Public Overrides ReadOnly Property Enabled() As Boolean
        Get
            Try
                Dim CrntActiveView As IActiveView
                CrntActiveView = m_hookHelper.ActiveView
                m_pMXDoc = m_application.Document
                CrntActiveView = m_pMXDoc.ActivatedView
                'Disable if not editing
                'm_pEditor = m_application.FindExtensionByName("ESRI Object Editor")
                'If m_pEditor.EditState = esriEditState.esriStateEditing Then
                'check if layer is selected and polyline
                If CheckForLayer(ROAD_DATASRC, CrntActiveView) Then
                    Dim pFlayer As IFeatureLayer
                    Dim pFsel As IFeatureSelection
                    pFlayer = GetLayerByName(m_pMXDoc, ROAD_DATASRC)
                    pFsel = pFlayer
                    If pFsel.SelectionSet.Count = 1 Then
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

