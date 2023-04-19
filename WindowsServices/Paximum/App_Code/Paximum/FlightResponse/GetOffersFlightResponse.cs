using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrawler.Paximum.App_Code.Paximum.FlightResponse
{
    public class GetOffersFlightResponse
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class BaggageInformation
        {
            public string SegmentId { get; set; }
            public int Weight { get; set; }
            public int Piece { get; set; }
            public int BaggageType { get; set; }
            public int UnitType { get; set; }
            public int PassengerType { get; set; }
        }

        public class Body
        {
            public List<Offer> Offers { get; set; }
        }

        public class Explanation
        {
            public string Text { get; set; }
        }

        public class Feature
        {
            public string CommercialName { get; set; }
            public int ServiceGroup { get; set; }
            public int PricingType { get; set; }
            public List<Explanation> Explanations { get; set; }
        }

        public class FlightBrandInfo
        {
            public List<Feature> Features { get; set; }
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public class FlightClassInformation
        {
            public int Type { get; set; }
            public string SegmentId { get; set; }
            public string Name { get; set; }
            public string Id { get; set; }
            public string Code { get; set; }
        }

        public class Header
        {
            public string RequestId { get; set; }
            public bool Success { get; set; }
            public DateTime ResponseTime { get; set; }
            public List<Message> Messages { get; set; }
        }

        public class Message
        {
            public int Id { get; set; }
            public string Code { get; set; }
            public int MessageType { get; set; }
            public string _Message { get; set; }
        }

        public class Offer
        {
            public string FlightId { get; set; }
            public int SegmentNumber { get; set; }
            public List<FlightClassInformation> FlightClassInformations { get; set; }
            public List<BaggageInformation> BaggageInformations { get; set; }
            public List<string> GroupKeys { get; set; }
            public List<OfferId> OfferIds { get; set; }
            public bool IsPackageOffer { get; set; }
            public int Route { get; set; }
            public FlightBrandInfo FlightBrandInfo { get; set; }
            public string OfferId { get; set; }
            public Price Price { get; set; }
            public int Provider { get; set; }
        }

        public class OfferId
        {
            public string GroupKey { get; set; }
            public string _OfferId { get; set; }
        }

        public class Price
        {
            public double Amount { get; set; }
            public string Currency { get; set; }
        }

        public class Root
        {
            public Body Body { get; set; }
            public Header Header { get; set; }
        }


    }
}
