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
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Geodatabase
Imports SanGISMaintenanceToolbar.Globals


<ComClass(Road_PasteFeature.ClassId, Road_PasteFeature.InterfaceId, Road_PasteFeature.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Road_PasteFeature")> _
Public NotInheritable Class Road_PasteFeature
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "c721b28e-167d-49ef-96d7-4d77e6489daf"
    Public Const InterfaceId As String = "644187cc-866c-4a65-ae59-80295749ecaa"
    Public Const EventsId As String = "04605038-43cd-49f7-b4d4-6d89faf80413"
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
        MyBase.m_caption = "Paste Selected Records to Road Layer"   'localizable text 
        MyBase.m_message = "Paste Selected Records to Road Layer"   'localizable text 
        MyBase.m_toolTip = "Paste Selected Records to Road Layer" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Road_PasteFeature"  'unique id, non-localizable (e.g. "MyCategory_MyCommand")


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
            'This button will allow the user to copy road features from a "scratch" layer into the main Roads dataset
            'the button is only enabled if the user has selected features from a line layer and has made that layer "active" in the ArcMap table of contents
            '-get all feature layers in the map, clear the selection from all but the "scratch" layer
            Dim pEnumLayer As IEnumLayer, pFLayer As IFeatureLayer, pFSel As IFeatureSelection
            Dim pCopyLayer As IFeatureLayer, pSelSet As ISelectionSet2, pMapSel As ISelection
            Dim pEditLayers As IEditLayers, pPasteLayer As IFeatureLayer, pCopyCursor As IFeatureCursor
            Dim pCopyFeature As IFeature, intRoadIDFld As Integer
            pCopyCursor = Nothing
            pEnumLayer = m_pMXDoc.FocusMap.Layers
            pCopyLayer = m_pMXDoc.SelectedLayer 'sure that the selected layer is a line layer due to code in the "Enabled" event
            pFSel = pEnumLayer.Next
            Do Until pFSel Is Nothing
                If TypeOf (pFSel) Is FeatureLayer Then
                    If Not pFSel Is pCopyLayer Then 'same object as the selected layer
                        pFSel.Clear() 'clear the selection from every other layer
                    End If
                    pFSel = pEnumLayer.Next
                End If
            Loop
            '-refresh so that only the scratch layer's features are shown selected
            m_pMXDoc.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, Nothing, m_pMXDoc.ActiveView.Extent)
            '-make sure to start an edit operation
            m_pEditor.StartOperation()
            '-calc the RoadID for all selected segments to "-99999", this is a flag that will prevent some of the editing code in the class extension from firing
            pFSel = pCopyLayer 'QI
            '-get the selected roads in the scratch layer
            pSelSet = pFSel.SelectionSet
            '-put the selected roads into an update cursor
            '-the "Update" method moves the selected features into a FeatureCursor (features in the cursor can be edited)
            pSelSet.Update(Nothing, False, pCopyCursor)
            '-get the index for the RoadID field, complain if it's not found
            intRoadIDFld = pCopyCursor.FindField(RD_ROADID_FLD_NAME)
            If intRoadIDFld < 0 Then
                MsgBox("The RoadID field for the scratch layer was not found (" & RD_ROADID_FLD_NAME & ").", vbCritical, "Paste Features")
                m_pEditor.AbortOperation()
                Exit Sub
            End If
            '-loop thru each selected road, change the RoadID
            pCopyFeature = pCopyCursor.NextFeature
            Do Until pCopyFeature Is Nothing
                pCopyFeature.Value(intRoadIDFld) = -99999
                pCopyCursor.UpdateFeature(pCopyFeature) '"UpdateFeature" is like "pRow.Store"
                pCopyFeature = pCopyCursor.NextFeature
            Loop


            '-get the selection from the map (not from the layer ... the map selection allows paste)
            pMapSel = m_pMXDoc.FocusMap.FeatureSelection 'ALL selected features in the map
            pMapSel.Copy() 'copy selected features to the clipboard
            '-prompt the user with a form to set the target layer to the primary roads layer
            pEnumLayer.Reset() 'move the pointer in the enum back to top
            pFLayer = pEnumLayer.Next
            Dim SelectPasteLayerForm As New frmSelectPasteLayer
            SelectPasteLayerForm.cboLineLayers.Items.Clear()
            Do Until pFLayer Is Nothing
                If pFLayer.FeatureClass.ShapeType = esriGeometryType.esriGeometryPolyline Then 'has to be line
                    If pFLayer.FeatureClass.Fields.FindField(RD_ROADID_FLD_NAME) >= 0 Then 'has to have roadid field
                        If pFLayer.Name <> pCopyLayer.Name Then 'not the same layer as selected layer
                            SelectPasteLayerForm.cboLineLayers.Items.Add(pFLayer.Name)
                        End If
                    End If
                End If
                pFLayer = pEnumLayer.Next
            Loop
            If SelectPasteLayerForm.cboLineLayers.Items.Count = 0 Then
                MsgBox("No Other line Layer with the RoadID field exists in map", vbOKOnly, "Paste Tool")
                m_pEditor.StopOperation("Paste Roads")
                Exit Sub
            Else
                SelectPasteLayerForm.cboLineLayers.Text = SelectPasteLayerForm.cboLineLayers.Items(0).ToString
                SelectPasteLayerForm.ShowDialog()
                '-if the user clicked "Close" or "X'd" out of the dialog, exit the procedure
                If Not SelectPasteLayerForm.g_NotCanceled Then
                    SelectPasteLayerForm.Close()
                    Exit Sub
                End If

                '-get the "Paste" layer using the selected name, then unload the form
                Dim strPasteLayerName As String
                strPasteLayerName = SelectPasteLayerForm.cboLineLayers.Text
                SelectPasteLayerForm.Close()
                '-call a function in the "Utilities" module to get the layer
                pPasteLayer = GetLayerByName(m_pMXDoc, strPasteLayerName)
                '-set the target to the paste layer
                pEditLayers = m_pEditor 'QI
                pEditLayers.SetCurrentLayer(pPasteLayer, 0)
                '-paste 'em in
                pMapSel.Paste()
                m_pMXDoc.ActiveView.Refresh()
                'Get a selectionset of the newly pasted features so we can pass them to the edit form.
                'This is done by setting the FeatureSelection = to the paste layer instead of the copy layer
                'and then resetting the SelectionSet to the selected features in the paste layer. Luckly the
                'features that were just pasted in are slected.
                pFSel = pPasteLayer 'QI
                pSelSet = pFSel.SelectionSet

                '-show a form for setting the RoadIDs
                '-give the form a reference to the Roads dataset
                '-form has a "RoadDataset" property to store the road feature class
                Dim PasteRoadAttributesForm As New frmPasteRoadAttributes
                'PasteRoadAttributesForm.FrmMap = m_hookHelper.ActiveView
                PasteRoadAttributesForm.RoadDataset = pPasteLayer.FeatureClass
                PasteRoadAttributesForm.MapDoc = m_pMXDoc
                PasteRoadAttributesForm.FrmMap = m_pMXDoc.ActiveView
                '-give the form a reference to the selected Roads (OIDs)
                '-form has a "Roads" property that stores the selected road OIDs
                PasteRoadAttributesForm.Roads = pSelSet.IDs
                PasteRoadAttributesForm.Show()
            End If
            m_pEditor.StopOperation("Paste Roads")

        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_PasteFeature.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_PasteFeature.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Road_PasteFeature.OnMouseUp implementation
    End Sub

    Public Overrides ReadOnly Property Enabled() As Boolean
        Get
            Try
                Dim CrntActiveView As IActiveView
                CrntActiveView = m_hookHelper.ActiveView
                m_pMXDoc = m_application.Document
                'Disable if not editing
                m_pEditor = m_application.FindExtensionByName("ESRI Object Editor")
                If m_pEditor.EditState = esriEditState.esriStateEditing Then
                    'check if layer is selected and polyline
                    If CheckSelectedLayerInfo(m_pMXDoc, "Any", esriGeometryType.esriGeometryPolyline) Then
                        'check something is selected
                        Dim pFlayer As IFeatureLayer
                        Dim pFsel As IFeatureSelection
                        pFlayer = m_pMXDoc.SelectedLayer
                        If pFlayer.FeatureClass.Fields.FindField(RD_ROADID_FLD_NAME) >= 0 Then
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

