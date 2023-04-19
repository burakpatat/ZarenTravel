﻿using Newtonsoft.Json;

namespace OneWayReq
{ 
    public class AdditionalParameters
    {
        [JsonProperty("getOptionsParameters")]
        public GetOptionsParameters GetOptionsParameters { get; set; }
    }

    public class ArrivalLocation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }
    }

    public class DepartureLocation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }
    }

    public class GetOptionsParameters
    {
        [JsonProperty("flightBaggageGetOption")]
        public int FlightBaggageGetOption { get; set; }
    }

    public class Passenger
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public class OneWayRequest
    {
        [JsonProperty("ProductType")]
        public int ProductType { get; set; }

        [JsonProperty("ServiceTypes")]
        public List<string> ServiceTypes { get; set; }

        [JsonProperty("CheckIn")]
        public string CheckIn { get; set; }

        [JsonProperty("DepartureLocations")]
        public List<DepartureLocation> DepartureLocations { get; set; }

        [JsonProperty("ArrivalLocations")]
        public List<ArrivalLocation> ArrivalLocations { get; set; }

        [JsonProperty("Passengers")]
        public List<Passenger> Passengers { get; set; }

        [JsonProperty("additionalParameters")]
        public AdditionalParameters AdditionalParameters { get; set; }

        [JsonProperty("acceptPendingProviders")]
        public bool AcceptPendingProviders { get; set; }

        [JsonProperty("forceFlightBundlePackage")]
        public bool ForceFlightBundlePackage { get; set; }

        [JsonProperty("disablePackageOfferTotalPrice")]
        public bool DisablePackageOfferTotalPrice { get; set; }

        [JsonProperty("calculateFlightFees")]
        public bool CalculateFlightFees { get; set; }

        [JsonProperty("flightClasses")]
        public List<int> FlightClasses { get; set; }

        [JsonProperty("Culture")]
        public string Culture { get; set; }

        [JsonProperty("Currency")]
        public string Currency { get; set; }
    }


}

