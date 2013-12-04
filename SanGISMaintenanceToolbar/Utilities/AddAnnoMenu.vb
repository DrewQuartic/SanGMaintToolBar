Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports System.Runtime.InteropServices

<ComClass(AddAnnoMenu.ClassId, AddAnnoMenu.InterfaceId, AddAnnoMenu.EventsId), _
 ProgId("SanGISMaintenanceToolbar.AddAnnoMenu")> _
Public NotInheritable Class AddAnnoMenu
    Inherits BaseMenu

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
    Public Const ClassId As String = "78ada81f-5524-46cd-ad23-0084255dadf0"
    Public Const InterfaceId As String = "c2124fb0-ab9a-4fe2-a12a-1bcb2151c0d9"
    Public Const EventsId As String = "2ae56feb-824d-4dcc-86c0-3b05c58bcc40"
#End Region

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()        '

        AddItem("SanGISMaintenanceToolbar.Road_AddRoadNameAnno", 1)
        AddItem("SanGISMaintenanceToolbar.Address_AddAddressAnno", 2)
        AddItem("SanGISMaintenanceToolbar.Parcel_AddParcelAnno", 3)
        AddItem("SanGISMaintenanceToolbar.Lot_AddLotAnno", 4)
        AddItem("SanGISMaintenanceToolbar.MapNum_AddAnno", 5)
        AddItem("SanGISMaintenanceToolbar.BlockNum_AddAnno", 6)
        AddItem("SanGISMaintenanceToolbar.SubName_AddAnno", 7)
        AddItem("SanGISMaintenanceToolbar.TentMap_AddAnno", 8)
    End Sub

    Public Overrides ReadOnly Property Caption() As String
        Get
            'TODO: Replace bar caption
            Return "Add Anno"
        End Get
    End Property

    Public Overrides ReadOnly Property Name() As String
        Get
            'TODO: Replace bar ID
            Return "AddAnnoMenu"
        End Get
    End Property
End Class


