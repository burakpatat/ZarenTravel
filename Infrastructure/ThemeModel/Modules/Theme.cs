using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Theme
    {
        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("classAttr")]
        public string ClassAttr;

        [JsonPropertyName("cookieName")]
        public string CookieName;

        [JsonPropertyName("activeClass")]
        public string ActiveClass;
    }

}