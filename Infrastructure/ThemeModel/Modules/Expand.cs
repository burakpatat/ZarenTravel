using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Expand
    {
        [JsonPropertyName("status")]
        public bool Status;

        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("toggleTitle")]
        public string ToggleTitle;

        [JsonPropertyName("class")]
        public string Class;
    }

}