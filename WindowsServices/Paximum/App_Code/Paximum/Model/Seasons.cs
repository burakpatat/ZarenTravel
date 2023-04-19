using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("Seasons")]
    public class Seasons : IEntity
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
        private int? _SeasonTextCategoryId;
        [JsonPropertyName("seasontextcategoryid")]
        public int? SeasonTextCategoryId
        {
            get { return _SeasonTextCategoryId; }
            set { _SeasonTextCategoryId = value; }
        }
        private int? _FacilitySelectedCategoryId;
        [JsonPropertyName("facilityselectedcategoryid")]
        public int? FacilitySelectedCategoryId
        {
            get { return _FacilitySelectedCategoryId; }
            set { _FacilitySelectedCategoryId = value; }
        }
        private int? _SeasonMediaFileId;
        [JsonPropertyName("seasonmediafileid")]
        public int? SeasonMediaFileId
        {
            get { return _SeasonMediaFileId; }
            set { _SeasonMediaFileId = value; }
        }
        private int? _SeasonThemeId;
        [JsonPropertyName("seasonthemeid")]
        public int? SeasonThemeId
        {
            get { return _SeasonThemeId; }
            set { _SeasonThemeId = value; }
        }
        private int? _ApiId;
        [JsonPropertyName("apiid")]
        public int? ApiId
        {
            get { return _ApiId; }
            set { _ApiId = value; }
        }
        private int? _AgencyId;
        [JsonPropertyName("agencyid")]
        public int? AgencyId
        {
            get { return _AgencyId; }
            set { _AgencyId = value; }
        }
        private int? _MicroSiteId;
        [JsonPropertyName("micrositeid")]
        public int? MicroSiteId
        {
            get { return _MicroSiteId; }
            set { _MicroSiteId = value; }
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
    }
}
