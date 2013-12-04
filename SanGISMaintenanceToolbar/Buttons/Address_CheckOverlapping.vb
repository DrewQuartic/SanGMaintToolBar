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
Imports System.Windows.Forms

<ComClass(Address_CheckOverlapping.ClassId, Address_CheckOverlapping.InterfaceId, Address_CheckOverlapping.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Address_CheckOverlapping")> _
Public NotInheritable Class Address_CheckOverlapping
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "62d30d42-4efc-4703-bf78-c79e9164dd24"
    Public Const InterfaceId As String = "264686d9-242f-4c5e-b4a4-4ff321593d8e"
    Public Const EventsId As String = "6bf068f1-fd1f-499a-9193-c1dee564ed53"
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


    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.

    Private m_hookHelper As IHookHelper
    Private m_application As IApplication
    Private m_pEditor As IEditor2
    Private m_pMXDoc As IMxDocument

    Public Sub New()
        MyBase.New()

        ' TODO: Define values for the public properties
        ' TODO: Define values for the public properties
        MyBase.m_category = "SanGIS"  'localizable text 
        MyBase.m_caption = "Check for Overlapping Block Ranges"   'localizable text 
        MyBase.m_message = "Check for Overlapping Block Ranges"   'localizable text 
        MyBase.m_toolTip = "Check for Overlapping Block Ranges" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Address_CheckOverlapping"  'unique id, non-localizable (e.g. "MyCategory_ArcMapTool")

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

            'This button will simply call a function that returns true if there is any overlap of address ranges for the selected RoadID
            Dim pMXDoc As IMxDocument
            Dim pFLayer As IFeatureLayer, pFClass As IFeatureClass
            Dim pFSel As IFeatureSelection, pRoad As IFeature
            Dim intOID As Long, intRoadID As Long, bOverlap As Boolean

            pMXDoc = m_application.Document
            pFLayer = GetLayerByName(pMXDoc, ROAD_DATASRC)
            '-complain if the Roads layer was not found in the map
            If pFLayer Is Nothing Then
                MsgBox("Error: the roads layer was not located in the map (" & ROAD_DATASRC & ").", vbCritical, "Check Address Overlap")
                Exit Sub
            End If
            pFSel = pFLayer 'QI
            pFClass = pFLayer.FeatureClass
            '-if there is a selection in the roads layer, use the selected feature's RoadID
            If pFSel.SelectionSet.Count > 0 Then
                If pFSel.SelectionSet.Count > 1 Then
                    MsgBox("Please Select Only One Road Segment")
                    Exit Sub
                End If
                '-get the selected road feature (just need it to get it's RoadID)
                intOID = pFSel.SelectionSet.IDs.Next 'selected feature's OID
                pRoad = pFClass.GetFeature(intOID) 'get the road feature
                '-get the selected road's RoadID value
                intRoadID = pRoad.Value(pRoad.Fields.FindField(RD_ROADID_FLD_NAME))

                '-call a function that checks overlap
                bOverlap = DoAddressesOverlap(intRoadID, pFClass)
                '-check for error
                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default

                'Get the overlap table to clean up if it is not overlapped and is in the table, or to add to the table if is overlapped and isn't in there
                Dim pOVQueryFilter As IQueryFilter
                Dim pOVTable As ITable
                Dim pOVRow2 As IRow
                Dim pOVCursor As ICursor
                pOVQueryFilter = New QueryFilter
                pOVQueryFilter.WhereClause = "ROADID = " & intRoadID
                Dim pDS As IDataset
                pDS = pRoad.Class
                Dim pFWorkSpace As IFeatureWorkspace = pDS.Workspace
                pOVTable = pFWorkSpace.OpenTable(LOG_OVERLAP_DATASRC)
                pOVCursor = pOVTable.Search(pOVQueryFilter, False)
                pOVRow2 = pOVCursor.NextRow


                '-report the result and add or remove from table
                If bOverlap Then
                    MsgBox("Overlapping address ranges were found for Road #" & intRoadID & ".", vbExclamation, "Check Overlap")
                    If pOVRow2 Is Nothing Then

                        'get the roadname table to populate the fields

                        Dim pRNTable As ITable
                        Dim pRNRow2 As IRow
                        Dim pRNCursor As ICursor
                        Dim rdnmRdname As String = ""
                        Dim rdnmRdJur As String = ""
                        '-find the table that has the roadIDs
                        pRNTable = pFWorkSpace.OpenTable("T.ROADNAME")
                        If pRNTable Is Nothing Then
                            MsgBox("ROADNAME Table not found to search for new roadid", vbCritical)
                            Throw New InvalidOperationException
                            Exit Sub
                        End If
                        'Check to make sure the RoadID Chosen was valid, if its -99999 then skip this as -99999  is a special case generated and delt with by the split tool
                        If Not intRoadID = -99999 Then
                            Dim pRNQueryFilter As IQueryFilter
                            pRNQueryFilter = New QueryFilter
                            pRNQueryFilter.WhereClause = "ROAD_ID = " & intRoadID
                            pRNCursor = pRNTable.Search(pRNQueryFilter, False) 'create a cursor of search results
                            pRNRow2 = pRNCursor.NextRow 'cursor must have a value or else the search failed IE the ROADID chosen in
                            If pRNRow2 Is Nothing Then    'frm.RoadIDForRoad.cboRoadIDs value does not exist in the table ROADNAME
                                MsgBox("RoadID " & intRoadID & " was not found in the table. Please make sure the new road feature has a corresponding record in the RoadName table.", vbCritical)
                                Throw New InvalidOperationException
                                Exit Sub
                            End If
                            'get the roadname info for the overlap issue log
                            If Not IsDBNull(pRNRow2.Value(pRNRow2.Fields.FindField("FULL_NAME"))) Then
                                rdnmRdname = pRNRow2.Value(pRNRow2.Fields.FindField("FULL_NAME"))
                            Else
                                rdnmRdname = ""
                            End If
                            If Not IsDBNull(pRNRow2.Value(pRNRow2.Fields.FindField("RESERVE_JUR_CD"))) Then
                                rdnmRdJur = pRNRow2.Value(pRNRow2.Fields.FindField("RESERVE_JUR_CD"))
                            Else
                                rdnmRdJur = ""
                            End If
                        End If

                        'add the row to the overlap list
                        pOVRow2 = pOVTable.CreateRow
                        pOVRow2.Value(pOVRow2.Fields.FindField("POSTDATE")) = Now()
                        pOVRow2.Value(pOVRow2.Fields.FindField("IsException")) = "N"
                        pOVRow2.Value(pOVRow2.Fields.FindField(RD_ROADID_FLD_NAME)) = pRoad.Value(pRoad.Fields.FindField(RD_ROADID_FLD_NAME))
                        pOVRow2.Value(pOVRow2.Fields.FindField(ADDR_ISSUE_FLD_NAME)) = "OVERLAP"
                        'Add roadname table info
                        pOVRow2.Value(pOVRow2.Fields.FindField("ROADNAME")) = rdnmRdname
                        pOVRow2.Value(pOVRow2.Fields.FindField("JURISDIC")) = rdnmRdJur
                        pOVRow2.Store()
                    End If
                Else
                    MsgBox("No overlapping address values were found for Road #" & intRoadID & ".", vbInformation, "Check Overlap")
                    If Not pOVRow2 Is Nothing Then
                        Try
                            pOVRow2.Delete()
                        Catch ex As Exception
                            MessageBox.Show("Can't delete record in Overlap Range Table, Let Rob know")
                        End Try
                    End If
                End If
                pOVRow2 = Nothing
                Marshal.ReleaseComObject(pOVCursor)
                pOVCursor = Nothing
                pOVTable = Nothing
            End If
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try


    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Address_CheckOverlapping.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Address_CheckOverlapping.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Address_CheckOverlapping.OnMouseUp implementation
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

