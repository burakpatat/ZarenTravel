using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("FlightItems")]
    public class FlightItems : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int? _ProductType;
        [JsonPropertyName("provider")]
        public int? ProductType
        {
            get { return _ProductType; }
            set { _ProductType = value; }
        }
        private string _ServiceTypes;
        [JsonPropertyName("provider")]
        public string ServiceTypes
        {
            get { return _ServiceTypes; }
            set { _ServiceTypes = value; }
        }
        private int? _SegmentNumber;
        [JsonPropertyName("segmentnumber")]
        public int? SegmentNumber
        {
            get { return _SegmentNumber; }
            set { _SegmentNumber = value; }
        }
        private string _FlightNo;
        [JsonPropertyName("flightno")]
        public string FlightNo
        {
            get { return _FlightNo; }
            set { _FlightNo = value; }
        }
        private string _PnlName;
        [JsonPropertyName("pnlname")]
        public string PnlName
        {
            get { return _PnlName; }
            set { _PnlName = value; }
        }
        private DateTime? _FlightDate;
        [JsonPropertyName("flightdate")]
        public DateTime? FlightDate
        {
            get { return _FlightDate; }
            set { _FlightDate = value; }
        } 

        private int? _FlightProviderId;
        [JsonPropertyName("flightproviderid")]
        public int? FlightProviderId
        {
            get { return _FlightProviderId; }
            set { _FlightProviderId = value; }
        }
        private int? _DeparturesId;
        [JsonPropertyName("departureid")]
        public int? DeparturesId
        {
            get { return _DeparturesId; }
            set { _DeparturesId = value; }
        }
        private int? _ArrivalsId;
        [JsonPropertyName("arrivalsid")]
        public int? ArrivalsId
        {
            get { return _ArrivalsId; }
            set { _ArrivalsId = value; }
        }
       
        private string _AirLinesId;
        [JsonPropertyName("airlinesid")]
        public string AirLinesId
        {
            get { return _AirLinesId; }
            set { _AirLinesId = value; }
        }
        private string _MarketingAirlines;
        [JsonPropertyName("marketingairlines")]
        public string MarketingAirlines
        {
            get { return _MarketingAirlines; }
            set { _MarketingAirlines = value; }
        }
        private int? _FlightClassesId;
        [JsonPropertyName("flightclassesid")]
        public int? FlightClassesId
        {
            get { return _FlightClassesId; }
            set { _FlightClassesId = value; }
        }
        private string _FlightClassesSystemId;
        [JsonPropertyName("flightclassessystemid")]
        public string FlightClassesSystemId
        {
            get { return _FlightClassesSystemId; }
            set { _FlightClassesSystemId = value; }
        }
        private int? _Duration;
        [JsonPropertyName("duration")]
        public int? Duration
        {
            get { return _Duration; }
            set { _Duration = value; }
        }
        private int? _DayChange;
        [JsonPropertyName("daychange")]
        public int? DayChange
        {
            get { return _DayChange; }
            set { _DayChange = value; }
        }
        private int? _Route;
        [JsonPropertyName("route")]
        public int? Route
        {
            get { return _Route; }
            set { _Route = value; }
        }
        private int? _StopCount;
        [JsonPropertyName("stopcount")]
        public int? StopCount
        {
            get { return _StopCount; }
            set { _StopCount = value; }
        }
        private int? _FlightType;
        [JsonPropertyName("flighttype")]
        public int? FlightType
        {
            get { return _FlightType; }
            set { _FlightType = value; }
        }
        
        private int? _FlightsId;
        [JsonPropertyName("flightsid")]
        public int? FlightsId
        {
            get { return _FlightsId; }
            set { _FlightsId = value; }
        }
        private int? _ApiId;
        [JsonPropertyName("apiid")]
        public int? ApiId
        {
            get { return _ApiId; }
            set { _ApiId = value; }
        }
        private int? _LanguageId;
        [JsonPropertyName("languageid")]
        public int? LanguageId
        {
            get { return _LanguageId; }
            set { _LanguageId = value; }
        }
        private string _SystemId;
        [JsonPropertyName("systemid")]
        public string SystemId
        {
            get { return _SystemId; }
            set { _SystemId = value; }
        }
        private DateTime? _CreatedDate;
        [JsonPropertyName("createddate")]
        public DateTime? CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        private DateTime? _UpdatedDate;
        [JsonPropertyName("updateddate")]
        public DateTime? UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        private int? _CreatedBy;
        [JsonPropertyName("createdby")]
        public int? CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        private int? _UpdatedBy;
        [JsonPropertyName("updatedby")]
        public int? UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
    }
}
