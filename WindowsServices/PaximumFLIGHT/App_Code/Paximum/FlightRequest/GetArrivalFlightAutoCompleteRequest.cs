using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrawler.Paximum.App_Code.Paximum.FlightRequest
{
    public class GetArrivalFlightAutoCompleteRequest
    {
        public class DepartureLocation
        {
            [JsonProperty("type")]
            public int Type { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }
        }

        public class Root
        {
            [JsonProperty("ProductType")]
            public int ProductType { get; set; }

            [JsonProperty("Query")]
            public string Query { get; set; }

            [JsonProperty("ServiceType")]
            public string ServiceType { get; set; }

            [JsonProperty("DepartureLocations")]
            public List<DepartureLocation> DepartureLocations { get; set; }

            [JsonProperty("Culture")]
            public string Culture { get; set; }
        }
    }
}
