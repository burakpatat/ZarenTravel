using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("Flights")]
    public class Flights : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int? _Provider;
        [JsonPropertyName("provider")]
        public int? Provider
        {
            get { return _Provider; }
            set { _Provider = value; }
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
        private int? _AvailableSeatCount;
        [JsonPropertyName("availableseatcount")]
        public int? AvailableSeatCount
        {
            get { return _AvailableSeatCount; }
            set { _AvailableSeatCount = value; }
        }
        private int? _AvailableSeatCountType;
        [JsonPropertyName("availableseatcounttype")]
        public int? AvailableSeatCountType
        {
            get { return _AvailableSeatCountType; }
            set { _AvailableSeatCountType = value; }
        }

        private bool? _ReservableInfo;
        [JsonPropertyName("reservableinfo")]
        public bool? ReservableInfo
        {
            get { return _ReservableInfo; }
            set { _ReservableInfo = value; }
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
