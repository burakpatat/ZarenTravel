using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("Explanations")]
    public class Explanations : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _Text;
        [JsonPropertyName("text")]
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
        private int? _ServiceId;
        [JsonPropertyName("serviceid")]
        public int? ServiceId
        {
            get { return _ServiceId; }
            set { _ServiceId = value; }
        }
        private int? _SegmentId;
        [JsonPropertyName("segmentid")]
        public int? SegmentId
        {
            get { return _SegmentId; }
            set { _SegmentId = value; }
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
