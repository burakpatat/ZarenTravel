using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrawler.Paximum.App_Code.Paximum.FlightRequest.PriceSearchsRequest
{
    public class GetPriceSearchRoundtripRequest
    {
        public class ArrivalLocation
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("type")]
            public int Type { get; set; }

            [JsonProperty("provider")]
            public int Provider { get; set; }
        }

        public class DepartureLocation
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("type")]
            public int Type { get; set; }
        }

        public class Passenger
        {
            [JsonProperty("type")]
            public int Type { get; set; }

            [JsonProperty("count")]
            public int Count { get; set; }
        }

        public class Root
        {
            [JsonProperty("ProductType")]
            public int ProductType { get; set; }

            [JsonProperty("ServiceTypes")]
            public List<string> ServiceTypes { get; set; }

            [JsonProperty("CheckIn")]
            public string CheckIn { get; set; }

            [JsonProperty("Night")]
            public int Night { get; set; }

            [JsonProperty("DepartureLocations")]
            public List<DepartureLocation> DepartureLocations { get; set; }

            [JsonProperty("ArrivalLocations")]
            public List<ArrivalLocation> ArrivalLocations { get; set; }

            [JsonProperty("Passengers")]
            public List<Passenger> Passengers { get; set; }

            [JsonProperty("acceptPendingProviders")]
            public bool AcceptPendingProviders { get; set; }

            [JsonProperty("Culture")]
            public string Culture { get; set; }

            [JsonProperty("Currency")]
            public string Currency { get; set; }
        }
    }
}
