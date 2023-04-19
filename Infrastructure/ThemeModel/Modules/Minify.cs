using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Minify
    {
        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("toggledClass")]
        public string ToggledClass;

        [JsonPropertyName("cookieName")]
        public string CookieName;
    }

}