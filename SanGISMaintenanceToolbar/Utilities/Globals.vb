Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.Controls
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Display
Imports System.Windows.Forms
Imports ESRI.ArcGIS.esriSystem


Public Class Globals

#Region "Data Soruces"
    Public Const ROAD_DATASRC As String = "T.Road"
    Public Const ROAD_NAME_DATASRC As String = "T.ROADNAME"
    Public Const ROAD_STDS_DATASRC As String = "T.ROADNAME_STDS"
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
    Public Const SUBDIV_LOG_DATASRC As String = "T.SUBDIV_LOG"
    Public Const EASEMENT_DATASRC As String = "T.Open_Space_Easement"
    Public Const EASFLOODCONTROL_DATASRC As String = "T.Eas_FloodControl"
    Public Const EASFLOODCONTROL_DOC_DATASRC As String = "T.EAS_FLOODCONTROL_DOCUMENT"
    Public Const EASFLOODCONTROL_REL_DATASRC As String = "T.EASFLOODCONTROL_HAS_DOCUMENT"
    Public Const LOTSWORKAREA_DATASRC As String = "T.LotsWorkArea"
    Public Const ROW_DATASRC As String = "T.Right_Of_Way_ATR"
    Public Const ROADSEG_ALIAS_DATASRC As String = "T.ROADSEG_ALIAS"
    Public Const INTERSECTION_DATASRC As String = "T.Intersection"
    Public Const BOUND_DATASRC As String = "T.Boundary"
    Public Const Anno_APN_DATASRC As String = "T.Anno_APN"
    Public Const Anno_MAPNO_DATASRC As String = "T.Anno_MAPNUM"
    Public Const Anno_BLOCKNO_DATASRC As String = "T.Anno_BLOCKNUM"
    Public Const Anno_SUBNAME_DATASRC As String = "T.Anno_SUBNAME"
    Public Const Anno_TENTMAP_DATASRC As String = "T.Anno_TENTMAP"
    Public Const Anno_Address_DATASRC As String = "T.ANNO_ADDRESS"
    Public Const Anno_LotNo_DATASRC As String = "T.ANNO_LOTNUM"
    Public Const Anno_Road_DATASRC As String = "T.ANNO_ROADNAME"
    Public Const Anno_Block_DATASRC As String = "T.ANNO_BLOCKRANGE"
    Public Const JUR_PUB_STY_DATASRC As String = "T.JUR_PUBLIC_SAFETY"
    Public Const BOUNDARY_DATASRC As String = "T.Boundary"
    Public Const TOPOLOGY_DATASRC As String = "T.Road_Address_Topology"
    Public Const RD_GEOM_DATASRC As String = "T.ROAD_GEOMETRY"
    Public Const TMSBRS_DATASRC As String = "T.THOMAS_BROTHERS"
    Public Const MGRF_DATASRC As String = "T.MGRF"
    Public Const LAW_BEAT_DATASRC As String = "T.law_beats"
    Public Const CONTROL_DATASRC As String = "T.Control"
    Public Const LOG_PARCEL_CUTLOG_DATASRC As String = "T.LOG_PARCEL_CUTLOG"
    Public Const LOG_PARCEL_CUTLOG_DTL_DATASRC As String = "T.LOG_PARCEL_CUTLOG_DTL"
    Public Const LOG_PARCEL_ASR_CUTLOG_DATASRC As String = "T.LOG_PARCEL_ASR_CUTLOG"
    Public Const LOG_ROS_DATASRC As String = "T.LOG_ROS"
    Public Const LOG_SDADDRESS_DATASRC As String = "T.LOG_SD_ADDRESS"
    Public Const V_APNPARCEL_DATASRC As String = "T.QUERY_FORM_APN_PARCEL_VW" '"T.V_FORM_APN_PARCEL" '
    Public Const V_ADRROADAPN_DATASRC As String = "T.QUERY_FORM_ADDRESS_ROAD_VW" ' "T.V_ADDRAPN_ROADATR_ROADNAME"
    Public Const MPR_OWNER_DATASRC As String = "T.ASSESSOR_MPR_OWNERS"
    Public Const MPR_ORG_DATASRC As String = "T.ASSESSOR_MPR_ORIGINAL"
    Public Const V_BROWSEROADSEG_DATASRC As String = "T.QUERY_FORM_ROADSEG_VW" '"T.V_FORM_BROWSE_ROADSEG" '
    Public Const V_ADDRROADNAME_DATASRC As String = "T.QUERY_FORM_ADDRESS_ROAD_VW" ' "T.V_FORM_BROWSE_ADDRESS"
    Public Const V_LOTSUBDIVINFO_DATASRC As String = "T.LOT_MV" ' "T.QUERY_FORM_ADDRESS_ROAD_VW" ' "T.V_FORM_ADDRAPN_LOTSUB_ROAD"
    Public Const V_PARCELBACKLOG_DATASRC As String = "T.MPR_ORIGINAL_OWNERS_VW"
    Public Const LOG_ADDRESSISSUE_DATASRC As String = "T.LOG_ADDRESS_ISSUES"
    Public Const LOG_OVERLAP_DATASRC As String = "T.LOG_BLOCKRANGE_ISSUES"
    Public Const CENSUS_DATASRC As String = "T.CENSUS"
    'form not used for this view


#End Region

