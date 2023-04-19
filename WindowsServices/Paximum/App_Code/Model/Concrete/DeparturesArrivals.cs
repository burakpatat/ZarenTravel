using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("DeparturesArrivals")]
    public class DeparturesArrivals : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private DateTime? _Date;
        [JsonPropertyName("date")]
        public DateTime? Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        private int? _CountryId;
        [JsonPropertyName("countryid")]
        public int? CountryId
        {
            get { return _CountryId; }
            set { _CountryId = value; }
        }
        private int? _CityId;
        [JsonPropertyName("cityid")]
        public int? CityId
        {
            get { return _CityId; }
            set { _CityId = value; }
        }
        private int? _AirPortsId;
        [JsonPropertyName("airportsid")]
        public int? AirPortsId
        {
            get { return _AirPortsId; }
            set { _AirPortsId = value; }
        }
        private int? _GeoLocationId;
        [JsonPropertyName("geolocationid")]
        public int? GeoLocationId
        {
            get { return _GeoLocationId; }
            set { _GeoLocationId = value; }
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
        private int? _FlightItemsId;
        [JsonPropertyName("updatedby")]
        public int? FlightItemsId
        {
            get { return _FlightItemsId; }
            set { _FlightItemsId = value; }
        }
        
    }
}
