using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Font
    {
        [JsonPropertyName("family")]
        public string Family;

        [JsonPropertyName("size")]
        public string Size;

        [JsonPropertyName("weight")]
        public string Weight;
    }

}