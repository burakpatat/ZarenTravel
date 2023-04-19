using Newtonsoft.Json;

namespace ZarenUI.Services.Models.Reservation
{
    

    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class AdditionalFields
    {
        [JsonProperty("travellerTypeOrder")]
        public object TravellerTypeOrder { get; set; }

        [JsonProperty("travellerUniqueID")]
        public object TravellerUniqueID { get; set; }

        [JsonProperty("tourVisio_TravellerId")]
        public object TourVisioTravellerId { get; set; }

        [JsonProperty("smsLimit")]
        public object SmsLimit { get; set; }

        [JsonProperty("priceChanged")]
        public object PriceChanged { get; set; }

        [JsonProperty("allowSalePriceEdit")]
        public object AllowSalePriceEdit { get; set; }

        [JsonProperty("allowAgencyCanRes")]
        public object AllowAgencyCanRes { get; set; }

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
        public object ContactPhone { get; set; }

        [JsonProperty("email")]
        public object Email { get; set; }

        [JsonProperty("address")]
        public string Addresss { get; set; }

        [JsonProperty("zipCode")]
        public object ZipCode { get; set; }

        [JsonProperty("city")]
        public object City { get; set; }

        [JsonProperty("country")]
        public object Country { get; set; }

        [JsonProperty("phone")]
        public object Phone { get; set; }

        [JsonProperty("addressLines")]
        public List<string> AddressLines { get; set; }
    }

    public class ArrivalCity
    {
        [JsonProperty("code")]
        public object Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("latitude")]
        public object Latitude { get; set; }

        [JsonProperty("longitude")]
        public object Longitude { get; set; }

        [JsonProperty("parentId")]
        public object ParentId { get; set; }

        [JsonProperty("countryId")]
        public object CountryId { get; set; }

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

        [JsonProperty("latitude")]
        public object Latitude { get; set; }

        [JsonProperty("longitude")]
        public object Longitude { get; set; }

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

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

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

    public class Country
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("internationalCode")]
        public object InternationalCode { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }

        [JsonProperty("isTopRegion")]
        public bool IsTopRegion { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("latitude")]
        public object Latitude { get; set; }

        [JsonProperty("longitude")]
        public object Longitude { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        [JsonProperty("countryId")]
        public string CountryId { get; set; }
    }

    public class DepartureCity
    {
        [JsonProperty("code")]
        public object Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("latitude")]
        public object Latitude { get; set; }

        [JsonProperty("longitude")]
        public object Longitude { get; set; }

        [JsonProperty("parentId")]
        public object ParentId { get; set; }

        [JsonProperty("countryId")]
        public object CountryId { get; set; }

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

        [JsonProperty("latitude")]
        public object Latitude { get; set; }

        [JsonProperty("longitude")]
        public object Longitude { get; set; }

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

    public class HotelDetail
    {
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("transferLocation")]
        public TransferLocation TransferLocation { get; set; }

        [JsonProperty("stopSaleGuaranteed")]
        public int StopSaleGuaranteed { get; set; }

        [JsonProperty("stopSaleStandart")]
        public int StopSaleStandart { get; set; }

        [JsonProperty("geolocation")]
        public Geolocation Geolocation { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

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

    public class NetPrice
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
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

    public class ReservableInfo
    {
        [JsonProperty("reservable")]
        public bool Reservable { get; set; }
    }

    public class ReservationDetail
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("ticketNo")]
        public object TicketNo { get; set; }

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

        [JsonProperty("providerBookingID")]
        public object ProviderBookingID { get; set; }

        [JsonProperty("supplierBookingNumber")]
        public object SupplierBookingNumber { get; set; }

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

        [JsonProperty("hotelDetail")]
        public HotelDetail HotelDetail { get; set; }

        [JsonProperty("night")]
        public int Night { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonProperty("board")]
        public string Board { get; set; }

        [JsonProperty("accom")]
        public string Accom { get; set; }

        [JsonProperty("geoLocation")]
        public GeoLocation GeoLocation { get; set; }
    }
    public class GeoLocation
    {
        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }
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


}
