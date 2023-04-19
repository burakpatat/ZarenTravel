using System;
using System.Collections.Generic;
using System.Text;

namespace Zaren.Application.Services.getproductinfo
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Board
    {
        public List<Presentation> presentations { get; set; }
        public List<MediaFile> mediaFiles { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }

    public class Body
    {
        public Hotel hotel { get; set; }
    }

    public class City
    {
        public string name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int provider { get; set; }
        public bool isTopRegion { get; set; }
        public string id { get; set; }
    }

    public class Country
    {
        public string name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int provider { get; set; }
        public bool isTopRegion { get; set; }
        public string id { get; set; }
    }

    public class Facility
    {
        public string id { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public bool isPriced { get; set; }
        public bool highlighted { get; set; }
        public string unit { get; set; }
    }

    public class FacilityCategory
    {
        public string name { get; set; }
        public List<Facility> facilities { get; set; }
        public string id { get; set; }
    }

    public class Geolocation
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

    public class Hotel
    {
        public List<Season> seasons { get; set; }
        public string faxNumber { get; set; }
        public string phoneNumber { get; set; }
        public string homePage { get; set; }
        public List<Room> rooms { get; set; }
        public List<Board> boards { get; set; }
        public int stopSaleGuaranteed { get; set; }
        public int stopSaleStandart { get; set; }
        public List<PaymentPlanInfo> paymentPlanInfo { get; set; }
        public Geolocation geolocation { get; set; }
        public Location location { get; set; }
        public Country country { get; set; }
        public City city { get; set; }
        public Town town { get; set; }
        public HotelCategory hotelCategory { get; set; }
        public string code { get; set; }
        public int provider { get; set; }
        public string thumbnail { get; set; }
        public string thumbnailFull { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class HotelCategory
    {
        public string name { get; set; }
        public string id { get; set; }
        public string code { get; set; }
    }

    public class Location
    {
        public string name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int provider { get; set; }
        public bool isTopRegion { get; set; }
        public string id { get; set; }
    }

    public class MediaFile
    {
        public int fileType { get; set; }
        public string url { get; set; }
        public string urlFull { get; set; }
    }

    public class Message
    {
        public int id { get; set; }
        public string code { get; set; }
        public int messageType { get; set; }
        public string message { get; set; }
    }

    public class PaymentPlanInfo
    {
        public int id { get; set; }
        public int phase { get; set; }
        public int day { get; set; }
        public int paymentTimeStatus { get; set; }
        public Price price { get; set; }
    }

    public class Presentation
    {
        public int textType { get; set; }
        public string text { get; set; }
    }

    public class Price
    {
        public double percent { get; set; }
        public int amount { get; set; }
    }

    public class Room
    {
        public List<Presentation> presentations { get; set; }
        public List<Facility> facilities { get; set; }
        public List<MediaFile> mediaFiles { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }

    public class RootGetProductInfo
    {
        public Body body { get; set; }
        public Header header { get; set; }
    }

    public class Season
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public List<TextCategory> textCategories { get; set; }
        public List<FacilityCategory> facilityCategories { get; set; }
        public List<MediaFile> mediaFiles { get; set; }
        public List<Theme> themes { get; set; }
    }

    public class TextCategory
    {
        public string code { get; set; }
        public string name { get; set; }
        public List<Presentation> presentations { get; set; }
    }

    public class Theme
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Town
    {
        public string name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int provider { get; set; }
        public bool isTopRegion { get; set; }
        public string id { get; set; }
    }

}