namespace OneWayRes
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Airline
    {
        [JsonProperty("internationalCode")]
        public string InternationalCode { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("thumbnailFull")]
        public string ThumbnailFull { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("logoFull")]
        public string LogoFull { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Airport
    {
        [JsonProperty("geolocation")]
        public Geolocation Geolocation { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class AirportTax
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class Arrival
    {
        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("airport")]
        public Airport Airport { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("geoLocation")]
        public Geolocation GeoLocation { get; set; }
    }

    public class BaggageInformation
    {
        [JsonProperty("segmentId")]
        public string SegmentId { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("piece")]
        public int Piece { get; set; }

        [JsonProperty("baggageType")]
        public int BaggageType { get; set; }

        [JsonProperty("unitType")]
        public int UnitType { get; set; }

        [JsonProperty("passengerType")]
        public int PassengerType { get; set; }
    }

    public class Body
    {
        [JsonProperty("searchId")]
        public string SearchId { get; set; }

        [JsonProperty("expiresOn")]
        public DateTime ExpiresOn { get; set; }

        [JsonProperty("flights")]
        public List<Flight> Flights { get; set; }
    }

    public class City
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }

        [JsonProperty("isTopRegion")]
        public bool IsTopRegion { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }

        [JsonProperty("isTopRegion")]
        public bool IsTopRegion { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Departure
    {
        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("airport")]
        public Airport Airport { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("geoLocation")]
        public Geolocation GeoLocation { get; set; }
    }

    public class Fees
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("oneWay")]
        public OneWay OneWay { get; set; }
    }

    public class Flight
    {
        [JsonProperty("provider")]
        public int Provider { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("offers")]
        public List<Offer> Offers { get; set; }

        [JsonProperty("groupKeys")]
        public List<string> GroupKeys { get; set; }
    }

    public class FlightBrandInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class FlightClass
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class FlightClassInformation
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("segmentId")]
        public string SegmentId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class FlightProvider
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Geolocation
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

    public class Item
    {
        [JsonProperty("segmentNumber")]
        public int SegmentNumber { get; set; }

        [JsonProperty("flightNo")]
        public string FlightNo { get; set; }

        [JsonProperty("pnlName")]
        public string PnlName { get; set; }

        [JsonProperty("flightDate")]
        public DateTime FlightDate { get; set; }

        [JsonProperty("airline")]
        public Airline Airline { get; set; }

        [JsonProperty("marketingAirline")]
        public MarketingAirline MarketingAirline { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("dayChange")]
        public int DayChange { get; set; }

        [JsonProperty("departure")]
        public Departure Departure { get; set; }

        [JsonProperty("arrival")]
        public Arrival Arrival { get; set; }

        [JsonProperty("flightClass")]
        public FlightClass FlightClass { get; set; }

        [JsonProperty("route")]
        public int Route { get; set; }

        [JsonProperty("segments")]
        public List<Segment> Segments { get; set; }

        [JsonProperty("stopCount")]
        public int StopCount { get; set; }

        [JsonProperty("flightProvider")]
        public FlightProvider FlightProvider { get; set; }

        [JsonProperty("baggageInformations")]
        public List<BaggageInformation> BaggageInformations { get; set; }

        [JsonProperty("passengers")]
        public List<Passenger> Passengers { get; set; }

        [JsonProperty("flightType")]
        public int FlightType { get; set; }

        [JsonProperty("passengerType")]
        public int PassengerType { get; set; }

        [JsonProperty("passengerCount")]
        public int PassengerCount { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("airportTax")]
        public AirportTax AirportTax { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("totalPrice")]
        public double TotalPrice { get; set; }
    }

    public class MarketingAirline
    {
        [JsonProperty("internationalCode")]
        public string InternationalCode { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("thumbnailFull")]
        public string ThumbnailFull { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("logoFull")]
        public string LogoFull { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

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

    public class Offer
    {
        [JsonProperty("segmentNumber")]
        public int SegmentNumber { get; set; }

        [JsonProperty("singleAdultPrice")]
        public SingleAdultPrice SingleAdultPrice { get; set; }

        [JsonProperty("priceBreakDown")]
        public PriceBreakDown PriceBreakDown { get; set; }

        [JsonProperty("serviceFee")]
        public ServiceFee ServiceFee { get; set; }

        [JsonProperty("seatInfo")]
        public SeatInfo SeatInfo { get; set; }

        [JsonProperty("flightClassInformations")]
        public List<FlightClassInformation> FlightClassInformations { get; set; }

        [JsonProperty("baggageInformations")]
        public List<BaggageInformation> BaggageInformations { get; set; }

        [JsonProperty("services")]
        public List<Service> Services { get; set; }

        [JsonProperty("reservableInfo")]
        public ReservableInfo ReservableInfo { get; set; }

        [JsonProperty("groupKeys")]
        public List<string> GroupKeys { get; set; }

        [JsonProperty("fees")]
        public Fees Fees { get; set; }

        [JsonProperty("isPackageOffer")]
        public bool IsPackageOffer { get; set; }

        [JsonProperty("hasBrand")]
        public bool HasBrand { get; set; }

        [JsonProperty("route")]
        public int Route { get; set; }

        [JsonProperty("flightProvider")]
        public FlightProvider FlightProvider { get; set; }

        [JsonProperty("flightBrandInfo")]
        public FlightBrandInfo FlightBrandInfo { get; set; }

        [JsonProperty("expiresOn")]
        public DateTime ExpiresOn { get; set; }

        [JsonProperty("offerId")]
        public string OfferId { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }
    }

    public class OneWay
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }
    }

    public class Passenger
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("ages")]
        public List<object> Ages { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public class Price
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class PriceBreakDown
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class ReservableInfo
    {
        [JsonProperty("reservable")]
        public bool Reservable { get; set; }
    }

    public class OneWayResponse
    {
        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("header")]
        public Header Header { get; set; }
    }

    public class SeatInfo
    {
        [JsonProperty("availableSeatCount")]
        public int AvailableSeatCount { get; set; }

        [JsonProperty("availableSeatCountType")]
        public int AvailableSeatCountType { get; set; }
    }

    public class Segment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("flightNo")]
        public string FlightNo { get; set; }

        [JsonProperty("pnlName")]
        public string PnlName { get; set; }

        [JsonProperty("flightClass")]
        public FlightClass FlightClass { get; set; }

        [JsonProperty("airline")]
        public Airline Airline { get; set; }

        [JsonProperty("marketingAirline")]
        public MarketingAirline MarketingAirline { get; set; }

        [JsonProperty("departure")]
        public Departure Departure { get; set; }

        [JsonProperty("arrival")]
        public Arrival Arrival { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("baggageInformations")]
        public List<BaggageInformation> BaggageInformations { get; set; }

        [JsonProperty("services")]
        public List<Service> Services { get; set; }

        [JsonProperty("aircraft")]
        public string Aircraft { get; set; }
    }

    public class Service
    {
        [JsonProperty("segments")]
        public List<string> Segments { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("thumbnailFull")]
        public string ThumbnailFull { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ServiceFee
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class SingleAdultPrice
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }


}