#Region "Field Constants"
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
    Public Const RD_TLEVEL_FLD_NAME As String = "T_LEVEL"
    Public Const RD_FLEVEL_FLD_NAME As String = "F_LEVEL"
    Public Const RD_POSTID_FLD_NAME As String = "POSTID"
    Public Const RD_POSTDATE_FLD_NAME As String = "POSTDATE"
    Public Const RD_NAD83N_FLD_NAME As String = "NAD83N"
    Public Const RD_NAD83E_FLD_NAME As String = "NAD83E"
    Public Const RD_ADDSEGDT_FLD_NAME As String = "ADDSEGDT"
    '--Constants for dataset fields: Intersection
    Public Const INTER_INTERID_FLD_NAME As String = "INTERID"
    Public Const INTER_DPWNO_FLD_NAME As String = "DPWINTNO"
    Public Const INTER_TNODE_FLD_NAME As String = "TNODE"
    Public Const INTER_FNODE_FLD_NAME As String = "FNODE"

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
    Public Const PARCEL_PENDING_FLD_NAME As String = "PENDING"
    Public Const PARCEL_MULTI_FLD_NAME As String = "MULTI"
    Public Const PARCEL_PARCEL_TYPE_FLD_NAME As String = "SUB_TYPE"
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
    Public Const SUBDIV_ATR_POSTID_FLD_NAME As String = "POSTID"
    Public Const SUBDIV_ATR_POSTDATE_FLD_NAME As String = "POSTDATE"
    Public Const SUBDIV_ATR_JURISDIC_FLD_NAME As String = "JURISDIC"
    Public Const SUBDIV_ATR_WRKORDID_FLD_NAME As String = "WRKORDID"
    Public Const SUBDIV_ATR_TENTMAP_FLD_NAME As String = "TENTMAP"
    Public Const SUBDIV_ATR_RECDATE_FLD_NAME As String = "RECDATE"
    Public Const SUBDIV_ATR_MAPTYPE_FLD_NAME As String = "MAPTYPE"
    Public Const SUBDIV_ATR_MAPNUM_FLD_NAME As String = "MAPNUM"
    Public Const SUBDIV_ATR_NUMLOTS_FLD_NAME As String = "NUMLOTS"
    Public Const SUBDIV_ATR_SUBNAME_FLD_NAME As String = "SUBNAME"
    Public Const SUBDIV_ATR_ACREAGE_FLD_NAME As String = "ACREAGE"
    Public Const SUBDIV_ATR_STATUS_FLD_NAME As String = "STATUS"
    Public Const SUBDIV_ATR_TB_GRID_FLD_NAME As String = "TB_GRID"
    Public Const SUBDIV_ATR_BASETILE_FLD_NAME As String = "BASETILE"
    Public Const SUBDIV_ATR_ENG_SIGNDATE_FLD_NAME As String = "ENG_SIGN_DATE"
    Public Const SUBDIV_ATR_MAP_TIETYPE_FLD_NAME As String = "MAP_TIE_TYPE"
    Public Const SUBDIV_ATR_TIE_POSTID_FLD_NAME As String = "TIE_POSTID"
    Public Const SUBDIV_ATR_TIE_POSTDATE_FLD_NAME As String = "TIE_POSTDATE"
    Public Const SUBDIV_ATR_PIVOT_POINT_E_FLD_NAME As String = "PIVOT_POINT_EASTING"
    Public Const SUBDIV_ATR_PIVOT_POINT_N_FLD_NAME As String = "PIVOT_POINT_NORTHING"
    Public Const SUBDIV_ATR_ROTATION_ANGLE_FLD_NAME As String = "ROTATION_ANGLE"
    Public Const SUBDIV_ATR_REF_MAP_TYPE_FLD_NAME As String = "REF_MAP_TYPE"
    Public Const SUBDIV_ATR_REF_MAP_NUM_FLD_NAME As String = "REF_MAP_NUM"
    Public Const SUBDIV_ATR_TIE1_BEARING_FLD_NAME As String = "TIE1_BEARING"
    Public Const SUBDIV_ATR_TIE1_DIST_FLD_NAME As String = "TIE1_DIST"
    Public Const SUBDIV_ATR_TIE1_DISTTYPE_FLD_NAME As String = "TIE1_DIST_TYPE"
    Public Const SUBDIV_ATR_TIE1_POINT_FLD_NAME As String = "TIE1_POINT"
    Public Const SUBDIV_ATR_PT1_STATIONID_FLD_NAME As String = "PT1_STATION_ID"
    Public Const SUBDIV_ATR_TIE2_BEARING_FLD_NAME As String = "TIE2_BEARING"
    Public Const SUBDIV_ATR_TIE2_DIST_FLD_NAME As String = "TIE2_DIST"
    Public Const SUBDIV_ATR_TIE2_DISTTYPE_FLD_NAME As String = "TIE2_DIST_TYPE"
    Public Const SUBDIV_ATR_TIE2_POINT_FLD_NAME As String = "TIE2_POINT"
    Public Const SUBDIV_ATR_PT2_STATIONID_FLD_NAME As String = "PT2_STATION_ID"
    Public Const SUBDIV_ATR_GPS_PT1_E_FLD_NAME As String = "GPS_PT1_EASTING"
    Public Const SUBDIV_ATR_GPS_PT1_N_FLD_NAME As String = "GPS_PT1_NORTHING"
    Public Const SUBDIV_ATR_GPS_PT2_E_FLD_NAME As String = "GPS_PT2_EASTING"
    Public Const SUBDIV_ATR_GPS_PT2_N_FLD_NAME As String = "GPS_PT2_NORTHING"
    '--Constants for dataset fields: SUBDIV_LOG
    Public Const SUBDIV_LOG_SUBDIVID_FLD_NAME As String = "SUBDIVID"
    Public Const SUBDIV_LOG_RECEIVED_FLD_NAME As String = "RECEIVED"
    Public Const SUBDIV_LOG_MAPAREA_FLD_NAME As String = "MAP_AREA"
    Public Const SUBDIV_LOG_NAD83_FLD_NAME As String = "NAD83"
    Public Const SUBDIV_LOG_GETDXF_FLD_NAME As String = "GET_DXF"
    Public Const SUBDIV_LOG_HAVEDXF_FLD_NAME As String = "HAVE_DXF"
    Public Const SUBDIV_LOG_ASGNTO_FLD_NAME As String = "ASGN_TO"
    Public Const SUBDIV_LOG_ASGNDATE_FLD_NAME As String = "ASGN_DATE"
    Public Const SUBDIV_LOG_COMP_BY_FLD_NAME As String = "COMP_BY"
    Public Const SUBDIV_LOG_COMPDATE_NAME As String = "COMP_DATE"
    Public Const SUBDIV_LOG_COMMENTS_NAME As String = "COMMENTS"
    Public Const SUBDIV_LOG_POSTID_NAME As String = "POSTID"
    Public Const SUBDIV_LOG_POSTDATE_NAME As String = "POSTDATE"
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
    '--Constants for dataset fields: EAS_FloodControl
    Public Const EASFC_POSTID_FLD_NAME As String = "POSTID"
    Public Const EASFC_POSTDATE_FLD_NAME As String = "POSTDATE"
    Public Const EASFC_EASFCID_FLD_NAME As String = "EASFLOODCONTROLID"
    Public Const EASFC_SUBDIVID_FLD_NAME As String = "SUBDIVID"
    Public Const EASFC_EASDOCID_NAME As String = "EASFLOODCONTROLDOCID"
    Public Const EASFC_STATUS_FLD_NAME As String = "STATUS"
    Public Const EASFC_TYPE_FLD_NAME As String = "TYPE"
    Public Const EASFC_CREATEID_FLD_NAME As String = "CREATEID"
    Public Const EASFC_CREATEDATE_FLD_NAME As String = "CREATEDATE"
    Public Const EASFC_DOCIMAGEID_FLD_NAME As String = "DOCIMAGEID"
    Public Const EASEFCREL_EASFLDCNTRLID_FLD_NAME = "EASFLDCNTRLID"
    Public Const EASEFCREL_EASFLDCNTRLDOCID_FLD_NAME = "EASFLDCNTRLDOCID"
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
    Public Const RDGEOM_L_PSBLOCK_FLD_NAME As String = "L_PSBLOCK"
    Public Const RDGEOM_R_PSBLOCK_FLD_NAME As String = "R_PSBLOCK"
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
    '--Constants for dataset fields: RoadName Anno
    Public Const ROADNM_NAME_FLD_NAME As String = "ROAD20_NM"
    Public Const ROADNM_PREDIR_FLD_NAME As String = "ROAD20_PREDIR_IND"
    Public Const ROADNM_SUFFIX_FLD_NAME As String = "ROAD20_SUFFIX_NM"
    '--Constants for dataset fields: RoadName table
    Public Const RDNAME_ROADID_FLD_NAME As String = "ROAD_ID"
    Public Const ROADNM_RD20NAME_FLD_NAME As String = "ROAD20_NM"
    Public Const ROADNM_RD20PREDIR_FLD_NAME As String = "ROAD20_PREDIR_IND"
    Public Const ROADNM_RD20SUFFIX_FLD_NAME As String = "ROAD20_SUFFIX_NM"
    Public Const ROADNM_RD30NAME_FLD_NAME As String = "ROAD30_NM"
    Public Const ROADNM_RD30PREDIR_FLD_NAME As String = "ROAD30_PREDIR_IND"
    Public Const ROADNM_RD30SUFFIX_FLD_NAME As String = "ROAD30_SUFFIX_NM"
    Public Const ROADNM_RD30POSTDIR_FLD_NAME As String = "ROAD30_POSTDIR_IND"
    Public Const ROADNM_FULLNAME_FLD_NAME As String = "FULL_NAME"
    Public Const ROADNM_WORKORDERNUM_FLD_NAME As String = "WORK_ORDER_NUM"
    Public Const ROADNM_RESERVEJUR_FLD_NAME As String = "RESERVE_JUR_CD"
    Public Const ROADNM_POSTOPERATOR_FLD_NAME As String = "POST_OPERATOR_ID"
    Public Const ROADNM_POSTDATE_FLD_NAME As String = "POST_DATE"
    Public Const ROADNM_MULTIJUR_FLD_NAME As String = "MULTIPLE_JUR_IND"
    Public Const ROADNM_RESERVETOMBRO_NAME As String = "RESERVE_TOMBRO_NUM"
    Public Const ROADNM_RESERVETENTMAP_FLD_NAME As String = "RESERVE_TENTMAP"
    Public Const ROADNM_RESERVEBYNM_FLD_NAME As String = "RESERVE_BY_NM"
    'Constants for Cutlogs
    Public Const PARCUTLG_CUT_YEAR_FLD_NAME As String = "CUT_YEAR"
    Public Const PARCUTLG_CUT_NUM_FLD_NAME As String = "CUT_NUM"
    Public Const PARCUTLG_AREA_FLD_NAME As String = "T.LOG_PARCEL_CUTLOG.AREA"
    Public Const PARCUTLG_JUR_FLD_NAME As String = "JUR"
    Public Const PARCUTLG_CONDO_ONLY_FLD_NAME As String = "CONDO_ONLY"
    Public Const PARCUTLG_OPEN_SPACE_FLD_NAME As String = "OPEN_SPACE"
    Public Const PARCUTLG_STREET_DEDICATION_FLD_NAME As String = "STREET_DEDICATION"
    Public Const PARCUTLG_STREET_VACATION_FLD_NAME As String = "STREET_VACATION"
    Public Const PARCUTLG_RECEIVED_FLD_NAME As String = "RECEIVED"
    Public Const PARCUTLG_COMP_BY_FLD_NAME As String = "COMP_BY"
    Public Const PARCUTLG_COMP_DATE_FLD_NAME As String = "COMP_DATE"
    Public Const PARCUTLG_LAND_REQ_FLD_NAME As String = "LAND_REQ"
    Public Const PARCUTLG_MAP_TYPE_FLD_NAME As String = "MAP_TYPE"
    Public Const PARCUTLG_MAP_NUM_FLD_NAME As String = "MAP_NUM"
    Public Const PARCUTLG_ASSIGNED_TO_FLD_NAME As String = "ASSIGNED_TO"
    Public Const PARCUTLG_ASSIGNED_DATE_FLD_NAME As String = "ASSIGNED_DATE"
    Public Const PARCUTLG_REMARKS_FLD_NAME As String = "REMARKS"
    Public Const PARCUTLG_CUT_YEAR_NUM_FLD_NAME As String = "CUT_YEAR_NUM"
    Public Const PARCUTLG_POSTID_FLD_NAME As String = "POSTID"
    Public Const PARCUTLG_POSTDATE_FLD_NAME As String = "POSTDATE"

    Public Const PARCUTLGDTL_CUT_YEAR_FLD_NAME As String = "CUT_YEAR"
    Public Const PARCUTLGDTL_CUT_NUM_FLD_NAME As String = "CUT_NUM"
    Public Const PARCUTLGDTL_BOOK_PAGE_FLD_NAME As String = "BOOK_PAGE"
    Public Const PARCUTLGDTL_REMARKS_FLD_NAME As String = "REMARKS"
    Public Const PARCUTLGDTL_CUT_YEAR_NUM_FLD_NAME As String = "CUT_YEAR_NUM"

    Public Const PARCUTLGASR_CUT_NUM_FLD_NAME As String = "CUT_NUM"
    Public Const PARCUTLGASR_CUT_YY_FLD_NAME As String = "CUT_YY"
    Public Const PARCUTLGASR_FROM_APN_FLD_NAME As String = "FROM_APN"
    Public Const PARCUTLGASR_TO_APN_FLD_NAME As String = "TO_APN"
    Public Const PARCUTLGASR_TONOTE_FLD_NAME As String = "TONOTE"
    Public Const PARCUTLGASR_MAP_NUM_FLD_NAME As String = "MAP_NUM"
    Public Const PARCUTLGASR_CUT_TYPE_FLD_NAME As String = "CUT_TYPE"
    Public Const PARCUTLGASR_DATE_TO_RC_FLD_NAME As String = "DATE_TO_RC"
    Public Const PARCUTLGASR_DATE_TO_REALTY_FLD_NAME As String = "DATE_TO_REALTY"
    Public Const PARCUTLGASR_DATE_TO_COLLECTOR_FLD_NAME As String = "DATE_TO_COLLECTOR"
    Public Const PARCUTLGASR_DATE_FINAL_FILE_FLD_NAME As String = "DATE_FINAL_FILE"
    Public Const PARCUTLGASR_DATE_TO_FIELD_FLD_NAME As String = "DATE_TO_FIELD"
    Public Const PARCUTLGASR_DATE_TO_MAP_FLD_NAME As String = "DATE_TO_MAP"
    Public Const PARCUTLGASR_DATE_EFF_DATE_FLD_NAME As String = "DATE_EFF_DATE"
    Public Const PARCUTLGASR_CC_NUM_FLD_NAME As String = "CC_NUM"
    Public Const PARCUTLGASR_RC_NUM_FLD_NAME As String = "RC_NUM"
    Public Const PARCUTLGASR_NUM_FROM_FLD_NAME As String = "NUM_FROM"
    Public Const PARCUTLGASR_NUM_TO_FLD_NAME As String = "NUM_TO"
    Public Const PARCUTLGASR_APPR_NAME_FLD_NAME As String = "APPR_NAME"
    Public Const PARCUTLGASR_APPR_ID_FLD_NAME As String = "APPR_ID"
    Public Const PARCUTLGASR_SUPERVISOR_AREA_FLD_NAME As String = "SUPERVISOR_AREA"
    Public Const PARCUTLGASR_TECH_INITIALS_FLD_NAME As String = "TECH_INITIALS"
    Public Const PARCUTLGASR_AUTHORITY_FLD_NAME As String = "AUTHORITY"
    Public Const PARCUTLGASR_NOTES_FLD_NAME As String = "NOTES"
    Public Const PARCUTLGASR_DATERC_FLD_NAME As String = "DATERC"
    Public Const PARCUTLGASR_DATEREALTY_FLD_NAME As String = "DATEREALTY"
    Public Const PARCUTLGASR_DATECOLLECTOR_FLD_NAME As String = "DATECOLLECTOR"
    Public Const PARCUTLGASR_DATEFINAL_FLD_NAME As String = "DATEFINAL"
    Public Const PARCUTLGASR_DATEFIELD_FLD_NAME As String = "DATEFIELD"
    Public Const PARCUTLGASR_DATEMAP_FLD_NAME As String = "DATEMAP"
    Public Const PARCUTLGASR_DATEEFF_FLD_NAME As String = "DATEEFF"
    Public Const PARCUTLGASR_CUT_YEAR_NUM_FLD_NAME As String = "CUT_YEAR_NUM"
    Public Const PARCUTLGASR_CUT_YEAR_FLD_NAME As String = "CUT_YEAR"
    '--Constants for dataset fields: LOG_ROS
    Public Const ROSLG_MAPNUM_FLD_NAME As String = "MAPNUM"
    Public Const ROSLG_DOCDATE_FLD_NAME As String = "DOC_DATE"
    Public Const ROSLG_LOCATION_FLD_NAME As String = "LOCATION"
    Public Const ROSLG_ASSRBOOK_FLD_NAME As String = "ASSESSOR_BOOK"
    Public Const ROSLG_NAD_FLD_NAME As String = "NAD"
    Public Const ROSLG_JUR_FLD_NAME As String = "JUR"
    Public Const ROSLG_NUMSHTS_FLD_NAME As String = "NUM_SHEETS"
    Public Const ROSLG_CALCOORD_FLD_NAME As String = "CAL_COORD_INDEX"
    Public Const ROSLG_BSHEET_FLD_NAME As String = "B_SHEET"
    '--Constants for dataset fields: LOG_SD_ADDRESS
    Public Const ADRLG_ID_FLD_NAME As String = "ID"
    Public Const ADRLG_COMPLETED_FLD_NAME As String = "COMPLETED"
    Public Const ADRLG_ADDRCHANGE_FLD_NAME As String = "ADDRCHANGE"
    Public Const ADRLG_NEWADDR_FLD_NAME As String = "NEWADDR"
    Public Const ADRLG_DELETEADDR_FLD_NAME As String = "DELETEADDR"
    Public Const ADRLG_ADDRDESC_FLD_NAME As String = "ADDRDESC"
    Public Const ADRLG_ASSIGNDATE_FLD_NAME As String = "ASSIGNDATE"
    Public Const ADRLG_LOTPAR_FLD_NAME As String = "LOTPAR"
    Public Const ADRLG_DOCTYPE_FLD_NAME As String = "DOCTYPE"
    Public Const ADRLG_DOCNUM_FLD_NAME As String = "DOCNUM"
    Public Const ADRLG_ADDRESS_FLD_NAME As String = "ADDRESS"
    Public Const ADRLG_FRACTION_FLD_NAME As String = "FRACTION"
    Public Const ADRLG_UNIT_FLD_NAME As String = "UNIT"
    Public Const ADRLG_DIR_FLD_NAME As String = "DIR"
    Public Const ADRLG_ROADNAME_FLD_NAME As String = "ROADNAME"
    Public Const ADRLG_ROADSFX_FLD_NAME As String = "ROADSFX"
    Public Const ADRLG_ROADPDIR_FLD_NAME As String = "ROADPDIR"
    Public Const ADRLG_ROADFULL_FLD_NAME As String = "ROADFULL"
    Public Const ADRLG_ROADSDIR_FLD_NAME As String = "ROADSDIR"
    Public Const ADRLG_INCREASEDIR_FLD_NAME As String = "INCREASEDIR"
    Public Const ADRLG_ABLOADDR_FLD_NAME As String = "ABLOADDR"
    Public Const ADRLG_ABHIADDR_FLD_NAME As String = "ABHIADDR"
    Public Const ADRLG_LLOWADDR_FLD_NAME As String = "LLOWADDR"
    Public Const ADRLG_LHIGHADDR_FLD_NAME As String = "LHIGHADDR"
    Public Const ADRLG_RLOWADDR_FLD_NAME As String = "RLOWADDR"
    Public Const ADRLG_RHIGHADDR_FLD_NAME As String = "RHIGHADDR"
    Public Const ADRLG_SEGLIMIT_FLD_NAME As String = "SEGLIMIT"
    Public Const ADRLG_APN_FLD_NAME As String = "APN"
    Public Const ADRLG_ROADSEGID_FLD_NAME As String = "ROADSEGID"
    Public Const ADRLG_BASETILE_FLD_NAME As String = "BASETILE"
    Public Const ADRLG_TENTMAP_FLD_NAME As String = "TENTMAP"
    Public Const ADRLG_WRKORDID_FLD_NAME As String = "WRKORDID"
    Public Const ADRLG_MAPNAME_FLD_NAME As String = "MAPNAME"
    Public Const ADRLG_TOSANGIS_FLD_NAME As String = "TOSANGIS"
    '--Constant for the MPR Dataset
    Public Const MPR_APN_FLD_NAME As String = "APN"
    Public Const MPR_TRA_FLD_NAME As String = "TAX_RATE_AREA"
    Public Const MPR_DOCTYPE_FLD_NAME As String = "REC_DOC_TYPE"
    Public Const MPR_DOCDATE_FLD_NAME As String = "REC_DOC_DATE"
    Public Const MPR_DOCNO_FLD_NAME As String = "REC_DOC_NMBR"
    Public Const MPR_ASSYR_FLD_NAME As String = "ASSESSMENT_YEAR"
    Public Const MPR_TXSTATUS_FLD_NAME As String = "TAX_STATUS"
    Public Const MPR_TRANSDATE_FLD_NAME As String = "TRANSACTION_DATE"
    Public Const MPR_MARTSTATUS_FLD_NAME As String = "MARITAL_STATUS"
    Public Const MPR_OWNSTATUS_FLD_NAME As String = "OWNER_STATUS"
    Public Const MPR_OWNNAME_FLD_NAME As String = "OWNER_NAME"
    Public Const MPR_MAILADDR_FLD_NAME As String = "MAIL_ADDRESS"
    Public Const MPR_ZIP_FLD_NAME As String = "ZIP_CODE"
    Public Const MPR_LANDV_FLD_NAME As String = "LAND_VALUE"
    Public Const MPR_IMPSV_FLD_NAME As String = "IMPS_VALUE"
    Public Const MPR_PPYV_FLD_NAME As String = "PPY_VALUE"
    Public Const MPR_NETV_FLD_NAME As String = "NET_VALUE"
    Public Const MPR_EXMPCD1_FLD_NAME As String = "EXEMPTION_CODE_1"
    Public Const MPR_EXMPCD2_FLD_NAME As String = "EXEMPTION_CODE_2"
    Public Const MPR_EXMPCD3_FLD_NAME As String = "EXEMPTION_CODE_3"
    Public Const MPR_EXMPV1_FLD_NAME As String = "EXEMPTION_VALUE_1"
    Public Const MPR_EXMPV2_FLD_NAME As String = "EXEMPTION_VALUE_2"
    Public Const MPR_EXMPV3_FLD_NAME As String = "EXEMPTION_VALUE_3"
    Public Const MPR_SLDREDCD_FLD_NAME As String = "SOLD_RED_CODE"
    Public Const MPR_SLDREDYR_FLD_NAME As String = "SOLD_RED_YEAR"
    Public Const MPR_APPLSYR_FLD_NAME As String = "APPEALS_YEAR"
    Public Const MPR_MPRZN_FLD_NAME As String = "LAND_USE_ZONE"
    Public Const MPR_MPRCD_FLD_NAME As String = "LAND_USE_CODE"
    Public Const MPR_NUCZN_FLD_NAME As String = "NUCLEUS_ZONE_CD"
    Public Const MPR_NUCCD_FLD_NAME As String = "NUCLEUS_USE_CD"
    Public Const MPR_MLFLAG_FLD_NAME As String = "NUCLEUS_MAIL_ADDR_FLAG"
    Public Const MPR_ADDR_FLD_NAME As String = "NUCLEUS_SITUS_ST_NBR"
    Public Const MPR_FRAC_FLD_NAME As String = "NUCLEUS_SITUS_FRACTION"
    Public Const MPR_ADDRUNIT_FLD_NAME As String = "NUCLEUS_SITUS_UNIT_NBR"
    Public Const MPR_PREDIR_FLD_NAME As String = "NUCLEUS_SITUS_PRFX_DIR"
    Public Const MPR_RDNAME_FLD_NAME As String = "NUCLEUS_SITUS_ST_NAME"
    Public Const MPR_RDSFXFLD_NAME As String = "NUCLEUS_SITUS_ST_TYPE"
    Public Const MPR_PSTDIR_FLD_NAME As String = "NUCLEUS_SITUS_SFFX_DIR"
    Public Const MPR_SITCOMM_FLD_NAME As String = "NUCLEUS_SITUS_COMMUNITY"
    Public Const MPR_SITESTATE_FLD_NAME As String = "NUCLEUS_SITUS_STATE"
    Public Const MPR_SITEZIP_FLD_NAME As String = "NUCLEUS_SITUS_ZIP"
    Public Const MPR_MAPNUMBER_FLD_NAME As String = "MAP_NUMBER"
    Public Const MPR_ACREAGE_FLD_NAME As String = "ACREAGE"
    Public Const MPR_UNITS_FLD_NAME As String = "UNITS"
    Public Const MPR_PROPDESCRCD_FLD_NAME As String = "PROP_DESCR_CODE"
    Public Const MPR_PROPDESC_FLD_NAME As String = "PROP_DESCR_CHAR"
    Public Const MPR_REGCUTNO_FLD_NAME As String = "ORIG_CUT_NO"
    Public Const MPR_REGCUTDT_FLD_NAME As String = "ORIG_CUT_DATE"
    Public Const MPR_PREPARCUTNO_FLD_NAME As String = "RED_CUT_NO"
    Public Const MPR_PREPARCUTDATE_FLD_NAME As String = "RED_CUT_DATE"
    Public Const MPR_TRACUTNO_FLD_NAME As String = "TRA_CUT_NO"
    Public Const MPR_TRACUTDT_FLD_NAME As String = "TRA_CUT_DATE"
    Public Const MPR_PRIORPAR1_FLD_NAME As String = "OLD_MAPBOOK_NO"
    Public Const MPR_PRIORPAR2_FLD_NAME As String = "OLD_PAGE_NO"
    Public Const MPR_PRIORPAR3_FLD_NAME As String = "OLD_PARCEL"
    Public Const MPR_PRIORPAR4_FLD_NAME As String = "OLD_UND_INT"
    Public Const MPR_PRIORTRA_FLD_NAME As String = "OLD_TAX_RATE"
    Public Const MPR_PARENTPARCEL_FLD_NAME As String = "NUCLEUS_PARENT_PARCEL"
    'Issuelogs
    Public Const ADDR_ISSUE_FLD_NAME As String = "ISSUETYPE"

    '--Constants for dataset fields: Census
    Public Const CENSUS_CENSUSID_FLD_NAME As String = "CENSUSID"
    Public Const CENSUS_PSBLOCK_FLD_NAME As String = "PSBLOCK"
    Public Const CENSUS_BLOCK_FLD_NAME As String = "BLOCK"
    Public Const CENSUS_CT_FLD_NAME As String = "CT"
    Public Const CENSUS_CTBLOCK_FLD_NAME As String = "CTBLOCK"
