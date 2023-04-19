using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("PriceBreakDowns")]
    public class PriceBreakDowns : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int? _PassengerTypeId;
        [JsonPropertyName("passengertypeid")]
        public int? PassengerTypeId
        {
            get { return _PassengerTypeId; }
            set { _PassengerTypeId = value; }
        }
        private int? _PassengerCount;
        [JsonPropertyName("passengercount")]
        public int? PassengerCount
        {
            get { return _PassengerCount; }
            set { _PassengerCount = value; }
        }
        private double? _Amount;
        [JsonPropertyName("amount")]
        public double? Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        private int? _CurrencyId;
        [JsonPropertyName("currencyid")]
        public int? CurrencyId
        {
            get { return _CurrencyId; }
            set { _CurrencyId = value; }
        }
        private double? _AirportTaxAmount;
        [JsonPropertyName("airporttaxamount")]
        public double? AirportTaxAmount
        {
            get { return _AirportTaxAmount; }
            set { _AirportTaxAmount = value; }
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
        private int? _OffersId;
        [JsonPropertyName("offersid")]
        public int? OffersId
        {
            get { return _OffersId; }
            set { _OffersId = value; }
        }
        private int? _FlightId;
        [JsonPropertyName("flightid")]
        public int? FlightId
        {
            get { return _FlightId; }
            set { _FlightId = value; }
        }
    }
}
