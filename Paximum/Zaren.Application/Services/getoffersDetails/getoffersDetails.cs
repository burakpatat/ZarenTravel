using System;
using System.Collections.Generic;
using System.Text;
using Zaren.Application.Services.getoffers;

namespace Zaren.Application.Services.getoffersDetails
{
    using System;
    using System.Collections.Generic;
    using System.Text;


        public class Badge
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Board
        {
            public string id { get; set; }
        }

        public class BoardGroup
        {
            public string id { get; set; }
            public string name { get; set; }
        }
        public class Body
        {
            public string searchId { get; set; }
            public DateTime expiresOn { get; set; }
            public List<Hotel> hotels { get; set; }
            public Details details { get; set; }
            public List<OfferDetail> offerDetails { get; set; }
        }
        public class OfferDetail
        {
            public DateTime expiresOn { get; set; }
            public string offerId { get; set; }
            public DateTime checkIn { get; set; }
            public DateTime checkOut { get; set; }
            public bool isSpecial { get; set; }
            public bool isAvailable { get; set; }
            public bool isRefundable { get; set; }
            public string notes { get; set; }
            public Price price { get; set; }
            public List<Hotel> hotels { get; set; }
            public List<Room> rooms { get; set; }
            public List<CancellationPolicy> cancellationPolicies { get; set; }
            public List<PriceBreakdown> priceBreakdowns { get; set; }
            public ThirdPartyInformation thirdPartyInformation { get; set; }
        }
        public class Address
        {
            public City city { get; set; }
            public List<string> addressLines { get; set; }
            public string street { get; set; }
            public string streetNumber { get; set; }
            public string zipCode { get; set; }
            public Geolocation geolocation { get; set; }
        }
        public class PriceBreakdown
        {
            public string roomNumber { get; set; }
            public DateTime date { get; set; }
            public Price price { get; set; }
        }

        public class CancellationPolicy
        {
            public DateTime dueDate { get; set; }
            public Price price { get; set; }
            public int provider { get; set; }
        }

        public class City
        {
            public string name { get; set; }
            public string countryId { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Country
        {
            public string internationalCode { get; set; }
            public string name { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
        }

        public class Description
        {
            public string text { get; set; }
        }

        public class Details
        {
            public bool enablePaging { get; set; }
        }

        public class Facility
        {
            public bool isPriced { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Geolocation
        {
            public string longitude { get; set; }
            public string latitude { get; set; }
        }

        public class GiataInfo
        {
            public string hotelId { get; set; }
            public string destinationId { get; set; }
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
            public Geolocation geolocation { get; set; }
            public float stars { get; set; }
            public double rating { get; set; }
            public List<Facility> facilities { get; set; }
            public Location location { get; set; }
            public Country country { get; set; }
            public City city { get; set; }
            public GiataInfo giataInfo { get; set; }
            public List<Offer> offers { get; set; }
            public List<OfferDetail> offerDetails { get; set; }
            public List<BoardGroup> boardGroups { get; set; }
            public List<Board> boards { get; set; }
            public HotelCategory hotelCategory { get; set; }
            public bool hasThirdPartyOwnOffer { get; set; }
            public ThirdPartyInformation thirdPartyInformation { get; set; }
            public int provider { get; set; }
            public string thumbnail { get; set; }
            public string thumbnailFull { get; set; }
            public Description description { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public List<Badge> badges { get; set; }
            public List<Theme> themes { get; set; }
            public List<MediaFiles> mediaFiles { get; set; }
            public List<Address> addressList { get; set; }
            public Address address { get; set; }
            public Price price { get; set; }
            public List<Season> seasons { get; set; }
        }
        public class Season
        {
            public string name { get; set; }
            public List<TextCategory> textCategories { get; set; }
            public List<FacilityCategory> facilityCategories { get; set; }
            public List<MediaFiles> mediaFiles { get; set; }
        }
        public class FacilityCategory
        {
            public string name { get; set; }
            public List<Facility> facilities { get; set; }
        }
        public class TextCategory
        {
            public string name { get; set; }
            public List<Presentation> presentations { get; set; }
        }
        public class Presentation
        {
            public int textType { get; set; }
            public string text { get; set; }
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
            public string countryId { get; set; }
            public int provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Message
        {
            public int id { get; set; }
            public string code { get; set; }
            public int messageType { get; set; }
            public string message { get; set; }
        }

        public class Offer
        {
            public int night { get; set; }
            public bool isAvailable { get; set; }
            public int availability { get; set; }
            public List<Room> rooms { get; set; }
            public bool isRefundable { get; set; }
            public List<CancellationPolicy> cancellationPolicies { get; set; }
            public List<object> restrictions { get; set; }
            public DateTime expiresOn { get; set; }
            public string offerId { get; set; }
            public string adress { get; set; }
            public List<Address> addresses { get; set; }
            public DateTime checkIn { get; set; }
            public Price price { get; set; }
            public int provider { get; set; }
            public float stars { get; set; }
            public List<Theme> themes { get; set; }
            public List<MediaFiles> mediaFiles { get; set; }
            public List<Facility> facilities { get; set; }
        }

        public class Price
        {
            public double amount { get; set; }
            public string currency { get; set; }
        }

        public class Room
        {
            public string roomId { get; set; }
            public string roomName { get; set; }
            public string boardId { get; set; }
            public string boardName { get; set; }
            public List<BoardGroup> boardGroups { get; set; }
            public int stopSaleGuaranteed { get; set; }
            public int stopSaleStandart { get; set; }
            public List<Traveller> travellers { get; set; }
            public List<Facility> facilities { get; set; }
            public Price price { get; set; }
        }

        public class Root
        {
            public Body body { get; set; }
            public Header header { get; set; }
        }

        public class Theme
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class ThirdPartyInformation
        {
            public List<object> infos { get; set; }
        }

        public class Traveller
        {
            public int type { get; set; }
            public int age { get; set; }
            public string nationality { get; set; }
            public int minAge { get; set; }
            public int maxAge { get; set; }
        }

        public class MediaFiles
        {
            public int fileType { get; set; }
            public string url { get; set; }
            public string urlFull { get; set; }
        }

        public class GetDetailsResponse
        {
            public Body body { get; set; }
            public Header header { get; set; }
        }
}
