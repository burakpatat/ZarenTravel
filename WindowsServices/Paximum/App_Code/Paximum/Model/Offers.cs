using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("Offers")]
    public class Offers : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int? _Night;
        [JsonPropertyName("night")]
        public int? Night
        {
            get { return _Night; }
            set { _Night = value; }
        }
        private bool? _IsAvailable;
        [JsonPropertyName("isavailable")]
        public bool? IsAvailable
        {
            get { return _IsAvailable; }
            set { _IsAvailable = value; }
        }
        private int? _Availability;
        [JsonPropertyName("availability")]
        public int? Availability
        {
            get { return _Availability; }
            set { _Availability = value; }
        }
        private int? _OfferRoomsId;
        [JsonPropertyName("offerroomsid")]
        public int? OfferRoomsId
        {
            get { return _OfferRoomsId; }
            set { _OfferRoomsId = value; }
        }
        private bool? _IsRefundable;
        [JsonPropertyName("isrefundable")]
        public bool? IsRefundable
        {
            get { return _IsRefundable; }
            set { _IsRefundable = value; }
        }
        private string _OfferId;
        [JsonPropertyName("offerid")]
        public string OfferId
        {
            get { return _OfferId; }
            set { _OfferId = value; }
        }
        private DateTime? _CheckIn;
        [JsonPropertyName("checkin")]
        public DateTime? CheckIn
        {
            get { return _CheckIn; }
            set { _CheckIn = value; }
        }
        private DateTime? _CheckOut;
        [JsonPropertyName("checkout")]
        public DateTime? CheckOut
        {
            get { return _CheckOut; }
            set { _CheckOut = value; }
        }
        private int? _PriceId;
        [JsonPropertyName("priceid")]
        public int? PriceId
        {
            get { return _PriceId; }
            set { _PriceId = value; }
        }
        private bool? _OwnOffer;
        [JsonPropertyName("ownoffer")]
        public bool? OwnOffer
        {
            get { return _OwnOffer; }
            set { _OwnOffer = value; }
        }
        private int? _Provider;
        [JsonPropertyName("provider")]
        public int? Provider
        {
            get { return _Provider; }
            set { _Provider = value; }
        }
        private DateTime? _ExpiresOn;
        [JsonPropertyName("expreson")]
        public DateTime? ExpiresOn
        {
            get { return _ExpiresOn; }
            set { _ExpiresOn = value; }
        }
        private int? _OfferCancellationPolicyId;
        [JsonPropertyName("offercancellationpolicyid")]
        public int? OfferCancellationPolicyId
        {
            get { return _OfferCancellationPolicyId; }
            set { _OfferCancellationPolicyId = value; }
        }
        private int? _OfferPriceBreakDownId;
        [JsonPropertyName("offerpricebreakdownid")]
        public int? OfferPriceBreakDownId
        {
            get { return _OfferPriceBreakDownId; }
            set { _OfferPriceBreakDownId = value; }
        }
        private bool? _IsSpecial;
        [JsonPropertyName("isspecial")]
        public bool? IsSpecial
        {
            get { return _IsSpecial; }
            set { _IsSpecial = value; }
        }
        private int? _AgencyCommissionId;
        [JsonPropertyName("agencycommissionid")]
        public int? AgencyCommissionId
        {
            get { return _AgencyCommissionId; }
            set { _AgencyCommissionId = value; }
        }
        private int? _AgencySupplementCommissionId;
        [JsonPropertyName("agencysupplementcommissionid")]
        public int? AgencySupplementCommissionId
        {
            get { return _AgencySupplementCommissionId; }
            set { _AgencySupplementCommissionId = value; }
        }
        private int? _SystemId;
        [JsonPropertyName("systemid")]
        public int? SystemId
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
        public float PriceAmount { get; set; }
        public string PriceCurrency { get; set; }
    }
}
