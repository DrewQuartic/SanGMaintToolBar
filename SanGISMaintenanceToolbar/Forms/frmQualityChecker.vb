Imports SanGISMaintenanceToolbar.Globals
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.SystemUI
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class frmQualityChecker
    Private m_pMXDoc As IMxDocument
    Private m_pRoadFeatClass As IFeatureClass
    Private m_pFeatWorkspace As IFeatureWorkspace
    Private m_pIsSubmittal As Boolean


#Region "Properties"

    Private Sub SetProperty(ByVal pRow As IRow, ByVal field As enumLogFields, ByVal vProperty As Object)

        pRow.Value(field) = vProperty

    End Sub

    Public Property FrmMap() As IMxDocument
        Get
            Return m_pMXDoc
        End Get

        Set(ByVal pmxDoc As IMxDocument)
            m_pMXDoc = pmxDoc
        End Set

    End Property

    Public Property IsSubmittal() As Boolean
        Get
            Return m_pIsSubmittal
        End Get

        Set(ByVal pSubmittal As Boolean)
            m_pIsSubmittal = pSubmittal
        End Set

    End Property

#End Region

#Region "Custom"

    Private Enum enumLogFields
        enunObjectID = 0
        enumOwner = 1
        enumName = 2
        enumReconcileStart = 3
        enumReconcileEnd = 4
        enumLogTime = 5
        enumStatus = 6
    End Enum

    Private Sub PostVersion(ByVal pVersion As IVersion)

        Dim sVersionName As String
        sVersionName = pVersion.VersionName
        Dim pLogRow As IRow
        pLogRow = GetLogRow(pVersion)
        SetProperty(pLogRow, enumLogFields.enumLogTime, Now)
        SetProperty(pLogRow, enumLogFields.enumReconcileStart, DBNull.Value)
        SetProperty(pLogRow, enumLogFields.enumReconcileEnd, DBNull.Value)
        SetProperty(pLogRow, enumLogFields.enumStatus, DBNull.Value)
        pLogRow.Store()


    End Sub

    Private Function GetLogRow(ByVal pVersion As IVersion) As IRow
        Dim sVersionName As String
        Dim pFWorkspace As IFeatureWorkspace
        Dim pTable As ITable
        Dim pQueryFilter As IQueryFilter
        Dim pCursor As ICursor
        Dim pRow As IRow
        sVersionName = pVersion.VersionName
        pFWorkspace = pVersion
        On Error Resume Next
        pTable = pFWorkspace.OpenTable(RECONCILE_LOG_TABLE)
        On Error GoTo 0
        If pTable Is Nothing Then
            Err.Raise(vbObjectError + 1, "GetLogRow", _
              "Could not open table [" & RECONCILE_LOG_TABLE & "]." & vbCrLf & _
              "Create it manually or run the VersioningListener application to create the table.")
        End If

        pQueryFilter = New QueryFilter
        pQueryFilter.WhereClause = OWNER_FIELDNAME & "|| '.' || " & NAME_FIELDNAME & " = '" & sVersionName & "'"
        pCursor = pTable.Search(pQueryFilter, False)
        If pCursor Is Nothing Then
            Err.Raise(vbObjectError + 1, "GetLogRow", "Could not open Cursor")
        End If

        pRow = pCursor.NextRow
        If pRow Is Nothing Then
            pRow = pTable.CreateRow
            Dim iDot As Long
            iDot = InStr(1, sVersionName, ".", vbBinaryCompare)
            If iDot < 1 Or iDot > Len(sVersionName) Then
                Err.Raise(vbObjectError + 1, "GetLogRow", "Invalid version name [" & sVersionName & "]")
            End If
            SetProperty(pRow, enumLogFields.enumOwner, Microsoft.VisualBasic.Left(sVersionName, iDot - 1))
            SetProperty(pRow, enumLogFields.enumName, Mid(sVersionName, iDot + 1))
        End If

        If pRow Is Nothing Then
            Err.Raise(vbObjectError + 1, "GetLogRow", "Could not create new log row")
        End If

        GetLogRow = pRow
    End Function

    Private Function CheckNullValues(ByVal strTableName As String, ByVal strFieldName As String) As Boolean

        Dim pQueryFilter As IQueryFilter
        Dim pTable As ITable
        Dim pCursor As ICursor
        Dim pRow As IRow

        pQueryFilter = New QueryFilter
        pQueryFilter.WhereClause = strFieldName & " IS NULL"
        '539:  pQueryFilter.SubFields = strFieldName

        pTable = m_pFeatWorkspace.OpenTable(strTableName)
        pCursor = pTable.Search(pQueryFilter, True)
        pRow = pCursor.NextRow
        If Not pRow Is Nothing Then
            'MsgBox("QC FAILED !!!!!" & vbCrLf & "  Null value in the " & strFieldName & " field of " & strTableName & ", please edit")
            CheckNullValues = False
        Else
            CheckNullValues = True
        End If
        pRow = Nothing
        pCursor = Nothing
        pTable = Nothing
        pQueryFilter = Nothing
    End Function

    Private Function CheckBadStringValues(ByVal strTableName As String, ByVal strFieldName As String, ByVal strVal As String) As Boolean

        Dim pQueryFilter As IQueryFilter
        Dim pTable As ITable
        Dim pCursor As ICursor
        Dim pRow As IRow

        pQueryFilter = New QueryFilter
        pQueryFilter.WhereClause = strFieldName & " = '" & strVal & "'"
        '539:  pQueryFilter.SubFields = strFieldName

        pTable = m_pFeatWorkspace.OpenTable(strTableName)
        pCursor = pTable.Search(pQueryFilter, True)
        pRow = pCursor.NextRow
        If Not pRow Is Nothing Then
            'MsgBox("QC FAILED !!!!!" & vbCrLf & "  Null value in the " & strFieldName & " field of " & strTableName & ", please edit")
            CheckBadStringValues = False
        Else
            CheckBadStringValues = True
        End If
        pRow = Nothing
        pCursor = Nothing
        pTable = Nothing
        pQueryFilter = Nothing
    End Function

    Private Function CheckZeroLengthString(ByVal strTableName As String, ByVal strFieldName As String) As Boolean


        Dim pQueryFilter As IQueryFilter
        Dim pTable As ITable
        Dim pCursor As ICursor
        Dim pRow As IRow

        pQueryFilter = New QueryFilter
        pQueryFilter.WhereClause = strFieldName & " = ' '"

        pTable = m_pFeatWorkspace.OpenTable(strTableName)
        pCursor = pTable.Search(pQueryFilter, True)
        pRow = pCursor.NextRow
        If Not pRow Is Nothing Then
            'MsgBox("QC FAILED !!!!!" & vbCrLf & "  blank value in the " & strFieldName & " field of " & strTableName & ", please edit")
            CheckZeroLengthString = False
        Else
            CheckZeroLengthString = True
        End If


    End Function

