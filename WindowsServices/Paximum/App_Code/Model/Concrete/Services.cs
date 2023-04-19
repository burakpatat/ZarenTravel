using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("Services")]
    public class Services : IEntity
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
        private string _Thumbnail;
        [JsonPropertyName("thumbnail")]
        public string Thumbnail
        {
            get { return _Thumbnail; }
            set { _Thumbnail = value; }
        }
        private string _ThumbnailFull;
        [JsonPropertyName("thumbnailfull")]
        public string ThumbnailFull
        {
            get { return _ThumbnailFull; }
            set { _ThumbnailFull = value; }
        }
        private int? _ExplanationsId;
        [JsonPropertyName("explanationsid")]
        public int? ExplanationsId
        {
            get { return _ExplanationsId; }
            set { _ExplanationsId = value; }
        }
        private int? _OffersId;
        [JsonPropertyName("offersid")]
        public int? OffersId
        {
            get { return _OffersId; }
            set { _OffersId = value; }
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
