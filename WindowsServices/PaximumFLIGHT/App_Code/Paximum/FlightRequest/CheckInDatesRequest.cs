using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrawler.Paximum.FlightRequest
{
    
        public class ArrivalLocation
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("Type")]
            public int Type { get; set; }
        }

        public class DepartureLocation
        {
            [JsonProperty("Id")]
            public string Id { get; set; }

            [JsonProperty("Type")]
            public int Type { get; set; }
        }

        public class CheckInDatesRequest
        {
            [JsonProperty("ProductType")]
            public int ProductType { get; set; }

            [JsonProperty("ServiceType")]
            public string ServiceType { get; set; }

            [JsonProperty("DepartureLocations")]
            public List<DepartureLocation> DepartureLocations { get; set; }

            [JsonProperty("ArrivalLocations")]
            public List<ArrivalLocation> ArrivalLocations { get; set; }
        }


     
}
