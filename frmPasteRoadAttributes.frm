VERSION 5.00
Begin VB.Form frmPasteRoadAttributes 
   Caption         =   "Set Attributes of Pasted Roads"
   ClientHeight    =   8340
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6105
   LinkTopic       =   "Form1"
   ScaleHeight     =   8340
   ScaleWidth      =   6105
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame fmeMain 
      Caption         =   "Alter Road Atributes"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000015&
      Height          =   8055
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   5775
      Begin VB.CommandButton cmdShowHide 
         Caption         =   "Show Attributes"
         Enabled         =   0   'False
         BeginProperty Font 
            Name            =   "Tahoma"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   1080
         TabIndex        =   49
         Top             =   840
         Width           =   1335
      End
      Begin VB.CommandButton cmdGetUniqueRoadIDs 
         Height          =   375
         Left            =   1080
         Style           =   1  'Graphical
         TabIndex        =   47
         Top             =   360
         Width           =   495
      End
      Begin VB.ComboBox cboRoadIDs 
         Height          =   315
         Left            =   1800
         TabIndex        =   46
         Top             =   360
         Width           =   2535
      End
      Begin VB.CommandButton cmdNext 
         Caption         =   ">>"
         Height          =   375
         Left            =   4440
         TabIndex        =   45
         Top             =   360
         Width           =   855
      End
      Begin VB.CommandButton cmdSave 
         Caption         =   "Save"
         Height          =   375
         Left            =   2640
         TabIndex        =   44
         Top             =   840
         Width           =   735
      End
      Begin VB.CommandButton cmdClose 
         Caption         =   "Close"
         Height          =   375
         Left            =   3480
         TabIndex        =   43
         Top             =   840
         Width           =   855
      End
      Begin VB.Frame fmeSegInfo 
         Caption         =   "Segment 1: 99999"
         BeginProperty Font 
            Name            =   "Tahoma"
            Size            =   9.75
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00808080&
         Height          =   6375
         Left            =   120
         TabIndex        =   1
         Top             =   1440
         Width           =   5535
         Begin VB.ComboBox cboDedStat 
            Height          =   315
            Left            =   960
            TabIndex        =   22
            Top             =   480
            Width           =   1575
         End
         Begin VB.ComboBox cboLJurisdic 
            Height          =   315
            Left            =   960
            TabIndex        =   21
            Top             =   840
            Width           =   1575
         End
         Begin VB.ComboBox cboRJurisdic 
            Height          =   315
            Left            =   960
            TabIndex        =   20
            Top             =   1200
            Width           =   1575
         End
         Begin VB.ComboBox cboFireDriv 
            Height          =   315
            Left            =   960
            TabIndex        =   19
            Top             =   1920
            Width           =   1575
         End
         Begin VB.ComboBox cboSegClass 
            Height          =   315
            Left            =   960
            TabIndex        =   18
            Top             =   1560
            Width           =   1575
         End
         Begin VB.ComboBox cboSegStat 
            Height          =   315
            Left            =   3960
            TabIndex        =   17
            Top             =   480
            Width           =   1335
         End
         Begin VB.ComboBox cboFunClass 
            Height          =   315
            Left            =   3960
            TabIndex        =   16
            Top             =   840
            Width           =   1335
         End
         Begin VB.ComboBox cboOneWay 
            Height          =   315
            Left            =   3960
            TabIndex        =   15
            Top             =   1200
            Width           =   1335
         End
         Begin VB.ComboBox cboLMixAddr 
            Height          =   315
            Left            =   3960
            TabIndex        =   14
            Top             =   1800
            Width           =   1335
         End
         Begin VB.ComboBox cboRMixAddr 
            Height          =   315
            Left            =   3960
            TabIndex        =   13
            Top             =   2160
            Width           =   1335
         End
         Begin VB.ComboBox cboCarto 
            Height          =   315
            Left            =   3960
            TabIndex        =   12
            Top             =   2760
            Width           =   1335
         End
         Begin VB.ComboBox cboOBMH 
            Height          =   315
            Left            =   3960
            TabIndex        =   11
            Top             =   3120
            Width           =   1335
         End
         Begin VB.TextBox txtTravelWay 
            Height          =   285
            Left            =   960
            TabIndex        =   10
            Top             =   2760
            Width           =   1575
         End
         Begin VB.TextBox txtRightway 
            Height          =   285
            Left            =   960
            TabIndex        =   9
            Top             =   3120
            Width           =   1575
         End
         Begin VB.TextBox txtSpeed 
            Height          =   285
            Left            =   960
            TabIndex        =   8
            Top             =   3480
            Width           =   1575
         End
         Begin VB.TextBox txtAddHL 
            Height          =   285
            Left            =   1200
            TabIndex        =   7
            Top             =   4920
            Width           =   1455
         End
         Begin VB.TextBox txtAddrHR 
            Height          =   315
            Left            =   3480
            TabIndex        =   6
            Top             =   4920
            Width           =   1575
         End
         Begin VB.TextBox txtAddrLL 
            Height          =   315
            Left            =   1200
            TabIndex        =   5
            Top             =   5400
            Width           =   1455
         End
         Begin VB.TextBox txtAddrLR 
            Height          =   315
            Left            =   3480
            TabIndex        =   4
            Top             =   5400
            Width           =   1575
         End
         Begin VB.ComboBox cboL_Zip 
            Height          =   315
            Left            =   1200
            TabIndex        =   3
            Top             =   5880
            Width           =   1455
         End
         Begin VB.ComboBox cboR_Zip 
            Height          =   315
            Left            =   3480
            TabIndex        =   2
            Top             =   5880
            Width           =   1575
         End
         Begin VB.Label Label2 
            Alignment       =   1  'Right Justify
            Caption         =   "DedStat:"
            Height          =   255
            Left            =   120
            TabIndex        =   42
            Top             =   480
            Width           =   735
         End
         Begin VB.Label Label3 
            Alignment       =   1  'Right Justify
            Caption         =   "LJurisdic:"
            Height          =   255
            Left            =   120
            TabIndex        =   41
            Top             =   840
            Width           =   735
         End
         Begin VB.Label Label4 
            Alignment       =   1  'Right Justify
            Caption         =   "RJurisdic:"
            Height          =   255
            Left            =   120
            TabIndex        =   40
            Top             =   1200
            Width           =   735
         End
         Begin VB.Label Label5 
            Alignment       =   1  'Right Justify
            Caption         =   "FireDriv:"
            Height          =   255
            Left            =   120
            TabIndex        =   39
            Top             =   1920
            Width           =   735
         End
         Begin VB.Label Label6 
            Alignment       =   1  'Right Justify
            Caption         =   "SegClass:"
            Height          =   375
            Left            =   120
            TabIndex        =   38
            Top             =   1560
            Width           =   735
         End
         Begin VB.Label Label7 
            Alignment       =   1  'Right Justify
            Caption         =   "SegStat:"
            Height          =   255
            Left            =   3000
            TabIndex        =   37
            Top             =   480
            Width           =   855
         End
         Begin VB.Label Label8 
            Alignment       =   1  'Right Justify
            Caption         =   "FunClass:"
            Height          =   255
            Left            =   3120
            TabIndex        =   36
            Top             =   840
            Width           =   735
         End
         Begin VB.Label Label9 
            Alignment       =   1  'Right Justify
            Caption         =   "OneWay:"
            Height          =   255
            Left            =   3120
            TabIndex        =   35
            Top             =   1200
            Width           =   735
         End
         Begin VB.Label Label10 
            Alignment       =   1  'Right Justify
            Caption         =   "LMixAddress:"
            Height          =   255
            Left            =   2880
            TabIndex        =   34
            Top             =   1800
            Width           =   975
         End
         Begin VB.Label Label11 
            Alignment       =   1  'Right Justify
            Caption         =   "RMixAddress:"
            Height          =   255
            Left            =   2880
            TabIndex        =   33
            Top             =   2160
            Width           =   975
         End
         Begin VB.Label Label12 
            Alignment       =   1  'Right Justify
            Caption         =   "Carto:"
            Height          =   255
            Left            =   3120
            TabIndex        =   32
            Top             =   2760
            Width           =   735
         End
         Begin VB.Label Label13 
            Alignment       =   1  'Right Justify
            Caption         =   "OBMH:"
            Height          =   255
            Left            =   3120
            TabIndex        =   31
            Top             =   3120
            Width           =   735
         End
         Begin VB.Label Label14 
            Alignment       =   1  'Right Justify
            Caption         =   "TravelWay:"
            Height          =   255
            Left            =   0
            TabIndex        =   30
            Top             =   2760
            Width           =   855
         End
         Begin VB.Label Label15 
            Alignment       =   1  'Right Justify
            Caption         =   "RightWay:"
            Height          =   255
            Left            =   120
            TabIndex        =   29
            Top             =   3120
            Width           =   735
         End
         Begin VB.Label Label16 
            Alignment       =   1  'Right Justify
            Caption         =   "Speed:"
            Height          =   255
            Left            =   120
            TabIndex        =   28
            Top             =   3480
            Width           =   735
         End
         Begin VB.Label lblAddress 
            Caption         =   "Address"
            BeginProperty Font 
               Name            =   "Tahoma"
               Size            =   11.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00808080&
            Height          =   375
            Left            =   120
            TabIndex        =   27
            Top             =   4320
            Width           =   975
         End
         Begin VB.Label Label17 
            Alignment       =   2  'Center
            Caption         =   "Left"
            BeginProperty Font 
               Name            =   "Tahoma"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   1560
            TabIndex        =   26
            Top             =   4560
            Width           =   735
         End
         Begin VB.Label Label18 
            Alignment       =   2  'Center
            Caption         =   "Right"
            BeginProperty Font 
               Name            =   "Tahoma"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   3960
            TabIndex        =   25
            Top             =   4560
            Width           =   975
         End
         Begin VB.Label Label19 
            Alignment       =   1  'Right Justify
            Caption         =   "High:"
            BeginProperty Font 
               Name            =   "Tahoma"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   360
            TabIndex        =   24
            Top             =   4920
            Width           =   735
         End
         Begin VB.Label Label20 
            Alignment       =   1  'Right Justify
            Caption         =   "Low:"
            BeginProperty Font 
               Name            =   "Tahoma"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   360
            TabIndex        =   23
            Top             =   5400
            Width           =   735
         End
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
         Caption         =   "Road ID:"
         Height          =   255
         Left            =   120
         TabIndex        =   48
         Top             =   480
         Width           =   855
      End
   End
