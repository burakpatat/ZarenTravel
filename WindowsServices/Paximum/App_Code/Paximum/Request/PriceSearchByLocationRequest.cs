using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace   Request.ByLocation
{

    public class PriceSearchByLocationRequest
    {
        [JsonProperty("checkAllotment")]
        public bool CheckAllotment { get; set; }

        [JsonProperty("checkStopSale")]
        public bool CheckStopSale { get; set; }

        [JsonProperty("getOnlyDiscountedPrice")]
        public bool GetOnlyDiscountedPrice { get; set; }

        [JsonProperty("getOnlyBestOffers")]
        public bool GetOnlyBestOffers { get; set; }

        [JsonProperty("productType")]
        public int ProductType { get; set; }

        [JsonProperty("arrivalLocations")]
        public List<ArrivalLocation> ArrivalLocations { get; set; }

        [JsonProperty("roomCriteria")]
        public List<RoomCriterion> RoomCriteria { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("checkIn")]
        public string CheckIn { get; set; }

        [JsonProperty("night")]
        public int Night { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("culture")]
        public string Culture { get; set; }
    }

    public class RoomCriterion
    {
        [JsonProperty("adult")]
        public int Adult { get; set; }

        [JsonProperty("childAges")]
        public List<int> ChildAges { get; set; }
    }
    public class ArrivalLocation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }
    }

}
