﻿
using Newtonsoft.Json;

namespace BeginPayment
{
	// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
	public class Body
	{
		[JsonProperty("html")]
		public string Html { get; set; }

		[JsonProperty("postUrl")]
		public string PostUrl { get; set; }

		[JsonProperty("paymentTransactionType")]
		public int PaymentTransactionType { get; set; }

		[JsonProperty("paymentTransactionId")]
		public string PaymentTransactionId { get; set; }
	}

	public class Header
	{
		[JsonProperty("requestId")]
		public string RequestId { get; set; }

		[JsonProperty("success")]
		public bool Success { get; set; }

		[JsonProperty("messages")]
		public List<Message> Messages { get; set; }
	}

	public class Message
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("messageType")]
		public int MessageType { get; set; }

		[JsonProperty("message")]
		public string Messages { get; set; }
	}

	public class Root
	{
		[JsonProperty("header")]
		public Header Header { get; set; }

		[JsonProperty("body")]
		public Body Body { get; set; }
	}


}

namespace SanTsgHotelBooking.Application.Models.BeginTransactionResponse
{
    public class BeginTransactionResponse
    {
        public Body body { get; set; }
        public Header header { get; set; }
    }

    public class AdditionalFields
    {
        public string travellerTypeOrder { get; set; }
        public string travellerUniqueID { get; set; }
        public string tourVisio_TravellerId { get; set; }
        public DateTime birthDateFrom { get; set; }
        public DateTime birthDateTo { get; set; }
        public string smsLimit { get; set; }
        public string priceChanged { get; set; }
        public string allowSalePriceEdit { get; set; }
        public string sendFlightSms { get; set; }
        public string oldSalePrice { get; set; }
        public string willBePayAt { get; set; }
    }

    public class Address
    {
        public ContactPhone contactPhone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string zipCode { get; set; }
        public City city { get; set; }
        public Country country { get; set; }
        public string phone { get; set; }
        public List<string> addressLines { get; set; }
    }

    public class Agency
    {
        public string code { get; set; }
        public string name { get; set; }
        public Country country { get; set; }
        public Address address { get; set; }
        public bool ownAgency { get; set; }
        public bool aceExport { get; set; }
    }