#End Region

#Region "Table Wrapper Globals"
    'Form Globals for the table wrappers
    Public Shared m_CTYR As String
    Public Shared m_CTNM As String
    Public Shared m_CTYRNM As String
    Public Shared m_WrapperCaller As String
    Public Shared m_TWPostfixClause As String
    Public Shared m_TWWhereClause As String
#End Region

#Region "Layers"

    Shared Function CheckForLayer(ByVal playername As String, ByVal pmActiveView As IActiveView) As Boolean
        CheckForLayer = False
        Dim pMap As Map
        Dim pEnumLayers As IEnumLayer
        Dim pLayer As ILayer
        pMap = pmActiveView.FocusMap
        pEnumLayers = pMap.Layers(Nothing, False)
        pLayer = pEnumLayers.Next
        Do Until pLayer Is Nothing
            'added to handle grouped layers
            If TypeOf pLayer Is ICompositeLayer And Not (TypeOf pLayer Is IAnnotationLayer Or TypeOf pLayer Is IRasterLayer) Then
                Dim pGroupLayer As ICompositeLayer = CType(pLayer, ICompositeLayer)
                Dim j As Integer
                For j = 0 To pGroupLayer.Count - 1
                    'added to handle a second group layer
                    If TypeOf pGroupLayer.Layer(j) Is ICompositeLayer And Not (TypeOf pGroupLayer.Layer(j) Is IAnnotationLayer Or TypeOf pGroupLayer.Layer(j) Is IRasterLayer) Then
                        Dim pGroupLayer2 As ICompositeLayer = CType(pGroupLayer.Layer(j), ICompositeLayer)
                        Dim j2 As Integer
                        For j2 = 0 To pGroupLayer2.Count - 1
                            If UCase(playername) = "ANY" Then
                                If pGroupLayer2.Layer(j2).Name Like "T.*" And pGroupLayer2.Layer(j2).SupportedDrawPhases = 7 Then 'Not pLayer.Name Like "*Topology"
                                    CheckForLayer = True
                                    Exit Do
                                End If
                            Else
                                If pGroupLayer2.Layer(j2).Name = playername Then
                                    CheckForLayer = True
                                    Exit Do
                                End If
                            End If
                        Next j2
                    ElseIf UCase(playername) = "ANY" Then
                        If pGroupLayer.Layer(j).Name Like "T.*" And pGroupLayer.Layer(j).SupportedDrawPhases = 7 Then 'Not pLayer.Name Like "*Topology"
                            CheckForLayer = True
                            Exit Do
                        End If
                    Else
                        If pGroupLayer.Layer(j).Name = playername Then
                            CheckForLayer = True
                            Exit Do
                        End If
                    End If
                Next j
            ElseIf UCase(playername) = "ANY" Then
                If pLayer.Name Like "T.*" And pLayer.SupportedDrawPhases = 7 Then 'Not pLayer.Name Like "*Topology"
                    CheckForLayer = True
                    Exit Do
                End If
            Else
                If pLayer.Name = playername Then
                    CheckForLayer = True
                    Exit Do
                End If
            End If
            pLayer = pEnumLayers.Next
        Loop
    End Function

    Shared Function CheckifEditable(ByVal playername As String, ByVal pmActiveView As IActiveView) As Boolean
        CheckifEditable = False
        Dim Islayer As Boolean = False
        Dim pMap As Map
        Dim pEnumLayers As IEnumLayer
        Dim pLayer As ILayer
        pMap = pmActiveView.FocusMap
        pEnumLayers = pMap.Layers(Nothing, False)
        pLayer = pEnumLayers.Next
        Do Until pLayer Is Nothing
            'added to handle grouped layers
            If TypeOf pLayer Is ICompositeLayer And Not (TypeOf pLayer Is IAnnotationLayer Or TypeOf pLayer Is IRasterLayer) Then
                Dim pGroupLayer As ICompositeLayer = CType(pLayer, ICompositeLayer)
                Dim j As Integer
                For j = 0 To pGroupLayer.Count - 1
                    'added to handle a second group layer
                    If TypeOf pGroupLayer.Layer(j) Is ICompositeLayer And Not (TypeOf pGroupLayer.Layer(j) Is IAnnotationLayer Or TypeOf pGroupLayer.Layer(j) Is IRasterLayer) Then
                        Dim pGroupLayer2 As ICompositeLayer = CType(pGroupLayer.Layer(j), ICompositeLayer)
                        Dim j2 As Integer
                        For j2 = 0 To pGroupLayer2.Count - 1
                            If UCase(playername) = "ANY" Then
                                If pGroupLayer2.Layer(j2).Name Like "T.*" And pGroupLayer2.Layer(j2).SupportedDrawPhases = 7 Then 'Not pLayer.Name Like "*Topology"
                                    Try
                                        Dim pWkspc As IWorkspace
                                        Dim pversionW As IVersionedWorkspace
                                        Dim pVersion As IVersion
                                        Dim pversioninfo As IVersionInfo
                                        Dim pWSE As IWorkspaceEdit
                                        Dim pFlayer As IFeatureLayer
                                        pFlayer = pGroupLayer2.Layer(j2)
                                        pWkspc = Nothing
                                        If Not pFlayer.FeatureClass.FeatureDataset Is Nothing Then
                                            pWkspc = pFlayer.FeatureClass.FeatureDataset.Workspace
                                        Else
                                            CheckifEditable = False
                                            Exit Do
                                        End If
                                        If pWkspc Is Nothing Then
                                            CheckifEditable = False
                                            Exit Do
                                        End If
                                        pversionW = pWkspc
                                        pWSE = pversionW
                                        pVersion = pversionW
                                        pversioninfo = pVersion.VersionInfo
                                        pWSE.StartEditing(False)
                                        'pWSE.StartEditOperation()
                                        pWSE.StopEditing(False)
                                        CheckifEditable = True
                                        Exit Do
                                    Catch ex As Exception
                                        CheckifEditable = False
                                        Exit Do
                                    End Try
                                End If
                            Else
                                If pGroupLayer2.Layer(j2).Name = playername Then
                                    CheckifEditable = True
                                    Exit Do
                                End If
                            End If
                        Next j2
                    ElseIf UCase(playername) = "ANY" Then
                        If pGroupLayer.Layer(j).Name Like "T.*" And pGroupLayer.Layer(j).SupportedDrawPhases = 7 Then 'Not pLayer.Name Like "*Topology"
                            Try
                                Dim pWkspc As IWorkspace
                                Dim pversionW As IVersionedWorkspace
                                Dim pVersion As IVersion
                                Dim pversioninfo As IVersionInfo
                                Dim pWSE As IWorkspaceEdit
                                Dim pFlayer As IFeatureLayer
                                pFlayer = pGroupLayer.Layer(j)
                                pWkspc = Nothing
                                If Not pFlayer.FeatureClass.FeatureDataset Is Nothing Then
                                    pWkspc = pFlayer.FeatureClass.FeatureDataset.Workspace
                                Else
                                    CheckifEditable = False
                                    Exit Do
                                End If
                                If pWkspc Is Nothing Then
                                    CheckifEditable = False
                                    Exit Do
                                End If
                                pversionW = pWkspc
                                pWSE = pversionW
                                pVersion = pversionW
                                pversioninfo = pVersion.VersionInfo
                                pWSE.StartEditing(False)
                                'pWSE.StartEditOperation()
                                pWSE.StopEditing(False)
                                CheckifEditable = True
                                Exit Do
                            Catch ex As Exception
                                CheckifEditable = False
                                Exit Do
                            End Try

                        End If
                    Else
                        If pGroupLayer.Layer(j).Name = playername Then
                            CheckifEditable = True
                            Exit Do
                        End If
                    End If
                Next j
            ElseIf UCase(playername) = "ANY" Then
                If pLayer.Name Like "T.*" And pLayer.SupportedDrawPhases = 7 Then 'Not pLayer.Name Like "*Topology"
                    Try
                        Dim pWkspc As IWorkspace
                        Dim pversionW As IVersionedWorkspace
                        Dim pVersion As IVersion
                        Dim pversioninfo As IVersionInfo
                        Dim pWSE As IWorkspaceEdit
                        Dim pFlayer As IFeatureLayer
                        pFlayer = pLayer
                        pWkspc = Nothing
                        If Not pFlayer.FeatureClass.FeatureDataset Is Nothing Then
                            pWkspc = pFlayer.FeatureClass.FeatureDataset.Workspace
                        Else
                            CheckifEditable = False
                            Exit Do
                        End If
                        If pWkspc Is Nothing Then
                            CheckifEditable = False
                            Exit Do
                        End If
                        pversionW = pWkspc
                        pWSE = pversionW
                        pVersion = pversionW
                        pversioninfo = pVersion.VersionInfo
                        pWSE.StartEditing(False)
                        'pWSE.StartEditOperation()
                        pWSE.StopEditing(False)
                        CheckifEditable = True
                        Exit Do
                    Catch ex As Exception
                        CheckifEditable = False
                        Exit Do
                    End Try

                End If
            Else
                If pLayer.Name = playername Then
                    CheckifEditable = True
                    Exit Do
                End If
            End If
            pLayer = pEnumLayers.Next
        Loop
    End Function

    Shared Sub GetSelectedFeatures(ByVal layername As String, ByVal pmActiveView As IActiveView, ByVal pField As String, ByVal pFldValue As String, ByVal pMulti As Boolean)
        Dim pMap As Map
        Dim pEnumLayers As IEnumLayer
        Dim pLayer As ILayer
        Dim pTmpLayer As ILayer = Nothing
        Dim pFLayer As IFeatureLayer
        Dim pActiveView As IActiveView
        Dim pFClass As IFeatureClass

        Dim pFeatCursor As IFeatureCursor
        Dim pFeatSelFeat As IFeatureSelection
        Dim pFeature As IFeature

        Try
            pMap = pmActiveView.FocusMap
            pEnumLayers = pMap.Layers(Nothing, False)
            pLayer = pEnumLayers.Next
            pActiveView = pmActiveView
            Do Until pLayer Is Nothing

                If TypeOf pLayer Is ICompositeLayer And Not (TypeOf pLayer Is IAnnotationLayer Or TypeOf pLayer Is IRasterLayer) Then
                    Dim pGroupLayer As ICompositeLayer = CType(pLayer, ICompositeLayer)
                    Dim j As Integer
                    For j = 0 To pGroupLayer.Count - 1
                        'added to handle a second group layer
                        If TypeOf pGroupLayer.Layer(j) Is ICompositeLayer And Not (TypeOf pGroupLayer.Layer(j) Is IAnnotationLayer Or TypeOf pGroupLayer.Layer(j) Is IRasterLayer) Then
                            Dim pGroupLayer2 As ICompositeLayer = CType(pGroupLayer.Layer(j), ICompositeLayer)
                            Dim j2 As Integer
                            For j2 = 0 To pGroupLayer2.Count - 1
                                If pGroupLayer2.Layer(j2).Name = layername Then
                                    pTmpLayer = pGroupLayer2.Layer(j2)
                                    Exit For
                                End If
                            Next
                            'exit the other for if tmplayer set
                            If Not pTmpLayer Is Nothing Then
                                Exit For
                            End If
                        Else
                            If pGroupLayer.Layer(j).Name = layername Then
                                pTmpLayer = pGroupLayer.Layer(j)
                                Exit For
                            End If

                        End If
                    Next
                Else
                    If pLayer.Name = layername Then
                        pTmpLayer = pLayer
                    End If
                End If


                If Not pTmpLayer Is Nothing Then
                    pFLayer = pTmpLayer
                    pFClass = pFLayer.FeatureClass
                    Dim pQF2 As IQueryFilter
                    pQF2 = New QueryFilter
                    pQF2.WhereClause = pField & " = " & pFldValue
                    pFeatSelFeat = pFLayer
                    pFeatSelFeat.SelectFeatures(pQF2, esriSelectionResultEnum.esriSelectionResultNew, False)
                    'MsgBox(pQF2.WhereClause & "    " & pFeatSelFeat.SelectionSet.Count)
                    If pFeatSelFeat.SelectionSet.Count > 0 Then
                        pFeatCursor = pFClass.Search(pQF2, True)
                        pFeature = pFeatCursor.NextFeature
                        'If no roads were found, stop now
                        If pFeature Is Nothing Then
                            MsgBox("No Features found for value " & pFldValue & " for field " & pField, vbExclamation, _
                              "Query Form Feature Search")
                            pActiveView.Refresh()
                            Exit Sub
                        End If

                        Dim pEnv As IEnvelope
                        pEnv = New Envelope
                        If pFClass.ShapeType = esriGeometryType.esriGeometryPoint Then
                            Dim pNwPoint As IPoint
                            pNwPoint = pFeature.Shape
                            pEnv = pFeature.Shape.Envelope
                            pEnv.Expand(100, 100, False)
                            pEnv.CenterAt(pNwPoint)
                        Else
                            Do Until pFeature Is Nothing
                                pEnv.Union(pFeature.Extent)
                                pFeature = pFeatCursor.NextFeature
                            Loop
                            pEnv.Expand(2, 2, True)
                        End If

                        pActiveView.Extent = pEnv.Envelope
                        pActiveView.Refresh()

                        Exit Sub
                    Else
                        MsgBox("No Features found for value " & pFldValue & " for field " & pField, vbExclamation, _
                              "Query Form Feature Search")
                        pActiveView.Refresh()
                        Exit Sub
                    End If

                    'Dim pUID As New UID
                    'Dim pComdItem As ICommandItem
                    'pUID.Value = "esriCore.ZoomToSelectedCommand"
                    'pCmdItem = Thisdocument.CommandBars.Find(pUID)
                    Exit Do
                End If
                pLayer = pEnumLayers.Next
            Loop
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Shared Function CheckSelectedLayerInfo(ByVal pmMXDoc As IMxDocument, ByVal pLayerName As String, ByVal pGeomType As esriGeometryType) As Boolean
        CheckSelectedLayerInfo = False
        Try
            Dim pLayer As ILayer
            Dim pFLayer As IFeatureLayer
            If pmMXDoc.SelectedLayer Is Nothing Then
                CheckSelectedLayerInfo = False
                Exit Function
            Else
                pLayer = pmMXDoc.SelectedLayer
                If TypeOf pLayer Is IFeatureLayer Then
                    pFLayer = pmMXDoc.SelectedLayer
                    If Not pLayerName = "Any" Then
                        If pFLayer.Name = pLayerName And pFLayer.FeatureClass.ShapeType = pGeomType Then
                            CheckSelectedLayerInfo = True
                        Else
                            CheckSelectedLayerInfo = False
                        End If
                    Else
                        If pFLayer.FeatureClass.ShapeType = pGeomType Then
                            CheckSelectedLayerInfo = True
                        Else
                            CheckSelectedLayerInfo = False
                        End If
                    End If
                Else
                    CheckSelectedLayerInfo = False
                    Exit Function
                End If

            End If
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Function

    Shared Function GetLayerByName(ByVal pMXDoc As IMxDocument, ByVal LayerName As String) As ILayer
        GetLayerByName = Nothing
        Try
            Dim pEnumLayer As IEnumLayer, pLayer As ILayer
            pEnumLayer = pMXDoc.FocusMap.Layers
            pLayer = pEnumLayer.Next
            Do Until pLayer Is Nothing
                If pLayer.Name = LayerName Then
                    GetLayerByName = pLayer 'found it. pass it back and then exit
                    Exit Do
                End If
                pLayer = pEnumLayer.Next
            Loop
            'clean up object variables. pass the layer back (if it wasn't found, Nothing is passed back) ...
            GetLayerByName = pLayer
            pEnumLayer = Nothing
            pLayer = Nothing
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Function


