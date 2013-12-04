﻿
'
' ZIPPER TASK - The purpose of the zipper task is to uniformly replace segments from
' the geometries of the features that fall within the specified tolerance from the
' sketch that was entered.  In other words, zip features within the tolerance together
' along the geometry of the specified sketch (the sketch is often created by running
' a trace along an existing geometry).
'
' The new geometry for a feature is created by walking along the original geometry
' and testing each point for its proximity to the sketch.  The code will keep track
' of groups of points that pass or don't pass the hit test with the sketch geometry.
' In this way we can add segments from the original geometry or the sketch geometry
' to the new geometry we are creating for the feature.  For instance, suppose the
' first 5 points of the original geometry do not pass the hit test with the sketch,
' the next 3 points do pass the hit test (fall within the specified tolerance), and
' the last 2 points don't.  The new geometry for the feature will then be comprised
' of the first 4 segments of the original geometry, two segments from the sketch, and
' a final segment from the original geometry.  The two transition segments (from
' original to sketch geometry and then back again) are generated by connection the
' points.
'

Imports ESRI.ArcGIS.ADF.CATIDs
'Imports ESRI.ArcGIS.ArcMap
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
'Imports ESRI.ArcGIS.CartoUI
Imports ESRI.ArcGIS.Display
Imports ESRI.ArcGIS.Editor
Imports ESRI.ArcGIS.EditorExt
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.SystemUI

Public Class Zipper_Utilities
    Private m_pEdSketch As ESRI.ArcGIS.Editor.IEditSketch
    Dim m_bSketchLoop As Boolean
    Private m_pMap As ESRI.ArcGIS.Carto.IMap
    Private m_dDist As Double
    Private m_pSegColl As ESRI.ArcGIS.Geometry.ISegmentCollection
    Private m_TopoColl As Collection
    Private m_SelColl As Collection
    Private m_lCount As Integer
    Private m_frmZipper As frmZipperInput

#Region "Primaries"

    Public Sub New()
        'm_frmZipper = New frmZipperInput
    End Sub

#End Region

#Region "Properties"

    Public Property SelColl() As Collection
        Get
            Return m_SelColl
        End Get
        Set(ByVal value As Collection)
            m_SelColl = value
        End Set
    End Property

    Public Property Distance() As Double
        Get
            Return m_dDist
        End Get
        Set(ByVal value As Double)
            m_dDist = value
        End Set
    End Property

#End Region

