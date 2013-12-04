Attribute VB_Name = "Globals"
Option Explicit
Public Const E_FAIL As Long = -2147467259
Public g_blCancelled As Boolean
' Constant Field Namees
'--Constants for data source names for required datasets
Public Const ROAD_DATASRC As String = "T.Road"
Public Const ROAD_NAME_DATASRC As String = "T.ROADNAME"
Public Const ADDRESS_DATASRC As String = "T.AddressPoint"
Public Const ROAD_ALIAS_DATASRC As String = "T.ROADSEG_ALIAS"
Public Const PARCEL_DATASRC As String = "T.Parcel"
Public Const MUNICIPAL_DATASRC As String = "T.MUNICIPAL"
Public Const APN_ATR_DATASRC As String = "T.APN_ATR"
Public Const IC_INTERSECTION_DATASRC As String = "T.ADMATCH_INTERSECTION"
Public Const LOT_DATASRC As String = "T.Lot"
Public Const SUBDIVISION_DATASRC As String = "T.Subdivision"
Public Const ZIPCODE_DATASRC As String = "T.zipcode"
Public Const RECONCILE_LOG_TABLE As String = "T.RECONCILE_LOG"
Public Const SUBDIV_ATR_DATASRC As String = "T.SUBDIV_ATR"
Public Const EASEMENT_DATASRC As String = "T.Easements"
Public Const ROW_DATASRC As String = "T.Right_Of_Way_ATR"
Public Const ROADSEG_ALIAS_DATASRC As String = "T.ROADSEG_ALIAS"
Public Const INTERSECTION_DATASRC As String = "T.INTERSECTION"
Public Const BOUND_DATASRC As String = "T.Boundary"
Public Const Anno_APN_DATASRC As String = "T.Anno_APN"
Public Const Anno_Address_DATASRC As String = "T.ANNO_ADDRESS"
Public Const Anno_Road_DATASRC As String = "T.ANNO_ROADNAME"
Public Const Anno_Block_DATASRC As String = "T.ANNO_BLOCKRANGE"
Public Const JUR_PUB_STY_DATASRC As String = "T.JUR_PUBLIC_SAFETY"
Public Const BOUNDARY_DATASRC As String = "T.Boundary"
Public Const TOPOLOGY_DATASRC As String = "T.Road_Address_Topology"
Public Const RD_GEOM_DATASRC As String = "T.ROAD_GEOMETRY"
Public Const TMSBRS_DATASRC As String = "T.THOMAS_BROTHERS"
Public Const MGRF_DATASRC As String = "T.MGRF"
Public Const LAW_BEAT_DATASRC As String = "T.law_beats"

