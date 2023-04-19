using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrawler.Paximum.App_Code.Paximum.FlightRequest
{
    public class GetOffersFlightRequest
    {

            [JsonProperty("productType")]
            public int ProductType { get; set; }

            [JsonProperty("searchId")]
            public string SearchId { get; set; }

            [JsonProperty("offerIds")]
            public List<string> OfferIds { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("culture")]
            public string Culture { get; set; }


    }
}