#Region "Layer"

    Function SearchLayer(ByRef pPolyline As ESRI.ArcGIS.Geometry.IPolyline, ByRef sLayer As String, ByRef pBuf As ESRI.ArcGIS.Geometry.IPolygon) As Boolean
        Try
            Dim pLayer As ESRI.ArcGIS.Carto.IFeatureLayer
            Dim pFeatClass As ESRI.ArcGIS.Geodatabase.IFeatureClass
            Dim pTestCurve As ESRI.ArcGIS.Geometry.ICurve
            Dim pFeatCursor As ESRI.ArcGIS.Geodatabase.IFeatureCursor
            Dim pFilter As ESRI.ArcGIS.Geodatabase.ISpatialFilter
            Dim pFeat As ESRI.ArcGIS.Geodatabase.IFeature
            Dim pFeatGeom As ESRI.ArcGIS.Geometry.IGeometryCollection
            Dim pNewGeom As ESRI.ArcGIS.Geometry.IGeometry
            Dim pNewRing As ESRI.ArcGIS.Geometry.IRing
            Dim lLoop As Integer
            Dim pNewColl As ESRI.ArcGIS.Geometry.IGeometryCollection = Nothing
            Dim pGeomType As ESRI.ArcGIS.Geometry.esriGeometryType
            Dim pMSeg As ESRI.ArcGIS.Geometry.IMSegmentation
            Dim pMAware As ESRI.ArcGIS.Geometry.IMAware
            Dim dMin, dMax As Double
            Dim pMColl As ESRI.ArcGIS.Geometry.IMCollection
            Dim bMFlag As Boolean
            pLayer = FindLayer(sLayer)
            If pLayer Is Nothing Then
                MsgBox("Could not find layer - " & sLayer)
                Exit Function
            End If

            pFeatClass = pLayer.FeatureClass
            pFilter = New ESRI.ArcGIS.Geodatabase.SpatialFilter
            pFilter.Geometry = pBuf
            pFilter.GeometryField = pFeatClass.ShapeFieldName
            pFilter.SpatialRel = ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum.esriSpatialRelIntersects
            pFeatCursor = pLayer.Search(pFilter, False)
            pFeat = pFeatCursor.NextFeature
            Do While Not pFeat Is Nothing
                pGeomType = pFeat.Shape.GeometryType
                If pGeomType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint Then
                    pNewGeom = CreateNewPoint((pFeat.Shape), pPolyline)
                    If Not pNewGeom Is Nothing Then
                        pFeat.Shape = pNewGeom
                        pFeat.Store()
                    End If
                Else
                    bMFlag = False
                    pFeatGeom = pFeat.Shape
                    Select Case pGeomType
                        Case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline
                            pNewColl = New ESRI.ArcGIS.Geometry.Polyline
                            pMAware = pFeat.Shape
                            If pMAware.MAware Then
                                pMColl = pMAware
                                dMin = pMColl.MMin
                                dMax = pMColl.MMax
                                bMFlag = True
                            End If
                        Case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon
                            pNewColl = New ESRI.ArcGIS.Geometry.Polygon
                            pMAware = pFeat.Shape
                            If pMAware.MAware Then
                                pMColl = pMAware
                                dMin = pMColl.MMin
                                dMax = pMColl.MMax
                                bMFlag = True
                            End If
                        Case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryMultipoint
                            pNewColl = New ESRI.ArcGIS.Geometry.Multipoint
                    End Select

                    'Snap geometries looping through the parts
                    For lLoop = 0 To pFeatGeom.GeometryCount - 1
                        If pGeomType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon Or pGeomType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline Then
                            pNewGeom = CreateNewGeometry(pFeatGeom.Geometry(lLoop), pPolyline)
                            If Not pNewGeom Is Nothing Then
                                If pNewGeom.GeometryType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryRing Then
                                    pNewRing = pNewGeom
                                    pNewRing.Close()
                                End If
                                pTestCurve = pNewGeom
                                If pTestCurve.Length = 0 Then
                                    MsgBox("One of the features from the " & pLayer.Name & " layer returned a 0 length geometry." & vbCr & "Remove that layer from the selected list or try a smaller tolerance.")
                                    SearchLayer = False
                                    Exit Function
                                Else
                                    pNewColl.AddGeometry(pNewGeom)
                                End If
                            End If
                        Else 'Multipoint
                            pNewGeom = CreateNewPoint(pFeatGeom.Geometry(lLoop), pPolyline)
                            If Not pNewGeom Is Nothing Then
                                pNewColl.AddGeometry(pNewGeom)
                            End If
                        End If
                    Next lLoop

                    If Not pNewColl Is Nothing Then
                        If bMFlag Then
                            pMSeg = pNewColl
                            pMAware = pNewColl
                            pMAware.MAware = True
                            pMSeg.SetAndInterpolateMsBetween(dMin, dMax)
                        End If
                        pFeat.Shape = pNewColl
                        pFeat.Store()
                    End If
                End If

                pFeat = pFeatCursor.NextFeature
            Loop

            'If we are down here, then everything was successful and we can return true
            SearchLayer = True
        Catch ex As Exception
            MsgBox("SearchLayer - " & Err.Description & " : " & Erl())
        End Try
    End Function

    Public Function FindLayer(ByRef sLayerName As String) As ESRI.ArcGIS.Carto.IFeatureLayer
        '
        ' Routine for finding a layer based on a name and then returning that layer as
        ' a IFeatureLayer
        '
        Dim pFLayer As ESRI.ArcGIS.Carto.IFeatureLayer

        Dim enumLayer As ESRI.ArcGIS.Carto.IEnumLayer = m_pMap.Layers(Nothing, True)
        Dim pLayer As ESRI.ArcGIS.Carto.ILayer = enumLayer.Next()

        Do While Not pLayer Is Nothing
            If TypeOf pLayer Is ESRI.ArcGIS.Carto.IFeatureLayer Then
                pFLayer = pLayer
                If UCase(pFLayer.Name) = UCase(sLayerName) Then
                    Return pFLayer
                End If
            End If

            pLayer = enumLayer.Next()
        Loop

        Return Nothing
    End Function

    Private Sub LayerCheck(ByRef pFLayer As ESRI.ArcGIS.Carto.IFeatureLayer, ByVal pfrmZip As frmZipperInput)
        Try
            Dim pEdLayers As ESRI.ArcGIS.Editor.IEditLayers
            pEdLayers = m_pEdSketch

            If pEdLayers.IsEditable(pFLayer) Then
                'change to only include polyline and polygon, no points
                'If pFLayer.FeatureClass.ShapeType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline Or pFLayer.FeatureClass.ShapeType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint Or pFLayer.FeatureClass.ShapeType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryMultipoint Or (pFLayer.FeatureClass.ShapeType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon And pFLayer.FeatureClass.FeatureType <> ESRI.ArcGIS.Geodatabase.esriFeatureType.esriFTAnnotation) Then
                If pFLayer.FeatureClass.ShapeType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline Or (pFLayer.FeatureClass.ShapeType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon And pFLayer.FeatureClass.FeatureType <> ESRI.ArcGIS.Geodatabase.esriFeatureType.esriFTAnnotation) Then

                    pfrmZip.lstLayers.Items.Add(pFLayer.Name)
                    TopoCheck(pFLayer, m_lCount)
                    m_lCount = m_lCount + 1
                    'Select Parcel in the list and check it
                    If UCase(pFLayer.Name) Like ("T.PARCEL") Then
                        m_frmZipper.lstLayers.SelectedIndex = (m_lCount - 1)
                        m_frmZipper.lstLayers.SetItemChecked(m_lCount - 1, True)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("LayerCheck - " & Erl() & " - " & Err.Description)
        End Try

    End Sub

