using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Request.ByLocation;

namespace Paximum.Request
{
    public class GetOfferHotelDetailRequest
    { 
        public string searchId { get; set; }
        public string offerId { get; set; }
        public int productType { get; set; }
        public string productId { get; set; }
        public string currency { get; set; }
        public string culture { get; set; }
        public bool getRoomInfo { get; set; }
    }
    public class GetOffersRequest
    {
        public string searchId { get; set; }
        public string offerId { get; set; }
        public int productType { get; set; }
        public string productId { get; set; }
        public string currency { get; set; }
        public string culture { get; set; }
        public bool getRoomInfo { get; set; }
    }
    public class RootQ
    {
        public bool checkAllotment { get; set; } = true;
        public bool checkStopSale { get; set; } = true;
        public bool getOnlyDiscountedPrice { get; set; } = false;
        public bool getOnlyBestOffers { get; set; } = true;
        public int productType { get; set; } = 2;
        public List<string> Products { get; set; } = new List<string>() { };
        public List<RoomCriterion> roomCriteria { get; set; } = new List<RoomCriterion>() { new RoomCriterion { adult = 2 } };
        public string nationality { get; set; } = "TR";
        public string currency { get; set; } = "TRY";
        public string culture { get; set; } = "tr-TR";
        public string checkIn { get; set; }
        public int night { get; set; } = 7;
    }
    public class RoomCriterion
    {
        public int adult { get; set; }
    }
    public class EarlyRoot
    {
        public bool checkAllotment { get; set; } = true;
        public bool checkStopSale { get; set; } = true;
        public bool getOnlyDiscountedPrice { get; set; } = false;
        public bool getOnlyBestOffers { get; set; } = true;
        public int productType { get; set; } = 2;
        public List<dynamic> arrivalLocations { get; set; } = new List<dynamic>() { new { } };
        public List<RoomCriterion> roomCriteria { get; set; } = new List<RoomCriterion>() { new RoomCriterion { adult = 2 } };
        public string nationality { get; set; } = "TR";
        public string checkIn { get; set; }
        public int night { get; set; } = 7;
        public string currency { get; set; } = "TRY";
        public string culture { get; set; } = "tr-TR";
    }
    public class AllHotelQueryDTO
    {
        public string Id { get; set; }
        public int NumberOfTravellers { get; set; } = 1;
        public string CityName { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime ChcekOut { get; set; }
    }
}