#End Region

#Region "Graphics"

    Shared Function MakeRoadGraphic(ByVal RoadLine As ICurve, Optional ByVal ColorVal As String = "Red") As IElement
        MakeRoadGraphic = Nothing
        Try
            '-This function will make a new graphic element from the line shape that's passed in
            Dim pLineElem As ILineElement, pElem As IElement, pElemProps As IElementProperties, pLineSym As ISimpleLineSymbol
            Dim pColor As IRgbColor
            pColor = New RgbColor
            Select Case ColorVal
                Case Is = "Green"
                    pColor.RGB = RGB(0, 255, 0)
                Case Is = "Blue"
                    pColor.RGB = RGB(0, 0, 255)
                Case Else
                    pColor.RGB = RGB(255, 0, 0) 'red
            End Select
            pLineSym = New SimpleLineSymbol
            pLineSym.Color = pColor
            pLineSym.Style = esriSimpleLineStyle.esriSLSSolid
            pLineSym.Width = 5
            pLineElem = New LineElement
            pLineElem.Symbol = pLineSym
            pElem = pLineElem 'QI
            pElem.Geometry = RoadLine
            pElemProps = pElem 'QI
            pElemProps.Name = "RoadGraphic" 'name it so it can be removed later
            MakeRoadGraphic = pElem 'pass back the graphic
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Function

    Shared Sub FlashIt(ByVal pMXDoc As IMxDocument, ByVal FlashLayer As IFeatureLayer, ByVal FlashGeometry As IGeometry, ByVal FlashFID As Long)
        Try
            'this sub will flash a feature (with FlashFID) in the specified layer using the specified geometry to select it
            Dim pID As IIdentify 'an object used to identify features in a layer with a geometry object
            Dim pIDArray As IArray 'an array of features ID'd by the FlashGeometry
            Dim pIDObj As IIdentifyObj, pFIDObj As IRowIdentifyObject, pIDFeature As IFeature   'the identified feature
            Dim i As Integer 'index for accessing identified features

            pID = FlashLayer 'QI
            pIDArray = pID.Identify(FlashGeometry)  'this geometry is used to identify the feature(s) to flash, it is likely the point that was used to split the lines

            For i = 0 To pIDArray.Count - 1 'loop thru identified features, make sure to only flash the one with the specified FID
                pIDObj = pIDArray.Element(i) 'get a feature that was identified (may only be one)
                pFIDObj = pIDObj 'QI
                pIDFeature = pFIDObj.Row 'get the ID'd feature
                If pIDFeature.OID = FlashFID Then 'see if the FIDs match
                    pIDObj.Flash(pMXDoc.ActiveView.ScreenDisplay)  'm_pMxApp.Display   'flash it (pass in the application's display object as a required parameter)
                End If
            Next i
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Shared Sub DeleteGraphicByName(ByVal pMXDoc As IMxDocument, ByVal ElementName As String)
        Try
            'this sub will take the name of a graphic element, loop thru graphics in the map, then delete any that match the given name
            Dim pGC As IGraphicsContainer
            Dim pElem As IElementProperties

            pGC = pMXDoc.ActiveView.GraphicsContainer 'get the map (not deleting graphics from the page layout)
            pGC.Reset()
            pElem = pGC.Next
            Do Until pElem Is Nothing
                If pElem.Name = ElementName Then
                    pGC.DeleteElement(pElem)
                    '            Exit Do '*don't exit .... there may be more than one!
                End If
                pElem = pGC.Next
            Loop
            'refresh the display
            pMXDoc.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, Nothing, pMXDoc.ActiveView.Extent)

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