End
Attribute VB_Name = "frmPasteRoadAttributes"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False


'~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
'    Thad Tilton  October 31st, 2003
'-------Code for editing road features (SanGIS)--------
'    Thad@TiltonGIS.com
'    1.888.3-Tilton
'~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Option Explicit
Private m_pMXDoc As IMxDocument
Private m_pRoadFC As IFeatureClass 'module variable to reference the Roads dataset
Private m_pRoadOIDs As IEnumIDs  'module variable to contain the currently selected road features (FIDs)
Private m_intCurrentOID As Long 'variable containing the current feature ID
Private m_pCurrentFeature As IFeature 'variable to track the currently highlighted feature
'--module variables for the road table field indices
Private m_intRoadSegIDFld As Integer
Private m_intRoadIDFld As Integer
Private m_intDedStatFld As Integer
Private m_intLJurisFld As Integer
Private m_intRJurisFld As Integer
Private m_intSegStatFld As Integer
Private m_intSegClassFld As Integer
Private m_intFunClassFld As Integer
Private m_intCartoFld As Integer
Private m_intOBMHFld As Integer
Private m_intFireDrivFld As Integer
Private m_intOneWayFld As Integer
Private m_intLMixAddrFld As Integer
Private m_intRMixAddrFld As Integer
Private m_intAddHLFld As Integer
Private m_intAddLLFld As Integer
Private m_intAddHRFld As Integer
Private m_intAddLRFld As Integer
Private m_intRightwayFld As Integer
Private m_intTravelwayFld As Integer
Private m_intSpeedFld As Integer
Private m_intL_ZipFld As Integer
Private m_intR_ZipFld As Integer
'--dictionaries to contain the attribute domain values
Private m_dctDedStat As Scripting.Dictionary
Private m_dctLJuris As Scripting.Dictionary
Private m_dctRJuris As Scripting.Dictionary
Private m_dctSegStat As Scripting.Dictionary
Private m_dctFunClass As Scripting.Dictionary
Private m_dctFireDriv As Scripting.Dictionary
Private m_dctSegClass As Scripting.Dictionary
Private m_dctCarto As Scripting.Dictionary
Private m_dctOBMH As Scripting.Dictionary
Private m_dctZIP As Scripting.Dictionary
Private m_dctYesNo As Scripting.Dictionary
'-variant array of unique Road IDs (from RoadName table)
Private m_vRoadIDs As Variant
Const c_sModuleFileName As String = "\\nas1\home\ClassExtensions\ArcMapTools\Roads\Paste\Form1.frm"


