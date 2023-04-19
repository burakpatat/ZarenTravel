using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("BaggageInformations")]
    public class BaggageInformations : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int? _SegmentsId;
        [JsonPropertyName("segmentsid")]
        public int? SegmentsId
        {
            get { return _SegmentsId; }
            set { _SegmentsId = value; }
        }
        private int? _Weight;
        [JsonPropertyName("weight")]
        public int? Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
        private int? _Piece;
        [JsonPropertyName("piece")]
        public int? Piece
        {
            get { return _Piece; }
            set { _Piece = value; }
        }
        private int? _BaggageTypesId;
        [JsonPropertyName("baggagetypesid")]
        public int? BaggageTypesId
        {
            get { return _BaggageTypesId; }
            set { _BaggageTypesId = value; }
        }
        private int? _BaggageUnitTypesId;
        [JsonPropertyName("baggageunittypesid")]
        public int? BaggageUnitTypesId
        {
            get { return _BaggageUnitTypesId; }
            set { _BaggageUnitTypesId = value; }
        }
        private int? _PassengerTypesId;
        [JsonPropertyName("passengertypesid")]
        public int? PassengerTypesId
        {
            get { return _PassengerTypesId; }
            set { _PassengerTypesId = value; }
        }
        private string _Descriptions;
        [JsonPropertyName("descriptions")]
        public string Descriptions
        {
            get { return _Descriptions; }
            set { _Descriptions = value; }
        }
        private int? _ItemsId;
        [JsonPropertyName("itemsid")]
        public int? ItemsId
        {
            get { return _ItemsId; }
            set { _ItemsId = value; }
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