'--Constants for dataset fields: Road
Public Const RD_FNODE_FLD_NAME As String = "FNODE"
Public Const RD_TNODE_FLD_NAME As String = "TNODE"
Public Const RD_ROADSEGID_FLD_NAME As String = "ROADSEGID"
Public Const RD_ROADID_FLD_NAME As String = "ROADID"
Public Const RD_DEDSTAT_FLD_NAME As String = "DEDSTAT"
Public Const RD_SEGSTAT_FLD_NAME As String = "SEGSTAT"
'Public Const RD_TRAVLWAY_FLD_NAME As String = "TRAVLWAY"
Public Const RD_RIGHTWAY_FLD_NAME As String = "RIGHTWAY"
Public Const RD_FUNCLASS_FLD_NAME As String = "FUNCLASS"
Public Const RD_LJURIS_FLD_NAME As String = "LJURISDIC"
Public Const RD_RJURIS_FLD_NAME As String = "RJURISDIC"
Public Const RD_RMIXADDR_FLD_NAME As String = "RMIXADDR"
Public Const RD_LMIXADDR_FLD_NAME As String = "LMIXADDR"
Public Const RD_CARTO_FLD_NAME As String = "CARTO"
Public Const RD_OBMH_FLD_NAME As String = "OBMH"
Public Const RD_FIREDRIV_FLD_NAME As String = "FIREDRIV"
Public Const RD_ONEWAY_FLD_NAME As String = "ONEWAY"
Public Const RD_SEGCLASS_FLD_NAME As String = "SEGCLASS"
Public Const RD_LENGTH_FLD_NAME As String = "LENGTH"
Public Const RD_LLOWADDR_FLD_NAME As String = "LLOWADDR"
Public Const RD_LHIGHADDR_FLD_NAME As String = "LHIGHADDR"
Public Const RD_RLOWADDR_FLD_NAME As String = "RLOWADDR"
Public Const RD_RHIGHADDR_FLD_NAME As String = "RHIGHADDR"
Public Const RD_ABLOADDR_FLD_NAME As String = "ABLOADDR"
Public Const RD_ABHIADDR_FLD_NAME As String = "ABHIADDR"
Public Const RD_SPEED_FLD_NAME As String = "SPEED"
Public Const RD_L_ZIP_FLD_NAME As String = "L_ZIP"
Public Const RD_R_ZIP_FLD_NAME As String = "R_ZIP"
Public Const RD_LPSJUR_FLD_NAME As String = "LPSJUR"
Public Const RD_RPSJUR_FLD_NAME As String = "RPSJUR"
'--Constants for dataset fields: Intersection
Public Const INTER_INTERID_FLD_NAME As String = "INTERID"
Public Const INTER_DPWNO_FLD_NAME As String = "DPWINTNO"
Public Const INTER_TNODE_FLD_NAME As String = "TNODE"
Public Const INTER_FNODE_FLD_NAME As String = "FNODE"
'--Constants for dataset fields: RoadName table
Public Const RDNAME_ROADID_FLD_NAME As String = "ROAD_ID"
'--Constants for dataset fields: Address points
Public Const ADDR_ROADSEGID_FLD_NAME As String = "ROADSEGID"
Public Const ADDR_ADDRAPNID_FLD_NAME As String = "ADDRAPNID"
Public Const ADDR_POSTID_FLD_NAME As String = "POSTID"
Public Const ADDR_POSTDATE_FLD_NAME As String = "POSTDATE"
Public Const ADDR_APNID_FLD_NAME As String = "APNID"
Public Const ADDR_LOTID_FLD_NAME As String = "LOTID"
Public Const ADDR_ADDRNO_FLD_NAME As String = "ADDRNO"
Public Const ADDR_JUR_FLD_NAME As String = "JURISDIC"
Public Const ADDR_TYPE_FLD_NAME As String = "TYPE"
Public Const ADDR_PLNM_FLD_NAME As String = "PLACENAM"
Public Const ADDR_UNIT_FLD_NAME As String = "ADDRUNIT"
Public Const ADDR_FRAC_FLD_NAME As String = "ADDRFRAC"
Public Const ADDR_X_FLD_NAME As String = "X_COORD"
Public Const ADDR_Y_FLD_NAME As String = "Y_COORD"
Public Const ADDR_SUBTYPE_FLD_NAME As String = "SUB_TYPE"
'--Constants for dataset fields: ADMATCH_Intersection table
Public Const ADMATCH_INTERID_FLD_NAME As String = "INTERID"
'--Constants for dataset fields: Parcel
Public Const PARCEL_PARCELID_FLD_NAME As String = "PARCELID"
Public Const PARCEL_POSTID_FLD_NAME As String = "POSTID"
Public Const PARCEL_POSTDATE_FLD_NAME As String = "POSTDATE"
Public Const PARCEL_X_FLD_NAME As String = "X_COORD"
Public Const PARCEL_Y_FLD_NAME As String = "Y_COORD"
Public Const PARCEL_PENDING_FLD_NAME  As String = "PENDING"
Public Const PARCEL_MULTI_FLD_NAME  As String = "MULTI"
Public Const PARCEL_PARCEL_TYPE_FLD_NAME  As String = "SUB_TYPE"
'--Constants for dataset fields: MUNICIPAL
Public Const MUNI_NAME_FLD_NAME As String = "NAME"
Public Const MUNI_CODE_FLD_NAME As String = "CODE"
'--Constants for dataset fields: Lot
Public Const LOT_POSTID_FLD_NAME As String = "POSTID"
Public Const LOT_POSTDATE_FLD_NAME As String = "POSTDATE"
Public Const LOT_LOTID_FLD_NAME As String = "LOTID"
Public Const LOT_SUBDIVID_FLD_NAME As String = "SUBDIVID"
Public Const LOT_ACRE_FLD_NAME As String = "ACREAGE"
Public Const LOT_LOTNO_FLD_NAME As String = "LOTNO"
Public Const LOT_BLOCKNO_FLD_NAME As String = "BLOCKNO"
Public Const LOT_PEND_FLD_NAME As String = "PENDING"
'--Constants for dataset fields: Subdivision
Public Const SUBDIV_SUBDIVID_FLD_NAME As String = "SUBDIVID"
'--Constants for dataset fields: Zip
Public Const ZIP_FLD_NAME As String = "ZIP"
'--Constants for dataset fields: SUBDIV_ATR
Public Const SUBDIV_ATR_SUBDIVID_FLD_NAME As String = "SUBDIVID"
'--Constants for dataset fields: Easements
Public Const EASE_EASEID_FLD_NAME As String = "EASEID"
Public Const EASE_POSTID_FLD_NAME As String = "POSTID"
Public Const EASE_POSTDATE_FLD_NAME As String = "POSTDATE"
Public Const EASE_TYPE_FLD_NAME As String = "TYPE"
Public Const EASE_JURIS_FLD_NAME As String = "JURISDIC"
Public Const EASE_SUBDIV_FLD_NAME As String = "SUBDIVID"
Public Const EASE_DOCYR_FLD_NAME As String = "DOCYR"
Public Const EASE_DOCNO_FLD_NAME As String = "DOCNO"
Public Const EASE_RECDATE_FLD_NAME As String = "RECDATE"
Public Const EASE_SUBTYPE_FLD_NAME As String = "SUB_TYPE"
'--Constants for dataset fields: APN_ATR
Public Const APN_ATR_PARCELID_FLD_NAME As String = "PARCELID"
Public Const APN_ATR_APNID_FLD_NAME As String = "APNID"
Public Const APN_ATR_POSTID_FLD_NAME As String = "POSTID"
Public Const APN_ATR_POSTDATE_FLD_NAME As String = "POSTDATE"
Public Const APN_ATR_PENDING_FLD_NAME As String = "PENDING"
Public Const APN_ATR_APN_FLD_NAME As String = "APN"
'--Constants for dataset fields: Right_Of_Way_ATR
Public Const ROW_PARCELID_FLD_NAME As String = "PARCELID"
Public Const ROW_POSTID_FLD_NAME As String = "POSTID"
Public Const ROW_POSTDATE_FLD_NAME As String = "POSTDATE"
Public Const ROW_TYPE_FLD_NAME As String = "TYPE"
Public Const ROW_SUBDIVID_FLD_NAME As String = "SUBDIVID"
Public Const ROW_DOCYR_FLD_NAME As String = "DOC_YR"
Public Const ROW_DOCNO_FLD_NAME As String = "DOC_NUM"
Public Const ROW_DDOR_FLD_NAME As String = "DDOR"
Public Const ROW_RECDATE_FLD_NAME As String = "REC_DATE"
Public Const ROW_DRAWING_FLD_NAME As String = "DRAWING"
Public Const ROW_PENDING_FLD_NAME As String = "PENDING"
Public Const ROW_ADDDATE_FLD_NAME As String = "ADDDATE"
Public Const ROW_ADDID_FLD_NAME As String = "ADDID"
'--Constants for dataset fields: reconcile table
Public Const OWNER_FIELDNAME As String = "OWNER"
Public Const NAME_FIELDNAME As String = "NAME"
'--Constants for dataset fields: RoadSeg_Alias
Public Const RDSEG_ALIAS_ROADSEGID_FLD_NAME As String = "ROADSEGID"
Public Const RDSEG_ALIAS_POSTID_FLD_NAME As String = "POSTID"
Public Const RDSEG_ALIAS_POSTDATE_FLD_NAME As String = "POSTDATE"
Public Const RDSEG_ALIAS_PREDIR_FLD_NAME As String = "ALIAS_PREDIR_IND"
Public Const RDSEG_ALIAS_NAME_FLD_NAME As String = "ALIAS_NM"
Public Const RDSEG_ALIAS_SUFFIX_FLD_NAME As String = "ALIAS_SUFFIX_NM"
Public Const RDSEG_ALIAS_POST_FLD_NAME As String = "ALIAS_POST_DIR"
Public Const RDSEG_ALIAS_LLOW_FLD_NAME As String = "ALIAS_LEFT_LO_ADDR"
Public Const RDSEG_ALIAS_LHI_FLD_NAME As String = "ALIAS_LEFT_HI_ADDR"
Public Const RDSEG_ALIAS_RLOW_FLD_NAME As String = "ALIAS_RIGHT_LO_ADDR"
Public Const RDSEG_ALIAS_RHI_FLD_NAME As String = "ALIAS_RIGHT_HI_ADDR"
Public Const RDSEG_ALIAS_LMIX_FLD_NAME As String = "LMIXADDR"
Public Const RDSEG_ALIAS_RMIX_FLD_NAME As String = "RMIXADDR"
'--Constants for dataset fields: Road_Geometery
Public Const RDGEOM_ST_X_FLD_NAME As String = "FRXCOORD"
Public Const RDGEOM_ST_Y_FLD_NAME As String = "FRYCOORD"
Public Const RDGEOM_ED_X_FLD_NAME As String = "TOXCOORD"
Public Const RDGEOM_ED_Y_FLD_NAME As String = "TOYCOORD"
Public Const RDGEOM_MD_X_FLD_NAME As String = "MIDXCOORD"
Public Const RDGEOM_MD_Y_FLD_NAME As String = "MIDYCOORD"
Public Const RDGEOM_ROADSEGID_FLD_NAME As String = "ROADSEGID"
Public Const RDGEOM_L_MGRA_FLD_NAME As String = "L_MGRA"
Public Const RDGEOM_R_MGRA_FLD_NAME As String = "R_MGRA"
Public Const RDGEOM_L_BLOCK_FLD_NAME As String = "L_BLOCK"
Public Const RDGEOM_R_BLOCK_FLD_NAME As String = "R_BLOCK"
Public Const RDGEOM_L_TRACT_FLD_NAME As String = "L_TRACT"
Public Const RDGEOM_R_TRACT_FLD_NAME As String = "R_TRACT"
Public Const RDGEOM_L_BEAT_FLD_NAME As String = "L_BEAT"
Public Const RDGEOM_R_BEAT_FLD_NAME As String = "R_BEAT"
Public Const RDGEOM_TBMPAGE_FLD_NAME As String = "TBMPAGE"
Public Const RDGEOM_TBMQUAD_FLD_NAME As String = "TBMQUAD"
Public Const RDGEOM_TBMGRID_FLD_NAME As String = "TBMGRID"
Public Const JUR_PUB_STY_FLD_NAME As String = "CODE"
'--Constants for dataset fields: Thomas Bros
Public Const TB_TBMPAGE_FLD_NAME As String = "TBMPAGE"
Public Const TB_TBMQUAD_FLD_NAME As String = "TBMQUAD"
Public Const TB_TBMGRID_FLD_NAME As String = "TBMGRID"
'--Constants for dataset fields: Census (MGRF)
Public Const MGRF_MGFA_FLD_NAME As String = "MGRA"
Public Const MGRF_BLOCK_FLD_NAME As String = "BLOCK"
Public Const MGRF_TRACT_FLD_NAME As String = "TRACT"
'--Constants for dataset fields: Law_Beat (MGRF)
Public Const LAW_BEAT_BEAT_FLD_NAME As String = "Beat"
'--Constants for dataset fields:Intersection
'Public Const INTER_INTERID_FLD_NAME As String = "INTERID"
'--Constants for dataset fields:Parcel Anno
Public Const PAR_ANNO_PARCELID_FLD_NAME As String = "PARCELID"
Public Const PAR_ANNO_APN_FLD_NAME As String = "APN"
'--Constants for dataset fields: Road Name Anno
Public Const ROADNM_NAME_FLD_NAME As String = "ROAD20_NM"
Public Const ROADNM_PREDIR_FLD_NAME As String = "ROAD20_PREDIR_IND"
Public Const ROADNM_SUFFIX_FLD_NAME As String = "ROAD20_SUFFIX_NM"

