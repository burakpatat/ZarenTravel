using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrawler.Paximum.App_Code.Paximum.FlightRequest.PriceSearchsRequest
{
    
        public class AdditionalParameters
        {
            [JsonProperty("getOptionsParameters")]
            public GetOptionsParameters GetOptionsParameters { get; set; }
        }

        public class ArrivalLocation
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("type")]
            public int Type { get; set; }
        }

        public class DepartureLocation
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("type")]
            public int Type { get; set; }
        }

        public class GetOptionsParameters
        {
            [JsonProperty("flightBaggageGetOption")]
            public int FlightBaggageGetOption { get; set; }
        }

        public class Passenger
        {
            [JsonProperty("type")]
            public int Type { get; set; }

            [JsonProperty("count")]
            public int Count { get; set; }
        }

        public class GetPriceSearchOneWayRequest
    {
            [JsonProperty("ProductType")]
            public int ProductType { get; set; }

            [JsonProperty("ServiceTypes")]
            public List<string> ServiceTypes { get; set; }

            [JsonProperty("CheckIn")]
            public string CheckIn { get; set; }

            [JsonProperty("DepartureLocations")]
            public List<DepartureLocation> DepartureLocations { get; set; }

            [JsonProperty("ArrivalLocations")]
            public List<ArrivalLocation> ArrivalLocations { get; set; }

            [JsonProperty("Passengers")]
            public List<Passenger> Passengers { get; set; }

            [JsonProperty("additionalParameters")]
            public AdditionalParameters AdditionalParameters { get; set; }

            [JsonProperty("acceptPendingProviders")]
            public bool AcceptPendingProviders { get; set; }

            [JsonProperty("forceFlightBundlePackage")]
            public bool ForceFlightBundlePackage { get; set; }

            [JsonProperty("disablePackageOfferTotalPrice")]
            public bool DisablePackageOfferTotalPrice { get; set; }

            [JsonProperty("calculateFlightFees")]
            public bool CalculateFlightFees { get; set; }

            [JsonProperty("Culture")]
            public string Culture { get; set; }

            [JsonProperty("Currency")]
            public string Currency { get; set; }
        }


    
}