namespace RoundTripReq
{ // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AdditionalParameters
    {
        [JsonProperty("getOptionsParameters")]
        public GetOptionsParameters GetOptionsParameters { get; set; }
    }

    public class ArrivalLocation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }
    }

    public class DepartureLocation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }
    }

    public class GetOptionsParameters
    {
        [JsonProperty("flightBaggageGetOption")]
        public int FlightBaggageGetOption { get; set; }
    }

    public class Passenger
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public class RoundTripRequest
    {
        [JsonProperty("ProductType")]
        public int ProductType { get; set; }

        [JsonProperty("ServiceTypes")]
        public List<string> ServiceTypes { get; set; }

        [JsonProperty("DepartureLocations")]
        public List<DepartureLocation> DepartureLocations { get; set; }

        [JsonProperty("ArrivalLocations")]
        public List<ArrivalLocation> ArrivalLocations { get; set; }

        [JsonProperty("CheckIn")]
        public string CheckIn { get; set; }

        [JsonProperty("Night")]
        public int Night { get; set; }

        [JsonProperty("Passengers")]
        public List<Passenger> Passengers { get; set; }

        [JsonProperty("acceptPendingProviders")]
        public bool AcceptPendingProviders { get; set; }

        [JsonProperty("forceFlightBundlePackage")]
        public bool ForceFlightBundlePackage { get; set; }

        [JsonProperty("disablePackageOfferTotalPrice")]
        public bool DisablePackageOfferTotalPrice { get; set; }

        [JsonProperty("supportedFlightReponseListTypes")]
        public List<int> SupportedFlightReponseListTypes { get; set; }

        [JsonProperty("additionalParameters")]
        public AdditionalParameters AdditionalParameters { get; set; }

        [JsonProperty("calculateFlightFees")]
        public bool CalculateFlightFees { get; set; }

        [JsonProperty("Culture")]
        public string Culture { get; set; }

        [JsonProperty("Currency")]
        public string Currency { get; set; }
    }

}

