using Newtonsoft.Json;

namespace ZarenUI.Services.Models.AgencyCredit 
{
    

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Body
    {
        [JsonProperty("options")]
        public List<int> Options { get; set; }
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

    public class AgencyCreditResponse
    {
        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("header")]
        public Header Header { get; set; }
    }


}
