' Copyright 2008 ESRI
' 
' All rights reserved under the copyright laws of the United States
' and applicable international laws, treaties, and conventions.
' 
' You may freely redistribute and use this sample code, with or
' without modification, provided you include the original copyright
' notice and use restrictions.
' 
' See use restrictions at <your ArcGIS install location>/developerkit/userestrictions.txt.
' 

Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports System.Runtime.InteropServices

<ComClass(SangisMaintenanceToolbar.ClassId, SangisMaintenanceToolbar.InterfaceId, SangisMaintenanceToolbar.EventsId), _
 ProgId("SanGISMaintenanceToolbar")> _
Public NotInheritable Class SangisMaintenanceToolbar
    Inherits BaseToolbar

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
    Public Const ClassId As String = "173198f9-7081-4c2e-a2fc-31b0a8bc4d44"
    Public Const InterfaceId As String = "01ff9044-e901-434e-8a42-60c879417fe2"
    Public Const EventsId As String = "2a28e775-4078-429b-aca0-c2bd49f6c0bd"
#End Region

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        AddItem("SanGISMaintenanceToolbar.UpdateFormsMenu", 1)
        BeginGroup() 'Separator
        AddItem("SanGISMaintenanceToolbar.QueryFormsMenu", 2)
        BeginGroup() 'Separator
        AddItem("SanGISMaintenanceToolbar.AddAnnoMenu", 3)
        BeginGroup() 'Separator
        AddItem("SanGISMaintenanceToolbar.OverlayMenu", 4)
        BeginGroup() 'Separator
        AddItem("SanGISMaintenanceToolbar.Road_PasteFeature", 5)
        AddItem("SanGISMaintenanceToolbar.Road_AddRoadSegAlias", 6)
        'AddItem("SanGISMaintenanceToolbar.Road_RoadPolygonUpdate", 5)
        AddItem("SanGISMaintenanceToolbar.Road_RoadSplitTool", 7)
        AddItem("SanGISMaintenanceToolbar.Road_MergeSegments", 8)
        'AddItem("SanGISMaintenanceToolbar.Road_AddRoadNameAnno", 8)
        'AddItem("SanGISMaintenanceToolbar.Road_AddRoadBlockAnno", 9)
        AddItem("SanGISMaintenanceToolbar.Road_TransferRoadAttributes", 9)
        AddItem("SanGISMaintenanceToolbar.Road_ZoomToRoadSegmentID", 10)
        AddItem("SanGISMaintenanceToolbar.Road_GetConnectedRoads", 11)
        AddItem("SanGISMaintenanceToolbar.Intersection_GetConnectedRoads", 12)
        AddItem("SanGISMaintenanceToolbar.Intersection_SelectUnderReivew", 13)
        AddItem("SanGISMaintenanceToolbar.Address_CheckOverlapping", 14)
        BeginGroup() 'Separator
        AddItem("SanGISMaintenanceToolbar.Address_AddAddressPoint", 15)
        'AddItem("SanGISMaintenanceToolbar.Address_AddAddressAnno", 15)
        'AddItem("SanGISMaintenanceToolbar.Address_Overlay", 16)
        BeginGroup() 'Separator
        AddItem("SanGISMaintenanceToolbar.Parcel_ZoomToParcel", 16)
        'AddItem("SanGISMaintenanceToolbar.Parcel_AddParcelAnno", 18)
        AddItem("SanGISMaintenanceToolbar.Parcel_Lot_Incrementer", 17)
        'AddItem("SanGISMaintenanceToolbar.Parcel_Overlay", 20)
        BeginGroup() 'Separator
        AddItem("SanGISMaintenanceToolbar.Lot_LotIDIncrementer", 18)
        'AddItem("SanGISMaintenanceToolbar.Lot_AddLotAnno", 22)
        BeginGroup()
        AddItem("SanGISMaintenanceToolbar.ALL_ZipperTask", 19)
        BeginGroup()
        AddItem("SanGISMaintenanceToolbar.QC_NoSubmit", 20)
        AddItem("SanGISMaintenanceToolbar.Version_QualityChecker", 21)

        'Tools after this point are added for testing or admin only buttons
        'If System.Environment.UserName = "rodonnell" Then
        'AddItem("SanGISMaintenanceToolbar.Intersection_overlayUpdateType", 21)
        'AddItem("SanGISMaintenanceToolbar.MapNum_AddAnno", 27)
        'End If

    End Sub

    Public Overrides ReadOnly Property Caption() As String
        Get

            Return "SanGIS Maintenance Toolbar"
        End Get
    End Property

    Public Overrides ReadOnly Property Name() As String
        Get

            Return "SanGIS Maintenance Toolbar"
        End Get
    End Property



End Class