namespace RoundTripRes
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Airline
    {
        [JsonProperty("internationalCode")]
        public string InternationalCode { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("thumbnailFull")]
        public string ThumbnailFull { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("logoFull")]
        public string LogoFull { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Airport
    {
        [JsonProperty("geolocation")]
        public GeoLocation Geolocation { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class AirportTax
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class Arrival
    {
        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("airport")]
        public Airport Airport { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("geoLocation")]
        public GeoLocation GeoLocation { get; set; }
    }

    public class BaggageInformation
    {
        [JsonProperty("segmentId")]
        public string SegmentId { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("piece")]
        public int Piece { get; set; }

        [JsonProperty("baggageType")]
        public int BaggageType { get; set; }

        [JsonProperty("unitType")]
        public int UnitType { get; set; }

        [JsonProperty("passengerType")]
        public int PassengerType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Body
    {
        [JsonProperty("searchId")]
        public string SearchId { get; set; }

        [JsonProperty("expiresOn")]
        public DateTime ExpiresOn { get; set; }

        [JsonProperty("flights")]
        public List<Flight> Flights { get; set; }
    }

    public class City
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }

        [JsonProperty("isTopRegion")]
        public bool IsTopRegion { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("countryId")]
        public string CountryId { get; set; }
    }

    public class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }

        [JsonProperty("isTopRegion")]
        public bool IsTopRegion { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Departure
    {
        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("airport")]
        public Airport Airport { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("geoLocation")]
        public GeoLocation GeoLocation { get; set; }
    }

    public class Details
    {
        [JsonProperty("flightResponseListType")]
        public int FlightResponseListType { get; set; }

        [JsonProperty("enablePaging")]
        public bool EnablePaging { get; set; }
    }

    public class Explanation
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
    public class Flight
    {
        [JsonProperty("provider")]
        public int Provider { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("offers")]
        public List<Offer> Offers { get; set; }

        [JsonProperty("groupKeys")]
        public List<string> GroupKeys { get; set; }
    }

    public class FlightBrandInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class FlightClass
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class FlightClassInformation
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("segmentId")]
        public string SegmentId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class FlightProvider
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class GeoLocation
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

    public class Item
    {
        [JsonProperty("segmentNumber")]
        public int SegmentNumber { get; set; }

        [JsonProperty("flightNo")]
        public string FlightNo { get; set; }

        [JsonProperty("pnlName")]
        public string PnlName { get; set; }

        [JsonProperty("flightDate")]
        public DateTime FlightDate { get; set; }

        [JsonProperty("airline")]
        public Airline Airline { get; set; }

        [JsonProperty("marketingAirline")]
        public MarketingAirline MarketingAirline { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("dayChange")]
        public int DayChange { get; set; }

        [JsonProperty("departure")]
        public Departure Departure { get; set; }

        [JsonProperty("arrival")]
        public Arrival Arrival { get; set; }

        [JsonProperty("flightClass")]
        public FlightClass FlightClass { get; set; }

        [JsonProperty("route")]
        public int Route { get; set; }

        [JsonProperty("segments")]
        public List<Segment> Segments { get; set; }

        [JsonProperty("stopCount")]
        public int StopCount { get; set; }

        [JsonProperty("flightProvider")]
        public FlightProvider FlightProvider { get; set; }

        [JsonProperty("baggageInformations")]
        public List<BaggageInformation> BaggageInformations { get; set; }

        [JsonProperty("passengers")]
        public List<Passenger> Passengers { get; set; }

        [JsonProperty("flightType")]
        public int FlightType { get; set; }

        [JsonProperty("passengerType")]
        public int PassengerType { get; set; }

        [JsonProperty("passengerCount")]
        public int PassengerCount { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("airportTax")]
        public AirportTax AirportTax { get; set; }
    }

    public class MarketingAirline
    {
        [JsonProperty("internationalCode")]
        public string InternationalCode { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("thumbnailFull")]
        public string ThumbnailFull { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("logoFull")]
        public string LogoFull { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

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

    public class Offer
    {
        [JsonProperty("segmentNumber")]
        public int SegmentNumber { get; set; }

        [JsonProperty("singleAdultPrice")]
        public SingleAdultPrice SingleAdultPrice { get; set; }

        [JsonProperty("priceBreakDown")]
        public PriceBreakDown PriceBreakDown { get; set; }

        [JsonProperty("serviceFee")]
        public ServiceFee ServiceFee { get; set; }

        [JsonProperty("seatInfo")]
        public SeatInfo SeatInfo { get; set; }

        [JsonProperty("flightClassInformations")]
        public List<FlightClassInformation> FlightClassInformations { get; set; }

        [JsonProperty("baggageInformations")]
        public List<BaggageInformation> BaggageInformations { get; set; }

        [JsonProperty("services")]
        public List<Service> Services { get; set; }

        [JsonProperty("reservableInfo")]
        public ReservableInfo ReservableInfo { get; set; }

        [JsonProperty("groupKeys")]
        public List<string> GroupKeys { get; set; }

        [JsonProperty("offerIds")]
        public List<OfferId> OfferIds { get; set; }

        [JsonProperty("isPackageOffer")]
        public bool IsPackageOffer { get; set; }

        [JsonProperty("hasBrand")]
        public bool HasBrand { get; set; }

        [JsonProperty("route")]
        public int Route { get; set; }

        [JsonProperty("flightProvider")]
        public FlightProvider FlightProvider { get; set; }

        [JsonProperty("flightBrandInfo")]
        public FlightBrandInfo FlightBrandInfo { get; set; }

        [JsonProperty("expiresOn")]
        public DateTime ExpiresOn { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }
    }

    public class OfferId
    {
        [JsonProperty("groupKey")]
        public string GroupKey { get; set; }

        [JsonProperty("offerId")]
        public string OfferIdItem { get; set; }

        [JsonProperty("provider")]
        public Provider Provider { get; set; }
    }

    public class Passenger
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public class Price
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class PriceBreakDown
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class Provider
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ReservableInfo
    {
        [JsonProperty("reservable")]
        public bool Reservable { get; set; }
    }

    public class RoundTripResponse
    {
        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("header")]
        public Header Header { get; set; }
    }

    public class SeatInfo
    {
        [JsonProperty("availableSeatCount")]
        public int AvailableSeatCount { get; set; }

        [JsonProperty("availableSeatCountType")]
        public int AvailableSeatCountType { get; set; }
    }

    public class Segment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("flightNo")]
        public string FlightNo { get; set; }

        [JsonProperty("pnlName")]
        public string PnlName { get; set; }

        [JsonProperty("flightClass")]
        public FlightClass FlightClass { get; set; }

        [JsonProperty("airline")]
        public Airline Airline { get; set; }

        [JsonProperty("marketingAirline")]
        public MarketingAirline MarketingAirline { get; set; }

        [JsonProperty("departure")]
        public Departure Departure { get; set; }

        [JsonProperty("arrival")]
        public Arrival Arrival { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("baggageInformations")]
        public List<BaggageInformation> BaggageInformations { get; set; }

        [JsonProperty("services")]
        public List<Service> Services { get; set; }

        [JsonProperty("aircraft")]
        public string Aircraft { get; set; }
    }

    public class Service
    {
        [JsonProperty("segments")]
        public List<string> Segments { get; set; }

        [JsonProperty("explanations")]
        public List<Explanation> Explanations { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("thumbnailFull")]
        public string ThumbnailFull { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ServiceFee
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class SingleAdultPrice
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }



}