Private Sub cboCarto_Click()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "cboCarto_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cboDedStat_Click()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "cboDedStat_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cboFireDriv_Click()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "cboFireDriv_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cboFunClass_Click()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "cboFunClass_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cboL_Zip_Change()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError False, "cboL_Zip_Change " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cboLJurisdic_Click()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "cboLJurisdic_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cboLMixAddr_Click()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "cboLMixAddr_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cboOBMH_Click()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "cboOBMH_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cboOneWay_Click()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "cboOneWay_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cboR_Zip_Change()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError False, "cboR_Zip_Change " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cboRJurisdic_Click()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "cboRJurisdic_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cboRMixAddr_Click()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "cboRMixAddr_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cboRoadIDs_Change()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "cboRoadIDs_Change " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cboRoadIDs_Click()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "cboRoadIDs_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cboSegClass_Change()
  On Error GoTo ErrorHandler

Select Case cboSegClass.Text
Case "Freeway/Expressway"
    txtSpeed.Text = "50"
Case "Highway/State Route"
    txtSpeed.Text = "45"
Case "Minor Highway/Major Road"
    txtSpeed.Text = "35"
Case "Arterial or Collector"
    txtSpeed.Text = "35"
Case "Local Street"
    txtSpeed.Text = "20"
Case "Unpaved Road"
    txtSpeed.Text = "8"
Case "Private Road"
    txtSpeed.Text = "10"
Case "Freeway Tramsition Ramp"
    txtSpeed.Text = "40"
Case "Freeway On/Off Ramp"
    txtSpeed.Text = "18"
Case "Alley"
    txtSpeed.Text = "10"
Case "Speed Hump"
    txtSpeed.Text = "5"
Case "Military Street Within Base"
    txtSpeed.Text = "15"
Case "Paper Street"
    txtSpeed.Text = "0"
Case "Walkway"
    txtSpeed.Text = "0"
Case Else
    txtSpeed.Text = "0"
End Select
frmPasteRoadAttributes.Refresh
    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "cboSegClass_Change " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cboSegClass_Click()
  On Error GoTo ErrorHandler

Select Case cboSegClass.Text
Case "Freeway/Expressway"
    txtSpeed.Text = "50"
Case "Highway/State Route"
    txtSpeed.Text = "45"
Case "Minor Highway/Major Road"
    txtSpeed.Text = "35"
Case "Arterial or Collector"
    txtSpeed.Text = "35"
Case "Local Street"
    txtSpeed.Text = "20"
Case "Unpaved Road"
    txtSpeed.Text = "8"
Case "Private Road"
    txtSpeed.Text = "10"
Case "Freeway Tramsition Ramp"
    txtSpeed.Text = "40"
Case "Freeway On/Off Ramp"
    txtSpeed.Text = "18"
Case "Alley"
    txtSpeed.Text = "10"
Case "Speed Hump"
    txtSpeed.Text = "5"
Case "Military Street Within Base"
    txtSpeed.Text = "15"
Case "Paper Street"
    txtSpeed.Text = "0"
Case "Walkway"
    txtSpeed.Text = "0"
Case Else
    txtSpeed.Text = "0"
End Select
frmPasteRoadAttributes.Refresh
    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "cboSegClass_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub


Private Sub cmdClose_Click()
  On Error GoTo ErrorHandler

    DeleteGraphicByName "RoadGraphic"
    m_pMXDoc.ActiveView.PartialRefresh esriViewGraphics, Nothing, m_pMXDoc.ActiveView.Extent
    Unload Me


  Exit Sub
ErrorHandler:
  HandleError True, "cmdClose_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cmdGetUniqueRoadIDs_Click()
  On Error GoTo ErrorHandler

   Dim pRoadNameTable As ITable, pRoadNameCursor As ICursor, pDS As IDataset, pFWS As IFeatureWorkspace, pMouseCursor As MouseCursor
    Dim pData As IDataStatistics
    Dim pEnumVals As IEnumVariantSimple
    Dim vVal As Variant, rs As New ADODB.Recordset, vValueArray As Variant, vUniqueVals() As Variant
    Dim i As Long
    rs.Fields.Append "ROAD_ID", adDouble
    rs.Open
'-get an array of unique road IDs from the RoadName table
    '-first, set the mouse cursor to the "hourglass" (this might take a while!)
    Set pMouseCursor = New MouseCursor
    pMouseCursor.SetCursor 2
    '-set required variables to get the Roadname table
    Set pDS = m_pRoadFC  'QI
    Set pFWS = pDS.Workspace
    Set pRoadNameTable = pFWS.OpenTable("t.ROADNAME")
    Set pRoadNameCursor = pRoadNameTable.Search(Nothing, True)
    
    Set pData = New DataStatistics
    pData.field = "ROAD_ID"
    Set pData.Cursor = pRoadNameCursor
    Set pEnumVals = pData.UniqueValues
    vVal = pEnumVals.Next
    Do Until IsEmpty(vVal)
        rs.AddNew
        rs.Fields(0) = vVal
        rs.Update
        vVal = pEnumVals.Next
    Loop
    
    rs.Sort = "ROAD_ID"
    rs.MoveFirst
    vValueArray = rs.GetRows(-1, adBookmarkFirst) 'Returns a 2d array Fieldname,Value
    Dim temp As Long
    temp = rs.RecordCount - 1
    ReDim vUniqueVals(temp)
    
    For i = 0 To rs.RecordCount - 1
            vUniqueVals(i) = vValueArray(0, i)
            cboRoadIDs.AddItem vUniqueVals(i)
    Next i


  Exit Sub
ErrorHandler:
  HandleError True, "cmdGetUniqueRoadIDs_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cmdNext_Click()
  On Error GoTo ErrorHandler

Dim iTrack As Integer
MsgBox iTrack
iTrack = iTrack + 1