'--Constant for the snap tolerance
Public Const ROAD_SPLIT_SNAP_TOL As Long = 10  'pixels ...
'--Constants for layer UIDs: used for getting layers of a certain type from the map ...
Public Const UID_DATA_LAYER As String = "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}"
Public Const UID_GEOFEATURE_LAYER As String = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}"
Public Const UID_GRAPHICS_LAYER As String = "{34B2EF81-F4AC-11D1-A245-080009B6F22B}"
Public Const UID_COVERAGE_ANNO_LAYER As String = "{0C22A4C7-DAFD-11D2-9F46-00C04F6BC78E}"
Public Const UID_GROUP_LAYER As String = "{EDAD6644-1810-11D1-86AE-0000F8751720}"
'--enum of layer types
Public Enum LayerType
    ltAnyLayer = 0
    ltFeatureLayer = 1
    ltGraphicsLayer = 2
    ltCoverageAnnoLayer = 3
    ltGroupLayer = 4
    '--others? Raster?
End Enum
'--User-defined type to describe a road feature. This UDT will temporarily store edits to a road feature's attributes before they are committed
Public Type RoadFeature
    RoadID As Long
    RoadSegID As Long
    DedStat As String
    SegStat As String
'    Travlway As Integer
    Rightway As Integer
    FunClass As String
    LJurisdic As String
    RJurisdic As String
    RMixAddr As String
    LMixAddr As String
    Carto As String
    OBMH As String
    Firedriv As String
    Oneway As String
    SegClass As String
    LLowAddr As Long
    LHighAddr As Long
    RLowAddr As Long
    RHighAddr As Long
    Speed As Integer
    L_ZIP As Long
    R_ZIP As Long
End Type

