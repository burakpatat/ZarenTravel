using Newtonsoft.Json;


namespace SanTsgHotelBooking.Application.Models.GetReservationDetail.Response
{
    public class GetReservationDetailResponse
	{
 
		public Header header { get; set; }
        public Body body { get; set; }
    }

    public class AdditionalFields
    {
        public string travellerTypeOrder { get; set; }
        public string travellerUniqueID { get; set; }
        public string tourVisio_TravellerId { get; set; }
        public string smsLimit { get; set; }
        public string priceChanged { get; set; }
        public string allowSalePriceEdit { get; set; }
        public string allowAgencyCanRes { get; set; }
        public string isRefundable { get; set; }
        public string reservableInfo { get; set; }
        public string isEditable { get; set; }
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
        public double percent { get; set; }
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
        public double percent { get; set; }
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
        public string reservationNumber { get; set; }
        public string encryptedReservationNumber { get; set; }
        public string transactionId { get; set; }
        public DateTime expiresOn { get; set; }
        public ReservationData reservationData { get; set; }
        public int status { get; set; }
    }

    public class BrokerCommission
    {
        public double percent { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class CancellationPolicy
    {
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
        public string countryCode { get; set; }
        public string phoneNumber { get; set; }
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

    public class Document
    {
        public int documentType { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public bool isDefault { get; set; }
        public bool proforma { get; set; }
        public int fromToType { get; set; }
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

    public class Header
    {
        public string requestId { get; set; }
        public bool success { get; set; }
        public DateTime responseTime { get; set; }
        public List<Message> messages { get; set; }
    }

    public class HotelDetail
    {
        public Address address { get; set; }
        public TransferLocation transferLocation { get; set; }
        public int stopSaleGuaranteed { get; set; }
        public int stopSaleStandart { get; set; }
        public Geolocation geolocation { get; set; }
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
        public string name { get; set; }
        public string twoLetterCode { get; set; }
        public string threeLetterCode { get; set; }
        public string numericCode { get; set; }
        public string isdCode { get; set; }
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
        public string citizenshipCountryCode { get; set; }
    }

    public class PaymentDetail
    {
        public List<PaymentPlan> paymentPlan { get; set; }
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
        public double percent { get; set; }
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
        public string encryptedBookingNumber { get; set; }
        public Agency agency { get; set; }
        public AgencyUser agencyUser { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public string note { get; set; }
        public string agencyReservationNumber { get; set; }
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
        public List<Document> documents { get; set; }
        public List<object> otherDocuments { get; set; }
        public ReservableInfo reservableInfo { get; set; }
        public int paymentFrom { get; set; }
        public DepartureCountry departureCountry { get; set; }
        public DepartureCity departureCity { get; set; }
        public ArrivalCountry arrivalCountry { get; set; }
        public ArrivalCity arrivalCity { get; set; }
        public DateTime createDate { get; set; }
        public AdditionalFields additionalFields { get; set; }
        public string additionalCode1 { get; set; }
        public string additionalCode2 { get; set; }
        public string additionalCode3 { get; set; }
        public string additionalCode4 { get; set; }
        public double agencyDiscount { get; set; }
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
        public string ticketNo { get; set; }
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
        public List<Document> documents { get; set; }
        public string providerBookingID { get; set; }
        public string supplierBookingNumber { get; set; }
        public string encryptedServiceNumber { get; set; }
        public List<object> priceBreakDowns { get; set; }
        public double commission { get; set; }
        public ReservableInfo reservableInfo { get; set; }
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
        public int recordId { get; set; }
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
        public GeoLocation2 geoLocation { get; set; }
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
        public int age { get; set; }
        public Nationality nationality { get; set; }
        public string identityNumber { get; set; }
        public PassportInfo passportInfo { get; set; }
        public Address address { get; set; }
        public DestinationAddress destinationAddress { get; set; }
        public List<Service> services { get; set; }
        public int gender { get; set; }
        public int orderNumber { get; set; }
        public List<string> requiredFields { get; set; }
        public List<object> documents { get; set; }
        public int passengerType { get; set; }
        public AdditionalFields additionalFields { get; set; }
        public List<object> insertFields { get; set; }
        public int status { get; set; }
    }


}


namespace Reservation
{
	// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
	public class AdditionalFields
	{
		[JsonProperty("travellerTypeOrder")]
		public string TravellerTypeOrder { get; set; }

		[JsonProperty("travellerUniqueID")]
		public string TravellerUniqueID { get; set; }

		[JsonProperty("tourVisio_TravellerId")]
		public string TourVisioTravellerId { get; set; }

		[JsonProperty("paximum_TravellerId")]
		public string PaximumTravellerId { get; set; }

		[JsonProperty("birthDateFrom")]
		public DateTime BirthDateFrom { get; set; }

		[JsonProperty("birthDateTo")]
		public DateTime BirthDateTo { get; set; }

		[JsonProperty("smsLimit")]
		public string SmsLimit { get; set; }

		[JsonProperty("priceChanged")]
		public string PriceChanged { get; set; }

		[JsonProperty("allowSalePriceEdit")]
		public string AllowSalePriceEdit { get; set; }

		[JsonProperty("sendFlightSms")]
		public string SendFlightSms { get; set; }

		[JsonProperty("isRefundable")]
		public string IsRefundable { get; set; }

		[JsonProperty("reservableInfo")]
		public string ReservableInfo { get; set; }

		[JsonProperty("isEditable")]
		public string IsEditable { get; set; }
	}

	public class Address
	{
		[JsonProperty("contactPhone")]
		public ContactPhone ContactPhone { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("address")]
		public string Addresss { get; set; }

		[JsonProperty("zipCode")]
		public string ZipCode { get; set; }

		[JsonProperty("city")]
		public City City { get; set; }

		[JsonProperty("country")]
		public Country Country { get; set; }

		[JsonProperty("phone")]
		public string Phone { get; set; }

		[JsonProperty("addressLines")]
		public List<string> AddressLines { get; set; }
	}

	public class Agency
	{
		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("country")]
		public Country Country { get; set; }

		[JsonProperty("address")]
		public Address Address { get; set; }

		[JsonProperty("ownAgency")]
		public bool OwnAgency { get; set; }

		[JsonProperty("aceExport")]
		public bool AceExport { get; set; }
	}

	public class AgencyAmountToPay
	{
		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class AgencyBalance
	{
		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class AgencyCommission
	{
		[JsonProperty("percent")]
		public double Percent { get; set; }

		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class AgencyEB
	{
		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class AgencyPriceToPay
	{
		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class AgencySupplementCommission
	{
		[JsonProperty("percent")]
		public double Percent { get; set; }

		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class AgencyUser
	{
		[JsonProperty("office")]
		public Office Office { get; set; }

		[JsonProperty("operator")]
		public Operator Operator { get; set; }

		[JsonProperty("market")]
		public Market Market { get; set; }

		[JsonProperty("agency")]
		public Agency Agency { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }
	}

	public class ArrivalCity
	{
		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public int Type { get; set; }

		[JsonProperty("latitude")]
		public string Latitude { get; set; }

		[JsonProperty("longitude")]
		public string Longitude { get; set; }

		[JsonProperty("parentId")]
		public string ParentId { get; set; }

		[JsonProperty("countryId")]
		public string CountryId { get; set; }

		[JsonProperty("provider")]
		public int Provider { get; set; }

		[JsonProperty("isTopRegion")]
		public bool IsTopRegion { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }
	}

	public class ArrivalCountry
	{
		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("internationalCode")]
		public string InternationalCode { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public int Type { get; set; }

		[JsonProperty("parentId")]
		public string ParentId { get; set; }

		[JsonProperty("countryId")]
		public string CountryId { get; set; }

		[JsonProperty("provider")]
		public int Provider { get; set; }

		[JsonProperty("isTopRegion")]
		public bool IsTopRegion { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }
	}

	public class AvailableTitle
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}

	public class Body
	{
		[JsonProperty("transactionId")]
		public string TransactionId { get; set; }

		[JsonProperty("expiresOn")]
		public DateTime ExpiresOn { get; set; }

		[JsonProperty("reservationData")]
		public ReservationData ReservationData { get; set; }

		[JsonProperty("status")]
		public int Status { get; set; }

		[JsonProperty("transactionType")]
		public int TransactionType { get; set; }
	}

	public class BrokerCommission
	{
		[JsonProperty("percent")]
		public double Percent { get; set; }

		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class CancellationPolicy
	{
		[JsonProperty("dueDate")]
		public DateTime DueDate { get; set; }

		[JsonProperty("price")]
		public Price Price { get; set; }

		[JsonProperty("provider")]
		public int Provider { get; set; }
	}

	public class City
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("type")]
		public int Type { get; set; }

		[JsonProperty("latitude")]
		public string Latitude { get; set; }

		[JsonProperty("longitude")]
		public string Longitude { get; set; }

		[JsonProperty("parentId")]
		public string ParentId { get; set; }

		[JsonProperty("countryId")]
		public string CountryId { get; set; }

		[JsonProperty("provider")]
		public int Provider { get; set; }

		[JsonProperty("isTopRegion")]
		public bool IsTopRegion { get; set; }
	}

	public class ContactPhone
	{
	}

	public class Country
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("internationalCode")]
		public string InternationalCode { get; set; }

		[JsonProperty("provider")]
		public int Provider { get; set; }

		[JsonProperty("isTopRegion")]
		public bool IsTopRegion { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("type")]
		public int Type { get; set; }

		[JsonProperty("parentId")]
		public string ParentId { get; set; }

		[JsonProperty("countryId")]
		public string CountryId { get; set; }
	}

	public class DepartureCity
	{
		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public int Type { get; set; }

		[JsonProperty("latitude")]
		public string Latitude { get; set; }

		[JsonProperty("longitude")]
		public string Longitude { get; set; }

		[JsonProperty("parentId")]
		public string ParentId { get; set; }

		[JsonProperty("countryId")]
		public string CountryId { get; set; }

		[JsonProperty("provider")]
		public int Provider { get; set; }

		[JsonProperty("isTopRegion")]
		public bool IsTopRegion { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }
	}

	public class DepartureCountry
	{
		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("internationalCode")]
		public string InternationalCode { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public int Type { get; set; }

		[JsonProperty("parentId")]
		public string ParentId { get; set; }

		[JsonProperty("countryId")]
		public string CountryId { get; set; }

		[JsonProperty("provider")]
		public int Provider { get; set; }

		[JsonProperty("isTopRegion")]
		public bool IsTopRegion { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }
	}

	public class DestinationAddress
	{
	}

	public class Discount
	{
		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class Geolocation
	{
		[JsonProperty("longitude")]
		public string Longitude { get; set; }

		[JsonProperty("latitude")]
		public string Latitude { get; set; }
	}

	public class GeoLocation2
	{
		[JsonProperty("longitude")]
		public string Longitude { get; set; }

		[JsonProperty("latitude")]
		public string Latitude { get; set; }
	}

	public class Header
	{
		[JsonProperty("requestId")]
		public string RequestId { get; set; }

		[JsonProperty("success")]
		public bool Success { get; set; }

		[JsonProperty("responseTime")]
		public DateTime ResponseTime { get; set; }

		[JsonProperty("messages")]
		public List<Message> Messages { get; set; }
	}

	public class HotelDetail
	{
		[JsonProperty("address")]
		public Address Address { get; set; }

		[JsonProperty("phoneNumber")]
		public string PhoneNumber { get; set; }

		[JsonProperty("transferLocation")]
		public TransferLocation TransferLocation { get; set; }

		[JsonProperty("stopSaleGuaranteed")]
		public int StopSaleGuaranteed { get; set; }

		[JsonProperty("stopSaleStandart")]
		public int StopSaleStandart { get; set; }

		[JsonProperty("restrictions")]
		public List<object> Restrictions { get; set; }

		[JsonProperty("handicaps")]
		public List<object> Handicaps { get; set; }

		[JsonProperty("geolocation")]
		public Geolocation Geolocation { get; set; }

		[JsonProperty("stars")]
		public int Stars { get; set; }

		[JsonProperty("location")]
		public Location Location { get; set; }

		[JsonProperty("country")]
		public Country Country { get; set; }

		[JsonProperty("city")]
		public City City { get; set; }

		[JsonProperty("thumbnail")]
		public string Thumbnail { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}

	public class Location
	{
		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public int Type { get; set; }

		[JsonProperty("latitude")]
		public string Latitude { get; set; }

		[JsonProperty("longitude")]
		public string Longitude { get; set; }

		[JsonProperty("parentId")]
		public string ParentId { get; set; }

		[JsonProperty("countryId")]
		public string CountryId { get; set; }

		[JsonProperty("provider")]
		public int Provider { get; set; }

		[JsonProperty("isTopRegion")]
		public bool IsTopRegion { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }
	}

	public class Market
	{
		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
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

	public class Nationality
	{
		[JsonProperty("twoLetterCode")]
		public string TwoLetterCode { get; set; }
	}

	public class NetPrice
	{
		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class Office
	{
		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}

	public class Operator
	{
		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("agencyCanDiscountCommission")]
		public bool AgencyCanDiscountCommission { get; set; }
	}

	public class PassengerAmountToPay
	{
		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class PassengerBalance
	{
		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class PassengerEB
	{
		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class PassengerPriceToPay
	{
		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class PassportInfo
	{
		[JsonProperty("expireDate")]
		public DateTime ExpireDate { get; set; }

		[JsonProperty("issueDate")]
		public DateTime IssueDate { get; set; }

		[JsonProperty("citizenshipCountryCode")]
		public string CitizenshipCountryCode { get; set; }
	}

	public class PaymentDetail
	{
		[JsonProperty("paymentPlan")]
		public List<PaymentPlan> PaymentPlan { get; set; }

		[JsonProperty("paymentInfo")]
		public List<object> PaymentInfo { get; set; }
	}

	public class PaymentPlan
	{
		[JsonProperty("paymentNo")]
		public int PaymentNo { get; set; }

		[JsonProperty("dueDate")]
		public DateTime DueDate { get; set; }

		[JsonProperty("price")]
		public Price Price { get; set; }

		[JsonProperty("paymentStatus")]
		public bool PaymentStatus { get; set; }
	}

	public class Price
	{
		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("percent")]
		public double Percent { get; set; }
	}

	public class PriceToPay
	{
		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class PromotionAmount
	{
		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class ReservableInfo
	{
		[JsonProperty("reservable")]
		public bool Reservable { get; set; }
	}

	public class ReservationData
	{
		[JsonProperty("travellers")]
		public List<Traveller> Travellers { get; set; }

		[JsonProperty("reservationInfo")]
		public ReservationInfo ReservationInfo { get; set; }

		[JsonProperty("services")]
		public List<Service> Services { get; set; }

		[JsonProperty("paymentDetail")]
		public PaymentDetail PaymentDetail { get; set; }

		[JsonProperty("invoices")]
		public List<object> Invoices { get; set; }
	}

	public class ReservationInfo
	{
		[JsonProperty("bookingNumber")]
		public string BookingNumber { get; set; }

		[JsonProperty("market")]
		public Market Market { get; set; }

		[JsonProperty("operator")]
		public Operator Operator { get; set; }

		[JsonProperty("agency")]
		public Agency Agency { get; set; }

		[JsonProperty("agencyUser")]
		public AgencyUser AgencyUser { get; set; }

		[JsonProperty("beginDate")]
		public DateTime BeginDate { get; set; }

		[JsonProperty("endDate")]
		public DateTime EndDate { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }

		[JsonProperty("salePrice")]
		public SalePrice SalePrice { get; set; }

		[JsonProperty("supplementDiscount")]
		public SupplementDiscount SupplementDiscount { get; set; }

		[JsonProperty("passengerEB")]
		public PassengerEB PassengerEB { get; set; }

		[JsonProperty("agencyEB")]
		public AgencyEB AgencyEB { get; set; }

		[JsonProperty("passengerAmountToPay")]
		public PassengerAmountToPay PassengerAmountToPay { get; set; }

		[JsonProperty("agencyAmountToPay")]
		public AgencyAmountToPay AgencyAmountToPay { get; set; }

		[JsonProperty("discount")]
		public Discount Discount { get; set; }

		[JsonProperty("agencyBalance")]
		public AgencyBalance AgencyBalance { get; set; }

		[JsonProperty("passengerBalance")]
		public PassengerBalance PassengerBalance { get; set; }

		[JsonProperty("agencyCommission")]
		public AgencyCommission AgencyCommission { get; set; }

		[JsonProperty("brokerCommission")]
		public BrokerCommission BrokerCommission { get; set; }

		[JsonProperty("agencySupplementCommission")]
		public AgencySupplementCommission AgencySupplementCommission { get; set; }

		[JsonProperty("promotionAmount")]
		public PromotionAmount PromotionAmount { get; set; }

		[JsonProperty("priceToPay")]
		public PriceToPay PriceToPay { get; set; }

		[JsonProperty("agencyPriceToPay")]
		public AgencyPriceToPay AgencyPriceToPay { get; set; }

		[JsonProperty("passengerPriceToPay")]
		public PassengerPriceToPay PassengerPriceToPay { get; set; }

		[JsonProperty("totalPrice")]
		public TotalPrice TotalPrice { get; set; }

		[JsonProperty("reservationStatus")]
		public int ReservationStatus { get; set; }

		[JsonProperty("confirmationStatus")]
		public int ConfirmationStatus { get; set; }

		[JsonProperty("paymentStatus")]
		public int PaymentStatus { get; set; }

		[JsonProperty("documents")]
		public List<object> Documents { get; set; }

		[JsonProperty("otherDocuments")]
		public List<object> OtherDocuments { get; set; }

		[JsonProperty("reservableInfo")]
		public ReservableInfo ReservableInfo { get; set; }

		[JsonProperty("paymentFrom")]
		public int PaymentFrom { get; set; }

		[JsonProperty("departureCountry")]
		public DepartureCountry DepartureCountry { get; set; }

		[JsonProperty("departureCity")]
		public DepartureCity DepartureCity { get; set; }

		[JsonProperty("arrivalCountry")]
		public ArrivalCountry ArrivalCountry { get; set; }

		[JsonProperty("arrivalCity")]
		public ArrivalCity ArrivalCity { get; set; }

		[JsonProperty("createDate")]
		public DateTime CreateDate { get; set; }

		[JsonProperty("changeDate")]
		public DateTime ChangeDate { get; set; }

		[JsonProperty("additionalFields")]
		public AdditionalFields AdditionalFields { get; set; }

		[JsonProperty("additionalCode1")]
		public string AdditionalCode1 { get; set; }

		[JsonProperty("additionalCode2")]
		public string AdditionalCode2 { get; set; }

		[JsonProperty("additionalCode3")]
		public string AdditionalCode3 { get; set; }

		[JsonProperty("additionalCode4")]
		public string AdditionalCode4 { get; set; }

		[JsonProperty("agencyDiscount")]
		public double AgencyDiscount { get; set; }

		[JsonProperty("hasAvailablePromotionCode")]
		public bool HasAvailablePromotionCode { get; set; }
	}

	public class Root
	{
		[JsonProperty("body")]
		public Body Body { get; set; }

		[JsonProperty("header")]
		public Header Header { get; set; }
	}

	public class SalePrice
	{
		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class Service
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("type")]
		public int Type { get; set; }

		[JsonProperty("price")]
		public Price Price { get; set; }

		[JsonProperty("passengerType")]
		public int PassengerType { get; set; }

		[JsonProperty("orderNumber")]
		public int OrderNumber { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }

		[JsonProperty("departureCountry")]
		public DepartureCountry DepartureCountry { get; set; }

		[JsonProperty("departureCity")]
		public DepartureCity DepartureCity { get; set; }

		[JsonProperty("arrivalCountry")]
		public ArrivalCountry ArrivalCountry { get; set; }

		[JsonProperty("arrivalCity")]
		public ArrivalCity ArrivalCity { get; set; }

		[JsonProperty("serviceDetails")]
		public ServiceDetails ServiceDetails { get; set; }

		[JsonProperty("partnerServiceId")]
		public string PartnerServiceId { get; set; }

		[JsonProperty("isMainService")]
		public bool IsMainService { get; set; }

		[JsonProperty("isRefundable")]
		public bool IsRefundable { get; set; }

		[JsonProperty("bundle")]
		public bool Bundle { get; set; }

		[JsonProperty("cancellationPolicies")]
		public List<CancellationPolicy> CancellationPolicies { get; set; }

		[JsonProperty("documents")]
		public List<object> Documents { get; set; }

		[JsonProperty("encryptedServiceNumber")]
		public string EncryptedServiceNumber { get; set; }

		[JsonProperty("priceBreakDowns")]
		public List<object> PriceBreakDowns { get; set; }

		[JsonProperty("commission")]
		public double Commission { get; set; }

		[JsonProperty("reservableInfo")]
		public ReservableInfo ReservableInfo { get; set; }

		[JsonProperty("unit")]
		public int Unit { get; set; }

		[JsonProperty("conditionalSpos")]
		public List<object> ConditionalSpos { get; set; }

		[JsonProperty("isThirdPartyOwnProvider")]
		public bool IsThirdPartyOwnProvider { get; set; }

		[JsonProperty("isThirdPartyOwnOffer")]
		public bool IsThirdPartyOwnOffer { get; set; }

		[JsonProperty("thirdPartyInformation")]
		public ThirdPartyInformation ThirdPartyInformation { get; set; }

		[JsonProperty("confirmationStatus")]
		public int ConfirmationStatus { get; set; }

		[JsonProperty("serviceStatus")]
		public int ServiceStatus { get; set; }

		[JsonProperty("productType")]
		public int ProductType { get; set; }

		[JsonProperty("createServiceTypeIfNotExists")]
		public bool CreateServiceTypeIfNotExists { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("beginDate")]
		public DateTime BeginDate { get; set; }

		[JsonProperty("endDate")]
		public DateTime EndDate { get; set; }

		[JsonProperty("adult")]
		public int Adult { get; set; }

		[JsonProperty("child")]
		public int Child { get; set; }

		[JsonProperty("infant")]
		public int Infant { get; set; }

		[JsonProperty("netPrice")]
		public NetPrice NetPrice { get; set; }

		[JsonProperty("includePackage")]
		public bool IncludePackage { get; set; }

		[JsonProperty("compulsory")]
		public bool Compulsory { get; set; }

		[JsonProperty("isExtraService")]
		public bool IsExtraService { get; set; }

		[JsonProperty("supplierCode")]
		public string SupplierCode { get; set; }

		[JsonProperty("supplierName")]
		public string SupplierName { get; set; }

		[JsonProperty("supplier")]
		public string Supplier { get; set; }

		[JsonProperty("provider")]
		public int Provider { get; set; }

		[JsonProperty("travellers")]
		public List<string> Travellers { get; set; }

		[JsonProperty("thirdPartyRecord")]
		public bool ThirdPartyRecord { get; set; }

		[JsonProperty("recordId")]
		public int RecordId { get; set; }

		[JsonProperty("additionalFields")]
		public AdditionalFields AdditionalFields { get; set; }
	}

	public class ServiceDetails
	{
		[JsonProperty("serviceId")]
		public string ServiceId { get; set; }

		[JsonProperty("thumbnail")]
		public string Thumbnail { get; set; }

		[JsonProperty("hotelDetail")]
		public HotelDetail HotelDetail { get; set; }

		[JsonProperty("night")]
		public int Night { get; set; }

		[JsonProperty("roomCode")]
		public string RoomCode { get; set; }

		[JsonProperty("room")]
		public string Room { get; set; }

		[JsonProperty("boardCode")]
		public string BoardCode { get; set; }

		[JsonProperty("board")]
		public string Board { get; set; }

		[JsonProperty("accom")]
		public string Accom { get; set; }

		[JsonProperty("star")]
		public string Star { get; set; }

		[JsonProperty("geoLocation")]
		public Geolocation GeoLocation { get; set; }
	}

	public class SupplementDiscount
	{
		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class ThirdPartyInformation
	{
		[JsonProperty("infos")]
		public List<object> Infos { get; set; }
	}

	public class TotalPrice
	{
		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }
	}

	public class TransferLocation
	{
		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public int Type { get; set; }

		[JsonProperty("latitude")]
		public string Latitude { get; set; }

		[JsonProperty("longitude")]
		public string Longitude { get; set; }

		[JsonProperty("parentId")]
		public string ParentId { get; set; }

		[JsonProperty("countryId")]
		public string CountryId { get; set; }

		[JsonProperty("provider")]
		public int Provider { get; set; }

		[JsonProperty("isTopRegion")]
		public bool IsTopRegion { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }
	}

	public class Traveller
	{
		[JsonProperty("travellerId")]
		public string TravellerId { get; set; }

		[JsonProperty("type")]
		public int Type { get; set; }

		[JsonProperty("title")]
		public int Title { get; set; }

		[JsonProperty("availableTitles")]
		public List<AvailableTitle> AvailableTitles { get; set; }

		[JsonProperty("availableAcademicTitles")]
		public List<object> AvailableAcademicTitles { get; set; }

		[JsonProperty("isLeader")]
		public bool IsLeader { get; set; }

		[JsonProperty("birthDate")]
		public DateTime BirthDate { get; set; }

		[JsonProperty("nationality")]
		public Nationality Nationality { get; set; }

		[JsonProperty("identityNumber")]
		public string IdentityNumber { get; set; }

		[JsonProperty("passportInfo")]
		public PassportInfo PassportInfo { get; set; }

		[JsonProperty("address")]
		public Address Address { get; set; }

		[JsonProperty("destinationAddress")]
		public DestinationAddress DestinationAddress { get; set; }

		[JsonProperty("services")]
		public List<Service> Services { get; set; }

		[JsonProperty("orderNumber")]
		public int OrderNumber { get; set; }

		[JsonProperty("birthDateFrom")]
		public DateTime BirthDateFrom { get; set; }

		[JsonProperty("birthDateTo")]
		public DateTime BirthDateTo { get; set; }

		[JsonProperty("requiredFields")]
		public List<string> RequiredFields { get; set; }

		[JsonProperty("documents")]
		public List<object> Documents { get; set; }

		[JsonProperty("passengerType")]
		public int PassengerType { get; set; }

		[JsonProperty("additionalFields")]
		public AdditionalFields AdditionalFields { get; set; }

		[JsonProperty("insertFields")]
		public List<object> InsertFields { get; set; }

		[JsonProperty("status")]
		public int Status { get; set; }
	}


}