'Before moving on to the next segment, make sure there are no edits to save
    If cmdSave.Enabled = True Then
    '-if there have been edits made, see if the user wants to discard them
        If (MsgBox("Move to the next feature without saving edits?", vbYesNo, "Edit Attributes") = vbNo) Then Exit Sub
    End If
    '-get the next OID in the enum, get the corresponding feature, then highlight it on the display
    m_intCurrentOID = m_pRoadOIDs.Next
    If m_intCurrentOID < 0 Then ' "-1" is returned when the enum is empty
        m_pRoadOIDs.Reset 'move back to the top
        m_intCurrentOID = m_pRoadOIDs.Next
    End If
MsgBox iTrack
iTrack = iTrack + 1
    '-use the OID to get the feature, highlight it ...
    Set m_pCurrentFeature = m_pRoadFC.GetFeature(m_intCurrentOID)
    '-fill the form controls with attributes for the current feature
MsgBox iTrack
iTrack = iTrack + 1
    FillFormControls
MsgBox iTrack
iTrack = iTrack + 1
    DeleteGraphicByName "RoadGraphic"
MsgBox iTrack
iTrack = iTrack + 1
    HighlightRoad
MsgBox iTrack
iTrack = iTrack + 1
    '-disable the save button (until a change is made)
    cmdSave.Enabled = False


  Exit Sub
ErrorHandler:
  HandleError True, "cmdNext_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cmdSave_Click()
  On Error GoTo ErrorHandler

'-Write the new info to the current feature's attribute table
    WriteRoadEdits
    '-disable the save button again (until a change is made)
    cmdSave.Enabled = False


  Exit Sub
ErrorHandler:
  HandleError True, "cmdSave_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub cmdShowHide_Click()
  On Error GoTo ErrorHandler

'This button will toggle the visibility of the attribute controls on the form
    If cmdShowHide.Caption = "Show Attributes" Then
        cmdShowHide.Caption = "Hide Attributes"
        Me.Height = 400
    Else
        cmdShowHide.Caption = "Show Attributes"
        Me.Height = 73
    End If


  Exit Sub
ErrorHandler:
  HandleError True, "cmdShowHide_Click " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub Form_Activate()
  On Error GoTo ErrorHandler

'when the form initially launches, highlight the first road on the map (with a line graphic)
    '-move the pointer above the first OID in the enum
    m_pRoadOIDs.Reset

    '-get the first OID
    m_intCurrentOID = m_pRoadOIDs.Next

    If m_intCurrentOID < 0 Then
        MsgBox "no Object Id's found", vbCritical, frmPasteRoadAttributes
        Exit Sub 'when no ID is found in the enum, -1 is returned
    End If
    '-get a feature using it's OID
    Set m_pCurrentFeature = m_pRoadFC.GetFeature(m_intCurrentOID)
    '-get the index positions for all attribute fields
    GetFieldIndices
    '-call a function that returns each field's domain values
    Set m_dctDedStat = GetDomainValues(m_pRoadFC, RD_DEDSTAT_FLD_NAME)
    Set m_dctLJuris = GetDomainValues(m_pRoadFC, RD_LJURIS_FLD_NAME)
    Set m_dctRJuris = GetDomainValues(m_pRoadFC, RD_RJURIS_FLD_NAME)
    Set m_dctSegStat = GetDomainValues(m_pRoadFC, RD_SEGSTAT_FLD_NAME)
    Set m_dctFunClass = GetDomainValues(m_pRoadFC, RD_FUNCLASS_FLD_NAME)
    Set m_dctSegClass = GetDomainValues(m_pRoadFC, RD_SEGCLASS_FLD_NAME)
    Set m_dctCarto = GetDomainValues(m_pRoadFC, RD_CARTO_FLD_NAME)
    Set m_dctOBMH = GetDomainValues(m_pRoadFC, RD_OBMH_FLD_NAME)
    Set m_dctZIP = GetDomainValues(m_pRoadFC, RD_L_ZIP_FLD_NAME)
    Set m_dctFireDriv = GetDomainValues(m_pRoadFC, RD_FIREDRIV_FLD_NAME)
    Set m_dctYesNo = m_dctOBMH 'generic yes/no domain
    m_vRoadIDs = Array("")
    '-call a sub that will fill the form controls with values for the current feature (segment)
    FillFormControls
    '-disable the save button (until a change is made)
    cmdSave.Enabled = False
    '-call a sub that will highlight the segment currently being edited (with a red line graphic)
    HighlightRoad


  Exit Sub
ErrorHandler:
  HandleError True, "Form_Activate " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub Form_Initialize()
  On Error GoTo ErrorHandler

Me.Height = 73


  Exit Sub
ErrorHandler:
  HandleError True, "Form_Initialize " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub Form_Load()
  On Error GoTo ErrorHandler




  Exit Sub
ErrorHandler:
  HandleError True, "Form_Load " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
  On Error GoTo ErrorHandler

 'When the user tries to close the form, make sure there are no outstanding edits
    If cmdSave.Enabled = True Then
        If (MsgBox("Close without saving edits?", vbYesNo, "Edit Attributes") = vbNo) Then
            Cancel = 1
        End If
    End If



  Exit Sub
ErrorHandler:
  HandleError True, "Form_QueryUnload " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub Form_Terminate()
  On Error GoTo ErrorHandler

Dim pMxApp As IMxApplication
    Set m_pMXDoc = Nothing
    Set m_pRoadFC = Nothing
    Set m_pRoadOIDs = Nothing
    Set m_pCurrentFeature = Nothing
    Set m_dctCarto = Nothing
    Set m_dctDedStat = Nothing
    Set m_dctFunClass = Nothing
    Set m_dctLJuris = Nothing
    Set m_dctRJuris = Nothing
    Set m_dctOBMH = Nothing
    Set m_dctSegClass = Nothing
    Set m_dctSegStat = Nothing
    Set m_dctYesNo = Nothing

    DeleteGraphicByName "RoadGraphic"
    m_pMXDoc.ActiveView.Refresh


  Exit Sub
ErrorHandler:
  HandleError True, "Form_Terminate " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub txtAddHL_Change()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "txtAddHL_Change " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub txtAddrHR_Change()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "txtAddrHR_Change " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub txtAddrLL_Change()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "txtAddrLL_Change " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub txtAddrLR_Change()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "txtAddrLR_Change " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub txtRightway_Change()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "txtRightway_Change " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub txtSpeed_Change()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "txtSpeed_Change " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub txtTravelWay_Change()
  On Error GoTo ErrorHandler

    Enabler


  Exit Sub
