using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace  Paximum.Response
{
    public class GetArrivalAutocompleteResponse
    {
        [JsonProperty("header")]
        public Header Header { get; set; }
        [JsonProperty("body")]
        public Body Body { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
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

    public class Country
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

    public class GiataInfo
    {
        [JsonProperty("hotelId")]
        public string HotelId { get; set; }

        [JsonProperty("destinationId")]
        public string DestinationId { get; set; }
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

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("giataInfo")]
        public GiataInfo GiataInfo { get; set; }

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

    public class State
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }




}
