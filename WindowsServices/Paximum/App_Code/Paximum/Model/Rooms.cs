using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("Rooms")]
    public class Rooms : IEntity
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
        private int? _AccomId;
        [JsonPropertyName("accomid")]
        public int? AccomId
        {
            get { return _AccomId; }
            set { _AccomId = value; }
        }
        private string _AccomName;
        [JsonPropertyName("accomname")]
        public string AccomName
        {
            get { return _AccomName; }
            set { _AccomName = value; }
        }
        private int? _BoardId;
        [JsonPropertyName("boardid")]
        public int? BoardId
        {
            get { return _BoardId; }
            set { _BoardId = value; }
        }
        private string _BoardName;
        [JsonPropertyName("boardname")]
        public string BoardName
        {
            get { return _BoardName; }
            set { _BoardName = value; }
        }
        private int? _Allotment;
        [JsonPropertyName("allotment")]
        public int? Allotment
        {
            get { return _Allotment; }
            set { _Allotment = value; }
        }
        private int? _StopSaleGuaranteed;
        [JsonPropertyName("stopsaleguaranteed")]
        public int? StopSaleGuaranteed
        {
            get { return _StopSaleGuaranteed; }
            set { _StopSaleGuaranteed = value; }
        }
        private int? _StopSaleStandart;
        [JsonPropertyName("stopsalestandart")]
        public int? StopSaleStandart
        {
            get { return _StopSaleStandart; }
            set { _StopSaleStandart = value; }
        }
        private int? _PriceId;
        [JsonPropertyName("priceid")]
        public int? PriceId
        {
            get { return _PriceId; }
            set { _PriceId = value; }
        }
        private string _Code;
        [JsonPropertyName("code")]
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        private int? _RoomMediaFileId;
        [JsonPropertyName("roommediafileid")]
        public int? RoomMediaFileId
        {
            get { return _RoomMediaFileId; }
            set { _RoomMediaFileId = value; }
        }
        private int? _PresentationId;
        [JsonPropertyName("presentationid")]
        public int? PresentationId
        {
            get { return _PresentationId; }
            set { _PresentationId = value; }
        }
        private int? _RoomFacilityId;
        [JsonPropertyName("roomfacilityid")]
        public int? RoomFacilityId
        {
            get { return _RoomFacilityId; }
            set { _RoomFacilityId = value; }
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
        public int? HotelId { get; set; }
        public int? Type { get; set; }
        public string OfferId { get; set; }
    }
}
