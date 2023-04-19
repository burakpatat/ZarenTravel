using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
using SanTsgHotelBooking.Application.Models.GetReservationDetail.Response;

namespace Model.Concrete
{
 
    public class BookingReservationsDTO  
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _ReservationNumber;
        [JsonPropertyName("reservationnumber")]
        public string ReservationNumber
        {
            get { return _ReservationNumber; }
            set { _ReservationNumber = value; }
        }
        private string _OfferId;
        [JsonPropertyName("offerid")]
        public string OfferId
        {
            get { return _OfferId; }
            set { _OfferId = value; }
        }
        private string _Note;
        [JsonPropertyName("note")]
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
        private string _CookieId;
        [JsonPropertyName("cookieid")]
        public string CookieId
        {
            get { return _CookieId; }
            set { _CookieId = value; }
        }
        private DateTime? _CreatedDate;
        [JsonPropertyName("createddate")]
        public DateTime? CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        private string _Guid;
        [JsonPropertyName("encryptedReservationNumber")]
        public string Guid
        {
            get { return _Guid; }
            set { _Guid = value; }
        }
        private string _UserId;
        [JsonPropertyName("userid")]
        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        private int? _ProductType;
        [JsonPropertyName("producttype")]
        public int? ProductType
        {
            get { return _ProductType; }
            set { _ProductType = value; }
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
        private string _ProductId;
        [JsonPropertyName("productid")]
        public string ProductId
        {
            get { return _ProductId; }
            set { _ProductId = value; }
        }
        private DateTime? _ExpireDate;
        [JsonPropertyName("expiredate")]
        public DateTime? ExpireDate
        {
            get { return _ExpireDate; }
            set { _ExpireDate = value; }
        }
        private int? _HasPaid;
        [JsonPropertyName("haspaid")]
        public int? HasPaid
        {
            get { return _HasPaid; }
            set { _HasPaid = value; }
        }
        private string _Currency;
        [JsonPropertyName("currency")]
        public string Currency
        {
            get { return _Currency; }
            set { _Currency = value; }
        }
        private string _Culture;
        [JsonPropertyName("culture")]
        public string Culture
        {
            get { return _Culture; }
            set { _Culture = value; }
        }
        private string _UserAgent;
        [JsonPropertyName("useragent")]
        public string UserAgent
        {
            get { return _UserAgent; }
            set { _UserAgent = value; }
        }
        private string _UserIp;
        [JsonPropertyName("userip")]
        public string UserIp
        {
            get { return _UserIp; }
            set { _UserIp = value; }
        } 

        private int? _Status;
        [JsonPropertyName("status")]
        public int? Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _TransactionId;
        [JsonPropertyName("transactionId")]
        public string TransactionId
        {
            get { return _TransactionId; }
            set { _TransactionId = value; }
        }

        public GetReservationDetailResponse GetReservationDetailResponse { get; set; }

        private bool? _OnBasket;
        [JsonPropertyName("onbasket")]
        public bool? OnBasket
        {
            get { return _OnBasket; }
            set { _OnBasket = value; }
        }
        private string _JsonData;
        [JsonPropertyName("jsondata")]
        public string JsonData
        {
            get { return _JsonData; }
            set { _JsonData = value; }
        }
        public decimal TotalAmount { get; set; }
        public int PaymentType { get; set; }

        public int PaymentStatus { get; set; }

        public int ConfirmationStatus { get; set; }
        public string BookingNumber { get; set; }
        public int ReservationStatus { get; set; }
        public int ApiId { get; set; }
    }
}