ErrorHandler:
  HandleError True, "txtTravelWay_Change " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub UserForm_Activate()
  On Error GoTo ErrorHandler

    'when the form initially launches, highlight the first road on the map (with a line graphic)
    '-move the pointer above the first OID in the enum
    m_pRoadOIDs.Reset

    '-get the first OID
    m_intCurrentOID = m_pRoadOIDs.Next

    If m_intCurrentOID < 0 Then
        MsgBox "no Object Id's found", vbCritical, frmPasteRoadAttributes
        Exit Sub 'when no ID is found in the enum, -1 is returned
    End If
    '-get a feature using it's OID
    Set m_pCurrentFeature = m_pRoadFC.GetFeature(m_intCurrentOID)
    '-get the index positions for all attribute fields
    GetFieldIndices
    '-call a function that returns each field's domain values
    Set m_dctDedStat = GetDomainValues(m_pRoadFC, RD_DEDSTAT_FLD_NAME)
    Set m_dctLJuris = GetDomainValues(m_pRoadFC, RD_LJURIS_FLD_NAME)
    Set m_dctRJuris = GetDomainValues(m_pRoadFC, RD_RJURIS_FLD_NAME)
    Set m_dctSegStat = GetDomainValues(m_pRoadFC, RD_SEGSTAT_FLD_NAME)
    Set m_dctFunClass = GetDomainValues(m_pRoadFC, RD_FUNCLASS_FLD_NAME)
    Set m_dctSegClass = GetDomainValues(m_pRoadFC, RD_SEGCLASS_FLD_NAME)
    Set m_dctCarto = GetDomainValues(m_pRoadFC, RD_CARTO_FLD_NAME)
    Set m_dctOBMH = GetDomainValues(m_pRoadFC, RD_OBMH_FLD_NAME)
    Set m_dctZIP = GetDomainValues(m_pRoadFC, RD_L_ZIP_FLD_NAME)
    Set m_dctFireDriv = GetDomainValues(m_pRoadFC, RD_FIREDRIV_FLD_NAME)
    Set m_dctYesNo = m_dctOBMH 'generic yes/no domain
    m_vRoadIDs = Array("")
    '-call a sub that will fill the form controls with values for the current feature (segment)
    FillFormControls
    '-disable the save button (until a change is made)
    cmdSave.Enabled = False
    '-call a sub that will highlight the segment currently being edited (with a red line graphic)
    HighlightRoad


  Exit Sub
ErrorHandler:
  HandleError False, "UserForm_Activate " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Public Property Set Roads(ids As IEnumIDs)
  On Error GoTo ErrorHandler

    '-this property will be set before the form is opened so the user can scroll thru all selected roads on the map
    Set m_pRoadOIDs = ids


  Exit Property
ErrorHandler:
  HandleError True, "Roads " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Property

Public Property Set RoadDataset(fc As IFeatureClass)
  On Error GoTo ErrorHandler

    '-this property will be set before the form is opened so the user can scroll thru all selected roads on the map
    Set m_pRoadFC = fc


  Exit Property
ErrorHandler:
  HandleError True, "RoadDataset " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Property

Private Sub HighlightRoad()
  On Error GoTo ErrorHandler

'This sub will draw a red line graphic to highlight the road that is currently being edited
    Dim pElem As IElement
    Set pElem = MakeRoadGraphic(m_pCurrentFeature.ShapeCopy)
    m_pMXDoc.ActiveView.GraphicsContainer.AddElement pElem, 0
    m_pMXDoc.ActiveView.PartialRefresh esriViewGraphics, Nothing, m_pMXDoc.ActiveView.Extent


  Exit Sub
ErrorHandler:
  HandleError False, "HighlightRoad " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub UserForm_Initialize()
  On Error GoTo ErrorHandler

    Me.Height = 73


  Exit Sub
ErrorHandler:
  HandleError False, "UserForm_Initialize " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub WriteRoadEdits()
'This sub will write all the info provided on the form to the attribute table for the current feature
On Error GoTo EH
    Dim strErrorMsg As String, bIDisOK As Boolean, vVal As Variant
    '-get each value from the form's combo boxes, update the current feature's attributes
'--RoadID
    strErrorMsg = "Invalid RoadID (value not found in the RoadName table)"
    bIDisOK = VerifyRoadID(CLng(cboRoadIDs.Text))
    If Not bIDisOK Then GoTo EH
    strErrorMsg = "?"
    m_pCurrentFeature.value(m_intRoadIDFld) = CLng(cboRoadIDs.Text)
'--Address Range
    strErrorMsg = "Invalid address range value"
    vVal = CLng(txtAddHL.Text)
    m_pCurrentFeature.value(m_intAddHLFld) = vVal
    vVal = CLng(txtAddrHR.Text)
    m_pCurrentFeature.value(m_intAddHRFld) = vVal
    vVal = CLng(txtAddrLL.Text)
    m_pCurrentFeature.value(m_intAddLLFld) = vVal
    vVal = CLng(txtAddrLR.Text)
    m_pCurrentFeature.value(m_intAddLRFld) = vVal
    strErrorMsg = "?"
'--Carto
    vVal = m_dctCarto.Item(cboCarto.Text)
    If IsNull(vVal) Then
        strErrorMsg = "Null value for Carto"
        GoTo EH
    End If
    m_pCurrentFeature.value(m_intCartoFld) = vVal
'--DedStat
    vVal = m_dctDedStat.Item(cboDedStat.Text)
    If IsNull(vVal) Then
        strErrorMsg = "Null value for DedStat"
        GoTo EH
    End If
    m_pCurrentFeature.value(m_intDedStatFld) = vVal
'--FunClass
    vVal = m_dctFunClass.Item(cboFunClass.Text)
    If IsNull(vVal) Then
        strErrorMsg = "Null value for FunClass"
        GoTo EH
    End If
    m_pCurrentFeature.value(m_intFunClassFld) = vVal
'--LJuris
    vVal = m_dctLJuris.Item(cboLJurisdic.Text)
    If IsNull(vVal) Then
        strErrorMsg = "Null value for LJuris"
        GoTo EH
    End If
    m_pCurrentFeature.value(m_intLJurisFld) = vVal
