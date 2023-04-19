using MongoDB.Bson;
using Newtonsoft.Json;

namespace ZarenUI.Services.Models.Payment.GetPaymentOptionDetail 
{
   

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Body
    {
        [JsonProperty("detail")]
        public List<Detail> Detail { get; set; }
    }

    public class Detail
    {
        [JsonProperty("options")]
        public List<Option> Options { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
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

    public class Option
    {
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("paymentTypes")]
        public List<PaymentType> PaymentTypes { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class PaymentType
    {
        [JsonProperty("paymentCurrency")]
        public string PaymentCurrency { get; set; }

        [JsonProperty("secure3D")]
        public bool Secure3D { get; set; }

        [JsonProperty("instalment")]
        public List<int> Instalment { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("pricebyBankCurrency")]
        public PricebyBankCurrency PricebyBankCurrency { get; set; }

        [JsonProperty("creditCardName")]
        public string CreditCardName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Price
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class PricebyBankCurrency
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class GetPaymentOptionDetailResponse
	{
	 
		[JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }
    }


}
