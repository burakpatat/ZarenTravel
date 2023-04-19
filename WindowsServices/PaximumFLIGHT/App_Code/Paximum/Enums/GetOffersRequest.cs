using Newtonsoft.Json;

namespace Paximum.Enums
{
    public class GetOffersRequest
    {
        [JsonProperty("searchId")]
        public string SearchId { get; set; }

        [JsonProperty("offerId")]
        public string OfferId { get; set; }

        [JsonProperty("productType")]
        public int ProductType { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("culture")]
        public string Culture { get; set; }

        [JsonProperty("getRoomInfo")]
        public bool GetRoomInfo { get; set; }
    }


}
