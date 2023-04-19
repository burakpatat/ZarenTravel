using Newtonsoft.Json;

namespace CheckInResponse
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Body
    {
        [JsonProperty("dates")]
        public List<DateTime> Dates { get; set; }
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

    public class CheckInDatesResponse
    {
        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("header")]
        public Header Header { get; set; }
    }


   
}

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
namespace CheckInRequest
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

    public class CheckInDateRequest
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
