using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using Core.Entities;
namespace Model.Concrete
{
    public class RequestMethod
    {
        [JsonPropertyName("mt")]
        public ServiceMethods Method { get; set; }

        [JsonPropertyName("ht")]
        public string HttpMethod { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }
    }

    public class RequestProxy
    {
        [JsonPropertyName("tb")]
        public string Parameters { get; set; }
    }


    public class Method : IEntity
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private int _TopCount;
        public int TopCount
        {
            get { return _TopCount; }
            set { _TopCount = value; }
        }
        private DataTypeMapping _DbType;
        public DataTypeMapping DbType
        {
            get { return _DbType; }
            set { _DbType = value; }
        }


        private List<Table> _CRUDConnectedTables;
        public List<Table> CRUDConnectedTables
        {
            get { return _CRUDConnectedTables; }
            set { _CRUDConnectedTables = value; }
        }

        private int _MaxItemOnSize;
        public int MaxItemOnSize
        {
            get { return _MaxItemOnSize; }
            set { _MaxItemOnSize = value; }
        }

        private int _PageIndex;
        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }

        private string _Query;
        public string Query
        {
            get { return _Query; }
            set { _Query = value; }
        }

        private bool _IsResponseGeneric;
        public bool IsResponseGeneric
        {
            get { return _IsResponseGeneric; }
            set { _IsResponseGeneric = value; }
        }

        private object _NonGenericResponseType;
        public object NonGenericResponseType
        {
            get { return _NonGenericResponseType; }
            set { _NonGenericResponseType = value; }
        }

        private bool _CanGetResponse;
        public bool CanGetResponse
        {
            get { return _CanGetResponse; }
            set { _CanGetResponse = value; }
        }

        private bool _IsAsync;
        public bool IsAsync
        {
            get { return _IsAsync; }
            set { _IsAsync = value; }
        }

        private bool _IsCachedResponse;
        public bool IsCachedResponse
        {
            get { return _IsCachedResponse; }
            set { _IsCachedResponse = value; }
        }

        private Type _CacheType;
        public Type CacheType
        {
            get { return _CacheType; }
            set { _CacheType = value; }
        }

        private string _WhereQuery;
        public string WhereQuery
        {
            get { return _WhereQuery; }
            set { _WhereQuery = value; }
        }

        private string _BodyCode;
        public string BodyCode
        {
            get { return _BodyCode; }
            set { _BodyCode = value; }
        }

        private List<HttpMethod> _ApiAllowedMethods;
        public List<HttpMethod> ApiAllowedMethods
        {
            get { return _ApiAllowedMethods; }
            set { _ApiAllowedMethods = value; }
        }
        private List<HttpMethod> _ApiAllowedIP;
        public List<HttpMethod> ApiAllowedIP
        {
            get { return _ApiAllowedMethods; }
            set { _ApiAllowedMethods = value; }
        }
        private List<string> _AdminIP;
        public List<string> AdminIP
        {
            get { return _AdminIP; }
            set { _AdminIP = value; }
        }

        private MethotParameters _RequestModel;
        public MethotParameters RequestModel
        {
            get { return _RequestModel; }
            set { _RequestModel = value; }
        }

        private List<DatabaseColumns> _RequestList;
        public List<DatabaseColumns> RequestList
        {
            get { return _RequestList; }
            set { _RequestList = value; }
        }

        private List<DatabaseColumns> _ResponseParams;
        public List<DatabaseColumns> ResponseParams
        {
            get { return _ResponseParams; }
            set { _ResponseParams = value; }
        }

    }


    public class QueryStringsVisible
    {

        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("finish")]
        public int Finish { get; set; }



        [JsonPropertyName("size")]
        public string Size { get; set; }

        [JsonPropertyName("pagecount")]
        public string Pagecount { get; set; }

        [JsonPropertyName("pageindex")]
        public string Pageindex { get; set; }

        [JsonPropertyName("orderDesc")]
        public bool OrderDesc { get; set; }

        [JsonPropertyName("skip")]
        public string Skip { get; set; }

        [JsonPropertyName("group")]
        public string GroupBy { get; set; }

        [JsonPropertyName("having")]
        public string Having { get; set; }

        [JsonPropertyName("count")]
        public string Count { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("minval")]
        public string Minval { get; set; }

        [JsonPropertyName("maxval")]
        public string Maxval { get; set; }

        [JsonPropertyName("where")]
        public string Where { get; set; }

        // [JsonPropertyName("=")]
        public string Equal { get; set; }

        //  [JsonPropertyName("<")]
        [JsonPropertyName("Smallerthan")]
        public string Smallerthan { get; set; }

        //        [JsonPropertyName("<=")]
        // [JsonPropertyName("<=")]
        public string SmallerEqualthan { get; set; }

        // [JsonPropertyName(">")]
        public string Biggerthan { get; set; }

        //[JsonPropertyName(">=")]
        public string BiggerEqualthan { get; set; }

        [JsonPropertyName("startdate")]
        public string Startdate { get; set; }

        [JsonPropertyName("enddate")]
        public string Enddate { get; set; }

        [JsonPropertyName("column")]
        public string Column { get; set; }

        [JsonPropertyName("or")]
        public string Or { get; set; }

        [JsonPropertyName("likecolumn")]
        public string Like { get; set; }

        [JsonPropertyName("likecolumnleft")]
        public string LikeLeft { get; set; }

        [JsonPropertyName("likecolumnright")]
        public string LikeRight { get; set; }

        [JsonPropertyName("likecolumnleftright")]
        public string LikeLeftRight { get; set; }

        [JsonPropertyName("in")]
        public string In { get; set; }

        [JsonPropertyName("inner")]
        public string Inner { get; set; }

        [JsonPropertyName("outher")]
        public string Outher { get; set; }

        [JsonPropertyName("parameter")]
        public string Parameter { get; set; }

        [JsonPropertyName("json")]
        public string Json { get; set; }

        [JsonPropertyName("table")]
        public string Table { get; set; }

        [JsonPropertyName("directQ")]
        public bool DirectQ { get; set; }

        [JsonPropertyName("primaryColumn")]
        public string PrimaryColumn { get; set; }

        [JsonPropertyName("subquery")]
        public string Subquery { get; set; }

        // [JsonPropertyName("(")]
        public string OpenLeft { get; set; }

        //[JsonPropertyName(")")]
        public string CloserRight { get; set; }

        [JsonPropertyName("select")]
        public string Select { get; set; }

        [JsonPropertyName("insert")]
        public string InsertInto { get; set; }

        [JsonPropertyName("update")]
        public string Update { get; set; }

        [JsonPropertyName("delete")]
        public string Delete { get; set; }

        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("all")]
        public string All { get; set; }

        [JsonPropertyName("query")]
        public string Query { get; set; }

        [JsonPropertyName("between")]
        public string Between { get; set; }
    }

    public class QueryStrings
    {
        [JsonPropertyName("size")]
        public string Size;

        [JsonPropertyName("pagecount")]
        public string Pagecount;

        [JsonPropertyName("pageindex")]
        public string Pageindex;

        [JsonPropertyName("orderby")]
        public string Orderby;

        [JsonPropertyName("orderbyway")]
        public string OrderbyWay;

        [JsonPropertyName("skip")]
        public string Skip;

        [JsonPropertyName("group")]
        public string GroupBy;

        [JsonPropertyName("having")]
        public string Having;

        [JsonPropertyName("count")]
        public string Count;

        [JsonPropertyName("source")]
        public string Source;

        [JsonPropertyName("minval")]
        public string Minval;

        [JsonPropertyName("maxval")]
        public string Maxval;

        [JsonPropertyName("where")]
        public string Where;

        // [JsonPropertyName("=")]
        public string Equal;

        //  [JsonPropertyName("<")]
        [JsonPropertyName("Smallerthan")]
        public string Smallerthan;

        //        [JsonPropertyName("<=")]
        // [JsonPropertyName("<=")]
        public string SmallerEqualthan;

        // [JsonPropertyName(">")]
        public string Biggerthan;

        //[JsonPropertyName(">=")]
        public string BiggerEqualthan;

        [JsonPropertyName("startdate")]
        public string Startdate;

        [JsonPropertyName("enddate")]
        public string Enddate;

        [JsonPropertyName("column")]
        public string Column;

        [JsonPropertyName("or")]
        public string Or;

        [JsonPropertyName("likecolumn")]
        public string Like;

        [JsonPropertyName("likecolumnleft")]
        public string LikeLeft;

        [JsonPropertyName("likecolumnright")]
        public string LikeRight;

        [JsonPropertyName("likecolumnleftright")]
        public string LikeLeftRight;

        [JsonPropertyName("in")]
        public string In;

        [JsonPropertyName("inner")]
        public string Inner;

        [JsonPropertyName("outher")]
        public string Outher;

        [JsonPropertyName("parameter")]
        public string Parameter;

        [JsonPropertyName("json")]
        public string Json;

        [JsonPropertyName("table")]
        public string Table;

        [JsonPropertyName("directQ")]
        public bool DirectQ;

        [JsonPropertyName("primaryColumn")]
        public string PrimaryColumn;

        [JsonPropertyName("subquery")]
        public string Subquery;

        // [JsonPropertyName("(")]
        public string OpenLeft;

        //[JsonPropertyName(")")]
        public string CloserRight;

        [JsonPropertyName("select")]
        public string Select;

        [JsonPropertyName("insert")]
        public string InsertInto;

        [JsonPropertyName("update")]
        public string Update;

        [JsonPropertyName("delete")]
        public string Delete;

        [JsonPropertyName("from")]
        public string From;

        [JsonPropertyName("all")]
        public string All;

        [JsonPropertyName("query")]
        public string Query;

        [JsonPropertyName("between")]
        public string Between;
    }
}
