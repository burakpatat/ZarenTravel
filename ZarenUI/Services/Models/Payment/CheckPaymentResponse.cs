using Newtonsoft.Json;

namespace ZarenUI.Services.Models.Payment
{
     

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Body
    {
        [JsonProperty("paymentTransactionId")]
        public string PaymentTransactionId { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
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

    public class CheckPaymentResponse
    {
        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("header")]
        public Header Header { get; set; }
    }


}
