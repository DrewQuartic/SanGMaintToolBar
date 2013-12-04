Imports System.Runtime.InteropServices
Imports System.Drawing
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.Controls
Imports ESRI.ArcGIS.Carto
Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.Editor


<ComClass(EditCityAddress.ClassId, EditCityAddress.InterfaceId, EditCityAddress.EventsId), _
ProgId("SanGISMaintenanceToolbar.EditCityAddress")> _
Public NotInheritable Class EditCityAddress
    Inherits BaseTool

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "a0d654dc-ab3c-449d-8336-53e936cd3ba5"
    Public Const InterfaceId As String = "4436ff6e-6d5c-44ff-a383-f1b81728f7b9"
    Public Const EventsId As String = "279237b5-d3d7-47ac-a9e0-8722bb2cc129"
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
    Private m_app As IApplication
    Private m_pEditor As IEditor2

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()

        ' TODO: Define values for the public properties
        ' TODO: Define values for the public properties
        MyBase.m_category = "SanGIS"  'localizable text 
        MyBase.m_caption = "Edit City Address Log"   'localizable text 
        MyBase.m_message = "Allows User to edit the City Address Log"   'localizable text 
        MyBase.m_toolTip = "Edit City Address Log" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_EditCityAddress"  'unique id, non-localizable (e.g. "MyCategory_ArcMapTool")

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
            Try
                m_hookHelper.Hook = hook
                If m_hookHelper.ActiveView Is Nothing Then m_hookHelper = Nothing
            Catch
                m_hookHelper = Nothing
            End Try
            m_app = hook
            'Disable if hook fails
            If m_hookHelper Is Nothing Then
                MyBase.m_enabled = False
            Else
                MyBase.m_enabled = True
            End If
        End If
        ' TODO:  Add other initialization code
    End Sub

    Public Overrides Sub OnClick()
        Dim AddCtyAddrForm As New frmEditCityAddress
        AddCtyAddrForm.FrmMap = m_hookHelper.ActiveView
        AddCtyAddrForm.ShowDialog()
        m_app.CurrentTool = Nothing
    End Sub
    Public Overrides ReadOnly Property Enabled() As Boolean
        Get
            Try
                Dim CrntActiveView As IActiveView
                CrntActiveView = m_hookHelper.ActiveView
                If CheckForLayer("ANY", CrntActiveView) Then
                    m_pEditor = m_app.FindExtensionByName("ESRI Object Editor")
                    If Not m_pEditor.EditState = esriEditState.esriStateEditing Then
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