#End Region

#Region "Data Features"

    Function CreateNewGeometry(ByRef pGeom As ESRI.ArcGIS.Geometry.IGeometry, ByRef pPolyline As ESRI.ArcGIS.Geometry.IPolyline) As ESRI.ArcGIS.Geometry.IGeometry
        Try
            Dim pPoints As ESRI.ArcGIS.Geometry.IPointCollection
            Dim lLoop, lCount As Integer
            Dim bFailed As Boolean
            Dim pPt As ESRI.ArcGIS.Geometry.IPoint
            Dim pHit As ESRI.ArcGIS.Geometry.IHitTest
            Dim pNewGeom As ESRI.ArcGIS.Geometry.IGeometry
            Dim pReturnPt As ESRI.ArcGIS.Geometry.IPoint
            Dim dHitDist As Double
            Dim lPart, lSeg As Integer
            Dim bSide As Boolean
            Dim lHitStart, lHitCount As Integer
            Dim pSubCurve As ESRI.ArcGIS.Geometry.ICurve
            Dim pStartPt, pEndPt As ESRI.ArcGIS.Geometry.IPoint
            Dim pSomePts As ESRI.ArcGIS.Geometry.IPointCollection
            Dim pRelOp As ESRI.ArcGIS.Geometry.IRelationalOperator
            Dim pPolySt, pTestPt As ESRI.ArcGIS.Geometry.IPoint
            Dim bPoly As Boolean
            Dim lNoHitStart, lNoHitCount As Integer
            Dim pLineSegs As ESRI.ArcGIS.Geometry.ISegmentCollection
            pEndPt = Nothing
            pStartPt = Nothing
            pPoints = pGeom
            'Create new rings and paths in case we are dealing with multipart shapes
            If pGeom.GeometryType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon Or pGeom.GeometryType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryRing Then
                bPoly = True
                lCount = pPoints.PointCount - 2
                pNewGeom = New ESRI.ArcGIS.Geometry.Ring
            Else
                bPoly = False
                lCount = pPoints.PointCount - 1
                pNewGeom = New ESRI.ArcGIS.Geometry.Path
            End If
            pSomePts = pNewGeom
            m_pSegColl = pNewGeom

            'Loop through the point collection looking for points to snap.  Also keep track of the stretches
            'whose segments need to be replaced in the lStretch array.  pPolyline is the sketch geometry.
            pHit = pPolyline
            lHitStart = -1
            lHitCount = 0
            lNoHitStart = -1
            lNoHitCount = 0
            bFailed = False
            pReturnPt = New ESRI.ArcGIS.Geometry.Point
            pPolySt = Nothing
            pTestPt = Nothing
            For lLoop = 0 To lCount
                pPt = pPoints.Point(lLoop)
                If pHit.HitTest(pPt, m_dDist, ESRI.ArcGIS.Geometry.esriGeometryHitPartType.esriGeometryPartVertex, pReturnPt, dHitDist, lPart, lSeg, bSide) Then
                    AddOriginalSegments(lNoHitStart, lNoHitCount, pPoints)
                    HitResult(pReturnPt, lHitStart, lLoop, pStartPt, bPoly, pPolySt, pEndPt, lHitCount)
                    If lHitCount = 2 Then
                        pTestPt = pPt
                    End If
                Else
                    If pHit.HitTest(pPt, m_dDist, ESRI.ArcGIS.Geometry.esriGeometryHitPartType.esriGeometryPartBoundary, pReturnPt, dHitDist, lPart, lSeg, bSide) Then
                        AddOriginalSegments(lNoHitStart, lNoHitCount, pPoints)
                        HitResult(pReturnPt, lHitStart, lLoop, pStartPt, bPoly, pPolySt, pEndPt, lHitCount)
                        If lHitCount = 2 Then
                            pTestPt = pPt
                        End If
                    Else
                        'If no hit, then start the counter for number of points
                        If lNoHitStart = -1 Then
                            lNoHitStart = lLoop
                            lNoHitCount = 1
                        Else
                            lNoHitCount = lNoHitCount + 1
                        End If

                        'Testing to see how many consecutive hits we got (feature vs. sketch), before we missed on the last pt.
                        Select Case lHitCount
                            Case 0 'If no hits, then there is nothing to do . . .
                            Case 1 'If one hit, then add the one hit point
                                pSomePts.AddPoint(pStartPt)
                            Case Else 'If more than one, then we replace the set with a subcurve generated from the sketch
                                pRelOp = pStartPt
                                If Not pRelOp.Equals(pEndPt) Then
                                    pSubCurve = GetSubCurve(pStartPt, pEndPt, pPolyline, lHitCount, pTestPt)
                                    pTestPt = Nothing
                                    If Not pSubCurve Is Nothing Then
                                        'Duplicate the last point in the sketch because it will be overwritten by the segment
                                        DuplicateLastPoint(pSomePts)
                                        m_pSegColl.AddSegmentCollection(pSubCurve)
                                    Else
                                        bFailed = True
                                        Exit For
                                    End If
                                Else
                                    pSomePts.AddPoint(pStartPt)
                                End If
                        End Select

                        lHitStart = -1
                        lHitCount = 0
                    End If
                End If
            Next lLoop

            'Check to see if we need to get a subcurve since we finished the loop and have
            'hit points we haven't accounted for.
            If lHitCount > 0 Then
                'If not pPolySt is nothing then the first point of the polygon also snapped and we need to
                'replace the segment between the last point and the first point
                If Not pPolySt Is Nothing Then
                    lHitCount = lHitCount + 1
                    pEndPt = pPolySt
                End If
                If lHitCount = 1 Then
                    pSomePts.AddPoint(pStartPt)
                Else
                    pRelOp = pStartPt
                    If Not pRelOp.Equals(pEndPt) Then
                        pSubCurve = GetSubCurve(pStartPt, pEndPt, pPolyline, lHitCount, pTestPt)
                        If Not pSubCurve Is Nothing Then
                            'Duplicate the last point in the sketch because it will be overwritten by the segment
                            DuplicateLastPoint(pSomePts)
                            m_pSegColl.AddSegmentCollection(pSubCurve)
                        Else
                            bFailed = True
                        End If
                    Else
                        'Check to see if all points from the feature were hits
                        If Not pPolySt Is Nothing Then
                            'If all points were hits, then just add the sketch as the new geometry
                            pLineSegs = pPolyline
                            m_pSegColl.AddSegmentCollection(pLineSegs)
                        Else
                            pSomePts.AddPoint(pStartPt)
                        End If
                    End If
                End If
            ElseIf lNoHitCount > 0 Then
                AddOriginalSegments(lNoHitStart, lNoHitCount, pPoints)
            End If

            If bFailed Then
                Return Nothing
            Else
                Return pNewGeom
            End If
        Catch ex As Exception
            MsgBox("CreateNewGeometry - " & Erl() & " - " & Err.Description)
            Return Nothing
        End Try
    End Function

    Function CreateNewPoint(ByRef pGeom As ESRI.ArcGIS.Geometry.IGeometry, ByRef pPolyline As ESRI.ArcGIS.Geometry.IPolyline) As ESRI.ArcGIS.Geometry.IGeometry
        Try
            Dim pPt As ESRI.ArcGIS.Geometry.IPoint
            Dim pHit As ESRI.ArcGIS.Geometry.IHitTest
            Dim pReturnPt As ESRI.ArcGIS.Geometry.IPoint
            Dim dHitDist As Double
            Dim lPart, lSeg As Integer
            Dim bSide As Boolean

            'Loop through the point collection looking for points to snap.  Also keep track of the stretches
            'whose segments need to be replaced in the lStretch array.  pPolyline is the sketch geometry.
            pHit = pPolyline
            pReturnPt = New ESRI.ArcGIS.Geometry.Point
            pPt = pGeom
            If Not pHit.HitTest(pPt, m_dDist, ESRI.ArcGIS.Geometry.esriGeometryHitPartType.esriGeometryPartVertex, pReturnPt, dHitDist, lPart, lSeg, bSide) Then
                If Not pHit.HitTest(pPt, m_dDist, ESRI.ArcGIS.Geometry.esriGeometryHitPartType.esriGeometryPartBoundary, pReturnPt, dHitDist, lPart, lSeg, bSide) Then
                    pReturnPt = pPt
                End If
            End If

            Return pReturnPt
        Catch ex As Exception
            MsgBox("CreateNewPoint - " & Erl() & " - " & Err.Description)
            Return Nothing
        End Try

    End Function

    Private Sub AddOriginalSegments(ByRef lNoHitStart As Integer, ByRef lNoHitCount As Integer, ByRef pPoints As ESRI.ArcGIS.Geometry.IPointCollection)
        'Routine for adding segments from the original geometry to the new geometry being created.
        Try
            Dim pOrigSegs As ESRI.ArcGIS.Geometry.ISegmentCollection
            Dim pOutSegs() As ESRI.ArcGIS.Geometry.ISegment
            Dim pSomePts As ESRI.ArcGIS.Geometry.IPointCollection
            Dim i As Integer
            pSomePts = m_pSegColl
            Select Case lNoHitCount
                Case 0
                    'Nothing to add
                Case 1
                    'If 1, then we just add the point to the new geometry
                    pSomePts.AddPoint(pPoints.Point(lNoHitStart))
                Case Else
                    'Duplicate the last point in the sketch because it will be overwritten by the segment
                    DuplicateLastPoint(m_pSegColl)

                    'If greater than 1, then we need to get the segments from the original
                    'geometry and add them to the new geometry.
                    ReDim pOutSegs(lNoHitCount - 1)
                    pOrigSegs = pPoints
                    If lNoHitCount = 3 Then
                        i = 3
                        Dim seg1 As ESRI.ArcGIS.Geometry.ISegment = pOrigSegs.Segment(0)
                        Dim seg2 As ESRI.ArcGIS.Geometry.ISegment = pOrigSegs.Segment(1)
                        Dim seg3 As ESRI.ArcGIS.Geometry.ISegment = pOrigSegs.Segment(2)
                    End If

                    'This is the only big replacement from the vb6 conversion.  ISegmentCollection.QuerySegments
                    'doesn't work with .NET because, so the alternative is to use the code below or employ
                    'IGeometryBridge
                    Dim lLoop As Long
                    Dim lCount As Long = lNoHitStart + lNoHitCount - 2
                    For lLoop = lNoHitStart To lCount
                        m_pSegColl.AddSegment(pOrigSegs.Segment(lLoop))
                    Next
                    'pOrigSegs.QuerySegments(lNoHitStart, lNoHitCount - 1, pOutSegs(0))
                    'm_pSegColl.AddSegments(lNoHitCount - 1, pOutSegs(0))
            End Select

            'Reset counters
            lNoHitStart = -1
            lNoHitCount = 0
        Catch ex As Exception
            MsgBox("AddOriginalSegments - " & Erl() & " - " & Err.Description)
        End Try

    End Sub

    Private Sub DuplicateLastPoint(ByRef pSomePts As ESRI.ArcGIS.Geometry.IPointCollection)
        Try
            Dim pClone As ESRI.ArcGIS.esriSystem.IClone
            Dim pTempPt As ESRI.ArcGIS.Geometry.IPoint
            'Duplicate the last point in the sketch because it will be overwritten by the segment
            If pSomePts.PointCount > 0 Then
                pClone = pSomePts.Point(pSomePts.PointCount - 1)
                pTempPt = pClone.Clone
                pSomePts.AddPoint(pTempPt)
            End If
        Catch ex As Exception
            MsgBox("DuplicateLastPoint - " & Erl() & " - " & Err.Description)
        End Try

    End Sub