namespace MultiCityReq
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ArrivalLocation
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class DepartureLocation
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Passenger
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public class MultiCityRequest
    {
        [JsonProperty("serviceTypes")]
        public List<string> ServiceTypes { get; set; }

        [JsonProperty("productType")]
        public int ProductType { get; set; }

        [JsonProperty("arrivalLocations")]
        public List<ArrivalLocation> ArrivalLocations { get; set; }

        [JsonProperty("departureLocations")]
        public List<DepartureLocation> DepartureLocations { get; set; }

        [JsonProperty("passengers")]
        public List<Passenger> Passengers { get; set; }

        [JsonProperty("checkIns")]
        public List<string> CheckIns { get; set; }

        [JsonProperty("calculateFlightFees")]
        public bool CalculateFlightFees { get; set; }

        [JsonProperty("acceptPendingProviders")]
        public bool AcceptPendingProviders { get; set; }

        [JsonProperty("forceFlightBundlePackage")]
        public bool ForceFlightBundlePackage { get; set; }

        [JsonProperty("disablePackageOfferTotalPrice")]
        public bool DisablePackageOfferTotalPrice { get; set; }

        [JsonProperty("supportedFlightReponseListTypes")]
        public List<int> SupportedFlightReponseListTypes { get; set; }

        [JsonProperty("culture")]
        public string Culture { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }


}


