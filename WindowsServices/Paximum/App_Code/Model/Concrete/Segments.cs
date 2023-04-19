using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("Segments")]
    public class Segments : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
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
        private int? _FlightClassesId;
        [JsonPropertyName("flightclassesid")]
        public int? FlightClassesId
        {
            get { return _FlightClassesId; }
            set { _FlightClassesId = value; }
        }

        private int? _ArrivalId;
        [JsonPropertyName("arrivalid")]
        public int? ArrivalId
        {
            get { return _ArrivalId; }
            set { _ArrivalId = value; }
        }

        private int? _DepartureId;
        [JsonPropertyName("departureid")]
        public int? DepartureId
        {
            get { return _DepartureId; }
            set { _DepartureId = value; }
        }
        private int? _AirLinesId;
        [JsonPropertyName("airlinesid")]
        public int? AirLinesId
        {
            get { return _AirLinesId; }
            set { _AirLinesId = value; }
        }
        private int? _MarketingAirLineId;
        [JsonPropertyName("maketingairlinesid")]
        public int? MarketingAirLineId
        {
            get { return _MarketingAirLineId; }
            set { _MarketingAirLineId = value; }
        }
        private int? _ItemsId;
        [JsonPropertyName("itemsid")]
        public int? ItemsId
        {
            get { return _ItemsId; }
            set { _ItemsId = value; }
        }
        private int? _Duration;
        [JsonPropertyName("duration")]
        public int? Duration
        {
            get { return _Duration; }
            set { _Duration = value; }
        }
        private string _AirCraft;
        [JsonPropertyName("aircraft")]
        public string AirCraft
        {
            get { return _AirCraft; }
            set { _AirCraft = value; }
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
        private int _FlightId;
        [JsonPropertyName("flightid")]
        public int FlightId
        {
            get { return _FlightId; }
            set { _FlightId = value; }
        }
    }
}