'--RJuris
    vVal = m_dctRJuris.Item(cboRJurisdic.Text)
    If IsNull(vVal) Then
        strErrorMsg = "Null value for RJuris"
        GoTo EH
    End If
    m_pCurrentFeature.value(m_intRJurisFld) = vVal
'--SegClass
    vVal = m_dctSegClass.Item(cboSegClass.Text)
    If IsNull(vVal) Then
        strErrorMsg = "Null value for SegClass"
        GoTo EH
    End If
    m_pCurrentFeature.value(m_intSegClassFld) = vVal
'--SegStat
    vVal = m_dctSegStat.Item(cboSegStat.Text)
    If IsNull(vVal) Then
        strErrorMsg = "Null value for SegStat"
        GoTo EH
    End If
    m_pCurrentFeature.value(m_intSegStatFld) = vVal
'--FireDriv
    vVal = m_dctFireDriv.Item(cboFireDriv.Text)
    If IsNull(vVal) Then
        strErrorMsg = "Null value for FireDriv"
        GoTo EH
    End If
    m_pCurrentFeature.value(m_intFireDrivFld) = vVal
'--OneWay
    vVal = m_dctYesNo.Item(cboOneWay.Text)
    If IsNull(vVal) Then
        strErrorMsg = "Null value for OneWay"
        GoTo EH
    End If
    m_pCurrentFeature.value(m_intOneWayFld) = vVal
'--L_ZIP
    vVal = m_dctZIP.Item(cboL_Zip.Text)
    If IsNull(vVal) Then
        strErrorMsg = "Null value for L_ZIP"
        GoTo EH
    End If
    m_pCurrentFeature.value(m_intL_ZipFld) = vVal
'--R_ZIP
    vVal = m_dctZIP.Item(cboR_Zip.Text)
    If IsNull(vVal) Then
        strErrorMsg = "Null value for R_ZIP"
        GoTo EH
    End If
    m_pCurrentFeature.value(m_intR_ZipFld) = vVal

'--Rightway
    m_pCurrentFeature.value(m_intRightwayFld) = CLng(txtRightway.Text)
''--Travlway
'821:     m_pCurrentFeature.value(m_intTravelwayFld) = CLng(txtTravelWay.Text)
'--Speed
    m_pCurrentFeature.value(m_intSpeedFld) = CLng(txtSpeed.Text)

    m_pCurrentFeature.Store
    Exit Sub
EH:
    If strErrorMsg = "?" Then
        MsgBox "Error when attempting to save road edits." & vbCr & Err.Description, vbCritical, "Road Edit"
    Else
        MsgBox strErrorMsg, vbCritical, "Edit Attributes"
    End If
End Sub

Private Sub FillFormControls()
  On Error GoTo ErrorHandler
'MsgBox "made it as far as Fillformcontrolls"
'This sub will fill the form's controls with attribute info for the current segment (seg1 or seg2)
    '-variant (array) variables to hold the domain values
    Dim vDedStat As Variant, vLJuris As Variant, vRJuris As Variant, vSegStat As Variant, vFunClass As Variant
    Dim vSegClass As Variant, vCarto As Variant, vOBMH As Variant, vYesNo As Variant, vL_Zip As Variant, vR_Zip As Variant
    Dim dtFeature As RoadFeature, vVal As Variant, vFireDriv As Variant
    Dim intFrameTextColor As OLE_COLOR, strFrameCaption As String
    Dim strSaveBtnCaption As String, strNextBtnCaption As String
    '-initialize variant array variables

    vDedStat = Array("")
    vLJuris = Array("")
    vRJuris = Array("")
    vSegStat = Array("")
    vFunClass = Array("")
    vSegClass = Array("")
    vCarto = Array("")
    vOBMH = Array("")
    vL_Zip = Array("")
    vR_Zip = Array("")
    vFireDriv = Array("")
    vYesNo = Array("") 'generic Yes/No domain (used on several fields)

    strFrameCaption = "Segment ID: " & m_pCurrentFeature.value(m_intRoadSegIDFld)
    '-get the keys from the domain dictionaries, put them in the array variables
    If Not m_dctDedStat Is Nothing Then vDedStat = m_dctDedStat.Keys
    If Not m_dctLJuris Is Nothing Then vLJuris = m_dctLJuris.Keys
    If Not m_dctRJuris Is Nothing Then vRJuris = m_dctRJuris.Keys
    If Not m_dctSegStat Is Nothing Then vSegStat = m_dctSegStat.Keys
    If Not m_dctFunClass Is Nothing Then vFunClass = m_dctFunClass.Keys
    If Not m_dctSegClass Is Nothing Then vSegClass = m_dctSegClass.Keys
    If Not m_dctFireDriv Is Nothing Then vFireDriv = m_dctFireDriv.Keys
    If Not m_dctCarto Is Nothing Then vCarto = m_dctCarto.Keys
    If Not m_dctOBMH Is Nothing Then vOBMH = m_dctOBMH.Keys
    If Not m_dctYesNo Is Nothing Then vYesNo = m_dctYesNo.Keys
    If Not m_dctZIP Is Nothing Then vL_Zip = m_dctZIP.Keys
    If Not m_dctZIP Is Nothing Then vR_Zip = m_dctZIP.Keys

    '-fill the form's combo boxes with the array values
    Dim i As Integer
    
    For i = 0 To UBound(vDedStat)
        cboDedStat.AddItem vDedStat(i)
    Next i
    
    For i = 0 To UBound(vLJuris)
        cboLJurisdic.AddItem vLJuris(i)
    Next i
    
    For i = 0 To UBound(vRJuris)
        cboRJurisdic.AddItem vRJuris(i)
    Next i

    For i = 0 To UBound(vSegStat)
        cboSegStat.AddItem vSegStat(i)
    Next i
    
    For i = 0 To UBound(vFunClass)
        cboFunClass.AddItem vFunClass(i)
    Next i
    
    For i = 0 To UBound(vSegClass)
        cboSegClass.AddItem vSegClass(i)
    Next i
    
    For i = 0 To UBound(vCarto)
         cboCarto.AddItem vCarto(i)
    Next i
    
    For i = 0 To UBound(vL_Zip)
        cboL_Zip.AddItem vL_Zip(i)
    Next i
    
    For i = 0 To UBound(vR_Zip)
        cboR_Zip.AddItem vR_Zip(i)
    Next i
    
    For i = 0 To UBound(vFireDriv)
        cboFireDriv.AddItem vFireDriv(i)
    Next i
    
    '-yes/no fields
    For i = 0 To UBound(vYesNo)
        cboOneWay.AddItem vYesNo(i)
     Next i
    
    For i = 0 To UBound(vYesNo)
        cboLMixAddr.AddItem vYesNo(i)
    Next i
    
    For i = 0 To UBound(vYesNo)
        cboRMixAddr.AddItem vYesNo(i)
    Next i
    
    For i = 0 To UBound(vYesNo)
        cboOBMH.AddItem vYesNo(i)
    Next i


    '-put the current RoadID into the form's combo box
    vVal = m_pCurrentFeature.value(m_intRoadIDFld)
    If Not IsNull(vVal) Then
        If (cboRoadIDs.ListCount < 1) Then cboRoadIDs.AddItem vVal
        cboRoadIDs.Text = vVal
    End If
    '-put the current values into the form controls
    '-get corresponding domain descriptions from the dictionary
    Dim strTest As String
    strTest = GetDictionaryKeyForItem(m_dctDedStat, m_pCurrentFeature.value(m_intDedStatFld))
    'MsgBox "GetDictionaryKeyForItem = " & strTest
    cboCarto.Text = GetDictionaryKeyForItem(m_dctCarto, m_pCurrentFeature.value(m_intCartoFld))
    cboDedStat.Text = GetDictionaryKeyForItem(m_dctDedStat, m_pCurrentFeature.value(m_intDedStatFld))
    cboFunClass.Text = GetDictionaryKeyForItem(m_dctFunClass, m_pCurrentFeature.value(m_intFunClassFld))
    cboLJurisdic.Text = GetDictionaryKeyForItem(m_dctLJuris, m_pCurrentFeature.value(m_intLJurisFld))
    cboRJurisdic.Text = GetDictionaryKeyForItem(m_dctRJuris, m_pCurrentFeature.value(m_intRJurisFld))
    cboSegClass.Text = GetDictionaryKeyForItem(m_dctSegClass, m_pCurrentFeature.value(m_intSegClassFld))
    cboSegStat.Text = GetDictionaryKeyForItem(m_dctSegStat, m_pCurrentFeature.value(m_intSegStatFld))
    cboFireDriv.Text = GetDictionaryKeyForItem(m_dctFireDriv, m_pCurrentFeature.value(m_intFireDrivFld))
    cboL_Zip.Text = GetDictionaryKeyForItem(m_dctZIP, m_pCurrentFeature.value(m_intL_ZipFld))
    cboR_Zip.Text = GetDictionaryKeyForItem(m_dctZIP, m_pCurrentFeature.value(m_intR_ZipFld))



    '-simply get the current field values for the text boxes and
