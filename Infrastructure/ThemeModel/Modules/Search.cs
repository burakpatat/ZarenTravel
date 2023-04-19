using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Search
    {
        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("hideClass")]
        public string HideClass;

        [JsonPropertyName("foundClass")]
        public string FoundClass;
    }

}