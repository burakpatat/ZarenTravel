using Newtonsoft.Json;


namespace ArrivalAutoComplete
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Airport
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Body
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class Geolocation
    {
        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }
    }

    public class Header
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("messages")]
        public List<Message> Messages { get; set; }
    }

    public class Item
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("geolocation")]
        public Geolocation Geolocation { get; set; }

        [JsonProperty("airport")]
        public Airport Airport { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }
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

    public class ArrivalAutoCompleteResponse
    {
        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }
    }


}

public class DepartureLocation
{
    [JsonProperty("type")]
    public int Type { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}