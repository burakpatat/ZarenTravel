using System.Text.Json.Serialization; 
namespace Builder{ 

    public class ResponsiveStyles
    {
        [JsonPropertyName("large")]
        public Large Large;

        [JsonPropertyName("medium")]
        public Medium Medium;

        [JsonPropertyName("small")]
        public Small Small;
    }

}