#End Region

#Region "Domains"

    Public Shared Function GetDmn(ByVal pWkspace As IWorkspace, ByVal FClass As IClass, ByVal FieldName As String) As ICodedValueDomain
        Dim intFieldIndex As Long, pField As IField
        Dim pDomain As IDomain
        'Dim pCodedValueDomain As ICodedValueDomain
        Dim fldDomain As IDomain
        GetDmn = Nothing
        Try
            intFieldIndex = FClass.FindField(FieldName)
            If intFieldIndex = -1 Then
                MessageBox.Show("Field Not found: " & FieldName)
                Exit Function '-1 means the field was not found
            End If
            pField = FClass.Fields.Field(intFieldIndex)
            fldDomain = pField.Domain
            If fldDomain Is Nothing Then
                MessageBox.Show("domain not found")
                Exit Function 'exit if the field doesn't use a domain
            End If
            If Not TypeOf fldDomain Is ICodedValueDomain Then
                MessageBox.Show("Type of Domain is not a Coded Value")
                Exit Function 'exit if it's a range domain
            End If
            Dim pWkspaceDomains As IWorkspaceDomains

            If TypeOf pWkspace Is IWorkspaceDomains Then
                pWkspaceDomains = pWkspace
                pDomain = pWkspaceDomains.DomainByName(fldDomain.Name)
                GetDmn = pDomain
            End If
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Function

    Public Shared Function GetCddDmnValues(ByVal pWrkspace As IWorkspace, ByVal FClass As IClass, ByVal FieldName As String, ByVal Task As String, ByVal DmnValue As String) As String
        GetCddDmnValues = Nothing
        Try
            Dim pcdddmn As ICodedValueDomain
            pcdddmn = GetDmn(pWrkspace, FClass, FieldName)
            Dim intDomainCount As Integer
            If Task = "GetDescription" Then
                For intDomainCount = 0 To (pcdddmn.CodeCount - 1)
                    If DmnValue = (pcdddmn.Value(intDomainCount)) Then
                        GetCddDmnValues = (pcdddmn.Name(intDomainCount))
                    End If
                Next
            ElseIf Task = "GetCode" Then
                For intDomainCount = 0 To (pcdddmn.CodeCount - 1)
                    If DmnValue = (pcdddmn.Name(intDomainCount)) Then
                        GetCddDmnValues = (pcdddmn.Value(intDomainCount))
                    End If
                Next
            Else
                MsgBox(Task & " Not in Task List: GetCode, GetDescription")
            End If
            If GetCddDmnValues = Nothing Then
                GetCddDmnValues = " "
            End If
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Function

