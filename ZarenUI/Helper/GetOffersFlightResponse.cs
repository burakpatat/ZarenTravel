

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using Newtonsoft.Json;

namespace FlightOffers
{
    public class BaggageInformation
    {
        [JsonProperty("segmentId")]
        public string SegmentId { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("piece")]
        public int Piece { get; set; }

        [JsonProperty("baggageType")]
        public int BaggageType { get; set; }

        [JsonProperty("unitType")]
        public int UnitType { get; set; }

        [JsonProperty("passengerType")]
        public int PassengerType { get; set; }
    }

    public class Body
    {
        [JsonProperty("offers")]
        public List<Offer> Offers { get; set; }
    }

    public class Explanation
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Feature
    {
        [JsonProperty("commercialName")]
        public string CommercialName { get; set; }

        [JsonProperty("serviceGroup")]
        public int ServiceGroup { get; set; }

        [JsonProperty("pricingType")]
        public int PricingType { get; set; }

        [JsonProperty("explanations")]
        public List<Explanation> Explanations { get; set; }
    }

    public class FlightBrandInfo
    {
        [JsonProperty("features")]
        public List<Feature> Features { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class FlightClassInformation
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("segmentId")]
        public string SegmentId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class Header
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("responseTime")]
        public DateTime ResponseTime { get; set; }

        [JsonProperty("messages")]
        public List<Message> Messages { get; set; }
    }

    public class Message
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("messageType")]
        public int MessageType { get; set; }

        [JsonProperty("message")]
        public string Messages { get; set; }
    }

    public class Offer
    {
        [JsonProperty("flightId")]
        public string FlightId { get; set; }

        [JsonProperty("segmentNumber")]
        public int SegmentNumber { get; set; }

        [JsonProperty("flightClassInformations")]
        public List<FlightClassInformation> FlightClassInformations { get; set; }

        [JsonProperty("baggageInformations")]
        public List<BaggageInformation> BaggageInformations { get; set; }

        [JsonProperty("groupKeys")]
        public List<string> GroupKeys { get; set; }

        [JsonProperty("offerIds")]
        public List<OfferId> OfferIds { get; set; }

        [JsonProperty("isPackageOffer")]
        public bool IsPackageOffer { get; set; }

        [JsonProperty("route")]
        public int Route { get; set; }

        [JsonProperty("flightBrandInfo")]
        public FlightBrandInfo FlightBrandInfo { get; set; }

        [JsonProperty("offerId")]
        public string OfferId { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }
    }

    public class OfferId
    {
        [JsonProperty("groupKey")]
        public string GroupKey { get; set; }

        [JsonProperty("offerId")]
        public string OfferIdItem { get; set; }
    }

    public class Price
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class GetOffersFlightResponse
    {
        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("header")]
        public Header Header { get; set; }
    }


}