#End Region

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim pFLayer As IFeatureLayer
        Dim pData As IDataStatistics
        Dim pCursor As ICursor, pStatResults As IStatisticsResults
        Dim lngTotalCount, lngUniqueCount As Long
        Dim pEnumVar As IEnumerator
        Dim pAllCursor As IFeatureCursor
        Dim pQueryFilter As IQueryFilter
        Dim pFeature As IFeature
        Dim pSelectionSet As ISelectionSet
        Dim paridQueryFilter As IQueryFilter
        Dim paridFeature As IFeature
        Dim paridSelectionSet As ISelectionSet
        Dim pWorkspace As IWorkspace
        Dim pVersion As IVersion
        Dim pTable As ITable
        Dim pQF As IQueryFilter
        Dim pFeatureclass As IFeatureClass
        Dim pSelSet As ISelectionSet
        Dim boldFont As New Drawing.Font("Microsoft Sans Serif", 8.25, Drawing.FontStyle.Bold)
        Dim regFont As New Drawing.Font("Microsoft Sans Serif", 8.25, Drawing.FontStyle.Regular)
        'Dim errMessage As String
        pCursor = Nothing
        pAllCursor = Nothing
        pWorkspace = Nothing


        Try

            Button1.Visible = False
            Button1.Enabled = False
            lblFinalStatus.Visible = True
            lblStatRoadID.Text = "Running"
            lblStatRoadID.Font = boldFont

            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Dim ErrStat As Boolean
            ErrStat = False
            'Set the datasources
            Dim pMXDoc As IMxDocument
            pMXDoc = m_pMXDoc
            pFLayer = GetLayerByName(pMXDoc, ROAD_DATASRC)
            If pFLayer Is Nothing Then
                MsgBox("Road layer not found. Please add it to the map before trying to QC")
                Me.Close()
            End If
            m_pRoadFeatClass = pFLayer.FeatureClass
            m_pFeatWorkspace = pFLayer.FeatureClass.FeatureDataset.Workspace

            'errMessage = "QC FAILED!!! For the Following:" & vbNewLine & "------------------------------" & vbNewLine & vbNewLine

            '-------------------------------------------------------------------
            'Road Checks
            '-------------------------------------------------------------------

            'Check for invalid ROADID's first
            '---------------------------------------------------
            pQF = New QueryFilter
            pQF.WhereClause = "ROADID = -99999"
            pQF.SubFields = "*"
            pSelSet = m_pRoadFeatClass.Select(pQF, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, m_pFeatWorkspace)

            If pSelSet.Count > 0 Then
                lblErrRoadID.Text = pSelSet.Count & " Roadsegments have the RoadID value of -99999 for Roadid."
                lblDnRoadIDs.Text = "X"
                lblDnRoadIDs.ForeColor = Drawing.Color.Red
                ErrStat = True
            Else
                lblErrRoadID.Text = "None"
                lblErrRoadID.ForeColor = Drawing.Color.Black
                lblDnRoadIDs.Text = "O"
                lblDnRoadIDs.ForeColor = Drawing.Color.Green
            End If
            lblStatRoadID.Text = "Done"
            lblStatRoadID.Font = regFont
            lblStatDupRdSeg.Text = "Running"
            lblStatDupRdSeg.Font = boldFont
            Me.Refresh()

            '-------------------------------------------------
            'Check for duplicated roadsegids next by comparing distinct vs total
            '--------------------------------------------------
            'if its just a qc check and not a final submit, save the time and skip this step
            If m_pIsSubmittal Then
                'Get count of distinct first
                pCursor = m_pRoadFeatClass.Search(Nothing, False)   'Get a cursor containing all records
                pData = New DataStatistics             'A datastatistics objects lests get the stats of a cursor
                pData.Cursor = pCursor
                pData.Field = RD_ROADSEGID_FLD_NAME        'Set the datastatistics to the cursor
                pEnumVar = pData.UniqueValues            ' There is a bug in ArcObjects that requires the UniqueValues method to be called before the UniqueValueCount method. We have to call it even though we aren't going to use it.
                lngUniqueCount = pData.UniqueValueCount      ' Here we get the total number of unique values

                'Then get count of all records
                pCursor = m_pRoadFeatClass.Search(Nothing, False) 'Need to reset the cursor before we can get toatal number of records
                pData.Cursor = pCursor
                pStatResults = pData.Statistics     'SatsResults.count method is easy way to get total count of features
                lngTotalCount = pStatResults.Count      ' Total number of features

                'Check that the counts match, if not then there are dups and we need to run process to report the dups
                If Not lngUniqueCount = lngTotalCount Then               '
                    Dim bdCnt As Integer
                    bdCnt = (((lngTotalCount - lngUniqueCount) + 1) / 2)
                    lblErrDupRdSeg.Text = pSelSet.Count & " Duplicated RoadSegID errors exist on T.Road; use the Summary tool to find them."
                    lblDnDupRdSegs.Text = "X"
                    lblDnDupRdSegs.ForeColor = Drawing.Color.Red
                    ErrStat = True
                Else
                    lblErrDupRdSeg.Text = "None"
                    lblErrDupRdSeg.ForeColor = Drawing.Color.Black
                    lblDnDupRdSegs.Text = "O"
                    lblDnDupRdSegs.ForeColor = Drawing.Color.Green
                End If
                lblStatDupRdSeg.Text = "Done"
                lblStatDupRdSeg.Font = regFont
            Else
                lblStatDupRdSeg.Text = "N/A"
                lblStatDupRdSeg.Font = regFont
                lblErrDupRdSeg.Text = "Skipped when it is not being submitted"
            End If 'if submittal
            lblStatRdFrDriv.Text = "Running"
            lblStatRdFrDriv.Font = boldFont
            Me.Refresh()

            '-------------------------------------------------


            'Check for null values fire drive
            '--------------------------------------------------
            If CheckNullValues(ROAD_DATASRC, RD_FIREDRIV_FLD_NAME) = False Then
                'errMessage = errMessage & "Null value found in " & ROAD_DATASRC & " for Column: " & RD_FIREDRIV_FLD_NAME & vbNewLine & vbNewLine
                lblErrRdFrDriv.Text = "Null value found in " & ROAD_DATASRC & " for Column: " & RD_FIREDRIV_FLD_NAME
                lblDnFirDriv.Text = "X"
                lblDnFirDriv.ForeColor = Drawing.Color.Red
                ErrStat = True
            Else
                lblErrRdFrDriv.Text = "None"
                lblErrRdFrDriv.ForeColor = Drawing.Color.Black
                lblDnFirDriv.Text = "O"
                lblDnFirDriv.ForeColor = Drawing.Color.Green
            End If
            lblStatRdFrDriv.Text = "Done"
            lblStatRdFrDriv.Font = regFont
            lblStatParcelPend.Text = "Running"
            lblStatParcelPend.Font = boldFont
            Me.Refresh()

            '-------------------------------------------------

            'check for parcel type pend parcel. If there are any ask the user to change them to a valid type.
            '-------------------------------------------------------------------
            pFeatureclass = m_pFeatWorkspace.OpenFeatureClass(PARCEL_DATASRC)
            pQF.WhereClause = PARCEL_PARCEL_TYPE_FLD_NAME & " = 6"
            pQF.SubFields = "*"
            pAllCursor = pFeatureclass.Search(pQF, True)      'Get a cursor containing all records
            pFeature = pAllCursor.NextFeature
            If Not pFeature Is Nothing Then
                'errMessage = errMessage & "Parcel of type PendParcel found. Please assign a legitimate type to it. Objectid: " & pFeature.OID & vbNewLine & vbNewLine
                lblErrParcelPend.Text = "Parcel of type PendParcel found. Please assign a legitimate type to it. Objectid: " & pFeature.OID
                lblDnPendPar.Text = "X"
                lblDnPendPar.ForeColor = Drawing.Color.Red
                ErrStat = True
            Else
                lblErrParcelPend.Text = "None"
                lblErrParcelPend.ForeColor = Drawing.Color.Black
                lblDnPendPar.Text = "O"
                lblDnPendPar.ForeColor = Drawing.Color.Green
            End If
            lblStatParcelPend.Text = "Done"
            lblStatParcelPend.Font = regFont
            lblStatLotNull.Text = "Running"
            lblStatLotNull.Font = boldFont
            Me.Refresh()

            '-------------------------------------------------

            'check for invalid values in Lot
            '-------------------------------------------------------------------

            If CheckNullValues(LOT_DATASRC, LOT_LOTID_FLD_NAME) = False Then
                'errMessage = errMessage & "Null value found in " & LOT_DATASRC & " for Column: " & LOT_LOTID_FLD_NAME & vbNewLine & vbNewLine

                lblErrLotNull.Text = "Null value found in " & LOT_DATASRC & " for Column: " & LOT_LOTID_FLD_NAME
                lblDnLotID.Text = "X"
                lblDnLotID.ForeColor = Drawing.Color.Red
                ErrStat = True
            Else
                lblErrLotNull.Text = "None"
                lblErrLotNull.ForeColor = Drawing.Color.Black
                lblDnLotID.Text = "O"
                lblDnLotID.ForeColor = Drawing.Color.Green
            End If
            lblStatLotNull.Text = "Done"
            lblStatLotNull.Font = regFont
            lblStatAPNATRNulls.Text = "Running"
            lblStatAPNATRNulls.Font = boldFont
            Me.Refresh()

            '-------------------------------------------------

            'check for invalid values in APN ATR
            '-------------------------------------------------------------------
            Dim Atrerrmsg As String
            Atrerrmsg = ""
            If CheckNullValues(APN_ATR_DATASRC, APN_ATR_APN_FLD_NAME) = False Then
                Atrerrmsg = Atrerrmsg & "Null value found in Table " & APN_ATR_DATASRC & " for Column: " & APN_ATR_APN_FLD_NAME & vbNewLine & vbNewLine
            End If

            If CheckZeroLengthString(APN_ATR_DATASRC, APN_ATR_APN_FLD_NAME) = False Then
                Atrerrmsg = Atrerrmsg & "Blank value found in Table " & APN_ATR_DATASRC & " for Column: " & APN_ATR_APN_FLD_NAME & vbNewLine & vbNewLine
            End If

            If CheckNullValues(APN_ATR_DATASRC, APN_ATR_APNID_FLD_NAME) = False Then
                Atrerrmsg = Atrerrmsg & "Null value found in Table " & APN_ATR_DATASRC & " for Column: " & APN_ATR_APNID_FLD_NAME & vbNewLine & vbNewLine
            End If

            'check if APNID in APN_ATR values have been added as 0 if so let the user know and have then fix it
            pTable = m_pFeatWorkspace.OpenTable(APN_ATR_DATASRC)
            pQueryFilter = New QueryFilter
            pQueryFilter.WhereClause = APN_ATR_APNID_FLD_NAME & " = 0"
            pSelectionSet = pTable.Select(pQueryFilter, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, pWorkspace)
            If pSelectionSet.Count > 0 Then
                Atrerrmsg = Atrerrmsg & "0 value found in Table " & APN_ATR_DATASRC & " for Column: " & APN_ATR_APNID_FLD_NAME & vbNewLine & vbNewLine
            End If

            'check if PARCELID in APN_ATR values have been added as 0 if so let the user know and have then fix it
            paridQueryFilter = New QueryFilter
            paridQueryFilter.WhereClause = APN_ATR_PARCELID_FLD_NAME & " = 0"
            paridSelectionSet = pTable.Select(paridQueryFilter, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, pWorkspace)
            If paridSelectionSet.Count > 0 Then
                Atrerrmsg = Atrerrmsg & "0 value found in Table " & APN_ATR_DATASRC & " for Column: " & APN_ATR_PARCELID_FLD_NAME & vbNewLine & vbNewLine
            End If


            If Atrerrmsg <> "" Then
                lblErrAPNATRNulls.Text = Atrerrmsg
                lblDnApnAtr.Text = "X"
                lblDnApnAtr.ForeColor = Drawing.Color.Red
                ErrStat = True
            Else
                lblErrAPNATRNulls.Text = "None"
                lblErrAPNATRNulls.ForeColor = Drawing.Color.Black
                lblDnApnAtr.Text = "O"
                lblDnApnAtr.ForeColor = Drawing.Color.Green
            End If
            lblStatAPNATRNulls.Text = "Done"
            lblStatAPNATRNulls.Font = regFont
            lblStatAddrAPNNull.Text = "Running"
            lblStatAddrAPNNull.Font = boldFont
            Me.Refresh()

            '-------------------------------------------------

            'check for invalid values in Addrs
            '-------------------------------------------------------------------
            If CheckNullValues(ADDRESS_DATASRC, ADDR_ADDRAPNID_FLD_NAME) = False Then
                'errMessage = errMessage & "Null value found in " & ADDRESS_DATASRC & "for Column: " & ADDR_ADDRAPNID_FLD_NAME & vbNewLine & vbNewLine
                lblErrAPNATRNulls.Text = Atrerrmsg
                lblDnApnAtr.Text = "X"
                lblDnApnAtr.ForeColor = Drawing.Color.Red
                ErrStat = True
            Else
                lblErrAddrAPNNull.Text = "None"
                lblErrAddrAPNNull.ForeColor = Drawing.Color.Black
                lblDnAddrAPN.Text = "O"
                lblDnAddrAPN.ForeColor = Drawing.Color.Green
            End If
            lblStatAddrAPNNull.Text = "Done"
            lblStatAddrAPNNull.Font = regFont
            lblStatBadFCERelate.Text = "Running"
            lblStatBadFCERelate.Font = boldFont
            Me.Refresh()


            '-------------------------------------------------
            'Check for FloodControl Has Doc relate with no record in Flood Control Doc
            '--------------------------------------------------
            Dim EFCErr As Boolean = False
            'Relationship class table
            Dim pRelTable As ITable
            Dim pTableSourcename As String
            pTableSourcename = EASFLOODCONTROL_REL_DATASRC
            pRelTable = m_pFeatWorkspace.OpenTable(pTableSourcename)
            If pRelTable Is Nothing Then
                Exit Sub
            End If

            'Ease Doc  table
            Dim pEaseDTable As ITable
            pTableSourcename = EASFLOODCONTROL_DOC_DATASRC
            pEaseDTable = m_pFeatWorkspace.OpenTable(pTableSourcename)
            If pEaseDTable Is Nothing Then
                Exit Sub
            End If

            'Easement table
            Dim pEaseTable As ITable
            pTableSourcename = EASFLOODCONTROL_DATASRC
            pEaseTable = m_pFeatWorkspace.OpenTable(pTableSourcename)
            If pEaseTable Is Nothing Then
                Exit Sub
            End If

            Dim pCur As ICursor, pRow As IRow, FIdx As Long, SIdx As Long
            FIdx = pRelTable.Fields.FindField(EASEFCREL_EASFLDCNTRLDOCID_FLD_NAME)
            SIdx = pRelTable.Fields.FindField(EASEFCREL_EASFLDCNTRLID_FLD_NAME)

            ''add a queryfilter and queryfilterdefinition for sorting
            pCur = pRelTable.Search(Nothing, True) 'changed this one
            pRow = pCur.NextRow
            'validate the values
            Dim pEaseDQF As IQueryFilter
            Dim pEaseQF As IQueryFilter
            pEaseDQF = New QueryFilter
            pEaseQF = New QueryFilter
            Dim sVal As String = ""
            Dim fVal As String = ""
            Do While Not pRow Is Nothing
                fVal = pRow.Value(FIdx)
                sVal = pRow.Value(SIdx)
                pEaseQF.WhereClause = EASFC_EASFCID_FLD_NAME & " = " & sVal
                pEaseDQF.WhereClause = EASFC_EASDOCID_NAME & " = " & fVal
                'check easement numbers
                pSelectionSet = pEaseTable.Select(pEaseQF, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, pWorkspace)
                If pSelectionSet.Count = 0 Then
                    EFCErr = True
                    Exit Do
                End If
                'check doc numbers
                pSelectionSet = pEaseDTable.Select(pEaseDQF, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, pWorkspace)
                If pSelectionSet.Count = 0 Then
                    EFCErr = True
                    Exit Do
                End If
                pRow = pCur.NextRow
            Loop

            If EFCErr Then
                lblErrBadEFCRelate.Text = "Flood Control Ease Relate Record has bad id: " & sVal & ";" & fVal
                lblDnBadEFCRel.Text = "X"
                lblDnBadEFCRel.ForeColor = Drawing.Color.Red
                ErrStat = True
                EFCErr = True
            Else
                lblErrBadEFCRelate.Text = "None"
                lblErrBadEFCRelate.ForeColor = Drawing.Color.Black
                lblDnBadEFCRel.Text = "O"
                lblDnBadEFCRel.ForeColor = Drawing.Color.Green
            End If
            lblStatBadFCERelate.Text = "Done"
            lblStatBadFCERelate.Font = regFont
            lblStatInterType.Text = "Running"
            lblStatInterType.Font = boldFont
            Me.Refresh()



            '-------------------------------------------------------------------

            'Check for null or under review values intersection type
            '
            'Temporary change to allow under review types until the Intersection database is cleaned up.  9-3-2013
            '--------------------------------------------------
            'If CheckNullValues(INTERSECTION_DATASRC, "TYPE") = False Or CheckBadStringValues(INTERSECTION_DATASRC, "TYPE", "R") = False Then
            If CheckNullValues(INTERSECTION_DATASRC, "TYPE") = False Then
                'errMessage = errMessage & "Null value found in " & ROAD_DATASRC & " for Column: " & RD_FIREDRIV_FLD_NAME & vbNewLine & vbNewLine
                ' lblErrInterType.Text = "Null value or Under Review found in " & INTERSECTION_DATASRC & " for Column: TYPE"
                lblErrInterType.Text = "Null value found in " & INTERSECTION_DATASRC & " for Column: TYPE"
                lblDnIntType.Text = "X"
                lblDnIntType.ForeColor = Drawing.Color.Red
                ErrStat = True
            Else
                lblErrInterType.Text = "None"
                lblErrInterType.ForeColor = Drawing.Color.Black
                lblDnIntType.Text = "O"
                lblDnIntType.ForeColor = Drawing.Color.Green
            End If
            lblStatInterType.Text = "Done"
            lblStatInterType.Font = regFont
            lblStatLevel.Text = "Running"
            lblStatLevel.Font = boldFont
            Me.Refresh()

            '-------------------------------------------------------------------

            'Check for null values F and T LEVEL fields
            '--------------------------------------------------
            If CheckNullValues(ROAD_DATASRC, RD_FLEVEL_FLD_NAME) = False Or CheckNullValues(ROAD_DATASRC, RD_TLEVEL_FLD_NAME) = False Then
                'errMessage = errMessage & "Null value found in " & ROAD_DATASRC & " for Column: " & RD_FIREDRIV_FLD_NAME & vbNewLine & vbNewLine
                lblErrLevel.Text = "Null values found in " & ROAD_DATASRC & " for F_LEVEL or T_LEVEL."
                lblDnLevel.Text = "X"
                lblDnLevel.ForeColor = Drawing.Color.Red
                ErrStat = True
            Else
                lblErrLevel.Text = "None"
                lblErrLevel.ForeColor = Drawing.Color.Black
                lblDnLevel.Text = "O"
                lblDnLevel.ForeColor = Drawing.Color.Green
            End If
            lblStatLevel.Text = "Done"
            lblStatLevel.Font = regFont
            lblStatPSBlock.Text = "Running"
            lblStatPSBlock.Font = boldFont
            Me.Refresh()

            '-------------------------------------------------------------------

            'Check for null values  PSBLOCK field
            '--------------------------------------------------
            If CheckNullValues(CENSUS_DATASRC, CENSUS_PSBLOCK_FLD_NAME) = False Then
                lblErrPSBlock.Text = "Null values found in " & CENSUS_DATASRC & " for PSBLOCK."
                lblDnPSBlock.Text = "X"
                lblDnPSBlock.ForeColor = Drawing.Color.Red
                ErrStat = True
            Else
                lblErrPSBlock.Text = "None"
                lblErrPSBlock.ForeColor = Drawing.Color.Black
                lblDnPSBlock.Text = "O"
                lblDnPSBlock.ForeColor = Drawing.Color.Green
            End If
            lblStatPSBlock.Text = "Done"
            lblStatPSBlock.Font = regFont
            Me.Refresh()

            'Check if its a submittal, if so run through the rec log submittal.  
            'if not then just notify if there are errors or not

            If m_pIsSubmittal Then


                '-------------------------------------------------
                'If errors then list the errors and exit sub, if no errors then run the submit
                '-------------------------------------------------------------------

                btnFinish.Visible = True
                If ErrStat Then
                    lblFinalStatus.Text = "Fix Errors and Re-Submit!"
                    lblFinalStatus.ForeColor = Drawing.Color.DarkRed
                    btnFinish.Enabled = True
                    Exit Sub
                Else
                    lblFinalStatus.Text = "Submitting...."
                    lblFinalStatus.ForeColor = Drawing.Color.Black
                    btnFinish.Enabled = False
                End If
                Me.Refresh()

                '-------------------------------------------------------------------
                'Post the version name to the rec log table if a submittal
                '-------------------------------------------------------------------
                pVersion = m_pRoadFeatClass.FeatureDataset.Workspace
                If pVersion.HasParent Then
                    PostVersion(pVersion)
                    MsgBox(pVersion.VersionName & " Passed QC process and has been submitted to Frank for approval.", vbOKOnly, "Submit Version")
                Else
                    MsgBox(pVersion.VersionName & " does not have a parent to post to.", vbOKOnly, "Submit Version")
                End If
                lblFinalStatus.Text = "Done.  No Errors Found"
                lblFinalStatus.ForeColor = Drawing.Color.Black
                btnFinish.Enabled = True

            Else
                'it is not a submittal, so just checking data and reporting if there were issues
                btnFinish.Visible = True
                btnFinish.Enabled = True
                If ErrStat Then
                    lblFinalStatus.Text = "Fix Errors and Re-QC!"
                    lblFinalStatus.ForeColor = Drawing.Color.DarkRed
                Else
                    lblFinalStatus.Text = "Done with QC Only.  No Errors Found." & vbNewLine & "(NOT submitted to Rec Log)"
                    lblFinalStatus.ForeColor = Drawing.Color.Black
                End If
                Me.Refresh()
            End If

            Me.Refresh()
            pCursor = Nothing
            pAllCursor = Nothing
           
            Exit Sub
        Catch ex As Exception
            pCursor = Nothing
            pAllCursor = Nothing
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

End Class