#End Region

#Region "Data Features and Workspace"

    '--User-defined type to describe a road feature. This UDT will temporarily store edits to a road feature's attributes before they are committed
    Public Structure RoadFeature
        Dim RoadID As Long
        Dim RoadSegID As Long
        Dim DedStat As String
        Dim SegStat As String
        Dim Rightway As Integer
        Dim FunClass As String
        Dim LJurisdic As String
        Dim RJurisdic As String
        Dim RMixAddr As String
        Dim LMixAddr As String
        Dim Carto As String
        Dim OBMH As String
        Dim Firedriv As String
        Dim Oneway As String
        Dim SegClass As String
        Dim LLowAddr As Long
        Dim LHighAddr As Long
        Dim RLowAddr As Long
        Dim RHighAddr As Long
        Dim Speed As Integer
        Dim L_ZIP As Long
        Dim R_ZIP As Long
    End Structure

    Shared Function GetWorkspaceTable(ByVal layername As String, ByVal pmActiveView As IActiveView, ByVal pTableLoad As String, ByVal pForQuery As Boolean) As ITable
        GetWorkspaceTable = Nothing
        Dim pWkspc As IWorkspace
        Dim pMap As Map
        Dim pEnumLayers As IEnumLayer
        Dim pLayer As ILayer
        Dim pFLayer As IFeatureLayer
        Dim pversionW As IVersionedWorkspace
        Dim pVersion As IVersion
        Dim pversioninfo As IVersionInfo
        Dim pFeatWorkSpace As IFeatureWorkspace
        Dim pWSE As IWorkspaceEdit
        Dim pTableName As String
        Dim pCheckTable As ITable

        pTableName = pTableLoad
        pWkspc = Nothing
        pMap = pmActiveView.FocusMap
        pEnumLayers = pMap.Layers(Nothing, False)
        pLayer = pEnumLayers.Next
        Do Until pLayer Is Nothing
            'added to handle grouped layers
            If TypeOf pLayer Is ICompositeLayer And Not (TypeOf pLayer Is IAnnotationLayer Or TypeOf pLayer Is IRasterLayer) Then
                Dim pGroupLayer As ICompositeLayer = CType(pLayer, ICompositeLayer)
                Dim j As Integer
                For j = 0 To pGroupLayer.Count - 1
                    'added to handle a second group layer
                    If TypeOf pGroupLayer.Layer(j) Is ICompositeLayer And Not (TypeOf pGroupLayer.Layer(j) Is IAnnotationLayer Or TypeOf pGroupLayer.Layer(j) Is IRasterLayer) Then
                        Dim pGroupLayer2 As ICompositeLayer = CType(pGroupLayer.Layer(j), ICompositeLayer)
                        Dim j2 As Integer
                        For j2 = 0 To pGroupLayer2.Count - 1
                            If UCase(layername) = "ANY" Then
                                If pGroupLayer2.Layer(j2).Name Like "T.*" And pGroupLayer2.Layer(j2).SupportedDrawPhases = 7 Then 'Not pLayer.Name Like "*Topology"
                                    pFLayer = pGroupLayer2.Layer(j2)
                                    If Not pFLayer.FeatureClass.FeatureDataset Is Nothing Then
                                        pWkspc = pFLayer.FeatureClass.FeatureDataset.Workspace
                                        Exit Do
                                    End If
                                End If
                            Else
                                If pGroupLayer2.Layer(j2).Name = layername Then
                                    pFLayer = pGroupLayer2.Layer(j2)
                                    pWkspc = pFLayer.FeatureClass.FeatureDataset.Workspace
                                    Exit Do
                                End If
                            End If
                        Next j2
                    ElseIf UCase(layername) = "ANY" Then
                        If pGroupLayer.Layer(j).Name Like "T.*" And pGroupLayer.Layer(j).SupportedDrawPhases = 7 Then 'Not pLayer.Name Like "*Topology"
                            pFLayer = pGroupLayer.Layer(j)
                            If Not pFLayer.FeatureClass.FeatureDataset Is Nothing Then
                                pWkspc = pFLayer.FeatureClass.FeatureDataset.Workspace
                                Exit Do
                            End If
                        End If
                    Else
                        If pGroupLayer.Layer(j).Name = layername Then
                            pFLayer = pGroupLayer.Layer(j)
                            pWkspc = pFLayer.FeatureClass.FeatureDataset.Workspace
                            Exit Do
                        End If
                    End If
                Next j
            ElseIf UCase(layername) = "ANY" Then
                If pLayer.Name Like "T.*" And pLayer.SupportedDrawPhases = 7 Then 'Not pLayer.Name Like "*Topology"
                    pFLayer = pLayer
                    If Not pFLayer.FeatureClass.FeatureDataset Is Nothing Then
                        pWkspc = pFLayer.FeatureClass.FeatureDataset.Workspace
                        Exit Do
                    End If
                End If
            Else
                If pLayer.Name = layername Then
                    pFLayer = pLayer
                    pWkspc = pFLayer.FeatureClass.FeatureDataset.Workspace
                    Exit Do
                End If
            End If
            pLayer = pEnumLayers.Next
        Loop
        If pWkspc Is Nothing Then
            MsgBox("Could Not Open Workspace, no T. landbase layers found in Map")
            GetWorkspaceTable = Nothing
        Else
            pversionW = pWkspc
            pWSE = pversionW
            pVersion = pversionW
            pversioninfo = pVersion.VersionInfo
            If Not pForQuery Then
                pWSE.StartEditing(False)
                pWSE.StartEditOperation()
            End If
            pFeatWorkSpace = pWSE 'QI
            pCheckTable = pFeatWorkSpace.OpenTable(pTableName)
            If pCheckTable Is Nothing Then
                MsgBox("Could not Load table: " & pTableLoad)
                If Not pForQuery Then
                    If pWSE.IsBeingEdited Then
                        pWSE.StopEditOperation()
                        pWSE.StopEditing(True)
                    End If
                End If
                GetWorkspaceTable = Nothing
            Else
                GetWorkspaceTable = pCheckTable
            End If
        End If
    End Function


    Shared Function GetUnVWorkspaceTable(ByVal layername As String, ByVal pmActiveView As IActiveView, ByVal pTableLoad As String) As ITable
        GetUnVWorkspaceTable = Nothing
        Dim pWkspc As IWorkspace
        Dim pMap As Map
        Dim pEnumLayers As IEnumLayer
        Dim pLayer As ILayer
        Dim pFLayer As IFeatureLayer
        Dim pFeatWorkSpace As IFeatureWorkspace
        Dim pTableName As String
        Dim pCheckTable As ITable

        pTableName = pTableLoad
        pWkspc = Nothing
        pMap = pmActiveView.FocusMap
        pEnumLayers = pMap.Layers(Nothing, False)
        pLayer = pEnumLayers.Next
        Do Until pLayer Is Nothing
            'added to handle grouped layers
            If TypeOf pLayer Is ICompositeLayer And Not (TypeOf pLayer Is IAnnotationLayer Or TypeOf pLayer Is IRasterLayer) Then
                Dim pGroupLayer As ICompositeLayer = CType(pLayer, ICompositeLayer)
                Dim j As Integer
                For j = 0 To pGroupLayer.Count - 1
                    'added to handle a second group layer
                    If TypeOf pGroupLayer.Layer(j) Is ICompositeLayer And Not (TypeOf pGroupLayer.Layer(j) Is IAnnotationLayer Or TypeOf pGroupLayer.Layer(j) Is IRasterLayer) Then
                        Dim pGroupLayer2 As ICompositeLayer = CType(pGroupLayer.Layer(j), ICompositeLayer)
                        Dim j2 As Integer
                        For j2 = 0 To pGroupLayer2.Count - 1
                            If UCase(layername) = "ANY" Then
                                If pGroupLayer2.Layer(j2).Name Like "T.*" And pGroupLayer2.Layer(j2).SupportedDrawPhases = 7 Then 'Not pLayer.Name Like "*Topology"
                                    pFLayer = pGroupLayer2.Layer(j2)
                                    If Not pFLayer.FeatureClass.FeatureDataset Is Nothing Then
                                        pWkspc = pFLayer.FeatureClass.FeatureDataset.Workspace
                                        Exit Do
                                    End If
                                End If
                            Else
                                If pGroupLayer2.Layer(j2).Name = layername Then
                                    pFLayer = pGroupLayer2.Layer(j2)
                                    pWkspc = pFLayer.FeatureClass.FeatureDataset.Workspace
                                    Exit Do
                                End If
                            End If
                        Next j2
                    ElseIf UCase(layername) = "ANY" Then
                        If pGroupLayer.Layer(j).Name Like "T.*" And pGroupLayer.Layer(j).SupportedDrawPhases = 7 Then 'Not pLayer.Name Like "*Topology"
                            pFLayer = pGroupLayer.Layer(j)
                            If Not pFLayer.FeatureClass.FeatureDataset Is Nothing Then
                                pWkspc = pFLayer.FeatureClass.FeatureDataset.Workspace
                                Exit Do
                            End If
                        End If
                    Else
                        If pGroupLayer.Layer(j).Name = layername Then
                            pFLayer = pGroupLayer.Layer(j)
                            pWkspc = pFLayer.FeatureClass.FeatureDataset.Workspace
                            Exit Do
                        End If
                    End If
                Next j
            ElseIf UCase(layername) = "ANY" Then
                If pLayer.Name Like "T.*" And pLayer.SupportedDrawPhases = 7 Then 'Not pLayer.Name Like "*Topology"
                    pFLayer = pLayer
                    If Not pFLayer.FeatureClass.FeatureDataset Is Nothing Then
                        pWkspc = pFLayer.FeatureClass.FeatureDataset.Workspace
                        Exit Do
                    End If
                End If
            Else
                If pLayer.Name = layername Then
                    pFLayer = pLayer
                    pWkspc = pFLayer.FeatureClass.FeatureDataset.Workspace
                    Exit Do
                End If
            End If
            pLayer = pEnumLayers.Next
        Loop
        If pWkspc Is Nothing Then
            MsgBox("Could Not Open Workspace, no T. landbase layers found in Map")
            GetUnVWorkspaceTable = Nothing
        Else
            pFeatWorkSpace = pWkspc
            pCheckTable = pFeatWorkSpace.OpenTable(pTableName)
            If pCheckTable Is Nothing Then
                MsgBox("Could not Load table: " & pTableLoad)
                GetUnVWorkspaceTable = Nothing
            Else
                GetUnVWorkspaceTable = pCheckTable
            End If
        End If
    End Function

    Shared Function GetRoadNameUsingRoadID(ByVal pRoadID As Long, ByVal pActiveview As IActiveView) As String

        GetRoadNameUsingRoadID = ""
        'First we need to access the table and then once its open query it to find the name corrsponding to
        'the split segments RoadID
        Dim pQueryFilter As IQueryFilter, pTable As ITable
        Dim pCursor As ICursor, pRow As IRow
        Dim Index1 As Integer
        Index1 = 0
        Dim lngRoadID As Long
        lngRoadID = pRoadID
        pTable = GetWorkspaceTable("ANY", pActiveview, ROAD_NAME_DATASRC, True)
        pQueryFilter = New QueryFilter
        pQueryFilter.WhereClause = "ROAD_ID = " & lngRoadID
        pCursor = pTable.Search(pQueryFilter, False)
        pRow = pCursor.NextRow
        Do Until pRow Is Nothing
            GetRoadNameUsingRoadID = pRow.Value(pRow.Fields.FindField("ROAD20_NM"))
            Index1 = Index1 + 1
            pRow = pCursor.NextRow
        Loop
        If Index1 > 1 Then MsgBox(Index1 & "Records found for that RoadID")

    End Function

    Shared Function DoAddressesOverlap(ByVal RoadID As Long, ByVal roadFC As IFeatureClass) As Boolean

        Try
            'This function will check to see if there are any overlapping address ranges among segments of the specified road
            Dim pRoadCursor As IFeatureCursor, pQF As IQueryFilter, pRoad As IFeature
            'Dim intLowAddr() As Long, intHighAddr() As Long, intLLowAddr As Long, intLHiAddr As Long, intRLowAddr As Long, intRHiAddr As Long
            Dim intAbLoFld As Integer, intAbHiFld As Integer, intLLowFld As Integer, intLHiFld As Integer, intRLowFld As Integer, intRHiFld As Integer
            Dim intAbLo As Long, intAbHi As Long, intLLow As Long, intLHi As Long, intRLow As Long, intRHi As Long
            Dim vLoAddress() As Long, vHiAddress() As Long, vLLowAddress() As Long, vLHiAddress() As Long, vRLowAddress() As Long, vRHiAddress() As Long
            Dim i As Integer
            '-set a query filter that will get all roads with the specified ID
            pQF = New QueryFilter
            pQF.WhereClause = RD_ROADID_FLD_NAME & " = " & RoadID
            '-get a cursor of all road features with the specified ID (segments of the same road)
            pRoadCursor = roadFC.Search(pQF, True)
            '-pull out the first feature
            pRoad = pRoadCursor.NextFeature
            '-complain if a feature was not found (invalid RoadID, e.g.)
            If pRoad Is Nothing Then
                MsgBox("No roads were identified with that RoadID (" & RoadID & ").", vbCritical, "Check Overlap")
                DoAddressesOverlap = -99 'flag to indicate an error to the calling procedure
                Exit Function
            End If
            '-get the indices for the absolute low and high address range fields
            intAbLoFld = pRoad.Fields.FindField(RD_ABLOADDR_FLD_NAME)
            intAbHiFld = pRoad.Fields.FindField(RD_ABHIADDR_FLD_NAME)
            intLLowFld = pRoad.Fields.FindField(RD_LLOWADDR_FLD_NAME)
            intLHiFld = pRoad.Fields.FindField(RD_LHIGHADDR_FLD_NAME)
            intRLowFld = pRoad.Fields.FindField(RD_RLOWADDR_FLD_NAME)
            intRHiFld = pRoad.Fields.FindField(RD_RHIGHADDR_FLD_NAME)
            '-complain if they're not found
            If intAbLoFld < 0 Or intAbHiFld < 0 Then
                MsgBox("Error accessing address ranges, one of the following fields was not found." & vbCr & _
                                RD_ABLOADDR_FLD_NAME & vbCr & _
                                RD_LLOWADDR_FLD_NAME & vbCr & _
                                RD_LHIGHADDR_FLD_NAME & vbCr & _
                                RD_RLOWADDR_FLD_NAME & vbCr & _
                                RD_RHIGHADDR_FLD_NAME & vbCr & _
                                RD_ABHIADDR_FLD_NAME, vbCritical, "Check Address Ranges")
                Exit Function
            End If
            '-loop thru each segment
            Do Until pRoad Is Nothing
                '-redim the arrays to hold another value
                ReDim Preserve vLoAddress(i + 1)
                ReDim Preserve vHiAddress(i + 1)
                ReDim Preserve vLLowAddress(i + 1)
                ReDim Preserve vLHiAddress(i + 1)
                ReDim Preserve vRLowAddress(i + 1)
                ReDim Preserve vRHiAddress(i + 1)

                '-get the segment abs low/high address vals
                intAbLo = pRoad.Value(intAbLoFld)
                intAbHi = pRoad.Value(intAbHiFld)
                intLLow = pRoad.Value(intLLowFld)
                intLHi = pRoad.Value(intLHiFld)
                intRLow = pRoad.Value(intRLowFld)
                intRHi = pRoad.Value(intRHiFld)
                '-add the low val to an array
                vLoAddress(i) = intAbLo
                '-add the high val to an array
                vHiAddress(i) = intAbHi
                '-add the left low address to the left low arry etc
                vLLowAddress(i) = intLLow
                vLHiAddress(i) = intLHi
                vRLowAddress(i) = intRLow
                vRHiAddress(i) = intRHi

                '-get next segment
                pRoad = pRoadCursor.NextFeature
                '-increment the array index
                i = i + 1
                '-end of loop
            Loop
            '-sort each array from low-->high. In the resulting arrays, the corresponding low/high addresses are at the same index
            '-to get the low and high for segment #43 for example, you could simply do this: LoVal=vLoAddress(43), HiVal=vHiAddress(43)
            SortNumberArrayASC(vLoAddress) 'function in "Utilities" module
            SortNumberArrayASC(vHiAddress)
            SortNumberArrayASC(vLLowAddress)
            SortNumberArrayASC(vLHiAddress)
            SortNumberArrayASC(vRLowAddress)
            SortNumberArrayASC(vRHiAddress)

            '-loop thru arrays, examine to see if there is any overlap
            '-arrays look like this:
            ' ___________
            '|  Low  |  High  |
            '---------------------
            '| 100   |  199   |
            '|  200  |  299   |
            '|  300  |  399   |
            '|  350  |  499   |
            '---------------------
            '-to check for overlap, the code will get a "High" value and see if it's less than the following "Low" value
            '~~in the example above, the first comparison would be made with 199 (high) and 200 (following low)
            '~~all checks in the example above would be free of overlap until the last one (350 < 399)
            For i = 0 To UBound(vLoAddress) - 1
                '-uncomment the code below to show the array values side by side in the immediate window
                'Debug.Print "Lo(" & i & ") = " & vLoAddress(i) & "  Hi(" & i & ") = " & vHiAddress(i)
                intAbHi = vHiAddress(i) 'get the segment's high range
                intAbLo = vLoAddress(i + 1) 'get the following segment's low range (this is where overlap would occur)
                '-if overlap is found, exit the loop and return true
                If intAbLo < intAbHi Then
                    DoAddressesOverlap = True 'overlap found
                    Exit Function 'no need to hang around
                End If
                '-end loop
            Next i

            'Next check for overlap along the left side of the street
            For i = 0 To UBound(vLLowAddress) - 1
                intLHi = vLHiAddress(i)
                intLLow = vLLowAddress(i + 1)
                If intLLow < intLHi Then
                    DoAddressesOverlap = True
                    Exit Function
                End If
            Next i


            For i = 0 To UBound(vRLowAddress) - 1
                intRHi = vRHiAddress(i)
                intRLow = vRLowAddress(i + 1)
                If intRLow < intRHi Then
                    DoAddressesOverlap = True
                    Exit Function
                End If
            Next i

            DoAddressesOverlap = False
            '-return false (no overlap)

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try

    End Function

    Shared Function GetSequenceNumber(ByVal FWorkspace As IFeatureWorkspace, ByVal TableName As String, ByVal SeqTable As String) As Long
        Try
            Dim pQueryDef As IQueryDef
            Dim pCursor As ICursor
            Dim pRow As IRow
            ' Define the query
            pQueryDef = FWorkspace.CreateQueryDef
            pQueryDef.SubFields = SeqTable & ".NEXTVAL"
            pQueryDef.Tables = "sys.dual"
            pCursor = pQueryDef.Evaluate
            'Get the sequence value from the returned row...
            pRow = pCursor.NextRow
            GetSequenceNumber = pRow.Value(0)
        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Function

    Shared Sub AddLotNoAnno(ByVal pLotFeature As IFeature, ByVal pAnnoFWorkspace As IFeatureWorkspace, ByVal pLotActiveView As IActiveView)

        '------------------------------------------
        'ADDED 10112012 on removal of linked anno
        '-------------------------------------------

        Dim pPoint As IPoint
        Dim pFeature2 As IFeature
        Dim pAnnoFeat As IAnnotationFeature
        Dim pElement As IElement
        Dim pTextElement As ITextElement
        Dim pTextSymbol As ITextSymbol
        Dim pFeatClass As IFeatureClass
        Dim pEnvelope As IEnvelope
        Dim pRefEnvelope As IEnvelope

        pTextSymbol = New ESRI.ArcGIS.Display.TextSymbol
        With pTextSymbol
            .Size = 38
            .Angle = 0
        End With

        'Get the anno featureclass from workspace
        pFeatClass = pAnnoFWorkspace.OpenFeatureClass(Anno_LotNo_DATASRC)

        Dim pAddrNoChk As String
        If Not IsDBNull(pLotFeature.Value(pLotFeature.Fields.FindField(LOT_LOTNO_FLD_NAME))) Then
            pAddrNoChk = pLotFeature.Value(pLotFeature.Fields.FindField(LOT_LOTNO_FLD_NAME)).ToString()
            If Not pAddrNoChk = "" Then
                pFeature2 = pFeatClass.CreateFeature     'create a new annotation feature
                pAnnoFeat = pFeature2
                pTextElement = New TextElement
                'Create a new text element for each new lot feature and give its text value the Lot No
                With pTextElement
                    .ScaleText = False
                    .Symbol = pTextSymbol
                    .Text = pLotFeature.Value(pLotFeature.Fields.FindField(LOT_LOTNO_FLD_NAME))
                End With

                Dim pGroupSymbolElement As IGroupSymbolElement
                pGroupSymbolElement = pTextElement
                pGroupSymbolElement.SymbolID = 0
                pGroupSymbolElement.Size = 38

                pEnvelope = pLotFeature.Shape.Envelope
                Dim pArea As IArea
                pArea = pLotFeature.ShapeCopy
                pPoint = New ESRI.ArcGIS.Geometry.Point

                pPoint.X = pArea.LabelPoint.X
                pPoint.Y = pArea.LabelPoint.Y

                'Set the Anno geometry the same os the selected Lot
                pElement = pGroupSymbolElement 'pTextElement
                pElement.Geometry = pPoint
                pAnnoFeat.Annotation = pElement
                pFeature2.Store()
                'refresh so the anno shows
                pEnvelope = pLotFeature.Shape.Envelope
                pRefEnvelope = pEnvelope
                pRefEnvelope.XMin = pEnvelope.XMin - 100
                pRefEnvelope.YMin = pEnvelope.YMin - 100
                pRefEnvelope.XMax = pEnvelope.XMax + 100
                pRefEnvelope.YMax = pEnvelope.YMax + 100
                pLotActiveView.PartialRefresh(6, Nothing, pRefEnvelope)

            End If
        End If

    End Sub

