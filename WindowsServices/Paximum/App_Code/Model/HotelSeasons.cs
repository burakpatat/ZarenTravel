using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using Paximum.Response.OfferDetail;

namespace Model.Concrete
{
    [Table("HotelSeasons")]
    public class HotelSeasons : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _SystemId;
        [JsonPropertyName("systemid")]
        public string SystemId
        {
            get { return _SystemId; }
            set { _SystemId = value; }
        }
        private string _Name;
        [JsonPropertyName("name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private DateTime? _BeginDate;
        [JsonPropertyName("begindate")]
        public DateTime? BeginDate
        {
            get { return _BeginDate; }
            set { _BeginDate = value; }
        }
        private DateTime? _EndDate;
        [JsonPropertyName("enddate")]
        public DateTime? EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }
        private int? _LanguageId;
        [JsonPropertyName("languageid")]
        public int? LanguageId
        {
            get { return _LanguageId; }
            set { _LanguageId = value; }
        }
        private int? _ApiId;
        [JsonPropertyName("apiid")]
        public int? ApiId
        {
            get { return _ApiId; }
            set { _ApiId = value; }
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
        private int? _HotelId;
        [JsonPropertyName("hotelid")]
        public int? HotelId
        {
            get { return _HotelId; }
            set { _HotelId = value; }
        }
        private int? _Type;
        [JsonPropertyName("type")]
        public int? Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
    }
}
