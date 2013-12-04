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

<ComClass(Parcel_Lot_Incrementer.ClassId, Parcel_Lot_Incrementer.InterfaceId, Parcel_Lot_Incrementer.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Parcel_Lot_Incrementer")> _
Public NotInheritable Class Parcel_Lot_Incrementer
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "274ce1ab-c355-472e-8e2e-f2fb1b0d2ab4"
    Public Const InterfaceId As String = "dcc6164d-2532-41f2-b5a8-ec6e2fcdff06"
    Public Const EventsId As String = "99bec974-a65c-4d14-bdb3-d0e03cb6d7e7"
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
    Dim m_Form As New frmParcelLotIncrementer
    Const GWL_HWNDPARENT As Int32 = (-8)
    'Use the user32 dll to make the modeless form stay above arcmap (its parent) all the time, and minimize with it.
    'Using the topmost property doesn't let it minimize so instituted this user32 dll solution 08022010
    <DllImport("User32", CharSet:=CharSet.Auto)> _
      Public Shared Function SetWindowLong(ByVal hwnd As Integer, ByVal index As Integer, ByVal value As Integer) As Integer
    End Function


    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.

    Public Sub New()
        MyBase.New()

        ' TODO: Define values for the public properties
        ' TODO: Define values for the public properties
        MyBase.m_category = "SanGIS"  'localizable text 
        MyBase.m_caption = "Increment Parcel or Lot Numbers"   'localizable text 
        MyBase.m_message = "Increment Parcel or Lot Numbers"   'localizable text 
        MyBase.m_toolTip = "Increment Parcel or Lot Numbers" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Parcel_Lot_Incrementer"  'unique id, non-localizable (e.g. "MyCategory_ArcMapTool")

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


            '-show the incrementer form
            m_Form.MapApp = m_application
            SetWindowLong(m_Form.Handle.ToInt32, GWL_HWNDPARENT, m_application.hWnd)
            m_Form.Show()
            m_Form.optLotBlock.Checked = True

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Public Overrides Sub OnMouseDown(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Parcel_Lot_Incrementer.OnMouseDown implementation
    End Sub

    Public Overrides Sub OnMouseMove(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)
        'TODO: Add Parcel_Lot_Incrementer.OnMouseMove implementation
    End Sub

    Public Overrides Sub OnMouseUp(ByVal Button As Integer, ByVal Shift As Integer, ByVal X As Integer, ByVal Y As Integer)


        Dim pSpatialFilter As ISpatialFilter
        Dim pPoint As IPoint
        Dim pMxApp As IMxApplication
        Dim pDisApp As IAppDisplay
        Dim pDisplay As IDisplay
        Dim pFeatLayer As IFeatureLayer
        Dim pMXDoc As IMxDocument
        Dim pFeatClass As IFeatureClass
        Dim pFeatCursor As IFeatureCursor
        Dim pFeat As IFeature
        Dim pQF As IQueryFilter
        Dim pTable As ITable
        Dim pFWorkspace As IFeatureWorkspace
        Dim pCursor As ICursor
        Dim pRow As IRow
        Try
            pFeatCursor = Nothing
            'Get the click point and create the click
            pMxApp = m_application
            pMXDoc = m_application.Document
            pDisApp = pMxApp.Display
            pDisplay = pDisApp   'QI
            pPoint = pDisplay.DisplayTransformation.ToMapPoint(X, Y)
            pSpatialFilter = New SpatialFilter
            pSpatialFilter.Geometry = pPoint
            pSpatialFilter.GeometryField = "SHAPE"
            pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects

            'If lot num option chosen then get the lot layer and make sure its present
            If m_Form.optLotBlock.Checked Then
                pFeatLayer = GetLayerByName(m_pMXDoc, LOT_DATASRC)

                If pFeatLayer Is Nothing Then
                    MsgBox("Lot layer not present, please add it before proceeding")
                    m_Form.Close()
                    Exit Sub
                End If

                'get the lot that was clicked on by using a spatial filter
                pFeatClass = pFeatLayer.FeatureClass
                pFeatCursor = pFeatClass.Update(pSpatialFilter, False)
                pFeat = pFeatCursor.NextFeature
                'Start an edit operation assign the lot no
                m_pEditor.StartOperation()
                pFeat.Value(pFeat.Fields.FindField(LOT_LOTNO_FLD_NAME)) = m_Form.txtCurrentValue.Text 'frmIncrementer.txtCurrentValue.Text
                If (IsDBNull(pFeat.Value(pFeat.Fields.FindField(LOT_SUBDIVID_FLD_NAME))) Or Not IsNumeric(pFeat.Value(pFeat.Fields.FindField(LOT_SUBDIVID_FLD_NAME)))) And m_Form.cboSubDivIDs.Text <> "NONE" And IsNumeric(m_Form.cboSubDivIDs.Text) Then
                    pFeat.Value(pFeat.Fields.FindField(LOT_SUBDIVID_FLD_NAME)) = m_Form.cboSubDivIDs.Text
                End If
                pFeatCursor.UpdateFeature(pFeat)
                If IsNumeric(m_Form.txtCurrentValue.Text) Then m_Form.txtCurrentValue.Text = m_Form.txtCurrentValue.Text + 1 'frmIncrementer.txtCurrentValue.Text = frmIncrementer.txtCurrentValue.Text + 1

                '-------------------------------------------
                'ADDED 10122012 to add Lot No Anno when linked anno was removed
                pFWorkspace = pFeatClass.FeatureDataset.Workspace
                AddLotNoAnno(pFeat, pFWorkspace, pMXDoc.ActiveView)
                '--------------------------------------------

                m_pEditor.StopOperation("Update Lot Number")
                FlashIt(m_pMXDoc, pFeatLayer, pFeat.Shape, pFeat.OID)

                'if parcel option chosen
            ElseIf m_Form.optParcelAPN.Checked Then 'frmIncrementer.optParcelAPN Then
                pFeatLayer = GetLayerByName(m_pMXDoc, PARCEL_DATASRC)

                If pFeatLayer Is Nothing Then
                    MsgBox("Parcel layer not present, please add it before proceeding")
                    m_Form.Close()
                    Exit Sub
                End If

                'get the Parcel that was clicked on by using a spatial filter
                pFeatClass = pFeatLayer.FeatureClass
                pFeatCursor = pFeatClass.Search(pSpatialFilter, False)
                pFeat = pFeatCursor.NextFeature
                'if the parcel clicked on is type pend parcel then create apn and increment tool. If not skip
                If pFeat.Value(pFeat.Fields.FindField(PARCEL_PARCEL_TYPE_FLD_NAME)) = 6 Then
                    m_pEditor.StartOperation()
                    pFeat.Value(pFeat.Fields.FindField(PARCEL_PARCEL_TYPE_FLD_NAME)) = 1
                    pFeat.Store()
                    'Query the apn_atr table to see if the parcel already has a
                    pFWorkspace = pFeatClass.FeatureDataset.Workspace
                    pTable = pFWorkspace.OpenTable(APN_ATR_DATASRC)
                    pQF = New QueryFilter
                    pQF.WhereClause = APN_ATR_PARCELID_FLD_NAME & " = " & pFeat.Value(pFeat.Fields.FindField(PARCEL_PARCELID_FLD_NAME))
                    pCursor = pTable.Search(pQF, False)
                    pRow = pCursor.NextRow
                    'if the parcel somehow already has an apn attached then update it with the new one
                    If Not pRow Is Nothing Then
                        pRow.Value(pRow.Fields.FindField(APN_ATR_APN_FLD_NAME)) = CStr(m_Form.txtBK.Text & _
                                             m_Form.txtPG.Text & m_Form.txtCurrentValue.Text & m_Form.txtSID.Text)
                        pRow.Store()
                        'Else create a new record in the apn atr table
                    Else
                        pRow = pTable.CreateRow
                        pRow.Value(pRow.Fields.FindField(APN_ATR_PARCELID_FLD_NAME)) = pFeat.Value(pFeat.Fields.FindField(PARCEL_PARCELID_FLD_NAME))
                        pRow.Value(pRow.Fields.FindField(APN_ATR_APN_FLD_NAME)) = CStr(m_Form.txtBK.Text & _
                                            m_Form.txtPG.Text & m_Form.txtCurrentValue.Text & m_Form.txtSID.Text)
                        pRow.Store()
                    End If

                    If IsNumeric(m_Form.txtCurrentValue.Text) Then
                        If m_Form.txtCurrentValue.Text < 9 Then
                            m_Form.txtCurrentValue.Text = "0" & CStr(m_Form.txtCurrentValue.Text + 1)
                        Else
                            m_Form.txtCurrentValue.Text = m_Form.txtCurrentValue.Text + 1
                        End If
                    End If

                    m_pEditor.StopOperation("Increment APN")
                Else
                    MsgBox("the type of parcel you clicked on is not correct sub type")
                    m_Form.Focus()
                    Exit Sub
                End If
                FlashIt(m_pMXDoc, pFeatLayer, pFeat.Shape, pFeat.OID)
                pMXDoc.ActiveView.PartialRefresh(6, Nothing, pFeat.Shape.Envelope)

            End If
            If m_Form.Visible Then
                m_Form.Focus()
            End If
            pFeatCursor = Nothing
        Catch ex As Exception
            pFeatCursor = Nothing
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
                    'Disable if no parcel and lot layer
                    If CheckForLayer(PARCEL_DATASRC, CrntActiveView) Then
                        If CheckForLayer(LOT_DATASRC, CrntActiveView) Then
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

