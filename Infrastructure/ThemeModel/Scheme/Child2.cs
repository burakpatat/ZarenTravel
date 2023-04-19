using System.Text.Json.Serialization; 
namespace Builder{ 

    public class Child2
    {
        [JsonPropertyName("@type")]
        public string Type;

        [JsonPropertyName("@version")]
        public int Version;

        [JsonPropertyName("layerName")]
        public string LayerName;

        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("component")]
        public Component Component;

        [JsonPropertyName("responsiveStyles")]
        public ResponsiveStyles ResponsiveStyles;
    }

}