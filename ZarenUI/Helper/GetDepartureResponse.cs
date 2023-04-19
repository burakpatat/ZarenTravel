using MongoDB.Bson;
using Newtonsoft.Json;


namespace OneWayDepartureResponse
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

    public class City
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
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

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("provider")]
        public int Provider { get; set; }

        [JsonProperty("airport")]
        public Airport Airport { get; set; }
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

    public class GetDepartureResponse
    {
	 

		[JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }
    }


}