'    vVal = m_pCurrentFeature.Value(m_intFireDrivFld)
'    If Not IsNull(vVal) Then cboFireDriv.Text = vVal
'    vVal = m_pCurrentFeature.Value(m_intOneWayFld)
'    If Not IsNull(vVal) Then cboOneWay.Text = vVal
'    vVal = m_pCurrentFeature.Value(m_intOBMHFld)
'    If Not IsNull(vVal) Then cboOBMH.Text = vVal
'    vVal = m_pCurrentFeature.Value(m_intLMixAddrFld)
'    If Not IsNull(vVal) Then cboLMixAddr.Text = vVal
'    vVal = m_pCurrentFeature.Value(m_intRMixAddrFld)
'    If Not IsNull(vVal) Then cboRMixAddr.Text = vVal
'    vVal = m_pCurrentFeature.Value(m_intSegStatFld)
'    If Not IsNull(vVal) Then cboSegStat.Text = vVal
'    vVal = m_pCurrentFeature.Value(m_intCartoFld)
'    If Not IsNull(vVal) Then cboCarto.Text = vVal
'    vVal = m_pCurrentFeature.Value(m_intFunClassFld)
'    If Not IsNull(vVal) Then cboFunClass.Text = vVal
'    vVal = m_pCurrentFeature.Value(m_intDedStatFld)
'    If Not IsNull(vVal) Then cboDedStat.Text = vVal
'    vVal = m_pCurrentFeature.Value(m_intSegClassFld)
'    If Not IsNull(vVal) Then cboSegClass.Text = vVal

    vVal = m_pCurrentFeature.value(m_intAddHLFld)
    If Not IsNull(vVal) Then txtAddHL.Text = vVal
    vVal = m_pCurrentFeature.value(m_intAddHRFld)
    If Not IsNull(vVal) Then txtAddrHR.Text = vVal
    vVal = m_pCurrentFeature.value(m_intAddLLFld)
    If Not IsNull(vVal) Then txtAddrLL.Text = vVal
    vVal = m_pCurrentFeature.value(m_intAddLRFld)
    If Not IsNull(vVal) Then txtAddrLR.Text = vVal
    vVal = m_pCurrentFeature.value(m_intRightwayFld)
    If Not IsNull(vVal) Then txtRightway.Text = vVal
    vVal = m_pCurrentFeature.value(m_intTravelwayFld)
    If Not IsNull(vVal) Then txtTravelWay.Text = vVal
    vVal = m_pCurrentFeature.value(m_intSpeedFld)
    If Not IsNull(vVal) Then txtSpeed.Text = vVal

    '-set the frame's caption to identify the current segment
    fmeSegInfo.Caption = strFrameCaption


  Exit Sub
ErrorHandler:
  HandleError False, "FillFormControls " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub GetFieldIndices()
  On Error GoTo ErrorHandler

