using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("Hotels")]
    public class Hotels : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int? _HotelId;
        [JsonPropertyName("hotelid")]
        public int? HotelId
        {
            get { return _HotelId; }
            set { _HotelId = value; }
        }
        private string _Name;
        [JsonPropertyName("name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Address;
        [JsonPropertyName("address")]
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        private string _Description;
        [JsonPropertyName("description")]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        private int? _Provider;
        [JsonPropertyName("provider")]
        public int? Provider
        {
            get { return _Provider; }
            set { _Provider = value; }
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
        private int? _VillageId;
        [JsonPropertyName("villageid")]
        public int? VillageId
        {
            get { return _VillageId; }
            set { _VillageId = value; }
        }
        private int? _TownId;
        [JsonPropertyName("townid")]
        public int? TownId
        {
            get { return _TownId; }
            set { _TownId = value; }
        }
        private int? _CityId;
        [JsonPropertyName("cityid")]
        public int? CityId
        {
            get { return _CityId; }
            set { _CityId = value; }
        }
        private int? _CountryId;
        [JsonPropertyName("countryid")]
        public int? CountryId
        {
            get { return _CountryId; }
            set { _CountryId = value; }
        }
     
        private int? _GiataInfoId;
        [JsonPropertyName("giatainfoid")]
        public int? GiataInfoId
        {
            get { return _GiataInfoId; }
            set { _GiataInfoId = value; }
        }
       
        private string _FaxNumber;
        [JsonPropertyName("faxnumber")]
        public string FaxNumber
        {
            get { return _FaxNumber; }
            set { _FaxNumber = value; }
        }
        private string _PhoneNumber;
        [JsonPropertyName("phonenumber")]
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }
        private string _HomePage;
        [JsonPropertyName("homepage")]
        public string HomePage
        {
            get { return _HomePage; }
            set { _HomePage = value; }
        }
        private int? _HotelCategoryId;
        [JsonPropertyName("hotelcategoryid")]
        public int? HotelCategoryId
        {
            get { return _HotelCategoryId; }
            set { _HotelCategoryId = value; }
        }
       
        private string _SystemId;
        [JsonPropertyName("systemid")]
        public string SystemId
        {
            get { return _SystemId; }
            set { _SystemId = value; }
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
        public float Latitude { get; set; }
        public float Longtitude { get; set; }
    }
}
