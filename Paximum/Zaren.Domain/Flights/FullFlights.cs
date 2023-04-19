using System;
using System.Collections.Generic;
using System.Text;

namespace Zaren.Domain.Flights
{
    public class Airline
    {
        public string InternationalCode { get; set; }
        public string Thumbnail { get; set; }
        public string ThumbnailFull { get; set; }
        public string Logo { get; set; }
        public string LogoFull { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Airport
    {
        public GeoLocation Geolocation { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Code { get; set; }
    }

    public class AirportTax
    {
        public double Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Arrival
    {
        public Country Country { get; set; }
        public City City { get; set; }
        public Airport Airport { get; set; }
        public DateTime Date { get; set; }
        public GeoLocation GeoLocation { get; set; }
    }

    public class BaggageInformation
    {
        public string SegmentId { get; set; }
        public int Weight { get; set; }
        public int Piece { get; set; }
        public int BaggageType { get; set; }
        public int UnitType { get; set; }
        public int PassengerType { get; set; }
        public string Description { get; set; }
    }

    public class Body
    {
        public string SearchId { get; set; }
        public DateTime ExpiresOn { get; set; }
        public List<Flight> Flights { get; set; }
        public Details Details { get; set; }
        public List<Item> items { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
        public int Provider { get; set; }
        public bool IsTopRegion { get; set; }
        public string Id { get; set; }
        public string CountryId { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }
        public int Provider { get; set; }
        public bool IsTopRegion { get; set; }
        public string Id { get; set; }
    }

    public class Departure
    {
        public Country Country { get; set; }
        public City City { get; set; }
        public Airport Airport { get; set; }
        public DateTime Date { get; set; }
        public GeoLocation GeoLocation { get; set; }
    }

    public class Details
    {
        public int FlightResponseListType { get; set; }
        public bool EnablePaging { get; set; }
    }

    public class Explanation
    {
        public string Text { get; set; }
    }

    public class Flight
    {
        public int Provider { get; set; }
        public string Id { get; set; }
        public List<Item> Items { get; set; }
        public List<Offer> Offers { get; set; }
        public List<string> GroupKeys { get; set; }
    }

    public class FlightBrandInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class FlightClass
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Code { get; set; }
    }

    public class FlightClassInformation
    {
        public int Type { get; set; }
        public string SegmentId { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Code { get; set; }
    }

    public class FlightProvider
    {
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class GeoLocation
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }

    public class GeoLocation2
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }

    public class Header
    {
        public string RequestId { get; set; }
        public bool Success { get; set; }
        public DateTime ResponseTime { get; set; }
        public List<Message> Messages { get; set; }
    }

    public class Item
    {
        public int type { get; set; }
        public GeoLocation geolocation { get; set; }
        public Airport airport { get; set; }
        public int provider { get; set; } = 3;//tek yön
        public int SegmentNumber { get; set; }
        public string FlightNo { get; set; }
        public string PnlName { get; set; }
        public DateTime FlightDate { get; set; }
        public Airline Airline { get; set; }
        public MarketingAirline MarketingAirline { get; set; }
        public int Duration { get; set; }
        public int DayChange { get; set; }
        public Departure Departure { get; set; }
        public Arrival Arrival { get; set; }
        public FlightClass FlightClass { get; set; }
        public int Route { get; set; }
        public List<Segment> Segments { get; set; }
        public int StopCount { get; set; }
        public FlightProvider FlightProvider { get; set; }
        public List<BaggageInformation> BaggageInformations { get; set; }
        public List<Passenger> Passengers { get; set; }
        public int FlightType { get; set; }
        public int PassengerType { get; set; }
        public int PassengerCount { get; set; }
        public Price Price { get; set; }
        public AirportTax AirportTax { get; set; }
        public City City { get; set; }
    }

    public class MarketingAirline
    {
        public string InternationalCode { get; set; }
        public string Thumbnail { get; set; }
        public string ThumbnailFull { get; set; }
        public string Logo { get; set; }
        public string LogoFull { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Message
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int MessageType { get; set; }
        public string MessageText { get; set; }
    }

    public class Offer
    {
        public int SegmentNumber { get; set; }
        public SingleAdultPrice SingleAdultPrice { get; set; }
        public PriceBreakDown PriceBreakDown { get; set; }
        public ServiceFee ServiceFee { get; set; }
        public SeatInfo SeatInfo { get; set; }
        public List<FlightClassInformation> FlightClassInformations { get; set; }
        public List<BaggageInformation> BaggageInformations { get; set; }
        public List<Service> Services { get; set; }
        public ReservableInfo ReservableInfo { get; set; }
        public List<string> GroupKeys { get; set; }
        public bool IsPackageOffer { get; set; }
        public bool HasBrand { get; set; }
        public int Route { get; set; }
        public FlightProvider FlightProvider { get; set; }
        public FlightBrandInfo FlightBrandInfo { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string OfferId { get; set; }
        public Price Price { get; set; }
        public int Provider { get; set; }
    }

    public class Passenger
    {
        public int Type { get; set; }
        public int Count { get; set; }
    }

    public class Price
    {
        public double Amount { get; set; }
        public string Currency { get; set; }
    }

    public class PriceBreakDown
    {
        public List<Item> Items { get; set; }
    }

    public class ReservableInfo
    {
        public bool Reservable { get; set; }
    }

    public class Root
    {
        public Body Body { get; set; }
        public Header Header { get; set; }
    }

    public class SeatInfo
    {
        public int AvailableSeatCount { get; set; }
        public int AvailableSeatCountType { get; set; }
    }

    public class Segment
    {
        public string Id { get; set; }
        public string FlightNo { get; set; }
        public string PnlName { get; set; }
        public FlightClass FlightClass { get; set; }
        public Airline Airline { get; set; }
        public MarketingAirline MarketingAirline { get; set; }
        public Departure Departure { get; set; }
        public Arrival Arrival { get; set; }
        public int Duration { get; set; }
        public List<BaggageInformation> BaggageInformations { get; set; }
        public List<Service> Services { get; set; }
        public string Aircraft { get; set; }
    }

    public class Service
    {
        public List<string> Segments { get; set; }
        public List<Explanation> Explanations { get; set; }
        public string Thumbnail { get; set; }
        public string ThumbnailFull { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class ServiceFee
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
    }

    public class SingleAdultPrice
    {
        public double Amount { get; set; }
        public string Currency { get; set; }
    }

}