namespace MultiCityRes
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Airline
    {
        [JsonProperty("internationalCode")]
        public string InternationalCode { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("thumbnailFull")]
        public string ThumbnailFull { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("logoFull")]
        public string LogoFull { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Airport
    {
        [JsonProperty("geolocation")]
        public Geolocation Geolocation { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class AirportTax
    {
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class Arrival
    {
        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("airport")]
        public Airport Airport { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("geoLocation")]
        public Geolocation GeoLocation { get; set; }
    }

    public class BaggageInformation
    {
        [JsonProperty("segmentId")]
        public string SegmentId { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("piece")]
        public int Piece { get; set; }

        [JsonProperty("baggageType")]
        public int BaggageType { get; set; }

        [JsonProperty("unitType")]
        public int UnitType { get; set; }

        [JsonProperty("passengerType")]
        public int PassengerType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Body
    {
        [JsonProperty("searchId")]
        public string SearchId { get; set; }

        [JsonProperty("expiresOn")]
        public DateTime ExpiresOn { get; set; }

        [JsonProperty("flights")]
        public List<Flight> Flights { get; set; }

        [JsonProperty("details")]
        public Details Details { get; set; }
    }

    public class City
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }

        [JsonProperty("isTopRegion")]
        public bool IsTopRegion { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }

        [JsonProperty("isTopRegion")]
        public bool IsTopRegion { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Departure
    {
        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("airport")]
        public Airport Airport { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("geoLocation")]
        public Geolocation GeoLocation { get; set; }
    }

    public class Details
    {
        [JsonProperty("flightResponseListType")]
        public int FlightResponseListType { get; set; }

        [JsonProperty("enablePaging")]
        public bool EnablePaging { get; set; }
    }

    public class Explanation
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Flight
    {
        [JsonProperty("provider")]
        public int Provider { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("offers")]
        public List<Offer> Offers { get; set; }

        [JsonProperty("groupKeys")]
        public List<string> GroupKeys { get; set; }
    }

    public class FlightBrandInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class FlightClass
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class FlightClassInformation
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("segmentId")]
        public string SegmentId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class FlightProvider
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
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

    public class Item
    {
        [JsonProperty("segmentNumber")]
        public int SegmentNumber { get; set; }

        [JsonProperty("flightNo")]
        public string FlightNo { get; set; }

        [JsonProperty("pnlName")]
        public string PnlName { get; set; }

        [JsonProperty("flightDate")]
        public DateTime FlightDate { get; set; }

        [JsonProperty("airline")]
        public Airline Airline { get; set; }

        [JsonProperty("marketingAirline")]
        public MarketingAirline MarketingAirline { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("dayChange")]
        public int DayChange { get; set; }

        [JsonProperty("departure")]
        public Departure Departure { get; set; }

        [JsonProperty("arrival")]
        public Arrival Arrival { get; set; }

        [JsonProperty("flightClass")]
        public FlightClass FlightClass { get; set; }

        [JsonProperty("route")]
        public int Route { get; set; }

        [JsonProperty("segments")]
        public List<Segment> Segments { get; set; }

        [JsonProperty("stopCount")]
        public int StopCount { get; set; }

        [JsonProperty("flightProvider")]
        public FlightProvider FlightProvider { get; set; }

        [JsonProperty("baggageInformations")]
        public List<BaggageInformation> BaggageInformations { get; set; }

        [JsonProperty("passengers")]
        public List<Passenger> Passengers { get; set; }

        [JsonProperty("flightType")]
        public int FlightType { get; set; }

        [JsonProperty("passengerType")]
        public int PassengerType { get; set; }

        [JsonProperty("passengerCount")]
        public int PassengerCount { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("airportTax")]
        public AirportTax AirportTax { get; set; }
    }

    public class MarketingAirline
    {
        [JsonProperty("internationalCode")]
        public string InternationalCode { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("thumbnailFull")]
        public string ThumbnailFull { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("logoFull")]
        public string LogoFull { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

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

    public class Offer
    {
        [JsonProperty("segmentNumber")]
        public int SegmentNumber { get; set; }

        [JsonProperty("singleAdultPrice")]
        public SingleAdultPrice SingleAdultPrice { get; set; }

        [JsonProperty("priceBreakDown")]
        public PriceBreakDown PriceBreakDown { get; set; }

        [JsonProperty("serviceFee")]
        public ServiceFee ServiceFee { get; set; }

        [JsonProperty("seatInfo")]
        public SeatInfo SeatInfo { get; set; }

        [JsonProperty("flightClassInformations")]
        public List<FlightClassInformation> FlightClassInformations { get; set; }

        [JsonProperty("baggageInformations")]
        public List<BaggageInformation> BaggageInformations { get; set; }

        [JsonProperty("services")]
        public List<Service> Services { get; set; }

        [JsonProperty("reservableInfo")]
        public ReservableInfo ReservableInfo { get; set; }

        [JsonProperty("groupKeys")]
        public List<string> GroupKeys { get; set; }

        [JsonProperty("offerIds")]
        public List<OfferId> OfferIds { get; set; }

        [JsonProperty("isPackageOffer")]
        public bool IsPackageOffer { get; set; }

        [JsonProperty("hasBrand")]
        public bool HasBrand { get; set; }

        [JsonProperty("route")]
        public int Route { get; set; }

        [JsonProperty("flightProvider")]
        public FlightProvider FlightProvider { get; set; }

        [JsonProperty("flightBrandInfo")]
        public FlightBrandInfo FlightBrandInfo { get; set; }

        [JsonProperty("expiresOn")]
        public DateTime ExpiresOn { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }
    }

    public class OfferId
    {
        [JsonProperty("groupKey")]
        public string GroupKey { get; set; }

        [JsonProperty("offerId")]
        public string OfferIdItem { get; set; }

        [JsonProperty("provider")]
        public Provider Provider { get; set; }
    }

    public class Passenger
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public class Price
    {
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class PriceBreakDown
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class Provider
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ReservableInfo
    {
        [JsonProperty("reservable")]
        public bool Reservable { get; set; }

        [JsonProperty("optionDate")]
        public DateTime OptionDate { get; set; }
    }

    public class MultiCityResponse
    {
        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }
    }

    public class SeatInfo
    {
        [JsonProperty("availableSeatCount")]
        public int AvailableSeatCount { get; set; }

        [JsonProperty("availableSeatCountType")]
        public int AvailableSeatCountType { get; set; }
    }

    public class Segment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("flightNo")]
        public string FlightNo { get; set; }

        [JsonProperty("pnlName")]
        public string PnlName { get; set; }

        [JsonProperty("flightClass")]
        public FlightClass FlightClass { get; set; }

        [JsonProperty("airline")]
        public Airline Airline { get; set; }

        [JsonProperty("marketingAirline")]
        public MarketingAirline MarketingAirline { get; set; }

        [JsonProperty("departure")]
        public Departure Departure { get; set; }

        [JsonProperty("arrival")]
        public Arrival Arrival { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("baggageInformations")]
        public List<BaggageInformation> BaggageInformations { get; set; }

        [JsonProperty("services")]
        public List<Service> Services { get; set; }

        [JsonProperty("aircraft")]
        public string Aircraft { get; set; }
    }

    public class Service
    {
        [JsonProperty("segments")]
        public List<string> Segments { get; set; }

        [JsonProperty("explanations")]
        public List<Explanation> Explanations { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("thumbnailFull")]
        public string ThumbnailFull { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ServiceFee
    {
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class SingleAdultPrice
    {
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }


}