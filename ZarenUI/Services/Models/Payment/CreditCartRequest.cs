using Newtonsoft.Json;

namespace ZarenUI.Services.Models.CreditCart
{
  

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CardInfo
    {
        [JsonProperty("ExpiryMonth")]
        public string ExpiryMonth { get; set; }

        [JsonProperty("ExpiryYear")]
        public string ExpiryYear { get; set; }

        [JsonProperty("CardNo")]
        public string CardNo { get; set; }

        [JsonProperty("CardHolderFirstName")]
        public string CardHolderFirstName { get; set; }

        [JsonProperty("CardHolderLastName")]
        public string CardHolderLastName { get; set; }

        [JsonProperty("CvvNo")]
        public string CvvNo { get; set; }
    }

    public class CreditCartRequest
    {
        [JsonProperty("TransactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("PaymentOption")]
        public int PaymentOption { get; set; }

        [JsonProperty("PaymentTypeId")]
        public string PaymentTypeId { get; set; }

        [JsonProperty("Installment")]
        public int Installment { get; set; }

        [JsonProperty("CardInfo")]
        public CardInfo CardInfo { get; set; }

        [JsonProperty("SuccessUrl")]
        public string SuccessUrl { get; set; }

        [JsonProperty("ErrorUrl")]
        public string ErrorUrl { get; set; }
    }


}
