using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrawler.Paximum.App_Code.Paximum.FlightResponse
{
    public class GetArrivalAutoCompleteResponse
    {
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

        public class Root
        {
            [JsonProperty("header")]
            public Header Header { get; set; }

            [JsonProperty("body")]
            public Body Body { get; set; }
        }


    }
}
