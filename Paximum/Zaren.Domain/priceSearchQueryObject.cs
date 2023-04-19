using System;
using System.Collections.Generic;
using System.Text;

namespace Zaren.Domain
{
   
        public class RoomCriterion
        {
            public int adult { get; set; }
        }

    public class GetOfferDetailsRequest
    {
        public string offerIds { get; set; }
        public string currency { get; set; }
        public bool getProductInfo { get; set; }
    }


    public class RootQ
    {
        public bool checkAllotment { get; set; } = true;
        public bool checkStopSale { get; set; } = true;
        public bool getOnlyDiscountedPrice { get; set; } = false;
        public bool getOnlyBestOffers { get; set; } = true;
        public int productType { get; set; } = 2;
        public List<string> Products { get; set; }=new List<string>() { };
        public List<RoomCriterion> roomCriteria { get; set; } = new List<RoomCriterion>() { new RoomCriterion { adult=2} };
        public string nationality { get; set; } = "TR";
        public string currency { get; set; } = "TRY";
        public string culture { get; set; } = "tr-TR";
        public string checkIn { get; set; }
        public int night { get; set; } = 7;
    }

    
}