#End Region

#Region "Arrays"

    Shared Sub SortStringArrayASC(ByRef vArray() As String)

        'This sub will sort an array of values (strings) in ascending order
        Dim vTmp As String
        Dim i As Integer, j As Integer
        ' Loop through each element in the array.
        For i = 0 To UBound(vArray) - 1
            For j = i + 1 To UBound(vArray)
                '-compare adjacent values, switch them if they are not in order
                If StrComp(vArray(i), vArray(j), vbTextCompare) > 0 Then
                    vTmp = vArray(i)
                    vArray(i) = vArray(j)
                    vArray(j) = vTmp
                End If
            Next j
        Next i

    End Sub

    Shared Sub SortNumberArrayASC(ByRef vArray() As Long)
        'This sub will sort an array of values (numbers) in ascending order
        Dim vTmp As Long
        Dim i As Integer, j As Integer
        ' Loop through each element in the array.
        For i = 0 To UBound(vArray) - 1
            For j = i + 1 To UBound(vArray)
                '-compare adjacent values, switch them if they are not in order
                If (vArray(i) > vArray(j)) Then
                    vTmp = vArray(i)
                    vArray(i) = vArray(j)
                    vArray(j) = vTmp
                End If
            Next j
        Next i
    End Sub

#End Region
  
End Class
