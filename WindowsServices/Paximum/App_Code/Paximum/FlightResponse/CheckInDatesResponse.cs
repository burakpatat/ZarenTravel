using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrawler.Paximum.FlightResponse
{
    public class CheckInDatesResponse
    {
        //[JsonProperty("dates")]
        //public List<DateTime> Dates { get; set; }
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

            [JsonProperty("messages")]
            public List<Message> Messages { get; set; }
        }
        public class Root
        {
            [JsonProperty("header")]
            public Header Header { get; set; }

            [JsonProperty("body")]
            public Body Body { get; set; }
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

    }
   
}
