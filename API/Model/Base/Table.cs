
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Model.Concrete
{

    public class Table : IEntity
    {
        private string _TableName;
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }

        private string _ProcedureName;
        public string ProcedureName
        {
            get { return _ProcedureName; }
            set { _ProcedureName = value; }
        }

        private string _Schema;
        public string Schema
        {
            get { return _Schema; }
            set { _Schema = value; }
        }
        public string ProjectName { get; set; }
        public string Connection { get; set; }

        private string _DisplayName;
        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }

        private long? _ObjectId;
        public long? ObjectId
        {
            get { return _ObjectId; }
            set { _ObjectId = value; }
        }

        private List<string> _AllowedCors;
        public List<string> AllowedCors
        {
            get { return _AllowedCors; }
            set { _AllowedCors = value; }
        }

        public List<DatabaseColumns> Columns { get; set; }

        public List<Tabs> Tabs = new List<Tabs>();

        public bool ExcludeInCodeGen { get; set; }

        public string Name { get; set; }

        public string AddFeature { get; set; }

        public string DeleteFeature { get; set; }

        public string EditFeature { get; set; }

        public string MultiDeleteFeature { get; set; }

        public string NumberOfRows { get; set; }

        public string MenuName { get; set; }

        public string DisplayText { get; set; }

        public string DeleteFormTitle { get; set; }

        public string DeleteFormMessage { get; set; }

        private string _Query;
        public string Query
        {
            get { return _Query; }
            set { _Query = value; }
        }
        private string _RequestHeader;
        public string RequestHeader
        {
            get { return _RequestHeader; }
            set { _RequestHeader = value; }
        }

        private List<string> _ThisUsersCanSee;
        public List<string> ThisUsersCanSee
        {
            get { return _ThisUsersCanSee; }
            set { _ThisUsersCanSee = value; }
        }

        private List<string> _ThisRolesCanSee;
        public List<string> ThisRolesCanSee
        {
            get { return _ThisRolesCanSee; }
            set { _ThisRolesCanSee = value; }
        }

        private List<string> _ThisRoleGroupsCanSee;
        public List<string> ThisRoleGroupsCanSee
        {
            get { return _ThisRoleGroupsCanSee; }
            set { _ThisRoleGroupsCanSee = value; }
        }

        private bool _IsRouting;
        public bool IsRouting
        {
            get { return _IsRouting; }
            set { _IsRouting = value; }
        }
        private bool _HasMultiLanguage;
        public bool HasMultiLanguage
        {
            get { return _HasMultiLanguage; }
            set { _HasMultiLanguage = value; }
        }

        private bool _ForUI;
        public bool ForUser
        {
            get { return _ForUI; }
            set { _ForUI = value; }
        }
        private int _CMSGridSize;
        public int CMSGridSize
        {
            get { return _CMSGridSize; }
            set { _CMSGridSize = value; }
        }

        private int _TableOrder;
        public int TableOrder
        {
            get { return _TableOrder; }
            set { _TableOrder = value; }
        }
        private string _ParentTable;
        public string ParentTable
        {
            get { return _ParentTable; }
            set { _ParentTable = value; }
        }

        private bool _HasPaging;
        public bool HasPaging
        {
            get { return _HasPaging; }
            set { _HasPaging = value; }
        }

        private bool _IsEnumType;
        public bool IsEnumType
        {
            get { return _IsEnumType; }
            set { _IsEnumType = value; }
        }

        private bool _IsLogging;
        public bool IsLogging
        {
            get { return _IsLogging; }
            set { _IsLogging = value; }
        }

        private string _CMSIcon;
        public string CMSIcon
        {
            get { return _CMSIcon; }
            set { _CMSIcon = value; }
        }


        private List<string> _ListTemplateParts;
        public List<string> ListTemplatePart
        {
            get { return _ListTemplateParts; }
            set { _ListTemplateParts = value; }
        }

        private List<string> _DetailTemplateParts;
        public List<string> DetailTemplateParts
        {
            get { return _DetailTemplateParts; }
            set { _DetailTemplateParts = value; }
        }

        private List<Dictionary<string, string>> _ForeignKeyTables;
        public List<Dictionary<string, string>> ForeignKeyTables
        {
            get { return _ForeignKeyTables; }
            set { _ForeignKeyTables = value; }
        }

        private List<Tuple<string, Dictionary<JoinType, string>>> _JoinTables;
        public List<Tuple<string, Dictionary<JoinType, string>>> JoinTables
        {
            get { return _JoinTables; }
            set { _JoinTables = value; }
        }

        private bool? _IsSystemTable;
        public bool? IsSystemTable
        {
            get { return _IsSystemTable; }
            set { _IsSystemTable = value; }
        }

        private bool _HasExcelExport;
        public bool HasExcelExport
        {
            get { return _HasExcelExport; }
            set { _HasExcelExport = value; }
        }
        private bool _HasPdfExport;
        public bool HasPdfExport
        {
            get { return _HasPdfExport; }
            set { _HasPdfExport = value; }
        }
        private bool _HasPrintEvent;
        public bool HasPrintEvent
        {
            get { return _HasPrintEvent; }
            set { _HasPrintEvent = value; }
        }
        private bool _HasCopyEvent;
        public bool HasCopyEvent
        {
            get { return _HasCopyEvent; }
            set { _HasCopyEvent = value; }
        }
        private bool _OnLeftMenu;
        public bool OnLeftMenu
        {
            get { return _OnLeftMenu; }
            set { _OnLeftMenu = value; }
        }

        private bool _OnLeftMenuTargetBlank;
        public bool OnLeftMenuTargetBlank
        {
            get { return _OnLeftMenuTargetBlank; }
            set { _OnLeftMenuTargetBlank = value; }
        }
        private bool _HasAudit;
        public bool HasAudit
        {
            get { return _HasAudit; }
            set { _HasAudit = value; }
        }
        private bool _HasCreateBtnOnList;
        public bool HasCreateBtnOnList
        {
            get { return _HasCreateBtnOnList; }
            set { _HasCreateBtnOnList = value; }
        }

        private string _CreateBtnOnListText;
        public string CreateBtnOnListText
        {
            get { return _CreateBtnOnListText; }
            set { _CreateBtnOnListText = value; }
        }

        private string _CreateBtnOnListIcon;
        public string CreateBtnOnListIcon
        {
            get { return _CreateBtnOnListIcon; }
            set { _CreateBtnOnListIcon = value; }
        }

        private bool _DragAndDrop;
        public bool DragAndDrop
        {
            get { return _DragAndDrop; }
            set { _DragAndDrop = value; }
        }
        private bool _HasSecurityForApi;
        public bool HasSecurityForApi
        {
            get { return _HasSecurityForApi; }
            set { _HasSecurityForApi = value; }
        }

        private string _JWTKey;
        public string JWTKey
        {
            get { return _JWTKey; }
            set { _JWTKey = value; }
        }

        private bool _CanBeGenerate;
        public bool CanBeGenerate
        {
            get { return _CanBeGenerate; }
            set { _CanBeGenerate = value; }
        }

        private DateTime _LastGenerateDate;
        public DateTime LastGenerateDate
        {
            get { return _LastGenerateDate; }
            set { _LastGenerateDate = value; }
        }

        private List<Methods> _MethodList;
        public List<Methods> MethodList
        {
            get { return _MethodList; }
            set { _MethodList = value; }
        }
    }

    public class ServiceMethods
    {
        [JsonPropertyName("canCreate")]
        public bool IsMagic { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        [JsonPropertyName("header")]
        public Dictionary<string, string> HeaderParameters { get; set; }

        [JsonPropertyName("request")]
        public List<RequestParameter> Request { get; set; }

        [JsonPropertyName("response")]
        public List<ResponseParameter> Response { get; set; }
        [JsonPropertyName("query")]
        public string Query { get; set; }
        [JsonPropertyName("avaibleparams")]
        public List<AvailableParameters> AvailableParameters { get; set; }
    }


    public class SchemeApi
    {
        [JsonPropertyName("c")]
        public string ConnectionString { get; set; }

        [JsonPropertyName("t")]
        public string Table { get; set; }

        [JsonPropertyName("f")]
        public string Function { get; set; }

        [JsonPropertyName("v")]
        public string View { get; set; }

        [JsonPropertyName("s")]
        public string SchemessName { get; set; }
    }


    public class AvailableParameters
    {

        private string _ColumnName;

        [JsonPropertyName("cn")]
        public string ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }

        private string _DbType;

        [JsonPropertyName("dt")]
        public string DbType
        {
            get { return _DbType; }
            set { _DbType = value; }
        }
        private int? _MaxLength;

        [JsonPropertyName("ml")]
        public int? MaxLength
        {
            get { return _MaxLength; }
            set { _MaxLength = value; }
        }

        private bool? _IsRequired;
        [JsonPropertyName("rq")]
        public bool? IsRequired
        {
            get { return _IsRequired; }
            set { _IsRequired = value; }
        }
    }
    public class Methods
    {

        public string Name { get; set; }
        public Dictionary<string, string> HeaderParameters { get; set; }
        public List<RequestParams> Request { get; set; }
        public List<ResponseParams> Response { get; set; }

        public string Query { get; set; }
    }

    public class HtmlColumns
    {
        public List<Data> dataList { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("data")]
        public string Value { get; set; }
    }

    public class ReportIndex
    {
        public string Database;

        public string Table;

        public string IndexName;

        public string IndexType;

        public decimal AvgFrag;

        public long RowCt;

        public string StatsDt;
    }
    public enum JoinType
    {
        Left = 1,
        Inner = 2,
        Right = 3,


    }
}
