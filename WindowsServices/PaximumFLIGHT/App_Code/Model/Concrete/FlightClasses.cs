using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("FlightClasses")]
    public class FlightClasses : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _Name;
        [JsonPropertyName("name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private int? _Type;
        [JsonPropertyName("type")]
        public int? Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        private string _Code;
        [JsonPropertyName("code")]
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        private int? _FlightItemId;
        [JsonPropertyName("flightitemid")]
        public int? FlightItemId
        {
            get { return _FlightItemId; }
            set { _FlightItemId = value; }
        }
        private int? _FlightId;
        [JsonPropertyName("flightid")]
        public int? FlightId
        {
            get { return _FlightId; }
            set { _FlightId = value; }
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
       
        private int? _SegmentId;
        [JsonPropertyName("segmentid")]
        public int? SegmentId
        {
            get { return _SegmentId; }
            set { _SegmentId = value; }
        }
    }
}
