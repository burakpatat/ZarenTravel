using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("HotelTextCategoriesSelectedPresentations")]
    public class HotelTextCategoriesSelectedPresentations : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int? _HotelTextCategoriesId;
        [JsonPropertyName("hoteltextcategoriesid")]
        public int? HotelTextCategoriesId
        {
            get { return _HotelTextCategoriesId; }
            set { _HotelTextCategoriesId = value; }
        }
        private int? _PresentationId;
        [JsonPropertyName("presentationid")]
        public int? PresentationId
        {
            get { return _PresentationId; }
            set { _PresentationId = value; }
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
        private int? _Type;
        [JsonPropertyName("type")]
        public int? Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public int HotelId { get; set; }
        public string SystemId { get; set; }
    }
}
