using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Header
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("hasScrollClass")]
        public string HasScrollClass;
    }

}