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
Imports ESRI.ArcGIS.Geometry

<ComClass(Parcel_ZoomToParcel.ClassId, Parcel_ZoomToParcel.InterfaceId, Parcel_ZoomToParcel.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Parcel_ZoomToParcel")> _
Public NotInheritable Class Parcel_ZoomToParcel
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "b2aec7ab-6ab3-4fdd-92b3-a69a33315d3c"
    Public Const InterfaceId As String = "69926369-a016-4ec9-b9d2-94b28dde73a9"
    Public Const EventsId As String = "02eb0f94-5311-4422-9640-a841f935d807"
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
        MyBase.m_caption = "Zoom to Parcel by APN"   'localizable text 
        MyBase.m_message = "Zoom to Parcel by APN"   'localizable text 
        MyBase.m_toolTip = "Zoom to Parcel by APN" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Parcel_ZoomToParcel"  'unique id, non-localizable (e.g. "MyCategory_ArcMapTool")

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

        Dim sAPN As String
        Dim pActiveView As IActiveView
        Dim pDocDirty As IDocumentDirty
        Dim pFeatLayer As IFeatureLayer
        Dim pFeatClass As IFeatureClass
        Dim pFeatCursor As IFeatureCursor
        Dim pFeatSelSegment As IFeatureSelection
        Dim pFeature As IFeature
        Try
            pFeatCursor = Nothing
            m_application.CurrentTool = Nothing

            pActiveView = m_pMXDoc.ActiveView
            sAPN = ""
            Do While sAPN = ""
                sAPN = InputBox("Enter APN (8-10 digits); dashes are accepted", "Parcel Search")
                sAPN = sAPN.Replace("-", "")
                If sAPN = "" Then Exit Sub
                If Len(sAPN) < 8 Or Len(sAPN) > 10 Then
                    MsgBox("'" & sAPN & "' is not 8 to 10 digits long", vbExclamation, _
                           "Parcel Search Error")
                    sAPN = ""
                ElseIf Not IsNumeric(sAPN) Then
                    MsgBox(sAPN & " is not numeric", vbExclamation, "Parcel Search Error")
                    sAPN = ""
                End If
            Loop

            '-show the "hourglass" cursor while processing

            'Set pMouseCursor = New MouseCursor
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor


            Dim pQF As IQueryFilter
            Dim pQF2 As IQueryFilter

            pQF = New QueryFilter
            pQF2 = New QueryFilter
            pQF.WhereClause = APN_ATR_APN_FLD_NAME & " LIKE '" & sAPN & "%'"

            Dim pTable As ITable
            Dim pCursor As ICursor
            pTable = GetWorkspaceTable("ANY", m_pMXDoc.ActiveView, APN_ATR_DATASRC, True)
            pCursor = pTable.Search(pQF, True)
            Dim pRow As IRow
            pRow = pCursor.NextRow
            'If no Row found then let the user know the APN doesn't exist and exit the Sub
            If pRow Is Nothing Then
                MsgBox(" Invalid APN ")
                Exit Sub
            End If

            pQF2.WhereClause = PARCEL_PARCELID_FLD_NAME & " = " & pRow.Value(pRow.Fields.FindField(APN_ATR_PARCELID_FLD_NAME))
            pFeatLayer = GetLayerByName(m_pMXDoc, PARCEL_DATASRC)
            If pFeatLayer Is Nothing Then
                MessageBox.Show("Parcel Layer not Found, Please Load")
                Exit Sub
            End If
            pFeatClass = pFeatLayer.FeatureClass
            pFeatSelSegment = pFeatLayer
            pFeatSelSegment.SelectFeatures(pQF2, esriSelectionResultEnum.esriSelectionResultNew, False)
            pFeatCursor = pFeatClass.Search(pQF2, True)
            pFeature = pFeatCursor.NextFeature
            'If no parcels were found, stop now
            If pFeature Is Nothing Then
                MsgBox("No Parcel was found matching APN " & sAPN, vbExclamation, _
                       "Parcel APN Search")
                pActiveView.Refresh()
                Exit Sub
            End If

            Dim pEnv As IEnvelope
            pEnv = New Envelope
            Do Until pFeature Is Nothing
                pEnv.Union(pFeature.Extent)
                pFeature = pFeatCursor.NextFeature
            Loop
            If pEnv.IsEmpty Then
                MsgBox("Unable to zoom to the selected parcel(s)", vbExclamation, _
                       "Parcel APN Search Error")
                pActiveView.Refresh()
                Exit Sub
            End If

            'Zoom to the new extent
            pEnv.Expand(4, 4, True)
            pActiveView.Extent = pEnv
            pActiveView.Refresh()

            pDocDirty = m_pMXDoc
            pDocDirty.SetDirty()
            pCursor = Nothing
            pFeatCursor = Nothing
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Catch ex As Exception
            pFeatCursor = Nothing
            m_application.CurrentTool = Nothing
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try

    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Parcel_ZoomToParcel.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Parcel_ZoomToParcel.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Parcel_ZoomToParcel.OnMouseUp implementation
    End Sub

    Public Overrides ReadOnly Property Enabled() As Boolean
        Get
            Try
                Dim CrntActiveView As IActiveView
                m_pMXDoc = m_application.Document
                CrntActiveView = m_pMXDoc.ActivatedView
                'Disable if no road layer
                If CheckForLayer(PARCEL_DATASRC, CrntActiveView) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property

End Class

