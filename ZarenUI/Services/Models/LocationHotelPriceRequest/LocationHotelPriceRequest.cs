namespace SanTsgHotelBooking.Application.Models.LocationHotelPriceRequest
{
    public class LocationHotelPriceRequest
    {
        public bool checkAllotment { get; set; } 
        public bool checkStopSale { get; set; } 
        public bool getOnlyDiscountedPrice { get; set; } 
        public bool getOnlyBestOffers { get; set; } 
        public int productType { get; set; } 
        public List<ArrivalLocation> arrivalLocations { get; set; }
        public List<RoomCriterion> roomCriteria { get; set; } 
        public string nationality { get; set; } 
        public string checkIn { get; set; }
        public int night { get; set; }
        public string currency { get; set; }
        public string culture { get; set; }
    }
    public class ArrivalLocation
    {
        public string id { get; set; }
        public int type { get; set; } = 2;
    }

    public class RoomCriterion
    {
        public int adult { get; set; }
        public List<int> childAges { get; set; }
    }
}


//namespace SanTsgHotelBooking.Application.Models.LocationHotelPriceRequest
//{
//    public class LocationHotelPriceRequest
//    {
//        public bool checkAllotment { get; set; } = true;
//        public bool checkStopSale { get; set; } = true;
//        public bool getOnlyDiscountedPrice { get; set; } = false;
//        public bool getOnlyBestOffers { get; set; } = true;
//        public int productType { get; set; } = 2;
//        public List<ArrivalLocation> arrivalLocations { get; set; } = new List<ArrivalLocation> { new ArrivalLocation { id = "23494", type = 2 } };
//        public List<RoomCriterion> roomCriteria { get; set; }
//        public string nationality { get; set; } = "DE";
//        public string checkIn { get; set; }
//        public int night { get; set; }
//        public string currency { get; set; }
//        public string culture { get; set; }
//    }
//    public class ArrivalLocation
//    {
//        public string id { get; set; }
//        public int type { get; set; } = 2;
//    }

//    public class RoomCriterion
//    {
//        public int adult { get; set; }
//        public List<int> childAges { get; set; }
//    }
//}
