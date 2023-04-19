using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Request.ByHotel
{
     
    public class PriceSearchByHotelRequest
    {
        public bool checkAllotment { get; set; }
        public bool checkStopSale { get; set; }
        public bool getOnlyDiscountedPrice { get; set; }
        public bool getOnlyBestOffers { get; set; }
        public int productType { get; set; }
        public string[] Products { get; set; }
        public List<Roomcriteria>  roomCriteria { get; set; }
        public string nationality { get; set; }
        public string checkIn { get; set; }
        public int night { get; set; }
        public string currency { get; set; }
        public string culture { get; set; }
    }

    public class Roomcriteria
    {
        public int adult { get; set; }
    }

}