#End Region

    Public Sub ZipFeatureGeometries(ByVal pEdSketch As IEditSketch)
        Dim pPolyline As ESRI.ArcGIS.Geometry.IPointCollection
        Dim pEditor As ESRI.ArcGIS.Editor.IEditor
        Dim lLoop As Integer
        Dim pActive As ESRI.ArcGIS.Carto.IActiveView
        Dim bUpdateFlag As Boolean
        Dim pTopo As ESRI.ArcGIS.Geometry.ITopologicalOperator
        Dim pBuf As ESRI.ArcGIS.Geometry.IPolygon
        Dim pRelOp As ESRI.ArcGIS.Geometry.IRelationalOperator
        Dim pUID As New ESRI.ArcGIS.esriSystem.UID
        Dim lIndex As Integer

        Try
            m_pEdSketch = pEdSketch
            pPolyline = pEdSketch.Geometry
            pEditor = pEdSketch
            m_pMap = pEditor.Map

            'Check for a loop in the sketch
            pRelOp = pPolyline.Point(0)
            If pRelOp.Equals(pPolyline.Point(pPolyline.PointCount - 1)) Then
                m_bSketchLoop = True
            Else
                m_bSketchLoop = False
            End If

            'Bring up the form
            m_lCount = 0
            'pfrmZip.Load()
            m_frmZipper = New frmZipperInput
            m_frmZipper.txtDistance.Text = CStr(m_dDist)
            m_frmZipper.cmdOK.Enabled = True
            m_TopoColl = New Collection
            Dim enumLayer As ESRI.ArcGIS.Carto.IEnumLayer = m_pMap.Layers(Nothing, True)
            Dim pLayer As ESRI.ArcGIS.Carto.ILayer = enumLayer.Next()
            Do While Not pLayer Is Nothing
                If TypeOf pLayer Is ESRI.ArcGIS.Carto.IFeatureLayer Then LayerCheck(pLayer, m_frmZipper)

                pLayer = enumLayer.Next()
            Loop

            'Check to see if we have a selected set of layers from a previous execution
            For lLoop = 1 To m_SelColl.Count()
                lIndex = m_SelColl.Item(lLoop)
                m_frmZipper.lstLayers.SetItemChecked(lIndex, True)
            Next lLoop
            m_frmZipper.m_TopoColl = m_TopoColl
            m_frmZipper.ShowDialog()

            Do While Not m_frmZipper.m_bCancel
                'Create the search buffer around the sketch geometry
                pTopo = pPolyline
                m_dDist = CDbl(m_frmZipper.txtDistance.Text)
                pBuf = pTopo.Buffer(m_dDist)
                m_SelColl = New Collection

                bUpdateFlag = True
                pEditor.StartOperation()
                For lLoop = 0 To m_frmZipper.lstLayers.Items.Count - 1
                    If m_frmZipper.lstLayers.GetItemChecked(lLoop) Then
                        m_SelColl.Add(lLoop, CStr(lLoop)) 'Keep track of selected layers for future executions
                        'If the update fails (because a geometry was returned with zero length), then don't do any more
                        'updates.  Continue the loop so we can keep track of the layers that were selected.
                        If bUpdateFlag Then
                            Dim s As String = m_frmZipper.lstLayers.Items(lLoop).ToString()  'VB6.GetItemString(m_frmZipper.lstLayers, lLoop)
                            bUpdateFlag = SearchLayer(pPolyline, m_frmZipper.lstLayers.Items(lLoop).ToString(), pBuf)
                        End If
                    End If
                Next lLoop

                'Check to see if the updates were all completed.  If they were, then finish the operation and
                'execute the loop.  If they weren't, then show the form again giving the user the chance to change
                'the tolerance or remove a layer
                If bUpdateFlag Then
                    pEditor.StopOperation("Zip me")

                    pActive = pEditor.Map
                    pActive.Refresh()
                    Exit Do
                Else
                    pEditor.AbortOperation()
                    MsgBox("Operation aborted.  Change parameters and try again or Cancel.")
                    m_frmZipper.ShowDialog()
                End If
            Loop

            'Unload the form
            m_frmZipper.Close()
        Catch ex As Exception
            MsgBox("ZipFeatureGeometries - " & Err.Description)
            m_frmZipper.Close()
        End Try
    End Sub

    Sub TopoCheck(ByRef pFLayer As ESRI.ArcGIS.Carto.IFeatureLayer, ByRef lIndex As Integer)
        'Determine which of our layers are part of the current topology, so we can select them
        'quickly when determining the layers to update.
        Try
            Dim pTopo As ESRI.ArcGIS.Geodatabase.ITopology
            Dim pMapTopo As ESRI.ArcGIS.EditorExt.IMapTopology
            Dim lIndex2 As Integer
            Dim pTopoClass As ESRI.ArcGIS.Geodatabase.ITopologyClass
            Dim pUID As New ESRI.ArcGIS.esriSystem.UID
            Dim pTopoExt As ESRI.ArcGIS.EditorExt.ITopologyExtension
            Dim pEditor As IEditor = m_pEdSketch
            Dim pApp As IApplication = pEditor.Parent

            'Get the Topology extension
            pUID.Value = "esriEditor.TopologyExtension"
            pTopoExt = pApp.FindExtensionByCLSID(pUID)

            If pTopoExt.CurrentTopology Is Nothing Then Exit Sub

            If TypeOf pTopoExt.CurrentTopology Is ESRI.ArcGIS.EditorExt.IMapTopology Then
                pMapTopo = pTopoExt.CurrentTopology
                lIndex2 = pMapTopo.FindClass(pFLayer.FeatureClass)
                If lIndex2 > -1 Then
                    m_TopoColl.Add(lIndex, CStr(lIndex))
                End If
            Else
                pTopo = pTopoExt.CurrentTopology
                If TypeOf pFLayer.FeatureClass Is ESRI.ArcGIS.Geodatabase.ITopologyClass Then
                    pTopoClass = pFLayer.FeatureClass
                    If Not pTopoClass.Topology Is Nothing Then
                        If pTopo.TopologyID = pTopoClass.Topology.TopologyID Then
                            m_TopoColl.Add(lIndex, CStr(lIndex))
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("TopoCheck - " & Erl() & " - " & Err.Description)
        End Try
    End Sub

    Private Sub HitResult(ByRef pReturnPt As ESRI.ArcGIS.Geometry.IPoint, ByRef lHitStart As Integer, ByRef lLoop As Integer, ByRef pStartPt As ESRI.ArcGIS.Geometry.IPoint, ByRef bPoly As Boolean, ByRef pPolySt As ESRI.ArcGIS.Geometry.IPoint, ByRef pEndPt As ESRI.ArcGIS.Geometry.IPoint, ByRef lHitCount As Integer)
        Try
            'Called when there is a hit between a point on the geometry of the feature being processed and the
            'edit sketch.
            Dim pClone As ESRI.ArcGIS.esriSystem.IClone

            pClone = pReturnPt
            If lHitStart = -1 Then
                lHitStart = lLoop
                pStartPt = pClone.Clone
                If lLoop = 0 And bPoly Then
                    pPolySt = pClone.Clone
                End If
            Else
                pEndPt = pClone.Clone
            End If
            lHitCount = lHitCount + 1
        Catch ex As Exception
            MsgBox("HitRetult - " & Erl() & " - " & Err.Description)
        End Try

    End Sub

    Function GetSubCurve(ByRef pStartPt As ESRI.ArcGIS.Geometry.IPoint, ByRef pEndPt As ESRI.ArcGIS.Geometry.IPoint, ByRef pPolyline As ESRI.ArcGIS.Geometry.IPolyline, ByRef lHitCount As Integer, ByRef pTestPt As ESRI.ArcGIS.Geometry.IPoint) As ESRI.ArcGIS.Geometry.ICurve
        Try
            Dim dEnd, dStart, dOut As Double
            Dim pOutPt As ESRI.ArcGIS.Geometry.IPoint
            Dim bSide As Boolean
            Dim pSubCurve As ESRI.ArcGIS.Geometry.ICurve
            Dim pReturnPt As ESRI.ArcGIS.Geometry.IPoint
            Dim dHitDist As Double
            Dim lPart, lSeg As Integer
            Dim pHit As ESRI.ArcGIS.Geometry.IHitTest
            Dim pNewCurve As ESRI.ArcGIS.Geometry.ICurve = Nothing
            pOutPt = Nothing
            pReturnPt = Nothing
            pSubCurve = Nothing

            'Find the Start and end points on the sketch curve
            pPolyline.QueryPointAndDistance(ESRI.ArcGIS.Geometry.esriSegmentExtension.esriNoExtension, pStartPt, True, pOutPt, dStart, dOut, bSide)
            pPolyline.QueryPointAndDistance(ESRI.ArcGIS.Geometry.esriSegmentExtension.esriNoExtension, pEndPt, True, pOutPt, dEnd, dOut, bSide)

            If dStart >= 0 And dEnd >= 0 Then
                pPolyline.GetSubcurve(dStart, dEnd, True, pSubCurve)
            Else
                Return Nothing
            End If

            If Not pSubCurve Is Nothing Then
                If Not pSubCurve.IsEmpty Then
                    'Check for a loop in the sketch and make sure we did the right thing if one is found
                    If m_bSketchLoop And Not pTestPt Is Nothing Then
                        If lHitCount > 2 Then
                            'With more than 2 hit points we can test one of the middle points and make sure it hits the
                            'curve we generate.  If it doesn't, then the curve is redone going through the start/end pt
                            'of the sketch loop.
                            pHit = pSubCurve
                            If Not pHit.HitTest(pTestPt, m_dDist, ESRI.ArcGIS.Geometry.esriGeometryHitPartType.esriGeometryPartVertex, pReturnPt, dHitDist, lPart, lSeg, bSide) Then
                                If Not pHit.HitTest(pTestPt, m_dDist, ESRI.ArcGIS.Geometry.esriGeometryHitPartType.esriGeometryPartBoundary, pReturnPt, dHitDist, lPart, lSeg, bSide) Then
                                    'If no hit found for the test point then the subcurve goes the wrong way and we need to redo it
                                    pNewCurve = GetSubCurveAgain(dStart, dEnd, pPolyline)
                                Else
                                    pNewCurve = pSubCurve
                                End If
                            Else
                                pNewCurve = pSubCurve
                            End If
                        ElseIf lHitCount = 2 Then
                            'If we only have 2 hit points, then we are going to find the shortest piece for the subcurve
                            'from the sketch.
                            If System.Math.Abs(dStart - dEnd) > 0.5 Then
                                pNewCurve = GetSubCurveAgain(dStart, dEnd, pPolyline)
                            Else
                                pNewCurve = pSubCurve
                            End If
                        End If
                        'We have our subcurve, so leave the function
                        Return pNewCurve
                    End If

                    Return pSubCurve
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox("GetSubCurve - " & Erl() & " - " & Err.Description)
            Return Nothing
        End Try

    End Function

    Function GetSubCurveAgain(ByRef dStart As Double, ByRef dEnd As Double, ByRef pPolyline As ESRI.ArcGIS.Geometry.IPolyline) As ESRI.ArcGIS.Geometry.ICurve
        Try
            Dim pSubCurvePart1, pSubCurvePart2 As ESRI.ArcGIS.Geometry.ICurve
            Dim pSegs2, pSegs1, pTotalSegs As ESRI.ArcGIS.Geometry.ISegmentCollection
            pSubCurvePart1 = Nothing
            pSubCurvePart2 = Nothing
            'If no hit found for the test point then the subcurve goes the wrong way and we need to redo it
            If dStart < dEnd Then
                pPolyline.GetSubcurve(dStart, 0, True, pSubCurvePart1)
                pPolyline.GetSubcurve(1, dEnd, True, pSubCurvePart2)
            Else
                pPolyline.GetSubcurve(dStart, 1, True, pSubCurvePart1)
                pPolyline.GetSubcurve(0, dEnd, True, pSubCurvePart2)
            End If
            pSegs1 = pSubCurvePart1
            pSegs2 = pSubCurvePart2
            pTotalSegs = New ESRI.ArcGIS.Geometry.Polyline
            pTotalSegs.AddSegmentCollection(pSegs1)
            pTotalSegs.AddSegmentCollection(pSegs2)

            Return pTotalSegs
        Catch ex As Exception
            MsgBox("GetSubCurveAgain - " & Erl() & " - " & Err.Description)
            Return Nothing
        End Try

    End Function

 
End Class
