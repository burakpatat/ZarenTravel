using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paximum.Response.OfferDetail
{

    public class GetOfferDetailsResponse
    {
        public Header header { get; set; }
        public Body body { get; set; }
    }

    public class Header
    {
        public string requestId { get; set; }
        public bool success { get; set; }
        public DateTime responseTime { get; set; }
        public Message[] messages { get; set; }
    }

    public class Message
    {
        public int id { get; set; }
        public string code { get; set; }
        public int messageType { get; set; }
        public string message { get; set; }
    }

    public class Body
    {
        public Offerdetail[] offerDetails { get; set; }
    }

    public class Offerdetail
    {
        public DateTime expiresOn { get; set; }
        public string offerId { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public bool isSpecial { get; set; }
        public bool isAvailable { get; set; }
        public bool isRefundable { get; set; }
        public Passengeramounttopay passengerAmountToPay { get; set; }
        public Agencycommission agencyCommission { get; set; }
        public Agencysupplementcommission agencySupplementCommission { get; set; }
        public Hotel[] hotels { get; set; }
        public Extraservice[] extraServices { get; set; }
        public Cancellationpolicy[] cancellationPolicies { get; set; }
        public Pricebreakdown1[] priceBreakdowns { get; set; }
        public int provider { get; set; }
        public Paymentdetail paymentDetail { get; set; }
    }

    public class Passengeramounttopay
    {
        public decimal? amount { get; set; }
        public string currency { get; set; }
    }

    public class Agencycommission
    {
        public int percent { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Agencysupplementcommission
    {
        public int percent { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Paymentdetail
    {
        public Paymentplan[] paymentPlan { get; set; }
        public object[] paymentInfo { get; set; }
    }

    public class Paymentplan
    {
        public int paymentNo { get; set; }
        public DateTime dueDate { get; set; }
        public Price price { get; set; }
        public bool paymentStatus { get; set; }
    }

    public class Price
    {
        public int percent { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Hotel
    {
        public Season[] seasons { get; set; }
        public Address address { get; set; }
        public string faxNumber { get; set; }
        public string phoneNumber { get; set; }
        public string homePage { get; set; }
        public Room[] rooms { get; set; }
        public int stopSaleGuaranteed { get; set; }
        public int stopSaleStandart { get; set; }
        public Geolocation1 geolocation { get; set; }
        public float stars { get; set; }
        public float rating { get; set; }
        public object[] themes { get; set; }
        public Location location { get; set; }
        public Country country { get; set; }
        public City1 city { get; set; }
        public Giatainfo giataInfo { get; set; }
        public Offer[] offers { get; set; }
        public int provider { get; set; }
        public string thumbnail { get; set; }
        public string thumbnailFull { get; set; }
        public Description description { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Address
    {
        public City city { get; set; }
        public string[] addressLines { get; set; }
        public string street { get; set; }
        public Geolocation geolocation { get; set; }
    }

    public class City
    {
        public string name { get; set; }
        public int provider { get; set; }
        public bool isTopRegion { get; set; }
    }

    public class Geolocation
    {
        public string longitude { get; set; }
        public string latitude { get; set; }
    }

    public class Geolocation1
    {
        public string longitude { get; set; }
        public string latitude { get; set; }
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

    public class Country
    {
        public string name { get; set; }
        public int provider { get; set; }
        public bool isTopRegion { get; set; }
        public string id { get; set; }
    }

    public class City1
    {
        public string name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int provider { get; set; }
        public bool isTopRegion { get; set; }
        public string id { get; set; }
    }

    public class Giatainfo
    {
        public string hotelId { get; set; }
        public string destinationId { get; set; }
    }

    public class Description
    {
        public string text { get; set; }
    }

    public class Season
    {
        public string name { get; set; }
        public Textcategory[] textCategories { get; set; }
        public Mediafile[] mediaFiles { get; set; }
    }

    public class Textcategory
    {
        public string name { get; set; }
        public Presentation[] presentations { get; set; }
    }

    public class Presentation
    {
        public int textType { get; set; }
        public string text { get; set; }
    }

    public class Mediafile
    {
        public int fileType { get; set; }
        public string url { get; set; }
        public string urlFull { get; set; }
    }

    public class Room
    {
        public object[] presentations { get; set; }
        public Facility[] facilities { get; set; }
        public Mediafile1[] mediaFiles { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Facility
    {
        public string name { get; set; }
    }

    public class Mediafile1
    {
        public int fileType { get; set; }
        public string urlFull { get; set; }
    }

    public class Offer
    {
        public bool isAvailable { get; set; }
        public int availability { get; set; }
        public Room1[] rooms { get; set; }
        public bool isRefundable { get; set; }
    }

    public class Room1
    {
        public string roomId { get; set; }
        public string roomName { get; set; }
        public string boardId { get; set; }
        public string boardName { get; set; }
        public Traveller[] travellers { get; set; }
        public string roomInfoId { get; set; }
    }

    public class Traveller
    {
        public int type { get; set; }
        public int minAge { get; set; }
        public int maxAge { get; set; }
    }

    public class Extraservice
    {
        public bool compulsory { get; set; }
        public bool free { get; set; }
        public Offer1[] offers { get; set; }
        public string code { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Offer1
    {
        public Pricebreakdown priceBreakDown { get; set; }
        public int willBePayAt { get; set; }
        public DateTime checkIn { get; set; }
        public Price2 price { get; set; }
    }

    public class Pricebreakdown
    {
        public Item[] items { get; set; }
    }

    public class Item
    {
        public int type { get; set; }
        public Price1 price { get; set; }
    }

    public class Price1
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Price2
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Cancellationpolicy
    {
        public string roomNumber { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime dueDate { get; set; }
        public Price3 price { get; set; }
        public int provider { get; set; }
    }

    public class Price3
    {
        public int percent { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class Pricebreakdown1
    {
        public string roomNumber { get; set; }
        public DateTime date { get; set; }
        public Price4 price { get; set; }
    }

    public class Price4
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

}
