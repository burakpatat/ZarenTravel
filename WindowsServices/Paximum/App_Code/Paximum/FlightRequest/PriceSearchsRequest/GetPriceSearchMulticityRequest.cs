using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrawler.Paximum.App_Code.Paximum.FlightRequest.PriceSearchsRequest
{
    public class GetPriceSearchMulticityRequest
    {
        public class ArrivalLocation
        {
            [JsonProperty("type")]
            public int Type { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }
        }

        public class DepartureLocation
        {
            [JsonProperty("type")]
            public int Type { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }
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
            [JsonProperty("serviceTypes")]
            public List<string> ServiceTypes { get; set; }

            [JsonProperty("productType")]
            public int ProductType { get; set; }

            [JsonProperty("arrivalLocations")]
            public List<ArrivalLocation> ArrivalLocations { get; set; }

            [JsonProperty("departureLocations")]
            public List<DepartureLocation> DepartureLocations { get; set; }

            [JsonProperty("passengers")]
            public List<Passenger> Passengers { get; set; }

            [JsonProperty("checkIns")]
            public List<string> CheckIns { get; set; }

            [JsonProperty("calculateFlightFees")]
            public bool CalculateFlightFees { get; set; }

            [JsonProperty("acceptPendingProviders")]
            public bool AcceptPendingProviders { get; set; }

            [JsonProperty("forceFlightBundlePackage")]
            public bool ForceFlightBundlePackage { get; set; }

            [JsonProperty("disablePackageOfferTotalPrice")]
            public bool DisablePackageOfferTotalPrice { get; set; }

            [JsonProperty("supportedFlightReponseListTypes")]
            public List<int> SupportedFlightReponseListTypes { get; set; }

            [JsonProperty("culture")]
            public string Culture { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }
        }


    }
}
