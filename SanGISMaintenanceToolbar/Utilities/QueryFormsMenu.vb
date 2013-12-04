Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports System.Runtime.InteropServices

<ComClass(QueryFormsMenu.ClassId, QueryFormsMenu.InterfaceId, QueryFormsMenu.EventsId), _
 ProgId("SanGISMaintenanceToolbar.QueryFormsMenu")> _
Public NotInheritable Class QueryFormsMenu
    Inherits BaseMenu

#Region "Com"
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
    ''' <summary>
    ''' Required method for ArcGIS Component Category registration -
    ''' Do not modify the contents of this method with the code editor.
    ''' </summary>
    Private Shared Sub ArcGISCategoryRegistration(ByVal registerType As Type)
        Dim regKey As String = String.Format("HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID)
        MxCommandBars.Register(regKey)

    End Sub
    ''' <summary>
    ''' Required method for ArcGIS Component Category unregistration -
    ''' Do not modify the contents of this method with the code editor.
    ''' </summary>
    Private Shared Sub ArcGISCategoryUnregistration(ByVal registerType As Type)
        Dim regKey As String = String.Format("HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID)
        MxCommandBars.Unregister(regKey)

    End Sub

#End Region
#End Region

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "e08701f1-3eea-4774-ac53-c22761598630"
    Public Const InterfaceId As String = "031a1343-75b1-4bd8-8c89-04b9260f28a6"
    Public Const EventsId As String = "9bd23249-5da5-4c34-9521-bd0b56f08132"
#End Region

#End Region

#Region "Primaries"

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        AddItem("SanGISMaintenanceToolbar.QueryAPN", 1)
        AddItem("SanGISMaintenanceToolbar.QueryMPRParcel", 2)
        AddItem("SanGISMaintenanceToolbar.QuerySubdivision", 3)
        AddItem("SanGISMaintenanceToolbar.QueryRoadSegByRoadID", 4)
        AddItem("SanGISMaintenanceToolbar.QueryControl", 5)
        AddItem("SanGISMaintenanceToolbar.QueryMissingAPNs", 6)
        AddItem("SanGISMaintenanceToolbar.QueryROS", 7)
        AddItem("SanGISMaintenanceToolbar.Edit_AddressIssues", 8)
        AddItem("SanGISMaintenanceToolbar.EditBlockRangeOverlap", 9)
        AddItem("SanGISMaintenanceToolbar.QueryLastEdits", 10)
    End Sub

#End Region


    Public Overrides ReadOnly Property Caption() As String
        Get
            'TODO: Replace bar caption
            Return "Query Forms"
        End Get
    End Property

    Public Overrides ReadOnly Property Name() As String
        Get
            'TODO: Replace bar ID
            Return "QueryFormsMenu"
        End Get
    End Property
End Class


