Imports System.Runtime.InteropServices
Imports System.Drawing
Imports ESRI.ArcGIS.ADF.BaseClasses
Imports ESRI.ArcGIS.ADF.CATIDs
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.ArcMapUI

Imports ESRI.ArcGIS.Controls
Imports ESRI.ArcGIS.Editor
Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geometry

<ComClass(Road_LinkAnno.ClassId, Road_LinkAnno.InterfaceId, Road_LinkAnno.EventsId), _
 ProgId("SanGISMaintenanceToolbar.Road_LinkAnno")> _
Public NotInheritable Class Road_LinkAnno
    Inherits BaseCommand

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "b28e51ce-6561-4e39-9eb1-2e94ab4e7e9f"
    Public Const InterfaceId As String = "17e9fa95-f3ec-4c64-afac-91a252ed85e8"
    Public Const EventsId As String = "1a8286e6-e091-4879-a08e-840c2709d3da"
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
        MyBase.m_caption = "Update Linked Block Range Anno"   'localizable text 
        MyBase.m_message = "Update Linked Block Range Anno"   'localizable text 
        MyBase.m_toolTip = "Update Linked Block Range Anno" 'localizable text 
        MyBase.m_name = "SanGISMaintenanceToolbar_Road_LinkAnno"  'unique id, non-localizable (e.g. "MyCategory_MyCommand")

        Try
            'TODO: change bitmap name if necessary
            Dim bitmapResourceName As String = Me.GetType().Name + ".bmp"
            MyBase.m_bitmap = New Bitmap(Me.GetType(), bitmapResourceName)
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
        'TODO: Add Road_LinkAnno.OnClick implementation
        'do a search for any block range anno in a radius with a specific angle that matches the road.
        Try
            m_application.CurrentTool = Nothing

            '-show the "hourglass" cursor while processing
            'Set pMouseCursor = New MouseCursor
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor


            'Dim pMXDoc As IMxDocument
            'Dim pFLayer As IFeatureLayer
            Dim pPoint As IPoint
            Dim pFCursor As IFeatureCursor
            Dim pSelSet As ISelectionSet
            ' Dim pFeatureSel As IFeatureSelection
            Dim pFeature As IFeature
            ' Dim pFeature2 As IFeature
            Dim pAnnoFeat As IAnnotationFeature
            Dim pElement As IElement
            ' Dim pTextElement As ITextElement
            Dim pFWorkspace As IFeatureWorkspace
            Dim pFeatClass As IFeatureClass
            ' Dim pMouseCursor As MouseCursor
            Dim pEnvelope As IEnvelope
            Dim pRefEnvelope As IEnvelope
            Dim ConcRDNM As String
            Dim pLine As ILine
            Dim pFrmPnt As IPoint
            Dim pToPnt As IPoint
            Dim pT2D As ITransform2D
            Dim pGeometry As IGeometry
            Dim pPolyLine As IPolyline
            Dim pLnAngle As Double
            Dim pLine2 As ILine
            Dim pLnAngle2 As Double
            Dim ROWDIS As Integer
            Dim pGroupSymbolElement As IGroupSymbolElement



            Dim pFeatLayer As IFeatureLayer
            Dim pFeatSel As IFeatureSelection
            Dim pRdSelSet As ISelectionSet
            Dim pFeatureCursor As IFeatureCursor
            Dim pFeat As IFeature
            pFeatureCursor = Nothing


            pFeatLayer = GetLayerByName(m_pMXDoc, ROAD_DATASRC)
            If pFeatLayer Is Nothing Then
                MsgBox("Road Layer not found. Please add it to continue")
                Exit Sub
            End If
            pFeatSel = pFeatLayer
            pRdSelSet = pFeatSel.SelectionSet

            If pRdSelSet.Count < 1 Then
                MsgBox("No Roads Selected to update")
                Exit Sub
            End If

            pRdSelSet.Search(Nothing, False, pFeatureCursor)
            pFeat = pFeatureCursor.NextFeature
            While Not pFeat Is Nothing
                'get the block ranges
                pFeatClass = pFWorkspace.OpenFeatureClass(Anno_Block_DATASRC)
                'select the block range anno based on the road info


                'Get the Right of Way Distance, or default to 50
                If Not IsDBNull(pFeature.Value(pFeature.Fields.FindField(RD_RIGHTWAY_FLD_NAME))) And IsNumeric(pFeature.Value(pFeature.Fields.FindField(RD_RIGHTWAY_FLD_NAME))) Then
                    If pFeature.Value(pFeature.Fields.FindField(RD_RIGHTWAY_FLD_NAME)) > 40 Then
                        ROWDIS = pFeature.Value(pFeature.Fields.FindField(RD_RIGHTWAY_FLD_NAME))
                    Else
                        ROWDIS = 50
                    End If
                Else
                    ROWDIS = 50
                End If

                'determine the line angle
                pGeometry = pFeature.Shape
                pPolyLine = pGeometry

                pEnvelope = pFeature.Shape.Envelope
                pFrmPnt = New ESRI.ArcGIS.Geometry.Point
                pToPnt = New ESRI.ArcGIS.Geometry.Point
                pLine = New ESRI.ArcGIS.Geometry.Line
                pLine2 = New ESRI.ArcGIS.Geometry.Line
                pLine.FromPoint = pPolyLine.FromPoint
                pLine.ToPoint = pPolyLine.ToPoint
                'Give true radian angle to determine text and offsets
                pLnAngle = (180 - (pLine.Angle * 180) / 3.14159265358979)
                'Get Envelope angle to determin rotation of test (everything left/right bottom/top)
                pFrmPnt.X = pEnvelope.XMin
                pFrmPnt.Y = pEnvelope.YMin
                pToPnt.X = pEnvelope.XMax
                pToPnt.Y = pEnvelope.YMax
                pLine2.FromPoint = pFrmPnt
                pLine2.ToPoint = pToPnt
                pLnAngle2 = pLine2.Angle

                If IsNumeric(pFeature.Value(pFeature.Fields.FindField(RD_LLOWADDR_FLD_NAME))) Then
                    'find a selection point to search for the anno AND determine the anno text to search for
                    pPoint = New ESRI.ArcGIS.Geometry.Point
                    'East
                    If pLnAngle >= 135 And pLnAngle <= 225 Then
                        pPoint.X = ((pPolyLine.FromPoint.X) + 60)
                        pPoint.Y = ((pPolyLine.FromPoint.Y) + ROWDIS - 10)
                        ConcRDNM = pFeature.Value(pFeature.Fields.FindField(RD_LLOWADDR_FLD_NAME)) & ">"
                        'North
                    ElseIf pLnAngle > 45 And pLnAngle < 135 Then
                        pPoint.X = ((pPolyLine.FromPoint.X) - ROWDIS + 10)
                        pPoint.Y = ((pPolyLine.FromPoint.Y) + 60)
                        ConcRDNM = pFeature.Value(pFeature.Fields.FindField(RD_LLOWADDR_FLD_NAME)) & ">"
                        'West
                    ElseIf pLnAngle >= 315 Or pLnAngle <= 45 Then
                        pPoint.X = ((pPolyLine.FromPoint.X) - 60)
                        pPoint.Y = ((pPolyLine.FromPoint.Y) - ROWDIS)
                        ConcRDNM = "<" & pFeature.Value(pFeature.Fields.FindField(RD_LLOWADDR_FLD_NAME))
                        'South
                    ElseIf pLnAngle > 225 And pLnAngle < 315 Then
                        pPoint.X = ((pPolyLine.FromPoint.X) + ROWDIS - 5)
                        pPoint.Y = ((pPolyLine.FromPoint.Y) - 60)
                        ConcRDNM = "<" & pFeature.Value(pFeature.Fields.FindField(RD_LLOWADDR_FLD_NAME))
                    End If

                    'Get the expected rotation and envelope
                    pElement = pGroupSymbolElement 'pTextElement
                    pElement.Geometry = pPoint
                    pT2D = pElement ' added
                    pT2D.Rotate(pPoint, pLnAngle2)
                    pAnnoFeat.Annotation = pElement
                    pRefEnvelope = pEnvelope
                    pRefEnvelope.XMin = pEnvelope.XMin - 100
                    pRefEnvelope.YMin = pEnvelope.YMin - 100
                    pRefEnvelope.XMax = pEnvelope.XMax + 100
                    pRefEnvelope.YMax = pEnvelope.YMax + 100
                    'MsgBox (pRefEnvelope.XMin & " , " & pRefEnvelope.XMax & " , " & pRefEnvelope.YMin & " , " & pRefEnvelope.YMax)
                    'pMXDoc.ActiveView.PartialRefresh(6, Nothing, pRefEnvelope)

                    'Select the block range that matches everything to a degree.

    

                End If 'Left Block


                    'Create the Right Low Address Range
                If IsNumeric(pFeature.Value(pFeature.Fields.FindField(RD_RLOWADDR_FLD_NAME))) Then

                    pPoint = New ESRI.ArcGIS.Geometry.Point
                    'East
                    If pLnAngle >= 135 And pLnAngle <= 225 Then
                        pPoint.X = ((pPolyLine.FromPoint.X) + 60)
                        pPoint.Y = ((pPolyLine.FromPoint.Y) - ROWDIS)
                        ConcRDNM = pFeature.Value(pFeature.Fields.FindField(RD_RLOWADDR_FLD_NAME)) & ">"
                        'North
                    ElseIf pLnAngle > 45 And pLnAngle < 135 Then
                        pPoint.X = ((pPolyLine.FromPoint.X) + ROWDIS)
                        pPoint.Y = ((pPolyLine.FromPoint.Y) + 60)
                        ConcRDNM = pFeature.Value(pFeature.Fields.FindField(RD_RLOWADDR_FLD_NAME)) & ">"
                        'West
                    ElseIf pLnAngle >= 315 Or pLnAngle <= 45 Then
                        pPoint.X = ((pPolyLine.FromPoint.X) - 60)
                        pPoint.Y = ((pPolyLine.FromPoint.Y) + ROWDIS - 10)
                        ConcRDNM = "<" & pFeature.Value(pFeature.Fields.FindField(RD_RLOWADDR_FLD_NAME))
                        'South
                    ElseIf pLnAngle > 225 And pLnAngle < 315 Then
                        pPoint.X = ((pPolyLine.FromPoint.X) - ROWDIS + 5)
                        pPoint.Y = ((pPolyLine.FromPoint.Y) - 60)
                        ConcRDNM = "<" & pFeature.Value(pFeature.Fields.FindField(RD_RLOWADDR_FLD_NAME))
                    End If


                    'Set the Anno geometry the same os the selected road, and angle
                    pElement = pGroupSymbolElement 'pTextElement
                    pElement.Geometry = pPoint
                    pT2D = pElement ' added
                    pT2D.Rotate(pPoint, pLnAngle2)
                    pAnnoFeat.Annotation = pElement
                    'pFeature2.Store()
                    pRefEnvelope = pEnvelope
                    pRefEnvelope.XMin = pEnvelope.XMin - 100
                    pRefEnvelope.YMin = pEnvelope.YMin - 100
                    pRefEnvelope.XMax = pEnvelope.XMax + 100
                    pRefEnvelope.YMax = pEnvelope.YMax + 100
                    'MsgBox (pRefEnvelope.XMin & " , " & pRefEnvelope.XMax & " , " & pRefEnvelope.YMin & " , " & pRefEnvelope.YMax)
                    'pMXDoc.ActiveView.PartialRefresh(6, Nothing, pRefEnvelope)
                End If 'Right address


                pFeature = pFCursor.NextFeature


                'Start editing
                m_pEditor.StartOperation()
                pSelSet.Search(Nothing, True, pFCursor)

                'Loop through the set getting each selected addresses related address number value
                pFeature = pFCursor.NextFeature

                Do Until pFeature Is Nothing


                Loop
            End While
            m_pEditor.StopOperation("Update Road Anno")
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub
End Class