'This sub will find all required field indices for the road attribute table
    Dim pFlds As IFields
    Set pFlds = m_pRoadFC.Fields
    '-field name constants are defined in the "Globals" module
    m_intCartoFld = pFlds.FindField(RD_CARTO_FLD_NAME)
    m_intDedStatFld = pFlds.FindField(RD_DEDSTAT_FLD_NAME)
    m_intFunClassFld = pFlds.FindField(RD_FUNCLASS_FLD_NAME)
    m_intLJurisFld = pFlds.FindField(RD_LJURIS_FLD_NAME)
    m_intRJurisFld = pFlds.FindField(RD_RJURIS_FLD_NAME)
    m_intOBMHFld = pFlds.FindField(RD_OBMH_FLD_NAME)
    m_intSegStatFld = pFlds.FindField(RD_SEGSTAT_FLD_NAME)
    m_intFireDrivFld = pFlds.FindField(RD_FIREDRIV_FLD_NAME)
    m_intOneWayFld = pFlds.FindField(RD_ONEWAY_FLD_NAME)
    m_intSegClassFld = pFlds.FindField(RD_SEGCLASS_FLD_NAME)
    m_intLMixAddrFld = pFlds.FindField(RD_LMIXADDR_FLD_NAME)
    m_intRMixAddrFld = pFlds.FindField(RD_RMIXADDR_FLD_NAME)
    m_intRoadSegIDFld = pFlds.FindField(RD_ROADSEGID_FLD_NAME)
    m_intRoadIDFld = pFlds.FindField(RD_ROADID_FLD_NAME)
    m_intAddHLFld = pFlds.FindField(RD_LHIGHADDR_FLD_NAME)
    m_intAddLLFld = pFlds.FindField(RD_LLOWADDR_FLD_NAME)
    m_intAddHRFld = pFlds.FindField(RD_RHIGHADDR_FLD_NAME)
    m_intAddLRFld = pFlds.FindField(RD_RLOWADDR_FLD_NAME)
    m_intRightwayFld = pFlds.FindField(RD_RIGHTWAY_FLD_NAME)
'1032:     m_intTravelwayFld = pFlds.FindField(RD_TRAVLWAY_FLD_NAME)
    m_intSpeedFld = pFlds.FindField(RD_SPEED_FLD_NAME)
    m_intL_ZipFld = pFlds.FindField(RD_L_ZIP_FLD_NAME)
    m_intR_ZipFld = pFlds.FindField(RD_R_ZIP_FLD_NAME)



  Exit Sub
ErrorHandler:
  HandleError False, "GetFieldIndices " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub UserForm_QueryClose(Cancel As Integer, CloseMode As Integer)
  On Error GoTo ErrorHandler

    'When the user tries to close the form, make sure there are no outstanding edits
    If cmdSave.Enabled = True Then
        If (MsgBox("Close without saving edits?", vbYesNo, "Edit Attributes") = vbNo) Then
            Cancel = 1
        End If
    End If


  Exit Sub
ErrorHandler:
  HandleError False, "UserForm_QueryClose " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub Enabler()
  On Error GoTo ErrorHandler

'centralized logic to control whether the "Save" button is enabled or not
'called from all (most) controls on the form

'If the RoadID value is -99999 then disable
    If cboRoadIDs.Text = "-99999" Then
        cmdSave.Enabled = False
    Else
        cmdSave.Enabled = True
    End If
    '-if the road ID has not been set with an appropriate value, make the control red
    If cboRoadIDs.Text = "" Or InStr(cboRoadIDs.Text, "-9") > 0 Then
        cboRoadIDs.BackColor = &HC0C0FF 'lite red
    Else
        cboRoadIDs.BackColor = &H80000005 'white
    End If


  Exit Sub
ErrorHandler:
  HandleError False, "Enabler " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Sub UserForm_Terminate()
  On Error GoTo ErrorHandler

    Dim pMxApp As IMxApplication
    Set m_pMXDoc = Nothing
    Set m_pRoadFC = Nothing
    Set m_pRoadOIDs = Nothing
    Set m_pCurrentFeature = Nothing
    Set m_dctCarto = Nothing
    Set m_dctDedStat = Nothing
    Set m_dctFunClass = Nothing
    Set m_dctLJuris = Nothing
    Set m_dctRJuris = Nothing
    Set m_dctOBMH = Nothing
    Set m_dctSegClass = Nothing
    Set m_dctSegStat = Nothing
    Set m_dctYesNo = Nothing

    DeleteGraphicByName "RoadGraphic"
    m_pMXDoc.ActiveView.Refresh


  Exit Sub
ErrorHandler:
  HandleError False, "UserForm_Terminate " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub

Private Function VerifyRoadID(ID As Long) As Boolean
  On Error GoTo ErrorHandler

'This function will check to see if the RoadID entered is valid (it exists in the RoadName table)
    '-set required variables to get the Roadname table
    Dim pDS As IDataset, pFWS As IFeatureWorkspace, pRoadNameTable As ITable
    Dim pRoadNameCursor As ICursor, pQF As IQueryFilter, pRec As IRow
    Set pDS = m_pRoadFC   'QI
    Set pFWS = pDS.Workspace
    '-get the table (constant for the data path name is set in the "Globals" module)
    Set pRoadNameTable = GetDataset(ROAD_NAME_DATASRC, pFWS, esriDTTable)
    '-make a new query filter to find records with the passed in RoadID
    Set pQF = New QueryFilter
    pQF.WhereClause = RDNAME_ROADID_FLD_NAME & " = " & ID
    '-get a cursor of records that have the ID passed in (should be either 1 or 0)
    Set pRoadNameCursor = pRoadNameTable.Search(pQF, True)
    Set pRec = pRoadNameCursor.NextRow
    '-if a record was found, ID is valid, otherwise it is not
    VerifyRoadID = Not pRec Is Nothing


  Exit Function
ErrorHandler:
  HandleError False, "VerifyRoadID " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Function

Public Property Set MapDoc(Map As IMxDocument)
  On Error GoTo ErrorHandler

Set m_pMXDoc = Map


  Exit Property
ErrorHandler:
  HandleError True, "MapDoc " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Property

Public Sub DeleteGraphicByName(ElementName As String)
  On Error GoTo ErrorHandler

'this sub will take the name of a graphic element, loop thru graphics in the map, then delete any that match the given name
    Dim pGC As IGraphicsContainer
    Dim pElem As IElementProperties
    
    Set pGC = m_pMXDoc.FocusMap 'get the map (not deleting graphics from the page layout)
    pGC.Reset
    Set pElem = pGC.Next
    Do Until pElem Is Nothing
        If pElem.Name = ElementName Then
            pGC.DeleteElement pElem
'            Exit Do '*don't exit .... there may be more than one!
        End If
        Set pElem = pGC.Next
    Loop
    'refresh the display
    m_pMXDoc.ActiveView.PartialRefresh esriViewForeground, Nothing, m_pMXDoc.ActiveView.Extent


  Exit Sub
ErrorHandler:
  HandleError True, "DeleteGraphicByName " & c_sModuleFileName & " " & GetErrorLineNumberString(Erl), Err.Number, Err.Source, Err.Description, 4
End Sub
