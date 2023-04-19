using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("FlightOffers")]
    public class FlightOffers : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int? _SegmentNumber;
        [JsonPropertyName("segmentnumber")]
        public int? SegmentNumber
        {
            get { return _SegmentNumber; }
            set { _SegmentNumber = value; }
        }
        private bool? _IsPackageOffer;
        [JsonPropertyName("ispackageoffer")]
        public bool? IsPackageOffer
        {
            get { return _IsPackageOffer; }
            set { _IsPackageOffer = value; }
        }
        private bool? _HasBrand;
        [JsonPropertyName("hasbrand")]
        public bool? HasBrand
        {
            get { return _HasBrand; }
            set { _HasBrand = value; }
        }
        private int? _Route;
        [JsonPropertyName("route")]
        public int? Route
        {
            get { return _Route; }
            set { _Route = value; }
        }
        private string _ExpiresOn;
        [JsonPropertyName("expireson")]
        public string ExpiresOn
        {
            get { return _ExpiresOn; }
            set { _ExpiresOn = value; }
        }
        private string _OfferId;
        [JsonPropertyName("offerid")]
        public string OfferId
        {
            get { return _OfferId; }
            set { _OfferId = value; }
        }
        private int? _Provider;
        [JsonPropertyName("provider")]
        public int? Provider
        {
            get { return _Provider; }
            set { _Provider = value; }
        }
        private double? _SingleAdultPrice;
        [JsonPropertyName("singleadultprice")]
        public double? SingleAdultPrice
        {
            get { return _SingleAdultPrice; }
            set { _SingleAdultPrice = value; }
        }
        private bool? _ReservableInfo;
        [JsonPropertyName("reservableinfo")]
        public bool? ReservableInfo
        {
            get { return _ReservableInfo; }
            set { _ReservableInfo = value; }
        }
        private double? _ServiceFeesAmount;
        [JsonPropertyName("servicefeesamount")]
        public double? ServiceFeesAmount
        {
            get { return _ServiceFeesAmount; }
            set { _ServiceFeesAmount = value; }
        }
        private int? _SeatInfosSeatCount;
        [JsonPropertyName("seatinfosseatcount")]
        public int? SeatInfosSeatCount
        {
            get { return _SeatInfosSeatCount; }
            set { _SeatInfosSeatCount = value; }
        }
        private int? _SeatInfosSeatCountType;
        [JsonPropertyName("seatinfosseatcounttype")]
        public int? SeatInfosSeatCountType
        {
            get { return _SeatInfosSeatCountType; }
            set { _SeatInfosSeatCountType = value; }
        }
        private string _GroupKey;
        [JsonPropertyName("groupkey")]
        public string GroupKey
        {
            get { return _GroupKey; }
            set { _GroupKey = value; }
        }
        private int? _FlightsId;
        [JsonPropertyName("flightsid")]
        public int? FlightsId
        {
            get { return _FlightsId; }
            set { _FlightsId = value; }
        }

        private int? _PriceBreakDownId;
        [JsonPropertyName("pricebreakdownid")]
        public int? PriceBreakDownId
        {
            get { return _PriceBreakDownId; }
            set { _PriceBreakDownId = value; }
        }

        private int? _FlightProviderId;
        [JsonPropertyName("flightproviderid")]
        public int? FlightProviderId
        {
            get { return _FlightProviderId; }
            set { _FlightProviderId = value; }
        }
        private int? _FlightBrandsId;
        [JsonPropertyName("flightbrandsid")]
        public int? FlightBrandsId
        {
            get { return _FlightBrandsId; }
            set { _FlightBrandsId = value; }
        }

        private double? _Price;
        [JsonPropertyName("price")]
        public double? Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        private int? _CurrencyId;
        [JsonPropertyName("currency")]
        public int? CurrencyId
        {
            get { return _CurrencyId; }
            set { _CurrencyId = value; }
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