    public class AgencyAmountToPay
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class AgencyBalance
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class AgencyCommission
    {
        public string percent { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class AgencyEB
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class AgencyPriceToPay
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class AgencySupplementCommission
    {
        public string percent { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class AgencyUser
    {
        public Office office { get; set; }
        public Operator @operator { get; set; }
        public Market market { get; set; }
        public Agency agency { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }

    public class ArrivalCity
    {
        public string code { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string parentId { get; set; }
        public string countryId { get; set; }
        public int provider { get; set; }
        public bool isTopRegion { get; set; }
        public string id { get; set; }
    }

    public class ArrivalCountry
    {
        public string code { get; set; }
        public string internationalCode { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string parentId { get; set; }
        public string countryId { get; set; }
        public int provider { get; set; }
        public bool isTopRegion { get; set; }
        public string id { get; set; }
    }

    public class AvailableTitle
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Body
    {
        public string transactionId { get; set; }
        public DateTime expiresOn { get; set; }
        public ReservationData reservationData { get; set; }
        public int status { get; set; }
        public int transactionType { get; set; }
    }

    public class BrokerCommission
    {
        public string percent { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class CancellationPolicy
    {
        public DateTime beginDate { get; set; }
        public DateTime dueDate { get; set; }
        public Price price { get; set; }
        public int provider { get; set; }
    }

    public class City
    {
        public string id { get; set; }
        public string name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int provider { get; set; }
        public bool isTopRegion { get; set; }
        public string code { get; set; }
        public int type { get; set; }
        public string parentId { get; set; }
        public string countryId { get; set; }
    }

    public class ContactPhone
    {
    }

    public class Country
    {
        public string id { get; set; }
        public string name { get; set; }
        public string internationalCode { get; set; }
        public int provider { get; set; }
        public bool isTopRegion { get; set; }
        public string code { get; set; }
        public int type { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string parentId { get; set; }
        public string countryId { get; set; }
    }

    public class DepartureCity
    {
        public string code { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string parentId { get; set; }
        public string countryId { get; set; }
        public int provider { get; set; }
        public bool isTopRegion { get; set; }
        public string id { get; set; }
    }

    public class DepartureCountry
    {
        public string code { get; set; }
        public string internationalCode { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string parentId { get; set; }
        public string countryId { get; set; }
        public int provider { get; set; }
        public bool isTopRegion { get; set; }
        public string id { get; set; }
    }

    public class DestinationAddress
    {
    }

    public class Discount
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class ExtraServiceDetail
    {
        public bool show { get; set; }
        public bool compulsory { get; set; }
        public bool free { get; set; }
    }

    public class Geolocation
    {
        public string longitude { get; set; }
        public string latitude { get; set; }
    }

    public class GeoLocation2
    {
        public string longitude { get; set; }
        public string latitude { get; set; }
    }

    public class Handicap
    {
        public string type { get; set; }
        public string code { get; set; }
        public string handicap { get; set; }
        public string name { get; set; }
    }

    public class Header
    {
        public string requestId { get; set; }
        public bool success { get; set; }
        public DateTime responseTime { get; set; }
        public List<Message> messages { get; set; }
    }

    public class HolidayPackageInfo
    {
        public int priceListNo { get; set; }
        public string code { get; set; }
    }

    public class HotelDetail
    {
        public Address address { get; set; }
        public string faxNumber { get; set; }
        public string phoneNumber { get; set; }
        public string homePage { get; set; }
        public TransferLocation transferLocation { get; set; }
        public int stopSaleGuaranteed { get; set; }
        public int stopSaleStandart { get; set; }
        public Geolocation geolocation { get; set; }
        public int stars { get; set; }
        public Location location { get; set; }
        public Country country { get; set; }
        public City city { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Location
    {
        public string code { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string parentId { get; set; }
        public string countryId { get; set; }
        public int provider { get; set; }
        public bool isTopRegion { get; set; }
        public string id { get; set; }
    }

    public class Market
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Message
    {
        public int id { get; set; }
        public string code { get; set; }
        public int messageType { get; set; }
        public string message { get; set; }
    }

    public class Nationality
    {
        public string twoLetterCode { get; set; }
    }

    public class NetPrice
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class Office
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Operator
    {
        public string code { get; set; }
        public string name { get; set; }
        public bool agencyCanDiscountCommission { get; set; }
    }

    public class PassengerAmountToPay
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class PassengerBalance
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class PassengerEB
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class PassengerPriceToPay
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class PassportInfo
    {
        public string serial { get; set; }
        public string number { get; set; }
        public DateTime expireDate { get; set; }
        public DateTime issueDate { get; set; }
        public string issueCountryCode { get; set; }
        public string citizenshipCountryCode { get; set; }
    }

    public class PaymentDetail
    {
        public List<PaymentPlan> paymentPlan { get; set; }
        public List<object> paymentInfo { get; set; }
    }

    public class PaymentPlan
    {
        public int paymentNo { get; set; }
        public DateTime dueDate { get; set; }
        public Price price { get; set; }
        public bool paymentStatus { get; set; }
    }

    public class Price
    {
        public double amount { get; set; }
        public string currency { get; set; }
        public string percent { get; set; }
    }

    public class PriceBreakDown
    {
        public string roomNumber { get; set; }
        public DateTime date { get; set; }
        public Price price { get; set; }
    }

    public class PriceToPay
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class PromotionAmount
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class ReservableInfo
    {
        public bool reservable { get; set; }
    }

    public class ReservationData
    {
        public List<Traveller> travellers { get; set; }
        public ReservationInfo reservationInfo { get; set; }
        public List<Service> services { get; set; }
        public PaymentDetail paymentDetail { get; set; }
        public List<object> invoices { get; set; }
    }

    public class ReservationInfo
    {
        public string bookingNumber { get; set; }
        public Agency agency { get; set; }
        public AgencyUser agencyUser { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public string note { get; set; }
        public SalePrice salePrice { get; set; }
        public SupplementDiscount supplementDiscount { get; set; }
        public PassengerEB passengerEB { get; set; }
        public AgencyEB agencyEB { get; set; }
        public PassengerAmountToPay passengerAmountToPay { get; set; }
        public AgencyAmountToPay agencyAmountToPay { get; set; }
        public Discount discount { get; set; }
        public AgencyBalance agencyBalance { get; set; }
        public PassengerBalance passengerBalance { get; set; }
        public AgencyCommission agencyCommission { get; set; }
        public BrokerCommission brokerCommission { get; set; }
        public AgencySupplementCommission agencySupplementCommission { get; set; }
        public PromotionAmount promotionAmount { get; set; }
        public PriceToPay priceToPay { get; set; }
        public AgencyPriceToPay agencyPriceToPay { get; set; }
        public PassengerPriceToPay passengerPriceToPay { get; set; }
        public TotalPrice totalPrice { get; set; }
        public int reservationStatus { get; set; }
        public int confirmationStatus { get; set; }
        public int paymentStatus { get; set; }
        public List<object> documents { get; set; }
        public List<object> otherDocuments { get; set; }
        public ReservableInfo reservableInfo { get; set; }
        public int paymentFrom { get; set; }
        public DepartureCountry departureCountry { get; set; }
        public DepartureCity departureCity { get; set; }
        public ArrivalCountry arrivalCountry { get; set; }
        public ArrivalCity arrivalCity { get; set; }
        public DateTime createDate { get; set; }
        public AdditionalFields additionalFields { get; set; }
        public HolidayPackageInfo holidayPackageInfo { get; set; }
        public List<Handicap> handicaps { get; set; }
        public string additionalCode1 { get; set; }
        public string additionalCode2 { get; set; }
        public string additionalCode3 { get; set; }
        public string additionalCode4 { get; set; }
        public string agencyDiscount { get; set; }
        public bool hasAvailablePromotionCode { get; set; }
    }
    public class SalePrice
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class Service
    {
        public string id { get; set; }
        public int type { get; set; }
        public Price price { get; set; }
        public int passengerType { get; set; }
        public int orderNumber { get; set; }
        public string note { get; set; }
        public DepartureCountry departureCountry { get; set; }
        public DepartureCity departureCity { get; set; }
        public ArrivalCountry arrivalCountry { get; set; }
        public ArrivalCity arrivalCity { get; set; }
        public ServiceDetails serviceDetails { get; set; }
        public bool isMainService { get; set; }
        public bool isRefundable { get; set; }
        public bool bundle { get; set; }
        public List<CancellationPolicy> cancellationPolicies { get; set; }
        public List<object> documents { get; set; }
        public List<PriceBreakDown> priceBreakDowns { get; set; }
        public int unit { get; set; }
        public int confirmationStatus { get; set; }
        public int serviceStatus { get; set; }
        public int productType { get; set; }
        public bool createServiceTypeIfNotExists { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public int adult { get; set; }
        public int child { get; set; }
        public int infant { get; set; }
        public NetPrice netPrice { get; set; }
        public bool includePackage { get; set; }
        public bool compulsory { get; set; }
        public bool isExtraService { get; set; }
        public string supplierCode { get; set; }
        public string supplier { get; set; }
        public int provider { get; set; }
        public List<string> travellers { get; set; }
        public bool thirdPartyRecord { get; set; }
        public List<string> handicaps { get; set; }
        public int recordId { get; set; }
        public string mainServiceId { get; set; }
        public int? agencyCommission { get; set; }
        public AdditionalFields additionalFields { get; set; }
    }

    public class ServiceDetails
    {
        public string serviceId { get; set; }
        public HotelDetail hotelDetail { get; set; }
        public int night { get; set; }
        public string room { get; set; }
        public string board { get; set; }
        public string accom { get; set; }
        public string star { get; set; }
        public GeoLocation2 geoLocation { get; set; }
        public int? priceType { get; set; }
        public ExtraServiceDetail extraServiceDetail { get; set; }
    }

    public class SupplementDiscount
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class TotalPrice
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class TransferLocation
    {
        public string code { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string parentId { get; set; }
        public string countryId { get; set; }
        public int provider { get; set; }
        public bool isTopRegion { get; set; }
        public string id { get; set; }
    }

    public class Traveller
    {
        public string travellerId { get; set; }
        public int type { get; set; }
        public int title { get; set; }
        public List<AvailableTitle> availableTitles { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public bool isLeader { get; set; }
        public DateTime birthDate { get; set; }
        public Nationality nationality { get; set; }
        public string identityNumber { get; set; }
        public PassportInfo passportInfo { get; set; }
        public Address address { get; set; }
        public DestinationAddress destinationAddress { get; set; }
        public List<Service> services { get; set; }
        public int orderNumber { get; set; }
        public DateTime birthDateFrom { get; set; }
        public DateTime birthDateTo { get; set; }
        public List<string> requiredFields { get; set; }
        public List<object> documents { get; set; }
        public int passengerType { get; set; }
        public AdditionalFields additionalFields { get; set; }
        public List<object> insertFields { get; set; }
        public int status { get; set; }
    }



}
